---
title: C#でPowerPointをPDFに変換
linktitle: PowerPointをPDFに変換
type: docs
weight: 40
url: /net/convert-powerpoint-to-pdf/
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
- C#
- Csharp
- .NET
- Aspose.Slides for .NET
description: "C#または.NETでPowerPointプレゼンテーションをPDFに変換します。コンプライアンスまたはアクセシビリティ基準に従ってPowerPointをPDFとして保存します。"
---

## **概要**

PowerPoint文書をPDF形式に変換することには、異なるデバイス間での互換性を確保し、プレゼンテーションのレイアウトやフォーマットを保持するなど、いくつかの利点があります。この記事では、プレゼンテーションをPDF文書に変換する方法、画像品質を制御するためのさまざまなオプションの使用、非表示スライドの含め方、PDF文書のパスワード保護、フォントの置き換えの検出、変換するスライドの選択、出力文書にコンプライアンス基準を適用する方法を示します。

## **PowerPointからPDFへの変換**

Aspose.Slidesを使用すると、これらの形式のプレゼンテーションをPDFに変換できます：

* PPT
* PPTX
* ODP

プレゼンテーションをPDFに変換するには、[`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスの引数としてファイル名を渡し、次に[`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)メソッドを使用してプレゼンテーションをPDFとして保存するだけです。 [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスには、プレゼンテーションをPDFに変換するために一般的に使用される[`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/#presentationsave-method-5-of-9)メソッドが公開されています。

{{%  alert title="注意"  color="warning"   %}} 

Aspose.Slides for .NETは、出力文書にAPI情報とバージョン番号を直接書き込みます。たとえば、プレゼンテーションをPDFに変換する際、Aspose.Slides for .NETはアプリケーションフィールドに'*Aspose.Slides*'の値を、PDFプロデューサーフィールドに'*Aspose.Slides v XX.XX*'形式の値を入力します。**注意**として、出力文書からこの情報を変更または削除するようにAspose.Slides for .NETに指示することはできません。

{{% /alert %}}

Aspose.Slidesを使用すると、次のことができます：

* プレゼンテーション全体をPDFに変換する
* プレゼンテーション内の特定のスライドをPDFに変換する
* プレゼンテーションを 

Aspose.Slidesは、プレゼンテーションの内容が元のプレゼンテーションに非常に似ているPDFを出力します。これらの既知の要素と属性は、プレゼンテーションからPDFへの変換で適切にレンダリングされることがよくあります：

* 画像
* テキストボックスやその他の図形
* テキストとそのフォーマット
* 段落とそのフォーマット
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* テーブル

## **PowerPointをPDFに変換**

標準のPowerPoint PDF変換操作は、デフォルトのオプションを使用して実行されます。この場合、Aspose.Slidesは指定されたプレゼンテーションを最大品質レベルの最適設定でPDFに変換しようとします。

このC#コードは、PowerPoint（PPT、PPTX、ODP）をPDFに変換する方法を示しています：

```c#
// PowerPointファイルを表すPresentationクラスをインスタンス化します。PPT、PPTX、ODPなどが含まれます。
Presentation presentation = new Presentation("PowerPoint.ppt");

// プレゼンテーションをPDFとして保存します。
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Asposeは、プレゼンテーションからPDFへの変換プロセスを示す無料のオンライン[**PowerPoint to PDFコンバーター**](https://products.aspose.app/slides/conversion/ppt-to-pdf)を提供しています。ここで説明された手順のライブ実装を行うには、コンバーターを使用してテストを行うことができます。

{{% /alert %}}

## **オプション付きでPowerPointをPDFに変換**

Aspose.Slidesは、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)クラスの下にあるカスタムオプションを提供し、PDF（変換プロセスから得られたもの）をカスタマイズしたり、PDFをパスワードでロックしたり、変換プロセスの方法を指定したりできます。

### **カスタムオプションでPowerPointをPDFに変換**

カスタム変換オプションを使用すると、ラスター画像の好みの品質設定を設定したり、メタファイルの扱い方を指定したり、テキストの圧縮レベルを設定したり、画像のDPIを設定したりできます。

以下のコード例では、PowerPointプレゼンテーションをいくつかのカスタムオプションでPDFに変換する操作を示しています：

```c#
// PdfOptionsクラスをインスタンス化します
PdfOptions pdfOptions = new PdfOptions
{
    // JPG画像の品質を設定します
    JpegQuality = 90,

    // 画像のDPIを設定します
    SufficientResolution = 300,

    // メタファイルの扱いを設定します
    SaveMetafilesAsPng = true,

    // テキストコンテンツの圧縮レベルを設定します
    TextCompression = PdfTextCompression.Flate,

    // PDFコンプライアンスモードを定義します
    Compliance = PdfCompliance.Pdf15
};

// PowerPoint文書を表すPresentationクラスをインスタンス化します
using (Presentation presentation = new Presentation("PowerPoint.pptx"))
{
    // プレゼンテーションをPDF文書として保存します
    presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
}
```

### **非表示スライドを含めてPowerPointをPDFに変換**

プレゼンテーションに非表示スライドが含まれている場合は、[`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)クラスの[`ShowHiddenSlides`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/)プロパティを使用して、Aspose.Slidesに非表示スライドを結果のPDFにページとして含めるよう指示できます。

このC#コードは、非表示スライドを含めてPowerPointプレゼンテーションをPDFに変換する方法を示しています：

```c#
// PowerPointファイルを表すPresentationクラスをインスタンス化します
Presentation presentation = new Presentation("PowerPoint.pptx");

// PdfOptionsクラスをインスタンス化します
PdfOptions pdfOptions = new PdfOptions();

// 非表示スライドを追加します
pdfOptions.ShowHiddenSlides = true;

// プレゼンテーションをPDFとして保存します
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **パスワード保護されたPDFにPowerPointを変換**

このC#コードは、パスワード保護されたPDFにPowerPointを変換する方法を示しています（[`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)クラスからの保護パラメータを使用）：

```c#
// PowerPointファイルを表すPresentationオブジェクトをインスタンス化します
Presentation presentation = new Presentation("PowerPoint.pptx");

/// PdfOptionsクラスをインスタンス化します
PdfOptions pdfOptions = new PdfOptions();

// PDFパスワードとアクセス権を設定します
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// プレゼンテーションをPDFとして保存します
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **フォントの置き換えの検出**

Aspose.Slidesは、[SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/)クラスの下にある[WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/)プロパティを提供し、PDF変換プロセスでフォントの置き換えを検出できるようにします。

このC#コードは、フォントの置き換えを検出する方法を示しています：xxx

```c#
public static void Main()
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.WarningCallback = warningCallback;

    using (Presentation pres = new Presentation("pres.pptx", loadOptions))
    {
    }
}

private class FontSubstSendsWarningCallback : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"フォント置き換え警告: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

レンダリングプロセスにおけるフォント置き換えの警告コールバックの取得についての詳細は、[フォント置き換えの警告コールバックの取得](https://docs.aspose.com/slides/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)を参照してください。

フォント置き換えに関する詳細は、[フォント置き換え](https://docs.aspose.com/slides/net/font-substitution/)の記事を参照してください。

{{% /alert %}} 

## **選択したスライドをPowerPointからPDFに変換**

このC#コードは、PowerPointプレゼンテーションの特定のスライドをPDFに変換する方法を示しています：

```c#
// PowerPointファイルを表すPresentationオブジェクトをインスタンス化します
Presentation presentation = new Presentation("PowerPoint.pptx");

// スライドの位置の配列を設定します
int[] slides = { 1, 3 };

// プレゼンテーションをPDFとして保存します
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **カスタムスライドサイズでPowerPointをPDFに変換**

このC#コードは、スライドサイズが指定された状態でPowerPointをPDFに変換する方法を示しています：

```c#
// PowerPointファイルを表すPresentationオブジェクトをインスタンス化します 
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];
auxPresentation.Slides.InsertClone(0, slide);

// スライドのタイプとサイズを設定します 
// auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height,SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F,SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
options.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

## **ノートスライドビューでPowerPointをPDFに変換**

このC#コードは、PowerPointをPDFノートに変換する方法を示しています：

```c#
// PowerPointファイルを表すPresentationクラスをインスタンス化します
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
	PdfOptions pdfOptions = new PdfOptions();
	INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
	options.NotesPosition = NotesPositions.BottomFull;

	// プレゼンテーションをPDFノートとして保存します
	presentation.Save("Pdf_Notes_out.tiff", SaveFormat.Pdf, pdfOptions);
}
```

## **PDFのアクセシビリティとコンプライアンス基準**

Aspose.Slidesを使用すると、[Webコンテンツアクセシビリティガイドライン（**WCAG**）](https://www.w3.org/TR/WCAG-TECHS/pdf.html)に準拠した変換手順を使用できます。これらのコンプライアンス基準のいずれかを使用してPowerPoint文書をPDFにエクスポートできます: **PDF/A1a**、**PDF/A1b**、および**PDF/UA**。

このC#コードは、異なるコンプライアンス基準に基づいて複数のPDFを取得するPowerPointからPDFへの変換操作を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1a
    });
   
    pres.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1b
    });
   
    pres.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
   {
        Compliance = PdfCompliance.PdfUa
    });
}
```

{{% alert title="注意" color="warning" %}} 

Aspose.SlidesのPDF変換操作は、PDFを最も一般的なファイル形式に変換できるように広がります。 [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)、および[PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/)などの変換が可能です。他のPDF変換操作として、特殊な形式への[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)、および[PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)もサポートされています。

{{% /alert %}}