---
title: Grafieken maken met VSTO en Aspose.Slides for Java
linktitle: Grafiek maken
type: docs
weight: 70
url: /nl/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- grafiek maken
- migratie
- VSTO
- Office-automatisering
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe je PowerPoint-grafieken kunt automatiseren in Java. Deze stapsgewijze gids toont waarom Aspose.Slides for Java een snellere, krachtigere alternatief is voor Microsoft.Office.Interop."
---
{{% alert color="info" %}} 
Grafieken zijn visuele weergaven van gegevens die veel worden gebruikt in presentaties. Dit artikel toont de code om een grafiek in Microsoft PowerPoint programmeermatig te maken met behulp van [VSTO](/slides/nl/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) en [Aspose.Slides for Java](/slides/nl/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).
{{% /alert %}} 
## **Een grafiek maken**
De onderstaande codevoorbeelden beschrijven het proces van het toevoegen van een eenvoudige 3D gegroepeerde kolomgrafiek met VSTO. Je maakt een presentatie‑instantie, voegt er een standaardgrafiek aan toe. Vervolgens gebruik je een Microsoft Excel‑werkmap om de grafiekgegevens te benaderen en te wijzigen, samen met het instellen van grafiekeigenschappen. Ten slotte sla je de presentatie op.
### **VSTO-voorbeeld**
Met VSTO worden de volgende stappen uitgevoerd:

1. Maak een instantie van een Microsoft PowerPoint‑presentatie.
1. Voeg een lege dia toe aan de presentatie.
1. Voeg een **3D gegroepeerde kolom**‑grafiek toe en krijg er toegang toe.
1. Maak een nieuwe Microsoft Excel‑werkmap‑instantie aan en laad de grafiekgegevens.
1. Benader het werkblad met grafiekgegevens via de Microsoft Excel‑werkmap‑instantie.
1. Stel het grafiekbereik in op het werkblad in en verwijder serie 2 en 3 uit de grafiek.
1. Wijzig de categorische gegevens van de grafiek in het werkblad met grafiekgegevens.
1. Wijzig de gegevens van grafiekserie 1 in het werkblad met grafiekgegevens.
1. Toegang nu tot de grafiektitel en stel de gerelateerde lettertype‑eigenschappen in.
1. Benader de waardenas van de grafiek en stel de grootste eenheid, kleine eenheden, maximale en minimale waarden in.
1. Benader de diepte‑ of serienaam van de grafiek en verwijder deze, want in dit voorbeeld wordt slechts één serie gebruikt.
1. Stel nu de rotatiehoeken van de grafiek in X‑ en Y‑richting in.
1. Sla de presentatie op.
1. Sluit de instanties van Microsoft Excel en PowerPoint.

**De uitvoer‑presentatie, gemaakt met VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for Java-voorbeeld**
Met Aspose.Slides for Java worden de volgende stappen uitgevoerd:

1. Maak een instantie van een Microsoft PowerPoint‑presentatie.
1. Voeg een lege dia toe aan de presentatie.
1. Voeg een **3D gegroepeerde kolom**‑grafiek toe en krijg er toegang toe.
1. Benader het werkblad met grafiekgegevens via een Microsoft Excel‑werkmap‑instantie.
1. Verwijder ongebruikte series 2 en 3.
1. Benader de grafiekcategorieën en wijzig de labels.
1. Benader serie 1 en wijzig de seriewaarden.
1. Toegang nu tot de grafiektitel en stel de lettertype‑eigenschappen in.
1. Benader de waardenas van de grafiek en stel de grootste eenheid, kleine eenheden, maximale en minimale waarden in.
1. Stel nu de rotatiehoeken van de grafiek in X‑ en Y‑richting in.
1. Sla de presentatie op in PPTX‑formaat.

**De uitvoer‑presentatie, gemaakt met Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

### Kan ik andere soorten grafieken maken, zoals taart-, lijngrafieken of staafgrafieken, met Aspose.Slides?
Ja. Aspose.Slides ondersteunt een breed scala aan [grafiektype‑s](/slides/nl/java/create-chart/), waaronder taartgrafieken, lijngrafieken, staafgrafieken, spreidingsdiagrammen, bubbelgrafieken en meer. Je kunt het gewenste grafiektype opgeven met de [ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/)-klasse bij het toevoegen van een grafiek.

### Kan ik aangepaste stijlen of thema's toepassen op de grafiek?
Ja. Je kunt het uiterlijk van de grafiek volledig aanpassen, inclusief kleuren, lettertypen, vullingen, contouren, rasterlijnen en layout. Het toepassen van Office‑thema's precies zoals in PowerPoint vereist echter het handmatig instellen van individuele stijlen.

### Kan ik de grafiek apart van de dia exporteren als een afbeelding?
Ja, Aspose.Slides stelt je in staat om elke vorm — inclusief grafieken — als een afzonderlijke afbeelding (bijv. PNG, JPEG) te exporteren met de `getImage`-methode op de grafiek-[shape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/).