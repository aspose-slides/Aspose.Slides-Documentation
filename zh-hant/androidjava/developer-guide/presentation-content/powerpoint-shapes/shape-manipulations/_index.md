---
title: 在 Android 上管理簡報形狀
linktitle: 形狀操作
type: docs
weight: 40
url: /zh-hant/androidjava/shape-manipulations/
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
- 形狀調整點
- 預設形狀調整
- 形狀幾何
- 形狀版面格式
- 形狀為 SVG
- 形狀轉 SVG
- 對齊形狀
- 翻轉形狀
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 識別、調整、複製、移除、隱藏、重新排序、匯出、對齊與翻轉簡報形狀。"
---
## **概述**

Aspose.Slides for Android via Java 以有序的 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/) 來表示投影片上的形狀。此集合同時是您尋找與修改形狀的所在，也是它們堆疊順序的來源：索引 `0` 為最靠後的形狀，而最後一個索引為最前面的形狀。

本文遵循此模型。首先說明如何可靠地辨識形狀並修改預設的調整點，接著展示如何複製、移除、隱藏與重新排序形狀。最後的章節涵蓋版面層級的格式設定、SVG 匯出、對齊與翻轉設定。每個範例皆獨立，您可以僅使用工作流程所需的操作。

## **識別與尋找形狀**

在處理已知檔案時，使用集合索引很方便，但它們不是穩定的識別子。新增、移除或重新排序形狀都會改變其索引。請依照簡報的製作與維護方式選擇識別子：

- [Name](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getName--) 於開發人員控制的模板中很有用，且可在 PowerPoint 的「選取窗格」中檢視。名稱可編輯且不保證唯一，若程式碼依賴名稱，請建立命名慣例。
- [AlternativeText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getAlternativeText--) 在已提供可辨識形狀的無障礙說明或作者標籤時很有用。此文字會向使用者顯示，可能會本地化或為無障礙重新編寫，且不保證唯一。不要將具有意義的無障礙文字悄悄用作資料庫鍵值。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) 為唯讀識別子，於投影片內唯一，對應 PowerPoint Interop 使用的形狀 ID。當與 PowerPoint 整合或在形狀生命週期內需要明確參照時使用。被複製或重新建立的形狀會成為不同的形狀，並取得自己的 ID。

相關的 [getUniqueId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getUniqueId--) 方法會傳回簡報範圍內的識別子，但此識別子僅供外掛使用，可能會重新指派。不要將其視為永久的外部鍵。若長期身份辨識很重要，請在應用程式資料中保存對應關係，並驗證預期的形狀仍然存在。

以下範例以名稱做完全相等比對搜尋，並回報投影片範圍的 Interop ID。當模板未包含預期形狀時，程式會回報此結果，而不會繼續使用錯誤的物件。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

當操作針對特定形狀類型時，使用前請先檢查介面。本範例僅在命名物件為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 時，才更新文字與替代文字。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **識別與修改預設形狀調整**

預設幾何形狀可能會暴露調整點，用以控制如角落大小、箭頭比例或弧度等特徵。透過唯讀的 [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) 集合存取它們。集合本身由形狀提供，但每個 [IAdjustValue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iadjustvalue/) 包含可變更的值。

不要只依賴固定的集合索引。遍歷調整項目，並檢查唯讀的 [getType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iadjustvalue/#getType--) 方法，其回傳的 [ShapeAdjustmentType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shapeadjustmenttype/) 會說明此調整控制什麼。唯讀的 [getName](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iadjustvalue/#getName--) 方法提供額外辨識資訊，當同一語意類型出現多次時特別有用。

使用與調整意義相符的值方法：

| 調整類型 | 目的 | 要變更的值 |
|---|---|---|
| `CornerSize` | 圓角的大小 | [setRawValue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | 箭尾的粗細 | `setRawValue` |
| `ArrowheadLength` | 箭頭的長度 | `setRawValue` |
| `ArrowheadWidth` | 箭頭的寬度 | `setRawValue` |
| `StartAngle` | 扇形或弧形的起始角度 | [setAngleValue](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | 扇形或弧形的結束角度 | `setAngleValue` |

`getType` 與 `getName` 只回傳唯讀資訊。`getRawValue` 與 `setRawValue` 使用預設幾何單位的整數，而 `getAngleValue` 與 `setAngleValue` 使用度數。調整的數量、順序、語意與有效範圍取決於預設的 [ShapeType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/igeometryshape/#getShapeType--)。某一預設有效的值，對其他預設可能無效或產生不同效果。

當 `getType` 回傳 `ShapeAdjustmentType.Custom` 時，API 無法辨識標準語意。請檢查 `getName`、預設類型與現有值，除非已知預期的意義與範圍，否則保持調整不變。即使是已辨識的類型，也要先確認同一類型是否出現多次再選取值。[Connector](/slides/zh-hant/androidjava/connector/) 文章示範了連接線彎曲調整的情況。

以下完整範例建立三種預設形狀的預設與修改版本。它遍歷每個調整項目，回報名稱與類型，使用 `setRawValue` 變更尺寸相關值，使用 `setAngleValue` 變更角度，並儲存結果。左欄保留預設幾何，右欄則顯示調整後的圓角矩形、四向箭頭與餅形。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 為預設與調整後的形狀欄位添加標題。
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在變更值之前先檢查語意類型，可讓程式碼對意圖更明確，並避免假設同一索引在不同預設形狀中具有相同意義。

## **修改形狀集合**

加入、複製、移除與重新排序的方法會立即作用於集合。若操作改變形狀的數量或順序，請勿繼續使用先前捕獲的索引。

### **複製形狀**

[addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) 會建立獨立的副本，並將其附加到目標集合。[insertClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) 亦會建立副本，但會放置在指定的 z‑order 索引。接受座標的多載會在不改變尺寸的情況下移動副本；帶有寬度與高度的多載則可同時調整大小。

範例建立目標投影片，將帶標籤的矩形複製至最前面，並在最背面插入第二個副本。對任一副本的變更不會影響來源形狀。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

複製會將形狀的內容與格式，包括名稱與替代文字，一同複製。若這些值必須唯一，請為副本指派新的邏輯識別子。複雜形狀使用的資源由簡報處理，但副本仍是新集合項目，擁有新的形狀識別。

### **移除形狀**

[remove](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 會從其集合中刪除特定形狀物件。於索引化迭代時若要移除多個符合項目，請從末端向前遍歷，以免剩餘索引失效。

此範例移除所有具有指定名稱的形狀。它在目前索引讀取形狀，而非固定的集合項目，且不會不必要地進行型別轉換。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

移除後，形狀計數與後續形狀的索引會變化。對未受影響的形狀保持參考比保存的索引更可靠。也請考慮連接線、動畫與其他可能參照被移除物件的簡報功能；移除可見形狀可能會改變投影片外觀以外的更多項目。

### **隱藏形狀**

將 [Hidden](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) 設為 `true` 會保留形狀於集合中，但阻止其在一般投影片放映中顯示。其索引、格式與內容仍可供程式碼存取，因此適用於可能稍後恢復的可選元素。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

隱藏不是刪除或安全機制。使用者或程式碼仍可發現並取消隱藏，且它仍是簡報檔案的一部份。

### **變更 Z‑Order**

重疊的形狀會依集合順序繪製。[reorder](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) 會將既有形狀移動至目標索引，且不會產生副本。索引 `0` 為最背面，`size() - 1` 為最前面。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此範例先建立矩形，使其最初位於橢圓之後。將其移至最後索引後即位於前方。請在加入或複製所有相關形狀之後再最終確定 Z‑order，因為這些操作會新增或插入集合項目，可能改變原先的堆疊順序。

## **檢查版面投影片上的形狀**

一般投影片、版面投影片與母片各自擁有獨立的形狀集合。版面集合中的形狀不是與普通投影片上相同位置的形狀同一物件。當您需要了解或變更版面提供的格式時，請檢查版面形狀。

以下範例讀取每個版面形狀的 [FillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getFillFormat--) 與 [LineFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getLineFormat--)，且不假設每個形狀都是 `AutoShape`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

編輯版面可能會影響使用該版面的多個投影片。變更版面形狀前，請先確定普通投影片是繼承該物件還是有本地覆寫，並測試所有使用該版面的投影片。

## **將形狀匯出為 SVG**

[writeAsSvg](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) 會將單一形狀的渲染內容寫入串流。結果僅包含該形狀本身，不會包含整張投影片的背景或鄰近形狀。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

渲染時請保持簡報開啟。輸出取決於形狀的格式以及字型、影像等資源。若需要整個組合，請匯出投影片而非單一形狀。呼叫方負責管理串流，需自行關閉。

## **對齊形狀**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) 的多載可對齊全部形狀或選取的集合索引。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shapesalignmenttype/) 定義對齊的邊緣、中心線或分佈模式。將 `alignToSlide` 設為 `true` 以使用投影片邊緣；設為 `false` 則以相對於彼此的方式對齊選取的形狀。

此範例將三個形狀對齊至投影片的上緣。返回的形狀參考會在對齊前立即轉換為其當前索引。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

對齊會變更位置，而非 Z‑order。相對對齊通常需要至少兩個形狀，而水平或垂直分佈則需要足夠的形狀以定義間距。若在呼叫方法前修改了集合，請重新計算索引。

## **翻轉形狀**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shapeframe/) 類別儲存位置、大小、水平與垂直翻轉設定，以及旋轉角度。其 `getFlipH` 與 `getFlipV` 值使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/nullablebool/)：`True` 表示啟用翻轉，`False` 表示停用，`NotDefined` 代表保留未指定/預設狀態。

下方輸入的簡報僅包含一個未翻轉的形狀。

![The shape before flipping](shape_to_be_flipped.png)

此範例保留其他所有框架值，僅取代兩個翻轉設定。這點很重要，因為指派新的 [Frame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) 會取代整個框架。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

儲存的形狀會在水平與垂直方向上鏡像，同時保留其位置、大小與旋轉。

![The shape after flipping](flipped_shape.png)

## **FAQ**

**是否應該使用集合索引作為形狀識別子？**

僅在集合在使用索引前不會變更的短暫處理情境下可使用。對於已製作的模板，建議使用已驗證的 `Name` 或 `AlternativeText` 慣例；對於投影片層級的 Interop 工作，則使用 `OfficeInteropShapeId`。

**隱藏形狀會從 Z‑order 中移除嗎？**

不會。隱藏的形狀仍保留於集合中，索引不變。它仍可被尋找、重新排序、編輯或再次顯示。

**為何被複製的形狀會出現在另一個形狀前面？**

`addClone` 會將副本附加至集合的末端，即 Z‑order 的最前面。若要指定起始索引，可使用 `insertClone`，或在所有形狀加入後使用 `reorder`。

**我可以使用固定索引來識別預設形狀的調整項目嗎？**

僅在已驗證確切的預設與集合佈局後方可使用。更建議遍歷 `IGeometryShape.getAdjustments`，檢查 `IAdjustValue.getType`；當相同語意類型出現多次時，使用 `IAdjustValue.getName` 作為補充資訊。