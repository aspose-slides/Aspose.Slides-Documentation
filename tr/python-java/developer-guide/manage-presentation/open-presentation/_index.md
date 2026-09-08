---
title: Python üzerinden Java ile Sunum Açma
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/python-java/open-presentation/
keywords:
- PowerPoint Aç
- Sunumu Aç
- PPTX Aç
- PPT Aç
- ODP Aç
- Sunumu Yükle
- PPTX Yükle
- PPT Yükle
- ODP Yükle
- Korunan Sunum
- Büyük Sunum
- Harici Kaynak
- İkili Nesne
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ile PowerPoint ve OpenDocument sunumlarını nasıl açacağınızı, açma şifreleri sağlayabileceğinizi, kaynak yüklemeyi kontrol edebileceğinizi ve Aspose.Slides for Python via Java ile bellek kullanımını nasıl azaltacağınızı öğrenin."
---
## **Giriş**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/tr/python-java/) PowerPoint ve OpenDocument sunumlarını dosyalardan ve akışlardan yükleyebilir. Sunum yüklendikten sonra yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka bir desteklenen formatta kaydedebilirsiniz.

Yükleme davranışı, [LoadOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/) sınıfı aracılığıyla özelleştirilebilir. Örneğin, bir açma şifresi sağlayabilir, büyük ikili nesneleri Java yığın belleği dışında tutabilir, dış kaynakları kontrol edebilir veya gömülü ikili verileri atlayabilirsiniz.

## **Sunumları Aç**

Mevcut bir sunumu açmak için dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) yapıcısına geçirin. Kullanım sonrası sunumu serbest bırakarak dosya tanıtıcıları, geçici veriler ve diğer kaynakların hızlıca serbest bırakılmasını sağlayın.

Aşağıdaki Python örneği bir sunumu nasıl açıp slayt sayısını alacağınızı gösterir:

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

Açma şifresi sunum içeriğini şifreler. Tam sunumu yüklemek için doğru şifreyi [LoadOptions.setPassword](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setPassword) metoduna aktarın ve seçenekleri [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) yapıcısına verin. Şifre eksik ya da hatalı olduğunda yükleme başarısız olur.

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

Şifre algılama, doğrulama ve şifreleme iş akışları için [Password-Protect Presentations](/slides/tr/python-java/password-protected-presentation/) bölümüne bakın. Şifreli bir sunum, kasıtlı olarak genel belge özellikleriyle kaydedildiyse, bu özellikler şifre olmadan okunabilir; daha fazla bilgi için [Manage Presentation Properties](/slides/tr/python-java/presentation-properties/) bölümüne bakın.

## **Büyük Sunumları Aç**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) yöntemi, Aspose.Slides'ın resim, ses ve video gibi büyük ikili nesneleri nasıl ele alacağını kontrol eden seçenekleri döndürür. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellekte tutulan BLOB verisinin miktarını sınırlayabilirsiniz.

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

{{% alert color="info" title="Note" %}}
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) ile kaynak dosya, sunum örneği serbest bırakılana kadar kilitli kalır. Bu örnek yaşamışken kaynak dosyayı taşıma, üzerine yazma ya da silme yapmayın.

Aspose.Slides, bir giriş akışının içeriğini yüklerken kopyalayabilir. Büyük sunumlar için dosya yolu, genellikle akıştan daha verimlidir. Ek depolama ve bellek yönetimi seçenekleri için [Manage BLOBs](/slides/tr/python-java/manage-blob/) bölümüne bakın.
{{% /alert %}}

## **Harici Kaynakları Kontrol Et**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) yöntemi, Java kaynak yükleme geri çağırma arabirimini uygulayan bir JPype vekilini kabul eder. Geri çağırma, yerine koyma verisi sağlayabilir, bir kaynağa yönlendirme yapabilir, varsayılan yükleyiciyi kullanabilir veya kaynağı atlayabilir. Bu, sunumların uygulamaya özgü güvenlik veya depolama kurallarına göre çözümlenmesi gereken harici görüntüler içerdiği durumlarda faydalıdır.

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

Bir sunum, uygulamanın ihtiyaç duymadığı veya tutmak istemediği gömülü ikili veriler içerebilir. Örnekler:

- VBA projeleri, [Presentation.getVbaProject](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getVbaProject) aracılığıyla erişilebilir;
- gömülü OLE verileri, [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) aracılığıyla erişilebilir;
- ActiveX denetim verileri, [Control.getActiveXControlBinary](https://reference.aspose.com/slides/tr/python-java/aspose.slides/control/#getActiveXControlBinary) aracılığıyla erişilebilir.

Bu ikili verileri yükleme sırasında kaldırmak için [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) özelliğini `True` olarak ayarlayın. Yüklenen sunumu kaydederek temizlenmiş sonucu kalıcı hâle getirin.

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

**Bir dosyanın bozuk olduğunu ve açılamadığını nasıl anlayabilirim?**

Aspose.Slides, yükleme sırasında bir ayrıştırma veya format istisnası fırlatır. Bu hatayı yanlış şifre hatasından ayrı olarak ele alarak uygulamanın nedeni doğru bir şekilde raporlamasını sağlayın.

**Gerekli yazı tipleri eksik olursa ne olur?**

Sunum hala yüklenebilir, ancak render ve dışa aktarım yazı tiplerini değiştirebilir. Çıktıyı daha öngörülebilir hâle getirmek için [font substitution](/slides/tr/python-java/font-substitution/) yapılandırabilir veya [custom fonts](/slides/tr/python-java/custom-font/) sağlayabilirsiniz.

**Bir sunumu yüklemek aynı zamanda gömülü medyasını da yükler mi?**

Gömülü ses ve video, sunum nesne modeli aracılığıyla erişilebilir hâle gelir. Harici kaynaklar, yapılandırılmış kaynak yükleme davranışına göre çözülür ve konumları erişilemezse kullanılamaz olabilir.