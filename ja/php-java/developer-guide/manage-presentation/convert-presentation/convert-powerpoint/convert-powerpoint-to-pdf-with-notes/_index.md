---
title: PowerPointをPDFノートに変換
type: docs
weight: 50
url: /ja/php-java/convert-powerpoint-to-pdf-with-notes/
keywords: "javaでPowerPointをPDFノートに変換"
description: "PowerPointをノート付きPDFに変換"
---

## **カスタムスライドサイズでPowerPointをPDFに変換**
以下の例は、プレゼンテーションをカスタムスライドサイズを持つPDFノート文書に変換する方法を示しています。1インチは72に相当します。

```php
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $presIn = new Presentation("SelectedSlides.pptx");
  $presOut = new Presentation();
  try {
    $slide = $presIn->getSlides()->get_Item(0);
    $presOut->getSlides()->insertClone(0, $slide);
    # スライドタイプとサイズの設定
    $presOut->getSlideSize()->setSize(612.0, 792.0, SlideSizeScaleType::EnsureFit);
    $pdfOptions = new PdfOptions();
    $pdfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $presOut->save("PDF-SelectedSlide.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($presIn)) {
      $presIn->dispose();
    }
    if (!java_is_null($presOut)) {
      $presOut->dispose();
    }
  }
```

## **ノートスライドビューでPowerPointをPDFに変換**
[**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-)メソッドは、[**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスによって公開され、ノートスライドビューでプレゼンテーション全体をPDFに変換するために使用できます。以下のコードスニペットは、ノートスライドビューのPDFへのサンプルプレゼンテーションを更新します。

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $pres->save($resourcesOutputPath . "PDF-Notes.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Asposeの[PowerPointをPDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf)や[PPTをPDF](https://products.aspose.app/slides/conversion/ppt-to-pdf)コンバーターをチェックしてみてください。 

{{% /alert %}}