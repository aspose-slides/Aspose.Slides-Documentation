---
title: ActiveX vezérlők kezelése prezentációkban JavaScript használatával
linktitle: ActiveX
type: docs
weight: 80
url: /hu/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX kezelése
- ActiveX hozzáadása
- ActiveX módosítása
- médialejátszó
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "ActiveX szövegmezők és gombok szerkesztése, a vezérlő előnézetek frissítése, és egy Windows Media Player vezérlő újrafelhasználása PowerPoint prezentációkban az Aspose.Slides for Node.js via Java segítségével."
---
## **Bevezetés**

Az ActiveX vezérlők interaktív elemeket adnak a PowerPoint diára, például szövegmezőket, parancsgombokat és médialejátszókat. Az Aspose.Slides for Node.js a Java-n keresztül a diák vezérlőit a [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls) segítségével teszi elérhetővé. Használja ezt a gyűjteményt egy vezérlő szerkesztéséhez, áthelyezéséhez a dián vagy eltávolításához.

## **Az ActiveX vezérlők listázása és tárolt tulajdonságaik**

Egy ismeretlen sablon ellenőrzéséhez nyissa meg olvasásra, és iteráljon végig a vezérlőkön minden dián. A példa jelentést készít a dia számáról, a vezérlő nevéről, a [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId) értékről, valamint a [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) minden kulcs-érték párjáról. A prezentációt úgy olvassa be, hogy nem aktiválja a vezérlőket, nem hív meg eseményeket vagy makrókat, nem változtatja az értékeket, és nem menti a fájlt.

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

A `ActiveX.pptm` kiválasztott kimenete egy szövegmezőt és egy parancsgombot mutat.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Az üres tulajdonsággyűjtemény `[]` formában jelenik meg. Azoknál a vezérlőknél, amelyek bináris tárolást használnak, a [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) `null` értéket adhat vissza, amely `Properties unavailable`-ként jelenik meg. Ha csak a nevekre van szüksége, használja a [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) metódust a null ellenőrzés után. A jelentés felsorolja a prezentációból elérhető tulajdonságokat. Egy vezérlő a futás során további tulajdonságokat támogathat.

## **ActiveX vezérlők módosítása**

A példa egy makrókkal engedélyezett prezentációt vár, amelyen az első dián egy `TextBox1` nevű szövegmező és egy `CommandButton1` nevű parancsgomb található. A [control properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) segítségével módosítja a szövegmező értékét és a gomb feliratát. Minden vezérlőnek van egy statikus előnézete is, amelyet a PowerPoint aktiválás előtt megjeleníthet. Adjon meg egy PNG-t minden vezérlőhöz, amely a frissített szöveget és megjelenést mutatja. A példa ezeket a képeket a [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat) segítségével rendeli hozzá.

A példa minden vezérlőt az első dián 100 ponttal lefelé mozdít a keretét a [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame) segítségével beállítva. Elmenti a szerkesztett prezentációt PPTM formátumban, majd a [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) használatával egy második példányt ment, amelyben az összes ActiveX vezérlő eltávolításra került az adott diáról.

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
## **ActiveX mediaplayer vezérlő hozzáadása**

Egy előre beállított Windows Media Player vezérlő újbóli felhasználásához kezdje egy olyan sablonnal, amelynek első diája egy `WindowsMediaPlayer1` nevű lejátszót tartalmaz. A [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) az egész diát egy új prezentációba másolja. A példa beállítja a lejátszó `URL`-jét a [properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) segítségével, és a klónozott diát egyetlen diaként menti a kimenetbe. A videó külső marad, ezért válasszon egy olyan útvonalat, amelyhez a lejátszó a lejátszás során hozzáfér.

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
## **GYIK**

**Meg tudja őrizni az Aspose.Slides az ActiveX vezérlőket anélkül, hogy futtatná őket?**

Igen. Az Aspose.Slides képes olvasni és menteni a vezérlőket, beleértve azok tulajdonságait és helyzetét, anélkül, hogy aktiválná őket.

**Miben különböznek az ActiveX vezérlők az OLE objektumoktól?**

Az ActiveX vezérlők lehetővé teszik a felhasználók számára a diával való interakciót, például szöveg bevitelét vagy gomb megnyomását. Egy [OLE objektum](/slides/hu/nodejs-java/manage-ole/) lehetővé teszi, hogy a dia tartalmazzon vagy hivatkozzon egy másik alkalmazás által kezelt tartalomra, például egy Excel munkalapra.

**Az ActiveX események továbbra is kiváltják a VBA makrókat, miután egy prezentációt mentek az Aspose.Slides használatával?**

Mentse a prezentációt makrókkal engedélyezett formátumban, például PPTM-ben, hogy megőrizze a VBA projektet. A Windows-os PowerPoint képes futtatni a meglévő eseménykezelőket, ha a biztonsági beállításai engedélyezik az ActiveX vezérlőket és a makrókat.