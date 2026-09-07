---
title: Python'da PPT'yi PPTX'e Dönüştür
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/python-java/convert-ppt-to-pptx/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPT'den PPTX'e
- PPT'yi PPTX olarak kaydet
- PPT'yi PPTX'e dışa aktar
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Python'da eski PPT dosyalarını PPTX'e dönüştürün. Tek dosya ve toplu dönüşüm, hata yönetimi ve doğruluk notları için Python örneklerini içerir."
---
## **Genel Bakış**

PPT, eski ikili PowerPoint formatıdır, PPTX ise yeni Open XML formatıdır. Aspose.Slides for Python via Java, bir PPT dosyasını Microsoft PowerPoint olmadan yükleyebilir ve PPTX olarak kaydedebilir. Bu makale, tek bir dosyayı veya bir dosya dizinini nasıl dönüştüreceğinizi gösterir ve dönüşüm sonrası neyin doğrulanması gerektiğini açıklar.

Her örnek, gerekirse Java sanal makinesini başlatır ve kullanımdan sonra sunumu serbest bırakır. Örnek yolları kendi dosya veya dizin yollarınızla değiştirin.

## **Bir PPT Dosyasını PPTX'e Dönüştürme**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfı ile yükleyin, ardından [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Pptx) ile çağırın. `finally` bloğu sunumu temizler ve kaynaklarını serbest bırakır.

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

Dosya uzantısı tek başına çıkış formatını seçmez; bunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Pptx) argümanı yapar. Orijinal PPT dosyasını korumanız gerekiyorsa giriş ve çıkış yollarını farklı tutun.

## **Birden Çok PPT Dosyasını Dönüştürme**

Aşağıdaki örnek bir dizindeki tüm `.ppt` dosyalarını dönüştürür. Her dosya bağımsız olarak işlenir, bu yüzden bir dönüştürme hatası diğerlerini durdurmaz.

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

Üretim ortamlarında, tam istisna kaydını tutun, mevcut bir çıkış dosyasının üzerine yazılıp yazılmayacağına karar verin ve başarısız dosya adlarını bir yeniden deneme veya inceleme kuyruğuna yazın. Bozuk dosyalar, gerekli şifre olmadan açılan şifre korumalı dosyalar, erişilemeyen yollar ve desteklenmeyen içerik dönüştürmenin başarısız olmasına neden olabilir. Şifreli dosyaları yüklemek için [Password-Protected Presentations](/slides/tr/python-java/password-protected-presentation/) sayfasına bakın.

## **Doğruluk ve Eski Özellikler**

Dönüştürme genellikle slaytları, ana şablonları, düzenleri, metni, şekilleri, resimleri, tabloları ve grafikleri korur. Ancak, PPT ve PPTX her özelliği tam olarak aynı şekilde temsil etmez. Kütüphane tarafından desteklenmeyen veya PPTX eşdeğeri olmayan eski bir özellik, normalleştirilebilir, atlanabilir veya farklı gösterilebilir.

Dönüştürülen dosyada animasyonlar, geçişler, gömülü veya bağlantılı OLE nesneleri, ActiveX denetimleri, gömülü medya, nadir fontlar veya VBA makroları varsa kontrol edin. Düz bir PPTX dosyası makro destekli bir format değildir, bu yüzden VBA'nın kullanılabilir olması gerekiyorsa uygun bir makro‑destekli iş akışı kullanın. Ayrıca, dönüştürülmüş sunumun açılacağı veya işleneceği ortamda gerekli fontların ve dış kaynakların mevcut olduğundan emin olun.

Önemli belgeler için, oluşturulan PPTX'i programlı olarak yeniden açın ve ana slayt sayısını ve içeriğini inceleyin, ardından görünümünü ve slayt gösterisi davranışını hedef izleyicide karşılaştırın. Başarılı bir [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) çağrısını, her eski özelliğin tam bir PPTX temsiline sahip olduğunun kanıtı olarak görmeyin.

## **PPTX Ne Zaman Kullanılmalı**

Sunum, mevcut PowerPoint sürümlerinde düzenlenecek, Open XML paketleriyle çalışan sistemlerle değiş tokuş yapılacak veya eski ikili PPT'ye göre daha kolay incelenip kurtarılabilen bir formatta saklanacaksa PPTX kullanın. Dönüştürülmüş sunum, doğruluk kontrollerinizi geçtiğinde orijinal PPT'yi arşivleme veya geri alma kopyası olarak tutun.

Eğer PDF, HTML, resimler, XPS veya başka bir çıktı türüne ihtiyacınız varsa, tüm hedeflerin düzenlenebilir PowerPoint özelliklerini koruduğunu varsaymak yerine [Convert Presentations to Multiple Formats](/slides/tr/python-java/convert-presentation/) sayfasındaki formata özgü rehberliği kullanın.

## **Çevrimiçi Dönüştürücü**

Ara sıra bir dosya veya hızlı bir karşılaştırma için [online PPT to PPTX converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) adresini kullanabilirsiniz. Tekrarlanan dönüşümler, toplu işleme veya uygulama düzeyinde hata yönetimi için Python via Java API'sini kullanın.

## **İlgili Makaleler**

- [PPT vs PPTX](/slides/tr/python-java/ppt-vs-pptx/)
- [Python'da Sunumları Kaydet](/slides/tr/python-java/save-presentation/)
- [Desteklenen Dosya Biçimleri](/slides/tr/python-java/supported-file-formats/)
- [Python'da Sunumları Aç](/slides/tr/python-java/open-presentation/)

## **SSS**

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürebilir miyim?**

Evet. Aspose.Slides for Python via Java, Microsoft PowerPoint gerektirmeden sunum dosyalarını yükler ve kaydeder.

**PPT'den PPTX'e dönüşüm tüm içeriği tam olarak korur mu?**

Ortak sunum içeriğini korur, ancak her eski ya da desteklenmeyen özellik için tam doğruluk garantilenmez. Oluşturulan dosya makrolar, OLE veya ActiveX nesneleri, medya, özel animasyonlar veya nadir fontlar içeriyorsa gözden geçirilmelidir.

**Şifre korumalı bir PPT dosyasını dönüştürebilir miyim?**

Evet, dosyayı yüklerken doğru şifreyi sağlarsanız. Şifre eksik ya da hatalı olduğunda yükleme işlemi başarısız olur.

**Dönüşümden sonra PPT dosyasını silmeli miyim?**

Orijinali, PPTX'i sizin için önemli olan izleyiciler ve iş akışlarıyla doğrulayana kadar saklayın. Bu, bir eski özelliğin farklı dönüştürülmesi durumunda geri alma kopyası sağlar.