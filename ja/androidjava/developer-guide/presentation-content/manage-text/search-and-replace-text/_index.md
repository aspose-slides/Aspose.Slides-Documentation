---
title: Android で PowerPoint プレゼンテーションのテキストを検索および置換
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
description: "Aspose.Slides for Android via Java を使用して、PowerPoint プレゼンテーション内のテキストを検索、ハイライト、置換し、すべてのマッチを収集します。"
---
## **概要**

Aspose.Slides for Android via Java は、個々のテキスト フレームまたはプレゼンテーション全体でテキストを検索、ハイライト、置換できます。各操作は結果コールバックを通じてマッチごとにアプリケーションに通知することもできます。これにより、プレゼンテーションを更新しながら、マッチしたテキスト、そのコンテキスト、位置、テキスト フレーム、スライド番号を含む監査トレイルを同時に構築できます。

これらの機能は、レビュー、レダクション、用語チェック、テンプレートのクリーンアップ、そして自動レポート作成ワークフローに役立ちます。

以下の最初の例では、"sample.pptx" という名前のファイルを使用します。このファイルは、最初のスライドに単一のテキスト ボックスがあり、次のテキストが含まれています:

![サンプルテキスト](sample_text.png)

## **検索スコープの選択**

操作を単一のテキスト フレームに限定するには、[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) のメソッドを使用します。プレゼンテーション内のすべての該当テキストを処理するには、[IPresentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/) のメソッドを使用します。

| 操作 | 単一テキストフレーム | プレゼンテーション全体 |
|---|---|---|
| リテラルテキストのハイライト | [ITextFrame.highlightText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 正規表現マッチのハイライト | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| リテラルテキストの置換 | [ITextFrame.replaceText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 正規表現マッチの置換 | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **テキストマッチングの構成**

リテラルテキスト操作では、[TextSearchOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/) を使用してマッチングを制御します:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) は、マッチを完全な単語に限定します。
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) は、文字の大文字小文字が一致する必要があるかどうかを制御します。
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) は、プレゼンテーションレベルの検索、置換、ハイライト操作にスライド ノートを含めます。

正規表現操作は Java の `Pattern` を使用するため、大小文字の区別や単語境界などのマッチングルールは、式およびそのフラグで定義されます。

## **コールバックでマッチ情報を収集**

すべてのマッチについて通知を受け取るには、[IFindResultCallback](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifindresultcallback/) を実装します。その [IFindResultCallback.foundResult](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) メソッドは、関連するテキスト フレーム、ソース テキスト、マッチしたテキスト、およびマッチ位置を提供します。

コールバックはスライド番号を直接受け取らないため、以下の実装では親スライドから取得し、スライドノート内のテキストも処理します。nullable な `Integer` を使用することで、同じ結果モデルで他のスライドタイプに関連付けられたテキストも表現できます。

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

    private static Integer getSlideNumber(ITextFrame textFrame) {
        if (!(textFrame instanceof TextFrame)) {
            return null;
        }

        IBaseSlide parentSlide = ((TextFrame) textFrame).getSlide();

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

置換操作の場合、`foundText` には元のマッチテキストが含まれるため、コールバックは正確にどの用語が置換されたかを記録できます。

## **テキストのハイライト**

テキスト フレーム内のリテラルテキストのマッチをハイライトするには、[ITextFrame.highlightText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) メソッドを使用します。[TextSearchOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/) を渡して検索を制御し、コールバックでマッチ詳細を収集します。

以下のコード例は、文字列 **"try"** のすべての出現箇所をハイライトし、その後完全な単語 **"to"** のみをハイライトします。両方の検索は同じコールバックにマッチを報告します。

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

    // テキスト フレーム内の "try" のすべての出現箇所をハイライトします。
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // 完全な単語 "to" のみをハイライトします。
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

結果：

![ハイライトされたテキスト](highlighted_text.png)

## **正規表現を使用したテキストのハイライト**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) メソッドは、テキスト フレーム内で正規表現によって見つかったテキスト マッチをハイライトします。

以下のコードは、7 文字以上を含むすべての単語をハイライトし、各マッチを収集します。

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

結果：

![正規表現を使用したハイライトテキスト](highlighted_text_using_regex.png)

## **プレゼンテーション全体のテキストハイライト**

[IPresentation.highlightText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [IPresentation.highlightRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) を使用して、プレゼンテーション内のすべての該当テキスト フレームを検索します。以下の例では、リテラル用語とすべてのメール アドレスをハイライトし、2 つの検索結果を別々のコレクションに保持しています。

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

## **テキスト フレーム内のテキスト置換**

リテラルテキストの場合は [ITextFrame.replaceText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) を、パターンベースの置換の場合は [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を使用します。これらのメソッドは既存のテキスト フレーム内のマッチしたテキストを更新し、プレーン文字列からテキスト フレームを再構築するのではなく、周囲の書式設定を保持します。

以下の例では、綴りのバリエーションを標準化し、次にバージョン ラベルを置換します。同じコールバックが両方の操作でマッチした元の用語を記録します。

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

マッチが異なる書式設定の部分にまたがる場合、出力を確認し、置換テキストに適用すべき書式設定を確認してください。

## **プレゼンテーション全体のテキスト置換**

[IPresentation.replaceText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [IPresentation.replaceRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を使用して、プレゼンテーション全体に同じ操作を適用します。これは、テンプレートのクリーンアップ、用語の更新、レダクションに役立ちます。

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

## **レポート用のマッチのグループ化**

すべての結果がスライド番号とテキスト フレームを保持しているため、アプリケーションは監査、レポート、またはレビュー ワークフローのためにマッチをグループ化できます。以下の例では、収集した結果をまずスライドごとに、次にテキスト フレームごとにグループ化しています。

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

**プレゼンテーション全体ではなく、単一のテキスト ボックスだけを検索するにはどうすればよいですか？**

シェイプのテキスト フレームを取得し、そのテキスト フレームに対して [ITextFrame.highlightText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、[ITextFrame.highlightRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-)、[ITextFrame.replaceText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、または [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を呼び出します。プレゼンテーションレベルのメソッドは、すべての該当テキスト フレームを処理します。

**正しい大文字小文字で完全な単語にマッチさせるにはどうすればよいですか？**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) と [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) を `true` に設定し、リテラルテキストのハイライトまたは置換メソッドにオプションを渡します。正規表現の場合は、Java の `Pattern` 自体で単語境界と大小文字の区別を定義します。

**検索と置換でスライドノート内のテキストも含められますか？**

はい。プレゼンテーションレベルのリテラルテキスト操作を使用する際に、[TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) を `true` に設定します。上記のコールバック実装は、ノート スライド内のマッチを親スライド番号にマッピングします。

**プレゼンテーションを再度スキャンせずにレポートを作成するにはどうすればよいですか？**

ハイライトまたは置換操作に [IFindResultCallback](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifindresultcallback/) 実装を渡します。コールバックは操作実行中にすべてのマッチを受け取り、アプリケーションはソース テキスト、マッチしたテキスト、位置、テキスト フレーム、導出されたスライド番号を後でのグループ化やエクスポートのために保存できます。

**テキストを置換しても書式は保持されますか？**

[ITextFrame.replaceText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) は、既存のテキスト フレーム内のマッチしたテキストを変更し、周囲の書式設定を保持します。マッチが異なる書式設定の部分にまたがる場合、置換が希望のスタイルで行われているか結果を確認してください。