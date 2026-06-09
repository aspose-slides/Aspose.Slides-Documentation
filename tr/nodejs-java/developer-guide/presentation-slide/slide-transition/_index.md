---
title: JavaScript Kullanarak Sunumlarda Slayt Geçişlerini Yönetme
linktitle: Slayt Geçişi
type: docs
weight: 80
url: /tr/nodejs-java/slide-transition/
keywords:
- slayt geçişi
- slayt geçişi ekle
- slayt geçişi uygula
- gelişmiş slayt geçişi
- morph geçişi
- geçiş türü
- geçiş efekti
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak JavaScript'te slayt geçişlerini özelleştirin, PowerPoint ve OpenDocument sunumları için adım adım rehberlik."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunumlarda slayt geçişlerini nasıl yöneteceğinizi açıklar. Slaytlara geçiş türleri uygulamayı, geçiş davranışını tıklamayla veya belirli bir süreden sonra ilerletmeyi, otomatik ilerlemeyi kontrol etmeyi ve devre dışı bırakmayı, Morph geçişini ve türlerini kullanmayı ve geçiş efekti seçeneklerini ayarlamayı gösterir. Örnekler, bir sunumu nasıl yükleneceğini veya oluşturulacağını, seçili slaytların geçiş ayarlarının nasıl değiştirileceğini ve sonucun PPTX dosyası olarak nasıl kaydedileceğini gösterir. Makale ayrıca geçiş hızı, geçiş sesleri, aynı geçişin birden çok slayda uygulanması ve bir slaytta şu anda ayarlanmış geçişin nasıl kontrol edileceği gibi yaygın sorulara yanıt verir.

## **Slayt Geçişi Ekle**
Basit bir slayt geçişi etkisi oluşturmak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının örneğini oluşturun.
2. Aspose.Slides for Node.js via Java tarafından sunulan geçiş efektlerinden birini TransitionType enum üzerinden seçerek slayta bir **Slide Transition Type** uygulayın.
3. Değiştirilmiş sunum dosyasını yazın.

```javascript
// Presentation sınıfını örnekleyerek kaynak sunum dosyasını yükleyin
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Slayt 1'e daire tipi geçiş uygula
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Slayt 2'ye tarak tipi geçiş uygula
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Sunumu diske yaz
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gelişmiş Slayt Geçişi Ekle**
Önceki bölümde yalnızca basit bir geçiş efekti uyguladık. Şimdi bu basit geçişi daha iyi ve kontrol edilebilir hale getirmek için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının örneğini oluşturun.
2. Aspose.Slides for Node.js via Java tarafından sunulan geçiş efektlerinden birini slayta uygulayın.
3. Geçişi **Advance On Click**, belirli bir zaman diliminden sonra veya her ikisi olarak ayarlayabilirsiniz.
4. Geçiş **Advance On Click** olarak etkinleştirilmişse, geçiş yalnızca bir tıklama ile ilerler. **Advance After Time** özelliği ayarlanmışsa, belirtilen süre geçtikten sonra geçiş otomatik olarak ilerler.
5. Değiştirilmiş sunumu bir sunum dosyası olarak yazın.

```javascript
// Bir sunum dosyasını temsil eden Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // Slayt 1'e daire tipi geçiş uygula
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Geçiş süresini 3 saniye olarak ayarla
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // Slayt 2'ye tarak tipi geçiş uygula
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Geçiş süresini 5 saniye olarak ayarla
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // Slayt 3'e yakınlaştırma tipi geçiş uygula
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // Geçiş süresini 7 saniye olarak ayarla
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // Sunumu diske kaydet
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph Geçişi**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java artık [Morph Transition](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/MorphTransition) geçişini destekliyor. Bu, PowerPoint 2019’da tanıtılan yeni morph geçişini temsil eder.

{{% /alert %}} 

Morph geçişi, bir slayttan diğerine sorunsuz bir hareket animasyonu oluşturmanıza olanak tanır. Bu makale kavramı ve Morph geçişinin nasıl kullanılacağını açıklar. Morph geçişini etkili bir şekilde kullanmak için ortak en az bir nesneye sahip iki slayta ihtiyacınız olur. En kolay yöntem, slaytı kopyalayıp ikinci slayttaki nesneyi farklı bir konuma taşımaktır.

Aşağıdaki kod parçacığı, sunuma bazı metin içeren bir slayt kopyası eklemenizi ve ikinci slayta bir [morph type](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TransitionType) geçişi ayarlamanızı gösterir.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph Geçişi Türleri**
Yeni bir [TransitionMorphType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/TransitionMorphType) enum u eklendi. Bu, farklı Morph slayt geçişi türlerini temsil eder.

TransitionMorphType enum unun üç üyesi vardır:

- ByObject: Morph geçişi, şekilleri bölünemez nesneler olarak ele alarak gerçekleştirilir.
- ByWord: Morph geçişi, mümkün olduğunda metni kelimeler bazında aktararak gerçekleştirilir.
- ByChar: Morph geçişi, mümkün olduğunda metni karakterler bazında aktararak gerçekleştirilir.

Aşağıdaki kod parçacığı, slayta morph geçişi ayarlamayı ve morph türünü değiştirmeyi gösterir:

```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Geçiş Efektlerini Ayarla**
Aspose.Slides for Node.js via Java, siyah’dan, soldan, sağdan vb. gibi geçiş efektlerini ayarlamayı destekler. Geçiş Efektini ayarlamak için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının örneğini oluşturun.
- Slayt referansını alın.
- Geçiş efektini ayarlayın.
- Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın.

Aşağıdaki örnekte geçiş efektleri ayarlanmıştır.

```javascript
// Presentation sınıfının bir örneğini oluşturun
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Efekti ayarla
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // Sunumu diske kaydedin
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Geçişin [speed](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/setspeed/) özelliğini [TransitionSpeed](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/transitionspeed/) ayarıyla (yavaş/orta/hızlı) belirleyin.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. Geçiş için bir ses gömebilir ve ses modu, döngü gibi ayarlarla davranışı kontrol edebilirsiniz (ör. [setSound](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/)), ayrıca [setSoundIsBuiltIn](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) ve [setSoundName](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/setsoundname/) gibi meta veriler de bulunur.

**Aynı geçişi her slayta en hızlı nasıl uygularım?**

Her slaytın geçiş ayarlarında istenen geçiş türünü yapılandırın; geçişler slayt başına saklandığından aynı türü tüm slaytlara uygulamak tutarlı bir sonuç verir.

**Bir slaytta şu anda ayarlanmış geçişi nasıl kontrol ederim?**

Slaydın [transition settings](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) kısmını inceleyin ve [transition type](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideshowtransition/gettype/) değerini okuyun; bu değer hangi etkinin uygulandığını doğrudan gösterir.