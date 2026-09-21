---
title: JavaScript'te PDF Belgelerini Düzenle
linktitle: PDF Düzenle
type: docs
weight: 65
url: /tr/nodejs-java/edit-pdf/
keywords:
- PDF düzenle
- PDF metnini değiştir
- PDF'den PPTX'e
- PPTX'den PDF'e
- Node.js
- JavaScript
- Aspose.Slides
description: "PDF belgelerini JavaScript'te Aspose.Slides'e içe aktararak, metni değiştirerek ve değiştirilmiş sunumu PDF olarak kaydederek düzenleyin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, PDF içeriğini sayfalarını slayt olarak içe aktararak, sunumu değiştirerek ve tekrar PDF olarak dışa aktararak düzenlemenizi sağlar. Bu makale basit bir metin değiştirme işlemini gösterir. Sunum bellek içinde kalır, bu yüzden ara bir PPTX dosyası kaydetmek isteğe bağlıdır.

## **PDF'de Metin Değiştirme**

Sayfaları içe aktarmak için [addFromPdf](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/#addFromPdf), metni güncellemek için [replaceText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#replaceText) ve sonucu dışa aktarmak için [save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) kullanın.

Aşağıdaki örnek, `input.pdf` dosyasının içe aktarıldıktan sonra düzenlenebilir metin olarak "Draft" kelimesini içerdiğini varsayar. Bu kelimeyi "Final" ile değiştirir ve `edited.pdf` olarak yazar. İçe aktarmadan önce ilk slaytı temizlemek, çıktıda ekstra boş bir sayfanın oluşmasını önler. Arama, aynı harf duyarlılığıyla tam kelimeleri eşleştirir; `null` bir sonuç geri çağrısına ihtiyaç olmadığını gösterir.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Daha fazla seçenek için [Metin Arama ve Değiştirme](/slides/tr/nodejs-java/search-and-replace-text/) ve [PowerPoint'i PDF'e Dönüştür](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/) sayfalarına bakın.

{{% alert color="info" title="Note" %}}
Metin değiştirme, taranmış görüntülerdeki metin yerine içe aktarılmış metinler üzerinde çalışır. Dönüşüm, düzen ve biçimlendirmeyi etkileyebilir; bu nedenle çıktıyı gözden geçirin, özellikle değiştirme metni orijinalden daha uzun olduğunda.
{{% /alert %}}

## **SSS**

**PDF'yi dışa aktarmadan önce bir PPTX dosyası kaydetmem gerekiyor mu?**

Hayır. Aynı sunumu bellek içinde düzenleyip dışa aktarabilirsiniz. PPTX kopyasını yalnızca PowerPoint'te düzenlemeye devam etmek istiyorsanız kaydedin; [Sunumları Kaydet](/slides/tr/nodejs-java/save-presentation/) sayfasına bakın.

**Neden bazı metinler değişmeden kalabilir?**

Örnek, tam olarak aynı harf duyarlılığıyla "Draft" kelimesinin tamamını eşleştirir. Görüntü olarak içe aktarılmış veya ayrı metin çerçevelerine bölünmüş metinler aramayla mutlaka eşleşmeyebilir. İçe aktarılan içeriği kontrol edin ve belgeniz için aramayı ayarlayın.