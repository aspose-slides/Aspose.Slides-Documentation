---
title: Python'da Sunum Özelliklerini Yönetme
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
- belge üst verileri
- üst verileri düzenle
- düzeltme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java'da sunum özelliklerini uzmanlaşın ve PowerPoint ve OpenDocument dosyalarınızda aramayı, markalaşmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides belge özelliklerinin iki türünü destekler: **Built-in** ve **Custom**. Bu özellik türlerine Aspose.Slides API'si aracılığıyla kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle çalışmanıza **DocumentProperties**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/) sınıfı üzerinden olanak tanır. Bu sınıfın bir örneği **Presentation.getDocumentProperties**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getDocumentProperties) tarafından döndürülür. Aşağıdaki örnekler bu özelliklerin nasıl okunacağını, değiştirileceğini ve yönetileceğini gösterir.

{{% alert color="info" title="Not" %}}
Lütfen **Application** ve **AppVersion** alanlarının değiştirilemeyeceğini unutmayın. Aspose.Slides bu alanları her kaydetmede yeniden yazar; bu nedenle kaydedilen bir sunum her zaman “Aspose.Slides for Java” ve onu üreten kütüphanenin sürümünü rapor eder. **DocumentProperties.setNameOfApplication**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#setNameOfApplication](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/#setNameOfApplication)’a geçirilen herhangi bir değer, sunum yazıldığında göz ardı edilir.
{{% /alert %}}

## **PowerPoint'ta Belge Özellikleri**

Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmenize olanak tanır. Aşağıda gösterildiği gibi Office simgesine tıklayın ve **Prepare | Properties | Advanced Properties** seçeneğini seçin:

|**Gelişmiş Özellikler menüsü öğesini seçme**|
| :- |
|![PowerPoint belge özellikleri](https://i.imgur.com/ZrmuCD6.jpg)|

**Advanced Properties** seçtikten sonra, PowerPoint dosyasının belge özelliklerini yönetebileceğiniz bir iletişim kutusu görüntülenir:

|**Özellikler İletişim Kutusu**|
| :- |
|![PowerPoint belge özellikleri](https://i.imgur.com/LibmdQd.jpg)|

**Properties Dialog** **General**, **Summary**, **Statistics**, **Contents** ve **Custom** gibi sekmeler içerir. Bu sekmeler, PowerPoint dosyaları hakkında farklı türde bilgiler yapılandırmanıza olanak tanır. Özel özellikleri yönetmek için **Custom** sekmesini kullanın.

## **Aspose.Slides for Python via Java Kullanarak Belge Özellikleriyle Çalışma**

Yukarıda açıklandığı gibi, Aspose.Slides for Python via Java hem **Built-in** hem de **Custom** belge özelliklerini destekler. **DocumentProperties**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/) sınıfı, bir sunum dosyasıyla ilişkili belge özelliklerini temsil eder.

Bu özelliklere **Presentation.getDocumentProperties**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getDocumentProperties) ile erişin.

## **Şifreli Bir Sunumdan Genel Özellikleri Okuma**

Açma parolası, genellikle sunum içeriğini ve belge özelliklerini korur. **ProtectionManager.setEncryptDocumentProperties**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties)‘a `false` geçirilerek bir sunum şifrelendiğinde, belge özellikleri genel kalır. Bir uygulama daha sonra **LoadOptions.setOnlyLoadDocumentProperties**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties)‘a `true` geçirerek açma parolasını sağlamadan genel üst verileri okuyabilir.

Belge‑özellikleri‑yalnızca seçeneği, Aspose.Slides’ın neyi yüklediğini kontrol eder; hiçbir şeyi şifre çözmez. Özellikler şifreleme içinde dahil edilmişse, parolasız yükleme başarısız olur. Sunum şifrelenmemişse, seçenek yok sayılır ve tam sunum yüklenir.

Aşağıdaki örnek, **ProtectionManager.isOnlyDocumentPropertiesLoaded**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) aracılığıyla yükleme modunu doğrular ve ardından **Presentation.getDocumentProperties**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getDocumentProperties) ile yerleşik özellikleri okur:

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

Bu modda slayt içeriği yüklenmez. Slaytlar, ana şablonlar, düzenler, şekiller, medya ve diğer sunum nesneleri kullanılamaz. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman **ProtectionManager.isOnlyDocumentPropertiesLoaded**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/tr/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) kontrol etmelidir.

{{% alert color="warning" title="Uyarı" %}}
Genel üst veriler yazar adları, başlıklar, konular, anahtar kelimeler, şirket bilgileri, yorumlar ve özel değerleri ortaya çıkarabilir. Hassas özellikleri sunumla birlikte şifreleyin. Yalnızca indeksleme, sınıflandırma, arama veya belge‑yönetim sistemlerinin parola olmadan erişim gerektirdiği durumlarda genel bırakın.
{{% /alert %}}

## **Şifreli Bir Sunumun Özelliklerini Güncelleme**

Şifreli bir PPTX dosyası için, belge‑özellikleri‑yalnızca modunda yüklü bir sunum, yalnızca genel üst verileri okumak içindir. Aspose.Slides, bu yalnızca‑üst‑veri nesnesindeki değiştirilen özellikleri kaydedemez; çünkü genel özellikler şifreli sunum içindeki ilgili verilerle tutarlı olmalıdır. Bu nedenle güncelleme, doğru açma parolasını sağlayarak tam yükleme gerektirir.

Aşağıdaki örnek, **LoadOptions.setPassword**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setPassword](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setPassword) ile sunumu açar, genel yerleşik özellikleri günceller ve sonucu kaydeder. Ardından **PresentationInfo.isEncrypted**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#isEncrypted](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#isEncrypted) kullanarak şifrelemenin korunduğunu doğrular ve yeni değerleri kontrol etmek için parolasız olarak genel üst verileri tekrar açar:

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

Bir uygulama sunum içeriğini şifreleyemiyor veya yükleyemiyorsa, şifreli bir PPTX dosyasının genel özelliklerini yalnızca okuma‑yazma olarak değerlendirmelidir.

## **Yerleşik Özelliklere Erişim**

**DocumentProperties**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/](https://reference.aspose.com/slides/tr/python-java/aspose.slides/documentproperties/) tarafından sunulan yerleşik özellikler şunlardır: **Creator** (Yazar), **Description**, **Created** (Oluşturulma Tarihi), **Modified** (Değiştirilme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **Keywords**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Sunumu temsil eden Presentation sınıfını örnekleyin
presentation = Presentation("Presentation.pptx")
try:
    # Presentation ile ilişkili DocumentProperties nesnesine bir referans oluşturun
    properties = presentation.getDocumentProperties()

    # Yerleşik özellikleri görüntüle
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Yerleşik Özellikleri Değiştirme**

Yerleşik özellikleri değiştirmek, onlara erişmek kadar basittir. Yeni bir değer atamak için ilgili ayarlayıcıyı kullanın. Aşağıdaki örnek, Aspose.Slides for Python via Java kullanarak yerleşik belge özelliklerini değiştirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Presentation ile ilişkili DocumentProperties nesnesine bir referans oluşturun
    properties = presentation.getDocumentProperties()

    # Yerleşik özellikleri ayarlayın
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Sunumunuzu bir dosyaya kaydedin
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bu örnek, aşağıda gösterildiği gibi sunumun yerleşik özelliklerini değiştirir:

|**Değişiklikten Sonra Yerleşik Belge Özellikleri**|
| :- |
|![PowerPoint belge özellikleri](https://i.imgur.com/zz1N9de.jpg)|

## **Özel Belge Özellikleri Ekleme**

Aspose.Slides for Python via Java, geliştiricilerin sunumlara özel belge özellikleri eklemesine de izin verir. Aşağıdaki örnek üç özel özellik ekler, ardından 2. indekste saklanan adı bulur ve bu özelliği kaldırır; böylece kaydedilen sunum iki özelliği tutar. Özel özellikler alfabetik sırayla indekslenir, eklenme sırasına göre değil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Belge Özelliklerini Almak
    properties = presentation.getDocumentProperties()

    # Özel özellikler ekleme
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Belirli bir indeksdeki özellik adını alıyor
    property_name = properties.getCustomPropertyName(2)

    # Seçilen özelliği kaldırma
    properties.removeCustomProperty(property_name)

    # Sunumu kaydetme
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Eklenmiş Özel Belge Özellikleri**|
| :- |
|![PowerPoint belge özellikleri](https://i.imgur.com/HdKcxI9.png)|

## **Özel Özelliklere Erişim ve Değiştirme**

Aspose.Slides for Python via Java, geliştiricilerin özel özellik değerlerine erişmesine de imkan tanır. Aşağıdaki örnek, bir sunumdaki tüm özel özelliklere nasıl erişileceğini ve değiştirileceğini gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Presentation ile ilişkili DocumentProperties nesnesine bir referans oluşturun
    properties = presentation.getDocumentProperties()

    # Özel özelliklere eriş ve değiştir
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Özel özelliklerin adlarını ve değerlerini görüntüle
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Özel özelliklerin değerlerini değiştir
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Sunumunuzu bir dosyaya kaydedin
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bu örnek, [PPTX](https://docs.fileformat.com/presentation/pptx/) sunumunun özel özelliklerini değiştirir. Aşağıdaki figürler, değişiklik öncesi ve sonrası sunum özel özelliklerini gösterir:

|**Değişiklik Öncesi Özel Özellikler**|
| :- |
|![PowerPoint belge özellikleri](https://i.imgur.com/Ze7YHvi.jpg)|

|**Değişiklik Sonrası Özel Özellikler**|
| :- |
|![PowerPoint belge özellikleri](https://i.imgur.com/Tofu0CL.jpg)|

## **Gelişmiş Belge Özellikleri**

{{% alert color="info" title="Not" %}}
Yeni yöntemler **readDocumentProperties**, **updateDocumentProperties** ve **writeBindedPresentation**, **PresentationInfo** sınıfına eklenmiştir; ayrıca **DocumentProperties.setLastSavedTime** metodunun davranışı değiştirilmiştir.
{{% /alert %}}

İki yeni yöntem **readDocumentProperties** ve **updateDocumentProperties**, **PresentationInfo** sınıfına eklenmiştir. Bu yöntemler, belge özelliklerine hızlı erişim sağlar ve tüm sunumu yüklemeden özellikleri değiştirme ve güncelleme imkanı tanır.

Özellikleri yükleme, değerlerini değiştirme ve belgeyi güncelleme tipik iş akışı aşağıdaki gibi uygulanabilir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Sunum bilgilerini oku
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Mevcut özellikleri al
properties = presentation_info.readDocumentProperties()

# Yazar ve Başlık alanlarının yeni değerlerini ayarla
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Sunumu yeni değerlerle güncelle
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

Belirli bir sunumun özelliklerini şablon olarak kullanıp diğer sunumlarda özellikleri güncellemenin başka bir yolu da vardır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

Sıfırdan yeni bir şablon oluşturulabilir ve ardından birden fazla sunumu güncellemek için kullanılabilir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **Düzeltme Diline Ayar**

Aspose.Slides, **PortionFormat.setLanguageId**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/#setLanguageId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/#setLanguageId) metodunu sağlar; bu metod, bir PowerPoint belgesi için düzeltme dilini ayarlamanıza olanak tanır. Düzeltme dili, sunumdaki yazım ve dilbilgisi denetiminin yapılacağı dildir.

Bu Python kodu, bir PowerPoint için düzeltme dilinin nasıl ayarlanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # set the Id of a proofing language

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Varsayılan Dile Ayar**

Bu Python kodu, tüm bir PowerPoint sunumu için varsayılan dilin nasıl ayarlanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # Metin içeren bir dikdörtgen şekil ekler
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # İlk bölümün dilini kontrol eder
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Canlı Örnek**

Aspose.Slides API'si aracılığıyla belge özellikleriyle nasıl çalışılacağını görmek için **[Aspose.Slides Metadata](https://products.aspose.app/slides/tr/metadata)** çevrimiçi uygulamasını deneyin:

[![PowerPoint Üst Verilerini Görüntüle ve Düzenle](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, izin verilen bir özellik ise değerlerini değiştirebilir veya boş bir değere ayarlayabilirsiniz.

**Zaten var olan bir özel özelliği eklersem ne olur?**

Var olan bir özel özelliği eklediğinizde, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak değeri günceller.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. **PresentationFactory.getPresentationInfo**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/#getPresentationInfo](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) ve ardından **PresentationInfo.readDocumentProperties**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#readDocumentProperties](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationinfo/#readDocumentProperties) kullanarak bir **Presentation**[https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği oluşturmadan saklanan belge üst verilerini okuyabilirsiniz. Tam raporlama örneği ve format‑spesifik sınırlamalar için **[Build a Lightweight Presentation Inventory](/slides/tr/python-java/examine-presentation/)** bölümüne bakın.

**Şifreli bir sunumun genel özelliklerini açma parolasını bilmeden okuyabilir miyim?**

Evet. Belge‑özelliği şifrelemesi, sunum şifrelenmeden önce devre dışı bırakılmış olmalı ve sunum belge‑özellikleri‑yalnızca modunda yüklenmiş olmalıdır.

**Şifreli bir PPTX dosyasını belge‑özellikleri‑yalnızca modunda güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalıdır; bu nedenle bir şifreli PPTX dosyasını güncellemek, doğru açma parolasıyla tam yükleme gerektirir.