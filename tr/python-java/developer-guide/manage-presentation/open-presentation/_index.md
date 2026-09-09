---
title: Python aracılığıyla Java ile Sunumları Açma
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/python-java/open-presentation/
keywords:
- PowerPoint Aç
- Sunum Aç
- PPTX Aç
- PPT Aç
- ODP Aç
- Sunumu Yükle
- PPTX Yükle
- PPT Yükle
- ODP Yükle
- Korunmuş Sunum
- Büyük Sunum
- Harici Kaynak
- İkili Nesne
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ile PowerPoint ve OpenDocument sunumlarını nasıl açacağınızı, açma şifreleri sağlayarak, kaynak yüklemeyi kontrol ederek ve Aspose.Slides for Python via Java ile bellek kullanımını nasıl azaltacağınızı öğrenin."
---
## **Giriş**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/tr/python-java/) dosyalar ve akışlardan PowerPoint ve OpenDocument sunumlarını yükleyebilir. Bir sunum yüklendikten sonra yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka bir desteklenen formatta kaydedebilirsiniz.

Yükleme davranışı, [LoadOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/) sınıfı aracılığıyla özelleştirilebilir. Örneğin, bir açma parolası belirleyebilir, büyük ikili nesneleri Java yığını dışına tutabilir, harici kaynakları kontrol edebilir ya da gömülü ikili verileri atlayabilirsiniz.

## **Sunumları Aç**

Mevcut bir sunumu açmak için dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) yapıcısına geçirin. Dosya tutamaçları, geçici veriler ve diğer kaynakların hızlıca serbest bırakılması için sunumu kullanım sonrası serbest bırakın.

Aşağıdaki Python örneği bir sunumu nasıl açıp slayt sayısını alabileceğinizi gösterir:

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

## **Şifre Koruması Olan Sunumları Aç**

Açma parolası sunum içeriğini şifreler. Tam sunumu yüklemek için doğru parolayı [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setPassword) metoduna geçirip seçenekleri [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) yapıcısına sağlayın. Parola eksik ya da hatalı olduğunda yükleme başarısız olur.

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

Parola algılama, doğrulama ve şifreleme iş akışları için [Password-Protect Presentations](/slides/tr/python-java/password-protected-presentation/) sayfasına bakın. Şifreli bir sunum, kasıtlı olarak herkese açık belge özellikleriyle kaydedildiyse, bu özellikler parola olmadan okunabilir; bunun için [Manage Presentation Properties](/slides/tr/python-java/presentation-properties/) bölümüne bakın.

## **Büyük Sunumları Aç**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) yöntemi, Aspose.Slides'ın görüntüler, ses ve video gibi büyük ikili nesneleri nasıl ele aldığını kontrol eden seçenekleri döndürür. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellekte tutulan BLOB veri miktarını sınırlayabilirsiniz.

Aşağıdaki Python kodu büyük bir sunumu (örneğin 2 GB) yüklemeyi gösterir:

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

[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) ile kaynak dosya, sunum örneği serbest bırakılana kadar kilitli kalır. Bu örnek yaşam süresi boyunca kaynak dosyayı taşıma, üzerine yazma veya silme yapmayın.

Aspose.Slides, bir giriş akışının içeriğini yüklerken kopyalayabilir. Büyük sunumlar için dosya yolu, akışa göre genellikle daha verimlidir. Ek depolama ve bellek yönetimi seçenekleri için [Manage BLOBs](/slides/tr/python-java/manage-blob/) sayfasına bakın.

{{% /alert %}}

## **Harici Kaynakları Kontrol Et**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) metodu, Java kaynak yükleme geri arama arayüzünü uygulayan bir JPype vekilini kabul eder. Geri arama, yerine koyma verisi sağlayabilir, bir kaynağı yönlendirebilir, varsayılan yükleyiciyi kullanabilir veya kaynağı atlayabilir. Bu, sunumların uygulamaya özgü güvenlik veya depolama kurallarına göre çözülmesi gereken harici görseller içerdiği durumlarda faydalıdır.

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

## **Gömülü İkili Nesneler Olmadan Sunumları Yükle**

Bir sunum, uygulamanın ihtiyaç duymadığı veya tutmak istemediği gömülü ikili veri içerebilir. Örnekler:

- VBA projeleri, [Presentation.getVbaProject](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getVbaProject) üzerinden erişilebilir;
- gömülü OLE verileri, [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) üzerinden erişilebilir;
- ActiveX kontrol verileri, [Control.getActiveXControlBinary](https://reference.aspose.com/slides/tr/python-java/aspose.slides/control/#getActiveXControlBinary) üzerinden erişilebilir.

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) özelliğini `True` olarak ayarlayarak bu ikili verileri yükleme sırasında kaldırın. Temizlenmiş sonucu kalıcı kılmak için yüklü sunumu kaydedin.

Bu seçenek istenmeyen gömülü yükleri azaltır, ancak tam bir kötü amaçlı yazılım tespiti veya içerik temizleme sistemi değildir.

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

**Bir dosyanın bozuk olduğunu ve açılamadığını nasıl anlayabilirim?**

Aspose.Slides, yükleme sırasında bir ayrıştırma veya format istisnası fırlatır. Bu hatayı hatalı parola hatasından ayrı şekilde ele alın ki uygulama nedeni doğru raporlayabilsin.

**Gerekli yazı tipleri eksik olduğunda ne olur?**

Sunum hâlâ yüklenebilir, ancak yürütme ve dışa aktarım yazı tiplerini değiştirebilir. Çıktının daha öngörülebilir olması için [yazı tipi ikamesi yapılandırmasını](/slides/tr/python-java/font-substitution/) veya [özel yazı tipleri sağlamayı](/slides/tr/python-java/custom-font/) kullanabilirsiniz.

**Bir sunumu yüklemek aynı zamanda gömülü medyasını da yükler mi?**

Gömülü ses ve video, sunum nesne modeli aracılığıyla kullanılabilir hale gelir. Harici kaynaklar, yapılandırılmış kaynak yükleme davranışına göre çözülür ve konumlarına erişilemezse kullanılamaz olabilir.