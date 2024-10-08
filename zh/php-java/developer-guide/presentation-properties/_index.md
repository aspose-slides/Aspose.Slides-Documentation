---
title: 演示文稿属性
type: docs
weight: 70
url: /php-java/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPoint 提供了一个功能，可以向演示文稿文件添加一些属性。这些文档属性允许一些有用的信息与文档（演示文稿文件）一起存储。文档属性主要有两种类型，如下所示：

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置**属性包含有关文档的一般信息，如文档标题、作者名称、文档统计信息等。**自定义**属性是用户定义的，以**名称/值**对的形式存在，名称和值均由用户定义。通过 Aspose.Slides for PHP via Java，开发人员可以访问和修改内置属性以及自定义属性的值。

{{% /alert %}} 

## **PowerPoint 中的文档属性**
Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。您需要做的就是单击办公图标，然后选择 Microsoft PowerPoint 2007 的 **准备 | 属性 | 高级属性** 菜单项，如下所示：

{{% alert color="primary" %}} 

请注意，您不能为 **应用程序** 和 **生成者** 字段设置值，因为 Aspose Ltd. 和 Aspose.Slides for PHP via Java x.x.x 将显示在这些字段上。

{{% /alert %}} 

|**选择高级属性菜单项**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
在您选择 **高级属性** 菜单项后，会出现一个对话框，允许您管理 PowerPoint 文件的文档属性，如下图所示：

|**属性对话框**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
在上述 **属性对话框** 中，您可以看到有许多选项卡，如 **常规**、**摘要**、**统计信息**、**内容** 和 **自定义**。所有这些选项卡允许配置与 PowerPoint 文件相关的不同种类信息。**自定义**选项卡用于管理 PowerPoint 文件的自定义属性。



使用 Aspose.Slides for PHP via Java 操作文档属性

如前所述，Aspose.Slides for PHP via Java 支持两种类型的文档属性，即 **内置** 和 **自定义** 属性。因此，开发人员可以使用 Aspose.Slides for PHP via Java API 访问这两种属性。Aspose.Slides for PHP via Java 提供了一个类 [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties)，它表示与演示文稿文件关联的文档属性，通过 **Presentation.DocumentProperties** 属性访问。

开发人员可以使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 对象公开的 **IDocumentProperties** 属性来访问演示文件的文档属性，如下所示：

## **访问内置属性**
由 [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties) 对象公开的这些属性包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最后打印日期）、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否在不同生成者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**。

```php
  # 实例化表示演示文稿的 Presentation 类
  $pres = new Presentation("Presentation.pptx");
  try {
    # 创建与 Presentation 关联的 IDocumentProperties 对象的引用
    $dp = $pres->getDocumentProperties();
    # 显示内置属性
    echo("类别 : " . $dp->getCategory());
    echo("当前状态 : " . $dp->getContentStatus());
    echo("创建日期 : " . $dp->getCreatedTime());
    echo("作者 : " . $dp->getAuthor());
    echo("描述 : " . $dp->getComments());
    echo("关键词 : " . $dp->getKeywords());
    echo("最后修改人 : " . $dp->getLastSavedBy());
    echo("主管 : " . $dp->getManager());
    echo("修改日期 : " . $dp->getLastSavedTime());
    echo("演示文稿格式 : " . $dp->getPresentationFormat());
    echo("最后打印日期 : " . $dp->getLastPrinted());
    echo("在生成者之间是否共享 : " . $dp->getSharedDoc());
    echo("主题 : " . $dp->getSubject());
    echo("标题 : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **修改内置属性**
修改演示文件的内置属性和访问它们一样简单。您只需将字符串值分配给任何所需属性，属性值就会被修改。在下面给出的示例中，我们演示了如何使用 Aspose.Slides for PHP via Java 修改演示文件的内置文档属性。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 创建与 Presentation 关联的 IDocumentProperties 对象的引用
    $dp = $pres->getDocumentProperties();
    # 设置内置属性
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("修改演示文稿属性");
    $dp->setSubject("Aspose 主题");
    $dp->setComments("Aspose 描述");
    $dp->setManager("Aspose 主管");
    # 将演示文稿保存到文件
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

此示例修改演示文稿的内置属性，如下所示：

|**修改后的内置文档属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **添加自定义文档属性**
Aspose.Slides for PHP via Java 还允许开发人员为演示文稿文档属性添加自定义值。下面的示例展示了如何为演示文稿设置自定义属性。

```php
  $pres = new Presentation();
  try {
    # 获取文档属性
    $dProps = $pres->getDocumentProperties();
    # 添加自定义属性
    $dProps->set_Item("新自定义", 12);
    $dProps->set_Item("我的名字", "Mudassir");
    $dProps->set_Item("自定义", 124);
    # 获取特定索引的属性名称
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

|**添加的自定义文档属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **访问和修改自定义属性**
Aspose.Slides for PHP via Java 还允许开发人员访问自定义属性的值。下面的示例展示了如何访问和修改演示文稿的所有这些自定义属性。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 创建与 Presentation 关联的 DocumentProperties 对象的引用
    $dp = $pres->getDocumentProperties();
    # 访问和修改自定义属性
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # 显示自定义属性的名称和值
      echo("自定义属性名称 : " . $dp->getCustomPropertyName($i));
      echo("自定义属性值 : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # 修改自定义属性的值
      $dp->set_Item($dp->getCustomPropertyName($i), "新值 " . $i + 1);
    }
    # 将演示文稿保存到文件
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

此示例修改了 [PPTX](https://docs.fileformat.com/presentation/pptx/) 演示文稿的自定义属性。以下图展示了修改前后的演示文稿自定义属性：

|**修改前的自定义属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**修改后的自定义属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高级文档属性**
{{% alert color="primary" %}} 

新的方法 [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 和 [WriteBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) 已添加到 [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo)，并且 [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) 属性设置器的逻辑已更改。

{{% /alert %}} 

两个新方法 [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--) 和 [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 已添加到 [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo) 接口。它们提供了对文档属性的快速访问，并允许在不加载整个演示文稿的情况下更改和更新属性。

典型的场景是加载属性，修改某些值，然后更新文档，可以通过以下方式实现：

```php
  # 读取演示文稿信息
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # 获取当前属性
  $props = $info->readDocumentProperties();
  # 设置作者和标题字段的新值
  $props->setAuthor("新作者");
  $props->setTitle("新标题");
  # 使用新值更新演示文稿
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");

```

还有另一种方法可以使用特定演示文稿的属性作为模板来更新其他演示文稿的属性：

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("模板作者");
  $template->setTitle("模板标题");
  $template->setCategory("模板类别");
  $template->setKeywords("关键词1, 关键词2, 关键词3");
  $template->setCompany("我们的公司");
  $template->setComments("从模板创建");
  $template->setContentType("模板内容");
  $template->setSubject("模板主题");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

可以从头开始创建一个新模板，然后用来更新多个演示文稿：

```php
  $template = new DocumentProperties();
  $template->setAuthor("模板作者");
  $template->setTitle("模板标题");
  $template->setCategory("模板类别");
  $template->setKeywords("关键词1, 关键词2, 关键词3");
  $template->setCompany("我们的公司");
  $template->setComments("从模板创建");
  $template->setContentType("模板内容");
  $template->setSubject("模板主题");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

## **检查演示文稿是否被修改或创建**
Aspose.Slides for PHP via Java 提供了检查演示文稿是否被修改或创建的功能。下面的示例展示了如何检查演示文稿是否被创建或修改。

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("props.pptx");
  $props = $info->readDocumentProperties();
  $app = $props->getNameOfApplication();
  $ver = $props->getAppVersion();
  echo("应用程序名称: " . $app);
  echo("应用程序版本: " . $ver);

```

## **设置校对语言**

Aspose.Slides 提供了 LanguageId 属性（由 PortionFormat 类公开），允许您为 PowerPoint 文档设置校对语言。校对语言是 PowerPoint 中拼写和语法检查的语言。

这段 PHP 代码演示了如何为 PowerPoint 设置校对语言：xxx 为什么 LanguageId 在 Java PortionFormat 类中缺失？

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

这段 PHP 代码演示了如何为整个 PowerPoint 演示文稿设置默认语言：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # 添加一个新的矩形形状，并带有文本
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("新文本");
    # 检查第一个部分的语言
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```