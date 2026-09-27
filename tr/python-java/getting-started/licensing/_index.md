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
- ölçülen lisanslama
- değerlendirme sınırlamaları
description: "Aspose.Slides for Python via Java’da dosya, bayt tabanlı veya ölçülen lisans uygulayın ve uygulamalarınızdaki değerlendirme sınırlamalarını kaldırın."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, değerlendirme modunda ya da bir lisans ile çalıştırılabilir. Değerlendirme modunda, kaydettiği her sunumun her slaytına bir değerlendirme filigranı metin kutusu ekler ve kodunuzun sunumlardan okuduğu metni kısaltır. Bu makale, bir lisansı dosyadan ya da baytlardan nasıl uygulayacağınızı ve ölçülen lisanslamayı nasıl yapılandıracağınızı açıklar.

Satın alma seçenekleri için [Pricing Information](https://purchase.aspose.com/pricing/slides/family) sayfasına bakın. Genel lisanslama ve satın alma soruları için [Purchase Policies and FAQ](https://purchase.aspose.com/policies) sayfasını ziyaret edin.

Değerlendirme sınırlamaları ve geçici bir lisans talep etme hakkında bilgi için [Evaluate Aspose.Slides](/slides/tr/python-java/evaluate-aspose-slides/) sayfasına bakın. Geçici bir lisansı, satın alınmış bir lisans dosyası gibi aynı şekilde uygulayın.

## **Lisans Hakkında**

Bir lisans dosyası, ürün adı, lisanslı geliştirici sayısı ve abonelik son tarih gibi bilgileri içerir. Dosya, dijital olarak imzalanmış bir XML’dir.

{{% alert color="warning" title="Warning" %}}
Lisans dosyasını düzenlemeyin. Fazladan bir satır sonu bile dijital imzasını geçersiz kılabilir.
{{% /alert %}}

Lisansı, sunumları oluşturmadan ya da diğer Aspose.Slides işlemlerini yapmadan önce, uygulama ya da işlem başına bir kez uygulayın. Lisans dosyası için [License](https://reference.aspose.com/slides/python-java/aspose.slides/license/) sınıfını kullanın. Ölçülen lisanslama, lisans dosyası yerine bir açık ve gizli anahtar çifti kullanır.

## **Lisansı Uygula**

Aşağıdaki örnekler, Aspose.Slides for Python via Java ve önkoşullarının yüklü olduğunu varsayar. Her örnek, JVM’yi başlatan, API’yi içe aktaran ve bir lisans uygulayan bağımsız bir betiktir. Uygulamanızda, lisansı uyguladıktan sonra sunum işlemlerinizi gerçekleştirin ve tüm Aspose.Slides çalışması tamamlandıktan sonra JVM’yi kapatın.

### **Dosyadan Lisans Uygula**

Lisans dosyası yolunu [License.setLicense](https://reference.aspose.com/slides/python-java/aspose.slides/license/#setLicense) yöntemine aktarın. `Aspose.Slides.lic` ifadesini lisans dosyanızın yolu ile değiştirin.

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
        # Sunum işlemlerini burada gerçekleştirin, JVM'i kapatmadan önce.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Dosya adını uzantısı ile birlikte tam olarak kullanın. Örneğin dosyanın adı `Aspose.Slides.lic.xml` ise, yolda `.xml` uzantısını da ekleyin. Tam bir yol, uygulamanın çalışma dizini hakkındaki belirsizliği ortadan kaldırır.

Örnek, lisansın uygulanıp uygulanmadığını kontrol etmek için [License.isLicensed](https://reference.aspose.com/slides/python-java/aspose.slides/license/#isLicensed) metodunu kullanır.

### **Baytlardan Lisans Uygula**

Lisans Python baytları olarak mevcutsa, [License.setLicenseFromBytes](https://reference.aspose.com/slides/python-java/aspose.slides/license/#setLicenseFromBytes) yöntemini kullanın. Aşağıdaki örnek, dosyayı ikili modda okur ve lisansı uygulamadan önce kapatır.

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
        # Sunum işlemlerini burada gerçekleştirin, JVM'i kapatmadan önce.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Orijinal baytları değiştirmeyin. Lisans içeriğini uygulamadan önce çözümlemeyin, yeniden biçimlendirmeyin ya da başka bir şekilde değiştirmeyin.

## **Ölçülen Lisans Uygula**

Ölçülen lisanslama, API kullanımınıza göre faturalandırır. Ölçülen bir lisans elde ettikten sonra, açık ve gizli anahtarlarını [Metered.setMeteredKey](https://reference.aspose.com/slides/python-java/aspose.slides/metered/#setMeteredKey) ile uygulayın. [Metered](https://reference.aspose.com/slides/python-java/aspose.slides/metered/) nesnesini başlatın ve anahtarları uygulama başlatıldığında bir kez ayarlayın.

Aşağıdaki örnek, `ASPOSE_METERED_PUBLIC_KEY` ve `ASPOSE_METERED_PRIVATE_KEY` ortam değişkenlerinden anahtarları okur. Betiği çalıştırmadan önce her iki değişkeni de ayarlayın.

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
        # Sunum işlemlerini burada gerçekleştirin, JVM'i kapatmadan önce.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
Ölçülen lisanslama, anahtarları doğrulamak ve kullanım raporlamak için bir internet bağlantısı gerektirir. Gizli anahtarı kaynak kodundan ve günlük dosyalarından uzak tutun. Bağlantı ve faturalandırma detayları için [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) sayfasına bakın.
{{% /alert %}}

## **SSS**

**Lisans satın aldıktan sonra farklı bir paket yüklemem gerekiyor mu?**

Hayır. Değerlendirme için kullandığınız aynı pakete lisansı uygulayın.

**Her sunum için lisans uygulamalı mıyım?**

Hayır. Sunumları oluşturma ya da yükleme öncesinde, uygulama başlangıcında bir kez uygulayın.

**Lisans dosyasının adını değiştirebilir miyim?**

Evet. Kodunuzda tam yeni dosya adını kullanın ve dosya içeriğini değiştirmeyin.

**Bayt tabanlı örnekle geçici bir lisans kullanabilir miyim?**

Evet. Geçici lisans dosyasını bayt olarak okuyun ve satın alınan lisans gibi uygulayın.