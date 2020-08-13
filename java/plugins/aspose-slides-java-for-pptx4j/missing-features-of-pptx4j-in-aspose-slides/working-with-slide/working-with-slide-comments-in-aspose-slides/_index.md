---
title: Working with Slide Comments in Aspose.Slides
type: docs
weight: 50
url: /java/working-with-slide-comments-in-aspose-slides/
---

## **Aspose.Slides - Working with Slide Comments**
In Aspose.Slides for Java, the presentation slide comment are associated with particular author. The **Presentation** class holds the collection of authors in **CommentAuthorCollection** that are responsible for adding slide comments. For each author, there is collection of comments in **CommentCollection**. The **Comment** class include information like author who added slide comment, time of creation, slide where comment is added, the position of slide comment on selected slide and the comment text. The **CommentAuthor** class includes author name, his initials and list of associated comments.

**Java**

``` java

 // ======================================

// Adding Slide Comments

// ======================================

Presentation pres = new Presentation();

// Adding Empty slide

pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

// Adding Author

ICommentAuthor author = pres.getCommentAuthors().addAuthor("Aspose", "AS");

// Position of comments

java.awt.geom.Point2D.Float point = new java.awt.geom.Point2D.Float(0.2f, 0.2f);

java.util.Date date = new java.util.Date();

// Adding slide comment for an author on slide 1

author.getComments().addComment("Hello Mudassir, this is slide comment",

		pres.getSlides().get_Item(0), point, date);

// Adding slide comment for an author on slide 1

author.getComments().addComment("Hello Mudassir, this is second slide comment",

		pres.getSlides().get_Item(1), point, date);

// Accessing ISlide 1

ISlide slide = pres.getSlides().get_Item(0);

// if null is passed as an argument then it will bring comments from all

// authors on selected slide

IComment[] Comments = slide.getSlideComments(author);

// Accessing the comment at index 0 for slide 1

String str = Comments[0].getText();

pres.save(dataDir + "AsposeComments.pptx", SaveFormat.Pptx);

if (Comments.length > 0)

{

	// Select comments collection of Author at index 0

	ICommentCollection commentCollection = Comments[0].getAuthor().getComments();

	String comment = commentCollection.get_Item(0).getText();

}

// ======================================

// Accessing Slide Comments

// ======================================

// Presentation pres = new Presentation(dataDir + "AsposeComments.pptx");

for (ICommentAuthor author1 : pres.getCommentAuthors())

{

	for (IComment comment : author1.getComments())

	{

		System.out.println("ISlide :"

			+ comment.getSlide().getSlideNumber()

			+ " has comment: " + comment.getText()

			+ " with Author: " + comment.getAuthor().getName()

			+ " posted on time :" + comment.getCreatedTime() + "\n");

	}

}

```
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Working with Slide Comments](http://docs.aspose.com:8082/docs/display/slidesjava/Working+with+Slide+Comments).

{{% /alert %}}
