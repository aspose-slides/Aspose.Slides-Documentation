---
title: Manage ActiveX Controls in Presentations Using JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /nodejs-java/activex/
keywords:
- ActiveX
- ActiveX control
- manage ActiveX
- add ActiveX
- modify ActiveX
- media player
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Edit ActiveX text boxes and buttons, update control previews, and reuse a Windows Media Player control in PowerPoint presentations with Aspose.Slides for Node.js via Java."
---

## **Introduction**

ActiveX controls give a PowerPoint slide interactive elements such as text boxes, command buttons, and media players. Aspose.Slides for Node.js via Java exposes a slide's controls through [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls). Use this collection to edit a control, move it on the slide, or remove it.

## **List ActiveX Controls and Their Stored Properties**

To inspect an unfamiliar template, open it for reading and iterate through the controls on each slide. The example reports the slide number, control name, [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId), and each key-value pair in [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties). It reads the presentation without activating controls, invoking events or macros, changing values, or saving the file.

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

Selected output from `ActiveX.pptm` shows a text box and a command button.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

An empty property collection appears as `[]`. For controls that use binary storage, [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) can return `null`, shown as `Properties unavailable`. If you need only the names, use [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) after the null check. The report lists the properties available from the presentation. A control may support additional properties at runtime.

## **Modify ActiveX Controls**

The example expects a macro-enabled presentation with a text box named `TextBox1` and a command button named `CommandButton1` on the first slide. It uses the [control properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) to change the text box value and the button caption. Each control also has a static preview that PowerPoint can display before activation. Supply a PNG for each control showing its updated text and appearance. The example assigns these images through [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat).

The example moves every control on the first slide down by 100 points by setting its frame with [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame). It saves the edited presentation in PPTM format, then uses [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) to save a second copy with all ActiveX controls removed from that slide.

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

## **Add an ActiveX Media Player Control**

To reuse a configured Windows Media Player control, start with a template whose first slide contains a player named `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) copies the entire slide into a new presentation. The example sets the player's `URL` in its [properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) and saves the cloned slide as the only slide in the output. The video stays external, so choose a path the player can access during playback.

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

## **FAQ**

**Can Aspose.Slides preserve ActiveX controls without running them?**

Yes. Aspose.Slides can read and save controls, including their properties and positions, without activating them.

**How do ActiveX controls differ from OLE objects?**

ActiveX controls let users interact with a slide, for example by entering text or clicking a button. An [OLE object](/slides/nodejs-java/manage-ole/) lets a slide contain or link to content managed by another application, such as an Excel worksheet.

**Will ActiveX events still trigger VBA macros after I save a presentation with Aspose.Slides?**

Save the presentation in a macro-enabled format such as PPTM to retain its VBA project. PowerPoint for Windows can run the existing event handlers when its security settings allow both ActiveX controls and macros.
