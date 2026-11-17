---
title: Java Kullanarak Sunumlarda Slayt Geçişlerini Yönetme
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
description: "Aspose.Slides for Java ile slayt geçişlerini uygulayın, otomatik slayt ilerlemesini yapılandırın ve Morph ve diğer geçiş etkilerini özelleştirin."
---
## **Genel Bakış**

Slayt geçişleri, bir slayt gösterisi sırasında slaytların nasıl göründüğünü kontrol eder. Aspose.Slides for Java ile her slayt için bir geçiş efekti seçebilir, fare tıklaması veya zamanlayıcı ile ilerlemeyi yapılandırabilir ve etkene özgü seçenekleri ayarlayabilirsiniz. Bu makale, geçişleri uygulamak, tam geçiş sürelerini ayarlamak, slayt zamanlamasını yönetmek ve iki slayt arasında bir Morph geçişi oluşturmak için Java örneklerini kullanır. Örnekler ayrıca ayarların bir PPTX dosyasına kaydedilmesini gösterir.

## **Slayt Geçişi Ekle**

Bir geçiş uygulamak için, bir sunumu [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) sınıfı ile yükleyin ve slaytın geçiş ayarlarına [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) aracılığıyla erişin. [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) yöntemini [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) enum değerlerinden biriyle kullanın, ardından sunumu kaydedin.

Aşağıdaki örnek, birinci slayta Circle geçişi ve ikinci slayta Comb geçişi uygular. En az iki slayt içeren bir `input.pptx` dosyası kullanın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Tekerlek Geçişi**

[setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) yöntemi, [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) içinde hedef slaytı ortaya çıkaran radyal sektör sayısını kontrol eder. Slaytın geçiş tipini [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) üzerinden Wheel olarak ayarlayın, ardından [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) yöntemine [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) olarak erişmeden önce [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) kullanın.

Bu örnek, iki adet aynı slayt çiftini oluşturur: siyah bir slayt ve ardından altın bir dikdörtgen içeren bir slayt. Hedef slaytlar, 1 ve 8 radye sektörü sayısıyla kullanılmaktadır; aynı hız [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) ile ayarlanmış ve [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) ile 8.000 milisaniye olarak açıkça belirlenmiştir, böylece fark gözlemlenmesi kolay olur.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    Color gold = new Color(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Çıktı sunumunu PowerPoint'te açın ve slayt gösterisini başlatın. Slayt 1'den slayt 2'ye, ardından slayt 3'ten slayt 4'e ilerleyin. PowerPoint oynatımında, doğrulanmış 1 sektör sayısı slaytı saat yönünde tek bir süpürme ile ortaya çıkar; 8 sektör sayısı ise sekiz radyal sektörle aynı anda ortaya çıkar. Hedef içeriği ve geçiş zamanlaması aynı olduğu için fark, ortaya çıkma sektörlerinin sayısıdır.

## **Gelişmiş Slayt Geçişi Ekle**

Slayt ekranında ne kadar süre kalacağını ve fare tıklamasıyla slayt gösterisinin ilerleyip ilerlemeyeceğini yapılandırabilirsiniz. Aşağıdaki yöntemler bu davranışı kontrol eder:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) izleyicinin fareyle tıklayarak ilerlemesine izin verir.
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) otomatik ilerlemeyi etkinleştirir.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) otomatik ilerleme öncesindeki gecikmeyi milisaniye cinsinden belirler.

Hem tıklama hem de zamanlanmış ilerlemeyi etkinleştirerek izleyicinin bir tıklama ile devam etmesini veya zamanlayıcıyı beklemesini sağlayın. Sadece zamanlayıcıyı kullanmak için [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) içine `false` gönderin. Gecikme, slayt gösterisinin ne zaman ilerleyeceğini kontrol eder; görsel geçiş efektinin süresini belirlemez.

Bu örnek, ilk üç slayta farklı efektler atar ve sırasıyla 3, 5 ve 7 saniye sonra otomatik ilerlemeyi etkinleştirir. Bu slaytlar fare tıklamasıyla da ilerleyebilir. En az üç slayt içeren bir `input.pptx` dosyası kullanın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Zamanlanmış ilerlemenin etkin olup olmadığını kontrol etmek için [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) metodunu çağırın. Saklanan gecikme tek başına zamanlayıcının aktif olduğunu göstermez.

Sonraki örnek, yukarıda kaydedilen dosyayı açar, her etkin zamanlayıcıyı raporlar ve iki saniyeden uzun gecikmeye sahip slaytlar için otomatik ilerlemeyi devre dışı bırakır. Bu slaytlar için fare tıklamasını etkinleştirir ve güncellenmiş ayarları kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Geçiş Zamanlamasını Kesin Bir Şekilde Kontrol Et**

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) yöntemini kullanarak bir geçiş efektinin tam uzunluğunu milisaniye cinsinden belirtebilirsiniz. Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) yöntemi bu ayarları [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/) aracılığıyla ortaya çıkarır:

| Yöntem | Amaç |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Geçiş efektinin kendisinin süresini milisaniye cinsinden ayarlar. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Slaytın otomatik olarak ilerlemesinden önceki gecikmeyi milisaniye cinsinden ayarlar. Bu zamanlayıcıyı etkinleştirmek için [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) içine `true` gönderin. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) enum’undan önceden tanımlı bir hız kategorisini (Slow, Medium, Fast) seçer. Kesin bir süre belirtilmediğinde kullanılır. |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) yalnızca geçiş efektini kontrol eder; slaytın ekranda ne kadar süre kalacağını belirlemez. Otomatik ilerleme gecikmesini ayrı olarak yapılandırın. Açık bir süre ayarlanmamışsa, Aspose.Slides geçiş tipine ve [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) değerine göre efekt süresini belirler.

<!-- visual-explanation:slide-transition:start -->
[![Ayrı çubuklar 750 ms geçiş süresini ve 5.000 ms otomatik ilerleme ayarını gösterir.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Ortak örnek, her slayta 750 ms Fade geçişi verir ve ayrıca 5.000 ms’de otomatik ilerlemeyi etkinleştirir. Geçiş süresi efekti kontrol eder; ilerleme ise slayttan ne zaman çıkılacağını belirler. Bu çubuklar ölçülen bir birleşik zaman çizelgesi değil, şematik ayarlardır.*
<!-- visual-explanation:slide-transition:end -->

### **Her Slayta Aynı Süreyi Uygula**

Tutarlı bir akış için aynı efekti ve kesin süreyi her slayta uygulayın. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) üzerinden Fade seçer ve her geçişe 750 milisaniye süresi verir. Ayrıca 5.000 milisaniye sonra otomatik ilerlemeyi ayrı olarak etkinleştirir ve fare tıklamasını devre dışı bırakır, ardından sonucu PPTX olarak kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Etki süresinden bağımsız olarak otomatik ilerlemeyi yapılandır.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bireysel Slaytlar İçin Farklı Süreler Belirle**

Farklı slaytlar farklı efekt süreleri kullanabilir. Örneğin, başlık slaytı için kısa bir geçiş, bölüm giriş slaytı için daha uzun bir geçiş kullanın. Bu örnek birinci slayta 500 milisaniye, ikinci slayta 1.200 milisaniye ayarlar. En az iki slayt içeren bir `input.pptx` dosyası kullanın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Animasyonlu Çıktı ile Geçişleri Koordine Et**

[animasyonlu GIF](/slides/tr/java/convert-powerpoint-to-animated-gif/), [HTML5 sunumu](/slides/tr/java/export-to-html5/) veya [video](/slides/tr/java/convert-powerpoint-to-video/) hazırlarken, istenen akışı eşleştirmek için dışa aktarmadan önce kesin geçiş süreleri ayarlayın. Örneğin, sahneler arasında 600 milisaniyelik bir solma kullanın ve her slaytın ilerleme gecikmesini ayrı ayrı ayarlayarak anlatım veya içerik için zaman tanıyın.

GIF ve video için, çıkış kare hızını efekt süresiyle koordine edin: 600 milisaniye, saniyede 30 karede 18 kareye denk gelir. HTML5’te, dışa aktarma ayarlarında animasyonlu geçişleri etkinleştirin. Seçilen dışa aktarma formatının desteklediği efektleri ve zamanlama seçeneklerini kontrol edin ve senkronizasyonu onaylamak için çıktıyı ön izleyin.

### **Mevcut Bir Geçiş Süresini Oku**

Geçişi değiştirmeden önce [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) metodunu çağırarak açık bir değer depolanıp depolanmadığını belirleyin. `-1` değeri, açık bir sürenin ayarlanmadığını; negatif olmayan bir değer ise milisaniye cinsinden saklanan süreyi belirtir. Ayarlanmamış değer, hesaplanan oynatma süresi değildir: Aspose.Slides geçiş tipini ve [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) değerini kullanarak bu süreyi belirler. Bir geçiş tipi ayarlamak bir süreyi başlatabilir, bu yüzden önce orijinal ayarları inceleyin.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph Geçişi**

Morph geçişi, ardışık slaytlardaki nesneler arasındaki değişiklikleri canlandırır. Basit bir Morph etkisi oluşturmak için bir slaytı klonlayın, klondaki bir nesneyi taşıyın veya yeniden boyutlandırın ve ikinci slayta Morph geçişini uygulayın. Bu, geçişin ilgili nesneleri orijinal ve değiştirilmiş haller arasında canlandırmasını sağlar.

Aşağıdaki örnek, bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı klonlar ve klondaki dikdörtgenin konum ve boyutunu değiştirir. Ardından ikinci slayt için [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) enum’undan Morph seçer. Kaydedilen dosyayı Morph’u destekleyen bir sunum görüntüleyicide açın ve slayt gösterisi sırasında efekti görün.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph Geçiş Tipleri**

[TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) enum’u, Morph’un içeriği nasıl eşleştirdiğini ve canlandırdığını belirler:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) her şekli bütün bir nesne olarak ele alır.
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) mümkün olduğunda metni kelimelerle eşleştirerek canlandırır.
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) mümkün olduğunda metni karakterlerle eşleştirerek canlandırır.

Morph seçmek için [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) kullanın, ardından [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) üzerinden [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/) arabirimini alın ve onun [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) metoduyla eşleşme modunu seçin.

Bu örnek, önceki bölümde oluşturulan sunumu açar ve ikinci slaytı kelime temelli Morph animasyonu kullanacak şekilde yapılandırır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Geçiş Efektlerini Ayarla**

Bazı geçişler ek seçenekler ortaya çıkarır; örneğin yön veya etkinin siyah bir ekrandan başlaması gibi. Kullanılabilir seçenekler, [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) ile seçilen geçişe bağlıdır. Önce tipi ayarlayın, ardından [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) üzerinden uygun arabirimi kullanın.

Aşağıdaki örnek, `input.pptx` dosyasının ilk slaytına Cut geçişi uygular. [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) aracılığıyla [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) metodunu çağırır ve geçişin siyah bir ekrandan başlamasını sağlar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir slayt geçişinin oynatma hızını kontrol edebilir miyim?**

Evet. Milisaniye cinsinden kesin bir efekt süresi gerektiğinde [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) tercih edin. Önceden tanımlı bir [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) kategorisi (Slow, Medium veya Fast) yeterli olduğunda ve açık bir süre ayarlanmamışsa [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) kullanın. Bu ayarlar geçiş efektini otomatik ilerleme gecikmesinden bağımsız olarak kontrol eder.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. Gömülü sesi [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) ile atayın, [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) enum’undan StartSound değerini [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-) ile geçirin ve [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) özelliğini `true` yapın. Ses, slayt gösterisinde bir sonraki ses olayına kadar döngüye girer.

**Her slayta aynı geçişi uygulamanın en hızlı yolu nedir?**

Sunumun [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) koleksiyonunda döngü oluşturun ve her slaytın geçişi için aynı değeri kullanan [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) metodunu çağırın. Zamanlama ve efekt seçeneklerini aynı döngüde ayarlayarak davranışı tüm slaytlarda tutarlı tutun.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol edebilirim?**

Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) sonucunda [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) metodunu çağırın. Bu, [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) enum’undan bir değer döndürür; None değeri hiçbir geçiş etkisinin uygulanmadığını gösterir.