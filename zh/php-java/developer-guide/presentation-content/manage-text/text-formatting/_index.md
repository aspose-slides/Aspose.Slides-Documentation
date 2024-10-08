---
title: 文本格式化
type: docs
weight: 50
url: /zh/php-java/text-formatting/
---

## **高亮文本**
方法 [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) 已被添加到 [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) 接口和 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) 类中。

它允许使用文本示例以背景颜色高亮显示文本部分，类似于 PowerPoint 2019 中的文本高亮工具。

下面的代码片段展示了如何使用这一功能：

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);//高亮显示所有单词 'important'

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);//高亮显示所有单独的 'the' 发生情况

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Aspose 提供了一个简单的 [免费在线 PowerPoint 编辑服务](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **使用正则表达式高亮文本**

方法 [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) 已被添加到 [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) 接口和 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) 类中。

它允许使用正则表达式以背景颜色高亮显示文本部分，类似于 PowerPoint 2019 中的文本高亮工具。

下面的代码片段展示了如何使用这一功能：

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);//高亮显示所有长度为 10 个符号或更长的单词

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **设置文本背景颜色**

Aspose.Slides 允许您为文本的背景指定首选颜色。

下面的 PHP 代码展示了如何为整个文本设置背景颜色：

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("黑色");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" 红色 ");
    $portion3 = new Portion("黑色");
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
    $portion1 = new Portion("黑色");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" 红色 ");
    $portion3 = new Portion("黑色");
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
    $redPortion = StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->spliterator(), false)->filter(( p) -> $p->getText()->contains("红色"))->findFirst();
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

文本格式化是在创建任何类型的文档或演示文稿时的关键元素之一。我们知道 Aspose.Slides for PHP via Java 支持向幻灯片添加文本，但在本主题中，我们将看到如何控制幻灯片中文本段落的对齐。请按照以下步骤使用 Aspose.Slides for PHP via Java 对齐文本段落：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 访问幻灯片中存在的占位符形状并将其类型转换为 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape)。
4. 从 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) 所暴露的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#getTextFrame--) 中获取需要对齐的段落。
5. 对齐段落。段落可以对齐为右、左、居中和对齐。
6. 将修改后的演示文稿写入 PPTX 文件。

上述步骤的实现如下：

```php
  # 实例化一个表示 PPTX 文件的 Presentation 对象
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 访问幻灯片中的第一个和第二个占位符并将其转换为 AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # 更改两个占位符中的文本
    $tf1->setText("居中对齐 by Aspose");
    $tf2->setText("居中对齐 by Aspose");
    # 获取占位符的第一个段落
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # 将文本段落对齐到中心
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Center);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Center);
    # 将演示文稿写入 PPTX 文件
    $pres->save("Centeralign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **设置文本透明度**
本文演示了如何使用 Aspose.Slides for PHP via Java 设置任何文本形状的透明度属性。为了设置文本的透明度，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 获取幻灯片的引用。
3. 设置阴影颜色。
4. 将演示文稿写入 PPTX 文件。

上述步骤的实现如下。

```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - 透明度为: " . $shadowColor->getAlpha() / 255.0 * 100);
    # 设置透明度为零
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **设置文本字符间距**

Aspose.Slides 允许您设置文本框中字母之间的间距。通过这种方式，您可以通过扩展或收缩字符之间的间距来调整文本行或文本块的视觉密度。

以下 PHP 代码展示了如何扩展一行文本的间距并压缩另一行的间距：

```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);//扩展

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);//压缩

  $presentation->save("out.pptx", SaveFormat::Pptx);
```

## **管理段落的字体属性**

演示文稿通常包含文本和图像。文本可以以各种方式格式化，无论是突出特定的部分和单词，还是符合企业样式。文本格式化帮助用户改变演示内容的外观和感觉。本文展示了如何使用 Aspose.Slides for PHP via Java 配置幻灯片上文本段落的字体属性。要管理使用 Aspose.Slides for PHP via Java 的段落字体属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 访问幻灯片中的占位符形状并将其转换为 [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)。
4. 从 [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) 所暴露的 [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) 中获取 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame)。
5. 使段落两端对齐。
6. 访问段落的文本部分。
7. 使用 FontData 定义字体并相应地设置文本部分的字体。
   1. 设置字体为粗体。
   2. 设置字体为斜体。
8. 使用 [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#getFillFormat--) 设置字体颜色，该方法由 [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion) 对象暴露。
9. 将修改后的演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

上述步骤的实现如下。它将一个未装饰的演示文稿进行格式化，并在其中一个幻灯片上格式化字体。

```php
  # 实例化一个表示 PPTX 文件的 Presentation 对象
  $pres = new Presentation("FontProperties.pptx");
  try {
    # 使用幻灯片位置访问幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 访问幻灯片中的第一个和第二个占位符并将其转换为 AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # 访问第一个段落
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # 访问第一个部分
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # 定义新字体
    $fd1 = new FontData("大象");
    $fd2 = new FontData("Castellar");
    # 分配新字体给部分
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # 设置字体为粗体
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # 设置字体为斜体
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
部分用于在段落中保持具有相似格式样式的文本。本文展示了如何使用 Aspose.Slides for PHP via Java 创建一个带有文本的文本框，然后定义特定字体及其余的字体系列属性。要创建文本框并设置其中文本的字体属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 向幻灯片添加 [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) 类型的 [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle)。
4. 移除与 [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) 关联的填充样式。
5. 访问 AutoShape 的 TextFrame。
6. 向 TextFrame 添加一些文本。
7. 访问与 [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) 关联的 Portion 对象。
8. 定义要用于 [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion) 的字体。
9. 使用相关属性设置其他字体属性，如粗体、斜体、下划线、颜色和高度。
10. 将修改后的演示文稿写入 PPTX 文件。

上述步骤的实现如下。

```php
  # 实例化 Presentation
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加一个矩形类型的 AutoShape
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # 删除与 AutoShape 关联的任何填充样式
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 访问与 AutoShape 关联的 TextFrame
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose 文本框");
    # 访问与 TextFrame 关联的 Portion
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # 设置 Portion 的字体
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # 设置字体的粗体属性
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # 设置字体的斜体属性
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # 设置字体的下划线属性
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # 设置字体的高度
    $port->getPortionFormat()->setFontHeight(25);
    # 设置字体的颜色
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

Aspose.Slides 允许您为段落中的现有文本和将来可能添加到段落中的其他文本选择首选字体大小。

以下 PHP 代码展示了如何设置段落中包含文本的字体大小：

```php
  $presentation = new Presentation("example.pptx");
  try {
    # 获取第一个形状，例如。
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # 获取第一个段落，例如。
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # 将所有文本部分的默认字体大小设置为 20 磅。
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # 将当前段落中的文本部分的字体大小设置为 20 磅。
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

Aspose.Slides for PHP via Java 允许开发人员旋转文本。文本可以被设置为水平 [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Horizontal)、垂直 [Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical)、270度垂直 [Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical270)、艺术字垂直 [WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVertical)、东亚垂直 [EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#EastAsianVertical)、蒙古文垂直 [MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#MongolianVertical) 或艺术字从右到左垂直 [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft)。要旋转任何 TextFrame 的文本，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任何形状。
4. 访问 [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)。
5. [旋转文本](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setTextVerticalType-byte-)。
6. 将文件保存到磁盘。

```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加一个矩形类型的 AutoShape
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # 为矩形添加 TextFrame
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 访问文本框
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # 创建文本框的段落对象
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 为段落创建 Portion 对象
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("一只敏捷的棕色狐狸跳过懒狗。一只敏捷的棕色狐狸跳过懒狗。");
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
Aspose.Slides for PHP via Java 现已支持为文本框设置自定义旋转角度。在本主题中，我们将通过示例了解如何在 Aspose.Slides 中设置 RotationAngle 属性。新的方法 [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-) 和 [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#getRotationAngle--) 已被添加到 [IChartTextBlockFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IChartTextBlockFormat) 和 [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) 接口中，可以设置文本框的自定义旋转角度。要设置 RotationAngle，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 在幻灯片上添加一个图表。
3. [设置 RotationAngle 属性](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-)。
4. 将演示文稿写入 PPTX 文件。

在下面给出的示例中，我们设置 RotationAngle 属性。

```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加一个矩形类型的 AutoShape
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # 为矩形添加 TextFrame
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 访问文本框
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # 创建文本框的段落对象
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 为段落创建 Portion 对象
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("文本旋转示例。");
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

## **段落的行间距**
Aspose.Slides 提供了 [`ParagraphFormat`](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraphFormat) 下的属性——`SpaceAfter`、`SpaceBefore` 和 `SpaceWithin`——允许您管理段落的行间距。这三个属性的使用方法如下：

* 要以百分比指定段落的行间距，请使用正值。
* 要以点数指定段落的行间距，请使用负值。

例如，您可以通过将 `SpaceBefore` 属性设置为 -16 来对段落应用 16pt 的行间距。

这是如何为特定段落指定行间距：

1. 加载包含一些文本的 AutoShape 的演示文稿。
2. 通过其索引获取幻灯片的引用。
3. 访问 TextFrame。
4. 访问段落。
5. 设置段落属性。
6. 保存演示文稿。

以下 PHP 代码展示了如何为段落指定行间距：

```php
  # 创建 Presentation 类的实例
  $pres = new Presentation("Fonts.pptx");
  try {
    # 通过其索引获取幻灯片的引用
    $sld = $pres->getSlides()->get_Item(0);
    # 访问 TextFrame
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # 访问段落
    $para = $tf1->getParagraphs()->get_Item(0);
    # 设置段落属性
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
在本主题中，我们将探讨文本框的不同格式化属性。本文涵盖了如何设置文本框的 AutofitType 属性、文本的锚定和旋转演示文稿中的文本。Aspose.Slides for PHP via Java 允许开发人员设置任何文本框的 AutofitType 属性。AutofitType 可以设置为 [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) 或 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape)。如果设置为 [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal)，则形状将保持不变，而文本将被调整而不会导致形状本身发生变化；如果 AutofitType 设置为 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape)，则形状将被修改，以确保只包含所需的文本。要设置文本框的 AutofitType 属性，请遵循以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任何形状。
4. 访问 [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)。
5. [设置 TextFrame 的 AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAutofitType-byte-)。
6. 将文件保存到磁盘。

```php
  # 创建一个 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加一个矩形类型的 AutoShape
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # 为矩形添加 TextFrame
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 访问文本框
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # 创建文本框的段落对象
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 为段落创建 Portion 对象
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("一只敏捷的棕色狐狸跳过懒狗。一只敏捷的棕色狐狸跳过懒狗。");
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

## **设置 TextFrame 的锚定**
Aspose.Slides for PHP via Java 允许开发人员设置任何 TextFrame 的锚定。TextAnchorType 指定文本在形状中的放置位置。AnchorType 可以设置为 [Top](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Top)、[Center](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Center)、[Bottom](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Bottom)、[Justified](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Justified) 或 [Distributed](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Distributed)。要设置任何 TextFrame 的锚定，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任何形状。
4. 访问 [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)。
5. [设置 TextFrame 的 TextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAnchoringType-byte-)。
6. 将文件保存到磁盘。

```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加一个矩形类型的 AutoShape
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # 为矩形添加 TextFrame
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 访问文本框
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # 创建文本框的段落对象
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 为段落创建 Portion 对象
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("一只敏捷的棕色狐狸跳过懒狗。一只敏捷的棕色狐狸跳过懒狗。");
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

## **演示文稿中的制表符和有效制表符**
所有文本制表符的给定单位为像素。

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**图示：2 个显式制表符和 2 个默认制表符**|
- EffectiveTabs.ExplicitTabCount (在我们的例子中为 2) 属性等于 Tabs.Count。
- EffectiveTabs 集合包括所有制表符（来自 Tabs 集合和默认制表符）。
- EffectiveTabs.ExplicitTabCount (在我们的例子中为 2) 属性等于 Tabs.Count。
- EffectiveTabs.DefaultTabSize (294) 属性显示默认制表符之间的距离（在我们的示例中为 3 和 4）。
- EffectiveTabs.GetTabByIndex(index) 的索引 = 0 将返回第一个显式制表符（位置 = 731），索引 = 1 - 第二个制表符（位置 = 1241）。如果您尝试使用索引 = 2 获取下一个制表符，它将返回第一个默认制表符（位置 = 1470）等等。
- EffectiveTabs.GetTabAfterPosition(pos) 用于获取某些文本之后的下一个制表符。例如，如果您有文本：“Hello World！”。要呈现这样的文本，您需要知道在哪里开始绘制“world！”首先，您需要计算“Hello”在像素中的长度，并使用这个值调用 GetTabAfterPosition。您将获得下一个制表符的位置以绘制“world！”。
