---
title: Správa ActiveX ovládacích prvků v prezentacích pomocí JavaScriptu
linktitle: ActiveX
type: docs
weight: 80
url: /cs/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX ovládací prvek
- správa ActiveX
- přidání ActiveX
- úprava ActiveX
- přehrávač médií
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Upravujte textová pole a tlačítka ActiveX, aktualizujte náhledy ovládacích prvků a znovu použijte ovládací prvek Windows Media Player v prezentacích PowerPoint s Aspose.Slides pro Node.js prostřednictvím Javy."
---
## **Úvod**

ActiveX ovládací prvky poskytují snímku PowerPointu interaktivní elementy, jako jsou textová pole, tlačítka příkazů a přehrávače médií. Aspose.Slides pro Node.js prostřednictvím Javy zpřístupňuje ovládací prvky snímku pomocí [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls). Použijte tuto kolekci pro úpravu ovládacího prvku, jeho přesunutí na snímku nebo odstranění.

## **Seznam ActiveX ovládacích prvků a jejich uložených vlastností**

Pro prozkoumání neznámé šablony ji otevřete pro čtení a projděte ovládací prvky na každém snímku. Příklad uvádí číslo snímku, název ovládacího prvku, [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId) a každý pár klíč‑hodnota v [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties). Prezentaci načítá, aniž by aktivoval ovládací prvky, vyvolával události nebo makra, měnil hodnoty nebo ukládal soubor.

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

Vybraný výstup ze souboru `ActiveX.pptm` zobrazuje textové pole a tlačítko příkazu.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Prázdná kolekce vlastností se zobrazí jako `[]`. U ovládacích prvků, které používají binární úložiště, může [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) vrátit `null`, zobrazené jako `Properties unavailable`. Pokud potřebujete pouze názvy, použijte [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) po kontrole na null. Zpráva uvádí vlastnosti dostupné v prezentaci. Ovládací prvek může v čase běhu podporovat další vlastnosti.

## **Úprava ActiveX ovládacích prvků**

Příklad očekává prezentaci s povolenými makry, která má na prvním snímku textové pole pojmenované `TextBox1` a tlačítko příkazu pojmenované `CommandButton1`. Používá [kolekce vlastností ovládacího prvku](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) pro změnu hodnoty textového pole a popisku tlačítka. Každý ovládací prvek má také statický náhled, který PowerPoint může zobrazit před aktivací. Poskytněte PNG pro každý ovládací prvek, zobrazující jeho aktualizovaný text a vzhled. Příklad přiřadí tyto obrázky pomocí [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat).

Příklad posune každý ovládací prvek na prvním snímku dolů o 100 bodů nastavením jeho rámce pomocí [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame). Uloží upravenou prezentaci ve formátu PPTM a poté pomocí [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) uloží druhou kopii, ze které jsou všechny ActiveX ovládací prvky z tohoto snímku odstraněny.

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

## **Přidání ActiveX ovládacího prvku Media Player**

Pro opětovné použití nakonfigurovaného ovládacího prvku Windows Media Player začněte šablonou, jejíž první snímek obsahuje přehrávač pojmenovaný `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) zkopíruje celý snímek do nové prezentace. Příklad nastaví pro přehrávač `URL` v jeho [kolekce vlastností](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) a uloží zkopírovaný snímek jako jediný snímek ve výstupu. Video zůstane externí, takže zvolte cestu, ke které má přehrávač během přehrávání přístup.

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

## **Často kladené otázky**

**Dokáže Aspose.Slides zachovat ActiveX ovládací prvky, aniž by je spouštěl?**

Ano. Aspose.Slides může číst a ukládat ovládací prvky, včetně jejich vlastností a pozic, aniž by je aktivoval.

**Jak se liší ActiveX ovládací prvky od OLE objektů?**

ActiveX ovládací prvky umožňují uživatelům interagovat se snímkem, například zadáním textu nebo kliknutím na tlačítko. An [OLE objekt](/slides/cs/nodejs-java/manage-ole/) umožňuje snímku obsahovat nebo odkazovat na obsah spravovaný jinou aplikací, například list Excelu.

**Spustí události ActiveX i nadále VBA makra po uložení prezentace pomocí Aspose.Slides?**

Uložte prezentaci do formátu s povolenými makry, například PPTM, aby byl zachován její projekt VBA. PowerPoint pro Windows může spustit existující obslužné rutiny událostí, pokud jeho bezpečnostní nastavení povolí jak ActiveX ovládací prvky, tak makra.