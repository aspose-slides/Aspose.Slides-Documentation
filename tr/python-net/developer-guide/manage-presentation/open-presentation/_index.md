---
title: "Python'da Sunumları Açma"
linktitle: "Sunum Açma"
type: docs
weight: 20
url: /tr/python-net/open-presentation/
keywords:
- "PowerPoint aç"
- "sunum aç"
- "PPTX aç"
- "PPT aç"
- "ODP aç"
- "sunum yükle"
- "PPTX yükle"
- "PPT yükle"
- "ODP yükle"
- "korumalı sunum"
- "büyük sunum"
- "harici kaynak"
- "ikili nesne"
- "Python"
- "Aspose.Slides"
description: "Python'da PowerPoint ve OpenDocument sunumlarını nasıl açacağınızı, açma şifreleri sağlamayı ve Aspose.Slides for Python via .NET ile bellek kullanımını azaltmayı öğrenin."
---
## **Giriş**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/tr/python-net/) PowerPoint ve OpenDocument sunumlarını dosyalardan ve akarlardan yükleyebilir. Sunum yüklendikten sonra yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka bir desteklenen formatta kaydedebilirsiniz.

Yükleme davranışı, [LoadOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/) sınıfı aracılığıyla özelleştirilebilir. Örneğin, bir açma şifresi sağlayabilir, büyük ikili nesneleri belleğin dışında tutabilir veya gömülü ikili verileri atlayabilirsiniz.

## **Sunum Açma**

Mevcut bir sunumu açmak için dosya yolunu [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) yapıcısına aktarın. Dosya tutucuları, geçici veriler ve diğer kaynakların hızlıca serbest bırakılması için bir `with` ifadesi kullanın.

Aşağıdaki Python örneği bir sunumu nasıl açıp slayt sayısını alacağınızı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Şifre Koruması Olan Sunumları Açma**

Açma şifresi, sunum içeriğini şifreler. Sunumu tamamen yüklemek için doğru şifreyi [LoadOptions.password](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/password/) özelliğine atayın ve bu seçenekleri [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) yapıcısına geçirin. Şifre eksik veya hatalı olduğunda yükleme başarısız olur.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Şifre tespiti, doğrulama ve şifreleme iş akışları için [Password-Protect Presentations](/slides/tr/python-net/password-protected-presentation/) bölümüne bakın. Şifrelenmiş bir sunum, özellikle belge özellikleri genel olarak kaydedildiyse, şifre olmadan da okunabilir; bunun için [Manage Presentation Properties](/slides/tr/python-net/presentation-properties/) bölümüne göz atın.

## **Büyük Sunumları Açma**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/blob_management_options/) Aspose.Slides’ın resim, ses ve video gibi ikili büyük nesneleri nasıl yöneteceğini denetler. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellekte tutulan BLOB verisinin miktarını sınırlayabilirsiniz.

Bu Python kodu büyük bir sunumu (örneğin 2 GB) yüklemeyi gösterir:

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
`PresentationLockingBehavior.KEEP_LOCKED` ile kaynak dosya, `Presentation` nesnesi serbest bırakılana kadar kilitli kalır. Bu nesne yaşamdayken dosyayı taşımayın, üzerine yazmayın veya silmeyin.

Aspose.Slides, bir giriş akışının içeriğini yüklerken kopyalayabilir. Büyük sunumlar için dosya yolu genellikle bir akıra göre daha verimlidir. Ek depolama ve bellek yönetimi seçenekleri için [Manage BLOBs](/slides/tr/python-net/manage-blob/) bölümüne bakın.
{{% /alert %}}

## **Gömülü İkili Nesneler Olmadan Sunum Yükleme**

Bir sunum, uygulamanın ihtiyaç duymadığı veya tutmak istemediği gömülü ikili veriler içerebilir. Örnekler:

- VBA projeleri, [Presentation.vba_project](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/vba_project/) aracılığıyla erişilebilir;
- gömülü OLE verileri, [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) aracılığıyla erişilebilir;
- ActiveX kontrol verileri, [Control.active_x_control_binary](https://reference.aspose.com/slides/tr/python-net/aspose.slides/control/active_x_control_binary/) aracılığıyla erişilebilir.

Yükleme sırasında bu ikili verileri kaldırmak için [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) özelliğini `True` olarak ayarlayın. Temizlenmiş sonucu kalıcı kılmak için yüklenen sunumu kaydedin.

Bu seçenek istenmeyen gömülü yükleri azaltır, ancak tam bir kötü amaçlı yazılım tespit veya içerik temizleme sistemi değildir.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Bir dosyanın bozuk olduğunu ve açılamadığını nasıl anlayabilirim?**

Aspose.Slides yükleme sırasında bir ayrıştırma ya da format istisnası oluşturur. Uygulamanın nedeni doğru bir şekilde raporlayabilmesi için bu hatayı, hatalı şifre hatasından ayrı ele alın.

**Gerekli yazı tipleri eksik olursa ne olur?**

Sunum yine de yüklenebilir, ancak render ve dışa aktarma sırasında yazı tipleri değiştirilir. Çıktının daha öngörülebilir olması için [yazı tipi ikamesini yapılandırabilir](/slides/tr/python-net/font-substitution/) ya da [özel yazı tipleri sağlayabilirsiniz](/slides/tr/python-net/custom-font/).

**Bir sunumu yüklemek aynı zamanda gömülü medya dosyalarını da yükler mi?**

Gömülü ses ve video, sunum nesne modeli üzerinden erişilebilir hale gelir. Harici kaynaklar, varsayılan kaynak yükleme davranışına göre çözülür ve konumlarına erişilemezse kullanılamaz.