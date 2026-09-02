---
title: 管理 Android 上的簡報形狀
linktitle: 形狀操作
type: docs
weight: 40
url: /zh-hant/androidjava/shape-manipulations/
keywords:
- PowerPoint 形狀
- 簡報形狀
- 投影片上的形狀
- 尋找形狀
- 克隆形狀
- 移除形狀
- 隱藏形狀
- 變更形狀順序
- 取得 interop 形狀 ID
- 形狀替代文字
- 形狀版面格式
- 形狀作為 SVG
- 形狀轉 SVG
- 對齊形狀
- 翻轉形狀
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 識別、克隆、移除、隱藏、重新排序、匯出、對齊及翻轉簡報形狀。"
---
## **概觀**

Aspose.Slides for Android via Java 將投影片上的形狀表示為有序的 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/)。此集合不僅是您尋找和修改形狀的地方，也是它們堆疊順序的來源：索引 `0` 為最背面的形狀，而最後一個索引則為最前面的形狀。

本文遵循此模型。它首先說明如何可靠地辨識形狀，接著展示如何克隆、移除、隱藏和重新排列形狀。最後的章節涵蓋版面層級格式設定、SVG 匯出、對齊以及翻轉設定。每個範例都是獨立的，您可以只使用工作流程所需的操作。

## **辨識與尋找形狀**

在處理已知檔案時，集合索引很方便，但它們並非穩定的識別子。新增、移除或重新排列形狀都會改變其索引。請根據簡報的編寫與維護方式選擇識別子：

- [Name](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getName--) 對於開發人員控制的範本非常有用，且可在 PowerPoint 的「選取窗格」中輕鬆檢視。名稱可編輯且不保證唯一，因此若程式碼依賴名稱，請建立命名規則。
- [AlternativeText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getAlternativeText--) 當可存取性說明或作者提供的標籤已經辨識形狀時很有用。它會顯示給使用者，可能會本地化或為可及性重新撰寫，且不保證唯一。切勿將具意義的可及性文字靜默地改作資料庫鍵值。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) 是唯讀識別子，在投影片內唯一，對應 PowerPoint 互操作使用的形狀 ID。當與 PowerPoint 整合或需要在形狀生命週期內取得明確參照時使用。被克隆或重新建立的形狀會是不同的形狀，並獲得自己的 ID。

相關的 [getUniqueId](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getUniqueId--) 方法會回傳投影片範圍內的識別子，但該識別子旨在外掛程式使用，且可能被重新指派。不要將其視為永久的外部鍵。若長期身份認證很重要，請將映射保存在應用程式資料中，並驗證預期的形狀仍然存在。

以下範例以完全相等比較依名稱搜尋，並回報投影片範圍的互操作 ID。當範本未包含預期形狀時，程式會回報該結果，而不會繼續使用錯誤的物件。

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

當操作針對特定形狀類型時，請先檢查介面再使用類型特定的成員。此範例僅在命名物件是 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 時才更新文字與替代文字。

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

## **修改形狀集合**

新增、克隆、移除與重新排序方法會立即作用於集合。如果操作改變了形狀的數量或順序，請不要繼續依賴先前取得的索引。

### **克隆形狀**

[addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) 建立獨立的副本並將其附加到目標集合。 [insertClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) 也會建立副本，但會放置在指定的 Z 軸順序索引。接受座標的多載會在不變更大小的情況下移動副本；接受寬度與高度的多載則可同時調整大小。

此範例建立目的投影片，將帶標籤的矩形克隆至前端，並在後端插入第二個克隆。對任一克隆的變更不會修改來源形狀。

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

克隆會複製形狀的內容與格式，包括名稱與替代文字。當這些值必須唯一時，請為克隆指派新的邏輯識別子。複雜形狀使用的資源由簡報負責管理，但克隆仍是具有新形狀身份的新集合項目。

### **移除形狀**

[remove](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) 從其集合中刪除特定形狀物件。當在索引化迭代期間移除多個符合項目時，請自末端向前遍歷，以保持其餘索引的有效性。

此範例移除所有具有指定名稱的形狀。它讀取目前索引處的形狀，而非固定的集合項目，且不會不必要地轉型形狀。

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

移除後，形狀總數與之後形狀的索引會改變。對未受影響形狀的參考比已儲存的索引更可靠。另外，請考慮連接線、動畫與其他可能參照被移除物件的簡報功能；移除可見形狀可能會改變不只投影片的外觀。

### **隱藏形狀**

將 [Hidden](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) 設為 `true` 會保留形狀於集合中，但阻止其在一般投影片放映中出現。其索引、格式與內容仍可供程式碼存取，因此隱藏適用於日後可能恢復的可選元素。

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

隱藏並非刪除或安全機制。使用者或程式碼仍可發現並取消隱藏，且它仍是簡報檔案的一部份。

### **變更 Z 軸順序**

重疊的形狀會依集合順序繪製。[reorder](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) 會將既有形狀移至目標索引而不進行克隆。索引 `0` 為最背面；`size() - 1` 為最前面。

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

先建立矩形，最初位於橢圓之後。將它移至最後索引即會置於前端。請在加入或克隆所有相關形狀後再完成 Z 軸順序的最終設定，因為這些操作會附加或插入新集合項目，可能改變原有堆疊。

## **檢查版面投影片上的形狀**

普通投影片、版面投影片與母片投影片各自擁有獨立的形狀集合。版面集合中的形狀並非與普通投影片上相同位置的形狀同一物件。當需要了解或變更版面提供的格式時，請檢查版面形狀。

以下範例讀取每個版面形狀的 [FillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getFillFormat--) 與 [LineFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getLineFormat--)，且不假設每個形狀皆為 `AutoShape`。

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

編輯版面可能會影響使用該版面的多張投影片。變更版面形狀前，請先確定普通投影片是繼承該物件或包含本機覆寫，並測試所有使用該版面的投影片。

## **將形狀匯出為 SVG**

[writeAsSvg](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) 會將單一形狀的渲染內容寫入串流。結果只包含該形狀，不會包含整張投影片的背景或鄰近形狀。

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

渲染時請保持簡報開啟。輸出受形狀格式以及字型、圖片等資源影響。若需要整個組合，請匯出投影片而非單一形狀。呼叫端擁有串流並負責關閉它。

## **對齊形狀**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) 的多載可對齊全部形狀或選取的集合索引。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shapesalignmenttype/) 定義邊緣、中心線或分布模式。將 `alignToSlide` 設為 `true` 以使用投影片邊緣；設為 `false` 則相對於彼此對齊選取的形狀。

此範例將三個形狀對齊至投影片上緣。對齊前會立即將回傳的形狀參考轉換為目前的索引。

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

對齊會改變位置，而非 Z 軸順序。相對對齊通常需要至少兩個形狀，而水平或垂直分布則需要足夠的形狀以定義間距。若在呼叫方法前修改了集合，請重新計算索引。

## **翻轉形狀**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shapeframe/) 類別儲存位置、大小、水平與垂直翻轉設定，以及旋轉。其 `getFlipH` 與 `getFlipV` 值使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/nullablebool/)：`True` 啟用翻轉，`False` 停用翻轉，`NotDefined` 保留未指定/預設狀態。

以下輸入簡報包含一個未翻轉的形狀。

![The shape before flipping](shape_to_be_flipped.png)

此範例保留所有其他框架值，僅替換兩個翻轉設定。這很重要，因為指派新 [Frame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) 會取代整個框架。

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

儲存的形狀會水平與垂直鏡射，同時保留其位置、大小與旋轉。

![The shape after flipping](flipped_shape.png)

## **常見問題**

**應該使用集合索引作為形狀識別子嗎？**

僅在短期處理且集合在使用索引前不會變更的情況下使用。對於作者自行編寫的範本，建議使用已驗證的 `Name` 或 `AlternativeText` 規則；對於投影片範圍的互操作工作，則使用 `OfficeInteropShapeId`。

**隱藏形狀會從 Z 軸順序中移除嗎？**

不會。隱藏的形狀仍保留在相同索引的集合中。它仍可被找到、重新排序、編輯或重新顯示。

**為何克隆的形狀會出現在另一個形狀的前面？**

`addClone` 會將克隆附加到集合的末端，也就是 Z 軸順序的最前端。若要指定初始索引，請使用 `insertClone`，或在全部形狀加入後使用 `reorder`。