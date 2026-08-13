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
description: "了解 Aspose.Slides for Java 如何利用 ActiveX 自动化并增强 PowerPoint 演示文稿，为开发人员提供对幻灯片的强大控制。"
---
## **简介**

ActiveX 控件在演示文稿中使用。Aspose.Slides for Java 允许您添加和管理 ActiveX 控件，但与普通演示文稿形状相比，它们的管理更为棘手。我们在 Aspose.Slides 中实现了对添加媒体播放器 Active 控件的支持。请注意，ActiveX 控件不是形状；它们不属于演示文稿的[IShapeCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapecollection/)。它们属于单独的[IControlCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icontrolcollection/)。在本主题中，我们将向您展示如何使用它们。

## **在幻灯片中添加媒体播放器 ActiveX 控件**
要添加 ActiveX 媒体播放器控件，请执行以下操作：

1. 创建[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation)类的实例，并生成一个空的演示文稿实例。
1. 在[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation)中访问目标幻灯片。
1. 使用[IControlCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icontrolcollection/)提供的[addControl](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-)方法添加媒体播放器 ActiveX 控件。
1. 访问媒体播放器 ActiveX 控件，并通过其属性设置视频路径。
1. 将演示文稿保存为 PPTX 文件。

下面的示例代码基于上述步骤，演示了如何在幻灯片中添加媒体播放器 ActiveX 控件：

```java
import com.aspose.slides.*;

// 创建空的演示文稿实例
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
{{% alert color="info" %}} 

Aspose.Slides for Java 7.1.0 及更高版本配备了管理 ActiveX 控件的组件。您可以访问演示文稿中已添加的 ActiveX 控件，并通过其属性进行修改或删除。

{{% /alert %}} 

要在幻灯片上管理诸如文本框和简单命令按钮之类的简单 ActiveX 控件，请执行以下操作：

1. 创建[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation)类的实例，并加载其中包含 ActiveX 控件的演示文稿。
1. 通过索引获取幻灯片引用。
1. 通过访问[IControlCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icontrolcollection/)来获取幻灯片中的 ActiveX 控件。
1. 使用[IControl](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icontrol/)对象访问 TextBox1 ActiveX 控件。
1. 更改 TextBox1 ActiveX 控件的属性，包括文本、字体、字体高度和框架位置。
1. 访问名为 CommandButton1 的第二个控件。
1. 更改按钮的标题、字体和位置。
1. 移动 ActiveX 控件框架的位置。
1. 将修改后的演示文稿写入 PPTX 文件。

下面的示例代码基于上述步骤，演示了如何管理简单的 ActiveX 控件：

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// 访问带有 ActiveX 控件的演示文稿
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // 访问演示文稿中的第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 更改 TextBox 文本
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // 更改替代图像。PowerPoint 将在 ActiveX 激活期间替换此图像，
        // 因此有时可以保持图像不变。
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

## **常见问题**

### Aspose.Slides 在读取和重新保存时，如果在 Java 运行时无法执行，是否会保留 ActiveX 控件？

是的。Aspose.Slides 将它们视为演示文稿的一部分，能够读取/修改它们的属性和框架；不需要执行控件本身即可保留它们。

### ActiveX 控件与演示文稿中的 OLE 对象有何不同？

ActiveX 控件是交互式受管理的控件（按钮、文本框、媒体播放器），而[OLE](/slides/zh/java/manage-ole/) 则指嵌入的应用程序对象（例如 Excel 工作表）。它们的存储和处理方式不同，并拥有不同的属性模型。

### 如果文件已被 Aspose.Slides 修改，ActiveX 事件和 VBA 宏是否仍能工作？

Aspose.Slides 会保留现有的标记和元数据；但事件和宏仅在 Windows 上的 PowerPoint 中且安全设置允许时才会运行。该库不会执行 VBA。