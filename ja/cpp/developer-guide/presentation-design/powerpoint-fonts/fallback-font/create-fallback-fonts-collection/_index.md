---
title: C++ でフォールバックフォントコレクションを構成
linktitle: フォールバックフォントコレクション
type: docs
weight: 20
url: /ja/cpp/create-fallback-fonts-collection/
keywords:
- フォールバックフォント
- フォールバック規則
- フォントコレクション
- フォントを構成
- フォントの設定
- PowerPoint
- OpenDocument
- プレゼンテーション
- С++
- Aspose.Slides
description: "Aspose.Slides for C++ でフォールバックフォントコレクションを設定し、PowerPoint および OpenDocument プレゼンテーションでテキストを一貫して鮮明に保ちます。"
---

## **フォールバック規則を適用**

[FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection) に整理できます。このコレクションは [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rules_collection) インターフェイスを実装しています。コレクションへの規則の追加や削除が可能です。

その後、このコレクションは [FontsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager) クラスの [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924) メソッドに渡すことができます。FontsManager はプレゼンテーション全体のフォントを制御します。詳しくは [FontsManager と FontsLoader について](/slides/ja/cpp/about-fontsmanager-and-fontsloader/) をご覧ください。

各 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) には、独自の FontsManager インスタンスを取得できる [get_FontsManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#acee582a9c243cbd63e30634c9714514a) メソッドがあります。

以下はフォールバックフォント規則コレクションを作成し、特定のプレゼンテーションの FontsManager に割り当てる例です：  
``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```


FontsManager がフォールバックフォントコレクションで初期化されると、プレゼンテーションのレンダリング中にフォールバックフォントが適用されます。

{{% alert color="primary" %}} 
[フォールバックフォントでプレゼンテーションをレンダリングする](/slides/ja/cpp/render-presentation-with-fallback-font/) 方法の詳細をご覧ください。
{{% /alert %}}

## **FAQ**

**フォールバック規則は PPTX ファイルに埋め込まれ、保存後に PowerPoint で表示されますか？**

いいえ。フォールバック規則は実行時のレンダリング設定であり、PPTX にシリアライズされないため、PowerPoint の UI には表示されません。

**SmartArt、WordArt、チャート、テーブル内のテキストにもフォールバックは適用されますか？**

はい。これらのオブジェクト内のテキストにも同じグリフ置換メカニズムが使用されます。

**Aspose はライブラリと共にフォントを配布していますか？**

いいえ。フォントはご自身で追加・使用していただき、責任は利用者にあります。

**欠落フォントの置換/置換と欠落グリフのフォールバックは同時に使用できますか？**

はい。これらは同じフォント解決パイプラインの独立した段階です。まずエンジンがフォントの可用性を解決し（[置換](/slides/ja/cpp/font-replacement/)/[置換](/slides/ja/cpp/font-substitution/)）、次にフォールバックが利用可能なフォント内の欠落グリフを補填します。