---
title: 使用 Java 管理演示文稿中的 ActiveX 控件
linktitle: ActiveX
type: docs
weight: 80
url: /zh/java/activex/
keywords:
- ActiveX
- ActiveX 控件
- 管理 ActiveX
- 添加 ActiveX
- 修改 ActiveX
- 媒体播放器
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 如何利用 ActiveX 自动化和增强 PowerPoint 演示文稿，为开发者提供对幻灯片的强大控制。"
---

{{% alert color="primary" %}} 

ActiveX 控件在演示文稿中使用。Aspose.Slides for Java 允许您添加和管理 ActiveX 控件，但与普通演示形状相比，它们的管理稍显复杂。我们实现了在 Aspose.Slides 中添加 Media Player Active 控件的支持。请注意，ActiveX 控件不是形状；它们不属于演示文稿的 [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IShapeCollection)。它们属于单独的 [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection)。在本主题中，我们将向您展示如何使用它们。 

{{% /alert %}} 

## **在幻灯片中添加 Media Player ActiveX 控件**
要添加 ActiveX Media Player 控件，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例并生成一个空的演示文稿实例。  
1. 在 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 中访问目标幻灯片。  
1. 使用 [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection) 中公开的 [addControl](https://reference.aspose.com/slides/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) 方法添加 Media Player ActiveX 控件。  
1. 访问 Media Player ActiveX 控件并使用其属性设置视频路径。  
1. 将演示文稿保存为 PPTX 文件。  

基于上述步骤的示例代码展示了如何将 Media Player ActiveX 控件添加到幻灯片中：
```java
// 创建空的演示文稿实例
Presentation pres = new Presentation();
try {
    // 添加 Media Player ActiveX 控件
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // 访问 Media Player ActiveX 控件并设置视频路径
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // 保存演示文稿
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **修改 ActiveX 控件**
{{% alert color="primary" %}} 

Aspose.Slides for Java 7.1.0 及更高版本配备了用于管理 ActiveX 控件的组件。您可以访问演示文稿中已添加的 ActiveX 控件并通过其属性进行修改或删除。 

{{% /alert %}} 

要在幻灯片上管理诸如文本框和简单命令按钮之类的基本 ActiveX 控件，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例并加载包含 ActiveX 控件的演示文稿。  
1. 通过索引获取幻灯片引用。  
1. 通过访问 [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControlCollection) 来获取幻灯片中的 ActiveX 控件。  
1. 使用 [IControl](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IControl) 对象访问 TextBox1 ActiveX 控件。  
1. 更改 TextBox1 ActiveX 控件的属性，包括文本、字体、字体高度和框架位置。  
1. 访问第二个名为 CommandButton1 的控件。  
1. 更改按钮的标题、字体和位置。  
1. 移动 ActiveX 控件框架的位置。  
1. 将修改后的演示文稿写入 PPTX 文件。  

基于上述步骤的示例代码展示了如何管理一个简单的 ActiveX 控件： 
```java
// 访问包含 ActiveX 控件的演示文稿
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // 访问演示文稿中的第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 更改 TextBox 文本
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // 更改替代图片。PowerPoint 在激活 ActiveX 时会替换此图片，
        // 因此有时可以保持图片不变。
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
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // 更改替代图片
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

            // 向下移动 100 点
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // 删除控件
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```


## **FAQ**

**在读取并重新保存时，如果 Java 运行时无法执行 ActiveX 控件，Aspose.Slides 是否会保留它们？**

是的。Aspose.Slides 将它们视为演示文稿的一部分，能够读取/修改其属性和框架；不需要执行控件本身即可保留它们。

**ActiveX 控件与演示文稿中的 OLE 对象有何不同？**

ActiveX 控件是交互式受管理的控件（按钮、文本框、媒体播放器），而 [OLE](/slides/zh/java/manage-ole/) 指的是嵌入的应用程序对象（例如 Excel 工作表）。它们的存储和处理方式不同，属性模型也不同。

**如果文件已由 Aspose.Slides 修改，ActiveX 事件和 VBA 宏是否仍然有效？**

Aspose.Slides 保留现有的标记和元数据；然而，只有在 Windows 上的 PowerPoint 且安全设置允许时，事件和宏才会运行。该库本身不会执行 VBA。