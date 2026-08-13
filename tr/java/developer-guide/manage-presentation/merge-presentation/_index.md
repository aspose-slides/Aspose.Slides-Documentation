---
title: Java’da Sunumları Verimli Bir Şekilde Birleştirin
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
description: "Aspose.Slides for Java ile PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarını zahmetsizce birleştirerek iş akışınızı hızlandırın."
---
## **Genel Bakış**

PowerPoint ve OpenDocument sunumlarını birleştirmek, özellikle rapor oluşturma, farklı kaynaklardan slaytları derleme veya sunum iş akışlarını otomatikleştirme gibi birçok Java uygulamasında yaygın bir görevdir. Aspose.Slides for Java, Microsoft PowerPoint, LibreOffice veya OpenOffice kurmadan birden fazla PPT, PPTX veya ODP dosyasını tek bir sunumda birleştirmenizi sağlayan güçlü ve kullanımı kolay bir API sunar.

Bu rehberde, sadece birkaç satır Java kodu kullanarak PowerPoint ve OpenDocument sunumlarını nasıl birleştireceğinizi öğreneceksiniz. Hazır örnekler sunacağız ve birleştirme sürecinde slayt biçimlendirmesini, düzenlerini ve diğer sunum öğelerini nasıl koruyacağınızı göstereceğiz.

İster kurumsal düzeyde bir uygulama ister basit bir otomasyon aracı geliştirin, Aspose.Slides Java’da sunumları hızlı, güvenilir ve ölçeklenebilir bir şekilde birleştirmenizi sağlar. Aspose.Slides for Java, sunumları farklı şekillerde birleştirmenize olanak tanır. Tüm şekiller, stiller, metin, biçimlendirme, yorumlar, animasyonlar ve daha fazlası – kalite veya veri kaybı endişesi olmadan – birleştirilebilir.

{{% alert color="info" %}}
Ayrıca bakınız: [Slaytları Kopyala](https://docs.aspose.com/slides/tr/java/clone-slides/)
{{% /alert %}}

### **Ne Birleştirilebilir?**

Aspose.Slides ile şunları birleştirebilirsiniz:

**Tam sunumlar** – birden fazla sunumdaki tüm slaytlar tek bir sunumda birleştirilir.

**Belirli slaytlar** – yalnızca seçilen slaytlar tek bir sunumda birleştirilir.

**Aynı formatta sunumlar** (ör. PPT‑den PPT‑ye, PPTX‑ten PPTX‑e) ve **farklı formatlarda** (ör. PPT‑den PPTX‑e, PPTX‑ten ODP‑ye).

### **Birleştirme Seçenekleri**

Aşağıdaki seçenekleri uygulayarak şunların belirlenmesini sağlayabilirsiniz:

- Çıktı sunumundaki her slayt özgün stilini korur
- Çıktı sunumundaki tüm slaytlara belirli bir stil uygulanır

Sunumları birleştirmek için Aspose.Slides, [ISlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/) arayüzündeki `AddClone` metodlarını sunar. Birleştirme sürecinin davranışını tanımlayan çeşitli `AddClone` metod aşırı yüklemeleri vardır. Her [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) nesnesinin bir Slides koleksiyonu vardır. Bu nedenle, slaytları birleştirmek istediğiniz hedef sunumda bir `AddClone` metodunu çağırabilirsiniz.

`AddClone` metodu, kaynak slaytın bir klonu olan bir [ISlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/) nesnesi döndürür. Çıktı sunumundaki slaytlar, orijinal slaytların basit kopyalarıdır. Bu, klonlanan slaytları güvenle değiştirmenize — stil, biçimlendirme seçenekleri veya düzen uygulama gibi — kaynak sunumu etkilemeden olanak tanır.

## **Sunumları Birleştir** 

Aspose.Slides, orijinal düzen ve stillerini koruyarak slaytları birleştirmenizi sağlayan [AddClone(ISlide)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) metodunu sunar (varsayılan davranış).

Aşağıdaki Java kodu, sunumların nasıl birleştirileceğini gösterir:

```java
import com.aspose.slides.*;

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

## **Sunumları Slayt Şablonu ile Birleştir** 

Aspose.Slides, bir sunum şablonundan slayt şablonu uygulayarak slaytları birleştirmenizi sağlayan [AddClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) metodunu sunar. Böylece, gerekirse çıktı sunumundaki slaytların stilini değiştirebilirsiniz.

Aşağıdaki Java kodu bu işlemi gösterir:

```java
import com.aspose.slides.*;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        IMasterSlide masterSlide = presentation1.getMasters().get_Item(0);
        presentation1.getSlides().addClone(slide, masterSlide, true);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

{{% alert title="Not" color="warning" %}}
Slaytın slayt düzeni otomatik olarak belirlenir. Uygun bir düzen bulunamazsa ve `AddClone` metodunun `allowCloneMissingLayout` boolean parametresi `true` olarak ayarlanmışsa, kaynak slayttan düzen kullanılır. Aksi takdirde bir [PptxEditException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pptxeditexception/) fırlatılır.
{{% /alert %}}

## **Sunumlardan Belirli Slaytları Birleştir** 

Birden fazla sunumdan belirli slaytları birleştirmek, özel slayt desteleri oluşturmak için kullanışlıdır. Aspose.Slides for Java, yalnızca ihtiyacınız olan slaytları seçip içe aktarmanıza olanak tanır. API, orijinal slaytların biçimlendirmesini, düzenini ve tasarımını korur.

Aşağıdaki Java kodu, yeni bir sunum oluşturur, iki diğer sunumdan başlık slaytlarını ekler ve sonucu bir dosyaya kaydeder:

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

## **Sunumları Slayt Düzeni ile Birleştir** 

Birleştirme sırasında çıktı slaytlarına farklı bir slayt düzeni uygulamak için [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) metodunu kullanın.

Aşağıdaki Java kodu, tercih ettiğiniz slayt düzenini uygulayarak birden fazla sunumdan slaytları birleştirir ve tek bir çıktı sunumu oluşturur:

```java
import com.aspose.slides.*;

int layoutIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ILayoutSlide layoutSlide = presentation1.getLayoutSlides().get_Item(layoutIndex);
        presentation1.getSlides().addClone(slide, layoutSlide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir** 

Farklı slayt boyutlarına sahip iki sunumu birleştirmek için, birinin slayt boyutunu diğerinin boyutuna eşit olacak şekilde yeniden boyutlandırmalısınız.

Aşağıdaki Java kodu bu işlemi gösterir:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

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

## **Slaytları Sunum Bölümüne Birleştir** 

Slaytları belirli bir sunum bölümüne birleştirmek, içeriği düzenlemenize ve slayt gezintisini iyileştirmenize yardımcı olur. Aspose.Slides, slaytları mevcut bölümlere birleştirmenizi sağlar. Bu, her slaytın özgün biçimlendirmesini korurken net bir yapı oluşturur.

Aşağıdaki Java kodu, belirli bir slaytı bir sunum bölümüne nasıl birleştireceğinizi gösterir:

```java
import com.aspose.slides.*;

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

## **Diğer İlgili İçerikler** 

Aspose, bir **ÜCRETSİZ Online Kolaj Oluşturucu** ([FREE Online Collage Maker](https://products.aspose.app/slides/tr/collage)) sunar. Bu çevrimiçi hizmeti kullanarak [JPG‑den JPG‑ye](https://products.aspose.app/slides/tr/collage/jpg) veya PNG‑den PNG‑ye resimleri birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir ve daha fazlasını yapabilirsiniz.

[Aspose ÜCRETSİZ Online Birleştirici](https://products.aspose.app/slides/tr/merger) ’ni inceleyin. Aynı formatta (ör. PPT‑den PPT‑ye, PPTX‑den PPTX‑ye) ya da farklı formatlar arasında (ör. PPT‑den PPTX‑e, PPTX‑den ODP‑ye) PowerPoint sunumlarını birleştirmenizi sağlar.

[![Aspose ÜCRETSİZ Online Birleştirici](slides-merger.png)](https://products.aspose.app/slides/tr/merger)

Sunumların yanı sıra, Aspose.Slides diğer dosya türlerini de birleştirmenize olanak tanır:

- [**Görseller**](https://products.aspose.com/slides/tr/java/merger/image-to-image/), örneğin [JPG‑den JPG‑ye](https://products.aspose.com/slides/tr/java/merger/jpg-to-jpg/) veya [PNG‑den PNG‑ye](https://products.aspose.com/slides/tr/java/merger/png-to-png/)
- **Belgeler**, örneğin [PDF‑den PDF‑ye](https://products.aspose.com/slides/tr/java/merger/pdf-to-pdf/) veya [HTML‑den HTML‑ye](https://products.aspose.com/slides/tr/java/merger/html-to-html/)
- **Karışık dosya türleri**, örneğin [görselden PDF‑ye](https://products.aspose.com/slides/tr/java/merger/image-to-pdf/), [JPG‑den PDF‑ye](https://products.aspose.com/slides/tr/java/merger/jpg-to-pdf/) veya [TIFF‑den PDF‑ye](https://products.aspose.com/slides/tr/java/merger/tiff-to-pdf/)

## **SSS** 

### Sunumları birleştirirken slayt sayısıyla ilgili sınırlamalar var mı? 

Katı bir sınırlama yoktur. Aspose.Slides büyük dosyaları işleyebilir, ancak performans dosyanın büyüklüğüne ve sistem kaynaklarına bağlıdır. Çok büyük sunumlar için 64‑bit JVM kullanmanız ve yeterli yığın belleği ayırmanız önerilir.

### Gömülü video veya ses içeren sunumları birleştirebilir miyim? 

Evet, Aspose.Slides slaytlara gömülü multimedya içeriğini korur, ancak sonuç sunumun boyutu önemli ölçüde artabilir.

### Sunumları birleştirirken yazı tipleri korunur mu? 

Evet. Kaynak sunumlardan kullanılan yazı tipleri, sistemde yüklü olduğu veya [gömülü](/slides/tr/java/embedded-font/) olduğu sürece çıktı dosyasında korunur.