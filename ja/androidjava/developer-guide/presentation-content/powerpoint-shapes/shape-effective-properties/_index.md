---
title: Android のプレゼンテーションからシェイプの有効なプロパティを取得する
linktitle: 有効なプロパティ
type: docs
weight: 50
url: /ja/androidjava/shape-effective-properties/
keywords:
- シェイプ プロパティ
- カメラ プロパティ
- ライト リグ
- ベベル シェイプ
- テキスト フレーム
- テキスト スタイル
- フォント 高さ
- 塗りつぶし 形式
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を介して Android 用 Aspose.Slides を使用し、PowerPoint プレゼンテーション内でローカル、継承、および有効なシェイプの書式設定を区別する方法を学びます。"
---
## **ローカル、継承、および有効なプロパティを理解する**

PowerPoint の書式設定は複数の場所から取得できます。オブジェクトに直接格納されている値は **ローカル値** と呼ばれます。その値が設定されていない場合、PowerPoint は段落のデフォルト、テキストスタイル、レイアウトまたはマスタースライド、テーマ、プレゼンテーション レベルのデフォルトなど、親の書式設定ソースを参照します。これらの値は **継承値** と呼ばれます。階層全体が解決された後に残る値が **有効値** であり、オブジェクトの描画に使用される値です。

たとえば、テキストの一部は独自のフォント高さを定義していない場合があります。そのローカル[getFontHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--)の値は `Float.NaN` となり、これは「ここでは設定されていない」ことを意味します。その部分は段落やプレゼンテーションのデフォルトテキストスタイル、または他の適用可能なソースから高さを継承できます。[getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportionformat/#getEffective--) を呼び出すと、部分書式の最終的に解決された高さが返されます。

目的に応じて、2 種類の書式設定データを使用します：

- 値がどこで定義されているかを制御したい場合は、[IPortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportionformat/) のようなローカル書式オブジェクトを読み取ったり変更したりします。
- 最終的なレンダリング結果が必要な場合は、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportionformateffectivedata/) のような有効データオブジェクトを読み取ります。有効データは読み取り専用です。

## **ローカル、継承、および有効な値の比較**

次の完全な例では、シェイプを作成し、プレゼンテーション、段落、そして部分レベルでフォント高さを設定します。各ステップでそれらのレベルで定義された値と、同じテキスト部分に対する結果の有効値を出力します。また、書式設定を変更した後に有効データを再度読み取る必要がある理由も示しています。

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

            // 2 つの異なるレベルで継承された値を定義します。
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // 部分のローカル値が継承された値の両方を上書きします。
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // 継承された値を変更しても、既存のローカル値は上書きされません。
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // ローカル値をクリアします。これにより、部分は再び段落から継承します。
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // 段落の値をクリアします。プレゼンテーションのデフォルトが結果を提供します。
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

        // 前の変更後に有効なデータを読み取ります。
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

この例における優先順位は、まず部分のローカル書式設定、次に段落の書式設定、最後にプレゼンテーションのデフォルトです。他のオブジェクトは異なる継承チェーンを持つ場合がありますが、原則は同じで、より具体的な明示的な値が優先され、[getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportionformat/#getEffective--) が最終結果を返します。

## **有効なテキストプロパティを取得する**

テキストの書式設定は複数のオブジェクトに分割されています：

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframeformat/#getEffective--) は、余白、アンカリング、自動調整、垂直テキスト方向などのテキストフレームのプロパティを解決します。
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextstyle/#getEffective--) は、各テキストスタイルレベルの段落書式設定を解決します。
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) は、配置、インデント、箇条書きなどの段落プロパティを解決します。
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportionformat/#getEffective--) は、フォント高さ、フォント、色、太字、斜体などの文字プロパティを解決します。

次の例では、`text-formatting.pptx` に少なくとも 1 枚のスライドと、空でないテキストフレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/autoshape/) が含まれている必要があります。AutoShape はシェイプコレクション内の任意の位置に存在して構いません。コードは適切なオブジェクトを検索し、使用前に検証します。

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

## **有効な 3D プロパティを取得する**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformat/#getEffective--) は、すべての解決済み 3D 設定をまとめた [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformateffectivedata/) オブジェクトを返します。その [getCamera](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformateffectivedata/#getCamera--)、[getLightRig](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformateffectivedata/#getLightRig--)、[getBevelTop](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--)、[getBevelBottom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) メソッドは、対応する有効データを取得できます。これらの関連設定をまとめて読むことで、シェイプの最終的な 3D 表示を理解しやすくなります。

この例では、`shape-3d.pptx` の最初のスライドに少なくとも 1 つのシェイプが含まれている必要があります。そのシェイプに 3D カメラ、照明、またはベベル設定を適用すれば、出力にデフォルト以外の値が含まれます。

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

## **有効なテーブル書式設定を取得する**

テーブルの書式設定は、テーブルスタイルやテーブル全体、列、行、個々のセルに適用された書式から取得されます。明示的に定義された塗りつぶしの競合がある場合、優先順位はセル、行、列、そしてテーブル全体です。セルの有効書式は、そのセルを描画する際に使用される最終的な書式です。

この例では、`table-formatting.pptx` の最初のスライドに少なくとも 1 つのテーブルが含まれている必要があります。そのテーブルは少なくとも 1 行と 1 列を持っている必要があります。コードは `getShapes().get_Item(0)` がテーブルであると仮定せず、[ITable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itable/) を検索します。

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

塗りつぶしタイプだけでなく色が必要な場合は、まず有効な[getFillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifillformateffectivedata/#getFillType--) を確認し、そのタイプに対応するメソッドを読み取ります。例として、単色塗りつぶしの場合は[getSolidFillColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) を使用します。

## **変更後に有効データを再読込する**

有効データは、解決時点の書式階層を表します。その階層に関与できるものを変更した後は、`getEffective` を再度呼び出します。対象項目は次のとおりです：

- オブジェクトのローカル書式設定；
- 段落またはテキストフレームのデフォルト；
- テーブルスタイル、テーブル、列、行、またはセルの書式；
- レイアウトまたはマスタースライドの書式設定；
- テーマデータまたはプレゼンテーション レベルのデフォルト；
- スライドに割り当てられたレイアウトまたはマスター。

有効データオブジェクトを永続的なスナップショットとして保持しないでください。Aspose.Slides は内部で一部の有効データをキャッシュする可能性があり、後で `getEffective` を呼び出すとそのデータが更新されます。変更前後の値を比較する必要がある場合は、フォント高さ、色、配置、ベベル幅など必要なスカラー値を変更前に自分の変数にコピーしてください。

値を変更するには、適切なローカル書式オブジェクトを更新し、`getEffective` を呼び出して結果を確認します。有効データオブジェクト自体は読み取り専用です。

## **FAQ**

**有効な値を提供したレベルはどのように特定できますか？**

有効データは最終的な値を保持しており、ソースは含まれません。最も具体的なレベルから外側へ向かって該当するローカルオブジェクトを確認してください。テキストの場合、portion、段落、テキストフレーム、レイアウト、マスター、テーマ、プレゼンテーションのデフォルトが含まれます。`Float.NaN` や `null` のように未定義の値は、別のレベルで検索が続くことを示します。

**プロパティがどのレベルでも定義されていない場合はどうなりますか？**

Aspose.Slides は適切な PowerPoint またはライブラリのデフォルトを解決します。その解決された値は、ローカルオブジェクトが明示的に定義していなくても有効データに表示されます。

**なぜ有効な値がローカル値と同じになることがあるのですか？**

ローカル値が継承計算で勝ったためです。オブジェクトにプロパティが明示的に設定され、より具体的なルールが上書きしない場合にこのようになります。

**ローカルデータを使用すべき時期はいつで、いつ有効データを使用すべきですか？**

ローカルデータは特定の書式レベルを検査または編集するために使用します。継承やテーマ規則、適用スタイルが解決された後の最終的な外観が必要な場合は有効データを使用します。[完全な比較例](#compare-local-inherited-and-effective-values) は同じワークフローで両方を示しています。