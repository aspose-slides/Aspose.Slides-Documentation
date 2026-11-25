---
title: Python'da Uzun Süreli Sunum İşlemlerini Kesintiye Uğratma
linktitle: Sunum İşlemlerini Kesintiye Uğratma
type: docs
weight: 120
url: /tr/python-java/support-for-interruptable-library/
keywords:
- kesintiye uğrayabilir işlemler
- kesinti belirteci
- iptal belirteci
- uzun süren görev
- görevi kesintiye uğrat
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'da uzun süren sunum işlemlerini nasıl iptal edeceğinizi ve slaytları bir döngü içinde dışa aktarırken kısmi bir sonuç nasıl döndüreceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, uzun süren işlemleri (yükleme, kaydetme ve sunumları render etme gibi) kesintiye uğratabilir. Uygulamanız aynı kesinti belirtecini bir döngüyü, bir sonraki slaytı işlemeye başlamadan durdurmak için kullanabilir.

## **Bir Sunum İşlemini Kesintiye Uğratma**

Bir [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) oluşturun, token'ını [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken) ile alın ve token'ı [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken) ile geçirin. Yükleme seçeneklerini [Presentation yapıcı](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) içine aktarın. İptal talep etmek için kaynağın [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) metodunu çağırın. Kesintiye uğrayabilir bir işlem, isteği gördüğünde durur. Python’da Java istisnası `com.aspose.slides.exceptions.OperationCanceledException` yakalamak için `jpype.JClass` kullanın.

Örnek, `sample.pptx` dosyasını arka plan iş parçacığında `sample.ppt` biçimine dönüştürür. Çağıran iş parçacığı dönüşümün tamamlanması için en fazla 10 saniye bekler. Dönüşüm hâlâ çalışıyorsa, iptal talep eder ve çalışan iş parçacığının çıkmasını bekler.

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **Aspose.Slides'a Bir Python Zaman Aşımını Bağlama**

Bir sunum işlemi için zaman sınırı belirlemek amacıyla, zaman aşımı süresi dolduğunda [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) metodunu çağıran bir [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) kullanın. Örnek, `sample.pptx` dosyasını yüklemek ve `sample.pdf` olarak dışa aktarmak için 20 saniye tanır. Dışa aktarma erken tamamlanırsa, uygulama planlanan isteği iptal eder.

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **Sonraki Slaytı İşlemeye Başlamadan Durdurma**

Sunum ve slaytlarını dışa aktaran döngü için aynı [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) kullanın. Her dışa aktarmadan önce [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) kontrol edin. Eğer çağıran kısmi bir sonuç kullanabiliyorsa, başarılı bir şekilde tamamlanan dışa aktarmaların slayt numaralarını döndürün.

En az iki slaytı olan `sample.pptx` adlı bir sunum kullanın. Java `int[]` alan [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) aşırı yüklemesi, slayt numaralarını 1’den başlatarak kullanır. Bu diziyi Python’da oluşturmak için `jpype.JArray(jpype.JInt)` kullanın. Örnek, her slaytı ayrı bir PDF’ye kaydeder ve ilk başarılı dışa aktarımı kaydettikten hemen sonra iptal talep eder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

Örnek, `slide-1.pdf` yazar ve `Starting slide 1` ardından `Completed: [1]` çıktısını verir. Döngü, slayt 2’ye başlamadan önce iptal isteğini görür. Kaydetme sırasında iptal gelirse, döngü slaytı tamamlanmış olarak kaydetmeden çıkar.

Eğer çağıranın iptali işlemesi gerekiyorsa, döngünün üst kısmındaki kontrol ve `break` ifadesini `token.throwIfInterruptionRequested()` ile değiştirin. Kaydetme etrafındaki `try`/`except` bloğunu kaldırın, böylece dışa aktarma sırasında oluşan iptal de çağırana ulaşır. Aynı girişle örnek yalnızca `Starting slide 1` yazdırır ve `slide-1.pdf` oluşturur. İkinci yinelemenin başında, [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) yöntemi, bir sonraki dışa aktarım başlamadan önce `com.aspose.slides.exceptions.OperationCanceledException` hatasını fırlatır. İstisna, fonksiyonun listeyi döndürmesinden önce çağırana yayılır.

## **SSS**

**İptali ne zaman talep etmeliyim?**

İşlem zaman sınırınızı aştığında veya uygulamanız sonucu artık ihtiyaç duymadığında iptal talep edin.

**[InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) ve [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) arasındaki fark nedir?**

Kaynak, uygulamanızın iptal talep etmesini sağlar. Token ise Aspose.Slides ve uygulamanızın bu talebi kontrol etmesine izin verir.

**Bir Python zamanlayıcısından bir işlemi iptal edebilir miyim?**

Evet. Sunumla ilişkili kaynağa [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) çağrısı zamanlayıcıyla planlayabilirsiniz.

**Hangi işlemleri kesintiye uğratabilirim?**

Yükleme, kaydetme ve render etme işlemlerini kesintiye uğratabilirsiniz. Token’ı [Presentation yapıcı](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) üzerinden [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken) ile geçirin. Sunum, PDF’ye kaydetme gibi sonraki işlemler sırasında iptali gözlemleyebilir.

**İşlem hemen durur mu?**

İptal iş birliğine dayalıdır. İşlem token’ı periyodik olarak kontrol eder ve isteği gördüğünde durur.

**[InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) metodunu bir işlem bittikten sonra çağırırsam ne olur?**

Tamamlanan işlem sonucunu korur.

**Birden fazla işlem aynı [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) kullanabilir mi?**

Evet. [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) çağrısı, o kaynağın token’ını kullanan tüm işlemler için iptal talep eder. Bağımsız olarak iptal etmek istediğiniz her işlem için ayrı bir kaynak kullanın.