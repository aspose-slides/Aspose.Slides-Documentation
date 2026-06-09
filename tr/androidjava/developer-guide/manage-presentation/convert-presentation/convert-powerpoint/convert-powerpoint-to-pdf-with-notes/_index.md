---
title: PowerPoint Sunumlarını Notlarla Android'de PDF'ye Dönüştür
linktitle: PowerPoint Notlarla PDF'ye
type: docs
weight: 50
url: /tr/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten PDF'ye
- sunumdan PDF'ye
- slayttan PDF'ye
- PPT'den PDF'ye
- PPTX'ten PDF'ye
- sunumu PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'ye aktar
- PPTX'i PDF'ye aktar
- konuşmacı notları
- notlu PDF
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'i Java aracılığıyla kullanarak PPT ve PPTX formatlarını notlarla PDF'ye dönüştürün. Profesyonel sunumlar için düzenleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu rehber gerekli adımları kapsar ve bu görevi verimli bir şekilde gerçekleştirmenize yardımcı olacak kod örnekleri sunar. Makalenin sonunda şu yeteneklere sahip olacaksınız:

- PowerPoint slaytlarını konuşmacı notlarını koruyarak PDF belgelerine dönüştürme sürecini uygulayın.
- Çıktı PDF'sini özelleştirerek konuşmacı notlarının dahil edilmesini ve gereksinimlerinize göre biçimlendirilmesini sağlayın.

## **PowerPoint'i Notlarla PDF'ye Dönüştür**

`save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfında bir PPT veya PPTX sunumunu konuşmacı notlarıyla PDF'ye dönüştürmek için kullanılabilir. Aspose.Slides ile sadece sunumu yüklersiniz, konuşmacı notlarını dahil etmek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notescommentslayoutingoptions/) sınıfını kullanarak düzen seçeneklerini yapılandırırsınız ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod örneği, bir örnek sunumu Not Slaytı görünümünde PDF'ye nasıl dönüştüreceğinizi gösterir.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
	// Konuşmacı notlarını render etmek için PDF seçeneklerini yapılandır.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Slaytın altında konuşmacı notlarını render et.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Sunumu konuşmacı notlarıyla PDF olarak kaydet.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="primary" %}} 
Aspose [Çevrimiçi PowerPoint'ten PDF'ye Dönüştürücü](https://products.aspose.app/slides/tr/conversion)'yi kontrol etmek isteyebilirsiniz. 
{{% /alert %}}