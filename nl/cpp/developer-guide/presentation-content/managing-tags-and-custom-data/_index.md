---
title: Beheer tags en aangepaste gegevens in presentaties met C++
linktitle: Tags en aangepaste gegevens
type: docs
weight: 300
url: /nl/cpp/managing-tags-and-custom-data/
keywords:
- documenteigenschappen
- tag
- aangepaste gegevens
- tag toevoegen
- waardeparen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u tags en aangepaste gegevens kunt toevoegen, lezen, bijwerken en verwijderen in Aspose.Slides voor C++, met voorbeelden voor PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe Aspose.Slides werkt met tags en aangepaste gegevens in PowerPoint‑presentaties. Het schetst kort hoe gegevens worden opgeslagen in PPTX‑bestanden, merkt op dat presentatiespecifieke gegevens kunnen bestaan als tags en aangepaste XML‑onderdelen, en beschrijft tags als sleutel‑waarde‑tekenreeksparen.

Het laat ook zien hoe tag‑waarden gelezen kunnen worden en hoe tags toegevoegd kunnen worden aan een presentatie, een individuele dia of een vorm. Daarnaast behandelt het artikel veelvoorkomende tag‑beheer taken zoals alle tags wissen, een tag verwijderen op naam, en de lijst van tag‑namen opvragen.

## **Gegevensopslag in presentatiebestanden**

PPTX‑bestanden — items met de extensie .pptx — worden opgeslagen in het PresentationML‑formaat, dat deel uitmaakt van de Office Open XML‑specificatie. Het Office Open XML‑formaat definieert de structuur voor gegevens die zich in presentaties bevinden.  

Met een *slide* als een van de elementen in presentaties, bevat een *slide part* de inhoud van één dia. Een slide‑part mag expliciete relaties hebben met veel onderdelen — zoals User Defined Tags — gedefinieerd door ISO/IEC 29500.  

Aangepaste gegevens (specifiek voor een presentatie) of gebruiker kunnen bestaan als tags ([ITagCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itagcollection/)) en CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icustomxmlpartcollection/)).  

{{% alert color="primary" %}}  
Tags zijn in feite tekenreeks‑sleutel‑paar waarden.  
{{% /alert %}}  

## **Waarden van tags ophalen**

In Slides komt een tag overeen met de eigenschap IDocumentProperties.Keywords. Deze voorbeeldcode laat zien hoe je de waarde van een tag ophaalt met Aspose.Slides voor C++ voor [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Tags toevoegen aan presentaties**

Aspose.Slides stelt je in staat tags toe te voegen aan presentaties. Een tag bestaat doorgaans uit twee onderdelen:

- de naam van een aangepaste eigenschap - `MyTag`  
- de waarde van de aangepaste eigenschap - `My Tag Value`

Als je enkele presentaties wilt classificeren op basis van een specifieke regel of eigenschap, kun je profiteren van het toevoegen van tags. Bijvoorbeeld, als je alle presentaties uit Noord‑Amerikaanse landen wilt groeperen, kun je een Noord‑Amerikaanse tag maken en vervolgens de relevante landen (de VS, Mexico en Canada) als waarden toewijzen.  

Deze voorbeeldcode toont hoe je een tag toevoegt aan een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) met Aspose.Slides voor C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Tags kunnen ook worden ingesteld voor [Slide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Of voor een individuele [Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Beperkingen**

Tags die via de aangepaste data‑tag‑collectie met `get_CustomData()->get_Tags()` worden toegevoegd, worden alleen in het PowerPoint‑bestand opgeslagen. Ze worden **niet** overgebracht naar de PDF‑tag‑structuur wanneer de presentatie naar PDF wordt geëxporteerd. Daardoor kan een aangepast identifier dat als tag is toegewezen niet worden opgehaald uit de getagde PDF.

**Workaround**: Je kunt een aangepast identifier opslaan in de **Alt Text** van het object (bijv. `shape->set_AlternativeText(u"MyId")`). Na exporteren naar PDF kan de Alt Text in de PDF‑tag‑structuur verschijnen.

## **Veelgestelde vragen**

**Kan ik alle tags uit een presentatie, dia of vorm in één keer verwijderen?**

Ja. De [tag collection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/tagcollection/) ondersteunt een [clear](https://reference.aspose.com/slides/nl/cpp/aspose.slides/tagcollection/clear/)‑bewerking die alle sleutel‑waarde‑paren in één keer verwijdert.

**Hoe verwijder ik een enkele tag op naam zonder de hele collectie te doorlopen?**

Gebruik de [Remove(name)](https://reference.aspose.com/slides/nl/cpp/aspose.slides/tagcollection/remove/)‑bewerking op [TagCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/tagcollection/) om de tag op zijn sleutel te verwijderen.

**Hoe kan ik de volledige lijst van tag‑namen ophalen voor analyses of filtering?**

Gebruik [GetNamesOfTags](https://reference.aspose.com/slides/nl/cpp/aspose.slides/tagcollection/getnamesoftags/) op de [tag collection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/tagcollection/); het retourneert een array met alle tag‑namen.