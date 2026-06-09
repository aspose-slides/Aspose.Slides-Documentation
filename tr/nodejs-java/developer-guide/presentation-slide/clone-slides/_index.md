---
title: JavaScript'te Sunum Slaytlarını Klonla
linktitle: Slaytları Klonla
type: docs
weight: 35
url: /tr/nodejs-java/clone-slides/
keywords:
- slaytı klonla
- slaytı kopyala
- slaytı kaydet
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile PowerPoint slaytlarını hızlıca çoğaltın. Kod örneklerimizi izleyerek PPT oluşturmayı saniyeler içinde otomatikleştirin ve manuel işleri ortadan kaldırın."
---
## **Giriş**

Klonlama, bir şeyin tam bir kopyasını veya replikasını oluşturma sürecidir. Aspose.Slides for Node.js via Java, herhangi bir slaytı kopyalamayı veya klonlamayı ve ardından bu klonlanan slaytı mevcut veya başka bir açık sunuma eklemeyi de mümkün kılar. Slayt klonlama işlemi, orijinal slaytı değiştirmeden geliştiriciler tarafından değiştirilebilecek yeni bir slayt oluşturur. Bir slaytı klonlamanın birkaç olası yolu vardır:

- Sunum içinde Sona Klonla.
- Sunum içinde Başka Bir Konuma Klonla.
- Başka bir Sunumda Sona Klonla.
- Başka bir Sunumda Başka Bir Konuma Klonla.
- Başka bir Sunumda Belirli bir Konuma Klonla.

Aspose.Slides for Node.js via Java’da, [Presentation] nesnesi tarafından sunulan (bir [Slide] nesnesi koleksiyonu), yukarıdaki slayt klonlama türlerini gerçekleştirmek için [addClone] ve [insertClone] metodlarını sağlar.

## **Sunum içinde Sona Klonla**
Mevcut slaytların sonuna aynı sunum dosyasında bir slaytı klonlamak ve ardından kullanmak istiyorsanız, aşağıdaki adımlara göre [addClone] metodunu kullanın:

1. Bir [Presentation] sınıfının bir örneğini oluşturun.
1. [Presentation] nesnesi tarafından sunulan Slides koleksiyonuna başvurarak [SlideCollection] sınıfını örnekleyin.
1. [SlideCollection] nesnesi tarafından sunulan [addClone] metodunu çağırın ve klonlanacak slaytı [addClone] metoduna parametre olarak geçin.
1. Değiştirilmiş sunum dosyasını yazın.

Aşağıdaki örnekte, bir slaytı (sunumun ilk konumunda – sıfır indeks – bulunan) sunumun sonuna klonladık.

```javascript
// Sunum dosyasını temsil eden Presentation sınıfını örnekle
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Aynı sunumdaki slayt koleksiyonunun sonuna istenen slaytı klonla
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Değiştirilmiş sunumu diske kaydet
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Sunum içinde Başka Bir Konuma Klonla**
Bir slaytı klonlamak ve aynı sunum dosyasında farklı bir konuma eklemek istiyorsanız, [insertClone] metodunu kullanın:

1. Bir [Presentation] sınıfının bir örneğini oluşturun.
1. [Presentation] nesnesi tarafından sunulan **Slides** koleksiyonuna başvurarak sınıfı örnekleyin.
1. [SlideCollection] nesnesi tarafından sunulan [insertClone] metodunu çağırın ve klonlanacak slaytı yeni konumun indeksiyle birlikte [insertClone] metoduna parametre olarak geçin.
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, bir slaytı (sunumun sıfır indeksinde – konum 1 – bulunan) indeks 1 – Konum 2 – üzerine klonladık.

```javascript
// Sunum dosyasını temsil eden Presentation sınıfını örnekle
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Aynı sunumdaki slayt koleksiyonunun sonuna istenen slaytı klonla
    var slds = pres.getSlides();
    // Aynı sunumdaki belirli indekse istenen slaytı klonla
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Değiştirilmiş sunumu diske kaydet
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Başka bir Sunumda Sona Klonla**
Mevcut slaytların sonuna, bir sunumdan bir slaytı klonlayıp başka bir sunum dosyasında kullanmanız gerekiyorsa:

1. Slaytın klonlanacağı sunumu içeren bir [Presentation] sınıfının örneğini oluşturun.
1. Slaytın ekleneceği hedef sunumu içeren bir [Presentation] sınıfının örneğini oluşturun.
1. Hedef sunumun Presentation nesnesi tarafından sunulan **Slides** koleksiyonuna başvurarak [SlideCollection] sınıfını örnekleyin.
1. [SlideCollection] nesnesi tarafından sunulan [addClone] metodunu çağırın ve kaynak sunumdan slaytı [addClone] metoduna parametre olarak geçin.
1. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, bir slaytı (kaynak sunumun ilk indeksinden) hedef sunumun sonuna klonladık.

```javascript
// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Slide'ın klonlanacağı hedef PPTX için Presentation sınıfını örnekle
    var destPres = new aspose.slides.Presentation();
    try {
        // Klonlanan slaytı kaynak sunumdan hedef sunumdaki slayt koleksiyonunun sonuna ekle
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Hedef sunumu diske kaydet
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Başka bir Sunumda Başka Bir Konuma Klonla**
Bir sunumdan bir slaytı klonlayıp başka bir sunum dosyasında belirli bir konuma eklemeniz gerekiyorsa:

1. Slaytın klonlanacağı kaynak sunumu içeren bir [Presentation] sınıfının örneğini oluşturun.
1. Slaytın ekleneceği sunumu içeren bir [Presentation] sınıfının örneğini oluşturun.
1. Hedef sunumun Presentation nesnesi tarafından sunulan Slides koleksiyonuna başvurarak [SlideCollection] sınıfını örnekleyin.
1. [SlideCollection] nesnesi tarafından sunulan [insertClone] metodunu çağırın ve kaynak sunumdan slaytı istenen konumla birlikte [insertClone] metoduna parametre olarak geçin.
1. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, bir slaytı (kaynak sunumun sıfır indeksinden) hedef sunumda indeks 1 (konum 2) üzerine klonladık.

```javascript
// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Slide'ın klonlanacağı hedef PPTX için Presentation sınıfını örnekle
    var destPres = new aspose.slides.Presentation();
    try {
        // Klonlanan slaytı kaynak sunumdan hedef sunumdaki slayt koleksiyonunun sonuna ekle
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // Hedef sunumu diske kaydet
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Başka bir Sunumda Belirli Bir Konuma Klonla**
Bir sunumdan master slaytı olan bir slaytı klonlayıp başka bir sunumda kullanmanız gerekiyorsa, önce istediğiniz master slaytı kaynak sunumdan hedef sunuma klonlamanız gerekir. Ardından bu master slaytı, master slaytı olan slaytı klonlamak için kullanmalısınız. **addClone(ISlide, IMasterSlide, boolean)** metodu, kaynak sunumdan değil, hedef sunumdan bir master slayt bekler. Bir slaytı master ile klonlamak için aşağıdaki adımları izleyin:

1. Slaytın klonlanacağı kaynak sunumu içeren bir [Presentation] sınıfının örneğini oluşturun.
1. Slaytın klonlanacağı hedef sunumu içeren bir [Presentation] sınıfının örneğini oluşturun.
1. Klonlanacak slayta ve ona bağlı master slayta erişin.
1. Hedef sunumun Presentation nesnesi tarafından sunulan Masters koleksiyonuna başvurarak [MasterSlideCollection] sınıfını örnekleyin.
1. [MasterSlideCollection] nesnesi tarafından sunulan [addClone] metodunu çağırın ve kaynak PPTX'ten klonlanacak master'ı [addClone] metoduna parametre olarak geçin.
1. Hedef sunumun Presentation nesnesi tarafından sunulan Slides koleksiyonuna referans vererek [SlideCollection] sınıfını örnekleyin.
1. [SlideCollection] nesnesi tarafından sunulan [addClone] metodunu çağırın ve kaynak sunumdan klonlanacak slaytı ve master slaytı [addClone] metoduna parametre olarak geçin.
1. Değiştirilmiş hedef sunum dosyasını yazın.

Aşağıdaki örnekte, bir slaytı (kaynak sunumun sıfır indeksinde bulunan) master slaytı ile klonlayıp, bu master'ı kullanarak hedef sunumun sonuna ekledik.

```javascript
// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Slide'ın klonlanacağı hedef sunum için Presentation sınıfını örnekle
    var destPres = new aspose.slides.Presentation();
    try {
        // Kaynak sunumdaki slayt koleksiyonundan ISlide nesnesini ve
        // Master slaytı örnekle
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // İstenen master slaytı kaynak sunumdan
        // hedef sunumdaki master koleksiyonuna kopyala
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // İstenen master slaytı kaynak sunumdan
        // hedef sunumdaki master koleksiyonuna kopyala
        var iSlide = masters.addClone(SourceMaster);
        // İstenen master ile kaynak sunumdan istenen slaytı
        // hedef sunumdaki slayt koleksiyonunun sonuna kopyala
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // Hedef sunumu diske kaydet
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Belirtilen Bölümde Sona Klonla**
Bir slaytı klonlamak ve aynı sunum dosyasında farklı bir bölümde kullanmak istiyorsanız, [addClone] metodunu kullanın. Aspose.Slides for Node.js via Java, bir slaytı ilk bölüme klonlamayı ve ardından bu klonlanan slaytı aynı sunumun ikinci bölümüne eklemeyi mümkün kılar.

Aşağıdaki kod parçacığı, bir slaytı nasıl klonlayacağınızı ve klonlanan slaytı belirtilen bir bölüme nasıl ekleyeceğinizi gösterir.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Hedef sunumu diske kaydet
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **SSS**

**Sunum notları ve gözden geçiren yorumları klonlanır mı?**

Evet. Not sayfası ve yorumlar klona dahil edilir. İstemiyorsanız, eklemeden sonra [kaldırın](/slides/tr/nodejs-java/presentation-notes/).

**Grafikler ve veri kaynakları nasıl işlenir?**

Grafik nesnesi, biçimlendirmesi ve gömülü verileri kopyalanır. Grafik dış bir kaynağa (ör. OLE gömülü bir çalışma kitabı) bağlıysa, bu bağlantı bir [OLE nesnesi](/slides/tr/nodejs-java/manage-ole/) olarak korunur. Dosyalar arasında taşıdıktan sonra veri kullanılabilirliğini ve yenileme davranışını kontrol edin.

**Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?**

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve seçtiğiniz bir [bölüme](/slides/tr/nodejs-java/slide-section/) yerleştirebilirsiniz. Hedef bölüm yoksa, önce bölümü oluşturun ve ardından slaytı içine taşıyın.