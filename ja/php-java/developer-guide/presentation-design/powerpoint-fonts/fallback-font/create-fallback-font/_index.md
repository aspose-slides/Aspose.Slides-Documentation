---
title: PHP でプレゼンテーションのフォールバック フォントを指定する
linktitle: フォールバック フォント
type: docs
weight: 10
url: /ja/php-java/create-fallback-font/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォントを適用
- フォントの置換
- Unicode 範囲
- 欠損グリフ
- 適切なグリフ
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides をマスターし、PPT、PPTX、ODP ファイルにフォールバック フォントを設定して、あらゆるデバイスや OS でテキスト表示の一貫性を保護します。"
---

## **フォールバック ルール**

Aspose.Slides は [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) クラスをサポートし、フォールバック フォントを適用するルールを指定できます。[FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) クラスは、見つからないグリフの検索に使用される指定された Unicode 範囲と、適切なグリフを含む可能性のあるフォントの一覧との関連付けを表します：
```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # 複数の方法でフォントリストを追加できます:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```


既存の [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) オブジェクトからフォールバック フォントを [remove](https://reference.aspose.com/slides/php-java/aspose.slides/fontfallbackrule/remove/) したり、 [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) を追加したりすることも可能です。

複数の Unicode 範囲に対してフォールバック フォント置換ルールを指定する必要がある場合は、[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) を使用して [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) オブジェクトの一覧を整理できます。

{{% alert color="primary" title="参照" %}} 
- [フォールバック フォント コレクションの作成](/slides/ja/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**フォールバック フォント、フォント置換、フォント埋め込みの違いは何ですか？**

フォールバック フォントは、プライマリ フォントに存在しない文字に対してのみ使用されます。[Font substitution](/slides/ja/php-java/font-substitution/) は指定されたフォント全体を別のフォントに置き換えます。[Font embedding](/slides/ja/php-java/embedded-font/) はフォントを出力ファイルにパッケージ化し、受信者が意図どおりにテキストを表示できるようにします。

**PDF、PNG、SVG などのエクスポート時にもフォールバックは適用されますか、それとも画面表示時のみですか？**

はい。フォールバックは、文字を描画する必要があるが元のフォントに存在しない場合のすべての [rendering and export operations](/slides/ja/php-java/convert-presentation/) に影響します。

**フォールバックの設定はプレゼンテーション ファイル自体を変更しますか？設定は将来のオープン時にも保持されますか？**

いいえ。フォールバック ルールはコード内の実行時レンダリング設定であり、.pptx ファイルに保存されないため、PowerPoint には表示されません。

**オペレーティング システム（Windows/Linux/macOS）やフォント ディレクトリの構成はフォールバック選択に影響しますか？**

はい。エンジンは利用可能なシステム フォルダーと、指定した [additional paths](/slides/ja/php-java/custom-font/) からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは機能しません。

**フォールバックは WordArt、SmartArt、チャートでも機能しますか？**

はい。これらのオブジェクトにテキストが含まれる場合、同じグリフ置換メカニズムが欠けている文字のレンダリングに適用されます。