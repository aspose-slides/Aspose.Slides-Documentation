---
title: Python ile Sunum Özelliklerini Yönetme
linktitle: Sunum Özellikleri
type: docs
weight: 70
url: /tr/python-net/presentation-properties/
keywords:
- PowerPoint özellikleri
- sunum özellikleri
- belge özellikleri
- yerleşik özellikler
- özel özellikler
- gelişmiş özellikler
- özellikleri yönetme
- özellikleri değiştirme
- belge meta verileri
- meta verileri düzenleme
- düzeltme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'te sunum özelliklerini yönetin ve PowerPoint dosyalarınızda aramayı, markalaşmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides for Python via .NET **yerleşik** ve **özel** belge özelliklerini destekler. Bu özellikleri, yazar, başlık ve kullanıcı tanımlı değerler gibi sunum meta verilerini okumak ve güncellemek için kullanın.

Aspose.Slides, sunum belge özelliklerini [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) sınıfı aracılığıyla işlemenizi sağlar. Bu sınıfın bir örneği, [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) tarafından döndürülür. Aşağıdaki örnekler, bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="info" title="Note" %}}
Aspose.Slides, sunumları kaydederken uygulama ve üretici meta verilerini yönetir; bu alanlar çıktıyı oluşturan yazılımı tanımlar.
{{% /alert %}}

## **Sunum Özelliklerini Yönetme**

Belge özellikleri, sunum içeriğiyle birlikte tanımlayıcı bilgi depolar. İki kategoriye ayrılırlar:

- **Yerleşik özellikler** başlık, yazar ve belge istatistikleri gibi standart meta verileri içerir.
- **Özel özellikler** kullanıcı tanımlı ad/değer çiftlerini depolar.

Aspose.Slides for Python via .NET, her iki kategoriye de erişim sağlar. PowerPoint'te belge meta verilerini incelemek için **File → Info → Properties → Advanced Properties** seçeneğini seçin. İletişim kutusu, bilgiyi **Summary**, **Statistics**, **Contents** ve **Custom** gibi sekmelere gruplar. Kullanıcı tanımlı özellikleri yönetmek için **Custom** sekmesini kullanın.

## **Şifrelenmiş Bir Sunumdan Genel Özellikleri Okuma**

Açma şifresi genellikle hem sunum içeriğini hem de belge özelliklerini korur. Bir sunum, [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) `False` olarak ayarlandığında şifrelenmişse, belge özellikleri genel olarak kalır. Bir uygulama daha sonra [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) `True` olarak ayarlayarak açma şifresini sağlamadan genel meta verileri okuyabilir.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) Aspose.Slides’in neyi yüklediğini kontrol eder; hiçbir şeyi çözmez. Özellikler şifreleme içinde yer alıyorsa, şifre olmadan yükleme başarısız olur. Sunum şifreli değilse, seçenek yok sayılır ve tam sunum yüklenir.

Bu örnek, belge özellikleri genel olarak bırakılmış şifreli bir sunum gerektirir. Yükleme kipini [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) ile doğrular ve ardından [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) aracılığıyla yerleşik özellikleri okur:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Bu kipte slayt içeriği yüklenmez. Slaytlar, ana şablonlar, düzenler, şekiller, medya ve diğer sunum nesneleri kullanılamaz. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) kontrol etmelidir.

{{% alert color="warning" title="Security" %}}
Genel meta veriler yazar adları, başlıklar, konular, anahtar kelimeler, şirket bilgileri, yorumlar ve özel değerleri ifşa edebilir. Hassas özellikleri sunumla birlikte şifreleyin. Yalnızca indeksleme, sınıflandırma, arama veya belge‑yönetim sistemlerinin şifre olmadan erişim gereksinimi olduğunda genel bırakın.
{{% /alert %}}

## **Şifrelenmiş Bir Sunumun Özelliklerini Güncelleme**

Şifreli bir PPTX dosyası için, [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) ile yüklenen bir sunum, genel meta verileri okumak için tasarlanmıştır. Aspose.Slides, bu yalnızca meta veri nesnesinden değiştirilen özellikleri kaydedemez çünkü genel özellikler şifreli sunum içindeki ilgili verilerle tutarlı olmalıdır. Bu nedenle güncelleme doğru açma şifresi ve tam bir yükleme gerektirir.

Bu örnek, genel belge özelliklerine sahip şifreli bir PPTX sunumu ve bilinen bir açma şifresi gerektirir. Tam sunumu [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) ile açar, genel yerleşik özellikleri günceller ve sonucu kaydeder. Ardından [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) kullanarak şifrelemenin korunduğunu doğrular ve yeni değerleri kontrol etmek için genel meta verileri şifresiz yeniden açar:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Uygulama, sunum içeriğini çözümleyemez veya yükleyemezse, şifreli bir PPTX dosyasının genel özelliklerini yalnızca okuma‑yalnızca olarak ele almalıdır.

## **Yerleşik Özelliklere Erişim**

[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) sınıfı, [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) ve [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/) gibi tiplenmiş özellikler aracılığıyla yerleşik meta verileri ortaya çıkarır. Bu örnek mevcut bir sunumu açar ve saklanan meta verileri konsola yazdırır. Değerler girdi sunumuna bağlıdır; bazı alanlar boş olabilir.

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

## **Yerleşik Özellikleri Değiştirme**

Yerleşik meta verileri güncellemek için, [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) tarafından ortaya çıkarılan yazılabilir özelliklere değerler atayın. Bu örnek mevcut bir sunumu açar, [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/) ve [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/) ayarlar, ardından güncellenen sunumu [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) ile kaydeder. Kaydedilen PPTX yeni meta verileri içerir.

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Köprü Temelini Yönetme**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) göreli köprüler için belge‑seviyesindeki temeli depolar. Sunumu ve bağlı dosyalarını başka bir konuma taşıdığınızda kullanışlıdır. Bu, bireysel bir köprünün [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) özelliğinden ayrı bir ayardır: temeli değiştirmek depolanan köprü adreslerini yeniden yazmaz veya mutlak hedefleri değiştirmez.

Bu örnek, `target.html` gibi bir göreli bağ ve bir dosya ya da web sitesine mutlak bağ içeren bir sunum gerektirir. Mevcut temeli okur, yeni bir temel adres atar ve değeri kontrol etmek için sunumu kaydedip yeniden açar. Ardından temeli `""` ile temizler ve ayrı bir kaydedilen dosyada boş değeri doğrular. Örnek temel adresi, bağlı dosyalarınızın konumuyla değiştirin.

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

İki doğrulama mesajı `True` yazdırmalıdır. Temelin temizlenmesi, bireysel köprü adreslerini etkilenmemiş bırakır.

`target.pptx` göreli bir bağ, temel `old` klasörüne işaret ettiğinde `old/target.pptx` dosyasını açtı. Temel `new` klasörüne değiştirildikten, kaydedildikten ve sunum yeniden açıldıktan sonra aynı bağ `new/target.pptx` dosyasını açtı. Mutlak bağ aynı dosyayı açmaya devam etti. Sunumu taşıdıktan ya da temelini değiştirdikten önce ve sonra göreli bağlarınızı PowerPoint’te test edin.

## **Özel Sunum Özellikleri Ekleme**

Özel özellikler, karşılığı olmayan yerleşik bir alanı olmayan meta verileri depolar. [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) yöntemi, özellik adını kullanarak bir değer atamanıza olanak tanır. Bu örnek bir sunum oluşturur, iki metin değeri ve bir tam sayı sürüm değeri ekler ve sunumu [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) ile kaydeder. Mevcut bir ada değer atamak, o özelliğin değerini değiştirir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Özel Özelliklere Erişim ve Değiştirme**

Bu örnek, özel özellikler içeren bir sunumu açar ve [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) kullanarak bunlar üzerinde yineleme yapar. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) sıfır‑tabanlı bir indeks kabul eder ve [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) tarafından kullanılan adı döndürür. Örnek, özel özelliklerin tümünün dize olduğu bir sunum gerektirir. Her orijinal adı ve değeri yazdırır, her değeri numaralı bir dizeyle değiştirir ve değişiklikleri kaydeder. Özel özellik yoksa döngü hiçbir değişiklik yapmaz.

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) değeri, ikinci argüman olarak geçirilen tek öğeli liste aracılığıyla döndürür. Yer tutucu, saklanan özelliğin türüyle eşleşmelidir: dize için `[""]` veya tam sayı için `[0]` kullanın. Tür uyuşmazlığı bir `InvalidCastException` oluşmasına neden olur; yer tutucuyu özel‑özellik şemanıza göre seçin.

## **Canlı Örnek**

Aspose.Slides API’sini kullanarak belge özellikleriyle nasıl çalışılacağını görmek için çevrimiçi uygulama **[PowerPoint Meta Verilerini Görüntüle ve Düzenle](https://products.aspose.app/slides/metadata)**’yi deneyin:

[![PowerPoint Meta Verilerini Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler sunumun bütünleşik bir parçasıdır ve tamamen kaldırılamaz. Ancak, değerlerini değiştirebilir ya da izin veriliyorsa boş bir değer atayabilirsiniz.

**Zaten var olan bir özel özellik eklersem ne olur?**

Var olan bir özel özellik eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak değeri günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. Önce [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) çağırın, ardından [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) ile bir [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) örneği oluşturmadan saklı belge meta verilerini okuyun. Tam raporlama örneği ve format‑spesifik sınırlamalar için [Build a Lightweight Presentation Inventory](/slides/tr/python-net/examine-presentation/) bölümüne bakın.

**Şifreli bir sunumun genel özelliklerini açma şifresi olmadan okuyabilir miyim?**

Evet. Sunum, [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) `False` olarak şifrelenmiş olmalı ve [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) `True` olarak yüklenmelidir.

**Belge‑özellikleri‑yalnızca modunda şifreli bir PPTX dosyasını güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalıdır; bu yüzden şifreli bir PPTX dosyasını güncellemek, doğru açma şifresiyle tam sunumu yüklemeyi gerektirir.