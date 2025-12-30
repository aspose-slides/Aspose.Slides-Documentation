---
title: PHPでプレゼンテーションのフォールバックフォントを指定する
linktitle: フォールバックフォント
type: docs
weight: 10
url: /ja/php-java/create-fallback-font/
keywords:
- フォールバックフォント
- フォールバック規則
- フォントの適用
- フォントの置換
- Unicode範囲
- 欠損グリフ
- 適切なグリフ
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java経由でPHP用Aspose.Slidesをマスターし、PPT、PPTX、ODPファイルにフォールバックフォントを設定して、あらゆるデバイスやOSで一貫したテキスト表示を保護します。"
---

## **フォールバックルール**

Aspose.Slides は、フォールバックフォントを適用する規則を指定するために、[IFontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRule) インターフェイスと [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) クラスをサポートします。[FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) クラスは、欠落したグリフの検索に使用される指定された Unicode 範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連を表します：
```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # 複数の方法でフォントリストを追加できます:
  $fontNames = array("Segoe UI Emoji, Segue UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```


既存の [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) オブジェクトに対して、フォールバックフォントを [remove](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) したり、[addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) を追加したりすることも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) は、複数の Unicode 範囲に対してフォールバックフォント置換規則を指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) オブジェクトのリストを整理するために使用できます。

{{% alert color="primary" title="参照" %}} 
- [フォールバックフォントコレクションの作成](/slides/ja/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **よくある質問**

**フォールバックフォント、フォント置換、フォント埋め込みの違いは何ですか？**

フォールバックフォントは、プライマリフォントに存在しない文字に対してのみ使用されます。[Font substitution](/slides/ja/php-java/font-substitution/) は、指定されたフォント全体を別のフォントに置き換えます。[Font embedding](/slides/ja/php-java/embedded-font/) は、フォントを出力ファイル内にパッケージ化し、受信者が意図した通りにテキストを表示できるようにします。

**PDF、PNG、SVG などへのエクスポート時にもフォールバックフォントは適用されますか、それとも画面上のレンダリング時のみですか？**

はい。フォールバックは、文字を描画する必要があるが元のフォントに存在しない場合のすべての [rendering and export operations](/slides/ja/php-java/convert-presentation/) に影響します。

**フォールバックの設定はプレゼンテーションファイル自体を変更し、将来の開封時にも設定が保持されますか？**

いいえ。フォールバック規則はコード内の実行時レンダリング設定であり、.pptx に保存されず、PowerPoint でも表示されません。

**オペレーティングシステム（Windows/Linux/macOS）やフォントディレクトリのセットは、フォールバックの選択に影響しますか？**

はい。エンジンは利用可能なシステムフォルダと、提供した任意の [additional paths](/slides/ja/php-java/custom-font/) からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照する規則は動作しません。

**WordArt、SmartArt、チャートでもフォールバックは機能しますか？**

はい。これらのオブジェクトにテキストが含まれる場合、欠落した文字を描画するために同じグリフ置換メカニズムが適用されます。