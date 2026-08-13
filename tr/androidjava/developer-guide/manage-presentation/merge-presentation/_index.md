---
title: "Android'de Sunumları Verimli Bir Şekilde Birleştirme"
linktitle: "Sunumları Birleştir"
type: docs
weight: 40
url: /tr/androidjava/merge-presentation/
keywords:
- "PowerPoint birleştirme"
- "sunumları birleştir"
- "slaytları birleştir"
- "PPT birleştir"
- "PPTX birleştir"
- "ODP birleştir"
- "PowerPoint birleştir"
- "sunumları birleştir"
- "slaytları birleştir"
- "PPT birleştir"
- "PPTX birleştir"
- "ODP birleştir"
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarını sorunsuz bir şekilde birleştirerek iş akışınızı sadeleştirin."
---
## **Genel Bakış**

PowerPoint ve OpenDocument sunumlarını birleştirmek, rapor oluşturma, farklı kaynaklardan slayt derleme veya sunum iş akışlarını otomatikleştirme gibi durumlarda birçok Android uygulamasında yaygın bir görevdir. Aspose.Slides, Microsoft PowerPoint, LibreOffice veya OpenOffice kurmadan birden fazla PPT, PPTX veya ODP dosyasını tek bir sunumda birleştirmenizi sağlayan güçlü ve kullanımı kolay bir API sunar.

Bu rehberde, sadece birkaç satır kod kullanarak PowerPoint ve OpenDocument sunumlarını nasıl birleştireceğinizi öğreneceksiniz. Hazır örnekler sunacağız ve birleştirme işlemi sırasında slayt biçimlendirmesi, düzenleri ve diğer sunum öğelerinin nasıl korunacağını göstereceğiz.

İster kurumsal düzeyde bir uygulama ister basit bir otomasyon aracı geliştirin, Aspose.Slides sunumları hızlı, güvenilir ve ölçeklenebilir bir şekilde birleştirmenizi sağlar. Aspose.Slides, sunumları çeşitli şekillerde birleştirmenize olanak tanır. Sunumları tüm şekilleri, stilleri, metinleri, biçimlendirmeleri, yorumları, animasyonları ve daha fazlasıyla birlikte—kalite veya veri kaybı endişesi olmadan—birleştirebilirsiniz.

{{% alert color="info" %}}
Ayrıca bakınız: [Slaytları Kopyala](https://docs.aspose.com/slides/tr/androidjava/clone-slides/)
{{% /alert %}}

### **Ne Birleştirilebilir**

With Aspose.Slides, you can merge 

* tüm sunumları. Sunumlardan gelen tüm slaytlar tek bir sunumda toplanır
* belirli slaytları. Seçilen slaytlar tek bir sunumda toplanır
* aynı formatta (PPT'ten PPT'ye, PPTX'ten PPTX'e vb.) ve farklı formatlarda (PPT'ten PPTX'e, PPTX'ten ODP'ye vb.) sunumları birbirine.

### **Birleştirme Seçenekleri**

Çıktı sunumundaki her slaydın benzersiz bir stile sahip olup olmayacağını belirleyen seçenekler uygulayabilirsiniz

* çıktı sunumundaki her slayt benzersiz bir stil korur
* çıktı sunumundaki tüm slaytlar aynı spesifik stili kullanır.

Sunumları birleştirmek için Aspose.Slides, [AddClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yöntemlerini ([ISlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection) arabiriminden) sağlar. `AddClone` yöntemlerinin, sunum birleştirme süreci parametrelerini tanımlayan çeşitli uygulamaları vardır. Her Presentation nesnesinin bir [Slides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) koleksiyonu bulunur, böylece slaytları birleştirmek istediğiniz sunumdan bir `AddClone` yöntemi çağırabilirsiniz.

`AddClone` yöntemi, kaynak slaydın bir klonu olan bir `ISlide` nesnesi döndürür. Çıktı sunumundaki slaytlar, kaynak slaytlardan basit bir kopyadır. Bu nedenle, kaynak sunumların etkilenmesi konusunda endişelenmeden sonuç slaytlarda değişiklik yapabilirsiniz (örneğin stiller, biçimlendirme seçenekleri veya düzenler uygulamak).

## **Sunumları Birleştirme**

Aspose.Slides, slaytların düzenlerini ve stillerini (varsayılan parametreler) koruyarak slaytları birleştirmenizi sağlayan [**AddClone(ISlide)**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) yöntemini sunar.

Bu Java kodu, sunumları nasıl birleştireceğinizi gösterir:
```java
import com.aspose.slides.*;

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

## **Slayt Ana Şablonlu Sunumları Birleştirme**

Aspose.Slides, slayt ana şablonu sunum şablonunu uygulayarak slaytları birleştirmenizi sağlayan [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) yöntemini sunar. Bu sayede, gerekirse çıktı sunumundaki slaytların stilini değiştirebilirsiniz.

Bu Java kodu, açıklanan işlemi gösterir:
```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Slayt ana şablonu için slayt düzeni otomatik olarak belirlenir. Uygun bir düzen belirlenemediğinde, `AddClone` yönteminin `allowCloneMissingLayout` boolean parametresi true olarak ayarlanmışsa, kaynak slaydın düzeni kullanılır. Aksi takdirde, [PptxEditException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PptxEditException) istisnası fırlatılır.
{{% /alert %}}

Çıktı sunumundaki slaytların farklı bir slayt düzenine sahip olmasını istiyorsanız, birleştirirken [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) yöntemini kullanın.

## **Sunumlardan Belirli Slaytları Birleştirme**

Birden fazla sunumdan belirli slaytları birleştirmek, özelleştirilmiş slayt desteleri oluşturmak için yararlıdır. Android için Aspose.Slides, Java aracılığıyla yalnızca ihtiyacınız olan slaytları seçip içe aktarmanıza izin verir. API, orijinal slaytların biçimlendirmesini, düzenini ve tasarımını korur.

Aşağıdaki Java kodu yeni bir sunum oluşturur, iki başka sunumdan başlık slaytlarını ekler ve sonucu bir dosyaya kaydeder:
```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Slayt Düzeni ile Sunumları Birleştirme**

Bu Java kodu, slaytları birleştirirken tercih ettiğiniz slayt düzenini uygulayarak tek bir çıktı sunumu elde etmenizi gösterir:
```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **Farklı Slayt Boyutlu Sunumları Birleştirme**

{{% alert title="Note" color="warning" %}} 
Farklı slayt boyutlarına sahip sunumları birleştiremezsiniz. 
{{% /alert %}}

Farklı slayt boyutlarına sahip 2 sunumu birleştirmek için, sunumlardan birinin boyutunu diğerine eşit olacak şekilde yeniden boyutlandırmanız gerekir.

Bu örnek kod, açıklanan işlemi göstermektedir:
```java
import com.aspose.slides.*;

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

## **Slaytları Sunum Bölümüne Birleştirme**

Bu Java kodu, belirli bir slaytı bir sunum bölümüyle birleştirmenizi gösterir:
```java
import com.aspose.slides.*;

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

{{% alert title="Tip" color="info" %}}
Aspose, bir [ÜCRETSİZ Collage web uygulaması](https://products.aspose.app/slides/tr/collage) sunar. Bu çevrimiçi hizmeti kullanarak [JPG'den JPG'ye](https://products.aspose.app/slides/tr/collage/jpg) veya PNG'den PNG'ye görüntüleri birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir vb.
{{% /alert %}}

## **FAQ**

### Sunumları birleştirirken slayt sayısı üzerinde herhangi bir sınırlama var mı?
Katı bir sınırlama yoktur. Aspose.Slides büyük dosyaları işleyebilir, ancak performans dosyanın boyutu ve sistem kaynaklarına bağlıdır. Çok büyük sunumlar için 64‑bit bir JVM kullanmanız ve yeterli yığın belleği ayırmanız önerilir.

### Gömülü video veya ses içeren sunumları birleştirebilir miyim?
Evet, Aspose.Slides, slaytlara gömülmüş çoklu ortam içeriğini korur, ancak sonuç sunum önemli ölçüde daha büyük olabilir.

### Sunumları birleştirirken yazı tipleri korunacak mı?
Evet. Kaynak sunumlarda kullanılan yazı tipleri, sistemde yüklü oldukları veya [gömülü](/slides/tr/androidjava/embedded-font/) olduğu sürece çıktı dosyasında korunur.