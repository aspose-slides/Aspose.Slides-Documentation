---
title: C++ で PPT と PPTX を PDF に変換 [高度な機能を含む]
linktitle: PowerPoint を PDF に変換
type: docs
weight: 40
url: /ja/cpp/convert-powerpoint-to-pdf/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PowerPoint を PDF に変換
- プレゼンテーションを PDF に変換
- PPT を PDF に変換
- PPT を PDF に変換
- PPTX を PDF に変換
- PPTX を PDF に変換
- PowerPoint を PDF として保存
- PPT を PDF として保存
- PPTX を PDF として保存
- PPT を PDF にエクスポート
- PPTX を PDF にエクスポート
- 添付ファイル
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ で PowerPoint PPT/PPTX を高品質で検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---
## **概要**

C++ で PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換すると、デバイス間の互換性が向上し、プレゼンテーションのレイアウトや書式設定を保持できるなど、さまざまな利点があります。本ガイドでは、プレゼンテーションを PDF 文書に変換する方法、画像品質を制御するオプションの使用方法、非表示スライドの含め方、PDF ファイルのパスワード保護、フォント置換の検出、特定スライドの選択変換、出力文書へのコンプライアンス標準の適用方法を実演します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスに渡し、[Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) メソッドで PDF として保存します。[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) メソッドを公開しています。

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ は API 情報とバージョン番号を出力文書に挿入します。たとえば、プレゼンテーションを PDF に変換する際、Application フィールドに "*Aspose.Slides*"、PDF Producer フィールドに "*Aspose.Slides v XX.XX*" 形式の値が設定されます。**Note** として、この情報を出力文書から変更または削除することはできません。
{{% /alert %}}

Aspose.Slides は次の変換をサポートします。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションから特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、結果の PDF が元のプレゼンテーションに極めて近い形になるよう保証します。変換時に正確にレンダリングされる要素と属性には、次が含まれます。

* 画像
* テキスト ボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最高品質レベルで最適な設定を使用して提供されたプレゼンテーションを PDF に変換しようとします。

次の例はプレゼンテーションを読み込み、デフォルトのエクスポート設定で表示中のすべてのスライドを PDF に保存します。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose は無料のオンライン [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しており、プレゼンテーションから PDF への変換プロセスをデモします。このコンバータでテストを実行すると、ここで説明する手順を実際に確認できます。
{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラス配下のカスタムオプション（プロパティ）を提供し、生成される PDF のカスタマイズ、PDF のパスワード保護、変換プロセスの制御が可能です。

### **カスタムオプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスタ画像の品質設定、メタファイルの取り扱い方法、テキストの圧縮レベル、画像の DPI などを指定できます。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **画像圧縮の自動選択**

プレゼンテーションに多数の写真やスクリーンショットが含まれる場合、エクスポートされた PDF のサイズを縮小することでメールやダウンロードが容易になります。[PdfOptions::set_BestImagesCompressionRatio](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_bestimagescompressionratio/) を `true` で呼び出すと、PDF エクスポート時に各画像に最適な圧縮アルゴリズムが自動的に選択されます。

次の例は既存のプレゼンテーションを読み込み、自動画像圧縮選択を有効にして PDF 文書として保存します。他の PDF エクスポート設定はデフォルト値を保持します。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_BestImagesCompressionRatio(true);

auto presentation = MakeObject<Presentation>(u"image-heavy.pptx");
presentation->Save(u"image-heavy.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

このオプションは画像ごとに圧縮アルゴリズムを選択します。[set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) で JPEG 品質を下げると画像品質が低下し、[set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) で解像度を下げると画像が低解像度にダウンサンプリングされ、ディテールが減少します。自動圧縮選択を有効にしてもこれらの設定は自動的に下げられません。

画像圧縮アルゴリズムの選択には追加の処理時間とメモリが必要です。サイズ削減はプレゼンテーションの画像やエクスポート設定に依存し、すべてのプレゼンテーションで一定の削減が保証されるわけではありません。

### **埋め込み OLE ファイルを PDF 添付ファイルとして保持**

プレゼンテーションに埋め込みの Excel ワークブックが含まれる場合、PDF の受取人がスライドだけでなくワークブックのデータにもアクセスできるようにしたいことがあります。[PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) を `true` で呼び出すと、埋め込み OLE ファイルが結果の PDF に添付ファイルとして保持されます。

デフォルトは `false` で、OLE オブジェクトのプレビュー画像またはアイコンは PDF ページに描画されますが、埋め込みファイル自体は添付されません。`true` に設定するとファイルデータも添付されます。プレビューは視覚的表現のままで、添付ファイルにより受取人は埋め込みファイルを別途開いたり保存したりできます。OLE オブジェクトが PDF ページ上でインタラクティブな Excel ワークシートになることはありません。

次の例は既に埋め込み Excel ワークブックを含むプレゼンテーションを読み込み、ワークブックを添付した状態で PDF にエクスポートします。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

結果を確認する方法:

1. 添付ファイルに対応したビューア（例: Adobe Acrobat Reader）でエクスポートされた PDF を開きます。
2. ビューアの **Attachments** パネルを開き、埋め込みワークブックを探します。
3. 添付ファイルを保存し、Excel で開いてデータを確認するか、ビューアが許可すれば直接開きます。PDF ページ上のプレビューは添付ファイルとは別物です。

{{% alert color="info" title="Note" %}}
PDF/A 標準は添付ファイルに制限を課しています。PDF/A-1 は埋め込みファイルを禁止し、PDF/A-2 は PDF/A 添付のみを許可し、PDF/A-3 は Excel ワークブックを含むその他のファイルタイプを許可します。これらは標準自体の要件であり、Aspose.Slides 固有の制限ではありません。本例はデフォルトの PDF コンプライアンス設定を使用しており、PDF/A エクスポートは示していません。
{{% /alert %}}

### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれる場合、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスの [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) メソッドを使用して、非表示スライドを PDF のページとして含めることができます。

次の例は非表示スライドを含めてプレゼンテーションを PDF にエクスポートします。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **パスワード保護された PDF に変換**

次の例はパスワード `password` が必要な PDF にプレゼンテーションをエクスポートします。アクセス権限は印刷を許可し、高品質印刷も可能です。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **フォント置換の検出**

Aspose.Slides は [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラス配下の [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) メソッドを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できます。

次の例はプレゼンテーションを PDF にエクスポートし、コンソールにフォント置換警告を出力します。利用できないフォントが置換されたときのみ警告が表示されます。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
フォント置換の詳細については、[Font Substitution](/slides/ja/cpp/font-substitution/) 記事をご参照ください。
{{% /alert %}} 

### **専用の太字フォントがない場合の処理**

フォントに専用の太字書体が存在しなくても、プレゼンテーションはテキストに太字書式を適用できます。合成太字により通常のグリフが人工的に太く表示されますが、PDF で見たときに文字が重すぎる、または意図した見た目と異なる場合は、[PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) を `true` で呼び出してみてください。このオプションは PDF エクスポート時に対象テキストをビットマップとして描画し、特定のフォントで見た目を改善できる場合があります。デフォルトは `false` です。

サンプルプレゼンテーションには、通常テキストと同じフォントで太字書式が適用されたテキストボックスが二つ含まれています（このフォントには専用の太字書体がありません）。次の例はプレゼンテーションを読み込み、サポートされていないフォントスタイルのラスタライズを有効にして PDF にエクスポートします。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

以下のプレビューはオプション無効時と有効時の出力を示します。この例では、オプションが無効な場合は太字テキストのストロークが太く表示されます。オプションを有効にするとストロークが細くなり、通常テキストは変わりません。設定を選択する前に結果を比較してください。

| オプション無効 (`false`、デフォルト) | オプション有効 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

この例では、オプションを有効にすると太字テキストだけがビットマップ化され、OCR なしでは選択・コピー・検索ができず、800% ズーム時にエッジが柔らかく表示されます。通常テキストは検索可能なままです。オプションが無効の場合、両方の文字列はテキストとして扱われます。

このオプションは、専用の太字書体がないフォントで太字書式が付いたテキストをラスタライズします。[Font substitution](/slides/ja/cpp/font-substitution/) は、元のフォントが利用できない場合に別のフォントを選択します。

## **プレゼンテーションから選択したスライドを PDF に変換**

次の例はプレゼンテーションからスライド 1 とスライド 3 を抽出し、PDF にエクスポートします。この配列のスライド番号は 1 起算で、入力プレゼンテーションは最低でも 3 枚のスライドを含んでいる必要があります。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **カスタムスライドサイズで PowerPoint を PDF に変換**

次の例はプレゼンテーションの最初のスライドを、スライドサイズ 612 × 792 ポイント（8.5 × 11 インチ）の新しいプレゼンテーションにコピーし、スライド内容をフィットさせて単一スライドを PDF にエクスポートします。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **ノートスライドビューで PowerPoint を PDF に変換**

次の例はプレゼンテーションを PDF にエクスポートし、各スライドのスピーカー ノートをスライドの下に配置します。結果を確認するには、スピーカー ノートを含むプレゼンテーションを使用してください。

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **PDF のアクセシビリティとコンプライアンス標準**

Aspose.Slides は [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を利用できます。次のコンプライアンス標準のいずれかを使用して PowerPoint 文書を PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

この C++ コードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose.Slides は PDF 変換機能をサポートしており、PDF ファイルを一般的な形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) の変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) などの専門フォーマットへの変換もサポートされています。
{{% /alert %}}

> **Note:** PDF/UA にエクスポートする場合、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックスを単一の図として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされることがあります。代替テキストは全体の図に対してのみ提供されます。

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチで PDF に変換することをサポートしています。ファイルを列挙してプログラム的に変換プロセスを適用できます。

**変換された PDF にパスワードを設定できますか？**

はい。変換プロセス中に [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスを使用してパスワードとアクセス許可を設定できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスの [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) メソッドを使用して、結果の PDF に非表示スライドをページとして含められます。

**Aspose.Slides は PDF の画像品質を高く保つことができますか？**

はい。[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスの [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) や [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) メソッドを使用して、PDF 内の画像品質を高く保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠した PDF のエクスポートをサポートし、文書がアクセシビリティとアーカイブ要件を満たすようにできます。

## **追加リソース**

- [Aspose.Slides for C++ Documentation](/slides/ja/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)