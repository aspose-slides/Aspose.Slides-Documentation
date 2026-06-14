---
title: 在 .NET 中管理簡報形狀
linktitle: 形狀操作
type: docs
weight: 40
url: /zh-hant/net/shape-manipulations/
keywords:
- PowerPoint 形狀
- 簡報形狀
- 投影片上的形狀
- 尋找形狀
- 複製形狀
- 移除形狀
- 隱藏形狀
- 變更形狀順序
- 取得 Interop 形狀 ID
- 形狀替代文字
- 形狀版面配置格式
- 形狀為 SVG
- 形狀轉 SVG
- 對齊形狀
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "學習在 Aspose.Slides for .NET 中建立、編輯與最佳化形狀，並提供高效能的 PowerPoint 簡報。"
---
## **概述**

本文說明如何使用 Aspose.Slides 在簡報中處理形狀。它展示了如何在投影片上尋找形狀、複製形狀、移除形狀、隱藏形狀、變更順序、取得 Interop 形狀 ID，並設定替代文字以供辨識與後續處理。

同時也涵蓋了如何存取形狀的版面配置、將形狀渲染為 SVG、在投影片上對齊形狀，以及使用翻轉屬性進行水平與垂直鏡像。文章最後還提供了關於形狀組合、堆疊順序與形狀鎖定的簡短 FAQ。

## **在投影片上尋找形狀**
本節將說明一種簡易技巧，讓開發人員在不使用內部 Id 的情況下，更容易在投影片上找到特定形狀。必須了解 PowerPoint 簡報檔案只能透過內部唯一 Id 來辨識形狀，直接以此 Id 搜尋對開發者相當困難。所有加入投影片的形狀皆具有替代文字 (Alt Text)。我們建議開發者使用替代文字來尋找特定形狀。您可以在 Microsoft PowerPoint 中為未來可能變更的物件定義替代文字。

設定好任意形狀的替代文字後，即可使用 Aspose.Slides for .NET 開啟簡報，遍歷投影片中所有形狀。於每次迭代時檢查形狀的替代文字，符合的形狀即為您所需。為了更清楚說明此技巧，我們建立了方法[FindShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/findshape/#findshape_1) 來在投影片中尋找特定形狀，並直接回傳該形狀。

```c#
public static void Run()
{
    // 實例化一個代表簡報檔案的 Presentation 類別
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // 要尋找的形狀之替代文字
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// 使用替代文字在投影片中尋找形狀的方法實作
public static IShape FindShape(ISlide slide, string alttext)
{
    // 遍歷投影片內的所有形狀
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // 如果投影片的替代文字與所需的相符，則
        // 返回該形狀
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```

## **複製形狀**
使用 Aspose.Slides for .NET 複製形狀至投影片的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
1. 依索引取得投影片參考。  
1. 取得來源投影片的形狀集合。  
1. 向簡報新增投影片。  
1. 從來源投影片的形狀集合複製形狀至新投影片。  
1. 將修改後的簡報儲存為 PPTX 檔案。

以下範例示範將群組形狀新增至投影片。

```c#
 // 實例化 Presentation 類別
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// 將 PPTX 檔案寫入磁碟
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```

## **移除形狀**
Aspose.Slides for .NET 允許開發者移除任何形狀。要從投影片移除形狀，請依照下列步驟操作：

1. 建立 `Presentation` 類別的實例。  
1. 取得第一張投影片。  
1. 以特定 AlternativeText 找到形狀。  
1. 移除該形狀。  
1. 將檔案儲存至磁碟。

```c#
// 建立 Presentation 物件
Presentation pres = new Presentation();

// 取得第一張投影片
ISlide sld = pres.Slides[0];

// 新增矩形類型的自動形狀
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// 將簡報儲存至磁碟
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```

## **隱藏形狀**
Aspose.Slides for .NET 允許開發者隱藏任何形狀。要在投影片上隱藏形狀，請依照下列步驟操作：

1. 建立 `Presentation` 類別的實例。  
1. 取得第一張投影片。  
1. 以特定 AlternativeText 找到形狀。  
1. 隱藏該形狀。  
1. 將檔案儲存至磁碟。

```c#
// 建立代表 PPTX 的 Presentation 類別實例
Presentation pres = new Presentation();

// 取得第一張投影片
ISlide sld = pres.Slides[0];

// 新增矩形類型的自動圖形
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// 將簡報儲存至磁碟
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```

## **變更形狀順序**
Aspose.Slides for .NET 允許開發者重新排列形狀的順序。重新排序可決定哪個形狀位於前方、哪個位於後方。要在投影片上重新排序形狀，請依照下列步驟操作：

1. 建立 `Presentation` 類別的實例。  
1. 取得第一張投影片。  
1. 新增一個形狀。  
1. 在形狀的文字框中加入文字。  
1. 再新增另一個座標相同的形狀。  
1. 重新排序這些形狀。  
1. 將檔案儲存至磁碟。

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```

## **取得 Interop 形狀 ID**
Aspose.Slides for .NET 允許開發者取得投影片範圍內的唯一形狀識別碼，這與 UniqueId 屬性在簡報範圍內取得唯一識別碼不同。`OfficeInteropShapeId` 屬性已加入 `IShape` 介面與 `Shape` 類別。此屬性回傳的值對應於 Microsoft.Office.Interop.PowerPoint.Shape 物件的 Id。以下提供範例程式碼。

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// 在投影片範圍內取得唯一形狀識別碼
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```

## **設定形狀的替代文字**
Aspose.Slides for .NET 允許開發者設定任何形狀的 `AlternateText`。簡報中的形狀可透過 `AlternativeText` 或 Shape Name 屬性加以辨識。`AlternativeText` 屬性可由 Aspose.Slides 及 Microsoft PowerPoint 讀寫。利用此屬性，您可以為形狀加標籤，進而執行移除形狀、隱藏形狀或重新排序形狀等不同操作。設定形狀的 `AlternateText`，請依照下列步驟：

1. 建立 `Presentation` 類別的實例。  
1. 取得第一張投影片。  
1. 向投影片新增任意形狀。  
1. 對新加入的形狀執行一些操作。  
1. 逐一遍歷形狀以找到目標形狀。  
1. 設定 `AlternativeText`。  
1. 將檔案儲存至磁碟。

```c#
// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();

// 取得第一張投影片
ISlide sld = pres.Slides[0];

// 新增矩形類型的自動形狀
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// 將簡報儲存至磁碟
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```

## **存取形狀的版面配置格式**
Aspose.Slides for .NET 提供簡易 API 以存取形狀的版面配置格式。本文示範如何取得這些格式。

以下提供範例程式碼。

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```

## **將形狀渲染為 SVG**
現在 Aspose.Slides for .NET 已支援將形狀渲染為 SVG。`WriteAsSvg` 方法（以及其重載）已加入 `Shape` 類別與 `IShape` 介面。此方法可將形狀內容另存為 SVG 檔案。下方程式碼示範如何將投影片的形狀匯出為 SVG 檔案。

```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```

## **對齊形狀**

透過[SlidesUtil.AlignShape()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/methods/alignshapes/index)的多載方法，您可以

* 依投影片的邊界對形狀進行對齊。請參考範例 1。  
* 依形狀彼此之間對齊。請參考範例 2。

[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapesalignmenttype) 列舉定義了可用的對齊選項。

**範例 1**

以下 C# 程式碼示範如何將索引為 1、2 與 4 的形狀對齊至投影片上緣的邊框：

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```

**範例 2**

以下 C# 程式碼示範如何將整個形狀集合相對於集合中最底部的形狀進行對齊：

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **翻轉屬性**

在 Aspose.Slides 中，[ShapeFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapeframe/) 類別提供 `FlipH` 與 `FlipV` 屬性，以控制形狀的水平與垂直鏡像。兩個屬性皆為 [NullableBool](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/nullablebool/) 型別，可接受 `True`（翻轉）、`False`（不翻轉）或 `NotDefined`（使用預設行為）。此設定可透過形狀的 [Frame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/frame/) 取得。

若要修改翻轉設定，可建立一個新的 [ShapeFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapeframe/) 實例，提供形狀目前的位置與大小、`FlipH` 與 `FlipV` 的期望值，及旋轉角度。將此實例指派給形狀的 [Frame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/frame/)，再儲存簡報，即可套用鏡像變換並寫入輸出檔案。

假設我們有一個 sample.pptx 檔案，其第一張投影片僅包含一個使用預設翻轉設定的形狀，如下圖所示。

![The shape to be flipped](shape_to_be_flipped.png)

以下程式碼範例取得該形狀目前的翻轉屬性，並同時進行水平與垂直翻轉。

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // 取得形狀的水平翻轉屬性。
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // 取得形狀的垂直翻轉屬性。
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // 水平翻轉。
    NullableBool flipV = NullableBool.True; // 垂直翻轉。
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

結果如下：

![The flipped shape](flipped_shape.png)

## **FAQ**

**我可以在投影片上合併形狀（聯集/交集/相減）嗎？**

目前並未提供內建的布林運算 API。您可自行建構所需的輪廓，例如計算最終幾何（透過[GeometryPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/geometrypath/)），然後以該輪廓建立新形狀，必要時再移除原始形狀。

**如何控制堆疊順序（z-order），讓形狀永遠顯示在最上層？**

變更投影片 [shapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseslide/shapes/) 集合中的插入或移動順序即可。為取得可預測的結果，請在完成其他投影片修改後最後確定 z-order。

**我能「鎖定」形狀，以防使用者在 PowerPoint 中編輯它嗎？**

可以。設定[形狀層級的保護旗標](/slides/zh-hant/net/applying-protection-to-presentation/)，例如鎖定選取、移動、調整大小或文字編輯。若需要，亦可在母片或版面上鏡射相同限制。請注意這屬於 UI 級別的保護，並非安全機制；若需更高安全性，建議搭配檔案層級的限制，如[唯讀建議或密碼](/slides/zh-hant/net/password-protected-presentation/)。