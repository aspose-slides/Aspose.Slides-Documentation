---
title: C++ のプレゼンテーションでフォールバック フォントを指定
linktitle: フォールバック フォント
type: docs
weight: 10
url: /ja/cpp/create-fallback-font/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォントの適用
- フォントの置換
- Unicode 範囲
- 欠落したグリフ
- 適切なグリフ
- PowerPoint
- OpenDocument
- プレゼンテーション
- С++
- Aspose.Slides
description: "C++ 用 Aspose.Slides をマスターし、PPT、PPTX、ODP ファイルでフォールバック フォントを設定して、あらゆるデバイスや OS でテキスト表示の一貫性を保護します。"
---

## **フォールバック ルール**

Aspose.Slides はフォールバック フォントを適用するためのルールを指定するために、[IFontFallBackRule] インターフェイスと[FontFallBackRule] クラスをサポートしています。[FontFallBackRule] クラスは、欠落したグリフを検索するために使用される特定の Unicode 範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連付けを表します：
``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// 複数の方法でフォントリストを追加できます:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```




既存の[FontFallBackRule] オブジェクトに対して、[Remove()] でフォールバック フォントを削除したり、[AddFallBackFonts()] でフォールバック フォントを追加したりすることも可能です。

[FontFallBackRulesCollection] は、複数の Unicode 範囲に対するフォールバック フォント置換ルールを指定する必要がある場合に、[FontFallBackRule] オブジェクトのリストを整理するために使用できます。

{{% alert color="primary" title="See also" %}} 
- [フォールバック フォント コレクションの作成](/slides/ja/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **よくある質問**

**フォールバック フォント、フォント置換、およびフォント埋め込みの違いは何ですか？**

フォールバック フォントは、プライマリ フォントに存在しない文字に対してのみ使用されます。[Font substitution](/slides/ja/cpp/font-substitution/) は指定されたフォント全体を別のフォントに置き換えます。[Font embedding](/slides/ja/cpp/embedded-font/) はフォントを出力ファイル内にパッケージ化し、受信者が意図した通りにテキストを表示できるようにします。

**フォールバック フォントは PDF、PNG、SVG などへのエクスポート時にも適用されますか、それとも画面上のレンダリングのみですか？**

はい。フォールバックは、文字を描画する必要があるが元のフォントに存在しない場合のすべての[rendering and export operations](/slides/ja/cpp/convert-presentation/)に影響します。

**フォールバックの設定はプレゼンテーション ファイル自体を変更しますか、また設定は次回開くときにも保持されますか？**

いいえ。フォールバック ルールはコード内の実行時レンダリング設定であり、.pptx ファイルに保存されず、PowerPoint には表示されません。

**オペレーティングシステム（Windows/Linux/macOS）やフォント ディレクトリの構成は、フォールバックの選択に影響しますか？**

はい。エンジンは利用可能なシステム フォルダーや、提供された[additional paths](/slides/ja/cpp/custom-font/)からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは適用されません。

**フォールバックは WordArt、SmartArt、およびチャートでも機能しますか？**

はい。これらのオブジェクトにテキストが含まれる場合、同じグリフ置換メカニズムが適用され、欠落した文字がレンダリングされます。