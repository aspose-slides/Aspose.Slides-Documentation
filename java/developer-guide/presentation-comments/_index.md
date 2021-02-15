---
title: Presentation Comments
type: docs
weight: 100
url: /java/presentation-comments/
keywords: "PowerPoint presentation comments"
description: "Add PowerPoint comments and reply presentation comments in Java."
---


## **Add Comment Reply**
New methods **getParentComment** and **setParentComment** have been added to **IComment** interface and **Comment** class in Aspose.Slides for Java. It allows to get or set the parent comment, thus creating a dialog in the form of a hierarchy of comments and replies.

The code snippet below shows a sample of adding some comments and some replies to them:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Comments-AddParentComments-AddParentComments.java" >}}

**Attention: remove** method of **IComment** interface removes the comment with all its replies.

**NOTE:** If setting **ParentComment** leads to a circular reference, the exception of type **PptxEditException** will be thrown.
