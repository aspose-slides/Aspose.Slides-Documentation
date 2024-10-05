---
title: PowerPointをPDFノートに変換
type: docs
weight: 50
url: /java/convert-powerpoint-to-pdf-with-notes/
keywords: "javaでPowerPointをPDFノートに変換"
description: "JavaでのPowerPointをPDFノートに変換"
---

## **カスタムスライドサイズでPowerPointをPDFに変換**
以下の例は、カスタムスライドサイズでプレゼンテーションをPDFノート文書に変換する方法を示しています。1インチは72ポイントに相当します。

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation presIn = new Presentation("SelectedSlides.pptx");
Presentation presOut = new Presentation();
try {
    ISlide slide = presIn.getSlides().get_Item(0);
    presOut.getSlides().insertClone(0, slide);
    
    // スライドタイプとサイズを設定
    presOut.getSlideSize().setSize(612F, 792F,SlideSizeScaleType.EnsureFit);
        
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    presOut.save("PDF-SelectedSlide.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presIn != null) presIn.dispose();
    if (presOut != null) presOut.dispose();
}
```

## **ノートスライドビューでPowerPointをPDFに変換**
[**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-)メソッドは、[**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスによって公開されており、ノートスライドビューの全体のプレゼンテーションをPDFに変換するために使用できます。以下のコードスニペットは、ノートスライドビューにPDFとしてサンプルプレゼンテーションを更新します。

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

Asposeの[PowerPointをPDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf)または[PPTをPDF](https://products.aspose.app/slides/conversion/ppt-to-pdf)コンバータをチェックしてみてください。 

{{% /alert %}}