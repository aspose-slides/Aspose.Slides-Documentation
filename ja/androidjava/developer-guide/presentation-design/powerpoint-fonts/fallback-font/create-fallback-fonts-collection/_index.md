---
title: Android でフォールバック フォント コレクションを設定する
linktitle: フォールバック フォント コレクション
type: docs
weight: 20
url: /ja/androidjava/create-fallback-fonts-collection/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォント コレクション
- フォントの構成
- フォントの設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides のフォールバック フォント コレクションを設定し、PowerPoint および OpenDocument のプレゼンテーションでテキストを一貫性がありくっきりと表示させます。"
---

## **フォールバック ルールの適用**

[FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) に編成でき、[IFontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRulesCollection) インターフェイスを実装します。コレクションからルールを追加または削除することが可能です。

次に、このコレクションは [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) クラスの [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) メソッドに割り当てることができます。FontsManager はプレゼンテーション全体のフォントを管理します。詳細は [FontsManager と FontsLoader の概要](/slides/ja/androidjava/about-fontsmanager-and-fontsloader/) をご覧ください。

各 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) には、独自の [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) インスタンスを返す [getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) メソッドがあります。

以下は、フォールバック フォント ルール コレクションを作成し、特定のプレゼンテーションの [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getFontsManager--) に割り当てる方法の例です：  
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
詳しくは、[Render Presentation with Fallback Font](/slides/ja/androidjava/render-presentation-with-fallback-font/) をご覧ください。 
{{% /alert %}}

## **よくある質問**

**私のフォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされないため、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のすべてのテキストに同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントはユーザー側で追加および使用し、自己責任で管理してください。

**不足しているフォントの置換/代替と、欠落したグリフのフォールバックは同時に使用できますか？**

はい。これらは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの利用可能性を解決し（[replacement](/slides/ja/androidjava/font-replacement/)/[substitution](/slides/ja/androidjava/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠けたグリフを補填します。