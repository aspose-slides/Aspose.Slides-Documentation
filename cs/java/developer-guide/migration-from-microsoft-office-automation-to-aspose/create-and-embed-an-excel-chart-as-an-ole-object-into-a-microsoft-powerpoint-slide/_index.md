---
title: Vytvořit a vložit grafy Excel jako OLE objekty pomocí VSTO a Aspose.Slides pro Java
linktitle: Vytvořit a vložit grafy Excel jako OLE objekty
type: docs
weight: 60
url: /cs/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- vytvořit graf
- vložit graf Excel
- OLE objekt
- migrace
- VSTO
- automatizace Office
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Migrujte z automatizace Microsoft Office na Aspose.Slides pro Java a vložte grafy Excel jako OLE objekty do snímků PowerPoint (PPT, PPTX) v jazyce Java."
---
{{% alert color="info" %}} 

Grafy jsou vizuálními představami vašich dat a jsou široce používány v prezentačních snímcích. Tento článek vám ukáže kód pro programové vytvoření a vložení grafu Excel jako OLE objektu do snímku PowerPointu pomocí [VSTO](/slides/cs/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) a [Aspose.Slides for Java](/slides/cs/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Vytvoření a vložení grafu Excel**
The two code examples below are long and detailed because the task they're describing is involved. You create a Microsoft Excel workbook, create a chart and then create the Microsoft PowerPoint presentation that you'll embed the chart into. OLE objects contain links to the original document so a user that double-clicks the embedded file will launch the file and it's application.
### **Příklad VSTO**
Using VSTO, the following steps are performed:

1. Vytvořte instanci objektu Microsoft Excel ApplicationClass.
1. Vytvořte nový sešit s jedním listem.
1. Přidejte graf do listu.
1. Uložte sešit.
1. Otevřete Excel sešit obsahující list s daty grafu.
1. Získejte kolekci ChartObjects pro list.
1. Získejte graf, který chcete kopírovat.
1. Vytvořte prezentaci Microsoft PowerPoint.
1. Přidejte prázdný snímek do prezentace.
1. Zkopírujte graf z Excel listu do schránky.
1. Vložte graf do prezentace PowerPoint.
1. Umístěte graf na snímek.
1. Uložte prezentaci.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Příklad Aspose.Slides for Java**
Using Aspose.Slides for .NET, the following steps are performed:

1. Vytvořte sešit pomocí Aspose.Cells pro Java.
1. Vytvořte graf Microsoft Excel.
1. Nastavte velikost OLE objektu grafu Excel.
1. Získejte obrázek grafu.
1. Vložte graf Excel jako OLE objekt do prezentace PPTX pomocí Aspose.Slides pro Java.
1. Nahraďte změněný obrázek objektu obrázkem získaným ve třetím kroku, aby se vyřešil problém se změnou objektu.
1. Zapíšete výstupní prezentaci na disk ve formátu PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}