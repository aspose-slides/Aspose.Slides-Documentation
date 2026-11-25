---
title: Java'da Uzun Süreli Sunum İşlemlerini Kesintiye Uğratma
linktitle: Sunum İşlemlerini Kesintiye Uğrat
type: docs
weight: 120
url: /tr/java/support-for-interruptable-library/
keywords:
- kesintiye uğrayabilen işlemler
- kesinti belirteci
- iptal belirteci
- uzun süren görev
- görevi kesintiye uğrat
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da uzun süren sunum işlemlerini nasıl iptal edeceğinizi ve slaytları bir döngü içinde dışa aktarırken kısmi bir sonuç nasıl döndüreceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Java, uzun süren işlemleri (yükleme, kaydetme ve sunumları işleme) kesintiye uğratabilir. Uygulamanız aynı kesinti belirtecini kullanarak bir döngüyü bir sonraki slaytı işlemeye başlamadan durdurabilir.

## **Sunum İşlemini Kesintiye Uğratma**

Bir [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) oluşturun, belirtecini [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--) ile alın ve belirteci [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) metoduna aktarın. Yükleme seçeneklerini [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) metoduna geçirin. İptal talep etmek için, kaynağın [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) metodunu çağırın. Kesintiye uğrayabilen bir işlem, talebi gördüğünde durur.

Örnek, arka plan iş parçacığında `sample.pptx` dosyasını `sample.ppt` biçimine dönüştürür. Çağıran iş parçacığı, dönüşümün tamamlanmasını en fazla 10 saniye bekler. Dönüşüm hâlâ çalışıyorsa, iptal talep eder ve çalışan iş parçacığının çıkmasını bekler.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;

InterruptionTokenSource source = new InterruptionTokenSource();
Thread worker = new Thread(() -> {
    LoadOptions options = new LoadOptions();
    options.setInterruptionToken(source.getToken());
    try {
        Presentation presentation = new Presentation("sample.pptx", options);
        try {
            presentation.save("sample.ppt", SaveFormat.Ppt);
        } finally {
            presentation.dispose();
        }
    } catch (OperationCanceledException canceled) {
        System.out.println("Conversion canceled");
    }
});

worker.start();
worker.join(10000);
if (worker.isAlive()) {
    source.interrupt();
    worker.join();
}
```

## **Aspose.Slides ile Java Zaman Aşımını Bağlama**

Bir sunum işlemi için zaman sınırı belirlemek amacıyla, zaman aşımı dolduğunda [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) metodunu çağırmak için bir [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) kullanın. Örnek, `sample.pptx` dosyasını yüklemek ve `sample.pdf` olarak dışa aktarmak için 20 saniye verir. Dışa aktarım erken tamamlanırsa, uygulama zamanlanmış isteği iptal eder.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;

InterruptionTokenSource source = new InterruptionTokenSource();
LoadOptions options = new LoadOptions();
options.setInterruptionToken(source.getToken());

ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
try {
    Presentation presentation = new Presentation("sample.pptx", options);
    try {
        presentation.save("sample.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
    }
} catch (OperationCanceledException canceled) {
    System.out.println("Presentation processing was canceled");
} finally {
    timeout.cancel(false);
    timer.shutdown();
}
```

## **Bir Sonraki Slaytı İşlemeye Başlamadan Durdurma**

Sunum ve slaytlarını dışa aktaran döngü için aynı [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) kullanın. Her dışa aktarımdan önce [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) metodunu kontrol edin. Çağıran, kısmi bir sonucu kullanabiliyorsa, başarılı bir şekilde tamamlanan dışa aktarımların slayt numaralarını döndürün.

`sample.pptx` adlı ve en az iki slaytı olan bir sunum kullanın. Slayt numaraları dizisi alan [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) aşırı yüklemesi 1'den başlar. Örnek, her slaytı ayrı bir PDF dosyasına kaydeder ve ilk başarılı dışa aktarımı kaydettikten hemen sonra iptal talep eder.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;

class SlideExporter {
    List<Integer> exportSlides(String path, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        Presentation presentation = new Presentation(path, options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    presentation.save("slide-" + number + ".pdf", new int[] { number }, SaveFormat.Pdf);
                } catch (OperationCanceledException canceled) {
                    if (token.isInterruptionRequested()) {
                        break;
                    }
                    throw canceled;
                }

                completed.add(number);
                if (number == 1) {
                    source.interrupt();
                }
            }
            return completed;
        } finally {
            presentation.dispose();
        }
    }
}

InterruptionTokenSource source = new InterruptionTokenSource();
SlideExporter exporter = new SlideExporter();
List<Integer> completed = exporter.exportSlides("sample.pptx", source);
System.out.println("Completed: " + completed);
```

Örnek, `slide-1.pdf` dosyasını yazar ve `Starting slide 1` ardından `Completed: [1]` mesajını yazdırır. Döngü, slayt 2'ye başlamadan önce talebi algılar. Kaydetme sırasında iptal gelirse, döngü o slaytı tamamlanmış olarak kaydetmeden çıkar.

Çağıranın iptali ele alması gerekiyorsa, döngünün başındaki kontrol ve `break` ifadesini `token.throwIfInterruptionRequested()` ile değiştirin. Kaydetme çevresindeki `try`/`catch` bloklarını kaldırın, böylece dışa aktarım sırasında iptal de çağırana iletilir. Aynı girdiyle, örnek yalnızca `Starting slide 1` mesajını yazdırır ve `slide-1.pdf` dosyasını yazar. İkinci yinelemenin başlangıcında, [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) metodu, bir sonraki dışa aktarım başlamadan önce `com.aspose.slides.exceptions.OperationCanceledException` hatasını fırlatır. Metod hiçbir liste döndürmez.

## **SSS**

**İptali ne zaman talep etmeliyim?**

Bir işlem zaman sınırınızı aştığında ya da uygulamanız sonucun artık gerekmediği durumda iptal talep edin.

**[InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) ve [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) arasındaki fark nedir?**

Kaynak, uygulamanızın iptal talep etmesini sağlar. Belirteç ise Aspose.Slides ve uygulamanızın bu talebi kontrol etmesine izin verir.

**Bir Java zamanlayıcı ile bir işlemi iptal edebilir miyim?**

Evet. Sunumla ilişkili kaynağa [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) çağrısını zamanlayın.

**Hangi işlemleri kesintiye uğratabilirim?**

Yükleme, kaydetme ve işleme (rendering) işlemlerini kesintiye uğratabilirsiniz. Belirteci, [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) aracılığıyla [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) metoduna aktarın. Sunum, daha sonraki işlemler sırasında (ör. PDF kaydetme) iptali algılayabilir.

**Bir işlem hemen durur mu?**

İptal, iş birliğine dayalıdır. Bir işlem periyodik olarak belirteci kontrol eder ve talebi gördüğünde durur.

**Bir işlem tamamlandıktan sonra [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) çağrısı yaparsam ne olur?**

Tamamlanan işlem sonucunu korur.

**Birden fazla işlem aynı [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) paylaşabilir mi?**

Evet. [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) çağrısı, o kaynaktan alınan belirteci kullanan tüm işlemler için iptal talep eder. Bağımsız olarak iptal etmek istediğiniz her işlem için ayrı bir kaynak kullanın.