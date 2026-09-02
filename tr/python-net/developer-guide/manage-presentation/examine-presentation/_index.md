---
title: Python'da Sunum Bilgilerini Getirme ve Güncelleme
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/python-net/examine-presentation/
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
- Aspose.Slides
description: "Python kullanarak PowerPoint ve OpenDocument sunumlarındaki slaytları, yapıyı ve üst verileri keşfedin, daha hızlı içgörüler ve daha akıllı içerik denetimleri için."
---
## **Genel Bakış**

Aspose.Slides, bir sunumun formatını tanımlayabilir ve tam bir sunum nesne modelini oluşturmadan belge üst verilerini okuyabilir. Bu, dosyaları sınıflandırmanız, bir envanter oluşturmanız veya sunum içeriğini yükleyip işlemeye karar vermeden önce özellikleri incelemeniz gerektiğinde yararlıdır.

Bu makale, hafif denetimi [PresentationFactory](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/) ve [PresentationInfo](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/) aracılığıyla, ayrıca [DocumentProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/) üzerinden hedeflenmiş güncellemeleri gösterir.

## **Sunum Formatını Kontrol Et**

Bir dosyayı, bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturmadan denetlemek için [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/get_presentation_info/) kullanın. [PresentationInfo.load_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/load_format/) özelliği, PPTX, PPT veya ODP gibi algılanan formatı raporlar.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Hafif Sunum Envanteri Oluştur**

Birçok sunum dosyasını işlediğinizde, doğrulama, indeksleme veya belge yönetim sistemi için kompakt bir envantere ihtiyaç duyabilirsiniz. Bu senaryoda, bir [PresentationInfo](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/) nesnesi elde etmek için [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/get_presentation_info/) kullanın ve ardından belge üst verilerini okumak için [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/read_document_properties/) çağırın. Bu yaklaşım, bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturmaz ve tam sunum nesne modelini dolaşmanızı gerektirmez.

[DocumentProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/) tarafından sunulan genişletilmiş özellikler aşağıdaki envanter değerlerini sağlar:

| Özellik | Envanter değeri |
| --- | --- |
| [slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/slides/tr/) | Toplam slayt sayısı. |
| [hidden_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/hidden_slides/) | Gizli slayt sayısı. |
| [notes](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/notes/) | Not içeren slayt sayısı. |
| [paragraphs](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/paragraphs/) | Mevcut olduğunda toplam paragraf sayısı. |
| [words](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/words/) | Toplam kelime sayısı. |
| [multimedia_clips](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/multimedia_clips/) | Toplam ses ve video klip sayısı. |

Aşağıdaki örnek, bu değerleri bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesi oluşturmadan okur ve kompakt bir envanter yazdırır. Ayrıca, [heading_pairs](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/heading_pairs/) ile [titles_of_parts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/titles_of_parts/) birleştirerek yazı tipleri, temalar ve slayt başlıkları gibi içerik gruplarını gösterir.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

Her [HeadingPair](https://reference.aspose.com/slides/tr/python-net/aspose.slides/headingpair/) bir grup adı ve o gruptaki öğe sayısını sağlar. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/titles_of_parts/) düz, sıralı bir koleksiyondur; bu nedenle her başlık çiftinin belirttiği ardışık başlık sayısını tüketin.

### **Depolanmış Üst Veri ve Format Sınırlamaları**

[PresentationInfo.read_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/read_document_properties/) tarafından döndürülen envanter özellikleri, kaynak belgede mevcut olan üst verileri yansıtır. Aspose.Slides, bu çağrı için bu değerleri yeniden hesaplamak amacıyla sunum nesne modelini yükleyip dolaşmaz. Eksik özellikler varsayılan değerlerle temsil edilir ve son kaydeden uygulama belge özelliklerini güncellememişse, depolanan değerler eski olabilir.

- **PPTX:** Format, slayt, not, gizli slayt, paragraf, kelime ve multimedya sayımları için genişletilmiş belge özellikleri ile başlık çiftleri ve bölüm başlıklarını sağlar. Kullanılabilirlik, belge üreticisinin hangi özellikleri yazdığına bağlıdır.
- **PPT:** İkili format, ilgili belge özeti özelliklerini depolayabilir. Bir özellik eksikse veya belge üreticisi tarafından yenilenmemişse, Aspose.Slides, slaytlardan hesaplamak yerine depolanmış ya da varsayılan değerini döndürür.
- **ODP:** OpenDocument üst verileri, sayfa, paragraf ve kelime sayısı gibi genel belge istatistikleri sağlar, ancak bu değerler her PowerPoint'e özgü genişletilmiş özelliğe karşılık gelmez. Gizli slayt, not slaytı, multimedya, başlık çifti ve bölüm başlığı üst verileri mevcut olmayabilir ve envanter özellikleri varsayılan değerler döndürebilir. Sıfır değeri ya da boş bir koleksiyonu, ilgili içeriğin yok olduğuna dair kesin kanıt olarak değerlendirmeyin.

Hafif üst veri yaklaşımını envanterler ve ön kontroller için kullanın. Sonucun bellek içi değişiklikleri yansıtması gerektiğinde veya gerçek sunum içeriğini doğrulamanız gerektiğinde sunumu yükleyin ve canlı nesne modelini inceleyin.

## **Sunum Özelliklerini Güncelle**

[PresentationInfo.read_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/read_document_properties/) tarafından döndürülen özellikler, bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturmadan da değiştirilebilir. Değişiklikleri [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/update_document_properties/) ile uygulayın ve ardından bağlanmış sunumu [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/write_binded_presentation/) ile yazın.

Aşağıdaki resim, orijinal belge özelliklerini gösterir.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Aşağıdaki örnek, başlığı ve son kaydedilme zamanını değiştirir ve sonucu yeni bir dosyaya yazar:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

Aşağıdaki resim, güncellenmiş belge özelliklerini gösterir.

![PowerPoint sunumunun değiştirilmiş belge özellikleri](output_properties.png)

## **Yararlı Bağlantılar**

- [Sunumları Şifreyle Koru](/slides/tr/python-net/password-protected-presentation/)
- [Sunumları Yazma Korumasıyla Koru](/slides/tr/python-net/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunumu yükleyin ve [Presentation.fonts_manager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/fonts_manager/) kullanın. Gömülü yazı tiplerini elde etmek için [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) ve sunumda kullanılan yazı tiplerini elde etmek için [FontsManager.get_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_fonts/) çağırın. İki sonucu karşılaştırarak, render için gerekli ama gömülü olmayan yazı tiplerini bulun.

**Dosyanın gizli slaytları olup olmadığını ve kaç tane olduğunu hızlıca nasıl öğrenebilirim?**

Depolanan belge üst verileri yeterli olduğunda, [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/get_presentation_info/) ve [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/read_document_properties/) aracılığıyla [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/hidden_slides/) okuyun. Bu, hafif bir envanter için uygundur. Sunum bellek içinde değiştirildiyse, depolanan üst veriler eksik veya eski olabilir ya da canlı değerleri doğrulamanız gerekiyorsa, [Presentation.slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/slides/tr/) içinde döngü yaparak her slaydın [Slide.hidden](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/hidden/) özelliğini inceleyin.

**Özel slayt boyutu ve yönünün kullanıldığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Sunumu yükleyin ve [Presentation.slide_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/slide_size/) okuyun. Geçerli ayarları beklenen ön ayar ve boyutlarla karşılaştırmak için [SlideSize.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesize/size/) ve [SlideSize.orientation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesize/orientation/) inceleyin.

**Grafiklerin dış veri kaynaklarına başvurup başvurmadığını hızlı bir şekilde görmenin bir yolu var mı?**

Evet. Her [Chart](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/) öğesini bulun ve [ChartData.data_source_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/data_source_type/) inceleyin. Dış bir çalışma kitabı için [ChartData.external_workbook_path](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) okuyun. Veri kaynağı türü ve yolu, dış bir referansı tanımlar, ancak hedefin erişilebilir olup olmadığını doğrulamak ayrı bir kaynak kontrolü gerektirir.

**Render veya PDF dışa aktarma işlemlerini yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Tek bir karmaşıklık özelliği yoktur. [Presentation.slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/slides/tr/) ve her slaydın [BaseSlide.shapes](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/shapes/) koleksiyonunu dolaşın. Şekil sayısını ve büyük görseller, efektler, animasyonlar veya multimedya varlığını tarama sinyalleri olarak kullanın ve bir slaydın performans darboğazı olduğuna karar vermeden önce temsilci bir render veya dışa aktarma ölçümü yapın.