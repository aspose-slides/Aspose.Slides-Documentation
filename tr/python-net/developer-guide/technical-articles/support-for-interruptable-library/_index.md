---
title: Python'da Uzun Süreli Sunum İşlemlerini Kesintiye Uğratma
linktitle: Sunum İşlemlerini Kesintiye Uğrat
type: docs
weight: 150
url: /tr/python-net/support-for-interruptable-library/
keywords:
- kesintiye uğrayabilen işlemler
- kesinti belirteci
- PDF dışa aktarımını iptal et
- PowerPoint
- Python
- Aspose.Slides
description: "Python'da bir sunum dönüşümünü nasıl iptal edeceğinizi ve iptal öncesinde dışa aktarımı tamamlanan slaytların listesini nasıl döndüreceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, sunumları yükleme, kaydetme ve işleme gibi uzun süren işlemler sırasında işbirlikçi iptalı destekler. Slaytları tek tek dışa aktarırken, slaytlar arasında iptal durumunu kontrol edebilir ve dışa aktarması tamamlanan slaytların sayılarını döndürebilirsiniz.

## **Sunum Dönüştürmeyi İptal Etme**

Bir [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/) oluşturun, onun [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/)ını [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/) özelliğine atayın ve seçenekleri [Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/) ile geçirin. Token, sunumun yaşam süresi boyunca geçerlidir. Uygulamanızdan iptal talep etmek için [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/) yöntemini çağırın.

Örnek, `sample.pptx` dosyasını `sample.pdf` dosyasına dönüştürür. Bir [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) 20 saniye sonra `source.interrupt` çağrısını yapar. Zamanlayıcıyı dosyayı açmadan önce başlatmak, zaman aşımının hem yükleme hem de kaydetme işlemlerine uygulanmasını sağlar. İptal düğmesi bulunan bir uygulama, aynı yöntemi olay işleyicisinden çağırabilir.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

Yüklemeden sonra yapılan açık kontrol, zaman aşımı zaten geçmişse dışa aktarmayı atlar. Yükleme veya kaydetme isteği görürse, iptal istisnası çağırana ulaşır. Kaydetme, isteği görmeden önce tamamlanırsa PDF eksiksiz olur.

## **Sonraki Slaytı İşlemeye Başlamadan Durma**

Her dışa aktarmadan önce [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) özelliğini kontrol edin. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 1’den başlayarak slayt numaralarının bir listesini kabul eder. PDF başarıyla kaydedildikten sonra numarayı tamamlananlar listesine ekleyin.

En az iki slaytı olan bir `sample.pptx` dosyası kullanın. Sonucun yeniden üretilebilir olması için örnek, slayt 1 tamamlandığında iptal talebinde bulunur. Bir uygulamada, talep başka bir iş parçacığından, bir slayt kaydedilirken gelebilir.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

Örnek, `slide-1.pdf` yazar ve `Starting slide 1` ardından `Completed: [1]` yazdırır. Sonraki döngü, slayt 2’ye başlamadan önce isteği görür. İptal bir kaydetmeyi keserse, istisna işleyicisi önceki döngülerde kaydedilen sayıları döndürür. Diğer dışa aktarma hataları çağırana ulaşır.

Çağıranın iptali bir istisna olarak ele alması gerekiyorsa, döngünün üst kısmındaki kontrolü ve `break` ifadesini [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/) ile değiştirin. Ayrıca kaydetme etrafındaki `try`/`except` blokunu kaldırın. Aynı girişte, slayt 1 kaydedilir ve ikinci döngü, slayt 2’ye başlamadan önce bir iptal istisnası yükseltir.

## **SSS**

**Bir iptal talebi ne zaman etkili olur?**

Kesilebilir bir işlem, tokenını periyodik olarak kontrol eder. İsteği gördüğünde durur. Zaten tamamlanmış bir işlem sonucunu tutar.

**Kaynak ile token arasındaki fark nedir?**

Kaynak, uygulamanızın iptal talep etmesini sağlar. Token ise hem sunumun hem de kendi kodunuzun bu talebi kontrol etmesine imkân tanır.

**Birden fazla işlem aynı kaynağı paylaşabilir mi?**

Evet. `interrupt` çağrısı, o kaynaktan alınan tokenı kullanan tüm işlemler için iptal talep eder. İşlemleri bağımsız olarak iptal edebilmek istiyorsanız, her işleme kendi kaynağını verin.