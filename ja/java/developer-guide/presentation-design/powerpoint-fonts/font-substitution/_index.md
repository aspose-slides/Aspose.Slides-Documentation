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
- フォント置き換え
- フォント置換
- 置換ルール
- 置き換えルール
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションをレンダリングまたは変換する際に、Aspose.Slides for Java のフォント置換ルールを設定し、置換されたフォントを確認します。"
---
## **概要**

フォント置換により、Aspose.Slides はプレゼンテーションのレンダリングまたは変換時にアクセスできないフォントの代わりに、利用可能なフォントを使用できます。置換はレンダリングされた出力に影響しますが、プレゼンテーション コンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、Aspose.Slides がレンダリング中に行う置換を検査できます。これにより、インストールされているフォントが異なる環境間で出力を一貫させることができます。

## **フォント置換を取得**

[IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) メソッドを使用して、プレゼンテーションのレンダリング時に置換されるフォントを判別します。このメソッドは、元のフォント名と置換フォント名を示す [FontSubstitutionInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsubstitutioninfo/) オブジェクトを返します。

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

## **選択スライド用のフォント置換を取得**

`int[] slides` 引数を持つ [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) のオーバーロードを使用すると、特定のスライドのレンダリングに必要な置換のみを検査できます。これは、プレゼンテーションの一部をレンダリングまたはエクスポートする場合や、大規模なプレゼンテーションを増分でチェックする場合、利用できないフォントに依存するスライドを特定する場合、サーバーやコンテナ用に最小限のフォント パッケージを準備する場合、または関係のないスライドを処理せずにレンダリングの差異を診断する場合に便利です。

`slides` 配列は 1 ベースのスライド インデックスを含みます。`1` は最初のスライドを示します。対照的に、[Presentation.getSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSlides--) コレクション アクセサは 0 ベースのインデックスを使用するため、同じスライドは `presentation.getSlides().get_Item(0)` としてアクセスします。配列を構築する際はこの違いに注意し、オフバイワン エラーを防ぎください。

[Presentation.getFontsManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getFontsManager--) メソッドを介してオーバーロードを呼び出します。これにより、選択したスライドのレンダリング中に決定された置換のみが返されます。各結果は元のフォント名と置換フォント名を含む [FontSubstitutionInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsubstitutioninfo/) オブジェクトです。結果は現在のフォント環境、構成されたフォールバック ルール、および [外部フォント](/slides/ja/java/custom-font/) の読み込み状態を反映します。[IFontSubstRuleCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsubstrulecollection/) に保存された置換ルールはプレゼンテーションのレンダリング時に適用されますが、結果には一覧表示されません。代わりに出力ファイル内のフォントを確認してください。

同じ置換が複数の選択スライドで必要になることがあります。フォント インベントリやプリフライト レポートを作成する際は結果を重複排除してください。以下の例は、返されたすべての置換を報告し、ユニークなフォント マッピングのソート済みリストを作成します。

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

[IFontsManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/) インターフェイスは両方のオーバーロードを提供します。レンダリング操作のスコープに応じて選択してください。

| オーバーロード | 使用する場面 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) (引数なし) | プレゼンテーション全体の置換が必要な場合。 |
| [getSubstitutions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) (`int[] slides` あり) | 選択範囲、増分チェック、または部分エクスポートの置換が必要な場合。 |

## **フォント置換ルールを設定**

ソースフォントが利用できないときに Aspose.Slides が使用すべきフォントを指定するには、次の手順を実行します。

1. プレゼンテーションをロードします。  
2. ソースフォントと置換フォントの定義を作成します。  
3. [WhenInaccessible](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsubstcondition/) 条件を持つ [FontSubstRule](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsubstrule/) を作成します。  
4. ルールを [FontSubstRuleCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsubstrulecollection/) に追加します。  
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) メソッドを使用してコレクションを割り当てます。  
6. プレゼンテーションをレンダリングまたは変換します。

次の Java の例は、`SomeRareFont` が利用できないときに `Arial` に置換し、最初のスライドをレンダリングして結果を検証します。置換フォントは Aspose.Slides が利用できる必要があります。

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
プレゼンテーション全体で使用されるフォントを無条件に変更する場合は、[フォント置換](/slides/ja/java/font-replacement/) を参照してください。
{{% /alert %}}

## **数式フォントの制限**

フォント置換ルールは、レンダリングおよび変換時に使用される標準的なフォント選択プロセスの一部です。利用できないフォントをルールで指定した利用可能なフォントに置き換えられる場合、通常のテキストには機能します。

Office Math の数式には追加の要件があります。数式が **Cambria Math** を使用している場合、Aspose.Slides はレイアウト計算とレンダリングのためにその正確なフォントが必要になることがあります。**STIX Two Math** などの別の数式フォントに置換するルールは、**Cambria Math** の代わりにはなりません。その結果、レンダリング時に **Cambria Math** が必要であるという報告が残ることがあります。

このようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides が利用できるようにしてください。OS にインストールするか、[外部フォント](/slides/ja/java/custom-font/) として読み込みます。

この制限は数式のレイアウトにのみ適用されます。上記の置換ルールは通常のプレゼンテーションテキストには引き続き適用されます。

## **FAQ**

**フォント置換とフォント置換（replacement）の違いは何ですか？**  
[フォント置換](/slides/ja/java/font-replacement/) はプレゼンテーション全体でフォントを別のフォントに意図的に変更します。フォント置換は、元のフォントが利用できないなど条件が満たされたときに、レンダリング出力用のフォントを選択します。

**置換ルールはいつ適用されますか？**  
ルールはレンダリングおよび変換時の [フォント選択シーケンス](/slides/ja/java/font-selection-sequence/) に参加します。`WhenInaccessible` の場合、Aspose.Slides がソースフォントにアクセスできないときにのみルールが使用されます。

**フォントが欠落していて置換ルールが設定されていない場合はどうなりますか？**  
Aspose.Slides はフォント選択プロセスに従って最も近い利用可能なフォントを選択します。結果は実行環境にインストールされているフォントに依存します。

**外部フォントをロードして置換を回避できますか？**  
はい。[外部フォントをロード](/slides/ja/java/custom-font/) すれば、Aspose.Slides はレンダリングおよび変換時にそれらを使用できます。

**Aspose はライブラリにフォントを同梱していますか？**  
いいえ。フォントの提供とライセンス遵守はユーザーの責任です。

**Windows、Linux、macOS 間で置換結果が異なることがありますか？**  
あります。OS ごとにインストールされているフォントや検索場所が異なるため、あるマシンで利用可能なフォントが別のマシンでは置換が必要になることがあります。

**バッチ変換でフォント選択を一貫させるにはどうすればよいですか？**  
すべてのマシンまたはコンテナで同じフォント ファイルとバージョンを使用し、[必要な外部フォント](/slides/ja/java/custom-font/) をロードし、ライセンスが許可する場合は [フォントの埋め込み](/slides/ja/java/embedded-font/) を行います。また、エクスポート前に [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) を呼び出して予期しない置換を特定することもできます。