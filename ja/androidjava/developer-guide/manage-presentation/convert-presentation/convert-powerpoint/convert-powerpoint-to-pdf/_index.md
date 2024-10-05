---
title: JavaでPowerPointをPDFに変換
linktitle: PowerPointをPDFに変換
type: docs
weight: 40
url: /androidjava/convert-powerpoint-to-pdf/
keywords:
- PowerPointの変換
- プレゼンテーション
- PowerPointからPDF
- PPTからPDF
- PPTXからPDF
- PowerPointをPDFとして保存
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides for Android via Java
description: "JavaでPowerPointプレゼンテーションをPDFに変換します。準拠またはアクセシビリティ基準に従ってPowerPointをPDFとして保存します。"
---

## **概要**

PowerPointドキュメントをPDF形式に変換することには、異なるデバイス間での互換性を確保し、プレゼンテーションのレイアウトや書式を保持することなど、いくつかの利点があります。この記事では、プレゼンテーションをPDFドキュメントに変換し、画像品質をコントロールするためのさまざまなオプションを使用し、非表示のスライドを含め、PDFドキュメントをパスワードで保護し、フォントの置換を検出し、変換するスライドを選択し、出力ドキュメントに準拠基準を適用する方法を説明します。

## **PowerPointからPDFへの変換**

Aspose.Slidesを使用すると、以下の形式のプレゼンテーションをPDFに変換できます：

* PPT
* PPTX
* ODP

プレゼンテーションをPDFに変換するには、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスにファイル名を引数として渡し、[Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-)メソッドを使用してプレゼンテーションをPDFとして保存するだけです。[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスは、通常プレゼンテーションをPDFに変換するために使用される[Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-)メソッドを公開しています。

{{% alert title="注意" color="warning" %}} 

Aspose.Slides for Android via Javaは、出力ドキュメントにAPI情報とバージョン番号を直接書き込みます。例えば、プレゼンテーションをPDFに変換する際、Aspose.Slides for Android via Javaは、Applicationフィールドに'*Aspose.Slides*'の値を、PDF Producerフィールドに'*Aspose.Slides v XX.XX*'形式の値を設定します。**注意**として、Aspose.Slides for Android via Javaにこの情報を出力ドキュメントから変更または削除させることはできません。

{{% /alert %}}

Aspose.Slidesを使用すると、次の変換が可能です：

* プレゼンテーション全体をPDFに
* プレゼンテーション内の特定のスライドをPDFに
* プレゼンテーションを

Aspose.Slidesは、プレゼンテーションの内容と非常に似た形でPDFにエクスポートします。これらの既知の要素と属性は、プレゼンテーションからPDFへの変換で正しくレンダリングされることがよくあります：

* 画像
* テキストボックスやその他の図形
* テキストとその書式
* 段落とその書式
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* テーブル

## **PowerPointをPDFに変換する**

標準のPowerPointからPDFへの変換操作は、デフォルトのオプションを使用して実行されます。この場合、Aspose.Slidesは提供されたプレゼンテーションを最適な設定で最大品質のレベルでPDFに変換しようとします。

以下のJavaコードは、PowerPointをPDFに変換する方法を示しています：

```java
// PowerPointファイルを表すPresentationクラスのインスタンスを生成
Presentation pres = new Presentation("PowerPoint.ppt");
try {
    // プレゼンテーションをPDFとして保存
    pres.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Asposeは、プレゼンテーションからPDFへの変換プロセスを示す無料のオンライン[**PowerPointからPDFへの変換ツール**](https://products.aspose.app/slides/conversion/ppt-to-pdf)を提供しています。ここで説明されている手順のライブ実装をテストしたい場合は、変換ツールで試すことができます。

{{% /alert %}}

## **オプションを使用したPowerPointからPDFへの変換**

Aspose.Slidesはカスタムオプションを提供しており、[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PdfOptions)クラスのプロパティを使用して、PDF（変換プロセスの結果）をカスタマイズしたり、パスワードでPDFをロックしたり、変換プロセスを制御したりすることができます。

### **カスタムオプションを使用したPowerPointからPDFへの変換**

カスタム変換オプションを使用すると、ラスタ画像の品質設定を好みに合わせて設定したり、メタファイルの処理方法を指定したり、テキストの圧縮レベルを設定したり、画像のDPIを設定したりできます。

以下のコード例は、複数のカスタムオプションを使用してPowerPointプレゼンテーションをPDFに変換する操作を示しています：

```java
// PdfOptionsクラスのインスタンスを生成
PdfOptions pdfOptions = new PdfOptions();

// JPG画像の品質を設定
pdfOptions.setJpegQuality((byte)90);

// 画像のDPIを設定
pdfOptions.setSufficientResolution(300);

// メタファイルの処理方法を設定
pdfOptions.setSaveMetafilesAsPng(true);

// テキスト内容の圧縮レベルを設定
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// PDFの準拠モードを定義
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// PowerPointドキュメントを表すPresentationクラスのインスタンスを生成
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // プレゼンテーションをPDFドキュメントとして保存
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **非表示のスライドを含むPowerPointからPDFへの変換**

プレゼンテーションに非表示のスライドが含まれている場合、カスタムオプションである[ShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPdfOptions#getShowHiddenSlides--)プロパティを使用して、Aspose.Slidesに結果のPDFに非表示のスライドをページとして含めるよう指示できます。

このJavaコードは、非表示のスライドを含むPowerPointプレゼンテーションをPDFに変換する方法を示しています：

```java
// PowerPointファイルを表すPresentationクラスのインスタンスを生成
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // PdfOptionsクラスのインスタンスを生成
    PdfOptions pdfOptions = new PdfOptions();
    
    // 非表示のスライドを追加
    pdfOptions.setShowHiddenSlides(true);
    
    // プレゼンテーションをPDFとして保存
    pres.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **パスワード保護されたPDFにPowerPointを変換する**

このJavaコードは、PowerPointをパスワード保護されたPDFに変換する方法を示しています（[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PdfOptions)クラスの保護パラメータを使用）：

```java
// PowerPointファイルを表すPresentationオブジェクトのインスタンスを生成
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // PdfOptionsクラスのインスタンスを生成
    PdfOptions pdfOptions = new PdfOptions();
    
    // PDFのパスワードとアクセス権限を設定
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);
    
    // プレゼンテーションをPDFとして保存
    pres.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **フォント置換を検出する**

Aspose.Slidesは、[SaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/)クラスの[getWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#getWarningCallback--)メソッドを提供しており、プレゼンテーションをPDFに変換するプロセスでフォント置換を検出することができます。

このJavaコードは、フォント置換を検出する方法を示しています：

```java
public void main(String[] args)
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.setWarningCallback(warningCallback);

    Presentation pres = new Presentation("pres.pptx", loadOptions);
    try {
        
    } finally {
        if (pres != null) pres.dispose();
    }
}

private class FontSubstSendsWarningCallback implements IWarningCallback
{
    public int warning(IWarningInfo warning)
    {
        if (warning.getWarningType() == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted"))
        {
            System.out.println("フォント置換の警告: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="primary" %}} 

レンダリングプロセスでのフォント置換に関するコールバックを取得する方法についての詳細は、[フォント置換のための警告コールバックの取得](https://docs.aspose.com/slides/androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)を参照してください。

フォント置換に関する詳細は、[フォント置換](https://docs.aspose.com/slides/androidjava/font-substitution/)の記事を参照してください。

{{% /alert %}} 

## **PowerPointで選択したスライドをPDFに変換する**

このJavaコードは、PowerPointプレゼンテーション内の特定のスライドをPDFに変換する方法を示しています：

```java
// PowerPointファイルを表すPresentationオブジェクトのインスタンスを生成
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // スライドの位置の配列を設定
    int[] slides = { 1, 3 };
    
    // プレゼンテーションをPDFとして保存
    pres.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

## **カスタムスライドサイズでPowerPointをPDFに変換する**

このJavaコードは、スライドサイズが指定されたPowerPointをPDFに変換する方法を示しています：

```java
// PowerPointファイルを表すPresentationオブジェクトのインスタンスを生成 
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    Presentation outPres = new Presentation();
    try {
        ISlide slide = pres.getSlides().get_Item(0);

        outPres.getSlides().insertClone(0, slide);
        
        // スライドのタイプとサイズを設定 
        outPres.getSlideSize().setSize(612F, 792F, SlideSizeScaleType.EnsureFit);
        
        PdfOptions pdfOptions = new PdfOptions();
        INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
        options.setNotesPosition(NotesPositions.BottomFull);

        outPres.save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        if (pres != null) pres.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **メモスライドビューでPowerPointをPDFに変換する**

このJavaコードは、PowerPointをメモとしてPDFに変換する方法を示しています：

```java
// PowerPointファイルを表すPresentationクラスのインスタンスを生成
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    pres.save("Pdf_With_Notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PDFのアクセシビリティと準拠基準**

Aspose.Slidesを使用すると、[Webコンテンツアクセシビリティガイドライン（**WCAG**）](https://www.w3.org/TR/WCAG-TECHS/pdf.html)に準拠した変換手順を使用できます。PowerPoint文書を、**PDF/A1a**、**PDF/A1b**、**PDF/UA**のいずれかの準拠基準を使用してPDFにエクスポートできます。

以下のJavaコードは、異なる準拠基準に基づいて複数のPDFを取得するPowerPointからPDFへの変換操作を示します：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    
    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    pres.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    pres.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    pres.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

Aspose.SlidesのPDF変換操作は、PDFを最も一般的なファイル形式に変換することを許可しています。あなたは[PDFからHTML](https://products.aspose.com/slides/androidjava/conversion/pdf-to-html/)、[PDFから画像](https://products.aspose.com/slides/androidjava/conversion/pdf-to-image/)、[PDFからJPG](https://products.aspose.com/slides/androidjava/conversion/pdf-to-jpg/)、および[PDFからPNG](https://products.aspose.com/slides/androidjava/conversion/pdf-to-png/)への変換を行うことができます。他の特殊形式へのPDF変換操作—[PDFからSVG](https://products.aspose.com/slides/androidjava/conversion/pdf-to-svg/)、[PDFからTIFF](https://products.aspose.com/slides/androidjava/conversion/pdf-to-tiff/)、および[PDFからXML](https://products.aspose.com/slides/androidjava/conversion/pdf-to-xml/)への変換もサポートされています。

{{% /alert %}}