---
title: Presentation Comments
type: docs
weight: 100
url: /cpp/presentation-comments/
keywords: "Comments, PowerPoint comments, PowerPoint presentation, C++, Aspose.Slides for C++"
description: "Add comments and replies in PowerPoint presentation in C++"
---

In PowerPoint, a comment appears as a note or annotation on a slide. When a comment is clicked, its contents or messages are revealed. 

### **Why Add Comments to Presentations?**

You may want to use comments to provide feedback or communicate with your colleagues when you review presentations.

To allow you to use comments in PowerPoint presentations, Aspose.Slides for C++ provides

* The [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class, which contains the collections of authors (from the [get_CommentAuthors()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d) method). The authors add comments to slides. 
* The  [ICommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment_collection) interface, which contains the collection of comments for individual authors. 
* The  [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) class, which contains information on authors and their comments: who added the comment, the time the comment was added, the comment's position, etc. 
* The [CommentAuthor](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_author) class, which contains information on individual authors: the author's name, his initials, comments associated with the author's name, etc. 

## **Add Slide Comment**
This C++ code shows you how to add a comment to a slide in a PowerPoint presentation:

```cpp
// Instantiates the Presentation class
auto presentation = System::MakeObject<Presentation>();
// Adds an empty slide
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Adds an author
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Sets the position for comments
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Accesses ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// Accesses ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// Adds slide comment for an author on slide 1
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Adds slide comment for an author on slide 2
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// When null is passed as an argument, comments from all authors are brought to the selected slide
auto comments = slide1->GetSlideComments(author);

// Accesses the comment at index 0 for slide 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Selects the Author's comments collection at index 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **Access Slide Comments**
This C++ code shows you how to access an existing comment on a slide in a PowerPoint presentation:

```cpp
// Instantiates the Presentation class
auto presentation = System::MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" has comment: " + comment->get_Text()
                        + u" with Author: " + comment->get_Author()->get_Name()
                        + u" posted on time :" + comment->get_CreatedTime() + u"\n");
    }
}
```


## **Reply Comments**
A parent comment is the top or original comment in a hierarchy of comments or replies. Using the [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) property (from the [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) interface), you can set or get a parent comment. 

This C++ code shows you how to add comments and get replies to them:

```cpp
auto pres = System::MakeObject<Presentation>();

// Accesses ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Adds a comment
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Adds a reply to comment1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Adds another reply to comment1
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Adds a reply to existing reply
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Displays the comments hierarchy on console
auto comments = slide1->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::Write(u"{0} : {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
    Console::WriteLine();
}

pres->Save(u"parent_comment.pptx", SaveFormat::Pptx);

// Removes comment1 and all replies to it
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Attention" %}} 

* When the [Remove](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) method (from the [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) interface) is used to delete a comment, the replies to the comment also get deleted. 
* If the [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) setting results in a circular reference, [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) will be thrown.

{{% /alert %}}

## **Add Modern Comment**

In 2021, Microsoft introduced *modern comments* in PowerPoint. The modern comments feature significantly improves collaboration in PowerPoint. Through modern comments, PowerPoint users get to resolve comments, anchor comments to objects and texts, and engage in interactions a lot more easily than before. 

In [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-11-release-notes/), we implemented support for modern comments by adding the [ModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.modern_comment) class. The [AddModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) and [InsertModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) methods were added to the [CommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection) class.

This C++ code shows you how to add a modern comment to a slide in a PowerPoint presentation: 

```cpp
auto pres = System::MakeObject<Presentation>();
// Accesses ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Remove Comment**

### **Delete All Comments and Authors**

This C++ code shows you how to remove all comments and authors in a presentation:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Deletes all comments from the presentation
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Deletes all authors
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);

```

### **Delete Specific Comments**

This C++ code shows you how to delete specific comments on a slide:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// add comments...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// remove all comments that contain "comment 1" text
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"comment 1")
        {
            toRemove->Add(comment);
        }
    }
    for (auto comment : toRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}
        
presentation->Save(u"pres.pptx", SaveFormat::Pptx);

```

