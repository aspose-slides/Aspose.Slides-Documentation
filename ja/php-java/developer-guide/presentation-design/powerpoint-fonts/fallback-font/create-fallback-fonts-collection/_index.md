---
title: PHPでフォールバックフォントコレクションを構成する
linktitle: フォールバックフォントコレクション
type: docs
weight: 20
url: /ja/php-java/create-fallback-fonts-collection/
keywords:
- フォールバックフォント
- フォールバックルール
- フォントコレクション
- フォントを構成する
- フォントを設定する
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java を介して PHP 用 Aspose.Slides でフォールバックフォントコレクションを設定し、PowerPoint および OpenDocument プレゼンテーションでテキストを一貫して鮮明に保ちます。"
---

## **フォールバック ルールを適用**

[FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) に整理でき、[IFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRulesCollection) インターフェイスを実装しています。コレクションからルールを追加または削除することが可能です。

その後、このコレクションは [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) メソッドに割り当てることができます。FontsManager はプレゼンテーション全体のフォントを管理します。 詳細は [About FontsManager and FontsLoader](/slides/ja/php-java/about-fontsmanager-and-fontsloader/) をご覧ください。

各 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) には、独自の [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) クラスのインスタンスを持つ [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) メソッドがあります。

以下は、特定のプレゼンテーションの [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) にフォールバックフォントルールコレクションを作成して割り当てる例です:  ```php
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
詳細は、[Render Presentation with Fallback Font](/slides/ja/php-java/render-presentation-with-fallback-font/) をご覧ください。
{{% /alert %}}

## **よくある質問**

**フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされず、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のテキストすべてに同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリと共にフォントを配布していますか？**

いいえ。フォントはご自身で追加・使用し、その責任はユーザーにあります。

**不足しているフォントの置換/サブスティテューションと、欠損グリフのフォールバックは一緒に使用できますか？**

はい。これらは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの利用可否を解決します（[replacement](/slides/ja/php-java/font-replacement/)/[substitution](/slides/ja/php-java/font-substitution/)）。その後、フォールバックが利用可能なフォント内の欠損グリフのギャップを埋めます。