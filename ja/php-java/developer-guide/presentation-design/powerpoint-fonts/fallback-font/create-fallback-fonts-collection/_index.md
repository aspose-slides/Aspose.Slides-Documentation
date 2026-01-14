---
title: PHP でフォールバックフォントコレクションを構成する
linktitle: フォールバックフォント コレクション
type: docs
weight: 20
url: /ja/php-java/create-fallback-fonts-collection/
keywords:
- フォールバックフォント
- フォールバックルール
- フォントコレクション
- フォントの構成
- フォントの設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を Java 経由で使用してフォールバックフォントコレクションを設定し、PowerPoint および OpenDocument プレゼンテーションでテキストを一貫して鮮明に保ちます。"
---

## **フォールバック ルールの適用**

FontFallBackRule クラスのインスタンスは [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) に編成できます。コレクションからルールを追加または削除することが可能です。

このコレクションは [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) クラスの [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) メソッドに割り当てることができます。FontsManager はプレゼンテーション全体のフォントを管理します。詳細は [FontsManager と FontsLoader について](/slides/ja/php-java/about-fontsmanager-and-fontsloader/) をご覧ください。

各 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) は、独自の [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) クラスインスタンスを持つ [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) メソッドを備えています。

以下は、特定のプレゼンテーションの [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) にフォールバックフォントルールコレクションを作成して割り当てる例です:  
```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


FontsManager がフォールバックフォントコレクションで初期化されると、プレゼンテーションのレンダリング中にフォールバックフォントが適用されます。

{{% alert color="primary" %}} 
[Render Presentation with Fallback Font](/slides/ja/php-java/render-presentation-with-fallback-font/) の詳細をご覧ください。
{{% /alert %}}

## **FAQ**

**フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされず、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のすべてのテキストに同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントはご自身で追加・使用し、自己責任で管理してください。

**不足しているフォントの置換/サブスティテューションと欠損グリフのフォールバックを同時に使用できますか？**

はい。これらは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの可用性を解決し（[replacement](/slides/ja/php-java/font-replacement/)/[substitution](/slides/ja/php-java/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠損グリフのギャップを埋めます。