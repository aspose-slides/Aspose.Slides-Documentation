---
title: JavaでPowerPointをPDFに変換
linktitle: PowerPointをPDFに変換
type: docs
weight: 40
url: /java/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides for Java
description: "JavaでPowerPointプレゼンテーションをPDFに変換します。準拠またはアクセシビリティ基準に従ってPowerPointをPDFとして保存します。"
---

## **概要**

PowerPoint文書をPDF形式に変換することは、異なるデバイス間での互換性を確保し、プレゼンテーションのレイアウトとフォーマットを保持するなど、いくつかの利点があります。この記事では、プレゼンテーションをPDF文書に変換する方法、画像品質を管理するためのさまざまなオプションの使用、非表示スライドの含め方、PDF文書のパスワード保護、フォントの置き換えの検出、変換対象のスライドの選択、および出力文書に準拠基準を適用する方法を示します。

## **PowerPointからPDFへの変換**

Aspose.Slidesを使用すると、次の形式のプレゼンテーションをPDFに変換できます：

* PPT
* PPTX
* ODP

プレゼンテーションをPDFに変換するには、単に[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスにファイル名を引数として渡し、次に[Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-)メソッドを使用してプレゼンテーションをPDFとして保存するだけです。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスは、プレゼンテーションをPDFに変換するために通常使用される[Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-)メソッドを公開しています。

{{%  alert title="注意"  color="warning"   %}} 

Aspose.Slides for Javaは、出力文書にAPI情報とバージョン番号を直接書き込みます。たとえば、プレゼンテーションをPDFに変換するとき、Aspose.Slides for Javaは、アプリケーションフィールドに '*Aspose.Slides*' 値を、PDFプロデューサーフィールドに '*Aspose.Slides v XX.XX*' 形式の値を入力します。 **注意**：Aspose.Slides for Javaに出力文書からこの情報を変更または削除するように指示することはできません。

{{% /alert %}}

Aspose.Slidesを使用すると、以下を変換できます：

* プレゼンテーション全体をPDFに
* プレゼンテーション内の特定のスライドをPDFに
* プレゼンテーション

Aspose.Slidesは、プレゼンテーションをPDFにエクスポートする方法で、結果として得られるPDFの内容が元のプレゼンテーションに非常に似ていることを保証します。これらの既知の要素と属性は、プレゼンテーションからPDFへの変換で適切にレンダリングされることがよくあります：

* 画像
* テキストボックスやその他のシェイプ
* テキストとそのフォーマット
* 段落とそのフォーマット
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPointをPDFに変換**

標準的なPowerPoint PDF変換操作は、デフォルトオプションを使用して実行されます。この場合、Aspose.Slidesは最適な設定を使用して提供されたプレゼンテーションをPDFに変換しようとします。

このJavaコードは、PowerPointをPDFに変換する方法を示しています：

```java
// PowerPointファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation("PowerPoint.ppt");
try {
    // プレゼンテーションをPDFとして保存
    pres.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert  color="primary"  %}} 

Asposeは、プレゼンテーションからPDFへの変換プロセスをデモンストレーションするための無料オンライン[**PowerPoint to PDFコンバーター**](https://products.aspose.app/slides/conversion/ppt-to-pdf)を提供しています。ここで説明されている手順を使用して、コンバーターでテストを行うことができます。

{{% /alert %}}

## **オプションを使用してPowerPointをPDFに変換**

Aspose.Slidesは、PDF（変換プロセスから生成されたもの）をカスタマイズしたり、パスワードでPDFをロックしたり、変換プロセスの進行方法を指定したりできるカスタムオプション—[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions)クラスのプロパティを提供します。

### **カスタムオプションを使用してPowerPointをPDFに変換**

カスタム変換オプションを使用すると、ラスタ画像の品質設定を好みに合わせて設定したり、メタファイルの処理方法を指定したり、テキストの圧縮レベルを設定したり、画像のDPIを設定したりできます。

以下のコード例は、PowerPointプレゼンテーションがいくつかのカスタムオプションを使用してPDFに変換される操作を示しています：

```java
// PdfOptionsクラスをインスタンス化
PdfOptions pdfOptions = new PdfOptions();

// JPG画像の品質を設定
pdfOptions.setJpegQuality((byte)90);

// 画像のDPIを設定
pdfOptions.setSufficientResolution(300);

// メタファイルの動作を設定
pdfOptions.setSaveMetafilesAsPng(true);

// テキストコンテンツの圧縮レベルを設定
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// PDF準拠モードを定義
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// PowerPoint文書を表すPresentationクラスをインスタンス化
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // プレゼンテーションをPDF文書として保存
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **非表示スライドを含めてPowerPointをPDFに変換**

プレゼンテーションに非表示のスライドが含まれている場合、カスタムオプション—[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions)クラスの[ShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IPdfOptions#getShowHiddenSlides--)プロパティを使用して、Aspose.Slidesに非表示スライドを結果のPDFのページとして含めるよう指示できます。

このJavaコードは、非表示スライドを含むPowerPointプレゼンテーションをPDFに変換する方法を示しています：

```java
// PowerPointファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // PdfOptionsクラスをインスタンス化
    PdfOptions pdfOptions = new PdfOptions();
    
    // 非表示のスライドを追加
    pdfOptions.setShowHiddenSlides(true);
    
    // プレゼンテーションをPDFとして保存
    pres.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **パスワード保護されたPDFにPowerPointを変換**

このJavaコードは、パスワード保護されたPDFにPowerPointを変換する方法を示しています（[PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions)クラスからの保護パラメータを使用）：

```java
// PowerPointファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // PdfOptionsクラスをインスタンス化
    PdfOptions pdfOptions = new PdfOptions();
    
    // PDFパスワードとアクセス許可を設定
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);
    
    // プレゼンテーションをPDFとして保存
    pres.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **フォントの置き換えを検出**

Aspose.Slidesは、[SaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/)クラスの[getWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#getWarningCallback--)メソッドを提供して、プレゼンテーションからPDFへの変換プロセスでフォントの置き換えを検出できるようにします。

このJavaコードは、フォントの置き換えを検出する方法を示しています： 

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
            System.out.println("フォント置き換えの警告: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

レンダリングプロセスでフォントの置き換えに関するコールバックを取得する方法については、[フォントの置き換えに関する警告コールバックの取得](https://docs.aspose.com/slides/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)を参照してください。

フォントの置き換えに関する詳細については、[フォントの置き換え](https://docs.aspose.com/slides/java/font-substitution/)の記事を参照してください。

{{% /alert %}} 

## **PowerPointの特定のスライドをPDFに変換**

このJavaコードは、PowerPointプレゼンテーション内の特定のスライドをPDFに変換する方法を示しています：

```java
// PowerPointファイルを表すPresentationオブジェクトをインスタンス化
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

## **カスタムスライドサイズでPowerPointをPDFに変換**

このJavaコードは、スライドサイズが指定されたPowerPointをPDFに変換する方法を示しています：

```java
// PowerPointファイルを表すPresentationオブジェクトをインスタンス化 
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

## **ノートスライド表示でPowerPointをPDFに変換**

このJavaコードは、PowerPointをノートとしてPDFに変換する方法を示しています：

```java
// PowerPointファイルを表すPresentationクラスをインスタンス化
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

## **PDFのアクセシビリティおよび準拠基準**

Aspose.Slidesは、[Webコンテンツアクセシビリティガイドライン（**WCAG**）](https://www.w3.org/TR/WCAG-TECHS/pdf.html)に準拠する変換手続きを使用することを可能にします。PowerPoint文書をPDFにエクスポートする際には、**PDF/A1a**、**PDF/A1b**、**PDF/UA**のいずれかの準拠基準を使用できます。

このJavaコードは、異なる準拠基準に基づいて複数のPDFが得られるPowerPointからPDFへの変換操作を示しています：

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

Aspose.SlidesのPDF変換操作は、最も人気のあるファイル形式へのPDFの変換も許可します。PDFから[HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)への変換、[画像](https://products.aspose.com/slides/java/conversion/pdf-to-image/)への変換、[JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)への変換、[PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/)への変換が可能です。また、[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)などの特殊な形式へのPDF変換操作もサポートされています。

{{% /alert %}}