---
title: Cirkeldiagrammen aanpassen in presentaties met C++
linktitle: Cirkeldiagram
type: docs
url: /nl/cpp/pie-chart/
keywords:
- cirkeldiagram
- diagram beheren
- diagram aanpassen
- diagramopties
- diagraminstellingen
- plotopties
- segmentkleur
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u cirkeldiagrammen maakt en aanpast in C++ met Aspose.Slides, exporteerbaar naar PowerPoint, zodat u uw dataverhaal in seconden versterkt."
---
## **Overzicht**

Dit artikel legt uit hoe u met cirkeldiagrammen in Aspose.Slides kunt werken. Het laat zien hoe u secundaire plotopties voor Pie of Pie- en Bar of Pie-diagrammen kunt configureren en hoe u automatische kleuring van segmenten voor een standaardcirkeldiagram kunt inschakelen.

De voorbeelden richten zich op praktische stappen voor het aanpassen van diagrammen, zoals het toevoegen van een diagram aan een dia, het aanpassen van serie- en labelinstellingen, het vervangen van de standaarddiagramgegevens door aangepaste categorieën en waarden, en het opslaan van de bijgewerkte presentatie.

## **Secundaire Plotopties voor Pie of Pie- en Bar of Pie-diagrammen**
Aspose.Slides voor C++ ondersteunt nu secundaire plotopties voor Pie of Pie- of Bar of Pie-diagrammen. In dit onderwerp laten we met een voorbeeld zien hoe u deze opties kunt specificeren met Aspose.Slides. Volg de onderstaande stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse‑object.
2. Voeg een diagram toe aan de dia.
3. Specificeer de secundaire plotopties van het diagram.
4. Schrijf de presentatie naar schijf.

In het onderstaande voorbeeld hebben we verschillende eigenschappen van een Pie of Pie-diagram ingesteld.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Automatische kleuring van cirkeldiagramsegmenten instellen**
Aspose.Slides voor C++ biedt een eenvoudige API voor het automatisch instellen van kleuren van cirkeldiagramsegmenten. De voorbeeldcode past de bovengenoemde eigenschappen toe.

1. Maak een instantie van de Presentation‑klasse.
2. Open de eerste dia.
3. Voeg een diagram toe met standaardgegevens.
4. Stel de titel van het diagram in.
5. Stel de eerste serie in op Waarden weergeven.
6. Stel de index van het diagram‑datablad in.
7. Haalt het werkblad met diagramgegevens op.
8. Verwijder de standaardgegenereerde series en categorieën.
9. Voeg nieuwe categorieën toe.
10. Voeg een nieuwe serie toe.

Schrijf de aangepaste presentatie naar een PPTX‑bestand.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**Worden de 'Pie of Pie' en 'Bar of Pie'-varianten ondersteund?**

Ja, de bibliotheek [ondersteunt](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/charttype/) een secundaire plot voor cirkeldiagrammen, inclusief de 'Pie of Pie'- en 'Bar of Pie'-typen.

**Kan ik alleen het diagram exporteren als afbeelding (bijvoorbeeld PNG)?**

Ja, u kunt [het diagram zelf exporteren als afbeelding](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getimage/) (bijvoorbeeld PNG) zonder de volledige presentatie.