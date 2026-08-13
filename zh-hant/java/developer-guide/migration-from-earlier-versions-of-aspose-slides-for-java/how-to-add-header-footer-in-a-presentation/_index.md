---
title: 如何在 Java 中為簡報添加頁首與頁尾
linktitle: 添加頁首與頁尾
type: docs
weight: 20
url: /zh-hant/java/how-to-add-header-footer-in-a-presentation/
keywords:
- 遷移
- 添加頁首
- 添加頁尾
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Java 中使用舊版與新版 Aspose.Slides API，為 PowerPoint PPT、PPTX 與 ODP 簡報添加頁首與頁尾。"
---
{{% alert color="info" %}} 
一個全新的 [Aspose.Slides for Java API](https://docs.aspose.com/slides/zh-hant/java/) 已發布，現在此單一產品支援從頭建立 PowerPoint 文件以及編輯現有文件的功能。
{{% /alert %}} 
## **Support for Legacy Code**
為了使用在 13.x 之前的 Aspose.Slides for Java 版本開發的舊版程式碼，您只需對程式碼做少量修改，即可讓程式如同以前般運作。舊版 Aspose.Slides for Java 中位於 Aspose.Slide 與 Aspose.Slides.Pptx 命名空間的所有類別，現在已合併至單一的 Aspose.Slides 命名空間。請參閱以下簡單的程式碼片段，了解如何在舊版 Aspose.Slides API 中為簡報新增頁首頁尾，並依照說明步驟將其遷移至新合併的 API。
## **Legacy Aspose.Slides for Java Approach**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTXFooter-SetPPTXFooter.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTFooter-SetPPTFooter.java" >}}
## **New Aspose.Slides for Java 13.x Approach**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPresentationFooter-SetPresentationFooter.java" >}}