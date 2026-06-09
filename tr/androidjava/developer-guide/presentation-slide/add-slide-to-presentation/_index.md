---
title: Android'de Sunumlara Slayt Ekleme
linktitle: Slayt Ekle
type: docs
weight: 10
url: /tr/androidjava/add-slide-to-presentation/
keywords:
- slayt ekle
- slayt oluştur
- boş slayt
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint ve OpenDocument sunumlarınıza kolayca slayt ekleyin—saniyeler içinde sorunsuz ve verimli slayt ekleme."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarına programlı olarak slayt eklemenizi sağlar. Bir sunum, master/düzen slaytları ve normal slaytlar içerir ve normal slaytlar sıfır tabanlı bir indeksle sıralanır. Her slaytın benzersiz bir kimliği vardır ve slaytsız sunum dosyaları desteklenmez.

Bu makale, bir `Presentation` nesnesi oluşturmayı, slayt koleksiyonuna erişmeyi, boş bir slayt eklemeyi, yeni eklenen slayt ile çalışmayı ve güncellenmiş sunumu kaydetmeyi açıklar. Ayrıca belirli bir konuma slayt ekleme, düzenleri kullanma ve yeni oluşturulan bir sunumda mevcut olan boş slaytı anlama gibi ilgili konuları da kapsar.

## **Bir Sunuma Slayt Ekleme**

Sunum dosyalarına slayt eklemeden önce, slaytlar hakkında bazı gerçekleri ele alalım. Her PowerPoint sunum dosyası **Master / Layout** slaytı ve diğer **Normal** slaytları içerir. Bu, bir sunum dosyasının en az bir veya daha fazla slayt içerdiği anlamına gelir. Slaytsız sunum dosyalarının Aspose.Slides for Android via Java tarafından desteklenmediğini bilmek önemlidir. Her slaytın benzersiz bir kimliği vardır ve tüm Normal Slaytlar sıfır tabanlı indeksle belirlenen bir sırada düzenlenir.

Aspose.Slides for Android via Java, geliştiricilerin sunumlarına boş slayt eklemelerine olanak tanır. Sunuma boş bir slayt eklemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) nesnesi tarafından sağlanan [Slides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) (içerik Slide nesnelerinin koleksiyonu) özelliğine bir referans atayarak [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection) sınıfını örnekleyin.
- [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection) nesnesi tarafından sağlanan [**addEmptySlide**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) metodunu çağırarak içerik slaytları koleksiyonunun sonuna boş bir slayt ekleyin.
- Yeni eklenen boş slayt ile bazı işlemler yapın.
- Son olarak, sunum dosyasını [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) nesnesiyle yazın.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation();
try {
    // SlideCollection sınıfını örnekle
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

## **FAQ**

**Yeni bir slaytı sadece sona eklemek yerine belirli bir konuma ekleyebilir miyim?**

Evet. Kütüphane slayt koleksiyonlarını ve [insert](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) işlemlerini destekler, böylece sadece sona eklemek yerine gerekli indekse bir slayt ekleyebilirsiniz.

**Bir düzen temelinde slayt eklerken tema/stiller korunur mu?**

Evet. Bir düzen, master'ından biçimlendirmeyi devralır ve yeni slayt seçilen düzen ve ona bağlı master'dan devralır.

**Slayt eklemeden önce yeni bir "boş" sunumda hangi slayt bulunur?**

Yeni oluşturulan bir sunum zaten indeks sıfırda bir boş slayt içerir. Bu, ekleme indekslerini hesaplarken dikkate alınması gereken bir durumdur.

**Master'da birçok seçenek varsa yeni bir slayt için "doğru" düzeni nasıl seçerim?**

Genellikle, gereken yapıya ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidelayouttype/)) uyan [LayoutSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/layoutslide/) seçilir. Böyle bir düzen eksikse, [master'a ekle](/slides/tr/androidjava/slide-layout/) ile master'a ekleyebilir ve ardından kullanabilirsiniz.