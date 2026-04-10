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
- 导入HTML
- 文本转HTML
- 段落转HTML
- 段落转图片
- 文本转图片
- 导出段落
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 完成段落格式化的全面掌控——在 PPT、PPTX 和 ODP 演示文稿中优化对齐、间距和样式。"
---
Aspose.Slides 提供了处理 PowerPoint 文本、段落和段落部分所需的所有类。

* Aspose.Slides 提供了 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/) 类，允许您添加表示段落的对象。一个 `TextFame` 对象可以包含一个或多个段落（每个段落通过回车创建）。
* Aspose.Slides 提供了 [Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 类，允许您添加表示部分的对象。一个 `Paragraph` 对象可以包含一个或多个部分（由部分对象构成的集合）。
* Aspose.Slides 提供了 [Portion](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/) 类，允许您添加表示文本及其格式属性的对象。

`Paragraph` 对象能够通过其底层的 `Portion` 对象处理具有不同格式属性的文本。

## **添加包含多个段落且每个段落包含多个部分的文本框**

以下步骤演示如何添加一个包含 3 个段落且每个段落包含 3 个部分的文本框：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
4. 获取与该 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/) 关联的 ITextFrame。
5. 创建两个 [Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 对象，并将它们添加到 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/) 的段落集合中。
6. 为每个新 `Paragraph` 创建三个 [Portion](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/) 对象（默认 Paragraph 需要两个 Portion 对象），并将每个 `Portion` 对象添加到各自 `Paragraph` 的部分集合中。
7. 为每个部分设置一些文本。
8. 使用 `Portion` 对象公开的格式属性，对每个部分应用首选的格式功能。
9. 保存修改后的演示文稿。

```php
# 实例化一个表示 PPTX 文件的 Presentation 类
$pres = new Presentation();
try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加一个矩形类型的 AutoShape
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

项目符号列表可帮助您快速高效地组织和呈现信息。带项目符号的段落更易阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向选定的幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
4. 访问该自动形状的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 将段落的 bullet `Type` 设置为 `Symbol` 并设置 bullet 字符。
8. 设置段落的 `Text`。
9. 为 bullet 设置段落的 `Indent`。
10. 为 bullet 设置颜色。
11. 设置 bullet 的高度。
12. 将新段落添加到 `TextFrame` 的段落集合中。
13. 添加第二个段落并重复步骤 7 到 12。
14. 保存演示文稿。

```php
# 实例化一个表示 PPTX 文件的 Presentation 类
$pres = new Presentation();
try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加并访问 AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问 AutoShape 的文本框
    $txtFrm = $aShp->getTextFrame();
    # 删除默认段落
    $txtFrm->getParagraphs()->removeAt(0);
    # 创建段落
    $para = new Paragraph();
    # 设置段落的项目符号样式和符号
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # 设置段落文本
    $para->setText("Welcome to Aspose.Slides");
    # 设置项目符号缩进
    $para->getParagraphFormat()->setIndent(25);
    # 设置项目符号颜色
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// 将 IsBulletHardColor 设置为 true 以使用自定义项目符号颜色

    # 设置项目符号高度
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # 将段落添加到文本框
    $txtFrm->getParagraphs()->add($para);
    # 创建第二段落
    $para2 = new Paragraph();
    # 设置段落的项目符号类型和样式
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # 添加段落文本
    $para2->setText("This is numbered bullet");
    # 设置项目符号缩进
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// 将 IsBulletHardColor 设置为 true 以使用自定义项目符号颜色

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

图片列表可帮助您快速高效地组织和呈现信息。图片段落易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
4. 访问该自动形状的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 在 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 中加载图像。
8. 将 bullet 类型设置为 [Picture](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bullettype/#Picture) 并设置图像。
9. 设置段落的 `Text`。
10. 为 bullet 设置段落的 `Indent`。
11. 为 bullet 设置颜色。
12. 为 bullet 设置高度。
13. 将新段落添加到 `TextFrame` 的段落集合中。
14. 添加第二个段落并根据前述步骤重复操作。
15. 保存修改后的演示文稿。

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
    # 将演示文稿保存为 PPTX 文件
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # 将演示文稿保存为 PPT 文件
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **管理多级项目符号**

项目符号列表可帮助您快速高效地组织和呈现信息。多级项目符号易于阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 在新幻灯片中添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
4. 访问该自动形状的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 类创建第一个段落实例，并将深度设置为 0。
7. 通过 `Paragraph` 类创建第二个段落实例，并将深度设置为 1。
8. 通过 `Paragraph` 类创建第三个段落实例，并将深度设置为 2。
9. 通过 `Paragraph` 类创建第四个段落实例，并将深度设置为 3。
10. 将新段落添加到 `TextFrame` 的段落集合中。
11. 保存修改后的演示文稿。

```php
# 实例化一个表示 PPTX 文件的 Presentation 类
$pres = new Presentation();
try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加并访问 Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问创建的 Autoshape 的文本框
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

## **管理自定义编号列表的段落**

[BulletFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/) 类提供了 [setNumberedBulletStartWith](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 等方法，帮助您管理具有自定义编号或格式的段落。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。
2. 访问包含该段落的幻灯片。
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
4. 访问自动形状的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 类创建第一个段落实例，并将 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 设置为 2。
7. 通过 `Paragraph` 类创建第二个段落实例，并将 `NumberedBulletStartWith` 设置为 3。
8. 通过 `Paragraph` 类创建第三个段落实例，并将 `NumberedBulletStartWith` 设置为 7。
9. 将新段落添加到 `TextFrame` 的段落集合中。
10. 保存修改后的演示文稿。

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 访问创建的 AutoShape 的文本框
    $textFrame = $shape->getTextFrame();
    # 删除默认的已存在段落
    $textFrame->getParagraphs()->removeAt(0);
    # 第一个列表
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

## **为段落设置首行缩进**

使用 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/setindent/) 方法可控制段落的首行缩进。此方法仅移动段落左侧边距相对的第一行。正值会将第一行向右移动，剩余行保持与段落正文对齐。

需要整体移动段落时使用 [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/setmarginleft/)。仅需移动第一行时使用 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/setindent/)。

下面的示例创建若干段落并应用不同的缩进值，以演示首行缩进对段落布局的影响。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
4. 向该形状添加一个空的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)，并删除默认段落。
5. 创建若干段落，并为它们设置不同的 [Indent](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/setindent/) 值。
6. 将段落添加到文本框中。
7. 保存修改后的演示文稿。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![段落的首行缩进](first_line_indent.png)

## **为段落设置悬挂缩进**

悬挂缩进是一种段落布局，首行位于其余行的左侧。 在 Aspose.Slides 中，可使用 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/setindent/) 方法实现此效果。 将缩进设为负值，即可使首行相对于段落正文向左移动。

实际操作中， [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/setmarginleft/) 定义段落正文的左侧位置， [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/setindent/) 定义首行相对于该左侧边距的位置。要实现悬挂缩进，请将正的 `MarginLeft` 与负的 `Indent` 组合使用。

此格式常用于参考文献、文献目录、术语表等需要第二行起对齐正文的段落。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
4. 向该形状添加一个空的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)，并删除默认段落。
5. 为每个段落设置一个正的 [MarginLeft](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/setmarginleft/) 值。
6. 设置一个负的 [Indent](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/setindent/) 值，以产生悬挂缩进效果。
7. 将段落添加到文本框中。
8. 保存修改后的演示文稿。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![段落的悬挂缩进](hanging_indent.png)

## **管理段落结尾运行属性**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。
2. 通过位置获取包含该段落的幻灯片的引用。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
4. 向矩形添加一个带有两个段落的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)。
5. 设置段落的字体高度和字体类型。
6. 为段落设置 End 属性。
7. 将修改后的演示文稿写入为 PPTX 文件。

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

Aspose.Slides 对将 HTML 文本导入段落提供了增强支持。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
4. 添加并访问 `AutoShape` 的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 在 TextReader 中读取源 HTML 文件。
7. 通过 [Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 类创建第一个段落实例。
8. 将读取的 TextReader 中的 HTML 内容添加到 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphcollection/)。
9. 保存修改后的演示文稿。

```php
# 创建空的演示文稿实例
$pres = new Presentation();
try {
    # 访问演示文稿的默认第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加 AutoShape 以容纳 HTML 内容
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # 向形状添加文本框
    $ashape->addTextFrame("");
    # 清除已添加文本框中的所有段落
    $ashape->getTextFrame()->getParagraphs()->clear();
    # 使用流读取器加载 HTML 文件
    $tr = new StreamReader("file.html");
    # 从 HTML 流读取器中添加文本到文本框
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

Aspose.Slides 对将段落中的文本导出为 HTML 提供了增强支持。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例并加载所需的演示文稿。
2. 通过索引访问相应幻灯片的引用。
3. 访问包含待导出为 HTML 文本的形状。
4. 访问该形状的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)。
5. 创建 `StreamWriter` 实例并添加新的 HTML 文件。
6. 为 StreamWriter 提供起始索引并导出您选择的段落。

```php
# 加载演示文稿文件
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # 访问演示文稿的默认第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 期望的索引
    $index = 0;
    # 访问已添加的形状
    $ashape = $slide->getShapes()->get_Item($index);
    # 创建输出 HTML 文件
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # 将首段提取为 HTML
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

## **将段落保存为图片**

本节将展示两个示例，演示如何将由 [Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 类表示的文本段落保存为图片。两者均通过 [Shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/) 类的 `getImage` 方法获取包含段落的形状图像，计算段落在形状中的边界，并将其导出为位图。此方法可将 PowerPoint 中的特定文本部分提取为独立图片，便于在各种场景中进一步使用。

假设我们有一个名为 sample.pptx 的演示文稿，包含一张幻灯片，第一形状是包含三段文本的文本框。

![包含三段文本的文本框](paragraph_to_image_input.png)

**示例 1**

本示例获取第二段文本并将其保存为图片。我们首先提取演示文稿第一张幻灯片中形状的图像，然后计算该形状文本框中第二段的边界。随后将该段落重新绘制到新的位图并以 PNG 格式保存。该方法在需要将特定段落单独保存为图片且保持原始尺寸和格式时非常有用。

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // 将形状保存为内存中的位图。
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // 从内存创建形状位图。
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // 计算第二段的边界。
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

![段落图片](paragraph_to_image_output.png)

**示例 2**

在前述方法的基础上，本示例为段落图片添加了缩放因子。形状图像以 `2` 的缩放因子提取，从而在导出段落时获得更高分辨率。随后在计算段落边界时考虑了该缩放比例。缩放在需要更高细节的图片（例如用于高质量印刷材料）时尤为有用。

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // 将形状以缩放方式保存为内存中的位图。
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // 从内存创建形状位图。
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // 计算第二段的边界。
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

## **常见问题解答**

**我可以完全禁用文本框内的自动换行吗？**

可以。使用文本框的换行设置（[setWrapText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/setwraptext/)）将换行关闭，即可防止在框边缘换行。

**如何获取特定段落在幻灯片上的精确边界？**

您可以检索段落（甚至单个 Portion）的 bounding rectangle，以了解其在幻灯片上的准确位置和尺寸。

**段落的对齐方式（左/右/居中/两端对齐）在哪里控制？**

[Alignment](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/setalignment/) 是 [ParagraphFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/) 的段落级设置；它作用于整个段落，而不受单个 Portion 的格式影响。

**我能为段落中的某个词单独设置拼写检查语言吗？**

可以。语言在 Portion 级别设置（[PortionFormat::setLanguageId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setLanguageId)），因此同一段落中可以共存多种语言。