---
title: Java'da Sunum Slaytlarını Klonla
linktitle: Slaytları Klonla
type: docs
weight: 35
url: /tr/java/clone-slides/
keywords:
- slaytı klonla
- slaytı kopyala
- slaytı kaydet
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint slaytlarını hızlıca çoğaltın. Kod örneklerimizi izleyerek PPT oluşturmayı saniyeler içinde otomatikleştirin ve manuel işi ortadan kaldırın."
---
## **Giriş**

Klonlama, bir şeyin tam bir kopyasını veya replikasını oluşturma sürecidir. Aspose.Slides for Java, herhangi bir slaytın bir kopyasını veya klonunu oluşturmayı ve ardından bu klonlanmış slaytı mevcut veya başka bir açık sunuma eklemeyi de mümkün kılar. Slayt klonlama işlemi, geliştiricilerin özgün slaytı değiştirmeden üzerinde değişiklik yapabileceği yeni bir slayt oluşturur. Bir slaytı klonlamanın birkaç olası yolu vardır:

- Sunum içinde Sona Klonla.
- Sunum içinde Başka Bir Konuma Klonla.
- Başka bir sunumda Sona Klonla.
- Başka bir sunumda Başka Bir Konuma Klonla.
- Başka bir sunumda Belirli Bir Konuma Klonla.

Aspose.Slides for Java'da, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesi tarafından sunulan (a collection of [ISlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide) objects) [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ve [insertClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metodlarını sağlayarak yukarıdaki slayt klonlama türlerini gerçekleştirir.

## **Bir Sunumun Sonunda Slayt Klonlama**
Mevcut slaytların sonuna aynı sunum dosyası içinde bir slaytı klonlamak ve ardından kullanmak istiyorsanız, aşağıda listelenen adımlara göre [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metodunu kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.
2. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesi tarafından sunulan Slides koleksiyonuna referans vererek [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) sınıfını örnekleyin.
3. [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metodunu çağırın ve klonlanacak slaytı [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metoduna parametre olarak geçin.
4. Değiştirilmiş sunum dosyasını yazın.

Aşağıdaki örnekte, bir slaytı (sunumun ilk konumunda – sıfır indeksinde – bulunan) sunumun sonuna klonladık.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonlayın
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Değiştirilmiş sunumu diske yazın
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Bir Sunum İçinde Başka Bir Konuma Slayt Klonlama**
Aynı sunum dosyası içinde bir slaytı klonlamak ve ardından farklı bir konumda kullanmak istiyorsanız, [insertClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metodunu kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.
2. Sınıfı, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesi tarafından sunulan **Slides** koleksiyonuna referans vererek örnekleyin.
3. [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [insertClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metodunu çağırın ve klonlanacak slaytı yeni konumun indeksiyle birlikte [insertClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) metoduna parametre olarak geçin.
4. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

Aşağıdaki örnekte, bir slaytı (sunumun sıfır indeksinde – konum 1 – bulunan) indeks 1 – Konum 2 –'ye klonladık.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonlayın
    ISlideCollection slds = pres.getSlides();

    // İstenen slaytı aynı sunumdaki belirtilen indekse klonlayın
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Değiştirilmiş sunumu diske yazın
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Başka Bir Sunumun Sonunda Slayt Klonlama**
Bir sunumdan slaytı klonlamanız ve başka bir sunum dosyasında mevcut slaytların sonuna eklemeniz gerekiyorsa:

1. Slaytın klonlanacağı sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.
2. Slaytın ekleneceği hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.
3. Hedef sunumun Presentation nesnesi tarafından sunulan **Slides** koleksiyonuna referans vererek [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection) sınıfını örnekleyin.
4. [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metodunu çağırın ve kaynak sunumdan slaytı [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metoduna parametre olarak geçin.
5. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, bir slaytı (kaynak sunumun ilk indeksinden) hedef sunumun sonuna klonladık.

```java
// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Hedef PPTX için Presentation sınıfını örnekleyin (slaytın klonlanacağı yer)
    Presentation destPres = new Presentation();
    try {
        // İstenen slaytı kaynak sunumdan hedef sunumdaki slayt koleksiyonunun sonuna klonlayın
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Hedef sunumu diske yazın
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Başka Bir Sunumda Başka Bir Konuma Slayt Klonlama**
Bir sunumdan slaytı klonlamanız ve başka bir sunum dosyasında belirli bir konuma eklemeniz gerekiyorsa:

1. Slaytın klonlanacağı kaynak sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.
2. Slaytın ekleneceği sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.
3. Hedef sunumun Presentation nesnesi tarafından sunulan Slides koleksiyonuna referans vererek [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) sınıfını örnekleyin.
4. [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [insertClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) metodunu çağırın ve kaynak sunumdan slaytı istenen konumla birlikte [insertClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) metoduna parametre olarak geçin.
5. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, bir slaytı (kaynak sunumun sıfır indeksinden) hedef sunumun indeks 1 (konum 2)'ye klonladık.

```java
// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Hedef PPTX için Presentation sınıfını örnekleyin (slaytın klonlanacağı yer)
    Presentation destPres = new Presentation();
    try {
        // İstenen slaytı kaynak sunumdan hedef sunumdaki slayt koleksiyonunun sonuna klonlayın
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Hedef sunumu diske yazın
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Başka Bir Sunumda Belirli Bir Konuma Slayt Klonlama**
Bir sunumdan ana slaytı (master slide) olan bir slaytı klonlamanız ve başka bir sunumda kullanmanız gerekiyorsa, önce istenen ana slaytı kaynak sunumdan hedef sunuma klonlamalısınız. Daha sonra bu ana slaytı, ana slaytı olan slaytı klonlamak için kullanmanız gerekir. [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) metodu, kaynak sunumdan değil hedef sunumdan bir ana slayt bekler. Ana slaytı olan slaytı klonlamak için aşağıdaki adımları izleyin:

1. Slaytın klonlanacağı kaynak sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.
2. Slaytı klonlayacağınız hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.
3. Klonlanacak slayta ve ona ait ana slayta erişin.
4. Hedef sunumun Presentation nesnesi tarafından sunulan Masters koleksiyonuna referans vererek [IMasterSlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IMasterSlideCollection) sınıfını örnekleyin.
5. [IMasterSlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IMasterSlideCollection) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metodunu çağırın ve kaynak PPTX'ten klonlanacak ana slaytı [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metoduna parametre olarak geçin.
6. Hedef sunumun Presentation nesnesi tarafından sunulan Slides koleksiyonuna referans ayarlayarak [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) sınıfını örnekleyin.
7. [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metodunu çağırın ve kaynak sunumdan klonlanacak slaytı ve ana slaytı [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metoduna parametre olarak geçin.
8. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, ana slaytı (kaynak sunumun sıfır indeksinde bulunan) olan bir slaytı, kaynak slayttan alınan ana slaytı kullanarak hedef sunumun sonuna klonladık.

```java
// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Hedef sunum (slaytın klonlanacağı yer) için Presentation sınıfını örnekleyin
    Presentation destPres = new Presentation();
    try {
        // Kaynak sunumdaki slayt koleksiyonundan ISlide'ı ve
        // Master slaytı örnekleyin
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // İstenen master slaytı kaynak sunumdan master koleksiyonuna klonlayın
        // Hedef sunumda
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // İstenen master slaytı kaynak sunumdan master koleksiyonuna klonlayın
        // Hedef sunumda
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // İstenen master ile kaynak sunumdan slaytı hedef sunumdaki slayt koleksiyonunun sonuna klonlayın
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

## **Belirli Bir Bölümün Sonunda Slayt Klonlama**
Bir slaytı klonlamak ve aynı sunum dosyasında farklı bir bölüme eklemek istiyorsanız, [**addClone**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) metodunu [**ISlideCollection**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection) arayüzü aracılığıyla kullanın. Aspose.Slides for Java, bir slaytı ilk bölümden klonlamanızı ve ardından bu klonlanmış slaytı aynı sunumun ikinci bölümüne eklemenizi sağlar.

Aşağıdaki kod snippet'i, bir slaytı nasıl klonlayıp belirli bir bölüme ekleyeceğinizi gösterir.

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

**Konuşmacı notları ve inceleme yorumları klonlanıyor mu?**

Evet. Not sayfası ve inceleme yorumları klona dahil edilir. İstemiyorsanız, eklemeden sonra [kaldırın](/slides/tr/java/presentation-notes/).

**Grafikler ve veri kaynakları nasıl ele alınır?**

Grafik nesnesi, biçimlendirme ve gömülü veriler kopyalanır. Grafik dış bir kaynağa (ör. OLE gömülü bir çalışma kitabı) bağlanmışsa, bu bağlantı bir [OLE nesnesi](/slides/tr/java/manage-ole/) olarak korunur. Dosyalar arasında taşındıktan sonra veri kullanılabilirliğini ve yenileme davranışını doğrulayın.

**Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?**

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve seçtiğiniz bir [bölüme](/slides/tr/java/slide-section/) yerleştirebilirsiniz. Hedef bölüm mevcut değilse, önce oluşturun ve ardından slaytı ona taşıyın.