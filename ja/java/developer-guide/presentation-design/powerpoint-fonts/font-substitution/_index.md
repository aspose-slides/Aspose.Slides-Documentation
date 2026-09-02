---
title: Java を使用したプレゼンテーションでのフォント置換の設定
linktitle: フォント置換
type: docs
weight: 70
url: /ja/java/font-substitution/
keywords:
- フォント
- 代替フォント
- フォント置換
- フォントの置換
- フォント置換
- 置換規則
- 置換規則
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションをレンダリングまたは変換する際に、Aspose.Slides for Java でフォント置換規則を設定し、置換されたフォントを確認します。"
---
## **概要**

フォント置換を使用すると、Aspose.Slides はプレゼンテーションのレンダリングまたは変換時にアクセスできないフォントの代わりに利用可能なフォントを使用できます。置換はレンダリングされた出力に影響しますが、プレゼンテーションコンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、また、Aspose.Slides がレンダリング時に行う置換を確認できます。これにより、インストールされているフォントが異なる環境間でも出力を一貫させることができます。

## **フォント置換の取得**

プレゼンテーションがレンダリングされる際にどのフォントが置換されるかを判定するには、[IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) メソッドを使用します。このメソッドは、元のフォント名と置換後のフォント名を示す [FontSubstitutionInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsubstitutioninfo/) オブジェクトを返します。

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

`int[] slides` 引数を指定した [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) のオーバーロードを使用すると、特定のスライドをレンダリングする際に必要な置換のみを検査できます。これは、プレゼンテーションの一部をレンダリングまたはエクスポートする場合、巨大なプレゼンテーションを増分チェックする場合、利用できないフォントに依存するスライドを特定する場合、サーバーまたはコンテナ向けに最小限のフォントパッケージを準備する場合、または無関係なスライドを処理せずにレンダリングの差異を診断する場合に便利です。

`slides` 配列は 1 から始まるスライドインデックスを含みます：`1` は最初のスライドを表します。対照的に、[Presentation.getSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getSlides--) コレクションアクセサは 0 ベースのインデックスを使用するため、同じスライドは `presentation.getSlides().get_Item(0)` としてアクセスされます。配列を作成するときはこの違いを念頭に置き、オフバイワンエラーを防いでください。

このオーバーロードは [Presentation.getFontsManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getFontsManager--) メソッド経由で呼び出します。選択したスライドのレンダリング中に決定された置換のみを返します。各結果は元のフォント名と置換後のフォント名を含む [FontSubstitutionInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsubstitutioninfo/) オブジェクトです。結果は現在のフォント環境、設定されたフォールバック規則、[IFontSubstRuleCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsubstrulecollection/) に格納された置換規則、および [externally loaded fonts](/slides/ja/java/custom-font/) を反映します。

同じ置換が複数の選択スライドで必要になることがあります。フォントインベントリやプリフライトレポートを作成する際は結果を重複除去してください。次の例は、返されたすべての置換を報告し、その後一意のフォントマッピングのソートリストを作成します。

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

[IFontsManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/) インターフェイスは両方のオーバーロードを提供します。レンダリング操作の対象範囲に応じて選択してください。

| オーバーロード | 使用シーン |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getSubstitutions--)（引数なし） | プレゼンテーション全体の置換が必要な場合。 |
| [getSubstitutions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---)（`int[] slides`） | 選択範囲、増分チェック、または部分エクスポートの置換が必要な場合。 |

## **フォント置換規則の設定**

元フォントが利用できないときに Aspose.Slides が使用すべきフォントを指定するには、次の手順に従います。

1. プレゼンテーションをロードします。
2. 元フォントと代替フォントの定義を作成します。
3. [WhenInaccessible](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsubstcondition/) 条件で [FontSubstRule](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsubstrule/) を作成します。
4. ルールを [FontSubstRuleCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsubstrulecollection/) に追加します。
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) メソッドを使用してコレクションを割り当てます。
6. プレゼンテーションをレンダリングまたは変換します。

次の Java の例は、`SomeRareFont` が利用できないときに `Arial` を代替フォントとして使用し、結果を確認するために最初のスライドをレンダリングします。代替フォントは Aspose.Slides が利用できる状態である必要があります。

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
プレゼンテーション全体で使用されるフォントを無条件に変更する場合は、[Font Replacement](/slides/ja/java/font-replacement/) を参照してください。
{{% /alert %}}

## **数式フォントの制限**

フォント置換規則は、レンダリングおよび変換時に使用される標準的なフォント選択プロセスの一部です。規則は、アクセスできないフォントを規則で指定された利用可能なフォントに置き換えることができる通常のテキストに対して機能します。

Office Math の数式には追加の要件があります。数式が **Cambria Math** を使用している場合、Aspose.Slides はレイアウト計算とレンダリングのためにその正確なフォントが必要になることがあります。**STIX Two Math** のような別の数式フォントに置換する規則は **Cambria Math** の代替にはなりません。そのため、レンダリングは依然として **Cambria Math** が必要であると報告する可能性があります。

そのようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides が利用できるようにしてください。OS にインストールするか、[外部フォント](/slides/ja/java/custom-font/) としてロードします。

この制限は数式レイアウトにのみ適用されます。上記の置換規則は通常のプレゼンテーションテキストには引き続き適用されます。

## **FAQ**

**フォント置換とフォント置換規則の違いは何ですか？**  
[Font replacement](/slides/ja/java/font-replacement/) はプレゼンテーション全体であるフォントを別のフォントに意図的に変更します。フォント置換は、元のフォントが利用できないなど設定条件が満たされたときに、レンダリング出力用のフォントを選択します。

**置換規則はいつ適用されますか？**  
規則はレンダリングおよび変換時の [フォント選択シーケンス](/slides/ja/java/font-selection-sequence/) に参加します。`WhenInaccessible` が指定されている場合、Aspose.Slides が元フォントにアクセスできないときにのみ規則が使用されます。

**フォントが欠落していて置換規則が設定されていない場合はどうなりますか？**  
Aspose.Slides はフォント選択プロセスに基づき、利用可能な最も近いフォントを選択します。結果は実行時環境にインストールされているフォントに依存します。

**外部フォントをロードすれば置換を回避できますか？**  
はい。[外部フォント](/slides/ja/java/custom-font/) をロードすれば、レンダリングや変換時にそれらを使用できます。

**Aspose はライブラリにフォントを同梱していますか？**  
いいえ。フォントの提供とライセンス遵守はユーザーの責任です。

**Windows、Linux、macOS 間で置換結果が異なることがありますか？**  
あります。OS ごとにインストールされているフォントや検索パスが異なるため、あるマシンで利用できるフォントが別のマシンでは置換対象になることがあります。

**バッチ変換でフォント選択を一貫させるにはどうすればよいですか？**  
すべてのマシンまたはコンテナで同じフォントファイルとバージョンを使用し、必要な外部フォントを [ロード](/slides/ja/java/custom-font/) し、ライセンスが許可する場合は [フォント埋め込み](/slides/ja/java/embedded-font/) を行います。また、エクスポート前に [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) を呼び出して予期しない置換を特定することもできます。