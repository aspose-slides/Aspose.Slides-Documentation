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
- 内置属性
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
description: "在 Aspose.Slides for PHP via Java 中掌握演示文稿属性，并在您的 PowerPoint 和 OpenDocument 文件中简化搜索、品牌和工作流。"
---
## **介绍**

Aspose.Slides for PHP via Java 支持 **内置** 和 **自定义** 文档属性。使用这些属性可以读取和更新演示文稿的元数据，例如作者、标题和用户定义的值。

Aspose.Slides 允许您通过 [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) 类来操作演示文稿的文档属性。该类的实例由 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) 返回。以下示例展示了如何读取、修改和管理这些属性。示例假设已初始化 PHP/Java Bridge 和 Aspose.Slides PHP 包装器。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在保存演示文稿时管理应用程序和制作者的元数据；这些字段标识了创建输出的软件。
{{% /alert %}}

## **管理演示文稿属性**

文档属性在演示文稿内容旁存储描述性信息。它们分为两类：

- **内置属性** 包含标准元数据，例如标题、作者和文档统计信息。
- **自定义属性** 存储用户定义的名称/值对。

Aspose.Slides for PHP via Java 提供对两类属性的访问。在 PowerPoint 中，选择 **文件 → 信息 → 属性 → 高级属性** 来检查文档元数据。该对话框将信息分组到诸如 **概要**、**统计信息**、**内容** 和 **自定义** 的选项卡中。使用 **自定义** 选项卡来管理用户定义的属性。

## **从加密的演示文稿读取公共属性**

打开密码通常同时保护演示文稿内容和文档属性。若在调用 [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) 并传入 `false` 后对演示文稿进行加密，则其文档属性保持为公共。此时应用程序可以调用 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) 并传入 `true`，在不提供打开密码的情况下读取公共元数据。

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) 控制 Aspose.Slides 的加载行为；它并不进行解密。如果属性被包含在加密中，则在没有密码的情况下加载会失败。如果演示文稿未加密，则此选项被忽略，完整的演示文稿会被加载。

该示例需要一个文档属性保持为公共的加密演示文稿。它通过 [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) 验证加载模式，然后通过 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) 读取内置属性：

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

在此模式下，幻灯片内容不会被加载。幻灯片、母版、布局、形状、媒体以及其他演示文稿对象均不可用。应用程序在执行需要完整演示文稿对象模型的操作前，应始终检查 [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/)。

{{% alert color="warning" title="Warning" %}}
公共元数据可能泄露作者姓名、标题、主题、关键词、公司信息、注释以及自定义值。应将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统明确需要在不使用密码的情况下访问时，才将其保持为公共。
{{% /alert %}}

## **更新加密演示文稿的属性**

对于加密的 PPTX 文件，在调用 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) 并传入 `true` 后加载的演示文稿仅用于读取公共元数据。Aspose.Slides 无法从仅包含元数据的对象保存更改的属性，因为公共属性必须与加密演示文稿内部对应的数据保持一致。因此，更新这些属性需要正确的打开密码并完整加载演示文稿。

该示例需要一个文档属性为公共且已知打开密码的加密 PPTX 演示文稿。它使用 [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/) 打开完整的演示文稿，更新公共内置属性并保存结果。随后利用 [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) 验证加密仍然保留，并在不提供密码的情况下重新打开公共元数据以验证新值：

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

如果应用程序不被允许解密或加载演示文稿内容，则必须将加密 PPTX 文件的公共属性视为只读。

## **访问内置属性**

[DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) 类通过 getter 方法公开内置元数据，包括 [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/)、[getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/) 和 [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/)。本示例打开现有演示文稿并将其存储的元数据打印到控制台。值取决于输入的演示文稿；某些字段可能为空。

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

## **修改内置属性**

要更新内置元数据，请对 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) 返回的对象使用 setter 方法。本示例打开现有演示文稿，调用 [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/)、[setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/)、[setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/)、[setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/) 和 [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/)，随后使用 [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) 保存更新后的演示文稿。保存的 PPTX 包含新的元数据。

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

## **管理超链接基址**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) 返回文档级别的相对超链接基址。使用 [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) 可更改或清除该基址。当将演示文稿及其链接文件移动到其他位置时，这非常有用。它与单个超链接的 [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) 是分离的：更改基址不会重写已存储的链接地址或更改绝对目标。

该示例需要一个包含相对链接（例如 `target.html`）和绝对链接（例如 `https://example.org/absolute.html`）的演示文稿。它读取现有基址，分配新的基址地址，保存并重新打开演示文稿以检查该值。随后使用空字符串清除基址，并在另一个保存的文件中验证空值。请将示例基址替换为您链接文件所在的位置。

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

两个验证消息应输出 `true`。清除基址后，单个超链接地址保持不变。

当基址指向 `old` 文件夹时，相对链接 `target.pptx` 打开 `old/target.pptx`。将基址更改为 `new` 文件夹后，保存并重新打开演示文稿，同一链接打开 `new/target.pptx`。绝对链接仍然打开相同的文件。在移动演示文稿或更改基址前后，请在 PowerPoint 中测试您的相对链接。

## **添加自定义演示文稿属性**

自定义属性存储没有对应内置字段的元数据。[DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) 方法允许您按属性名称分配值。本示例创建一个演示文稿，添加两个文本值和一个整数版本值，并使用 [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) 保存演示文稿。为已有名称分配值会替换该属性的值。

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

本示例打开包含自定义属性的演示文稿，并使用 [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) 对其进行迭代。 [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) 接受从零开始的索引并返回由 [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) 使用的名称。示例打印每个原始名称和值，将所有值替换为带编号的字符串（不论其原始类型），并保存更改。如果没有自定义属性，循环不会进行任何修改。

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

尝试在线应用程序 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 了解如何使用 Aspose.Slides API 操作文档属性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常见问题**

**如何从演示文稿中移除内置属性？**

内置属性是演示文稿的组成部分，无法完全删除。不过，您可以更改其值，或在特定属性允许的情况下将其设为空。

**如果我添加的自定义属性已存在，会发生什么？**

如果添加的自定义属性已经存在，其现有值将被新值覆盖。您无需事先删除或检查该属性，Aspose.Slides 会自动更新属性值。

**我能在不完整加载演示文稿的情况下访问演示文稿属性吗？**

是的。使用 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) 然后 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) 可在不创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 实例的情况下读取存储的文档元数据。请参阅 [构建轻量级演示文稿清单](/slides/zh/php-java/examine-presentation/) 了解完整的报告示例以及格式特定的限制。

**我能在不提供打开密码的情况下读取加密演示文稿的公共属性吗？**

是的。演示文稿必须在调用 [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) 并传入 `false` 后进行加密，并且需在调用 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) 并传入 `true` 后加载。

**我能在仅文档属性模式下更新加密的 PPTX 文件吗？**

不能。公共属性和加密属性数据必须保持一致，因此更新加密的 PPTX 文件需要使用正确的打开密码完整加载演示文稿。