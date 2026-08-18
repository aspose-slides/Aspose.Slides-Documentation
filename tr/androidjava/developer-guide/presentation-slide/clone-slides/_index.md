---
title: Android'de Sunum Slaytlarını Klonla
linktitle: Slaytları Klonla
type: docs
weight: 35
url: /tr/androidjava/clone-slides/
keywords:
- slaytı klonla
- slaytı kopyala
- slaytı kaydet
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile PowerPoint slaytlarını çoğaltın. Saniyeler içinde PPT oluşturmayı otomatikleştirmek ve manuel işi ortadan kaldırmak için net Java kod örneklerimizi izleyin."
---
## **Giriş**

Klonlama, bir şeyin tam bir kopyasını veya replikasını oluşturma sürecidir. Aspose.Slides for Android via Java ayrıca herhangi bir slaytın bir kopyasını veya klonunu oluşturmayı ve ardından bu klonlanmış slaytı mevcut ya da başka bir açık sunuma eklemeyi mümkün kılar. Slayt klonlama süreci, geliştiricilerin orijinal slaytı değiştirmeden yeni bir slaytı değiştirmesine izin verir. Bir slaytı klonlamanın çeşitli olası yolları vardır:

- Sunum içinde sona klonla.
- Sunum içinde başka bir konuma klonla.
- Başka bir sunumda sona klonla.
- Başka bir sunumda başka bir konuma klonla.
- Başka bir sunumda belirli bir konuma klonla.

Aspose.Slides for Android via Java'da, (bir [ISlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlide) nesnesi koleksiyonu) [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) nesnesi tarafından ortaya çıkarılır ve yukarıdaki slayt klonlama türlerini gerçekleştirmek için [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) ve [insertClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metodlarını sağlar.

## **Sunumun Sonuna Slayt Klonlama**
Mevcut slaytların sonuna aynı sunum dosyasında bir slaytı klonlamak ve ardından kullanmak istiyorsanız, aşağıdaki adımlara göre [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metodunu kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) nesnesi tarafından ortaya çıkarılan Slides koleksiyonuna referans vererek [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) sınıfının bir örneğini oluşturun.
1. [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sağlanan [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metodunu çağırın ve klonlanacak slaytı [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metoduna parametre olarak geçirin.
1. Değiştirilmiş sunum dosyasını kaydedin.

Aşağıda verilen örnekte, sunumun ilk konumunda (sıfır indeks) bulunan bir slaytı sunumun sonuna klonladık.

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonla
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Değiştirilmiş sunumu diske kaydet
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Sunum içinde başka bir konuma Slayt Klonlama**
Eğer bir slaytı klonlamak ve aynı sunum dosyasında farklı bir konuma yerleştirmek istiyorsanız, [insertClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metodunu kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) nesnesi tarafından ortaya çıkarılan **Slides** koleksiyonuna referans vererek sınıfı örnekleyin.
1. [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sağlanan [insertClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metodunu çağırın ve klonlanacak slaytı yeni konumun indeksiyle birlikte [insertClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metoduna parametre olarak geçirin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnekte, sunumda indeks 1 (konum 2) bulunan bir slaytı indeks 2 (konum 3) konumuna klonladık.

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Aynı sunumdaki slayt koleksiyonunu al
    ISlideCollection slds = pres.getSlides();

    // İstenen slaytı aynı sunumda belirtilen indekse klonla
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Değiştirilmiş sunumu diske kaydet
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Başka bir Sunumun Sonuna Slayt Klonlama**
Eğer bir sunumdan slayt klonlayıp başka bir sunum dosyasında mevcut slaytların sonuna eklemeniz gerekiyorsa:

1. Slaytın klonlanacağı kaynağı içeren [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Slaytın ekleneceği hedef sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Hedef sunumun Presentation nesnesi tarafından ortaya çıkarılan **Slides** koleksiyonuna referans vererek [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection) sınıfının bir örneğini oluşturun.
1. [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sağlanan [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metodunu çağırın ve kaynak sunumdan slaytı parametre olarak geçirin.
1. Değiştirilmiş hedef sunum dosyasını kaydedin.

Aşağıdaki örnekte, kaynak sunumun ilk indeksindeki bir slaytı hedef sunumun sonuna klonladık.

```java
import com.aspose.slides.*;

// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Hedef PPTX (slaytın klonlanacağı yer) için Presentation sınıfını örnekle
    Presentation destPres = new Presentation();
    try {
        // Kaynak sunumdan istenen slaytı hedef sunumdaki slayt koleksiyonunun sonuna klonla
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Hedef sunumu diske kaydet
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Başka bir Sunumda başka bir konuma slayt klonlama**
Eğer bir sunumdan slayt klonlayıp onu başka bir sunum dosyasında belirli bir konuma eklemeniz gerekiyorsa:

1. Slaytı klonlayacağınız kaynak sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Slaytı ekleyeceğiniz hedef sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Hedef sunumun Presentation nesnesi tarafından ortaya çıkarılan Slides koleksiyonuna referans vererek [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) sınıfının bir örneğini oluşturun.
1. [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sağlanan [insertClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metodunu çağırın ve kaynak sunumdan slaytı istenen konumla birlikte [insertClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metoduna parametre olarak geçirin.
1. Değiştirilmiş hedef sunum dosyasını kaydedin.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki bir slaytı hedef sunumun indeks 1 (konum 2) konumuna klonladık.

```java
import com.aspose.slides.*;

// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Hedef PPTX (slaytın klonlanacağı yer) için Presentation sınıfını örnekle
    Presentation destPres = new Presentation();
    try {
        // Kaynak sunumdan istenen slaytı hedef sunumda belirtilen indekse klonla
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Hedef sunumu diske kaydet
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Başka bir Sunumda belirli bir konuma slaytı klonlama**
Eğer bir sunumdan ana slaytı (master slide) olan bir slaytı klonlayıp başka bir sunumda kullanmanız gerekiyorsa, önce istediğiniz ana slaytı kaynak sunumdan hedef sunuma klonlamanız gerekir. Ardından bu ana slaytı, ana slaytı olan slaytı klonlamak için kullanmalısınız. [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) metodu, kaynak sunumdan değil, hedef sunumdan bir ana slayt bekler. Ana slaytı olan slaytı klonlamak için lütfen aşağıdaki adımları izleyin:

1. Kaynak sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Hedef sunumu içeren [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Klonlanacak slayta ve onun ana slaytına erişin.
1. Hedef sunumun Presentation nesnesi tarafından ortaya çıkarılan Masters koleksiyonuna referans vererek [IMasterSlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IMasterSlideCollection) sınıfının bir örneğini oluşturun.
1. [IMasterSlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IMasterSlideCollection) nesnesi tarafından sağlanan [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metodunu çağırın ve kaynak PPTX'den klonlanacak ana slaytı parametre olarak geçirin.
1. Hedef sunumun Presentation nesnesi tarafından ortaya çıkarılan Slides koleksiyonuna referans ayarlayarak [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) sınıfının bir örneğini oluşturun.
1. [ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) nesnesi tarafından sağlanan [addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metodunu çağırın ve kaynak sunumdan klonlanacak slaytı ve ana slaytı parametre olarak geçirin.
1. Değiştirilmiş hedef sunum dosyasını kaydedin.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki bir ana slaytı olan slaytı, kaynak slayttan alınan bir ana slaytı kullanarak hedef sunumun sonuna klonladık.

```java
import com.aspose.slides.*;

// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekle
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Hedef sunum (slaytın klonlanacağı yer) için Presentation sınıfını örnekle
    Presentation destPres = new Presentation();
    try {
        // Kaynak sunumdaki slayt koleksiyonundan ISlide'ı ve
        // Ana slaytı oluştur
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // İstenen ana slaytı kaynak sunumdan hedef sunumun ana slayt koleksiyonuna klonla
        // Hedef sunuma
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // İstenen slaytı kaynak sunumdan istenen ana slayt ile birlikte hedef sunumdaki slayt koleksiyonunun sonuna klonla
        // Hedef sunumdaki slayt koleksiyonuna
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Hedef sunumu diske kaydet
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Belirtilen Bölümün Sonuna Slayt Klonlama**
Eğer bir slaytı klonlayıp aynı sunum dosyasında farklı bir bölüme eklemek istiyorsanız, [**ISlideCollection**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection) arayüzü tarafından sağlanan [**addClone**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) metodunu kullanın. Aspose.Slides for Android via Java, bir slaytı ilk bölümden klonlayıp aynı sunumun ikinci bölümüne eklemeyi mümkün kılar.

Aşağıdaki kod parçacığı, bir slaytı nasıl klonlayıp belirli bir bölüme ekleyeceğinizi gösterir.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
    // Hedef sunumu diske kaydet
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Slayt Boyutunun Uyumlu Olduğundan Emin Olun**

Başka bir sunuma slayt klonlarken, hedef sunumun kaynakla aynı slayt boyutuna sahip olduğundan emin olun. Slayt boyutları farklıysa, Aspose.Slides klonlanan şekilleri otomatik olarak yeniden ölçeklendirmez; orijinal koordinat ve boyutları korunur, bu da içeriğin kayması veya slayt sınırlarını aşmasıyla sonuçlanabilir.

Master ve slaytı klonlamadan önce, hedef sunumun slayt boyutunu kaynağa eşit olacak şekilde ayarlayabilirsiniz:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Bunu, master ve slaytı klonlamadan önce yapın.

## **FAQ**

**Konuşmacı notları ve gözden geçiren yorumları klonlanır mı?**

Evet. Not sayfası ve gözden geçirme yorumları klona dahil edilir. İstemiyorsanız, eklemeden sonra [kaldırın](/slides/tr/androidjava/presentation-notes/).

**Grafikler ve veri kaynakları nasıl ele alınır?**

Grafik nesnesi, biçimlendirmesi ve gömülü verileri kopyalanır. Grafik dış bir kaynağa (ör. OLE gömülü bir çalışma kitabı) bağlıysa, bu bağlantı bir [OLE nesnesi](/slides/tr/androidjava/manage-ole/) olarak korunur. Dosyalar arasında taşındıktan sonra veri erişilebilirliğini ve yenileme davranışını kontrol edin.

**Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?**

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve seçtiğiniz bir [bölüm](/slides/tr/androidjava/slide-section/) içine yerleştirebilirsiniz. Hedef bölüm mevcut değilse, önce oluşturun ve ardından slaytı ona taşıyın.