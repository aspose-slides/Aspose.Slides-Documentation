---
title: Python'da Sunum Özelliklerini Yönet
linktitle: Sunum Özellikleri
type: docs
weight: 70
url: /tr/python-java/presentation-properties/
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
description: "Aspose.Slides for Python via Java'da sunum özelliklerini ustaca yönetin ve PowerPoint ve OpenDocument dosyalarınızda aramayı, markalaştırmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides for Python via Java, **yerleşik** ve **özel** belge özelliklerini destekler. Bu özellikleri, yazar, başlık ve kullanıcı tanımlı değerler gibi sunum meta verilerini okumak ve güncellemek için kullanın.

Aspose.Slides, sunum belge özellikleriyle [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) sınıfı aracılığıyla çalışmanıza olanak tanır. Bu sınıfın bir örneği, [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) tarafından döndürülür. Aşağıdaki örnekler, bu özellikleri nasıl okuyacağınızı, değiştireceğinizi ve yöneteceğinizi gösterir.

{{% alert color="info" title="Note" %}}
Aspose.Slides, sunumları kaydederken uygulama ve üretici meta verilerini yönetir; bu alanlar çıktıyı oluşturan yazılımı tanımlar.
{{% /alert %}}

## **Sunum Özelliklerini Yönet**

Belge özellikleri, sunum içeriği ile birlikte tanımlayıcı bilgileri depolar. İki kategoriye ayrılırlar:

- **Yerleşik özellikler** standart meta verileri içerir, örneğin başlık, yazar ve belge istatistikleri.
- **Özel özellikler** kullanıcı tanımlı ad/değer çiftlerini saklar.

Aspose.Slides for Python via Java, her iki kategoriye de erişim sağlar. PowerPoint'te belge meta verilerini incelemek için **File → Info → Properties → Advanced Properties** seçeneğini seçin. İletişim kutusu, bilgileri **Summary**, **Statistics**, **Contents** ve **Custom** gibi sekmelere ayırır. Kullanıcı tanımlı özellikleri yönetmek için **Custom** sekmesini kullanın.

## **Şifreli Sunumdan Genel Özellikleri Okuma**

Açma parolası genellikle hem sunum içeriğini hem de belge özelliklerini korur. Bir sunum, [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) `False` ile çağrıldıktan sonra şifrelenirse, belge özellikleri genel olarak kalır. Bir uygulama daha sonra [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `True` ile çağırarak açma parolasını sağlamadan genel meta verileri okuyabilir.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) Aspose.Slides'in neyi yükleyeceğini kontrol eder; hiçbir şeyi çözümlmez. Özellikler şifreleme içinde dahil edilmişse, parolasız yükleme başarısız olur. Sunum şifrelenmemişse, seçenek yoksayılır ve tam sunum yüklenir.

Örnek, belge özellikleri genel bırakılmış bir şifreli sunum gerektirir. Yükleme modunu [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) üzerinden doğrular ve ardından [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) aracılığıyla yerleşik özellikleri okur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

Bu modda, slayt içeriği yüklenmez. Slaytlar, masterlar, düzenler, şekiller, medya ve diğer sunum nesneleri kullanılamaz. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) kontrol etmelidir.

{{% alert color="warning" title="Warning" %}}
Genel meta veriler, yazar adları, başlıklar, konular, anahtar kelimeler, şirket bilgileri, yorumlar ve özel değerleri ifşa edebilir. Hassas özellikleri sunumla birlikte şifreleyin. Parolasız erişim gerektiren sadece indeksleme, sınıflandırma, arama veya belge yönetim sistemleri gibi özel durumlarda genel bırakın.
{{% /alert %}}

## **Şifreli Sunumun Özelliklerini Güncelleme**

Şifreli bir PPTX dosyası için, [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `True` ile çağrıldıktan sonra yüklenen bir sunum, genel meta verileri okumak içindir. Aspose.Slides, bu yalnızca meta veri nesnesinden değiştirilen özellikleri kaydedemez çünkü genel özelliklerin şifreli sunum içindeki karşılık gelen verilerle tutarlı kalması gerekir. Bu yüzden güncelleme için doğru açma parolası ve tam yükleme gereklidir.

Örnek, genel belge özelliklerine ve bilinen bir açma parolasına sahip şifreli bir PPTX sunumu gerektirir. Tam sunumu [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword) ile açar, genel yerleşik özellikleri günceller ve sonucu kaydeder. Ardından [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) kullanarak şifrelemenin korunduğunu doğrular ve yeni değerleri doğrulamak için parolasız genel meta verileri tekrar açar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

Bir uygulama sunum içeriğini çözümlmeye veya yüklemeye yetkili değilse, şifreli bir PPTX dosyasının genel özelliklerini yalnızca okuma olarak ele almalıdır.

## **Yerleşik Özelliklere Erişim**

[DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) sınıfı, [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) ve [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime) gibi getter metodları aracılığıyla yerleşik meta verileri ortaya çıkarır. Bu örnek mevcut bir sunumu açar ve saklanan meta verileri konsola yazdırır. Değerler giriş sunumuna bağlıdır; bazı alanlar boş olabilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

## **Yerleşik Özellikleri Değiştir**

Yerleşik meta verileri güncellemek için, [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) tarafından döndürülen nesnedeki setter metodlarını kullanın. Bu örnek mevcut bir sunumu açar, [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) ve [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager) metodlarını çağırır, ardından güncellenen sunumu [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) ile kaydeder. Kaydedilen PPTX yeni meta verileri içerir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Köprü Temelini Yönet**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) görece köprüler için belge düzeyinde temel adresi döndürür. [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) kullanarak bunu değiştirebilir veya temizleyebilirsiniz. Bu, bir sunumu ve bağlı dosyalarını başka bir konuma taşıdığınızda faydalıdır. Bu, tek tek bir köprünün [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) metodundan ayrı bir şeydir; temeli değiştirmek, kaydedilen köprü adreslerini yeniden yazmaz veya mutlak hedefleri değiştirmez.

Örnek, `target.html` gibi bir görece köprü ve `https://example.org/absolute.html` gibi bir mutlak köprü içeren bir sunum gerektirir. Mevcut temeli okur, yeni bir temel adresi atar ve değeri kontrol etmek için sunumu kaydedip tekrar açar. Ardından temeli boş bir string ile temizler ve ayrı bir kaydedilmiş dosyada boş değeri doğrular. Örnek temel adresini, bağlı dosyalarınızın konumuyla değiştirin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

İki doğrulama mesajı `True` yazdırmalıdır. Temelin temizlenmesi, tek tek köprü adreslerini etkilenmemiş bırakır.

`target.pptx`'ye görece bir köprü, temel `old` klasörüne işaret ettiğinde `old/target.pptx`'yi açtı. Temel `new` klasörüne değiştirildikten, kaydedildikten ve sunum tekrar açıldıktan sonra aynı köprü `new/target.pptx`'yi açtı. Mutlak bir köprü aynı dosyayı açmaya devam etti. Sunumu taşıdıktan veya temeli değiştirdikten önce ve sonra PowerPoint'te görece köprülerinizi test edin.

## **Özel Sunum Özellikleri Ekle**

Özel özellikler, karşılık gelen bir yerleşik alanı olmayan meta verileri depolar. [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) metodu, özellik adını kullanarak bir değer atamanızı sağlar. Bu örnek bir sunum oluşturur, iki metin değeri ve bir tam sayı sürüm değeri (`jpype.JInt` kullanarak Java tam sayısı geçirilir) ekler ve [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) ile sunumu kaydeder. Mevcut bir ada değer atamak, o özelliğin değerini değiştirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Özel Özelliklere Erişim ve Değiştirme**

Bu örnek, özel özellikler içeren bir sunumu açar ve [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) kullanarak bunlar üzerinde döner. [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) sıfır tabanlı bir indeks alır ve [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) tarafından kullanılan adı döndürür. Örnek, her orijinal adı ve değeri yazdırır, tüm değerleri tipine bakılmaksızın numaralı bir dizeyle değiştirir ve değişiklikleri kaydeder. Özel özellik yoksa, döngü hiçbir değişiklik yapmaz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Canlı Örnek**

Aspose.Slides API'sini kullanarak belge özellikleriyle nasıl çalışılacağını görmek için çevrimiçi uygulama olan [**PowerPoint Meta Verilerini Görüntüle ve Düzenle**](https://products.aspose.app/slides/metadata)'yi deneyin:

[![PowerPoint Meta Verilerini Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **SSS**

**Sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, değerlerini değiştirebilir veya ilgili özellik izin veriyorsa boş olarak ayarlayabilirsiniz.

**Zaten mevcut olan bir özel özellik eklersem ne olur?**

Varolan bir özel özellik eklenirse, mevcut değeri yeniyle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides özelliğin değerini otomatik olarak günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) ve ardından [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) kullanarak bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) örneği oluşturmadan saklanan belge meta verilerini okuyabilirsiniz. Tam bir raporlama örneği ve format‑spesifik sınırlamalar için [Build a Lightweight Presentation Inventory](/slides/tr/python-java/examine-presentation/) sayfasına bakın.

**Şifreli bir sunumun genel özelliklerini açma parolası olmadan okuyabilir miyim?**

Evet. Sunum, [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) `False` ile çağrıldıktan sonra şifrelenmiş olmalı ve [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `True` ile çağrıldıktan sonra yüklenmiş olmalıdır.

**Yerleşik belge‑özellikleri‑sadece modunda şifreli bir PPTX dosyasını güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalıdır; bu yüzden şifreli bir PPTX dosyasını güncellemek, doğru açma parolasını kullanarak tam sunumu yüklemeyi gerektirir.