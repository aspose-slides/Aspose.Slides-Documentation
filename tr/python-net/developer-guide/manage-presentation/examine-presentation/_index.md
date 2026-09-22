---
title: "Python'da Sunum Bilgilerini Al ve Güncelle"
linktitle: "Sunum Bilgileri"
type: docs
weight: 30
url: /tr/python-net/examine-presentation/
keywords:
- sunum biçimi
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
description: "Python kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin, daha hızlı içgörüler ve akıllı içerik denetimleri elde edin."
---
## **Genel Bakış**

Aspose.Slides, bir sunumun biçimini tanımlayabilir ve tam bir sunum nesne modelini oluşturmadan belge meta verilerini okuyabilir. Bu, dosyaları sınıflandırmanız, bir envanter oluşturmanız veya sunum içeriğini yükleyip işlemeye karar vermeden önce özellikleri incelemeniz gerektiğinde kullanışlıdır.

Bu makale, [PresentationFactory](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/) ve [PresentationInfo](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/) aracılığıyla hafif denetimi, ayrıca [DocumentProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/) aracılığıyla hedeflenmiş güncellemeleri gösterir.

## **Sunum Biçimini Kontrol Et**

Zaten yüklü bir sunumunuz varsa, yükleme sonrasında tespit için [Orijinal Sunum Biçimini Belirle](/slides/tr/python-net/detect-presentation-source-format/) ve eski PPT, PPS ve POT akışlarının sınırlamaları bölümüne bakınız.

[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/get_presentation_info/) kullanarak bir dosyayı [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturmadan inceleyebilirsiniz. [PresentationInfo.load_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/load_format/) özelliği, PPTX, PPT veya ODP gibi tespit edilen biçimi raporlar.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Hafif Sunum Envanteri Oluştur**

Birçok sunum dosyasını işlerken, doğrulama, indeksleme veya belge yönetim sistemi için kompakt bir envantere ihtiyaç duyabilirsiniz. Bu senaryoda, [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/get_presentation_info/) kullanarak bir [PresentationInfo](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/) nesnesi elde edin ve ardından belge meta verilerini okumak için [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/read_document_properties/) çağırın. Bu yaklaşım bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturmaz ve tam sunum nesne modelini dolaşmanız gerekmez.

[DocumentProperties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/) tarafından sunulan genişletilmiş özellikler aşağıdaki envanter değerlerini sağlar:

| Özellik | Envanter değeri |
| --- | --- |
| [slaytlar](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/slides/tr/) | Toplam slayt sayısı. |
| [gizli_slaytlar](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/hidden_slides/) | Gizli slaytların sayısı. |
| [notlar](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/notes/) | Not içeren slaytların sayısı. |
| [paragraflar](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/paragraphs/) | Mevcut olduğunda toplam paragraf sayısı. |
| [kelimeler](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/words/) | Toplam kelime sayısı. |
| [multimedya_klipleri](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/multimedia_clips/) | Toplam ses ve video klip sayısı. |

Aşağıdaki örnek bu değerleri bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesi oluşturmadan okur ve kompakt bir envanter yazdırır. Ayrıca [heading_pairs](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/heading_pairs/) ile [titles_of_parts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/titles_of_parts/) birleştirilerek yazı tipleri, temalar ve slayt başlıkları gibi içerik grupları gösterilir.

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

Her [HeadingPair](https://reference.aspose.com/slides/tr/python-net/aspose.slides/headingpair/) bir grup adı ve o grup içindeki öğe sayısını sağlar. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/titles_of_parts/) düz, sıralı bir koleksiyondur; bu nedenle her başlık çiftinin belirttiği ardışık başlık sayısı tüketilir.

### **Depolanmış Meta Veriler ve Biçim Sınırlamaları**

[PresentationInfo.read_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/read_document_properties/) tarafından döndürülen envanter özellikleri, kaynak belgede mevcut meta verilere dayanır. Aspose.Slides bu çağrı için bu değerleri yeniden hesaplamak amacıyla sunum nesne modelini yüklemez ve dolaşmaz. Eksik özellikler varsayılan değerlerle temsil edilir ve saklanan değerler, dosyayı en son kaydeden uygulama belge özelliklerini güncellememişse eski olabilir.

- **PPTX:** Biçim, slayt, not, gizli‑slayt, paragraf, kelime ve multimedya sayımları ile başlık çiftleri ve bölüm başlıkları için genişletilmiş belge özellikleri sağlar. Kullanılabilirlik, belge üreticisinin hangi özellikleri yazdığına bağlıdır.
- **PPT:** İkili biçim, karşılık gelen belge‑özet özelliklerini depolayabilir. Bir özellik eksikse veya belge üreticisi tarafından yenilenmemişse, Aspose.Slides bu değeri slaytlardan hesaplamak yerine saklanan ya da varsayılan değeri döndürür.
- **ODP:** OpenDocument meta verileri, sayfa, paragraf ve kelime sayısı gibi genel belge istatistikleri sunar, ancak bu değerler her PowerPoint‑özel genişletilmiş özellik ile eşleşmez. Gizli‑slayt, not‑slayt, multimedya, başlık‑çifti ve bölüm‑başlığı meta verileri mevcut olmayabilir ve envanter özellikleri varsayılan değer döndürebilir. Sıfır değeri veya boş bir koleksiyonu, ilgili içeriğin yok olduğunun kesin kanıtı olarak değerlendirmeyin.

Envanter ve ön kontrol amaçları için hafif meta veri yaklaşımını kullanın. Sonucun bellek içi değişiklikleri yansıtması gerektiğinde veya gerçek sunum içeriğini doğrulamanız gerektiğinde sunumu yükleyin ve canlı nesne modelini inceleyin.

## **Sunum Özelliklerini Güncelle**

[PresentationInfo.read_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/read_document_properties/) tarafından döndürülen özellikler, bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneği oluşturmadan da değiştirilebilir. Değişiklikleri [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/update_document_properties/) ile uygulayın ve ardından bağlanmış sunumu [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/write_binded_presentation/) ile yazın.

Aşağıdaki görsel PowerPoint sunumunun orijinal belge özelliklerini gösterir.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Aşağıdaki örnek başlığı ve son‑kaydedilme zamanını değiştirir ve sonucu yeni bir dosyaya yazar:

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

Aşağıdaki görsel PowerPoint sunumunun güncellenmiş belge özelliklerini gösterir.

![PowerPoint sunumunun güncellenmiş belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

İlgili güvenlik kontrolleri ve koruma ayarları için aşağıdaki makalelere bakınız:

- [Sunumları Parola ile Koruma](/slides/tr/python-net/password-protected-presentation/)
- [Sunumları Yazma Koruması](/slides/tr/python-net/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunumu yükleyin ve [Presentation.fonts_manager](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/fonts_manager/) kullanın. Gömülü yazı tiplerini almak için [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) ve sunumda kullanılan yazı tiplerini almak için [FontsManager.get_fonts](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fontsmanager/get_fonts/) çağırın. İki sonucu karşılaştırarak render için gerekli ancak gömülmemiş yazı tiplerini bulun.

**Dosyanın gizli slaytları olup olmadığını ve kaç tane olduğunu hızlıca nasıl öğrenebilirim?**

Saklanan belge meta verileri yeterli olduğunda, [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationfactory/get_presentation_info/) ve [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentationinfo/read_document_properties/) aracılığıyla [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/documentproperties/hidden_slides/) okuyun. Bu, hafif bir envanter için uygundur. Sunum bellek içinde değiştirilmişse, saklanan meta veriler eksik ya da eski olabilir veya canlı değerleri doğrulamanız gerekiyorsa, [Presentation.slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/slides/tr/) üzerinden döngü kurarak her slaytın [Slide.hidden](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/hidden/) özelliğini inceleyin.

**Özel slayt boyutu ve yönünün kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Sunumu yükleyin ve [Presentation.slide_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/slide_size/) özelliğini okuyun. Mevcut ayarları beklenen ön ayar ve boyutlarla karşılaştırmak için [SlideSize.type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesize/size/) ve [SlideSize.orientation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidesize/orientation/) özelliklerini inceleyin.

**Grafiklerin dış veri kaynaklarına başvurup başvurmadığını hızlıca gösteren bir yol var mı?**

Evet. Her bir [Chart](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/) bulun ve [ChartData.data_source_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/data_source_type/) özelliğini inceleyin. Dış bir çalışma kitabı için [ChartData.external_workbook_path](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) okun. Veri kaynağı türü ve yolu dış referansı belirler, ancak hedefin mevcut olup olmadığını doğrulamak ayrı bir kaynak kontrolü gerektirir.

**Render veya PDF dışa aktarımını yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Tek bir karmaşıklık özelliği yoktur. [Presentation.slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/slides/tr/) ve her slaytın [BaseSlide.shapes](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/shapes/) koleksiyonunu dolaşın. Şekil sayısı ve büyük görüntüler, efektler, animasyonlar veya multimedya varlığı gibi sinyalleri tarama göstergeleri olarak kullanın ve bir slaytı kesin bir performans darboğazı olarak değerlendirmeden önce temsilî bir render veya dışa aktarma ölçümü yapın.