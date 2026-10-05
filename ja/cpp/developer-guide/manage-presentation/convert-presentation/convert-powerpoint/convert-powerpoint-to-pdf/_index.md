---
title: C++ で PPT と PPTX を PDF に変換（高度な機能を含む）
linktitle: PowerPoint を PDF に変換
type: docs
weight: 40
url: /ja/cpp/convert-powerpoint-to-pdf/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PowerPoint から PDF へ
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
description: "Aspose.Slides を使用して C++ で PowerPoint の PPT/PPTX を高品質かつ検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---
## **概要**

C++でPowerPointプレゼンテーション（PPT、PPTX、ODP など）をPDF形式に変換すると、さまざまな利点があります。デバイス間の互換性やプレゼンテーションのレイアウトと書式設定の保持が含まれます。このガイドでは、プレゼンテーションをPDFドキュメントに変換する方法、画像品質を制御するさまざまなオプションの使用、非表示スライドの含め方、PDFファイルのパスワード保護、フォント置換の検出、特定のスライドを選択して変換する方法、および出力ドキュメントにコンプライアンス基準を適用する方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slidesを使用して、以下の形式のプレゼンテーションをPDFに変換できます：

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションをPDFに変換するには、ファイル名を引数として[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスに渡し、次に[Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)メソッドを使用してPDFとして保存します。[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスは通常、プレゼンテーションをPDFに変換するために使用される[Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)メソッドを公開しています。

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ は API 情報とバージョン番号を出力ドキュメントに挿入します。たとえば、プレゼンテーションをPDFに変換する場合、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値を設定します。**注意** Aspose.Slides に対してこの情報を変更または削除するよう指示することはできません。
{{% /alert %}}

Aspose.Slidesを使用すると、次の変換が可能です：

* プレゼンテーション全体をPDFに変換
* プレゼンテーションから特定のスライドをPDFに変換

Aspose.SlidesはプレゼンテーションをPDFにエクスポートし、生成されたPDFが元のプレゼンテーションにできるだけ忠実になるよう保証します。変換時に正確にレンダリングされる要素と属性には次が含まれます：

* 画像
* テキスト ボックスと図形
* テキストの書式設定
* 段落の書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準のPowerPointからPDFへの変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最適な設定と最大品質レベルで提供されたプレゼンテーションをPDFに変換しようとします。

以下の例はプレゼンテーションを読み込み、デフォルトのエクスポート設定を使用してすべての表示スライドをPDFに保存します。

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
Aspose は、プレゼンテーションからPDFへの変換プロセスを実演する無料のオンライン[**PowerPoint を PDF に変換するコンバーター**](https://products.aspose.app/slides/conversion/ppt-to-pdf)を提供しています。このコンバーターでテストを実行すると、ここで説明した手順を実際に確認できます。
{{% /alert %}}

## **PowerPoint をオプション付きで PDF に変換**

Aspose.Slidesは、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)クラスのプロパティとしてカスタムオプションを提供し、生成されるPDFをカスタマイズしたり、パスワードでロックしたり、変換プロセスの動作方法を指定したりできます。

### **PowerPoint をカスタムオプションで PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI などを指定できます。

以下の例は、JPEG 品質を90、画像解像度を300 DPI、メタファイルを PNG として保存し、Flate テキスト圧縮を使用してPDF 1.5 にエクスポートします。

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

プレゼンテーションに埋め込みの Excel ワークブックが含まれている場合、PDF の受信者がスライドだけでなくワークブックのデータにもアクセスできるようにしたいことがあります。`true` を指定して [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) を呼び出すと、埋め込み OLE ファイルが結果の PDF に添付ファイルとして保持されます。

既定値は `false` です。OLE オブジェクトのプレビュー画像またはアイコンは PDF ページに描画されますが、埋め込みファイルは添付として含まれません。`true` に設定するとファイルデータも添付されます。プレビューは視覚的表現のままで、添付ファイルにより受信者は埋め込みファイルを個別に開いたり保存したりできます。OLE オブジェクト自体が PDF ページ上でインタラクティブな Excel ワークシートになることはありません。

以下の例は、すでに埋め込み Excel ワークブックを含むプレゼンテーションを読み込み、ワークブックを添付した状態で PDF にエクスポートします。

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

結果を確認する手順：

1. Adobe Acrobat Reader など、添付ファイルをサポートするビューアでエクスポートされた PDF を開きます。
2. ビューアの**Attachments**パネルを開き、埋め込みワークブックを見つけます。
3. 添付ファイルを保存し、Excel で開いてデータを確認するか、ビューアが許可していれば直接開きます。PDF ページ上のプレビューは添付ファイルとは別です。

{{% alert color="info" title="Note" %}}
PDF/A 標準は添付ファイルに制限を課します。PDF/A‑1 は埋め込みファイルを禁止し、PDF/A‑2 は PDF/A 添付ファイルのみを許可し、PDF/A‑3 は Excel ワークブックを含むその他のファイルタイプを許可します。これらは標準の要件であり、Aspose.Slides 固有の制限ではありません。この例は既定の PDF コンプライアンス設定を使用しており、PDF/A エクスポートは示していません。
{{% /alert %}}

### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスの [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) メソッドを使用して、非表示スライドを結果の PDF のページとして含めることができます。

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

以下の例は、開く際にパスワード `password` が必要な PDF にプレゼンテーションをエクスポートします。アクセス許可は印刷を許可し、高品質印刷も可能です。

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

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスの下にある [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) メソッドを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できるようにします。

以下の例は、プレゼンテーションを PDF にエクスポートし、フォント置換の警告をコンソールに出力します。利用できないフォントが置換されたときにのみ警告が出力されます。

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
フォント置換の詳細については、[フォント置換](/slides/ja/cpp/font-substitution/)記事をご参照ください。
{{% /alert %}} 

## **PowerPoint から選択したスライドを PDF に変換**

以下の例は、プレゼンテーションからスライド 1 と 3 を抽出して PDF にエクスポートします。この配列のスライド番号は 1 から始まり、入力プレゼンテーションは少なくとも 3 枚のスライドを含んでいる必要があります。

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

以下の例は、プレゼンテーションの最初のスライドを新しいプレゼンテーションにコピーし、スライドサイズを 612 × 792 ポイント（8.5 × 11 インチ）に設定します。スライド内容をフィットさせるように拡大縮小し、単一スライドを PDF にエクスポートします。

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

以下の例は、各スライドのスピーカーノートをスライドの下に配置してプレゼンテーションを PDF にエクスポートします。結果を確認するには、スピーカーノートを含むプレゼンテーションを使用してください。

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

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかを使用して PowerPoint ドキュメントを PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

この C++ コードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています：

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
Aspose.Slides は PDF 変換機能をサポートしており、PDF ファイルを一般的な形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) の変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) といった特殊フォーマットへの変換もサポートされています。
{{% /alert %}}

> **注意:** PDF/UA にエクスポートする場合、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされる可能性があります。代替テキストは全体の図に対してのみ提供されます。

## **よくある質問**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルを PDF にバッチ変換することをサポートしています。ファイルを順に走査し、プログラムから変換処理を適用できます。

**変換後の PDF にパスワードを設定できますか？**

はい。変換プロセス中に [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスを使用してパスワードを設定し、アクセス許可を定義できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスの [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) メソッドを使用して、結果の PDF に非表示スライドを含めることができます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい。[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスの [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) や [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) などのメソッドを使用して、PDF 内の画像を高品質に保つことができます。

**Aspose.Slides は PDF/A のコンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA など、さまざまな標準に準拠した PDF のエクスポートをサポートしており、アクセシビリティやアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for C++ ドキュメント](/slides/ja/cpp/)
- [Aspose.Slides for C++ API リファレンス](https://reference.aspose.com/slides/cpp/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)