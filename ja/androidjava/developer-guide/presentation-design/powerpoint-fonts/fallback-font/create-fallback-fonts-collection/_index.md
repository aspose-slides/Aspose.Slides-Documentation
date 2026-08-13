---
title: Android でフォールバックフォントコレクションを構成する
linktitle: フォールバックフォントコレクション
type: docs
weight: 20
url: /ja/androidjava/create-fallback-fonts-collection/
keywords:
- フォールバックフォント
- フォールバックルール
- フォントコレクション
- フォント構成
- フォント設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides で Java を使用してフォールバックフォントコレクションを設定し、PowerPoint と OpenDocument のプレゼンテーションでテキストを一貫性があり鮮明に保ちます。"
---
## **概要**

Aspose.Slides を使用すると、プレゼンテーション用のフォールバックフォントルールのコレクションを構成できます。各フォールバックルールは `FontFallBackRule` クラスで表され、`FontFallBackRulesCollection` に追加でき、これは `IFontFallBackRulesCollection` インターフェイスを実装しています。

コレクションを作成したら、プレゼンテーションの `FontsManager` の `FontFallBackRulesCollection` プロパティに割り当てることができます。`FontsManager` はプレゼンテーション全体のフォントを管理し、各 `Presentation` インスタンスは独自の `FontsManager` を持ちます。

`FontsManager` がフォールバックフォントコレクションで初期化されると、指定したフォールバックフォントがプレゼンテーションのレンダリング時に適用されます。

## **フォールバックルールの適用**

[FontFallBackRule](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontFallBackRule) クラスのインスタンスは、[IFontFallBackRulesCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IFontFallBackRulesCollection) インターフェイスを実装する [FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontFallBackRulesCollection) に整理できます。コレクションからルールを追加または削除できます。

その後、このコレクションは [FontsManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontsManager) クラスの [FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontFallBackRulesCollection) メソッドに割り当てることができます。FontsManager はプレゼンテーション全体のフォントを制御します。

各 [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) には、独自の [FontsManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontsManager) インスタンスを持つ [getFontsManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#getFontsManager--) メソッドがあります。

以下は、特定のプレゼンテーションの [FontsManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#getFontsManager--) にフォールバックフォントルールコレクションを作成して割り当てる例です。

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

`FontsManager` がフォールバックフォントコレクションで初期化されると、フォールバックフォントがプレゼンテーションのレンダリング時に適用されます。

{{% alert color="info" %}} 
さらに詳しくは、[フォールバックフォントでプレゼンテーションをレンダリングする](/slides/ja/androidjava/render-presentation-with-fallback-font/) をご覧ください。 
{{% /alert %}}

## **よくある質問**

### フォールバックルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？

いいえ。フォールバックルールは実行時のレンダリング設定であり、PPTX にシリアライズされないため、PowerPoint の UI には表示されません。

### フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？

はい。これらのオブジェクト内のすべてのテキストに対して、同じグリフ置換メカニズムが使用されます。

### Aspose はライブラリと共にフォントを配布していますか？

いいえ。フォントはお客様側で追加・使用し、自己責任で管理してください。

### 欠落フォントの置換/サブスティチューションと欠落グリフのフォールバックは同時に使用できますか？

はい。これらは同一のフォント解決パイプラインの独立した段階です。まずエンジンがフォントの利用可否を解決し（[replacement](/slides/ja/androidjava/font-replacement/)/[substitution](/slides/ja/androidjava/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠落グリフを補填します。