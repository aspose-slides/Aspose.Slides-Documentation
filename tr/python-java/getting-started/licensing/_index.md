---
title: Lisanslama
type: docs
weight: 80
url: /tr/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- lisans dosyası
- geçici lisans
- ölçülü lisanslama
- değerlendirme sınırlamaları
description: "Aspose.Slides for Python via Java içinde dosya, bayt tabanlı veya ölçülü lisans uygulayın ve uygulamalarınızdaki değerlendirme sınırlamalarını kaldırın."
---
## **Genel Bakış**

Aspose.Slides for Python via Java değerlendirme modunda veya lisanslı olarak çalışabilir. Bu makale, bir lisansı dosyadan veya baytlardan nasıl uygulayacağınızı ve ölçülü lisanslamanın nasıl yapılandırılacağını açıklar.

Satın alma seçenekleri için [Pricing Information](https://purchase.aspose.com/pricing/slides/tr/family) sayfasına bakın. Genel lisanslama ve satın alma soruları için [Purchase Policies and FAQ](https://purchase.aspose.com/policies) sayfasına bakın.

Değerlendirme sınırlamaları ve geçici bir lisans talep etme hakkında bilgi için [Evaluate Aspose.Slides](/slides/tr/python-java/evaluate-aspose-slides/) sayfasına bakın. Geçici bir lisansı, satın alınmış bir lisans dosyası gibi aynı şekilde uygulayın.

## **Lisans Hakkında**

Bir lisans dosyası, ürün adı, lisanslı geliştirici sayısı ve abonelik son tarih gibi bilgileri içerir. Dosya, dijital olarak imzalanmış bir XML'dir.

{{% alert color="warning" title="Warning" %}}
Lisans dosyasını düzenlemeyin. Ek bir satır boşluğu bile dijital imzasını geçersiz kılabilir.
{{% /alert %}}

## **Lisansı Uygula**

Lisansı, sunumlar oluşturulmadan veya diğer Aspose.Slides işlemleri yapılmadan önce, uygulama veya süreç başına bir kez uygulayın. Lisans dosyası için [License](https://reference.aspose.com/slides/tr/python-java/aspose.slides/license/) sınıfını kullanın. Ölçülü lisanslama, lisans dosyası yerine bir ortak ve bir özel anahtar çifti kullanır.

### **Dosyadan Lisans Uygulama**

Lisans dosyası yolunu [License.setLicense](https://reference.aspose.com/slides/tr/python-java/aspose.slides/license/#setLicense) yöntemine gönderin. `Aspose.Slides.lic` ifadesini lisans dosyanızın yolu ile değiştirin.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Sunum işlemlerini burada gerçekleştirin, JVM kapatılmadan önce.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Dosya adını tam olarak, uzantısı dahil, kullanın. Örneğin dosya adı `Aspose.Slides.lic.xml` ise, yola `.xml` ekleyin. Mutlak bir yol, uygulamanın çalışma dizini hakkındaki belirsizliği ortadan kaldırır.

Örnek, lisansın uygulanıp uygulanmadığını kontrol etmek için [License.isLicensed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/license/#isLicensed) yöntemini kullanır.

### **Baytlardan Lisans Uygulama**

Lisans Python baytları olarak mevcut olduğunda [License.setLicenseFromBytes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/license/#setLicenseFromBytes) yöntemini kullanın. Aşağıdaki örnek dosyayı ikili modda okur ve lisansı uygulamadan önce kapatır.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Sunum işlemlerini burada gerçekleştirin, JVM kapatılmadan önce.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Orijinal baytları değiştirmeyin. Lisans içeriğini uygulamadan önce çözümlemeyin, yeniden biçimlendirmeyin veya başka bir şekilde değiştirmeyin.

## **Ölçülü Lisans Uygulama**

Ölçülü lisanslama, API kullanımınıza göre faturalandırır. Ölçülü bir lisans aldıktan sonra, ortak ve özel anahtarlarını [Metered.setMeteredKey](https://reference.aspose.com/slides/tr/python-java/aspose.slides/metered/#setMeteredKey) yöntemiyle uygulayın. [Metered](https://reference.aspose.com/slides/tr/python-java/aspose.slides/metered/) nesnesini başlatın ve anahtarları uygulama başlangıcında bir kez uygulayın.

Aşağıdaki örnek, anahtarları `ASPOSE_METERED_PUBLIC_KEY` ve `ASPOSE_METERED_PRIVATE_KEY` ortam değişkenlerinden okur. Betiği çalıştırmadan önce her iki değişkeni de ayarlayın.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Sunum işlemlerini burada gerçekleştirin, JVM kapatılmadan önce.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
Ölçülü lisanslama, anahtarları doğrulamak ve kullanımı raporlamak için bir Internet bağlantısı gerektirir. Özel anahtarı kaynak kodundan ve günlüklerden uzak tutun. Bağlantı ve faturalama ayrıntıları için [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) sayfasına bakın.
{{% /alert %}}

## **SSS**

**Bir lisans satın aldıktan sonra farklı bir paket yüklemem gerekir mi?**

Hayır. Lisansı, değerlendirme sırasında kullandığınız aynı pakete uygulayın.

**Her sunum için lisans uygulamalı mıyım?**

Hayır. Uygulama başlangıcında, sunumları oluşturma veya yükleme işleminden önce bir kez uygulayın.

**Lisans dosyasının adını değiştirebilir miyim?**

Evet. Kodunuzda yeni dosya adını tam olarak kullanın ve dosya içeriğini değiştirmeyin.

**Bayt tabanlı örnekle geçici bir lisans kullanabilir miyim?**

Evet. Geçici lisans dosyasını bayt olarak okuyun ve satın alınan bir lisans gibi aynı şekilde uygulayın.