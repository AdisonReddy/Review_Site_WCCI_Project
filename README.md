# Reviews Site
Opinions. You know the saying...everyone has one. And the Internet has made them easier to consume, or ignore. Acquisitions, Inc. has many, many products from its years of, well, acquiring things. They have asked you to build a reviews site for some of their current products. The data gathered will help them gain insight into their customer base and the products they have come to enjoy...or enjoy less.

Acquisitions, Inc. requires:
- Development of a MVC Web Application by a team that practices agile methodology, utilizes test driven design, and values clean code
- Appropriate use of Git and access to your application on GitHub
- Useful instructions in the form of a README.md file
- Ability for Users to:
   - view reviews on products
   - create, read, update, and delete their own reviews

## Sprint 1 Deliverable: Product and Review Models

### User Stories
**Product Index View**
- As a user, I would like to see a list of Products, so that I have an index of all the Products that exist.
**Product Details View**
- As a user, I would like to see the details for a chosen Product, so that I can understand more about the Product.

### Details

- Create an MVC Web Application with appropriate NUnit tests.
- Before you add any code, create a dev branch from master (or main). For every new feature you add into your application, create a new feature branch from the dev branch. Note: Each of the steps below would make good feature branches. Keep your feature branches small and focused. They are your "safety net".
- Create a Product model class for the content of products, including a list of reviews. Its properties should include:
   - Id (make this of type int and just use arbitrary, unique numbers for these ids)
   - Name
   - Image (a string of an image URL)
   - Reviews
   - And whatever other things you'd like to include. Some ideas: Date or Description
- Create a Review model class for the reviews held on each product
   - Id
   - Reviewer Name
   - Content

## Sprint 2 Deliverables: Configure your EF Database

### User Stories

**Products Have Many Reviews**
- As a developer, I would like to create a table relationship between Products and Reviews, so that I can easily display Reviews that belong to a particular Product.
**Product Reviews View**
- As a user, I would like to see all Reviews for a chosen Product, so that I can determine if it is a good Product.

### Details

NOTE: Feel free to use appropriate class names other than Product and Review, but these instructions will refer to Product and Review.

A Product can have many Reviews.

For example:

| Product	| Review |
| ------- | ------ |
|Starbucks	| I like it, but its too expensive. |
|Starbucks	| Love it, I go there everyday! |
|Starbucks	| Overrated... |
|Dunkin	| Great, cheap coffee. And they have great donuts. |
|Arabica	| My original favorite, but stores are hard to find. |
|Arabica	| Love the atmosphere of this coffee shop. |

- Create a ProductController controller.
   - This class should be configured so that it will be injected into ProductController.
   - Create appropriate CRUD methods
   - It should have a List to store your products
   - For this step, all Product data should be hard coded in the List.
   - It should have an action that gets and returns all of your products in a Products Index View.
   - It should have an action that requires an id parameter to get and return one of your products in a Product Details View. This method should expect an "id" parameter in order to select a specific product.
- Create a ReviewController controller.
   - Create appropriate Controller, and Tests to handle Review actions.
   - Create appropriate CRUD methods
   - Add a DbContext database of Reviews in the ReviewRepository.
   - Add seed data to the DbContext for Reviews.
- Create your DbContext
   - Create Dbsets for your products and reviews
   - Move seed data from the Repository to the DbContext by overriding the OnModelCreating() method.
- Update Product and Review Models for Entity Framework and Code First Migrations. Update the Product class such that:
   - It is an Entity Framework entity.
   - It configures a one-to-many relationship to Review.
      - This is done by adding the optional 'virtual' modifier for objects, and adding an oppropriate Id.
- Update the Review class such that:
   - It is an Entity Framework entity.
   - It configures an appropriate relationship to its Product.
   
## Sprint 3 Deliverables: Use HTML forms to allow a user to add, edit and delete Reviews!

### User Stories

**Create Reviews**
- As a user, I would like to have the ability to add a Review to a Product, so that I can share my opinion.
**Edit Reviews**
- As a user, I would like to have the ability to edit a Review for a Product, so that I can change my mind or fix an error.
**Delete Reviews**
- As a user, I would like to have the ability to delete a Review for a Product, so that I can remove it.
**Navigation Links**
- As a user, I would like to have the ability to navigate off of every page I visit, so that I am not trapped on a page.

### Details

NOTE: You may need to modify the deliverables below based on the unique model design of your team's application. The deliverables below assume your data context consists of a one to many relationship between the Product Model class and the Review Model class.

- Add Views and Navigation links.
   - Allow user to logically navigate to all the functions you have added to your program. 
   - NOTE: Some of these functions may be shown on the same page
      - List of all Products
      - Details for a Product
      - List of all Reviews for a given Product
      - Ability to Add a Product Review
      - Ability to Edit a Product Review
      - Ability to Delete a Product Review
- Create HTML forms that allow users to edit, update, and delete objects from your database

### Stretch Task Deliverables

- Add a Landing Page for your Review Site
- Figure out a way to upload images for products
- Add Authentication for your Product Review Site
- Control what reviews a user has access to change
- Add CRUD operations and views for your Product
- Add a Category class with a one-to-many relationship to your Product.

## Grading

Ideally, you should write your code by writing tests first. If you do so, each public method you write should have a unit test that covers its behavior. The test classes should also be well maintained and follow the principles of clean code. Grading for this assignment will be handled via demonstration, and there will be no additional space for regrading. 
