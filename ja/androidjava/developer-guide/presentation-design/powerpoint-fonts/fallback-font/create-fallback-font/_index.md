---
title: Android でプレゼンテーション用フォールバック フォントを指定する
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
description: "Java を使用して Android 用 Aspose.Slides をマスターし、PPT、PPTX、ODP ファイルでフォールバック フォントを設定して、あらゆるデバイスや OS でテキスト表示の一貫性を保護します。"
---
## **概要**

Aspose.Slides では、プレゼンテーションのレンダリングおよびエクスポート操作にフォールバック フォントを指定できます。フォールバック フォントは、プライマリ フォントに特定の文字のグリフが含まれていない場合に使用されます。

フォールバックの動作はフォールバック ルールで構成します。各ルールは Unicode 範囲と、必要なグリフを含む可能性のある 1 つ以上のフォントを関連付けます。さまざまな文字範囲に対してルールを定義したり、既存のルールからフォールバック フォントを追加・削除したり、複数のルールをフォールバック フォント ルール コレクションに整理できます。

フォールバック ルールは実行時のレンダリング設定です。プレゼンテーション ファイル自体は変更せず、PPTX ファイル内に保存されません。

## **フォールバック ルール**

Aspose.Slides は、フォールバック フォントを適用するルールを指定するために、[IFontFallBackRule](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IFontFallBackRule) インターフェイスと [FontFallBackRule](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontFallBackRule) クラスをサポートしています。[FontFallBackRule] クラスは、欠損したグリフの検索に使用される指定された Unicode 範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連を表します：

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//複数の方法でフォントリストを追加できます:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

既存の [FontFallBackRule](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontFallBackRule) オブジェクトに対して、フォールバック フォントを [remove](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) したり、[addFallBackFonts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) を追加したりすることも可能です。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontFallBackRulesCollection) は、複数の Unicode 範囲に対してフォールバック フォント置換ルールを指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FontFallBackRule) オブジェクトのリストを整理するために使用できます。

{{% alert color="info" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/ja/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### フォールバック フォント、フォント置換、フォント埋め込みの違いは何ですか？

フォールバック フォントは、プライマリ フォントに欠けている文字に対してのみ使用されます。[フォント置換](/slides/ja/androidjava/font-substitution/) は、指定されたフォント全体を別のフォントに置き換えます。[フォント埋め込み](/slides/ja/androidjava/embedded-font/) は、フォントを出力ファイル内にパッケージ化し、受信者が意図した通りにテキストを表示できるようにします。

### PDF、PNG、SVG などのエクスポート時にもフォールバック フォントが適用されますか、それとも画面上のレンダリング時だけですか？

はい。フォールバックは、文字を描画する必要があるがソース フォントに存在しない場合の、すべての[レンダリングおよびエクスポート操作](/slides/ja/androidjava/convert-presentation/)に影響します。

### フォールバックの設定はプレゼンテーション ファイル自体を変更しますか、また設定は次回開くときにも保持されますか？

いいえ。フォールバック ルールはコード内の実行時レンダリング設定であり、.pptx 内に保存されず、PowerPoint でも表示されません。

### オペレーティングシステム（Windows／Linux／macOS）やフォント ディレクトリの設定は、フォールバックの選択に影響しますか？

はい。エンジンは利用可能なシステム フォルダーおよび提供された[追加パス](/slides/ja/androidjava/custom-font/)からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは適用されません。

### WordArt、SmartArt、チャートでもフォールバックは機能しますか？

はい。これらのオブジェクトにテキストが含まれている場合、同じグリフ置換メカニズムが適用され、欠損文字を描画します。