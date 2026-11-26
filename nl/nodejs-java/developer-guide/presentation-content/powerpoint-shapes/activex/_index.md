---
title: Beheer ActiveX-besturingselementen in presentaties met JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /nl/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX besturingselement
- ActiveX beheren
- ActiveX toevoegen
- ActiveX wijzigen
- mediaspeler
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Bewerk ActiveX-tekstvakken en -knoppen, werk besturingselement-voorbeelden bij, en hergebruik een Windows Media Player-besturingselement in PowerPoint-presentaties met Aspose.Slides voor Node.js via Java."
---
## **Inleiding**

ActiveX‑besturingselementen geven een PowerPoint‑dia interactieve elementen zoals tekstvakken, commandoknoppen en mediaplayers. Aspose.Slides for Node.js via Java maakt de besturingselementen van een dia toegankelijk via [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls). Gebruik deze collectie om een besturingselement te bewerken, te verplaatsen op de dia, of te verwijderen.

## **Lijst van ActiveX‑besturingselementen en hun opgeslagen eigenschappen**

Om een onbekende sjabloon te inspecteren, opent u deze voor lezen en doorloopt u de besturingselementen op elke dia. Het voorbeeld geeft het slidennummer, de besturingselementnaam, [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId), en elk sleutel‑waarde‑paar in [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties). Het leest de presentatie zonder de besturingselementen te activeren, events of macro's uit te voeren, waarden te wijzigen, of het bestand op te slaan.

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

Geselecteerde uitvoer van `ActiveX.pptm` toont een tekstvak en een commandoknop.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Een lege eigenschappenverzameling verschijnt als `[]`. Voor besturingselementen die binaire opslag gebruiken, kan [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) `null` teruggeven, weergegeven als `Properties unavailable`. Als u alleen de namen nodig heeft, gebruik dan [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) na de null‑controle. Het rapport geeft de beschikbare eigenschappen van de presentatie weer. Een besturingselement kan tijdens uitvoering extra eigenschappen ondersteunen.

## **ActiveX‑besturingselementen wijzigen**

Het voorbeeld gaat uit van een macro‑ingeschakelde presentatie met een tekstvak genaamd `TextBox1` en een commandoknop genaamd `CommandButton1` op de eerste dia. Het gebruikt de [verzameling van besturingseigenschappen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) om de waarde van het tekstvak en het label van de knop te wijzigen. Elk besturingselement heeft ook een statische voorbeeldweergave die PowerPoint kan tonen vóór activatie. Lever een PNG voor elk besturingselement met de bijgewerkte tekst en weergave. Het voorbeeld kent deze afbeeldingen toe via [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat).

Het voorbeeld verplaatst elk besturingselement op de eerste dia 100 punten naar beneden door het frame in te stellen met [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame). Het slaat de bewerkte presentatie op in PPTM‑formaat en gebruikt vervolgens [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) om een tweede kopie op te slaan waarbij alle ActiveX‑besturingselementen van die dia verwijderd zijn.

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
## **Een ActiveX‑mediaplayer‑besturingselement toevoegen**

Om een geconfigureerd Windows Media Player‑besturingselement opnieuw te gebruiken, start u met een sjabloon waarvan de eerste dia een speler bevat met de naam `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) kopieert de volledige dia naar een nieuwe presentatie. Het voorbeeld stelt de `URL` van de speler in via de [eigenschappenverzameling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) en slaat de gekloonde dia op als de enige dia in de uitvoer. De video blijft extern, dus kies een pad dat de speler tijdens het afspelen kan bereiken.

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

**Kan Aspose.Slides ActiveX‑besturingselementen behouden zonder ze uit te voeren?**

Ja. Aspose.Slides kan besturingselementen lezen en opslaan, inclusief hun eigenschappen en posities, zonder ze te activeren.

**Hoe verschillen ActiveX‑besturingselementen van OLE‑objecten?**

ActiveX‑besturingselementen laten gebruikers een dia interactief gebruiken, bijvoorbeeld door tekst in te voeren of op een knop te klikken. Een [OLE‑object](/slides/nl/nodejs-java/manage-ole/) laat een dia inhoud bevatten of linken naar content die door een andere toepassing wordt beheerd, zoals een Excel‑werkblad.

**Zullen ActiveX‑events nog steeds VBA‑macro’s activeren nadat ik een presentatie opsla met Aspose.Slides?**

Sla de presentatie op in een macro‑ingeschakeld formaat zoals PPTM om het VBA‑project te behouden. PowerPoint voor Windows kan de bestaande event‑handlers uitvoeren wanneer de beveiligingsinstellingen zowel ActiveX‑besturingselementen als macro’s toestaan.