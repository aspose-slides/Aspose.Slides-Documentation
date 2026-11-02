---
title: 在 JavaScript 中管理演示文稿属性
linktitle: 演示文稿属性
type: docs
weight: 70
url: /zh/nodejs-java/presentation-properties/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js via Java 中精通演示文稿属性，并在您的 PowerPoint 和 OpenDocument 文件中简化搜索、品牌化和工作流。"
---
## **介绍**

Aspose.Slides for Node.js via Java 支持 **built-in** 和 **custom** 文档属性。使用这些属性读取和更新演示文稿元数据，例如作者、标题和用户定义的值。

Aspose.Slides 允许您通过 [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) 类操作演示文稿文档属性。该类的实例由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) 返回。以下示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在保存演示文稿时管理应用程序和生产者元数据；这些字段用于标识创建输出的软件。
{{% /alert %}}

## **管理演示文稿属性**

文档属性在演示文稿内容旁存储描述性信息。它们分为两类：

- **Built-in properties** 包含标准元数据，例如标题、作者和文档统计信息。
- **Custom properties** 存储用户定义的名称/值对。

Aspose.Slides for Node.js via Java 提供对两类属性的访问。在 PowerPoint 中，选择 **File → Info → Properties → Advanced Properties** 以检查文档元数据。对话框将信息分组到 **Summary**、**Statistics**、**Contents** 和 **Custom** 等选项卡。使用 **Custom** 选项卡管理用户自定义属性。

## **读取加密演示文稿的公共属性**

打开密码通常会保护演示文稿内容和文档属性。当在调用 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) 并传入 `false` 后对演示文稿进行加密时，其文档属性保持为公共。此时应用程序可以调用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 并传入 `true`，在不提供打开密码的情况下读取公共元数据。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 控制 Aspose.Slides 加载的内容；它并不进行解密。如果属性已被加密，则在没有密码的情况下加载会失败。如果演示文稿未加密，则该选项被忽略，完整的演示文稿将被加载。

示例需要一个文档属性保持公共的加密演示文稿。它通过 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) 验证加载模式，然后通过 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) 读取内置属性：

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

在此模式下，幻灯片内容不会被加载。幻灯片、母版、版式、形状、媒体以及其他演示文稿对象均不可用。应用程序在执行需要完整演示文稿对象模型的操作前应始终检查 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded)。

{{% alert color="warning" title="Warning" %}}
公共元数据可能泄露作者姓名、标题、主题、关键字、公司信息、注释以及自定义值。请将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统需要在无需密码的情况下访问时，才将其保持公共。
{{% /alert %}}

## **更新加密演示文稿的属性**

对于加密的 PPTX 文件，在调用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 并传入 `true` 后加载的演示文稿旨在读取公共元数据。Aspose.Slides 无法从仅包含元数据的对象保存更改的属性，因为公共属性必须与加密演示文稿内的相应数据保持一致。因此，更新这些属性需要正确的打开密码并完整加载演示文稿。

示例需要一个具有公共文档属性且已知打开密码的加密 PPTX 演示文稿。它使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword) 打开完整演示文稿，更新公共内置属性并保存结果。随后使用 [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) 验证加密仍然存在，并在不提供密码的情况下重新打开公共元数据以验证新值：

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

如果应用程序不被允许解密或加载演示文稿内容，则必须将加密 PPTX 文件的公共属性视为只读。

## **访问内置属性**

The [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) class exposes built-in metadata through getter methods, including [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle), and [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). This example opens an existing presentation and prints its stored metadata to the console. Values depend on the input presentation; some fields may be empty.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **修改内置属性**

要更新内置元数据，请对由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) 返回的对象使用 setter 方法。此示例打开现有演示文稿，调用 [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor)、[setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle)、[setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject)、[setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) 和 [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager)，随后使用 [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) 保存更新后的演示文稿。保存的 PPTX 包含新的元数据。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **管理超链接基准**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) 返回相对超链接的文档级基准。使用 [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) 可更改或清除该基准。当移动演示文稿及其链接文件到其他位置时，这非常有用。它与单个超链接的 [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) 是分离的：更改基准不会重写存储的链接地址或更改绝对目标。

示例需要一个包含相对链接（如 `target.html`）和绝对链接（如 `https://example.org/absolute.html`）的演示文稿。它读取现有基准，分配新的基准地址，并保存并重新打开演示文稿以检查该值。随后使用空字符串清除基准，并在另一个保存的文件中验证空值。请将示例基准地址替换为您的链接文件所在位置。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

两个验证消息应输出 `true`。清除基准后，单个超链接地址保持不变。

当基准指向 `old` 文件夹时，指向 `target.pptx` 的相对链接会打开 `old/target.pptx`。将基准更改为 `new` 文件夹后，保存并重新打开演示文稿，同一链接会打开 `new/target.pptx`。绝对链接仍然打开相同的文件。在移动演示文稿或更改其基准前后，请在 PowerPoint 中测试您的相对链接。

## **添加自定义演示文稿属性**

自定义属性存储没有对应内置字段的元数据。[DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) 方法允许您按属性名称分配值。此示例创建一个演示文稿，添加两个文本值和一个整数版本值，并使用 [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) 保存演示文稿。对已有名称赋值会替换该属性的值。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **访问和修改自定义属性**

此示例打开包含自定义属性的演示文稿，并使用 [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) 进行遍历。[getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) 接受从零开始的索引并返回由 [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) 使用的名称。示例打印每个原始名称和值，将每个值替换为带编号的字符串（不论原始类型），并保存更改。如果没有自定义属性，则循环不做任何修改。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **实时示例**

尝试在线应用程序 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 以了解如何使用 Aspose.Slides API 操作文档属性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常见问题**

**如何从演示文稿中删除内置属性？**

内置属性是演示文稿的组成部分，无法完全删除。不过，您可以更改它们的值，或在特定属性允许的情况下将其设为空。

**如果添加已经存在的自定义属性会怎样？**

如果添加的自定义属性已经存在，其现有值将被新值覆盖。无需事先删除或检查该属性，因为 Aspose.Slides 会自动更新属性的值。

**我可以在不完整加载演示文稿的情况下访问演示文稿属性吗？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo)，然后使用 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) 在不创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 实例的情况下读取存储的文档元数据。完整的报告示例和格式特定限制请参见 [Build a Lightweight Presentation Inventory](/slides/zh/nodejs-java/examine-presentation/)。

**我可以在没有打开密码的情况下读取加密演示文稿的公共属性吗？**

可以。演示文稿必须在调用 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) 并传入 `false` 后进行加密，并且在调用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) 并传入 `true` 后加载。

**我可以在仅加载文档属性模式下更新加密的 PPTX 文件吗？**

不能。公共属性和加密属性数据必须保持一致，因此更新加密的 PPTX 文件需要使用正确的打开密码完整加载演示文稿。