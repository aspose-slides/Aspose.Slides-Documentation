---
title: Grafieken maken met VSTO en Aspose.Slides voor Java
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
description: "Leer hoe u het maken van PowerPoint-grafieken in Java kunt automatiseren. Deze stapsgewijze gids laat zien waarom Aspose.Slides voor Java een snellere, krachtigere alternatieve oplossing is voor Microsoft.Office.Interop."
---
{{% alert color="primary" %}} 

Grafieken zijn visuele weergaven van gegevens die veel worden gebruikt in presentaties. In dit artikel wordt de code getoond om een grafiek in een Microsoft PowerPoint‑presentatie programmatically te maken met behulp van [VSTO](/slides/nl/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) en [Aspose.Slides for Java](/slides/nl/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Een grafiek maken**
De codevoorbeelden hieronder beschrijven hoe je een eenvoudige 3D gegroepeerde kolomgrafiek toevoegt met VSTO. Je maakt een presentatie‑instance, voegt er een standaardgrafiek aan toe en gebruikt vervolgens een Microsoft Excel‑werkmap om de grafiekgegevens te benaderen en te wijzigen, samen met het instellen van grafiekeigenschappen. Ten slotte sla je de presentatie op.
### **VSTO‑voorbeeld**
Met VSTO worden de volgende stappen uitgevoerd:

1. Maak een instantie van een Microsoft PowerPoint‑presentatie.
1. Voeg een lege dia toe aan de presentatie.
1. Voeg een **3D gegroepeerde kolom**‑grafiek toe en benader deze.
1. Maak een nieuwe Microsoft Excel‑Workbook‑instantie en laad de grafiekgegevens.
1. Benader het werkblad met grafiekgegevens via de Microsoft Excel‑Workbook‑instantiefromworkbook.
1. Stel het grafiekbereik in het werkblad in en verwijder serie 2 en 3 uit de grafiek.
1. Wijzig de categorische gegevens van de grafiek in het werkblad.
1. Wijzig de gegevens van serie 1 in het werkblad.
1. Open nu de titel van de grafiek en stel de gerelateerde lettertype‑eigenschappen in.
1. Benader de waardenas van de grafiek en stel de hoofd‑ en subeenheid, maximale en minimale waarden in.
1. Benader de diepte‑ of seriebenas van de grafiek en verwijder deze, want in dit voorbeeld wordt slechts één serie gebruikt.
1. Stel nu de rotatiehoeken van de grafiek in X‑ en Y‑richting in.
1. Sla de presentatie op.
1. Sluit de instanties van Microsoft Excel en PowerPoint.

**De gegenereerde presentatie, gemaakt met VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for Java‑voorbeeld**
Met Aspose.Slides for Java worden de volgende stappen uitgevoerd:

1. Maak een instantie van een Microsoft PowerPoint‑presentatie.
1. Voeg een lege dia toe aan de presentatie.
1. Voeg een **3D gegroepeerde kolom**‑grafiek toe en benader deze.
1. Benader het werkblad met grafiekgegevens via een Microsoft Excel‑Workbook‑instantiefromworkbook.
1. Verwijder de ongebruikte series 2 en 3.
1. Benader de grafiekcategorieën en wijzig de labels.
1. Benader serie 1 en wijzig de serie‑waarden.
1. Open nu de titel van de grafiek en stel de lettertype‑eigenschappen in.
1. Benader de waardenas van de grafiek en stel de hoofd‑ en subeenheid, maximale en minimale waarden in.
1. Stel nu de rotatiehoeken van de grafiek in X‑ en Y‑richting in.
1. Sla de presentatie op in PPTX‑formaat.

**De gegenereerde presentatie, gemaakt met Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

**Kan ik andere soorten grafieken maken, zoals taart‑, lijngrafieken of staafgrafieken met Aspose.Slides?**

Ja. Aspose.Slides ondersteunt een breed scala aan [grafiektypen](/slides/nl/java/create-chart/), inclusief taartgrafieken, lijngrafieken, staafgrafieken, spreidingsdiagrammen, bubbelgrafieken en meer. Je kunt het gewenste grafiektype opgeven met de [ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/)‑klasse bij het toevoegen van een grafiek.

**Kan ik aangepaste stijlen of thema’s op de grafiek toepassen?**

Ja. Je kunt het uiterlijk van de grafiek volledig aanpassen, waaronder kleuren, lettertypes, vullingen, contouren, rasterlijnen en lay‑out. Het exact toepassen van Office‑thema’s zoals in PowerPoint vereist echter handmatig het instellen van individuele stijlen.

**Kan ik de grafiek apart van de dia exporteren als afbeelding?**

Ja, Aspose.Slides maakt het mogelijk om elke vorm – inclusief grafieken – exporteren als een afzonderlijke afbeelding (bijv. PNG, JPEG) met de `getImage`‑methode op de grafiek[shape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/).