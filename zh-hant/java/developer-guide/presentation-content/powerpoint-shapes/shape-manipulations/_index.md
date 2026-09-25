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
- 移除圖形
- 隱藏圖形
- 變更圖形順序
- 取得 interop 圖形 ID
- 圖形替代文字
- 圖形調整點
- 預設圖形調整
- 圖形幾何
- 圖形版面格式
- 圖形為 SVG
- 圖形轉 SVG
- 對齊圖形
- 翻轉圖形
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 識別、調整、複製、移除、隱藏、重新排序、匯出、對齊與翻轉簡報圖形。"
---
## **概觀**

Aspose.Slides for Java 以有序的 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/) 來表示投影片上的圖形。此集合同時是您尋找與修改圖形的所在，也是它們堆疊順序的來源：索引 `0` 為最背面的圖形，而最後的索引則是最前面的圖形。

本篇文章遵循此模型。首先說明如何可靠地識別圖形並修改預設的圖形調整點，接著示範如何複製、移除、隱藏與重新排序圖形。最後的章節涵蓋版面層級的格式設定、SVG 匯出、對齊與翻轉設定。每個範例皆獨立，您可僅使用工作流程所需的操作。

## **識別與尋找圖形**

在處理已知檔案時，集合索引很方便，但它們並非穩定的識別子。新增、移除或重新排序圖形都會改變其索引。請依照投影片的製作與維護方式選擇識別子：

- [Name](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getName--) 適用於開發人員控制的範本，且可在 PowerPoint 的「選取窗格」中輕鬆檢視。名稱可以編輯且不保證唯一，因此若程式碼依賴名稱，請建立命名慣例。
- [AlternativeText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getAlternativeText--) 在已具備無障礙描述或作者自行加入的標籤時很有用。它對使用者可見、可能會本地化或為無障礙需求重新撰寫，但同樣不保證唯一。不要在未檢查的情況下將有意義的無障礙文字作為資料庫鍵使用。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) 為唯讀識別子，在同一投影片內唯一，對應 PowerPoint Interop 使用的圖形 ID。當需要與 PowerPoint 整合或在圖形生命週期內取得明確參照時使用。已複製或重新建立的圖形會是不同的圖形，並取得自己的 ID。

相關的 [getUniqueId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getUniqueId--) 方法會返回作用於整個簡報範圍的識別子，但該識別子僅供外掛使用，可能會被重新指派。不要將它視為永久的外部鍵。若長期身份辨識相當重要，請將映射保留於應用程式資料中，並驗證預期的圖形仍然存在。

若要參考同時讀取與更新「Alternative Text」的標題與說明，請參閱 [Manage Alternative Text Titles and Descriptions](/slides/zh-hant/java/presentation-accessibility/)。使用 alternative text 來向讀者說明視覺元素的含意，並將其與程式碼用於尋找圖形的名稱分開。

以下範例以完全相等的比較方式依名稱搜尋，並回報投影片範圍的 Interop ID。當範本未包含預期的圖形時，程式會回報該結果，而非繼續使用錯誤的物件。

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

當操作特定於圖形類型時，請先檢查介面再使用類型專屬的成員。此範例僅在具名物件是 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 時，才更新文字與 alternative text。

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

## **識別與修改預設圖形調整**

預設幾何圖形可能會公開調整點，以控制角落大小、箭頭比例或弧度等特徵。透過唯讀的 [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/igeometryshape/#getAdjustments--) 集合存取它們。集合本身由圖形提供，但每個 [IAdjustValue](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iadjustvalue/) 包含可變更的值。

不要只依賴固定的集合索引。遍歷調整項目並檢查唯讀的 [getType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iadjustvalue/#getType--) 方法，其 [ShapeAdjustmentType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shapeadjustmenttype/) 值說明此調整控制什麼。唯讀的 [getName](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iadjustvalue/#getName--) 方法提供額外的識別資訊，特別在同一預設含有多個相同語意類型的調整時很有用。

使用與調整意義相符的值方法：

| 調整類型 | 目的 | 要變更的值 |
|---|---|---|
| `CornerSize` | 圓角的大小 | [setRawValue](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | 箭尾的粗細 | `setRawValue` |
| `ArrowheadLength` | 箭頭的長度 | `setRawValue` |
| `ArrowheadWidth` | 箭頭的寬度 | `setRawValue` |
| `StartAngle` | 圓餅或弧線的起始角度 | [setAngleValue](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | 圓餅或弧線的結束角度 | `setAngleValue` |

`getType` 與 `getName` 只回傳唯讀資訊。`getRawValue` 與 `setRawValue` 使用預設幾何單位的整數，而 `getAngleValue` 與 `setAngleValue` 使用度數。調整的數量、順序、意義與有效範圍取決於預設的 [ShapeType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/igeometryshape/#getShapeType--)。對某一預設有效的值，對其他預設可能無效或產生不同效果。

當 `getType` 回傳 `ShapeAdjustmentType.Custom` 時，API 無法辨識標準語意。檢查 `getName`、預設類型與現有值，除非已知預期含意與範圍，否則保留調整不變。即使是已辨識的類型，在選擇值前也要確認相同類型是否出現多次。連接線彎曲調整的情況請參考 [Connector](/slides/zh-hant/java/connector/) 文章。

以下完整範例建立三個預設圖形的預設與修改版本。它遍歷每個調整，回報名稱與類型，透過 `setRawValue` 改變尺寸相關的值，透過 `setAngleValue` 改變角度，並儲存結果。左欄保留預設幾何；右欄則顯示調整後的圓角矩形、四向箭頭與圓餅圖。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 為預設和已調整的圖形欄位新增標題。
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

在變更值之前檢查語意類型，使程式碼能清楚表達意圖，並避免假設不同預設圖形的相同集合索引具有相同意義。

## **修改圖形集合**

新增、複製、移除與重新排序方法會立即作用於集合。若某操作改變了圖形的數量或順序，請勿繼續依賴該操作前捕獲的索引。

### **複製圖形**

[addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) 會建立獨立的副本，並將其附加至目標集合的末端。[insertClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) 也會建立副本，但會放置在指定的 Z 軸索引處。接受座標的重載會在不變更大小的情況下移動副本；接受寬度與高度的重載則可同時調整大小。

此範例建立目的投影片，將一個已標記的矩形複製到前端，並在背端插入第二個副本。對任一副本的變更不會影響來源圖形。

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

複製會一起帶走圖形的內容與格式，包括名稱與 alternative text。若這些值必須唯一，請為副本指派新的邏輯識別子。複雜圖形使用的資源由簡報本身管理，但副本仍是具有新圖形識別的新集合項目。

### **移除圖形**

[remove](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 會從其集合中刪除特定圖形物件。於索引迭代期間移除多個匹配項目時，請從結尾向前遍歷，以確保每個剩餘索引仍然有效。

此範例移除所有具指定名稱的圖形。它在當前索引讀取圖形，而非固定的集合項目，且不會不必要地轉型圖形。

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

移除後，圖形計數以及後續圖形的索引會改變。對未受影響的圖形的參照比保存的索引更可靠。亦請考慮連接線、動畫及其他可能參照被移除物件的簡報功能；移除可見圖形可能會改變投影片外觀以外的更多內容。

### **隱藏圖形**

設定 [Hidden](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#setHidden-boolean-) 為 `true` 會保留圖形於集合中，但阻止其在一般投影片放映中出現。其索引、格式與內容仍可供程式碼存取，因此隱藏適用於未來可能恢復的可選元素。

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

隱藏並非刪除或安全機制。使用者或程式碼仍可發現並將其取消隱藏，且它仍是簡報檔案的一部份。

### **變更 Z 軸順序**

重疊的圖形會依集合順序繪製。[reorder](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) 會將現有圖形移動至目標索引，而不會複製它。索引 `0` 為最背面；`size() - 1` 為最前面。

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

矩形最先建立，最初位於橢圓的背後。將其移動到最後的索引即會置於前端。於加入或複製所有相關圖形後最後調整 Z 軸順序，因為這些操作會附加或插入新集合項目，可能會改變預期的堆疊。

## **檢查版面投影片上的圖形**

一般投影片、版面投影片與母片都有各自的圖形集合。版面集合中的圖形並非與普通投影片上同位置圖形相同的物件。當需要了解或變更版面提供的格式時，請檢查版面圖形。

以下範例讀取每個版面圖形的 [FillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getFillFormat--) 與 [LineFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getLineFormat--)，且不假設每個圖形都是 `AutoShape`。

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

編輯版面可能會影響多個使用該版面的投影片。變更版面圖形前，請先判斷普通投影片是繼承該物件還是有本地覆寫，並測試所有使用該版面的投影片。

## **將圖形匯出為 SVG**

[writeAsSvg](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) 會將單一圖形的渲染內容寫入串流。結果只包含該圖形本身，而不含整張投影片的背景或相鄰圖形。

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

渲染期間請保持簡報開啟。輸出內容取決於圖形的格式以及字型、影像等資源。若需要整個組合，請匯出投影片而非單一圖形。呼叫端負責擁有並關閉串流。

## **對齊圖形**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) 的重載可對全部圖形或選取的集合索引進行對齊。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shapesalignmenttype/) 指定對齊的邊緣、中心線或分佈模式。將 `alignToSlide` 設為 `true` 會使用投影片邊緣；設為 `false` 則相對於彼此對齊選取的圖形。

此範例將三個圖形對齊至投影片的上緣。對齊前會立即將返回的圖形參照轉換為當前索引。

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

對齊會變更位置，而非 Z 軸順序。相對對齊通常至少需要兩個圖形，水平或垂直分佈則需要足夠的圖形以定義間距。若在呼叫方法前修改了集合，請重新計算索引。

## **翻轉圖形**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shapeframe/) 類別儲存位置、大小、水平與垂直翻轉設定，以及旋轉。其 `getFlipH` 與 `getFlipV` 值使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/nullablebool/)：`True` 代表啟用翻轉，`False` 代表停用，`NotDefined` 則保留未指定/預設狀態。

以下輸入簡報僅包含一個未翻轉的圖形。

![翻轉前的圖形](shape_to_be_flipped.png)

此範例保留其他所有框架值，僅取代兩個翻轉設定。這點很重要，因為指派新的 [Frame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) 會取代整個框架。

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

儲存的圖形會在水平與垂直兩方向鏡像，同時保留其位置、大小與旋轉。

![翻轉後的圖形](flipped_shape.png)

## **常見問題**

**我可以將集合索引作為圖形識別子嗎？**

僅在集合在使用索引前不會變動的短暫處理情境下可行。對於已製作的範本，建議使用經驗證的 `Name` 或 `AlternativeText` 命名慣例；對於投影片範圍的 Interop 工作，則使用 `OfficeInteropShapeId`。

**隱藏圖形會將其從 Z 軸順序中移除嗎？**

不會。隱藏的圖形仍保留於集合的相同索引。它仍可被找到、重新排序、編輯或再次顯示。

**為什麼複製的圖形會出現在另一個圖形的前面？**

`addClone` 會將副本附加至集合的末端，也就是 Z 軸的前端。若要指定初始索引，可使用 `insertClone`，或在全部圖形加入後使用 `reorder`。

**我可以使用固定索引辨識預設圖形的調整嗎？**

只有在已驗證確切的預設與集合布局後才可。建議遍歷 `IGeometryShape.getAdjustments`，檢查 `IAdjustValue.getType`；若同一語意類型出現多次，可使用 `IAdjustValue.getName` 取得額外資訊。