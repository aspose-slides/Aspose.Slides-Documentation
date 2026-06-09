---
title: Python ile Sunumlarda Etiketleri ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veriler
type: docs
weight: 300
url: /tr/python-net/managing-tags-and-custom-data/
keywords:
- belge özellikleri
- etiket
- özel veri
- etiket ekleme
- çift değerler
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'te PowerPoint ve OpenDocument sunumları için örneklerle etiketleri ve özel verileri eklemeyi, okumayı, güncellemeyi ve kaldırmayı öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'in PowerPoint sunumlarında etiketler ve özel verilerle nasıl çalıştığını açıklar. Veri .pptx dosyalarında nasıl depolandığını kısaca özetler, sunuma özgü verilerin etiketler ve özel XML bölümleri olarak var olabileceğini belirtir ve etiketleri anahtar-değer dize çiftleri olarak tanımlar.

Ayrıca etiket değerlerini nasıl okuyacağınızı ve bir sunuma, tek bir slayta veya bir şekle nasıl etiket ekleyeceğinizi gösterir. Buna ek olarak, makale tüm etiketleri temizleme, bir etiketi adla kaldırma ve etiket adlarının listesini alma gibi yaygın etiket-yönetimi görevlerini kapsar.

## **Sunum Dosyalarında Veri Depolama**

PPTX dosyaları—.pptx uzantısına sahip öğeler—Office Open XML spesifikasyonunun bir parçası olan PresentationML formatında depolanır. Office Open XML formatı, sunumlarda bulunan verilerin yapısını tanımlar.

*Slide* (slayt), sunumların öğelerinden biri olarak, bir *slide part* tek bir slaytın içeriğini içerir. Bir slide part, ISO/IEC 29500 tarafından tanımlanan Kullanıcı Tanımlı Etiketler gibi birçok bölüme açık ilişkiler kurabilir.

Özel veri (bir sunuma özgü) veya kullanıcı etiketler ([ITagCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/itagcollection/)) ve CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/icustomxmlpartcollection/)) şeklinde var olabilir.

{{% alert color="primary" %}} 
Etiketler aslinda dize-anahtar çift değerleridir. 
{{% /alert %}} 

## **Etiketlerin Değerlerini Almak**

Slaytlarda bir etiket, IDocumentProperties.Keywords özelliğine karşılik gelir. Bu örnek kod, [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) için Aspose.Slides for Python via .NET ile bir etiketin değerini nasıl alacaginizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumlara etiket eklemenize izin verir. Bir etiket tipik olarak iki öğeden olusur:

- özel bir özelliğin adı - `MyTag`
- özel bir özelliğin degeri - `My Tag Value`

Belirli bir kural veya özelliğe göre bazı sunumları sınıflandırmanız gerekiyorsa, bu sunumlara etiket eklemek faydalı olabilir. Örnegin, Kuzey Amerika ülkelerinden gelen tum sunumları bir araya getirmek isterseniz, bir Kuzey Amerika etiketi olusturabilir ve ilgili ülkeleri (ABD, Meksika ve Kanada) deger olarak atayabilirsiniz.

Bu örnek kod, Aspose.Slides for Python via .NET kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) üzerine etiket eklemenin nasil yapılacağını gösterir:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Etiketler ayrıca [Slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/) için de ayarlanabilir:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Veya herhangi bir tekil [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) için:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Sınırlamalar**

`custom_data.tags` koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyası içinde depolanır. Sunum PDF olarak dışa aktarildığında etiket yapısına **aktarılmaz**. Sonuç olarak, etiket olarak atanan özel bir tanımlayıcı, etiketlenmiş PDF'den alınamaz.

**Geçici Çözüm**: Özel bir tanımlayıcıyı nesnenin **Alt Text** (örn., `shape.alternative_text = "MyId"`) içinde depolayabilirsiniz. PDF'ye dışa aktardıktan sonra Alt Text, PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**

Evet. [Tag collection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/tagcollection/) aynı anda tum anahtar-deger çiftlerini silen bir [clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides/tagcollection/clear/) islemini destekler.

**Tum koleksiyonu dolaşmadan, adıyla tek bir etiketi nasıl silebilirim?**

Etiketi anahtarıyla silmek için [TagCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/tagcollection/) üzerinde [remove(name)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/tagcollection/remove/) işlemini kullanın.

**Analiz veya filtreleme için etiket adlarının tam listesini nasıl alabilirim?**

[Tag collection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/tagcollection/) üzerinde [get_names_of_tags](https://reference.aspose.com/slides/tr/python-net/aspose.slides/tagcollection/get_names_of_tags/) kullanın; bu, tum etiket adlarini içeren bir dizi döndürür.