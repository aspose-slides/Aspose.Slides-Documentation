---
title: ActiveX
type: docs
weight: 80
url: /zh/java/activex/
---


{{% alert color="primary" %}} 

ActiveX 控件在演示文稿中使用。Aspose.Slides for Java 允许你添加和管理 ActiveX 控件，但与普通演示文稿形状相比，它们的管理稍显复杂。我们在 Aspose.Slides 中实现了添加媒体播放器 Active 控件的支持。请注意，ActiveX 控件不是形状；它们不是演示文稿的 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IShapeCollection) 的一部分。它们实际上属于单独的 [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection)。在本主题中，我们将向您展示如何处理它们。 

{{% /alert %}} 

## **将媒体播放器 ActiveX 控件添加到幻灯片**
要添加 ActiveX 媒体播放器控件，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例，并生成空白演示文稿实例。
1. 访问 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 中的目标幻灯片。
1. 使用 [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection) 暴露的 [addControl](https://reference.aspose.com/slides/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) 方法添加媒体播放器 ActiveX 控件。
1. 访问媒体播放器 ActiveX 控件，并通过其属性设置视频路径。
1. 将演示文稿保存为 PPTX 文件。

以下示例代码基于上述步骤，演示如何将媒体播放器 ActiveX 控件添加到幻灯片：

```java
// 创建空白演示文稿实例
Presentation pres = new Presentation();
try {
    // 添加媒体播放器 ActiveX 控件
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // 访问媒体播放器 ActiveX 控件并设置视频路径
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // 保存演示文稿
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **修改 ActiveX 控件**
{{% alert color="primary" %}} 

Aspose.Slides for Java 7.1.0 及更新版本配备了管理 ActiveX 控件的组件。您可以访问演示文稿中已添加的 ActiveX 控件，并通过其属性进行修改或删除。

{{% /alert %}} 

要管理幻灯片上简单的 ActiveX 控件，如文本框和简单命令按钮，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例，并加载其中包含 ActiveX 控件的演示文稿。
1. 通过索引获取幻灯片引用。
1. 通过访问 [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection) 访问幻灯片中的 ActiveX 控件。
1. 使用 [IControl](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControl) 对象访问 TextBox1 ActiveX 控件。
1. 更改 TextBox1 ActiveX 控件的属性，包括文本、字体、字体高度和框架位置。
1. 访问第二个控件 CommandButton1。
1. 更改按钮标题、字体和位置。
1. 移动 ActiveX 控件框架的位置。
1. 将修改后的演示文稿写入 PPTX 文件。

以下示例代码基于上述步骤，演示如何管理简单的 ActiveX 控件：

```java
// 访问包含 ActiveX 控件的演示文稿
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // 访问演示文稿中的第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 更改 TextBox 文本
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "更改的文本";
        control.getProperties().set_Item("Value", newText);

        // 更改替代图像。PowerPoint 在激活 ActiveX 时会替换此图像，
        // 因此在某些情况下，保持图像不变是可以的。
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // 更改按钮标题
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "显示消息框";
        control.getProperties().set_Item("Caption", newCaption);
        // 更改替代图像
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // 向下移动 100 个点
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // 移除控件
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```