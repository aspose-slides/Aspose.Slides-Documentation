---
title: 在 PHP 中管理演示文稿属性
linktitle: 演示文稿属性
type: docs
weight: 70
url: /zh/php-java/presentation-properties/
keywords:
- PowerPoint 属性
- 演示文稿属性
- 文档属性
- 内建属性
- 自定义属性
- 高级属性
- 管理属性
- 修改属性
- 文档元数据
- 编辑元数据
- 校对语言
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 中掌握演示文稿属性，并在您的 PowerPoint 和 OpenDocument 文件中简化搜索、品牌化和工作流。"
---
## **介绍**

Aspose.Slides for PHP via Java 支持 **built-in** 和 **custom** 文档属性。使用这些属性可以读取和更新演示文稿元数据，例如作者、标题和用户定义的值。

Aspose.Slides 允许您通过 [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) 类来处理演示文稿的文档属性。该类的实例由 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) 返回。以下示例展示了如何读取、修改和管理这些属性。它们假设 PHP/Java Bridge 和 Aspose.Slides PHP 包装器已初始化。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在保存演示文稿时管理应用程序和生成者的元数据；这些字段标识创建输出的软件。
{{% /alert %}}

## **管理演示文稿属性**

文档属性在演示文稿内容旁存储描述性信息。它们分为两类：

- **Built-in properties** 包含标准元数据，例如标题、作者和文档统计信息。
- **Custom properties** 保存用户定义的名称/值对。

Aspose.Slides for PHP via Java 提供对两类属性的访问。在 PowerPoint 中，选择 **File → Info → Properties → Advanced Properties** 来查看文档元数据。对话框将信息分为 **Summary**、**Statistics**、**Contents** 和 **Custom** 等选项卡。使用 **Custom** 选项卡来管理用户定义的属性。

## **从加密演示文稿读取公共属性**

打开密码通常同时保护演示文稿内容和文档属性。在调用 [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 并传入 `false` 后对演示文稿进行加密时，文档属性保持为公共。此时应用程序可以调用 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 并传入 `true`，在不提供打开密码的情况下读取公共元数据。

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 控制 Aspose.Slides 加载的内容；它并不执行解密。如果属性已被加密，则在没有密码的情况下加载会失败。如果演示文稿未加密，则该选项被忽略，完整的演示文稿将被加载。

该示例需要一个文档属性保持公共的加密演示文稿。它通过 [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 验证加载模式，然后通过 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) 读取内建属性：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

在此模式下，幻灯片内容不会被加载。幻灯片、母版、布局、形状、媒体以及其他演示文稿对象均不可用。应用程序在执行需要完整演示文稿对象模型的操作前应始终检查 [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded)。

{{% alert color="warning" title="Warning" %}}
公共元数据可能会泄露作者姓名、标题、主题、关键字、公司信息、注释以及自定义值。请将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统有特定需求在无需密码的情况下访问时，才将其保持公共。
{{% /alert %}}

## **更新加密演示文稿的属性**

对于加密的 PPTX 文件，在调用 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 并传入 `true` 后加载的演示文稿仅用于读取公共元数据。Aspose.Slides 无法从仅包含元数据的对象保存更改的属性，因为公共属性必须与加密演示文稿内部相应的数据保持一致。因此，更新这些属性需要正确的打开密码并完整加载演示文稿。

该示例需要一个具有公共文档属性并且已知打开密码的加密 PPTX 演示文稿。它使用 [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword) 打开完整演示文稿，更新公共内建属性并保存结果。随后使用 [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#isEncrypted) 验证加密仍然保留，并在不提供密码的情况下重新打开公共元数据以确认新值：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

如果应用程序不允许解密或加载演示文稿内容，则必须将加密 PPTX 文件的公共属性视为只读。

## **访问内建属性**

[DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) 类通过 getter 方法公开内建元数据，包括 [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getAuthor)、[getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTitle) 和 [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCreatedTime)。此示例打开现有演示文稿并将其存储的元数据打印到控制台。值取决于输入的演示文稿；某些字段可能为空。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

### **报告修订号和编辑时间**

要报告 `presentations` 文件夹中每个 PPTX 文件的修订号和总编辑时间，请使用 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) 在不加载幻灯片进行编辑的情况下读取其 [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/)。PHP via Java API 以毫秒返回编辑时间。示例将其转换为小时、分钟和秒，并在持续时间超过 24 小时时包含天数。

```php
use aspose\slides\PresentationFactory;

echo "File | RevisionNumber | TotalEditingTime\n";
foreach (new GlobIterator("presentations/*.pptx") as $file) {
    if (!$file->isFile()) {
        continue;
    }

    $info = PresentationFactory::getInstance()->getPresentationInfo($file->getRealPath());
    $properties = $info->readDocumentProperties();
    $totalSeconds = (int) (java_values($properties->getTotalEditingTime()) / 1000);
    $days = intdiv($totalSeconds, 86400);
    $time = sprintf("%02d:%02d:%02d", intdiv($totalSeconds, 3600) % 24, intdiv($totalSeconds, 60) % 60, $totalSeconds % 60);
    $editingTime = $days > 0 ? $days . "." . $time : $time;
    printf("%s | %d | %s\n", $file->getFilename(), java_values($properties->getRevisionNumber()), $editingTime);
}
```

对于修订号为 17、记录编辑时间为 1 天 2 小时 5 分钟的演示文稿，报告将显示以下输出。

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[DocumentProperties::getRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getRevisionNumber) 读取一个值，应用程序可以通过 [DocumentProperties::setRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setRevisionNumber) 更改它。仅凭修订号无法确定演示文稿保存的次数或重建其版本历史。

[DocumentProperties::getTotalEditingTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTotalEditingTime) 读取文件中记录的编辑时长。即使有人对演示文稿进行了编辑，它也可能存储为零时长 (`00:00:00`)。

## **修改内建属性**

要更新内建元数据，请使用由 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) 返回的对象上的 setter 方法。本示例打开现有演示文稿，调用 [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setAuthor)、[setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setTitle)、[setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setSubject)、[setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setComments) 和 [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setManager)，然后使用 [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) 保存更新后的演示文稿。保存的 PPTX 包含新的元数据。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **管理超链接基地址**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getHyperlinkBase) 返回文档级别的相对超链接基地址。使用 [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setHyperlinkBase) 可以更改或清除它。当移动演示文稿及其链接文件到其他位置时，这非常有用。它与单个超链接的 [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/#getExternalUrl) 分离：更改基地址不会重新写入已存储的链接地址或改变绝对目标。

该示例需要一个包含相对链接（例如 `target.html`）和绝对链接（例如 `https://example.org/absolute.html`）的演示文稿。它读取现有基地址，分配一个新的基地址，然后保存并重新打开演示文稿以检查该值。随后使用空字符串清除基地址，并在另一个保存的文件中验证为空值。请将示例基地址替换为您链接文件所在的位置。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

两个验证信息应输出 `true`。清除基地址不会影响各个超链接的地址。

当基地址指向 `old` 文件夹时，指向 `target.pptx` 的相对链接会打开 `old/target.pptx`。将基地址更改为 `new` 文件夹后，保存并重新打开演示文稿，同一链接会打开 `new/target.pptx`。绝对链接仍然打开相同的文件。在移动演示文稿或更改基地址前后，请在 PowerPoint 中测试您的相对链接。

## **添加自定义演示文稿属性**

自定义属性存储没有对应内建字段的元数据。[DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) 方法允许您按属性名称分配值。此示例创建一个演示文稿，添加两个文本值和一个整数版本值，并使用 [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) 保存演示文稿。对已有名称赋值会替换该属性的值。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **访问和修改自定义属性**

此示例打开包含自定义属性的演示文稿，并使用 [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCountOfCustomProperties) 遍历它们。[getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCustomPropertyName) 接受从零开始的索引并返回由 [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) 使用的名称。示例打印每个原始名称和值，无论原始类型如何，都将每个值替换为编号字符串，并保存更改。如果没有自定义属性，循环不会进行任何修改。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **实时示例**

尝试在线应用程序 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 以了解如何使用 Aspose.Slides API 操作文档属性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常见问题**

**如何从演示文稿中移除内建属性？**

内建属性是演示文稿的组成部分，无法完全移除。不过，您可以更改它们的值，或在特定属性允许的情况下将其设为空。

**如果我添加已经存在的自定义属性会怎样？**

如果您添加的自定义属性已存在，其现有值将被新值覆盖。无需在此之前删除或检查属性，因为 Aspose.Slides 会自动更新属性的值。

**我能在不完整加载演示文稿的情况下访问演示文稿属性吗？**

可以。使用 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/#getPresentationInfo) 然后调用 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) 可在不创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 实例的情况下读取存储的文档元数据。请参阅 [Build a Lightweight Presentation Inventory](/slides/zh/php-java/examine-presentation/) 获取完整的报告示例以及格式特定的限制。

**我能在没有打开密码的情况下读取加密演示文稿的公共属性吗？**

可以。演示文稿必须在调用 [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 并传入 `false` 后进行加密，并且在调用 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 并传入 `true` 后加载。

**我能在仅文档属性模式下更新加密的 PPTX 文件吗？**

不能。公共属性和加密属性的数据必须保持一致，因此更新加密的 PPTX 文件需要使用正确的打开密码完整加载演示文稿。