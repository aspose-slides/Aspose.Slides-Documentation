---
title: JavaScript ile Sunum Slaytlarını Klonla
linktitle: Slaytları Klonla
type: docs
weight: 35
url: /tr/nodejs-java/clone-slides/
keywords:
- slayt klonla
- slayt kopyala
- slayt kaydet
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile PowerPoint slaytlarını hızlıca çoğaltın. Kod örneklerimizi izleyerek PPT oluşturmayı saniyeler içinde otomatikleştirin ve manuel işi ortadan kaldırın."
---
## **Giriş**

Kloneleme, bir şeyin tam bir kopyasını veya replikasını oluşturma işlemidir. Aspose.Slides for Node.js via Java, herhangi bir slaytı kopyalamanızı veya klonlamanızı ve ardından o klonlanmış slaytı geçerli veya başka bir açık sunumun içine eklemenizi sağlar. Slayt klonlama süreci, orijinal slaytı değiştirmeden geliştiricilerin değiştirebileceği yeni bir slayt oluşturur. Bir slaytı klonlamanın birkaç olası yolu vardır:

- Sunum içinde sonuna klonla.
- Sunum içinde başka bir konuma klonla.
- Başka bir sunumun sonuna klonla.
- Başka bir sunumda başka bir konuma klonla.
- Başka bir sunumda belirli bir konuma klonla.

Aspose.Slides for Node.js via Java’de, [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) nesnesi tarafından sunulan (bir [Slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Slide) nesnesi koleksiyonu), yukarıdaki slayt klonlama tiplerini gerçekleştirmek için [addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) ve [insertClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) yöntemlerini sağlar.

## **Sunum içinde sonuna klonla**
Aynı sunum dosyasında mevcut slaytların sonuna bir slaytı klonlayıp kullanmak istiyorsanız, aşağıdaki adımlara göre [addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) yöntemini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) nesnesi tarafından sunulan Slides koleksiyonuna başvurarak [SlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getSlides--) sınıfını örnekleyin.  
3. [SlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) yöntemini çağırın ve klonlanacak slaytı parametre olarak geçin.  
4. Değiştirilen sunum dosyasını yazın.

Aşağıdaki örnekte, sunumun ilk konumunda (sıfır indeksi) bulunan bir slaytı, sunumun sonuna klonladık.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonlayın
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Değiştirilmiş sunumu diske yazın
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Sunum içinde başka bir konuma klonla**
Aynı sunum dosyasında farklı bir konuma bir slaytı klonlayıp kullanmak istiyorsanız, [insertClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) yöntemini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) nesnesi tarafından sunulan **Slides** (https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getSlides--) koleksiyonuna başvurarak sınıfı örnekleyin.  
3. [SlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [insertClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) yöntemini çağırın ve klonlanacak slaytı yeni konumun indeksiyle birlikte parametre olarak geçin.  
4. Değiştirilen sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun 1. indeksindeki (2. konum) slaytı, 2. indeks (3. konum) içine klonladık.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // İstenen slaytı aynı sunumdaki slayt koleksiyonunun sonuna klonlayın
    var slds = pres.getSlides();
    // İstenen slaytı aynı sunumdaki belirtilen indekse klonlayın
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Değiştirilmiş sunumu diske yazın
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Başka bir sunumun sonuna klonla**
Bir sunumdan slaytı klonlayıp, başka bir sunum dosyasının mevcut slaytların sonuna eklemek istiyorsanız:

1. Slaytın klonlanacağı kaynak sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) örneği oluşturun.  
2. Slaytın ekleneceği hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) örneği oluşturun.  
3. Hedef sunumun Presentation nesnesi tarafından sunulan **Slides** (https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getSlides--) koleksiyonuna başvurarak [SlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection) sınıfını örnekleyin.  
4. [SlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) yöntemini çağırın ve kaynak sunumdan slaytı parametre olarak geçin.  
5. Değiştirilen hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun ilk indeksindeki bir slaytı, hedef sunumun sonuna klonladık.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Hedef PPTX için Presentation sınıfını örnekleyin (slaytın klonlanacağı yer)
    var destPres = new aspose.slides.Presentation();
    try {
        // İstenen slaytı kaynak sunumdan hedef sunumdaki slayt koleksiyonunun sonuna klonlayın
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Hedef sunumu diske yazın
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Başka bir sunumda başka bir konuma klonla**
Bir sunumdan slaytı klonlayıp, başka bir sunum dosyasında belirli bir konuma eklemek istiyorsanız:

1. Slaytın klonlanacağı kaynak sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) örneği oluşturun.  
2. Slaytın ekleneceği hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) örneği oluşturun.  
3. Hedef sunumun Presentation nesnesi tarafından sunulan Slides koleksiyonuna başvurarak [SlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getSlides--) sınıfını örnekleyin.  
4. [SlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [insertClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) yöntemini çağırın ve kaynak sunumdan slaytı, istenen konumla birlikte parametre olarak geçin.  
5. Değiştirilen hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki bir slaytı, hedef sunumun 1. indeksine (2. konum) klonladık.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Hedef PPTX için Presentation sınıfını örnekleyin (slaytın klonlanacağı yer)
    var destPres = new aspose.slides.Presentation();
    try {
        // İstenen slaytı kaynak sunumdan hedef sunumdaki slayt koleksiyonunun sonuna klonlayın
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // Hedef sunumu diske yazın
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Başka bir sunumda belirli bir konuma klonla**
Bir slaytı, ana slaytıyla birlikte bir sunumdan klonlayıp başka bir sunuma eklemek istiyorsanız, önce istenen ana slaytı kaynak sunumdan hedef sunuma klonlamanız gerekir. Ardından bu ana slaytı, ana slaytı olan slaytı klonlamak için kullanmalısınız. [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) yöntemi, kaynak sunumdan değil hedef sunumdan bir ana slayt bekler. Ana slaytı içeren slaytı klonlamak için aşağıdaki adımları izleyin:

1. Slaytı klonlayacağınız kaynak sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) örneği oluşturun.  
2. Slaytı klonlayacağınız hedef sunumu içeren bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) örneği oluşturun.  
3. Klonlanacak slaytı ve ilgili ana slaytı alın.  
4. Hedef sunumun Presentation nesnesi tarafından sunulan Masters koleksiyonuna başvurarak [MasterSlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/MasterSlideCollection) sınıfını örnekleyin.  
5. [MasterSlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/MasterSlideCollection) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) yöntemini çağırın ve kaynak PPTX’ten klonlanacak ana slaytı parametre olarak geçin.  
6. Hedef sunumun Presentation nesnesi tarafından sunulan Slides koleksiyonuna başvurarak [SlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getSlides--) sınıfını ayarlayın.  
7. [SlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getSlides--) nesnesi tarafından sunulan [addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) yöntemini çağırın ve kaynak sunumdaki slaytı ve ana slaytı parametre olarak geçin.  
8. Değiştirilen hedef sunum dosyasını yazın.

Aşağıdaki örnekte, kaynak sunumun sıfır indeksindeki bir slaytı, kaynak slayttan bir ana slayt kullanarak hedef sunumun sonuna klonladık.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Hedef sunum (slaytın klonlanacağı yer) için Presentation sınıfını örnekleyin
    var destPres = new aspose.slides.Presentation();
    try {
        // Kaynak sunumdaki slayt koleksiyonundan ISlide öğesini ve
        // Ana slaytı örnekleyin
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // İstenen ana slaytı kaynak sunumdan hedef sunumun
        // ana slayt koleksiyonuna klonlayın
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // İstenen slaytı, istenen master slaytı ile birlikte kaynak sunumdan hedef sunumdaki slayt koleksiyonunun sonuna
        // klonlayın
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // Hedef sunumu diske kaydedin
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Belirtilen Bölümde sonuna klonla**
Aynı sunum dosyasında farklı bir bölüme bir slaytı klonlayıp eklemek istiyorsanız, [**addClone**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) yöntemini [**SlideCollection**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection) sınıfı üzerinden kullanın. Aspose.Slides for Node.js via Java, bir slaytı ilk bölümden klonlamayı ve ardından o klonlanmış slaytı aynı sunumun ikinci bölümüne eklemeyi mümkün kılar.

Aşağıdaki kod parçacığı, bir slaytı klonlayıp belirtilen bir bölüme eklemenizi gösterir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Hedef sunumu diske kaydedin
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Eşleşen Slayt Boyutunu Sağlama**

Slaytları başka bir sunuma klonlarken, hedef sunumun slayt boyutunun kaynakla aynı olduğundan emin olun. Slayt boyutları farklıysa, Aspose.Slides klonlanmış şekilleri otomatik olarak yeniden ölçeklendirmez—orijinal koordinat ve boyutları korunur; bu da içeriğin kaydırılmış veya slayt sınırları dışına taşmış görünmesine yol açabilir.

Klonlamadan önce master ve slaytı klonlamadan önce hedef sunumun slayt boyutunu kaynağa eşitleyebilirsiniz:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

Bunu master ve slaytı klonlamadan önce yapın.

## **SSS**

**Konuşmacı notları ve yorumlayıcı yorumları klonlanır mı?**

Evet. Not sayfası ve inceleme yorumları klona dahil edilir. İstemiyorsanız, eklemeden sonra [kaldırın](/slides/tr/nodejs-java/presentation-notes/).

**Grafikler ve veri kaynakları nasıl ele alınır?**

Grafik nesnesi, biçimlendirme ve gömülü veri kopyalanır. Grafik harici bir kaynağa (ör. OLE gömülü çalışma kitabı) bağlıysa, bu bağlantı bir [OLE nesnesi](/slides/tr/nodejs-java/manage-ole/) olarak korunur. Dosyalar arasında taşındıktan sonra veri kullanılabilirliğini ve yenileme davranışını kontrol edin.

**Klonun ekleme konumunu ve bölümlerini kontrol edebilir miyim?**

Evet. Klonu belirli bir slayt indeksine ekleyebilir ve seçtiğiniz bir [bölüme](/slides/tr/nodejs-java/slide-section/) yerleştirebilirsiniz. Hedef bölüm yoksa, önce oluşturup ardından slaytı ona taşıyın.