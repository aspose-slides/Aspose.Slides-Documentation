---
title: 管理 PowerPoint 文本段落在 PHP 中
linktitle: 管理段落
type: docs
weight: 40
url: /zh/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
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
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 创建和格式化段落、Portion、项目符号、编号列表、缩进、HTML 内容以及段落图像。"
---
## **概述**

Aspose.Slides for PHP via Java 将文本表示为文本框、段落和 Portion 的层次结构：

* [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/) 表示形状中的文本容器，并提供对其段落集合的访问。
* [Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 表示文本框中的一个段落，并提供对其 Portion 和段落级格式的访问。
* [Portion](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/) 表示段落内的一个文本运行。每个 Portion 可以拥有自己的文本和字符级格式。

因此，一个段落可以通过使用多个 Portion 来包含不同字体、颜色、大小和其他格式的文本。

## **创建和格式化段落**

### **创建包含多个 Portion 的段落**

以下步骤创建一个包含三个段落、每个段落有三个 Portion 的文本框：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 向幻灯片添加一个矩形的 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)。
5. 使用默认段落并向文本框添加另外两个 [Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 对象。
6. 为每个段落添加足够的 [Portion](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/) 对象，使其包含三个 Portion。默认段落已经包含一个空的 Portion。
7. 设置每个 Portion 的文本。
8. 通过 [Portion::getPortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/#getPortionFormat--) 应用字符级格式设置。
9. 保存修改后的演示文稿。

此 PHP 示例实现了上述步骤：

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **创建项目符号和编号列表**

### **创建项目符号或编号列表**

项目符号和编号可以让相关项更易于浏览。在 Aspose.Slides 中，列表设置通过 [BulletFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/) 定义。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 向选定的幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)。
5. 从文本框中移除默认段落。
6. 为符号项目符号创建一个 [Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/)。
7. 将 [BulletFormat::setType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/#setType-int-) 设置为 [BulletType::Symbol](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bullettype/) 并指定项目符号字符。
8. 设置段落的文本、缩进、项目符号颜色和项目符号高度。
9. 将段落添加到文本框。
10. 创建第二个段落并将 [BulletFormat::setType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/#setType-int-) 设置为 [BulletType::Numbered](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bullettype/)。
11. 配置编号项目符号样式并将段落添加到文本框。
12. 保存演示文稿。

此 PHP 示例创建了一个符号项目符号和一个编号项目符号：

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **使用图片项目符号**

图片项目符号允许使用自定义图像代替符号或数字。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/) 并访问其 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)。
4. 从文本框中移除默认段落。
5. 加载项目符号图像并将其作为 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 添加到演示文稿的图像集合中。
6. 创建一个 [Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 并设置其文本。
7. 将 [BulletFormat::setType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/#setType-int-) 设置为 [BulletType::Picture](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bullettype/)。
8. 通过 [BulletFormat::getPicture](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/#getPicture--) 指定图像并设置项目符号高度。
9. 将段落添加到文本框。
10. 保存修改后的演示文稿。

此 PHP 示例创建了一个图片项目符号：

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **创建多级列表**

将 [ParagraphFormat::setDepth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setDepth-short-) 设置为不同的深度，以在列表中放置不同层级的段落。顶层的深度为 `0`。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 并访问一张幻灯片。
2. 添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/) 并清除其文本框中的默认段落。
3. 创建四个段落并配置其项目符号符号。
4. 将它们的 [ParagraphFormat::setDepth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setDepth-short-) 值分别设为 `0`、`1`、`2`、`3`。
5. 将段落添加到文本框并保存演示文稿。

此 PHP 示例创建了一个四级项目符号列表：

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **自定义编号列表的起始值**

使用 [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) 为编号段落设置初始显示的数字。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 并向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
2. 清除形状文本框中的默认段落。
3. 创建三个编号段落。
4. 为相应段落将 [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) 设置为 `2`、`3`、`7`。
5. 将段落添加到文本框并保存演示文稿。

此 PHP 示例为每个段落分配了自定义的起始编号：

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **控制段落布局和结束属性**

### **设置首行缩进**

使用 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setIndent-float-) 控制段落的首行缩进。此方法仅移动首行相对于段落左边距的位置。正值将首行向右移动，而其余行保持与段落主体对齐。

需要整体移动整段时使用 [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-)。仅需移动首行时使用 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setIndent-float-)。

下面的示例创建了若干段落，并对不同的 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setIndent-float-) 值进行演示，以展示首行缩进对段落布局的影响。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形的 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/) 并移除默认段落。
5. 创建若干段落并为它们设置不同的 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setIndent-float-) 值。
6. 将段落添加到文本框。
7. 保存修改后的演示文稿。

此 PHP 代码展示了如何设置段落缩进：

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
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

### **设置悬挂缩进**

悬挂缩进是一种段落布局，其中首行位于其余行的左侧。在 Aspose.Slides 中，可通过 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setIndent-float-) 实现。传入负值即可把首行相对于段落主体向左移动。

实际使用时，`[ParagraphFormat::setMarginLeft]` 定义段落主体的左侧位置，`[ParagraphFormat::setIndent]` 定义首行相对于该左侧的位置。要实现悬挂缩进，需对 `setMarginLeft` 传入正值，对 `setIndent` 传入负值。

此格式常用于参考文献、词汇表条目等，需要让换行后的行对齐到段落正文而非首行首字符的场景。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形的 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/) 并移除默认段落。
5. 为每个段落调用 [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) 传入正值。
6. 通过 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setIndent-float-) 传入负值以产生悬挂缩进效果。
7. 将段落添加到文本框。
8. 保存修改后的演示文稿。

此 PHP 代码展示了如何为段落设置悬挂缩进：

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
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

### **设置段落结束运行属性**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) 控制段落结束标记的格式。下面的 PHP 示例为第二段落的结束标记分配了字体大小和拉丁字体：

1. 加载一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 并访问一张幻灯片。
2. 添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/) 并清除其默认段落。
3. 创建两个段落并向其中添加文本 Portion。
4. 为第二段落的结束标记创建一个 [PortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portionformat/)。
5. 设置 [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) 和 [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-)。
6. 使用 [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) 赋予格式并保存演示文稿。

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **导入和导出段落内容**

### **将 HTML 文本导入段落**

使用 [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) 将 HTML 标记转换为文本框中的段落和 Portion。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例。
2. 访问一张幻灯片并添加一个 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
3. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/) 并清除默认段落。
4. 读取源 HTML 文件。
5. 将 HTML 字符串传递给 [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)。
6. 保存修改后的演示文稿。

此 PHP 示例将 HTML 导入到文本框中：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **将段落文本导出为 HTML**

使用 [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) 将选定范围的段落导出为 HTML。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类的实例并加载所需的演示文稿。
2. 访问幻灯片并找到包含文本的 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)。
3. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)。
4. 调用 [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) 并提供起始段落索引和要导出的段落数量。
5. 将返回的 HTML 字符串写入文件。

此 PHP 示例导出第一个文本形状中的所有段落：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **将段落渲染为图像**

[Paragraph::getImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/#getImage--) 直接渲染单个段落并返回一个 [IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/)。使用 [IImage::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/#save-java.lang.String-int-) 将结果保存到文件或流中。无需渲染包含的形状或手动裁剪位图。

如果段落在其父集合中未找到、没有有效的渲染边界，或无法渲染，[Paragraph::getImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/#getImage--) 可能返回 `null`。在保存之前检查返回值，并在使用后释放图像。

#### **在默认比例下渲染段落**

假设我们有一个名为 sample.pptx 的演示文稿，包含一张幻灯片，第一形状是一个包含三段落的文本框。

![包含三段落的文本框](paragraph_to_image_input.png)

下面的 PHP 示例在默认比例下渲染第二段落并以 PNG 格式保存返回的图像。`finally` 块确保图像被正确释放。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

结果：

![段落图像](paragraph_to_image_output.png)

#### **在表格单元格中按比例渲染段落**

使用接受 `$scaleX`和 `$scaleY` 参数的 [Paragraph::getImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/#getImage-float-float-) 重载来设置水平和垂直比例因子。下面的 PHP 示例创建一个表格，在其第一个单元格中以两倍的默认宽高渲染段落，并将结果保存为 PNG 图像。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

比例因子 `1` 保持该轴的默认像素尺寸。例如，两个因子均为 `2` 时，生成的图像宽高约为默认尺寸的两倍，即像素数量约为四倍。更大的因子通常可在放大或高分辨率输出时获得更锐利的文字，但也会增加内存使用和文件大小。小于 `1` 的因子会生成更小的图像，细节减少。使用相同的因子可保持段落的宽高比；不同的水平和垂直因子会独立拉伸输出。

在需要包含形状填充、边框或其他视觉上下文的情况下，仍可使用 [Shape::getImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#getImage--) 渲染整个形状。仅需段落图像时，请使用 [Paragraph::getImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/#getImage--)。

## **常见问题解答**

**我能完全禁用文本框内的换行吗？**

可以。将 [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/#setWrapText-byte-) 设置为禁用换行，使行不会在文本框边缘断开。

**如何获取特定段落在幻灯片上的精确边界？**

使用 [Paragraph::getRect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/#getRect--) 获取段落的矩形边界。[Portion::getRect](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/#getRect--) 提供单个 Portion 的边界。

**段落的对齐方式（左、右、居中或两端对齐）在哪里控制？**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setAlignment-int-) 是段落级设置，适用于整个段落，而不受单个 Portion 格式的影响。

**我可以为段落的部分文本设置校对语言吗？**

可以。为各个 Portion 设置 [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)，这样一个段落可以包含多种语言的文本。