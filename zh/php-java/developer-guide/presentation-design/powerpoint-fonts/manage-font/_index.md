---
title: 管理字体 - PowerPoint Java API
linktitle: 管理字体
type: docs
weight: 10
url: /php-java/manage-fonts/
description: 演示文稿通常包含文本和图像。本文展示如何使用 PowerPoint Java API 配置幻灯片上文本段落的字体属性。
---

## **管理字体相关属性**
{{% alert color="primary" %}} 

演示文稿通常包含文本和图像。文本可以通过多种方式格式化，以突出特定部分和单词或符合企业风格。文本格式化帮助用户改变演示内容的外观和感觉。本文展示如何使用通过 Java 的 Aspose.Slides for PHP 配置幻灯片上文本段落的字体属性。

{{% /alert %}} 

使用通过 Java 的 Aspose.Slides for PHP 管理段落的字体属性：

1. 创建一个表示 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 使用幻灯片的索引获取幻灯片的引用。
1. 访问幻灯片中的 [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Placeholder) 形状并将其强制转换为 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape)。
1. 从 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape) 中暴露的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame) 获取 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Paragraph)。
1. 对段落进行对齐。
1. 访问 [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Paragraph) 的文本 [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion)。
1. 使用 [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/classes/FontData) 定义字体，并相应地设置文本 [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) 的 **Font**。
   1. 设置字体为粗体。
   1. 设置字体为斜体。
1. 使用 [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) 对象暴露的 [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/classes/FillFormat) 设置字体颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

上述步骤的实现如下。它获取一个未修饰的演示文稿并格式化其中一张幻灯片的字体。随后的截图显示输入文件以及代码片段如何更改它。代码更改了字体、颜色和字体样式。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**图：输入文件中的文本**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**图：更新格式的相同文本**|

```php
  # 实例化一个表示 PPTX 文件的 Presentation 对象
  $pres = new Presentation("FontProperties.pptx");
  try {
    # 通过索引访问幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 访问幻灯片中的第一个和第二个占位符，并将其强制转换为 AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # 访问第一个 Paragraph
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # 对段落进行对齐
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # 访问第一个 portion
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # 定义新字体
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # 将新字体分配给 portion
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
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # 将 PPTX 保存到磁盘
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **设置文本字体属性**
{{% alert color="primary" %}} 

如 **管理字体相关属性** 中所述， [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) 用于在段落中包含具有相似格式样式的文本。本文展示如何使用通过 Java 的 Aspose.Slides for PHP 创建一个文本框及其中文本，并定义特定字体以及字体系列的各种其他属性。

{{% /alert %}} 

要创建文本框并设置其中文本的字体属性：

1. 创建一个表示 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 向幻灯片添加一个类型为 **Rectangle** 的 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape)。
1. 移除与 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape) 相关的填充样式。
1. 访问与 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/classes/AutoShape) 关联的 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame)。
1. 向 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame) 添加一些文本。
1. 访问与 [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/classes/TextFrame) 关联的 [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) 对象。
1. 定义要用于 [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) 的字体。
1. 使用 [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion) 对象暴露的相关属性设置其他字体属性，如粗体、斜体、下划线、颜色和高度。
1. 将修改后的演示文稿写入为 PPTX 文件。

上述步骤的实现如下。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**图：通过 Java 的 Aspose.Slides for PHP 设置某些字体属性的文本**|

```php
  # 实例化一个表示 PPTX 文件的 Presentation 对象
  $pres = new Presentation();
  try {
    # 获取第一个幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加一个类型为 Rectangle 的 AutoShape
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # 移除与 AutoShape 相关的任何填充样式
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 访问与 AutoShape 关联的 TextFrame
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # 访问与 TextFrame 关联的 Portion
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # 设置 Portion 的字体
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # 设置字体的 Bold 属性
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # 设置字体的 Italic 属性
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # 设置字体的 Underline 属性
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # 设置字体的高度
    $port->getPortionFormat()->setFontHeight(25);
    # 设置字体的颜色
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # 将演示文稿保存到磁盘
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```