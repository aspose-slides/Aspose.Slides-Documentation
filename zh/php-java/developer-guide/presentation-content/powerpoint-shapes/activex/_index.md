---
title: 使用 PHP 在演示文稿中管理 ActiveX 控件
linktitle: ActiveX
type: docs
weight: 80
url: /zh/php-java/activex/
keywords:
- ActiveX
- ActiveX 控件
- 管理 ActiveX
- 添加 ActiveX
- 修改 ActiveX
- 媒体播放器
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP via Java 如何利用 ActiveX 自动化并增强 PowerPoint 演示文稿，为开发者提供对幻灯片的强大控制。"
---

{{% alert color="primary" %}} 
ActiveX 控件在演示文稿中使用。Aspose.Slides for PHP via Java 允许您添加和管理 ActiveX 控件，但与普通演示形状相比，它们的管理稍微更复杂。我们在 Aspose.Slides 中实现了添加 Media Player Active 控件的支持。请注意，ActiveX 控件不是形状；它们不属于演示文稿的 [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/)。它们属于单独的 [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/)。在本主题中，我们将向您展示如何使用它们。
{{% /alert %}} 

## **向幻灯片添加 Media Player ActiveX 控件**
要添加 ActiveX Media Player 控件，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例，并生成一个空白演示文稿实例。
2. 在 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 中访问目标幻灯片。
3. 使用 [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/) 提供的 [addControl](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/addcontrol/) 方法添加 Media Player ActiveX 控件。
4. 访问 Media Player ActiveX 控件，并使用其属性设置视频路径。
5. 将演示文稿保存为 PPTX 文件。

以下示例代码基于上述步骤，演示如何向幻灯片添加 Media Player ActiveX 控件：
```php
  # 创建空的演示文稿实例
  $pres = new Presentation();
  try {
    # 添加 Media Player ActiveX 控件
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # 访问 Media Player ActiveX 控件并设置视频路径
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # 保存演示文稿
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **修改 ActiveX 控件**
{{% alert color="primary" %}} 
Aspose.Slides for PHP via Java 7.1.0 及更高版本配备了管理 ActiveX 控件的组件。您可以访问演示文稿中已添加的 ActiveX 控件，并通过其属性对其进行修改或删除。
{{% /alert %}} 

要在幻灯片上管理诸如文本框和简单命令按钮的简单 ActiveX 控件，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例，并加载其中含有 ActiveX 控件的演示文稿。
2. 按索引获取幻灯片引用。
3. 通过访问 [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/) 来获取幻灯片中的 ActiveX 控件。
4. 使用 [Control](https://reference.aspose.com/slides/php-java/aspose.slides/control/) 对象访问 TextBox1 ActiveX 控件。
5. 更改 TextBox1 ActiveX 控件的属性，包括文本、字体、字体高度和框架位置。
6. 访问名为 CommandButton1 的第二个控件。
7. 更改按钮的标题、字体和位置。
8. 移动 ActiveX 控件框架的位置。
9. 将修改后的演示文稿写入 PPTX 文件。

以下示例代码基于上述步骤，演示如何管理简单的 ActiveX 控件：
```php
  # 访问包含 ActiveX 控件的演示文稿
  $pres = new Presentation("ActiveX.pptm");
  try {
    # 访问演示文稿中的第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 更改 TextBox 文本
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # 更改占位图像。PowerPoint 将在 ActiveX 激活期间替换此图像，
      # 因此有时保持图像不变也是可以的。
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->window);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $graphics->drawString($newText, 10, 20);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # 更改按钮标题
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # 更改占位图像
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->control);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $metrics = $graphics->getFontMetrics($font);
      $graphics->drawString($newCaption, $image->getWidth() - $metrics->stringWidth($newCaption) / 2, 20);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # 向下移动 100 点
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # 移除控件
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**Aspose.Slides 在读取并重新保存时是否会保留无法在 Java 运行时执行的 ActiveX 控件？**  
是的。Aspose.Slides 将它们视为演示文稿的一部分，能够读取/修改其属性和框架；不需要执行控件本身即可保留它们。

**ActiveX 控件与演示文稿中的 OLE 对象有何区别？**  
ActiveX 控件是交互式的受管理控件（按钮、文本框、媒体播放器），而 [OLE](/slides/zh/php-java/manage-ole/) 指的是嵌入的应用程序对象（例如 Excel 工作表）。它们的存储和处理方式不同，属性模型也不同。

**如果文件已被 Aspose.Slides 修改，ActiveX 事件和 VBA 宏是否仍然有效？**  
Aspose.Slides 会保留现有的标记和元数据；不过，事件和宏只能在 Windows 上的 PowerPoint 中（且安全设置允许时）运行。该库不会执行 VBA。