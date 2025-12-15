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
description: "在 Aspose.Slides for Android via Java 中精通演示文稿属性，并在您的 PowerPoint 和 OpenDocument 文件中简化搜索、品牌化和工作流。"
---

{{% alert color="primary" %}} 

Microsoft PowerPoint 提供了一项功能，可以向演示文稿文件添加一些属性。这些文档属性允许将有用的信息与文档（演示文稿文件）一起存储。文档属性分为以下两类：

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置**属性包含文档的一般信息，例如文档标题、作者姓名、文档统计信息等。**自定义**属性是用户以 **名称/值** 对的形式定义的，其中名称和值均由用户自行设定。使用 Aspose.Slides for Android via Java，开发人员可以访问并修改内置属性和自定义属性的值。

{{% /alert %}} 

## **PowerPoint 中的文档属性**

Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。只需单击 Office 图标，然后依次选择 **Prepare | Properties | Advanced Properties** 菜单项，如下所示：

{{% alert color="primary" %}} 

请注意，您无法对 **Application** 和 **Producer** 字段设置值，因为 Aspose Ltd. 和 Aspose.Slides for Android via Java x.x.x 将显示在这些字段中。

{{% /alert %}} 

|**选择 高级 属性 菜单项**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

选择 **Advanced Properties** 菜单项后，会出现一个对话框，允许您管理 PowerPoint 文件的文档属性，如下图所示：

|**属性 对话框**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

在上述 **Properties Dialog** 中，您可以看到有 **General**、**Summary**、**Statistics**、**Contents** 和 **Custom** 等多个选项卡。这些选项卡允许配置与 PowerPoint 文件相关的不同信息。**Custom** 选项卡用于管理 PowerPoint 文件的自定义属性。

### 使用 Aspose.Slides for Android via Java 处理文档属性

正如前文所述，Aspose.Slides for Android via Java 支持两类文档属性，即 **内置** 和 **自定义** 属性。因此，开发人员可以通过 Aspose.Slides for Android via Java API 访问这两类属性。Aspose.Slides for Android via Java 提供了一个接口 [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties)，它通过 **Presentation.DocumentProperties** 属性表示与演示文稿文件关联的文档属性。

开发人员可以使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 对象公开的 **IDocumentProperties** 属性来访问演示文稿文件的文档属性，示例如下：

## **访问内置属性**

通过 [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties) 对象公开的属性包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最近打印日期）、**LastModifiedBy**、**SharedDoc**（是否在不同制作者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**  
```java
// 实例化表示演示文稿的 Presentation 类
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 创建与 Presentation 关联的 IDocumentProperties 对象的引用
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

修改演示文稿文件的内置属性与访问它们一样简便。只需为任意所需属性分配字符串值即可完成修改。下面的示例演示了如何使用 Aspose.Slides for Android via Java 修改演示文稿的内置文档属性。  
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 创建与 Presentation 关联的 IDocumentProperties 对象的引用
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 设置内置属性
    dp.setAuthor("Aspose.Slides for Android via Java");
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


此示例修改了演示文稿的内置属性，修改后效果如下：

|**修改后 的 内置文档属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **添加自定义文档属性**

Aspose.Slides for Android via Java 还允许开发人员为演示文稿添加自定义属性值。下面的示例展示了如何为演示文稿设置自定义属性。  
```java
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


|**已添加的自定义文档属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **访问并修改自定义属性**

Aspose.Slides for Android via Java 也允许开发人员访问自定义属性的值。下面的示例展示了如何访问并修改演示文稿的所有自定义属性。  
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 创建与 Presentation 关联的 DocumentProperties 对象的引用
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


此示例修改了 [PPTX ](https://docs.fileformat.com/presentation/pptx/) 演示文稿的自定义属性。下图分别展示了修改前后的自定义属性：

|**修改前的自定义属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改后的自定义属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高级文档属性**

{{% alert color="primary" %}} 

新增了方法 [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)、以及 [WriteBindedPresentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) 至 [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo)，并已更改 [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) 属性 setter 的实现。

{{% /alert %}} 

两个新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) 和 [UpdateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 已被添加到 [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationInfo) 接口。它们提供对文档属性的快速访问，并允许在不加载完整演示文稿的情况下更改和更新属性。

典型的场景是加载属性、修改某些值，然后更新文档，示例代码如下：  
```java
// 读取演示文稿的信息
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


另一种方式是将特定演示文稿的属性作为模板，以更新其他演示文稿的属性：  
```java
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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


也可以从头创建新模板，然后用于更新多个演示文稿：  
```java
DocumentProperties template = new DocumentProperties();\

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


## **设置校对语言**

Aspose.Slides 提供了 LanguageId 属性（由 PortionFormat 类公开），可以为 PowerPoint 文档设置校对语言。校对语言决定了 PowerPoint 中的拼写和语法检查使用的语言。

下面的 Java 代码演示了如何为 PowerPoint 设置校对语言： xxx 为什么 Java PortionFormat 类中缺少 LanguageId？  
```java
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

    portionFormat.setLanguageId("zh-CN"); // 设置校对语言的ID

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```


## **设置默认语言**

下面的 Java 代码演示了如何为整个 PowerPoint 演示文稿设置默认语言：  
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // 添加一个带文本的新矩形形状
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // 检查第一个文字段的语言
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```


## **实时示例**

尝试使用在线应用 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) 了解如何通过 Aspose.Slides API 操作文档属性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**如何从演示文稿中移除内置属性？**

内置属性是演示文稿的组成部分，无法完全删除。不过，您可以更改它们的值，或在属性允许的情况下将其设为空。

**如果添加的自定义属性已存在会怎样？**

如果添加的自定义属性已存在，原有的值会被新值覆盖。无需事先删除或检查该属性，Aspose.Slides 会自动更新属性的值。

**能否在不完全加载演示文稿的情况下访问其属性？**

可以。您可以使用 [PresentationFactory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/) 类的 `getPresentationInfo` 方法获取演示文稿信息，然后调用 [IPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/) 接口的 `readDocumentProperties` 方法高效读取属性，从而节省内存并提升性能。