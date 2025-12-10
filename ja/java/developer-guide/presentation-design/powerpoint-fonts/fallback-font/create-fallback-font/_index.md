---
title: Javaでプレゼンテーションのフォールバック フォントを指定する
linktitle: フォールバック フォント
type: docs
weight: 10
url: /ja/java/create-fallback-font/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォントの適用
- フォントの置換
- Unicode 範囲
- 欠損グリフ
- 正しいグリフ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java をマスターし、PPT、PPTX、ODP ファイルでフォールバック フォントを設定して、あらゆるデバイスや OS でテキスト表示の一貫性を確保します。"
---

## **フォールバック ルール**

Aspose.Slides は、[IFontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRule) インターフェイスと[FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) クラスをサポートし、フォールバック フォントを適用するルールを指定できます。[FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) クラスは、検索対象となる欠損グリフ用の Unicode 範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連を表します：
```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


既存の[FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) オブジェクトに対して、フォールバック フォントを[remove](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-)したり、[addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) を追加したりすることも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) は、複数の Unicode 範囲に対してフォールバック フォント置換ルールを指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) オブジェクトのリストを整理するために使用できます。

{{% alert color="primary" title="参照" %}} 
- [フォールバック フォント コレクションの作成](/slides/ja/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **よくある質問**

**フォールバック フォント、フォント置換、フォント埋め込みの違いは何ですか？**

フォールバック フォントは、プライマリ フォントに存在しない文字に対してのみ使用されます。[Font substitution](/slides/ja/java/font-substitution/) は、指定されたフォント全体を別のフォントに置き換えます。[Font embedding](/slides/ja/java/embedded-font/) は、フォントを出力ファイルにパッケージ化し、受信者が意図した通りにテキストを表示できるようにします。

**フォールバック フォントは PDF、PNG、SVG などへのエクスポート時にも適用されますか、それとも画面表示時のみですか？**

はい。フォールバックは、文字を描画する必要があるが元のフォントに存在しない場合のすべての[レンダリングおよびエクスポート操作](/slides/ja/java/convert-presentation/)に影響します。

**フォールバックを設定するとプレゼンテーション ファイル自体が変更されますか？また、設定は次回以降の開封時にも保持されますか？**

いいえ。フォールバック ルールはコード内の実行時レンダリング設定であり、.pptx に保存されず、PowerPoint には表示されません。

**オペレーティングシステム（Windows/Linux/macOS）やフォント ディレクトリの構成は、フォールバックの選択に影響しますか？**

はい。エンジンは利用可能なシステム フォルダと、提供された[追加パス](/slides/ja/java/custom-font/)からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは効果を発揮できません。

**フォールバックは WordArt、SmartArt、チャートでも機能しますか？**

はい。これらのオブジェクトにテキストが含まれる場合、同じグリフ置換メカニズムが適用され、欠損文字が描画されます。