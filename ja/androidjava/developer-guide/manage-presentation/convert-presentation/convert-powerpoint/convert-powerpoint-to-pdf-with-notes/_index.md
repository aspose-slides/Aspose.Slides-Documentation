---
title: PowerPointをPDFノートに変換する
type: docs
weight: 50
url: /androidjava/convert-powerpoint-to-pdf-with-notes/
keywords: "JavaでPowerPointをノート付きPDFに変換する"
description: "JavaでPowerPointをノート付きPDFに変換する"
---

## **カスタムスライドサイズでPowerPointをPDFに変換する**
以下の例は、カスタムスライドサイズを持つPDFノート文書にプレゼンテーションを変換する方法を示しています。1インチは72に相当します。

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化する
Presentation presIn = new Presentation("SelectedSlides.pptx");
Presentation presOut = new Presentation();
try {
    ISlide slide = presIn.getSlides().get_Item(0);
    presOut.getSlides().insertClone(0, slide);
    
    // スライドのタイプとサイズを設定する
    presOut.getSlideSize().setSize(612F, 792F, SlideSizeScaleType.EnsureFit);
        
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    presOut.save("PDF-SelectedSlide.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presIn != null) presIn.dispose();
    if (presOut != null) presOut.dispose();
}
```

## **ノートスライドビューでPowerPointをPDFに変換する**
[**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスによって公開される[**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-)メソッドを使用して、ノートスライドビューでの全プレゼンテーションをPDFに変換できます。以下のコードスニペットは、サンプルプレゼンテーションをノートスライドビューでPDFに更新します。

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    pres.save(resourcesOutputPath+"PDF-Notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Asposeの[PowerPointをPDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf)や[PPTをPDF](https://products.aspose.app/slides/conversion/ppt-to-pdf)コンバータをチェックしてみてください。

{{% /alert %}} 