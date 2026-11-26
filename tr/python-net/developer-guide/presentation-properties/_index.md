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
- özellikleri yönet
- özellikleri değiştir
- belge meta verileri
- meta verileri düzenle
- düzeltme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET içinde sunum özelliklerini yöneterek PowerPoint dosyalarınızda aramayı, markalaştırmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides for Python via .NET **yerleşik** ve **özel** belge özelliklerini destekler. Bu özellikleri sunum meta verilerini okumak ve güncellemek için kullanın; örneğin yazar, başlık ve kullanıcı tanımlı değerler.

Aspose.Slides, sunum belge özellikleriyle [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) sınıfı aracılığıyla çalışmanıza olanak tanır. Bu sınıfın bir örneği [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) tarafından döndürülür. Aşağıdaki örnekler bu özellikleri nasıl okuyacağınızı, değiştireceğinizi ve yöneteceğinizi gösterir.

{{% alert color="info" title="Note" %}}
Aspose.Slides, sunumları kaydederken uygulama ve üretici meta verilerini yönetir; bu alanlar çıktıyı oluşturan yazılımı tanımlar.
{{% /alert %}}

## **Sunum Özelliklerini Yönet**

Belge özellikleri, sunum içeriğinin yanı sıra tanımlayıcı bilgileri depolar. İki kategoriye ayrılırlar:

- **Yerleşik özellikler** standart meta verileri içerir, örneğin başlık, yazar ve belge istatistikleri.
- **Özel özellikler** kullanıcı tanımlı ad/değer çiftlerini depolar.

Aspose.Slides for Python via .NET, her iki kategoriye de erişim sağlar. PowerPoint'ta belge meta verilerini incelemek için **File → Info → Properties → Advanced Properties** seçeneğini seçin. İletişim kutusu bilgileri **Summary**, **Statistics**, **Contents** ve **Custom** gibi sekmelere gruplar. Kullanıcı tanımlı özellikleri yönetmek için **Custom** sekmesini kullanın.

## **Şifreli Bir Sunumdan Genel Özellikleri Okuma**

Açma şifresi genellikle sunum içeriğini ve belge özelliklerini korur. Bir sunum, [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) `False` olarak ayarlandığında şifrelenmişse, belge özellikleri genel kalır. Bir uygulama daha sonra [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) `True` olarak ayarlayabilir ve açma şifresi vermeden genel meta verileri okuyabilir.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) Aspose.Slides'ın neyi yükleyeceğini kontrol eder; hiçbir şeyi çözmez. Özellikler şifreleme içinde yer alıyorsa, şifre olmadan yükleme başarısız olur. Sunum şifreli değilse, seçenek yok sayılır ve tam sunum yüklenir.

Örnek, belge özellikleri genel bırakılmış bir şifreli sunum gerektirir. Yükleme modunu [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) ile doğrular ve ardından [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) üzerinden yerleşik özellikleri okur:

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

Bu modda slayt içeriği yüklenmez. Slaytlar, ana slaytlar, düzenler, şekiller, medya ve diğer sunum nesneleri kullanılamaz. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) kontrol etmelidir.

{{% alert color="warning" title="Security" %}}
Genel meta veriler yazar adları, başlıklar, konu, anahtar kelimeler, şirket bilgileri, yorumlar ve özel değerleri açığa çıkarabilir. Hassas özellikleri sunumla birlikte şifreleyin. Yalnızca indeksleme, sınıflandırma, arama veya belge yönetim sistemlerinin şifre olmadan erişim ihtiyacı olduğunda genel bırakın.
{{% /alert %}}

## **Şifreli Bir Sunumun Özelliklerini Güncelleme**

Şifreli bir PPTX dosyası için, [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) ile yüklenen bir sunum, yalnızca genel meta verileri okuma amaçlıdır. Aspose.Slides, bu meta veri‑only nesneden değiştirilen özellikleri kaydedemez çünkü genel özellikler şifreli sunum içindeki ilgili verilerle tutarlı olmalıdır. Bu nedenle güncelleme, doğru açma şifresi ve tam yükleme gerektirir.

Örnek, genel belge özelliklerine sahip şifreli bir PPTX sunumu ve bilinen bir açma şifresi gerektirir. Tam sunumu [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) ile açar, genel yerleşik özellikleri günceller ve sonucu kaydeder. Ardından [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) ile şifrelemenin korunduğunu doğrular ve yeni değerleri kontrol etmek için genel meta verileri şifresiz yeniden açar:

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

Bir uygulama sunum içeriğini çözemiyor veya yükleyemiyorsa, şifreli bir PPTX dosyasının genel özelliklerini yalnızca‑okunur olarak ele almalıdır.

## **Yerleşik Özelliklere Erişim**

[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) sınıfı, [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) ve [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/) gibi tipli özellikler aracılığıyla yerleşik meta verileri ortaya koyar. Bu örnek mevcut bir sunumu açar ve depolanmış meta verilerini konsola yazdırır. Değerler giriş sunumuna bağlıdır; bazı alanlar boş olabilir.

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

### **Revizyon Numarası ve Düzenleme Süresini Raporlama**

`presentations` klasöründeki her PPTX dosyasının revizyon numarasını ve toplam düzenleme süresini raporlamak için [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) kullanarak [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) alınır; slaytlar yüklenmez. Python süresi bir `timedelta` olarak gösterir; kayıt süresi 24 saate ulaştığında gün sayısını da içerir.

```python
from pathlib import Path

import aspose.slides as slides

print("File | RevisionNumber | TotalEditingTime")
for path in Path("presentations").glob("*.pptx"):
    if path.is_file():
        info = slides.PresentationFactory.instance.get_presentation_info(str(path))
        properties = info.read_document_properties()
        print(f"{path.name} | {properties.revision_number} | {properties.total_editing_time}")
```

1 gün, 2 saat ve 5 dakika kayıtlı düzenleme süresi olan bir sunum için rapor şu satırı içerir.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1 day, 2:05:00
```

[DocumentProperties.revision_number](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/revision_number/) yazılabilir meta veridir. Değeri tek başına sunumun kaç kez kaydedildiğini belirleyemez veya sürüm geçmişini yeniden oluşturamaz.

[DocumentProperties.total_editing_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/total_editing_time/) dosyada depolanan düzenleme süresini raporlar. `0:00:00` değeri, kayıtlı sürenin sıfır olduğunu, birinin sunumu düzenlemiş olsa bile gösterir.

## **Yerleşik Özellikleri Değiştirme**

Yerleşik meta verileri güncellemek için [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) aracılığıyla sunulan yazılabilir özelliklere değer atayın. Bu örnek mevcut bir sunumu açar, [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/) ve [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/) ayarlar ve ardından [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) ile güncellenmiş sunumu kaydeder. Kaydedilen PPTX yeni meta verileri içerir.

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

## **Hipermetin Tabanını Yönetme**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) belge‑düzeyinde göreceli hipermetinler için temel adresi depolar. Sunumu ve bağlı dosyalarını başka bir konuma taşırken faydalıdır. Bu, bireysel bir hipermetnin [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) adresinden ayrı bir yapıdır; temeli değiştirmek saklanan bağlantı adreslerini yeniden yazmaz veya mutlak hedefleri değiştirmez.

Örnek, `target.html` gibi göreceli bir bağlantı ve bir dosya ya da web sitesine mutlak bağlanı içerir. Mevcut temel adresi okur, yeni bir temel adres atar, sunumu kaydeder ve değeri kontrol etmek için yeniden açar. Ardından temel adresi `""` ile temizler ve ayrı bir kaydedilmiş dosyada boş değeri doğrular. Örnek temel adresi, bağlı dosyalarınızın konumuyla değiştirin.

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

İki doğrulama mesajı da `True` yazdırmalıdır. Temelin temizlenmesi bireysel hipermetin adreslerini etkilemez.

Temel `old` klasörüne işaret ettiğinde `target.pptx` göreceli bağlantısı `old/target.pptx` dosyasını açtı. Temel `new` klasörüne değiştirildikten, kaydedilip sunum yeniden açıldıktan sonra aynı bağlantı `new/target.pptx` dosyasını açtı. Mutlak bağlantı aynı dosyayı açmaya devam etti. Göreceli bağlantılarınızı PowerPoint'te sunumu taşıyıp temeli değiştirmeden önce ve sonra test edin.

## **Özel Sunum Özellikleri Ekleme**

Özel özellikler, yerleşik bir alanı olmayan meta verileri depolar. [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) yöntemi, özellik adını belirterek bir değer atamanıza izin verir. Bu örnek bir sunum oluşturur, iki metin değeri ve bir tam sayı sürüm değeri ekler ve [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) ile sunumu kaydeder. Mevcut bir ada değer atamak, o özelliğin değerini değiştirir.

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

Bu örnek, özel özellikler içeren bir sunumu açar ve [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) kullanarak bunlar üzerinde yineleme yapar. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) sıfır‑tabanlı bir indeks alır ve [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) ile kullanılan adı döndürür. Örnek, tüm özel özelliklerin string olduğu bir sunum gerektirir. Her orijinal adı ve değerini yazdırır, her değeri numaralı bir string ile değiştirir ve değişiklikleri kaydeder. Özel özellik hiç yoksa döngü hiçbir değişiklik yapmaz.

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

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) değerini ikinci argüman olarak verilen tek‑elemanlı liste üzerinden döndürür. Yer tutucu, saklanan özelliğin tipine eşleşmelidir: bir string için `[""]`, bir tam sayı için `[0]` kullanın. Tip uyumsuzluğu bir `InvalidCastException` oluşturur; yer tutucuyu özel‑özellik şemanıza göre seçin.

## **Canlı Örnek**

Belge özellikleriyle çalışmayı görmek için çevrimiçi uygulama **[View & Edit PowerPoint Metadata](https://products.aspose.app/slides/metadata)** deneyin:

[![PowerPoint Meta Verilerini Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler sunumun bütünleşik bir parçasıdır ve tamamen kaldırılamaz. Ancak, değerlerini değiştirebilir veya izin veriliyorsa boş olarak ayarlayabilirsiniz.

**Zaten var olan bir özel özelliği eklersem ne olur?**

Var olan bir özel özellik eklenirse, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak değeri günceller.

**Sunumu tamamen yüklemeden özelliklere erişebilir miyim?**

Evet. Önce [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) ardından [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) kullanarak [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) örneği oluşturmadan depolanmış belge meta verilerini okuyabilirsiniz. Tam raporlama örneği ve format‑spesifik sınırlamalar için **[Build a Lightweight Presentation Inventory](/slides/tr/python-net/examine-presentation/)** bölümüne bakın.

**Şifreli bir sunumun genel özelliklerini açma şifresi olmadan okuyabilir miyim?**

Evet. Sunum, [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) `False` olarak ayarlanmış ve [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) `True` olarak yüklenmiş olmalıdır.

**Şifreli bir PPTX dosyasını belge‑özellikleri‑sadece modunda güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalıdır; bu yüzden şifreli bir PPTX dosyasını güncellemek doğru açma şifresi ile tam sunumu yüklemeyi gerektirir.