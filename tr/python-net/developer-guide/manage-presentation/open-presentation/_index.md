---
title: Python'da Sunum Açma
linktitle: Sunum Açma
type: docs
weight: 20
url: /tr/python-net/open-presentation/
keywords:
- PowerPoint açma
- sunum açma
- PPTX aç
- PPT aç
- ODP aç
- sunum yükleme
- PPTX yükleme
- PPT yükleme
- ODP yükleme
- korumalı sunum
- büyük sunum
- harici kaynak
- ikili nesne
- Python
- Aspose.Slides
description: "Python'da PowerPoint ve OpenDocument sunumlarını nasıl açacağınızı, açma parolalarını nasıl sağlayacağınızı ve Aspose.Slides for Python via .NET ile bellek kullanımını nasıl azaltacağınızı öğrenin."
---
## **Giriş**

Aspose.Slides for Python via .NET, dosyalar ve akışlardan PowerPoint ve OpenDocument sunumlarını yükleyebilir. Bir sunum yüklendikten sonra, yapısını inceleyebilir, slaytları düzenleyebilir, kaynakları yönetebilir ve orijinal ya da başka desteklenen bir biçimde kaydedebilirsiniz.

Yükleme davranışı, LoadOptions sınıfı aracılığıyla özelleştirilebilir. Örneğin, açma parolası belirtebilir, büyük ikili nesneleri bellekte tutmayabilir veya gömülü ikili verileri atlayabilirsiniz.

## **Sunumları Açma**

Bir dosya veya akışı yükledikten sonra, uygulamanızın onu nasıl işleyeceğini seçmek için [orijinal sunum biçimini belirleyebilirsiniz](/slides/tr/python-net/detect-presentation-source-format/).

Mevcut bir sunumu açmak için dosya yolunu Presentation yapıcısına geçirin. Dosya tutucuları, geçici veriler ve diğer kaynakların hızlıca serbest bırakılması için bir `with` ifadesi kullanın.

Aşağıdaki Python örneği, bir sunumu nasıl açıp slayt sayısını alacağınızı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Parola Korumalı Sunumları Açma**

Açma parolası, sunum içeriğini şifreler. Sunumu tamamen yüklemek için doğru parolayı LoadOptions.password özelliğine atayın ve seçenekleri Presentation yapıcısına geçirin. Parola eksik ya da hatalı olduğunda yükleme başarısız olur.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Parola algılama, doğrulama ve şifreleme iş akışları için [Parola ile Korunan Sunumlar](/slides/tr/python-net/password-protected-presentation/) bölümüne bakın. Şifrelenmiş bir sunum kasıtlı olarak genel belge özellikleriyle kaydedildiyse, bu özellikler parola olmadan okunabilir; bkz. [Sunum Özelliklerini Yönetme](/slides/tr/python-net/presentation-properties/).

## **Büyük Sunumları Açma**

[LoadOptions.blob_management_options] Aspose.Slides'in resimler, ses ve video gibi büyük ikili nesneleri nasıl yönettiğini kontrol eder. Kaynak dosyayı kilitli tutabilir, geçici dosyalara izin verebilir ve bellekte tutulan BLOB veri miktarını sınırlayabilirsiniz.

Bu Python kodu, büyük bir sunumu (örneğin 2 GB) yüklemeyi gösterir:

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
`PresentationLockingBehavior.KEEP_LOCKED` ile kaynak dosya, `Presentation` nesnesi serbest bırakılana kadar kilitli kalır. Bu nesne hâlâ mevcutken kaynak dosyayı taşımayın, üzerine yazmayın veya silmeyin.

Aspose.Slides, yükleme sırasında bir giriş akışının içeriğini kopyalayabilir. Büyük sunumlar için dosya yolu genellikle akışa göre daha verimlidir. Ek depolama ve bellek yönetimi seçenekleri için [BLOB'ları Yönetme](/slides/tr/python-net/manage-blob/) bölümüne bakın.
{{% /alert %}}

## **Gömülü İkili Nesneler Olmadan Sunumları Yükleme**

Bir sunum, bir uygulamanın ihtiyacı olmayan veya tutmak istemediği gömülü ikili veriler içerebilir. Örnekler:

- VBA projeleri, Presentation.vba_project aracılığıyla erişilebilir;
- gömülü OLE verileri, OleEmbeddedDataInfo.embedded_file_data aracılığıyla erişilebilir;
- ActiveX kontrol verileri, Control.active_x_control_binary aracılığıyla erişilebilir.

Yükleme sırasında bu ikili verileri kaldırmak için LoadOptions.delete_embedded_binary_objects özelliğini `True` olarak ayarlayın. Temizlenmiş sonucu kalıcı hale getirmek için yüklenen sunumu kaydedin.

Bu seçenek, istenmeyen gömülü içeriklere maruziyeti azaltır, ancak tam bir kötü yazılım tespiti veya içerik temizleme sistemi değildir.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Bir dosyanın bozuk olduğunu ve açılamadığını nasıl anlayabilirim?**  
Aspose.Slides, yükleme sırasında bir ayrıştırma veya biçim istisnası fırlatır. Bu hatayı, hatalı parola hatasından ayrı olarak ele alın, böylece uygulama nedeni doğru şekilde raporlayabilir.

**Gerekli yazı tipleri eksik olursa ne olur?**  
Sunum yine de yüklenebilir, ancak renderleme ve dışa aktarma yazı tiplerini değiştirebilir. Çıktının daha öngörülebilir olması için [yazı tipi ikamesini yapılandırabilir](/slides/tr/python-net/font-substitution/) veya [özel yazı tipleri sağlayabilirsiniz](/slides/tr/python-net/custom-font/).

**Bir sunumu yüklemek, gömülü medyalarını da yükler mi?**  
Gömülü ses ve video, sunum nesne modeli aracılığıyla erişilebilir hale gelir. Dış kaynaklar, varsayılan kaynak yükleme davranışına göre çözülür ve konumlarına erişilemezse kullanılamaz olabilir.