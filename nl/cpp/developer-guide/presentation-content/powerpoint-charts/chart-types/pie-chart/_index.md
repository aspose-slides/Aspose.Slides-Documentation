---
title: "Pas taartdiagrammen aan in presentaties met C++"
linktitle: "Taartdiagram"
type: docs
url: /nl/cpp/pie-chart/
keywords:
- "taartdiagram"
- "diagram beheren"
- "diagram aanpassen"
- "diagramopties"
- "diagraminstellingen"
- "plotopties"
- "segmentkleur"
- "PowerPoint"
- "presentatie"
- "C++"
- "Aspose.Slides"
description: "Leer hoe je taartdiagrammen maakt en aanpast in C++ met Aspose.Slides, exporteerbaar naar PowerPoint, waardoor je gegevensverhaal in enkele seconden wordt versterkt."
---
## **Overzicht**

Dit artikel legt uit hoe je met taartdiagrammen in Aspose.Slides werkt. Het laat zien hoe je secundaire plotopties voor Pie of Pie‑ en Bar of Pie‑diagrammen kunt configureren en hoe je automatische kleurtoewijzing van segmenten voor een standaard taartdiagram kunt inschakelen.

De voorbeelden richten zich op praktische stappen voor het aanpassen van diagrammen, zoals het toevoegen van een diagram aan een dia, het aanpassen van series‑ en labelinstellingen, het vervangen van standaard diagramgegevens door aangepaste categorieën en waarden, en het opslaan van de bijgewerkte presentatie.

## **Secundaire plotopties voor Pie of Pie- en Bar of Pie-diagrammen**
Aspose.Slides for C++ ondersteunt nu tweede plotopties voor Pie of Pie‑ of Bar of Pie‑diagrammen. In dit onderwerp laten we met een voorbeeld zien hoe je deze opties kunt specificeren met behulp van Aspose.Slides. Volg hiervoor de onderstaande stappen:

1. Instantieer een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse‑object.  
2. Voeg een diagram toe aan de dia.  
3. Specificeer de tweede plotopties van het diagram.  
4. Schrijf de presentatie naar schijf.  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Automatische kleuring van taartdiagramsegmenten instellen**
Aspose.Slides for C++ biedt een eenvoudige API om automatisch kleuren voor taartdiagramsegmenten in te stellen. De voorbeeldcode past de hierboven genoemde eigenschappen toe.

1. Maak een instantie van de Presentation‑klasse.  
2. Open de eerste dia.  
3. Voeg een diagram toe met standaardgegevens.  
4. Stel de titel van het diagram in.  
5. Stel de eerste serie in om waarden weer te geven.  
6. Stel de index van het diagramgegevensblad in.  
7. Haal het gegevenswerkblad van het diagram op.  
8. Verwijder de standaard gegenereerde series en categorieën.  
9. Voeg nieuwe categorieën toe.  
10. Voeg een nieuwe serie toe.  

Schrijf de aangepaste presentatie naar een PPTX‑bestand.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **Veelgestelde vragen**

**Worden de 'Pie of Pie' en 'Bar of Pie' varianten ondersteund?**

Ja, de bibliotheek [ondersteunt](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/charttype/) een secundaire plot voor taartdiagrammen, inclusief de 'Pie of Pie' en 'Bar of Pie' types.

**Kan ik alleen het diagram exporteren als afbeelding (bijvoorbeeld PNG)?**

Ja, je kunt het diagram zelf [exporteren als afbeelding](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getimage/) (bijvoorbeeld PNG) zonder de volledige presentatie.