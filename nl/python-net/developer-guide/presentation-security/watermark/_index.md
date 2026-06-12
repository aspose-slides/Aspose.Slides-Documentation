---
title: Watermerken toevoegen aan presentaties in Python
linktitle: Watermerk
type: docs
weight: 40
url: /nl/python-net/watermark/
keywords:
- watermerk
- tekstwatermerk
- afbeeldingswatermerk
- watermerk toevoegen
- watermerk wijzigen
- watermerk verwijderen
- watermerk verwijderen
- watermerk toevoegen aan PPT
- watermerk toevoegen aan PPTX
- watermerk toevoegen aan ODP
- watermerk verwijderen van PPT
- watermerk verwijderen van PPTX
- watermerk verwijderen van ODP
- watermerk verwijderen van PPT
- watermerk verwijderen van PPTX
- watermerk verwijderen van ODP
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u tekst- en afbeeldingswatermerken in PowerPoint- en OpenDocument-presentaties in Python kunt beheren om een concept, vertrouwelijke informatie, auteursrecht en meer aan te geven."
---
## **Introductie**

**Een watermerk** in een presentatie is een tekst‑ of afbeeldingstempel die op een dia of op alle dia’s van de presentatie wordt toegepast. Meestal wordt een watermerk gebruikt om aan te geven dat de presentatie een concept is (bijv. een “Concept‑watermerk”), dat deze vertrouwelijke informatie bevat (bijv. een “Vertrouwelijk‑watermerk”), om te specificeren van welk bedrijf hij afkomstig is (bijv. een “Bedrijfsnaam‑watermerk”), om de auteur van de presentatie te identificeren, enzovoort. Een watermerk helpt auteursrechtsschendingen te voorkomen doordat het aangeeft dat de presentatie niet gekopieerd mag worden. Watermerken worden zowel in PowerPoint‑ als in OpenOffice‑presentatieformaten gebruikt. In Aspose.Slides kun je een watermerk toevoegen aan PowerPoint‑PPT, PPTX en OpenOffice‑ODP‑bestandsformaten.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/python-net/), zijn er verschillende manieren om watermerken in PowerPoint‑ of OpenOffice‑documenten te maken en hun ontwerp en gedrag aan te passen. Het gemeenschappelijke punt is dat je voor tekst‑watermerken de [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/)‑klasse moet gebruiken, en voor afbeelding‑watermerken de [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/)‑klasse of een vorm met een afbeelding vult. `PictureFrame` implementeert de [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/)‑klasse, waardoor je alle flexibele instellingen van het vormobject kunt gebruiken. Omdat `TextFrame` geen vorm is en de instellingen beperkt zijn, wordt het verpakt in een [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/)‑object.

Er zijn twee manieren waarop een watermerk kan worden toegepast: op één enkele dia of op alle presentatiedia’s. De Slide Master wordt gebruikt om een watermerk op alle dia’s toe te passen — het watermerk wordt aan de Slide Master toegevoegd, daar volledig ontworpen, en vervolgens op alle dia’s toegepast zonder de mogelijkheid om het watermerk op individuele dia’s te wijzigen.

Een watermerk wordt doorgaans beschouwd als niet bewerkbaar door andere gebruikers. Om te voorkomen dat het watermerk (of beter gezegd de bovenliggende vorm van het watermerk) wordt bewerkt, biedt Aspose.Slides vergrendelingsfunctionaliteit voor vormen. Een specifieke vorm kan vergrendeld worden op een normale dia of op een Slide Master. Wanneer de watermerk­vorm op de Slide Master vergrendeld is, is deze vergrendeld op alle presentatiedia’s.

Je kunt een naam toekennen aan het watermerk, zodat je het later, bijvoorbeeld bij verwijderen, kunt vinden in de vormen van de dia op naam.

Je kunt het watermerk op elke gewenste manier ontwerpen; er zijn echter meestal gemeenschappelijke eigenschappen, zoals centreren, roteren, naar voren brengen, enzovoort. Hieronder laten we zien hoe je deze kunt gebruiken.

## **Tekst‑watermerk**

### **Een tekst‑watermerk aan een dia toevoegen**

Om een tekst‑watermerk toe te voegen in PPT, PPTX of ODP, kun je eerst een vorm aan de dia toevoegen en vervolgens een tekstkader aan die vorm. Het tekstkader wordt vertegenwoordigd door de [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/)‑klasse. Dit type is niet afgeleid van [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/), dat een breed scala aan eigenschappen biedt voor flexibele positionering van het watermerk. Daarom wordt het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/)‑object verpakt in een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/)‑object. Om tekst aan de vorm toe te voegen, gebruik je de [add_text_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/add_text_frame/#str)‑methode zoals hieronder weergegeven.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Zie ook" %}} 
- [Hoe de TextFrame‑klasse te gebruiken](/slides/nl/python-net/text-formatting/)
{{% /alert %}}

### **Een tekst‑watermerk aan een volledige presentatie toevoegen**

Als je een tekst‑watermerk aan de hele presentatie (dus alle dia’s tegelijk) wilt toevoegen, plaats je het in de [MasterSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslide/). De rest van de logica is dezelfde als bij het toevoegen aan een enkele dia — maak een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/)‑object en voeg vervolgens het watermerk toe met de [add_text_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/add_text_frame/#str)‑methode.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Zie ook" %}} 
- [Hoe de Slide Master te gebruiken](/slides/nl/python-net/slide-master/)
{{% /alert %}}

### **Transparantie van de watermerkvorm instellen**

Standaard wordt de rechthoekige vorm opgemaakt met opvul‑ en lijneqkleuren. De volgende code maakt de vorm transparant.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Lettertype voor een tekst‑watermerk instellen**

Je kunt het lettertype van het tekst‑watermerk wijzigen zoals hieronder weergegeven.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Kleur van de watermerktekst instellen**

Om de kleur van de watermerktekst in te stellen, gebruik je deze code:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Een tekst‑watermerk centreren**

Het is mogelijk om het watermerk op een dia te centreren; daarvoor kun je het volgende doen:

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

De afbeelding hieronder toont het eindresultaat.

![Het tekstwatermerk](text_watermark.png)

## **Afbeeldings‑watermerk**

### **Een afbeelding‑watermerk aan een presentatie toevoegen**

Om een afbeelding‑watermerk aan een presentatiedia toe te voegen, kun je het volgende doen:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Een watermerk tegen bewerken beveiligen**

Indien je een watermerk wilt voorkomen dat het bewerkt wordt, gebruik je de [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/auto_shape_lock/)‑eigenschap op de vorm. Met deze eigenschap kun je de vorm beschermen tegen selectie, grootte‑verandering, verplaatsing, groeperen met andere elementen, het tekstgedeelte vergrendelen tegen bewerken, en meer:

```py
# Vergrendel de watermerkvorm tegen wijziging
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Een watermerk naar voren brengen**

In Aspose.Slides kan de Z‑volgorde van vormen worden ingesteld via de [ShapeCollection.reorder](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ishapecollection/reorder/#int-ishape)‑methode. Roep deze methode aan vanuit de lijst met presentatiedia’s en geef de vormreferentie en het gewenste volgnummer door. Op die manier kun je een vorm naar voren halen of naar achteren sturen op de dia. Deze functionaliteit is vooral handig wanneer je een watermerk voor de presentatie wilt plaatsen:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Rotatie van een watermerk instellen**

Hier is een code‑voorbeeld hoe je de rotatie van het watermerk kunt aanpassen zodat het diagonaal over de dia wordt geplaatst:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Een naam toekennen aan een watermerk**

Aspose.Slides stelt je in staat een naam aan een vorm toe te wijzen. Met de vormnaam kun je later de vorm vinden om deze te wijzigen of te verwijderen. Om de naam van de watermerkvorm in te stellen, ken je deze toe aan de [AutoShape.name](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/name/)‑eigenschap:

```py
watermark_shape.name = "watermark"
```

## **Een watermerk verwijderen**

Om de watermerkvorm te verwijderen, gebruik je de [AutoShape.name](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/name/)‑methode om deze in de dia‑vormen te vinden. Vervolgens geef je de watermerkvorm door aan de [ShapeCollection.remove](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/remove/#ishape)‑methode:

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Een live‑voorbeeld**

Je kunt de **Aspose.Slides free**‑tools **Add Watermark**(https://products.aspose.app/slides/nl/watermark) en **Remove Watermark**(https://products.aspose.app/slides/nl/watermark/remove-watermark) online uitproberen.

![Online tools om watermerken toe te voegen en te verwijderen](online_tools.png)

## **FAQ**

**Wat is een watermerk en waarom zou ik het gebruiken?**

Een watermerk is een tekst‑ of afbeeldingsoverlay die op dia’s wordt toegepast en helpt intellectueel eigendom te beschermen, merkherkenning te verhogen of ongeautoriseerd gebruik van presentaties te voorkomen.

**Kan ik een watermerk aan alle dia’s van een presentatie toevoegen?**

Ja, Aspose.Slides maakt het mogelijk om een watermerk aan elke dia van een presentatie toe te voegen. Je kunt door alle dia’s itereren en de watermerk‑instellingen individueel toepassen.

**Hoe kan ik de transparantie van het watermerk aanpassen?**

Je kunt de transparantie aanpassen door de opvulinstellingen ([FillFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fillformat/)) van de vorm te wijzigen. Zo blijft het watermerk subtiel en afleidt het niet van de inhoud van de dia.

**Welke afbeeldingformaten worden ondersteund voor watermerken?**

Aspose.Slides ondersteunt diverse afbeeldingformaten zoals PNG, JPEG, GIF, BMP, SVG en meer.

**Kan ik het lettertype en de stijl van een tekst‑watermerk aanpassen?**

Ja, je kunt elk lettertype, grootte en stijl kiezen om aan te sluiten bij het ontwerp van je presentatie en de merkconsistentie te behouden.

**Hoe wijzig ik de positie of oriëntatie van een watermerk?**

Je kunt positie en oriëntatie aanpassen door de coördinaten, grootte en rotatie‑eigenschappen van de [shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/) te wijzigen.