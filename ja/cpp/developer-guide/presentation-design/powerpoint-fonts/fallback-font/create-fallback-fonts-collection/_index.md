---
title: C++ でフォールバックフォント コレクションを構成する
linktitle: フォールバック フォント コレクション
type: docs
weight: 20
url: /ja/cpp/create-fallback-fonts-collection/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォント コレクション
- フォント を構成する
- フォント を設定する
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でフォールバックフォント コレクションを設定し、PowerPoint および OpenDocument プレゼンテーションでテキストの一貫性と鮮明さを保ちます。"
---
## **概要**

Aspose.Slides を使用すると、プレゼンテーション用のフォールバックフォント規則コレクションを構成できます。各フォールバック規則は `FontFallBackRule` クラスで表され、`IFontFallBackRulesCollection` インターフェイスを実装する `FontFallBackRulesCollection` に追加できます。

コレクションを作成した後、プレゼンテーションの `FontsManager` の `set_FontFallBackRulesCollection` メソッドを使用して割り当てることができます。`FontsManager` はプレゼンテーション全体のフォントを制御し、各 `Presentation` インスタンスは独自の `FontsManager` を持ちます。

`FontsManager` がフォールバックフォントコレクションで初期化されると、指定されたフォールバックフォントがプレゼンテーションのレンダリング中に適用されます。

## **フォールバック規則の適用**

[FontFallBackRule](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrule/) クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrulescollection/) に整理でき、[IFontFallBackRulesCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontfallbackrulescollection/) インターフェイスを実装します。コレクションから規則を追加または削除することが可能です。

その後、このコレクションは [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) メソッドに渡すことができ、[FontsManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontsmanager/) クラスで使用されます。FontsManager はプレゼンテーション全体のフォントを制御します。

各 [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) は、独自の FontsManager インスタンスを返す [get_FontsManager()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_fontsmanager/) メソッドを持ちます。

以下は、特定のプレゼンテーションの FontsManager にフォールバックフォント規則コレクションを作成して割り当てる例です：

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

FontsManager がフォールバックフォントコレクションで初期化されると、プレゼンテーションのレンダリング中にフォールバックフォントが適用されます。

{{% alert color="primary" %}} 
詳しくは、[フォールバック フォントでプレゼンテーションをレンダリングする方法](/slides/ja/cpp/render-presentation-with-fallback-font/) をご覧ください。
{{% /alert %}}

## **よくある質問**

**フォールバック規則は PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック規則は実行時のレンダリング設定であり、PPTX にシリアライズされず、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のテキストにも同じグリフ置換機構が使用されます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントはご自身で追加・使用していただき、自己責任となります。

**欠落フォントの置換/サブスティテューションと、欠落グリフのフォールバックは併用できますか？**

はい。これらは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの有無を解決し（[replacement](/slides/ja/cpp/font-replacement/)/[substitution](/slides/ja/cpp/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠落グリフを埋めます。