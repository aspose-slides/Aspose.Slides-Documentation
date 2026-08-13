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
- Morph geçişi
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

Bu makale, Aspose.Slides kullanarak sunularda slayt geçişlerini nasıl yöneteceğinizi açıklar. Geçiş türlerini slaytlara nasıl uygulayacağınızı, tıklandığında veya belirli bir süreden sonra ilerleme gibi geçiş davranışlarını nasıl yapılandıracağınızı, Morph geçişi ve türlerini nasıl kullanacağınızı ve geçiş efekti seçeneklerini nasıl ayarlayacağınızı gösterir. Örnekler, bir sunumu nasıl yükleyeceğinizi veya oluşturacağınızı, seçili slaytlar için geçiş ayarlarını nasıl değiştireceğinizi ve sonucu PPTX dosyası olarak nasıl kaydedeceğinizi gösterir. Makale ayrıca geçiş hızı, geçiş sesleri, aynı geçişin birden çok slayta uygulanması ve bir slaytta şu anda ayarlı geçişin kontrol edilmesiyle ilgili yaygın soruları yanıtlar.

## **Slayt Geçişi Ekle**
Basit bir slayt geçiş efekti oluşturmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Aspose.Slides for Android via Java tarafından sunulan geçiş efektlerinden birini kullanarak slaytta bir Slide Transition Type uygulayın; bu işlem TransitionType enum ile yapılır.  
3. Değiştirilen sunum dosyasını yazın.

```java
import com.aspose.slides.*;

// Sunum sınıfını örnekleyerek kaynak sunum dosyasını yükle
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 1. slayta daire tipi geçiş uygula
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 2. slayta tarak tipi geçiş uygula
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Sunumu diske kaydet
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gelişmiş Slayt Geçişi Ekle**
Yukarıdaki bölümde sadece basit bir geçiş efekti uygulamıştık. Şimdi bu basit geçişi daha iyi ve kontrol edilebilir hâle getirmek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Aspose.Slides for Android via Java tarafından sunulan geçiş efektlerinden birini kullanarak slaytta bir Slide Transition Type uygulayın.  
3. Geçişi Tıklamayla İlerleme, belirli bir zaman diliminden sonra veya her ikisi olarak ayarlayabilirsiniz.  
4. Geçiş Tıklamayla İlerleme olarak etkinleştirildiyse, geçiş yalnızca fare tıklandığında ilerler. Ayrıca Advance After Time özelliği ayarlanmışsa, belirtilen süre geçtikten sonra geçiş otomatik olarak ilerler.  
5. Değiştirilen sunumu bir sunum dosyası olarak yazın.

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // 1. slayta daire tipi geçiş uygula
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Tıklamayla ilerle veya 3 saniye sonrasında otomatik olarak ilerle
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // 2. slayta tarak tipi geçiş uygula
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Tıklamayla ilerle veya 5 saniye sonrasında otomatik olarak ilerle
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // 3. slayta yakınlaştırma tipi geçiş uygula
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Tıklamayla ilerle veya 7 saniye sonrasında otomatik olarak ilerle
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Sunumu diske kaydet
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph Geçişi**
{{% alert color="info" %}} 
Aspose.Slides for Android via Java artık [Morph Transition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IMorphTransition) özelliğini desteklemektedir. Bu özellik, PowerPoint 2019'da tanıtılan yeni morph geçişini temsil eder.
{{% /alert %}} 

Morph geçişi, bir slayttan diğerine sorunsuz bir hareket animasyonu oluşturmanızı sağlar. Bu makale konsepti ve Morph geçişinin nasıl kullanılacağını açıklar. Morph geçişini etkili bir şekilde kullanmak için ortak en az bir nesneye sahip iki slaytınızın olması gerekir. En kolay yol, slaytı kopyalamak ve ikinci slayttaki nesneyi farklı bir konuma taşımaktır.

Aşağıdaki kod parçacığı, sunuma bir metin içeren slayt klonu ekleyip ikinci slayta bir [morph type](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/TransitionType) geçişi ayarlamanızı gösterir.

```java
import com.aspose.slides.*;

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
Yeni [TransitionMorphType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/TransitionMorphType) enum’ı eklenmiştir. Bu enum, farklı Morph slayt geçişi türlerini temsil eder.

TransitionMorphType enum’ının üç üyesi vardır:

- **ByObject**: Morph geçişi, şekilleri bölünemez nesneler olarak değerlendirerek gerçekleştirilir.  
- **ByWord**: Morph geçişi, mümkün olduğunda metni kelimeler bazında aktararak gerçekleştirilir.  
- **ByChar**: Morph geçişi, mümkün olduğunda metni karakterler bazında aktararak gerçekleştirilir.

Aşağıdaki kod parçacığı, bir slayta morph geçişi ayarlamayı ve morph türünü değiştirmeyi gösterir:

```java
import com.aspose.slides.*;

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
Aspose.Slides for Android via Java, siyahdan, soldan, sağdan vb. gibi geçiş efektlerini ayarlamayı destekler. Geçiş Efektini ayarlamak için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
- Slayt referansını alın.  
- Geçiş efektini ayarlayın.  
- Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın.

Aşağıdaki örnekte geçiş efektleri ayarlanmıştır.

```java
import com.aspose.slides.*;

// Presentation sınıfının bir örneğini oluştur
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

## **SSS**

### Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?

Evet. Geçişin [speed](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) ayarını [TransitionSpeed](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/transitionspeed/) (örneğin, yavaş/orta/hızlı) kullanarak ayarlayabilirsiniz.

### Geçişe ses ekleyebilir ve döngüde çalmasını sağlayabilir miyim?

Evet. Geçiş için bir ses gömebilir ve ses modu, döngü gibi ayarlarla davranışı kontrol edebilirsiniz (örneğin, [setSound](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), ayrıca [setSoundIsBuiltIn](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) ve [setSoundName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-) gibi meta veriler).

### Aynı geçişi her slayta uygulamanın en hızlı yolu nedir?

Her slaytın geçiş ayarlarında istenen geçiş tipini yapılandırın; geçişler slayt başına saklanır, bu yüzden aynı tip tüm slaytlara uygulanarak tutarlı bir sonuç elde edilir.

### Bir slaytta şu anda ayarlı geçişi nasıl kontrol edebilirim?

Slaytın [transition settings](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) öğesini inceleyin ve [transition type](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideshowtransition/#setType-int-) değerini okuyun; bu değer hangi etkinin uygulandığını kesin olarak gösterir.