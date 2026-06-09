---
title: Java'da Sunumları Etkili Bir Şekilde Birleştirin
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/java/merge-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarını sorunsuz bir şekilde birleştirerek iş akışınızı hızlandırın."
---
## **Genel Bakış**

PowerPoint ve OpenDocument sunumlarını birleştirmek, özellikle rapor oluşturma, farklı kaynaklardan slayt derleme veya sunum iş akışlarını otomatikleştirme gibi durumlarda birçok Java uygulamasında yaygın bir görevdir. Aspose.Slides for Java, Microsoft PowerPoint, LibreOffice veya OpenOffice kurmadan birden fazla PPT, PPTX veya ODP dosyasını tek bir sunumda birleştirmek için güçlü ve kullanımı kolay bir API sağlar.

Bu rehberde, sadece birkaç satır Java kodu kullanarak PowerPoint ve OpenDocument sunumlarını nasıl birleştireceğinizi öğreneceksiniz. Hazır örnekler sunacağız ve birleştirme işlemi sırasında slayt biçimlendirmesini, düzenleri ve diğer sunum öğelerini nasıl koruyacağınızı göstereceğiz.

İster kurumsal düzeyde bir uygulama ister basit bir otomasyon aracı geliştiriyor olun, Aspose.Slides Java'da sunumları birleştirmeyi hızlı, güvenilir ve ölçeklenebilir kılar. Aspose.Slides for Java, sunumları farklı şekillerde birleştirmenize olanak tanır. Tüm şekiller, stiller, metin, biçimlendirme, yorumlar, animasyonlar ve daha fazlası ile birlikte sunumları birleştirebilir—kalite veya veri kaybı konusunda endişe etmeden.
{{% alert color="primary" %}}
Ayrıca bakınız: [Clone Slides](https://docs.aspose.com/slides/tr/java/clone-slides/)
{{% /alert %}}
### **Ne Birleştirilebilir?**

Aspose.Slides ile aşağıdakileri birleştirebilirsiniz:

**Tüm sunumlar** – birden fazla sunumdaki tüm slaytlar tek bir sunumda birleştirilir.

**Belirli slaytlar** – yalnızca seçilen slaytlar tek bir sunumda birleştirilir.

**Aynı formatta sunumlar** (örn. PPT'den PPT'ye, PPTX'ten PPTX'e) ve **farklı formatlarda sunumlar** (örn. PPT'den PPTX'e, PPTX'ten ODP'ye).

### **Birleştirme Seçenekleri**

Şu belirleyen seçenekleri uygulayabilirsiniz:
- Çıktı sunumundaki her slayt özgün stilini korur
- Çıktı sunumundaki tüm slaytlara belirli bir stil uygulanır

Sunumları birleştirmek için, Aspose.Slides, [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/) arayüzündeki `AddClone` yöntemlerini sağlar. Birleştirme işleminin nasıl davranacağını belirleyen çeşitli `AddClone` yöntem aşırı yüklemeleri vardır. Her [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) nesnesinin bir Slides koleksiyonu vardır. Bu nedenle, slaytları birleştirmek istediğiniz hedef sunumda bir `AddClone` yöntemi çağırabilirsiniz.

`AddClone` yöntemi, kaynak slaydın bir klonu olan bir [ISlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/) nesnesi döndürür. Çıktı sunumundaki oluşan slaytlar, orijinal slaytların basit kopyalarıdır. Bu, klonlanmış slaytları güvenle değiştirmenizi sağlar—örneğin stiller, biçimlendirme seçenekleri veya düzenler uygulamak—kaynak sunumu etkilemeden.
## **Sunumları Birleştir**

Aspose.Slides, slaytları orijinal düzenlerini ve stillerini koruyarak birleştirmenizi sağlayan [AddClone(ISlide)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) yöntemini sunar (varsayılan davranış).  
Aşağıdaki Java kodu, sunumların nasıl birleştirileceğini gösterir:
```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```
## **Sunumları Bir Slayt Ana Şablonu ile Birleştir**

Aspose.Slides, bir sunum şablonundan slayt ana şablonu uygulayarak slaytları birleştirmenizi sağlayan [AddClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.IMasterSlide-boolean-) yöntemini sunar. Bu sayede, gerekirse, çıktı sunumdaki slaytların stilini değiştirebilirsiniz.  
Aşağıdaki Java kodu bu işlemi gösterir:
```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        IMasterSlide masterSlide = presentation2.getMasters().get_Item(0);
        presentation1.getSlides().addClone(slide, masterSlide, true);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```
{{% alert title="Note" color="warning" %}}
Slaytın düzeni otomatik olarak belirlenir. Uygun bir düzen bulunamadığında ve `AddClone` yönteminin `allowCloneMissingLayout` boolean parametresi `true` olarak ayarlandığında, kaynak slayttan düzen kullanılır. Aksi takdirde bir [PptxEditException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxeditexception/) istisnası fırlatılır.
{{% /alert %}}
## **Sunumlardan Belirli Slaytları Birleştir**

Birden fazla sunumdan belirli slaytları birleştirmek, özelleştirilmiş slayt desteleri oluşturmak için faydalıdır. Aspose.Slides for Java, yalnızca ihtiyacınız olan slaytları seçip içe aktarmanıza olanak tanır. API, orijinal slaytların biçimlendirmesini, düzenini ve tasarımını korur.  
Aşağıdaki Java kodu yeni bir sunum oluşturur, iki diğer sunumdan başlık slaytları ekler ve sonucu bir dosyaya kaydeder:
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
## **Sunumları Bir Slayt Düzeni ile Birleştir**

Birleştirme sırasında çıktı slaytlarına farklı bir slayt düzeni uygulamak için, bunun yerine [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ILayoutSlide-) yöntemini kullanın.  
Aşağıdaki Java kodu, tercih ettiğiniz slayt düzenini uygulayarak birden fazla sunumdan slaytları nasıl birleştireceğinizi ve tek bir çıktı sunumu elde edeceğinizi gösterir:
```java
int layoutIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ILayoutSlide layoutSlide = presentation2.getLayoutSlides().get_Item(layoutIndex);
        presentation1.getSlides().addClone(slide, layoutSlide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```
## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

Farklı slayt boyutlarına sahip iki sunumu birleştirmek için, birini diğer sunumun slayt boyutuna göre yeniden boyutlandırmalısınız.  
Aşağıdaki Java kodu bu işlemi gösterir:
```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    Dimension2D slideSize = presentation1.getSlideSize().getSize();
    float slideWidth = (float) slideSize.getWidth();
    float slideHeight = (float) slideSize.getHeight();
    
    presentation2.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```
## **Slaytları Bir Sunum Bölümüne Birleştir**

Slaytları belirli bir sunum bölümüne birleştirmek, içeriği düzenlemeye ve slayt gezinimini iyileştirmeye yardımcı olur. Aspose.Slides, slaytları mevcut bölümlere birleştirmenizi sağlar. Bu, her slaydın özgün biçimlendirmesini korurken net bir yapı oluşturur.  
Aşağıdaki Java kodu, belirli bir slaytı bir sunum bölümüne nasıl birleştirileceğini gösterir:
```java
int sectionIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ISection section = presentation1.getSections().get_Item(sectionIndex);
        presentation1.getSlides().addClone(slide, section);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```
Slayt, bölümün sonuna eklenir.
## **İlgili Bağlantılar**

Aspose, bir [ÜCRETSİZ Çevrimiçi Kolaj Oluşturucu](https://products.aspose.app/slides/tr/collage) sağlar. Bu çevrimiçi hizmeti kullanarak, [JPG'den JPG'ye](https://products.aspose.app/slides/tr/collage/jpg) veya PNG'den PNG'ye resimleri birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir ve daha fazlasını yapabilirsiniz.

[Aspose ÜCRETSİZ Çevrimiçi Birleştirici](https://products.aspose.app/slides/tr/merger)'yi inceleyin. Aynı formatta (örn. PPT'den PPT'ye, PPTX'ten PPTX'e) veya farklı formatlarda (örn. PPT'den PPTX'e, PPTX'ten ODP'ye) PowerPoint sunumlarını birleştirmenizi sağlar.

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/tr/merger)

Sunumların yanı sıra, Aspose.Slides diğer dosyaları da birleştirmenize olanak tanır:
- [**Görseller**](https://products.aspose.com/slides/tr/java/merger/image-to-image/), örneğin [JPG'den JPG'ye](https://products.aspose.com/slides/tr/java/merger/jpg-to-jpg/) veya [PNG'den PNG'ye](https://products.aspose.com/slides/tr/java/merger/png-to-png/)
- **Belgeler**, örneğin [PDF'den PDF'ye](https://products.aspose.com/slides/tr/java/merger/pdf-to-pdf/) veya [HTML'den HTML'ye](https://products.aspose.com/slides/tr/java/merger/html-to-html/)
- **Karışık dosya türleri**, örneğin [görselden PDF'e](https://products.aspose.com/slides/tr/java/merger/image-to-pdf/), [JPG'den PDF'e](https://products.aspose.com/slides/tr/java/merger/jpg-to-pdf/) veya [TIFF'ten PDF'e](https://products.aspose.com/slides/tr/java/merger/tiff-to-pdf/) 
## **SSS**

**Sunumları birleştirirken slayt sayısı konusunda herhangi bir sınırlama var mı?**  
Sınırlı bir sınırlama yoktur. Aspose.Slides büyük dosyaları işleyebilir, ancak performans dosyanın boyutu ve sistem kaynaklarına bağlıdır. Çok büyük sunumlar için 64‑bit bir JVM kullanmanız ve yeterli yığın belleği ayırmanız önerilir.

**Gömülü video veya ses içeren sunumları birleştirebilir miyim?**  
Evet, Aspose.Slides slaytlara gömülü çoklu ortam içeriğini korur, ancak son sunum önemli ölçüde daha büyük olabilir.

**Sunumları birleştirirken yazı tipleri korunacak mı?**  
Evet. Kaynak sunumlarda kullanılan yazı tipleri, sistemde yüklü oldukları veya [gömülü](/slides/tr/java/embedded-font/) varsayımıyla çıktı dosyasında korunur.