---
title: "Python で PPT と PPTX を PDF に変換 | 高度なオプション"
linktitle: "PowerPoint を PDF に変換"
type: docs
weight: 40
url: /ja/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
  - "PowerPoint を変換"
  - "プレゼンテーション"
  - "PowerPoint を PDF に変換"
  - "PPT を PDF に変換"
  - "PPTX を PDF に変換"
  - "PowerPoint を PDF として保存"
  - "PDF/A1a"
  - "PDF/A1b"
  - "PDF/UA"
  - "Python"
  - "Aspose.Slides for Python"
description: "Aspose.Slides を使用した Python で PPT、PPTX、ODP を高品質かつ WCAG 準拠の PDF に変換するステップバイステップ ガイド―パスワード保護、スライド選択、画像品質制御を含む。"
showReadingTime: true
---
## **概要**

Python で PowerPoint プレゼンテーション（PPT、PPTX、ODP）を PDF 形式に変換すると、さまざまな利点があります。デバイス間の互換性を確保し、プレゼンテーションのレイアウトと書式設定を保持できます。このガイドでは、プレゼンテーションを PDF に変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF にパスワードを設定する方法、フォント置換の検出、特定のスライドだけを変換する方法、そして出力ドキュメントに準拠基準を適用する方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

Python でプレゼンテーションを PDF に変換するには、[Presentation](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/) クラスにファイル名を引数として渡し、[Save](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/#methods) メソッドで PDF として保存します。[Presentation](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される[Save](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/#methods) メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python は、出力ドキュメントに API 情報とバージョン番号を直接書き込みます。たとえば、プレゼンテーションを PDF に変換すると、Application フィールドに「*Aspose.Slides*」という値が、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」という形式の値が設定されます。**注意**：Aspose.Slides for Python にこの情報を変更または削除させることはできません。

{{% /alert %}}

Aspose.Slides では、以下の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーション内の特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF の内容が元のプレゼンテーションとほぼ一致するようにします。変換時に正確にレンダリングされる要素と属性は次のとおりです。

* 画像
* テキスト ボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint PDF 変換はデフォルト オプションで実行されます。この場合、Aspose.Slides は最適な設定で最高品質レベルの PDF への変換を試みます。以下の Python コードは、PowerPoint を PDF に変換する方法を示しています。

_Steps: PowerPoint to PDF Conversions in Python_

次のサンプルコードは、.NET 経由で Python を使用した変換を説明しています
- <a name="python-net-powerpoint-to-pdf"><strong>手順: Python via .NET を使用して PowerPoint を PDF に変換</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>手順: Python via .NET を使用して PPT を PDF に変換</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>手順: Python via .NET を使用して PPTX を PDF に変換</strong></a>
- <a name="python-net-odp-to-pdf"><strong>手順: Python via .NET を使用して ODP を PDF に変換</strong></a>
- <a name="python-net-odp-to-pdf"><strong>手順: Python via .NET を使用して PPS を PDF に変換</strong></a>

_Code Steps:_

- [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、PowerPoint ファイルを指定します。
  * _.ppt_ 拡張子を使用して **PPT** ファイルを _Presentation_ クラスにロードします。
  * _.pptx_ 拡張子を使用して **PPTX** ファイルを _Presentation_ クラスにロードします。
  * _.odp_ 拡張子を使用して **ODP** ファイルを _Presentation_ クラスにロードします。
  * _.pps_ 拡張子を使用して **PPS** ファイルを _Presentation_ クラスにロードします。
- **Save** メソッドと **SaveFormat.PDF** 列挙体を使用して、_Presentation_ を **PDF** 形式で保存します。
  

```python
import aspose.slides as slides

# PowerPoint ファイルを表す Presentation クラスのインスタンスを生成します
presentation = slides.Presentation("PowerPoint.ppt")

# プレゼンテーションを PDF として保存します
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose は、プレゼンテーションから PDF への変換プロセスを実演する無料のオンライン [**PowerPoint to PDF コンバータ**](https://products.aspose.app/slides/ja/conversion/ppt-to-pdf) を提供しています。ここで説明した手順の実装をライブで試すには、コンバータでテストできます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は、[PdfOptions](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides.export/pdfoptions/) クラスのプロパティとしてカスタム オプションを提供し、PDF（変換プロセスの結果）をカスタマイズしたり、PDF にパスワードを設定したり、変換プロセスの動作を指定したりできます。

### **カスタム オプション付きで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの取り扱い方法、テキストの圧縮レベル、画像の DPI などを指定できます。

以下のコード例は、複数のカスタム オプションを使用して PowerPoint プレゼンテーションを PDF に変換する操作を示しています。

```python
import aspose.slides as slides

# PdfOptions クラスのインスタンスを生成します
pdf_options = slides.export.PdfOptions()

# JPG 画像の品質を設定します
pdf_options.jpeg_quality = 90

# 画像の DPI を設定します
pdf_options.sufficient_resolution = 300

# メタファイルの動作を設定します
pdf_options.save_metafiles_as_png = True

# テキストコンテンツの圧縮レベルを設定します
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# PDF のコンプライアンスモードを定義します
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# PowerPoint ドキュメントを表す Presentation クラスのインスタンスを生成します
with slides.Presentation("PowerPoint.pptx") as presentation:
    # プレゼンテーションを PDF ドキュメントとして保存します
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides.export/pdfoptions/) クラスの `show_hidden_slides` プロパティを使用して、Aspose.Slides に非表示スライドを生成された PDF のページとして含めるよう指示できます。

以下の Python コードは、非表示スライドを含めて PowerPoint を PDF に変換する方法を示しています。

```python
import aspose.slides as slides

# PowerPoint ファイルを表す Presentation クラスのインスタンスを生成します
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions クラスのインスタンスを生成します
pdfOptions = slides.export.PdfOptions()

# 非表示スライドを追加します
pdfOptions.show_hidden_slides = True

# プレゼンテーションを PDF として保存します
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **パスワード保護された PDF に PowerPoint を変換**

以下の Python コードは、[PdfOptions](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides.export/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint をパスワード保護された PDF に変換する方法を示しています。

```python
import aspose.slides as slides

# PowerPoint ファイルを表す Presentation オブジェクトのインスタンスを生成します
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions クラスのインスタンスを生成します
pdfOptions = slides.export.PdfOptions()

# PDF のパスワードとアクセス権限を設定します
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# プレゼンテーションを PDF として保存します
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **選択したスライドだけを PowerPoint から PDF に変換**

以下の Python コードは、PowerPoint プレゼンテーションの特定スライドだけを PDF に変換する方法を示しています。

```python
import aspose.slides as slides

# PowerPoint ファイルを表す Presentation オブジェクトのインスタンスを生成します
presentation = slides.Presentation("PowerPoint.pptx")

# スライド位置の配列を設定します
slides_array = [ 1, 3 ]

# プレゼンテーションを PDF として保存します
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **カスタム スライド サイズで PowerPoint を PDF に変換**

以下の Python コードは、スライドサイズが指定された PowerPoint を PDF に変換する方法を示しています。

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを生成します。
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # 調整されたスライドサイズで新しいプレゼンテーションを作成します。
    with slides.Presentation() as resized_presentation:

        # カスタムスライドサイズを設定します。
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # 元のプレゼンテーションから最初のスライドをクローンします。
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # リサイズされたプレゼンテーションをノート付き PDF として保存します。
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **ノート スライド ビューで PowerPoint を PDF に変換**

以下の Python コードは、ノート付きで PowerPoint を PDF に変換する方法を示しています。

```python
import aspose.slides as slides

# PowerPoint ファイルを表す Presentation クラスのインスタンスを生成します
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# プレゼンテーションを PDF ノートとして保存します
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PDF のアクセシビリティと準拠基準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。PowerPoint ドキュメントを PDF にエクスポートする際に、**PDF/A1a**、**PDF/A1b**、**PDF/UA** のいずれかの準拠基準を選択できます。

以下の Python コードは、異なる準拠基準に基づく複数の PDF を取得する PowerPoint から PDF への変換操作を示しています。

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

Aspose.Slides の PDF 変換機能は、PDF を最も一般的なファイル形式に変換できるように拡張されています。たとえば、[PDF to HTML](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-png/) への変換が可能です。また、[PDF to SVG](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-xml/) などの特殊形式への変換もサポートされています。

{{% /alert %}}

> **注意:** PDF/UA にエクスポートする場合、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされることがあります。代替テキストは全体の図に対してのみ提供されます。

## **FAQ**

**Aspose.Slides for Python は PDF からアプリケーション情報を削除できますか？**

いいえ、Aspose.Slides for Python は出力 PDF に API 情報とバージョン番号を自動的に含めます。この情報は変更または削除できません。

**PDF 変換時に特定のスライドだけを含めるにはどうすればよいですか？**

`save` メソッドにスライド位置の配列を渡すことで、変換したいスライドインデックスを指定できます。

**変換時に PDF にパスワードを設定できますか？**

はい、`PdfOptions` クラスでパスワードとアクセス権限を設定してからプレゼンテーションを PDF として保存できます。

**Aspose.Slides は PDF を他の形式に変換することをサポートしていますか？**

はい、Aspose.Slides は PDF を HTML、画像形式（JPG、PNG）、SVG、TIFF、XML などに変換できます。

**PDF がアクセシビリティ基準に準拠していることを確認するには？**

`PdfOptions` の `compliance` プロパティを `PDF_A1A`、`PDF_A1B`、`PDF_UA` などに設定すると、アクセシビリティガイドラインに準拠した PDF が生成されます。

**非表示スライドを PDF に含めることはできますか？**

はい、`PdfOptions` の `show_hidden_slides` プロパティを `True` に設定すると、非表示スライドが PDF に含まれます。

**変換時に画像品質や解像度を調整するには？**

`PdfOptions` の `jpeg_quality` と `sufficient_resolution` プロパティを使用して、生成される PDF の画像品質と解像度を制御できます。

**フォント置換は自動的に処理されますか？**

Aspose.Slides は変換中にフォント置換を検出し、`SaveOptions` の `warning_callback` プロパティ（現在は限定的）で処理できます。

## **追加リソース**

- [Aspose.Slides for .NET ドキュメント](https://docs.aspose.com/slides/ja/python-net/)
- [Aspose.Slides API リファレンス](https://reference.aspose.com/slides/ja/python-net/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/ja/conversion)