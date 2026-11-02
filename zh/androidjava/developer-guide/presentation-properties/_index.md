---
title: 在 Android 上管理演示文稿属性
linktitle: 演示文稿属性
type: docs
weight: 70
url: /zh/androidjava/presentation-properties/
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
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android via Java 中掌握演示文稿属性，并简化 PowerPoint 和 OpenDocument 文件的搜索、品牌化和工作流。"
---
## **简介**

Aspose.Slides for Android via Java 支持 **内置** 和 **自定义** 文档属性。使用这些属性读取和更新演示文稿的元数据，例如作者、标题和用户定义的值。

Aspose.Slides 允许通过 [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) 接口操作演示文稿的文档属性。该接口的实例由 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) 返回。以下示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}

Aspose.Slides 在保存演示文稿时管理应用程序和生成者的元数据；这些字段标识创建输出的软件。

{{% /alert %}}

## **管理演示文稿属性**

文档属性在演示文稿内容旁存储描述性信息。它们分为两类：

- **内置属性** 包含标准元数据，如标题、作者和文档统计信息。
- **自定义属性** 保存用户定义的名称/值对。

Aspose.Slides for Android via Java 提供对这两类的访问。在 PowerPoint 中，选择 **文件 → 信息 → 属性 → 高级属性** 检查文档元数据。该对话框将信息分组为 **摘要**、**统计信息**、**内容** 和 **自定义** 等选项卡。使用 **自定义** 选项卡管理用户定义的属性。

## **从加密演示文稿读取公开属性**

打开密码通常保护演示文稿内容和文档属性。当在调用 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 并传入 `false` 后加密演示文稿时，其文档属性仍保持公开。此时应用程序可以调用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 并传入 `true`，在不提供打开密码的情况下读取公开元数据。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 控制 Aspose.Slides 加载的内容；它不进行解密。如果属性已被加密，未提供密码加载将失败。如果演示文稿未加密，则此选项被忽略，完整演示文稿将被加载。

示例需要一个文档属性保持公开的加密演示文稿。它通过 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) 验证加载模式，然后通过 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) 读取内置属性：

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

在此模式下，幻灯片内容不会被加载。幻灯片、母版、布局、形状、媒体以及其他演示文稿对象不可用。应用程序在执行需要完整演示文稿对象模型的操作前，应始终检查 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--)。

{{% alert color="warning" title="Warning" %}}
公开的元数据可能泄露作者姓名、标题、主题、关键字、公司信息、注释以及自定义值。请将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统需要在不提供密码的情况下访问时才将其保持公开。
{{% /alert %}}

## **更新加密演示文稿的属性**

对于加密的 PPTX 文件，在调用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 并传入 `true` 后加载的演示文稿旨在读取公开元数据。Aspose.Slides 无法从该仅元数据对象保存更改后的属性，因为公共属性必须与加密演示文稿内部对应的数据保持一致。因此，更新它们需要正确的打开密码并进行完整加载。

示例需要一个拥有公开文档属性且已知打开密码的加密 PPTX 演示文稿。它使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 打开完整演示文稿，更新公开的内置属性，并保存结果。随后使用 [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) 验证加密仍然保留，并在不提供密码的情况下重新打开公开元数据以验证新值：

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

如果应用程序不被允许解密或加载演示文稿内容，则必须将加密 PPTX 文件的公开属性视为只读。

## **访问内置属性**

[IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) 接口通过 getter 方法公开内置元数据，包括 [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--)、[getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--) 和 [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--)。此示例打开现有演示文稿并将其存储的元数据打印到控制台。值取决于输入的演示文稿；某些字段可能为空。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **修改内置属性**

要更新内置元数据，请对由 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) 返回的对象使用 setter 方法。此示例打开现有演示文稿，调用 [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-)、[setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-)、[setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-)、[setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-)、[setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-)，然后使用 [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 保存更新后的演示文稿。保存的 PPTX 包含新的元数据。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Android via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **管理超链接基准**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) 返回文档级别的相对超链接基准。使用 [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) 更改或清除它。当将演示文稿及其链接文件移动到其他位置时，这非常有用。它与单个超链接的 [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) 是分开的：更改基准不会重写存储的链接地址或更改绝对目标。

示例需要一个包含相对链接（如 `target.html`）和绝对链接（如 `https://example.org/absolute.html`）的演示文稿。它读取现有基准，分配新的基准地址，保存并重新打开演示文稿以检查该值。随后使用空字符串清除基准，并在单独的保存文件中验证空值。请将示例基准地址替换为链接文件所在位置。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
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

两个验证消息应打印 `true`。清除基准后，单个超链接地址保持不变。

相对链接 `target.pptx` 在基准指向 `old` 文件夹时打开 `old/target.pptx`。将基准更改为 `new` 文件夹后，保存并重新打开演示文稿，同一链接将打开 `new/target.pptx`。绝对链接仍然打开相同的文件。在 PowerPoint 中移动演示文稿或更改基准前后，请测试相对链接。

## **添加自定义演示文稿属性**

自定义属性存储没有对应内置字段的元数据。[IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) 方法允许按属性名称分配值。此示例创建演示文稿，添加两个文本值和一个整数版本值，并使用 [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 保存演示文稿。对已有名称赋值会替换该属性的值。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **访问和修改自定义属性**

此示例打开包含自定义属性的演示文稿，并使用 [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) 迭代它们。[getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) 接受从零开始的索引并返回用于 [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) 的名称。示例打印每个原始名称和值，将每个值替换为带编号的字符串（无论原始类型），并保存更改。如果没有自定义属性，循环不会进行任何更改。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **实时示例**

尝试在线应用程序 [**查看并编辑 PowerPoint 元数据**](https://products.aspose.app/slides/metadata) 了解如何使用 Aspose.Slides API 操作文档属性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常见问题**

**如何从演示文稿中删除内置属性？**

内置属性是演示文稿的组成部分，无法完全删除。但您可以更改其值，或在特定属性允许的情况下将其设为空。

**如果添加已存在的自定义属性会怎样？**

如果添加已存在的自定义属性，其现有值将被新值覆盖。您无需事先删除或检查属性，Aspose.Slides 会自动更新属性值。

**我可以在不完整加载演示文稿的情况下访问演示文稿属性吗？**

是的。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 然后 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 可在不创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 实例的情况下读取存储的文档元数据。参见 [Build a Lightweight Presentation Inventory](/slides/zh/androidjava/examine-presentation/) 获取完整报告示例及格式特定限制。

**我可以在没有打开密码的情况下读取加密演示文稿的公开属性吗？**

是的。演示文稿必须在调用 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 并传入 `false` 后加密，且必须在调用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 并传入 `true` 后加载。

**我可以在仅文档属性模式下更新加密的 PPTX 文件吗？**

不能。公共和加密的属性数据必须保持一致，因此在仅文档属性模式下更新加密的 PPTX 文件需要使用正确的打开密码加载完整演示文稿。