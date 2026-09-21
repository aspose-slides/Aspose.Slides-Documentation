---
title: C++'ta PDF Belgelerini Düzenleme
linktitle: PDF'yi Düzenle
type: docs
weight: 65
url: /tr/cpp/edit-pdf/
keywords:
- PDF düzenle
- PDF metnini değiştir
- PDF'den PPTX'e
- PPTX'den PDF'e
- C++
- Aspose.Slides
description: "PDF belgelerini C++'ta Aspose.Slides'e içe aktararak, metni değiştirerek ve değiştirilen sunumu tekrar PDF olarak kaydederek düzenleyin."
---
## **Genel Bakış**

Aspose.Slides for C++ PDF içeriğini sayfalarını slayt olarak içe aktararak, sunumu değiştirerek ve tekrar PDF olarak dışa aktararak düzenlemenizi sağlar. Bu makale basit bir metin değiştirme örneği sunar. Sunum bellek içinde kalır; bu nedenle ara bir PPTX dosyası kaydetmek isteğe bağlıdır.

## **PDF'de Metni Değiştir**

Sayfaları içe aktarmak için [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slidecollection/addfrompdf/), metni güncellemek için [Presentation::ReplaceText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/replacetext/), sonucu dışa aktarmak için ise [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) kullanın.

Aşağıdaki örnek, `input.pdf` dosyasının içe aktarıldıktan sonra düzenlenebilir bir “Draft” kelimesi içerdiğini varsayar. Bu kelime “Final” ile değiştirilir ve `edited.pdf` olarak yazılır. İçeri aktarmadan önce başlangıç slaytının temizlenmesi, çıktıda ekstra boş bir sayfanın oluşmasını önler. Arama, aynı harf büyüklüğüyle tam kelimeleri eşleştirir; `nullptr` sonuç geri çağrısının gerektiği anlamına gelmez.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

Daha fazla seçenek için [Metin Arama ve Değiştirme](/slides/tr/cpp/search-and-replace-text/) ve [PowerPoint'i PDF'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-pdf/) sayfalarına bakın.

{{% alert color="info" title="Not" %}}
Metin değiştirme, taranmış görüntüler içindeki metin yerine içe aktarılan metin üzerinde çalışır. Dönüştürme, düzen ve biçimlendirmeyi etkileyebilir; özellikle değiştirme metni orijinalden daha uzunsa çıktıyı gözden geçirin.
{{% /alert %}}

## **SSS**

**PDF dışa aktarmadan önce bir PPTX dosyası kaydetmem gerekir mi?**

Hayır. Sunumu bellek içinde düzenleyip aynı anda dışa aktarabilirsiniz. PPTX kopyasını yalnızca PowerPoint'te düzenlemeye devam etmek istiyorsanız kaydedin; [Sunumları Kaydet](/slides/tr/cpp/save-presentation/) sayfasına bakın.

**Bazı metinler neden değişmeden kalıyor?**

Örnek, tam olarak “Draft” kelimesini büyük/küçük harf duyarlılığıyla eşleştirir. Görüntü olarak içe aktarılan veya ayrı metin çerçevelerine bölünmüş metinler aramayla eşleşmeyebilir. İçe aktarılan içeriği kontrol edin ve belgeniz için aramayı gerektiği gibi ayarlayın.