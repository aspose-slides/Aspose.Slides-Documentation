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
- フォント置換
- フォント置換
- 置換規則
- 置換規則
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PowerPoint と OpenDocument プレゼンテーションを他のファイル形式に変換する際に、Aspose.Slides for PHP via Java のフォント置換を最適化します。"
---

## **フォント置換規則の設定**

Aspose.Slides では、特定の条件（例: フォントにアクセスできない場合）で何を行うかを決定するフォント規則を次のように設定できます。

1. 対象のプレゼンテーションを読み込みます。
2. 置換対象となるフォントを読み込みます。
3. 新しいフォントを読み込みます。
4. 置換の規則を追加します。
5. プレゼンテーションのフォント置換規則コレクションに規則を追加します。
6. スライド画像を生成し、効果を確認します。

この PHP コードはフォント置換プロセスを示しています:
```php
  # プレゼンテーションを読み込みます
  $pres = new Presentation("Fonts.pptx");
  try {
    # 置換対象となるソースフォントを読み込みます
    $sourceFont = new FontData("SomeRareFont");
    # 新しいフォントを読み込みます
    $destFont = new FontData("Arial");
    # フォント置換のためのルールを追加します
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # フォント置換ルールコレクションにルールを追加します
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # ルールリストにフォントルールコレクションを追加します
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # Arial フォントは SomeRareFont がアクセスできない場合に代わりに使用されます
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # 画像を JPEG 形式でディスクに保存します
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{%  alert title="NOTE"  color="warning"   %}} 
以下をご覧ください[**フォント置換**](/slides/ja/php-java/font-replacement/)。
{{% /alert %}}

## **よくある質問**

**フォント置換とフォント代替の違いは何ですか？**

[置換](/slides/ja/php-java/font-replacement/) はプレゼンテーション全体であるフォントを別のフォントに強制的に上書きするものです。代替は特定の条件（例: 元のフォントが利用できない場合）でトリガーされ、指定された代替フォントが使用されます。

**代替規則は正確にいつ適用されますか？**

規則はロード、レンダリング、変換の際に評価される標準的な[フォント選択](/slides/ja/php-java/font-selection-sequence/)シーケンスに参加します。選択されたフォントが利用できない場合、置換または代替が適用されます。

**置換も代替も設定されておらず、システムにフォントが存在しない場合のデフォルト動作は何ですか？**

ライブラリは PowerPoint と同様に、利用可能な最も近いシステムフォントを選択しようとします。

**代替を回避するために、実行時にカスタム外部フォントを添付できますか？**

はい。ランタイム時に[外部フォントを追加](/slides/ja/php-java/custom-font/)することで、ライブラリはそれらを選択やレンダリングに考慮し、以降の変換にも使用できます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。Aspose は有料・無料を問わずフォントを配布していません。フォントの追加と使用はご自身の裁量と責任で行ってください。

**Windows、Linux、macOS で代替の挙動に違いはありますか？**

はい。フォントの検出は OS のフォントディレクトリから開始されます。デフォルトで利用可能なフォントセットや検索パスはプラットフォームごとに異なり、利用可否や代替の必要性に影響します。

**バッチ変換時に予期しない代替を最小限に抑えるために環境をどう準備すべきですか？**

マシンやコンテナ間でフォントセットを同期し、出力ドキュメントに必要な[外部フォントを追加](/slides/ja/php-java/custom-font/)し、可能であればプレゼンテーションに[フォントを埋め込む](/slides/ja/php-java/embedded-font/)ことで、レンダリング時に選択されたフォントが利用できるようにします。