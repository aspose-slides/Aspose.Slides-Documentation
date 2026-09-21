---
title: "Android'de Notlu PowerPoint Sunumlarını PDF'e Dönüştür"
linktitle: "Notlu PowerPoint'ten PDF'e"
type: docs
weight: 50
url: /tr/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords:
- "PowerPoint dönüştür"
- "sunumu dönüştür"
- "slaytı dönüştür"
- "PPT dönüştür"
- "PPTX dönüştür"
- "PowerPoint'ten PDF'e"
- "sunumu PDF'e"
- "slaytı PDF'e"
- "PPT'den PDF'e"
- "PPTX'ten PDF'e"
- "sunumu PDF olarak kaydet"
- "PPT'yi PDF olarak kaydet"
- "PPTX'i PDF olarak kaydet"
- "PPT'yi PDF'ye aktar"
- "PPTX'i PDF'ye aktar"
- "konuşmacı notları"
- "notlu PDF"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Android via Java kullanarak notlu PPT ve PPTX formatlarını PDF'e dönüştürün. Profesyonel sunumlar için düzenleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu rehber gerekli adımları kapsayacak ve bu görevi verimli bir şekilde gerçekleştirmenize yardımcı olacak kod örnekleri sunacak. Makalenin sonunda şunları yapabileceksiniz:

- Konuşmacı notlarını koruyarak PowerPoint slaytlarını PDF belgelerine dönüştürme sürecini uygulamak.
- Çıktı PDF'yi özelleştirerek konuşmacı notlarının dahil edildiğinden ve gereksinimlerinize göre biçimlendirildiğinden emin olmak.

Not sayfası boyutlarını ve yönünü dışa aktarmadan önce ayarlamak için [Not Sayfası Boyutu](/slides/tr/androidjava/notes-size/) sayfasına bakın.

## **PowerPoint'i Notlarla PDF'e Dönüştür**

`save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfında PPT veya PPTX sunumunu konuşmacı notlarıyla PDF'e dönüştürmek için kullanılabilir. Aspose.Slides ile sadece sunumu yüklersiniz, konuşmacı notlarını dahil etmek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/notescommentslayoutingoptions/) sınıfını kullanarak yerleşim seçeneklerini yapılandırırsınız ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod parçacığı, örnek bir sunumu Not Slayt görünümünde PDF'e nasıl dönüştüreceğinizi gösterir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// Konuşmacı notlarını render etmek için PDF seçeneklerini yapılandır.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Konuşmacı notlarını slaytın altında render et.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Sunumu konuşmacı notlarıyla PDF olarak kaydet.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose [Çevrimiçi PowerPoint'ten PDF'ye Dönüştürücü](https://products.aspose.app/slides/tr/conversion) sayfasına göz atmak isteyebilirsiniz.
{{% /alert %}}