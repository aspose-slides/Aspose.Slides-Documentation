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
description: "在 Aspose.Slides for Java 中掌握演示文稿属性，并在 PowerPoint 和 OpenDocument 文件中简化搜索、品牌化和工作流。"
---
## **简介**

Aspose.Slides 支持两种文档属性类型：**内置**和**自定义**。可以使用 Aspose.Slides API 轻松访问和管理这两种属性类型。

Aspose.Slides 允许通过 [IDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides.idocumentproperties/) 接口处理演示文稿的文档属性。该接口的实例由 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ipresentation/#getDocumentProperties--) 返回。以下示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}
请注意，**Application** 和 **AppVersion** 字段不可修改。Aspose.Slides 在每次保存时都会重写它们，因此已保存的演示文稿始终报告为 “Aspose.Slides for Java” 以及生成它的库版本。传递给 `setNameOfApplication` 的任何值在写入演示文稿时都会被丢弃。
{{% /alert %}} 

## **PowerPoint 中的文档属性**

Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。只需单击 Office 图标，然后选择 **Prepare | Properties | Advanced Properties** 菜单项，如下所示：

|**选择高级属性菜单项**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
选择 **Advanced Properties** 菜单项后，会出现一个对话框，允许您管理 PowerPoint 文件的文档属性，如下图所示：

|**属性对话框**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
在上述 **属性对话框** 中，您可以看到有 **General**、**Summary**、**Statistics**、**Contents** 和 **Custom** 等选项卡。这些选项卡允许配置与 PowerPoint 文件相关的不同信息。**Custom** 选项卡用于管理 PowerPoint 文件的自定义属性。

使用 Aspose.Slides for Java 处理文档属性

正如前面所述，Aspose.Slides for Java 支持 **内置** 和 **自定义** 两种文档属性。因此，开发人员可以通过 Aspose.Slides for Java API 访问这两类属性。Aspose.Slides for Java 提供了一个表示演示文稿文件相关文档属性的类 [IDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides.idocumentproperties)，通过 **Presentation.DocumentProperties** 属性获取。

开发人员可以使用 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides.presentation) 对象公开的 **IDocumentProperties** 属性来访问演示文稿文件的文档属性，如下所示：

## **从加密演示文稿读取公开属性**

打开密码通常会保护演示文稿内容和文档属性。当通过将 `false` 传递给 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides.iprotectionmanager/#setEncryptDocumentProperties-boolean-) 来加密演示文稿时，其文档属性保持公开。此时应用程序可以将 `true` 传递给 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides.loadoptions/#setOnlyLoadDocumentProperties-boolean-)，在不提供打开密码的情况下读取公开的元数据。

文档属性仅加载选项控制 Aspose.Slides 加载的内容；它不进行任何解密。如果属性已被加密，则在未提供密码的情况下加载会失败。如果演示文稿未加密，则该选项被忽略，完整演示文稿将被加载。

下面的示例通过 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh/java/com.aspose.slides.iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) 验证加载模式，然后通过 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ipresentation/#getDocumentProperties--) 读取内置属性：

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

在此模式下，不会加载幻灯片内容。幻灯片、母版、布局、形状、媒体及其他演示对象均不可用。应用程序应在执行需要完整演示对象模型的操作前，始终检查 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh/java/com.aspose.slides.iprotectionmanager/#isOnlyDocumentPropertiesLoaded--)。

{{% alert color="warning" title="Warning" %}}
公开的元数据可能会泄露作者姓名、标题、主题、关键字、公司信息、注释以及自定义值。请将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统需要在不提供密码的情况下访问时，才将其保持公开。
{{% /alert %}}

## **更新加密演示文稿的属性**

对于加密的 PPTX 文件，以仅文档属性模式加载的演示文稿旨在读取公开的元数据。Aspose.Slides 无法从仅元数据对象保存已更改的属性，因为公开属性必须与加密演示文稿内部对应的数据保持一致。因此，更新这些属性需要提供正确的打开密码并完整加载演示文稿。

下面的示例使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh/java/com.aspose.slides.loadoptions/#setPassword-java.lang.String-) 打开演示文稿，更新公开的内置属性并保存结果。随后使用 [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ipresentationinfo/#isEncrypted--) 验证加密仍然保留，并在不提供密码的情况下重新打开公开元数据以验证新值：

```java
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
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

[IDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides.idocumentproperties) 对象公开的属性包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最后打印日期）、**LastModifiedBy**、**SharedDoc**（是否在不同制作者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**。

```java
import com.aspose.slides.*;

// 实例化代表演示文稿的 Presentation 类
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 创建与 Presentation 关联的 IDocumentProperties 对象引用
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 显示内置属性
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **修改内置属性**

修改演示文稿文件的内置属性与访问它们一样简单。只需为任意所需属性赋予字符串值，即可修改属性值。下面的示例演示了如何使用 Aspose.Slides for Java 修改演示文稿的内置文档属性。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // 创建与 Presentation 关联的 IDocumentProperties 对象引用
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 设置内置属性
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // 将演示文稿保存到文件
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

该示例修改后的内置属性如下所示：

|**修改后的内置文档属性**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **添加自定义文档属性**

Aspose.Slides for Java 还允许开发人员为演示文稿的文档属性添加自定义值。下面的示例添加了三个自定义属性，然后查找索引 2 处的名称并将其移除，因此保存的演示文稿中保留了两个属性。自定义属性按字母顺序索引，而不是添加顺序。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // 获取文档属性
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // 添加自定义属性
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // 获取特定索引处的属性名称
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // 删除选定的属性
    dProps.removeCustomProperty(getPropertyName);
    
    // 保存演示文稿
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**已添加的自定义文档属性**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **访问并修改自定义属性**

Aspose.Slides for Java 还允许开发人员访问自定义属性的值。下面的示例展示了如何访问并修改演示文稿的所有自定义属性。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // 创建与 Presentation 关联的 DocumentProperties 对象引用
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 访问并修改自定义属性
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // 显示自定义属性的名称和值
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // 修改自定义属性的值
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // 将演示文稿保存到文件
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

该示例修改了 [PPTX](https://docs.fileformat.com/presentation/pptx/) 演示文稿的自定义属性。下图分别展示了修改前后的自定义属性：

|**修改前的自定义属性**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改后的自定义属性**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高级文档属性**

{{% alert color="info" title="Note" %}}
已在 [IPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides.IPresentationInfo) 中添加新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides.IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides.IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 和 [WriteBindedPresentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides.IPresentationInfo#writeBindedPresentation-java.lang.String-)，并修改了 [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh/java/com.aspose.slides.idocumentproperties#setLastSavedTime-java.util.Date-) 属性设置器的逻辑。
{{% /alert %}} 

已向 [IPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides.IPresentationInfo) 接口添加了两个新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides.IPresentationInfo#readDocumentProperties--) 和 [UpdateDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides.IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)。它们提供了快速访问文档属性的方式，并允许在不加载完整演示文稿的情况下更改和更新属性。

典型场景是加载属性、修改某些值，然后更新文档，可按以下方式实现：

```java
import com.aspose.slides.*;

// 读取演示文稿的信息
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// 获取当前属性
IDocumentProperties props = info.readDocumentProperties();

// 设置 Author 和 Title 字段的新值
props.setAuthor("New Author");
props.setTitle("New Title");

// 使用新值更新演示文稿
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

还可以将特定演示文稿的属性用作模板，以更新其他演示文稿的属性：

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

也可以从头创建新模板，然后用于更新多个演示文稿：

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **设置校对语言**

Aspose.Slides 提供了 LanguageId 属性（由 PortionFormat 类公开），用于设置 PowerPoint 文档的校对语言。校对语言是 PowerPoint 检查拼写和语法时使用的语言。

以下 Java 代码演示如何为 PowerPoint 设置校对语言：

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // 设置校对语言的 Id

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置默认语言**

以下 Java 代码演示如何为整个 PowerPoint 演示文稿设置默认语言：

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // 添加一个带文本的矩形形状
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // 检查第一个部分的语言
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **实时示例**

尝试在线应用程序 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh/metadata) 查看如何通过 Aspose.Slides API 操作文档属性：

[![查看并编辑 PowerPoint 元数据](slides-metadata.png)](https://products.aspose.app/slides/zh/metadata)

## **常见问题**

**如何从演示文稿中移除内置属性？**

内置属性是演示文稿的组成部分，无法完全删除。不过，您可以更改其值，或者在特定属性允许的情况下将其设为空。

**如果添加已存在的自定义属性会怎样？**

如果添加的自定义属性已存在，原有的值会被新值覆盖。无需事先删除或检查属性，Aspose.Slides 会自动更新属性值。

**是否可以在未完整加载演示文稿的情况下访问演示文稿属性？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides.presentationfactory/#getPresentationInfo-java.lang.String-) 然后调用 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides.ipresentationinfo/#readDocumentProperties--) 即可在不创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides.presentation/) 实例的情况下读取存储的文档元数据。请参阅 [构建轻量级演示文稿清单](/slides/zh/java/examine-presentation/) 获取完整的报告示例及格式特定限制。

**是否可以在不提供打开密码的情况下读取加密演示文稿的公开属性？**

可以。前提是文档属性加密在演示文稿加密之前已被禁用，并且演示文稿以仅文档属性模式加载。

**是否可以在仅文档属性模式下更新加密的 PPTX 文件？**

不可以。公开属性和加密属性的数据必须保持一致，因此更新加密的 PPTX 文件需要使用正确的打开密码完整加载演示文稿。