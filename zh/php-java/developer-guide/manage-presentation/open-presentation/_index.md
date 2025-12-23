---
title: 在 PHP 中打开演示文稿
linktitle: 打开演示文稿
type: docs
weight: 20
url: /zh/php-java/open-presentation/
keywords:
- 打开 PowerPoint
- 打开 OpenDocument
- 打开演示文稿
- 打开 PPTX
- 打开 PPT
- 打开 ODP
- 加载演示文稿
- 加载 PPTX
- 加载 PPT
- 加载 ODP
- 受保护的演示文稿
- 大型演示文稿
- 外部资源
- 二进制对象
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（通过 Java）轻松打开 PowerPoint（.pptx、.ppt）和 OpenDocument（.odp）演示文稿——快速、可靠、功能完整。"
---

## **概述**

除了从头创建 PowerPoint 演示文稿之外，Aspose.Slides 还可以打开现有的演示文稿。加载演示文稿后，您可以检索其信息、编辑幻灯片内容、添加新幻灯片、删除已有幻灯片等。

## **打开演示文稿**

要打开现有的演示文稿，请实例化 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类并将文件路径传入其构造函数。

以下 PHP 示例演示了如何打开演示文稿并获取其幻灯片计数：
```php
// 实例化 Presentation 类并将文件路径传递给其构造函数。
$presentation = new Presentation("Sample.pptx");
try {
    // 输出演示文稿中的幻灯片总数。
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```


## **打开受密码保护的演示文稿**

当需要打开受密码保护的演示文稿时，将密码通过 [setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword) 方法传入 [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) 类，以解密并加载它。以下 PHP 代码演示了此操作：
```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // 对已解密的演示文稿执行操作。
} finally {
    $presentation->dispose();
}
```


## **打开大型演示文稿**

Aspose.Slides 提供了一些选项——尤其是 [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) 类中的 [getBlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) 方法——帮助您加载大型演示文稿。

以下 PHP 代码演示了加载大型演示文稿（例如 2 GB）：
```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// 选择 KeepLocked 行为——演示文稿文件将在整个生命周期内保持锁定
// Presentation 实例，但无需加载到内存或复制到临时文件。
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // 已加载大型演示文稿，可直接使用，同时内存消耗保持低水平。

    // 对演示文稿进行更改。
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // 将演示文稿保存到另一个文件。此操作期间内存消耗仍保持低水平。
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// 不要这样做！因为文件在演示文稿对象释放之前被锁定，会抛出 I/O 异常。
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// 在这里执行是可以的。源文件已不再被演示文稿对象锁定。
unlink($filePath);
```


{{% alert color="info" title="信息" %}}

为了解决在流操作时的一些限制，Aspose.Slides 可能会复制流的内容。从流加载大型演示文稿会导致演示文稿被复制，从而减慢加载速度。因此，当需要加载大型演示文稿时，我们强烈建议使用演示文稿文件路径而不是流。

在创建包含大型对象（视频、音频、高分辨率图像等）的演示文稿时，您可以使用 [BLOB management](/slides/zh/php-java/manage-blob/) 来降低内存消耗。

{{%/alert %}}

## **控制外部资源**

Aspose.Slides 提供了 [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) 接口，允许您管理外部资源。以下 PHP 代码展示了如何使用 `IResourceLoadingCallback` 接口：
```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // 加载替代图像。
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // 设置替代 URL。
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // 跳过所有其他图像。
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```


## **加载不含嵌入二进制对象的演示文稿**

PowerPoint 演示文稿可能包含以下类型的嵌入二进制对象：

- VBA 项目（可通过 [Presentation.getVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject) 访问）；
- OLE 对象嵌入数据（可通过 [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) 访问）；
- ActiveX 控件二进制数据（可通过 [Control.getActiveXControlBinary](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getActiveXControlBinary) 访问）。

使用 [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) 方法，您可以在加载演示文稿时删除所有嵌入的二进制对象。

此方法对于移除可能的恶意二进制内容非常有用。以下 PHP 代码演示了如何加载不含任何嵌入二进制内容的演示文稿：
```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // 对演示文稿执行操作。
} finally {
    $presentation->dispose();
}
```


## **常见问题**

**如何判断文件已损坏且无法打开？**

加载时会抛出解析/格式验证异常。此类错误通常会提到 ZIP 结构无效或 PowerPoint 记录损坏。

**打开时若缺少必需的字体会怎样？**

文件仍会打开，但后续的 [rendering/export](/slides/zh/php-java/convert-presentation/) 可能会替换字体。请在运行时环境中 [Configure font substitutions](/slides/zh/php-java/font-substitution/) 或 [add the required fonts](/slides/zh/php-java/custom-font/)。

**打开时嵌入的媒体（视频/音频）怎么办？**

它们会作为演示文稿资源可用。如果媒体通过外部路径引用，请确保这些路径在您的环境中可访问；否则 [rendering/export](/slides/zh/php-java/convert-presentation/) 可能会省略这些媒体。