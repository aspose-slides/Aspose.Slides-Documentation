---
title: Presentation Comments
type: docs
weight: 100
url: /net/presentation-comments/
keywords: "PowerPoint presentation comments"
description: "Add PowerPoint comments and reply presentation comments with Aspose.Slides."
---



Slide comment is like an annotation in PDF file or a note that one can attach with a slide. Slide comments are generally used while reviewing the slides in PowerPoint. However, they can also serve as a useful utility for highlighting something important in the presentation slide and giving the needed explanation for that.
## **Add Slide Comment**
In Aspose.Slides for .NET, the presentation slide comment are associated with a particular author. The [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class holds the collection of authors in [**ICommentAuthorCollection** ](https://apireference.aspose.com/net/slides/aspose.slides/icommentauthorcollection/properties/index)that are responsible for adding slide comments. For each author, there is a collection of comments in [**ICommentCollection**](https://apireference.aspose.com/net/slides/aspose.slides/icommentcollection). The [**IComment**](https://apireference.aspose.com/net/slides/aspose.slides/icomment) class includes information like an author who added slide comment, time of creation, slide where a comment is added, the position of slide comment on the selected slide and the comment text. The [**CommentAuthor**](https://apireference.aspose.com/net/slides/aspose.slides/commentauthor) class includes the author's name, his initials and list of associated comments. In the following example, we have added the code snippet for adding the slide comments.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Comments-AddSlideComments-AddSlideComments.cs" >}}
## **Access Slide Comments**
In the following example, we will learn how to access the existing slide comments and can even modify the comments as well.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Comments-AccessSlideComments-AccessSlideComments.cs" >}}
## **Reply Comments**
A new property [**ParentComment**](https://apireference.aspose.com/net/slides/aspose.slides/icomment/properties/parentcomment) has been added to [**IComment**](https://apireference.aspose.com/net/slides/aspose.slides/icomment) interface and [**Comment**](https://apireference.aspose.com/net/slides/aspose.slides/comment) class in Aspose.Slides for .NET. It allows to get or set the parent comment, thus creating a dialog in the form of a hierarchy of comments and replies.

The code snippet below shows a sample of adding some comments and some replies to them:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Slides-Comments-AddParentComments-AddParentComments.cs" >}}

{{% alert color="warning" title="Attention" %}} 
Remove method of [**IComment**](https://apireference.aspose.com/net/slides/aspose.slides/icomment) interface removes the comment with all its replies.
{{% /alert %}}

{{% alert color="info" title="Note" %}} 
If setting [**ParentComment**](https://apireference.aspose.com/net/slides/aspose.slides/icomment/properties/parentcomment) leads to a circular reference, the exception of type **PptxEditException** will be thrown.
{{% /alert %}}