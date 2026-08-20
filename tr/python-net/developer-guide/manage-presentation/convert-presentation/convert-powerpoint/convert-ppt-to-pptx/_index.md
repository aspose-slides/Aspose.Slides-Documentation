---
title: Python'da PPT'yi PPTX'e Dönüştür
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/python-net/convert-ppt-to-pptx/
keywords:
- PowerPoint dönüştür
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
description: "Aspose.Slides ile Python'da eski PPT dosyalarını PPTX'e dönüştürün. Tek dosya ve toplu dönüşüm örnekleri, hata yönetimi ve doğruluk notları içerir."
---
## **Genel Bakış**

PPT, eski ikili PowerPoint formatıdır, PPTX ise daha yeni Open XML formatıdır. Aspose.Slides for Python via .NET, bir PPT dosyasını Microsoft PowerPoint olmadan yükleyebilir ve PPTX olarak kaydedebilir. Bu makale, tek bir dosyayı ya da bir dosya dizinini nasıl dönüştüreceğinizi gösterir ve dönüşüm sonrası neyin doğrulanması gerektiğini açıklar.

## **Bir PPT Dosyasını PPTX'e Dönüştürme**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfı ile yükleyin, ardından [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) metodunu [SaveFormat.PPTX](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/saveformat/) argümanıyla çağırın. `with` ifadesi, blok sona erdiğinde sunumu temizler ve kaynaklarını serbest bırakır.

```python
import aspose.slides as slides

# Eski PPT sunumunu yükle.
with slides.Presentation("presentation.ppt") as presentation:
    # Sunumu PPTX formatında kaydet.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Dosya uzantısı tek başına çıktı formatını seçmez; bunu [SaveFormat.PPTX](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/saveformat/) argümanı belirler. Orijinal PPT dosyasını korumanız gerekiyorsa giriş ve çıkış yollarını farklı tutun.

## **Birden Çok PPT Dosyasını Dönüştürme**

Aşağıdaki örnek, bir dizindeki tüm `.ppt` dosyalarını dönüştürür. Her dosya bağımsız olarak işlenir, bu yüzden bir dönüşümün başarısız olması diğerlerini durdurmaz.

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

Üretim ortamları için, tam istisna kaydını tutun, mevcut bir çıktı dosyasının üzerine yazılıp yazılamayacağına karar verin ve başarısız dosya adlarını yeniden deneme veya inceleme kuyruğuna yazın. Bozuk dosyalar, gerekli şifre olmadan açılan şifre korumalı dosyalar, erişilemeyen yollar ve desteklenmeyen içerik dönüşümün başarısız olmasına neden olabilir. Şifreli dosyaları yüklemek için [Password-Protected Presentations](/python-net/password-protected-presentation/) bölümüne bakın.

## **Doğruluk ve Eski Özellikler**

Dönüştürme genellikle slaytları, masterları, düzenleri, metni, şekilleri, görüntüleri, tabloları ve grafikleri korur. Ancak PPT ve PPTX, her özelliği tam olarak aynı şekilde temsil etmez. Kütüphane tarafından desteklenmeyen veya PPTX eşdeğeri olmayan bir eski özellik, normalleştirilebilir, atlanabilir veya farklı görüntülenebilir.

Animasyonlar, geçişler, gömülü ya da bağlanmış OLE nesneleri, ActiveX denetimleri, gömülü medya, nadir kullanılan yazı tipleri veya VBA makroları içerdiğinde dönüştürülen dosyayı kontrol edin. Normal bir PPTX dosyası makro‑uyumlu bir format değildir; VBA'nın mevcut kalması gerektiğinde uygun makro‑uyumlu bir iş akışı kullanın. Ayrıca, dönüştürülen sunumun açılacağı veya render edileceği ortamda gereken yazı tipleri ve dış kaynakların mevcut olduğunu doğrulayın.

Önemli belgeler için, oluşturulan PPTX'i programlı olarak yeniden açın ve ana slayt sayısını ve içeriğini inceleyin, ardından görünümünü ve slayt gösterisi davranışını hedeflenen görüntüleyicide karşılaştırın. Başarılı bir [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) çağrısını, her eski özelliğin tam bir PPTX temsiline sahip olduğunun kanıtı olarak değerlendirmeyin.

## **Ne Zaman PPTX Kullanmalı**

Sunum, mevcut PowerPoint sürümlerinde düzenlenecekse, Open XML paketleriyle çalışan sistemlerle değiş tokuş edilecekse veya eski ikili PPT'den daha kolay incelenip kurtarılabilen bir formatta saklanacaksa PPTX kullanın. Dönüştürülen sunum doğruluk kontrollerinizi geçtiğinde, orijinal PPT'yi arşiv veya geri dönüş kopyası olarak tutun.

PDF, HTML, görüntüler, XPS veya başka bir çıktı türüne ihtiyacınız varsa, tüm hedeflerin düzenlenebilir PowerPoint özelliklerini koruyacağını varsaymak yerine [Convert Presentations to Multiple Formats](/python-net/convert-presentation/) bölümündeki format‑özel rehberliği kullanın.

## **Çevrimiçi Dönüştürücü**

Arada sırada bir dosya veya hızlı bir karşılaştırma için [online PPT to PPTX converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) hizmetini kullanabilirsiniz. Tekrarlayan dönüşümler, toplu işleme veya uygulama‑seviyesi hata yönetimi için Python API'sini kullanın.

## **İlgili Makaleler**

- [PPT vs PPTX](/python-net/ppt-vs-pptx/)
- [Python'da Sunumları Kaydet](/python-net/save-presentation/)
- [Desteklenen Dosya Biçimleri](/python-net/supported-file-formats/)
- [Python'da Sunumları Aç](/python-net/open-presentation/)

## **SSS**

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürebilir miyim?**

Evet. Aspose.Slides for Python via .NET, Microsoft PowerPoint gerektirmeden sunum dosyalarını yükler ve kaydeder.

**PPT'den PPTX'e dönüşüm tüm içeriği tam olarak korur mu?**

Ortak sunum içeriğini korur, ancak her eski ya da desteklenmeyen özellik için tam doğruluk garantilenmez. Makrolar, OLE veya ActiveX nesneleri, medya, özel animasyonlar veya nadir kullanılan yazı tipleri içerdiğinde üretilen dosyayı inceleyin.

**Şifre korumalı bir PPT dosyasını dönüştürebilir miyim?**

Evet, dosyayı yüklerken doğru şifreyi sağlarsanız. Eksik veya hatalı şifre, yükleme işleminin başarısız olmasına neden olur.

**Dönüştürmeden sonra PPT dosyasını silmeli miyim?**

Orijinali, PPTX'i sizin için önemli olan görüntüleyicilerde ve iş akışlarında doğrulayana kadar saklayın. Bu, bir eski özelliğin farklı dönüştürülmesi durumunda geri dönüş kopyası sağlar.