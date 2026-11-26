---
title: ActiveX vezérlők kezelése prezentációkban Java nyelven
linktitle: ActiveX
type: docs
weight: 80
url: /hu/java/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX kezelése
- ActiveX hozzáadása
- ActiveX módosítása
- médialejátszó
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Szerkessze az ActiveX szövegdobozokat és gombokat, frissítse a vezérlő előnézeteket, és használja újra a Windows Media Player vezérlőt PowerPoint prezentációkban az Aspose.Slides for Java segítségével."
---
## **Bevezetés**

Az ActiveX vezérlők interaktív elemeket adnak a PowerPoint diákhoz, például szövegdobozokat, parancsgombokat és médialejátszókat. Az Aspose.Slides for Java a diák vezérlőit a [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--) metódussal teszi elérhetővé. Használja ezt a gyűjteményt egy vezérlő szerkesztéséhez, áthelyezéséhez a diáron vagy eltávolításához.

## **Az ActiveX vezérlők listázása és tárolt tulajdonságaik**

Ismeretlen sablon vizsgálatához nyissa meg olvasásra, és járja végig a vezérlőket minden dián. A példa jelentést készít a diaszámmal, a vezérlő nevével, a [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--) metódussal, és minden kulcs‑érték párral a [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) metódusban. A bemutatót anélkül olvassa be, hogy aktiválja a vezérlőket, eseményeket vagy makrókat hívna meg, értékeket módosítana, vagy fájlt mentene.

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

A `ActiveX.pptm` kiválasztott kimenete egy szövegdobozt és egy parancsgombot jelenít meg.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Egy üres tulajdonsággyűjtemény `[]`‑ként jelenik meg. A bináris tárolást használó vezérlőknél a [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) `null`‑t adhat vissza, ami `Properties unavailable`‑ként jelenik meg. Ha csak a nevekre van szüksége, használja a [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--)‑t a null ellenőrzés után. A jelentés felsorolja a bemutatóból elérhető tulajdonságokat. Egy vezérlő futásidőben további tulajdonságokat is támogathat.

## **Az ActiveX vezérlők módosítása**

A példa egy makró‑engedélyezett bemutatót vár, amelynek az első dián van egy `TextBox1` nevű szövegdoboz és egy `CommandButton1` nevű parancsgomb. A [vezérlő tulajdonsággyűjtemény](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) segítségével módosítja a szövegdoboz értékét és a gomb feliratát. Minden vezérlőnek van egy statikus előnézete, amelyet a PowerPoint aktiválás előtt megjeleníthet. Biztosítson egy PNG‑t minden vezérlőhöz, amely a frissített szöveget és megjelenést mutatja. A példa ezeket a képeket a [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--) metódussal rendeli hozzá.

A példa az első dián lévő összes vezérlőt 100 ponttal lefelé mozgatja a keretét a [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-) metódussal. A szerkesztett bemutatót PPTM formátumban menti, majd a [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) segítségével elment egy második példányt, amelyből minden ActiveX vezérlő el van távolítva az adott diáról.

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
## **ActiveX médiaplayer vezérlő hozzáadása**

Egy konfigurált Windows Media Player vezérlő újrahasználatához kezdjen egy sablonnal, amelynek első dián egy `WindowsMediaPlayer1` nevű lejátszó található. A [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) a teljes diát egy új bemutatóba másolja. A példa beállítja a lejátszó `URL`‑jét a [properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) segítségével, és a klónozott diát az egyetlen diaként menti a kimenetbe. A videó külső marad, ezért válasszon egy olyan útvonalat, amelyhez a lejátszó a lejátszás során hozzáfér.

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
## **GYIK**

**Megőrizheti az Aspose.Slides az ActiveX vezérlőket anélkül, hogy futtatná őket?**

Igen. Az Aspose.Slides képes olvasni és menteni a vezérlőket, beleértve azok tulajdonságait és pozícióit, anélkül, hogy aktiválná őket.

**Miben különböznek az ActiveX vezérlők az OLE objektumoktól?**

Az ActiveX vezérlők lehetővé teszik a felhasználók számára a diával való interakciót, például szöveg beírását vagy gombra kattintást. Egy [OLE objektum](/slides/hu/java/manage-ole/) lehetővé teszi, hogy a dia olyan tartalmat tartalmazzon vagy hivatkozzon rá, amelyet egy másik alkalmazás kezel, például egy Excel munkalap.

**Az ActiveX események továbbra is elindítják a VBA makrókat, miután a prezentációt az Aspose.Slides‑szel mentem?**

Mentse a bemutatót makró‑engedélyezett formátumban, például PPTM‑ben, hogy megőrizze a VBA projektet. A Windows‑ra készült PowerPoint a meglévő eseménykezelőket akkor tudja futtatni, ha a biztonsági beállítások engedélyezik az ActiveX vezérlőket és a makrókat egyaránt.