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
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ で PowerPoint の PPT/PPTX を高品質かつ検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---

## **概要**

PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を C++ で PDF 形式に変換すると、さまざまなメリットがあります。デバイス間の互換性やプレゼンテーションのレイアウトと書式を保持できることなどです。本ガイドでは、プレゼンテーションを PDF 文書に変換する方法、画像品質を制御するさまざまなオプションの使用方法、非表示スライドの含め方、PDF ファイルへのパスワード保護、フォント置換の検出、変換対象スライドの選択、出力文書への準拠基準の適用方法を示します。

## **PowerPoint から PDF への変換**

以下の形式のプレゼンテーションを Aspose.Slides を使用して PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスに渡し、`Save` メソッドを使用して PDF として保存します。[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される `Save` メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for C++ は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換する際、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値を設定します。**注意**：この情報を出力ドキュメントから変更または削除するように指示することはできません。
{{% /alert %}}

Aspose.Slides では、次の変換が可能です：

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションとほぼ同一になるよう保証します。変換では、次の要素と属性が正確にレンダリングされます。

* 画像
* テキストボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準的な PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は提供されたプレゼンテーションを最大品質レベルの最適設定で PDF に変換しようとします。

この C++ コードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示しています。
```c++
// PowerPointまたはOpenDocumentファイルを表すPresentationクラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// プレゼンテーションをPDFとして保存します。
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```


{{%  alert  color="primary"  %}} 
Aspose は、プレゼンテーションから PDF への変換プロセスを実演する無料のオンライン **PowerPoint to PDF コンバータ** を提供しています。このコンバータでテストを実行すれば、本稿で説明した手順を実際に試すことができます。
{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスのプロパティとして提供されるカスタムオプションを提供し、結果の PDF をカスタマイズしたり、パスワードでロックしたり、変換プロセスの進め方を指定したりできます。

### **カスタムオプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI 設定などを指定できます。

以下のコード例は、いくつかのカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```c++
// PdfOptions クラスのインスタンスを作成します。
auto pdfOptions = MakeObject<PdfOptions>();

// JPG 画像の品質を設定します。
pdfOptions->set_JpegQuality(90);

// 画像の DPI を設定します。
pdfOptions->set_SufficientResolution(300);

// メタファイルの処理方法を設定します。
pdfOptions->set_SaveMetafilesAsPng(true);

// テキストコンテンツの圧縮レベルを設定します。
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// PDF のコンプライアンスモードを定義します。
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// プレゼンテーションを PDF ドキュメントとして保存します。
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **非表示スライド付きで PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれる場合、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスの [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) メソッドを使用して、非表示スライドを結果の PDF のページとして含めることができます。

この C++ コードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```c++
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions クラスのインスタンスを作成します。
auto pdfOptions = MakeObject<PdfOptions>();

// 非表示スライドを追加します。
pdfOptions->set_ShowHiddenSlides(true);

// プレゼンテーションを PDF として保存します。
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **パスワード保護付き PDF に PowerPoint を変換**

この C++ コードは、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています。
```c++
// PowerPointまたはOpenDocumentファイルを表すPresentationクラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptionsクラスのインスタンスを作成します。
auto pdfOptions = MakeObject<PdfOptions>();

// PDFのパスワードとアクセス許可を設定します。
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// プレゼンテーションをPDFとして保存します。
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **フォント置換の検出**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスの下にある [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) メソッドを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できるようにします。

この C++ コードは、フォント置換を検出する方法を示しています。
```c++
// 警告コールバックの実装。
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss && 
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // PDF オプションに警告コールバックを設定します。
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // プレゼンテーションを PDF として保存します。
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```


{{%  alert color="primary"  %}} 
レンダリングプロセス中のフォント置換に対するコールバック取得に関する詳細は、[Getting Warning Callbacks for Fonts Substitution](/slides/ja/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) を参照してください。

フォント置換に関する詳細は、[Font Substitution](/slides/ja/cpp/font-substitution/) 記事をご覧ください。
{{% /alert %}} 

## **PowerPoint から選択したスライドを PDF に変換**

この C++ コードは、PowerPoint プレゼンテーションから特定のスライドのみを PDF に変換する方法を示しています。
```C++
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// スライド番号の配列を設定します。
auto slides = MakeArray<int32_t>({ 1, 3 });

// プレゼンテーションを PDF として保存します。
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```


## **カスタムスライドサイズで PowerPoint を PDF に変換**

この C++ コードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```


## **ノートスライドビューで PowerPoint を PDF に変換**

この C++ コードは、ノートを含む PDF に PowerPoint プレゼンテーションを変換する方法を示しています。
```C++
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Configure the PDF options with Notes Layout.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to a PDF with notes.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


## **PDF のアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できるようにします。これらのコンプライアンス標準のいずれか（**PDF/A1a**、**PDF/A1b**、**PDF/UA**）を使用して、PowerPoint ドキュメントを PDF にエクスポートできます。

この C++ コードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています。
```C++
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


{{% alert title="Note" color="warning" %}} 
Aspose.Slides は PDF 変換操作をサポートしており、PDF ファイルを一般的なファイル形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) 変換を実行できます。また、[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) といった専門的な形式への PDF 変換もサポートされています。
{{% /alert %}}

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルを PDF にバッチ変換することをサポートしています。ファイルをループ処理して、プログラムで変換プロセスを適用できます。

**変換された PDF にパスワード保護を設定できますか？**

もちろんです。変換プロセス中に [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスを使用してパスワードを設定し、アクセス許可を定義できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスの `set_ShowHiddenSlides` メソッドを使用して、結果の PDF に非表示スライドを含めます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) クラスの `set_JpegQuality` や `set_SufficientResolution` などのメソッドを使用して、PDF の画像品質を高く保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠した PDF のエクスポートを可能にし、アクセシビリティとアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for C++ ドキュメント](/slides/ja/cpp/)
- [Aspose.Slides for C++ API リファレンス](https://reference.aspose.com/slides/cpp/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)