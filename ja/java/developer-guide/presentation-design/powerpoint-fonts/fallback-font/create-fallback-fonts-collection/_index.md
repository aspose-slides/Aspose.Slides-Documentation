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
description: "Aspose.Slides for Java でフォールバックフォントコレクションを設定し、PowerPoint と OpenDocument のプレゼンテーションでテキストの一貫性と鮮明さを保ちます。"
---

## **Apply Fallback Rules**

[FontFallBackRule] クラスのインスタンスは、[FontFallBackRulesCollection] に整理でき、これは[IFontFallBackRulesCollection] インターフェースを実装しています。コレクションからルールを追加または削除することが可能です。

次に、このコレクションは[FontsManager] クラスの[FontFallBackRulesCollection] メソッドに割り当てることができます。FontsManager はプレゼンテーション全体のフォントを管理します。詳細は[About FontsManager and FontsLoader](/slides/ja/java/about-fontsmanager-and-fontsloader/) を参照してください。

各[Presentation] には、独自の[FontsManager] インスタンスを返す[getFontsManager] メソッドがあります。

以下は、フォールバックフォントルールコレクションを作成し、特定のプレゼンテーションの[FontsManager] に割り当てる例です。　
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


FontsManager がフォールバックフォントコレクションで初期化されると、プレゼンテーションのレンダリング中にフォールバックフォントが適用されます。

{{% alert color="primary" %}} 
フォールバックフォントでプレゼンテーションをレンダリングする方法の詳細は、[Render Presentation with Fallback Font](/slides/ja/java/render-presentation-with-fallback-font/) をご覧ください。
{{% /alert %}}

## **FAQ**

**保存後に PPTX ファイルにフォールバックルールが埋め込まれ、PowerPoint で表示されますか？**

いいえ。フォールバックルールは実行時のレンダリング設定であり、PPTX にシリアライズされないため、PowerPoint の UI には表示されません。

**SmartArt、WordArt、チャート、テーブル内のテキストにもフォールバックは適用されますか？**

はい。これらのオブジェクト内のテキストにも同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリと一緒にフォントを配布していますか？**

いいえ。フォントはご自身で追加・使用していただくものです。その責任は利用者にあります。

**欠損フォントの置換/サブスティテューションと、欠損グリフのフォールバックを同時に使用できますか？**

はい。これは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの利用可能性を解決し（[replacement](/slides/ja/java/font-replacement/)/[substitution](/slides/ja/java/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠損グリフを補填します。