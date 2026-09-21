---
title: Python'da PDF Belgelerini Düzenle
linktitle: PDF'yi Düzenle
type: docs
weight: 65
url: /tr/python-net/edit-pdf/
keywords:
- PDF'yi düzenle
- PDF metnini değiştir
- PDF'den PPTX'e
- PPTX'ten PDF'e
- Python
- Aspose.Slides
description: "PDF belgelerini Python'da Aspose.Slides'e aktararak, metni değiştirerek ve değiştirilmiş sunumu PDF olarak kaydederek düzenleyin."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, PDF içeriğini sayfalarını slayt olarak içe aktararak, sunumu değiştirerek ve tekrar PDF olarak dışa aktararak düzenlemenizi sağlar. Bu makale basit bir metin değiştirmeyi gösterir. Sunum bellek içinde kalır, bu yüzden ara bir PPTX dosyası kaydetmek isteğe bağlıdır.

## **PDF'de Metin Değiştir**

Sayfaları içe aktarmak için [add_from_pdf](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_from_pdf/), metni güncellemek için [replace_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/replace_text/), ve sonucu dışa aktarmak için [save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) kullanın.

Aşağıdaki örnek, `input.pdf` dosyasının içe aktarıldıktan sonra düzenlenebilir metin olarak "Draft" kelimesini içerdiğini varsayar. Bu kelimeyi "Final" ile değiştirir ve `edited.pdf` olarak yazar. İçe aktarmadan önce ilk slaytı temizlemek, çıktıdaki ekstra boş sayfayı önler. Arama, aynı harf durumunda tam kelimeleri eşleştirir; `None` sonucun geri çağrısının gereksiz olduğunu ifade eder.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

Daha fazla seçenek için [Metin Ara ve Değiştir](/slides/tr/python-net/search-and-replace-text/) ve [PowerPoint'i PDF'e Dönüştür](/slides/tr/python-net/convert-powerpoint-to-pdf/) sayfalarına bakın.

{{% alert color="info" title="Not" %}}
Metin değiştirme, içe aktarılan metin üzerinde çalışır, taranmış görüntülerdeki metin üzerinde çalışmaz. Dönüştürme, düzen ve biçimlendirmeyi etkileyebilir, bu yüzden çıktıyı gözden geçirin, özellikle değiştirme metni orijinalden daha uzun olduğunda.
{{% /alert %}}

## **SSS**

**PDF'yi dışa aktarmadan önce bir PPTX dosyası kaydetmem gerekiyor mu?**

Hayır. Aynı sunumu bellek içinde düzenleyebilir ve dışa aktarabilirsiniz. PPTX bir kopyasını yalnızca PowerPoint'te düzenlemeye devam etmek istiyorsanız kaydedin; [Sunumları Kaydet](/slides/tr/python-net/save-presentation/) sayfasına bakın.

**Neden bazı metinler değişmeden kalabilir?**

Örnek, tam olarak aynı harf durumunda "Draft" tam kelimesini eşleştirir. Görüntü olarak içe aktarılan metin veya ayrı metin çerçevelerine bölünmüş metin, aramayla mutlaka eşleşmez. İçe aktarılan içeriği kontrol edin ve belgeniz için aramayı ayarlayın.