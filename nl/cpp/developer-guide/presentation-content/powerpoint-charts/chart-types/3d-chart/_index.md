---
title: Pas 3D-grafieken in presentaties aan met С++
linktitle: 3D-grafiek
type: docs
url: /nl/cpp/3d-chart/
keywords:
- 3D-grafiek
- rotatie
- diepte
- PowerPoint
- presentatie
- С++
- Aspose.Slides
description: "Leer hoe u 3‑D‑grafieken maakt en aanpast in Aspose.Slides voor С++, met ondersteuning voor PPT‑ en PPTX‑bestanden — verbeter vandaag nog uw presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe je een 3D-diagram in Aspose.Slides kunt aanpassen door de `Rotation3D`‑instellingen zoals `RotationX`, `RotationY`, `DepthPercents` en `RightAngleAxes` te configureren. Het laat stap voor stap zien hoe je een presentatie maakt, een 3D-diagram met standaardgegevens toevoegt, de vereiste 3D‑weergave‑instellingen toepast en de gewijzigde presentatie opslaat als een PPTX‑bestand.

## **Stel de eigenschappen RotationX, RotationY en DepthPercents van een 3D-diagram in**
Aspose.Slides voor C++ biedt een eenvoudige API om deze eigenschappen in te stellen. Het volgende artikel helpt je bij het instellen van verschillende eigenschappen zoals X‑, Y‑rotatie, **DepthPercents** enz. De voorbeeldcode past de eerder genoemde eigenschappen toe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse aan.
2. Open de eerste dia.
3. Voeg een diagram toe met standaardgegevens.
4. Stel de Rotation3D‑eigenschappen in.
5. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **Veelgestelde vragen**

**Welke diagramtypen ondersteunen de 3D‑modus in Aspose.Slides?**

Aspose.Slides ondersteunt 3D‑varianten van kolomdiagrammen, waaronder Column 3D, Clustered Column 3D, Stacked Column 3D en 100 % Stacked Column 3D, evenals gerelateerde 3D‑typen die beschikbaar zijn via de [ChartType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/charttype/)‑enumeratie. Voor een exacte, up‑to‑date lijst, bekijk de leden van [ChartType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/charttype/) in de API‑referentie van de geïnstalleerde versie.

**Kan ik een rasterafbeelding van een 3D-diagram krijgen voor een rapport of het web?**

Ja. Je kunt een diagram exporteren naar een afbeelding via de [chart API](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getimage/) of [de volledige dia renderen](/slides/nl/cpp/convert-powerpoint-to-png/) naar formaten zoals PNG of JPEG. Dit is handig wanneer je een pixel‑perfecte weergave nodig hebt of het diagram wilt insluiten in documenten, dashboards of webpagina’s zonder dat PowerPoint vereist is.

**Hoe presteert het bouwen en renderen van grote 3D‑diagrammen?**

De performance hangt af van de hoeveelheid gegevens en de visuele complexiteit. Voor optimale resultaten houd je 3D‑effecten tot een minimum, vermijd je zware texturen op wanden en plotgebieden, beperk je het aantal datapunten per serie waar mogelijk, en render je naar een output met een passende grootte (resolutie en afmetingen) die overeenkomt met het doel‑display of de afdrukvereisten.