---
title: Android'de Sunumlarda Slayt Geçişlerini Yönetme
linktitle: Slayt Geçişi
type: docs
weight: 80
url: /tr/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'da slayt geçişlerini nasıl özelleştireceğinizi, PowerPoint ve OpenDocument sunumları için adım adım rehberle keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunumlarda slayt geçişlerini nasıl yöneteceğinizi açıklar. Slaytlara geçiş türleri uygulamayı, tıklamayla ilerleme veya belirli bir süreden sonra ilerleme gibi geçiş davranışını yapılandırmayı, otomatik ilerlemeyi kontrol etmeyi ve devre dışı bırakmayı, Morph geçişini ve türlerini kullanmayı ve geçiş efekti seçeneklerini ayarlamayı gösterir. Örnekler, bir sunumu yüklemeyi veya oluşturmayı, seçili slaytlar için geçiş ayarlarını değiştirmeyi ve sonucu PPTX dosyası olarak kaydetmeyi gösterir. Makale ayrıca geçiş hızı, geçiş sesleri, aynı geçişin birden fazla slayta uygulanması ve bir slaytta şu anda ayarlanmış geçişin kontrol edilmesi gibi yaygın soruları yanıtlar.

## **Slayt Geçişi Ekle**
Basit bir slayt geçiş efekti oluşturmak için, aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. Aspose.Slides for Android via Java tarafından sunulan geçiş efektlerinden birini kullanarak slayta bir Slide Transition Type uygulayın ve TransitionType enum üzerinden belirtin.
3. Değiştirilmiş sunum dosyasını yazın.

```java
// Sunum sınıfını başlat ve kaynak sunum dosyasını yükle
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 1. slayta daire tipi geçişi uygula
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 2. slayta comb tipi geçişi uygula
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Sunumu diske yaz
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gelişmiş Slayt Geçişi Ekle**
Yukarıdaki bölümde, slayta sadece basit bir geçiş efekti uyguladık. Şimdi, bu basit geçiş efektini daha iyi ve kontrol edilebilir hale getirmek için, lütfen aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. Aspose.Slides for Android via Java tarafından sunulan geçiş efektlerinden birini kullanarak slayta bir Slide Transition Type uygulayın.
3. Geçişi Tıklamayla İlerleme, belirli bir zaman diliminden sonra veya her ikisi olarak ayarlayabilirsiniz.
4. Eğer slayt geçişi Tıklamayla İlerleme olarak etkinleştirilmişse, geçiş yalnızca birinin fareye tıkladığında ilerleyecektir. Ayrıca, Advance After Time özelliği ayarlanmışsa, geçiş belirtilen sürenin geçmesinin ardından otomatik olarak ilerleyecektir.
5. Değiştirilmiş sunumu bir sunum dosyası olarak yazın.

```java
// Sunumu temsil eden Presentation sınıfını başlat
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // 1. slayta daire tipi geçişi uygula
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 3 saniye geçiş süresini ayarla
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // 2. slayta comb tipi geçişi uygula
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 5 saniye geçiş süresini ayarla
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // 3. slayta zoom tipi geçişi uygula
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // 7 saniye geçiş süresini ayarla
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
Aspose.Slides for Android via Java artık [Morph Transition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IMorphTransition) desteği sunuyor. Bu, PowerPoint 2019'da tanıtılan yeni morph geçişini temsil eder.
{{% /alert %}} 

Morph geçişi, bir slayttan sonraki slayta sorunsuz bir hareket animasyonu yapmanızı sağlar. Bu makale kavramı ve Morph geçişinin nasıl kullanılacağını açıklar. Morph geçişini etkili bir şekilde kullanmak için en az bir ortak nesneye sahip iki slayta ihtiyacınız olacak. En kolay yol, slaytı kopyalamak ve ikinci slayttaki nesneyi farklı bir konuma taşımaktır.

Aşağıdaki kod parçacığı, sunuma bir metin içeren slayt klonu eklemeyi ve ikinci slayta bir [morph type](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/TransitionType) geçişi ayarlamayı gösterir.

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

## **Morph Geçiş Tipleri**
Yeni [TransitionMorphType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/TransitionMorphType) enum'ı eklendi. Bu, Morph slayt geçişinin farklı tiplerini temsil eder.

TransitionMorphType enum'ı üç üye içerir:

- ByObject: Morph geçişi, şekilleri bölünemez nesneler olarak değerlendirerek gerçekleştirilir.
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

## **Geçiş Efektlerini Ayarlama**
Aspose.Slides for Android via Java, siyah üzerinden, soldan, sağdan vb. gibi geçiş efektlerini ayarlamayı destekler. Geçiş Efektini ayarlamak için, lütfen aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Slaytın referansını alın.
- Geçiş efektini ayarlayın.
- Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın.

Aşağıdaki örnekte geçiş efektlerini ayarladık.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Etkiyi ayarla
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Sunumu diske yaz
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Geçişin [speed](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) ayarını [TransitionSpeed](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/transitionspeed/) (örneğin, slow/medium/fast) kullanarak ayarlayabilirsiniz.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. Geçiş için bir ses gömebilir ve ses modu, döngü gibi ayarlarla davranışı kontrol edebilirsiniz (örneğin, [setSound](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), ayrıca [setSoundIsBuiltIn](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) ve [setSoundName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-) gibi meta veriler).

**Aynı geçişi her slayta uygulamanın en hızlı yolu nedir?**

Her slaytın geçiş ayarlarında istenen geçiş tipini yapılandırın; geçişler slayt başına depolandığından, aynı tipin tüm slaytlara uygulanması tutarlı bir sonuç verir.

**Bir slaytta şu anda ayarlanmış geçişi nasıl kontrol edebilirim?**

Slaytın [transition settings](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) inceleyin ve [transition type](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideshowtransition/#setType-int-) değerini okuyun; bu değer hangi etkinin uygulandığını tam olarak gösterir.