---
title: 在 PHP 中指定默认演示文稿字体
linktitle: 默认字体
type: docs
weight: 30
url: /zh/php-java/default-font/
keywords:
- 默认字体
- 常规字体
- 正常字体
- 亚洲字体
- PDF 导出
- XPS 导出
- 图像导出
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 中设置默认字体，以确保 PowerPoint (PPT, PPTX) 和 OpenDocument (ODP) 正确转换为 PDF、XPS 和图像。"
---

## **使用默认字体渲染演示文稿**
Aspose.Slides 允许您为将演示文稿渲染为 PDF、XPS 或缩略图设置默认字体。本文展示如何定义 DefaultRegularFont 和 DefaultAsianFont 作为默认字体。请按照以下步骤使用 Aspose.Slides for PHP via Java API 从外部目录加载字体：

1. 创建 [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions) 的实例。
2. 将 [Set the DefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) 设置为您想要的字体。在以下示例中，我使用了 Wingdings。
3. 将 [Set the DefaultAsianFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) 设置为您想要的字体。我在以下示例中使用了 Wingdings。
4. 使用 Presentation 加载演示文稿并设置加载选项。
5. 现在，生成幻灯片缩略图、PDF 和 XPS 以验证结果。

上述实现代码如下。
```php
  # 使用加载选项来定义默认常规和亚洲字体
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # 加载演示文稿
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # 生成幻灯片缩略图
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # 将图像保存到磁盘。
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # 生成 PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # 生成 XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**DefaultRegularFont 和 DefaultAsianFont 到底影响什么——仅导出，还是包括缩略图、PDF、XPS、HTML 和 SVG？**

它们参与所有受支持输出的渲染管道。这包括幻灯片缩略图、[PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/php-java/convert-powerpoint-to-xps/)、[光栅图像](/slides/zh/php-java/convert-powerpoint-to-png/)、[HTML](/slides/zh/php-java/convert-powerpoint-to-html/)、以及 [SVG](/slides/zh/php-java/render-a-slide-as-an-svg-image/)，因为 Aspose.Slides 在这些目标上使用相同的布局和字形解析逻辑。

**在仅读取并保存 PPTX 而不进行任何渲染时，是否会应用默认字体？**

不。只有在需要测量和绘制文本时，默认字体才起作用。直接打开后保存演示文稿不会更改存储的字体运行或文件结构。默认字体在渲染或重新排版文本的操作中才会生效。

**如果我添加自己的字体文件夹或从内存提供字体，它们会在选择默认字体时被考虑吗？**

是的。[自定义字体源](/slides/zh/php-java/custom-font/) 会扩展引擎可使用的字体族和字形目录。默认字体和任何 [回退规则](/slides/zh/php-java/fallback-font/) 将首先在这些源中解析，从而在服务器和容器中提供更可靠的覆盖。

**默认字体会影响文本度量（字距、前进宽度），从而影响换行和折行吗？**

是的。更换字体会改变字形度量，可能在渲染过程中影响换行、折行和分页。为保持布局稳定，建议 [嵌入原始字体](/slides/zh/php-java/embedded-font/) 或选择度量兼容的默认和回退字体族。

**如果演示文稿中使用的所有字体都已嵌入，设置默认字体还有意义吗？**

通常没有必要，因为 [嵌入字体](/slides/zh/php-java/embedded-font/) 已经保证了外观一致性。不过默认字体仍可作为安全网，处理嵌入子集未覆盖的字符或文件中混合了嵌入和未嵌入的文本时。