---
title: Python üzerinden Java ile Sunum Bilgilerini Al ve Güncelle
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/python-java/examine-presentation/
keywords:
- sunum formatı
- sunum özellikleri
- belge özellikleri
- özellikleri al
- özellikleri oku
- özellikleri değiştir
- özellikleri düzenle
- özellikleri güncelle
- PPTX incele
- PPT incele
- ODP incele
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin, daha hızlı içgörüler ve daha akıllı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumun biçimini tanımlayabilir ve tam bir sunum nesne modelini oluşturmadan belge meta verilerini okuyabilir. Bu, dosyaları sınıflandırmanız, bir envanter oluşturmanız veya sunum içeriğini yükleyip işlemeye karar vermeden önce özellikleri incelemeniz gerektiğinde kullanışlıdır.

Örnekler, Java aracılığıyla Python için Aspose.Slides ve uyumlu bir Java çalışma zamanına ihtiyaç duyar. Her örnek, JVM hâlâ çalışmıyorsa başlatır. Örneklerde kullanılan yollarda mevcut sunum dosyalarını sağlayın.

Bu makale, hafif denetimi [PresentationFactory](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/) ve [PresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/) aracılığıyla, ayrıca hedeflenmiş güncellemeleri [DocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/) ile göstermektedir.

## **Sunum Biçimini Kontrol Et**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) kullanarak bir dosyayı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği oluşturmadan inceleyebilirsiniz. [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#getLoadFormat) yöntemi, tespit edilen biçimi, örneğin PPTX, PPT veya ODP olarak raporlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Hafif Sunum Envanteri Oluştur**

Birçok sunum dosyasını işlerken, doğrulama, indeksleme veya belge‑yönetim sistemi için kompakt bir envantere ihtiyacınız olabilir. Bu senaryoda, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) kullanarak bir [PresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/) nesnesi elde edin ve ardından [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#readDocumentProperties) çağrısıyla belge meta verilerini okuyun. Bu yaklaşım bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği oluşturmaz ve tam sunum nesne modelini dolaşmanızı gerektirmez.

[DocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/) tarafından sağlanan genişletilmiş özellikler aşağıdaki envanter değerlerini sunar:

| Yöntem | Envanter değeri |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getSlides) | Toplam slayt sayısı. |
| [getHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Gizli slaytların sayısı. |
| [getNotes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getNotes) | Not içeren slaytların sayısı. |
| [getParagraphs](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getParagraphs) | Mevcut olduğunda toplam paragraf sayısı. |
| [getWords](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getWords) | Toplam kelime sayısı. |
| [getMultimediaClips](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Toplam ses ve video klip sayısı. |

Aşağıdaki örnek bu değerleri bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi oluşturulmadan okur ve kompakt bir envanter yazdırır. Ayrıca [getHeadingPairs](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getHeadingPairs) ile [getTitlesOfParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getTitlesOfParts) birleştirilerek yazı tipleri, temalar ve slayt başlıkları gibi içerik grupları gösterilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Her [HeadingPair](https://reference.aspose.com/slides/tr/python-java/aspose.slides/headingpair/) bir grup adı ve o gruptaki öğe sayısını sağlar. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getTitlesOfParts) düz, sıralı bir dizi döndürdüğü için her başlık çiftinde belirtilen ardışık başlık sayısını tüketin.

### **Depolanmış Meta Veriler ve Biçim Sınırlamaları**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#readDocumentProperties) tarafından döndürülen envanter özellikleri, kaynak belgede kullanılabilir meta verileri yansıtır. Aspose.Slides bu çağrı için bu değerleri yeniden hesaplamak üzere sunum nesne modelini yüklemez ve dolaşmaz. Eksik özellikler varsayılan değerlerle temsil edilir ve saklanan değerler, dosyayı son kaydeden uygulama belge özelliklerini güncellememişse eski olabilir.

- **PPTX:** Biçim, slayt, not, gizli‑slayt, paragraf, kelime ve multimedya sayıları ile başlık çiftleri ve parça başlıkları için genişletilmiş belge özellikleri sağlar. Kullanılabilirlik, belge üreticisinin hangi özellikleri yazdığına bağlıdır.
- **PPT:** İkili biçim, karşılık gelen belge‑özet özelliklerini depolayabilir. Bir özellik eksikse veya belge üreticisi tarafından yenilenmemişse, Aspose.Slides onu slaytlardan hesaplamak yerine saklanan veya varsayılan değerini döndürür.
- **ODP:** OpenDocument meta verileri, sayfa, paragraf ve kelime sayısı gibi genel belge istatistikleri sunar, ancak bu değerler her PowerPoint‑özel genişletilmiş özelliğe karşılık gelmez. Gizli‑slayt, not‑slaytı, multimedya, başlık‑çifti ve parça‑başlığı meta verileri mevcut olmayabilir ve envanter özellikleri varsayılan değer döndürebilir. Sıfır değeri veya boş dizi, ilgili içeriğin yok olduğuna dair kesin kanıt olarak kabul edilmemelidir.

Envanterler ve ön kontrol için hafif meta veri yaklaşımını kullanın. Sonucun bellekteki değişiklikleri yansıtması gerektiğinde veya gerçek sunum içeriğini doğrulamanız gerektiğinde sunumu yükleyin ve canlı nesne modelini inceleyin.

## **Sunum Özelliklerini Güncelle**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#readDocumentProperties) tarafından döndürülen özellikler, bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği oluşturmadan da değiştirilebilir. Değişiklikleri [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) ile uygulayın ve ardından bağlı sunumu [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) ile yazın.

Aşağıdaki resim, PowerPoint sunumunun orijinal belge özelliklerini gösterir.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Aşağıdaki örnek, başlığı ve son kaydedilme zamanını değiştirir ve sonucu yeni bir dosyaya yazar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

Aşağıdaki resim, PowerPoint sunumunun değiştirilmiş belge özelliklerini gösterir.

![PowerPoint sunumunun değiştirilmiş belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

İlgili güvenlik kontrolleri ve koruma ayarları için aşağıdaki makalelere göz atın:

- [Sunumları Şifrele](/slides/tr/python-java/password-protected-presentation/)
- [Sunumları Yazma Koruması](/slides/tr/python-java/write-protected-presentation/)

## **SSS**

**Yerleşik yazı tipleri olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunumu yükleyin ve [Presentation.getFontsManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getFontsManager) kullanın. Yerleşik yazı tiplerini elde etmek için [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts), sunumda kullanılan yazı tiplerini elde etmek için ise [FontsManager.getFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getFonts) çağırın. Renderlama için gerekli ancak yerleşik olmayan yazı tiplerini bulmak amacıyla iki sonucu karşılaştırın.

**Dosyanın gizli slaytları olup olmadığını ve sayısını hızlıca nasıl öğrenebilirim?**

Depolanmış belge meta verileri yeterli olduğunda, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) ve [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#readDocumentProperties) aracılığıyla [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getHiddenSlides) okunabilir. Bu, hafif bir envanter için uygundur. Sunum bellek içinde değiştirilmişse, saklanan meta veriler eksik veya eski olabilir; bu durumda canlı değerleri doğrulamak için [Presentation.getSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlides) üzerinden dolaşıp her slaytın [Slide.getHidden](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getHidden) metodunu inceleyin.

**Özel slayt boyutu ve yönünün kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Sunumu yükleyin ve [Presentation.getSlideSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlideSize) çağırın. Mevcut ayarları beklenen ön ayar ve boyutlarla karşılaştırmak için [SlideSize.getType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesize/#getSize) ve [SlideSize.getOrientation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesize/#getOrientation) kullanın.

**Grafiklerin harici veri kaynaklarına başvurup başvurmadığını hızlıca görmenin bir yolu var mı?**

Evet. Her bir [Chart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/) bulun ve [ChartData.getDataSourceType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getDataSourceType) çağır. Harici bir çalışma kitabı için [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) metodunu kullan. Veri kaynağı türü ve yolu dış referansı gösterir, ancak hedefin erişilebilir olup olmadığını doğrulamak ayrı bir kaynak kontrolü gerektirir.

**Renderlama veya PDF dışa aktarmayı yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Tek bir karmaşıklık özelliği yoktur. [Presentation.getSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlides) ve her slaytın [BaseSlide.getShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getShapes) koleksiyonunu dolaşı. Şekil sayısı, büyük görseller, efektler, animasyonlar veya multimedya varlığı gibi sinyalleri tarama göstergesi olarak kullanın ve bir slaytı kesin bir performans darboğazı olarak kabul etmeden önce temsilî bir render veya dışa aktarım ölçümü yapın.