---
title: Lägg till rektanglar i presentationer med JavaScript
linktitle: Rektangel
type: docs
weight: 80
url: /sv/nodejs-java/rectangle/
keywords:
- lägga till rektangel
- skapa rektangel
- rektangelform
- enkel rektangel
- formaterad rektangel
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Förbättra dina PowerPoint-presentationer genom att lägga till rektanglar med JavaScript och Aspose.Slides för Node.js—designa och modifiera former programatiskt med enkelhet."
---
## **Overview**

Den här artikeln visar hur man lägger till rektangelformer i PowerPoint‑presentationer med hjälp av Aspose.Slides. Den täcker hur man skapar en enkel rektangel, en formaterad rektangel och sparar den uppdaterade presentationen som en PPTX‑fil.

Du får också se hur man tillämpar grundläggande formatering av rektangel, såsom fyllningsfärg, linjefärg och linjebredd. Dessutom pekar artikelns FAQ på relaterade rektangeluppgifter, inklusive rundade hörn, bildfyllningar, visuella effekter, hyperlänkar, lås för former, exportalternativ och effektiva egenskaper. 

## **Add Rectangle to Slide**

Precis som tidigare ämnen handlar detta också om att lägga till en form, och den här gången är formen som vi diskuterar en rektangel. I detta ämne har vi beskrivit hur utvecklare kan lägga till enkla eller formaterade rektanglar i sina bildspel med Aspose.Slides. 

För att lägga till en enkel rektangel på en vald bild i presentationen, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation)klass.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape) av typen Rectangle med metoden [addAutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection)objekt.
- Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en enkel rektangel på den första bilden i presentationen.

```javascript
// Instansiera Presentation‑klassen som representerar PPTX
var pres = new aspose.slides.Presentation();
try {
    // Hämta den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Lägg till AutoShape av ellipstyp
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Skriv PPTX‑filen till disk
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Add Formatted Rectangle to Slide**
För att lägga till en formaterad rektangel på en bild, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation)klass.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape) av typen Rectangle med metoden [addAutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection)objekt.
- Ställ in fyllningstypen för rektangeln till Solid.
- Ställ in färgen på rektangeln med metoden [SolidFillColor.setColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) som exponeras av [FillFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FillFormat)objektet som är kopplat till [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape)objektet.
- Ställ in färgen på rektangelns linjer.
- Ställ in bredden på rektangelns linjer.
- Skriv den modifierade presentationen som PPTX‑fil.

Stegen ovan är implementerade i exemplet nedan.

```javascript
// Instansiera Presentation‑klassen som representerar PPTX
var pres = new aspose.slides.Presentation();
try {
    // Hämta den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Lägg till AutoShape av ellipstyp
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Applicera någon formatering på ellipsformen
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Applicera någon formatering på Ellipsens linje
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Skriv PPTX‑filen till disk
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**How do I add a rectangle with rounded corners?**

Använd den rundade hörn‑formen och justera hörnradien i formens egenskaper; avrundning kan också appliceras per hörn via geometrijusteringar.

**How do I fill a rectangle with an image (texture)?**

Välj bildfyllningstypen, ange bildkällan och konfigurera läge för töjning/upprepning.

**Can a rectangle have shadow and glow?**

Ja. Yttre/inre skugga, glöd och mjuka kanter är tillgängliga med justerbara parametrar.

**Can I turn a rectangle into a button with a hyperlink?**

Ja. Tilldela en hyperlänk till formens klick (hoppa till en bild, fil, webbadress eller e‑post).

**How can I protect a rectangle from moving and changes?**

Använd lås för former: du kan förbjuda flyttning, storleksändring, urval eller textredigering för att bevara layouten.

**Can I convert a rectangle to a raster image or SVG?**

Ja. Du kan rendera formen till en bild med angiven storlek/skalning eller exportera den som SVG för vektorbruk.

**How do I quickly get the actual (effective) properties of a rectangle considering theme and inheritance?**

Använd formens effektiva egenskaper: API‑et returnerar beräknade värden som tar hänsyn till temastilar, layout och lokala inställningar, vilket förenklar formatanalys.