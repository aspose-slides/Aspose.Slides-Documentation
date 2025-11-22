---
title: ActiveX
type: docs
weight: 80
url: /zh/nodejs-java/activex/
---

{{% alert color="primary" %}} 

ActiveX 控件在演示文稿中使用。Aspose.Slides for Node.js via Java 允许您添加和管理 ActiveX 控件，但与普通演示形状相比，它们的管理稍显复杂。我们在 Aspose.Slides 中实现了对 Media Player Active 控件的支持。请注意，ActiveX 控件不是形状；它们不属于演示文稿的 [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/)。它们属于单独的 [ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/)。在本主题中，我们将向您展示如何使用它们。

{{% /alert %}} 

## **将 Media Player ActiveX 控件添加到幻灯片**
要添加 ActiveX Media Player 控件，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例并生成一个空的演示文稿实例。
2. 在 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 中访问目标幻灯片。
3. 使用由 [ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/) 暴露的 [addControl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) 方法添加 Media Player ActiveX 控件。
4. 访问 Media Player ActiveX 控件并使用其属性设置视频路径。
5. 将演示文稿保存为 PPTX 文件。

下面的示例代码基于上述步骤，展示了如何将 Media Player ActiveX 控件添加到幻灯片：
```javascript
// 创建空的演示文稿实例
var pres = new aspose.slides.Presentation();
try {
    // 添加 Media Player ActiveX 控件
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // 访问 Media Player ActiveX 控件并设置视频路径
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // 保存演示文稿
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **修改 ActiveX 控件**

要在幻灯片上管理像文本框和简单命令按钮这样的 ActiveX 控件，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例并加载包含 ActiveX 控件的演示文稿。
2. 通过索引获取幻灯片引用。
3. 通过访问 [ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/) 来访问幻灯片中的 ActiveX 控件。
4. 使用 [Control](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/) 对象访问 TextBox1 ActiveX 控件。
5. 更改 TextBox1 ActiveX 控件的属性，包括文本、字体、字号和框架位置。
6. 访问第二个名为 CommandButton1 的访问控件。
7. 更改按钮的标题、字体和位置。
8. 调整 ActiveX 控件框架的位置。
9. 将修改后的演示文稿写入 PPTX 文件。

下面的示例代码基于上述步骤，展示了如何管理一个简单的 ActiveX 控件：
```javascript
const imageio = java.import("javax.imageio.ImageIO");
// 访问带有 ActiveX 控件的演示文稿
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // 访问演示文稿中的第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 更改 TextBox 文本
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // 更改替代图像。PowerPoint 将在 ActiveX 激活期间替换此图像，
        // 因此有时可以保持图像不变。
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // 更改按钮标题
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // 更改替代
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // 向下移动 100 点
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // 删除控件
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**在 Python 运行时无法执行时，Aspose.Slides 在读取并重新保存时是否会保留 ActiveX 控件？**

是的。Aspose.Slides 将它们视为演示文稿的一部分，能够读取/修改其属性和框架；无需执行控件本身即可保留它们。

**ActiveX 控件与演示文稿中的 OLE 对象有何不同？**

ActiveX 控件是交互式受管理的控件（按钮、文本框、媒体播放器），而 [OLE](/slides/zh/nodejs-java/manage-ole/) 指的是嵌入的应用程序对象（例如 Excel 工作表）。它们的存储和处理方式不同，属性模型也不同。

**如果文件已被 Aspose.Slides 修改，ActiveX 事件和 VBA 宏是否仍然可用？**

Aspose.Slides 保留现有的标记和元数据；然而，事件和宏仅在 Windows 上的 PowerPoint 中且安全设置允许时才会运行。该库本身不执行 VBA。