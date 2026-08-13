---
title: Java Kullanarak Sunularda Slayt Geçişlerini Yönetme
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
- geçiş türü
- geçiş efekti
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da slayt geçişlerini nasıl özelleştireceğinizi keşfedin, PowerPoint ve OpenDocument sunumları için adım adım rehberle."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunularda slayt geçişlerini nasıl yöneteceğinizi açıklar. Slaytlara geçiş türleri uygulamayı, geçiş davranışını – tıklamayla ilerleme veya belirli bir süreden sonra ilerleme – yapılandırmayı, otomatik ilerlemeyi kontrol etmeyi ve devre dışı bırakmayı, Morph geçişini ve türlerini kullanmayı ve geçiş efekti seçeneklerini ayarlamayı gösterir. Örnekler, bir sunumu yüklemenin veya oluşturmanın, seçili slaytlar için geçiş ayarlarını değiştirmenin ve sonucu bir PPTX dosyası olarak kaydetmenin yollarını gösterir. Makale ayrıca geçiş hızı, geçiş sesleri, aynı geçişin birden çok slayta uygulanması ve bir slaytta şu anda ayarlanmış geçişin kontrol edilmesi gibi yaygın sorulara yanıt verir.

## **Slayt Geçişi Ekle**
Basit bir slayt geçiş efekti oluşturmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Aspose.Slides for Java tarafından sunulan geçiş efektlerinden birini TransitionType enum aracılığıyla slayta bir Slide Transition Type uygulayın
1. Değiştirilmiş sunum dosyasını yazın.

```java
import com.aspose.slides.*;

// Kaynak sunum dosyasını yüklemek için Presentation sınıfını örnekleyin
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Slayt 1 üzerinde daire tipi geçişi uygula
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Slayt 2 üzerinde tarak tipi geçişi uygula
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Sunumu diske kaydet
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gelişmiş Slayt Geçişi Ekle**
Yukarıdaki bölümde yalnızca basit bir geçiş efekti uyguladık. Şimdi bu basit geçiş efektini daha iyi ve kontrol edilebilir hâle getirmek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Aspose.Slides for Java tarafından sunulan geçiş efektlerinden birini slayta bir Slide Transition Type uygulayın
1. Geçişi Tıklamayla İleri, belirli bir süre sonra veya her ikisi olarak ayarlayabilirsiniz.
1. Slayt geçişi Tıklamayla İleri olarak etkinleştirilmişse, geçiş yalnızca birisi fareye tıkladığında ilerleyecektir. Ayrıca, Advance After Time özelliği ayarlanmışsa, geçiş belirtilen sürenin geçmesinin ardından otomatik olarak ilerleyecektir.
1. Değiştirilmiş sunumu bir sunum dosyası olarak yazın.

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Slayt 1 üzerinde daire tipi geçişi uygula
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 3 saniyelik geçiş süresini ayarla
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Slayt 2 üzerinde tarak tipi geçişi uygula
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 5 saniyelik geçiş süresini ayarla
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Slayt 3 üzerinde yakınlaştırma tipi geçişi uygula
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // 7 saniyelik geçiş süresini ayarla
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

Aspose.Slides for Java artık [Morph Transition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IMorphTransition) özelliğini destekliyor. Bu, PowerPoint 2019’da tanıtılan yeni morph geçişini temsil eder.

{{% /alert %}} 

Morph geçişi, bir slayttan diğerine sorunsuz bir hareketi canlandırmanıza olanak tanır. Bu makale kavramı ve Morph geçişinin nasıl kullanılacağını açıklar. Morph geçişini etkili bir şekilde kullanmak için ortak en az bir nesneye sahip iki slayta ihtiyacınız olacak. En kolay yol, slaytı kopyalamak ve ikinci slayttaki nesneyi farklı bir konuma taşımaktır.

Aşağıdaki kod parçacığı, sunuma biraz metin içeren bir slayt klonu eklemeyi ve ikinci slayta bir [morph type](https://reference.aspose.com/slides/tr/java/com.aspose.slides/TransitionType) geçişi ayarlamayı gösterir.

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

## **Morph Geçiş Türleri**
Yeni eklenen [TransitionMorphType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/TransitionMorphType) enum, Morph slayt geçişinin farklı türlerini temsil eder.

TransitionMorphType enum üç üyeye sahiptir:

- ByObject: Morph geçişi, şekilleri bölünemez nesneler olarak ele alarak gerçekleştirilir.
- ByWord: Morph geçişi, mümkün olduğunda metni kelimeler halinde aktararak gerçekleştirilir.
- ByChar: Morph geçişi, mümkün olduğunda metni karakterler halinde aktararak gerçekleştirilir.

Aşağıdaki kod parçacığı, slayta morph geçişi ayarlamayı ve morph türünü değiştirmeyi gösterir:

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
Aspose.Slides for Java, siyahdan, soldan, sağdan vb. geçiş efektlerini ayarlamayı destekler. Geçiş Efektini ayarlamak için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Slaytın referansını alın.
- Geçiş efektini ayarlayın.
- Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak yazın.

Aşağıdaki örnekte geçiş efektlerini ayarladık.

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

Evet. Geçişin [speed](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) ayarını [TransitionSpeed](https://reference.aspose.com/slides/tr/java/com.aspose.slides/transitionspeed/) ayarını kullanarak belirleyin (örnek: yavaş/orta/hızlı).

### Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?

Evet. Geçiş için bir ses gömebilir ve ses modu ve döngü gibi ayarlarla davranışı kontrol edebilirsiniz (örnek: [setSound](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), ayrıca [setSoundIsBuiltIn](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) ve [setSoundName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-) gibi meta veriler).

### Aynı geçişi her slayta uygulamanın en hızlı yolu nedir?

İstenen geçiş türünü her slaytın geçiş ayarları içinde yapılandırın; geçişler slayt başına depolandığı için aynı türü tüm slaytlara uygulamak tutarlı bir sonuç verir.

### Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol edebilirim?

Slaytın [transition settings](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseslide/#getSlideShowTransition--) öğesini inceleyin ve [transition type](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideshowtransition/#setType-int-) değerini okuyun; bu değer hangi etkinin uygulandığını tam olarak gösterir.