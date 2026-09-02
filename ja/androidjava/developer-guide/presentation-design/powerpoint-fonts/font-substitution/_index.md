---
title: Android でプレゼンテーションのフォント置換を構成する
linktitle: フォント置換
type: docs
weight: 70
url: /ja/androidjava/font-substitution/
keywords:
- フォント
- 置換フォント
- フォント置換
- フォント置き換え
- フォント置換
- 置換規則
- 置き換え規則
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides でプレゼンテーションをレンダリングまたは変換する際に、フォント置換規則を構成し、置換されたフォントを確認します。"
---
## **概要**

フォント置換により、Aspose.Slides はプレゼンテーションのレンダリングまたは変換時にアクセスできないフォントの代わりに利用可能なフォントを使用できます。置換はレンダリング結果にのみ影響し、プレゼンテーションコンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、Aspose.Slides がレンダリング中に行う置換を確認できます。これにより、Android デバイスや利用可能フォントが異なる環境間で出力を一貫させることができます。

## **フォント置換の取得**

[IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) メソッドを使用して、プレゼンテーションがレンダリングされる際に置換されるフォントを判定します。このメソッドは、元のフォント名と置換フォント名を示す [FontSubstitutionInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsubstitutioninfo/) オブジェクトを返します。

次の Java の例は、プレゼンテーションのすべてのフォント置換を一覧表示します。

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

## **選択スライドのフォント置換の取得**

`int[] slides` 引数を持つ [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) オーバーロードを使用すると、特定のスライドのレンダリングに必要な置換だけを確認できます。これは、プレゼンテーションの一部をレンダリングまたはエクスポートする場合や、大規模なプレゼンテーションを段階的にチェックする場合、利用できないフォントに依存するスライドを特定する場合、Android アプリ用に最小限のフォントパッケージを用意する場合、または無関係なスライドを処理せずにレンダリングの差異を診断する場合に便利です。

`slides` 配列は 1 ベースのスライドインデックスを含みます。`1` が最初のスライドを示します。対照的に、[Presentation.getSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getSlides--) コレクションアクセサは 0 ベースのインデックスを使用するため、同じスライドは `presentation.getSlides().get_Item(0)` で取得します。配列を作成する際はこの違いに注意し、オフバイワンエラーを防いでください。

[Presentation.getFontsManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getFontsManager--) メソッド経由でオーバーロードを呼び出します。選択したスライドのレンダリング中に決定された置換のみが返されます。各結果は、元のフォント名と置換フォント名を含む [FontSubstitutionInfo](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsubstitutioninfo/) オブジェクトです。結果は現在のフォント環境、設定されたフォールバック規則、[IFontSubstRuleCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsubstrulecollection/) に保存された置換規則、および [externally loaded fonts](/slides/ja/androidjava/custom-font/) を反映します。

同じ置換が複数の選択スライドで要求されることがあります。フォントインベントリや事前チェックレポートを作成する際は結果を重複排除してください。以下の例は返されたすべての置換を報告し、ユニークなフォントマッピングのソートリストを作成します。

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

[IFontsManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/) インターフェイスは両方のオーバーロードを提供します。レンダリング操作の対象範囲に応じて選択してください。

| オーバーロード | 使用シーン |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--)（引数なし） | プレゼンテーション全体の置換が必要なとき |
| [getSubstitutions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---)（`int[] slides`） | 選択範囲、増分チェック、または部分エクスポートの置換が必要なとき |

## **フォント置換規則の設定**

ソースフォントが利用できない場合に Aspose.Slides が使用すべきフォントを指定する手順:

1. プレゼンテーションを読み込む。
2. ソースフォントと置換フォントの定義を作成する。
3. [WhenInaccessible](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsubstcondition/) 条件を持つ [FontSubstRule](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsubstrule/) を作成する。
4. ルールを [FontSubstRuleCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsubstrulecollection/) に追加する。
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) メソッドでコレクションを割り当てる。
6. プレゼンテーションをレンダリングまたは変換する。

次の Java の例は、`SomeRareFont` が利用できないときに `Arial` に置換し、結果を確認するために最初のスライドをレンダリングします。置換フォントは Aspose.Slides が利用できる状態である必要があります。

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
プレゼンテーション全体で使用されるフォントを無条件に変更する場合は、[Font Replacement](/slides/ja/androidjava/font-replacement/) を参照してください。
{{% /alert %}}

## **数式フォントの制限**

フォント置換規則は、レンダリングおよび変換時に使用される標準的なフォント選択プロセスの一部です。アクセスできないフォントを規則で指定された利用可能なフォントに置き換えることができるため、通常のテキストには機能します。

Office Math の数式には追加の要件があります。数式が **Cambria Math** を使用している場合、Aspose.Slides はレイアウト計算とレンダリングのためにその正確なフォントが必要になることがあります。**STIX Two Math** など別の数式フォントに置換する規則は **Cambria Math** の代替にはならず、レンダリングは依然として **Cambria Math** が必要と報告される可能性があります。

このようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides が利用できるようにしてください。[外部フォント](/slides/ja/androidjava/custom-font/) としてロードすれば、アプリケーションがレンダリングおよび変換時に使用できます。

この制限は数式レイアウトにのみ適用されます。上記の置換規則は通常のプレゼンテーションテキストには引き続き適用されます。

## **FAQ**

**フォント置換とフォント置換規則の違いは何ですか？**

[Font replacement](/slides/ja/androidjava/font-replacement/) はプレゼンテーション全体でフォントを別のフォントに意図的に変更します。フォント置換は、元のフォントが利用できないなどの条件が満たされたときに、レンダリング出力用にフォントを選択します。

**置換規則はいつ適用されますか？**

規則はレンダリングおよび変換時の [font selection sequence](/slides/ja/androidjava/font-selection-sequence/) に参加します。`WhenInaccessible` の場合、ソースフォントにアクセスできないときだけ規則が使用されます。

**フォントが見つからず、置換規則が設定されていない場合はどうなりますか？**

Aspose.Slides はフォント選択プロセスに従って最も近い利用可能なフォントを選びます。結果は実行時環境にインストールされているフォントに依存します。

**外部フォントをロードして置換を回避できますか？**

はい。[外部フォント](/slides/ja/androidjava/custom-font/) をロードすれば、Aspose.Slides がレンダリングおよび変換時に使用できます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントの提供とライセンス遵守は利用者の責任です。

**Android デバイス間で置換結果が異なることはありますか？**

あります。Android のバージョン、デバイス、ベンダーによって利用できるシステムフォントが異なるため、ある環境で利用可能なフォントが別の環境では置換が必要になることがあります。

**Android デバイス間でフォント選択を一貫させるには？**

必要なフォントファイルをアプリに同梱し、[外部フォント](/slides/ja/androidjava/custom-font/) としてロードし、ライセンスが許可する場合は [embed fonts](/slides/ja/androidjava/embedded-font/) を使用します。また、エクスポート前に [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) を呼び出して予期しない置換を特定することもできます。