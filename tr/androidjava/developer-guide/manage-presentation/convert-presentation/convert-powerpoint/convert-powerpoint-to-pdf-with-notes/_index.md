---
title: PowerPoint Sunumlarını Notlarla Android'de PDF'e Dönüştürme
linktitle: PowerPoint Notlu PDF'e Dönüştürme
type: docs
weight: 50
url: /tr/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten PDF'e
- sunumdan PDF'e
- slayttan PDF'e
- PPT'den PDF'e
- PPTX'den PDF'e
- sunumu PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'e aktar
- PPTX'i PDF'e aktar
- konuşmacı notları
- notlu PDF
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'ı Java aracılığıyla kullanarak PPT ve PPTX formatlarını notlarla birlikte PDF'e dönüştürün. Profesyonel sunumlar için düzenleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla birlikte PDF formatına dönüştürmeyi öğreneceksiniz. Bu kılavuz gerekli adımları kapsar ve görevi verimli bir şekilde gerçekleştirmenize yardımcı olacak kod örnekleri sunar. Makalenin sonunda aşağıdakileri yapabilecek duruma geleceksiniz:

- Konuşmacı notlarını koruyarak PowerPoint slaytlarını PDF belgelerine dönüştürme sürecini uygulamak.
- Çıktı PDF'sini, konuşmacı notlarının dahil edilmesini ve gereksinimlerinize göre biçimlendirilmesini sağlayacak şekilde özelleştirmek.

## **Notlu PowerPoint'i PDF'e Dönüştürme**

`save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfında, bir PPT veya PPTX sunumunu konuşmacı notlarıyla birlikte PDF'ye dönüştürmek için kullanılabilir. Aspose.Slides ile sadece sunumu yükler, konuşmacı notlarını eklemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notescommentslayoutingoptions/) sınıfını kullanarak düzen seçeneklerini yapılandırır ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod parçacığı, örnek bir sunumu Not Slaytı görünümünde PDF'ye nasıl dönüştüreceğinizi gösterir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// Konuşmacı notlarını işlemek için PDF seçeneklerini yapılandır.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Konuşmacı notlarını slaytın altında göster.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Sunumu konuşmacı notlarıyla birlikte PDF olarak kaydet.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" %}} 
Aspose [Çevrimiçi PowerPoint PDF Dönüştürücü](https://products.aspose.app/slides/tr/conversion) hizmetini de inceleyebilirsiniz. 
{{% /alert %}}