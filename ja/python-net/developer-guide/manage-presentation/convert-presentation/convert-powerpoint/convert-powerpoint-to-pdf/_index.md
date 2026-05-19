---
title: Python で PPT と PPTX を PDF に変換 | 詳細オプション
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
- Aspose.Slides for Python
description: "Aspose.Slides を使用した Python での PPT、PPTX、ODP を高品質かつ WCAG に準拠した PDF に変換する手順ガイド。パスワード保護、スライド選択、画像品質制御が含まれます。"
showReadingTime: true
---
## **概要**

PowerPoint プレゼンテーション（PPT、PPTX、ODP）を Python で PDF 形式に変換すると、デバイス間の互換性が確保され、プレゼンテーションのレイアウトや書式が保持されるなどのメリットがあります。このガイドでは、プレゼンテーションを PDF に変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF のパスワード保護、フォント置換の検出、変換対象スライドの選択、出力ドキュメントへのコンプライアンス基準の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

Python でプレゼンテーションを PDF に変換するには、[Presentation](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/) クラスにファイル名を引数として渡し、[Save](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/#methods) メソッドで PDF として保存します。[Presentation](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/) クラスは、通常 PDF への変換に使用される [Save](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/#methods) メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python は、出力ドキュメントに API 情報とバージョン番号を直接書き込みます。たとえば、プレゼンテーションを PDF に変換すると、Application フィールドに「*Aspose.Slides*」が、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」という形式の値が設定されます。**注意**：この情報を出力ドキュメントから変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slides では、次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーション内の特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、結果の PDF が元のプレゼンテーションとほぼ同一になるようにします。変換時に正確にレンダリングされる要素と属性は次のとおりです。

* 画像
* テキストボックスとシェイプ
* テキストの書式設定
* 段落の書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換する**

標準の PowerPoint PDF 変換操作はデフォルトオプションで実行されます。この場合、Aspose.Slides は提供されたプレゼンテーションを最大品質レベルの最適設定で PDF に変換しようとします。以下の Python コードは PowerPoint を PDF に変換する方法を示しています。

_手順: Python での PowerPoint から PDF への変換_

次のサンプルコードは .NET 経由で Python を使用した変換を説明しています
- <a name="python-net-powerpoint-to-pdf"><strong>手順: .NET 経由で Python を使用して PowerPoint を PDF に変換</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>手順: .NET 経由で Python を使用して PPT を PDF に変換</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>手順: .NET 経由で Python を使用して PPTX を PDF に変換</strong></a>
- <a name="python-net-odp-to-pdf"><strong>手順: .NET 経由で Python を使用して ODP を PDF に変換</strong></a>
- <a name="python-net-odp-to-pdf"><strong>手順: .NET 経由で Python を使用して PPS を PDF に変換</strong></a>

_コード手順:_

- [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、PowerPoint ファイルを指定します。
  * _.ppt_ 拡張子で **PPT** ファイルを _Presentation_ クラスに読み込みます。
  * _.pptx_ 拡張子で **PPTX** ファイルを _Presentation_ クラスに読み込みます。
  * _.odp_ 拡張子で **ODP** ファイルを _Presentation_ クラスに読み込みます。
  * _.pps_ 拡張子で **PPS** ファイルを _Presentation_ クラスに読み込みます。
- **Save** メソッドを呼び出し、**SaveFormat.PDF** 列挙体を使用して _Presentation_ を **PDF** 形式で保存します。
  

```python
import aspose.slides as slides

# PowerPoint ファイルを表す Presentation クラスのインスタンスを作成します
presentation = slides.Presentation("PowerPoint.ppt")

# プレゼンテーションを PDF として保存します
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose は、プレゼンテーションから PDF への変換プロセスをデモンストレーションする無料のオンライン [**PowerPoint to PDF コンバータ**](https://products.aspose.app/slides/ja/conversion/ppt-to-pdf) を提供しています。ここで説明した手順の実装をライブで試す場合は、コンバータでテストできます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換する**

Aspose.Slides は、[PdfOptions](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides.export/pdfoptions/) クラスのプロパティとしてカスタムオプションを提供し、PDF（変換結果）をカスタマイズしたり、パスワードでロックしたり、変換プロセスの挙動を指定したりできます。

### **カスタムオプションで PowerPoint を PDF に変換する**

カスタム変換オプションを使用すると、ラスタ画像の品質設定、メタファイルの取り扱い方法、テキストの圧縮レベル、画像の DPI などを指定できます。

以下のコード例は、複数のカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する操作を示しています。

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

# テキストコンテンツの圧縮レベルを設定します
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# PDF のコンプライアンスモードを定義します
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# PowerPoint ドキュメントを表す Presentation クラスのインスタンスを作成します
with slides.Presentation("PowerPoint.pptx") as presentation:
    # プレゼンテーションを PDF ドキュメントとして保存します
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **非表示スライドを含めて PowerPoint を PDF に変換する**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides.export/pdfoptions/) クラスの `show_hidden_slides` プロパティを使用して、Aspose.Slides に非表示スライドを PDF のページとして含めるよう指示できます。

この Python コードは、非表示スライドを含めて PowerPoint を PDF に変換する方法を示しています。

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

この Python コードは、[PdfOptions](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides.export/pdfoptions/) クラスの保護パラメータを使用して、パスワード保護された PDF に PowerPoint を変換する方法を示しています。

```python
import aspose.slides as slides

# PowerPoint ファイルを表す Presentation オブジェクトのインスタンスを作成します
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions クラスのインスタンスを作成します
pdfOptions = slides.export.PdfOptions()

# PDF のパスワードとアクセス許可を設定します
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# プレゼンテーションを PDF として保存します
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **フォント置換の検出**

Aspose.Slides は、[SaveOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveoptions/) クラスの `warning_callback` プロパティを提供し、プレゼンテーションから PDF への変換プロセスでフォント置換を検出できます。

この Python コードは、フォント置換を検出する方法を示しています。

```python
[TODO[SLIDESPYNET-91]: callbacks are not supported for now]
```

{{%  alert color="primary"  %}} 

フォント置換の詳細については、[Font Substitution](https://docs.aspose.com/slides/ja/python-net/font-substitution/) 記事をご覧ください。

{{% /alert %}} 

## **選択したスライドだけを PowerPoint から PDF に変換する**

この Python コードは、PowerPoint プレゼンテーション内の特定スライドだけを PDF に変換する方法を示しています。

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

この Python コードは、スライドサイズが指定された PowerPoint を PDF に変換する方法を示しています。

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

        # 元のプレゼンテーションから最初のスライドをクローンします。
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # リサイズされたプレゼンテーションをノート付きの PDF として保存します。
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **ノートスライドビューで PowerPoint を PDF に変換する**

この Python コードは、PowerPoint のノート情報を含んだ PDF を生成する方法を示しています。

```python
import aspose.slides as slides

# PowerPoint ファイルを表す Presentation クラスのインスタンスを作成します
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# プレゼンテーションを PDF のノートとして保存します
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PDF のアクセシビリティとコンプライアンス基準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかを使用して PowerPoint ドキュメントを PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

この Python コードは、異なるコンプライアンス標準に基づく複数の PDF を取得する PowerPoint から PDF への変換操作を示しています。

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

Aspose.Slides の PDF 変換機能は、PDF を最も一般的なファイル形式に変換できるよう拡張されています。次の変換が可能です： [PDF to HTML](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-png/)。さらに、[PDF to SVG](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/ja/python-net/conversion/pdf-to-xml/) などの特殊フォーマットへの変換もサポートされています。

{{% /alert %}}

> **注意:** PDF/UA にエクスポートする際、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされることがあり、代替テキストは全体の図に対してのみ提供されます。

## **FAQ**

**Aspose.Slides for Python は PDF からアプリケーション情報を削除できますか？**

いいえ、Aspose.Slides for Python は出力 PDF に API 情報とバージョン番号を自動的に含めます。この情報は変更または削除できません。

**PDF 変換時に特定のスライドだけを含めるにはどうすればよいですか？**

`save` メソッドにスライド位置の配列を渡すことで、変換したいスライドインデックスを指定できます。

**変換時に PDF をパスワードで保護できますか？**

はい、PDF に保存する前に `PdfOptions` クラスでパスワードとアクセス権限を設定できます。

**Aspose.Slides は PDF を他の形式に変換できますか？**

はい、Aspose.Slides は PDF を HTML、画像形式（JPG、PNG）、SVG、TIFF、XML などに変換することをサポートしています。

**PDF がアクセシビリティ基準に準拠していることを確認するには？**

`PdfOptions` の `compliance` プロパティに `PDF_A1A`、`PDF_A1B`、`PDF_UA` などの基準を設定して、アクセシビリティガイドラインに準拠させます。

**非表示スライドを PDF 出力に含めることは可能ですか？**

はい、`PdfOptions` の `show_hidden_slides` プロパティを `True` に設定すれば、非表示スライドが PDF に含まれます。

**変換時に画像品質と解像度を調整するには？**

`PdfOptions` の `jpeg_quality` と `sufficient_resolution` プロパティを使用して、生成される PDF の画像品質と解像度を制御できます。

**フォント置換は自動的に処理されますか？**

Aspose.Slides は変換中にフォント置換を検出し、`SaveOptions` の `warning_callback` プロパティで（現在は制限あり）対応できます。

## **追加リソース**

- [Aspose.Slides for .NET ドキュメント](https://docs.aspose.com/slides/ja/python-net/)
- [Aspose.Slides API リファレンス](https://reference.aspose.com/slides/ja/python-net/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/ja/conversion)