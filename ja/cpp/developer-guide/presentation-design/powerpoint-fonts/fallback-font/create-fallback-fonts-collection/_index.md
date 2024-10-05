---
title: フォールバックフォントコレクションの作成
type: docs
weight: 20
url: /cpp/create-fallback-fonts-collection/
---

[FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule)クラスのインスタンスは、[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection)に整理することができ、これは[IFontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rules_collection)インターフェイスを実装しています。コレクションからルールを追加または削除することが可能です。

次に、このコレクションは[FontsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager)クラスの[set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924)メソッドに渡すことができます。FontsManagerはプレゼンテーション全体のフォントを管理します。[About FontsManager and FontsLoader](/slides/cpp/about-fontsmanager-and-fontsloader/)について詳しく読むことができます。

各[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)は独自のFontsManagerクラスのインスタンスを持つ[get_FontsManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#acee582a9c243cbd63e30634c9714514a)メソッドがあります。

以下は、フォールバックフォントルールコレクションを作成し、特定のプレゼンテーションのFontsManagerに割り当てる方法の例です：

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

FontsManagerがフォールバックフォントコレクションで初期化されると、プレゼンテーションのレンダリング中にフォールバックフォントが適用されます。

{{% alert color="primary" %}} 
フォールバックフォントで[プレゼンテーションをレンダリングする方法](/slides/cpp/render-presentation-with-fallback-font/)についてさらに読むことができます。
{{% /alert %}}