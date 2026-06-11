---
title: Lägg till vattenmärken i presentationer i Python
linktitle: Vattenmärke
type: docs
weight: 40
url: /sv/python-net/watermark/
keywords:
- vattenmärke
- textvattenmärke
- bildvattenmärke
- lägg till vattenmärke
- ändra vattenmärke
- ta bort vattenmärke
- radera vattenmärke
- lägg till vattenmärke i PPT
- lägg till vattenmärke i PPTX
- lägg till vattenmärke i ODP
- ta bort vattenmärke från PPT
- ta bort vattenmärke från PPTX
- ta bort vattenmärke från ODP
- radera vattenmärke från PPT
- radera vattenmärke från PPTX
- radera vattenmärke från ODP
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du hanterar text- och bildvattenmärken i PowerPoint- och OpenDocument-presentationer i Python för att ange ett utkast, konfidentiell information, upphovsrätt och mer."
---
## **Introduktion**

**Ett vattenmärke** i en presentation är en text- eller bildstämpel som används på en bild eller genom alla presentationsbilder. Vanligtvis används ett vattenmärke för att indikera att presentationen är ett utkast (t.ex. ett "Utkast"-vattenmärke), att den innehåller konfidentiell information (t.ex. ett "Konfidentiellt"-vattenmärke), för att ange vilket företag den tillhör (t.ex. ett "Företagsnamn"-vattenmärke), för att identifiera författaren till presentationen osv. Ett vattenmärke hjälper till att förhindra upphovsrättsintrång genom att ange att presentationen inte får kopieras. Vattenmärken används i både PowerPoint- och OpenOffice-presentationsformat. I Aspose.Slides kan du lägga till ett vattenmärke i PowerPoint PPT-, PPTX- och OpenOffice ODP-filformat.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/python-net/) finns det olika sätt att skapa vattenmärken i PowerPoint- eller OpenOffice-dokument och ändra deras design och beteende. Det gemensamma är att för att lägga till textvattenmärken bör du använda klassen [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/), och för att lägga till bildvattenmärken, använd klassen [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) eller fyll en vattenmärkesform med en bild. `PictureFrame` implementerar klassen [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/), vilket gör att du kan använda alla flexibla inställningar för formobjektet. Eftersom `TextFrame` inte är en form och dess inställningar är begränsade, omsluts den i ett [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/)‑objekt.

Det finns två sätt att applicera ett vattenmärke: på en enda bild eller på alla presentationsbilder. Slide Master används för att applicera ett vattenmärke på alla presentationsbilder — vattenmärket läggs till i Slide Master, designas helt där och tillämpas på alla bilder utan att påverka möjligheten att redigera vattenmärket på enskilda bilder.

Ett vattenmärke anses vanligtvis vara otillgängligt för redigering av andra användare. För att förhindra att vattenmärket (eller snarare dess överordnade form) redigeras, erbjuder Aspose.Slides funktionalitet för låsning av former. En specifik form kan låsas på en vanlig bild eller på en Slide Master. När vattenmärkesformen låses på Slide Master, låses den på alla presentationsbilder.

Du kan ange ett namn för vattenmärket så att du i framtiden, om du vill ta bort det, kan hitta det bland bildens former efter namn.

Du kan utforma vattenmärket på vilket sätt som helst; det finns dock vanligtvis gemensamma egenskaper i vattenmärken, såsom centrering, rotation, förgrundsposition osv. Vi kommer att gå igenom hur man använder dessa i exemplen nedan.

## **Textvattenmärke**

### **Lägg till ett textvattenmärke på en bild**

För att lägga till ett textvattenmärke i PPT, PPTX eller ODP kan du först lägga till en form på bilden och sedan lägga till en textram i den formen. Textramen representeras av klassen [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/). Denna typ är inte ärvd från [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/), som har ett brett urval av egenskaper för att placera vattenmärket på ett flexibelt sätt. Därför omsluts [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/)‑objektet i ett [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/)‑objekt. För att lägga till vattenmärketext till formen, använd metoden [add_text_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/add_text_frame/#str) som visas nedan.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Se också" %}} 
- [Hur man använder TextFrame-klassen](/slides/sv/python-net/text-formatting/)
{{% /alert %}}

### **Lägg till ett textvattenmärke i en presentation**

Om du vill lägga till ett textvattenmärke i hela presentationen (dvs. alla bilder på en gång), lägg till det i [MasterSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/masterslide/). Resten av logiken är densamma som när du lägger till ett vattenmärke på en enda bild — skapa ett [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/)‑objekt och lägg sedan till vattenmärket i det med hjälp av metoden [add_text_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Se också" %}} 
- [Hur man använder Slide Master](/slides/sv/python-net/slide-master/)
{{% /alert %}}

### **Ställ in vattenmärkesformens transparens**

Som standard är rektangelformen stiliserad med fyllnings- och linjefärger. Följande kodrader gör formen transparent.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Ställ in teckensnitt för ett textvattenmärke**

Du kan ändra teckensnittet för textvattenmärket som visas nedan.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Ställ in färgen på vattenmärketexten**

För att ange färgen på vattenmärketexten, använd följande kod:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Centrera ett textvattenmärke**

Det är möjligt att centrera vattenmärket på en bild, och för att göra det kan du göra följande:

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

Bilden nedan visar slutresultatet.

![Textvattenmärket](text_watermark.png)

## **Bildvattenmärke**

### **Lägg till ett bildvattenmärke i en presentation**

För att lägga till ett bildvattenmärke i en presentationsbild kan du göra följande:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Lås ett vattenmärke från redigering**

Om det är nödvändigt att förhindra att ett vattenmärke redigeras, använd egenskapen [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/auto_shape_lock/) på formen. Med denna egenskap kan du skydda formen från att väljas, ändras i storlek, flyttas, grupperas med andra element, låsa dess text från redigering och mycket mer:

```py
# Lås vattenmärkesformen från att ändras
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Flytta ett vattenmärke till framkant**

I Aspose.Slides kan Z‑ordningen för former sättas via metoden [ShapeCollection.reorder](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). För att göra detta måste du anropa metoden från presentationsbildlistan och skicka in formreferensen samt dess ordningsnummer. På så sätt är det möjligt att flytta en form framåt eller skicka den bakåt på bilden. Denna funktion är särskilt användbar om du behöver placera ett vattenmärke framför presentationen:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Ställ in rotation för vattenmärke**

Här är ett kodexempel på hur du justerar rotationen på vattenmärket så att det placeras diagonalt över bilden:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Ange ett namn för ett vattenmärke**

Aspose.Slides låter dig ange ett namn för en form. Genom att använda formens namn kan du i framtiden komma åt den för att ändra eller ta bort den. För att ange namnet på vattenmärkesformen, tilldela det till egenskapen [AutoShape.name](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "watermark"
```

## **Ta bort ett vattenmärke**

För att ta bort vattenmärkesformen, använd metoden [AutoShape.name](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/name/) för att hitta den bland bildens former. Därefter, skicka vattenmärkesformen till metoden [ShapeCollection.remove](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Ett levande exempel**

Du kanske vill titta på de **gratis Aspose.Slides**-verktygen online för [Lägg till vattenmärke](https://products.aspose.app/slides/sv/watermark) och [Ta bort vattenmärke](https://products.aspose.app/slides/sv/watermark/remove-watermark).

![Onlineverktyg för att lägga till och ta bort vattenmärken](online_tools.png)

## **FAQ**

**Vad är ett vattenmärke och varför bör jag använda det?**

Ett vattenmärke är en text- eller bildöverlagring som appliceras på bilder och som hjälper till att skydda immateriella rättigheter, stärka varumärkesigenkänning eller förhindra obehörig användning av presentationer.

**Kan jag lägga till ett vattenmärke på alla bilder i en presentation?**

Ja, Aspose.Slides låter dig lägga till ett vattenmärke på varje bild i en presentation. Du kan iterera genom alla bilder och applicera vattenmärkesinställningarna individuellt.

**Hur kan jag justera transparensen för vattenmärket?**

Du kan justera transparensen för vattenmärket genom att ändra fyllningsinställningarna ([FillFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fillformat/)) för formen. Detta säkerställer att vattenmärket är subtilt och inte distraherar från bildens innehåll.

**Vilka bildformat stödjs för vattenmärken?**

Aspose.Slides stödjer olika bildformat såsom PNG, JPEG, GIF, BMP, SVG med mera.

**Kan jag anpassa teckensnitt och stil för ett textvattenmärke?**

Ja, du kan välja vilket teckensnitt, storlek och stil som helst för att matcha designen på din presentation och upprätthålla varumärkeskonsekvens.

**Hur ändrar jag position eller orientering av ett vattenmärke?**

Du kan justera position och orientering av vattenmärket genom att ändra formens koordinater, storlek och rotationsegenskaper.