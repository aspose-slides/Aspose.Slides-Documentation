---
title: Lägg till rektanglar i presentationer i Java
linktitle: Rektangel
type: docs
weight: 80
url: /sv/java/rectangle/
keywords:
- lägga till rektangel
- skapa rektangel
- rektangel form
- enkel rektangel
- formaterad rektangel
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Förbättra dina PowerPoint-presentationer genom att lägga till rektanglar med Aspose.Slides för Java – designa och ändra former enkelt via kod."
---
## **Översikt**

Den här artikeln visar hur man lägger till rektangelformer i PowerPoint‑bilder med hjälp av Aspose.Slides. Den täcker att skapa en enkel rektangel, skapa en formaterad rektangel och spara den uppdaterade presentationen som en PPTX‑fil.

Du kommer också att se hur man tillämpar grundläggande rektangelformatering, såsom en solid fyllnadsfärg, linjefärg och linjebredd. Dessutom pekar artikeln FAQ på relaterade rektangeluppgifter, inklusive rundade hörn, bildfyllningar, visuella effekter, hyperlänkar, form lås, exportalternativ och effektiva egenskaper.

## **Lägg till en rektangel på en bild**
För att lägga till en enkel rektangel på en vald bild i presentationen, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation)‑klassen.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAutoShape) av typen Rectangle med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection)‑objektet.
- Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en enkel rektangel på den första bilden i presentationen.

```java
// Skapa en Presentation-klass som representerar PPTX
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till AutoShape av ellipstyp
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Skriv PPTX-filen till disk
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lägg till en formaterad rektangel på en bild**
För att lägga till en formaterad rektangel på en bild, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation)‑klassen.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IAutoShape) av typen Rectangle med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection)‑objektet.
- Ställ in [Fill Type](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FillType) för rektangeln till Solid.
- Ställ in färgen på rektangeln med hjälp av metoden [SolidFillColor.setColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) som exponeras av [IFillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IFillFormat)‑objektet som är associerat med [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape)‑objektet.
- Ställ in färgen på rektangelns linjer.
- Ställ in bredden på rektangelns linjer.
- Skriv den modifierade presentationen som en PPTX‑fil.

Ovanstående steg är implementerade i exemplet nedan.

```java
// Instansiera Presentation-klassen som representerar PPTX
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till AutoShape av ellipstyp
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Applicera viss formatering på ellipsformen
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Applicera viss formatering på ellipsens linje
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

Använd den rundade hörn‑[shape type](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shapetype/) och justera hörnradien i formens egenskaper; avrundning kan även tillämpas per hörn via geometrijusteringar.

**Hur fyller jag en rektangel med en bild (textur)?**

Välj bild‑[fill type](https://reference.aspose.com/slides/sv/java/com.aspose.slides/filltype/), ange bildkällan och konfigurera [stretching/tiling modes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/picturefillmode/).

**Kan en rektangel ha skugga och glöd?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/sv/java/shape-effect/) är tillgängliga med justerbara parametrar.

**Kan jag göra en rektangel till en knapp med en hyperlänk?**

Ja. [Assign a hyperlink](/slides/sv/java/manage-hyperlinks/) till formens klick (hoppa till en bild, fil, webbadress eller e‑post).

**Hur kan jag skydda en rektangel från att flyttas och ändras?**

[Use shape locks](/slides/sv/java/applying-protection-to-presentation/): du kan förbjuda flyttning, storleksändring, markering eller textredigering för att bevara layouten.

**Kan jag konvertera en rektangel till en rasterbild eller SVG?**

Ja. Du kan [render the shape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getImage-int-float-float-) till en bild med en specificerad storlek/skala eller [export it as SVG](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) för vektorbruk.

**Hur får jag snabbt de faktiska (effektiva) egenskaperna för en rektangel med hänsyn till tema och arv?**

[Use the shape’s effective properties](/slides/sv/java/shape-effective-properties/): API‑et returnerar beräknade värden som tar hänsyn till temastilar, layout och lokala inställningar, vilket förenklar analys av formatering.