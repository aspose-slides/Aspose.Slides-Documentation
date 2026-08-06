---
title: Python で PPT & PPTX を PDF に変換 | 高度なオプション
linktitle: PowerPoint を PDF に変換
type: docs
weight: 40
url: /ja/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
  - PowerPoint を変換
  - プレゼンテーション
  - PowerPoint を PDF に変換
  - PPT を PDF に変換
  - PPTX を PDF に変換
  - PowerPoint を PDF として保存
  - PDF/A1a
  - PDF/A1b
  - PDF/UA
  - Python
  - Aspose.Slides for Python
description: "Aspose.Slides を使用して Python で PPT、PPTX、ODP を高品質で WCAG に準拠した PDF に変換するステップバイステップガイド — パスワード保護、スライド選択、画像品質制御を含む。"
showReadingTime: true
---
## **概要**

Python で PowerPoint プレゼンテーション（PPT、PPTX、ODP）を PDF 形式に変換すると、デバイス間の互換性を確保し、プレゼンテーションのレイアウトや書式を保持できるなど、さまざまな利点があります。本ガイドでは、プレゼンテーションを PDF に変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF にパスワードを設定する方法、フォント置換の検出、特定のスライドだけを変換する方法、そして出力ドキュメントにコンプライアンス標準を適用する方法を示します。

## **インストール**

```bash
pip install aspose.slides
```

このパッケージは必要なランタイムを同梱しているため、変換を実行するマシンに Microsoft PowerPoint をインストールする必要はありません。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、以下の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

Python でプレゼンテーションを PDF に変換するには、[Presentation](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/) クラスにファイル名を引数として渡し、[Save](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/#methods) メソッドで PDF として保存します。[Presentation](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/) クラスは、通常 PDF 変換に使用される[Save](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/#methods) メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python は、出力ドキュメントに API 情報とバージョン番号を直接書き込みます。たとえば、プレゼンテーションを PDF に変換する際、Application フィールドに「*Aspose.Slides*」という値が、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」という形式の値が設定されます。**注意**：Aspose.Slides for Python に対して、これらの情報を変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slides では以下の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーション内の特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF の内容が元のプレゼンテーションに極めて近い状態になるよう保証します。変換時に正確にレンダリングされる要素と属性は次のとおりです。

* 画像
* テキスト ボックスとシェイプ
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* テーブル

## **PowerPoint を PDF に変換する**

標準の PowerPoint PDF 変換操作は既定オプションで実行されます。この場合、Aspose.Slides は最大品質レベルの最適設定でプレゼンテーションを PDF に変換しようとします。以下の Python コードは PowerPoint を PDF に変換する方法を示しています。

*Steps: PowerPoint to PDF Conversions in Python*

以下のサンプルコードは .NET 経由で Python を使用した変換例を説明しています。
- <a name="python-net-powerpoint-to-pdf"><strong>Steps: Convert PowerPoint to PDF using Python via .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Steps: Convert PPT to PDF using Python via .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Steps: Convert PPTX to PDF using Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Steps: Convert ODP to PDF using Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Steps: Convert PPS to PDF using Python via .NET</a></strong>

_Code Steps:_

- [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、PowerPoint ファイルを指定します。
  * _.ppt_ 拡張子は **PPT** ファイルを _Presentation_ クラスに読み込むために使用します。
  * _.pptx_ 拡張子は **PPTX** ファイルを _Presentation_ クラスに読み込むために使用します。
  * _.odp_ 拡張子は **ODP** ファイルを _Presentation_ クラスに読み込むために使用します。
  * _.pps_ 拡張子は **PPS** ファイルを _Presentation_ クラスに読み込むために使用します。
- **Save** メソッドと **SaveFormat.PDF** 列挙体を使用して、_Presentation_ を **PDF** 形式で保存します。
  

```python
import aspose.slides as slides

# PowerPoint ファイルを表す Presentation クラスのインスタンスを作成します
presentation = slides.Presentation("PowerPoint.ppt")

# プレゼンテーションを PDF として保存します
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose は、プレゼンテーションから PDF への変換プロセスをデモする無料のオンライン **PowerPoint to PDF コンバータ**[https://products.aspose.app/slides/ja/conversion/ppt-to-pdf] を提供しています。ここで説明した手順の実装をライブで確認したい場合は、コンバータでテストしてください。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換する**

Aspose.Slides は、[PdfOptions](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides.export/pdfoptions/) クラスで提供されるカスタムオプション（プロパティ）を通じて、PDF のカスタマイズ、パスワード保護、変換プロセスの詳細指定が可能です。

### **カスタムオプションで PowerPoint を PDF に変換する**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI などを指定できます。

以下のコード例は、複数のカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する操作を示しています：

```python
import aspose.slides as slides

# PdfOptions クラスのインスタンスを作成します
pdf_options = slides.export.PdfOptions()

# JPG 画像の品質を設定します
pdf_options.jpeg_quality = 90

# 画像の DPI を設定します
pdf_options.sufficient_resolution = 300

# メタファイルの動作を設定します
pdf_options.save_metafiles_as_png = True

# テキスト コンテンツの圧縮レベルを設定します
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# PDF コンプライアンスモードを定義します
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# PowerPoint ドキュメントを表す Presentation クラスのインスタンスを作成します
with slides.Presentation("PowerPoint.pptx") as presentation:
    # プレゼンテーションを PDF ドキュメントとして保存します
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **非表示スライドを含めて PowerPoint を PDF に変換する**

プレゼンテーションに非表示スライドが含まれる場合、[PdfOptions](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides.export/pdfoptions/) クラスの `show_hidden_slides` プロパティを使用して、非表示スライドを結果の PDF のページとして含めるよう指示できます。

この Python コードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています：

```python
import aspose.slides as slides

# PowerPoint ファイルを表す Presentation クラスのインスタンスを作成します
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions クラスのインスタンスを作成します
pdfOptions = slides.export.PdfOptions()

# 非表示スライドを追加します
pdfOptions.show_hidden_slides = True

# プレゼンテーションを PDF として保存します
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **パスワード保護された PDF に PowerPoint を変換する**

この Python コードは、[PdfOptions](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides.export/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint をパスワード保護された PDF に変換する方法を示しています：

```python
import aspose.slides as slides

# PowerPoint ファイルを表す Presentation オブジェクトのインスタンスを作成します
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions クラスのインスタンスを作成します
pdfOptions = slides.export.PdfOptions()

# PDF のパスワードとアクセス権限を設定します
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# プレゼンテーションを PDF として保存します
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PowerPoint の選択スライドだけを PDF に変換する**

この Python コードは、PowerPoint プレゼンテーションの特定スライドだけを PDF に変換する方法を示しています：

```python
import aspose.slides as slides

# PowerPoint ファイルを表す Presentation オブジェクトのインスタンスを作成します
presentation = slides.Presentation("PowerPoint.pptx")

# スライド位置の配列を設定します
slides_array = [ 1, 3 ]

# プレゼンテーションを PDF として保存します
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **カスタムスライドサイズで PowerPoint を PDF に変換する**

この Python コードは、スライドサイズが指定された PowerPoint を PDF に変換する方法を示しています：

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # 調整されたスライドサイズで新しいプレゼンテーションを作成します。
    with slides.Presentation() as resized_presentation:

        # カスタムスライドサイズを設定します。
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # 元のプレゼンテーションから最初のスライドをクローンし、デフォルトの空スライドを削除します。
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # リサイズされたプレゼンテーションを PDF として保存します。
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **ノートスライドビューで PowerPoint を PDF に変換する**

この Python コードは、ノート付きの PowerPoint を PDF に変換する方法を示しています：

```python
import aspose.slides as slides

# PowerPoint ファイルを表す Presentation クラスのインスタンスを作成します
presentation = slides.Presentation("NotesFile.pptx")

# メモレイアウトで PDF オプションを設定します
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# メモ付きでプレゼンテーションを PDF に保存します
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PDF のアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順をサポートします。次のコンプライアンス標準のいずれかを使用して PowerPoint 文書を PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

この Python コードは、異なるコンプライアンス標準に基づく複数の PDF を取得する PowerPoint から PDF への変換操作を示しています：

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides の PDF 変換機能は、PDF を最も一般的なファイル形式に変換できる機能も提供します。以下の変換が可能です： [PDF to HTML](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-png/)。さらに、[PDF to SVG](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-xml/) といった専門的な形式への変換もサポートされています。

{{% /alert %}}

> **注意:** PDF/UA へエクスポートする際、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図形として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされることがあります。代替テキストは全体の図形に対してのみ提供されます。

## **FAQ**

### Aspose.Slides for Python は PDF からアプリケーション情報を削除できますか？

いいえ、Aspose.Slides for Python は出力 PDF に自動的に API 情報とバージョン番号を含めます。この情報は変更または削除できません。

### PDF 変換で特定のスライドだけを含めるにはどうすればよいですか？

`save` メソッドにスライド位置の配列を渡すことで、変換したいスライドインデックスを指定できます。

### 変換時に PDF にパスワードを設定できますか？

はい、`PdfOptions` クラスでパスワードとアクセス権限を設定してから、プレゼンテーションを PDF として保存できます。

### Aspose.Slides は PDF を他の形式に変換する機能を持っていますか？

はい、Aspose.Slides は PDF を HTML、画像形式（JPG、PNG）、SVG、TIFF、XML などに変換する機能をサポートしています。

### PDF がアクセシビリティ基準に準拠していることを確認するには？

`PdfOptions` の `compliance` プロパティに `PDF_A1A`、`PDF_A1B`、`PDF_UA` などの標準を設定して、アクセシビリティガイドラインへの準拠を確保します。

### 非表示スライドを PDF に含めることはできますか？

はい、`PdfOptions` の `show_hidden_slides` プロパティを `True` に設定すると、非表示スライドが PDF に含まれます。

### 変換時に画像品質と解像度を調整するには？

`PdfOptions` の `jpeg_quality` と `sufficient_resolution` プロパティを使用して、生成される PDF の画像品質と解像度を制御できます。

### Aspose.Slides はフォント置換を自動的に処理しますか？

Aspose.Slides は変換中にフォント置換を検出し、`SaveOptions` の `warning_callback` プロパティ（現在は制限あり）でそれらを処理できます。

## **追加リソース**

- [Aspose.Slides for .NET Documentation](https://docs.aspose.com/slides/ja/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/ja/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/ja/conversion)