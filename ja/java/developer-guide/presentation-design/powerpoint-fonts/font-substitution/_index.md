---
title: Java を使用したプレゼンテーションのフォント置換の構成
linktitle: フォント置換
type: docs
weight: 70
url: /ja/java/font-substitution/
keywords:
- フォント
- 置換フォント
- フォント置換
- フォントの置換
- フォント置換
- 置換ルール
- 置換ルール
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションのレンダリングまたは変換時に、Aspose.Slides for Java でフォント置換ルールを構成し、置換されたフォントを確認します。"
---
## **概要**

フォント置換により、Aspose.Slides はプレゼンテーションのレンダリングまたは変換時にアクセスできないフォントの代わりに利用可能なフォントを使用できます。置換はレンダリングされた出力に影響しますが、プレゼンテーション コンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、Aspose.Slides がレンダリング中に行う置換を確認できます。これにより、インストールされているフォントが異なる環境間でも出力を一貫させることができます。

フォントは利用可能だが専用の太字タイプフェイスがない場合は、[専用の太字フォントがない場合のフォント処理](/slides/ja/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)をご覧ください。そのセクションでは、PDF エクスポート時に対象テキストをラスタライズする方法と、テキスト選択、検索、スケーリングへの影響が説明されています。

## **フォント置換の取得**

[IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) メソッドを使用して、プレゼンテーションがレンダリングされる際にどのフォントが置換されるかを判定します。このメソッドは、元のフォント名と置換後のフォント名を示す [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) オブジェクトを返します。

次の Java の例は、プレゼンテーションに対するすべてのフォント置換を一覧表示します。

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **選択したスライドのフォント置換の取得**

`int[] slides` 引数を使用した [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) のオーバーロードを利用すると、特定のスライドのレンダリングに必要な置換のみを調べることができます。これは、プレゼンテーションの一部をレンダリングまたはエクスポートする場合や、大規模なプレゼンテーションを段階的にチェックする場合、利用できないフォントに依存するスライドを特定する場合、サーバーまたはコンテナ用に最小限のフォント パッケージを用意する場合、または無関係なスライドを処理せずにレンダリングの差異を診断する場合に便利です。

`slides` 配列は 1 から始まるスライド インデックスを含みます：`1` は最初のスライドを指します。対照的に、[Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) コレクション アクセサはゼロベースのインデックスを使用するため、同じスライドは `presentation.getSlides().get_Item(0)` としてアクセスされます。配列を作成する際はこの違いに注意し、オフバイワン エラーを防いでください。

[Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--) メソッドを通じてオーバーロードを呼び出します。これにより、選択したスライドのレンダリング中に決定された置換のみが返されます。各結果は元のフォント名と置換後のフォント名を含む [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) オブジェクトです。結果は現在のフォント環境、構成されたフォールバック ルール、および [外部読み込みフォント](/slides/ja/java/custom-font/) を反映します。[IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/) に保存された置換ルールはプレゼンテーションのレンダリング時に適用されますが、結果には一覧表示されません。代わりに出力ファイル内のフォントを確認してください。

同じ置換が複数の選択スライドで必要になることがあります。フォント インベントリやプリフライト レポートを作成する際は結果を重複除去してください。次の例は返されたすべての置換を報告し、次に一意のフォント マッピングのソート済みリストを作成します。

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

[IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) インターフェイスは両方のオーバーロードを提供します。レンダリング操作の対象範囲に合わせて選択してください。

| オーバーロード | 使用する場合 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--)（引数なし） | プレゼンテーション全体の置換が必要なとき |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---)（`int[] slides`） | 選択範囲、増分チェック、または部分エクスポートの置換が必要なとき |

## **フォント置換ルールの設定**

ソース フォントが利用できない場合に Aspose.Slides が使用すべきフォントを指定する手順：

1. プレゼンテーションをロードします。
2. ソース フォントと置換フォントの定義を作成します。
3. [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) を [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/) 条件で作成します。
4. ルールを [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/) に追加します。
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) メソッドを使用してコレクションを割り当てます。
6. プレゼンテーションをレンダリングまたは変換します。

次の Java の例は、`SomeRareFont` が利用できない場合に `Arial` を置換フォントとして使用し、最初のスライドをレンダリングして結果を検証します。置換フォントは Aspose.Slides が使用できる状態である必要があります。

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
プレゼンテーション全体で使用されるフォントを無条件に変更する場合は、[フォント置換](/slides/ja/java/font-replacement/)をご覧ください。
{{% /alert %}}

## **数式フォントの制限**

フォント置換ルールは、レンダリングおよび変換時に使用される標準的なフォント選択プロセスの一部です。アクセスできないフォントをルールで指定された利用可能なフォントに置き換えられる場合、通常のテキストで機能します。

Office Math の数式には追加の要件があります。数式で **Cambria Math** を使用している場合、Aspose.Slides はレイアウト計算とレンダリングのために正確にそのフォントが必要になることがあります。**STIX Two Math** など別の数式フォントに置き換えるルールはこの目的では **Cambria Math** を置き換えることができず、レンダリング時に **Cambria Math** が必要であると報告される可能性があります。

このようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides が利用できるようにしてください。オペレーティングシステムにインストールするか、[外部フォント](/slides/ja/java/custom-font/)としてロードします。

この制限は数式レイアウトにのみ適用されます。上記の置換ルールは通常のプレゼンテーションテキストには引き続き適用されます。

## **よくある質問**

**フォント置換とフォント置換（Replacement）の違いは何ですか？**

[フォント置換](/slides/ja/java/font-replacement/) はプレゼンテーション全体でフォントを意図的に別のフォントに変更します。フォント置換は、元のフォントが利用できないなど、設定された条件が満たされたときにレンダリング出力用のフォントを選択します。

**置換ルールはいつ適用されますか？**

ルールはレンダリングおよび変換時の [フォント選択シーケンス](/slides/ja/java/font-selection-sequence/) に参加します。`WhenInaccessible` を使用した場合、ソース フォントにアクセスできないときだけルールが適用されます。

**フォントが欠落していて置換ルールが設定されていない場合はどうなりますか？**

Aspose.Slides はフォント選択プロセスに基づき、利用可能な最も近いフォントを選択します。結果は実行時環境にインストールされているフォントに依存します。

**置換を回避するために外部フォントをロードできますか？**

はい。[外部フォントをロード](/slides/ja/java/custom-font/) して、レンダリングおよび変換時に Aspose.Slides が使用できるようにできます。

**Aspose はライブラリと共にフォントを配布していますか？**

いいえ。フォントの提供およびライセンス遵守はユーザーの責任です。

**Windows、Linux、macOS 間で置換結果が異なることがありますか？**

はい。インストールされているフォントやフォント検索場所は OS によって異なるため、あるマシンで利用できるフォントが別のマシンでは置換が必要になることがあります。

**バッチ変換でフォント選択を一貫させるにはどうすればよいですか？**

すべてのマシンまたはコンテナで同じフォント ファイルとバージョンを使用し、[必要な外部フォントをロード](/slides/ja/java/custom-font/)し、ライセンスが許可する場合は [フォントを埋め込む](/slides/ja/java/embedded-font/)ことが推奨されます。また、エクスポート前に [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) を呼び出して予期しない置換を特定することもできます。