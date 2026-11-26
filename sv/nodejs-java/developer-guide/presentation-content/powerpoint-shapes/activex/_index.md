---
title: Hantera ActiveX-kontroller i presentationer med JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /sv/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX‑kontroll
- hantera ActiveX
- lägga till ActiveX
- modifiera ActiveX
- mediaspelare
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Redigera ActiveX‑textrutor och‑knappar, uppdatera kontrollförhandsgranskningar och återanvänd en Windows Media Player‑kontroll i PowerPoint‑presentationer med Aspose.Slides för Node.js via Java."
---
## **Introduktion**

ActiveX‑kontroller ger en PowerPoint‑bild interaktiva element som textrutor, kommandoknappar och mediespelare. Aspose.Slides för Node.js via Java exponerar en bilds kontroller genom [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls). Använd den här samlingen för att redigera en kontroll, flytta den på bilden eller ta bort den.

## **Lista ActiveX‑kontroller och deras lagrade egenskaper**

För att undersöka en okänd mall, öppna den för läsning och iterera genom kontrollerna på varje bild. Exemplet rapporterar bildnumret, kontrollens namn, [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId), och varje nyckel‑värde‑par i [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties). Det läser presentationen utan att aktivera kontroller, utlösa händelser eller makron, ändra värden eller spara filen.

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

Det valda resultatet från `ActiveX.pptm` visar en textruta och en kommandoknapp.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

En tom egenskapskollektion visas som `[]`. För kontroller som använder binär lagring kan [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) returnera `null`, vilket visas som `Properties unavailable`. Om du bara behöver namnen, använd [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) efter null‑kontrollen. Rapporten listar de egenskaper som finns tillgängliga i presentationen. En kontroll kan stödja ytterligare egenskaper vid körning.

## **Ändra ActiveX‑kontroller**

Exemplet förutsätter en makroaktiverad presentation med en textruta med namnet `TextBox1` och en kommandoknapp med namnet `CommandButton1` på den första bilden. Det använder [control properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) för att ändra textrutans värde och knappens rubrik. Varje kontroll har också en statisk förhandsgranskning som PowerPoint kan visa innan aktivering. Tillhandahåll en PNG för varje kontroll som visar dess uppdaterade text och utseende. Exemplet tilldelar dessa bilder via [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat).

Exemplet flyttar varje kontroll på den första bilden nedåt med 100 punkter genom att sätta dess ram med [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame). Det sparar den redigerade presentationen i PPTM‑format, och använder sedan [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) för att spara en andra kopia där alla ActiveX‑kontroller har tagits bort från den bilden.

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

## **Lägg till en ActiveX‑mediaspelarkontroll**

För att återanvända en konfigurerad Windows Media Player‑kontroll, börja med en mall där den första bilden innehåller en spelare med namnet `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) kopierar hela bilden till en ny presentation. Exemplet sätter spelarens `URL` i dess [properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) och sparar den klonade bilden som den enda bilden i utdata. Videon förblir extern, så välj en sökväg som spelaren kan komma åt under uppspelning.

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

## **Vanliga frågor**

**Kan Aspose.Slides bevara ActiveX‑kontroller utan att köra dem?**

Ja. Aspose.Slides kan läsa och spara kontroller, inklusive deras egenskaper och positioner, utan att aktivera dem.

**Hur skiljer sig ActiveX‑kontroller från OLE‑objekt?**

ActiveX‑kontroller låter användare interagera med en bild, till exempel genom att skriva in text eller klicka på en knapp. Ett [OLE‑objekt](/slides/sv/nodejs-java/manage-ole/) låter en bild innehålla eller länka till innehåll som hanteras av ett annat program, som ett Excel‑arbetsblad.

**Kommer ActiveX‑händelser fortfarande att utlösa VBA‑makron efter att jag sparat en presentation med Aspose.Slides?**

Spara presentationen i ett makroaktiverat format som PPTM för att behålla dess VBA‑projekt. PowerPoint för Windows kan köra de befintliga händelsehanterarna när dess säkerhetsinställningar tillåter både ActiveX‑kontroller och makron.