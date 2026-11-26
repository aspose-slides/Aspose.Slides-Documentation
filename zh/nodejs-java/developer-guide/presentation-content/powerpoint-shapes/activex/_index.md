---
title: 使用 JavaScript 管理演示文稿中的 ActiveX 控件
linktitle: ActiveX
type: docs
weight: 80
url: /zh/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX 控件
- 管理 ActiveX
- 添加 ActiveX
- 修改 ActiveX
- 媒体播放器
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 编辑 ActiveX 文本框和按钮，更新控件预览，并在 PowerPoint 演示文稿中重复使用 Windows Media Player 控件。"
---
## **介绍**

ActiveX 控件为 PowerPoint 幻灯片提供交互元素，例如文本框、命令按钮和媒体播放器。Aspose.Slides for Node.js via Java 通过 [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls) 暴露幻灯片的控件。使用此集合可编辑控件、在幻灯片上移动或删除控件。

## **列出 ActiveX 控件及其存储属性**

要检查不熟悉的模板，打开它进行读取并遍历每张幻灯片上的控件。示例报告幻灯片号、控件名称、[getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId)以及 [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) 中的每个键值对。它读取演示文稿时不激活控件、不调用事件或宏、不更改数值，也不保存文件。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
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

空的属性集合显示为 `[]`。对于使用二进制存储的控件，[getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) 可以返回 `null`，显示为 `Properties unavailable`。如果只需要属性名称，请在空检查后使用 [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties)。报告列出了演示文稿中可用的属性。控件在运行时可能支持其他属性。

## **修改 ActiveX 控件**

示例假设演示文稿已启用宏，第一张幻灯片上有一个名为 `TextBox1` 的文本框和一个名为 `CommandButton1` 的命令按钮。它使用 [控件属性集合](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) 来更改文本框的值和按钮的标题。每个控件还有 PowerPoint 在激活前可以显示的静态预览。为每个控件提供显示其更新文本和外观的 PNG。示例通过 [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat) 为这些图像赋值。

示例通过使用 [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame) 将第一张幻灯片上所有控件的框架向下移动 100 点。它以 PPTM 格式保存编辑后的演示文稿，然后使用 [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) 保存第二个副本，删除该幻灯片上的所有 ActiveX 控件。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```
## **添加 ActiveX 媒体播放器控件**

要复用已配置的 Windows Media Player 控件，首先使用第一张幻灯片包含名为 `WindowsMediaPlayer1` 的播放器的模板。[SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) 将整张幻灯片复制到新演示文稿中。示例在其 [属性集合](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) 中设置播放器的 `URL`，并将克隆的幻灯片保存为输出中的唯一幻灯片。视频保持外部链接，请选择播放器在播放期间能够访问的路径。

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```
## **常见问题**

**Aspose.Slides 能在不运行 ActiveX 控件的情况下保留它们吗？**

可以。Aspose.Slides 能读取并保存控件，包括它们的属性和位置，而无需激活它们。

**ActiveX 控件与 OLE 对象有何不同？**

ActiveX 控件让用户与幻灯片交互，例如输入文本或点击按钮。一个 [OLE 对象](/slides/zh/nodejs-java/manage-ole/) 让幻灯片包含或链接到由其他应用程序管理的内容，例如 Excel 工作表。

**在使用 Aspose.Slides 保存演示文稿后，ActiveX 事件仍会触发 VBA 宏吗？**

将演示文稿保存为启用宏的格式（例如 PPTM），以保留其 VBA 项目。当 Windows 版 PowerPoint 的安全设置同时允许 ActiveX 控件和宏时，它可以运行现有的事件处理程序。