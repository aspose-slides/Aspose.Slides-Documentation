---
title: Java ile Sunularda Slayt Geçişlerini Yönetme
linktitle: Slayt Geçişi
type: docs
weight: 80
url: /tr/java/slide-transition/
keywords:
- slayt geçişi
- slayt geçişi ekle
- slayt geçişi uygula
- gelişmiş slayt geçişi
- morph geçişi
- geçiş tipi
- geçiş efekti
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da PowerPoint ve OpenDocument sunumları için adım adım rehberlik ile slayt geçişlerini nasıl özelleştireceğinizi keşfedin."
---
## **Overview**

Bu makale, Aspose.Slides kullanarak sunularda slayt geçişlerini nasıl yöneteceğinizi açıklar. Slaytlara geçiş türleri uygulama, tıklama ile veya belirli bir süreden sonra ilerleme gibi geçiş davranışını yapılandırma, otomatik ilerlemeyi kontrol etme ve devre dışı bırakma, Morph geçişi ve tiplerini kullanma ve geçiş efekti seçeneklerini ayarlama konularını gösterir. Örnekler, bir sunumu yükleme veya oluşturma, seçili slaytlar için geçiş ayarlarını değiştirme ve sonucu PPTX dosyası olarak kaydetme konularını gösterir. Makale ayrıca geçiş hızı, geçiş sesleri, aynı geçişin birden çok slayta uygulanması ve bir slaytta şu anda ayarlanmış geçişin kontrol edilmesi gibi sık sorulan sorulara da yanıt verir.

## **Slayt Geçişi Ekle**
Basit bir slayt geçişi efekti oluşturmak için aşağıdaki adımları izleyin:

1. Aspose.Slides'in [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. Aspose.Slides for Java tarafından sunulan geçiş efektlerinden birini kullanarak slayta bir geçiş türü uygulayın.
3. Değiştirilmiş sunum dosyasını yazın.

```java
// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 1. slayta daire tipi geçiş uygula
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 2. slayta comb tipi geçiş uygula
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Sunumu diske kaydet
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gelişmiş Slayt Geçişi Ekle**
Yukarıdaki bölümde slayta basit bir geçiş efekti uygulamıştık. Şimdi bu basit geçiş efektini daha da iyileştirip kontrol edilebilir hâle getirmek için aşağıdaki adımları izleyin:

1. Aspose.Slides'in [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. Aspose.Slides for Java tarafından sunulan geçiş efektlerinden birini kullanarak slayta bir geçiş türü uygulayın.
3. Geçişi Advance On Click, belirli bir süre sonrasında Advance After Time veya her ikisine de ayarlayabilirsiniz.
4. Geçiş Advance On Click olarak etkinleştirildiyse, geçiş yalnızca fare tıklandığında ilerleyecektir. Ayrıca, Advance After Time özelliği ayarlandıysa, geçiş belirtilen sürenin geçmesinin ardından otomatik olarak ilerleyecektir.
5. Değiştirilmiş sunumu bir sunum dosyası olarak yazın.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // 1. slayta daire tipi geçiş uygula
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Geçiş süresini 3 saniye olarak ayarla
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // 2. slayta comb tipi geçiş uygula
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Geçiş süresini 5 saniye olarak ayarla
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // 3. slayta zoom tipi geçiş uygula
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Geçiş süresini 7 saniye olarak ayarla
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Sunumu diske kaydet
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph Geçişi**
{{% alert color="primary" %}} 

Aspose.Slides for Java artık [Morph Transition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IMorphTransition) desteğine sahip. Bu, PowerPoint 2019'da tanıtılan yeni morph geçişini temsil eder.

{{% /alert %}} 

Morph geçişi, bir slayttan sonraki slayta sorunsuz bir hareketi animasyonlu hâle getirmenizi sağlar. Bu makale, kavramı ve Morph geçişinin nasıl kullanılacağını açıklar. Morph geçişini etkili bir şekilde kullanmak için ortak en az bir nesneye sahip iki slaytınız olmalıdır. En kolay yol, slaytı kopyalamak ve ikinci slayttaki nesneyi farklı bir konuma taşımaktır.

Aşağıdaki kod parçacığı, slaytın bir klonunu bazı metinlerle sunuma eklemeyi ve ikinci slayta bir [morph type](https://reference.aspose.com/slides/tr/java/com.aspose.slides/TransitionType) geçişi ayarlamayı gösterir.

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Morph Geçişi Türleri**
Yeni eklenen [TransitionMorphType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/TransitionMorphType) enum'ı, farklı Morph slayt geçişi türlerini temsil eder.

TransitionMorphType enum'ı üç üyeye sahiptir:

- ByObject: Morph geçişi, şekilleri bölünemez nesneler olarak ele alarak gerçekleştirilir.
- ByWord: Morph geçişi, mümkün olduğunda metni kelimeler halinde aktararak gerçekleştirilir.
- ByChar: Morph geçişi, mümkün olduğunda metni karakterler halinde aktararak gerçekleştirilir.

Aşağıdaki kod parçacığı, slayta morph geçişi ayarlamayı ve morph tipini değiştirmeyi gösterir:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Geçiş Efektlerini Ayarla**
Aspose.Slides for Java, siyah üzerinden, soldan, sağdan vb. gibi geçiş efektlerini ayarlamayı destekler. Geçiş Efektini ayarlamak için aşağıdaki adımları izleyin:

- Aspose.Slides'in [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Slayt referansını alın.
- Geçiş efektini ayarlayın.
- Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın.

Aşağıda verilen örnekte, geçiş efektlerini ayarladık.

```java
// Presentation sınıfının bir örneğini oluşturun
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Etkiyi ayarla
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Sunumu diske kaydet
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Geçişin [speed](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) ayarını, [TransitionSpeed](https://reference.aspose.com/slides/tr/java/com.aspose.slides/transitionspeed/) ayarını (ör. slow/medium/fast) kullanarak belirleyin.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. Geçiş için ses gömebilir ve ses modu ve döngü gibi ayarlarla davranışı kontrol edebilirsiniz (ör. [setSound](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), ayrıca [setSoundIsBuiltIn](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-), [setSoundName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-) gibi meta veriler).

**Aynı geçişi her slayta uygulamanın en hızlı yolu nedir?**

İstenen geçiş tipini her slaytın geçiş ayarlarında yapılandırın; geçişler slayt başına saklanır, bu yüzden aynı tip tüm slaytlara uygulanarak tutarlı bir sonuç elde edilir.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol edebilirim?**

Slaytın [transition settings](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseslide/#getSlideShowTransition--) özelliğini inceleyin ve [transition type](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideshowtransition/#setType-int-) değerini okuyun; bu değer, hangi etkinin uygulandığını tam olarak gösterir.