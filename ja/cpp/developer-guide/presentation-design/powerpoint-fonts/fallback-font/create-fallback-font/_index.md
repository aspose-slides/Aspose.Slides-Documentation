---
title: C++でプレゼンテーション用フォールバックフォントを指定
linktitle: フォールバックフォント
type: docs
weight: 10
url: /ja/cpp/create-fallback-font/
keywords:
- フォールバックフォント
- フォールバックルール
- フォント適用
- フォント置換
- Unicode 範囲
- 欠損グリフ
- 適切なグリフ
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ 用 Aspose.Slides をマスターし、PPT、PPTX、ODP ファイルでフォールバックフォントを設定して、あらゆるデバイスや OS でテキスト表示の一貫性を確保します。"
---

## **フォールバック ルール**

Aspose.Slides は、フォールバックフォントを適用するルールを指定するために、[IFontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule) インターフェイスと [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) クラスをサポートします。[FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) クラスは、検索対象となる欠損グリフ用の指定された Unicode 範囲と、適切なグリフを含む可能性のあるフォントの一覧との関連付けを表します:
``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```


既存の [FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) オブジェクトに対して、フォールバックフォントを [Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#abd87e889a55b4a62174ddd14f1b1476e) したり、[AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_font_fall_back_rule#a9bac44ca199a76c6cd004146cb02cd79) を追加したりすることも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rules_collection) は、複数の Unicode 範囲に対してフォールバックフォント置換ルールを指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule) オブジェクトのリストを整理するために使用できます。

{{% alert color="primary" title="See also" %}} 
- [フォールバック フォント コレクションの作成](/slides/ja/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **よくある質問**

**フォールバック フォント、フォント置換、およびフォント埋め込みの違いは何ですか？**

フォールバックフォントは、プライマリフォントに存在しない文字に対してのみ使用されます。[フォント置換](/slides/ja/cpp/font-substitution/) は、指定されたフォント全体を別のフォントに置き換えます。[フォント埋め込み](/slides/ja/cpp/embedded-font/) は、フォントを出力ファイルにパッケージ化し、受信者が意図した通りにテキストを表示できるようにします。

**エクスポート（PDF、PNG、SVG など）時にフォールバックフォントが適用されますか、それとも画面上のレンダリング時のみですか？**

はい。フォールバックは、文字を描画する必要があるがソースフォントに存在しない場合のすべての[レンダリングおよびエクスポート操作](/slides/ja/cpp/convert-presentation/)に影響します。

**フォールバックの設定はプレゼンテーションファイル自体を変更し、将来の開く際に設定が保持されますか？**

いいえ。フォールバックルールはコード内の実行時レンダリング設定であり、.pptx に保存されず、PowerPoint には表示されません。

**オペレーティングシステム（Windows/Linux/macOS）やフォントディレクトリのセットは、フォールバックの選択に影響しますか？**

はい。エンジンは利用可能なシステムフォルダーや、提供した任意の[追加パス](/slides/ja/cpp/custom-font/)からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは効果を発揮できません。

**フォールバックは WordArt、SmartArt、チャートでも機能しますか？**

はい。これらのオブジェクトにテキストが含まれる場合、同じグリフ置換メカニズムが適用され、欠損文字がレンダリングされます。