---
title: PHP'de PDF Belgelerini Düzenle
linktitle: PDF Düzenle
type: docs
weight: 65
url: /tr/php-java/edit-pdf/
keywords:
- PDF düzenle
- PDF metnini değiştir
- PDF'den PPTX'e
- PPTX'ten PDF'e
- PHP
- Aspose.Slides
description: "PDF belgelerini Aspose.Slides'e aktararak, metni değiştirerek ve değiştirilmiş sunumu tekrar PDF olarak kaydederek PHP'de düzenleyin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, PDF sayfalarını slayt olarak içe aktararak, sunumu değiştirerek ve yeniden PDF olarak dışa aktararak PDF içeriğini düzenlemenizi sağlar. Bu makale basit bir metin değişimini gösterir. Sunum bellek içinde kalır, bu yüzden ara bir PPTX dosyasını kaydetmek isteğe bağlıdır.

## **PDF'te Metin Değiştirme**

Sayfaları içe aktarmak için [SlideCollection::addFromPdf](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/#addFromPdf), metni güncellemek için [Presentation::replaceText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#replaceText) ve sonucu dışa aktarmak için [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) kullanın.

Aşağıdaki örnek, içe aktarım sonrası `input.pdf` dosyasının düzenlenebilir metin olarak "Draft" kelimesini içerdiğini varsayar. Bu kelimeyi "Final" ile değiştirir ve `edited.pdf` olarak yazar. İçe aktarmadan önce ilk slaytı temizlemek, çıktıda ekstra boş bir sayfanın oluşmasını önler. Arama, aynı harf durumunda tam kelimeleri eşleştirir; `null` herhangi bir sonuç geri aramasının gerekmediği anlamına gelir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

Daha fazla seçenek için [Arama ve Metin Değiştirme](/slides/tr/php-java/search-and-replace-text/) ve [PowerPoint'i PDF'e Dönüştür](/slides/tr/php-java/convert-powerpoint-to-pdf/) sayfalarına bakın.

{{% alert color="info" title="Note" %}}
Metin değiştirme, içe aktarılmış metin üzerinde çalışır, taranmış görüntüler içindeki metin üzerinde değil. Dönüştürme, düzen ve biçimlendirmeyi etkileyebilir; bu yüzden çıktıyı gözden geçirin, özellikle değiştirme metni orijinalden daha uzun olduğunda.
{{% /alert %}}

## **SSS**

**PDF'i dışa aktarmadan önce bir PPTX dosyasını kaydetmem gerekiyor mu?**

Hayır. Aynı sunumu bellekte düzenleyip dışa aktarabilirsiniz. PowerPoint'te düzenlemeye devam etmek isterseniz yalnızca bir PPTX kopyasını kaydedin; [Sunumları Kaydet](/slides/tr/php-java/save-presentation/) sayfasına bakın.

**Neden bazı metinler değişmeden kalabilir?**

Örnek, tam olarak aynı harf durumunda "Draft" kelimesinin bütününü eşleştirir. Görüntü olarak içe aktarılmış metin veya ayrı metin çerçevelerine bölünmüş metin, aramayla mutlaka eşleşmez. İçe aktarılan içeriği kontrol edin ve belgeniz için aramayı ayarlayın.