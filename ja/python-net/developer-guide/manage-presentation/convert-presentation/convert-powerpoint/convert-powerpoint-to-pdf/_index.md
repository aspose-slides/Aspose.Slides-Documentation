---
title: Python で PPT と PPTX を PDF に変換 | 高度なオプション
linktitle: PowerPoint を PDF に変換
type: docs
weight: 40
url: /ja/python-net/convert-powerpoint-to-pdf/
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
- Python 用 Aspose.Slides
description: "Aspose.Slides を使用して Python で PPT、PPTX、ODP を高品質かつ WCAG 準拠の PDF に変換するステップバイステップ ガイドです。パスワード保護、スライド選択、画像品質の制御も含まれます。"
showReadingTime: true
---

## **概要**

PowerPoint プレゼンテーション（PPT、PPTX、ODP）を Python で PDF 形式に変換すると、さまざまな利点があります。デバイス間の互換性を確保し、プレゼンテーションのレイアウトと書式設定を保持できます。本ガイドでは、プレゼンテーションを PDF ドキュメントに変換する方法、画像品質を制御するさまざまなオプションの利用、非表示スライドの含め方、PDF 文書へのパスワード保護、フォント置換の検出、特定スライドの選択変換、出力文書へのコンプライアンス基準の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

Python でプレゼンテーションを PDF に変換するには、[Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) クラスにファイル名を引数として渡し、その後 [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) メソッドで PDF として保存します。[Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) クラスは、プレゼンテーションを PDF に変換する際に通常使用される [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for Python は、出力文書に API 情報とバージョン番号を直接書き込みます。たとえば、プレゼンテーションを PDF に変換すると、Aspose.Slides for Python は Application フィールドに「*Aspose.Slides*」という値を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」という形式の値を設定します。**注意**：Aspose.Slides for Python に対して、これらの情報を変更または削除するよう指示することはできません。 
{{% /alert %}}

Aspose.Slides では、次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーション内の特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF の内容が元のプレゼンテーションとほぼ同一になるようにします。変換時に正確にレンダリングされる要素と属性は以下のとおりです。

* 画像
* テキスト ボックスとシェイプ
* テキストの書式設定
* 段落の書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換する**

標準の PowerPoint PDF 変換操作はデフォルトオプションで実行されます。この場合、Aspose.Slides は最適な設定と最高品質レベルで提供されたプレゼンテーションを PDF に変換しようとします。以下の Python コードは、PowerPoint を PDF に変換する方法を示しています。

_手順: Python での PowerPoint から PDF への変換_

以下のサンプルコードは、.NET 経由で Python を使用した変換を説明しています
- <a name="python-net-powerpoint-to-pdf"><strong>手順: .NET 経由で Python を使用して PowerPoint を PDF に変換</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>手順: .NET 経由で Python を使用して PPT を PDF に変換</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>手順: .NET 経由で Python を使用して PPTX を PDF に変換</strong></a>
- <a name="python-net-odp-to-pdf"><strong>手順: .NET 経由で Python を使用して ODP を PDF に変換</strong></a>
- <a name="python-net-odp-to-pdf"><strong>手順: .NET 経由で Python を使用して PPS を PDF に変換</strong></a>

**コード手順:**

- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、PowerPoint ファイルを渡します。
  * _.ppt_ 拡張子で **PPT** ファイルを _Presentation_ クラスにロードします。
  * _.pptx_ 拡張子で **PPTX** ファイルを _Presentation_ クラスにロードします。
  * _.odp_ 拡張子で **ODP** ファイルを _Presentation_ クラスにロードします。
  * _.pps_ 拡張子で **PPS** ファイルを _Presentation_ クラスにロードします。
- **Save** メソッドを呼び出し、**SaveFormat.PDF** 列挙体を使用して _Presentation_ を **PDF** 形式で保存します。
```python
import aspose.slides as slides

# PowerPoint ファイルを表す Presentation クラスのインスタンスを作成します
presentation = slides.Presentation("PowerPoint.ppt")

# プレゼンテーションを PDF として保存します
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```


{{%  alert  color="primary"  %}} 
Aspose は、プレゼンテーションを PDF に変換するプロセスを実演する無料のオンライン [**PowerPoint から PDF へのコンバータ**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。ここで説明した手順の実装をライブで確認したい場合は、コンバータでテストできます。 
{{% /alert %}}

## **オプションを使用して PowerPoint を PDF に変換する**

Aspose.Slides は、[PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) クラスのプロパティとしてカスタムオプションを提供し、PDF（変換プロセスの結果）をカスタマイズしたり、パスワードでロックしたり、変換プロセスの挙動を指定したりできます。

### **カスタムオプションで PowerPoint を PDF に変換する**

カスタム変換オプションを使用すると、ラスタ画像の品質設定、メタファイルの取り扱い、テキストの圧縮レベル、画像の DPI などを指定できます。

以下のコード例は、複数のカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する操作を示しています:
```python
import aspose.slides as slides

# PdfOptions クラスのインスタンスを作成します
pdf_options = slides.export.PdfOptions()

# JPG 画像の品質を設定します
pdf_options.jpeg_quality = 90

# 画像の DPI を設定します
pdf_options.sufficient_resolution = 300

# メタファイルの処理方法を設定します
pdf_options.save_metafiles_as_png = True

# テキストコンテンツの圧縮レベルを設定します
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# PDF コンプライアンスモードを定義します
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# PowerPoint ドキュメントを表す Presentation クラスのインスタンスを作成します
with slides.Presentation("PowerPoint.pptx") as presentation:
    # プレゼンテーションを PDF ドキュメントとして保存します
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```


### **非表示スライドを含めて PowerPoint を PDF に変換する**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) クラスの `show_hidden_slides` プロパティというカスタムオプションを使用して、Aspose.Slides に非表示スライドを結果の PDF のページとして含めるよう指示できます。

以下の Python コードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています:
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

以下の Python コードは、[PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) クラスの保護パラメーターを使用して、PowerPoint をパスワード保護された PDF に変換する方法を示しています:
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


### **フォント置換を検出する**

Aspose.Slides は、[SaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/) クラスの `warning_callback` プロパティを提供し、プレゼンテーションから PDF への変換プロセスでフォント置換を検出できます。

以下の Python コードは、フォント置換を検出する方法を示しています:  
```python
[TODO[SLIDESPYNET-91]: コールバックは現在サポートされていません]
```


{{%  alert color="primary"  %}} 
フォント置換の詳細については、[フォント置換](https://docs.aspose.com/slides/python-net/font-substitution/) 記事をご参照ください。 
{{% /alert %}} 

## **PowerPoint の特定スライドを PDF に変換する**

以下の Python コードは、PowerPoint プレゼンテーション内の特定スライドを PDF に変換する方法を示しています:
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

以下の Python コードは、スライドサイズが指定された PowerPoint を PDF に変換する方法を示しています:
```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# PowerPoint または OpenDocument ファイルを表す Presentation クラスをインスタンス化します。
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # 調整されたスライドサイズで新しいプレゼンテーションを作成します。
    with slides.Presentation() as resized_presentation:

        # カスタムスライドサイズを設定します。
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # 元のプレゼンテーションから最初のスライドをクローンします。
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # サイズ変更されたプレゼンテーションをノート付き PDF として保存します。
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```


## **ノートスライドビューで PowerPoint を PDF に変換する**

以下の Python コードは、PowerPoint のノートを PDF に変換する方法を示しています:
```python
import aspose.slides as slides

# PowerPoint ファイルを表す Presentation クラスのインスタンスを作成します
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# プレゼンテーションを PDF ノートとして保存します
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```


## **PDF のアクセシビリティとコンプライアンス基準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかを使用して PowerPoint 文書を PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下の Python コードは、異なるコンプライアンス標準に基づく複数の PDF を取得する PowerPoint から PDF への変換操作をデモンストレーションします:
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
Aspose.Slides の PDF 変換機能は、PDF を最も一般的なファイル形式に変換することもサポートしています。[PDF から HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)、[PDF から画像](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)、[PDF から JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/)、および [PDF から PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) への変換が可能です。さらに、[PDF から SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)、[PDF から TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/)、[PDF から XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) といった特殊形式への変換もサポートされています。 
{{% /alert %}}

## **FAQ**

**Aspose.Slides for Python は PDF からアプリケーション情報を削除できますか？**

いいえ、Aspose.Slides for Python は出力 PDF に API 情報とバージョン番号を自動的に含めます。この情報は変更も削除もできません。

**PDF 変換時に特定のスライドだけを含めるにはどうすればよいですか？**

`save` メソッドにスライド位置の配列を渡すことで、変換したいスライドインデックスを指定できます。

**変換時に PDF にパスワードを設定できますか？**

はい、`PdfOptions` クラスでパスワードとアクセス権限を設定してから、プレゼンテーションを PDF として保存できます。

**Aspose.Slides は PDF を他の形式に変換できますか？**

はい、Aspose.Slides は PDF を HTML、画像形式（JPG、PNG）、SVG、TIFF、XML などに変換することをサポートしています。

**PDF がアクセシビリティ基準に準拠しているか確認するには？**

`PdfOptions` の `compliance` プロパティを `PDF_A1A`、`PDF_A1B`、または `PDF_UA` に設定することで、アクセシビリティガイドラインへの準拠を保証できます。

**非表示スライドを PDF に含めることはできますか？**

はい、`PdfOptions` の `show_hidden_slides` プロパティを `True` に設定すれば、非表示スライドが PDF に含まれます。

**変換時に画像の品質と解像度を調整するには？**

`PdfOptions` の `jpeg_quality` と `sufficient_resolution` プロパティを使用して、生成される PDF の画像品質と解像度を制御できます。

**Aspose.Slides はフォント置換を自動的に処理しますか？**

Aspose.Slides は変換中にフォント置換を検出し、`SaveOptions` の `warning_callback` プロパティでそれらを処理できます（現在は制限あり）。

## **追加リソース**

- [Aspose.Slides for .NET ドキュメント](https://docs.aspose.com/slides/python-net/)
- [Aspose.Slides API リファレンス](https://reference.aspose.com/slides/python-net/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)