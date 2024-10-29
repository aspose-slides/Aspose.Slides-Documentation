---
title: 管理 PowerPoint 段落
type: docs
weight: 40
url: /zh/php-java/manage-paragraph/
keywords: "添加 PowerPoint 段落, 管理段落, 段落缩进, 段落属性, HTML 文本, 导出段落文本, PowerPoint 演示文稿, Java, Aspose.Slides for PHP via Java"
description: "创建和管理 PowerPoint 演示文稿中的段落、文本、缩进和属性"
---

Aspose.Slides 提供了您与 PowerPoint 文本、段落和部分一起工作的所有接口和类。

* Aspose.Slides 提供了 [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) 接口，允许您添加表示段落的对象。一个 `ITextFrame` 对象可以有一个或多个段落（每个段落通过换行符创建）。
* Aspose.Slides 提供了 [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) 接口，允许您添加表示部分的对象。一个 `IParagraph` 对象可以有一个或多个部分（iPortions 对象的集合）。
* Aspose.Slides 提供 [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) 接口，允许您添加表示文本及其格式属性的对象。

一个 `IParagraph` 对象能够通过其底层的 `IPortion` 对象处理具有不同格式属性的文本。

## **添加多个包含多个部分的段落**

这些步骤演示了如何添加一个文本框，其中包含 3 个段落，每个段落包含 3 个部分：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向幻灯片添加一个矩形 [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)。
4. 获取与 [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) 相关联的 ITextFrame。
5. 创建两个 [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) 对象并将它们添加到 [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) 的 `IParagraphs` 集合中。
6. 为每个新 `IParagraph` 创建三个 [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) 对象（默认段落中的两个部分对象），并将每个 `IPortion` 对象添加到每个 `IParagraph` 的 IPortion 集合中。
7. 为每个部分设置一些文本。
8. 使用 `IPortion` 对象所暴露的格式属性应用您首选的格式功能。
9. 保存修改后的演示文稿。

下面的 PHP 代码实现了添加包含部分的段落的步骤：

```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加矩形类型的 AutoShape 
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # 访问 AutoShape 的 TextFrame
    $tf = $ashp->getTextFrame();
    # 创建具有不同文本格式的段落和部分
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
      for($j = 0; $j < 3; $j++) {
        $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
        $portion->setText("Portion0" . $j);
        if ($j == 0) {
          $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
          $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
          $portion->getPortionFormat()->setFontBold(NullableBool::True);
          $portion->getPortionFormat()->setFontHeight(15);
        } else if ($j == 1) {
          $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
          $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
          $portion->getPortionFormat()->setFontItalic(NullableBool::True);
          $portion->getPortionFormat()->setFontHeight(18);
        }
      }
    }
    # 将 PPTX 写入磁盘
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **管理段落项目符号**

项目符号列表帮助您快速高效地组织和呈现信息。带有项目符号的段落总是更易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向选定的幻灯片添加一个 [自动形状](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)。
4. 访问自动形状的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 将段落的项目符号 `Type` 设置为 `Symbol` 并设置项目符号字符。
8. 设置段落 `Text`。
9. 为项目符号设置段落 `Indent`。
10. 为项目符号设置颜色。
11. 设置项目符号的高度。
12. 将新段落添加到 `TextFrame` 段落集合中。
13. 添加第二个段落并重复步骤 7 到 13 所述过程。
14. 保存演示文稿。

下面的 PHP 代码演示了如何添加段落项目符号：

```php
  # 实例化一个表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加并访问自动形状
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问自动形状文本框
    $txtFrm = $aShp->getTextFrame();
    # 删除默认段落
    $txtFrm->getParagraphs()->removeAt(0);
    # 创建一个段落
    $para = new Paragraph();
    # 设置段落项目符号样式和符号
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # 设置段落文本
    $para->setText("欢迎使用 Aspose.Slides");
    # 设置项目符号缩进
    $para->getParagraphFormat()->setIndent(25);
    # 设置项目符号颜色
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True); // 将 IsBulletHardColor 设置为 true 以使用自定义项目符号颜色

    # 设置项目符号高度
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # 将段落添加到文本框中
    $txtFrm->getParagraphs()->add($para);
    # 创建第二个段落
    $para2 = new Paragraph();
    # 设置段落项目符号类型和样式
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # 添加段落文本
    $para2->setText("这是编号项目符号");
    # 设置项目符号缩进
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True); // 将 IsBulletHardColor 设置为 true 以使用自定义项目符号颜色

    # 设置项目符号高度
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # 将段落添加到文本框中
    $txtFrm->getParagraphs()->add($para2);
    # 保存修改后的演示文稿
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **管理图片项目符号**

项目符号列表可以帮助您快速高效地组织和呈现信息。图片段落易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向幻灯片添加一个 [自动形状](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)。
4. 访问自动形状的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 在 [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/) 中加载图像。
8. 将项目符号类型设置为 [图片](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/) 并设置图像。
9. 设置段落 `Text`。
10. 设置段落 `Indent` 以实现项目符号。
11. 设置项目符号的颜色。
12. 设置项目符号的高度。
13. 将新段落添加到 `TextFrame` 段落集合中。
14. 添加第二个段落并根据前面的步骤重复过程。
15. 保存修改后的演示文稿。

下面的 PHP 代码演示了如何添加和管理图片项目符号：

```php
  # 实例化一个表示 PPTX 文件的 Presentation 类
  $presentation = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $presentation->getSlides()->get_Item(0);
    # 实例化项目符号的图像
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
      $picture = $presentation->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 添加并访问自动形状
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问自动形状文本框
    $textFrame = $autoShape->getTextFrame();
    # 删除默认段落
    $textFrame->getParagraphs()->removeAt(0);
    # 创建一个新段落
    $paragraph = new Paragraph();
    $paragraph->setText("欢迎使用 Aspose.Slides");
    # 设置段落项目符号样式和图像
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # 设置项目符号高度
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # 将段落添加到文本框中
    $textFrame->getParagraphs()->add($paragraph);
    # 将演示文稿写入 PPTX 文件
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # 将演示文稿写入 PPT 文件
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **管理多级项目符号**

项目符号列表帮助您快速高效地组织和呈现信息。多级项目符号易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 在新幻灯片中添加一个 [自动形状](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)。
4. 访问自动形状的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 类创建第一个段落实例并设置深度为 0。
7. 通过 `Paragraph` 类创建第二个段落实例并将深度设置为 1。
8. 通过 `Paragraph` 类创建第三个段落实例并将深度设置为 2。
9. 通过 `Paragraph` 类创建第四个段落实例并将深度设置为 3。
10. 将新段落添加到 `TextFrame` 段落集合中。
11. 保存修改后的演示文稿。

下面的 PHP 代码演示了如何添加和管理多级项目符号：

```php
  # 实例化一个表示 PPTX 文件的 Presentation 类
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加并访问自动形状
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问创建的自动形状的文本框
    $text = $aShp->addTextFrame("");
    # 清除默认段落
    $text->getParagraphs()->clear();
    # 添加第一个段落
    $para1 = new Paragraph();
    $para1->setText("内容");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置项目符号级别
    $para1->getParagraphFormat()->setDepth(0);
    # 添加第二个段落
    $para2 = new Paragraph();
    $para2->setText("第二级");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置项目符号级别
    $para2->getParagraphFormat()->setDepth(1);
    # 添加第三个段落
    $para3 = new Paragraph();
    $para3->setText("第三级");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置项目符号级别
    $para3->getParagraphFormat()->setDepth(2);
    # 添加第四个段落
    $para4 = new Paragraph();
    $para4->setText("第四级");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置项目符号级别
    $para4->getParagraphFormat()->setDepth(3);
    # 将段落添加到集合中
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # 将演示文稿写入 PPTX 文件
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **管理带有自定义编号列表的段落**

[IBulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/) 接口提供了 [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 属性和其他属性，允许您管理带有自定义编号或格式的段落。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 访问包含段落的幻灯片。
3. 向幻灯片添加一个 [自动形状](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)。
4. 访问自动形状的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 类通过设置 [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 为 2 创建第一个段落实例。
7. 使用 `Paragraph` 类通过设置 `NumberedBulletStartWith` 为 3 创建第二个段落实例。
8. 使用 `Paragraph` 类通过设置 `NumberedBulletStartWith` 为 7 创建第三个段落实例。
9. 将新段落添加到 `TextFrame` 段落集合中。
10. 保存修改后的演示文稿。

下面的 PHP 代码演示了如何添加和管理带有自定义编号或格式的段落：

```php
  $presentation = new Presentation();
  try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问创建的自动形状的文本框
    $textFrame = $shape->getTextFrame();
    # 删除默认的现有段落
    $textFrame->getParagraphs()->removeAt(0);
    # 第一个列表
    $paragraph1 = new Paragraph();
    $paragraph1->setText("项目符号 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("项目符号 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("项目符号 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **设置段落缩进**

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
1. 通过其索引访问相关幻灯片的引用。
1. 向幻灯片添加一个矩形 [自动形状](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)。
1. 向矩形自动形状添加一个带有三个段落的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)。
1. 隐藏矩形的边框。
1. 通过每个 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 的 BulletOffset 属性设置缩进。
1. 将修改后的演示文稿写入 PPT 文件。

下面的 PHP 代码演示了如何设置段落缩进：

```php
  # 实例化 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加矩形形状
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # 向矩形添加 TextFrame
    $tf = $rect->addTextFrame("这是第一行 \r这是第二行 \r这是第三行");
    # 设置文本以适应形状
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # 隐藏矩形的边框
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # 获取 TextFrame 中的第一个段落并设置其缩进
    $para1 = $tf->getParagraphs()->get_Item(0);
    # 设置段落项目符号样式和符号
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para1->getParagraphFormat()->setDepth(2);
    $para1->getParagraphFormat()->setIndent(30);
    # 获取 TextFrame 中的第二个段落并设置其缩进
    $para2 = $tf->getParagraphs()->get_Item(1);
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar(8226);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para2->getParagraphFormat()->setDepth(2);
    $para2->getParagraphFormat()->setIndent(40);
    # 获取 TextFrame 中的第三个段落并设置其缩进
    $para3 = $tf->getParagraphs()->get_Item(2);
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para3->getParagraphFormat()->setDepth(2);
    $para3->getParagraphFormat()->setIndent(50);
    # 将演示文稿写入磁盘
    $pres->save("InOutDent_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **为段落设置悬挂缩进**

这段 PHP 代码演示了如何为段落设置悬挂缩进：

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 550, 150);
    $para1 = new Paragraph();
    $para1->setText("示例");
    $para2 = new Paragraph();
    $para2->setText("为段落设置悬挂缩进");
    $para3 = new Paragraph();
    $para3->setText("此 C# 代码演示了如何为段落设置悬挂缩进： ");
    $para2->getParagraphFormat()->setMarginLeft(10.0);
    $para3->getParagraphFormat()->setMarginLeft(20.0);
    $autoShape->getTextFrame()->getParagraphs()->add($para1);
    $autoShape->getTextFrame()->getParagraphs()->add($para2);
    $autoShape->getTextFrame()->getParagraphs()->add($para3);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **管理段落的结束段落运行属性**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
1. 通过其位置获取包含段落的幻灯片的引用。
1. 向幻灯片添加一个矩形 [自动形状](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)。
1. 向矩形添加一个带有两个段落的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)。
1. 为段落设置 `FontHeight` 和字体类型。
1. 为段落设置结束属性。
1. 将修改后的演示文稿写入 PPTX 文件。

下面的 PHP 代码演示了如何设置 PowerPoint 中段落的结束属性：

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("示例文本"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("示例文本 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **将 HTML 文本导入段落**

Aspose.Slides 提供了增强的支持，用于将 HTML 文本导入段落。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 通过其索引访问相关幻灯片的引用。
3. 向幻灯片添加一个 [自动形状](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/)。
4. 添加并访问 `autoshape` [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/)。
5. 删除 `ITextFrame` 中的默认段落。
6. 在 TextReader 中读取源 HTML 文件。
7. 使用 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 类创建第一个段落实例。
8. 将读取的 TextReader 中的 HTML 文件内容添加到 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/)。
9. 保存修改后的演示文稿。

下面的 PHP 代码是将 HTML 文本导入段落的步骤的实现：

```php
  # 创建空的演示实例
  $pres = new Presentation();
  try {
    # 访问演示文稿的默认第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加自动形状以容纳 HTML 内容
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # 向形状添加文本框
    $ashape->addTextFrame("");
    # 清除添加的文本框中的所有段落
    $ashape->getTextFrame()->getParagraphs()->clear();
    # 使用流读取器加载 HTML 文件
    $tr = new StreamReader("file.html");
    # 将 HTML 流读取器中的文本添加到文本框的段落中
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # 保存演示文稿
    $pres->save("output_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **将段落文本导出为 HTML**

Aspose.Slides 提供了增强的支持，将文本（包含在段落中）导出为 HTML。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例并加载所需的演示文稿。
2. 通过其索引访问相关幻灯片的引用。
3. 访问包含要导出为 HTML 的文本的形状。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。
5. 创建一个 `StreamWriter` 实例并添加新的 HTML 文件。
6. 为 StreamWriter 提供起始索引并导出您所需的段落。

下面的 PHP 代码演示了如何将 PowerPoint 段落文本导出为 HTML：

```php
  # 加载演示文稿文件
  $pres = new Presentation("ExportingHTMLText.pptx");
  try {
    # 访问演示文稿的默认第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 所需索引
    $index = 0;
    # 访问已添加的形状
    $ashape = $slide->getShapes()->get_Item($index);
    # 创建输出 HTML 文件
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # 将第一个段落提取为 HTML
    # 通过提供段落起始索引和要复制的总段落，将段落数据写入 HTML
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```