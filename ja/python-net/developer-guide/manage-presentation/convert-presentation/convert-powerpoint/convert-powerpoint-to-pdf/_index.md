---
title: Python で PPT と PPTX を PDF に変換 | 高度なオプション
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
description: "Aspose.Slides を使用した Python における PPT、PPTX、ODP を高品質で WCAG 準拠の PDF に変換するステップバイステップガイド—パスワード保護、スライド選択、画像品質制御を含む。"
showReadingTime: true
---
## **概要**

PowerPoint プレゼンテーション（PPT、PPTX、ODP）を Python で PDF 形式に変換することには、さまざまな利点があります。デバイス間の互換性を確保し、プレゼンテーションのレイアウトや書式を保持できる点などです。本ガイドでは、プレゼンテーションを PDF 文書に変換する方法、画像品質を制御するオプションの利用方法、非表示スライドの含め方、PDF 文書のパスワード保護、フォント置換の検出、特定のスライドのみを変換する方法、そして出力文書に適用できるコンプライアンス基準について示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、これらの形式のプレゼンテーションを PDF に変換できます：

* **PPT**
* **PPTX**
* **ODP**

Python でプレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスに渡し、その後 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) メソッドを使用してプレゼンテーションを PDF として保存するだけです。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) メソッドを公開しています。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換する際、Aspose.Slides for Python は Application フィールドに '*Aspose.Slides*' の値を、PDF Producer フィールドには '*Aspose.Slides v XX.XX*' 形式の値を設定します。**Note** として、Aspose.Slides for Python にこの情報を変更または削除させることはできません。
{{% /alert %}}

Aspose.Slides では、次の変換が可能です：

* プレゼンテーション全体を PDF に変換
* プレゼンテーション内の特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF の内容が元のプレゼンテーションとほぼ同一になるよう保証します。変換時には、要素や属性が正確にレンダリングされ、以下が含まれます：

* 画像
* テキスト ボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は提供されたプレゼンテーションを最高品質の最適設定で PDF に変換しようとします。

以下の例は、プレゼンテーションを読み込み、デフォルトのエクスポート設定を使用してすべての表示スライドを PDF に保存します。

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose は、プレゼンテーションを PDF に変換するプロセスを示す無料のオンライン [**PowerPoint から PDF へのコンバータ**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。ここで説明した手順を実際に実装するには、コンバータでテストできます。
{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) クラスのプロパティとしてカスタムオプションを提供し、変換プロセスで生成される PDF をカスタマイズしたり、PDF にパスワードでロックしたり、変換プロセスの動作を指定したりできます。

### **カスタムオプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定やメタファイルの取り扱い方法、テキストの圧縮レベル、画像の DPI などを設定できます。

以下の例は、JPEG 品質を 90、画像解像度を 300 DPI、メタファイルを PNG として保存し、Flate テキスト圧縮を使用して PDF 1.5 にエクスポートします。

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

プレゼンテーションに埋め込みの Excel ワークブックが含まれている場合、PDF の受取人がスライドを閲覧できるだけでなく、ワークブックのデータにもアクセスできるようにしたいことがあります。[PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) を `True` に設定すると、埋め込み OLE ファイルが生成された PDF の添付ファイルとして保持されます。

デフォルト値は `False` です。OLE オブジェクトのプレビュー画像またはアイコンは PDF ページに描画されますが、埋め込みファイルは添付ファイルとして含まれません。オプションを `True` に設定すると、ファイルデータも添付されます。プレビューは視覚的な表現のままで、添付ファイルにより受取人は埋め込みファイルを個別に開いたり保存したりできます。OLE オブジェクトは PDF ページ上でインタラクティブな Excel ワークシートにはなりません。

以下の例は、既に埋め込み Excel ワークブックを含むプレゼンテーションを読み込み、ワークブックを添付した状態で PDF にエクスポートします。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

結果を確認するには：

1. Adobe Acrobat Reader など、ファイル添付をサポートするビューアでエクスポートされた PDF を開きます。
2. ビューアの **Attachments** パネルを開き、埋め込みワークブックを探します。
3. 添付ファイルを保存し、Excel で開いてデータを確認するか、ビューアが許可すれば直接開きます。PDF ページ上のプレビューは添付ファイルとは別です。

{{% alert color="info" title="Note" %}}
PDF/A 標準は添付ファイルに制限を課しています。PDF/A-1 は埋め込みファイルを禁止し、PDF/A-2 は PDF/A 添付ファイルのみを許可し、PDF/A-3 は Excel ワークブックを含むその他のファイルタイプを許可します。これらは標準の要件であり、Aspose.Slides 固有の制限ではありません。この例はデフォルトの PDF コンプライアンス設定を使用しており、PDF/A エクスポートは示していません。
{{% /alert %}}

### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれる場合、[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) クラスのカスタムオプションである [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) プロパティを使用して、Aspose.Slides に非表示スライドを生成される PDF のページとして含めるよう指示できます。

以下の例は、非表示スライドを含めてプレゼンテーションを PDF にエクスポートします。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **パスワード保護付き PDF に PowerPoint を変換**

以下の例は、開く際にパスワード `password` が必要な PDF にプレゼンテーションをエクスポートします。アクセス権限は印刷（高品質印刷を含む）を許可しています。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **専用の太字フォントがないフォントの処理**

プレゼンテーションでは、フォントに専用の太字体がなくてもテキストに太字書式を適用できます。この場合、合成太字（synthetic bolding）により通常の字形を人工的に太くして太字に見せます。PDF でそのテキストが重すぎる、または期待する外観と異なる場合は、[PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) を `True` に設定してみてください。このオプションは PDF エクスポート時に該当テキストをビットマップとしてレンダリングし、特定のフォントで外観を改善できます。デフォルト値は `False` です。

サンプルのプレゼンテーションには、通常テキストと、同じフォントで太字書式が適用されたテキストの 2 つのテキストボックスが含まれています。そのフォントには専用の太字体がありません。以下の例はプレゼンテーションを読み込み、サポートされていないフォントスタイルのラスター化を有効にして PDF にエクスポートします。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

以下のプレビューは、オプション無効時と有効時の出力を示しています。この例では、オプションが無効の場合、太字テキストの線が太くなります。オプションを有効にすると、線が細くなり、通常テキストは変わりません。設定を選択する前に結果を比較してください。

| オプション無効 (`False`, デフォルト) | オプション有効 (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

この例では、オプションを有効にすると太字テキストだけがビットマップに変換されます。そのため、OCR なしでは選択・コピー・検索ができず、800% のズーム時にエッジがやわらかく表示されます。通常テキストは検索可能なままです。オプションが無効の場合、両方の文字列はテキストとして残ります。

このオプションは、フォントに専用の太字体がない場合に、太字で書式設定されたテキストをラスター化します。[Font substitution](/slides/ja/python-net/font-substitution/) は、元のフォントが利用できないときに別のフォントを選択します。

## **PowerPoint の選択スライドを PDF に変換**

以下の例は、プレゼンテーションからスライド 1 と 3 を抽出して PDF にエクスポートします。この配列のスライド番号は 1 から始まり、入力プレゼンテーションは少なくとも 3 枚のスライドを含んでいる必要があります。

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **カスタムスライドサイズで PowerPoint を PDF に変換**

以下の例は、プレゼンテーションの最初のスライドを 612 × 792 ポイント（8.5 × 11 インチ）のスライドサイズを持つ新しいプレゼンテーションにコピーします。スライド内容をフィットするように拡大縮小し、単一スライドを PDF にエクスポートします。

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # 新しいプレゼンテーションが作成されたときにできる空白スライドを削除します。
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **ノートスライド表示で PowerPoint を PDF に変換**

以下の例は、プレゼンテーションを PDF にエクスポートし、各スライドのスライドノートをスライドの下に配置します。スライドノートを含むプレゼンテーションを使用して結果を確認してください。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **PDF のアクセシビリティとコンプライアンス基準**

Aspose.Slides は、[Web コンテンツアクセシビリティガイドライン (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。これらのコンプライアンス基準のいずれかを用いて PowerPoint 文書を PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

この Python コードは、異なるコンプライアンス基準に基づく複数の PDF を取得する PowerPoint から PDF への変換操作を示しています：

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
Aspose.Slides の PDF 変換機能により、PDF を最も一般的なファイル形式に変換できます。[PDF を HTML に変換](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)、[PDF を画像に変換](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)、[PDF を JPG に変換](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/)、[PDF を PNG に変換](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) が可能です。その他の専門的な形式への PDF 変換操作として、[PDF を SVG に変換](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)、[PDF を TIFF に変換](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/)、[PDF を XML に変換](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) もサポートされています。
{{% /alert %}}

> **Note:** PDF/UA へのエクスポート時、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個々のパス要素は別々のコンテンツとして保持されず、アーティファクトとしてマークされることがあります。代替テキストは図全体に対してのみ提供されます。

## **よくある質問**

**Aspose.Slides for Python は PDF からアプリケーション情報を削除できますか？**

いいえ、Aspose.Slides for Python は出力 PDF に API 情報とバージョン番号を自動的に含めます。この情報は変更も削除もできません。

**PDF 変換で特定のスライドだけを含めるにはどうすればよいですか？**

変換したいスライドのインデックスを、[save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) メソッドにスライド位置の配列として渡すことで指定できます。

**変換時に PDF にパスワード保護を設定できますか？**

はい、プレゼンテーションを PDF として保存する前に、[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) クラスを使用してパスワードを設定し、アクセス権限を定義できます。

**Aspose.Slides は PDF を他の形式に変換することをサポートしていますか？**

はい、Aspose.Slides は PDF を HTML、画像形式（JPG、PNG）、SVG、TIFF、XML などの形式に変換することをサポートしています。

**PDF がアクセシビリティ基準に準拠していることを確認するにはどうすればよいですか？**

アクセシビリティガイドラインへの準拠を確保するには、[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) の [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) プロパティを `PDF_A1A`、`PDF_A1B`、または `PDF_UA` などの基準に設定します。

**PDF 出力に非表示スライドを含めることはできますか？**

はい、[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) の [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) プロパティを `True` に設定することで、非表示スライドが PDF に含まれます。

**変換時に画像の品質と解像度を調整するにはどうすればよいですか？**

画像品質と解像度を制御するには、[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) の [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) および [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) プロパティを使用します。

**Aspose.Slides はフォント置換を自動的に処理しますか？**

Aspose.Slides は変換時にフォント置換を検出し、`SaveOptions` の `warning_callback` プロパティを使用して処理できます（現在は制限あり）。

## **追加リソース**

- [Aspose.Slides for Python via .NET ドキュメント](/slides/ja/python-net/)
- [Aspose.Slides API リファレンス](https://reference.aspose.com/slides/python-net/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)