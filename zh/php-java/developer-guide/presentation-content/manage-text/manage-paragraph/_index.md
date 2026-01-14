---
title: 在 PHP 中管理 PowerPoint 文本段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh/php-java/manage-paragraph/
keywords:
- 添加文本
- 添加段落
- 管理文本
- 管理段落
- 管理项目符号
- 段落缩进
- 悬挂缩进
- 段落项目符号
- 编号列表
- 项目符号列表
- 段落属性
- 导入 HTML
- 文本转 HTML
- 段落转 HTML
- 段落转图像
- 文本转图像
- 导出段落
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（通过 Java）精通段落格式化——在 PPT、PPTX 和 ODP 演示文稿中优化对齐、间距和样式。"
---

Aspose.Slides 提供了处理 PowerPoint 文本、段落和文字块所需的所有类。

* Aspose.Slides 提供了 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 类，用于向演示文稿中添加表示段落的对象。一个 `TextFame` 对象可以包含一个或多个段落（每个段落通过回车创建）。
* Aspose.Slides 提供了 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 类，用于向演示文稿中添加表示文字块的对象。一个 `Paragraph` 对象可以包含一个或多个文字块（文字块对象的集合）。
* Aspose.Slides 提供了 [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) 类，用于向演示文稿中添加表示文本及其格式属性的对象。

`Paragraph` 对象通过其底层的 `Portion` 对象能够处理具有不同格式属性的文本。

## **添加包含多个文字块的多个段落**

以下步骤演示了如何添加一个包含 3 个段落且每个段落包含 3 个文字块的文本框：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取相应幻灯片的引用。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
4. 获取与该 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 关联的 ITextFrame。
5. 创建两个 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 对象并将其添加到 [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) 的段落集合中。
6. 为每个新 `Paragraph`（默认段落使用两个）创建三个 [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) 对象，并将每个 `Portion` 对象添加到相应 `Paragraph` 的文字块集合中。
7. 为每个文字块设置文本。
8. 使用 `Portion` 对象公开的格式属性为每个文字块应用所需的格式特性。
9. 保存修改后的演示文稿。

下面的 PHP 代码实现了上述添加文字块段落的步骤：
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
    # 创建具有不同文本格式的段落和文字块
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

项目符号列表可以帮助您快速、高效地组织和呈现信息。使用项目符号的段落更易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取相应幻灯片的引用。
3. 向选定的幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
4. 访问该 AutoShape 的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 类创建第一段落实例。
7. 将段落的项目符号 `Type` 设置为 `Symbol` 并指定项目符号字符。
8. 设置段落的 `Text`。
9. 为项目符号设置段落的 `Indent`。
10. 为项目符号设置颜色。
11. 为项目符号设置高度。
12. 将新段落添加到 `TextFrame` 的段落集合中。
13. 添加第二段落并重复步骤 7 至 13。
14. 保存演示文稿。

下面的 PHP 代码展示了如何添加段落项目符号：
```php
# 实例化一个表示 PPTX 文件的 Presentation 类
$pres = new Presentation();
try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加并访问 Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问 Autoshape 的文本框
    $txtFrm = $aShp->getTextFrame();
    # 删除默认段落
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
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// 设置 IsBulletHardColor 为 true 以使用自定义项目符号颜色

    # 设置项目符号高度
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # 将段落添加到文本框
    $txtFrm->getParagraphs()->add($para);
    # 创建第二段落
    $para2 = new Paragraph();
    # 设置段落项目符号类型和样式
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # 添加段落文本
    $para2->setText("This is numbered bullet");
    # 设置项目符号缩进
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// 设置 IsBulletHardColor 为 true 以使用自定义项目符号颜色

    # 设置项目符号高度
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # 将段落添加到文本框
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

项目符号列表可以帮助您快速、高效地组织和呈现信息。使用图片的段落同样易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取相应幻灯片的引用。
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
4. 访问该 AutoShape 的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 类创建第一段落实例。
7. 在 [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 中加载图片。
8. 将项目符号类型设置为 [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture) 并指定图片。
9. 设置段落的 `Text`。
10. 为项目符号设置段落的 `Indent`。
11. 为项目符号设置颜色。
12. 为项目符号设置高度。
13. 将新段落添加到 `TextFrame` 的段落集合中。
14. 添加第二段落并根据前述步骤重复操作。
15. 保存修改后的演示文稿。

下面的 PHP 代码展示了如何添加和管理图片项目符号：
```php
# 实例化一个表示 PPTX 文件的 Presentation 类
$presentation = new Presentation();
try {
    # 访问第一张幻灯片
    $slide = $presentation->getSlides()->get_Item(0);
    # 实例化用于项目符号的图像
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # 添加并访问 Autoshape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问 Autoshape 的文本框
    $textFrame = $autoShape->getTextFrame();
    # 删除默认段落
    $textFrame->getParagraphs()->removeAt(0);
    # 创建新段落
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # 设置段落项目符号样式和图像
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # 设置项目符号高度
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # 将段落添加到文本框
    $textFrame->getParagraphs()->add($paragraph);
    # 将演示文稿写入为 PPTX 文件
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # 将演示文稿写入为 PPT 文件
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


## **管理多级项目符号**

项目符号列表可以帮助您快速、高效地组织和呈现信息。多级项目符号同样易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取相应幻灯片的引用。
3. 在新幻灯片中添加一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
4. 访问该 AutoShape 的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 类创建第一段落实例并将深度设置为 0。
7. 通过 `Paragraph` 类创建第二段落实例并将深度设置为 1。
8. 通过 `Paragraph` 类创建第三段落实例并将深度设置为 2。
9. 通过 `Paragraph` 类创建第四段落实例并将深度设置为 3。
10. 将新段落添加到 `TextFrame` 的段落集合中。
11. 保存修改后的演示文稿。

下面的 PHP 代码展示了如何添加和管理多级项目符号：
```php
# 实例化一个表示 PPTX 文件的 Presentation 类
$pres = new Presentation();
try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加并访问 Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问已创建 Autoshape 的文本框
    $text = $aShp->addTextFrame("");
    # 清除默认段落
    $text->getParagraphs()->clear();
    # 添加第一段落
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置项目符号级别
    $para1->getParagraphFormat()->setDepth(0);
    # 添加第二段落
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置项目符号级别
    $para2->getParagraphFormat()->setDepth(1);
    # 添加第三段落
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置项目符号级别
    $para3->getParagraphFormat()->setDepth(2);
    # 添加第四段落
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置项目符号级别
    $para4->getParagraphFormat()->setDepth(3);
    # 将段落添加到集合
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # 将演示文稿保存为 PPTX 文件
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **使用自定义编号列表管理段落**

[BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) 类提供了 [setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 等方法，可帮助您管理具有自定义编号或格式的段落。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 获取包含目标段落的幻灯片。
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
4. 访问该 AutoShape 的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 类创建第一段落实例，并将 [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 设置为 2。
7. 通过 `Paragraph` 类创建第二段落实例，并将 `NumberedBulletStartWith` 设置为 3。
8. 通过 `Paragraph` 类创建第三段落实例，并将 `NumberedBulletStartWith` 设置为 7。
9. 将新段落添加到 `TextFrame` 的段落集合中。
10. 保存修改后的演示文稿。

下面的 PHP 代码展示了如何添加和管理具有自定义编号或格式的段落：
```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问已创建自动形状的文本框
    $textFrame = $shape->getTextFrame();
    # 删除默认的现有段落
    $textFrame->getParagraphs()->removeAt(0);
    # 第一列表
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
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

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取相应幻灯片的引用。  
1. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。  
1. 向矩形 AutoShape 添加一个包含三个段落的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。  
1. 隐藏矩形的边框。  
1. 通过段落的 BulletOffset 属性为每个 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 设置缩进。  
1. 将修改后的演示文稿写入为 PPT 文件。

下面的 PHP 代码展示了如何设置段落缩进：
```php
# 实例化 Presentation 类
$pres = new Presentation();
try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加矩形形状
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # 向矩形添加 TextFrame
    $tf = $rect->addTextFrame("This is first line \rThis is second line \rThis is third line");
    # 设置文本以适应形状
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # 隐藏矩形的线条
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # 获取 TextFrame 中的第一段落并设置其缩进
    $para1 = $tf->getParagraphs()->get_Item(0);
    # 设置段落项目符号样式和符号
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para1->getParagraphFormat()->setDepth(2);
    $para1->getParagraphFormat()->setIndent(30);
    # 获取 TextFrame 中的第二段落并设置其缩进
    $para2 = $tf->getParagraphs()->get_Item(1);
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar(8226);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para2->getParagraphFormat()->setDepth(2);
    $para2->getParagraphFormat()->setIndent(40);
    # 获取 TextFrame 中的第三段落并设置其缩进
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

下面的 PHP 代码展示了如何为段落设置悬挂缩进：
```php
$pres = new Presentation();
try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 550, 150);
    $para1 = new Paragraph();
    $para1->setText("Example");
    $para2 = new Paragraph();
    $para2->setText("Set Hanging Indent for Paragraph");
    $para3 = new Paragraph();
    $para3->setText("This code shows you how to set the hanging indent for a paragraph: ");
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


## **管理段落结束属性**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
1. 通过位置获取包含目标段落的幻灯片的引用。  
1. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。  
1. 向矩形添加一个包含两个段落的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。  
1. 为段落设置字体高度和字体类型。  
1. 为段落设置结束属性。  
1. 将修改后的演示文稿写入为 PPTX 文件。

下面的 PHP 代码展示了如何为 PowerPoint 中的段落设置结束属性：
```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
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

Aspose.Slides 提供了增强的 HTML 文本导入段落的支持。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取相应幻灯片的引用。  
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。  
4. 添加并访问 `AutoShape` 的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。  
5. 删除 `TextFrame` 中的默认段落。  
6. 在 TextReader 中读取源 HTML 文件。  
7. 通过 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 类创建第一段落实例。  
8. 将读取的 TextReader 中的 HTML 内容添加到 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/)。  
9. 保存修改后的演示文稿。

下面的 PHP 代码实现了将 HTML 文本导入段落的步骤：
```php
# 创建空的演示文稿实例
$pres = new Presentation();
try {
    # 访问演示文稿默认的第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加 AutoShape 以容纳 HTML 内容
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # 为形状添加文本框
    $ashape->addTextFrame("");
    # 清除已添加文本框中的所有段落
    $ashape->getTextFrame()->getParagraphs()->clear();
    # 使用流读取器加载 HTML 文件
    $tr = new StreamReader("file.html");
    # 将 HTML 流读取器的文本添加到文本框中
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # 保存演示文稿
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **导出段落文本为 HTML**

Aspose.Slides 提供了增强的将段落中的文本导出为 HTML 的支持。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例并加载所需的演示文稿。  
2. 通过索引获取相应幻灯片的引用。  
3. 获取包含要导出为 HTML 的文本的形状。  
4. 访问该形状的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。  
5. 创建 `StreamWriter` 实例并添加新的 HTML 文件。  
6. 为 StreamWriter 提供起始索引并导出所需的段落。

下面的 PHP 代码展示了如何将 PowerPoint 段落文本导出为 HTML：
```php
# 加载演示文稿文件
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # 访问演示文稿默认的第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 期望的索引
    $index = 0;
    # 访问已添加的形状
    $ashape = $slide->getShapes()->get_Item($index);
    # 创建输出 HTML 文件
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # 提取第一段落为 HTML
    # 通过提供段落起始索引和要复制的段落总数，将段落数据写入 HTML
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **将段落保存为图像**

本节将介绍两个示例，演示如何将由 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) 类表示的文本段落保存为图像。两个示例均包括：使用 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 类的 `getImage` 方法获取包含段落的形状图像，计算段落在形状中的边界，并将其导出为位图图像。这些方法可帮助您从 PowerPoint 演示文稿中提取特定文本部分并保存为单独的图像，便于在各种场景中进一步使用。

假设我们有一个名为 sample.pptx 的演示文稿，包含一张幻灯片，第一形状是一个包含三个段落的文本框。

![包含三个段落的文本框](paragraph_to_image_input.png)

**示例 1**

本示例获取第二段落的图像。为此，我们先提取演示文稿第一张幻灯片中该形状的图像，然后计算该形状文本框中第二段落的边界。随后将在新位图图像上重新绘制该段落，并以 PNG 格式保存。该方法在需要将特定段落另存为单独图像且需保持文本的精确尺寸和格式时尤为有用。
```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // 将形状保存到内存中为位图。
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // 从内存创建形状位图。
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // 计算第二段落的边界。
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // 计算输出图像的坐标和大小（最小尺寸为 1x1 像素）。
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // 裁剪形状位图，仅获取段落位图。
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


结果：

![段落图像](paragraph_to_image_output.png)

**示例 2**

本示例在前述方法基础上为段落图像添加了缩放因子。我们先提取形状并以 `2` 的缩放因子保存为图像，从而在导出段落时获得更高分辨率。随后在考虑缩放后的情况下计算段落边界。缩放在需要更高细节的图像时非常有用，例如用于高质量印刷材料。
```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // 将形状以缩放方式保存到内存中作为位图。
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // 从内存创建形状位图。
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // 计算第二段落的边界。
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // 计算输出图像的坐标和尺寸（最小尺寸为 1x1 像素）。
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // 裁剪形状位图，仅获取段落位图。
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


## **常见问题**

**我能完全禁用文本框内的自动换行吗？**

可以。使用文本框的换行设置（[setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/)）将换行关闭，行就不会在框边缘处断行。

**如何获取特定段落在幻灯片上的精准边界？**

您可以检索段落（甚至单个文字块）的边界矩形，以确定其在幻灯片上的精确位置和尺寸。

**段落的对齐方式（左/右/居中/两端对齐）在哪里控制？**

对齐是 [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) 中的段落级设置（[Alignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/)），它作用于整个段落，而不受单个文字块格式的影响。

**我能为段落中的某个单词单独设置拼写检查语言吗？**

可以。语言在文字块级别设置（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId)），因此一个段落中可以共存多种语言。