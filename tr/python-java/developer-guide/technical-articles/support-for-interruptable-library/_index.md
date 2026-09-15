---
title: Kesintiye Ulaşılabilir Kütüphane Desteği
type: docs
weight: 120
url: /tr/python-java/support-for-interruptable-library/
keywords:
- kesintiye ulaşılabilir kütüphane
- kesinti belirteci
- iptal belirteci
- uzun süren görev
- görevi kes
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile uzun süren görevleri iptal edilebilir hâle getirin. PowerPoint ve OpenDocument için renderleme ve dönüşümleri güvenli bir şekilde, örneklerle kesintiye uğratın."
---
## **Genel Bakış**

Aspose.Slides, serileştirme, serileştirme ve renderleme gibi uzun süren sunum görevleri için kesintiye izin veren bir işleme mekanizması sağlar. Bu mekanizma, [InterruptionToken](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontoken/) ve [InterruptionTokenSource](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontokensource/) sınıflarına dayanır.

Bir [InterruptionToken](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontoken/) [LoadOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/) nesnesine atanabilir ve [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) yapıcısına geçirilebilir. [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontokensource/#interrupt) çağrıldığında, ilişkili uzun süren görev kesintiye uğrar.

## **Kesintiye Ulaşılabilir Kütüphane**

Aspose.Slides for Python via Java, [InterruptionToken](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontoken/) ve [InterruptionTokenSource](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontokensource/) sınıflarını sağlar. Bunlar, serileştirme, serileştirme ve renderleme gibi uzun süren görevleri kesmenize olanak tanır.

- [InterruptionTokenSource](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontokensource/) [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setInterruptionToken) yöntemiyle geçirilen token(ler)in kaynağıdır.
- [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setInterruptionToken) çağrıldığında ve [LoadOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/) örneği [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) yapıcısına geçirildiğinde, [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontokensource/#interrupt) yürütülmesi, o [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) ile ilişkili herhangi bir uzun süren görevi kesintiye uğratır.

Aşağıdaki kod parçacığı çalışan bir görevi kesintiye uğratmayı gösterir:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # Eylemi ayrı bir iş parçacığında çalıştır.
    time.sleep(10)  # Zaman aşımı.
    token_source.interrupt()  # Dönüştürmeyi durdur.
    conversion_task.result()
```

## **SSS**

**Aspose.Slides kesinti kütüphanesinin amacı nedir?**

Uzun süren işlemleri—sunumları yükleme, kaydetme veya renderleme gibi—tamamlanmadan önce kesintiye uğratmak için bir mekanizma sağlar. İşlem süresi sınırlı olduğunda ya da göreve artık ihtiyaç duyulmadığında yararlıdır.

**[InterruptionToken](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontoken/) ve [InterruptionTokenSource](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontokensource/) arasındaki fark nedir?**

- [InterruptionToken](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontoken/) Aspose.Slides API'sine geçirilir ve uzun süren işlemler sırasında kontrol edilir.
- [InterruptionTokenSource](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontokensource/) kodunuzda tokenlar oluşturmak ve [interrupt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontokensource/#interrupt) çağrısı yaparak kesintileri tetiklemek için kullanılır.

**Hangi görevler kesintiye uğratılabilir?**

Bir [InterruptionToken](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontoken/) kabul eden herhangi bir Aspose.Slides görevi—örneğin [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) ile bir sunumu yüklemek ya da [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) ile kaydetmek—kesintiye uğratılabilir.

**Kesinti hemen gerçekleşir mi?**

Hayır. Kesinti iş birliğine dayalıdır: işlem periyodik olarak tokenı kontrol eder ve [interrupt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontokensource/#interrupt) çağrıldığını fark eder etmez durur.

**Bir görev zaten tamamlandıktan sonra [interrupt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontokensource/#interrupt) çağrısı yaparsam ne olur?**

Hiçbir şey—ilgili görev zaten tamamlandıysa çağrı hiçbir etki yapmaz.

**Aynı [InterruptionTokenSource](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontokensource/) birden fazla görev için yeniden kullanılabilir mi?**

Evet—ancak o kaynakta [interrupt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/interruptiontokensource/#interrupt) çağrıldıktan sonra, tokenlarını kullanan tüm görevler kesintiye uğrar. Görevleri bağımsız yönetmek için ayrı token kaynakları kullanın.