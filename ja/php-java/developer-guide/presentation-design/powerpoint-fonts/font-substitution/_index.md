---
title: PHP を使用したプレゼンテーションでのフォント置換の設定
linktitle: フォント置換
type: docs
weight: 70
url: /ja/php-java/font-substitution/
keywords:
- フォント
- 置換フォント
- フォント置換
- フォント置換え
- フォントを置き換える
- 置換規則
- 置き換え規則
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PowerPoint および OpenDocument のプレゼンテーションをレンダリングまたは変換する際に、Java 経由で PHP 用 Aspose.Slides のフォント置換規則を設定し、置換されたフォントを確認します。"
---
## **概要**

フォント置換を使用すると、Aspose.Slides はプレゼンテーションがレンダリングまたは変換される際にアクセスできないフォントの代わりに利用可能なフォントを使用できます。置換はレンダリングされた出力に影響しますが、プレゼンテーションのコンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、Aspose.Slides がレンダリング中に行う置換を確認することができます。これにより、インストールされているフォントが異なる環境間でも出力を一貫させることができます。

## **フォント置換の取得**

プレゼンテーションがレンダリングされる際に置換されるフォントを確認するには、[FontsManager::getSubstitutions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/getsubstitutions/) メソッドを使用します。このメソッドは、元のフォント名と置換後のフォント名を示す[FontSubstitutionInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsubstitutioninfo/) オブジェクトを返します。

次の PHP の例は、プレゼンテーションのすべてのフォント置換を一覧表示します。

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

## **選択したスライドのフォント置換の取得**

特定のスライドをレンダリングするために必要な置換のみを確認するには、`int[] slides` 引数を持つ [FontsManager::getSubstitutions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/getsubstitutions/) のオーバーロードを使用します。これは、プレゼンテーションの一部をレンダリングまたはエクスポートする場合、大規模なプレゼンテーションを増分でチェックする場合、利用できないフォントに依存するスライドを特定する場合、サーバーやコンテナ用に最小限のフォントパッケージを準備する場合、または無関係なスライドを処理せずにレンダリングの差異を診断する場合に役立ちます。

`slides` 配列は 1 ベースのスライドインデックスを含みます: `1` が最初のスライドを示します。一方、[Presentation::getSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getSlides) コレクションアクセサは 0 ベースのインデックスを使用するため、同じスライドは `$presentation->getSlides()->get_Item(0)` でアクセスされます。この違いを考慮して配列を作成し、オフバイワンエラーを防いでください。

オーバーロードは [Presentation::getFontsManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getFontsManager) メソッドから呼び出します。選択したスライドのレンダリング中に決定された置換のみが返されます。各結果は元のフォント名と置換フォント名を含む [FontSubstitutionInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsubstitutioninfo/) オブジェクトです。結果は現在のフォント環境、設定されたフォールバック規則、[FontSubstRuleCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsubstrulecollection/) に格納された置換規則、そして[外部フォント](/slides/ja/php-java/custom-font/) に反映されます。

同じ置換が複数の選択スライドで必要になることがあります。フォントインベントリや事前チェックレポートを作成する際は結果を重複排除してください。次の例は返されたすべての置換を報告し、ユニークなフォントマッピングのソート済みリストを作成します。

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

[FontsManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/) クラスは両方のオーバーロードを提供します。レンダリング操作のスコープに応じて選択してください。

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | プレゼンテーション全体の置換が必要な場合。 |
| [getSubstitutions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | 選択した範囲、増分チェック、または部分エクスポートの置換が必要な場合。 |

## **フォント置換ルールの設定**

1. プレゼンテーションをロードします。
2. 元フォントと置換フォントの定義を作成します。
3. [WhenInaccessible](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsubstcondition/) 条件を使用して [FontSubstRule](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsubstrule/) を作成します。
4. [FontSubstRuleCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsubstrulecollection/) にルールを追加します。
5. [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) メソッドを使用してコレクションを割り当てます。
6. プレゼンテーションをレンダリングまたは変換します。

次の PHP の例は、`SomeRareFont` が利用できない場合に `Arial` に置換し、結果を確認するために最初のスライドをレンダリングします。置換フォントは Aspose.Slides が使用できるものである必要があります。

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
プレゼンテーション全体でフォントを無条件に変更したい場合は、[Font Replacement](/slides/ja/php-java/font-replacement/) を参照してください。
{{% /alert %}}

## **数式フォントに関する制限**

フォント置換ルールは、レンダリングおよび変換時に使用される標準のフォント選択プロセスの一部です。これは、Aspose.Slides がアクセスできないフォントを規則で指定された利用可能なフォントに置き換えることができる通常のテキストに対して機能します。

Office Math の数式には追加の要件があります。数式が **Cambria Math** を使用している場合、Aspose.Slides はレイアウト計算とレンダリングのためにその正確なフォントが必要になることがあります。**STIX Two Math** のような別の数式フォントに置換する規則は、**Cambria Math** を置き換えることはできず、レンダリングは依然として **Cambria Math** が必要であると報告する可能性があります。

このようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides が使用できるようにしてください。OS にインストールするか、[外部フォント](/slides/ja/php-java/custom-font/) としてロードします。

この制限は数式レイアウトにのみ適用されます。上記の置換ルールは通常のプレゼンテーションテキストには引き続き適用されます。

## **FAQ**

**フォント置換とフォント代替の違いは何ですか？**  
[Font replacement](/slides/ja/php-java/font-replacement/) はプレゼンテーション全体でフォントを意図的に別のフォントに変更します。フォント置換は、元のフォントが利用できないなど設定された条件が満たされたときに、レンダリング出力用のフォントを選択します。

**置換ルールはいつ適用されますか？**  
ルールはレンダリングおよび変換時の[フォント選択シーケンス](/slides/ja/php-java/font-selection-sequence/) に参加します。`WhenInaccessible` が指定されている場合、Aspose.Slides が元フォントにアクセスできないときにのみルールが使用されます。

**フォントが欠落していて置換ルールが設定されていない場合はどうなりますか？**  
Aspose.Slides はフォント選択プロセスに基づき、利用可能な最も近いフォントを選択します。結果は実行環境にインストールされているフォントに依存します。

**置換を回避するために外部フォントをロードできますか？**  
はい。[外部フォント](/slides/ja/php-java/custom-font/) をロードすれば、レンダリングおよび変換時に Aspose.Slides が使用できます。

**Aspose はライブラリにフォントを同梱していますか？**  
いいえ。フォントの提供とライセンス遵守はユーザーの責任です。

**置換結果は Windows、Linux、macOS で異なる場合がありますか？**  
はい。OS ごとにインストールされているフォントや検索場所が異なるため、あるマシンで利用可能なフォントが別のマシンでは置換が必要になることがあります。

**バッチ変換でフォント選択を一貫させるにはどうすればよいですか？**  
すべてのマシンまたはコンテナで同じフォントファイルとバージョンを使用し、[外部フォント](/slides/ja/php-java/custom-font/) をロードし、ライセンスが許可する場合は[フォントの埋め込み](/slides/ja/php-java/embedded-font/) を行います。また、エクスポート前に [FontsManager::getSubstitutions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fontsmanager/getsubstitutions/) を呼び出して予期しない置換を特定できます。