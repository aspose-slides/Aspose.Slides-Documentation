---
title: Python'da PPT'yi PPTX'e Dönüştür
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/python-java/convert-ppt-to-pptx/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPT'den PPTX'e
- PPT'yi PPTX olarak kaydet
- PPT'yi PPTX'e aktar
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides ile Python'da eski PPT dosyalarını PPTX'e dönüştürün. Tek dosya ve toplu dönüşüm, hata yönetimi ve doğruluk notları için Python örneklerini içerir."
---
## **Genel Bakış**

PPT, eski ikili PowerPoint formatı iken, PPTX daha yeni Open XML formatıdır. Aspose.Slides for Python via Java, Microsoft PowerPoint olmadan bir PPT dosyasını yükleyebilir ve PPTX olarak kaydedebilir. Bu makale, tek bir dosyayı veya bir dizindeki dosyaları nasıl dönüştüreceğinizi gösterir ve dönüşümden sonra neyin doğrulanması gerektiğini açıklar.

Her örnek, gerekirse Java sanal makinesini başlatır ve kullanım sonrası sunumu serbest bırakır. Örnek yolları kendi dosya veya dizin yollarınızla değiştirin.

## **Bir PPT Dosyasını PPTX'e Dönüştür**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfı ile yükleyin, ardından [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Pptx) ile çağırın. `finally` bloğu sunumu serbest bırakır ve kaynaklarını temizler.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Eski PPT sunumunu yükle.
presentation = Presentation("presentation.ppt")
try:
    # Sunumu PPTX formatında kaydet.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dosya uzantısı tek başına çıktı formatını seçmez; bunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Pptx) argümanı yapar. Orijinal PPT dosyasını korumanız gerekiyorsa giriş ve çıkış yollarını farklı tutun.

## **Birden Çok PPT Dosyasını Dönüştür**

Aşağıdaki örnek, bir klasördeki tüm `.ppt` dosyalarını dönüştürür. Her dosya bağımsız olarak işlenir, bu nedenle bir dönüşüm hatası diğer dosyaların işlenmesini durdurmaz.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

Üretim ortamları için, tam istisna kaydını tutun, mevcut bir çıktı dosyasının üzerine yazılıp yazılamayacağına karar verin ve başarısız dosya adlarını yeniden deneme veya inceleme kuyruğuna yazın. Bozuk dosyalar, gerekli şifre olmadan açılan şifre korumalı dosyalar, erişilemeyen yollar ve desteklenmeyen içerik dönüşümün başarısız olmasına neden olabilir. Şifreli dosyaları yüklemek için [Password-Protected Presentations](/slides/tr/python-java/password-protected-presentation/) sayfasına bakın.

## **Doğruluk ve Eski Özellikler**

Dönüşüm genellikle slaytları, ana düzenleri, yerleşimleri, metni, şekilleri, resimleri, tabloları ve grafikleri korur. Ancak, PPT ve PPTX her özelliği tam aynı şekilde temsil etmez. Kitaplık tarafından desteklenmeyen veya PPTX eşdeğeri olmayan eski bir özellik, normalleştirilebilir, atlanabilir veya farklı şekilde gösterilebilir.

Dönüştürülmüş dosyayı, animasyon, geçiş, gömülü veya bağlantılı OLE nesneleri, ActiveX denetimleri, gömülü medya, nadir yazı tipleri veya VBA makroları içerdiğinde kontrol edin. Düz bir PPTX dosyası makro‑etkin bir format değildir; bu nedenle VBA'nın mevcut olması gerektiğinde uygun bir makro‑etkin iş akışı kullanın. Ayrıca, gerekli yazı tiplerinin ve harici kaynakların, dönüştürülmüş sunumun açılacağı veya işleneceği ortamda bulunduğundan emin olun.

Önemli belgeler için, oluşturulan PPTX dosyasını programlı olarak yeniden açın ve temel slayt sayısını ve içeriği inceleyin, ardından görünümünü ve slayt gösterisi davranışını hedeflenen görüntüleyicide karşılaştırın. Başarılı bir [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) çağrısını, tüm eski özelliklerin tam bir PPTX temsiline sahip olduğu kanıtı olarak değerlendirmeyin.

## **Ne Zaman PPTX Kullanmalı**

Sunum, güncel PowerPoint sürümlerinde düzenlenecekse, Open XML paketleriyle çalışan sistemlerle değiş tokuş edilecekse veya eski ikili PPT'ye göre daha kolay incelenip kurtarılabilen bir formatta saklanacaksa PPTX kullanın. Dönüştürülmüş sunum doğruluk kontrollerinizi geçtiği sürece, orijinal PPT'yi arşiv veya geri dönüş kopyası olarak tutun.

PDF, HTML, görseller, XPS veya başka bir çıktı türüne ihtiyacınız varsa, tüm hedeflerin düzenlenebilir PowerPoint özelliklerini koruyacağını varsaymak yerine [Convert Presentations to Multiple Formats](/slides/tr/python-java/convert-presentation/) içindeki format‑spesifik rehberi kullanın.

## **Çevrimiçi Dönüştürücü**

Ara sıra bir dosya veya hızlı bir karşılaştırma için [online PPT to PPTX converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) servisini kullanabilirsiniz. Tekrarlanan dönüşümler, toplu işleme veya uygulama seviyesinde hata yönetimi için Python via Java API'yi kullanın.

## **İlgili Makaleler**

- [PPT vs PPTX](/slides/tr/python-java/ppt-vs-pptx/)
- [Python'da Sunumları Kaydet](/slides/tr/python-java/save-presentation/)
- [Desteklenen Dosya Formatları](/slides/tr/python-java/supported-file-formats/)
- [Python'da Sunumları Aç](/slides/tr/python-java/open-presentation/)

## **SSS**

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürebilir miyim?**

Evet. Aspose.Slides for Python via Java, Microsoft PowerPoint gerektirmeden sunum dosyalarını yükleyip kaydedebilir.

**PPT'den PPTX'e dönüşüm tüm içeriği tam olarak korur mu?**

Ortak sunum içeriğini korur, ancak her eski veya desteklenmeyen özelliğin tam bir eşdeğeri olmayabilir. Makrolar, OLE veya ActiveX nesneleri, medya, özel animasyonlar veya nadir yazı tipleri içerdiğinde oluşturulan dosyayı inceleyin.

**Şifre korumalı bir PPT dosyasını dönüştürebilir miyim?**

Evet, dosyayı yüklerken doğru şifreyi sağlarsanız dönüşüm yapılabilir. Şifre eksik veya hatalıysa yükleme işlemi başarısız olur.

**Dönüşüm sonrasında PPT dosyasını silmeli miyim?**

Orijinali, PPTX'i izleyicilerde ve iş akışlarınızda doğrulayıp onaylayana kadar tutun. Bu, eski bir özelliğin farklı dönüştürülmesi durumunda geri dönüş kopyası sağlar.