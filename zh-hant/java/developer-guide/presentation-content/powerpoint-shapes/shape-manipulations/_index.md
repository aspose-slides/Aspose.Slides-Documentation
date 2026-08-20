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
- 圖形版面格式
- 圖形為 SVG
- 圖形轉 SVG
- 對齊圖形
- 翻轉圖形
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 識別、複製、移除、隱藏、重新排序、匯出、對齊與翻轉簡報圖形。"
---
## **概觀**

Aspose.Slides for Java 將投影片上的圖形表示為有序的 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/)。此集合同時是您尋找與修改圖形的所在，也是它們堆疊順序的來源：索引 `0` 為最背後的圖形，而最後一個索引則為最前面的圖形。

本篇文章遵循此模型。首先說明如何可靠地辨識圖形，接著示範如何複製、移除、隱藏與重新排序圖形。最後的章節涵蓋版面層級的格式設定、SVG 匯出、對齊以及翻轉設定。每個範例都是獨立的，您可以只使用工作流程所需的操作。

## **辨識與尋找圖形**

在處理已知檔案時，集合索引相當方便，但它們並非穩定的識別子。加入、移除或重新排序圖形都可能改變其索引。請根據簡報的編寫與維護方式選擇識別子：

- [Name](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getName--) 在開發者控制的範本中很有用，且可在 PowerPoint 的「選取窗格」中輕鬆檢查。名稱可編輯且不保證唯一，若程式碼依賴名稱，請建立命名慣例。
- [AlternativeText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getAlternativeText--) 在已有無障礙說明或作者自行標記的情況下很有用。它會對使用者可見，可能會本地化或為無障礙目的重新編寫，且不保證唯一。請勿無聲地將有意義的無障礙文字重新作為資料庫鍵。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) 是唯讀識別子，在投影片內唯一，對應 PowerPoint 互通使用的圖形 ID。於與 PowerPoint 整合或在圖形存活期間需要明確參照時使用。複製或重新建立的圖形是不同的圖形，會獲得自己的 ID。

相關的 [getUniqueId](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getUniqueId--) 方法傳回範圍為簡報的識別子，但此識別子僅供附加元件使用，可能會被重新指派。不要將它視為永久的外部鍵。若長期身份至關重要，請在應用程式資料中保留對映，並驗證預期的圖形仍然存在。

以下範例以名稱進行精確比較搜尋，並回報投影片範圍的 interop ID。當範本未包含預期圖形時，程式碼會回報此結果而非繼續使用錯誤的物件。

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

當操作特定於圖形類型時，請在使用類型專屬成員前先檢查介面。本範例僅在命名物件為 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/) 時更新文字與替代文字。

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

## **修改圖形集合**

新增、複製、移除與重新排序方法會立即作用於集合。若某項操作改變了圖形的數量或順序，請勿再依賴該操作前取得的索引。

### **複製圖形**

[addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) 會建立獨立的副本並將其附加至目標集合。[insertClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) 也會建立副本，但會放置在指定的 Z 序索引。接受座標的重載會在不改變大小的情況下移動副本；接受寬度與高度的重載則可同時調整大小。

此範例建立目的投影片，將帶標籤的矩形複製至最前面，並在最背後插入第二個副本。對任一副本的變更皆不會影響來源圖形。

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

複製會將圖形的內容與格式（包括名稱與替代文字）一起複製。若這些值必須唯一，請為副本指派新的邏輯識別子。複雜圖形使用的資源由簡報負責處理，但複製後仍是具有新圖形身分的新集合項目。

### **移除圖形**

[remove](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 會從其集合中刪除指定的圖形物件。於索引式迭代時移除多筆符合條件的圖形，請自行從結尾向前遍歷，以確保每個剩餘索引仍然有效。

此範例移除所有具有指定名稱的圖形。它在當前索引讀取圖形，而非固定的集合項目，且不會不必要地轉型圖形。

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

移除後，圖形數量與後續圖形的索引皆會變更。相較於已儲存的索引，對未受影響圖形的引用更為可靠。亦須考慮連接線、動畫與其他簡報功能可能仍參照被移除的物件；移除可見圖形可能會改變投影片外觀以外的其他內容。

### **隱藏圖形**

將 [Hidden](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#setHidden-boolean-) 設為 `true` 會保留圖形於集合中，但阻止其在一般投影片放映中顯示。其索引、格式與內容仍可供程式碼存取，適用於可能稍後恢復的可選元素。

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

隱藏並非刪除或安全機制。使用者或程式碼仍能找到並取消隱藏，且它仍是簡報檔案的一部份。

### **變更 Z 序**

重疊的圖形會依集合順序繪製。[reorder](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) 會將既有圖形移至目標索引，且不會產生複製。索引 `0` 為最背後；`size() - 1` 為最前面。

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

矩形最先建立，最初位於橢圓之後。將其移至最後索引即會置於前面。於加入或複製所有相關圖形後再完成 Z 序的最終調整，因為這些操作會附加或插入新集合項目，可能改變原先的堆疊順序。

## **檢查版面投影片上的圖形**

普通投影片、版面投影片與母片投影片各自擁有獨立的圖形集合。版面集合中的圖形並非與普通投影片上同位置圖形相同的物件。當需要了解或變更版面提供的格式時，請檢查版面圖形。

以下範例讀取每個版面圖形的 [FillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getFillFormat--) 與 [LineFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getLineFormat--)，且未假設每個圖形皆為 `AutoShape`。

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

編輯版面可能會影響使用該版面的多張投影片。變更版面圖形前，請先確認普通投影片是繼承該物件，還是具有本地覆寫，並測試所有使用該版面的投影片。

## **將圖形匯出為 SVG**

[writeAsSvg](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) 會將單一圖形的渲染內容寫入串流。結果僅包含該圖形本身，並不包含整張投影片的背景或相鄰圖形。

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

在渲染時請保持簡報開啟。輸出受圖形格式以及字型、影像等資源影響。若需要完整的組合圖，請匯出投影片而非單一圖形。呼叫端負責擁有並關閉串流。

## **對齊圖形**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) 的重載可對全部圖形或選取的集合索引進行對齊。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shapesalignmenttype/) 指定邊緣、中心線或分布模式。將 `alignToSlide` 設為 `true` 以使用投影片邊緣；設為 `false` 則相對於彼此對齊所選圖形。

此範例將三個圖形對齊至投影片的上緣。返回的圖形參考會在對齊前立即轉換為目前的索引。

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

對齊會變更位置，而非 Z 序。相對對齊通常需要至少兩個圖形；水平或垂直分布則需足夠的圖形以定義間距。若在呼叫方法前修改了集合，請重新計算索引。

## **翻轉圖形**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shapeframe/) 類別儲存位置、大小、水平與垂直翻轉設定，以及旋轉。其 `getFlipH` 與 `getFlipV` 值使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/nullablebool/) ：`True` 表示啟用翻轉，`False` 表示停用，`NotDefined` 保留未指定/預設狀態。

以下輸入簡報包含一個未翻轉的圖形。

![翻轉前的圖形](shape_to_be_flipped.png)

此範例保留其他所有框架值，僅替換兩個翻轉設定。這點很重要，因為指派新 [Frame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) 會取代完整的框架。

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

儲存的圖形會水平與垂直鏡像，同時保留其位置、大小與旋轉。

![翻轉後的圖形](flipped_shape.png)

## **常見問題集**

**我可以使用集合索引作為圖形識別子嗎？**

僅限於集合在使用索引前不會變動的短暫處理。對於已編寫的範本，建議使用已驗證的 `Name` 或 `AlternativeText` 慣例；若為投影片範圍的互通工作，則使用 `OfficeInteropShapeId`。

**隱藏圖形會從 Z 序中移除嗎？**

不會。隱藏的圖形仍保留於集合中且索引不變。它仍可被尋找、重新排序、編輯或重新顯示。

**為什麼複製的圖形會出現在另一圖形前面？**

`addClone` 會將副本附加至集合的末端，也就是 Z 序的最前端。若要選擇初始索引，可使用 `insertClone`，或在所有圖形加入後使用 `reorder`。