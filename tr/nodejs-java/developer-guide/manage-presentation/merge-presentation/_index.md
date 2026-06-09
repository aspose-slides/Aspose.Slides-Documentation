---
title: JavaScript'te Sunumları Verimli Bir Şekilde Birleştirme
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/nodejs-java/merge-presentation/
keywords:
- PowerPoint'i birleştir
- sunumları birleştir
- slaytları birleştir
- PPT'yi birleştir
- PPTX'i birleştir
- ODP'yi birleştir
- PowerPoint'i birleştir
- sunumları birleştir
- slaytları birleştir
- PPT'yi birleştir
- PPTX'i birleştir
- ODP'yi birleştir
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript'te Aspose.Slides for Node.js ile PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarını zahmetsizce birleştirerek iş akışınızı sadeleştirin."
---
## **Genel Bakış**

Aspose.Slides, slaytları bir sunumdan diğerine kopyalayarak sunumları birleştirmenizi sağlar. Bu makale, bütün sunumları veya seçilen slaytları nasıl birleştireceğinizi, birleştirme sırasında bir slayt ustası veya belirli bir düzenin nasıl kullanılacağını, farklı slayt boyutlarına sahip sunumların nasıl ele alınacağını ve birleştirilen slaytların bir sunum bölümüne nasıl ekleneceğini açıklar. Ayrıca birleştirilmiş içerikle ilgili pratik notları kapsar; konuşmacı notları, yorumlar, şifre korumalı kaynak dosyalar ve iş parçacığı kullanımı dahil.

## **Sunum Birleştirme**

Bir sunumu diğerine birleştirdiğinizde, slaytlarını tek bir sunumda birleştirerek tek bir dosya elde etmiş olursunuz.

{{% alert title="Bilgi" color="info" %}}

Çoğu sunum programı (PowerPoint veya OpenOffice), kullanıcıların sunumları bu şekilde birleştirmesine olanak tanıyan işlevlere sahip değildir. 

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/tr/nodejs-java/), farklı şekillerde sunumları birleştirmenize izin verir. Tüm şekiller, stiller, metinler, biçimlendirme, yorumlar, animasyonlar vb. kayıpsız bir şekilde birleştirilen bir sunuma aktarılır.

**Ayrıca Bakınız**

[Slaytları Kopyala](https://docs.aspose.com/slides/tr/nodejs-java/clone-slides/).

{{% /alert %}}

### **Ne Birleştirilebilir**

Aspose.Slides ile

* bütün sunumları birleştirebilirsiniz. Sunumlardan tüm slaytlar tek bir sunumda yer alır
* belirli slaytları birleştirebilirsiniz. Seçilen slaytlar tek bir sunumda yer alır
* aynı formatta (PPT’den PPT’ye, PPTX’ten PPTX’e vb.) ve farklı formatlarda (PPT’den PPTX’e, PPTX’ten ODP’ye vb.) sunumları birbiriyle birleştirebilirsiniz. 

### **Birleştirme Seçenekleri**

Aşağıdaki seçenekleri uygulayabilirsiniz:

* çıktı sunumundaki her slaytın benzersiz bir stile sahip olup olmayacağı
* tüm slaytların aynı stilin kullanılması isteği. 

Sunumları birleştirmek için Aspose.Slides, [addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metodunu ([SlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection) sınıfından) sağlar. `addClone` metodunun birden çok uygulaması bulunur ve birleştirme sürecinin parametrelerini tanımlar. Her Presentation nesnesinin bir [Slides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getSlides--) koleksiyonu vardır; bu yüzden slaytları birleştirmek istediğiniz sunum üzerinden bir `addClone` metodu çağırabilirsiniz.

`addClone` metodu, kaynak slaytın bir kopyası olan bir `Slide` nesnesi döndürür. Çıktı sunumundaki slaytlar, kaynak slaytların basit bir kopyasıdır. Bu nedenle, kaynak sunumlar etkilenmeden oluşturulan slaytlarda (örneğin stil veya biçimlendirme seçenekleri ya da düzenler uygulayarak) değişiklik yapabilirsiniz. 

## **Sunumları Birleştirme** 

Aspose.Slides, slaytların düzen ve stillerini koruyarak birleştirmenizi sağlayan [**AddClone(ISlide)**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metodunu sunar (varsayılan parametreler).

Bu JavaScript kodu, sunumları nasıl birleştireceğinizi gösterir:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Sunumları Slayt Ustasıyla Birleştirme**

Aspose.Slides, slaytları bir slayt ustası şablonu uygulayarak birleştirmenizi sağlayan [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) metodunu sunar. Böylece gerekirse çıktı sunumundaki slaytların stilini değiştirebilirsiniz.

Bu JavaScript kodu, açıklanan işlemi gösterir:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

{{% alert title="Not" color="warning" %}} 

Slayt ustası için slayt düzeni otomatik olarak belirlenir. Uygun bir düzen belirlenemezse, `addClone` metodunun `allowCloneMissingLayout` boolean parametresi **true** olarak ayarlanmışsa kaynak slaytın düzeni kullanılır. Aksi takdirde [PptxEditException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PptxEditException) hatası fırlatılır.

{{% /alert %}}

Çıktı sunumundaki slaytların farklı bir slayt düzeni almasını istiyorsanız, birleştirirken [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) metodunu kullanın.

## **Sunumlardan Belirli Slaytları Birleştirme**

Birden fazla sunumdan belirli slaytları birleştirmek, özel slayt takımları oluşturmak için yararlıdır. Aspose.Slides for Node.js via Java, yalnızca ihtiyacınız olan slaytları seçip içe aktarmanıza olanak tanır. API, orijinal slaytların biçimlendirmesini, düzenini ve tasarımını korur.

Aşağıdaki JavaScript kodu, iki başka sunumdan başlık slaytlarını ekleyerek yeni bir sunum oluşturur ve sonucu bir dosyaya kaydeder:

```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```
```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

## **Slayt Düzeniyle Sunumları Birleştirme**

Bu JavaScript kodu, slaytları birleştirirken tercih ettiğiniz slayt düzenini uygulayarak tek bir çıktı sunumu elde etmenizi gösterir:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştirme**

{{% alert title="Not" color="warning" %}} 

Farklı slayt boyutlarına sahip sunumlar birleştirilemez. 

{{% /alert %}}

Farklı slayt boyutlarına sahip 2 sunumu birleştirmek için, boyutları aynı olacak şekilde bir sunumu yeniden boyutlandırmanız gerekir. 

Bu örnek kod, açıklanan işlemi gösterir:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Slaytları Sunum Bölümüne Birleştirme**

Bu JavaScript kodu, belirli bir slaytı bir sunum bölümüne nasıl birleştireceğinizi gösterir:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

Slayt, bölümün sonuna eklenir. 

## **SSS**

**Birleştirme sırasında konuşmacı notları korunur mu?**

Evet. Slaytları kopyalarken Aspose.Slides, notlar, biçimlendirme ve animasyonlar da dahil olmak üzere tüm slayt öğelerini aktarır.

**Yorumlar ve yazarları aktarılır mı?**

Yorumlar, slayt içeriğinin bir parçası olarak slaytla birlikte kopyalanır. Yorum yazar etiketleri, sonuç sunumunda yorum nesneleri olarak korunur.

**Kaynak sunum şifre korumalıysa ne olur?**

Şifreyle [açılmalıdır](/slides/tr/nodejs-java/password-protected-presentation/) ve [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/setpassword/) ile yüklenmelidir; yüklendikten sonra bu slaytlar korumasız bir hedef dosyaya (veya korumalı bir dosyaya) güvenle kopyalanabilir.

**Birleştirme işlemi ne kadar iş parçacığı güvenlidir?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneğini [birden fazla iş parçacığından](/slides/tr/nodejs-java/multithreading/) kullanmayın. Önerilen kural “bir belge — bir iş parçacığı”; farklı dosyalar ayrı iş parçacıklarında paralel olarak işlenebilir.

## **Diğer Bağlantılar**

Aspose, [ÜCRETSİZ Online Kolaj Oluşturucu](https://products.aspose.app/slides/tr/collage) sağlar. Bu çevrimiçi hizmetle [JPG’den JPG’ye](https://products.aspose.app/slides/tr/collage/jpg) veya PNG’den PNG’ye görselleri birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir ve daha fazlasını yapabilirsiniz.

[ÜCRETSİZ Online Birleştirici](https://products.aspose.app/slides/tr/merger)’yi inceleyin. Aynı formatta (ör. PPT’den PPT’ye, PPTX’den PPTX’e) veya farklı formatlar arasında (ör. PPT’den PPTX’e, PPTX’den ODP’ye) PowerPoint sunumlarını birleştirmenize olanak tanır.

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/tr/merger)