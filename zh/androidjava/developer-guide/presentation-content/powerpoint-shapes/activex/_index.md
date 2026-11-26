---
title: 在 Android 上管理演示文稿中的 ActiveX 控件
linktitle: ActiveX
type: docs
weight: 80
url: /zh/androidjava/activex/
keywords:
- ActiveX
- ActiveX 控件
- 管理 ActiveX
- 添加 ActiveX
- 修改 ActiveX
- 媒体播放器
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "编辑 ActiveX 文本框和按钮，更新控件预览，并在 PowerPoint 演示文稿中使用 Aspose.Slides for Android via Java 重用 Windows Media Player 控件。"
---
## **介绍**

ActiveX 控件为 PowerPoint 幻灯片提供交互元素，例如文本框、命令按钮和媒体播放器。Aspose.Slides for Android via Java 通过 [IBaseSlide.getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getControls--) 公开幻灯片的控件。使用此集合可以编辑控件、在幻灯片上移动控件或删除控件。在下面的示例中，请使用 Android 应用能够读取的文件路径，并为每个输出演示文稿选择可写位置。

## **列出 ActiveX 控件及其存储属性**

要检查不熟悉的模板，请以读取模式打开它并遍历每张幻灯片上的控件。示例报告幻灯片编号、控件名称、[getClassId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getClassId--)以及 [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) 中的每个键值对。它读取演示文稿时不会激活控件、触发事件或宏、更改值或保存文件。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

从 `ActiveX.pptm` 中选取的输出显示了一个文本框和一个命令按钮。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空的属性集合显示为 `[]`。对于使用二进制存储的控件，[getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) 可能返回 `null`，显示为 `Properties unavailable`。如果只需要属性名称，可在检查为 null 后使用 [getNamesOfProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--)。报告列出了演示文稿中可用的属性。控件在运行时可能支持额外的属性。

## **修改 ActiveX 控件**

示例需要一个启用宏的演示文稿，其中第一张幻灯片包含名为 `TextBox1` 的文本框和名为 `CommandButton1` 的命令按钮。它使用 [control properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) 更改文本框的值和按钮的标题。每个控件还有 PowerPoint 在激活前可以显示的静态预览。为每个控件提供显示更新后文本和外观的 PNG。示例通过 [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getSubstitutePictureFormat--) 为这些图像赋值。

示例通过使用 [IControl.setFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-) 将第一张幻灯片上的所有控件向下移动 100 点来设置它们的框架。它将编辑后的演示文稿保存为 PPTM 格式，然后使用 [IControlCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/#clear--) 保存第二份副本，其中该幻灯片上的所有 ActiveX 控件已被移除。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    IPPImage textBoxPreview;
    IPPImage buttonPreview;
    try (FileInputStream textBoxStream = new FileInputStream("text-box-preview.png");
         FileInputStream buttonStream = new FileInputStream("button-preview.png")) {
        textBoxPreview = presentation.getImages().addImage(textBoxStream);
        buttonPreview = presentation.getImages().addImage(buttonStream);
    }
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **添加 ActiveX 媒体播放器控件**

要复用已配置的 Windows Media Player 控件，请从第一张幻灯片包含名为 `WindowsMediaPlayer1` 的播放器的模板开始。[ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) 将整个幻灯片复制到新演示文稿中。示例在其 [properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) 中设置播放器的 `URL`，并将克隆的幻灯片保存为输出中的唯一幻灯片。视频保持为外部文件，因此请选择播放器在播放期间能够访问的路径。

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");

        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **FAQ**

**Aspose.Slides 能在不运行 ActiveX 控件的情况下保留它们吗？**

可以。Aspose.Slides 可以读取并保存控件，包括它们的属性和位置，而无需激活它们。

**ActiveX 控件与 OLE 对象有何区别？**

ActiveX 控件允许用户与幻灯片交互，例如输入文本或单击按钮。一个 [OLE 对象](/slides/zh/androidjava/manage-ole/) 使幻灯片能够包含或链接由其他应用程序管理的内容，例如 Excel 工作表。

**在使用 Aspose.Slides 保存演示文稿后，ActiveX 事件仍会触发 VBA 宏吗？**

请将演示文稿保存为启用宏的格式（如 PPTM），以保留其 VBA 项目。Windows 版 PowerPoint 在其安全设置允许 ActiveX 控件和宏时，可以运行现有的事件处理程序。