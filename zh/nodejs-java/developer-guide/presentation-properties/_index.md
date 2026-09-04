---
title: 管理 JavaScript 中的演示文稿属性
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
## **简介**

Aspose.Slides 支持两种类型的文档属性：**内置** 和 **自定义**。这两种属性类型都可以使用 Aspose.Slides API 轻松访问和管理。

Aspose.Slides 允许您通过 [DocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/) 类来操作演示文稿的文档属性。此类的实例由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getDocumentProperties) 方法返回。以下示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}
请注意，**Application** 和 **AppVersion** 字段无法修改。Aspose.Slides 在每次保存时都会重新写入它们，因此已保存的演示文稿始终报告为 “Aspose.Slides for Node.js via Java” 以及生成它的库版本。传递给 `setNameOfApplication` 的任何值在写入演示文稿时都会被丢弃。
{{% /alert %}} 

## **管理演示文稿属性**

Microsoft PowerPoint 提供了一项向演示文件添加属性的功能。这些文档属性允许在文档（演示文件）中存储一些有用的信息。文档属性分为以下两类：

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置** 属性包含文档的一般信息，例如文档标题、作者姓名、文档统计信息等。**自定义** 属性是用户以 **名称/值** 对的形式定义的，其中名称和值均由用户自行定义。使用 Aspose.Slides for Node.js via Java，开发人员可以访问和修改内置属性以及自定义属性的值。

## **PowerPoint 中的文档属性**

Microsoft PowerPoint 2007 允许管理演示文件的文档属性。只需单击 Office 图标，然后选择 **准备 | 属性 | 高级属性** 如下所示：

|**选择高级属性菜单项**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
选择 **高级属性** 菜单项后，会出现一个对话框，允许您管理 PowerPoint 文件的文档属性，如下图所示：

|**属性对话框**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
在上述 **属性对话框** 中，您可以看到多个选项卡，如 **常规**、**摘要**、**统计信息**、**内容** 和 **自定义**。所有这些选项卡都用于配置与 PowerPoint 文件相关的不同信息。**自定义** 选项卡用于管理 PowerPoint 文件的自定义属性。

使用 Aspose.Slides for Node.js via Java 操作文档属性

正如前面所述，Aspose.Slides for Node.js via Java 支持两种文档属性，即 **内置** 和 **自定义** 属性。因此，开发人员可以使用 Aspose.Slides for Node.js via Java API 访问这两种属性。Aspose.Slides for Node.js via Java 提供了一个 [DocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties) 类，通过 **Presentation.DocumentProperties** 属性表示与演示文件关联的文档属性。

开发人员可以使用由 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation) 对象公开的 **DocumentProperties** 属性来访问演示文件的文档属性，如下所示：

## **从加密演示文稿读取公共属性**

打开密码通常会保护演示内容和文档属性。当通过将 `false` 传递给 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 来加密演示文稿时，其文档属性保持公共。此时应用程序可以将 `true` 传递给 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 并在不提供打开密码的情况下读取公共元数据。

仅文档属性选项控制 Aspose.Slides 加载的内容；它不会解密任何内容。如果属性已包含在加密中，未提供密码加载将失败。如果演示文稿未加密，则忽略该选项并加载完整演示文稿。

以下示例通过 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 验证加载模式，然后通过 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getDocumentProperties) 读取内置属性：

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

在此模式下，不会加载幻灯片内容。幻灯片、母版、布局、形状、媒体及其他演示对象均不可用。应用程序在执行需要完整演示对象模型的操作前，应始终检查 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded)。

{{% alert color="warning" title="Warning" %}}
公共元数据可能会暴露作者姓名、标题、主题、关键字、公司信息、注释以及自定义值。请将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统需要在没有密码的情况下访问时，才将其设为公开。
{{% /alert %}}

## **更新加密演示文稿的属性**

对于加密的 PPTX 文件，以仅文档属性模式加载的演示文稿旨在读取公共元数据。Aspose.Slides 无法从该仅元数据对象保存更改的属性，因为公共属性必须与加密演示文稿内部的相应数据保持一致。因此，更新这些属性需要正确的打开密码并完整加载演示文稿。

以下示例使用 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#setPassword) 打开演示文稿，更新公共内置属性并保存结果。随后使用 [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) 验证加密仍然存在，并在不使用密码的情况下重新打开公共元数据以验证新值：

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

通过 [DocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties) 对象公开的属性包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最近打印日期）、**LastModifiedBy**、**SharedDoc**（是否在不同生产者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 实例化表示演示文稿的 Presentation 类
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 创建指向与演示文稿关联的 IDocumentProperties 对象的引用
    var dp = pres.getDocumentProperties();
    // 显示内置属性
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **修改内置属性**

修改演示文件的内置属性和访问它们一样简单。只需将字符串值分配给任意所需属性，即可修改属性值。下面的示例演示了如何使用 Aspose.Slides for Node.js via Java 修改演示文件的内置文档属性。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 创建指向与演示文稿关联的 IDocumentProperties 对象的引用
    var dp = pres.getDocumentProperties();
    // 设置内置属性
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // 将演示文稿保存到文件
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

此示例修改了演示文稿的内置属性，修改后效果如下所示：

|**修改后内置文档属性**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **添加自定义文档属性**

Aspose.Slides for Node.js via Java 还允许开发人员为演示文稿的文档属性添加自定义值。下面的示例展示了如何为演示文稿设置自定义属性。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // 获取文档属性
    var dProps = pres.getDocumentProperties();
    // 添加自定义属性
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // 获取特定索引处的属性名称
    var getPropertyName = dProps.getCustomPropertyName(2);
    // 删除选中的属性
    dProps.removeCustomProperty(getPropertyName);
    // 保存演示文稿
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**已添加的自定义文档属性**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **访问和修改自定义属性**

Aspose.Slides for Node.js via Java 还允许开发人员访问自定义属性的值。下面的示例展示了如何访问并修改演示文稿的所有自定义属性。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 创建指向与演示文稿关联的 DocumentProperties 对象的引用
    var dp = pres.getDocumentProperties();
    // 访问并修改自定义属性
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // 显示自定义属性的名称和值
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // 修改自定义属性的值
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // 将演示文稿保存到文件
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

此示例修改了 [PPTX](https://docs.fileformat.com/presentation/pptx/) 演示文稿的自定义属性。下图显示了修改前后的演示文稿自定义属性：

|**修改前的自定义属性**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改后的自定义属性**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高级文档属性**

{{% alert color="info" title="Note" %}}
新增了 [ReadDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) 和 [WriteBindedPresentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) 方法至 [PresentationInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PresentationInfo)，并更改了 [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) 属性设置器的逻辑。
{{% /alert %}} 

新的两种方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) 和 [UpdateDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) 已添加到 [PresentationInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/PresentationInfo) 类中。它们提供了对文档属性的快速访问，并允许在不加载完整演示文稿的情况下更改和更新属性。

典型的场景是加载属性、修改某些值并更新文档，可按以下方式实现：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 读取演示文稿的信息
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
var props = info.readDocumentProperties();
props.setAuthor("New Author");
props.setTitle("New Title");
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

还有一种方法是将特定演示文稿的属性用作模板，以更新其他演示文稿中的属性：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

可以从零创建新模板，然后用于更新多个演示文稿：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **设置校对语言**

Aspose.Slides 提供了 LanguageId 属性（由 PortionFormat 类公开），允许您为 PowerPoint 文档设置校对语言。校对语言是 PowerPoint 检查拼写和语法时使用的语言。

下面的 JavaScript 代码演示了如何为 PowerPoint 设置校对语言：xxx 为什么 JavaScript PortionFormat 类中缺少 LanguageId？

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// set the Id of a proofing language
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **设置默认语言**

下面的 JavaScript 代码演示了如何为整个 PowerPoint 演示文稿设置默认语言：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // 添加一个带文本的新矩形形状
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // 检查第一个文本分段的语言
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **实时示例**

尝试在线应用 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh/metadata) 了解如何通过 Aspose.Slides API 处理文档属性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/zh/metadata)

## **常见问题**

**如何从演示文稿中移除内置属性？**

内置属性是演示文稿的组成部分，不能完全移除。不过，您可以更改其值，或在特定属性允许的情况下将其设为空。

**如果添加已存在的自定义属性会怎样？**

如果添加的自定义属性已存在，其原有值将被新值覆盖。无需事先删除或检查属性，Aspose.Slides 会自动更新属性值。

**我可以在不完全加载演示文稿的情况下访问演示属性吗？**

可以。使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) 然后调用 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) 即可在不创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 实例的情况下读取存储的文档元数据。有关完整报告示例和特定格式限制，请参阅 [构建轻量级演示清单](/slides/zh/nodejs-java/examine-presentation/)。

**我可以在不提供打开密码的情况下读取加密演示文稿的公共属性吗？**

可以。前提是文档属性加密在演示文稿加密之前已被禁用，并且演示文稿以仅文档属性模式加载。

**我可以在仅文档属性模式下更新加密的 PPTX 文件吗？**

不能。公共属性和加密属性的数据必须保持一致，因此在仅文档属性模式下更新加密的 PPTX 文件需要使用正确的打开密码完整加载演示文稿。