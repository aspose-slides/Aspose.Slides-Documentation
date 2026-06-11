---
title: Hantera SmartArt-grafik i presentationer med JavaScript
linktitle: SmartArt-grafik
type: docs
weight: 20
url: /sv/nodejs-java/manage-smartart-shape/
keywords:
- SmartArt-objekt
- SmartArt-grafik
- SmartArt-stil
- SmartArt-färg
- skapa SmartArt
- lägga till SmartArt
- redigera SmartArt
- ändra SmartArt
- åtkomst till SmartArt
- SmartArt-layouttyp
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatisera skapande, redigering och formgivning av PowerPoint SmartArt i JavaScript med Aspose.Slides, med kortfattade kodexempel och prestandafokuserad vägledning."
---
## **Översikt**

Aspose.Slides låter dig skapa och hantera SmartArt-grafik i PowerPoint-presentationer programsmässigt. Den här artikeln förklarar hur du lägger till en SmartArt-form på en bild, får åtkomst till befintliga SmartArt-former, hittar SmartArt med en specifik layouttyp och uppdaterar dess visuella utseende genom att ändra SmartArt‑stilen eller färgstilen.

Exemplen visar hur du arbetar med SmartArt-former via presentationens bilds formssamling, kontrollerar om en form är SmartArt och sedan modifierar eller inspekterar dess egenskaper.

## **Skapa SmartArt-form**
Aspose.Slides för Node.js via Java har tillhandahållit ett API för att skapa SmartArt-former. För att skapa en SmartArt-form i en bild, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) klass.
1. Hämta referensen till en bild genom att använda dess Index.
1. [Lägg till en SmartArt-form](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) genom att ange `LayoutType`.
1. Spara den ändrade presentationen som en PPTX-fil.

```javascript
// Instansiera Presentation-klass
var pres = new aspose.slides.Presentation();
try {
    // Hämta första bilden
    var slide = pres.getSlides().get_Item(0);
    // Lägg till SmartArt-form
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Sparar presentationen
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figur: SmartArt-form tillagd på bilden**|

## **Åtkomst till SmartArt-form i bild**
Följande kod används för att få åtkomst till SmartArt-formerna som lagts till i presentationsbilden. I exempel­koden kommer vi att gå igenom varje form i bilden och kontrollera om den är en SmartArt-form. Om formen är av typen SmartArt kommer vi att typkonvertera den till en SmartArt‑instans.

```javascript
// Läs in önskad presentation
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Gå igenom varje form i den första bilden
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Kontrollera om shape är av SmartArt-typ
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Typkonvertera shape till SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Åtkomst till SmartArt-form med specifik LayoutType**
Följande exempel­kod hjälper dig att få åtkomst till SmartArt-formen med en viss LayoutType. Observera att du inte kan ändra LayoutType för SmartArt eftersom den är skrivskyddad och endast sätts när SmartArt‑formen läggs till.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) klass och ladda presentationen med SmartArt-form.
1. Hämta referensen till den första bilden genom att använda dess Index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
1. Kontrollera SmartArt‑formen med den specifika LayoutType och utför det som krävs därefter.

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Gå igenom varje form i den första bilden
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Kontrollera om form är av SmartArt-typ
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Typkonvertera form till SmartArtEx
            var smart = shape;
            // Kontrollerar SmartArt-layout
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ändra SmartArt-formens stil**
I detta exempel lär vi oss att ändra snabbstilen för en SmartArt-form.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) klass och ladda presentationen med SmartArt-form.
1. Hämta referensen till den första bilden genom att använda dess Index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
1. Hitta SmartArt‑formen med en viss Stil.
1. Ställ in den nya Stilen för SmartArt‑formen.
1. Spara presentationen.

```javascript
// Instansiera Presentation-klass
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Hämta första bilden
    var slide = pres.getSlides().get_Item(0);
    // Gå igenom varje form i den första bilden
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Kontrollera om form är av SmartArt-typ
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Typkonvertera form till SmartArtEx
            var smart = shape;
            // Kontrollerar SmartArt-stil
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // Ändrar SmartArt-stil
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Sparar presentationen
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figur: SmartArt-form med ändrad stil**|

## **Ändra SmartArt-formens färgstil**
I detta exempel lär vi oss att ändra färgstilen för en SmartArt-form. I följande exempel­kod kommer vi att få åtkomst till SmartArt‑formen med en viss Color Style och ändra dess stil.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) klass och ladda presentationen med SmartArt-form.
1. Hämta referensen till den första bilden genom att använda dess Index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
1. Hitta SmartArt‑formen med en viss Color Style.
1. Ställ in den nya Color Style för SmartArt‑formen.
1. Spara presentationen.

```javascript
// Instansiera Presentation-klass
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Hämta första bilden
    var slide = pres.getSlides().get_Item(0);
    // Gå igenom varje form i den första bilden
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Kontrollera om form är av SmartArt-typ
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Typkonvertera form till SmartArtEx
            var smart = shape;
            // Kontrollerar SmartArt-färgstyp
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // Ändrar SmartArt-färgstyp
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Sparar presentationen
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figur: SmartArt-form med ändrad Color Style**|

## **FAQ**

**Kan jag animera SmartArt som ett enda objekt?**

Ja. SmartArt är en form, så du kan tillämpa standardanimationer via animations‑API:t (ingång, utgång, betoning, rörelsespår) precis som för andra former.

**Hur kan jag hitta en specifik SmartArt på en bild om jag inte känner till dess interna ID?**

Ställ in och använd alternativ text (AltText) och sök efter formen med det värdet – detta är ett rekommenderat sätt att hitta målformen.

**Kan jag gruppera SmartArt med andra former?**

Ja. Du kan gruppera SmartArt med andra former (bilder, tabeller osv.) och sedan manipulera gruppen.

**Hur får jag en bild av en specifik SmartArt (t.ex. för en förhandsgranskning eller rapport)?**

Exportera en miniatyr/ bild av formen; biblioteket kan rendera enskilda former till rasterfiler (PNG/JPG/TIFF).

**Kommer SmartArt‑utseendet att bevaras när hela presentationen konverteras till PDF?**

Ja. Renderingsmotorn strävar efter hög noggrannhet vid PDF‑export, med ett antal kvalitets‑ och kompatibilitetsalternativ.