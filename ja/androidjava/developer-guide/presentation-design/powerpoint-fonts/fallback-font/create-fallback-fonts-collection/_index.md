---
title: Android でフォールバック フォント コレクションを構成する
linktitle: フォールバック フォント コレクション
type: docs
weight: 20
url: /ja/androidjava/create-fallback-fonts-collection/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォント コレクション
- フォント の構成
- フォント の設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides のフォールバック フォント コレクションを設定し、PowerPoint および OpenDocument のプレゼンテーションでテキストの一貫性と鮮明さを保ちます。"
---

## **フォールバック ルールの適用**

[FontFallBackRule] クラスのインスタンスは、[FontFallBackRulesCollection] に整理でき、[IFontFallBackRulesCollection] インターフェイスを実装しています。コレクションからルールを追加または削除することが可能です。

次に、このコレクションは [FontsManager] クラスの [FontFallBackRulesCollection] メソッドに割り当てることができます。FontsManager はプレゼンテーション全体のフォントを管理します。

各 [Presentation] には、[FontsManager] クラスのインスタンスを返す [getFontsManager] メソッドがあります。

以下は、フォールバック フォント ルール コレクションを作成し、特定のプレゼンテーションの [FontsManager] に割り当てる例です。  
```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```


FontsManager がフォールバック フォント コレクションで初期化されると、プレゼンテーションのレンダリング中にフォールバック フォントが適用されます。

{{% alert color="primary" %}} 
フォールバック フォントでプレゼンテーションをレンダリングする方法の詳細は、[Render Presentation with Fallback Font](/slides/ja/androidjava/render-presentation-with-fallback-font/) をご覧ください。
{{% /alert %}}

## **よくある質問**

**フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされないため、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のすべてのテキストに同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリと共にフォントを配布していますか？**

いいえ。フォントはご自身で追加・使用し、その責任は利用者にあります。

**欠落したフォントの置換/サブスティテューションと欠落したグリフのフォールバックは同時に使用できますか？**

はい。これらは同一のフォント解決パイプラインの独立した段階です。まずエンジンがフォントの利用可能性を解決し（[replacement](/slides/ja/androidjava/font-replacement/)/[substitution](/slides/ja/androidjava/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠落グリフを埋めます。