---
title: Java'da PDF Belgelerini Düzenleme
linktitle: PDF Düzenle
type: docs
weight: 65
url: /tr/java/edit-pdf/
keywords:
- PDF düzenle
- PDF metnini değiştir
- PDF'ten PPTX'e
- PPTX'ten PDF'e
- Java
- Aspose.Slides
description: "PDF belgelerini Java'da Aspose.Slides'e içe aktararak, metni değiştirerek ve değiştirilen sunumu tekrar PDF olarak kaydederek düzenleyin."
---
## **Genel Bakış**

Aspose.Slides for Java, PDF sayfalarını slayt olarak içe aktararak, sunumu değiştirerek ve tekrar PDF olarak dışa aktararak PDF içeriğini düzenlemenizi sağlar. Bu makale basit bir metin değiştirme örneği gösterir. Sunum bellek içinde kalır, bu yüzden ara bir PPTX dosyası kaydetmek isteğe bağlıdır.

## **PDF'de Metin Değiştirme**

Sayfaları içe aktarmak için [addFromPdf](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) , metni güncellemek için [replaceText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ve sonucu dışa aktarmak için [save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) kullanın.

Aşağıdaki örnek, `input.pdf` dosyasının içe aktarıldıktan sonra düzenlenebilir metin olarak "Draft" kelimesini içerdiğini varsayar. Bu kelimeyi "Final" ile değiştirir ve `edited.pdf` olarak yazar. İçe aktarmadan önce ilk slaytı temizlemek, çıktıda ekstra boş bir sayfa oluşmasını önler. Arama, aynı harf büyüklüğünde tam kelimeleri eşleştirir; `null` bir sonuç geri arama işlevine ihtiyaç olmadığını gösterir.

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

Daha fazla seçenek için [Metin Arama ve Değiştirme](/slides/tr/java/search-and-replace-text/) ve [PowerPoint'i PDF'e Dönüştür](/slides/tr/java/convert-powerpoint-to-pdf/) bölümlerine bakın.

{{% alert color="info" title="Note" %}}
Metin değiştirme, içe aktarılan metin üzerinde çalışır, taranmış görüntüler içindeki metin üzerinde çalışmaz. Dönüşüm, düzeni ve biçimlendirmeyi etkileyebilir; özellikle değiştirme metni orijinalden daha uzun olduğunda çıktıyı inceleyin.
{{% /alert %}}

## **SSS**

**PDF'i dışa aktarmadan önce bir PPTX dosyası kaydetmem gerekiyor mu?**

Hayır. Sunumu bellek içinde düzenleyip dışa aktarabilirsiniz. PowerPoint'te düzenlemeye devam etmek istiyorsanız yalnızca bir PPTX kopyası kaydedin; bkz. [Sunumları Kaydet](/slides/tr/java/save-presentation/).

**Bazı metinler neden değişmeden kalıyor?**

Örnek, tam olarak aynı harf büyüklüğünde "Draft" kelimesini eşleştirir. Görüntü olarak içe aktarılan veya ayrı metin çerçevelerine bölünmüş metinler aramayla eşleşmeyebilir. İçe aktarılan içeriği kontrol edin ve belgeniz için aramayı gerektiği gibi ayarlayın.