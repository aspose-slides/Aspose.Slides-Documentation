---
title: 使用 VSTO 與 Aspose.Slides for Java 建立圖表
linktitle: 建立圖表
type: docs
weight: 70
url: /zh-hant/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- 建立圖表
- 遷移
- VSTO
- Office 自動化
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Java 中自動化 PowerPoint 圖表的建立。此步驟說明指南展示了為何 Aspose.Slides for Java 是比 Microsoft.Office.Interop 更快速、更強大的替代方案。"
---
{{% alert color="primary" %}} 
圖表是資料的視覺化呈現，廣泛用於簡報。本文展示如何使用 [VSTO](/slides/zh-hant/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) 與 [Aspose.Slides for Java](/slides/zh-hant/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) 以程式方式在 Microsoft PowerPoint 中建立圖表的程式碼。
{{% /alert %}} 
## **建立圖表**
以下程式碼範例說明使用 VSTO 新增簡易 3D 群組柱狀圖的流程。您會建立簡報實例，向其中加入預設圖表。接著使用 Microsoft Excel 活頁簿存取並修改圖表資料，同時設定圖表屬性。最後，儲存簡報。
### **VSTO 範例**
使用 VSTO 時，執行以下步驟：

1. 建立 Microsoft PowerPoint 簡報的實例。
1. 向簡報新增一張空白投影片。
1. 加入一個 **3D 群組柱狀圖** 並存取它。
1. 建立新的 Microsoft Excel 活頁簿實例，並載入圖表資料。
1. 使用 Microsoft Excel 活頁簿實例 fromworkbook 存取圖表資料工作表。
1. 在工作表中設定圖表範圍，並從圖表中移除第 2、3 系列。
1. 在圖表資料工作表中修改圖表類別資料。
1. 在圖表資料工作表中修改第 1 系列的資料。
1. 現在，存取圖表標題並設定字型相關屬性。
1. 存取圖表值軸，並設定主要單位、次要單位、最大值與最小值。
1. 存取圖表深度（或系列軸）並將其移除，因為在此範例中僅使用一個系列。
1. 現在，設定圖表在 X 與 Y 方向的旋轉角度。
1. 儲存簡報。
1. 關閉 Microsoft Excel 與 PowerPoint 的實例。

**使用 VSTO 建立的輸出簡報** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for Java 範例**
使用 Aspose.Slides for Java 時，執行以下步驟：

1. 建立 Microsoft PowerPoint 簡報的實例。
1. 向簡報新增一張空白投影片。
1. 加入一個 **3D 群組柱狀圖** 並存取它。
1. 使用 Microsoft Excel 活頁簿實例 fromworkbook 存取圖表資料工作表。
1. 移除未使用的第 2、3 系列。
1. 存取圖表類別並修改標籤。
1. 存取第 1 系列並修改系列值。
1. 現在，存取圖表標題並設定字型屬性。
1. 存取圖表值軸，並設定主要單位、次要單位、最大值與最小值。
1. 現在，設定圖表在 X 與 Y 方向的旋轉角度。
1. 將簡報儲存為 PPTX 格式。

**使用 Aspose.Slides 建立的輸出簡報** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **常見問題**

**我可以使用 Aspose.Slides 建立其他類型的圖表，例如圓餅圖、折線圖或長條圖嗎？**

是的。Aspose.Slides 支援廣泛的[圖表類型](/slides/zh-hant/java/create-chart/)，包括圓餅圖、折線圖、長條圖、散佈圖、氣泡圖等。加入圖表時，您可以使用 [ChartType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/charttype/) 類別指定所需的圖表類型。

**我可以為圖表套用自訂樣式或主題嗎？**

可以。您可以完全自訂圖表的外觀，包括顏色、字型、填色、輪廓、格線與版面配置。然而，要完全套用 PowerPoint 中的 Office 主題，需要手動設定各項樣式。

**我可以將圖表獨立於投影片匯出為圖像嗎？**

可以，Aspose.Slides 允許您使用圖表 [shape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/) 的 `getImage` 方法，將任何形狀（包括圖表）匯出為單獨的圖像（例如 PNG、JPEG）。