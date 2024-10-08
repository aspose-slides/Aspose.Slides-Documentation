---
title: 演示文稿属性
type: docs
weight: 70
url: /java/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPoint 提供了一种功能，可以向演示文稿文件添加一些属性。这些文档属性允许将一些有用的信息与文档（演示文稿文件）一起存储。文档属性有两种类型，如下所示：

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置**属性包含有关文档的一般信息，如文档标题、作者名称、文档统计等。**自定义**属性是用户定义的**名称/值**对，其中名称和值均由用户定义。使用 Aspose.Slides for Java，开发人员可以访问和修改内置属性以及自定义属性的值。

{{% /alert %}} 

## **PowerPoint 中的文档属性**
Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。您只需单击 Office 图标，然后选择 Microsoft PowerPoint 2007 的 **准备 | 属性 | 高级属性** 菜单项，如下所示：

{{% alert color="primary" %}} 

请注意，您无法为 **Application** 和 **Producer** 字段设置值，因为 Aspose Ltd. 和 Aspose.Slides for Java x.x.x 将在这些字段中显示。

{{% /alert %}} 

|**选择高级属性菜单项**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
选择 **高级属性** 菜单项后，将出现一个对话框，允许您管理 PowerPoint 文件的文档属性，如下图所示：

|**属性对话框**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
在上述 **属性对话框** 中，您可以看到有许多选项卡，如 **常规**、**摘要**、**统计**、**内容**和 **自定义**。所有这些选项卡允许配置与 PowerPoint 文件相关的不同信息。**自定义**选项卡用于管理 PowerPoint 文件的自定义属性。

使用 Aspose.Slides for Java 处理文档属性

如前所述，Aspose.Slides for Java 支持两种文档属性，即 **内置** 和 **自定义** 属性。因此，开发人员可以使用 Aspose.Slides for Java API 访问这两种属性。Aspose.Slides for Java 提供了一个类 [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties)，该类表示与演示文稿文件关联的文档属性，通过 **Presentation.DocumentProperties** 属性访问。

开发人员可以使用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 对象公开的 **IDocumentProperties** 属性来访问演示文稿文件的文档属性，如下所述：

## **访问内置属性**
通过 [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties) 对象公开的这些属性包括： **Creator**（作者）、**Description**、**Keywords**、**Created**（创建日期）、**Modified** 修改日期、**Printed** 最后打印日期、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否在不同生成者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**

```java
// 实例化代表演示文稿的 Presentation 类
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 创建与 Presentation 关联的 IDocumentProperties 对象的引用
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 显示内置属性
    System.out.println("类别 : " + dp.getCategory());
    System.out.println("当前状态 : " + dp.getContentStatus());
    System.out.println("创建日期 : " + dp.getCreatedTime());
    System.out.println("作者 : " + dp.getAuthor());
    System.out.println("描述 : " + dp.getComments());
    System.out.println("关键字 : " + dp.getKeywords());
    System.out.println("最后修改者 : " + dp.getLastSavedBy());
    System.out.println("主管 : " + dp.getManager());
    System.out.println("修改日期 : " + dp.getLastSavedTime());
    System.out.println("演示格式 : " + dp.getPresentationFormat());
    System.out.println("最后打印日期 : " + dp.getLastPrinted());
    System.out.println("是否在生成者之间共享 : " + dp.getSharedDoc());
    System.out.println("主题 : " + dp.getSubject());
    System.out.println("标题 : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **修改内置属性**
修改演示文稿文件的内置属性与访问它们一样简单。您只需将字符串值分配给任何所需的属性，属性值将被修改。在下面的示例中，我们演示了如何使用 Aspose.Slides for Java 修改演示文稿文件的内置文档属性。

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 创建与 Presentation 关联的 IDocumentProperties 对象的引用
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 设置内置属性
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("修改演示文稿属性");
    dp.setSubject("Aspose 主题");
    dp.setComments("Aspose 描述");
    dp.setManager("Aspose 主管");
    
    // 将演示文稿保存到文件
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

该示例修改了演示文稿的内置属性，如下所示：

|**修改后的内置文档属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **添加自定义文档属性**
Aspose.Slides for Java 还允许开发人员为演示文稿文档属性添加自定义值。下面给出了一个示例，展示了如何为演示文稿设置自定义属性。

```java
Presentation pres = new Presentation();
try {
    // 获取文档属性
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // 添加自定义属性
    dProps.set_Item("新自定义", 12);
    dProps.set_Item("我的名字", "Mudassir");
    dProps.set_Item("自定义", 124);
    
    // 获取特定索引处的属性名称
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // 移除选定的属性
    dProps.removeCustomProperty(getPropertyName);
    
    // 保存演示文稿
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**添加的自定义文档属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **访问和修改自定义属性**
Aspose.Slides for Java 还允许开发人员访问自定义属性的值。下面给出了一个示例，展示了如何访问和修改演示文稿的所有自定义属性。

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 创建与 Presentation 关联的 DocumentProperties 对象的引用
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 访问和修改自定义属性
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // 显示自定义属性的名称和值
        System.out.println("自定义属性名称 : " + dp.getCustomPropertyName(i));
        System.out.println("自定义属性值 : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // 修改自定义属性的值
        dp.set_Item(dp.getCustomPropertyName(i), "新值 " + (i + 1));
    }
    
    // 将演示文稿保存到文件
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

该示例修改了 [PPTX](https://docs.fileformat.com/presentation/pptx/) 演示文稿的自定义属性。以下图像展示了修改前和修改后的演示文稿自定义属性：

|**修改前的自定义属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**修改后的自定义属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高级文档属性**
{{% alert color="primary" %}} 

新增的方法 [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 和 [WriteBindedPresentation](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) 已添加到 [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo)，[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) 属性设置器的逻辑已更改。

{{% /alert %}} 

两个新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) 和 [UpdateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 已添加到 [IPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationInfo) 接口。它们提供快速访问文档属性的功能，并允许在不加载整个演示文稿的情况下更改和更新属性。

典型的场景是加载属性，修改某些值并更新文档，可以通过以下方式实现：

```java
// 读取演示文稿的信息
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// 获取当前属性
IDocumentProperties props = info.readDocumentProperties();

// 设置作者和标题字段的新值
props.setAuthor("新作者");
props.setTitle("新标题");

// 使用新值更新演示文稿
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

还有另一种方法是使用特定演示文稿的属性作为模板来更新其他演示文稿中的属性：

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("模板作者");
template.setTitle("模板标题");
template.setCategory("模板类别");
template.setKeywords("关键字1, 关键字2, 关键字3");
template.setCompany("我们的公司");
template.setComments("从模板创建");
template.setContentType("模板内容");
template.setSubject("模板主题");

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

可以从头开始创建新的模板，然后用其更新多个演示文稿：

```java
DocumentProperties template = new DocumentProperties();\

template.setAuthor("模板作者");
template.setTitle("模板标题");
template.setCategory("模板类别");
template.setKeywords("关键字1, 关键字2, 关键字3");
template.setCompany("我们的公司");
template.setComments("从模板创建");
template.setContentType("模板内容");
template.setSubject("模板主题");

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

## **检查演示文稿是否已修改或创建**
Aspose.Slides for Java 提供了检查演示文稿是否已修改或创建的功能。下面给出了一个示例，展示了如何检查演示文稿是创建的还是修改的。

```java
IPresentationInfo info=PresentationFactory.getInstance().getPresentationInfo("props.pptx");

IDocumentProperties props = info.readDocumentProperties();
String app = props.getNameOfApplication();
String ver = props.getAppVersion();

System.out.println("应用程序名称: " + app);
System.out.println("应用程序版本: " + ver);
```

## **设置校对语言**

Aspose.Slides 提供了 LanguageId 属性（由 PortionFormat 类公开），允许您为 PowerPoint 文档设置校对语言。校对语言是用于检查 PowerPoint 中拼写和语法的语言。

以下 Java 代码演示了如何为 PowerPoint 设置校对语言：xxx 为什么语言 ID 在 Java PortionFormat 类中缺失？

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
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // 添加带文本的新矩形形状
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("新文本");

    // 检查第一个部分的语言
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```