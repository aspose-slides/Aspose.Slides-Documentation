---
title: Android のプレゼンテーションでフォント置換を設定する
linktitle: フォント置換
type: docs
weight: 70
url: /ja/androidjava/font-substitution/
keywords:
- フォント
- 置換フォント
- フォント置換
- フォントの置換
- フォント置換
- 置換規則
- 置換ルール
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "プレゼンテーションのレンダリングまたは変換時に、Java を使用して Android 用 Aspose.Slides のフォント置換規則を設定し、置換されたフォントを検査します。"
---
## **概要**

フォント置換を使用すると、Aspose.Slides は、プレゼンテーションのレンダリングまたは変換時にアクセスできないフォントの代わりに利用可能なフォントを使用できます。置換はレンダリング結果に影響しますが、プレゼンテーション コンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、Aspose.Slides がレンダリング中に行う置換を確認できます。これにより、利用可能なフォントが異なる Android デバイスや環境間で出力を一貫させることができます。

フォントが利用可能だが専用の太字書体がない場合は、[専用の太字書体がないフォントの処理](/slides/ja/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)をご覧ください。そのセクションでは、PDF エクスポート時に影響を受けたテキストをラスタライズする方法と、テキスト選択、検索、拡大縮小への影響について説明しています。

## **フォント置換の取得**

プレゼンテーションがレンダリングされる際にどのフォントが置換されるかを判断するには、[IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) メソッドを使用します。このメソッドは、元のフォント名と置換されたフォント名を特定する [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) オブジェクトを返します。

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

## **選択されたスライドのフォント置換の取得**

特定のスライドのレンダリングに必要な置換のみを確認するには、`int[] slides` 引数を使用した [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) のオーバーロードを使用します。これは、プレゼンテーションの一部をレンダリングまたはエクスポートする場合、大規模なプレゼンテーションを段階的にチェックする場合、利用できないフォントに依存するスライドを特定する場合、Android アプリ用に最小限のフォントパッケージを準備する場合、または関係のないスライドを処理せずにレンダリングの差異を診断する場合に便利です。

`slides` 配列は 1 から始まるスライドインデックスを含みます: `1` は最初のスライドを示します。これに対し、[Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) コレクションアクセサは 0 ベースのインデックスを使用するため、同じスライドは `presentation.getSlides().get_Item(0)` としてアクセスします。配列を作成する際はこの違いに留意し、オフバイワンエラーを防止してください。

[Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--) メソッドを介してオーバーロードを呼び出します。これにより、選択されたスライドのレンダリング中に決定された置換のみが返されます。各結果は、元のフォント名と置換フォント名を含む [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) オブジェクトです。結果は現在のフォント環境、設定されたフォールバック規則、[IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/) に格納された置換規則、および [外部フォント](/slides/ja/androidjava/custom-font/) を反映します。

同じ置換は�数の選択スライドで必要になることがあります。フォントインベントリやプリフライトレポートを作成する際は結果を重複除去してください。次の例は、返されたすべての置換を報告し、その後一意のフォントマッピングのソート済みリストを作成します。

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

[IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) インターフェイスは両方のオーバーロードを提供します。レンダリング操作の範囲に応じて選択してください。

| オーバーロード | 使用する状況 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) 引数なし | プレゼンテーション全体の置換が必要な場合 |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) `int[] slides` | 選択範囲、段階的チェック、または部分エクスポートの置換が必要な場合 |

## **フォント置換規則の設定**

ソースフォントが利用できない場合に Aspose.Slides が使用すべきフォントを指定するには、以下の手順を実行します。

1. プレゼンテーションをロードします。
2. ソースフォントと置換フォントの定義を作成します。
3. [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) を、[WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/) 条件とともに作成します。
4. [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/) にルールを追加します。
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) メソッドを使用してコレクションを割り当てます。
6. プレゼンテーションをレンダリングまたは変換します。

次の Java の例は、`SomeRareFont` が利用できない場合に `Arial` に置き換え、結果を確認するために最初のスライドをレンダリングします。置換フォントは Aspose.Slides が利用できる必要があります。

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
プレゼンテーション全体で使用されるフォントを無条件に変更するには、[フォント置換](/slides/ja/androidjava/font-replacement/)をご覧ください。
{{% /alert %}}

## **数式フォントの制限**

フォント置換規則は、レンダリングおよび変換時に使用される標準的なフォント選択プロセスの一部です。Aspose.Slides がアクセスできないフォントを規則で指定された利用可能なフォントに置換できる場合、通常のテキストに対して機能します。

Office Math の数式には追加の要件があります。数式が **Cambria Math** を使用している場合、Aspose.Slides はその正確なフォントが必要になることがあります。**STIX Two Math** のような別の数式フォントに置換する規則は、この目的のために **Cambria Math** を置き換えることはできず、レンダリングは依然として **Cambria Math** が必要であると報告する可能性があります。

このようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides が利用できるようにします。レンダリングおよび変換時にアプリケーションが使用できるよう、[外部フォント](/slides/ja/androidjava/custom-font/)としてロードしてください。

この制限は数式のレイアウトに適用されます。上記で説明した置換規則は通常のプレゼンテーションテキストには引き続き適用されます。

## **よくある質問**

**フォント置換とフォントサブスティテューションの違いは何ですか？**  
[フォント置換](/slides/ja/androidjava/font-replacement/) は、プレゼンテーション全体であるフォントを別のフォントに意図的に変更します。フォント置換は、元のフォントが利用できないなど、設定された条件が満たされたときに、レンダリング出力用のフォントを選択します。

**置換規則はいつ適用されますか？**  
これらの規則は、レンダリングおよび変換時の [フォント選択シーケンス](/slides/ja/androidjava/font-selection-sequence/) に参加します。`WhenInaccessible` を使用する場合、Aspose.Slides がソースフォントにアクセスできないときのみ規則が使用されます。

**フォントが欠落していて置換規則が構成されていない場合はどうなりますか？**  
Aspose.Slides は、フォント選択プロセスに従って最も近い利用可能なフォントを選択します。結果はランタイム環境で利用可能なフォントに依存します。

**置換を回避するために外部フォントをロードできますか？**  
はい。Aspose.Slides がレンダリングおよび変換時に使用できるよう、[外部フォントをロード](/slides/ja/androidjava/custom-font/) できます。

**Aspose はライブラリにフォントを同梱していますか？**  
いいえ。フォントはご自身で提供し、ライセンスを遵守する必要があります。

**Android デバイス間で置換結果が異なることがありますか？**  
はい。利用可能なシステムフォントは Android のバージョン、デバイス、ベンダーによって異なるため、ある環境で利用できるフォントが別の環境では置換が必要になることがあります。

**Android デバイス間でフォント選択を一貫させるにはどうすればよいですか？**  
同じ必要なフォントファイルをアプリケーションに同梱し、[外部フォントとしてロード](/slides/ja/androidjava/custom-font/)し、ライセンスが許可する場合は [フォントを埋め込む](/slides/ja/androidjava/embedded-font/)ことができます。エクスポート前に [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) を呼び出して、予期しない置換を特定することもできます。