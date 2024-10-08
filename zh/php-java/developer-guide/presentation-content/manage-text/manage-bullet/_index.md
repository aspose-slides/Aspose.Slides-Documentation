---
title: 管理项目符号
type: docs
weight: 60
url: /zh/php-java/manage-bullet/
keywords: "项目符号, 项目符号列表, 数字, 编号列表, 图片项目符号, 多级项目符号, PowerPoint演示文稿, Java, Aspose.Slides for PHP via Java"
description: "在PowerPoint演示文稿中创建项目符号和编号列表"
---

在**Microsoft PowerPoint**中，您可以像在Word和其他文本编辑器中一样创建项目符号和编号列表。**Aspose.Slides for PHP via Java**也允许您在演示文稿的幻灯片中使用项目符号和编号。

## 为什么使用项目符号列表？

项目符号列表帮助您快速高效地组织和展示信息。

**项目符号列表示例**

在大多数情况下，项目符号列表具有以下三个主要功能：

- 吸引读者或观众的注意力到重要信息
- 使读者或观众能够轻松扫描关键点
- 高效地传达和提供重要细节。

## 为什么使用编号列表？

编号列表也有助于组织和展示信息。理想情况下，当条目的顺序（例如，*步骤 1，步骤 2*等）很重要或当条目需要被引用（例如，*参见步骤 3*）时，您应该使用数字（代替项目符号）。

**编号列表示例**

以下是**创建项目符号**过程中的步骤摘要（步骤 1 到步骤 15）：

1. 创建演示文稿类的实例。
2. 执行多个任务（步骤 3 到步骤 14）。
3. 保存演示文稿。

## 创建项目符号
此主题也是管理文本段落主题系列的一部分。此页面将说明如何管理段落项目符号。描述诸如分步说明的内容时，项目符号更为有用。此外，使用项目符号使文本看起来井然有序。带项目符号的段落总是更容易阅读和理解。我们将看到开发人员如何使用Aspose.Slides for PHP via Java这一小而强大的功能。请按照以下步骤使用Aspose.Slides for PHP via Java管理段落项目符号：

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)类的实例。
1. 使用[ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide)对象访问幻灯片集合中的所需幻灯片。
1. 在选定的幻灯片中添加一个[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText)。
1. 访问添加形状的[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame)。
1. 移除TextFrame中的默认段落。
1. 使用[Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph)类创建第一个段落实例。
1. 设置段落的项目符号类型。
1. 将项目符号类型设置为[Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/BulletType#Symbol)并设置项目符号字符。
1. 设置段落文本。
1. 设置段落缩进以设置项目符号。
1. 设置项目符号的颜色。
1. 设置项目符号的高度。
1. 将创建的段落添加到TextFrame段落集合中。
1. 添加第二个段落，并重复步骤**7到13**中给出的过程。
1. 保存演示文稿。

此示例代码 — 上述步骤的实现 — 向您展示如何在幻灯片中创建项目符号列表：

```php
  # 实例化一个表示PPTX文件的Presentation类
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加和访问Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问创建的autoshape的文本框
    $txtFrm = $aShp->getTextFrame();
    # 移除默认的现有段落
    $txtFrm->getParagraphs()->removeAt(0);
    # 创建一个段落
    $para = new Paragraph();
    # 设置段落项目符号样式和符号
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # 设置段落文本
    $para->setText("欢迎使用Aspose.Slides");
    # 设置项目符号缩进
    $para->getParagraphFormat()->setIndent(25);
    # 设置项目符号颜色
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # 将IsBulletHardColor设置为true以使用自己的项目符号颜色
    $para->getParagraphFormat()->getBullet()->isBulletHardColor();
    # 设置项目符号高度
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # 将段落添加到文本框
    $txtFrm->getParagraphs()->add($para);
    # 将演示文稿保存为PPTX文件
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## 创建图片项目符号

Aspose.Slides for PHP via Java允许您更改项目符号列表中的项目符号。您可以使用自定义符号或图像替换项目符号。如果您想为列表添加视觉趣味，或进一步吸引对列表中条目的注意，可以使用自己的图像作为项目符号。

{{% alert color="primary" %}} 

理想情况下，如果您打算用图片替换常规项目符号符号，您可能希望选择一张简单的图形图像，并且背景透明。这样的图像作为自定义项目符号符号效果最佳。

无论如何，您选择的图像将被缩小到非常小的尺寸，因此我们强烈建议您选择一张在列表中看起来不错的图像（作为项目符号符号的替代品）。

{{% /alert %}} 

要创建图片项目符号，请按照以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)类的实例。
1. 使用[ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide)对象访问幻灯片集合中的所需幻灯片。
1. 在选定的幻灯片中添加一个autoshape。
1. 访问添加形状的[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)。
1. 移除[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)中的默认段落。
1. 使用Paragraph类创建第一个段落实例。
1. 从磁盘加载图像到[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPPImage)。
1. 将项目符号类型设置为图片并设置图像。
1. 设置段落文本。
1. 设置段落缩进以设置项目符号。
1. 设置项目符号的颜色。
1. 设置项目符号的高度。
1. 将创建的段落添加到[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)段落集合中。
1. 添加第二个段落，并重复之前步骤中给出的过程。
1. 保存演示文稿。

这段PHP代码向您展示如何在幻灯片中创建图片项目符号：

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
    # 添加和访问Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问创建的autoshape的文本框
    $txtFrm = $aShp->getTextFrame();
    # 移除默认的现有段落
    $txtFrm->getParagraphs()->removeAt(0);
    # 创建新的段落
    $para = new Paragraph();
    $para->setText("欢迎使用Aspose.Slides");
    # 设置段落项目符号样式和图像
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $para->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # 设置项目符号高度
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # 将段落添加到文本框
    $txtFrm->getParagraphs()->add($para);
    # 将演示文稿写入PPTX文件
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## 创建多级项目符号

要创建包含不同层级项目符号项目的项目符号列表，即在主项目符号列表下的附加列表，请按照以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)类的实例。
1. 使用[ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide)对象访问幻灯片集合中的所需幻灯片。
1. 在选定的幻灯片中添加一个autoshape。
1. 访问添加形状的[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)。
1. 移除[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)中的默认段落。
1. 使用Paragraph类创建第一个段落实例，并将深度设置为0。
1. 使用Paragraph类创建第二个段落实例，并将深度设置为1。
1. 使用Paragraph类创建第三个段落实例，并将深度设置为2。
1. 使用Paragraph类创建第四个段落实例，并将深度设置为3。
1. 将创建的段落添加到[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)段落集合中。
1. 保存演示文稿。

以下代码是上述步骤的实现，向您展示如何创建一个多级项目符号列表：

```php
  # 实例化一个表示PPTX文件的Presentation类
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加和访问Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问创建的autoshape的文本框
    $txtFrm = $aShp->addTextFrame("");
    # 移除默认的现有段落
    $txtFrm->getParagraphs()->clear();
    # 创建第一个段落
    $para1 = new Paragraph();
    # 设置段落项目符号样式和符号
    $para1->setText("内容");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置项目符号级别
    $para1->getParagraphFormat()->setDepth(0);
    # 创建第二个段落
    $para2 = new Paragraph();
    # 设置段落项目符号样式和符号
    $para2->setText("第二级");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置项目符号级别
    $para2->getParagraphFormat()->setDepth(1);
    # 创建第三个段落
    $para3 = new Paragraph();
    # 设置段落项目符号样式和符号
    $para3->setText("第三级");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置项目符号级别
    $para3->getParagraphFormat()->setDepth(2);
    # 创建第四个段落
    $para4 = new Paragraph();
    # 设置段落项目符号样式和符号
    $para4->setText("第四级");
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
    # 将演示文稿保存为PPTX文件
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## 创建自定义编号列表
Aspose.Slides for PHP via Java提供了一个简单的API来管理带有自定义数字格式的段落。要在段落中添加一个自定义编号列表，请按照以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)类的实例。
1. 使用[ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide)对象访问幻灯片集合中的所需幻灯片。
1. 在选定的幻灯片中添加一个autoshape。
1. 访问添加形状的[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)。
1. 移除[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)中的默认段落。
1. 使用Paragraph类创建第一个段落实例，并将**NumberedBulletStartWith**设置为2。
1. 使用Paragraph类创建第二个段落实例，并将**NumberedBulletStartWith**设置为3。
1. 使用Paragraph类创建第三个段落实例，并将**NumberedBulletStartWith**设置为7。
1. 将创建的段落添加到[TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)段落集合中。
1. 保存演示文稿。

这段PHP代码向您展示如何在幻灯片中创建一个编号列表：

```php
  # 实例化一个表示PPTX文件的Presentation类
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加和访问Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问创建的autoshape的文本框
    $txtFrm = $aShp->addTextFrame("");
    # 移除默认的现有段落
    $txtFrm->getParagraphs()->clear();
    # 第一个列表
    $paragraph1 = new Paragraph();
    $paragraph1->setText("编号 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("编号 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph2);
    # 第二个列表
    $paragraph5 = new Paragraph();
    $paragraph5->setText("编号 5");
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