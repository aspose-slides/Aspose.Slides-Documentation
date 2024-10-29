---
title: 保存演示文稿
type: docs
weight: 80
url: /zh/php-java/save-presentation/
---

## **概述**
{{% alert color="primary" %}} 

[打开演示文稿](/slides/zh/php-java/open-presentation/) 描述了如何使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类打开演示文稿。本文解释了如何创建和保存演示文稿。

{{% /alert %}} 

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类保存演示文稿的内容。无论是从头创建演示文稿还是修改现有的演示文稿，完成后都想保存演示文稿。使用 Aspose.Slides for PHP via Java，可以保存为 **文件** 或 **流**。本文解释了如何以不同方式保存演示文稿：

## **将演示文稿保存到文件**
通过调用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的 [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) 方法，将演示文稿保存到文件。只需将文件名和 [**SaveFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/SaveFormat) 传递给 [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) 方法。

下面的示例展示了如何使用 Aspose.Slides for PHP via Java 保存演示文稿。

```php
  # 实例化一个表示 PPT 文件的 Presentation 对象
  $pres = new Presentation();
  try {
    # ...在这里做一些工作...
    # 将演示文稿保存到文件
    $pres->save("demoPass.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **将演示文稿保存到流**
可以通过将输出流传递给 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的 [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.io.OutputStream-int-) 方法将演示文稿保存到流。可以将演示文稿保存到许多类型的流。在下面的示例中，我们创建了一个新的演示文稿文件，添加形状中的文本并将演示文稿保存到流。

```php
  # 实例化一个表示 PPT 文件的 Presentation 对象
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 200, 200);
    # 向形状添加文本
    $shape->getTextFrame()->setText("此演示演示了如何创建 PowerPoint 文件并将其保存到流。");
    $os = new Java("java.io.FileOutputStream", "Save_As_Stream_out.pptx");
    $pres->save($os, SaveFormat::Pptx);
    $os->close();
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **使用预定义视图类型保存演示文稿**
Aspose.Slides for PHP via Java 提供了一种设施，可以在通过 [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) 类打开生成的演示文稿时设置视图类型。 [**setLastView**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#setLastView-int-) 属性用于通过使用 [**ViewType**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewType) 枚举器设置视图类型。

```php
  # 打开演示文稿文件
  $pres = new Presentation();
  try {
    # 设置视图类型
    $pres->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # 保存演示文稿
    $pres->save("newDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **将演示文稿保存为严格的 Office Open XML 格式**
Aspose.Slides 允许您将演示文稿保存为严格的 Office Open XML 格式。为此，它提供了 [**PptxOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions) 类，在保存演示文稿时可以设置 Conformance 属性。如果将其值设置为 [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/php-java/aspose.slides/Conformance#Iso29500_2008_Strict)，则输出的演示文稿文件将以严格的 Open XML 格式保存。

以下示例代码创建一个演示文稿并将其保存为严格的 Office Open XML 格式。在为演示文稿调用 [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法时，将 [**PptxOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions) 对象传递给它，并将 Conformance 属性设置为 [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/php-java/aspose.slides/Conformance#Iso29500_2008_Strict)。

```php
  # 实例化一个表示 PPT 文件的 Presentation 对象
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加类型为线的自动形状
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # 设置严格的 Office Open XML 格式保存选项
    $options = new PptxOptions();
    $options->setConformance(Conformance->Iso29500_2008_Strict);
    # 将演示文稿保存到文件
    $pres->save("demoPass.pptx", SaveFormat::Pptx, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **以 Zip64 模式将演示文稿保存为 Office Open XML 格式**
Office Open XML 文件是一个 ZIP 压缩档案，文件的未压缩大小、压缩大小和总档案大小都限制为 4 GB（2^32 字节），并且档案中有 65,535（2^16-1）个文件的限制。ZIP64 格式扩展增加了这些限制到 2^64。

新的 [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/) 属性允许您选择何时为保存的 Office Open XML 文件使用 ZIP64 格式扩展。

此属性提供以下模式：

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#IfNecessary) 意味着仅在演示文稿超出上述限制时才会使用 ZIP64 格式扩展。这是默认模式。
- [Zip64Mode.Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) 意味着不使用 ZIP64 格式扩展。 
- [Zip64Mode.Always](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Always) 意味着始终使用 ZIP64 格式扩展。

以下代码演示了如何将演示文稿保存为使用 ZIP64 格式扩展的 PPTX 格式：

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $pptxOptions = new PptxOptions();
    $pptxOptions->setZip64Mode(Zip64Mode::Always);
    
    $pres->save("Sample-zip64.pptx", SaveFormat::Pptx, $pptxOptions);
  } finally {
    $pres->dispose();
  }
```

{{% alert title="注意" color="warning" %}}

在 Zip64Mode.Never 模式下保存将抛出 [PptxException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxexception/)，如果无法以 ZIP32 格式保存演示文稿。

{{% /alert %}}

## **以百分比更新保存进度**
新的 [**IProgressCallback**](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback) 接口已添加到 [**ISaveOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISaveOptions) 接口和 [**SaveOptions** ](https://reference.aspose.com/slides/php-java/aspose.slides/SaveOptions) 抽象类。 [**IProgressCallback**](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback) 接口表示回调对象，用于以百分比形式保存进度更新。  

以下代码片段展示了如何使用 [IProgressCallback](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback) 接口：

```php
  class ExportProgressHandler {
    function reporting($progressValue) {
      # 在这里使用进度百分比值
      $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
      echo($progress . "% 文件已转换");
    }
  }

  # 打开演示文稿文件
  $pres = new Presentation("ConvertToPDF.pptx");
  try {
    $saveOptions = new PdfOptions();
    $progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));
    $saveOptions->setProgressCallback($progressHandler);
    $pres->save("ConvertToPDF.pdf", SaveFormat::Pdf, $saveOptions);
  } finally {
    $pres->dispose();
  }
```

{{% alert title="信息" color="info" %}}

使用自己的 API，Aspose 开发了一个 [免费的 PowerPoint 分割工具](https://products.aspose.app/slides/splitter)，允许用户将演示文稿拆分为多个文件。基本上，该应用程序将来自给定演示文稿的选定幻灯片保存为新的 PowerPoint (PPTX 或 PPT) 文件。 

{{% /alert %}}