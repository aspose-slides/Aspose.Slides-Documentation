---
title: 在 PHP 中格式化 PowerPoint 文本
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/php-java/text-formatting/
keywords:
- 突出显示文本
- 正则表达式
- 对齐段落
- 文本样式
- 文本背景
- 文本透明度
- 字符间距
- 字体属性
- 字体系列
- 文本旋转
- 旋转角度
- 文本框
- 行距
- 自动适应属性
- 文本框锚点
- 文本制表符
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化和样式设置。自定义字体、颜色、对齐方式等。"
---

## **突出显示文本**
已向 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 类添加了方法 [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/highlighttext/)。

它允许使用文本示例为文本片段添加背景色进行高亮，类似于 PowerPoint 2019 中的文本高亮颜色工具。

下面的代码片段展示了如何使用此功能：
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// 突出显示所有单词 'important'

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// 突出显示所有单独的 'the' 出现

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
Aspose 提供了一个简单的、[免费在线 PowerPoint 编辑服务](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **使用正则表达式高亮文本**
已向 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 类添加了方法 [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/highlightregex/)。

它允许使用正则表达式为文本片段添加背景色进行高亮，类似于 PowerPoint 2019 中的文本高亮颜色工具。

下面的代码片段展示了如何使用此功能：
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);// 突出显示所有长度为10个字符或更长的单词

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **设置文本背景颜色**
Aspose.Slides 允许您为文本的背景指定首选颜色。

此 PHP 代码展示了如何为整段文本设置背景颜色：
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Black");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Red ");
    $portion3 = new Portion("Black");
    $portion3->getPortionFormat()->setFontBold(NullableBool::True);
    $para->getPortions()->add($portion1);
    $para->getPortions()->add($portion2);
    $para->getPortions()->add($portion3);
    $autoShape->getTextFrame()->getParagraphs()->add($para);
    $pres->save("text.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
  $presentation = new Presentation("text.pptx");
  try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->spliterator(), false)->map(( p) -> $p->getPortions())->forEach(( c) -> $c->forEach(( ic) -> $ic->getPortionFormat()->getHighlightColor()->setColor($Color.BLUE)));
    $presentation->save("text-red.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


此 PHP 代码展示了如何仅为文本的一部分设置背景颜色：
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Black");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Red ");
    $portion3 = new Portion("Black");
    $portion3->getPortionFormat()->setFontBold(NullableBool::True);
    $para->getPortions()->add($portion1);
    $para->getPortions()->add($portion2);
    $para->getPortions()->add($portion3);
    $autoShape->getTextFrame()->getParagraphs()->add($para);
    $pres->save("text.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
  $presentation = new Presentation("text.pptx");
  try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $redPortion = StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->spliterator(), false)->filter(( p) -> $p->getText()->contains("Red"))->findFirst();
    if ($redPortion->isPresent()) {
      $redPortion->get()->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->RED);
    }
    $presentation->save("text-red.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **对齐文本段落**
文本格式是创建任何文档或演示文稿时的关键要素。我们知道 Aspose.Slides for PHP via Java 支持向幻灯片添加文本，但在本主题中，我们将了解如何控制幻灯片中文本段落的对齐方式。请按照以下步骤使用 Aspose.Slides for PHP via Java 对齐文本段落：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 访问幻灯片中存在的占位符形状，并将其强制转换为 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
4. 从由 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 暴露的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 中获取需要对齐的段落 (Paragraph)。
5. 对段落进行对齐。段落可以对齐到右、左、居中和两端对齐。
6. 将修改后的演示文稿写入为 PPTX 文件。

以下给出上述步骤的实现示例。
```php
  # 实例化一个表示 PPTX 文件的 Presentation 对象
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 访问幻灯片中的第一个和第二个占位符并将其强制转换为 AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # 更改两个占位符中的文本
    $tf1->setText("Center Align by Aspose");
    $tf2->setText("Center Align by Aspose");
    # 获取占位符的第一个段落
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # 将文本段落对齐至居中
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Center);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Center);
    # 将演示文稿保存为 PPTX 文件
    $pres->save("Centeralign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **设置文本透明度**
本文演示如何使用 Aspose.Slides for PHP via Java 为任意文本形状设置透明度属性。要对文本设置透明度，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 获取幻灯片的引用。
3. 设置阴影颜色。
4. 将演示文稿保存为 PPTX 文件。

以下给出上述步骤的实现示例。
```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - transparency is: " . $shadowColor->getAlpha() / 255.0 * 100);
    # 将透明度设置为零百分比
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **设置文本字符间距**
Aspose.Slides 允许您为文本框中的字符设置间距。这样，您可以通过扩大或缩小字符之间的间距来调整行或块文本的视觉密度。

此 PHP 代码展示了如何为一行文本扩大间距，并为另一行文本缩小间距：
```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// 扩展

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// 压缩

  $presentation->save("out.pptx", SaveFormat::Pptx);
```


## **管理段落的字体属性**
演示文稿通常包含文本和图像。文本可以通过多种方式格式化，无论是为了突出特定章节和词语，还是符合企业样式。文本格式化帮助用户改变演示内容的外观与感受。本文展示如何使用 Aspose.Slides for PHP via Java 配置幻灯片上段落文本的字体属性。使用 Aspose.Slides for PHP via Java 管理段落的字体属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 访问幻灯片中的占位符形状，并将其强制转换为 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
1. 从由 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 暴露的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 中获取 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)。
1. 将段落两端对齐。
1. 访问段落的文本 Portion。
1. 使用 FontData 定义字体，并相应地设置该 Portion 的 Font。
   1. 将字体设为粗体。
   1. 将字体设为斜体。
1. 使用由 [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) 对象暴露的 [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) 设置字体颜色。
1. 将修改后的演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

以下给出上述步骤的实现示例。它采用一个未作任何装饰的演示文稿，并在其中一张幻灯片上格式化字体。
```php
  # 实例化一个表示 PPTX 文件的 Presentation 对象
  $pres = new Presentation("FontProperties.pptx");
  try {
    # 使用幻灯片位置访问幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 访问幻灯片中的第一个和第二个占位符并将其强制转换为 AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # 访问第一个段落
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # 访问第一个文本块
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # 定义新字体
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # 将新字体分配给文本块
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # 将字体设置为粗体
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # 将字体设置为斜体
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # 设置字体颜色
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # 将 PPTX 写入磁盘
    $pres->save("WelcomeFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **管理文本的字体系列**
Portion 用于在段落中保存具有相同格式的文本。本文展示如何使用 Aspose.Slides for PHP via Java 创建一个包含文本的文本框，并为其定义特定字体以及字体系列的其他属性。创建文本框并设置其中文本的字体属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加类型为 [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/#Rectangle) 的 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
4. 移除与该 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) 关联的填充样式。
5. 访问 AutoShape 的 TextFrame。
6. 向 TextFrame 添加一些文本。
7. 访问与 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) 关联的 Portion 对象。
8. 为该 [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) 定义要使用的字体。
9. 使用 Portion 对象暴露的相关属性设置粗体、斜体、下划线、颜色和高度等其他字体属性。
10. 将修改后的演示文稿保存为 PPTX 文件。

以下给出上述步骤的实现示例。
```php
  # 实例化 Presentation
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加矩形类型的 AutoShape
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # 移除与 AutoShape 关联的填充样式
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 访问与 AutoShape 关联的 TextFrame
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # 访问与 TextFrame 关联的 Portion
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # 为 Portion 设置字体
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # 将字体设置为粗体
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # 将字体设置为斜体
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # 将字体设置为下划线
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # 设置字体高度
    $port->getPortionFormat()->setFontHeight(25);
    # 设置字体颜色
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # 将 PPTX 写入磁盘
    $pres->save("SetTextFontProperties_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **设置文本的字体大小**
Aspose.Slides 允许您为段落中已有的文本以及以后可能添加到段落的文本选择首选的字体大小。

此 PHP 代码展示了如何为段落中的文本设置字体大小：
```php
  $presentation = new Presentation("example.pptx");
  try {
    # 获取第一个形状，例如。
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # 获取第一个段落，例如。
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # 将段落中所有文本块的默认字体大小设置为 20 磅。
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # 将段落中当前文本块的字体大小设置为 20 磅。
      foreach($paragraph->getPortions() as $portion) {
        $portion->getPortionFormat()->setFontHeight(20);
      }
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **设置文本旋转**
Aspose.Slides for PHP via Java 允许开发者旋转文本。文本可以设置为 [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Horizontal)、[Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Vertical)、[Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Vertical270)、[WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#WordArtVertical)、[EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical)、[MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#MongolianVertical) 或 [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#WordArtVerticalRightToLeft)。要旋转任意 TextFrame 的文本，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任意形状。
4. 访问该形状的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。
5. [旋转文本](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/)。
6. 将文件保存到磁盘。

```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加矩形类型的 AutoShape
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # 向矩形添加 TextFrame
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 访问文本框
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # 为文本框创建 Paragraph 对象
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 为段落创建 Portion 对象
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 保存演示文稿
    $pres->save("RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **为 TextFrame 设置自定义旋转角度**
Aspose.Slides for PHP via Java 现在支持为 TextFrame 设置自定义旋转角度。本主题通过示例演示如何在 Aspose.Slides 中设置 RotationAngle 属性。已向 [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/) 类添加了新方法 [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setrotationangle/) 和 [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/getrotationangle/)，用于为 TextFrame 设置自定义旋转角度。要设置 RotationAngle，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 在幻灯片上添加图表。
3. [设置旋转角度](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setrotationangle/)。
4. 将演示文稿写入 PPTX 文件。

下面的示例演示了如何设置 RotationAngle 属性。
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加矩形类型的 AutoShape
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # 向矩形添加 TextFrame
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 访问文本框
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # 为文本框创建 Paragraph 对象
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 为段落创建 Portion 对象
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Text rotation example.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 保存演示文稿
    $pres->save($resourcesOutputPath . "RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **段落的行距**
Aspose.Slides 在 [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) 下提供了 `SpaceAfter`、`SpaceBefore` 和 `SpaceWithin` 三个属性，用于管理段落的行距。这三个属性的使用方式如下：

* 要以百分比指定段落的行距，请使用正值。 
* 要以磅值指定段落的行距，请使用负值。

例如，您可以通过将 `SpaceBefore` 属性设为 -16 来为段落应用 16pt 的行距。

下面是为特定段落指定行距的步骤：

1. 加载包含带有文本的 AutoShape 的演示文稿。
2. 通过索引获取幻灯片的引用。
3. 访问 TextFrame。
4. 访问 Paragraph。
5. 设置 Paragraph 属性。
6. 保存演示文稿。

此 PHP 代码展示了如何为段落指定行距：
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation("Fonts.pptx");
  try {
    # 通过索引获取幻灯片的引用
    $sld = $pres->getSlides()->get_Item(0);
    # 访问 TextFrame
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # 访问段落
    $para = $tf1->getParagraphs()->get_Item(0);
    # 设置段落的属性
    $para->getParagraphFormat()->setSpaceWithin(80);
    $para->getParagraphFormat()->setSpaceBefore(40);
    $para->getParagraphFormat()->setSpaceAfter(40);
    # 保存演示文稿
    $pres->save("LineSpacing_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **设置 TextFrame 的 AutofitType 属性**
在本主题中，我们将探讨 TextFrame 的各种格式属性。本文介绍如何设置 TextFrame 的 AutofitType 属性、文本的锚点以及在演示文稿中旋转文本。Aspose.Slides for PHP via Java 允许开发者为任意 TextFrame 设置 AutofitType 属性。AutofitType 可以设为 [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Normal) 或 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Shape)。如果设为 [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Normal)，形状保持不变，文本会自动调整而不改变形状；如果设为 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Shape)，则会修改形状，使其仅容纳所需的文本。要设置 TextFrame 的 AutofitType 属性，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任意形状。
4. 访问该形状的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。
5. 为 TextFrame [设置自动适应类型](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setautofittype/)。
6. 将文件保存到磁盘。

```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加矩形类型的 AutoShape
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # 向矩形添加 TextFrame
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 访问文本框
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # 为文本框创建 Paragraph 对象
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 为段落创建 Portion 对象
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 保存演示文稿
    $pres->save($resourcesOutputPath . "formatText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **设置 TextFrame 的锚点**
Aspose.Slides for PHP via Java 允许开发者设置任意 TextFrame 的锚点。TextAnchorType 指定文本在形状中的放置位置。锚点类型可设为 [Top](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Top)、[Center](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Center)、[Bottom](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Bottom)、[Justified](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Justified) 或 [Distributed](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Distributed)。要为任意 TextFrame 设置锚点，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任意形状。
4. 访问该形状的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)。
5. 为 TextFrame [设置文本锚点类型](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setanchoringtype/)。
6. 将文件保存到磁盘。

```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加矩形类型的 AutoShape
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # 向矩形添加 TextFrame
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 访问文本框
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # 为文本框创建 Paragraph 对象
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 为段落创建 Portion 对象
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 保存演示文稿
    $pres->save("AnchorText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **演示文稿中的制表符和 EffectiveTabs**
所有文本制表位均以像素为单位给出。

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**图：2 个显式制表符和 2 个默认制表符**|

- EffectiveTabs.ExplicitTabCount（在本例中为 2）属性等于 Tabs.Count。
- EffectiveTabs 集合包含所有制表位（来自 Tabs 集合以及默认制表位）。
- EffectiveTabs.ExplicitTabCount（在本例中为 2）属性等于 Tabs.Count。
- EffectiveTabs.DefaultTabSize（294）属性显示默认制表位之间的距离（本例中的第 3 和第 4 个制表位）。
- 使用 EffectiveTabs.GetTabByIndex(index) 时，index = 0 将返回第一个显式制表位（Position = 731），index = 1 返回第二个显式制表位（Position = 1241）。如果尝试使用 index = 2，则返回第一个默认制表位（Position = 1470），依此类推。
- EffectiveTabs.GetTabAfterPosition(pos) 用于获取某段文本之后的下一个制表位。例如您有文本："Hello World!"。要渲染该文本，需要知道从何处开始绘制 "world!"。首先，应计算 "Hello" 的像素长度，然后将该值传入 GetTabAfterPosition，即可获得绘制 "world!" 的下一个制表位位置。

## **提取全大写效果的文本**
在 PowerPoint 中，应用 **All Caps** 字体效果会使文本在幻灯片上显示为全大写，即使原始输入是小写。当使用 Aspose.Slides 检索此类文本片段时，库会返回原始输入的文本。为处理此情况，请检查 [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/)——如果其指示为 `All`，则将返回的字符串转换为大写，以便输出与幻灯片上用户看到的效果一致。

假设我们在 sample2.pptx 文件的第一张幻灯片上有如下文本框。

![The All Caps effect](all_caps_effect.png)

下面的代码示例展示了如何提取带有 **All Caps** 效果的文本：
```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $textPortion = $paragraph->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = $textPortion->getText()->toUpperCase();
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```


输出：
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **常见问题**

**如何修改幻灯片上表格中的文本？**

要修改幻灯片上表格中的文本，需要使用 [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) 类。您可以遍历表格中的所有单元格，通过访问每个单元格的 `TextFrame` 和 `ParagraphFormat` 属性来更改其中的文本。

**如何在 PowerPoint 幻灯片中的文本上应用渐变色？**

要为文本应用渐变色，请在 [BasePortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/) 中使用 `getFillFormat` 方法。将 `FillFormat` 设置为 `Gradient`，并可定义渐变的起止颜色以及方向、透明度等其他属性，从而在文本上创建渐变效果。