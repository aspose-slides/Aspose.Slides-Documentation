---
title: Skapa och bädda in Excel-diagram som OLE-objekt med VSTO och Aspose.Slides för Java
linktitle: Skapa och bädda in Excel-diagram som OLE-objekt
type: docs
weight: 60
url: /sv/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- skapa diagram
- bädda in Excel-diagram
- OLE-objekt
- migration
- VSTO
- Office-automatisering
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Flytta från Microsoft Office-automatisering till Aspose.Slides för Java och bädda in Excel-diagram som OLE-objekt i PowerPoint‑bilder (PPT, PPTX) i Java."
---
{{% alert color="info" %}}

Diagram är visuella representationer av dina data och används i stor utsträckning i presentationsbilder. Denna artikel visar koden för att programmässigt skapa och bädda in ett Excel-diagram som ett OLE-objekt i en PowerPoint-bild med hjälp av [VSTO](/slides/sv/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) och [Aspose.Slides for Java](/slides/sv/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}}
## **Skapa och bädda in ett Excel-diagram**
De två kodexemplen nedan är långa och detaljerade eftersom uppgiften de beskriver är komplex. Du skapar en Microsoft Excel-arbetsbok, skapar ett diagram och sedan skapar du Microsoft PowerPoint-presentationen som du ska bädda in diagrammet i. OLE-objekt innehåller länkar till originaldokumentet så en användare som dubbelklickar på den inbäddade filen startar filen och dess program.
### **VSTO-exempel**
Med VSTO utförs följande steg:

1. Skapa en instans av Microsoft Excel ApplicationClass-objektet.
1. Skapa en ny arbetsbok med ett blad.
1. Lägg till diagram på bladet.
1. Spara arbetsboken.
1. Öppna Excel-arbetsboken som innehåller kalkylbladet med diagramdata.
1. Hämta ChartObjects-samlingen för bladet.
1. Hämta diagrammet för kopiering.
1. Skapa en Microsoft PowerPoint-presentation.
1. Lägg till en tom bild i presentationen.
1. Kopiera diagrammet från Excel-kalkylbladet till urklipp.
1. Klistra in diagrammet i PowerPoint-presentationen.
1. Placera diagrammet på bilden.
1. Spara presentationen.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides för Java‑exempel**
Med Aspose.Slides för .NET utförs följande steg:

1. Skapa en arbetsbok med Aspose.Cells för Java.
1. Skapa ett Microsoft Excel-diagram.
1. Ställ in OLE-storleken för Excel-diagrammet.
1. Hämta en bild av diagrammet.
1. Bädda in Excel-diagrammet som ett OLE-objekt i en PPTX-presentation med Aspose.Slides för Java.
1. Byt ut den ändrade objektbilden mot bilden som erhölls i steg 3 för att hantera problemet med ändrat objekt.
1. Skriv den färdiga presentationen till disk i PPTX-format.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}