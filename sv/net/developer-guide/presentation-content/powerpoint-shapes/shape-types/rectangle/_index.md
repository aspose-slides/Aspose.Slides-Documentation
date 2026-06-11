---
title: Lägg till rektanglar i presentationer i .NET
linktitle: Rektangel
type: docs
weight: 80
url: /sv/net/rectangle/
keywords:
- lägga till rektangel
- skapa rektangel
- rektangelform
- enkel rektangel
- formaterad rektangel
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Förbättra dina PowerPoint-presentationer genom att lägga till rektanglar med Aspose.Slides för .NET—designa och modifiera former enkelt via kod."
---
## **Översikt**

Denna artikel visar hur man lägger till rektangelformer i PowerPoint‑bilder med hjälp av Aspose.Slides. Den täcker att skapa en enkel rektangel, skapa en formaterad rektangel och spara den uppdaterade presentationen som en PPTX‑fil.

Du kommer också att se hur du använder grundläggande rektangelformatering, såsom en solid fyllningsfärg, linjefärg och linjebredd. Dessutom pekar artikelns FAQ på relaterade rektangeluppgifter, inklusive rundade hörn, bildfyllningar, visuella effekter, hyperlänkar, formlåsningsalternativ, exportalternativ och effektiva egenskaper.

## **Skapa en enkel rektangel**
Liksom tidigare ämnen handlar detta också om att lägga till en form och den här gången är formen vi kommer att diskutera en Rektangel. I detta ämne har vi beskrivit hur utvecklare kan lägga till enkla eller formaterade rektanglar i sina bilder med Aspose.Slides för .NET. För att lägga till en enkel rektangel på ett valt bild i presentationen, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)-klassen.
2. Hämta referensen till en bild genom att använda dess Index.
3. Lägg till en IAutoShape av typen Rectangle med hjälp av AddAutoShape‑metoden som exponeras av IShapes‑objektet.
4. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en enkel rektangel på den första bilden i presentationen.

```c#
// Skapa en instans av Presentation-klassen som representerar PPTX-filen
using (Presentation pres = new Presentation())
{
    // Hämta den första bilden
    ISlide sld = pres.Slides[0];

    // Lägg till en autoshape av typ rektangel
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //Skriv PPTX-filen till disk
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```

## **Skapa en formaterad rektangel**
För att lägga till en formaterad rektangel på en bild, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)-klassen.
2. Hämta referensen till en bild genom att använda dess Index.
3. Lägg till en IAutoShape av typen Rectangle med hjälp av AddAutoShape‑metoden som exponeras av IShapes‑objektet.
4. Ställ in fyllningstypen för rektangeln till Solid.
5. Ställ in färgen på rektangeln med egenskapen SolidFillColor.Color som exponeras av FillFormat‑objektet som är associerat med IShape‑objektet.
6. Ställ in färgen på rektangelns linjer.
7. Ställ in bredden på rektangelns linjer.
8. Skriv den modifierade presentationen som en PPTX‑fil.

Stegen ovan implementeras i exemplet nedan.

```c#
// Skapa en instans av Presentation-klassen som representerar PPTX-filen
using (Presentation pres = new Presentation())
{

    // Hämta den första bilden
    ISlide sld = pres.Slides[0];

    // Lägg till en autoshape av typen rektangel
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Använd lite formatering på rektangelformen
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Använd lite formatering på rektangelns linje
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Write PPTX-filen till disk
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Hur lägger jag till en rektangel med rundade hörn?**

Använd den rundade hörn‑[formtypen](https://reference.aspose.com/slides/sv/net/aspose.slides/shapetype/) och justera hörnradien i formens egenskaper; avrundning kan även appliceras per hörn via geometrijusteringar.

**Hur fyller jag en rektangel med en bild (textur)?**

Välj bild‑[fyllningstyp](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/), ange bildkällan och konfigurera [sträcknings‑/tilingslägen](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillmode/).

**Kan en rektangel ha skugga och glöd?**

Ja. [Yttre/inre skugga, glöd och mjuka kanter](/slides/sv/net/shape-effect/) är tillgängliga med justerbara parametrar.

**Kan jag göra om en rektangel till en knapp med en hyperlänk?**

Ja. [Tilldela en hyperlänk](/slides/sv/net/manage-hyperlinks/) till formens klick (hoppa till en bild, fil, webbadress eller e‑post).

**Hur kan jag skydda en rektangel från att flyttas och ändras?**

[Använd formlåsningsfunktioner](/slides/sv/net/applying-protection-to-presentation/): du kan förbjuda flyttning, storleksändring, markering eller textredigering för att bevara layouten.

**Kan jag konvertera en rektangel till en rasterbild eller SVG?**

Ja. Du kan [rendera formen](http://reference.aspose.com/slides/sv/net/aspose.slides/shape/getimage/) till en bild med angiven storlek/skalning eller [exportera den som SVG](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/writeassvg/) för vektorbruk.

**Hur får jag snabbt de faktiska (effektiva) egenskaperna för en rektangel med hänsyn till tema och arv?**

[Använd formens effektiva egenskaper](/slides/sv/net/shape-effective-properties/): API‑t returnerar beräknade värden som tar hänsyn till temastilar, layout och lokala inställningar, vilket förenklar formateringsanalys.