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
description: "在 Aspose.Slides for Java 中掌握演示文稿属性，并简化 PowerPoint 和 OpenDocument 文件的搜索、品牌和工作流。"
---
## **简介**

Aspose.Slides 支持两种文档属性类型：**内置**和**自定义**。这两种属性类型都可以通过 Aspose.Slides API 轻松访问和管理。

Aspose.Slides 允许您通过 [IDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties/) 接口处理演示文稿的文档属性。该接口的实例由 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getDocumentProperties--) 方法返回。下面的示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" %}} 
请注意，**Application** 和 **AppVersion** 字段无法修改。Aspose.Slides 在每次保存时都会重新写入它们，因此保存的演示文稿始终报告为 “Aspose.Slides for Java” 以及生成它的库版本。传递给 `setNameOfApplication` 的任何值在写入演示文稿时都会被丢弃。 
{{% /alert %}} 

## **PowerPoint 中的文档属性**

Microsoft PowerPoint 2007 允许管理演示文件的文档属性。只需单击 Office 图标，然后依次选择 **Prepare | Properties | Advanced Properties** 菜单项，如下所示：

|**选择高级属性菜单项**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

选择 **Advanced Properties** 菜单项后，会出现一个对话框，允许您管理 PowerPoint 文件的文档属性，如下图所示：

|**属性对话框**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

在上述**属性对话框**中，您可以看到许多选项卡，如**常规**、**摘要**、**统计**、**内容**和**自定义**。所有这些选项卡允许配置与 PowerPoint 文件相关的不同信息。**自定义**选项卡用于管理 PowerPoint 文件的自定义属性。

## **使用 Aspose.Slides for Java 处理文档属性**

如前所述，Aspose.Slides for Java 支持两种文档属性，即**内置**和**自定义**属性。因此，开发者可以使用 Aspose.Slides for Java API 访问这两类属性。Aspose.Slides for Java 提供了一个类 [IDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties) 来表示通过 **Presentation.DocumentProperties** 属性关联的演示文件的文档属性。

开发者可以通过 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 对象公开的 **IDocumentProperties** 属性访问演示文件的文档属性，如下所示：

## **访问内置属性**

这些属性由 [IDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties) 对象公开，包括：**Creator** (Author)、**Description**、**Keywords** **Created** (Creation Date)、**Modified** Modification Date、**Printed** Last Print Date、**LastModifiedBy**、**Keywords**、**SharedDoc** (Is shared between different producers?)、**PresentationFormat**、**Subject** 和 **Title**。

```java
import com.aspose.slides.*;

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

修改演示文件的内置属性和访问它们一样简单。您只需为任意所需属性赋予字符串值，即可修改该属性的值。下面的示例演示了如何使用 Aspose.Slides for Java 修改演示文件的内置文档属性。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // 创建与 Presentation 关联的 IDocumentProperties 对象的引用
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

此示例修改了演示文稿的内置属性，修改后效果如下所示：

|**修改后内置文档属性**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **添加自定义文档属性**

Aspose.Slides for Java 还允许开发者为演示文稿的文档属性添加自定义值。下面的示例添加了三个自定义属性，然后查找索引为 2 的名称并将其移除，因此保存的演示文稿保留了其中的两个。自定义属性按字母顺序索引，而非添加顺序。

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
    
    // 移除选中的属性
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

Aspose.Slides for Java 还允许开发者访问自定义属性的值。下面的示例展示了如何访问并修改演示文稿的所有自定义属性。

```java
import com.aspose.slides.*;

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

此示例修改了 [PPTX ](https://docs.fileformat.com/presentation/pptx/) 演示文稿的自定义属性。下面的图片分别展示了修改前后的自定义属性：

|**修改前的自定义属性**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改后的自定义属性**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高级文档属性**

{{% alert color="info" %}} 
新增了方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 和 [WriteBindedPresentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) 到 [IPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IPresentationInfo)，并且更改了 [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) 属性 setter 的实现逻辑。 
{{% /alert %}} 

两个新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) 和 [UpdateDocumentProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 已添加到 [IPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IPresentationInfo) 接口。它们提供了快速访问文档属性的方式，并且无需加载整个演示文稿即可更改和更新属性。

典型场景是加载属性、修改部分值并更新文档，可按以下方式实现：

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

还有一种方式是将特定演示文稿的属性用作模板，以更新其他演示文稿中的属性：

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

Aspose.Slides 提供了 LanguageId 属性（由 PortionFormat 类公开），允许您为 PowerPoint 文档设置校对语言。校对语言是 PowerPoint 检查拼写和语法的语言。

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

    portionFormat.setLanguageId("zh-CN"); // 设置校对语言的 ID

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置默认语言**

以下 Java 代码演示了如何为整个 PowerPoint 演示文稿设置默认语言：

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // 添加一个带文本的新矩形形状
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // 检查第一个部分的语言
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **实时示例**

尝试在线应用程序 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh/metadata) 了解如何通过 Aspose.Slides API 操作文档属性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/zh/metadata)

## ***常见问题**

### 如何从演示文稿中移除内置属性？

内置属性是演示文稿的组成部分，无法完全移除。不过，您可以更改它们的值，或者在特定属性允许的情况下将其设为空。

### 如果添加已存在的自定义属性会怎样？

如果添加的自定义属性已经存在，其已有的值将被新值覆盖。您无需事先删除或检查属性，Aspose.Slides 会自动更新属性的值。

### 能否在不完全加载演示文稿的情况下访问演示文稿属性？

可以。使用 [PresentationFactory](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationfactory/) 类的 `getPresentationInfo` 方法获取演示文稿信息，然后调用 [IPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/) 接口的 `readDocumentProperties` 方法即可高效读取属性，从而节省内存并提升性能。