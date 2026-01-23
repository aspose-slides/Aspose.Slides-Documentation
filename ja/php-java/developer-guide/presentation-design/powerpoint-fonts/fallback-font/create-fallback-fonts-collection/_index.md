---
title: PHP でフォールバック フォント コレクションを設定する
linktitle: フォールバック フォント コレクション
type: docs
weight: 20
url: /ja/php-java/create-fallback-fonts-collection/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォント コレクション
- フォント 設定
- フォント 設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP（Java 経由）でフォールバック フォント コレクションを設定し、PowerPoint および OpenDocument のプレゼンテーションでテキストを一貫して鮮明に保ちます。"
---

## **フォールバック ルールの適用**

Instances of [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) class can be organized into [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection). It is possible to add or remove rules from the collection.

Then this collection may be assigned to [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) method of the [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) class. FontsManager controls fonts across the presentation.

Each [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) has a [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) method with its own instance of the [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) class.

Here is an examples how to create fallback fonts rules collection and assign in into the [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) of a certain presentation:  
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


After FontsManager is initialised with fallback fonts collection, the fallback fonts are applied during presentation rendering.

{{% alert color="primary" %}} 
フォールバック フォントでのプレゼンテーションのレンダリングの詳細は、[Render Presentation with Fallback Font](/slides/ja/php-java/render-presentation-with-fallback-font/) をご覧ください。 
{{% /alert %}}

## **FAQ**

**保存後に PPTX ファイルにフォールバック ルールが埋め込まれ、PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされないため、PowerPoint の UI には表示されません。

**SmartArt、WordArt、チャート、テーブル内のテキストにもフォールバックは適用されますか？**

はい。これらのオブジェクト内のテキストすべてに同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントはご自身で追加・使用し、その責任は利用者にあります。

**欠落フォントの置換/代替と欠落グリフのフォールバックは同時に使用できますか？**

はい。これらは同一のフォント解決パイプラインの独立した段階です。まずエンジンがフォントの利用可能性を解決し（[replacement](/slides/ja/php-java/font-replacement/)/[substitution](/slides/ja/php-java/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠落グリフのギャップを埋めます。