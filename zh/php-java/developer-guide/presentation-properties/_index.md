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
description: "在 Aspose.Slides for PHP via Java 中掌握演示文稿属性，并在 PowerPoint 和 OpenDocument 文件中简化搜索、品牌化和工作流。"
---
## **简介**

Aspose.Slides 支持两种文档属性类型：**内置** 和 **自定义**。这两种属性类型都可以通过 Aspose.Slides API 轻松访问和管理。

Aspose.Slides 通过 [DocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/) 类处理演示文稿的文档属性。该类的实例由 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getDocumentProperties) 方法返回。以下示例展示了如何读取、修改和管理这些属性。

{{% alert color="info" title="注意" %}}
请注意，**Application** 和 **AppVersion** 字段无法修改。Aspose.Slides 在每次保存时都会重新写入它们，因此已保存的演示文稿始终报告为 “Aspose.Slides for PHP via Java” 以及生成该文件的库版本。传递给 `setNameOfApplication` 的任何值在写入演示文稿时都会被忽略。
{{% /alert %}}

## **管理演示文稿属性**

Microsoft PowerPoint 提供向演示文稿文件添加属性的功能。这些文档属性允许在文档（演示文件）中存储一些有用的信息。文档属性分为以下两类：

- 系统定义（内置）属性
- 用户定义（自定义）属性

**内置** 属性包含文档的一般信息，如文档标题、作者姓名、文档统计信息等。**自定义** 属性是用户以 **名称/值** 对的形式定义的，其中名称和值均由用户自行定义。使用 Aspose.Slides for PHP via Java，开发者可以访问并修改内置属性和自定义属性的值。

## **PowerPoint 中的文档属性**

Microsoft PowerPoint 2007 允许管理演示文稿文件的文档属性。只需点击 Office 图标，然后选择 **准备 | 属性 | 高级属性** 菜单项，如下所示：

|**选择“高级属性”菜单项**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

选择 **高级属性** 菜单项后，会弹出如下对话框，允许您管理 PowerPoint 文件的文档属性：

|**属性对话框**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

在上述 **属性对话框** 中，您可以看到多个选项卡，如 **常规**、**摘要**、**统计信息**、**内容** 和 **自定义**。所有这些选项卡均用于配置与 PowerPoint 文件相关的不同信息。**自定义** 选项卡用于管理 PowerPoint 文件的自定义属性。

### 使用 Aspose.Slides for PHP via Java 操作文档属性

正如前面所述，Aspose.Slides for PHP via Java 支持 **内置** 和 **自定义** 两种文档属性。因此，开发者可以使用 Aspose.Slides for PHP via Java API 访问这两类属性。Aspose.Slides for PHP via Java 提供了 [DocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties) 类，表示通过 **Presentation.DocumentProperties** 属性关联的演示文稿文件的文档属性。

开发者可以通过 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation) 对象公开的 **DocumentProperties** 属性访问演示文稿文件的文档属性，示例如下：

## **从加密演示文稿读取公共属性**

打开密码通常同时保护演示内容和文档属性。当通过将 `false` 传递给 [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 来加密文档属性时，文档属性保持为公共。此时，应用程序可以将 `true` 传递给 [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 并在不提供打开密码的情况下读取公共元数据。

文档属性仅加载选项控制 Aspose.Slides 加载的内容；它不解密任何数据。如果属性已被加密，则在未提供密码的情况下加载会失败。若演示文稿未加密，则该选项被忽略，完整演示文稿将被加载。

以下示例通过 [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 验证加载模式，然后通过 [Presentation::getDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getDocumentProperties) 读取内置属性：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

在此模式下，幻灯片内容不会被加载。幻灯片、母版、布局、形状、媒体以及其他演示对象均不可用。应用程序在执行需要完整演示对象模型的操作前，应始终检查 [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded)。

{{% alert color="warning" title="警告" %}}
公共元数据可能会泄露作者姓名、标题、主题、关键字、公司信息、注释以及自定义值。请将敏感属性与演示文稿一起加密。仅在索引、分类、搜索或文档管理系统明确要求在不提供密码的情况下访问时，才将其保持为公共。
{{% /alert %}}

## **更新加密演示文稿的属性**

对于加密的 PPTX 文件，以仅文档属性模式加载的演示文稿旨在读取公共元数据。Aspose.Slides 无法保存该仅元数据对象的更改属性，因为公共属性必须与加密演示文稿内部对应的数据保持一致。因此，更新这些属性需要正确的打开密码并完整加载演示文稿。

以下示例使用 [LoadOptions::setPassword](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setPassword) 打开演示文稿，更新公共内置属性并保存结果。随后使用 [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#isEncrypted) 验证加密状态，并在不提供密码的情况下重新打开公共元数据以验证新值：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

如果应用程序不被允许解密或加载演示文稿内容，则必须将加密 PPTX 文件的公共属性视为只读。

## **访问内置属性**

[DocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties) 对象公开的属性包括：**Creator**（作者）、**Description**、**Keywords**、**Created**（创建日期）、**Modified**（修改日期）、**Printed**（最近打印日期）、**LastModifiedBy**、**SharedDoc**（是否在不同作者之间共享？）、**PresentationFormat**、**Subject** 和 **Title**。

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

修改演示文稿文件的内置属性与访问它们一样简单。只需为任意所需属性赋予字符串值，即可修改该属性的值。下面的示例演示了如何使用 Aspose.Slides for PHP via Java 修改演示文稿的内置文档属性。

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

该示例修改后的内置属性如下所示：

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
    # 移除选定的属性
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

Aspose.Slides for PHP via Java 也允许开发者访问自定义属性的值。下面的示例展示了如何访问并修改演示文稿的所有自定义属性。

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

该示例修改了 [PPTX](https://docs.fileformat.com/presentation/pptx/) 演示文稿的自定义属性。下图分别展示了修改前后的自定义属性：

|**修改前的自定义属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**修改后的自定义属性**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高级文档属性**

{{% alert color="info" title="注意" %}}
新增了 [PresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PresentationInfo) 的方法 [readDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)、[updateDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) 和 [writeBindedPresentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation)，并修改了 [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#setLastSavedTime) 属性 setter 的实现逻辑。
{{% /alert %}}

两个新方法 [readDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) 和 [updateDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) 已添加至 [PresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PresentationInfo) 类。它们提供了快速访问文档属性的方式，并允许在不加载完整演示文稿的情况下更改和更新属性。

典型场景：加载属性、修改某些值并更新文档，可按以下方式实现：

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

另一种方式是使用特定演示文稿的属性作为模板，以更新其他演示文稿中的属性：

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

也可以从头创建新模板，然后用于更新多个演示文稿：

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

Aspose.Slides 提供了由 PortionFormat 类公开的 LanguageId 属性，用于设置 PowerPoint 文档的校对语言。校对语言是 PowerPoint 检查拼写和语法时使用的语言。

以下 PHP 代码演示了如何为 PowerPoint 设置校对语言：xxx 为什么 Java 的 PortionFormat 类中缺少 LanguageId？

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
    $portionFormat->setLanguageId("zh-CN");// 设置校对语言的标识

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **设置默认语言**

以下 PHP 代码演示了如何为整个 PowerPoint 演示文稿设置默认语言：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # 添加一个带文本的矩形形状
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # 检查第一个 Portion 的语言
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **实时示例**

尝试在线应用程序 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh/metadata) 了解如何通过 Aspose.Slides API 操作文档属性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/zh/metadata)

## **常见问题**

**如何从演示文稿中移除内置属性？**

内置属性是演示文稿的组成部分，不能完全删除。不过，您可以更改其值，或者在特定属性允许的情况下将其设为空。

**如果添加的自定义属性已经存在会怎样？**

如果添加的自定义属性已存在，其原有值将被新值覆盖。无需事先删除或检查属性，Aspose.Slides 会自动更新属性值。

**是否可以在不完整加载演示文稿的情况下访问演示文稿属性？**

可以。使用 [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationfactory/) 然后调用 [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/#readDocumentProperties) 即可在不创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 实例的情况下读取已存储的文档元数据。请参阅 [构建轻量级演示文稿清单](/slides/zh/php-java/examine-presentation/) 获取完整的报告示例以及格式特定的限制。

**是否可以在没有打开密码的情况下读取加密演示文稿的公共属性？**

可以。前提是文档属性加密在演示文稿加密之前已被禁用，并且演示文稿以仅文档属性模式加载。

**是否可以在仅文档属性模式下更新加密的 PPTX 文件？**

不能。公共属性和加密属性数据必须保持一致，因此在仅文档属性模式下更新加密的 PPTX 文件需要使用正确的打开密码完整加载演示文稿。