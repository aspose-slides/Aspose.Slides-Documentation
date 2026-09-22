---
title: Python üzerinden Java ile Sunumları Açma
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/python-java/open-presentation/
keywords:
- PowerPoint aç
- sunum aç
- PPTX aç
- PPT aç
- ODP aç
- sunumu yükle
- PPTX yükle
- PPT yükle
- ODP yükle
- korumalı sunum
- büyük sunum
- harici kaynak
- ikili nesne
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ile PowerPoint ve OpenDocument sunumlarını nasıl açacağınızı, açma şifreleri sağlamayı, kaynak yüklemeyi kontrol etmeyi ve Aspose.Slides for Python via Java ile bellek kullanımını azaltmayı öğrenin."
---
## **Giriş**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/tr/python-java/) dosyalardan ve akışlardan PowerPoint ve OpenDocument sunumlarını yükleyebilir. Bir sunum yüklendikten sonra yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka bir desteklenen formatta kaydedebilirsiniz.

Yükleme davranışı, [LoadOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/) sınıfı aracılığıyla özelleştirilebilir. Örneğin, bir açma şifresi sağlayabilir, büyük ikili nesneleri Java yığını dışına tutabilir, dış kaynakları kontrol edebilir veya gömülü ikili verileri atlayabilirsiniz.

## **Sunumları Açma**

Bir dosya veya akış yüklendikten sonra, uygulamanızın nasıl işlem yapacağını belirlemek için [orijinal sunum formatını belirleyebilirsiniz](/slides/tr/python-java/detect-presentation-source-format/).

Mevcut bir sunumu açmak için dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) yapıcı metoduna geçirin. Sunumu kullandıktan sonra, dosya tutamaçları, geçici veriler ve diğer kaynakların hızlıca serbest bırakılması için sunumu kapatın.

Aşağıdaki Python örneği, bir sunumu nasıl açıp slayt sayısını alacağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Şifreli Sunumları Açma**

Açma şifresi, sunum içeriğini şifreler. Tam sunumu yüklemek için doğru şifreyi [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setPassword) metoduna geçirip bu seçenekleri [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) yapıcı metoduna verin. Şifre eksik ya da hatalı olduğunda yükleme başarısız olur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

Şifre algılama, doğrulama ve şifreleme iş akışları için [Şifreli Sunumlar](/slides/tr/python-java/password-protected-presentation/) bölümüne bakın. Şifreli bir sunum, kasıtlı olarak genel belge özellikleriyle kaydedildiyse, bu özellikler şifresiz okunabilir; bununla ilgili bilgiye [Sunum Özelliklerini Yönetme](/slides/tr/python-java/presentation-properties/) bölümünden ulaşabilirsiniz.

## **Büyük Sunumları Açma**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) yöntemi, Aspose.Slides’in resimler, ses ve video gibi büyük ikili nesneleri nasıl ele alacağını kontrol eden seçenekleri döndürür. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellek içinde tutulan BLOB verisinin miktarını sınırlayabilirsiniz.

Aşağıdaki Python kodu, büyük bir sunumu (örneğin 2 GB) yüklemeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Not" %}}
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) ile kaynak dosya, sunum nesnesi serbest bırakılana kadar kilitli kalır. Bu nesne hâlâ etkinken kaynak dosyayı taşımayın, üzerine yazmayın ya da silmeyin.
Aspose.Slides, yükleme sırasında bir giriş akışının içeriğini kopyalayabilir. Büyük sunumlar için dosya yolu, genellikle akıştan daha verimlidir. Ek depolama ve bellek yönetimi seçenekleri için [BLOB'ları Yönetme](/slides/tr/python-java/manage-blob/) bölümüne bakın.
{{% /alert %}}

## **Dış Kaynakları Kontrol Etme**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) metodu, Java kaynak yükleme geri arama arabirimini uygulayan bir JPype vekilini kabul eder. Geri arama, yerine geçecek veri sağlayabilir, bir kaynağı yönlendirebilir, varsayılan yükleyiciyi kullanabilir ya da kaynağı atlayabilir. Bu, sunumların dış resimler içermesi ve bu resimlerin uygulama‑spesifik güvenlik veya depolama kurallarına göre çözülmesi gerektiğinde faydalıdır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Gömülü Ikili Nesneler Olmadan Sunumları Yükleme**

Bir sunum, uygulamanın gerekmeyen veya saklamak istemediği gömülü ikili veriler içerebilir. Örnekler:
- VBA projeleri, [Presentation.getVbaProject](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getVbaProject) aracılığıyla alınabilir;
- gömülü OLE verileri, [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) aracılığıyla alınabilir;
- ActiveX denetim verileri, [Control.getActiveXControlBinary](https://reference.aspose.com/slides/tr/python-java/aspose.slides/control/#getActiveXControlBinary) aracılığıyla alınabilir.

Yükleme sırasında bu ikili verileri kaldırmak için [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) seçeneğini `True` yapın. Temizlenmiş sonucu saklamak için yüklü sunumu kaydedin.

Bu seçenek, istenmeyen gömülü yükleri azaltır, ancak tam bir kötü amaçlı yazılım algılama veya içerik temizleme sistemi değildir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Bir dosyanın bozuk olduğunu ve açılamadığını nasıl anlarım?**

Aspose.Slides, yükleme sırasında bir ayrıştırma veya format istisnası fırlatır. Bu hatayı yanlış şifre hatasından ayrı olarak yakalayın ki uygulama nedeni doğru raporlayabilsin.

**Gerekli yazı tipleri eksik olursa ne olur?**

Sunum hâlâ yüklenebilir, ancak oluşturma ve dışa aktarma işlemleri yazı tiplerini değiştirebilir. Çıktının daha öngörülebilir olması için [yazı tipi ikamesini yapılandırabilir](/slides/tr/python-java/font-substitution/) ya da [özel yazı tipleri sağlayabilirsiniz](/slides/tr/python-java/custom-font/).

**Bir sunumu yüklemek gömülü medyasını da yükler mi?**

Gömülü ses ve video, sunum nesne modelinde erişilebilir hâle gelir. Dış kaynaklar, yapılandırılmış kaynak‑yükleme davranışına göre çözülür ve konumlarına erişilemezse kullanılabilir olmaz.