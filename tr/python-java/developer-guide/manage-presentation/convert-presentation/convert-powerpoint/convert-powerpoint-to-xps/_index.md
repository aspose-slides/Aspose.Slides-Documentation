---
title: PowerPoint Sunumlarını Python ile XPS'ye Dönüştür
linktitle: PowerPoint'tan XPS'ye
type: docs
weight: 70
url: /tr/python-java/convert-powerpoint-to-xps/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'tan XPS'ye
- sunumu XPS'ye
- PPT'den XPS'ye
- PPTX'ten XPS'ye
- PPT'yi XPS olarak kaydet
- PPTX'i XPS olarak kaydet
- PPT'yi XPS'ye aktar
- PPTX'i XPS'ye aktar
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak, Python'da PowerPoint PPT ve PPTX sunumlarını XPS'ye, varsayılan veya özel dışa aktarma ayarlarıyla dönüştürün."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, PPT veya PPTX dosyasını XPS formatında kaydederek PowerPoint sunumlarını XPS'ye dönüştürmenizi sağlar. Bu makale, XPS'nin ne zaman yararlı olabileceğini açıklar ve bir sunumu varsayılan ayarlarla veya özel [XpsOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xpsoptions/) ayarlarıyla dışa aktarmanın yollarını gösterir.

## **XPS Hakkında**

XPS (XML Paper Specification), Microsoft tarafından geliştirilen XML tabanlı bir belge formatıdır. Sabit sayfaları tanımlar, metin ve grafik düzenini uyumlu yazılımlarla görüntüleme ve yazdırma için korur.

## **Microsoft XPS Formatı Ne Zaman Kullanılır**

XPS'yi, belge iş akışının paylaşımlı veya yazdırma amaçlı sabit sayfa dosyalarına ihtiyaç duyduğu ve XPS uyumlu araçlarla kullanılacağı zaman kullanın. Alıcıların XPS'yi destekleyen bir yazılıma ihtiyacı vardır. İş akışınız PDF gerektiriyorsa, [Convert PowerPoint to PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/) bölümüne bakın.

{{% alert color="info" title="Not" %}}
PPT veya PPTX sunumunu XPS'ye dönüştürmeyi denemek için [ücretsiz çevrimiçi dönüştürücü](https://products.aspose.app/slides/tr/conversion) kullanın.
{{% /alert %}}

| Giriş PowerPoint sunumu | Çıktı XPS belgesi |
| --- | --- |
| ![Orijinal PowerPoint sunumu](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![XPS'ye dönüştürülmüş sunum](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **Aspose.Slides ile XPS Dönüştürmesi**

Bir sunumu dışa aktarmak için [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının [save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunu [SaveFormat.Xps](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#Xps) ile kullanın. Varsayılan dışa aktarma ayarlarını kullanabilir veya çıkışı özelleştirmek için [XpsOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xpsoptions/) sağlayabilirsiniz.

Aşağıdaki her örnek, gerekirse Java sanal makinesini başlatır ve kullanım sonrası sunumu serbest bırakır. Giriş dosya adını PPT veya PPTX dosyanızın yolu ile değiştirin.

### **Varsayılan Ayarlarla Sunumları XPS'ye Dönüştürme**

Aşağıdaki Python kodu, bir sunumu varsayılan ayarları kullanarak XPS'ye dönüştürür:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Sunumu XPS belgesi olarak kaydet.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **Özel Ayarlarla Sunumları XPS'ye Dönüştürme**

Aşağıdaki örnek, oluşan XPS belgesinde metafile'ları PNG görüntüleri olarak kaydetmek için [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) kullanır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # Sunumu özel XPS ayarlarıyla kaydet.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **SSS**

**XPS'yi bir dosya yerine akışa kaydedebilir miyim?**

Evet. [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metodunun Java çıktı akışı kabul eden aşırı yüklemeleri vardır. Python via Java ile, JPype üzerinden uyumlu bir Java akışı, örneğin bir Java bayt‑dizisi çıktı akışı kullanarak dışa aktarılan veriyi bellekte tutabilirsiniz.

**Gizli slaytlar XPS çıktısına dahil edilir mi?**

Gizli slaytlar varsayılan olarak dışarıda bırakılır. Bunları dahil etmek için, kaydetmeden önce [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) değerini `True` olarak ayarlayın.

**Animasyonlar ve slayt geçişleri XPS'de korunur mu?**

Hayır. XPS sabit sayfalar içerdiği için, dışa aktarılan slaytlar animasyonları veya geçiş efektlerini oynatmaz.