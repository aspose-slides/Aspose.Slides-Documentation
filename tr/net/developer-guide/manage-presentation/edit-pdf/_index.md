---
title: .NET'te PDF Belgelerini Düzenle
linktitle: PDF Düzenle
type: docs
weight: 65
url: /tr/net/edit-pdf/
keywords:
- PDF düzenle
- PDF metnini değiştir
- PDF'den PPTX'e
- PPTX'den PDF'e
- .NET
- C#
- Aspose.Slides
description: "PDF belgelerini C# ile Aspose.Slides içine aktararak, metni değiştirerek ve değiştirilmiş sunumu tekrar PDF olarak kaydederek düzenleyin."
---
## **Genel Bakış**

Aspose.Slides for .NET, PDF içeriğini sayfalarını slayt olarak içe aktararak, sunumu değiştirerek ve tekrar PDF olarak dışa aktararak düzenlemenizi sağlar. Bu makale basit bir metin değiştirmeyi gösterir. Sunum hafızada kalır, bu nedenle ara bir PPTX dosyası kaydetmek isteğe bağlıdır.

## **PDF'de Metin Değiştirme**

Sayfaları içe aktarmak için AddFromPdf, metni güncellemek için ReplaceText ve sonucu dışa aktarmak için Save kullanın.

Aşağıdaki örnek, `input.pdf` dosyasının içe aktarım sonrasında düzenlenebilir bir metin olarak "Draft" kelimesini içerdiğini varsayar. Bu kelimeyi "Final" ile değiştirir ve `edited.pdf` olarak yazar. İçeri aktarmadan önce ilk slaytı temizlemek, çıktıda ekstra boş bir sayfa oluşmasını önler. Arama, aynı harf duyarlılığına sahip tam kelimelerle eşleşir; `null` bir sonuç geri araması gerektiği anlamına gelmez.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

Daha fazla seçenek için [Metin Arama ve Değiştirme](/slides/tr/net/search-and-replace-text/) ve [PowerPoint'i PDF'e Dönüştür](/slides/tr/net/convert-powerpoint-to-pdf/) sayfalarına bakın.

{{% alert color="info" title="Note" %}}
Metin değiştirme, içe aktarılmış metinler üzerinde çalışır, taranmış görüntülerdeki metinler üzerinde çalışmaz. Dönüştürme, düzen ve biçimlendirmeyi etkileyebilir, bu nedenle çıktıyı gözden geçirin, özellikle değiştirme metni orijinalinden daha uzun olduğunda.
{{% /alert %}}

## **SSS**

**PDF dışa aktarmadan önce bir PPTX dosyasını kaydetmem gerekiyor mu?**

Hayır. Aynı sunumu hafızada düzenleyip dışa aktarabilirsiniz. PPTX bir kopyasını yalnızca PowerPoint'te düzenlemeye devam etmek istiyorsanız kaydedin; [Sunumları Kaydet](/slides/tr/net/save-presentation/) sayfasına bakın.

**Neden bazı metinler değişmeden kalabilir?**

Örnek, tam olarak aynı harf duyarlılığına sahip "Draft" kelimesiyle eşleşir. Metin bir görüntü olarak içe aktarılmışsa veya ayrı metin çerçevelerine bölünmüşse aramayla eşleşmeyebilir. İçeri aktarılan içeriği kontrol edin ve belgeniz için aramayı ayarlayın.