---
title: Android'de Sunum Slaytlarını Klonla
linktitle: Slaytları Klonla
type: docs
weight: 35
url: /tr/androidjava/clone-slides/
keywords:
  - slayt klonlama
  - slaytı kopyala
  - slaytı kaydet
  - PowerPoint
  - OpenDocument
  - sunum
  - Android
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Android ile PowerPoint slaytlarını çoğaltın. Java kod örneklerimizle saniyeler içinde PPT oluşturmayı otomatikleştirin ve manuel işi ortadan kaldırın."
---
## **Giriş**

Klonlama, bir şeyin tam bir kopyasını veya benzerini oluşturma sürecidir. Aspose.Slides for Android via Java, herhangi bir slaytın bir kopyasını veya klonunu oluşturmayı ve ardından bu klonlanmış slaytı mevcut veya başka bir açık sunuma eklemeyi de mümkün kılar. Slayt klonlama süreci, orijinal slaytı değiştirmeden geliştiriciler tarafından değiştirilebilecek yeni bir slayt oluşturur. Bir slaytı klonlamanın birkaç olası yolu vardır:

- Sunum içinde sona klonla.
- Sunum içinde başka bir konuma klonla.
- Başka bir sunumda sona klonla.
- Başka bir sunumda başka bir konuma klonla.
- Başka bir sunumda belirli bir konuma klonla.

Aspose.Slides for Android via Java’da, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) nesnesi tarafından sunulan (bir [ISlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlide) nesnesi koleksiyonu) [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ve [insertClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) yöntemlerini sağlayarak yukarıdaki slayt klonlama türlerini gerçekleştirebilir.

## **Sunumun Sonuna Slayt Kopyalama**
Mevcut slaytların sonuna aynı sunum dosyası içinde bir slaytı klonlamak ve kullanmak istiyorsanız, aşağıdaki adımlara göre [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yöntemini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) nesnesi tarafından sunulan Slides koleksiyonuna referans vererek [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) sınıfını örnekleyin.
3. [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yöntemini çağırın ve klonlanacak slaytı [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yöntemine parametre olarak geçin.
4. Değiştirilmiş sunum dosyasını yazın.

Aşağıda verilen örnekte, bir slaytı (sunumun ilk konumunda – sıfır indeks – bulunan) sunumun sonuna klonladık.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonlayın
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Değiştirilmiş sunumu diske kaydedin
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Sunum İçinde Başka Bir Konuma Slayt Kopyalama**
Aynı sunum dosyası içinde farklı bir konuma bir slaytı klonlamak ve kullanmak istiyorsanız, [insertClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) yöntemini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) nesnesi tarafından sunulan **Slides** koleksiyonuna referans vererek sınıfı örnekleyin.
3. [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [insertClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) yöntemini çağırın ve klonlanacak slaytı yeni konum indeksiyle birlikte [insertClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) yöntemine parametre olarak geçin.
4. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıda verilen örnekte, bir slaytı (sunumun sıfır indeksinde – pozisyon 1 – bulunan) indeks 1 – Pozisyon 2 –'ye klonladık.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonlayın
    ISlideCollection slds = pres.getSlides();

    // İstenen slaytı aynı sunumda belirtilen indekse klonlayın
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Değiştirilmiş sunumu diske kaydedin
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Başka Bir Sunumun Sonuna Slayt Kopyalama**
Bir sunumdan başka bir sunuma slaytı klonlamanız ve mevcut slaytların sonuna eklemeniz gerektiğinde:

1. Slaytın klonlanacağı sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Slaytın ekleneceği hedef sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
3. Hedef sunumun Presentation nesnesi tarafından sunulan **Slides** koleksiyonuna referans vererek [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection) sınıfını örnekleyin.
4. [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yöntemini çağırın ve kaynak sunumdan slaytı [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) yöntemine parametre olarak geçin.
5. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıda verilen örnekte, bir slaytı (kaynak sunumun ilk indeksinden) hedef sunumun sonuna klonladık.

```java
// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Hedef PPTX (slaytın klonlanacağı yer) için Presentation sınıfını örnekleyin
    Presentation destPres = new Presentation();
    try {
        // Kaynak sunumdan istenen slaytı hedef sunumdaki slayt koleksiyonunun sonuna klonlayın
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Hedef sunumu diske kaydedin
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Başka Bir Sunumda Başka Bir Konuma Slayt Kopyalama**
Bir sunumdan başka bir sunuma slaytı belirli bir konuma klonlamanız gerektiğinde:

1. Slaytın klonlanacağı kaynak sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Slaytın ekleneceği sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
3. Hedef sunumun Presentation nesnesi tarafından sunulan Slides koleksiyonuna referans vererek [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) sınıfını örnekleyin.
4. [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [insertClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) yöntemini çağırın ve kaynak sunumdan slaytı istediğiniz konumla birlikte [insertClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) yöntemine parametre olarak geçin.
5. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıda verilen örnekte, bir slaytı (kaynak sunumun sıfır indeksinden) hedef sunumun indeks 1 (pozisyon 2) konumuna klonladık.

```java
// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Hedef PPTX (slaytın klonlanacağı yer) için Presentation sınıfını örnekleyin
    Presentation destPres = new Presentation();
    try {
        // Kaynak sunumdan istenen slaytı hedef sunumdaki slayt koleksiyonunun sonuna klonlayın
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Hedef sunumu diske kaydedin
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Başka Bir Sunumda Belirli Bir Konuma Slayt Kopyalama**
Bir sunumdan başka bir sunuma master slaytı olan bir slaytı klonlamanız gerektiğinde, önce istediğiniz master slaytı kaynak sunumdan hedef sunuma klonlamalısınız. Ardından bu master slaytı, master slaytı olan slaytı klonlamak için kullanmanız gerekir. [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) yöntemi, kaynak sunumdan değil hedef sunumdan bir master slaytı bekler. Master slaytı olan bir slaytı klonlamak için aşağıdaki adımları izleyin:

1. Slaytın klonlanacağı kaynak sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Slaytın klonlanacağı hedef sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
3. Klonlanacak slayta ve onun master slaytına erişin.
4. Hedef sunumun Presentation nesnesi tarafından sunulan Masters koleksiyonuna referans vererek [IMasterSlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IMasterSlideCollection) sınıfını örnekleyin.
5. [IMasterSlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IMasterSlideCollection) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yöntemini çağırın ve kaynak PPTX'den klonlanacak master'ı [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yöntemine parametre olarak geçin.
6. Hedef sunumun Presentation nesnesi tarafından sunulan Slides koleksiyonuna referans ayarlayarak [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) sınıfını örnekleyin.
7. [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yöntemini çağırın ve kaynak sunumdan klonlanacak slaytı ve master slaytı [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) yöntemine parametre olarak geçin.
8. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıda verilen örnekte, bir master slaytı (kaynak sunumun sıfır indeksindeki) bir slaytı, kaynak slayttan alınan master kullanarak hedef sunumun sonuna klonladık.

```java
// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Hedef sunum (slaytın klonlanacağı yer) için Presentation sınıfını örnekleyin
    Presentation destPres = new Presentation();
    try {
        // Kaynak sunumdaki slayt koleksiyonundan ISlide nesnesini ve
        // master slaytı
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // İstenen master slaytı kaynak sunumdan hedef sunumdaki master koleksiyonuna klonlayın
        // Hedef sunum
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // İstenen master slaytı kaynak sunumdan hedef sunumdaki master koleksiyonuna klonlayın
        // Hedef sunum
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Kaynak sunumdan istenen slaytı, istenen master ile birlikte hedef sunumdaki slayt koleksiyonunun sonuna klonlayın
        // Hedef sunumdaki slayt koleksiyonuna
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Hedef sunumu diske kaydedin
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Belirtilen Bölümün Sonuna Slayt Kopyalama**
Eğer bir slaytı klonlamak ve aynı sunum dosyası içinde farklı bir bölüme eklemek istiyorsanız, [**addClone**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) yöntemini [**ISlideCollection**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection) arayüzünden kullanabilirsiniz. Aspose.Slides for Android via Java, bir slaytı ilk bölümden klonlamayı ve ardından bu klonlanmış slaytı aynı sunumun ikinci bölümüne eklemeyi mümkün kılar.

Aşağıdaki kod örneği, bir slaytı nasıl klonlayacağınızı ve klonlanmış slaytı belirtilen bir bölüme nasıl ekleyeceğinizi gösterir.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Hedef sunumu diske kaydedin
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Konuşmacı notları ve gözden geçirme yorumları klonlanıyor mu?**

Evet. Not sayfası ve gözden geçirme yorumları klona dahil edilir. İstemiyorsanız, eklemeden sonra [kaldırın](/slides/tr/androidjava/presentation-notes/).

**Grafikler ve veri kaynakları nasıl ele alınır?**

Grafik nesnesi, biçimlendirme ve gömülü veri kopyalanır. Grafik dış bir kaynağa (ör. OLE gömülü bir çalışma kitabı) bağlıysa, bu bağlantı bir [OLE nesnesi](/slides/tr/androidjava/manage-ole/) olarak korunur. Dosyalar arasında taşıdıktan sonra veri kullanılabilirliğini ve yenileme davranışını doğrulayın.

**Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?**

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve seçtiğiniz bir [bölüme](/slides/tr/androidjava/slide-section/) yerleştirebilirsiniz. Hedef bölüm yoksa, önce oluşturun ve ardından slaytı ona taşıyın.