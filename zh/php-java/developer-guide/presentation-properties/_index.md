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
description: "在 Aspose.Slides for PHP via Java 中精通演示文稿属性，并简化对 PowerPoint 和 OpenDocument 文件的搜索、品牌化和工作流。"
---


{{% alert color="primary" %}} 

Microsoft PowerPoint 提供了一项功能，可向演示文稿文件添加一些属性。这些文档属性允许将有用的信息与文档（演示文稿文件）一起存储。文档属性有以下两种类型

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置**属性包含有关文档的一般信息，如文档标题、作者姓名、文档统计等。**自定义**属性是用户以 **名称/值** 对形式定义的，其中名称和值均由用户定义。使用 Aspose.Slides for PHP via Java，开发人员可以访问和修改内置属性以及自定义属性的值。

{{% /alert %}} 

## **PowerPoint 中的文档属性**

Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。您只需点击 Office 图标，然后进一步选择 Microsoft PowerPoint 2007 的 **准备 | 属性 | 高级属性** 菜单项，如下所示：

{{% alert color="primary" %}} 

请注意，您无法为 **Application** 和 **Producer** 字段设置值，因为 Aspose Ltd. 和 Aspose.Slides for PHP via Java x.x.x 将显示在这些字段中。

{{% /alert %}} 

|**选择高级属性菜单项**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

选择 **高级属性** 菜单项后，将出现一个对话框，允许您管理 PowerPoint 文件的文档属性，如下图所示：

|**属性对话框**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

在上述 **属性对话框** 中，您可以看到有多个选项卡，如 **常规**、**摘要**、**统计**、**内容** 和 **自定义**。所有这些选项卡都允许配置与 PowerPoint 文件相关的不同信息。**自定义** 选项卡用于管理 PowerPoint 文件的自定义属性。

使用 Aspose.Slides for PHP via Java 处理文档属性

正如前面所述，Aspose.Slides for PHP via Java 支持两种文档属性，即 **内置** 和 **自定义** 属性。因此，开发人员可以使用 Aspose.Slides for PHP via Java API 访问这两种属性。Aspose.Slides for PHP via Java 提供了一个类[DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties)，该类通过 **Presentation.DocumentProperties** 属性表示与演示文稿文件关联的文档属性。

开发人员可以使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 对象公开的 **DocumentProperties** 属性来访问演示文稿文件的文档属性，如下所述：

## **访问内置属性**

这些属性由 [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties) 对象公开，包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最近打印日期）、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否在不同的制作者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**。

```php
  # 实例化表示演示文稿的 Presentation 类
  $pres = new Presentation("Presentation.pptx");
  try {
    # 创建与 Presentation 关联的 IDocumentProperties 对象的引用
    $dp = $pres->getDocumentProperties();
    # 显示内置属性
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **修改内置属性**

修改演示文稿文件的内置属性与访问它们一样简单。只需为任意所需属性分配字符串值，即可修改属性值。在下面的示例中，我们演示了如何使用 Aspose.Slides for PHP via Java 修改演示文稿文件的内置文档属性。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 创建与 Presentation 关联的 IDocumentProperties 对象的引用
    $dp = $pres->getDocumentProperties();
    # 设置内置属性
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # 将演示文稿保存到文件
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


此示例修改了演示文稿的内置属性，效果如下所示：

|**修改后内置文档属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **添加自定义文档属性**

Aspose.Slides for PHP via Java 还允许开发人员为演示文稿的文档属性添加自定义值。下面给出的示例演示了如何为演示文稿设置自定义属性。

```php
  $pres = new Presentation();
  try {
    # 获取文档属性
    $dProps = $pres->getDocumentProperties();
    # 添加自定义属性
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # 获取特定索引处的属性名称
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # 删除选定的属性
    $dProps->removeCustomProperty($getPropertyName);
    # 保存演示文稿
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|**已添加自定义文档属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **访问和修改自定义属性**

Aspose.Slides for PHP via Java 还允许开发人员访问自定义属性的值。下面给出的示例演示了如何访问和修改演示文稿的所有自定义属性。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 创建与 Presentation 关联的 DocumentProperties 对象的引用
    $dp = $pres->getDocumentProperties();
    # 访问并修改自定义属性
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # 显示自定义属性的名称和值
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # 修改自定义属性的值
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # 将演示文稿保存到文件
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


此示例修改了 [PPTX ](https://docs.fileformat.com/presentation/pptx/) 演示文稿的自定义属性。以下图示展示了修改前后演示文稿的自定义属性：

|**修改前的自定义属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改后的自定义属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高级文档属性**

{{% alert color="primary" %}} 

已向 [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) 添加了新方法 [readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)、[updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) 和 [writeBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation)。并且已更改了 [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setLastSavedTime) 属性设置器的逻辑。

{{% /alert %}} 

已向 [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) 类添加了两个新方法 [readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) 和 [updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties)。它们提供了对文档属性的快速访问，并允许在不加载整个演示文稿的情况下更改和更新属性。

典型的场景是加载属性、修改某些值并更新文档，可按以下方式实现：
```php
  # 读取演示文稿信息
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # 获取当前属性
  $props = $info->readDocumentProperties();
  # 设置 Author 和 Title 字段的新值
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # 使用新值更新演示文稿
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```


还有另一种方法，使用特定演示文稿的属性作为模板来更新其他演示文稿的属性：
```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```


可以从头创建新的模板，然后用于更新多个演示文稿：
```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```


## **设置校对语言**

Aspose.Slides 提供了 LanguageId 属性（由 PortionFormat 类公开），允许您为 PowerPoint 文档设置校对语言。校对语言是用于检查拼写和语法的语言。

此 PHP 代码演示了如何为 PowerPoint 设置校对语言：xxx 为什么 Java 的 PortionFormat 类中缺少 LanguageId？
```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// 设置校对语言的 Id

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **设置默认语言**

此 PHP 代码演示了如何为整个 PowerPoint 演示文稿设置默认语言：
```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # 添加一个带文本的新矩形形状
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # 检查第一个部分的语言
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **实时示例**

尝试使用在线应用程序 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) 查看如何通过 Aspose.Slides API 操作文档属性：

[![查看并编辑 PowerPoint 元数据](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常见问题**

**如何从演示文稿中删除内置属性？**

内置属性是演示文稿的组成部分，不能完全删除。不过，您可以更改它们的值，或在特定属性允许的情况下将其设为空。

**如果添加已经存在的自定义属性会怎样？**

如果添加已经存在的自定义属性，其现有值将被新值覆盖。您无需事先删除或检查属性，因为 Aspose.Slides 会自动更新属性的值。

**是否可以在不完整加载演示文稿的情况下访问演示文稿属性？**

是的，您可以使用 [PresentationFactory](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/) 类的 `getPresentationInfo` 方法在不完整加载演示文稿的情况下访问演示文稿属性。然后，利用 [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/) 类提供的 `readDocumentProperties` 方法高效读取属性，从而节省内存并提升性能。