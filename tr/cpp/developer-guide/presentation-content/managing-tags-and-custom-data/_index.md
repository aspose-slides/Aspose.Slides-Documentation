---
title: C++ Kullanarak Sunumlarda Etiketleri ve Özel Verileri Yönetme
linktitle: Etiketler ve Özel Veri
type: docs
weight: 300
url: /tr/cpp/managing-tags-and-custom-data/
keywords:
- belge özellikleri
- etiket
- özel veri
- etiket ekle
- çift değerler
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'de etiketleri ve özel verileri ekleme, okuma, güncelleme ve kaldırma konularını, PowerPoint ve OpenDocument sunumlarına yönelik örneklerle öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'in PowerPoint sunumlarında etiketler ve özel veri ile nasıl çalıştığını açıklar. Verilerin PPTX dosyalarında nasıl depolandığını kısaca özetler, sunuma özgü verilerin etiketler ve özel XML bölümleri olarak bulunabileceğini belirtir ve etiketleri anahtar‑değer dize çiftleri olarak tanımlar.

Ayrıca etiket değerlerini nasıl okuyacağınızı ve bir sunuma, tek bir slayta veya bir şekle nasıl etiket ekleyeceğinizi gösterir. Ek olarak, makale tüm etiketleri temizleme, bir etiketi adını kullanarak kaldırma ve etiket adlarının listesini alma gibi yaygın etiket yönetimi görevlerini kapsar.

## **Sunum Dosyalarında Veri Depolama**

PPTX dosyaları—.pptx uzantılı öğeler—Office Open XML (OOXML) spesifikasyonunun bir parçası olan PresentationML formatında depolanır. Office Open XML formatı, sunumlardaki verilerin yapısını tanımlar.

*Slayt*, sunumların öğelerinden biri olduğunda, bir *slayt parçası* tek bir slaytın içeriğini içerir. Bir slayt parçasının, ISO/IEC 29500 tarafından tanımlanan Kullanıcı Tanımlı Etiketler gibi birçok parçaya açık ilişkileri olabilir.

Özel veri (sunuma özgü) veya kullanıcı, etiketler ([ITagCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itagcollection/)) ve CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icustomxmlpartcollection/)) olarak bulunabilir.

{{% alert color="primary" %}} 
Etiketler esasen anahtar‑değer dize çiftleridir. 
{{% /alert %}} 

## **Etiket Değerlerini Alma**

Slaytlarda, bir etiket IDocumentProperties.Keywords özelliğine karşılık gelir. Bu örnek kod, Aspose.Slides for C++ ile bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) için etiket değerini nasıl alacağınızı gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Sunumlara Etiket Ekleme**

Aspose.Slides, sunumlara etiket eklemenize izin verir. Bir etiket genellikle iki öğeden oluşur:
- özel özelliğin adı - `MyTag`
- özel özelliğin değeri - `My Tag Value`

Belirli bir kural veya özelliğe göre bazı sunumları sınıflandırmanız gerekiyorsa, bu sunumlara etiket eklemek faydalı olabilir. Örneğin, Kuzey Amerika ülkelerinden tüm sunumları bir araya getirmek isterseniz, bir Kuzey Amerika etiketi oluşturabilir ve ilgili ülkeleri (ABD, Meksika ve Kanada) değerler olarak atayabilirsiniz.

Bu örnek kod, Aspose.Slides for C++ kullanarak bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) üzerine etiket eklemenin nasıl yapılacağını gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Etiketler ayrıca [Slide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/) için de ayarlanabilir:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Veya herhangi bir bireysel [Shape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Sınırlamalar**

`get_CustomData()->get_Tags()` kullanılarak özel veri etiket koleksiyonu aracılığıyla eklenen etiketler yalnızca PowerPoint dosyasında depolanır. Sunum PDF olarak dışa aktarıldığında bu etiketler PDF etiket yapısına **aktarılmaz**. Sonuç olarak, etiket olarak atanan özel bir tanımlayıcı etiketli PDF'den alınamaz.

**Geçici Çözüm**: Özel bir tanımlayıcıyı nesnenin **Alt Text** özelliğinde saklayabilirsiniz (örn., `shape->set_AlternativeText(u"MyId")`). PDF'ye dışa aktardıktan sonra Alt Text PDF etiket yapısında görünebilir.

## **SSS**

**Bir sunum, slayt veya şekilden tüm etiketleri tek bir işlemle kaldırabilir miyim?**

Evet. [tag collection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/) bir seferde tüm anahtar‑değer çiftlerini silen bir [clear](https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/clear/) işlemini destekler.

**Tüm koleksiyonu dolaşmadan, adını bilerek tek bir etiketi nasıl silebilirim?**

Etiketi anahtarıyla silmek için [TagCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/) üzerindeki [Remove(name)](https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/remove/) işlemini kullanın.

**Analiz veya filtreleme amacıyla etiket adlarının tam listesini nasıl alabilirim?**

[tag collection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/) üzerinde [GetNamesOfTags](https://reference.aspose.com/slides/tr/cpp/aspose.slides/tagcollection/getnamesoftags/) kullanın; bu, tüm etiket adlarını içeren bir dizi döndürür.