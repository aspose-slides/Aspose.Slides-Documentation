---
title: Beheer tags en aangepaste gegevens in presentaties met Python
linktitle: Tags en aangepaste gegevens
type: docs
weight: 300
url: /nl/python-net/managing-tags-and-custom-data/
keywords:
- documenteigenschappen
- tag
- aangepaste gegevens
- tag toevoegen
- paarwaarden
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u tags en aangepaste gegevens kunt toevoegen, lezen, bijwerken en verwijderen in Aspose.Slides voor Python via .NET, met voorbeelden voor PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides werkt met tags en aangepaste gegevens in PowerPoint‑presentaties. Het geeft een kort overzicht van hoe gegevens worden opgeslagen in PPTX‑bestanden, merkt op dat presentatiespecifieke gegevens kunnen bestaan als tags en aangepaste XML‑onderdelen, en beschrijft tags als sleutel‑waarde‑tekenreeksparen.

Het laat ook zien hoe je tag‑waarden kunt lezen en hoe je tags kunt toevoegen aan een presentatie, een individuele dia of een vorm. Daarnaast behandelt het artikel veelvoorkomende tag‑beheertaken zoals alle tags wissen, een tag op naam verwijderen en de lijst met tagnamen ophalen.

## **Gegevensopslag in presentatiebestanden**

PPTX‑bestanden — items met de extensie .pptx — worden opgeslagen in het PresentationML‑formaat, dat deel uitmaakt van de Office Open XML‑specificatie. Het Office Open XML‑formaat definieert de structuur voor gegevens die in presentaties zijn opgenomen. 

Met een *dia* als een van de elementen in presentaties bevat een *dia‑onderdeel* de inhoud van één dia. Een dia‑onderdeel mag expliciete relaties hebben met vele onderdelen — zoals User Defined Tags — zoals gedefinieerd in ISO/IEC 29500. 

Aangepaste gegevens (specifiek voor een presentatie) of gebruikers kunnen bestaan als tags ([ITagCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/itagcollection/)) en CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 
Tags zijn in wezen string‑sleutel‑paren. 
{{% /alert %}} 

## **Waarden van tags ophalen**

In Slides komt een tag overeen met de eigenschap IDocumentProperties.Keywords. Deze voorbeeldcode laat zien hoe je de waarde van een tag kunt ophalen met Aspose.Slides for Python via .NET voor [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Tags toevoegen aan presentaties**

Aspose.Slides stelt je in staat tags toe te voegen aan presentaties. Een tag bestaat doorgaans uit twee items: 

- de naam van een aangepaste eigenschap — `MyTag` 
- de waarde van de aangepaste eigenschap — `My Tag Value`

Als je presentaties wilt classificeren op basis van een specifieke regel of eigenschap, kun je baat hebben bij het toevoegen van tags aan die presentaties. Bijvoorbeeld, als je alle presentaties uit Noord‑Amerikaanse landen wilt groeperen, kun je een Noord‑Amerikaanse tag maken en vervolgens de relevante landen (de VS, Mexico en Canada) als waarden toewijzen. 

Deze voorbeeldcode laat zien hoe je een tag toevoegt aan een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) met Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Tags kunnen ook worden ingesteld voor [Slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Of voor een individuele [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Beperkingen**

Tags die via de `custom_data.tags`‑collectie worden toegevoegd, worden alleen binnen het PowerPoint‑bestand opgeslagen. Ze worden **niet** overgedragen naar de PDF‑tag‑structuur wanneer de presentatie wordt geëxporteerd naar PDF. Daardoor kan een aangepaste identifier die als tag is toegewezen niet worden opgehaald uit de getagde PDF.

**Workaround**: Je kunt een aangepaste identifier opslaan in de **Alt‑tekst** van het object (bijv. `shape.alternative_text = "MyId"`). Na het exporteren naar PDF kan de Alt‑tekst verschijnen in de PDF‑tag‑structuur.

## **Veelgestelde vragen**

**Kan ik alle tags uit een presentatie, dia of vorm in één bewerking verwijderen?**

Ja. De [tag collection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/tagcollection/) ondersteunt een [clear](https://reference.aspose.com/slides/nl/python-net/aspose.slides/tagcollection/clear/)‑bewerking die alle sleutel‑waarde‑paren in één keer verwijdert.

**Hoe verwijder ik een enkele tag op naam zonder de hele collectie te doorlopen?**

Gebruik de [remove(name)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/tagcollection/remove/)‑bewerking op [TagCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/tagcollection/) om de tag op zijn sleutel te verwijderen.

**Hoe kan ik de volledige lijst met tagnamen ophalen voor analyse of filtering?**

Gebruik [get_names_of_tags](https://reference.aspose.com/slides/nl/python-net/aspose.slides/tagcollection/get_names_of_tags/) op de [tag collection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/tagcollection/); dit retourneert een array met alle tagnamen.