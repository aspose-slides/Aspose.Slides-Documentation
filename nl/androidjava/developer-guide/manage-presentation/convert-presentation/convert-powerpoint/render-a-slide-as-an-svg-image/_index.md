---
title: Renderen van presentatiedia's als SVG-afbeeldingen op Android
linktitle: Dia naar SVG
type: docs
weight: 50
url: /nl/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint naar SVG
- presentatie naar SVG
- dia naar SVG
- PPT naar SVG
- PPTX naar SVG
- PPT opslaan als SVG
- PPTX opslaan als SVG
- PPT exporteren naar SVG
- PPTX exporteren naar SVG
- dia renderen
- dia converteren
- dia exporteren
- vectorafbeelding
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint-dia's kunt renderen als SVG-afbeeldingen met Aspose.Slides voor Android. Hoogwaardige visuals met eenvoudige Java-codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatiedia's kunt renderen als SVG-afbeeldingen met Aspose.Slides. Het beschrijft het SVG-formaat en de voordelen, waaronder schaalbaarheid, toegankelijkheid en geschiktheid voor webontwikkeling.

U leert hoe u een presentatiebestand laadt, door de dia's iterereert en elke dia opslaat als een afzonderlijk SVG‑bestand. Het artikel behandelt PowerPoint- en OpenDocument-presentatieformaten, waaronder PPT, PPTX, ODP en PPS, en laat zien hoe u de conversie programmatisch kunt uitvoeren met de `Presentation`‑klasse en de `writeAsSvg`‑methode.

## **SVG-formaat**

SVG—een acroniem voor Scalable Vector Graphics— is een standaardgrafiektype of -formaat dat wordt gebruikt om tweedimensionale afbeeldingen te renderen. SVG slaat afbeeldingen op als vectoren in XML met details die hun gedrag of uiterlijk definiëren. 

SVG is een van de weinige afbeeldingsformaten die zeer hoge eisen vervult op het gebied van schaalbaarheid, interactiviteit, prestaties, toegankelijkheid, programmeerbaarheid en meer. Om deze redenen wordt het veel gebruikt in webontwikkeling. 

U wilt SVG‑bestanden mogelijk gebruiken wanneer u moet

- **uw presentatie afdrukken in een *zeer groot formaat*.** SVG-afbeeldingen kunnen opschalen tot elke resolutie of niveau. U kunt SVG-afbeeldingen zoveel keer opnieuw schalen als nodig, zonder kwaliteitsverlies.
- **grafieken en diagrammen uit uw dia's gebruiken in *verschillende media of platformen**.* De meeste lezers kunnen SVG‑bestanden interpreteren. 
- **de *kleinste mogelijke afbeeldingsgroottes* gebruiken**. SVG‑bestanden zijn over het algemeen kleiner dan hun hoge‑resolutie‑equivalenten in andere formaten, vooral formaten die op bitmap gebaseerd zijn (JPEG of PNG).

## **Een dia renderen als een SVG-afbeelding**

Aspose.Slides for Android via Java maakt het mogelijk om dia's in uw presentaties te exporteren als SVG-afbeeldingen. Volg deze stappen om SVG‑afbeeldingen te genereren:

1. Maak een instantie van de `Presentation`‑klasse aan.
2. Itereer door alle dia's in de presentatie.
3. Schrijf elke dia naar een eigen SVG‑bestand via `FileOutputStream`.

{{% alert color="primary" %}} 

U kunt onze [gratis webapplicatie](https://products.aspose.app/slides/nl/conversion/ppt-to-svg) uitproberen, waarin we de PPT‑naar‑SVG‑conversiefunctie van Aspose.Slides for Android via Java hebben geïmplementeerd.

{{% /alert %}} 

Deze voorbeeldcode in Java laat zien hoe u PPT naar SVG converteert met Aspose.Slides:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Waarom kan de resulterende SVG er verschillend uitzien in verschillende browsers?**

Ondersteuning voor specifieke SVG‑functies wordt door browser‑engines anders geïmplementeerd. Parameters van [SVGOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgoptions/) helpen incompatibiliteiten te verzachten.

**Is het mogelijk om niet alleen dia's, maar ook individuele vormen naar SVG te exporteren?**

Ja. Elke [vorm kan als een afzonderlijk SVG‑bestand worden opgeslagen](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), wat handig is voor iconen, pictogrammen en het hergebruiken van grafische elementen.

**Kunnen meerdere dia's worden gecombineerd tot één enkele SVG (strip/document)?**

Het standaardscenario is één dia → één SVG. Het combineren van meerdere dia's tot één enkel SVG‑canvas is een nabewerkingsstap die op applicatieniveau wordt uitgevoerd.