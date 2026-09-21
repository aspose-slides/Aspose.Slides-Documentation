---
title: Android'de PDF Belgelerini Düzenle
linktitle: PDF Düzenle
type: docs
weight: 65
url: /tr/androidjava/edit-pdf/
keywords:
- PDF düzenle
- PDF metnini değiştir
- PDF'den PPTX'e
- PPTX'ten PDF'e
- Android
- Java
- Aspose.Slides
description: "Java ile Android'de PDF belgelerini Aspose.Slides'e aktararak, metni değiştirerek ve değiştirilmiş sunumu yeniden PDF olarak kaydederek düzenleyin."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, PDF sayfalarını slayt olarak içe aktararak, sunumu değiştirerek ve tekrar PDF olarak dışa aktararak PDF içeriğini düzenlemenizi sağlar. Bu makale basit bir metin değiştirme örneği sunar. Sunum bellekte kalır, bu nedenle ara bir PPTX dosyası kaydetmek isteğe bağlıdır.

## **PDF'de Metin Değiştirme**

Sayfaları içe aktarmak için [addFromPdf](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-), metni güncellemek için [replaceText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), ve sonucu dışa aktarmak için [save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) kullanın.

Aşağıdaki örnek, içe aktarma sonrası `input.pdf` dosyasının düzenlenebilir metin olarak "Draft" kelimesini içerdiğini varsayar. Bu kelimeyi "Final" ile değiştirir ve `edited.pdf` olarak yazar. İçe aktarmadan önce ilk slaytı temizlemek, çıktıdaki ekstra boş sayfayı önler. Arama, aynı harf durumuyla bütün kelimeleri eşleştirir; `null` bir sonuç geri arama callback'ine gerek olmadığını gösterir.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Daha fazla seçenek için [Metin Arama ve Değiştirme](/slides/tr/androidjava/search-and-replace-text/) ve [PowerPoint'i PDF'ye Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-pdf/) bölümlerine bakın.

{{% alert color="info" title="Note" %}}
Metin değiştirme, taranmış görüntüler içindeki metin yerine içe aktarılmış metin üzerinde çalışır. Dönüşüm, düzen ve biçimlendirmeyi etkileyebilir; özellikle değiştirme metni orijinalden daha uzun olduğunda çıktıyı gözden geçirin.
{{% /alert %}}

## **SSS**

**PDF'yi dışa aktarmadan önce bir PPTX dosyası kaydetmem gerekiyor mu?**

Hayır. Sunumu aynı anda bellekte düzenleyip dışa aktarabilirsiniz. PowerPoint'te de düzenlemeye devam etmek isterseniz bir PPTX kopyası kaydedin; bakın [Sunumları Kaydet](/slides/tr/androidjava/save-presentation/).

**Bazı metinler neden değişmeden kalıyor?**

Örnek, tam olarak aynı büyük/küçük harfle "Draft" kelimesini bütün olarak eşleştirir. Görüntü olarak içe aktarılmış veya ayrı metin çerçevelerine bölünmüş metinler aramayla eşleşmeyebilir. İçe aktarılan içeriği kontrol edin ve belgeye göre aramayı ayarlayın.