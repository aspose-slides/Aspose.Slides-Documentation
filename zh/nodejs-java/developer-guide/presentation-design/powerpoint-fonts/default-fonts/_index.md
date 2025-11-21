---
title: 默认字体 - PowerPoint JavaScript API
linktitle: 默认字体
type: docs
weight: 30
url: /zh/nodejs-java/default-font/
description: PowerPoint JavaScript API 允许您为将演示文稿渲染为 PDF、XPS 或缩略图设置默认字体。本文展示如何定义 DefaultRegular Font 和 DefaultAsian Font 作为默认字体。
---

## **使用默认字体呈现演示文稿**
Aspose.Slides 允许您为将演示文稿渲染为 PDF、XPS 或缩略图设置默认字体。本文展示如何定义 DefaultRegularFont 和 DefaultAsianFont 作为默认字体。请按照以下步骤使用 Aspose.Slides for Node.js 通过 Java API 从外部目录加载字体：

1. 创建一个[LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions)的实例。
1. 将[设置 DefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-)设置为您想要的字体。在下面的示例中，我使用了 Wingdings。
1. 将[设置 DefaultAsianFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-)设置为您想要的字体。我在以下示例中使用了 Wingdings。
1. 使用 Presentation 加载演示文稿并设置加载选项。
1. 现在，生成幻灯片缩略图、PDF 和 XPS 以验证结果。

```javascript
// 使用加载选项来定义默认的常规字体和亚洲字体
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// 生成幻灯片缩略图
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // 将图像保存到磁盘上。
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // 生成 PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // 生成 XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**DefaultRegularFont 和 DefaultAsianFont 究竟影响什么——仅导出，还是包括缩略图、PDF、XPS、HTML 和 SVG？**

它们参与所有受支持输出的渲染管道。这包括幻灯片缩略图、[PDF](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/nodejs-java/convert-powerpoint-to-xps/)、[光栅图像](/slides/zh/nodejs-java/convert-powerpoint-to-png/)、[HTML](/slides/zh/nodejs-java/convert-powerpoint-to-html/)、以及[SVG](/slides/zh/nodejs-java/render-a-slide-as-an-svg-image/)，因为 Aspose.Slides 在这些目标上使用相同的布局和字形解析逻辑。

**在仅读取并保存 PPTX 而不进行任何渲染时，是否会应用默认字体？**

不会。只有在需要测量和绘制文本时才会考虑默认字体。直接打开并保存演示文稿不会更改存储的字体运行或文件结构。默认字体仅在渲染或重新排版文本的操作中生效。

**如果我添加自己的字体文件夹或从内存提供字体，它们在选择默认字体时会被考虑吗？**

会。[自定义字体来源](/slides/zh/nodejs-java/custom-font/)会扩展引擎可用的字体族和字形目录。默认字体和任何[后备规则](/slides/zh/nodejs-java/fallback-font/)首先会在这些来源中解析，从而在服务器和容器环境中提供更可靠的覆盖。

**默认字体会影响文本度量（字距、前进）进而影响换行和自动换行吗？**

会。更换字体会改变字形度量，从而在渲染期间影响换行、自动换行和分页。为保持布局稳定，建议[嵌入原始字体](/slides/zh/nodejs-java/embedded-font/)或选择度量兼容的默认和后备字体族。

**如果演示文稿中使用的所有字体都已嵌入，设置默认字体还有意义吗？**

通常没有必要，因为[嵌入的字体](/slides/zh/nodejs-java/embedded-font/)已经确保外观一致。不过，默认字体仍可作为字符未被嵌入子集覆盖或文件混合使用嵌入和非嵌入文本时的安全网。