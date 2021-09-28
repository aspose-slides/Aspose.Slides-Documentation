---
title: Presentation Comments
type: docs
weight: 100
url: /cpp/presentation-comments/
keywords: "PowerPoint presentation comments"
description: "Add PowerPoint comments and reply presentation comments with Aspose.Slides."
---


Slide comment is like an annotation in PDF file or a note that one can attach with a slide. Slide comments are generally used while reviewing the slides in PowerPoint. However, they can also serve as a useful utility for highlighting something important in presentation slide and giving the needed explanation for that.
## **Add Slide Comment**
In Aspose.Slides for C++, the presentation slide comment are associated with a particular author. The [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class holds the collection of authors in **ICommentAuthorCollection** that are responsible for adding slide comments. For each author, there is a collection of comments in **ICommentCollection**. The **IComment** class includes information like an author who added slide comment, time of creation, slide where a comment is added, the position of slide comment on the selected slide and the comment text. The **CommentAuthor** class includes the author's name, his initials and list of associated comments. In the following example, we have added the code snippet for adding the slide comments.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlideComments-AddSlideComments.cpp" >}}
## **Access Slide Comment**
In the following example, we will learn how to access the existing slide comments and can even modify the comments as well.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSlideComments-AccessSlideComments.cpp" >}}
## **Add Comment Reply**
New **get_ParentComment()** and **set_ParentComment()** methods have been added to **IComment** and **Comment** classes. These methods allow to get or set the parent comment, thus creating a dialog in the form of a hierarchy of comments and replies.

The code snippet below shows a sample of adding some comments and some replies to them:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddParentComments-AddParentComments.cpp" >}}

**Attention: Remove** method of **IComment** interface removes the comment with all its replies.

**NOTE:** If setting **ParentComment** leads to a circular reference, the exception of type **PptxEditException** will be thrown.


