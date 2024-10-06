---
title: PowerPointをC++でPDFに変換
linktitle: PowerPointをPDFに変換
type: docs
weight: 40
url: /ja/cpp/convert-powerpoint-to-pdf/
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
- C++
- Aspose.Slides for C++
description: "C++でPowerPointプレゼンテーションをPDFに変換します。準拠またはアクセシビリティ基準に従ってPowerPointをPDFとして保存します。"
---

## **概要**

PowerPointドキュメントをPDF形式に変換することには、さまざまなデバイスとの互換性を確保し、プレゼンテーションのレイアウトやフォーマットを保持するなどの利点があります。本記事では、プレゼンテーションをPDFドキュメントに変換する方法、画像品質を制御するためのさまざまなオプションの使用、非表示スライドの含め方、PDFドキュメントのパスワード保護、フォント置換の検出、変換するスライドの選択、および出力ドキュメントに準拠基準を適用する方法について説明します。

## **PowerPointからPDFへの変換**

Aspose.Slidesを使用すると、次の形式のプレゼンテーションをPDFに変換できます。

* PPT
* PPTX
* ODP

プレゼンテーションをPDFに変換するには、単に[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/)クラスの引数としてファイル名を渡し、次に[Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)メソッドを使用してプレゼンテーションをPDFとして保存します。[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/)クラスは、通常プレゼンテーションをPDFに変換するために使用される[Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)メソッドを公開しています。

{{%  alert title="注意"  color="warning"   %}} 

Aspose.Slides for C++は、出力ドキュメントにAPI情報とバージョン番号を直接書き込みます。たとえば、プレゼンテーションをPDFに変換する際、Aspose.Slides for C++はApplicationフィールドに'*Aspose.Slides*'の値を、PDF Producerフィールドに'*Aspose.Slides v XX.XX*'形式の値を設定します。 **注意**：Aspose.Slides for C++に出力ドキュメントからこの情報を変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slidesでは、以下の内容をPDFに変換できます：

* プレゼンテーション全体をPDFに
* プレゼンテーション内の特定のスライドをPDFに
* プレゼンテーション

Aspose.Slidesは、プレゼンテーションの内容が生成されたPDFと非常に類似になるように、PDFへのエクスポートを行います。以下の既知の要素と属性は、プレゼンテーションからPDFへの変換時に適切にレンダリングされることがよくあります：

* 画像
* テキストボックスおよび他の図形
* テキストとそのフォーマット
* 段落とそのフォーマット
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* テーブル

## **PowerPointをPDFに変換**

標準のPowerPoint PDF変換操作は、デフォルトオプションを使用して実行されます。この場合、Aspose.Slidesは提供されたプレゼンテーションを最大品質レベルの最適設定を使用してPDFに変換しようとします。

<a name="cpp-powerpoint-to-pdf" id="cpp-powerpoint-to-pdf"><strong>手順：C++でPowerPointをPDFに変換</strong></a> |
<a name="cpp-ppt-to-pdf" id="cpp-ppt-to-pdf"><strong>手順：C++でPPTをPDFに変換</strong></a> |
<a name="cpp-pptx-to-pdf" id="cpp-pptx-to-pdf"><strong>手順：C++でPPTXをPDFに変換</strong></a> |
<a name="cpp-odp-to-pdf" id="cpp-odp-to-pdf"><strong>手順：C++でODPをPDFに変換</strong></a>

このC++コードは、PowerPointをPDFに変換する方法を示しています：

```c++
// PowerPointファイルを表すPresentationクラスをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.ppt");

// プレゼンテーションをPDFとして保存
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
```

{{%  alert  color="primary"  %}} 

Asposeは、プレゼンテーションからPDFへの変換プロセスを示す無料のオンライン[**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf)を提供しています。ここで説明されている手順のライブ実装をテストすることができます。

{{% /alert %}}

## **オプションを使用してPowerPointをPDFに変換**

Aspose.Slidesは、PDFをカスタマイズするためのカスタムオプション—[PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/)クラスのプロパティを提供します。これにより、変換プロセスから生成されたPDFをカスタマイズしたり、パスワードでPDFをロックしたり、さらには変換プロセスを指定することができます。

### **カスタムオプションを使用してPowerPointをPDFに変換**

カスタム変換オプションを使用すると、ラスタ画像の品質設定を好みに設定したり、メタファイルの処理方法を指定したり、テキストの圧縮レベルを設定したり、画像のDPIを設定したりできます。

以下のコード例は、PowerPointプレゼンテーションを複数のカスタムオプションを使用してPDFに変換する操作を示しています。

```c++
// PdfOptionsクラスをインスタンス化
auto pdfOptions = System::MakeObject<PdfOptions>();

// JPG画像の品質を設定
pdfOptions->set_JpegQuality(90);

// 画像のDPIを設定
pdfOptions->set_SufficientResolution(300);

// メタファイルの動作を設定
pdfOptions->set_SaveMetafilesAsPng(true);

// テキストコンテンツの圧縮レベルを設定
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// PDF準拠モードを定義
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// PowerPointドキュメントを表すPresentationクラスをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// プレゼンテーションをPDFドキュメントとして保存
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **非表示スライドを含むPowerPointをPDFに変換**

プレゼンテーションに非表示スライドが含まれている場合、カスタムオプションである[ShowHiddenSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options#ad11e5a17110d70456df91cc1a5dade23)プロパティを使用して、Aspose.Slidesに出力PDFのページとして非表示スライドを含めるよう指示することができます。

このC++コードは、非表示スライドを含めてPowerPointプレゼンテーションをPDFに変換する方法を示しています：

```c++
// PowerPointファイルを表すPresentationクラスをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptionsクラスをインスタンス化
auto pdfOptions = System::MakeObject<PdfOptions>();

// 非表示スライドを追加
pdfOptions->set_ShowHiddenSlides(true);

// プレゼンテーションをPDFとして保存
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### **パスワード保護されたPDFにPowerPointを変換**

このC++コードは、PowerPointをパスワード保護されたPDFに変換する方法を示しています（[PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/)クラスの保護パラメータを使用）：

```c++
// PowerPointファイルを表すPresentationオブジェクトをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

/// PdfOptionsクラスをインスタンス化
auto pdfOptions = System::MakeObject<PdfOptions>();

// PDFパスワードとアクセス権限を設定
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// プレゼンテーションをPDFとして保存
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### **フォント置換の検出**

Aspose.Slidesは、[SaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/)クラスの[get_WarningCallback()](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/get_warningcallback/)メソッドを提供しており、プレゼンテーションからPDFへの変換プロセスでフォント置換を検出できるようにしています。

このC++コードは、フォント置換を検出する方法を示しています：

```c++
class FontSubstSendsWarningCallback : public Warnings::IWarningCallback
{
public:
    Warnings::ReturnAction Warning(System::SharedPtr<Warnings::IWarningInfo> warning) override;
};

Warnings::ReturnAction FontSubstSendsWarningCallback::Warning(System::SharedPtr<Warnings::IWarningInfo> warning)
{
    if (warning->get_WarningType() == Warnings::WarningType::CompatibilityIssue)
    {
        return Warnings::ReturnAction::Continue;
    }

    if (warning->get_WarningType() == Warnings::WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        System::Console::WriteLine(u"フォント置換警告: {0}", warning->get_Description());
    }

    return Warnings::ReturnAction::Continue;
}
```

次のC++コードは、前述のクラスを使用する方法を示しています：

```c++
int main()
{
    System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    System::SharedPtr<FontSubstSendsWarningCallback> warningCallback = System::MakeObject<FontSubstSendsWarningCallback>();
    loadOptions->set_WarningCallback(warningCallback);

    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);
    return 0;
}
```

{{%  alert color="primary"  %}} 

レンダリングプロセスにおけるフォント置換のコールバックを取得する方法についての詳細は、[フォント置換のための警告コールバックの取得](https://docs.aspose.com/slides/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)を参照してください。

フォント置換に関する詳細は、[フォント置換](https://docs.aspose.com/slides/cpp/font-substitution/)の記事をご覧ください。

{{% /alert %}} 

## **PowerPointの特定のスライドをPDFに変換**

このC++コードは、PowerPointの特定のスライドをPDFに変換する方法を示しています：

```C++
// PowerPointファイルを表すPresentationオブジェクトをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// スライドの位置の配列を設定
auto slides = System::MakeArray<int32_t>({1, 3});

// プレゼンテーションをPDFとして保存
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
```

## **カスタムスライドサイズでPowerPointをPDFに変換**

このC++コードは、スライドサイズが指定されたPowerPointをPDFに変換する方法を示しています：

```C++
// ドキュメントディレクトリへのパス
String dataDir = GetDataPath()

// PowerPointファイルを表すPresentationオブジェクトをインスタンス化 
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// スライドタイプとサイズを設定 
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```

## **ノートスライドビューでPowerPointをPDFに変換**

このC++コードは、PowerPointをノートとしてPDFに変換する方法を示しています：

```C++
// ドキュメントディレクトリへのパス
System::String dataDir = u"";

// PowerPointファイルを表すPresentationクラスをインスタンス化
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// プレゼンテーションをPDFノートとして保存
presentation->Save(dataDir + u"Pdf_Notes_out.tiff", SaveFormat::Pdf, pdfOptions);
```

## **PDFのアクセシビリティと準拠基準**

Aspose.Slidesでは、[Webコンテンツアクセシビリティガイドライン（**WCAG**）](https://www.w3.org/TR/WCAG-TECHS/pdf.html)に準拠した変換手順を使用できます。PowerPointドキュメントをPDFにエクスポートする際には、**PDF/A1a**、**PDF/A1b**、**PDF/UA**のいずれかの準拠基準を使用できます。

このC++コードは、異なる準拠基準に基づいて複数のPDFを取得するPowerPointからPDFへの変換操作を示しています：

```C++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = System::MakeObject<PdfOptions>();
pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
pres->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = System::MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
pres->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = System::MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);
pres->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);
```

{{% alert title="注意" color="warning" %}} 

Aspose.SlidesのPDF変換操作は、最も人気のあるファイル形式へのPDFの変換も可能です。[PDFをHTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)、[PDFを画像](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)、[PDFをJPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)、[PDFをPNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/)への変換を行うことができます。他の特殊な形式へのPDF変換操作—[PDFをSVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)、[PDFをTIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)、[PDFをXML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)などもサポートされています。

{{% /alert %}}