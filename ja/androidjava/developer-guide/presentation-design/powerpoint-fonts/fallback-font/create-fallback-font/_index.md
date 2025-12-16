---
title: Android のプレゼンテーション用フォールバック フォントの指定
linktitle: フォールバック フォント
type: docs
weight: 10
url: /ja/androidjava/create-fallback-font/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォントの適用
- フォントの置換
- Unicode 範囲
- 欠損グリフ
- 適切なグリフ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides をマスターし、PPT、PPTX、ODP ファイルでフォールバック フォントを設定して、あらゆるデバイスや OS で一貫したテキスト表示を保護します。"
---

## **フォールバック ルール**

Aspose.Slides は、フォールバック フォントを適用するためのルールを指定するために、[IFontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRule) インターフェイスと[FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) クラスをサポートしています。[FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) クラスは、見つからないグリフの検索に使用される指定された Unicode 範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連付けを表します：

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//さまざまな方法でフォントのリストを追加できます:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


既存の[FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule)オブジェクトに、フォールバック フォントを[remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-)したり、[addFallBackFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-)を追加したりすることも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) は、複数の Unicode 範囲に対してフォールバック フォントの置換ルールを指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) オブジェクトのリストを整理するために使用できます。

{{% alert color="primary" title="参照" %}} 
- [フォールバック フォント コレクションの作成](/slides/ja/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **よくある質問**

**フォールバック フォント、フォント置換、およびフォント埋め込みの違いは何ですか？**

フォールバック フォントは、プライマリ フォントに存在しない文字にのみ使用されます。[Font substitution](/slides/ja/androidjava/font-substitution/) は、指定されたフォント全体を別のフォントに置き換えます。[Font embedding](/slides/ja/androidjava/embedded-font/) は、フォントを出力ファイルにパッケージ化し、受信者が意図した通りにテキストを表示できるようにします。

**フォールバック フォントは、PDF、PNG、SVG などへのエクスポート時にも適用されますか、それとも画面表示時のみですか？**

はい。フォールバックは、文字を描画する必要があるが元のフォントに存在しない場合のすべての[レンダリングおよびエクスポート操作](/slides/ja/androidjava/convert-presentation/)に影響します。

**フォールバックの設定はプレゼンテーション ファイル自体を変更しますか、また設定は将来の開封時にも保持されますか？**

いいえ。フォールバック ルールはコード内の実行時レンダリング設定であり、.pptx に保存されず、PowerPoint でも表示されません。

**オペレーティングシステム（Windows/Linux/macOS）やフォント ディレクトリのセットは、フォールバックの選択に影響しますか？**

はい。エンジンは利用可能なシステム フォルダーと、指定した[追加パス](/slides/ja/androidjava/custom-font/)からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは機能しません。

**フォールバックは WordArt、SmartArt、チャートでも機能しますか？**

はい。これらのオブジェクトにテキストが含まれる場合、同じグリフ置換メカニズムが適用され、欠落した文字がレンダリングされます。