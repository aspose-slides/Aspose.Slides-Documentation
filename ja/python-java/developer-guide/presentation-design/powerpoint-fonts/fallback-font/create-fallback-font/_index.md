---
title: Python via Javaでプレゼンテーションのフォールバック フォントを指定
linktitle: フォールバック フォント
type: docs
weight: 10
url: /ja/python-java/create-fallback-font/
keywords:
- フォールバック フォント
- フォールバック ルール
- フォントの適用
- フォントの置換
- Unicode 範囲
- 欠落したグリフ
- 正しいグリフ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python via Java 用 Aspose.Slides をマスターし、PPT、PPTX、ODP ファイルでフォールバック フォントを設定して、あらゆるデバイスや OS でテキスト表示が一貫するように保護します。"
---
## **概要**

Aspose.Slides は、プレゼンテーションのレンダリングおよびエクスポート操作でフォールバック フォントを指定できるようにします。フォールバック フォントは、プライマリ フォントに特定の文字のグリフが含まれていない場合に使用されます。

フォールバックの動作はフォールバック ルールで構成されます。各ルールは Unicode 範囲と、必要なグリフを含む可能性のある 1 つ以上のフォントを関連付けます。異なる文字範囲のルールを定義したり、既存のルールからフォールバック フォントを追加または削除したり、複数のルールをフォールバック フォント ルール コレクションに整理したりできます。

フォールバック ルールは実行時のレンダリング設定です。プレゼンテーション ファイル自体を変更せず、PPTX ファイル内に保存されません。

## **フォールバック ルール**

Aspose.Slides は、フォールバック フォントを適用するためのルールを指定する [FontFallBackRule](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontfallbackrule/) クラスを提供します。このクラスは、欠落したグリフを検索するために使用される Unicode 範囲と、必要なグリフを含む可能性のあるフォントのリストとの関連を表します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# フォントのリストを指定する複数の方法を使用します。
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

既存の [FontFallBackRule](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontfallbackrule/) オブジェクトで、[remove](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontfallbackrule/#remove) を使用してフォールバック フォントを削除したり、[addFallBackFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) を使用してフォールバック フォントを追加したりできます。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontfallbackrulescollection/) は、複数の Unicode 範囲に対してフォールバック フォント置換ルールを指定する必要がある場合に、[FontFallBackRule](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontfallbackrule/) オブジェクトのリストを整理できます。

{{% alert color="info" title="参照" %}} 
- [フォールバック フォント コレクションの作成](/slides/ja/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **よくある質問**

**フォールバック フォント、フォント置換、フォント埋め込みの違いは何ですか？**

フォールバック フォントは、プライマリ フォントに欠けている文字に対してのみ使用されます。[Font substitution](/slides/ja/python-java/font-substitution/) は、指定されたフォント全体を別のフォントに置き換えます。[Font embedding](/slides/ja/python-java/embedded-font/) は、フォントを出力ファイルにパッケージ化し、受信者が意図した通りにテキストを表示できるようにします。

**フォールバック フォントは PDF、PNG、SVG などのエクスポート時に適用されますか、それとも画面表示時のみですか？**

はい。フォールバックは、文字を描画する必要があるが元のフォントに存在しない場合のすべての [rendering and export operations](/slides/ja/python-java/convert-presentation/) に影響します。

**フォールバックの設定はプレゼンテーション ファイル自体を変更しますか、また将来開く際に設定は保持されますか？**

いいえ。フォールバック ルールはコード内の実行時レンダリング設定であり、.pptx 内に保存されず、PowerPoint でも表示されません。

**オペレーティング システム (Windows/Linux/macOS) やフォント ディレクトリのセットはフォールバックの選択に影響しますか？**

はい。エンジンは利用可能なシステム フォルダーや、提供した任意の [additional paths](/slides/ja/python-java/custom-font/) からフォントを解決します。フォントが実際に存在しない場合、そのフォントを参照するルールは機能しません。

**フォールバックは WordArt、SmartArt、チャートでも機能しますか？**

はい。これらのオブジェクトにテキストが含まれる場合、欠落した文字を描画するために同じグリフ置換メカニズムが適用されます。