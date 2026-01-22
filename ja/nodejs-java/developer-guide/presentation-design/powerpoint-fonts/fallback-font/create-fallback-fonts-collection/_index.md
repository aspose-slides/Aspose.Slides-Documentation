---
title: JavaScriptでフォールバックフォントコレクションを構成する
linktitle: フォールバックフォントコレクション
type: docs
weight: 20
url: /ja/nodejs-java/create-fallback-fonts-collection/
keywords:
- フォールバックフォント
- フォールバック規則
- フォントコレクション
- フォントの構成
- フォントの設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js 用 Aspose.Slides を使用して JavaScript でフォールバックフォントコレクションを設定し、PowerPoint および OpenDocument のプレゼンテーションでテキストを一貫して鮮明に保ちます。"
---

## **フォールバック規則の適用**

Instances of [FontFallBackRule] class can be organized into [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection), that implements [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) class. It is possible to add or remove rules from the collection.

Then this collection may be assigned to [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) method of the [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) class. FontsManager controls fonts across the presentation.

Each [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) has a [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) method with its own instance of the [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) class.

Here is an examples how to create fallback fonts rules collection and assign in into the [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) of a certain presentation:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


After FontsManager is initialised with fallback fonts collection, the fallback fonts are applied during presentation rendering.

{{% alert color="primary" %}} 
フォールバックフォントでのプレゼンテーションのレンダリングの詳細については、[Render Presentation with Fallback Font](/slides/ja/nodejs-java/render-presentation-with-fallback-font/) をご覧ください。 
{{% /alert %}}

## **よくある質問**

**私のフォールバック規則は PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック規則は実行時のレンダリング設定であり、PPTX にシリアライズされず、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のテキストには同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリと共にフォントを配布しますか？**

いいえ。フォントはご自身で追加・使用し、自己の責任で管理してください。

**欠落フォントの置換/代替と欠落グリフのフォールバックは同時に使用できますか？**

はい。これらは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの利用可能性を解決し（[replacement](/slides/ja/nodejs-java/font-replacement/)/[substitution](/slides/ja/nodejs-java/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠落グリフのギャップを埋めます。