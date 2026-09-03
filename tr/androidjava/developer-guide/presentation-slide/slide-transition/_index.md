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
description: "Aspose.Slides for Android via Java ile slayt geçişlerini uygulayın, otomatik slayt ilerlemeyi yapılandırın ve Morph ve diğer geçiş efektlerini özelleştirin."
---
## **Genel Bakış**

Slayt geçişleri, bir slayt gösterisi sırasında slaytların nasıl görüneceğini kontrol eder. Aspose.Slides for Android via Java ile her slayt için bir geçiş efekti seçebilir, ilerlemeyi fare tıklaması veya zamanlayıcı ile yapılandırabilir ve bir efekti özel seçeneklere göre ayarlayabilirsiniz. Bu makale, geçişleri uygulamak, kesin geçiş sürelerini ayarlamak, slayt zamanlamasını yönetmek ve iki slayt arasında bir Morph geçişi oluşturmak için Java örnekleri kullanır. Örnekler ayrıca ayarların bir PPTX dosyasına nasıl kaydedileceğini gösterir.

## **Slayt Geçişi Ekle**

Bir geçiş uygulamak için, bir sunumu [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı ile yükleyin ve slaytın geçiş ayarlarına [getSlideShowTransition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) üzerinden erişin. [TransitionType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/transitiontype/) enumından bir değerle [setType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) kullanın, ardından sunumu kaydedin.

Aşağıdaki örnek, ilk slayta Circle geçişi ve ikinci slayta Comb geçişi uygular. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

## **Gelişmiş Slayt Geçişi Ekle**

Bir slaytın ekranda ne kadar süre kalacağını ve fare tıklamasının slayt gösterisini ilerletip ilerletmeyeceğini yapılandırabilirsiniz. Aşağıdaki yöntemler bu davranışı kontrol eder:

- [setAdvanceOnClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) izleyicinin fare tıklamasıyla ilerlemesine izin verir.
- [setAdvanceAfter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) otomatik ilerlemeyi etkinleştirir.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) otomatik ilerleme öncesindeki gecikmeyi milisaniye cinsinden belirtir.

Hem tıklama hem de zamanlı ilerlemeyi etkinleştirerek izleyicinin bir tıklama ile devam etmesini veya zamanlayıcıyı beklemesini sağlayın. Yalnızca zamanlayıcıyı kullanmak için [setAdvanceOnClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) metoduna `false` geçin. Gecikme, slayt gösterisinin ne zaman ilerleyeceğini kontrol eder; görsel geçiş efektinin süresini ayarlamaz.

Bu örnek, ilk üç slayta farklı efektler atar ve sırasıyla 3, 5 ve 7 saniye sonra otomatik ilerlemeyi etkinleştirir. Fare tıklamaları da bu slaytları ilerletebilir. En az üç slaytı olan bir `input.pptx` dosyası kullanın.

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

Zamanlı ilerlemenin etkin olup olmadığını kontrol etmek için [getAdvanceAfter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) metodunu çağırın. Saklanan bir gecikme yalnızca zamanlayıcının aktif olduğunu göstermez.

Sonraki örnek, yukarıda kaydedilen dosyayı açar, etkin her zamanlayıcıyı raporlar ve iki saniyeden uzun bir gecikmeye sahip slaytlar için otomatik ilerlemeyi devre dışı bırakır. Bu slaytlar için fare tıklamasını etkinleştirir ve güncellenen ayarları kaydeder.

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

## **Geçiş Zamanlamasını Kesinlikle Kontrol Et**

Geçiş efektinin kesin uzunluğunu milisaniye cinsinden belirtmek için [setDuration](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) metodunu kullanın. Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) yöntemi bu ayarları [ISlideShowTransition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/) aracılığıyla ortaya çıkarır:

| Yöntem | Açıklama |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Geçiş efektinin kendisinin süresini milisaniye cinsinden ayarlar. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Slaytın otomatik olarak ilerlemesi öncesindeki gecikmeyi milisaniye cinsinden ayarlar. Bu zamanlayıcıyı etkinleştirmek için [setAdvanceAfter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) metoduna `true` geçirin. |
| [setSpeed](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | [TransitionSpeed](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/transitionspeed/) (Slow, Medium, Fast) içinden önceden tanımlı bir hız kategorisi seçer. Kesin bir süre belirtilmediğinde kullanılır. |

[setDuration] yalnızca geçiş efektini kontrol eder; slaytın görünür kalma süresini belirlemez. Otomatik ilerleme gecikmesini ayrı olarak yapılandırın. Açık bir süre ayarlanmamışsa, Aspose.Slides geçiş türü ve [getSpeed](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) değerine göre efekt süresini belirler.

### **Her Slayta Aynı Süreyi Uygula**

Tutarlı bir tempo için aynı efekti ve kesin süreyi her slayta uygulayın. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/transitiontype/) üzerinden Fade seçer ve her geçişe 750 milisaniye süre verir. Ayrıca otomatik ilerlemeyi 5 000 milisaniye sonra etkinleştirir ve fare tıklamasını devre dışı bırakır, ardından sonucu PPTX olarak kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Efekt süresinden bağımsız olarak otomatik ilerlemeyi yapılandır.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bireysel Slaytlar İçin Farklı Süreler Ayarla**

Farklı slaytlar farklı efekt süreleri kullanabilir. Örneğin, başlık slaytı için kısa bir geçiş, bölüm giriş slaytı için daha uzun bir geçiş kullanın. Bu örnek ilk slayta 500 milisaniye, ikinciye 1 200 milisaniye ayarlar. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

### **Geçişleri Animasyonlu Çıktı ile Koordine Et**

[animated GIF](/slides/tr/androidjava/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/tr/androidjava/export-to-html5/) veya [video](/slides/tr/androidjava/convert-powerpoint-to-video/) hazırlarken, istenen tempoya uygun olması için dışa aktarmadan önce kesin geçiş sürelerini ayarlayın. Örneğin sahneler arasında 600 milisaniyelik bir solma kullanın ve her slaydın ilerleme gecikmesini ayrı ayrı ayarlayarak anlatım veya içerik süresine yer verin.

GIF ve video için, çıktı kare hızını efekt süresiyle eşleştirin: 600 milisaniye, 30 fps’de 18 kareye eşittir. HTML5’te, dışa aktarma ayarlarında animasyonlu geçişleri etkinleştirin. Seçilen dışa aktarma formatının desteklediği efekt ve zamanlama seçeneklerini kontrol edin ve senkronizasyonu doğrulamak için çıktıyı önizleyin.

### **Mevcut Bir Geçiş Süresini Oku**

Geçişi değiştirmeden önce açık bir değerin saklanıp saklanmadığını belirlemek için [getDuration](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) metodunu çağırın. `-1` değeri, açık bir sürenin ayarlanmadığını gösterir; negatif olmayan bir değer, milisaniye cinsinden saklanan süreyi belirtir. Ayarlanmamış değer, hesaplanan oynatma süresi değildir; Aspose.Slides geçiş türü ve [getSpeed](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) değerini kullanarak bu süreyi belirler. Bir geçiş türü ayarlamak bir süreyi başlatabilir, bu yüzden önce orijinal ayarları inceleyin.

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

Morph geçişi, ardışık slaytlar arasındaki nesnelerin değişimini animasyonlaştırır. Basit bir Morph etkisi oluşturmak için bir slaytı klonlayın, klon üzerindeki bir nesneyi taşıyın veya yeniden boyutlandırın ve Morph geçişini ikinci slayta uygulayın. Bu, geçişin ilgili nesneleri özgün ve değiştirilmiş halleri arasında animasyonlandırmasını sağlar.

Aşağıdaki örnek, bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı klonlar ve klon üzerindeki dikdörtgenin konum ve boyutunu değiştirir. Ardından ikinci slayt için [TransitionType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/transitiontype/) enumundan Morph seçilir. Morph’u destekleyen bir sunum görüntüleyicide kaydedilen dosyayı açarak slayt gösterisi sırasında efekti görün.

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

## **Morph Geçiş Türleri**

[TransitionMorphType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/transitionmorphtype/) enumı, Morph’un içeriği nasıl eşleştirdiğini ve animasyonlaştırdığını kontrol eder:

- [ByObject](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) her şekli bütün bir nesne olarak ele alır.
- [ByWord](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) metni mümkün olduğunda kelimelere göre eşleştirerek animasyon yapar.
- [ByChar](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) metni mümkün olduğunda karakterlere göre eşleştirerek animasyon yapar.

Morph’u seçmek için [setType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) metodunu kullanın, ardından [getValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#getValue--) ile değeri alın. Bu değer, [IMorphTransition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imorphtransition/) arayüzünü sunar; bu arayüzün [setMorphType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) metodu eşleştirme modunu seçer.

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

Bazı geçişler ek yön veya efektin siyah bir ekrandan başlaması gibi ekstra seçenekler sunar. Kullanılabilir seçenekler, [setType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) ile seçilen geçişe bağlıdır. Önce türü ayarlayın, ardından [getValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#getValue--) üzerinden uygun arayüzü kullanın.

Aşağıdaki örnek, `input.pptx` dosyasının ilk slaytına Cut geçişi uygular. Geçişin siyah bir ekrandan başlaması için [IOptionalBlackTransition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioptionalblacktransition/) aracılığıyla [setFromBlack](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) metodunu çağırır.

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

Evet. Milisaniye cinsinden kesin bir efekt süresi gerektiğinde [setDuration](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) tercih edin. Önceden tanımlı bir [TransitionSpeed](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/transitionspeed/) kategorisi (Slow, Medium, Fast) yeterli olduğunda ve açık bir süre ayarlanmamışsa [setSpeed](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) kullanın. Bu ayarlar, otomatik ilerleme gecikmesinden bağımsız olarak geçiş efektini kontrol eder.

**Bir geçişe ses ekleyebilir ve döngüye alabilir miyim?**

Evet. [setSound](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) ile gömülü ses atayın, [TransitionSoundMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/transitionsoundmode/) enumından StartSound değerini [setSoundMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-) metoduna geçirin ve [setSoundLoop](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) metodunu `true` yaparak sesi döngüye alın. Ses, slayt gösterisindeki bir sonraki ses olayı gerçekleşene kadar döngüde kalır.

**Her slayta aynı geçişi uygulamanın en hızlı yolu nedir?**

Sunumun [getSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSlides--) koleksiyonunu döngüyle gezerek her slaytın geçişi için aynı değeri [setType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) metoduna aktarın. Zamanlama ve efekt seçeneklerini aynı döngü içinde ayarlayarak davranışı tüm slaytlar arasında tutarlı tutun.

**Bir slaytta şu anda hangi geçişin ayarlandığını nasıl kontrol edebilirim?**

Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) sonucunda [getType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islideshowtransition/#getType--) metodunu çağırın. Bu, [TransitionType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/transitiontype/) enumından bir değer döndürür; None değeri, hiçbir geçiş efektinin uygulanmadığını gösterir.