---
title: フォールバックフォントコレクションの作成
type: docs
weight: 20
url: /ja/nodejs-java/create-fallback-fonts-collection/
---

## **フォールバック ルールの適用**

[FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) に整理でき、[FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) クラスを実装します。コレクションからルールを追加または削除することが可能です。

このコレクションは、[FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) クラスの [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) メソッドに割り当てることができます。FontsManager はプレゼンテーション全体のフォントを管理します。さらに詳しくは、[About FontsManager and FontsLoader](/slides/ja/nodejs-java/about-fontsmanager-and-fontsloader/) をご覧ください。

各 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) には、独自の [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) クラスのインスタンスを返す [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) メソッドがあります。

以下は、フォールバックフォントルールコレクションを作成し、特定のプレゼンテーションの [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--) に割り当てる例です:  
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


FontsManager がフォールバックフォントコレクションで初期化されると、プレゼンテーションのレンダリング時にフォールバックフォントが適用されます。

{{% alert color="primary" %}} 
さらに詳しくは、[Render Presentation with Fallback Font](/slides/ja/nodejs-java/render-presentation-with-fallback-font/) をご覧ください。
{{% /alert %}}

## **よくある質問**

**フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされず、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のテキストすべてに同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントはご自身で追加・使用し、自己責任で管理してください。

**欠落フォントの置換/代替と、欠落グリフのフォールバックは併用できますか？**

はい。これらは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの利用可否を解決し（[replacement](/slides/ja/nodejs-java/font-replacement/)/[substitution](/slides/ja/nodejs-java/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠落グリフを補完します。