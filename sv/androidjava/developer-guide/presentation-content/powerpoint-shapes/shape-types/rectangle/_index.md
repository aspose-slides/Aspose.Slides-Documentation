---
title: Lägg till rektanglar i presentationer på Android
linktitle: Rektangel
type: docs
weight: 80
url: /sv/androidjava/rectangle/
keywords:
- lägg till rektangel
- skapa rektangel
- rektangelform
- enkel rektangel
- formaterad rektangel
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Förbättra dina PowerPoint‑presentationer genom att lägga till rektanglar med Aspose.Slides för Android via Java—designa och ändra former programmässigt med lätthet."
---
## **Översikt**

Den här artikeln visar hur du lägger till rektangelformer i PowerPoint‑bilder med Aspose.Slides. Den täcker hur du skapar en enkel rektangel, hur du skapar en formaterad rektangel och hur du sparar den uppdaterade presentationen som en PPTX‑fil.

Du kommer också att se hur du tillämpar grundläggande rektangelformatering, såsom fyllningsfärg, linjefärg och linjebredd. Dessutom pekar artikelns FAQ på relaterade rektangeluppgifter, inklusive runda hörn, bildfyllningar, visuella effekter, hyperlänkar, form lås, exportalternativ och effektiva egenskaper.

## **Lägg till en rektangel på en bild**
- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAutoShape) av typen Rectangle med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av objektet [IShapeCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection).
- Skriv den modifierade presentationen som en PPTX‑fil.

I exemplaret nedan har vi lagt till en enkel rektangel på den första bilden i presentationen.

```java
// Instansiera Presentation-klassen som representerar PPTX-filen
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till en AutoShape av ellipstyp
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Skriv PPTX-filen till disk
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lägg till en formaterad rektangel på en bild**
- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IAutoShape) av typen Rectangle med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av objektet [IShapeCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection).
- Ställ in [Fill Type](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FillType) för rektangeln till Solid.
- Ställ in färgen för rektangeln med metoden [SolidFillColor.setColor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) som exponeras av objektet [IFillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IFillFormat) som är associerat med objektet [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShape).
- Ställ in färgen på rektangelns linjer.
- Ställ in bredden på rektangelns linjer.
- Skriv den modifierade presentationen som en PPTX‑fil.

Ovanstående steg implementeras i exemplet nedan.

```java
// Instansiera Presentation-klassen som representerar PPTX-filen
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till en AutoShape av ellipstyp
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Tillämpa viss formatering på ellipsformen
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Tillämpa viss formatering på ellipsens linje
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Skriv PPTX-filen till disk
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Hur lägger jag till en rektangel med rundade hörn?**

Använd den rundade hörn‑[shape type](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shapetype/) och justera hörnradien i formens egenskaper; avrundning kan också tillämpas per hörn via geometrijusteringar.

**Hur fyller jag en rektangel med en bild (textur)?**

Välj bild‑[fill type](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/filltype/), ange bildkällan och konfigurera [stretching/tiling modes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/picturefillmode/).

**Kan en rektangel ha skugga och glöd?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/sv/androidjava/shape-effect/) är tillgängliga med justerbara parametrar.

**Kan jag göra om en rektangel till en knapp med en hyperlänk?**

Ja. [Assign a hyperlink](/slides/sv/androidjava/manage-hyperlinks/) till formens klick (hoppa till en bild, fil, webbadress eller e‑post).

**Hur kan jag skydda en rektangel från att flyttas och ändras?**

Använd form‑lås: du kan förbjuda flyttning, storleksändring, urval eller textredigering för att bevara layouten.

**Kan jag konvertera en rektangel till en rasterbild eller SVG?**

Ja. Du kan [render the shape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) till en bild med angiven storlek/skalning eller [export it as SVG](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) för vektoranvändning.

**Hur får jag snabbt de faktiska (effektiva) egenskaperna för en rektangel med hänsyn till tema och arv?**

[Use the shape’s effective properties](/slides/sv/androidjava/shape-effective-properties/): API:n returnerar beräknade värden som tar hänsyn till temastilar, layout och lokala inställningar, vilket förenklar formateringsanalys.