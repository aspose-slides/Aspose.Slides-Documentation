---
title: 在 .NET 中自訂簡報的圖表圖例
linktitle: 圖表圖例
type: docs
url: /zh-hant/net/chart-legend/
keywords:
- 圖表圖例
- 圖例位置
- 字型大小
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 自訂圖表圖例，以量身打造的圖例格式優化 PowerPoint 簡報。"
---
## **概觀**

Aspose.Slides 提供在 PowerPoint 簡報中自訂圖表圖例的選項。本篇說明如何設定圖例的位置與大小、為整個圖例設定字型大小，以及為單一圖例項目套用格式。

亦在 FAQ 中說明多項相關行為，包括使用非覆蓋模式讓繪圖區為圖例留出空間、允許長圖例標籤自動換行或使用換行字元，以及在未設定明確文字與填色時，讓圖例格式繼承簡報主題。

## **圖例定位**
若要設定圖例屬性，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
- 取得投影片的參考。
- 在投影片上新增圖表。
- 設定圖例的屬性。
- 將簡報寫入為 PPTX 檔案。

以下範例中，我們設定了圖表圖例的位置和大小。

```c#
// 建立 Presentation 類別的實例
Presentation presentation = new Presentation();

// 取得投影片的參考
ISlide slide = presentation.Slides[0];

// 在投影片上新增叢集直條圖表
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// 設定圖例屬性
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// 將簡報寫入磁碟
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```

## **設定圖例的字型大小**
Aspose.Slides for .NET 允許開發人員設定圖例的字型大小。請按照以下步驟操作：

- 實例化 `Presentation` 類別。
- 建立預設圖表。
- 設定字型大小。
- 設定最小軸值。
- 設定最大軸值。
- 將簡報寫入磁碟。

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **設定單一圖例項目的字型大小**
Aspose.Slides for .NET 允許開發人員設定單一圖例項目的字型大小。請按照以下步驟操作：

- 實例化 `Presentation` 類別。
- 建立預設圖表。
- 存取圖例項目。
- 設定字型大小。
- 設定最小軸值。
- 設定最大軸值。
- 將簡報寫入磁碟。

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**我可以啟用圖例，讓圖表自動為其分配空間而不是覆蓋它嗎？**

可以。使用非覆蓋模式（[Overlay](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/legend/overlay/) = `false`）；在此情況下，繪圖區域會縮小以容納圖例。

**我可以讓圖例標籤換行嗎？**

可以。當空間不足時，長標籤會自動換行；也支援在系列名稱中使用換行字元強制換行。

**我要如何讓圖例遵循簡報主題的配色方案？**

請勿為圖例或其文字設定明確的顏色、填色或字型。如此一來，它們會從主題繼承，且在設計變更時會正確更新。