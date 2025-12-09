---
title: 合并演示文稿
type: docs
weight: 40
url: /zh/nodejs-java/merge-presentation/
keywords: "合并 PowerPoint, PPTX, PPT, 组合 PowerPoint, 合并演示文稿, 组合演示文稿, Java"
description: "在 JavaScript 中合并或组合 PowerPoint 演示文稿"
---

## **演示文稿合并**

当您将一个演示文稿合并到另一个时，实际上是将它们的幻灯片合并到一个演示文稿中以获得单个文件。

{{% alert title="Info" color="info" %}}
大多数演示文稿程序（PowerPoint 或 OpenOffice）缺少允许用户以这种方式合并演示文稿的功能。

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/)，然而，允许您以不同方式合并演示文稿。您可以在不担心质量或数据丢失的情况下，合并演示文稿及其所有形状、样式、文本、格式、批注、动画等。

**另见**
[克隆幻灯片](https://docs.aspose.com/slides/nodejs-java/clone-slides/)。
{{% /alert %}}

### **可以合并的内容**

With Aspose.Slides, you can merge 

* 整个演示文稿。所有演示文稿中的幻灯片最终汇入一个演示文稿。
* 特定幻灯片。选定的幻灯片汇入一个演示文稿。
* 相同格式的演示文稿（PPT 到 PPT、PPTX 到 PPTX 等）以及不同格式的演示文稿（PPT 到 PPTX、PPTX 到 ODP 等）之间的合并。

{{% alert title="Note" color="warning" %}} 
除了演示文稿，Aspose.Slides 允许您合并其他文件：

* [图像转换](https://products.aspose.com/slides/nodejs-java/merger/image-to-image/)，例如 [JPG 到 JPG](https://products.aspose.com/slides/nodejs-java/merger/jpg-to-jpg/) 或 [PNG 到 PNG](https://products.aspose.com/slides/nodejs-java/merger/png-to-png/)。
* 文档，例如 [PDF 到 PDF](https://products.aspose.com/slides/nodejs-java/merger/pdf-to-pdf/) 或 [HTML 到 HTML](https://products.aspose.com/slides/nodejs-java/merger/html-to-html/)。
* 以及两种不同的文件，例如 [图像到 PDF](https://products.aspose.com/slides/nodejs-java/merger/image-to-pdf/) 或 [JPG 到 PDF](https://products.aspose.com/slides/nodejs-java/merger/jpg-to-pdf/) 或 [TIFF 到 PDF](https://products.aspose.com/slides/nodejs-java/merger/tiff-to-pdf/)。
{{% /alert %}}

### **合并选项**

您可以应用选项，以确定是否

* 输出演示文稿中的每个幻灯片保持唯一样式。
* 在输出演示文稿中为所有幻灯片使用特定样式。

要合并演示文稿，Aspose.Slides 提供了 [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法（来自 [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) 类）。`addClone` 方法有多种实现，定义了演示文稿合并过程的参数。每个 Presentation 对象都有一个 [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) 集合，因此您可以从要合并幻灯片的演示文稿调用 `addClone` 方法。

`addClone` 方法返回一个 `Slide` 对象，即源幻灯片的克隆。输出演示文稿中的幻灯片仅是源幻灯片的副本。因此，您可以更改生成的幻灯片（例如，应用样式、格式选项或布局），而无需担心源演示文稿受到影响。

## **合并演示文稿** 

Aspose.Slides 提供了 [**AddClone(ISlide)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 方法，可在幻灯片保留其布局和样式的情况下（默认参数）合并幻灯片。

以下 JavaScript 代码演示了如何合并演示文稿：
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **使用幻灯片母版合并演示文稿** 

Aspose.Slides 提供了 [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) 方法，可在应用幻灯片母版演示文稿模板的同时合并幻灯片。这样，必要时您可以更改输出演示文稿中幻灯片的样式。

以下 JavaScript 代码演示了上述操作：
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 
幻灯片母版的布局会自动确定。当无法确定合适的布局时，如果 `addClone` 方法的 `allowCloneMissingLayout` 布尔参数设置为 true，则使用源幻灯片的布局。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException)。
{{% /alert %}}

如果希望输出演示文稿中的幻灯片采用不同的布局，请在合并时改用 [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) 方法。

## **合并来自演示文稿的特定幻灯片** 

从多个演示文稿中合并特定幻灯片对于创建自定义幻灯片组很有用。Aspose.Slides for Node.js via Java 允许您仅选择并导入所需的幻灯片。API 保留原始幻灯片的格式、布局和设计。

以下 JavaScript 代码创建一个新演示文稿，添加来自两个其他演示文稿的标题幻灯片，并将结果保存为文件：
```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```

```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```


## **使用幻灯片布局合并演示文稿** 

以下 JavaScript 代码演示了如何在合并演示文稿的幻灯片时应用您首选的幻灯片布局，以获得一个输出演示文稿：
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **合并具有不同幻灯片尺寸的演示文稿** 

{{% alert title="Note" color="warning" %}} 
无法合并具有不同幻灯片尺寸的演示文稿。 
{{% /alert %}}

要合并尺寸不同的两个演示文稿，必须调整其中一个演示文稿的尺寸，使其与另一个演示文稿的尺寸匹配。

以下示例代码演示了上述操作：
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **将幻灯片合并到演示文稿章节** 

以下 JavaScript 代码演示了如何将特定幻灯片合并到演示文稿的章节中：
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


该幻灯片被添加到该章节的末尾。

## **常见问题** 

**合并期间是否保留演讲者备注？**

是的。克隆幻灯片时，Aspose.Slides 会保留所有幻灯片元素，包括备注、格式和动画。

**评论及其作者是否被转移？**

评论作为幻灯片内容的一部分，会随幻灯片一起复制。评论作者标签在生成的演示文稿中作为评论对象保留。

**如果源演示文稿受密码保护怎么办？**

必须通过 [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setpassword/) [使用密码打开](/slides/zh/nodejs-java/password-protected-presentation/)；加载后，这些幻灯片可以安全地克隆到未受保护的目标文件（或受保护的文件）。

**合并操作的线程安全性如何？**

不要在 [多个线程](/slides/zh/nodejs-java/multithreading/) 中使用相同的 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 实例。推荐的规则是“一个文档‑一个线程”；不同的文件可以在不同线程中并行处理。

## **另请参阅** 

Aspose 提供了一个 [免费在线拼贴制作器](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG 到 JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 图像，创建 [照片网格](https://products.aspose.app/slides/collage/photo-grid)，以及其他功能。

查看 [Aspose 免费在线合并工具](https://products.aspose.app/slides/merger)。它允许您在相同格式（例如 PPT 到 PPT、PPTX 到 PPTX）或跨不同格式（例如 PPT 到 PPTX、PPTX 到 ODP）合并 PowerPoint 演示文稿。

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)