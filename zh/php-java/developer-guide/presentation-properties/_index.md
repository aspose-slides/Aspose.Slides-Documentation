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
description: "在 Aspose.Slides for PHP via Java 中掌握演示文稿属性，并简化 PowerPoint 和 OpenDocument 文件的搜索、品牌化和工作流。"
---
## **介绍**

Aspose.Slides 支持两种文档属性类型：**内置**和**自定义**。这两种属性类型都可以通过 Aspose.Slides API 轻松访问和管理。

Aspose.Slides 允许您通过 [DocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/) 类来处理演示文稿的文档属性。该类的实例由 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getDocumentProperties) 方法返回。以下示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" title="Note" %}}
请注意，**Application** 和 **AppVersion** 字段无法修改。Aspose.Slides 会在每次保存时重新写入它们，因此已保存的演示文稿始终报告为 “Aspose.Slides for PHP via Java” 并显示生成它的库的版本。传递给 `setNameOfApplication` 的任何值在写入演示文稿时都会被丢弃。
{{% /alert %}} 

## **管理演示文稿属性**

Microsoft PowerPoint 提供了向演示文稿文件添加属性的功能。这些文档属性允许在文档（演示文件）中存储一些有用的信息。文档属性分为以下两类：

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置**属性包含有关文档的一般信息，如文档标题、作者姓名、文档统计信息等。**自定义**属性是用户以 **名称/值** 对形式定义的，其中名称和值均由用户自行定义。使用 Aspose.Slides for PHP via Java，开发者可以访问并修改内置属性和自定义属性的值。

## **PowerPoint 中的文档属性**

Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。只需单击 Office 图标，然后选择 **准备 | 属性 | 高级属性** 菜单项，如下所示：

|**选择“高级属性”菜单项**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

选择 **高级属性** 菜单项后，会出现一个对话框，允许您管理 PowerPoint 文件的文档属性，如下图所示：

|**属性对话框**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

在上述 **属性对话框** 中，您可以看到多个选项卡页面，如 **常规**、**摘要**、**统计信息**、**内容** 和 **自定义**。所有这些选项卡页面都允许配置与 PowerPoint 文件相关的不同信息。**自定义**选项卡用于管理 PowerPoint 文件的自定义属性。

### 使用 Aspose.Slides for PHP via Java 处理文档属性

正如前面所述，Aspose.Slides for PHP via Java 支持两种文档属性：**内置**和**自定义**属性。因此，开发者可以通过 Aspose.Slides for PHP via Java API 访问这两种属性。Aspose.Slides for PHP via Java 提供了一个 [DocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties) 类，代表通过 **Presentation.DocumentProperties** 属性关联的演示文件的文档属性。

开发者可以使用由 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation) 对象公开的 **DocumentProperties** 属性来访问演示文件的文档属性，如下所示：

## **访问内置属性**

通过 [DocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties) 对象公开的这些属性包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最近打印日期）、**LastModifiedBy**、**SharedDoc**（是否在不同制作者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**。

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

修改演示文稿的内置属性与访问它们一样简单。只需为任意所需属性赋予字符串值，即可修改属性值。下面的示例演示了如何使用 Aspose.Slides for PHP via Java 修改演示文件的内置文档属性。

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

此示例修改了演示文稿的内置属性，修改后效果如下所示：

|**修改后内置文档属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **添加自定义文档属性**

Aspose.Slides for PHP via Java 还允许开发者为演示文稿的文档属性添加自定义值。下面的示例展示了如何为演示文稿设置自定义属性。

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

|**已添加的自定义文档属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **访问并修改自定义属性**

Aspose.Slides for PHP via Java 同样允许开发者访问自定义属性的值。下面的示例展示了如何访问并修改演示文稿的所有自定义属性。

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

此示例修改了 [PPTX ](https://docs.fileformat.com/presentation/pptx/) 演示文稿的自定义属性。下图分别展示了修改前后的自定义属性：

|**修改前的自定义属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改后的自定义属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高级文档属性**

{{% alert color="info" title="Note" %}}
新增了 [readDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)、[updateDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) 和 [writeBindedPresentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) 方法到 [PresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PresentationInfo) 中，且 [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#setLastSavedTime) 属性设置器的逻辑已更改。
{{% /alert %}} 

两个新方法 [readDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) 和 [updateDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) 已添加到 [PresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PresentationInfo) 类。它们提供了对文档属性的快速访问，并允许在不加载完整演示文稿的情况下更改和更新属性。

典型场景是加载属性、修改某些值并更新文档，可按以下方式实现：

```php
  # 读取演示文稿的信息
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

另一个方式是将特定演示文稿的属性用作模板，以更新其他演示文稿中的属性：

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

可以从头创建一个新模板，然后用于更新多个演示文稿：

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

Aspose.Slides 提供了 LanguageId 属性（由 PortionFormat 类公开），用于设置 PowerPoint 文档的校对语言。校对语言是 PowerPoint 检查拼写和语法时使用的语言。

下面的 PHP 代码演示了如何为 PowerPoint 设置校对语言：xxx 为什么 Java 版 PortionFormat 类中缺少 LanguageId？

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// 设置校对语言的 Id

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **设置默认语言**

下面的 PHP 代码演示了如何为整个 PowerPoint 演示文稿设置默认语言：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # 添加一个带文本的新矩形形状
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # 检查首个部分的语言
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **实时示例**

尝试在线应用程序 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh/metadata) 以了解如何通过 Aspose.Slides API 操作文档属性：

[![查看并编辑 PowerPoint 元数据](slides-metadata.png)](https://products.aspose.app/slides/zh/metadata)

## **常见问题**

**如何从演示文稿中移除内置属性？**

内置属性是演示文稿的组成部分，无法完全删除。不过，您可以更改它们的值，或在特定属性允许的情况下将其设为空。

**如果添加的自定义属性已存在会怎样？**

如果添加的自定义属性已经存在，其现有值会被新的值覆盖。您无需提前删除或检查属性，Aspose.Slides 会自动更新属性的值。

**是否可以在不完全加载演示文稿的情况下访问演示文稿属性？**

可以。使用 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationfactory/) 然后调用 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#readDocumentProperties) 即可在不创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 实例的情况下读取存储的文档元数据。完整的报告示例和格式特定的限制请参见 [构建轻量级演示文稿清单](/slides/zh/php-java/examine-presentation/)。