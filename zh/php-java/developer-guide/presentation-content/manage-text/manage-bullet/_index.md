---
title: 使用 PHP 管理演示文稿中的项目符号和编号列表
linktitle: 管理列表
type: docs
weight: 60
url: /zh/php-java/manage-bullet/
keywords:
- 项目符号
- 项目符号列表
- 编号列表
- 符号项目符号
- 图片项目符号
- 自定义项目符号
- 多层级列表
- 创建项目符号
- 添加项目符号
- 添加列表
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 演示文稿中管理项目符号和编号列表。分步指南。"
---

在 **Microsoft PowerPoint** 中，您可以像在 Word 和其他文本编辑器中一样创建项目符号和编号列表。 **Aspose.Slides for PHP via Java** 也允许您在演示文稿的幻灯片中使用项目符号和编号。

## **为什么使用项目符号列表？**

项目符号列表帮助您快速高效地组织和呈现信息。

**项目符号列表示例**

在大多数情况下，项目符号列表具有以下三大功能：

- 吸引读者或观众的注意力，突出重要信息
- 使读者或观众能够轻松浏览关键点
- 高效传达和呈现重要细节

## **为什么使用编号列表？**

编号列表同样有助于组织和呈现信息。当条目的顺序（例如 *步骤 1、步骤 2* 等）重要，或需要引用某个条目（例如 *参见步骤 3*）时，最好使用编号（而不是项目符号）。

**编号列表示例**

下面是 **创建项目符号** 过程中的步骤摘要（步骤 1 到步骤 15）：

1. 创建演示文稿类的实例。 
2. 执行多个任务（步骤 3 到步骤 14）。 
3. 保存演示文稿。 

## **创建项目符号**
本主题也是管理文本段落系列主题的一部分。本页将演示如何管理段落项目符号。项目符号在需要按步骤描述某事时尤为有用。此外，使用项目符号可以使文本看起来更有条理。带项目符号的段落始终更易阅读和理解。我们将看到开发者如何使用 Aspose.Slides for PHP via Java 的这一小而强大的功能。请按照以下步骤使用 Aspose.Slides for PHP via Java 管理段落项目符号：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。  
1. 使用 [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide) 对象访问幻灯片集合中的目标幻灯片。  
1. 在选定的幻灯片中添加 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText)。  
1. 访问所添加形状的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame)。  
1. 删除 TextFrame 中的默认段落。  
1. 使用 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph) 类创建第一个段落实例。  
1. 设置段落的项目符号类型。  
1. 将项目符号类型设置为 [Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/BulletType#Symbol) 并设置项目符号字符。  
1. 设置段落文本。  
1. 设置段落缩进以确定项目符号位置。  
1. 设置项目符号的颜色。  
1. 设置项目符号的高度。  
1. 将创建的段落添加到 TextFrame 的段落集合中。  
1. 添加第二个段落并重复 **7 到 13** 步骤。  
1. 保存演示文稿。

以下示例代码 —— 实现上述步骤 —— 展示了如何在幻灯片中创建项目符号列表：
```php
  # 实例化一个表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加并访问自动形状
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问已创建自动形状的文本框
    $txtFrm = $aShp->getTextFrame();
    # 删除默认的现有段落
    $txtFrm->getParagraphs()->removeAt(0);
    # 创建段落
    $para = new Paragraph();
    # 设置段落项目符号样式和符号
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # 设置段落文本
    $para->setText("Welcome to Aspose.Slides");
    # 设置项目符号缩进
    $para->getParagraphFormat()->setIndent(25);
    # 设置项目符号颜色
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # 将 IsBulletHardColor 设置为 true 以使用自定义项目符号颜色
    $para->getParagraphFormat()->getBullet()->isBulletHardColor();
    # 设置项目符号高度
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # 将段落添加到文本框
    $txtFrm->getParagraphs()->add($para);
    # 将演示文稿保存为 PPTX 文件
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **创建图片项目符号**

Aspose.Slides for PHP via Java 允许您更改项目符号列表中的项目符号。您可以用自定义符号或图像替换项目符号。如果您想为列表增添视觉兴趣或进一步吸引列表条目，可使用自己的图片作为项目符号。

{{% alert color="primary" %}} 

理想情况下，如果您打算用图片替换常规项目符号，请选择具有透明背景的简单图形图像。这类图像最适合作为自定义项目符号。 

无论如何，所选图像会被缩小到非常小的尺寸，因此我们强烈建议您选择在列表中替代项目符号时仍能保持良好外观的图像。 

{{% /alert %}} 

创建图片项目符号的步骤如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。  
1. 使用 [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide) 对象访问幻灯片集合中的目标幻灯片。  
1. 在选定的幻灯片中添加自动形状。  
1. 访问所添加形状的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)。  
1. 删除 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) 中的默认段落。  
1. 使用 Paragraph 类创建第一个段落实例。  
1. 在 [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPPImage) 中从磁盘加载图像。  
1. 将项目符号类型设置为 Picture 并设置图像。  
1. 设置段落文本。  
1. 设置段落缩进以确定项目符号位置。  
1. 设置项目符号的颜色。  
1. 设置项目符号的高度。  
1. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) 的段落集合中。  
1. 添加第二个段落并重复前述步骤。  
1. 保存演示文稿。

以下 PHP 代码展示了如何在幻灯片中创建图片项目符号：
```php
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 实例化用于项目符号的图像
    $picture;
    $image = Images->fromFile("asp1.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 添加并访问自动形状
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问已创建自动形状的文本框
    $txtFrm = $aShp->getTextFrame();
    # 删除默认的现有段落
    $txtFrm->getParagraphs()->removeAt(0);
    # 创建新段落
    $para = new Paragraph();
    $para->setText("Welcome to Aspose.Slides");
    # 设置段落项目符号样式和图像
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $para->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # 设置项目符号高度
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # 将段落添加到文本框
    $txtFrm->getParagraphs()->add($para);
    # 将演示文稿写入为 PPTX 文件
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **创建多层级项目符号**

要创建包含不同层级项目的列表（主项目符号列表下的子列表），请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。  
1. 使用 [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide) 对象访问幻灯片集合中的目标幻灯片。  
1. 在选定的幻灯片中添加自动形状。  
1. 访问所添加形状的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)。  
1. 删除 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) 中的默认段落。  
1. 使用 Paragraph 类创建深度为 0 的第一个段落实例。  
1. 使用 Paragraph 类创建深度为 1 的第二个段落实例。  
1. 使用 Paragraph 类创建深度为 2 的第三个段落实例。  
1. 使用 Paragraph 类创建深度为 3 的第四个段落实例。  
1. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) 的段落集合中。  
1. 保存演示文稿。

以下代码实现了上述步骤，演示了如何创建多层级项目符号列表：
```php
  # 实例化一个表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加并访问自动形状
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问已创建自动形状的文本框
    $txtFrm = $aShp->addTextFrame("");
    # 删除默认的现有段落
    $txtFrm->getParagraphs()->clear();
    # 创建第一段落
    $para1 = new Paragraph();
    # 设置段落项目符号样式和符号
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置项目符号级别
    $para1->getParagraphFormat()->setDepth(0);
    # 创建第二段落
    $para2 = new Paragraph();
    # 设置段落项目符号样式和符号
    $para2->setText("Second level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置项目符号级别
    $para2->getParagraphFormat()->setDepth(1);
    # 创建第三段落
    $para3 = new Paragraph();
    # 设置段落项目符号样式和符号
    $para3->setText("Third level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置项目符号级别
    $para3->getParagraphFormat()->setDepth(2);
    # 创建第四段落
    $para4 = new Paragraph();
    # 设置段落项目符号样式和符号
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置项目符号级别
    $para4->getParagraphFormat()->setDepth(3);
    # 将段落添加到文本框
    $txtFrm->getParagraphs()->add($para1);
    $txtFrm->getParagraphs()->add($para2);
    $txtFrm->getParagraphs()->add($para3);
    $txtFrm->getParagraphs()->add($para4);
    # 保存演示文稿为 PPTX 文件
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **创建自定义编号列表**
Aspose.Slides for PHP via Java 提供了简单的 API 来管理具有自定义编号格式的段落。要在段落中添加自定义编号列表，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。  
1. 使用 [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide) 对象访问幻灯片集合中的目标幻灯片。  
1. 在选定的幻灯片中添加自动形状。  
1. 访问所添加形状的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)。  
1. 删除 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) 中的默认段落。  
1. 使用 Paragraph 类创建第一个段落实例，并将 **NumberedBulletStartWith** 设置为 2。  
1. 使用 Paragraph 类创建第二个段落实例，并将 **NumberedBulletStartWith** 设置为 3。  
1. 使用 Paragraph 类创建第三个段落实例，并将 **NumberedBulletStartWith** 设置为 7。  
1. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) 的段落集合中。  
1. 保存演示文稿。

以下 PHP 代码展示了如何在幻灯片中创建编号列表：
```php
  # 实例化一个表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加并访问自动形状
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问已创建自动形状的文本框
    $txtFrm = $aShp->addTextFrame("");
    # 删除默认的现有段落
    $txtFrm->getParagraphs()->clear();
    # 第一个列表
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph2);
    # 第二个列表
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 5");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(5);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph5);
    $pres->save($resourcesOutputPath . "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**使用 Aspose.Slides 创建的项目符号和编号列表能导出为 PDF 或图像等其他格式吗？**

可以，Aspose.Slides 在将演示文稿导出为 PDF、图像等格式时，完整保留项目符号和编号列表的格式与结构，确保结果一致。

**是否可以从已有的演示文稿中导入项目符号或编号列表？**

可以，Aspose.Slides 允许您导入并编辑已有演示文稿中的项目符号或编号列表，并保留原有的格式和外观。

**Aspose.Slides 是否支持在多语言演示文稿中使用项目符号和编号列表？**

可以，Aspose.Slides 完全支持多语言演示文稿，您可以在任何语言中创建项目符号和编号列表，包括使用特殊或非拉丁字符。