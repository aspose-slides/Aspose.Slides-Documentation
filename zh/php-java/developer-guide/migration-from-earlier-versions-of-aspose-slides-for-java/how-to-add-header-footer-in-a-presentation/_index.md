---
title: 如何在演示文稿中添加页眉和页脚
type: docs
weight: 20
url: /php-java/how-to-add-header-footer-in-a-presentation/
---

{{% alert color="primary" %}} 

新版本的 [Aspose.Slides for PHP via Java API](https://docs.aspose.com/slides/php-java/) 已经发布，现在这个单一产品支持从头生成 PowerPoint 文档和编辑现有文档的功能。

{{% /alert %}} 
## **对旧代码的支持**
为了使用在 Aspose.Slides for PHP via Java 13.x 之前版本中开发的旧代码，您需要对代码做一些小的修改，代码将按以前的方式工作。所有在旧版本 Aspose.Slides for PHP via Java 中的 Aspose.Slide 和 Aspose.Slides.Pptx 命名空间下的类已合并为单一的 Aspose.Slides 命名空间。请查看以下简单代码片段，了解如何在旧版本 Aspose.Slides API 中添加演示文稿的页眉和页脚，并按照所述步骤迁移到新的合并 API。
## **旧版 Aspose.Slides for PHP via Java 方法**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTXFooter-SetPPTXFooter.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTFooter-SetPPTFooter.java" >}}
## **新的 Aspose.Slides for PHP via Java 13.x 方法**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPresentationFooter-SetPresentationFooter.java" >}}