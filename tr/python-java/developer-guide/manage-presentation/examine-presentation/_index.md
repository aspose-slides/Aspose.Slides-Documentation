---
title: Python aracılığıyla Java kullanarak Sunum Bilgilerini Al ve Güncelle
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/python-java/examine-presentation/
keywords:
- sunum biçimi
- sunum özellikleri
- belge özellikleri
- özellik al
- özellik oku
- özellik değiştir
- özellik düzenle
- özellik güncelle
- PPTX incele
- PPT incele
- ODP incele
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ile PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin; daha hızlı içgörüler ve daha akıllı içerik denetimleri için."
---
## **Genel Bakış**

Aspose.Slides bir sunumun biçimini belirleyebilir ve tam bir sunum nesne modelini oluşturmadan belge meta verilerini okuyabilir. Bu, dosyaları sınıflandırmanız, bir envanter oluşturmanız veya sunum içeriğini yükleyip işlemeye karar vermeden önce özellikleri incelemeniz gerektiğinde faydalıdır.

Örnekler, Java aracılığıyla Python için Aspose.Slides ve uyumlu bir Java çalışma ortamı gerektirir. Her örnek, JVM hâlâ çalışmıyorsa başlatır. Örneklerde kullanılan yollar üzerindeki mevcut sunum dosyalarını sağlayın.

Bu makale, hafif inceleme için [PresentationFactory](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/) ve [PresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/) ile, hedefli güncellemeler için ise [DocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/) kullanımını gösterir.

## **Sunum Biçimini Kontrol Et**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) yöntemini kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği oluşturmadan bir dosyayı inceleyebilirsiniz. [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#getLoadFormat) yöntemi, PPTX, PPT veya ODP gibi tespit edilen biçimi raporlar.

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

## **Hafif Bir Sunum Envanteri Oluştur**

Birçok sunum dosyasını işlerken, doğrulama, indeksleme veya bir belge yönetim sistemi için kompakt bir envantere ihtiyaç duyabilirsiniz. Bu senaryoda, bir [PresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/) nesnesi elde etmek için [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) kullanın ve ardından belge meta verilerini okumak için [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#readDocumentProperties) metodunu çağırın. Bu yaklaşım bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği oluşturmaz ve tam sunum nesne modelinde dolaşmayı gerektirmez.

[DocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/) tarafından sunulan genişletilmiş özellikler aşağıdaki envanter değerlerini sağlar:

| Yöntem | Envanter değeri |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getSlides) | Toplam slayt sayısı. |
| [getHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Gizli slayt sayısı. |
| [getNotes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getNotes) | Not içeren slayt sayısı. |
| [getParagraphs](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getParagraphs) | Mevcut olduğunda, toplam paragraf sayısı. |
| [getWords](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getWords) | Toplam kelime sayısı. |
| [getMultimediaClips](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Toplam ses ve video klip sayısı. |

Aşağıdaki örnek, bu değerleri bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi oluşturmadan okur ve kompakt bir envanter yazdırır. Ayrıca, yazı tipleri, temalar ve slayt başlıkları gibi içerik gruplarını göstermek için [getHeadingPairs](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getHeadingPairs) ile [getTitlesOfParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getTitlesOfParts) metodlarını birleştirir.

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

Her [HeadingPair](https://reference.aspose.com/slides/tr/python-java/aspose.slides/headingpair/) bir grup adı ve o gruptaki öğe sayısını sağlar. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getTitlesOfParts) düz, sıralı bir dizi döndürür; bu yüzden her başlık çiftinin belirttiği ardışık başlık sayısını tüketin.

### **Depolanmış Meta Veriler ve Biçim Sınırlamaları**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#readDocumentProperties) tarafından döndürülen envanter özellikleri, kaynak belgede mevcut olan meta verileri yansıtır. Aspose.Slides bu çağrı için bu değerleri yeniden hesaplamak amacıyla sunum nesne modelini yüklemez ve dolaşmaz. Eksik özellikler varsayılan değerlerle temsil edilir ve saklanan değerler, dosyayı son kaydeden uygulama belge özelliklerini güncellememişse eski olabilir.

- **PPTX:** Biçim, slayt, not, gizli slayt, paragraf, kelime ve multimedya sayımları için genişletilmiş belge özellikleri ile başlık çiftleri ve parça başlıkları sağlar. Kullanılabilirlik, belge üreticisinin hangi özellikleri yazdığına bağlıdır.
- **PPT:** İkili biçim, karşılık gelen belge özeti özelliklerini depolayabilir. Bir özellik yoksa veya belge üreticisi tarafından yenilenmemişse, Aspose.Slides onu slaytlardan hesaplamak yerine saklanan ya da varsayılan değerini döndürür.
- **ODP:** OpenDocument meta verileri, sayfa, paragraf ve kelime sayısı gibi genel belge istatistiklerini sunar, ancak bu değerler her PowerPoint‑özel genişletilmiş özelliğe karşılık gelmez. Gizli slayt, not slaytı, multimedya, başlık çifti ve parça başlığı meta verileri bulunmayabilir ve envanter özellikleri varsayılan değerler döndürebilir. Sıfır değerini veya boş bir diziyi, ilgili içeriğin mevcut olmadığına dair kesin kanıt olarak kabul etmeyin.

Envanter ve ön incelemeler için hafif meta veri yaklaşımını kullanın. Sonuç, bellekteki değişiklikleri yansıtmalıysa veya gerçek sunum içeriğini doğrulamanız gerektiğinde sunumu yükleyip canlı nesne modelini inceleyin.

## **Sunum Özelliklerini Güncelle**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#readDocumentProperties) tarafından döndürülen özellikler, bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği oluşturmadan da değiştirilebilir. Değişiklikleri [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) ile uygulayın ve ardından bağlanmış sunumu [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) ile yazın.

Aşağıdaki görsel, orijinal belge özelliklerini gösterir.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Aşağıdaki örnek, başlığı ve son kaydetme zamanını değiştirir ve sonucu yeni bir dosyaya yazar:

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

Aşağıdaki görsel, güncellenmiş belge özelliklerini gösterir.

![PowerPoint sunumunun değiştirilmiş belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

İlgili güvenlik kontrolleri ve koruma ayarları için aşağıdaki makalelere bakın:

- [Sunumları Şifreyle Koruma](/slides/tr/python-java/password-protected-presentation/)
- [Sunumları Yazma Koruması](/slides/tr/python-java/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunumu yükleyin ve [Presentation.getFontsManager](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getFontsManager) kullanın. Gömülü yazı tiplerini elde etmek için [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts), sunum tarafından kullanılan yazı tiplerini elde etmek için ise [FontsManager.getFonts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsmanager/#getFonts) metodunu çağırın. İki sonucu karşılaştırarak, render için gerekli ancak gömülü olmayan yazı tiplerini bulun.

**Dosyanın gizli slaytları olup olmadığını ve sayısını hızlıca nasıl öğrenebilirim?**

Depolanmış belge meta verileri yeterli olduğunda, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) ve [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#readDocumentProperties) aracılığıyla [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#getHiddenSlides) öğesini okuyun. Bu, hafif bir envanter için uygundur. Sunum bellekte değiştirildiyse, depolanmış meta veriler eksik veya eski olabilir veya canlı değerleri doğrulamanız gerektiğinde, [Presentation.getSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlides) üzerinden döngü yapıp her slaydın [Slide.getHidden](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getHidden) metodunu inceleyin.

**Özel slayt boyutu ve yönünün kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Sunumu yükleyin ve [Presentation.getSlideSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlideSize) metodunu çağırın. Mevcut ayarları beklenen ön ayar ve boyutlarla karşılaştırmak için [SlideSize.getType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesize/#getSize) ve [SlideSize.getOrientation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesize/#getOrientation) metodlarını kullanın.

**Grafiklerin dış veri kaynaklarına başvurup başvurmadığını hızlıca görmek için bir yol var mı?**

Evet. Her bir [Chart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/) nesnesini bulun ve [ChartData.getDataSourceType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getDataSourceType) metodunu çağırın. Dış bir çalışma kitabı için [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) metodunu kullanın. Veri kaynağı türü ve yolu dış bir referansı gösterir, ancak hedefin mevcut olup olmadığını doğrulamak ayrı bir kaynak kontrolü gerektirir.

**Render süresini veya PDF dışa aktarımını yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Tek bir karmaşıklık özelliği yoktur. [Presentation.getSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlides) ve her slaydın [BaseSlide.getShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getShapes) koleksiyonunu dolaşın. Şekil sayısını ve büyük görseller, efektler, animasyonlar veya multimedya varlığını tarama sinyalleri olarak kullanın ve bir slaytı kesin bir performans darboğazı olarak değerlendirmeden önce temsilî bir render veya dışa aktarma ölçümü yapın.