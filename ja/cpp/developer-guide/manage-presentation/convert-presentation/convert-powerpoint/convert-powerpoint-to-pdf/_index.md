---
title: C++でPPTおよびPPTXをPDFに変換（高度な機能を含む）
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
description: "Aspose.Slides を使用して、C++で PowerPoint の PPT/PPTX を高品質かつ検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---

## **概要**

C++でPowerPointプレゼンテーション（PPT、PPTX、ODPなど）をPDF形式に変換すると、さまざまなデバイス間での互換性やプレゼンテーションのレイアウトと書式を保持できるなど、いくつかの利点があります。本ガイドでは、プレゼンテーションをPDFドキュメントに変換する方法、画像品質を制御するさまざまなオプションの使用、非表示スライドの含め方、PDFファイルのパスワード保護、フォント置換の検出、変換対象の特定スライドの選択、出力ドキュメントへのコンプライアンス標準の適用方法を示します。

## **PowerPointからPDFへの変換**

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションをPDFに変換するには、ファイル名を引数として[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスに渡し、`Save`メソッドを使用してプレゼンテーションをPDFとして保存します。[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスは、通常プレゼンテーションをPDFに変換するために使用される`Save`メソッドを提供しています。

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for C++は、出力ドキュメントにAPI情報とバージョン番号を挿入します。たとえば、プレゼンテーションをPDFに変換する際、Aspose.SlidesはApplicationフィールドに「*Aspose.Slides*」を、PDF Producerフィールドに「*Aspose.Slides v XX.XX*」形式の値を設定します。**Note**この情報を出力ドキュメントから変更または削除するようにAspose.Slidesに指示することはできません。
{{% /alert %}}

Aspose.Slidesでは次の変換が可能です：

* プレゼンテーション全体をPDFに変換
* プレゼンテーションから特定のスライドをPDFに変換

Aspose.SlidesはプレゼンテーションをPDFにエクスポートし、生成されたPDFが元のプレゼンテーションとほぼ同一になるよう保証します。変換時に正確にレンダリングされる要素と属性は以下のとおりです：

* 画像
* テキストボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPointをPDFに変換**

標準のPowerPointからPDFへの変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slidesは最高品質レベルの最適な設定を使用して提供されたプレゼンテーションをPDFに変換しようとします。

このC++コードは、プレゼンテーション（PPT、PPTX、ODPなど）をPDFに変換する方法を示します：
```c++
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// プレゼンテーションを PDF として保存します。
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```


{{%  alert  color="primary"  %}} 
Asposeは、プレゼンテーションからPDFへの変換プロセスを示す無料のオンライン**PowerPoint to PDF converter**(https://products.aspose.app/slides/conversion/ppt-to-pdf)を提供しています。このコンバータでテストを実行し、ここで説明した手順を実際に実装できます。
{{% /alert %}}

## **オプション付きでPowerPointをPDFに変換**

Aspose.Slidesは、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)クラスのプロパティとしてカスタムオプションを提供し、生成されたPDFをカスタマイズしたり、パスワードでロックしたり、変換プロセスの進行方法を指定したりできます。

### **カスタムオプションでPowerPointをPDFに変換**

カスタム変換オプションを使用すると、ラスタ画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像のDPI設定などを自由に定義できます。

以下のコード例は、複数のカスタムオプションを使用してPowerPointプレゼンテーションをPDFに変換する方法を示します。
```c++
// PdfOptions クラスのインスタンスを作成します。
auto pdfOptions = MakeObject<PdfOptions>();

// JPG 画像の品質を設定します。
pdfOptions->set_JpegQuality(90);

// 画像の DPI を設定します。
pdfOptions->set_SufficientResolution(300);

// メタファイルの動作を設定します。
pdfOptions->set_SaveMetafilesAsPng(true);

// テキストコンテンツの圧縮レベルを設定します。
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// PDF コンプライアンスモードを定義します。
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// プレゼンテーションを PDF ドキュメントとして保存します。
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **非表示スライド付きでPowerPointをPDFに変換**

プレゼンテーションに非表示スライドが含まれる場合、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)クラスの[set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/)メソッドを使用して、非表示スライドを生成されたPDFのページとして含めることができます。

このC++コードは、非表示スライドを含めてPowerPointプレゼンテーションをPDFに変換する方法を示します：
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


### **パスワード保護されたPDFにPowerPointを変換**

このС++コードは、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)クラスの保護パラメータを使用して、PowerPointプレゼンテーションをパスワード保護されたPDFに変換する方法を示します：
```c++
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions クラスのインスタンスを作成します。
auto pdfOptions = MakeObject<PdfOptions>();

// PDF のパスワードとアクセス権限を設定します。
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// プレゼンテーションを PDF として保存します。
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **フォント置換の検出**

Aspose.Slidesは、[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)クラスの下にある[set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/)メソッドを提供し、プレゼンテーションからPDFへの変換プロセス中にフォント置換を検出できるようにします。

このC++コードは、フォント置換を検出する方法を示します：
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
レンダリングプロセス中にフォント置換のコールバックを受け取る方法の詳細については、[Getting Warning Callbacks for Fonts Substitution](/slides/ja/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)をご覧ください。

フォント置換の詳細については、[Font Substitution](/slides/ja/cpp/font-substitution/)の記事をご参照ください。
{{% /alert %}} 

## **PowerPointから選択したスライドのみをPDFに変換**

このC++コードは、PowerPointプレゼンテーションから特定のスライドだけをPDFに変換する方法を示します：
```C++
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// スライド番号の配列を設定します。
auto slides = MakeArray<int32_t>({ 1, 3 });

// プレゼンテーションを PDF として保存します。
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```


## **カスタムスライドサイズでPowerPointをPDFに変換**

このC++コードは、指定したスライドサイズでPowerPointプレゼンテーションをPDFに変換する方法を示します：
```C++
auto slideWidth = 612;
auto slideHeight = 792;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// スライドサイズを調整した新しいプレゼンテーションを作成します。
auto resizedPresentation = MakeObject<Presentation>();

// カスタムスライドサイズを設定します。
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// 元のプレゼンテーションから最初のスライドをクローンします。
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// リサイズされたプレゼンテーションをノート付き PDF として保存します。
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```


## **ノートスライドビューでPowerPointをPDFに変換**

このC++コードは、ノートを含むPDFにPowerPointプレゼンテーションを変換する方法を示します：
```C++
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Notes レイアウトで PDF オプションを構成します。
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// プレゼンテーションをノート付き PDF として保存します。
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


## **PDFのアクセシビリティとコンプライアンス標準**

Aspose.Slidesは、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。以下のコンプライアンス標準のいずれかを使用して、PowerPointドキュメントをPDFにエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

このC++コードは、異なるコンプライアンス標準に基づいて複数のPDFを生成するPowerPointからPDFへの変換プロセスを示します：
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
Aspose.SlidesはPDF変換操作をサポートしており、PDFファイルを一般的なフォーマットに変換できます。[PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) の変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) といった専門フォーマットへの変換もサポートされています。
{{% /alert %}}

## **FAQ**

**複数のPowerPointファイルを一括でPDFに変換できますか？**

はい、Aspose.Slidesは複数のPPTまたはPPTXファイルをPDFにバッチ変換することをサポートしています。ファイルを反復処理し、プログラムで変換プロセスを適用できます。

**変換されたPDFにパスワードを設定できますか？**

もちろんです。[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)クラスを使用して、変換プロセス中にパスワードとアクセス許可を設定できます。

**PDFに非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)クラスの`set_ShowHiddenSlides`メソッドを使用して、非表示スライドを生成されたPDFに含めることができます。

**Aspose.SlidesはPDFの画像品質を高く保てますか？**

はい、`set_JpegQuality`や`set_SufficientResolution`などのメソッドを[PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)クラスで使用して、PDF内の画像品質を高く保つことができます。

**Aspose.SlidesはPDF/Aのコンプライアンス標準をサポートしていますか？**

はい、Aspose.SlidesはPDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠したPDFのエクスポートをサポートしており、アクセシビリティとアーカイブ要件を満たすことができます。

## **Additional Resources**

- [Aspose.Slides for C++ Documentation](/slides/ja/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)