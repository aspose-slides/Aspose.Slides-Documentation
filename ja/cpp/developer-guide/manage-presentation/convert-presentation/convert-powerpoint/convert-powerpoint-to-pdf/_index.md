---
title: C++ で PPT および PPTX を PDF に変換（高度な機能を含む）
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
- 添付
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ で PowerPoint PPT/PPTX を高品質で検索可能な PDF に変換し、迅速なコード例と高度な変換オプションを提供します。"
---
## **概要**

C++ で PowerPoint プレゼンテーション（PPT、PPTX、ODP など） を PDF 形式に変換すると、デバイス間の互換性やプレゼンテーションのレイアウト・書式を保持できるなど、さまざまなメリットがあります。本ガイドでは、プレゼンテーションを PDF に変換する方法、画像品質を制御するオプションの使用方法、非表示スライドの含め方、PDF ファイルのパスワード保護、フォント置換の検出、特定スライドの選択変換、そして出力ドキュメントへのコンプライアンス標準の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスに渡し、[Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) メソッドで PDF として保存します。 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) メソッドを公開しています。

{{% alert color="info" title="注" %}}

Aspose.Slides for C++ は API 情報とバージョン番号を出力ドキュメントに挿入します。たとえば、プレゼンテーションを PDF に変換すると、Application フィールドに「*Aspose.Slides*」が、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値が設定されます。**注**：この情報を出力ドキュメントから変更または削除することは指示できません。

{{% /alert %}}

Aspose.Slides では、次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、結果の PDF が元のプレゼンテーションとほぼ同一になるようにします。変換時に正確にレンダリングされる要素と属性は次のとおりです。

* 画像
* テキスト ボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最高品質レベルで最適な設定を用いて、提供されたプレゼンテーションを PDF に変換しようとします。

以下の例はプレゼンテーションを読み込み、デフォルトのエクスポート設定で表示スライドすべてを PDF に保存します。

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

{{% alert color="info" title="注" %}}

Aspose は、プレゼンテーションから PDF への変換プロセスをデモンストレーションする無料のオンライン [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。このコンバータで手順を実際にテストできます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラス配下のプロパティとしてカスタムオプションを提供し、生成される PDF のカスタマイズ、パスワード保護、変換プロセスの制御が行えます。

### **カスタムオプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI などを指定できます。

以下の例は、PDF 1.5 形式で JPEG 品質 90、画像解像度 300 DPI、メタファイルを PNG として保存し、Flate テキスト圧縮を適用してプレゼンテーションをエクスポートします。

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

### **埋め込み OLE ファイルを PDF 添付ファイルとして保持**

プレゼンテーションに埋め込みの Excel ワークブックが含まれている場合、PDF の受信者がスライドだけでなくワークブックのデータにもアクセスできるようにしたいことがあります。`true` を指定して [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) を呼び出すと、埋め込み OLE ファイルが PDF の添付ファイルとして保持されます。

デフォルトは `false` で、OLE オブジェクトのプレビュー画像またはアイコンは PDF ページに描画されますが、埋め込みファイルは添付されません。`true` に設定するとファイルデータも添付されます。プレビューは視覚的表現のままで、添付は受信者がファイルを別途開いたり保存したりできるようにします。OLE オブジェクトが PDF ページ上でインタラクティブな Excel ワークシートになることはありません。

以下の例は、既に埋め込み Excel ワークブックを含むプレゼンテーションを読み込み、ワークブックを添付した状態で PDF にエクスポートします。

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

結果を確認する手順:

1. 添付ファイルに対応したビューア（例: Adobe Acrobat Reader）でエクスポートされた PDF を開く。
2. ビューアの **Attachments** パネルを開き、埋め込みワークブックを探す。
3. 添付ファイルを保存し、Excel で開いてデータを確認するか、ビューアが許可すれば直接開く。PDF ページ上のプレビューは添付とは別物です。

{{% alert color="info" title="注" %}}

PDF/A 標準は添付ファイルに制限を課します。PDF/A-1 は埋め込みファイルを禁止し、PDF/A-2 は PDF/A 添付ファイルのみを許可し、PDF/A-3 は Excel ワークブックを含むその他のファイルタイプを許可します。これらは標準の要件であり、Aspose.Slides 固有の制限ではありません。本例はデフォルトの PDF コンプライアンス設定を使用しており、PDF/A エクスポートは示していません。

{{% /alert %}}

### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれる場合、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスの [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) メソッドを使用して、非表示スライドを PDF のページとして含めることができます。

以下の例は、非表示スライドを含むプレゼンテーションを PDF にエクスポートします。

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

### **パスワード保護された PDF に PowerPoint を変換**

以下の例は、パスワード `password` で開く必要がある PDF にプレゼンテーションをエクスポートします。アクセス許可は印刷（高品質印刷を含む）を許可します。

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

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラス配下の [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) メソッドを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できます。

以下の例は、プレゼンテーションを PDF にエクスポートし、フォント置換の警告をコンソールに出力します。利用できないフォントが置換されたときだけ警告が出力されます。

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

{{% alert color="info" title="注" %}}

フォント置換の詳細については、[Font Substitution](/slides/ja/cpp/font-substitution/) 記事をご覧ください。

{{% /alert %}} 

### **太字フォントが存在しない場合の処理**

フォントに専用の太字字形がない場合でも、プレゼンテーションは太字書式を適用できます。これは合成太字により、通常の字形を人工的に太くすることで実現されます。PDF でテキストが重く見える、または意図した外観と異なる場合は、`true` を指定して [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) を呼び出してください。このオプションは、PDF エクスポート時に該当テキストをビットマップとして描画し、特定フォントの外観を改善できる場合があります。既定値は `false` です。

サンプルのプレゼンテーションには、通常テキストと同じフォントに太字書式を適用したテキストボックスが2つ含まれています。そのフォントには専用の太字字形がありません。以下の例はプレゼンテーションを読み込み、サポートされていないフォントスタイルのラスタライズを有効にして PDF にエクスポートします。

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

以下のプレビューは、オプションが無効な場合と有効な場合の出力を示します。この例では、オプションが無効のときは太字テキストのストロークが太くなります。オプションを有効にするとストロークが細くなり、通常テキストは変わりません。結果を比較して、プレゼンテーションに適した設定を選択してください。

| オプション無効 (`false`、既定) | オプション有効 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

この例では、オプションを有効にすると太字テキストだけがビットマップ化されます。OCR なしでは選択、コピー、検索ができず、800% ズーム時にエッジが柔らかく見えます。通常テキストは検索可能です。オプションを無効にすると、両方の文字列がテキストとして残ります。

このオプションは、フォントに専用の太字字形がない場合に太字テキストをラスタライズします。代わりに [Font substitution](/slides/ja/cpp/font-substitution/) は元のフォントが利用できないときに別のフォントを選択します。

## **選択したスライドだけを PowerPoint から PDF に変換**

以下の例は、プレゼンテーションからスライド 1 と 3 を選択し、PDF にエクスポートします。配列内のスライド番号は 1 から始まり、入力プレゼンテーションは少なくとも 3 枚のスライドを含んでいる必要があります。

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

以下の例は、プレゼンテーションの最初のスライドを新しいプレゼンテーションにコピーし、スライドサイズを 612 × 792 ポイント（8.5 × 11 インチ）に設定します。スライド内容を拡大縮小してフィットさせ、単一スライドを PDF にエクスポートします。

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

## **ノートスライド ビューで PowerPoint を PDF に変換**

以下の例は、プレゼンテーションを PDF にエクスポートし、各スライドのスピーカーノートをスライド下部に配置します。結果を見るには、スピーカーノートを含むプレゼンテーションを使用してください。

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

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかを使用して PowerPoint 文書を PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下の C++ コードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示します。

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

{{% alert color="info" title="注" %}}

Aspose.Slides は PDF 変換操作をサポートしており、PDF ファイルを一般的なファイル形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) の変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) といった特殊形式への変換もサポートしています。

{{% /alert %}}

> **注:** PDF/UA にエクスポートする際、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図形として扱います。個々のパス要素は別個のコンテンツとして保存されず、アーティファクトとしてマークされる可能性があります。代替テキストは全体の図形に対してのみ提供されます。

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチ変換して PDF に変換できます。ファイルを順に処理し、プログラムで変換プロセスを実行できます。

**変換した PDF にパスワード保護を設定できますか？**

はい。変換プロセス中に [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスを使用してパスワードとアクセス許可を設定できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスの [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) メソッドを使用して、結果の PDF に非表示スライドを含められます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい。[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスの [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) や [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) などのメソッドを使用して、PDF 内の画像品質を高く保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA など、さまざまな標準に準拠した PDF のエクスポートをサポートしており、アクセシビリティとアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for C++ Documentation](/slides/ja/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)