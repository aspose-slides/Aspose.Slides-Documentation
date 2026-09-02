---
title: Android の PowerPoint プレゼンテーションでテキストを検索および置換
linktitle: テキストの検索と置換
type: docs
weight: 55
url: /ja/androidjava/search-and-replace-text/
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
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides for Java を使用して、PowerPoint プレゼンテーション内のテキストを検索、ハイライト、置換し、すべての一致を収集します。"
---
## **概要**

Aspose.Slides for Android via Java は、個々のテキストフレームまたはプレゼンテーション全体でテキストの検索、ハイライト、置換を行うことができます。各操作は結果コールバックを介して一致するたびにアプリケーションに通知できます。これにより、プレゼンテーションを更新しながら、一致したテキスト、そのコンテキスト、位置、テキストフレーム、スライド番号を含む監査トレイルを同時に作成できます。

これらの機能は、レビュー、情報削除、用語チェック、テンプレートのクリーンアップ、そして自動レポート作成ワークフローに役立ちます。

以下の最初の例では、最初のスライドに単一のテキストボックスがあり、次のテキストが含まれる「sample.pptx」ファイルを使用します。

![サンプルテキスト](sample_text.png)

## **検索対象の選択**

[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) のメソッドを使用して操作を単一テキストフレームに限定します。[IPresentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/) のメソッドを使用すると、プレゼンテーション内のすべての該当テキストを処理できます。

| 操作 | 単一テキストフレーム | プレゼンテーション全体 |
|---|---|---|
| リテラルテキストをハイライト | [ITextFrame.highlightText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 正規表現マッチをハイライト | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| リテラルテキストを置換 | [ITextFrame.replaceText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 正規表現マッチを置換 | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **テキストマッチングの設定**

リテラルテキスト操作の場合は、[TextSearchOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/) を使用してマッチングを制御します。

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) は、完全な単語への一致に限定します。  
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) は、文字ケースの一致が必要かどうかを制御します。  
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) は、スライドノートをプレゼンテーションレベルの検索、置換、ハイライト操作に含めます。

正規表現操作は Java の `Pattern` を使用するため、ケースセンシティブや単語境界などのルールは式とフラグで定義されます。

## **テキストフレームの所有者を特定する**

汎用テキスト処理ワークフローは、検索、置換、検証、エクスポート時に [ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) を受け取ることがよくあります。[ITextFrame.getParentShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getParentShape--) と [ITextFrame.getParentCell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getParentCell--) を使用して、どのプレゼンテーションオブジェクトがテキストフレームを所有しているかを判断します。

期待される値は所有者によって異なります。

| テキストフレームの所有者 | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape または他のテキストを含むシェイプ | 所有する [IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) | `null` |
| テーブルセル | `null` | 所有する [ICell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icell/) |

両メソッドは読み取り専用ナビゲーションを提供します。呼び出してもテキストフレームは移動せず、所有者も変更されません。汎用コードは両方の値が `null` かどうかを確認し、いずれの所有者も利用できない可能性に対処すべきです。

以下の例は [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) を使用してプレゼンテーション内のテキストフレームを反復処理します。シェイプの場合はシェイプ名、Java 実行時型、所属スライドを報告し、テーブルセルの場合は 0 基準の列・行座標と所属スライドを報告します。

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

SmartArt コンテンツの場合は、[ISmartArtNode.getShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ismartartnode/#getShapes--) でシェイプを反復し、各 [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) にアクセスします。テキストフレームは [ITextFrame.getParentShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getParentShape--) で関連シェイプにたどり、[ITextFrame.getParentCell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#getParentCell--) は `null` を返します。したがって、例のシェイプ分岐は SmartArt ノードからのテキストも処理します。

## **コールバックで一致情報を収集する**

[IFindResultCallback](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifindresultcallback/) を実装して、すべての一致に対する通知を受け取ります。その [IFindResultCallback.foundResult](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) メソッドは、関連テキストフレーム、ソーステキスト、一致テキスト、位置を提供します。

コールバックは直接スライド番号を受け取りません。以下の実装は親スライドから番号を導出し、スライドノート内のテキストにも対応します。`Integer` の nullable で、他のスライド種別に紐づくテキストも同じ結果モデルで表現できます。

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

置換操作の場合、`foundText` には元の一致テキストが含まれるため、コールバックは置換された正確な語句を記録できます。

## **テキストのハイライト**

[ITextFrame.highlightText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) メソッドを使用して、テキストフレーム内のリテラルテキスト一致をハイライトします。[TextSearchOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/) を渡して検索を制御し、コールバックで一致詳細を収集します。

以下のコード例は文字列 **"try"** のすべての出現をハイライトし、その後完全な単語 **"to"** のみをハイライトします。両方の検索は同じコールバックに一致を報告します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    int substringHighlightColor = Color.rgb(173, 216, 230);

    // テキストフレーム内の「try」のすべての出現をハイライトします。
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

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

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) メソッドは、正規表現で見つかったテキストマッチをテキストフレーム内でハイライトします。

以下のコードは、7 文字以上の単語すべてをハイライトし、各一致を収集します。

```java
import com.aspose.slides.*;
import android.graphics.Color;
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

![正規表現でハイライトされたテキスト](highlighted_text_using_regex.png)

## **プレゼンテーション全体でテキストをハイライトする**

[IPresentation.highlightText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [IPresentation.highlightRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) を使用して、プレゼンテーション内のすべての該当テキストフレームを検索します。以下の例はリテラル語とすべてのメールアドレスをハイライトし、2 つの検索結果を別々のコレクションに保持します。

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    int termHighlightColor = Color.rgb(255, 165, 0);
    presentation.highlightText("confidential", termHighlightColor, searchOptions, termCallback);

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

## **テキストフレーム内でテキストを置換する**

[ITextFrame.replaceText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) はリテラルテキスト、[ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) はパターンベースの置換に使用します。これらのメソッドは既存のテキストフレーム内の一致テキストを更新し、周囲の書式を保持したまま置換を行います。

以下の例は綴りのバリエーションを統一し、バージョンラベルを置換します。同じコールバックが両方の操作で一致した元語を記録します。

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

一致が異なる書式の部分にまたがる場合は、置換後の書式が期待通りか出力を確認してください。

## **プレゼンテーション全体でテキストを置換する**

[IPresentation.replaceText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [IPresentation.replaceRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を使用して、同じ操作をプレゼンテーション全体に適用します。テンプレートのクリーンアップ、用語の更新、情報削除に便利です。

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

## **レポート作成のために一致をグループ化する**

すべての結果はスライド番号とテキストフレームを保持しているため、アプリケーションは監査、レポート、レビューのワークフロー向けに一致をグループ化できます。以下の例は収集した結果をまずスライドで、次にテキストフレームでグループ化します。

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

**テキストボックス単体だけを検索したい場合は？**

シェイプのテキストフレームを取得し、そのテキストフレームに対して [ITextFrame.highlightText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、[ITextFrame.highlightRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-)、[ITextFrame.replaceText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、または [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を呼び出します。プレゼンテーションレベルのメソッドはすべての該当テキストフレームを処理します。

**完全単語かつ正しい大文字小文字でマッチさせるには？**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) と [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) を `true` に設定し、リテラルテキストのハイライトまたは置換メソッドにオプションを渡します。正規表現の場合は、Java の `Pattern` 自体で単語境界とケースセンシティブを定義します。

**スライドノート内のテキストも検索・置換に含められるか？**

はい。プレゼンテーションレベルのリテラルテキスト操作を使用する際に、[TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) を `true` に設定します。上記のコールバック実装は、ノートスライド内の一致を親スライド番号にマッピングします。

**プレゼンテーションを再度走査せずにレポートを作成するには？**

ハイライトまたは置換操作に [IFindResultCallback](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifindresultcallback/) の実装を渡します。コールバックは操作実行中にすべての一致を受け取り、後でグループ化やエクスポートに使用できるようにソーステキスト、マッチテキスト、位置、テキストフレーム、導出したスライド番号を保存できます。

**テキストの置換は書式を保持するか？**

[ITextFrame.replaceText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) は既存のテキストフレーム内で一致テキストを変更し、周囲の部分書式を保持します。一致が異なる書式の部分にまたがる場合は、置換後の書式が期待通りか結果を確認してください。