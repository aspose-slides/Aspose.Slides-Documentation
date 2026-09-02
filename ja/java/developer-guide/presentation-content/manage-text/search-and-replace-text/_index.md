---
title: JavaでPowerPointプレゼンテーションのテキストを検索および置換
linktitle: テキストの検索と置換
type: docs
weight: 55
url: /ja/java/search-and-replace-text/
keywords:
- テキスト検索
- テキストハイライト
- テキスト置換
- 正規表現
- 結果コールバック
- テキストフレーム
- 監査レポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーション内のテキストを検索、ハイライト、置換し、すべてのマッチを収集します。"
---
## **概要**

Aspose.Slides for Java は、個々のテキストフレームまたはプレゼンテーション全体でテキストの検索、ハイライト、置換を行うことができます。各操作は、結果コールバックを通じてマッチごとにアプリケーションに通知することもできます。これにより、プレゼンテーションを更新しながら、マッチしたテキスト、そのコンテキスト、位置、テキストフレーム、スライド番号を含む監査トレイルを同時に作成できます。

これらの機能は、レビュー、情報削除、用語チェック、テンプレートのクリーンアップ、そして自動レポート作成ワークフローに役立ちます。

以下の最初の例では、`sample.pptx` というファイルを使用します。このファイルは、最初のスライドに単一のテキストボックスがあり、次のテキストが含まれています:

![サンプルテキスト](sample_text.png)

## **検索範囲の選択**

[ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) のメソッドを使用して操作を1つのテキストフレームに限定します。[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) のメソッドを使用してプレゼンテーション内のすべての対象テキストを処理します。

| 操作 | 1つのテキストフレーム | プレゼンテーション全体 |
|---|---|---|
| リテラルテキストをハイライト | [ITextFrame.highlightText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 正規表現マッチをハイライト | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| リテラルテキストを置換 | [ITextFrame.replaceText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 正規表現マッチを置換 | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **テキストマッチングの設定**

リテラルテキスト操作の場合、[TextSearchOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/) を使用してマッチングを制御します。

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) は、マッチを完全な単語のみに制限します。
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) は、文字の大小が一致するかどうかを制御します。
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) は、プレゼンテーションレベルの検索、置換、ハイライト操作にスライドノートを含めます。

正規表現操作は Java の `Pattern` を使用するため、大小文字の区別や単語境界などのマッチングルールは正規表現自体とそのフラグで定義されます。

## **テキストフレームの所有者を特定する**

汎用的なテキスト処理ワークフローでは、検索、置換、検証、またはエクスポート時に [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) が渡されることがよくあります。[ITextFrame.getParentShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#getParentShape--) と [ITextFrame.getParentCell](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#getParentCell--) を使用して、テキストフレームを所有しているプレゼンテーションオブジェクトを判断してください。

所有者に応じた期待値は次のとおりです:

| テキストフレームの所有者 | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape または他のテキストを含むシェイプ | 所有する[IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) | `null` |
| テーブルセル | `null` | 所有する[ICell](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icell/) |

両方のメソッドは読み取り専用のナビゲーションを提供します。呼び出してもテキストフレームは移動せず、所有者も変更されません。汎用コードでは両方の値が `null` である可能性を考慮してチェックしてください。

以下の例は [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) を使用してプレゼンテーション内のテキストフレームを列挙します。シェイプの場合はシェイプ名、Java ランタイム型、所属スライドを報告し、テーブルセルの場合は 0 基準の列・行座標と所属スライドを報告します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, false);

    for (ITextFrame textFrame : textFrames) {
        IShape ownerShape = textFrame.getParentShape();
        if (ownerShape != null) {
            String shapeName = ownerShape.getName().isEmpty() ? "(unnamed)" : ownerShape.getName();
            String shapeType = ownerShape.getClass().getSimpleName();
            IBaseSlide baseSlide = ownerShape.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        ICell ownerCell = textFrame.getParentCell();
        if (ownerCell != null) {
            IBaseSlide baseSlide = ownerCell.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        System.out.println("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

SmartArt コンテンツについては、[ISmartArtNode.getShapes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ismartartnode/#getShapes--) でシェイプを列挙し、各 [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ismartartshape/#getTextFrame--) にアクセスします。テキストフレームは [ITextFrame.getParentShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#getParentShape--) で関連シェイプにたどり着き、[ITextFrame.getParentCell](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#getParentCell--) は `null` を返します。したがって、例のシェイプ側ブランチは SmartArt ノードからのテキストも処理します。

## **コールバックでマッチ情報を収集する**

[IFindResultCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifindresultcallback/) を実装して、マッチごとに通知を受け取ります。その [IFindResultCallback.foundResult](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) メソッドは、対象テキストフレーム、元テキスト、マッチしたテキスト、そしてマッチ位置を提供します。

コールバックはスライド番号を直接受け取らないため、以下の実装では親スライドから取得し、スライドノート内のテキストにも対応しています。`Integer` の nullable を使用することで、他のスライド種別に紐付くテキストも同じ結果モデルで表現できます。

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private Integer getSlideNumber(ITextFrame textFrame) {
        IShape parentShape = textFrame.getParentShape();
        ICell parentCell = textFrame.getParentCell();
        IBaseSlide parentSlide = parentShape != null ? parentShape.getSlide() : parentCell != null ? parentCell.getSlide() : textFrame.getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

置換操作の場合、`foundText` には元のマッチテキストが含まれるため、コールバックは置換された正確な語句を記録できます。

## **テキストをハイライトする**

[ITextFrame.highlightText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) メソッドを使用して、テキストフレーム内のリテラルテキストマッチをハイライトします。検索条件を制御するために [TextSearchOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/) を渡し、マッチの詳細を収集するコールバックも指定します。

以下のコード例は文字列 **"try"** のすべての出現箇所をハイライトし、続いて完全な単語 **"to"** のみをハイライトします。両方の検索が同じコールバックにマッチ情報を報告します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    Color substringHighlightColor = new Color(173, 216, 230);

    // テキストフレーム内の「try」のすべての出現箇所をハイライトします。
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // 完全な単語「to」のみをハイライトします。
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![ハイライトされたテキスト](highlighted_text.png)

## **正規表現を使用したテキストのハイライト**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) メソッドは、正規表現で検出されたテキストマッチをテキストフレーム内でハイライトします。

次のコードは、7 文字以上の単語すべてをハイライトし、各マッチを収集します。

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![正規表現を使用したハイライトされたテキスト](highlighted_text_using_regex.png)

## **プレゼンテーション全体でテキストをハイライトする**

[Presentation.highlightText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [Presentation.highlightRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) を使用して、プレゼンテーション内のすべての対象テキストフレームを検索します。以下の例はリテラル語句とすべてのメールアドレスをハイライトし、2 つの検索結果を別々のコレクションに保持します。

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    presentation.highlightText("confidential", Color.ORANGE, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **テキストフレーム内のテキストを置換する**

リテラルテキストの場合は [ITextFrame.replaceText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) を、パターンベースの置換の場合は [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を使用します。これらのメソッドは、既存テキストフレーム内のマッチしたテキストだけを更新し、周囲の書式を保持したまま置換を行います。

以下の例は綴りのバリエーションを統一し、その後バージョンラベルを置換します。両方の操作で同じコールバックが元のマッチ語句を記録します。

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

マッチが異なる書式の部分にまたがる場合は、置換テキストに適用すべき書式を確認してください。

## **プレゼンテーション全体でテキストを置換する**

[Presentation.replaceText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [Presentation.replaceRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を使用して、同じ操作をプレゼンテーション全体に適用します。テンプレートのクリーンアップ、用語の更新、情報削除に便利です。

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **レポート用にマッチをグループ化する**

各結果がスライド番号とテキストフレームを保持しているため、アプリケーションは監査、レポート、レビュー用にマッチをグループ化できます。以下の例は、収集した結果をまずスライドごとに、次にテキストフレームごとにグループ化します。

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **FAQ**

**プレゼンテーション全体ではなく、1つのテキストボックスだけを検索するにはどうすればよいですか？**

対象シェイプのテキストフレームを取得し、そのテキストフレームに対して [ITextFrame.highlightText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、[ITextFrame.highlightRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)、[ITextFrame.replaceText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、[ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を呼び出します。プレゼンテーションレベルのメソッドはすべての適用可能なテキストフレームを処理します。

**完全な単語を正しい大文字小文字でマッチさせるにはどうすればよいですか？**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) と [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) を `true` に設定し、リテラルテキストのハイライトまたは置換メソッドにオプションを渡します。正規表現の場合は、Java の `Pattern` 自体で単語境界と大文字小文字の区別を定義します。

**検索および置換にスライドノートのテキストも含めることはできますか？**

はい。プレゼンテーションレベルのリテラルテキスト操作を使用する際に、[TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) を `true` に設定します。上記のコールバック実装は、ノートスライド内のマッチを親スライド番号にマッピングします。

**プレゼンテーションを再度スキャンせずにレポートを作成するにはどうすればよいですか？**

ハイライトまたは置換操作に [IFindResultCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifindresultcallback/) 実装を渡します。コールバックは操作実行中にすべてのマッチを受け取るため、アプリケーションは元テキスト、マッチテキスト、位置、テキストフレーム、導出したスライド番号を保存し、後でグループ化やエクスポートに利用できます。

**テキストを置換しても書式は保持されますか？**

[ITextFrame.replaceText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) は、既存のテキストフレーム内でマッチしたテキストだけを変更し、周囲の書式を保持します。マッチが異なる書式の部分にまたがる場合は、置換後の書式が期待通りであるか確認してください。