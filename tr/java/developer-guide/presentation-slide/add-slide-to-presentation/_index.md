---
title: Java'da Sunumlara Slayt Ekle
linktitle: Slayt Ekle
type: docs
weight: 10
url: /tr/java/add-slide-to-presentation/
keywords:
- slayt ekle
- slayt oluştur
- boş slayt
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument sunumlarınıza slaytları kolayca ekleyin—saniyeler içinde sorunsuz ve verimli slayt ekleme."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarına programlı olarak slayt eklemenizi sağlar. Bir sunum, master / layout slaytları ve normal slaytlar içerir ve normal slaytlar sıfır tabanlı bir dizine göre düzenlenir. Her slaytın benzersiz bir kimliği vardır ve slaytsız sunum dosyaları desteklenmez.

Bu makale, bir `Presentation` nesnesi oluşturmayı, slayt koleksiyonuna erişmeyi, boş bir slayt eklemeyi, yeni eklenen slayt ile çalışmayı ve güncellenen sunumu kaydetmeyi açıklar. Ayrıca belirli bir konuma slayt ekleme, düzen kullanma ve yeni oluşturulan bir sunumda mevcut olan boş slaytı anlama gibi ilgili konuları da kapsar.

## **Sunuma Slayt Ekleme**

Sunum dosyalarına slayt eklemeden önce slaytlar hakkında bazı gerçekleri inceleyelim. Her PowerPoint sunum dosyası **Master / Layout** slaytı ve diğer **Normal** slaytları içerir. Bu, bir sunum dosyasının en az bir veya daha fazla slayt içerdiği anlamına gelir. Aspose.Slides for Java tarafından slaytsız sunum dosyaları desteklenmez. Her slaytın benzersiz bir Id’si vardır ve tüm Normal Slaytlar sıfır tabanlı indeksle belirtilen bir sırada düzenlenir.

Aspose.Slides for Java, geliştiricilerin sunumlarına boş slayt eklemelerine olanak tanır. Sunuma boş bir slayt eklemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
- [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) nesnesinin açığa çıkardığı [Slides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) (içerik Slide nesnelerinin koleksiyonu) özelliğine bir referans ayarlayarak [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection) sınıfının bir örneğini alın.  
- [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection) nesnesinin açığa çıkardığı **addEmptySlide**(https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) yöntemini çağırarak içerik slaytları koleksiyonunun sonuna boş bir slayt ekleyin.  
- Yeni eklenen boş slayt ile bazı işlemler yapın.  
- Son olarak, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) nesnesini kullanarak sunum dosyasını yazın.

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluştur
Presentation pres = new Presentation();
try {
    // SlideCollection sınıfını oluştur
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Slides koleksiyonuna boş bir slayt ekle
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Yeni eklenen slayt üzerinde bazı işlemler yap

    // PPTX dosyasını diske kaydet
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **SSS**

**Belirli bir konuma yeni bir slayt ekleyebilir miyim, sadece sona değil?**

Evet. Kütüphane slayt koleksiyonlarını ve [insert](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) işlemlerini destekler; böylece yalnızca sona eklemek yerine istenen indeksde bir slayt ekleyebilirsiniz.

**Bir düzene dayalı slayt eklerken tema/stiller korunur mu?**

Evet. Bir layout, master’dan biçimlendirmeyi devralır ve yeni slayt seçilen layout ve ilgili master’dan devralır.

**Slayt eklemeden önce yeni bir "boş" sunumda hangi slayt bulunur?**

Yeni oluşturulan bir sunum zaten indeks sıfırda bir boş slayt içerir. Bu, ekleme indekslerini hesaplarken dikkate alınması gereken bir durumdur.

**Master birden fazla seçenek içeriyorsa yeni bir slayt için "doğru" düzeni nasıl seçerim?**

Genellikle gereken yapıya uygun olan [LayoutSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/layoutslide/) (ör. **Title and Content**, **Two Content** vb.) seçilir. Böyle bir layout eksikse, [mastera ekleyebilir](/slides/tr/java/slide-layout/) ve ardından onu kullanabilirsiniz.