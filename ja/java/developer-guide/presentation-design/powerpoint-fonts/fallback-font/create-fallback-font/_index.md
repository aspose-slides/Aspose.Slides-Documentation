---
title: Java でプレゼンテーション用フォールバック フォントを指定する
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
- 見つからないグリフ
- 正しいグリフ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java をマスターし、PPT、PPTX、ODP ファイルでフォールバック フォントを設定して、あらゆるデバイスや OS でテキスト表示の一貫性を確保します。"
---
## **概要**

Aspose.Slides を使用すると、プレゼンテーションのレンダリングおよびエクスポート操作にフォールバック フォントを指定できます。フォールバック フォントは、プライマリ フォントに特定の文字のグリフが含まれていない場合に使用されます。

フォールバックの動作はフォールバック ルールによって構成されます。各ルールは Unicode 範囲と、必要なグリフを含む可能性のある 1 つ以上のフォントを関連付けます。異なる文字範囲に対してルールを定義したり、既存のルールからフォールバック フォントを追加または削除したり、複数のルールをフォールバック フォント ルール コレクションに整理したりできます。

フォールバック ルールは実行時のレンダリング設定です。プレゼンテーション ファイル自体を変更せず、PPTX ファイル内に保存されることもありません。

## **フォールバック ルール**

Aspose.Slides は [IFontFallBackRule](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IFontFallBackRule) インターフェイスと [FontFallBackRule](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontFallBackRule) クラスをサポートし、フォールバック フォントを適用するルールを指定できます。 [FontFallBackRule](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontFallBackRule) クラスは、見つからなかったグリフの検索に使用する指定された Unicode 範囲と、適切なグリフを含む可能性のあるフォントのリストとの関連を表します。

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

既存の [FontFallBackRule](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontFallBackRule) オブジェクトに対して、[remove](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) でフォールバック フォントを削除したり、[addFallBackFonts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) でフォールバック フォントを追加したりすることも可能です。

複数の Unicode 範囲に対してフォールバック フォント置換ルールを指定する必要がある場合は、[FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontFallBackRulesCollection) を使用して [FontFallBackRule](https://reference.aspose.com/slides/ja/java/com.aspose.slides/FontFallBackRule) オブジェクトのリストを整理できます。

{{% alert color="info" title="参考" %}} 
- [フォールバック フォント コレクションの作成](/slides/ja/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### フォールバック フォント、フォント置換、フォント埋め込みの違いは何ですか？

フォールバック フォントはプライマリ フォントに存在しない文字に対してのみ使用されます。[フォント置換](/slides/ja/java/font-substitution/) は指定されたフォント全体を別のフォントに置き換えます。[フォント埋め込み](/slides/ja/java/embedded-font/) はフォントを出力ファイルにパッケージ化し、受信者が意図通りにテキストを表示できるようにします。

### PDF、PNG、SVG などへのエクスポート時にもフォールバック フォントは適用されますか？それとも画面上のレンダリングだけですか？

はい。フォールバックは文字がソース フォントに存在しない場合に描画が必要となるすべての [レンダリングおよびエクスポート操作](/slides/ja/java/convert-presentation/) に影響します。

### フォールバックを設定するとプレゼンテーション ファイル自体が変更されますか？設定は次回の開封時にも保持されますか？

いいえ。フォールバック ルールはコード内の実行時レンダリング設定であり、.pptx に保存されず、PowerPoint でも表示されません。

### オペレーティング システム（Windows / Linux / macOS）やフォント ディレクトリのセットはフォールバック選択に影響しますか？

はい。エンジンは利用可能なシステム フォルダーと、ユーザーが提供した [追加パス](/slides/ja/java/custom-font/) からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは効果を発揮できません。

### フォールバックは WordArt、SmartArt、チャートでも機能しますか？

はい。これらのオブジェクトにテキストが含まれる場合、同じグリフ置換メカニズムが適用され、欠落文字が描画されます。