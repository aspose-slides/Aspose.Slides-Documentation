---
title: Python via Java ile Sunumları XAML'e Dışa Aktarma
linktitle: Sunumu XAML'e
type: docs
weight: 30
url: /tr/python-java/export-to-xaml/
keywords:
- PowerPoint'i dışa aktar
- OpenDocument'i dışa aktar
- sunumu dışa aktar
- PowerPoint'i dönüştür
- OpenDocument'i dönüştür
- sunumu dönüştür
- PowerPoint'ten XAML'e
- OpenDocument'ten XAML'e
- sunumdan XAML'e
- PPT'den XAML'e
- PPTX'ten XAML'e
- ODP'den XAML'e
- PPT'yi XAML olarak kaydet
- PPTX'i XAML olarak kaydet
- ODP'yi XAML olarak kaydet
- PPT'yi XAML'e dışa aktar
- PPTX'i XAML'e dışa aktar
- ODP'yi XAML'e dışa aktar
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint ve OpenDocument sunumlarını XAML'e dışa aktarın. Varsayılan seçenekleri kullanın veya gizli slaytları dahil edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument sunumlarını XAML'e nasıl dışa aktarılacağını açıklar. XAML'i tanıtır, varsayılan ayarlarla nasıl dışa aktarılacağını gösterir ve gizli slaytların [XamlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/) ile nasıl dahil edileceğini gösterir.

Örnekler, Aspose.Slides for Python via Java ve uyumlu bir Java çalışma zamanı gerektirir. `pres.pptx` dosyasını geçerli çalışma dizinine yerleştirin. Her örnek, JVM zaten çalışmıyorsa başlatır.

## **XAML Hakkında**

XAML (Extensible Application Markup Language), kullanıcı arayüzlerini tanımlamak için XML tabanlı bir dildir. Windows Presentation Foundation (WPF) gibi çerçeveler tarafından kullanılır. XAML'i görsel bir tasarımcı veya metin editörü ile oluşturabilir ve düzenleyebilirsiniz.

## **Sunumları XAML'e Varsayılan Seçeneklerle Dışa Aktar**

Girdi dosyasından bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) oluşturun, ardından varsayılan ayarlarla dışa aktarmak için [XamlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/) nesnesini [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) metoduna geçirin:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Sunumları XAML'e Özel Seçeneklerle Dışa Aktar**

[XamlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/) kullanarak dışa aktarmayı yapılandırın. Gizli slaytları dahil etmek için, kaydetmeden önce `True` ile [setExportHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) metodunu çağırın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **SSS**

**Orijinal yazı tipi mevcut olmadığında yedek bir yazı tipi nasıl seçebilirim?**

[setDefaultRegularFont](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) metodunu [XamlOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/) nesnenizde yedek bir yazı tipi belirlemek için kullanın. Seçilen yazı tipinin dışa aktarma ortamında mevcut olduğundan emin olun.

**Dışa aktarılan işaretlemeyi herhangi bir XAML çerçevesinde kullanabilir miyim?**

XAML çerçeveleri, destekledikleri öğeler ve özellikler bakımından farklılık gösterir. İşaretlemeyi bir uygulamaya entegre etmeden önce hedef çerçevenizde test edin.

**Gizli slaytlar varsayılan olarak dışa aktarılır mı?**

Hayır. Bunları dahil etmek için [setExportHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) metodunu `True` ile çağırın. Hariç tutmak için `False` olarak bırakın.