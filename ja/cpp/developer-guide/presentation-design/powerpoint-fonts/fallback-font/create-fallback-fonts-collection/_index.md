---
title: C++でフォールバックフォントコレクションを構成する
linktitle: フォールバックフォントコレクション
type: docs
weight: 20
url: /ja/cpp/create-fallback-fonts-collection/
keywords:
- フォールバックフォント
- フォールバックルール
- フォントコレクション
- フォントの構成
- フォントの設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションでテキストを一貫して鮮明に保つために、C++ 用 Aspose.Slides でフォールバックフォントコレクションを設定します。"
---

## **フォールバック ルールを適用する**

[FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrulescollection/) に編成でき、[IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrulescollection/) インターフェイスを実装します。コレクションからルールを追加または削除することが可能です。

このコレクションは、[set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) メソッドに[FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) クラスへ渡すことができます。FontsManager はプレゼンテーション全体のフォントを制御します。

各[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) には、[FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) クラスの独自インスタンスを取得する [get_FontsManager()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) メソッドがあります。

以下は、フォールバックフォントルールコレクションを作成し、特定のプレゼンテーションの FontsManager に割り当てる例です：
``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```


FontsManager がフォールバックフォントコレクションで初期化されると、プレゼンテーションのレンダリング中にフォールバックフォントが適用されます。

{{% alert color="primary" %}} 
フォールバックフォントでプレゼンテーションをレンダリングする方法の詳細は、[Render Presentation with Fallback Font](/slides/ja/cpp/render-presentation-with-fallback-font/)をご覧ください。 
{{% /alert %}}

## **よくある質問**

**フォールバックルールは PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバックルールは実行時のレンダリング設定であり、PPTX にシリアライズされないため、PowerPoint の UI には表示されません。

**フォールバックは SmartArt、WordArt、チャート、テーブル内のテキストにも適用されますか？**

はい。これらのオブジェクト内のすべてのテキストに対して、同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリとともにフォントを配布していますか？**

いいえ。フォントはご自身で追加・使用していただき、自己の責任で管理してください。

**欠落したフォントの置換/サブスティテューションと、欠落したグリフに対するフォールバックは同時に使用できますか？**

はい。これらは同じフォント解決パイプラインの独立したステージです。最初にエンジンがフォントの有無を解決し（[replacement](/slides/ja/cpp/font-replacement/)/[substitution](/slides/ja/cpp/font-substitution/)）、その後、フォールバックが利用可能なフォント内の欠落したグリフのギャップを埋めます。