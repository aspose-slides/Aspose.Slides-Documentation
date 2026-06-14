---
title: 使用 VSTO 與 Aspose.Slides for Java 建立並嵌入 Excel 圖表作為 OLE 物件
linktitle: 建立並嵌入 Excel 圖表作為 OLE 物件
type: docs
weight: 60
url: /zh-hant/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- 建立圖表
- 嵌入 Excel 圖表
- OLE 物件
- 遷移
- VSTO
- Office 自動化
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "將 Microsoft Office 自動化遷移至 Aspose.Slides for Java，並在 Java 中將 Excel 圖表作為 OLE 物件嵌入 PowerPoint（PPT、PPTX）投影片中。"
---
{{% alert color="primary" %}} 
圖表是您資料的視覺化表示，且廣泛用於簡報投影片。本篇文章將示範如何使用 [VSTO](/slides/zh-hant/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) 以及 [Aspose.Slides for Java](/slides/zh-hant/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) 以程式方式在 PowerPoint 投影片中建立並嵌入 Excel 圖表作為 OLE 物件。
{{% /alert %}} 
## **建立並嵌入 Excel 圖表**
以下兩個程式碼範例較長且詳細，因為所描述的任務相當複雜。您需要建立一個 Microsoft Excel 活頁簿，建立圖表，然後建立要嵌入圖表的 Microsoft PowerPoint 簡報。OLE 物件會包含指向原始文件的連結，使用者雙擊嵌入的檔案時會開啟該檔案及其應用程式。
### **VSTO 範例**
使用 VSTO 時，將執行以下步驟：

1. 建立 Microsoft Excel ApplicationClass 物件的實例。
1. 建立一個包含單一工作表的新活頁簿。
1. 將圖表新增至工作表。
1. 儲存活頁簿。
1. 開啟包含圖表資料工作表的 Excel 活頁簿。
1. 取得該工作表的 ChartObjects 集合。
1. 取得要複製的圖表。
1. 建立 Microsoft PowerPoint 簡報。
1. 在簡報中新增一張空白投影片。
1. 將圖表從 Excel 工作表複製至剪貼簿。
1. 將圖表貼上至 PowerPoint 簡報。
1. 在投影片上定位圖表。
1. 儲存簡報.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for Java 範例**
使用 Aspose.Slides for .NET 時，將執行以下步驟：

1. 使用 Aspose.Cells for Java 建立活頁簿。
1. 建立 Microsoft Excel 圖表。
1. 設定 Excel 圖表的 OLE 大小。
1. 取得圖表的影像。
1. 使用 Aspose.Slides for Java 將 Excel 圖表作為 OLE 物件嵌入 PPTX 簡報中。
1. 將物件變更的影像替換為步驟 3 取得的影像，以處理物件變更問題。
1. 將輸出簡報寫入磁碟，使用 PPTX 格式。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}