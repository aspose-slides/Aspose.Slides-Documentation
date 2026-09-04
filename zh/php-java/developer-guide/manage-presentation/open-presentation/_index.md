---
title: 在 PHP 中打开演示文稿
linktitle: 打开演示文稿
type: docs
weight: 20
url: /zh/php-java/open-presentation/
keywords:
- 打开 PowerPoint
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
description: "了解如何在 PHP 中使用 Aspose.Slides for PHP via Java 打开 PowerPoint 和 OpenDocument 演示文稿，提供打开密码，控制资源加载，并减少内存使用。"
---
## **介绍**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/zh/php-java/) 可以从文件和流中加载 PowerPoint 和 OpenDocument 演示文稿。加载演示文稿后，您可以检查其结构、编辑幻灯片、管理资源，并以原始或其他受支持的格式保存。

可以通过 [LoadOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/) 类自定义加载行为。例如，您可以提供打开密码、将大型二进制对象保留在 Java 堆外内存、控制外部资源，或省略嵌入的二进制数据。

## **打开演示文稿**

要打开现有演示文稿，请将其文件路径传递给 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 构造函数。使用完毕后请释放演示文稿，以便及时释放文件句柄、临时数据和其他资源。

以下 PHP 示例展示了如何打开演示文稿并获取幻灯片计数：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **打开受密码保护的演示文稿**

打开密码会对演示文稿内容进行加密。要加载完整的演示文稿，请将正确的密码传递给 [LoadOptions::setPassword](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setPassword)，并将该选项提供给 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 构造函数。密码缺失或不正确时加载将失败。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

有关密码检测、验证和加密工作流，请参阅 [Password-Protect Presentations](/slides/zh/php-java/password-protected-presentation/)。如果加密的演示文稿故意以公开的文档属性保存，则可以在不提供密码的情况下读取这些属性；请参阅 [Manage Presentation Properties](/slides/zh/php-java/presentation-properties/)。

## **打开大型演示文稿**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) 返回控制 Aspose.Slides 如何处理图像、音频和视频等二进制大型对象（BLOB）的选项。您可以保持源文件锁定、允许使用临时文件，以及限制保留在内存中的 BLOB 数据量。

以下 PHP 代码演示了加载大型演示文稿（例如 2 GB）的方式：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="注意" %}}
使用 [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) 时，源文件会保持锁定状态，直到释放演示文稿实例。在该实例存活期间，请勿移动、覆盖或删除源文件。

Aspose.Slides 可能会在加载时复制输入流的内容。对于大型演示文稿，文件路径通常比流更高效。有关更多存储和内存管理选项，请参阅 [Manage BLOBs](/slides/zh/php-java/manage-blob/)。
{{% /alert %}}

## **控制外部资源**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) 通过 PHP/Java Bridge 接受对 Java [IResourceLoadingCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iresourceloadingcallback/) 接口的实现。回调可以提供替代数据、重定向资源、使用默认加载器或跳过资源。当演示文稿包含必须依据应用程序特定安全或存储规则解析的外部图像时，这非常有用。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **加载不含嵌入二进制对象的演示文稿**

演示文稿可能包含应用程序不需要或不想保留的嵌入二进制数据。例如：

- VBA 项目，可通过 [Presentation::getVbaProject](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getVbaProject) 获取；
- 嵌入的 OLE 数据，可通过 [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/zh/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) 获取；
- ActiveX 控件数据，可通过 [Control::getActiveXControlBinary](https://reference.aspose.com/slides/zh/php-java/aspose.slides/control/#getActiveXControlBinary) 获取。

将 [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) 设置为 `true`，即可在加载时删除这些二进制数据。将加载后的演示文稿保存即可保留已清理的结果。

此选项可降低意外嵌入负载的风险，但它并非完整的恶意软件检测或内容消毒系统。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常见问题**

**如何判断文件已损坏且无法打开？**

Aspose.Slides 在加载期间会抛出解析或格式异常。请将此类失败与密码错误单独处理，以便应用程序能够准确报告原因。

**如果缺少必需的字体会怎样？**

演示文稿仍能加载，但渲染和导出可能会替换字体。您可以 [configure font substitution](/slides/zh/php-java/font-substitution/) 或 [provide custom fonts](/slides/zh/php-java/custom-font/) 来使输出更可预测。

**加载演示文稿是否也会加载其嵌入的媒体？**

嵌入的音频和视频会通过演示文稿对象模型提供。外部资源会依据配置的资源加载行为进行解析，如果无法访问其位置，则可能不可用。