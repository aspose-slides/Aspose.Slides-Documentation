---
title: 如何在演示文稿中添加页眉和页脚
type: docs
weight: 20
url: /androidjava/how-to-add-header-footer-in-a-presentation/
---

{{% alert color="primary" %}} 

新版本的 [Aspose.Slides for Java API](https://docs.aspose.com/slides/androidjava/) 已经发布，现在这个单一产品支持从头生成 PowerPoint 文档以及编辑现有文档的功能。

{{% /alert %}} 
## **对遗留代码的支持**
为了使用早于 13.x 的 Aspose.Slides for Java 开发的遗留代码，您需要对代码做一些小的更改，代码将像以前一样工作。以前在旧版本 Aspose.Slides for Java 中存在的所有类，位于 Aspose.Slide 和 Aspose.Slides.Pptx 命名空间下，现在已经合并到单一的 Aspose.Slides 命名空间中。请查看以下简短的代码示例，了解如何在旧版 Aspose.Slides API 中添加演示文稿的页眉和页脚，并按照步骤说明如何迁移到新的合并 API。
## **旧版 Aspose.Slides for Java 方法**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTXFooter-SetPPTXFooter.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTFooter-SetPPTFooter.java" >}}
## **新版本 Aspose.Slides for Java 13.x 方法**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPresentationFooter-SetPresentationFooter.java" >}}