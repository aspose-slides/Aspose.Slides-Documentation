---
title: JavaScript'te Sunumlara Slayt Ekleme
linktitle: Slayt Ekle
type: docs
weight: 10
url: /tr/nodejs-java/add-slide-to-presentation/
keywords:
- slayt ekle
- slayt oluştur
- boş slayt
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint ve OpenDocument sunumlarınıza kolayca slayt ekleyin — sorunsuz, verimli slayt ekleme saniyeler içinde."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarına programlı olarak slayt eklemenizi sağlar. Bir sunum master / düzen slaytları ve normal slaytlardan oluşur ve normal slaytlar sıfır tabanlı bir indeksle sıralanır. Her slayt benzersiz bir ID’ye sahiptir ve slaytsız sunum dosyaları desteklenmez.

Bu makale, bir `Presentation` nesnesi oluşturmayı, slayt koleksiyonuna erişmeyi, boş bir slayt eklemeyi, yeni eklenen slaytla çalışmayı ve güncellenmiş sunumu kaydetmeyi açıklar. Ayrıca belirli bir konuma slayt ekleme, düzenleri kullanma ve yeni oluşturulan bir sunumda mevcut olan boş slaytı anlama gibi ilgili konuları kapsar.

## **Sunuma Slayt Ekle**

Sunum dosyalarına slayt eklemeden önce, slaytlarla ilgili bazı gerçekleri ele alalım. Her PowerPoint sunum dosyası **Master / Layout** slaytı ve diğer **Normal** slaytları içerir. Bu, bir sunum dosyasının en az bir veya daha fazla slayt içerdiği anlamına gelir. Aspose.Slides for Node.js via Java, slaytsız sunum dosyalarını desteklemez. Her slayt benzersiz bir Id’ye sahiptir ve tüm Normal Slaytlar sıfır tabanlı indeksle belirlenen bir sırada dizilir.

Aspose.Slides for Node.js via Java, geliştiricilerin sunumlarına boş slaytlar eklemesine olanak tanır. Sunuma boş bir slayt eklemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) nesnesinin açıkladığı [Slides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getSlides--) (içerik Slayt nesneleri koleksiyonu) özelliğine bir referans ayarlayarak [SlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection) sınıfının bir örneğini oluşturun.
- [SlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection) nesnesinin açıkladığı [**addEmptySlide**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) metodunu çağırarak içerik slaytları koleksiyonunun sonuna boş bir slayt ekleyin.
- Yeni eklenen boş slayt ile bazı işlemler yapın.
- Son olarak, [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) nesnesini kullanarak sunum dosyasını yazın.

```javascript
// Sunum dosyasını temsil eden Presentation sınıfını örnekle
var pres = new aspose.slides.Presentation();
try {
    // SlideCollection sınıfını örnekle
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Slides koleksiyonuna boş bir slayt ekle
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Yeni eklenen slayt üzerinde bazı işlemler yap
    // PPTX dosyasını diske kaydet
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**Belirli bir konuma yeni bir slayt ekleyebilir miyim, sadece sona değil?**

Evet. Kütüphane slayt koleksiyonlarını ve [insert](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/insertclone/) işlemlerini destekler, böylece sadece sona eklemek yerine istenen indekse bir slayt ekleyebilirsiniz.

**Bir düzen temelinde slayt eklerken tema/stiller korunuyor mu?**

Evet. Bir düzen, ustasından biçimlendirmeyi devralır ve yeni slayt, seçilen düzen ve ona bağlı ustadan miras alır.

**Slayt eklemeden önce yeni “boş” bir sunumda hangi slayt bulunmaktadır?**

Yeni oluşturulan bir sunum zaten sıfır indeksli bir boş slayt içerir. Bu, ekleme indekslerini hesaplarken dikkate alınması gereken önemli bir noktadır.

**Usta birden çok seçenek sunduğunda yeni bir slayt için “doğru” düzeni nasıl seçerim?**

Genellikle gereken yapıya (ör. [Başlık ve İçerik, İki İçerik, vb.](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidelayouttype/)) uyan [LayoutSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/layoutslide/) seçilir. Böyle bir düzen eksikse, [mastera ekleyebilir](/slides/tr/nodejs-java/slide-layout/) ve ardından kullanabilirsiniz.