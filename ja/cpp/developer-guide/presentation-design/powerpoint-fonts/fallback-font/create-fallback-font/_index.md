---
title: フォールバックフォントの作成
type: docs
weight: 10
url: /cpp/create-fallback-font/
---

Aspose.Slidesは、フォールバックフォントを適用するためのルールを指定するために、[IFontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule)インターフェースと[FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule)クラスをサポートしています。[FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule)クラスは、欠落しているグリフを検索するために使用される指定されたUnicode範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連を表します：

```cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// 複数の方法を使用してフォントのリストを追加できます：
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

既存の[FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule)オブジェクトに対して、フォールバックフォントを[Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#abd87e889a55b4a62174ddd14f1b1476e)したり、[AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#a9bac44ca199a76c6cd004146cb02cd79)したりすることも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection)は、複数のUnicode範囲に対してフォールバックフォント置換ルールを指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule)オブジェクトのリストを整理するために使用できます。

{{% alert color="primary" title="関連情報" %}} 
- [フォールバックフォントコレクションの作成](/slides/cpp/create-fallback-fonts-collection/)
{{% /alert %}}