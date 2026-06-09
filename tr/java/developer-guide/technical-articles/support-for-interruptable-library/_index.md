---
title: Interruptable Kütüphane Desteği
type: docs
weight: 120
url: /tr/java/support-for-interruptable-library/
keywords:
- interruptable kütüphane
- kesinti belirteci
- iptal belirteci
- uzun süren görev
- görevi kes
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile uzun süren görevleri iptal edilebilir hale getirin. PowerPoint ve OpenDocument için render ve dönüşümleri güvenli bir şekilde kesintiye uğratın, örneklerle."
---
## **Genel Bakış**

Aspose.Slides, serileştirme, seriden çıkarma ve render gibi uzun süren sunum görevleri için kesilebilir bir işleme mekanizması sağlar. Bu mekanizma `InterruptionToken` ve `InterruptionTokenSource` sınıflarına dayanır.

`InterruptionToken`, `LoadOptions` nesnesine atanabilir ve `Presentation` yapıcısına geçirilebilir. `InterruptionTokenSource.interrupt()` çağrıldığında, ilgili uzun süren görev kesilir.

## **Kesilebilir Kütüphane**

[Aspose.Slides 18.4](https://releases.aspose.com/slides/tr/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/) sürümünde, [InterruptionToken](https://reference.aspose.com/slides/tr/java/com.aspose.slides/interruptiontoken/) ve [InterruptionTokenSource](https://reference.aspose.com/slides/tr/java/com.aspose.slides/interruptiontokensource/) sınıflarını tanıttık. Bu sınıflar, seriden çıkarma, serileştirme ve render gibi uzun süren görevleri kesmenize olanak tanır.

- [InterruptionTokenSource](https://reference.aspose.com/slides/tr/java/com.aspose.slides/interruptiontokensource/) , [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) yöntemine geçirilen belirteç(ler)in kaynağıdır.
- [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) ayarlandığında ve [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) örneği [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) yapıcısına geçirildiğinde, [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/interruptiontokensource/#interrupt--) çağrısı, o [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) ile ilişkili herhangi bir uzun süren görevi keser.

Aşağıdaki kod parçacığı, çalışan bir görevin nasıl kesileceğini gösterir:

```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // işlemi ayrı bir iş parçacığında çalıştır
Thread.sleep(10000);     // zaman aşımı
tokenSource.interrupt(); // dönüşüm durdur
```

## **SSS**

**Aspose.Slides kesinti kütüphanesinin amacı nedir?**

Tamamlanmadan önce uzun süren işlemleri—sunumları yükleme, kaydetme veya render etme gibi—kesmek için bir mekanizma sağlar. İşleme süresinin sınırlı olması gerektiğinde veya göreve artık ihtiyaç duyulmadığında faydalıdır.

**[InterruptionToken](https://reference.aspose.com/slides/tr/java/com.aspose.slides/interruptiontoken/) ile [InterruptionTokenSource](https://reference.aspose.com/slides/tr/java/com.aspose.slides/interruptiontokensource/) arasındaki fark nedir?**

- `InterruptionToken`, Aspose.Slides API'sine geçirilir ve uzun süren işlemler sırasında kontrol edilir.
- `InterruptionTokenSource`, kodunuzda belirteç oluşturmak ve `Interrupt()` çağırarak kesintileri tetiklemek için kullanılır.

**Hangi görevler kesilebilir?**

[InterruptionToken] kabul eden herhangi bir Aspose.Slides görevi—örneğin `Presentation(path, loadOptions)` ile bir sunum yüklemek veya `Presentation.save(...)` ile kaydetmek—kesilebilir.

**Kesinti hemen gerçekleşir mi?**

Hayır. Kesinti işbirliklidir: işlem periyodik olarak belirteci kontrol eder ve [Interrupt()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/interruptiontokensource/#interrupt--) çağrıldığını fark eder etmez durur.

**Bir görev zaten tamamlandıktan sonra [Interrupt()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/interruptiontokensource/#interrupt--) çağırırsam ne olur?**

Hiçbir şey—ilgili görev zaten tamamlandıysa çağrı hiçbir etki yapmaz.

**Aynı [InterruptionTokenSource](https://reference.aspose.com/slides/tr/java/com.aspose.slides/interruptiontokensource/) öğesini birden fazla görevde yeniden kullanabilir miyim?**

Evet—ancak bu kaynağa [Interrupt()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/interruptiontokensource/#interrupt--) çağrısı yaptıktan sonra, onun belirteçlerini kullanan tüm görevler kesilir. Görevleri bağımsız yönetmek için ayrı belirteç kaynakları kullanın.