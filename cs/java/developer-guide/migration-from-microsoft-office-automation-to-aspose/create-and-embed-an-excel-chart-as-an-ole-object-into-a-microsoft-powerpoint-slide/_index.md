---
title: Vytvoření a vložení grafů Excel jako OLE objektů pomocí VSTO a Aspose.Slides pro Java
linktitle: Vytvoření a vložení grafů Excel jako OLE objektů
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
description: "Přesuňte se z automatizace Microsoft Office na Aspose.Slides pro Java a vložte grafy Excel jako OLE objekty do snímků PowerPoint (PPT, PPTX) v Javě."
---
{{% alert color="primary" %}}

Grafy jsou vizuálními reprezentacemi vašich dat a jsou široce používány v prezentačních snímcích. Tento článek vám ukáže kód pro vytvoření a vložení grafu Excel jako OLE objektu do snímku PowerPointu programově pomocí [VSTO](/slides/cs/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) a [Aspose.Slides for Java](/slides/cs/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Vytvoření a vložení grafu Excel**
Níže uvedené dva příklady kódu jsou dlouhé a podrobné, protože úloha, kterou popisují, je složitá. Vytvoříte sešit Microsoft Excel, vytvoříte graf a poté vytvoříte prezentaci Microsoft PowerPoint, do které graf vložíte. OLE objekty obsahují odkazy na původní dokument, takže uživatel, který dvakrát klikne na vložený soubor, spustí soubor a jeho aplikaci.
### **Příklad VSTO**
Pomocí VSTO jsou provedeny následující kroky:

1. Vytvořte instanci objektu Microsoft Excel ApplicationClass.
1. Vytvořte nový sešit s jedním listem.
1. Přidejte graf do listu.
1. Uložte sešit.
1. Otevřete sešit Excel obsahující list s daty grafu.
1. Získejte kolekci ChartObjects pro list.
1. Získejte graf, který chcete zkopírovat.
1. Vytvořte prezentaci Microsoft PowerPoint.
1. Přidejte prázdný snímek do prezentace.
1. Zkopírujte graf z listu Excelu do schránky.
1. Vložte graf do prezentace PowerPoint.
1. Umístěte graf na snímek.
1. Uložte prezentaci.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Příklad Aspose.Slides pro Java**
Pomocí Aspose.Slides pro .NET jsou provedeny následující kroky:

1. Vytvořte sešit pomocí Aspose.Cells pro Java.
1. Vytvořte graf Microsoft Excel.
1. Nastavte velikost OLE objektu grafu Excel.
1. Získejte obrázek grafu.
1. Vložte graf Excel jako OLE objekt do prezentace PPTX pomocí Aspose.Slides pro Java.
1. Nahraďte obrázek změněného objektu obrázkem získaným ve kroku 3, aby byl vyřešen problém s změněným objektem.
1. Zapište výstupní prezentaci na disk ve formátu PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}