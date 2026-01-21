---
title: Javaでフォールバックフォントコレクションを構成する
linktitle: フォールバックフォントコレクション
type: docs
weight: 20
url: /ja/java/create-fallback-fonts-collection/
keywords:
- フォールバックフォント
- フォールバックルール
- フォントコレクション
- フォントの構成
- フォントの設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java向けAspose.Slidesでフォールバックフォントコレクションを設定し、PowerPointおよびOpenDocumentプレゼンテーションでテキストの一貫性と鮮明さを維持します。"
---

## **フォールバック ルールの適用**

Instances of [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) class can be organized into [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection), that implements [IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection) interface. It is possible to add or remove rules from the collection.

Then this collection may be assigned to [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) method of the [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) class. FontsManager controls fonts across the presentation.

Each [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) has a [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) method with its own instance of the [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) class.

Here is an examples how to create fallback fonts rules collection and assign in into the [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) of a certain presentation:  
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


After FontsManager is initialised with fallback fonts collection, the fallback fonts are applied during presentation rendering.

{{% alert color="primary" %}} 
フォールバック フォントでプレゼンテーションをレンダリングする方法の詳細は、[Render Presentation with Fallback Font](/slides/ja/java/render-presentation-with-fallback-font/)をご覧ください。
{{% /alert %}}

## **よくある質問**

**フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされず、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のテキストすべてに同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントはご自身で追加・使用していただき、その責任はご自身にあります。

**欠落フォントの置換/サブスティテューションと、欠落グリフに対するフォールバックは同時に使用できますか？**

はい。これは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの利用可能性を解決し（[replacement](/slides/ja/java/font-replacement/)/[substitution](/slides/ja/java/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠落グリフのギャップを埋めます。