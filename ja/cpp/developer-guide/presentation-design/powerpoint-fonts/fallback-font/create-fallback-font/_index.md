---
title: C++ のプレゼンテーションでフォールバック フォントを指定する
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ をマスターし、PPT、PPTX、ODP ファイルでフォールバック フォントを設定して、あらゆるデバイスや OS でテキストが一貫して表示されるように保護します。"
---
## **概要**

Aspose.Slides を使用すると、プレゼンテーションのレンダリングおよびエクスポート操作にフォールバック フォントを指定できます。フォールバック フォントは、プライマリ フォントに特定の文字のグリフが含まれていない場合に使用されます。

フォールバックの動作はフォールバック ルールを通じて構成されます。各ルールは Unicode 範囲と、必要なグリフを含む可能性のある 1 つ以上のフォントを関連付けます。さまざまな文字範囲に対してルールを定義したり、既存のルールからフォールバック フォントを追加または削除したり、複数のルールをフォールバック フォント ルール コレクションに整理したりできます。

フォールバック ルールは実行時のレンダリング設定です。プレゼンテーション ファイル自体は変更されず、PPTX ファイル内に保存されません。

## **フォールバック ルール**

Aspose.Slides は、フォールバック フォントを適用するルールを指定するために、[IFontFallBackRule](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontfallbackrule/) インターフェイスと [FontFallBackRule](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrule/) クラスをサポートします。[FontFallBackRule](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrule/) クラスは、検索対象となる欠落したグリフのために使用される指定された Unicode 範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連を表します：

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// 複数の方法でフォントリストを追加できます。
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

既存の [FontFallBackRule](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrule/) オブジェクトに対して、フォールバック フォントを [Remove()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontfallbackrule/remove/) したり、[AddFallBackFonts()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) を追加したりすることも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrulescollection/) は、複数の Unicode 範囲に対するフォールバック フォント置換ルールを指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrule/) オブジェクトのリストを整理するために使用できます。

{{% alert color="info" title="その他" %}} 
- [フォールバック フォント コレクションの作成](/slides/ja/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **よくある質問**

### フォールバック フォント、フォント置換、フォント埋め込みの違いは何ですか？

フォールバック フォントは、プライマリ フォントに存在しない文字に対してのみ使用されます。[Font substitution](/slides/ja/cpp/font-substitution/) は、指定されたフォント全体を別のフォントに置き換えます。[Font embedding](/slides/ja/cpp/embedded-font/) は、フォントを出力ファイルにパッケージ化し、受信者が意図した通りにテキストを表示できるようにします。

### PDF、PNG、SVG などへのエクスポート時にもフォールバック フォントは適用されますか、それとも画面表示時のみですか？

はい。フォールバックは、文字を描画する必要があるが元のフォントに存在しない場合に発生するすべての [rendering and export operations](/slides/ja/cpp/convert-presentation/) に影響します。

### フォールバックを設定するとプレゼンテーション ファイル自体が変更されますか？設定は次回以降の開封時にも保持されますか？

いいえ。フォールバック ルールはコード内の実行時レンダリング設定であり、.pptx に保存されないため、PowerPoint で開いても表示されません。

### OS（Windows / Linux / macOS）やフォント ディレクトリの設定はフォールバック の選択に影響しますか？

はい。エンジンは利用可能なシステム フォルダーおよび指定した [additional paths](/slides/ja/cpp/custom-font/) からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは効果を発揮しません。

### フォールバックは WordArt、SmartArt、チャートでも機能しますか？

はい。これらのオブジェクトにテキストが含まれる場合、同じグリフ置換メカニズムが適用され、欠落した文字が正しく描画されます。