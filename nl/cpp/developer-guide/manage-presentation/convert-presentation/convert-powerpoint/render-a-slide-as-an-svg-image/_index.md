---
title: Presentatieslides renderen als SVG-afbeeldingen in C++
linktitle: Slide naar SVG
type: docs
weight: 50
url: /nl/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint naar SVG
- presentatie naar SVG
- slide naar SVG
- PPT naar SVG
- PPTX naar SVG
- PPT opslaan als SVG
- PPTX opslaan als SVG
- PPT exporteren naar SVG
- PPTX exporteren naar SVG
- slide renderen
- slide converteren
- slide exporteren
- vectorafbeelding
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe je PowerPoint‑slides kunt renderen als SVG‑afbeeldingen met Aspose.Slides voor C++. Hoogwaardige visuals met eenvoudige codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatieslides kunt renderen als SVG‑afbeeldingen met Aspose.Slides. Het beschrijft het SVG‑formaat en de voordelen ervan, waaronder schaalbaarheid, toegankelijkheid en geschiktheid voor webontwikkeling.

Je leert hoe je een presentatiedocument laadt, door de slides iterereert en elke slide opslaat als een afzonderlijk SVG‑bestand. Het artikel behandelt PowerPoint‑ en OpenDocument‑presentatieformaten, inclusief PPT, PPTX, ODP en PPS, en laat zien hoe je de conversie programmatisch kunt uitvoeren met de `Presentation`‑klasse en de `WriteAsSvg`‑methode.

## **SVG-indeling**

SVG—een afkorting voor Scalable Vector Graphics— is een standaardgrafiektype of -formaat dat wordt gebruikt om tweedimensionale afbeeldingen weer te geven. SVG slaat afbeeldingen op als vectoren in XML met details die hun gedrag of uiterlijk definiëren.

SVG is een van de weinige formaten voor afbeeldingen die zeer hoge eisen voldoen op het gebied van: schaalbaarheid, interactiviteit, prestaties, toegankelijkheid, programmeerbaarheid en meer. Om deze redenen wordt het vaak gebruikt in webontwikkeling.

Je wilt SVG‑bestanden misschien gebruiken wanneer je moet

- **druk je presentatie af in een *zeer groot formaat*.** SVG‑afbeeldingen kunnen opschalen tot elke resolutie of elk niveau. Je kunt SVG‑afbeeldingen zoveel keren verkleinen of vergroten als nodig, zonder kwaliteitsverlies.  
- **gebruik diagrammen en grafieken uit je slides in *verschillende media of platformen***. De meeste leessystemen kunnen SVG‑bestanden interpreteren.  
- **gebruik de *kleinste mogelijke afmetingen van afbeeldingen***. SVG‑bestanden zijn over het algemeen kleiner dan hun hoge‑resolutie‑equivalenten in andere formaten, vooral die op bitmap gebaseerd zijn (JPEG of PNG).

## **Render een slide als SVG‑afbeelding**

Aspose.Slides for C++ maakt het mogelijk om slides in je presentaties te exporteren als SVG‑afbeeldingen. Volg deze stappen om SVG‑afbeeldingen te genereren:

1. Maak een instantie van de `Presentation`‑klasse aan.  
2. Itereer door alle slides in de presentatie.  
3. Schrijf elke slide naar een eigen SVG‑bestand via `FileStream`.

{{% alert color="primary" %}} 
Je wilt misschien onze [gratis webapplicatie](https://products.aspose.app/slides/nl/conversion/ppt-to-svg) uitproberen waarin we de PPT‑naar‑SVG‑conversiefunctie van Aspose.Slides for C++ hebben geïmplementeerd. 
{{% /alert %}} 

Deze voorbeeldcode in C++ laat zien hoe je een PPT naar SVG kunt converteren met Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
        
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto fileName = String::Format(u"slide-{0}.svg", index);
    auto fileStream = System::MakeObject<FileStream>(fileName, FileMode::Create, FileAccess::Write);

    auto slide = pres->get_Slides()->idx_get(index);
    slide->WriteAsSvg(fileStream);
}
```

## **FAQ**

**Waarom kan de gegenereerde SVG er verschillend uitzien in verschillende browsers?**

Ondersteuning voor specifieke SVG‑functies wordt door verschillende browser‑engines anders geïmplementeerd. Parameters van [SVGOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgoptions/) helpen om incompatibiliteiten te verzachten.

**Is het mogelijk om niet alleen slides maar ook individuele vormen naar SVG te exporteren?**

Ja. Elke [vorm kan als een afzonderlijke SVG worden opgeslagen](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/writeassvg/), wat handig is voor iconen, pictogrammen en het hergebruiken van grafische elementen.

**Kunnen meerdere slides worden gecombineerd tot één SVG (strip/document)?**

Het standaardscenario is één slide → één SVG. Het combineren van meerdere slides tot één SVG‑canvas is een nabewerkingsstap die op toepassingsniveau wordt uitgevoerd.