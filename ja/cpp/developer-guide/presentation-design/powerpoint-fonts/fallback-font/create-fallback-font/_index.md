---
title: "C++ でプレゼンテーションのフォールバック フォントを指定する"
linktitle: "フォールバック フォント"
type: docs
weight: 10
url: /ja/cpp/create-fallback-font/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォントの適用
- フォントの置換
- Unicode 範囲
- 欠落グリフ
- 適切なグリフ
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ 用 Aspose.Slides をマスターし、PPT、PPTX、ODP ファイルでフォールバック フォントを設定して、あらゆるデバイスや OS で一貫したテキスト表示を保護します。"
---
## **概要**

Aspose.Slidesでは、プレゼンテーションのレンダリングおよびエクスポート操作のためにフォールバック フォントを指定できます。フォールバック フォントは、プライマリ フォントに特定の文字のグリフが含まれていない場合に使用されます。

フォールバックの動作はフォールバック ルールで構成されます。各ルールは Unicode 範囲と、必要なグリフを含む可能性のある 1 つまたは複数のフォントを関連付けます。さまざまな文字範囲に対してルールを定義したり、既存のルールからフォールバック フォントを追加または削除したり、複数のルールをフォールバック フォント ルール コレクションに整理したりできます。

フォールバック ルールは実行時のレンダリング設定です。プレゼンテーション ファイル自体は変更されず、PPTX ファイル内に保存されません。

## **フォールバック ルール**

Aspose.Slidesは[IFontFallBackRule](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontfallbackrule/) インターフェイスと [FontFallBackRule](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrule/) クラスをサポートし、フォールバック フォントを適用するルールを指定できます。[FontFallBackRule](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrule/) クラスは、見つからなかったグリフの検索に使用される指定された Unicode 範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連を表します:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// 複数の方法でフォントリストを追加できます:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

既存の [FontFallBackRule](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrule/) オブジェクトに対して、[Remove()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontfallbackrule/remove/) でフォールバック フォントを削除したり、[AddFallBackFonts()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) でフォールバック フォントを追加したりすることも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrulescollection/) は、複数の Unicode 範囲に対してフォールバック フォント置換ルールを指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontfallbackrule/) オブジェクトのリストを整理するために使用できます。

{{% alert color="primary" title="その他も参照" %}} 
- [フォールバック フォント コレクションの作成](/slides/ja/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **よくある質問**

**フォールバック フォント、フォント置換、フォント埋め込みの違いは何ですか？**

フォールバック フォントはプライマリ フォントに存在しない文字に対してのみ使用されます。[フォント置換](/slides/ja/cpp/font-substitution/) は指定されたフォント全体を別のフォントに置き換えます。[フォント埋め込み](/slides/ja/cpp/embedded-font/) はフォントを出力ファイルにパッケージ化し、受信者が意図したとおりにテキストを表示できるようにします。

**フォールバックは PDF、PNG、SVG などへのエクスポート時にも適用されますか、画面表示時だけですか？**

はい。フォールバックは文字を描画する必要があるが元のフォントに存在しない場合のすべての[レンダリングおよびエクスポート操作](/slides/ja/cpp/convert-presentation/) に影響します。

**フォールバックの設定はプレゼンテーション ファイル自体を変更しますか、将来の開く際に設定は保持されますか？**

いいえ。フォールバック ルールはコード内の実行時レンダリング設定であり、.pptx 内に保存されず、PowerPoint には表示されません。

**オペレーティング システム（Windows/Linux/macOS）やフォント ディレクトリの設定はフォールバックの選択に影響しますか？**

はい。エンジンは利用可能なシステム フォルダーと、提供した[追加パス](/slides/ja/cpp/custom-font/)からフォントを解決します。フォントが物理的に存在しない場合、そのフォントを参照するルールは効果を発揮できません。

**フォールバックは WordArt、SmartArt、チャートでも機能しますか？**

はい。これらのオブジェクトにテキストが含まれる場合、同じグリフ置換メカニズムが適用され、欠落文字がレンダリングされます。