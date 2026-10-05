---
title: Python で PPT と PPTX を PDF に変換 | 詳細オプション
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
  - 添付
  - PDF/A1a
  - PDF/A1b
  - PDF/UA
  - Python
  - Aspose.Slides for Python
description: "Aspose.Slides を使用した Python での PPT、PPTX、ODP の高品質かつ WCAG 準拠 PDF への変換手順ガイド — パスワード保護、スライド選択、画像品質の制御を含む。"
showReadingTime: true
---
## **概要**

Python で PowerPoint プレゼンテーション（PPT、PPTX、ODP）を PDF 形式に変換すると、デバイス間の互換性を確保し、プレゼンテーションのレイアウトや書式設定を保持できるなどのメリットがあります。本ガイドでは、プレゼンテーションを PDF 文書に変換する方法、画像品質を制御するオプションの使用方法、非表示スライドの含め方、PDF のパスワード保護、フォント置換の検出、変換対象スライドの選択、出力文書へのコンプライアンス標準の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

Python でプレゼンテーションを PDF に変換するには、ファイル名を引数として[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスに渡し、[save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) メソッドで PDF として保存するだけです。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される[save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) メソッドを公開しています。

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python は、出力文書に API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換すると、Application フィールドに '*Aspose.Slides*' が設定され、PDF Producer フィールドには '*Aspose.Slides v XX.XX*' 形式の値が設定されます。**注意** Aspose.Slides for Python に対して、出力文書からこの情報を変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slides では次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーション内の特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF の内容が元のプレゼンテーションに極めて近い形になるようにします。変換時に正確に描画される要素と属性は次のとおりです。

* 画像
* テキスト ボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint から PDF への変換プロセスはデフォルト オプションを使用します。この場合、Aspose.Slides は最適な設定と最大品質レベルで提供されたプレゼンテーションを PDF に変換しようとします。

次のサンプルはプレゼンテーションを読み込み、デフォルトのエクスポート設定で表示可能なすべてのスライドを PDF に保存します。

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}

Aspose は無料のオンライン[**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しており、プレゼンテーションから PDF への変換プロセスを実演しています。ここで説明した手順のライブ実装をテストしたい場合は、コンバータで試すことができます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) クラス配下のカスタム オプション（プロパティ）を提供し、PDF（変換結果）をカスタマイズしたり、パスワードでロックしたり、変換プロセスの動作を指定したりできます。

### **カスタム オプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの扱い、テキストの圧縮レベル、画像の DPI などを指定できます。

以下の例は、PDF 1.5 で JPEG 品質を 90、画像解像度を 300 DPI、メタファイルを PNG として保存し、Flate テキスト圧縮を適用してプレゼンテーションをエクスポートします。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **埋め込み OLE ファイルを PDF 添付ファイルとして保持**

プレゼンテーションに埋め込みの Excel ワークブックが含まれている場合、PDF の受取人がワークブックのデータにアクセスできるようにしたいことがあります。[PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) を `True` に設定すると、埋め込み OLE ファイルが結果の PDF に添付ファイルとして保持されます。

既定値は `False` です。OLE オブジェクトのプレビュー画像またはアイコンは PDF ページに描画されますが、埋め込みファイルは添付されません。`True` に設定するとファイル データも添付されます。プレビューは視覚的表現のままで、添付ファイルにより受取人は埋め込みファイルを別個に開くか保存できます。OLE オブジェクトが PDF ページ上で対話型の Excel ワークシートになることはありません。

以下の例は、すでに埋め込み Excel ワークブックを含むプレゼンテーションを読み込み、ワークブックを添付した状態で PDF にエクスポートします。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

結果を確認する手順:

1. ファイル添付をサポートするビューア（例: Adobe Acrobat Reader）でエクスポートされた PDF を開きます。
2. ビューアの **Attachments** パネルを開き、埋め込みワークブックを探します。
3. 添付ファイルを保存し、Excel で開いてデータを確認するか、ビューアが許可すれば直接開きます。PDF ページ上のプレビューは添付ファイルとは別です。

{{% alert color="info" title="Note" %}}

PDF/A 標準は添付ファイルに制限を課します。PDF/A-1 は埋め込みファイルを禁止し、PDF/A-2 は PDF/A 添付ファイルのみを許可し、PDF/A-3 は Excel ワークブックを含む他のファイルタイプを許可します。これらは標準の要件であり、Aspose.Slides 固有の制限ではありません。本例は既定の PDF コンプライアンス設定を使用しており、PDF/A エクスポートは示していません。

{{% /alert %}}

### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) クラスの [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) プロパティを使用して、非表示スライドを結果の PDF のページとして含めるよう指示できます。

以下の例は、非表示スライドを含めてプレゼンテーションを PDF にエクスポートします。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **パスワード保護された PDF に PowerPoint を変換**

以下の例は、`password` というパスワードで開く必要がある PDF にプレゼンテーションをエクスポートします。アクセス許可は印刷を許可し、高品質印刷も可能です。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **PowerPoint の選択スライドを PDF に変換**

以下の例は、プレゼンテーションからスライド 1 と 3 を抽出し、PDF にエクスポートします。この配列のスライド番号は 1 から始まり、入力プレゼンテーションは少なくとも 3 枚のスライドを含んでいる必要があります。

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **カスタム スライド サイズで PowerPoint を PDF に変換**

以下の例は、プレゼンテーションの最初のスライドを新しいプレゼンテーションにコピーし、スライド サイズを 612 × 792 ポイント（8.5 × 11 インチ）に設定します。スライド コンテンツはサイズに合わせて拡大縮小され、単一スライドが PDF にエクスポートされます。

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # 新しく作成されたプレゼンテーションに含まれる空白スライドを削除します。
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **ノート スライド ビューで PowerPoint を PDF に変換**

以下の例は、プレゼンテーションを PDF にエクスポートし、各スライドのスピーカーノートをスライドの下に配置します。結果を確認するには、スピーカーノートを含むプレゼンテーションを使用してください。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **PDF のアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順の使用をサポートします。次のコンプライアンス標準のいずれかを使用して PowerPoint 文書を PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

この Python コードは、異なるコンプライアンス標準に基づく複数の PDF を取得する PowerPoint から PDF への変換操作を示します。

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

{{% alert color="info" title="Note" %}}

Aspose.Slides の PDF 変換機能は、PDF を最も一般的なファイル形式に変換することを可能にします。[PDF to HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) 変換が利用可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) などの専門フォーマットへの変換もサポートされています。

{{% /alert %}}

> **注意:** PDF/UA にエクスポートする場合、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされることがあります。代替テキストは全体の図に対してのみ提供されます。

## **FAQ**

**Aspose.Slides for Python は PDF からアプリケーション情報を削除できますか？**

いいえ、Aspose.Slides for Python は出力 PDF に API 情報とバージョン番号を自動的に含めます。この情報は変更または削除できません。

**PDF 変換時に特定のスライドだけを含めるにはどうすればよいですか？**

[save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) メソッドにスライド位置の配列を渡すことで、変換したいスライドインデックスを指定できます。

**変換時に PDF にパスワードを設定できますか？**

はい、保存前に [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) クラスでパスワードとアクセス許可を設定できます。

**Aspose.Slides は PDF を他の形式に変換する機能がありますか？**

はい、Aspose.Slides は PDF を HTML、画像形式（JPG、PNG）、SVG、TIFF、XML などに変換できます。

**PDF がアクセシビリティ標準に準拠していることを確認するには？**

[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) の [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) プロパティを `PDF_A1A`、`PDF_A1B`、または `PDF_UA` に設定して、アクセシビリティ ガイドラインへの準拠を保証します。

**PDF 出力に非表示スライドを含めることは可能ですか？**

はい、[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) の [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) プロパティを `True` に設定すると、非表示スライドが PDF に含まれます。

**変換時に画像の品質と解像度を調整するには？**

[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) の [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) と [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) プロパティを使用して、生成される PDF の画像品質と解像度を制御できます。

**Aspose.Slides はフォント置換を自動的に処理しますか？**

Aspose.Slides は変換中にフォント置換を検出し、`warning_callback` プロパティ（現在は制限あり）で処理できます。

## **追加リソース**

- [Aspose.Slides for Python via .NET Documentation](/slides/ja/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)