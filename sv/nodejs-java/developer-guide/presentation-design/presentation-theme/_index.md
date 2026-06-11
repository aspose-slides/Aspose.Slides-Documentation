---
title: Hantera presentationsteman i JavaScript
linktitle: Presentationstema
type: docs
weight: 10
url: /sv/nodejs-java/presentation-theme/
keywords:
- PowerPoint-tema
- presentationstema
- bildtema
- sätt tema
- ändra tema
- hantera tema
- temafärg
- extra palett
- tematypsnitt
- temastil
- temaeffekt
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Behärska presentationsteman i JavaScript med Aspose.Slides för Node.js för att skapa, anpassa och konvertera PowerPoint-filer med enhetlig varumärkesprofil."
---
## **Introduktion**

Ett presentationstema definierar egenskaperna för designelement. När du väljer ett presentationstema väljer du i princip en specifik uppsättning visuella element och deras egenskaper.

I PowerPoint består ett tema av färger, [fonter](/slides/sv/nodejs-java/powerpoint-fonts/), [bakgrundsstilar](/slides/sv/nodejs-java/presentation-background/) och effekter.

![theme-constituents](theme-constituents.png)

## **Ändra temafärg**

Ett PowerPoint‑tema använder en specifik uppsättning färger för olika element på en bild. Om du inte gillar färgerna ändrar du dem genom att tillämpa nya färger för temat. För att du ska kunna välja en ny temafärg tillhandahåller Aspose.Slides värden under [SchemeColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SchemeColor)-uppräkningen.

Denna JavaScript‑kod visar hur du ändrar accentfärgen för ett tema:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Du kan på detta sätt bestämma den resulterande färgens effektiva värde:

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

För att ytterligare demonstrera färgändringsoperationen skapar vi ett annat element och tilldelar accentfärgen (från den ursprungliga operationen) till det. Sedan ändrar vi färgen i temat:

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Den nya färgen tillämpas automatiskt på båda elementen.

### **Ställ in temafärg från ytterligare palett**

När du tillämpar luminansomvandlingar på huvudtema‑färgen(1) bildas färger från den extra paletten(2). Du kan sedan sätta och hämta dessa temafärger. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Huvudtema‑färger

**2** - Färger från den extra paletten.

Denna JavaScript‑kod demonstrerar en operation där färger från den extra paletten erhålls från huvudtema‑färgen och sedan används i former:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Accent 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // Accent 4, Ljusare 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // Accent 4, Ljusare 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // Accent 4, Ljusare 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // Accent 4, Mörkare 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // Accent 4, Mörkare 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Mappa `SchemeColor` till `ColorScheme`‑färger**

När du arbetar med [SchemeColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/schemecolor/) kan du märka att det innehåller följande temafärgvärden:

`Background1`, `Background2`, `Text1` och `Text2`.

Dock returnerar `Presentation.getMasterTheme().getColorScheme()` [ColorScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/colorscheme/) som exponerar motsvarande färger som:

`Dark1`, `Dark2`, `Light1` och `Light2`.

Denna skillnad är endast i namngivning. Dessa värden hänvisar till samma temafärgsplatser och mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Det finns ingen dynamisk konvertering mellan `Text`/`Background` och `Dark`/`Light`. De är helt enkelt alternativa namn för samma temafärger.

Denna namnskillnad kommer från Microsoft Office‑terminologi. Äldre Office‑versioner använde `Dark 1`, `Light 1`, `Dark 2` och `Light 2`, medan nyare UI‑versioner visar samma platser som `Text 1`, `Background 1`, `Text 2` och `Background 2`.

## **Ändra temafont**

För att du ska kunna välja typsnitt för teman och andra ändamål använder Aspose.Slides dessa speciella identifierare (liknande de som används i PowerPoint):

* **+mn-lt** - Brödtexttypsnitt Latin (Minor Latin Font)
* **+mj-lt** - Rubriktypsnitt Latin (Major Latin Font)
* **+mn-ea** - Brödtexttypsnitt East Asian (Minor East Asian Font)
* **+mj-ea** - Brödtexttypsnitt East Asian (Major East Asian Font)

Denna JavaScript‑kod visar hur du tilldelar latin‑typsnittet till ett temaelement:

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

Denna JavaScript‑kod visar hur du ändrar temats typsnitt i presentationen:

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

Typsnittet i alla textrutor kommer att uppdateras.

{{% alert color="primary" title="TIP" %}} 
Du kanske vill se [PowerPoint-typsnitt](/slides/sv/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Ändra temats bakgrundsstil**

Som standard erbjuder PowerPoint‑appen 12 fördefinierade bakgrunder men endast 3 av dessa 12 bakgrunder sparas i en vanlig presentation. 

![todo:image_alt_text](presentation-design_8.png)

Till exempel, efter att du har sparat en presentation i PowerPoint‑appen, kan du köra denna JavaScript‑kod för att ta reda på antalet fördefinierade bakgrunder i presentationen:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" %}} 
Genom att använda egenskapen [BackgroundFillStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) från klassen [FormatScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FormatScheme) kan du lägga till eller komma åt bakgrundsstilen i ett PowerPoint‑tema.
{{% /alert %}} 

Denna JavaScript‑kod visar hur du ställer in bakgrunden för en presentation:

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Indexguide**: 0 används för ingen fyllning. Indexet börjar från 1.

{{% alert color="primary" title="TIP" %}} 
Du kanske vill se [PowerPoint-bakgrund](/slides/sv/nodejs-java/presentation-background/).
{{% /alert %}}

## **Ändra temaeffekt**

Ett PowerPoint‑tema innehåller vanligtvis 3 värden för varje stilarray. Dessa arrayer kombineras till dessa 3 effekter: subtil, måttlig och intensiv. Till exempel är detta resultatet när effekterna tillämpas på en specifik form:

![todo:image_alt_text](presentation-design_10.png)

Genom att använda 3 egenskaper ([FillStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) från klassen [FormatScheme](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FormatScheme) kan du ändra elementen i ett tema (ännu mer flexibelt än alternativen i PowerPoint).

Denna JavaScript‑kod visar hur du ändrar en temaeffekt genom att förändra delar av element:

```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

De resulterande förändringarna i fyllningsfärg, fyllningstyp, skuggeffekt osv:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Kan jag tillämpa ett tema på en enstaka bild utan att ändra master?**  
Ja. Aspose.Slides stödjer temaarv för enskild bild, så du kan tillämpa ett lokalt tema på just den bilden samtidigt som master‑temat förblir intakt (via [SlideThemeManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidethememanager/)).

**Vad är det säkraste sättet att föra ett tema från en presentation till en annan?**  
[Klona bilder](/slides/sv/nodejs-java/clone-slides/) tillsammans med deras master till målpresentationen. Detta bevarar den ursprungliga mastern, layouterna och det associerade temat så att utseendet förblir konsekvent.

**Hur kan jag se de "effektiva" värdena efter all arv och överskrivningar?**  
Använd API:ets ["effektiva" vyer](/slides/sv/nodejs-java/shape-effective-properties/) för tema/färg/typsnitt/effekt. Dessa returnerar de lösta, slutgiltiga egenskaperna efter att ha tillämpat master‑plus eventuella lokala överskrivningar.