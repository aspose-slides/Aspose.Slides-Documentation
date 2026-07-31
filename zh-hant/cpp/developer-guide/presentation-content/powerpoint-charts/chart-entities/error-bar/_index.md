---
title: 使用 C++ 自訂簡報圖表中的誤差棒
linktitle: 誤差棒
type: docs
url: /zh-hant/cpp/error-bar/
keywords:
- 誤差棒
- 自訂值
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在圖表中添加與自訂誤差棒——優化 PowerPoint 簡報中的資料視覺效果。"
---
## **概述**

本文說明如何使用 Aspose.Slides 在簡報圖表中使用誤差棒。它展示了如何將誤差棒加入圖表系列、設定 X 與 Y 誤差棒的屬性，以及套用固定、百分比和自訂等不同的值類型。  

它也示範了如何透過相應的資料點集合，為系列中的個別資料點指派自訂誤差棒值。此外，本文還簡要說明了誤差棒在匯出時的行為、與標記及資料標籤的相容性，以及在何處可以找到相關的 API 參考類別和列舉。

## **新增誤差棒**
Aspose.Slides for C++ 提供簡易的 API 來管理誤差棒值。此範例程式碼適用於使用自訂值類型的情況。若要指定值，請使用系列 **DataPoints** 集合中特定資料點的 **ErrorBarCustomValues** 屬性：

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 在目標投影片上新增氣泡圖。
3. 取得第一個圖表系列，並設定誤差棒 X 格式。
4. 取得第一個圖表系列，並設定誤差棒 Y 格式。
5. 設定棒的值與格式。
6. 將修改後的簡報寫入 PPTX 檔案。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **新增自訂誤差棒**
Aspose.Slides for C++ 提供簡易的 API 來管理自訂誤差棒值。此範例程式碼適用於 **IErrorBarsFormat.ValueType** 屬性等於 **Custom** 的情況。若要指定值，請使用系列 **DataPoints** 集合中特定資料點的 **ErrorBarCustomValues** 屬性：

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 在目標投影片上新增氣泡圖。
3. 取得第一個圖表系列，並設定誤差棒 X 格式。
4. 取得第一個圖表系列，並設定誤差棒 Y 格式。
5. 存取圖表系列的個別資料點，並為單一系列資料點設定誤差棒值。
6. 設定棒的值與格式。
7. 將修改後的簡報寫入 PPTX 檔案。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **常見問題**

**將簡報匯出為 PDF 或影像時，誤差棒會發生什麼情形？**

它們會作為圖表的一部分被繪製，並在轉換過程中與圖表的其他格式一起保留，前提是使用相容的版本或渲染器。

**誤差棒可以與標記和資料標籤結合使用嗎？**

可以。誤差棒是獨立的元素，且可與標記和資料標籤相容；若元素重疊，可能需要調整格式。

**在哪裡可以找到用於操作誤差棒的 API 屬性與列舉清單？**

請參考 API 文件：[ErrorBarsFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/errorbarsformat/) 類別及相關列舉 [ErrorBarType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/errorbartype/) 與 [ErrorBarValueType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/errorbarvaluetype/)。