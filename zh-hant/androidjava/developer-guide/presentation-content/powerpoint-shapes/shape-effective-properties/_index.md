---
title: 從 Android 簡報中取得形狀的有效屬性
linktitle: 有效屬性
type: docs
weight: 50
url: /zh-hant/androidjava/shape-effective-properties/
keywords:
- 形狀屬性
- 相機屬性
- 光線裝置
- 斜角形狀
- 文字框
- 文字樣式
- 字體高度
- 填充格式
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何透過 Java 使用 Aspose.Slides for Android，在 PowerPoint 簡報中區分本機、繼承和有效的形狀格式設定。"
---
## **了解本機、繼承和有效屬性**

PowerPoint 格式化可能來自多個來源。直接儲存在物件上的值稱為 **本機值**。如果未設定該值，PowerPoint 會查看父層格式來源，例如段落預設、文字樣式、版面或母片投影片、佈景主題或簡報層級的預設。這些值稱為 **繼承值**。在整個階層解析完畢後剩餘的值即為 **有效值**——用於呈現物件的值。

例如，文字片段可能未定義自己的字體高度。其本機[getFontHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--)值為 `Float.NaN`，表示「此處未設定」。此片段可以從其段落、簡報的預設文字樣式或其他適用來源繼承高度。對該片段格式呼叫[getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportionformat/#getEffective--)會回傳最終解析的高度。

使用兩種格式化資料的目的不同：

- 讀取或變更本機格式物件，例如[IPortionFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportionformat/)，當您需要控制值的定義位置時。
- 讀取有效資料物件，例如[IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportionformateffectivedata/)，當您需要最終、已呈現的結果時。有效資料是唯讀的。

## **比較本機、繼承和有效值**

以下完整範例建立一個形狀，並在簡報、段落和片段層級套用字體高度。每個步驟會列印在這些層級定義的值以及相同文字片段的最終有效值。它同時說明為何在格式變更後必須再次讀取有效資料。

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // 定義在兩個不同層級的繼承值。
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // 片段上的本機值會覆蓋兩個繼承值。
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // 變更繼承值不會覆蓋已存在的本機值。
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // 清除本機值。片段現在再次從段落繼承。
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // 清除段落值。簡報預設現在提供結果。
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // 在前面的變更之後讀取有效資料。
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

此範例的優先順序為片段本機格式，然後是段落格式，最後是簡報預設。其他物件的繼承鏈可能不同，但原則相同：更具體的明確值會勝出，而[getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportionformat/#getEffective--)會回傳最終結果。

## **取得有效文字屬性**

文字格式分散於多個物件：

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/#getEffective--) 解析文字框屬性，如邊距、錨點、自動調整和垂直文字方向。
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextstyle/#getEffective--) 解析每個文字樣式層級的段落格式。
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) 解析段落屬性，如對齊、縮排和項目符號。
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportionformat/#getEffective--) 解析字元屬性，如字體高度、字型、顏色、粗體與斜體。

對於下一個範例，`text-formatting.pptx` 必須至少包含一張投影片以及一個包含非空文字框的[AutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/autoshape/)。AutoShape 可以出現在形狀集合的任何位置；程式碼會搜尋合適的物件並在使用前進行驗證。

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **取得有效 3D 屬性**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getEffective--) 回傳一個[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformateffectivedata/) 物件，將所有已解析的 3D 設定彙總。其[getCamera](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformateffectivedata/#getCamera--)、[getLightRig](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformateffectivedata/#getLightRig--)、[getBevelTop](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--) 與 [getBevelBottom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) 方法會曝光對應的有效資料。將這些相關設定一起讀取，可更容易了解形狀最終的 3D 外觀。

對於此範例，`shape-3d.pptx` 必須在第一張投影片上至少包含一個形狀。若要產出非預設值，請對該形狀套用 3D 相機、照明或斜角設定。

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **取得有效表格格式**

表格格式可能來自表格樣式，也可能來自套用於整個表格、欄、列或單一儲存格的格式。對於明確定義的填色衝突，優先順序為儲存格、列、欄、最後是整個表格。儲存格的有效格式即為繪製該儲存格時使用的最終格式。

對於此範例，`table-formatting.pptx` 必須在第一張投影片上至少包含一個表格，且該表格必須至少有一列和一欄。程式碼會搜尋[ITable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itable/)，而不是假設 `getShapes().get_Item(0)` 為表格。

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

如果您需要取得顏色而不僅僅是填充類型，請先檢查有效的[getFillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifillformateffectivedata/#getFillType--)，然後讀取對應類型的方法──例如，對於實心填充，使用[getSolidFillColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--)。

## **變更後重新讀取有效資料**

有效資料描述解析當時的格式階層。變更任何可能參與該階層的項目後，請再次呼叫 `getEffective`，包括：

- 物件的本機格式；
- 段落或文字框的預設；
- 表格樣式、表格、欄、列或儲存格格式；
- 版面或母片投影片的格式；
- 佈景主題或簡報層級的預設；
- 指派給投影片的版面或母片。

不要將有效資料物件當作永久快照保存。Aspose.Slides 可能在內部快取部分有效資料，稍後的 `getEffective` 呼叫會重新整理該資料。如果需要在變更前後比較值，請在變更前將需要的純量值（例如字體高度、顏色、對齊或斜角寬度）複製到自己的變數中。

若要變更值，請更新相應的本機格式物件，然後呼叫 `getEffective` 以驗證結果。有效資料物件本身是唯讀的。

## **FAQ**

**如何判斷是哪個層級提供了有效值？**

有效資料僅包含最終值，未指明其來源。請從最具體的層級向外檢查相應的本機物件。對於文字，可能包括片段、段落、文字框、版面、母片、佈景主題以及簡報預設。`Float.NaN` 或 `null` 等未定義值表示搜尋會繼續往更高層級進行。

**當沒有任何層級定義屬性時會發生什麼？**

Aspose.Slides 會解析出相應的 PowerPoint 或函式庫預設值。即使沒有本機物件明確定義，解析後的預設值仍會出現在有效資料中。

**為什麼有效值有時會等於本機值？**

本機值在繼承計算中獲勝。這在屬性已在物件上明確設定且沒有更具體的規則覆寫時是正常的。

**何時應使用本機資料而非有效資料？**

當您需要檢查或編輯特定層級的格式時，使用本機資料。當您需要在繼承、主題規則和相關樣式全部解析後的最終外觀時，使用有效資料。完整的[比較範例](#compare-local-inherited-and-effective-values)在同一工作流程中演示了兩者的使用方式。