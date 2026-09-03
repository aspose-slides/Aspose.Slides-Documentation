---
title: Java ile Sunumlarda Slayt Geçişlerini Yönetme
linktitle: Slayt Geişi
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
description: "Aspose.Slides for Java ile slayt geçişlerini uygulayın, otomatik slayt ilerlemesini yapılandırın ve Morph ve diğer geçiş efektlerini özelleştirin."
---
## **Genel Bakış**

Slayt geçişleri, bir slayt gösterisi sırasında slaytların nasıl görüneceğini kontrol eder. Aspose.Slides for Java ile her slayt için bir geçiş efekti seçebilir, geçişi fare tıklamasıyla veya zamanlayıcıyla ilerletmeyi yapılandırabilir ve bir efekle özgü seçenekleri ayarlayabilirsiniz. Bu makale, geçişleri uygulamak, kesin geçiş sürelerini ayarlamak, slayt zamanlamasını yönetmek ve iki slayt arasına bir Morph geçişi oluşturmak için Java örnekleri kullanır. Örnekler ayrıca ayarların bir PPTX dosyasına nasıl kaydedileceğini gösterir.

## **Slayt Geçişi Ekle**

Bir geçiş uygulamak için, sunumu [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı ile yükleyin ve slaytın geçiş ayarlarına [getSlideShowTransition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) üzerinden erişin. [TransitionType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/transitiontype/) enum'undan bir değerle [setType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setType-int-) kullanın ve ardından sunumu kaydedin.

Aşağıdaki örnek, birinci slayta Circle geçişi ve ikinci slayta Comb geçişi uygular. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

Bir slayt ekranında ne kadar süre kalacağını ve fare tıklamasıyla slayt gösterisinin ilerleyip ilerlemeyeceğini yapılandırabilirsiniz. Aşağıdaki yöntemler bu davranışı kontrol eder:

- [setAdvanceOnClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) izleyicinin fare tıklamasıyla ilerlemesini sağlar.
- [setAdvanceAfter](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) otomatik ilerlemeyi etkinleştirir.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) otomatik ilerleme öncesi gecikmeyi milisaniye cinsinden belirler.

Hem tıklama hem de zamanlı ilerlemeyi etkinleştirerek izleyicinin tıklama ile devam etmesine veya zamanlayıcıyı beklemesine izin verin. Yalnızca zamanlayıcıyı kullanmak için [setAdvanceOnClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) yöntemine `false` gönderin. Gecikme, slayt gösterisinin ne zaman ilerleyeceğini kontrol eder; görsel geçiş efektinin süresini ayarlamaz.

Bu örnek, ilk üç slayta farklı efektler atar ve sırasıyla 3, 5 ve 7 saniye sonra otomatik ilerlemeyi etkinleştirir. Bu slaytlar fare tıklamasıyla da ilerleyebilir. En az üç slaytı olan bir `input.pptx` dosyası kullanın.

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

Zamanlı ilerlemenin etkin olup olmadığını kontrol etmek için [getAdvanceAfter](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) yöntemini çağırın. Depolanan gecikme yalnızca zamanlayıcının aktif olduğunu göstermez.

Aşağıdaki örnek, önceki bölümde kaydedilen dosyayı açar, etkin her zamanlayıcıyı raporlar ve iki saniyeden uzun bir gecikmeye sahip slaytlar için otomatik ilerlemeyi devre dışı bırakır. Bu slaytlar için fare tıklamasını etkinleştirir ve güncellenmiş ayarları kaydeder.

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

## **Geçiş Zamanını Kesin Bir Şekilde Kontrol Et**

Geçiş efektinin tam uzunluğunu milisaniye cinsinden belirtmek için [setDuration](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setDuration-int-) yöntemini kullanın. Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) yöntemi bu ayarları [ISlideShowTransition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/) üzerinden sunar:

| Yöntem | Amaç |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Geçiş efektinin kendisinin süresini milisaniye cinsinden ayarlar. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Slaytın otomatik olarak ilerlemesinden önceki gecikmeyi milisaniye cinsinden ayarlar. Bu zamanlayıcıyı etkinleştirmek için [setAdvanceAfter](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) yöntemine `true` gönderin. |
| [setSpeed](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | [TransitionSpeed](https://reference.aspose.com/slides/tr/java/com.aspose.slides/transitionspeed/) enum'undan (Slow, Medium veya Fast) önceden tanımlı bir hız kategorisi seçer. Kesin bir süre belirtilmediğinde kullanılır. |

[setDuration](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setDuration-int-) yalnızca geçiş efektini kontrol eder; slaytın ne kadar süre ekranda kalacağını belirlemez. Otomatik ilerleme gecikmesini ayrı olarak yapılandırın. Açık bir süre ayarlanmamışsa, Aspose.Slides geçiş tipine ve [getSpeed](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#getSpeed--) değerine göre efekt süresini belirler.

### **Her Slayta Aynı Süreyi Uygula**

Tutarlı bir tempo için aynı efekti ve kesin süresi her slayta uygulayın. Bu örnek `input.pptx` dosyasını yükler, [TransitionType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/transitiontype/) listesinden Fade seçer ve her geçişe 750 milisaniye süre verir. Aynı zamanda otomatik ilerlemeyi 5.000 milisaniye sonra etkinleştirir, fare tıklamasıyla ilerlemeyi devre dışı bırakır ve sonucu PPTX olarak kaydeder.

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

Farklı slaytlar farklı efekt süreleri kullanabilir. Örneğin, başlık slaytı için kısa bir geçiş, bölüm giriş slaytı için daha uzun bir geçiş tercih edebilirsiniz. Bu örnek birinci slayta 500 milisaniye, ikinci slayta 1.200 milisaniye süre ayarlar. En az iki slaytı olan bir `input.pptx` dosyası kullanın.

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

### **Geçişleri Animasyonlu Çıktıyla Koordine Et**

Bir [animated GIF](/slides/tr/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/tr/java/export-to-html5/) veya [video](/slides/tr/java/convert-powerpoint-to-video/) hazırlanırken, hedeflenen tempoya uygun olması için dışa aktarmadan önce kesin geçiş süreleri ayarlayın. Örneğin, sahneler arasında 600 milisaniyelik bir solma (fade) kullanın ve her slaytın anlatımına veya içeriğine zaman tanımak için ilerleme gecikmesini ayrı ayrı ayarlayın.

GIF ve video için, çıkış kare hızıyla efekt süresini eşleştirin: 600 milisaniye, 30 fps'de 18 kareye eşittir. HTML5'te, dışa aktarım ayarlarında animasyonlu geçişleri etkinleştirin. Seçilen dışa aktarım formatının desteklediği efektleri ve zamanlama seçeneklerini kontrol edin ve senkronizasyonu doğrulamak için ön izleme yapın.

### **Mevcut Bir Geçiş Süresini Oku**

Geçişi değiştirmeden önce mevcut bir değer depolanmış mı öğrenmek için [getDuration](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#getDuration--) yöntemini çağırın. `-1` değeri, açık bir sürenin ayarlanmadığını; negatif olmayan bir değer ise milisaniye cinsinden depolanmış süreyi gösterir. Ayarlanmamış değer, hesaplanan oynatma süresi değildir: Aspose.Slides geçiş tipine ve [getSpeed](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#getSpeed--) değerine göre bu süreyi belirler. Bir geçiş tipi ayarlamak bir süreyi başlatabilir, bu yüzden önce orijinal ayarları inceleyin.

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

Morph geçişi, ardışık slaytlar üzerindeki nesneler arasındaki değişiklikleri canlandırır. Basit bir Morph etkisi oluşturmak için bir slaytı klonlayın, klon üzerindeki bir nesneyi taşıyın veya yeniden boyutlandırın ve ikinci slayta Morph geçişi uygulayın. Bu, orijinal ve değiştirilmiş durumları arasında animasyon yapılacak nesneleri eşleştirir.

Aşağıdaki örnek bir metin dikdörtgeni içeren bir slayt oluşturur, slaytı klonlar ve klon üzerindeki dikdörtgenin konum ve boyutunu değiştirir. Ardından ikinci slayt için [TransitionType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/transitiontype/) enum'undan Morph seçer. Morph'u destekleyen bir sunum görüntüleyicide kaydedilen dosyayı açarak etkinliği görebilirsiniz.

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

## **Morph Geçişi Türleri**

[TransitionMorphType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/transitionmorphtype/) enum'ı, Morph'un içeriği nasıl eşleştirip canlandıracağını kontrol eder:

- [ByObject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/transitionmorphtype/#ByObject) her şekli bütün bir nesne olarak ele alır.
- [ByWord](https://reference.aspose.com/slides/tr/java/com.aspose.slides/transitionmorphtype/#ByWord) mümkün olduğunda kelimeleri eşleştirerek metni canlandırır.
- [ByChar](https://reference.aspose.com/slides/tr/java/com.aspose.slides/transitionmorphtype/#ByChar) mümkün olduğunda karakterleri eşleştirerek metni canlandırır.

Morph'u seçmek için [setType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setType-int-) yöntemini kullanın, ardından [getValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#getValue--) ile [IMorphTransition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imorphtransition/) arayüzünü alın ve bu arayüzün [setMorphType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imorphtransition/#setMorphType-int-) yöntemini çağırarak eşleştirme modunu seçin.

Bu örnek, önceki bölümde oluşturulan sunumu açar ve ikinci slaytı kelime bazlı Morph animasyonu kullanacak şekilde yapılandırır.

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

Bazı geçişler ek yön seçenekleri sunar; örneğin yön veya efektin siyah bir ekrandan başlaması gibi. Kullanılabilir seçenekler, [setType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setType-int-) ile seçilen geçişe bağlıdır. Önce geçiş tipini ayarlayın, ardından [getValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#getValue--) aracılığıyla uygun arayüzü kullanın.

Aşağıdaki örnek, `input.pptx` dosyasının ilk slaytına Cut geçişi uygular. Geçişin siyah bir ekrandan başlamasını sağlamak için [IOptionalBlackTransition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ioptionalblacktransition/) aracılığıyla [setFromBlack](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) yöntemini çağırır.

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

Evet. Milisaniye cinsinden kesin bir efekt süresi gerektiğinde [setDuration](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setDuration-int-) tercih edin. Önceden tanımlı bir [TransitionSpeed](https://reference.aspose.com/slides/tr/java/com.aspose.slides/transitionspeed/) kategorisi (Slow, Medium veya Fast) yeterli olduğunda ve açık bir süre ayarlanmamışsa [setSpeed](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) kullanın. Bu ayarlar geçiş efektini otomatik ilerleme gecikmesinden bağımsız olarak kontrol eder.

**Bir geçişe ses ekleyip döngüye alabilir miyim?**

Evet. Gömülü sesi [setSound](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) ile atayın, [TransitionSoundMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/transitionsoundmode/) enum'undan StartSound değerini [setSoundMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-) ile gönderin ve [setSoundLoop](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) yöntemine `true` aktararak sesi döngüye alın. Ses, slayt gösterisindeki bir sonraki ses olayı gerçekleşene kadar döner.

**Aynı geçişi tüm slaytlara en hızlı şekilde nasıl uygularım?**

Sunumun [getSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getSlides--) koleksiyonunda döngü oluşturun ve her slaytın geçişi için aynı değeri içeren [setType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#setType-int-) yöntemini çağırın. Zamanlama ve efekt seçeneklerini aynı döngü içinde ayarlayarak davranışın tüm slaytlarda tutarlı olmasını sağlayın.

**Bir slaytta şu anda hangi geçişin ayarlı olduğunu nasıl kontrol ederim?**

Slaytın [getSlideShowTransition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) sonucunda [getType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islideshowtransition/#getType--) metodunu çağırın. Bu, [TransitionType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/transitiontype/) enum'undan bir değer döndürür; None değeri, hiçbir geçiş efekti uygulanmadığını gösterir.