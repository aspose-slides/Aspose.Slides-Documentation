---
title: ".NET でプレゼンテーションのフォールバック フォントを指定する"
linktitle: "フォールバック フォント"
type: docs
weight: 10
url: /ja/net/create-fallback-font/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET をマスターし、PPT、PPTX、ODP ファイルでフォールバック フォントを設定して、あらゆるデバイスや OS で一貫したテキスト表示を保護します。"
---

## **フォールバック ルール**

Aspose.Slides は [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) インターフェイスと [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) クラスをサポートし、フォールバック フォントを適用するルールを指定できます。 [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) クラスは、見つからないグリフの検索に使用される特定の Unicode 範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連を表します:
```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//複数の方法でフォントリストを追加できます:
string[] fontNames = new string[] { "Segoe UI Emoji, Seguge UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


既存の [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) オブジェクトに対して、フォールバック フォントを [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) したり、[AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) を追加したりすることも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) は、複数の Unicode 範囲に対してフォールバック フォント置換ルールを指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) オブジェクトのリストを整理するために使用できます。

{{% alert color="primary" title="こちらも参照" %}} 
- [フォールバック フォント コレクションの作成](/slides/ja/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **よくある質問**

**フォールバック フォント、フォント置換、フォント埋め込みの違いは何ですか？**

フォールバック フォントは、プライマリ フォントに存在しない文字に対してのみ使用されます。[フォント置換](/slides/ja/net/font-substitution/) は指定したフォント全体を別のフォントに置き換えます。[フォント埋め込み](/slides/ja/net/embedded-font/) はフォントを出力ファイル内部にパッケージ化し、受信者がテキストを意図通りに表示できるようにします。

**フォールバック フォントは PDF、PNG、SVG などへのエクスポート時にも適用されますか、それとも画面表示時のみですか？**

はい。フォールバックは、文字を描画する必要があるが元のフォントに存在しない場合のすべての[レンダリングおよびエクスポート操作](/slides/ja/net/convert-presentation/)に影響します。

**フォールバックの設定はプレゼンテーション ファイル自体を変更しますか、また設定は次回開く際にも保持されますか？**

いいえ。フォールバック ルールはコード内の実行時レンダリング設定であり、.pptx ファイル内に保存されず、PowerPoint には表示されません。

**オペレーティングシステム（Windows/Linux/macOS）やフォント ディレクトリの設定はフォールバックの選択に影響しますか？**

はい。エンジンは利用可能なシステム フォルダーおよび提供された[追加パス](/slides/ja/net/custom-font/)からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは効果を発揮できません。

**フォールバックは WordArt、SmartArt、チャートでも機能しますか？**

はい。これらのオブジェクトにテキストが含まれる場合、欠落した文字を描画するために同じグリフ置換メカニズムが適用されます。