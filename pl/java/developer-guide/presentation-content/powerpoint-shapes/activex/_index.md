---
title: Zarządzanie kontrolkami ActiveX w prezentacjach w Javie
linktitle: ActiveX
type: docs
weight: 80
url: /pl/java/activex/
keywords:
- ActiveX
- kontrolka ActiveX
- zarządzanie ActiveX
- dodawanie ActiveX
- modyfikowanie ActiveX
- odtwarzacz multimedialny
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Edytuj pola tekstowe i przyciski ActiveX, aktualizuj podglądy kontrolek oraz ponownie użyj kontrolki Windows Media Player w prezentacjach PowerPoint przy pomocy Aspose.Slides dla Javy."
---
## **Wprowadzenie**

ActiveX controls give a PowerPoint slide interactive elements such as text boxes, command buttons, and media players. Aspose.Slides for Java exposes a slide's controls through [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--). Use this collection to edit a control, move it on the slide, or remove it.

## **Lista kontrolek ActiveX i ich przechowywanych właściwości**

To inspect an unfamiliar template, open it for reading and iterate through the controls on each slide. The example reports the slide number, control name, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--), and each key-value pair in [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--). It reads the presentation without activating controls, invoking events or macros, changing values, or saving the file.

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

Selected output from `ActiveX.pptm` shows a text box and a command button.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

An empty property collection appears as `[]`. For controls that use binary storage, [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) can return `null`, shown as `Properties unavailable`. If you need only the names, use [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) after the null check. The report lists the properties available from the presentation. A control may support additional properties at runtime.

## **Modyfikacja kontrolek ActiveX**

The example expects a macro-enabled presentation with a text box named `TextBox1` and a command button named `CommandButton1` on the first slide. It uses the [kolekcja właściwości kontrolki](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) to change the text box value and the button caption. Each control also has a static preview that PowerPoint can display before activation. Supply a PNG for each control showing its updated text and appearance. The example assigns these images through [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

The example moves every control on the first slide down by 100 points by setting its frame with [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). It saves the edited presentation in PPTM format, then uses [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) to save a second copy with all ActiveX controls removed from that slide.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
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

## **Dodanie kontrolki odtwarzacza multimediów ActiveX**

To reuse a configured Windows Media Player control, start with a template whose first slide contains a player named `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) copies the entire slide into a new presentation. The example sets the player's `URL` in its [kolekcja właściwości](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) and saves the cloned slide as the only slide in the output. The video stays external, so choose a path the player can access during playback.

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

**Czy Aspose.Slides może zachować kontrolki ActiveX bez ich uruchamiania?**

Tak. Aspose.Slides can read and save controls, including their properties and positions, without activating them.

**Czym różnią się kontrolki ActiveX od obiektów OLE?**

ActiveX controls let users interact with a slide, for example by entering text or clicking a button. An [obiekt OLE](/slides/pl/java/manage-ole/) lets a slide contain or link to content managed by another application, such as an Excel worksheet.

**Czy zdarzenia ActiveX nadal wywołają makra VBA po zapisaniu prezentacji przy użyciu Aspose.Slides?**

Save the presentation in a macro-enabled format such as PPTM to retain its VBA project. PowerPoint for Windows can run the existing event handlers when its security settings allow both ActiveX controls and macros.