---
title: Python üzerinden Java ile PDF Belgelerini Düzenle
linktitle: PDF Düzenle
type: docs
weight: 65
url: /tr/python-java/edit-pdf/
keywords:
- PDF düzenle
- PDF metnini değiştir
- PDF'den PPTX'e
- PPTX'ten PDF'e
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ile PDF belgelerini Aspose.Slides'e aktararak, metni değiştirip, değiştirilmiş sunumu tekrar PDF olarak kaydederek düzenleyin."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, PDF içeriğini sayfalarını slayt olarak içe aktararak, sunumu değiştirerek ve tekrar PDF olarak dışa aktararak düzenlemenize olanak tanır. Bu makale basit bir metin değiştirmeyi gösterir. Sunum hafızada kalır, bu yüzden ara bir PPTX dosyası kaydetmek isteğe bağlıdır.

## **PDF'de Metin Değiştirme**

Sayfaları içe aktarmak için [addFromPdf](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidecollection/#addFromPdf), metni güncellemek için [replaceText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#replaceText), ve sonucu dışa aktarmak için [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) kullanın.

Aşağıdaki örnek, `input.pdf` dosyasının içe aktarıldıktan sonra düzenlenebilir metin olarak "Draft" kelimesini içerdiğini varsayar. Bu kelimeyi "Final" ile değiştirir ve `edited.pdf` olarak yazar. İçe aktarmadan önce ilk slaytı temizlemek, çıktıda ekstra boş bir sayfanın oluşmasını önler. Arama, aynı harf büyüklüğüyle tam kelimeleri eşleştirir; `None` sonuç geri çağrısının gerekmediği anlamına gelir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Daha fazla seçenek için, [Search and Replace Text](/slides/tr/python-java/search-and-replace-text/) ve [Convert PowerPoint to PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/) bakınız.

{{% alert color="info" title="Note" %}}
Metin değiştirme, içe aktarılan metin üzerinde çalışır, taranmış görüntülerdeki metin üzerinde değil. Dönüştürme, düzen ve biçimlendirmeyi etkileyebilir, bu yüzden çıktıyı gözden geçirin, özellikle değiştirme metni orijinalden daha uzun olduğunda.
{{% /alert %}}

## **SSS**

**PDF dışa aktarmadan önce bir PPTX dosyasını kaydetmem gerekiyor mu?**

Hayır. Aynı sunumu hafızada düzenleyip dışa aktarabilirsiniz. PPTX kopyasını yalnızca PowerPoint'te düzenlemeye devam etmek isterseniz kaydedin; [Save Presentations](/slides/tr/python-java/save-presentation/) bakınız.

**Neden bazı metinler değişmeden kalabilir?**

Örnek, tam harf büyüklüğüyle "Draft" kelimesini tam olarak eşleştirir. Görüntü olarak içe aktarılan metin veya ayrı metin çerçevelerine bölünmüş metin, aramayla mutlaka eşleşmez. İçe aktarılan içeriği kontrol edin ve belgeniz için aramayı ayarlayın.