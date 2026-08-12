---
title: JavaでPowerPointプレゼンテーションのテキストを検索・置換
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
description: "Java用 Aspose.Slides で PowerPoint プレゼンテーションのテキストを検索、ハイライト、置換し、すべての一致を収集します。"
---
## **概要**

Aspose.Slides for Java は、個々のテキストフレームまたはプレゼンテーション全体でテキストを検索、ハイライト、置換できます。各操作は結果コールバックを通じて各一致についてアプリケーションに通知することもできます。これにより、プレゼンテーションを更新しながら、一致したテキスト、そのコンテキスト、位置、テキストフレーム、スライド番号を含む監査トレイルを同時に作成できます。

これらの機能は、レビュー、編集、用語チェック、テンプレートのクリーンアップ、そして自動レポート作成ワークフローに便利です。

以下の最初の例では、最初のスライドに単一のテキストボックスがあり、次のテキストが含まれる「sample.pptx」ファイルを使用します。

![サンプルテキスト](sample_text.png)

## **検索範囲の選択**

[ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) のメソッドを使用して操作を1つのテキストフレームに限定します。[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) のメソッドを使用すると、プレゼンテーション内のすべての該当テキストを処理できます。

| 操作 | 1つのテキストフレーム | プレゼンテーション全体 |
|---|---|---|
| リテラルテキストのハイライト | [ITextFrame.highlightText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 正規表現マッチのハイライト | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| リテラルテキストの置換 | [ITextFrame.replaceText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| 正規表現マッチの置換 | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **テキストマッチングの構成**

リテラルテキスト操作の場合、[TextSearchOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/) を使用してマッチングを制御します。

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) は完全な単語への一致に限定します。
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) は文字の大文字小文字の一致を要求するかどうかを制御します。
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) はプレゼンテーションレベルの検索、置換、ハイライト操作にスライドノートを含めます。

正規表現操作は Java の `Pattern` を使用するため、ケースセンシティビティや単語境界といったマッチルールは式自体とそのフラグで定義されます。

## **コールバックでマッチ情報を収集**

[IFindResultCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifindresultcallback/) を実装して、すべてのマッチについて通知を受け取ります。その [IFindResultCallback.foundResult](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) メソッドは、関連するテキストフレーム、元テキスト、マッチしたテキスト、およびマッチ位置を提供します。

コールバックはスライド番号を直接受け取りません。以下の実装は親スライドからスライド番号を導出し、スライドノート内のテキストも処理します。`Integer` の nullable 版を使用することで、同じ結果モデルで他のスライドタイプに関連するテキストも表現できます。

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

[ITextFrame.highlightText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) メソッドを使用して、テキストフレーム内のリテラルテキストの一致をハイライトします。[TextSearchOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/) を渡して検索条件を制御し、コールバックでマッチ詳細を収集します。

以下のコード例は文字列 **"try"** のすべての出現をハイライトし、続いて完全な単語 **"to"** のみをハイライトします。両方の検索は同じコールバックに結果を渡します。

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

    // テキストフレーム内の "try" のすべての出現をハイライトします。
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

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

結果:

![ハイライトされたテキスト](highlighted_text.png)

## **正規表現を使用したテキストのハイライト**

[ITextFrame.highlightRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) メソッドは、正規表現で見つかったテキストの一致をテキストフレーム内でハイライトします。

以下のコードは、7文字以上の単語すべてをハイライトし、各マッチを収集します。

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

![正規表現でハイライトされたテキスト](highlighted_text_using_regex.png)

## **プレゼンテーション全体でのテキストハイライト**

[Presentation.highlightText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [Presentation.highlightRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) を使用して、プレゼンテーション内のすべての該当テキストフレームを検索します。以下の例は、リテラル語句とすべてのメールアドレスをハイライトし、2 つの検索結果を別々のコレクションに保持します。

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

## **テキストフレーム内でのテキスト置換**

リテラルテキストには [ITextFrame.replaceText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) を、パターンベースの置換には [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を使用します。これらのメソッドは既存のテキストフレーム内の一致したテキストを更新し、周囲の書式を保持したまま置換を行います。

以下の例はスペリングの変種を標準化し、続いてバージョンラベルを置換します。同じコールバックが両方の操作で一致した元の用語を記録します。

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

1 つのマッチが異なる書式の部分にまたがる場合は、置換テキストに適用すべき書式を確認するために出力を検査してください。

## **プレゼンテーション全体でのテキスト置換**

[Presentation.replaceText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [Presentation.replaceRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を使用して、プレゼンテーション全体に同じ操作を適用します。テンプレートのクリーンアップ、用語の更新、編集削除に便利です。

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

## **レポート作成のためのマッチのグループ化**

すべての結果はスライド番号とテキストフレームを保持しているため、アプリケーションは監査、レポート、レビューのワークフロー向けにマッチをグループ化できます。以下の例は、収集した結果をまずスライドごと、次にテキストフレームごとにグループ化します。

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

**特定のテキストボックスだけを検索したい場合はどうすればよいですか？**

シェイプのテキストフレームを取得し、そのテキストフレームに対して [ITextFrame.highlightText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、[ITextFrame.highlightRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-)、[ITextFrame.replaceText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-)、または [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) を呼び出します。プレゼンテーションレベルのメソッドはすべての該当テキストフレームを処理します。

**完全な単語を正しい大文字小文字で一致させるにはどうすればよいですか？**

[TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) と [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) を `true` に設定し、リテラルテキストのハイライトまたは置換メソッドにオプションを渡します。正規表現の場合は、Java の `Pattern` 自体で単語境界とケースセンシティビティを定義します。

**検索・置換にスライドノートのテキストも含められますか？**

はい。プレゼンテーションレベルのリテラルテキスト操作を使用する際に、[TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) を `true` に設定します。上記のコールバック実装は、ノートスライド内のマッチを親スライド番号にマッピングします。

**プレゼンテーションを再度スキャンせずにレポートを作成するにはどうすればよいですか？**

ハイライトまたは置換操作に [IFindResultCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifindresultcallback/) 実装を渡します。コールバックは操作中にすべてのマッチを受け取り、アプリケーションは元テキスト、マッチテキスト、位置、テキストフレーム、導出されたスライド番号を保存して、後でグループ化またはエクスポートできます。

**テキストを置換すると書式は保持されますか？**

[ITextFrame.replaceText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) と [ITextFrame.replaceRegex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) は、既存のテキストフレーム内の一致したテキストを更新し、周囲の書式を保持します。マッチが異なる書式の部分にまたがる場合は、置換が期待どおりのスタイルになるよう結果を確認してください。