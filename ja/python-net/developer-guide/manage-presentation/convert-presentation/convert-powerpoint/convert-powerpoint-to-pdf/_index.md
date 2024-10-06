---
title: PythonでPowerPointをPDFに変換する
linktitle: PowerPointをPDFに変換する
type: docs
weight: 40
url: /ja/python-net/convert-powerpoint-to-pdf/
keywords:
- PowerPointを変換
- プレゼンテーション
- PowerPointからPDF
- PPTからPDF
- PPTXからPDF
- PowerPointをPDFとして保存
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "PythonでPowerPointプレゼンテーションをPDFに変換します。準拠またはアクセシビリティ基準を満たすPDFとしてPowerPointを保存します。"
---

## **概要**

PowerPoint文書をPDF形式に変換することは、異なるデバイス間の互換性を保証し、プレゼンテーションのレイアウトと書式を保持するなど、いくつかの利点があります。この記事では、プレゼンテーションをPDF文書に変換する方法、画像品質を制御するさまざまなオプションを使用する方法、非表示のスライドを含める方法、PDF文書をパスワードで保護する方法、フォントの置き換えを検出する方法、変換するスライドを選択する方法、および出力文書に準拠基準を適用する方法を示します。

## **PowerPointからPDFへの変換**

Aspose.Slidesを使用すると、次の形式のプレゼンテーションをPDFに変換できます：

* PPT
* PPTX
* ODP

PythonでプレゼンテーションをPDFに変換するには、[Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/)クラスにファイル名を引数として渡し、その後[Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods)メソッドを使用してプレゼンテーションをPDFとして保存するだけです。[Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/)クラスは、プレゼンテーションをPDFに変換するために通常使用される[Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods)メソッドを公開しています。

{{%  alert title="注意"  color="warning"   %}} 

Aspose.Slides for Pythonは、出力文書にAPI情報とバージョン番号を直接記載します。たとえば、プレゼンテーションをPDFに変換するとき、Aspose.Slides for PythonはApplicationフィールドに'*Aspose.Slides*'の値を入力し、PDF Producerフィールドには'*Aspose.Slides v XX.XX*'という形式の値を入力します。**注意**として、Aspose.Slides for Pythonにこの情報を出力文書から変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slidesでは、次のことが可能です：

* 全体のプレゼンテーションをPDFに変換する
* プレゼンテーション内の特定のスライドをPDFに変換する
* プレゼンテーションを 

Aspose.Slidesは、プレゼンテーションからの内容が元のプレゼンテーションと非常に似ている方法でPDFにエクスポートします。これらの既知の要素と属性は、プレゼンテーションからPDFへの変換で正しくレンダリングされることが多いです：

* 画像
* テキストボックスやその他の図形
* テキストとその書式
* 段落とその書式
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* テーブル

## **PowerPointをPDFに変換する**

標準的なPowerPoint PDF変換操作は、デフォルトのオプションを使用して実行されます。この場合、Aspose.Slidesは、提供されたプレゼンテーションを最大の品質レベルで最適な設定を使用してPDFに変換しようとします。このPythonコードでは、PowerPointをPDFに変換する方法を示します：

_手順：PythonでのPowerPointからPDFへの変換_

以下のサンプルコードでは、.NET経由でPythonを使用したこれらの変換を説明します
- <a name="python-net-powerpoint-to-pdf"><strong>手順：.NET経由でPythonを使用してPowerPointをPDFに変換する</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>手順：.NET経由でPythonを使用してPPTをPDFに変換する</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>手順：.NET経由でPythonを使用してPPTXをPDFに変換する</a></strong>
- <a name="python-net-odp-to-pdf"><strong>手順：.NET経由でPythonを使用してODPをPDFに変換する</a></strong>
- <a name="python-net-odp-to-pdf"><strong>手順：.NET経由でPythonを使用してPPSをPDFに変換する</a></strong>

_コード手順：_

- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、PowerPointファイルを提供します。
  * _.ppt_拡張子を使用して_Presentation_クラス内に**PPT**ファイルをロードします。
  * _.pptx_拡張子を使用して_Presentation_クラス内に**PPTX**ファイルをロードします。
  * _.odp_拡張子を使用して_Presentation_クラス内に**ODP**ファイルをロードします。
  * _.pps_拡張子を使用して_Presentation_クラス内に**PPS**ファイルをロードします。
- **Save**メソッドを呼び出して_Presentation_を**PDF**形式で保存します。  

```python
import aspose.slides as slides

# PowerPointファイルを表すPresentationクラスのインスタンスを作成
presentation = slides.Presentation("PowerPoint.ppt")

# プレゼンテーションをPDFとして保存
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Asposeは、プレゼンテーションをPDFに変換するプロセスを示す無料のオンライン[**PowerPointからPDFへの変換ツール**](https://products.aspose.app/slides/conversion/ppt-to-pdf)を提供しています。ここで説明されている手順のライブ実装のために、変換ツールでテストを行うことができます。

{{% /alert %}}

## PowerPointをオプション付きでPDFに変換する

Aspose.Slidesは、変換プロセスから得られるPDFをカスタマイズしたり、パスワードでPDFをロックしたり、変換プロセスの方法を指定したりできるカスタムオプションを提供します。

### **カスタムオプションを使用してPowerPointをPDFに変換する**

カスタム変換オプションを使用することで、ラスタ画像に対して好みの品質設定を設定したり、メタファイルの取り扱いを指定したり、テキストの圧縮レベルを設定したり、画像のDPIを設定したりできます。

以下のコード例では、PowerPointプレゼンテーションを複数のカスタムオプションでPDFに変換する操作を示しています：

```python
import aspose.slides as slides

# PdfOptionsクラスのインスタンスを作成
pdf_options = slides.export.PdfOptions()

# JPG画像の品質を設定
pdf_options.jpeg_quality = 90

# 画像のDPIを設定
pdf_options.sufficient_resolution = 300

# メタファイルの動作を設定
pdf_options.save_metafiles_as_png = True

# テキストコンテンツの圧縮レベルを設定
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# PDF準拠モードを定義
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# PowerPoint文書を表すPresentationクラスのインスタンスを作成
with slides.Presentation("PowerPoint.pptx") as presentation:
    # プレゼンテーションをPDF文書として保存
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **非表示スライドを含めてPowerPointをPDFに変換する**

プレゼンテーションに非表示のスライドが含まれている場合は、カスタムオプションとして[PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)クラスの`show_hidden_slides`プロパティを使用して、Aspose.Slidesに非表示のスライドをPDFのページとして含めるよう指示できます。

このPythonコードでは、非表示スライドを含めてPowerPointプレゼンテーションをPDFに変換する方法を示します：

```python
import aspose.slides as slides

# PowerPointファイルを表すPresentationクラスのインスタンスを作成
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptionsクラスのインスタンスを作成
pdfOptions = slides.export.PdfOptions()

# 非表示スライドを追加
pdfOptions.show_hidden_slides = True

# プレゼンテーションをPDFとして保存
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **パスワード保護されたPDFにPowerPointを変換する**

このPythonコードでは、PowerPointをパスワード保護されたPDFに変換する方法を示します（[PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)クラスの保護パラメータを使用）：

```python
import aspose.slides as slides

# PowerPointファイルを表すPresentationオブジェクトのインスタンスを作成
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptionsクラスのインスタンスを作成
pdfOptions = slides.export.PdfOptions()

# PDFパスワードとアクセス許可を設定
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# プレゼンテーションをPDFとして保存
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### フォントの置き換えを検出する

Aspose.Slidesは、プレゼンテーションからPDFへの変換プロセスでフォントの置き換えを検出するための[SaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/)クラスの`warning_callback`プロパティを提供します。

このPythonコードでは、フォントの置き換えを検出する方法を示します：  

```python
[TODO[SLIDESPYNET-91]: コールバックは現在サポートされていません]
```

{{%  alert color="primary"  %}} 

フォントの置き換えに関する詳細は、[フォントの置き換え](https://docs.aspose.com/slides/python-net/font-substitution/)の記事を参照してください。

{{% /alert %}} 

## **PowerPoint内の選択したスライドをPDFに変換する**

このPythonコードでは、PowerPointプレゼンテーション内の特定のスライドをPDFに変換する方法を示します：

```python
import aspose.slides as slides

# PowerPointファイルを表すPresentationオブジェクトのインスタンスを作成
presentation = slides.Presentation("PowerPoint.pptx")

# スライド位置の配列を設定
slides_array = [ 1, 3 ]

# プレゼンテーションをPDFとして保存
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **カスタムスライドサイズでPowerPointをPDFに変換する**

このPythonコードでは、スライドサイズが指定されたPowerPointをPDFに変換する方法を示します：

```python
import aspose.slides as slides

# PowerPointファイルを表すPresentationオブジェクトのインスタンスを作成 
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# スライドのタイプとサイズを設定 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **ノートスライドビューでPowerPointをPDFに変換する**

このPythonコードでは、PowerPointをPDFノートに変換する方法を示します：

```python
import aspose.slides as slides

# PowerPointファイルを表すPresentationクラスのインスタンスを作成
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# プレゼンテーションをPDFノートとして保存
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PDFのアクセシビリティと準拠基準**

Aspose.Slidesでは、[Webコンテンツアクセシビリティガイドライン（**WCAG**）](https://www.w3.org/TR/WCAG-TECHS/pdf.html)に準拠した変換手順を使用することができます。これらの準拠基準のいずれかを使用して、PowerPoint文書をPDFにエクスポートできます：**PDF/A1a**、**PDF/A1b**、および**PDF/UA**。

このPythonコードは、異なる準拠基準に基づいて複数のPDFを取得するPowerPointからPDFへの変換操作を示しています：

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

{{% alert title="注意" color="warning" %}} 

Aspose.SlidesのPDF変換操作は、PDFを最も人気のあるファイル形式に変換することを許可します。[PDFからHTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)、[PDFから画像](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)、[PDFからJPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/)、および[PDFからPNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/)への変換ができます。他のPDF変換操作では、[PDFからSVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)、[PDFからTIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/)、および[PDFからXML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)への変換もサポートされています。

{{% /alert %}}