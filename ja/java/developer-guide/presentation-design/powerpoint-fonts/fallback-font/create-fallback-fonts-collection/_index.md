---
title: Javaでフォールバック フォント コレクションを構成する
linktitle: フォールバック フォント コレクション
type: docs
weight: 20
url: /ja/java/create-fallback-fonts-collection/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォント コレクション
- フォント の構成
- フォント の設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でフォールバック フォント コレクションを設定し、PowerPoint および OpenDocument のプレゼンテーションでテキストの一貫性と鮮明さを保ちます。"
---
## **概要**

Aspose.Slides を使用すると、プレゼンテーションのフォールバック フォント ルールのコレクションを構成できます。各フォールバック ルールは `FontFallBackRule` クラスで表され、`IFontFallBackRulesCollection` インターフェイスを実装する `FontFallBackRulesCollection` に追加できます。

コレクションを作成したら、プレゼンテーションの `FontsManager` の `FontFallBackRulesCollection` プロパティに割り当てることができます。`FontsManager` はプレゼンテーション全体のフォントを管理し、各 `Presentation` インスタンスはそれぞれ独自の `FontsManager` を持ちます。

`FontsManager` がフォールバック フォント コレクションで初期化されると、指定されたフォールバック フォントがプレゼンテーションのレンダリング時に適用されます。

## **フォールバック規則の適用**

インスタンスは [FontFallBackRule](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontFallBackRule) クラスのものを、[FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontFallBackRulesCollection) に整理できます。このコレクションは [IFontFallBackRulesCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IFontFallBackRulesCollection) インターフェイスを実装しています。コレクションから規則を追加または削除することが可能です。

次に、このコレクションを [FontsManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontsManager) クラスの [FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontFallBackRulesCollection) メソッドに割り当てることができます。FontsManager はプレゼンテーション全体のフォントを管理します。

各 [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) には、独自の [FontsManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontsManager) インスタンスを返す [getFontsManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation#getFontsManager--) メソッドがあります。

以下は、特定のプレゼンテーションの [FontsManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation#getFontsManager--) にフォールバック フォント ルール コレクションを作成して割り当てる例です：

```java
import com.aspose.slides.*;

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

`FontsManager` がフォールバック フォント コレクションで初期化されると、プレゼンテーションのレンダリング時にフォールバック フォントが適用されます。

{{% alert color="info" %}} 
詳しくは[フォールバック フォントでプレゼンテーションをレンダリング](/slides/ja/java/render-presentation-with-fallback-font/)をご覧ください。
{{% /alert %}}

## **FAQ**

### フォールバック ルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？

いいえ。フォールバック ルールは実行時のレンダリング設定であり、PPTX にシリアライズされないため、PowerPoint の UI には表示されません。

### フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？

はい。これらのオブジェクト内のテキストには同じグリフ置換メカニズムが使用されます。

### Aspose はライブラリにフォントを同梱していますか？

いいえ。フォントはご自身で追加・使用していただくもので、すべてご自身の責任で管理してください。

### 欠落したフォントの置換/サブスティテューションと、欠落したグリフのフォールバックは同時に使用できますか？

はい。これらは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの利用可否を解決し（[replacement](/slides/ja/java/font-replacement/)/[substitution](/slides/ja/java/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠落したグリフのギャップを埋めます。