---
title: 管理 Java 中的簡報圖形
linktitle: 圖形操作
type: docs
weight: 40
url: /zh-hant/java/shape-manipulations/
keywords:
- PowerPoint 圖形
- 簡報圖形
- 投影片上的圖形
- 尋找圖形
- 複製圖形
- 刪除圖形
- 隱藏圖形
- 變更圖形順序
- 取得 Interop 圖形 ID
- 圖形替代文字
- 圖形版面格式
- 圖形為 SVG
- 圖形轉 SVG
- 對齊圖形
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中建立、編輯與最佳化圖形，並交付高效能的 PowerPoint 簡報。"
---
## **概述**

本篇說明如何在 Aspose.Slides 中操作投影片的圖形。內容包括如何在投影片上尋找圖形、複製、刪除、隱藏、變更圖形順序、取得 Interop 圖形 ID，以及設定替代文字以供辨識與後續處理。

此外，還會介紹如何取得圖形的版面格式、將圖形匯出為 SVG、在投影片上對齊圖形，以及使用翻轉屬性進行水平與垂直鏡射。最後，本文提供有關圖形合併、堆疊順序與圖形鎖定的簡短 FAQ。

## **在投影片上尋找圖形**
本節將說明一種簡單技巧，讓開發者在不使用內部 Id 的情況下，更容易於投影片上找到特定圖形。需要注意的是，PowerPoint 檔案只能以內部唯一 Id 來辨識圖形，直接使用該 Id 會較為困難。所有加入投影片的圖形皆可設定替代文字 (Alt Text)。建議開發者利用替代文字來尋找特定圖形。您可以在 Microsoft PowerPoint 中為未來可能變更的物件設定替代文字。

設定完欲尋找圖形的替代文字後，即可使用 Aspose.Slides for Java 開啟該投影片，遍歷投影片中的所有圖形。於每次迭代時檢查圖形的替代文字，匹配的圖形即為目標圖形。為了更清楚說明此技巧，我們建立了方法[findShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-)，可在投影片中找到特定圖形並回傳該圖形。

```java
// 實例化一個代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // 要尋找的圖形的替代文字
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// 使用替代文字在投影片中尋找圖形的方法實作
public static IShape findShape(ISlide slide, String alttext)
{
    // 迭代投影片內所有圖形
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // 如果投影片的替代文字與需求相符則
        // 返回該圖形
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **複製圖形**
使用 Aspose.Slides for Java 複製圖形至投影片的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
1. 依索引取得投影片參考。  
1. 取得來源投影片的圖形集合。  
1. 新增投影片至投影片檔。  
1. 將來源投影片圖形集合中的圖形複製至新投影片。  
1. 將修改後的投影片另存為 PPTX 檔案。

以下範例會在投影片中加入一個群組圖形。

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // 將 PPTX 檔案寫入磁碟
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **刪除圖形**
Aspose.Slides for Java 允許開發者刪除任何圖形。若要從投影片中刪除圖形，請依照下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
1. 取得第一張投影片。  
1. 以特定 AlternativeText 找到圖形。  
1. 刪除該圖形。  
1. 將檔案儲存至磁碟。

```java
// 建立 Presentation 物件
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增矩形類型的自動圖形
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // 將簡報儲存至磁碟
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **隱藏圖形**
Aspose.Slides for Java 允許開發者隱藏任何圖形。若要在投影片中隱藏圖形，請依照下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
1. 取得第一張投影片。  
1. 以特定 AlternativeText 找到圖形。  
1. 隱藏該圖形。  
1. 將檔案儲存至磁碟。

```java
// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增矩形類型的自動圖形
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // 將簡報儲存至磁碟
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **變更圖形順序**
Aspose.Slides for Java 允許開發者重新排列圖形。重新排列可決定哪些圖形位於前方或後方。若要在投影片中變更圖形順序，請依照下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
1. 取得第一張投影片。  
1. 新增一個圖形。  
1. 在圖形的文字框中加入文字。  
1. 再新增另一個座標相同的圖形。  
1. 重新排列這兩個圖形。  
1. 將檔案儲存至磁碟。

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **取得 Interop 圖形 ID**
Aspose.Slides for Java 允許開發者取得投影片範圍內唯一的圖形識別碼，這與 [getUniqueId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape#getUniqueId--) 方法（取得整份投影片檔案範圍內的唯一識別碼）不同。方法 [getOfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) 已加入至 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape) 介面與 [Shape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Shape) 類別。此方法回傳的值對應 Microsoft.Office.Interop.PowerPoint.Shape 物件的 Id。以下示範程式碼說明如何使用。

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 在投影片範圍內取得唯一圖形識別碼
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **設定圖形的替代文字**
Aspose.Slides for Java 允許開發者設定任意圖形的 AlternateText。投影片中的圖形可透過 [AlternativeText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) 或 [Shape Name](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape#setName-java.lang.String-) 方法加以辨識。使用 [setAlternativeText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) 與 [getAlternativeText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape#getAlternativeText--) 方法，您既可在 Aspose.Slides 中讀寫，也可在 Microsoft PowerPoint 中使用。透過此方法，您可以標記圖形，並執行例如刪除圖形、隱藏圖形或重新排列圖形等操作。

設定圖形的 AlternateText，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。  
1. 取得第一張投影片。  
1. 在投影片上加入任意圖形。  
1. 對新加入的圖形進行必要的操作。  
1. 遍歷圖形集合以尋找圖形。  
1. 設定 AlternativeText。  
1. 將檔案儲存至磁碟。

```java
// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增矩形類型的自動圖形
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // 將簡報儲存至磁碟
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **取得圖形的版面格式**
Aspose.Slides for Java 提供簡易 API 以取得圖形的版面格式。本文示範如何存取版面格式。

以下為範例程式碼。

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **將圖形匯出為 SVG**
現在 Aspose.Slides for Java 支援將圖形匯出為 SVG。方法 [writeAsSvg](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-)（以及其重載）已加入至 [Shape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Shape) 類別與 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape) 介面。此方法可將圖形內容另存為 SVG 檔案。以下程式碼片段說明如何把投影片的圖形匯出為 SVG 檔案。

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **對齊圖形**
Aspose.Slides 允許將圖形相對於投影片邊界或相對於彼此對齊。為此，已新增重載方法 [SlidesUtil.alignShape()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)。列舉 [ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ShapesAlignmentType) 定義了可能的對齊選項。

**範例 1**

以下原始碼將索引為 1、2 與 4 的圖形對齊至投影片上緣。

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```

**範例 2**

以下範例示範如何將整個圖形集合相對於集合中最底部的圖形對齊。

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **翻轉屬性**

在 Aspose.Slides 中，[ShapeFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shapeframe/) 類別提供 `flipH` 與 `flipV` 屬性，以控制圖形的水平與垂直鏡射。這兩個屬性皆為 `byte` 型別，`1` 代表翻轉、`0` 代表不翻轉，`-1` 則使用預設行為。這些值可從圖形的 [Frame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getFrame--) 取得。

若要修改翻轉設定，可使用圖形目前的位置與尺寸、欲設定的 `flipH`、`flipV` 以及旋轉角度，建立新的 [ShapeFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shapeframe/) 實例。將此實例指派給圖形的 [Frame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getFrame--) 後儲存投影片，即可套用鏡射變換並寫入輸出檔案。

以下示範檔案 sample.pptx，第一張投影片僅包含一個使用預設翻轉設定的圖形，如下所示。

![The shape to be flipped](shape_to_be_flipped.png)

以下程式碼範例取得圖形目前的翻轉屬性，並同時執行水平與垂直翻轉。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // 取得圖形的水平翻轉屬性。
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // 取得圖形的垂直翻轉屬性。
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // 水平翻轉。
    byte flipV = NullableBool.True; // 水平翻轉。
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果如下：

![The flipped shape](flipped_shape.png)

## **常見問題**

**我可以在投影片上像桌面編輯器那樣合併圖形（聯集/交集/相減）嗎？**

目前沒有內建的布林運算 API。您可以自行建構所需的外形，例如透過 [GeometryPath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/geometrypath/) 計算結果幾何，然後以該輪廓建立新圖形，並視需要刪除原始圖形。

**我如何控制堆疊順序（z-order），使圖形永遠保持在最上層？**

在投影片的 [shapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseslide/#getShapes--) 集合中變更插入或移動順序即可。為了得到可預測的結果，請在完成其他所有投影片修改後，最後確定 z-order。

**我可以「鎖定」圖形，以防止使用者在 PowerPoint 中編輯它嗎？**

可以。設定 [shape-level protection flags](/slides/zh-hant/java/applying-protection-to-presentation/)（例如鎖定選取、移動、調整大小、文字編輯）。必要時，也可在母片或版面上套用相同限制。請注意，這僅是 UI 層面的保護，非安全機制；若需更強的保護，請搭配檔案層面的限制，例如 [唯讀建議或密碼](/slides/zh-hant/java/password-protected-presentation/)。