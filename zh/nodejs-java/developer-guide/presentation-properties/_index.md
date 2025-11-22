---
title: 演示文稿属性
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
- 修改属性
- 文档元数据
- 编辑元数据
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "在 JavaScript 中管理 PowerPoint 演示文稿属性"
---

{{% alert color="primary" %}} 

Microsoft PowerPoint 提供了向演示文稿文件添加一些属性的功能。这些文档属性允许在文档（演示文稿文件）中存储一些有用的信息。文档属性分为以下两类：

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置**属性包含有关文档的一般信息，如文档标题、作者姓名、文档统计信息等。**自定义**属性是用户以 **名称/值** 对的形式定义的属性，名称和值均由用户自行定义。使用 Aspose.Slides for Node.js via Java，开发人员可以访问和修改内置属性以及自定义属性的值。

{{% /alert %}} 

## **PowerPoint 中的文档属性**

Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。您只需点击 Office 图标，然后进一步选择 **准备 | 属性 | 高级属性** 菜单项，如下所示：

{{% alert color="primary" %}} 

请注意，您无法设置 **Application** 和 **Producer** 字段的值，因为 Aspose Ltd. 和 Aspose.Slides for Node.js via Java x.x.x 将显示在这些字段中。

{{% /alert %}} 

|**选择高级属性菜单项**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

选择 **高级属性** 菜单项后，会出现如下对话框，允许您管理 PowerPoint 文件的文档属性：

|**属性对话框**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

在上述 **属性对话框** 中，您可以看到有多个选项卡页，如 **常规**、**摘要**、**统计**、**内容** 和 **自定义**。所有这些选项卡页允许配置与 PowerPoint 文件相关的不同类型信息。**自定义** 选项卡用于管理 PowerPoint 文件的自定义属性。

### 使用 Aspose.Slides for Node.js via Java 处理文档属性

如前所述，Aspose.Slides for Node.js via Java 支持两类文档属性，即 **内置** 和 **自定义** 属性。因此，开发人员可以使用 Aspose.Slides for Node.js via Java API 访问这两类属性。Aspose.Slides for Node.js via Java 提供了一个表示与演示文稿文件关联的文档属性的类 [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties)，通过 **Presentation.DocumentProperties** 属性获取。

开发人员可以使用由 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 对象公开的 **DocumentProperties** 属性来访问演示文稿文件的文档属性，如下所示：

## **访问内置属性**

这些属性由 [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties) 对象公开，包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最后打印日期）、**LastModifiedBy**、**SharedDoc**（是否在不同制作者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**  
```javascript
// 实例化代表演示文稿的 Presentation 类
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 创建对与 Presentation 关联的 IDocumentProperties 对象的引用
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

修改演示文稿文件的内置属性与访问它们一样简单。您只需为任意所需属性赋一个字符串值即可修改属性值。在下面的示例中，我们演示了如何使用 Aspose.Slides for Node.js via Java 修改演示文稿的内置文档属性。  
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 创建与 Presentation 关联的 IDocumentProperties 对象的引用
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


此示例修改了演示文稿的内置属性，修改后效果如下：

|**修改后的内置文档属性**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **添加自定义文档属性**

Aspose.Slides for Node.js via Java 还允许开发人员为演示文稿的文档属性添加自定义值。下面的示例展示了如何为演示文稿设置自定义属性。  
```javascript
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
    // 删除选定的属性
    dProps.removeCustomProperty(getPropertyName);
    // 保存演示文稿
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|**已添加的自定义文档属性**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **访问并修改自定义属性**

Aspose.Slides for Node.js via Java 也允许开发人员访问自定义属性的值。下面的示例展示了如何访问并修改演示文稿的所有自定义属性。  
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 创建与 Presentation 关联的 DocumentProperties 对象的引用
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


此示例修改了 [PPTX](https://docs.fileformat.com/presentation/pptx/) 演示文稿的自定义属性。如下图所示为修改前后的自定义属性：

|**修改前的自定义属性**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**修改后的自定义属性**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高级文档属性**

{{% alert color="primary" %}} 

已向 [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo) 添加了新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo#updateDocumentProperties-aspose.slides.IDocumentProperties-)、和 [WriteBindedPresentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo#writeBindedPresentation-java.lang.String-)，并且已更改了 [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) 属性设置器的逻辑。

{{% /alert %}} 

两个新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo#readDocumentProperties--) 和 [UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) 已添加到 [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo) 类。它们提供了对文档属性的快速访问，并允许在不加载整个演示文稿的情况下更改和更新属性。

典型的场景是加载属性、修改某些值并更新文档，可按以下方式实现：  
```javascript
// 读取演示文稿的信息
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// 获取当前属性
var props = info.readDocumentProperties();
// 设置作者和标题字段的新值
props.setAuthor("New Author");
props.setTitle("New Title");
// 用新值更新演示文稿
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


还有一种方法是将特定演示文稿的属性用作模板，以更新其他演示文稿中的属性：  
```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


可以从零创建新模板，然后用于更新多个演示文稿：  
```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


## **设置校对语言**

Aspose.Slides 提供了由 PortionFormat 类公开的 LanguageId 属性，允许您为 PowerPoint 文档设置校对语言。校对语言是 PowerPoint 检查拼写和语法时使用的语言。

下面的 JavaScript 代码演示了如何为 PowerPoint 设置校对语言： xxx 为什么 JavaScript 的 PortionFormat 类中缺少 LanguageId？  
```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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
    portionFormat.setLanguageId("zh-CN");// 设置校对语言的 Id
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
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // 添加一个带文本的矩形形状
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // 检查第一段的语言
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **实时示例**

尝试在线应用 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) 查看如何通过 Aspose.Slides API 使用文档属性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***常见问题**

**如何从演示文稿中删除内置属性？**

内置属性是演示文稿的组成部分，无法完全删除。不过，您可以更改它们的值，或在属性允许的情况下将其设为空。

**如果添加的自定义属性已存在会怎样？**

如果添加的自定义属性已存在，其原有值会被新值覆盖。无需事先删除或检查属性，Aspose.Slides 会自动更新属性的值。

**我可以在不完全加载演示文稿的情况下访问演示文稿属性吗？**

可以。您可以使用 [PresentationFactory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/) 类的 `getPresentationInfo` 方法获取演示文稿信息，然后调用 [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo/) 类的 `readDocumentProperties` 方法读取属性，从而节省内存并提升性能。