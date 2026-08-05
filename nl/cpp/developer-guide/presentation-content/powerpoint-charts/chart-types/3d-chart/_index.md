---
title: 3D‑grafieken aanpassen in presentaties met C++
linktitle: 3D‑grafiek
type: docs
url: /nl/cpp/3d-chart/
keywords:
- 3D‑grafiek
- rotatie
- diepte
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe je 3-D-grafieken maakt en aanpast in Aspose.Slides voor C++, met ondersteuning voor PPT- en PPTX-bestanden—geef je presentaties een boost vandaag."
---
## **Overzicht**

Dit artikel legt uit hoe je een 3D‑grafiek in Aspose.Slides kunt aanpassen door de `Rotation3D`‑instellingen zoals `RotationX`, `RotationY`, `DepthPercents` en `RightAngleAxes` te configureren. Het doorloopt het maken van een presentatie, het toevoegen van een 3D‑grafiek met standaardgegevens, het toepassen van de vereiste 3D‑view‑instellingen en het opslaan van de aangepaste presentatie als een PPTX‑bestand.

## **Instellen van RotationX, RotationY en DepthPercents‑eigenschappen van een 3D‑grafiek**
Aspose.Slides for C++ biedt een eenvoudige API om deze eigenschappen in te stellen. Het onderstaande artikel helpt je bij het instellen van verschillende eigenschappen zoals X‑, Y‑rotatie, **DepthPercents** enz. De voorbeeldcode past de hierboven genoemde eigenschappen toe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Open de eerste dia.
3. Voeg een grafiek toe met standaardgegevens.
4. Stel Rotation3D‑eigenschappen in.
5. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Welke grafiektype­n ondersteunen de 3D‑modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van staafgrafieken, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, samen met gerelateerde 3D‑typen die via de [ChartType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/charttype/)‑enumeratie worden blootgesteld. Voor een exacte, actuele lijst, controleer de leden van [ChartType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/charttype/) in de API‑referentie van jouw geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D‑grafiek krijgen voor een rapport of het web?**

Ja. Je kunt een grafiek exporteren naar een afbeelding via de [chart API](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getimage/) of [render the entire slide](/slides/nl/cpp/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is nuttig wanneer je een pixel‑perfecte preview nodig hebt of de grafiek wilt insluiten in documenten, dashboards of webpagina's zonder dat PowerPoint vereist is.

**Hoe presteert het bouwen en renderen van grote 3D‑grafieken?**

Prestaties hangen af van de hoeveelheid gegevens en de visuele complexiteit. Voor de beste resultaten, houd 3D‑effecten minimaal, vermijd zware texturen op wanden en plotgebieden, beperk het aantal gegevenspunten per serie waar mogelijk, en render naar een passend formaat (resolutie en afmetingen) dat aansluit bij de doel‑weergave of afdrukbehoeften.