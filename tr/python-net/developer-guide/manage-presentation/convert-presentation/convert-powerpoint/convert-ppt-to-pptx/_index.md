---
title: Python'da PPT'yi PPTX'e Dönüştür
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/python-net/convert-ppt-to-pptx/
keywords:
- PowerPoint'ı dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPT'den PPTX'e
- PPT'yi PPTX olarak kaydet
- PPT'yi PPTX'e dışa aktar
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python'da eski PPT dosyalarını PPTX'e dönüştürün. Tek dosya ve toplu dönüşüm örneklerini, hata yönetimini ve doğruluk notlarını içerir."
---
## **Genel Bakış**

PPT, eski ikili PowerPoint formatıdır, PPTX ise daha yeni Open XML formatıdır. Aspose.Slides for Python via .NET, Microsoft PowerPoint olmadan bir PPT dosyasını yükleyebilir ve PPTX olarak kaydedebilir. Bu makale, tek bir dosyayı veya bir dizindeki dosyaları nasıl dönüştüreceğinizi gösterir ve dönüşüm sonrası neyin doğrulanacağını açıklar.

## **Bir PPT Dosyasını PPTX'e Dönüştür**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfı ile yükleyin, ardından [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) yöntemini [SaveFormat.PPTX](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/saveformat/) ile çağırın. `with` ifadesi, blok sona erdiğinde sunumu yok eder ve kaynaklarını serbest bırakır.

```python
import aspose.slides as slides

# Eski PPT sunumunu yükle.
with slides.Presentation("presentation.ppt") as presentation:
    # Sunumu PPTX formatında kaydet.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Dosya uzantısı tek başına çıktı formatını seçmez; bunu [SaveFormat.PPTX](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/saveformat/) argümanı yapar. Orijinal PPT dosyasını tutmanız gerekiyorsa, giriş ve çıkış yollarını farklı tutun.

## **Birden Çok PPT Dosyasını Dönüştür**

Aşağıdaki örnek, bir dizindeki her `.ppt` dosyasını dönüştürür. Her dosya bağımsız olarak işlenir, bu yüzden tek bir dönüşüm hatası toplu işlemenin geri kalanını durdurmaz.

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

Üretim ortamları için, tam istisnayı günlüğe kaydedin, mevcut bir çıktı dosyasının üzerine yazılıp yazılamayacağına karar verin ve başarısız dosya adlarını bir tekrar deneyim veya inceleme kuyruğuna yazın. Bozuk dosyalar, gerekli şifre olmadan açılan şifre korumalı dosyalar, erişilemeyen yollar ve desteklenmeyen içerik dönüşümün başarısız olmasına neden olabilir. Şifreli dosyaları yüklemek için [Password-Protected Presentations](/slides/tr/python-net/password-protected-presentation/) sayfasına bakın.

## **Doğruluk ve Eski Özellikler**

Dönüşüm genellikle slaytları, ana şablonları, düzenleri, metni, şekilleri, görselleri, tabloları ve grafikleri korur. Ancak, PPT ve PPTX her özelliği tam olarak aynı şekilde temsil etmez. Kütüphane tarafından desteklenmeyen veya PPTX eşdeğeri olmayan bir eski özellik, normalleştirilebilir, atlanabilir veya farklı şekilde gösterilebilir.

Dönüştürülmüş dosyayı, animasyonlar, geçişler, gömülü veya bağlı OLE nesneleri, ActiveX denetimleri, gömülü medya, nadir fontlar veya VBA makroları içerdiğinde kontrol edin. Düz bir PPTX dosyası makro etkin bir format değildir, bu yüzden VBA'nın mevcut olması gerektiğinde uygun bir makro etkin iş akışı kullanın. Ayrıca, gereken fontların ve dış kaynakların, dönüştürülmüş sunumun açılacağı veya işleneceği ortamda mevcut olduğunu doğrulayın.

Önemli belgeler için, oluşturulan PPTX'i programlı olarak yeniden açın ve temel slayt sayısını ve içeriğini inceleyin, ardından görünümünü ve slayt gösterisi davranışını hedeflenen görüntüleyicide karşılaştırın. Başarılı bir [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) çağrısını, her eski özelliğin tam bir PPTX temsiline sahip olduğunun kanıtı olarak değerlendirmeyin.

## **PPTX Ne Zaman Kullanılmalı**

Sunum, mevcut PowerPoint sürümlerinde düzenlenecekse, Open XML paketleri ile çalışan sistemlerle değiş tokuş edilecekse veya eski ikili PPT'ye göre daha kolay incelenebilir ve kurtarılabilir bir formatta saklanacaksa PPTX kullanın. Dönüştürülmüş sunum doğruluk kontrollerinizi geçene kadar orijinal PPT'yi arşiv veya geri dönüş kopyası olarak tutun.

PDF, HTML, görseller, XPS veya başka bir çıktı türüne ihtiyacınız varsa, tüm hedeflerin düzenlenebilir PowerPoint özelliklerini koruduğunu varsaymak yerine [Convert Presentations to Multiple Formats](/slides/tr/python-net/convert-presentation/) sayfasındaki format‑özel yönergeleri kullanın.

## **Çevrimiçi Dönüştürücü**

Ara sıra bir dosya veya hızlı bir karşılaştırma için, [online PPT to PPTX converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) adresini kullanabilirsiniz. Tekrarlanan dönüşümler, toplu işleme veya uygulama seviyesinde hata yönetimi için Python API'sini kullanın.

## **İlgili Makaleler**

- [PPT vs PPTX](/slides/tr/python-net/ppt-vs-pptx/)
- [Python'da Sunumları Kaydet](/slides/tr/python-net/save-presentation/)
- [Desteklenen Dosya Formatları](/slides/tr/python-net/supported-file-formats/)
- [Python'da Sunumları Aç](/slides/tr/python-net/open-presentation/)

## **SSS**

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürebilir miyim?**

Evet. Aspose.Slides for Python via .NET, Microsoft PowerPoint gerektirmeden sunum dosyalarını yükler ve kaydeder.

**PPT'den PPTX'e dönüşüm tüm içeriği tam olarak korur mu?**

Ortak sunum içeriğini korur, ancak her eski veya desteklenmeyen özellik için tam doğruluk garanti edilmez. Makrolar, OLE veya ActiveX nesneleri, medya, özel animasyonlar veya nadir fontlar içerdiğinde üretilen dosyayı inceleyin.

**Şifre korumalı bir PPT dosyasını dönüştürebilir miyim?**

Evet, dosyayı yüklerken doğru şifreyi sağlarsanız. Eksik ya da hatalı şifre, yükleme işleminin başarısız olmasına neden olur.

**Dönüşümden sonra PPT dosyasını silmeli miyim?**

Orijinali, PPTX'i sizin için önemli olan görüntüleyicilerde ve iş akışlarında doğrulayana kadar tutun. Bu, bir eski özelliğin farklı dönüştürülmesi durumunda geri dönüş kopyası sağlar.