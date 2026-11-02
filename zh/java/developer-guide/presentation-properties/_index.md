---
title: 在 Java 中管理演示文稿属性
linktitle: 演示文稿属性
type: docs
weight: 70
url: /zh/java/presentation-properties/
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
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中精通演示文稿属性，并在您的 PowerPoint 和 OpenDocument 文件中简化搜索、品牌化和工作流。"
---
## **介绍**

Aspose.Slides for Java 支持 **内置** 和 **自定义** 文档属性。使用这些属性读取和更新演示文稿元数据，例如作者、标题和用户定义的值。

Aspose.Slides 允许您通过 [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) 接口操作演示文稿文档属性。该接口的实例由 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) 返回。以下示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在保存演示文稿时管理应用程序和生成者的元数据；这些字段标识创建输出的软件。
{{% /alert %}}

## **管理演示文稿属性**

文档属性在演示文稿内容旁存储描述性信息。它们分为两类：

- **内置属性** 包含标准元数据，例如标题、作者和文档统计信息。
- **自定义属性** 存储用户定义的名称/值对。

Aspose.Slides for Java 提供对两类属性的访问。在 PowerPoint 中，选择 **文件 → 信息 → 属性 → 高级属性** 来检查文档元数据。对话框将信息分组到 **摘要**、**统计**、**内容** 和 **自定义** 等选项卡中。使用 **自定义** 选项卡来管理用户定义的属性。

## **读取加密演示文稿的公共属性**

打开密码通常同时保护演示文稿内容和文档属性。当在调用 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 并传入 `false` 后对演示文稿进行加密时，其文档属性仍保持公共。此时应用程序可以调用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 并传入 `true`，在不提供打开密码的情况下读取公共元数据。

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 控制 Aspose.Slides 加载的内容；它不会进行解密。如果属性已被加密，则在没有密码的情况下加载会失败。如果演示文稿未加密，该选项被忽略，完整的演示文稿将被加载。

该示例需要一个文档属性保持公共的加密演示文稿。它通过 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) 验证加载模式，然后通过 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) 读取内置属性：

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

在此模式下，幻灯片内容未被加载。幻灯片、母版、布局、形状、媒体以及其他演示文稿对象均不可用。应用程序在执行需要完整演示文稿对象模型的操作之前，应始终检查 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--)。

{{% alert color="warning" title="Warning" %}}
公共元数据可能会暴露作者姓名、标题、主题、关键字、公司信息、评论和自定义值。请将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统明确需要在无需密码的情况下访问时才将其保持公共。
{{% /alert %}}

## **更新加密演示文稿的属性**

对于加密的 PPTX 文件，在调用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 并传入 `true` 后加载的演示文稿仅用于读取公共元数据。Aspose.Slides 无法从仅含元数据的对象保存更改的属性，因为公共属性必须与加密演示文稿中的相应数据保持一致。因此，更新这些属性需要正确的打开密码并完整加载演示文稿。

该示例需要一个具有公共文档属性且已知打开密码的加密 PPTX 演示文稿。它使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 打开完整演示文稿，更新公共内置属性并保存结果。随后使用 [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) 验证加密仍然保留，并在不提供密码的情况下重新打开公共元数据以验证新值：

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

如果应用程序不被允许解密或加载演示文稿内容，则必须将加密 PPTX 文件的公共属性视为只读。

## **访问内置属性**

[IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) 接口通过 getter 方法公开内置元数据，包括 [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--)、[getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--) 和 [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--)。此示例打开现有演示文稿并将其存储的元数据打印到控制台。值取决于输入的演示文稿；某些字段可能为空。

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

要更新内置元数据，请对由 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) 返回的对象使用 setter 方法。此示例打开现有演示文稿，调用 [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-)、[setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-)、[setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-)、[setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-)、[setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-)，然后使用 [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 保存更新后的演示文稿。保存的 PPTX 包含新的元数据。

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **管理超链接基址**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) 返回相对超链接的文档级基址。使用 [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) 可以更改或清除它。当移动演示文稿及其关联文件到其他位置时，这非常有用。它与单个超链接的 [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) 是分离的：更改基址不会重写已存储的链接地址或更改绝对目标。

该示例需要一个包含相对链接（例如 `target.html`）和绝对链接（例如 `https://example.org/absolute.html`）的演示文稿。它读取现有基址，分配新的基址，然后保存并重新打开演示文稿以检查该值。随后使用空字符串清除基址，并在另一个保存的文件中验证空值。请将示例基址替换为您链接文件所在的位置。

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

两个验证消息应打印 `true`。清除基址后，单个超链接地址保持不变。

当基址指向 `old` 文件夹时，对 `target.pptx` 的相对链接会打开 `old/target.pptx`。将基址更改为 `new` 文件夹并保存、重新打开演示文稿后，同一链接会打开 `new/target.pptx`。绝对链接仍然打开相同的文件。在移动演示文稿或更改基址前后，请在 PowerPoint 中测试您的相对链接。

## **添加自定义演示文稿属性**

自定义属性存储没有对应内置字段的元数据。[IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) 方法允许您按属性名称分配值。此示例创建一个演示文稿，添加两个文本值和一个整数版本值，并使用 [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 保存演示文稿。对已有名称赋值会替换该属性的值。

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

## **访问并修改自定义属性**

此示例打开包含自定义属性的演示文稿，并使用 [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) 进行遍历。[getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) 接受从零开始的索引并返回由 [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) 使用的名称。示例打印每个原始名称和值，将每个值替换为带编号的字符串（无论其原始类型），并保存更改。如果没有自定义属性，循环将不会进行任何修改。

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

尝试在线应用程序 [**查看并编辑 PowerPoint 元数据**](https://products.aspose.app/slides/metadata) 以了解如何使用 Aspose.Slides API 操作文档属性：

[![查看并编辑 PowerPoint 元数据](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常见问题**

**如何从演示文稿中删除内置属性？**

内置属性是演示文稿的组成部分，不能完全删除。不过，您可以更改它们的值，或在特定属性允许的情况下将其设置为空。

**如果添加的自定义属性已存在，会发生什么？**

如果添加的自定义属性已存在，其原有值将被新值覆盖。您无需事先删除或检查该属性，因为 Aspose.Slides 会自动更新属性的值。

**是否可以在不完全加载演示文稿的情况下访问演示文稿属性？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)，随后调用 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) 即可在不创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 实例的情况下读取存储的文档元数据。请参阅 [构建轻量级演示文稿清单](/slides/zh/java/examine-presentation/) 获取完整的报告示例以及特定格式的限制。

**是否可以在不提供打开密码的情况下读取加密演示文稿的公共属性？**

可以。演示文稿必须在调用 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 并传入 `false` 后进行加密，并且需要在调用 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) 并传入 `true` 后加载。

**是否可以在仅文档属性模式下更新加密的 PPTX 文件？**

不可以。公共属性和加密属性数据必须保持一致，因此要更新加密的 PPTX 文件，需要使用正确的打开密码完整加载演示文稿。