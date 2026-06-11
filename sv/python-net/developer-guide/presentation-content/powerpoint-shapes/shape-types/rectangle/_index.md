---
title: Lägg till rektanglar i presentationer i Python
linktitle: Rektangel
type: docs
weight: 80
url: /sv/python-net/rectangle/
keywords:
- lägga till rektangel
- skapa rektangel
- rektangelform
- enkel rektangel
- formaterad rektangel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Förbättra dina PowerPoint- och OpenDocument-presentationer genom att lägga till rektanglar med Aspose.Slides för Python via .NET - designa och modifiera former programvarumässigt enkelt."
---
## **Översikt**

Denna artikel visar hur du lägger till rektangelformer i PowerPoint‑bilder med hjälp av Aspose.Slides. Den täcker att skapa en enkel rektangel, skapa en formaterad rektangel och spara den uppdaterade presentationen som en PPTX‑fil.

Du kommer också att se hur du tillämpar grundläggande formatering för rektanglar, såsom en solid fyllningsfärg, linjefärg och linjebredd. Dessutom pekar artikelns FAQ på relaterade rektangeluppgifter, inklusive rundade hörn, bildfyllningar, visuella effekter, hyperlänkar, lås för former, exportalternativ och effektiva egenskaper.

## **Skapa en enkel rektangel**
Precis som tidigare ämnen handlar detta också om att lägga till en form och den här gången är formen vi kommer att diskutera en Rektangel. I detta avsnitt har vi beskrivit hur utvecklare kan lägga till enkla eller formaterade rektanglar i sina bilder med Aspose.Slides för Python via .NET. För att lägga till en enkel rektangel på ett valt bild i presentationen, följ stegen nedan:

1. Skapa en instans av [Presentation ](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)klassen.
2. Hämta referensen till en bild genom att använda dess Index.
3. Lägg till en IAutoShape av typen Rectangle med hjälp av AddAutoShape‑metoden som exponeras av IShapes‑objektet.
4. Skriv den ändrade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en enkel rektangel på den första bilden i presentationen.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar PPTX
with slides.Presentation() as pres:
    # Hämta den första bilden
    sld = pres.slides[0]

    # Lägg till autoshape av rektangeltyp
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Skriv PPTX-filen till disk
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Skapa en formaterad rektangel**
För att lägga till en formaterad rektangel på en bild, följ stegen nedan:

1. Skapa en instans av [Presentation ](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)klassen.
2. Hämta referensen till en bild genom att använda dess Index.
3. Lägg till en IAutoShape av typen Rectangle med hjälp av AddAutoShape‑metoden som exponeras av IShapes‑objektet.
4. Ställ in fyllningstypen för rektangeln till Solid.
5. Ange färgen på rektangeln med egenskapen SolidFillColor.Color som exponeras av FillFormat‑objektet som är kopplat till IShape‑objektet.
6. Ställ in färgen på rektangelns linjer.
7. Ställ in bredden på rektangelns linjer.
8. Skriv den ändrade presentationen som en PPTX‑fil.

Ovanstående steg implementeras i exemplet nedan.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instansiera Presentation-klassen som representerar PPTX
with slides.Presentation() as pres:
    # Hämta den första bilden
    sld = pres.slides[0]

    # Lägg till autoshape av rektangeltyp
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Tillämpa någon formatering på rektangelformen
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Tillämpa någon formatering på rektangelns linje
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Skriv PPTX-filen till disk
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Hur lägger jag till en rektangel med rundade hörn?**

Använd den rundade hörn‑[shapetypen](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapetype/) och justera hörnradien i formens egenskaper; avrundning kan även tillämpas per hörn via geometrijusteringar.

**Hur fyller jag en rektangel med en bild (textur)?**

Välj bild‑[fyllningstyp](https://reference.aspose.com/slides/sv/python-net/aspose.slides/filltype/), ange bildkällan och konfigurera [stretching/tiling‑lägen](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillmode/).

**Kan en rektangel ha skugga och glöd?**

Ja. [Yttre/inre skugga, glöd och mjuka kanter](/slides/sv/python-net/shape-effect/) är tillgängliga med justerbara parametrar.

**Kan jag göra om en rektangel till en knapp med en hyperlänk?**

Ja. [Tilldela en hyperlänk](/slides/sv/python-net/manage-hyperlinks/) till formens klick (hoppa till en bild, fil, webbadress eller e‑post).

**Hur kan jag skydda en rektangel från att flyttas och ändras?**

[Använd låsning av former](/slides/sv/python-net/applying-protection-to-presentation/): du kan förbjuda flytt, storleksändring, markering eller textredigering för att bevara layouten.

**Kan jag konvertera en rektangel till en rasterbild eller SVG?**

Ja. Du kan [rendera formen](http://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_image/) till en bild med specificerad storlek/skala eller [exportera den som SVG](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/write_as_svg/) för vektorbruk.

**Hur får jag snabbt de faktiska (effektiva) egenskaperna för en rektangel med hänsyn till tema och arv?**

[Använd formens effektiva egenskaper](/slides/sv/python-net/shape-effective-properties/): API‑et returnerar beräknade värden som tar hänsyn till temastilar, layout och lokala inställningar, vilket förenklar analysen av formatering.