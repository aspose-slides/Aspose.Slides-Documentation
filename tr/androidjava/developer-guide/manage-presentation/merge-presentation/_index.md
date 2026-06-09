---
title: Android'de Sunumları Verimli Bir Şekilde Birleştir
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/androidjava/merge-presentation/
keywords:
- PowerPoint birleştir
- sunumları birleştir
- slaytları birleştir
- PPT birleştir
- PPTX birleştir
- ODP birleştir
- PowerPoint birleştir
- sunumları birleştir
- slaytları birleştir
- PPT birleştir
- PPTX birleştir
- ODP birleştir
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarını zahmetsizce birleştirerek iş akışınızı sadeleştirin."
---
## **Genel Bakış**

PowerPoint ve OpenDocument sunumlarını birleştirmek, özellikle raporlar oluştururken, farklı kaynaklardan slaytları derlerken veya sunum iş akışlarını otomatikleştirirken birçok Android uygulamasında yaygın bir görevdir. Aspose.Slides, Microsoft PowerPoint, LibreOffice veya OpenOffice kurmadan birden çok PPT, PPTX veya ODP dosyasını tek bir sunumda birleştirmenizi sağlayan güçlü ve kullanımı kolay bir API sunar.

Bu kılavuzda, sadece birkaç satır kodla PowerPoint ve OpenDocument sunumlarını nasıl birleştireceğinizi öğreneceksiniz. Kullanıma hazır örnekler sunacağız ve birleştirme işlemi sırasında slayt biçimlendirmesi, düzenleri ve diğer sunum öğelerinin nasıl korunacağını göstereceğiz.

İster kurumsal düzeyde bir uygulama ister basit bir otomasyon aracı geliştiriyor olun, Aspose.Slides sunumları hızlı, güvenilir ve ölçeklenebilir bir şekilde birleştirmenizi sağlar. Aspose.Slides, sunumları farklı şekillerde birleştirmenize olanak tanır. Tüm şekiller, stiller, metin, biçimlendirme, yorumlar, animasyonlar ve daha fazlası—kalite veya veri kaybı endişesi olmadan—birleştirilebilir.

{{% alert color="primary" %}}
Ayrıca bakınız: [Slide Kopyalama](https://docs.aspose.com/slides/tr/androidjava/clone-slides/)
{{% /alert %}}

### **Ne Birleştirilebilir**

Aspose.Slides ile şunları birleştirebilirsiniz

* tüm sunumları. Sunumlardaki tüm slaytlar tek bir sunumda bir araya gelir
* belirli slaytları. Seçilen slaytlar tek bir sunumda bir araya gelir
* aynı formatta (PPT'den PPT'ye, PPTX'ten PPTX'e vb.) ve farklı formatlarda (PPT'den PPTX'e, PPTX'ten ODP'ye vb.) birbiriyle uyumlu şekilde.

### **Birleştirme Seçenekleri**

Aşağıdaki seçenekleri uygulayarak belirleyebilirsiniz

* çıktı sunumundaki her slaydın benzersiz bir stil koruması
* çıktı sunumundaki tüm slaytların ortak bir stil kullanması.

Sunumları birleştirmek için Aspose.Slides, [AddClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yöntemlerini ([ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection) arayüzünden) sunar. `AddClone` yöntemlerinin çeşitli uygulamaları, sunum birleştirme sürecinin parametrelerini tanımlar. Her Presentation nesnesinin bir [Slides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) koleksiyonu vardır; böylece slaytları birleştirmek istediğiniz sunum üzerinden bir `AddClone` yöntemi çağırabilirsiniz.

`AddClone` yöntemi, kaynak slaydın bir klonu olan bir `ISlide` nesnesi döndürür. Çıktı sunumundaki slaytlar, kaynak slaytlardan basitçe kopyalanır. Bu nedenle, oluşturulan slaytlarda (örneğin stiller uygulama, biçimlendirme seçenekleri veya düzenler değiştirme) kaynak sunumların etkilenmesi konusunda endişe duymadan değişiklik yapabilirsiniz.

## **Sunumları Birleştirme**

Aspose.Slides, slaytların düzenlerini ve stillerini koruyarak (varsayılan parametreler) slaytları birleştirmenizi sağlayan [**AddClone(ISlide)**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yöntemini sunar.

Bu Java kodu sunumları nasıl birleştireceğinizi gösterir:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Sunumları Slayt Ana Şablonu ile Birleştirme**

Aspose.Slides, slaytları birleştirirken bir slayt ana şablonu sunum şablonu uygulamanızı sağlayan [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) yöntemini sunar. Bu şekilde, gerektiğinde çıktı sunumundaki slaytların stilini değiştirme imkanı elde edersiniz.

Bu Java kodu açıklanan işlemi gösterir:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Not" color="warning" %}} 
Slayt ana şablonu için düzen otomatik olarak belirlenir. Uygun bir düzen belirlenemediğinde, `AddClone` yönteminin `allowCloneMissingLayout` boolean parametresi **true** olarak ayarlanmışsa kaynak slaydın düzeni kullanılır. Aksi takdirde [PptxEditException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PptxEditException) istisnası fırlatılacaktır.
{{% /alert %}}

Çıktı sunumundaki slaytların farklı bir slayt düzenine sahip olmasını istiyorsanız, birleştirirken [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) yöntemini kullanın.

## **Sunumlardan Belirli Slaytları Birleştirme**

Birden çok sunumdan belirli slaytları birleştirmek, özel slayt desteleri oluşturmak için yararlıdır. Aspose.Slides for Android via Java, yalnızca ihtiyacınız olan slaytları seçip içe aktarmanıza olanak tanır. API, orijinal slaytların biçimlendirmesini, düzenini ve tasarımını korur.

Aşağıdaki Java kodu yeni bir sunum oluşturur, iki başka sunumdan başlık slaytlarını ekler ve sonucu bir dosyaya kaydeder:

```java
Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```
```java
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Sunumları Slayt Düzeni ile Birleştirme**

Bu Java kodu, slaytları birleştirirken tercih ettiğiniz slayt düzenini uygulayarak tek bir çıktı sunumu elde etmenizi gösterir:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştirme**

{{% alert title="Not" color="warning" %}} 
Farklı slayt boyutlarına sahip sunumları birleştiremezsiniz. 
{{% /alert %}}

2 farklı slayt boyutuna sahip sunumu birleştirmek için, boyutları eşitlemek amacıyla sunumlardan birinin boyutunu diğerine uyacak şekilde yeniden boyutlandırmanız gerekir.

Bu örnek kod açıklanan işlemi gösterir:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Sunum Bölümüne Slaytları Birleştirme**

Bu Java kodu, belirli bir slaytı bir sunum bölümüne nasıl birleştireceğinizi gösterir:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

Slayt, bölümün sonuna eklenir. 

{{% alert title="İpucu" color="primary" %}}
Aspose, bir [ÜCRETSİZ Collage web uygulaması](https://products.aspose.app/slides/tr/collage) sunar. Bu çevrimiçi hizmeti kullanarak [JPG'den JPG'ye](https://products.aspose.app/slides/tr/collage/jpg) veya PNG'den PNG'ye resimleri birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir ve benzeri işlemler yapabilirsiniz. 
{{% /alert %}}

## **SSS**

**Sunumları birleştirirken slayt sayısı konusunda herhangi bir sınırlama var mı?**

Katı bir sınırlama yoktur. Aspose.Slides büyük dosyaları işleyebilir, ancak performans dosya boyutuna ve sistem kaynaklarına bağlıdır. Çok büyük sunumlar için 64‑bit bir JVM kullanmanız ve yeterli yığın belleği ayırmanız önerilir.

**Gömülü video veya ses içeren sunumları birleştirebilir miyim?**

Evet, Aspose.Slides slaytlara gömülü multimedya içeriğini korur, ancak son sunum önemli ölçüde daha büyük olabilir.

**Sunumları birleştirirken yazı tipleri korunur mu?**

Evet. Kaynak sunumlarda kullanılan yazı tipleri, sistemde yüklü olduğunda veya [gömülü](/slides/tr/androidjava/embedded-font/) olduğunda çıktı dosyasında korunur.