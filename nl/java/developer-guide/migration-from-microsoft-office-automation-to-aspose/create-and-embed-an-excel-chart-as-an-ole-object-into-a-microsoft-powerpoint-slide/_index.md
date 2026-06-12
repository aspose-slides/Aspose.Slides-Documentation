---
title: Excel‑grafieken creëren en insluiten als OLE‑objecten met VSTO en Aspose.Slides voor Java
linktitle: Excel‑grafieken creëren en insluiten als OLE‑objecten
type: docs
weight: 60
url: /nl/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- grafiek maken
- Excel‑grafiek insluiten
- OLE‑object
- migratie
- VSTO
- Office‑automatisering
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Migreer van Microsoft Office‑automatisering naar Aspose.Slides voor Java en sluit Excel‑grafieken in als OLE‑objecten in PowerPoint‑dia's (PPT, PPTX) in Java."
---
{{% alert color="primary" %}} 

 Grafieken zijn visuele weergaven van uw gegevens en worden veel gebruikt in presentatieslides. Dit artikel toont de code om een Excel‑grafiek als OLE‑object in een PowerPoint‑dia te maken en in te sluiten via programmeercode met behulp van [VSTO](/slides/nl/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) en [Aspose.Slides for Java](/slides/nl/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Een Excel‑grafiek maken en insluiten**
De twee code‑voorbeelden hieronder zijn lang en gedetailleerd omdat de beschreven taak complex is. U maakt een Microsoft Excel‑werkmap, maakt een grafiek en vervolgens maakt u de Microsoft PowerPoint‑presentatie waarin u de grafiek insluit. OLE‑objecten bevatten koppelingen naar het originele document, zodat een gebruiker die dubbelklikt op het ingesloten bestand het bestand en de bijbehorende applicatie start.
### **VSTO‑voorbeeld**
Met VSTO worden de volgende stappen uitgevoerd:

1. Maak een instantie van het Microsoft Excel ApplicationClass‑object.
2. Maak een nieuwe werkmap met één werkblad.
3. Voeg een grafiek toe aan het werkblad.
4. Sla de werkmap op.
5. Open de Excel‑werkmap die het werkblad met de grafiekgegevens bevat.
6. Haal de ChartObjects‑collectie voor het werkblad op.
7. Haal de te kopiëren grafiek op.
8. Maak een Microsoft PowerPoint‑presentatie.
9. Voeg een lege dia toe aan de presentatie.
10. Kopieer de grafiek van het Excel‑werkblad naar het klembord.
11. Plak de grafiek in de PowerPoint‑presentatie.
12. Positioneer de grafiek op de dia.
13. Sla de presentatie op.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for Java‑voorbeeld**
Met Aspose.Slides for .NET worden de volgende stappen uitgevoerd:

1. Maak een werkmap met Aspose.Cells for Java.
2. Maak een Microsoft Excel‑grafiek.
3. Stel de OLE‑grootte van de Excel‑grafiek in.
4. Verkrijg een afbeelding van de grafiek.
5. Integreer de Excel‑grafiek als OLE‑object in een PPTX‑presentatie met Aspose.Slides for Java.
6. Vervang de afbeelding van het gewijzigde object door de afbeelding uit stap 3 om het probleem met gewijzigde objecten op te lossen.
7. Schrijf de resulterende presentatie naar schijf in PPTX‑formaat.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}