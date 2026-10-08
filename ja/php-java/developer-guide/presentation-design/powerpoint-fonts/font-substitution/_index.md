---
title: "PHP を使用したプレゼンテーションにおけるフォント置換の設定"
linktitle: "フォント置換"
type: docs
weight: 70
url: /ja/php-java/font-substitution/
keywords:
- "フォント"
- "代替フォント"
- "フォント置換"
- "フォント置換"
- "フォント置換"
- "置換ルール"
- "置換ルール"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "PHP"
- "Aspose.Slides"
description: "PowerPoint および OpenDocument のプレゼンテーションをレンダリングまたは変換する際に、PHP 用 Aspose.Slides でフォント置換ルールを設定し、置換されたフォントを確認します。"
---
## **概要**

フォント置換を使用すると、Aspose.Slides はプレゼンテーションのレンダリングまたは変換時にアクセスできないフォントの代わりに利用可能なフォントを使用できます。置換はレンダリングされた出力に影響しますが、プレゼンテーションのコンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、またレンダリング中に Aspose.Slides が行う置換を確認できます。これにより、インストールされているフォントが異なる環境間でも出力を一貫させることができます。

フォントが利用可能だが専用の太字フォントがない場合は、[専用の太字フォントがないフォントの処理](/slides/ja/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) を参照してください。そのセクションでは、PDF エクスポート時に対象テキストをラスタライズする方法と、テキスト選択、検索、スケーリングへの影響について説明しています。

## **フォント置換の取得**

プレゼンテーションがレンダリングされる際にどのフォントが置換されるかを判断するには、[FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) メソッドを使用します。このメソッドは、元のフォント名と置換されたフォント名を示す [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) オブジェクトを返します。

次の PHP の例は、プレゼンテーションのすべてのフォント置換を一覧表示します：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **選択スライドのフォント置換の取得**

`int[] slides` 引数を使用した [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) のオーバーロードを利用すると、特定のスライドのレンダリングに必要な置換のみを確認できます。これは、プレゼンテーションの一部をレンダリングまたはエクスポートする場合や、大規模なプレゼンテーションを段階的にチェックする場合、利用できないフォントに依存するスライドを特定する場合、サーバーやコンテナ向けに最小限のフォントパッケージを準備する場合、または無関係なスライドを処理せずにレンダリングの違いを診断する場合に便利です。

`slides` 配列は 1 から始まるスライドインデックスを含みます。`1` は最初のスライドを示します。これに対し、[Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) コレクションアクセサは 0 から始まるインデックスを使用するため、同じスライドは `$presentation->getSlides()->get_Item(0)` でアクセスします。配列を作成する際はこの違いに注意し、オフバイワンエラーを防いでください。

オーバーロードは [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/) メソッドから呼び出します。これにより、選択したスライドのレンダリング中に決定された置換のみが返されます。各結果は、元のフォント名と置換されたフォント名を含む [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) オブジェクトです。この結果は、現在のフォント環境、設定されたフォールバックルール、[FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/) に格納された置換ルール、および [externally loaded fonts](/slides/ja/php-java/custom-font/) を反映します。

同じ置換が複数の選択スライドで必要になることがあります。フォントインベントリや事前チェックレポートを作成する際は、結果の重複を除去してください。次の例は、返されたすべての置換を報告し、その後ユニークなフォントマッピングのソート済みリストを作成します：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) クラスは両方のオーバーロードを提供します。レンダリング操作のスコープに応じて選択してください：

| オーバーロード | 使用するケース |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | プレゼンテーション全体の置換が必要な場合。 |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | 選択した範囲、段階的なチェック、または部分的なエクスポートの置換が必要な場合。 |

## **フォント置換ルールの設定**

元のフォントが利用できない場合に Aspose.Slides が使用すべきフォントを指定するには、次の手順を実行します：

1. プレゼンテーションをロードします。
2. 元フォントと置換フォントのフォント定義を作成します。
3. [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/) 条件を使用して [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) を作成します。
4. そのルールを [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/) に追加します。
5. [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) メソッドを使用してコレクションを割り当てます。
6. プレゼンテーションをレンダリングまたは変換します。

次の PHP の例は、`SomeRareFont` が利用できない場合に `Arial` を置換フォントとして使用し、結果を確認するために最初のスライドをレンダリングします。置換フォントは Aspose.Slides が利用できる状態である必要があります。

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
プレゼンテーション全体で使用されるフォントを無条件に変更するには、[Font Replacement](/slides/ja/php-java/font-replacement/) を参照してください。
{{% /alert %}}

## **数式フォントの制限**

フォント置換ルールは、レンダリングおよび変換時に使用される標準的なフォント選択プロセスの一部です。Aspose.Slides がアクセスできないフォントをルールで指定された利用可能なフォントに置き換えることができる場合、通常のテキストに対して機能します。

Office Math の数式には追加の要件があります。数式が **Cambria Math** を使用している場合、Aspose.Slides はその正確なフォントが数式レイアウトの計算およびレンダリングに必要になることがあります。**STIX Two Math** のような別の数式フォントに置換するルールは、この目的で **Cambria Math** を置き換えることはできず、レンダリングは依然として **Cambria Math** が必要であると報告する可能性があります。

このようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides が利用できるようにしてください。オペレーティングシステムにインストールするか、[external font](/slides/ja/php-java/custom-font/) としてロードします。

この制限は数式のレイアウトに適用されます。上記で説明した置換ルールは通常のプレゼンテーションテキストには引き続き適用されます。

## **FAQ**

**フォント置換とフォント代替の違いは何ですか？**  
[Font replacement](/slides/ja/php-java/font-replacement/) は、プレゼンテーション全体で一つのフォントを別のフォントに意図的に変更します。フォント代替は、元のフォントが利用できないなど、設定された条件が満たされたときに、レンダリングされた出力用のフォントを選択します。

**置換ルールはいつ適用されますか？**  
これらのルールは、レンダリングおよび変換中の [font selection sequence](/slides/ja/php-java/font-selection-sequence/) に参加します。`WhenInaccessible` を使用した場合、ルールは Aspose.Slides が元のフォントにアクセスできないときにのみ使用されます。

**フォントが存在せず、置換ルールが設定されていない場合はどうなりますか？**  
Aspose.Slides は、フォント選択プロセスに従って最も近い利用可能なフォントを選択します。結果は実行時環境で利用可能なフォントに依存します。

**置換を回避するために外部フォントをロードできますか？**  
はい。Aspose.Slides がレンダリングや変換時に使用できるように、[load external fonts](/slides/ja/php-java/custom-font/) を行うことができます。

**Aspose はライブラリにフォントを同梱していますか？**  
いいえ。フォントはお客様が提供し、ライセンスを遵守する必要があります。

**置換結果は Windows、Linux、macOS で異なる場合がありますか？**  
はい。インストールされているフォントやフォント検索場所は OS によって異なるため、あるマシンで利用できるフォントが別のマシンでは置換が必要になることがあります。

**バッチ変換でフォント選択を一貫させるにはどうすればよいですか？**  
各マシンやコンテナで同じフォントファイルとバージョンを使用し、[load required external fonts](/slides/ja/php-java/custom-font/) を行い、ライセンスで許可されている場合は [embed fonts](/slides/ja/php-java/embedded-font/) を使用してください。また、エクスポート前に [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) を呼び出すことで、予期しない置換を特定できます。