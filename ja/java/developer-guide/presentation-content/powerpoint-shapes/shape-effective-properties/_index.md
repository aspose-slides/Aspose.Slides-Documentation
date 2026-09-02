---
title: Java のプレゼンテーションからシェイプの実効プロパティを取得する
linktitle: 実効プロパティ
type: docs
weight: 50
url: /ja/java/shape-effective-properties/
keywords:
- シェイプ プロパティ
- カメラ プロパティ
- ライト リグ
- ベベル シェイプ
- テキスト フレーム
- テキスト スタイル
- フォント 高さ
- 塗りつぶし フォーマット
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーションにおけるローカル、継承、および実効シェイプ書式設定を区別する方法を学びます。"
---
## **ローカル、継承、および実効プロパティの理解**

PowerPoint の書式設定は複数の場所から取得されます。オブジェクトに直接保存されている値は **ローカル値** と呼ばれます。その値が設定されていない場合、PowerPoint は段落のデフォルト、テキストスタイル、レイアウトまたはマスタースライド、テーマ、プレゼンテーションレベルのデフォルトなど、親の書式設定ソースを参照します。これらの値は **継承値** と呼ばれます。階層全体が解決された後に残る値が **実効値** であり、オブジェクトの描画に使用される値です。

例えば、テキストの一部がフォント高さを独自に定義していない場合があります。そのローカルの[getFontHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) の値は `Float.NaN` となり、これは「ここでは設定されていない」ことを意味します。この部分は段落やプレゼンテーションのデフォルトテキストスタイル、その他の適用可能なソースから高さを継承できます。部分のフォーマットで[getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportionformat/#getEffective--) を呼び出すと、最終的に解決された高さが返されます。

異なる目的で2種類の書式データを使用します：

- 値がどこで定義されているかを制御する必要がある場合は、[IPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportionformat/) のようなローカルフォーマットオブジェクトを読み取るか変更します。
- 最終的なレンダリング結果が必要な場合は、[IPortionFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportionformateffectivedata/) のような実効データオブジェクトを読み取ります。実効データは読み取り専用です。

## **ローカル、継承、および実効値の比較**

以下の完全な例では、シェイプを作成し、プレゼンテーション、段落、および部分レベルでフォント高さを設定します。各ステップでそれらのレベルで定義された値と、同じテキスト部分の結果として得られる実効値を出力します。また、書式変更後に実効データを再度読み取る必要がある理由も示しています。

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

            // 部分のローカル値が両方の継承値を上書きします。
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // 継承値を変更しても、既存のローカル値は上書きされません。
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // ローカル値をクリアします。部分は再び段落から継承します。
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

        // 前の変更後に実効データを読み取ります。
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

この例の優先順位は、部分のローカル書式 → 段落書式 → プレゼンテーションのデフォルトです。他のオブジェクトは異なる継承チェーンを持つことがありますが、原則は同じです。より具体的な明示的値が優先され、[getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportionformat/#getEffective--) が最終結果を返します。

## **実効テキストプロパティの取得**

テキストの書式設定は複数のオブジェクトに分割されています：

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframeformat/#getEffective--) は、余白、アンカー、オートフィット、垂直テキスト方向などのテキストフレームプロパティを解決します。
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextstyle/#getEffective--) は、各テキストスタイルレベルの段落書式を解決します。
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getEffective--) は、配置、インデント、箇条書きなどの段落プロパティを解決します。
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportionformat/#getEffective--) は、フォント高さ、書体、色、ボールド、イタリックなどの文字プロパティを解決します。

次の例では、`text-formatting.pptx` に少なくとも 1 枚のスライドと、空でないテキストフレームを持つ 1 つの[AutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/autoshape/) が必要です。AutoShape はシェイプコレクションの任意の位置に配置できます。コードは適切なオブジェクトを検索し、使用前に検証します。

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

## **実効 3D プロパティの取得**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformat/#getEffective--) は、すべての解決済み 3D 設定をまとめた 1 つの[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformateffectivedata/) オブジェクトを返します。その [getCamera](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--)、[getLightRig](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--)、[getBevelTop](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--)、[getBevelBottom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) メソッドはそれぞれ対応する実効データを公開します。これらの関連設定をまとめて読み取ることで、シェイプの最終的な 3D 外観を理解しやすくなります。

この例では、`shape-3d.pptx` に最初のスライドに少なくとも 1 つのシェイプが含まれている必要があります。そのシェイプに 3D カメラ、照明、またはベベル設定を適用すると、デフォルト以外の値が出力に反映されます。

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

## **実効テーブル書式の取得**

テーブルの書式設定はテーブルスタイルと、テーブル全体、列、行、個々のセルに適用された書式の両方から取得されます。明示的に定義された塗りつぶしが競合する場合、優先順位はセル → 行 → 列 → テーブル全体です。セルの実効書式は、そのセルを描画する際に使用される最終書式です。

この例では、`table-formatting.pptx` に最初のスライドに少なくとも 1 つのテーブルが必要です。テーブルは少なくとも 1 行と 1 列を持っている必要があります。コードは `getShapes().get_Item(0)` がテーブルであると仮定せず、[ITable](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itable/) を検索します。

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

色が必要で塗りタイプだけでなく実際の色が必要な場合は、まず実効 [getFillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifillformateffectivedata/#getFillType--) を確認し、そのタイプに対応するメソッド（例: ソリッド塗りの場合は [getSolidFillColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--)）を読み取ります。

## **変更後に実効データを再取得する**

実効データは解決時点の書式階層を表します。階層に参加できる要素を変更した後は、`getEffective` を再度呼び出してください。対象となる要素は次のとおりです：

- オブジェクトのローカル書式
- 段落またはテキストフレームのデフォルト
- テーブルスタイル、テーブル、列、行、セルの書式
- レイアウトまたはマスタースライドの書式
- テーマデータまたはプレゼンテーションレベルのデフォルト
- スライドに割り当てられたレイアウトまたはマスタ

実効データオブジェクトを永続的なスナップショットとして保持しないでください。Aspose.Slides は内部で実効データをキャッシュすることがあり、後続の `getEffective` 呼び出しでデータが更新されます。変更前後の値を比較したい場合は、フォント高さ、色、配置、ベベル幅など必要なスカラー値を自分の変数にコピーしてから変更を加えてください。

値を変更するには、該当するローカルフォーマットオブジェクトを更新し、`getEffective` を呼び出して結果を検証します。実効データオブジェクト自体は読み取り専用です。

## **FAQ**

**実効値がどのレベルから供給されたかを判断する方法はありますか？**

実効データには最終値のみが含まれ、ソースは含まれません。最も具体的なレベルから外向きにローカルオブジェクトを調べてください。テキストの場合、対象は部分、段落、テキストフレーム、レイアウト、マスタ、テーマ、プレゼンテーションのデフォルトです。`Float.NaN` や `null` など未定義の値は、検索が別のレベルへ続くことを示します。

**どのレベルでもプロパティが定義されていない場合はどうなりますか？**

Aspose.Slides は適切な PowerPoint またはライブラリのデフォルトを解決します。その解決済み値が実効データに表示され、ローカルオブジェクトが明示的に定義していなくても利用可能になります。

**実効値がローカル値と同じになることがあるのはなぜですか？**

ローカル値が継承計算で勝ったことを示します。これは、プロパティがオブジェクトに明示的に設定され、より具体的なルールが上書きしなかった場合に予想通りの結果です。

**ローカルデータと実効データはいつ使い分けるべきですか？**

ローカルデータは特定の書式レベルを検査または編集する際に使用します。実効データは、継承、テーマ規則、適用可能なスタイルがすべて解決された後の最終的な外観が必要なときに使用します。[ローカル、継承、および実効値の比較例](#compare-local-inherited-and-effective-values) が同一ワークフローで両方を示しています。