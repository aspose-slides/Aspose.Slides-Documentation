---
title: "Java'da Sunum Slaytlarını Klonlayın"
linktitle: "Slaytları Klonla"
type: docs
weight: 35
url: /tr/java/clone-slides/
keywords:
- slayt klonlama
- slayt kopyalama
- slayt kaydetme
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint slaytlarını hızlıca çoğaltın. Açık kod örneklerimizle PPT oluşturmayı saniyeler içinde otomatikleştirin ve manuel işi ortadan kaldırın."
---
## **Giriş**

Klonlama, bir şeyin tam bir kopyasını veya replikasını oluşturma sürecidir. Aspose.Slides for Java, herhangi bir slaytı kopyalamanıza veya klonlamanıza ve ardından bu klonlanmış slaytı mevcut veya başka bir açık sunuma eklemenize olanak tanır. Slayt klonlama işlemi, geliştiricilerin orijinal slaytı değiştirmeden üzerinde değişiklik yapabileceği yeni bir slayt oluşturur. Slaytı klonlamanın birkaç olası yolu vardır:

- Sunum içinde sona klonla.
- Sunum içinde başka bir konuma klonla.
- Başka bir sunumun sonuna klonla.
- Başka bir sunumda başka bir konuma klonla.
- Master slaytıyla birlikte başka bir sunuma klonla.

Aspose.Slides for Java’da, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesi tarafından sunulan (bir [ISlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide) nesnesi koleksiyonu), yukarıdaki slayt klonlama türlerini gerçekleştirmek için [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ve [insertClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metodlarını sağlar.

## **Bir Sunumun Sonuna Slayt Klonlama**
Bir slaytı klonlamak ve ardından aynı sunum dosyasında mevcut slaytların sonuna eklemek istiyorsanız, aşağıdaki adımlara göre [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metodunu kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesi tarafından sunulan Slides koleksiyonuna başvurarak [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) sınıfını örnekleyin.
3. [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metodunu çağırın ve klonlanacak slaytı parametre olarak iletin.
4. Değiştirilen sunum dosyasını yazın.

Aşağıdaki örnekte, sunumun ilk konumundaki (sıfır indeksli) slaytı sunumun sonuna klonladık.

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonlayın
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Değiştirilen sunumu diske yazın
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Bir Sunumda Başka Bir Konuma Slayt Klonlama**
Bir slaytı klonlamak ve ardından aynı sunum dosyasında farklı bir konuma eklemek istiyorsanız, [insertClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metodunu kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesi tarafından sunulan **Slides** koleksiyonuna başvurarak sınıfı örnekleyin.
3. [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [insertClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metodunu çağırın ve klonlanacak slaytı yeni konum için indeksle birlikte parametre olarak iletin.
4. Değiştirilen sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun indeks 1 (konum 2) konumundaki slaytı indeks 2 (konum 3) konumuna klonladık.

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Sunumdaki slayt koleksiyonunu alın
    ISlideCollection slds = pres.getSlides();

    // İstenen slaytı aynı sunumdaki belirtilen indeks'e klonlayın
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Değiştirilen sunumu diske yazın
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Başka Bir Sunumun Sonuna Slayt Klonlama**
Bir slaytı bir sunumdan klonlayıp başka bir sunum dosyasının mevcut slaytlarının sonuna eklemeniz gerekiyorsa:

1. Kaynak slaytı içeren [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Hedef sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
3. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesi tarafından sunulan **Slides** koleksiyonuna başvurarak [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection) sınıfını örnekleyin.
4. [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metodunu çağırın ve kaynak sunumdan slaytı parametre olarak iletin.
5. Değiştirilen hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun ilk indeksindeki slaytı hedef sunumun sonuna klonladık.

```java
import com.aspose.slides.*;

// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Hedef PPTX (slaytın klonlanacağı yer) için Presentation sınıfını örnekleyin
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

## **Başka Bir Sunumda Belirli Bir Konuma Slayt Klonlama**
Bir slaytı bir sunumdan klonlayıp başka bir sunum dosyasında belirli bir konuma eklemeniz gerekiyorsa:

1. Kaynak sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Slaytı eklenecek hedef sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
3. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesi tarafından sunulan Slides koleksiyonuna başvurarak [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) sınıfını örnekleyin.
4. [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [insertClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-) metodunu çağırın ve kaynak sunumdaki slaytı istediğiniz konumla birlikte parametre olarak iletin.
5. Değiştirilen hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki slaytı hedef sunumun indeks 1 (konum 2) konumuna klonladık.

```java
import com.aspose.slides.*;

// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Hedef PPTX (slaytın klonlanacağı yer) için Presentation sınıfını örnekleyin
    Presentation destPres = new Presentation();
    try {
        // İstenen slaytı kaynak sunumdan hedef sunumdaki belirtilen indekse klonlayın
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Hedef sunumu diske yazın
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Master Slaytıyla Birlikte Slayt Klonlama ve Başka Bir Sunuma Aktarma**
Bir slaytı master slaytıyla birlikte bir sunumdan klonlayıp başka bir sunuma eklemeniz gerekiyorsa, önce istediğiniz master slaytı kaynak sunumdan hedef sunuma klonlamalısınız. Ardından bu master slaytı, master slaytıyla birlikte slaytı klonlamak için kullanmalısınız. [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-com.aspose.slides.IMasterSlide-boolean-) yöntemi, kaynak sunumdan değil, hedef sunumdan bir master slaytı bekler. Master slaytıyla birlikte slaytı klonlamak için aşağıdaki adımları izleyin:

1. Kaynak sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Hedef sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
3. Klonlanacak slaytı ve ona ait master slaytı alın.
4. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesi tarafından sunulan Masters koleksiyonuna başvurarak [IMasterSlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IMasterSlideCollection) sınıfını örnekleyin.
5. [IMasterSlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IMasterSlideCollection) nesnesi üzerinden [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metodunu çağırın ve kaynak PPTX’ten klonlanacak master slaytı parametre olarak iletin.
6. Hedef sunumun [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) nesnesi tarafından sunulan Slides koleksiyonuna referans vererek [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) sınıfını örnekleyin.
7. [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) nesnesi üzerinden [addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metodunu çağırın ve kaynak sunumdaki slaytı ve master slaytı parametre olarak iletin.
8. Değiştirilen hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki slaytı ve master slaytı, kaynak slayttan alınan master ile birlikte hedef sunumun sonuna klonladık.

```java
import com.aspose.slides.*;

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

        // Kaynak sunumdan istenen master slaytı hedef sunumdaki master koleksiyonuna klonlayın
        // Hedef sunum
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // Kaynak sunumdan istenen slaytı, istenen master ile birlikte hedef sunumdaki slayt koleksiyonunun sonuna klonlayın
        // Hedef sunumda
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // Hedef sunumu diske kaydedin
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Belirli Bir Bölümün Sonuna Slayt Klonlama**
Bir slaytı klonlayıp aynı sunum dosyasında farklı bir bölüme eklemek istiyorsanız, [**addClone**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) metodunu kullanın. Aspose.Slides for Java, bir slaytı ilk bölümden klonlayıp aynı sunumun ikinci bölümüne eklemenize olanak tanır.

Aşağıdaki kod parçası, bir slaytı klonlayıp belirtilen bölüme nasıl ekleyeceğinizi gösterir.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // Hedef sunumu diske kaydedin
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Slayt Boyutunun Eşleştiğinden Emin Olun**

Slaytları başka bir sunuma klonlarken, hedef sunumun slayt boyutunun kaynakla aynı olduğundan emin olun. Slayt boyutları farklı ise, Aspose.Slides klonlanmış şekilleri otomatik olarak yeniden ölçeklendirmez; özgün koordinat ve boyutları korunur ve içerik kaydırılmış ya da slayt sınırlarının dışına taşmış gibi görünebilir.

Master ve slaytı klonlamadan önce hedef sunumun slayt boyutunu kaynağa eşitleyebilirsiniz:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Bu adımı master ve slaytı klonlamadan önce uygulayın.

## **SSS**

**Konuşmacı notları ve gözden geçirme yorumları klonlanıyor mu?**

Evet. Not sayfası ve gözden geçirme yorumları klona dahil edilir. İstemiyorsanız, ekledikten sonra [kaldırın](/slides/tr/java/presentation-notes/).

**Grafikler ve veri kaynakları nasıl işleniyor?**

Grafik nesnesi, biçimlendirme ve yerleşik veri kopyalanır. Grafik harici bir kaynağa (ör. OLE gömülü çalışma kitabı) bağlanmışsa, bu bağlantı bir [OLE nesnesi](/slides/tr/java/manage-ole/) olarak korunur. Dosyalar arasında taşındıktan sonra veri kullanılabilirliğini ve yenileme davranışını kontrol edin.

**Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?**

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve seçtiğiniz bir [bölüm](/slides/tr/java/slide-section/) içine yerleştirebilirsiniz. Hedef bölüm yoksa, önce oluşturup ardından slaytı ona taşıyın.