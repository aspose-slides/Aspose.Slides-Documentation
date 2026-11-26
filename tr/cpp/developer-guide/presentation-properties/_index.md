---
title: C++'da Sunum Özelliklerini Yönetme
linktitle: Sunum Özellikleri
type: docs
weight: 70
url: /tr/cpp/presentation-properties/
keywords:
- PowerPoint özellikleri
- sunum özellikleri
- belge özellikleri
- gömülü özellikler
- özel özellikler
- ileri düzey özellikler
- özellikleri yönetme
- özellikleri değiştirme
- belge meta verileri
- meta verileri düzenleme
- düzeltme dili
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'da sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda aramayı, markalaşmayı ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides for C++ **gömülü** ve **özelleştirilmiş** belge özelliklerini destekler. Bu özellikleri, yazar, başlık ve kullanıcı tanımlı değerler gibi sunum meta verilerini okumak ve güncellemek için kullanın.

Aspose.Slides, sunum belge özellikleriyle [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) arayüzü üzerinden çalışmanıza olanak tanır. Bu arayüzün bir örneği, [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) tarafından döndürülür. Aşağıdaki örnekler, bu özellikleri nasıl okuyacağınızı, değiştireceğinizi ve yöneteceğinizi gösterir.

{{% alert color="info" title="Note" %}}

Aspose.Slides, sunumları kaydederken uygulama ve üretici meta verilerini yönetir; bu alanlar, çıktıyı oluşturan yazılımı tanımlar.

{{% /alert %}}

## **Sunum Özelliklerini Yönetme**

Belge özellikleri, sunum içeriğiyle birlikte tanımlayıcı bilgiler saklar. İki kategoriye ayrılırlar:

- **Yapılandırılmış özellikler** başlık, yazar ve belge istatistikleri gibi standart meta verileri içerir.
- **Özelleştirilmiş özellikler** kullanıcı tanımlı ad/değer çiftlerini saklar.

Aspose.Slides for C++ her iki kategoriye de erişim sağlar. PowerPoint’te belge meta verilerini incelemek için **Dosya → Bilgi → Özellikler → Gelişmiş Özellikler** seçeneğini seçin. İletişim kutusu, **Özet**, **İstatistikler**, **İçerik** ve **Özelleştirilmiş** gibi sekmelere bilgi gruplar. Kullanıcı tanımlı özellikleri yönetmek için **Özelleştirilmiş** sekmesini kullanın.

## **Şifreli Bir Sunumdan Genel Özellikleri Okuma**

Açma şifresi genellikle hem sunum içeriğini hem de belge özelliklerini korur. Belge özellikleri, [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) metoduna `false` aktarılarak şifrelenirse, bu özellikler hâlâ genel olarak kalır. Bir uygulama daha sonra [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) metoduna `true` aktararak, açma şifresi vermeden genel meta verileri okuyabilir.

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) Aspose.Slides’in neyi yükleyeceğini kontrol eder; hiçbir şeyi çözmez. Özellikler şifreleme içinde yer alıyorsa, şifre olmadan yükleme başarısız olur. Sunum şifreli değilse, seçenek göz ardı edilir ve tam sunum yüklenir.

Örnek, belge özellikleri genel bırakılmış şifreli bir sunumu gerektirir. Yükleme modunu [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) ile doğrular ve ardından [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) aracılığıyla gömülü özellikleri okur:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Bu modda slayt içeriği yüklenmez. Slaytlar, ana şablonlar, düzenler, şekiller, medya ve diğer sunum nesneleri kullanılamaz. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) kontrol etmelidir.

{{% alert color="warning" title="Security" %}}
Genel meta veriler yazar adları, başlıklar, konu, anahtar kelimeler, şirket bilgileri, yorumlar ve özelleştirilmiş değerleri açığa çıkarabilir. Hassas özellikleri sunumla birlikte şifreleyin. Yalnızca indeksleme, sınıflandırma, arama veya belge yönetim sistemlerinin şifre olmadan erişim gerektirdiği durumlarda genel bırakın.
{{% /alert %}}

## **Şifreli Bir Sunumun Özelliklerini Güncelleme**

Şifreli bir PPTX dosyası için, [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) metoduna `true` aktararak yüklenen sunum, yalnızca genel meta verileri okumak içindir. Aspose.Slides, bu yalnızca meta veri nesnesinden değiştirilen özellikleri kaydedemez çünkü genel özellikler şifreli sunum içindeki karşılık gelen verilerle tutarlı olmalıdır. Bu nedenle güncelleme için doğru açma şifresi ve tam yükleme gerekir.

Örnek, genel belge özelliklerine sahip şifreli bir PPTX sunumu ve bilinen bir açma şifresi gerektirir. Sunumu, [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) ile tamamen açar, genel gömülü özellikleri günceller ve sonucu kaydeder. Ardından [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) kullanarak şifrelemenin korunduğunu doğrular ve yeni değerleri kontrol etmek için şifresiz olarak genel meta verileri yeniden açar:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Uygulama, sunum içeriğini çözümleyemiyor veya yükleyemiyorsa, şifreli bir PPTX dosyasının genel özelliklerini yalnızca okuma amaçlı kullanmalıdır.

## **Yapılandırılmış Özelliklere Erişim**

[IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) arayüzü, [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/) ve [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/) gibi tiplenmiş getter’lar aracılığıyla gömülü meta verileri ortaya çıkarır. Bu örnek mevcut bir sunumu açar ve saklanan meta verileri konsola yazar. Değerler giriş sunumuna bağlıdır; bazı alanlar boş olabilir.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

### **Revizyon Numarası ve Düzenleme Süresini Raporlama**

[GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) ve [ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) kullanarak, slaytları yüklemeden her dosyanın [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) okunabilir. Bu örnek, `presentations` klasöründeki her PPTX dosyası için bir satır yazdırır. Standart `c` biçimi, kaydedilen düzenleme süresi 24 saate ulaştığında gün sayılarını içerir.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/timespan.h>

using namespace Aspose::Slides;
using namespace System::IO;

System::Console::WriteLine(u"File | RevisionNumber | TotalEditingTime");
auto paths = Directory::GetFiles(u"presentations", u"*.pptx");
for (const auto& path : paths)
{
    auto info = PresentationFactory::get_Instance()->GetPresentationInfo(path);
    auto properties = info->ReadDocumentProperties();
    auto fileName = Path::GetFileName(path);
    auto editingTime = properties->get_TotalEditingTime().ToString(u"c");
    System::Console::WriteLine(u"{0} | {1} | {2}", fileName, properties->get_RevisionNumber(), editingTime);
}
```

1 gün, 2 saat ve 5 dakika kaydedilmiş düzenleme süresi olan bir sunum için rapor şu şekilde görünür:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[get_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_revisionnumber/) bir meta veri değerini okur; uygulamalar bunu [set_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_revisionnumber/) ile değiştirebilir. Bu değer tek başına, sunumun kaç kez kaydedildiğini ya da sürüm geçmişini göstermez.

[get_TotalEditingTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_totaleditingtime/) dosyada kaydedilen düzenleme süresini döndürür. `00:00:00` değeri, saklanan sürenin sıfır olduğunu gösterir. Sunum hâlâ düzenlenmiş olabilir.

## **Yapılandırılmış Özellikleri Değiştirme**

Yapılandırılmış meta verileri güncellemek için, [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) tarafından döndürülen nesnenin setter’larını kullanın. Bu örnek mevcut bir sunumu açar, [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/) ve [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/) metodlarını çağırır ve ardından [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) ile güncellenmiş sunumu kaydeder. Kaydedilen PPTX yeni meta verileri içerir.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Köprü Temelini Yönetme**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) belge düzeyindeki göreli köprüler için temeli okur. Bu, bir sunumu ve ilişkilendirilmiş dosyalarını başka bir konuma taşırken faydalıdır. Bu, bireysel bir köprünün [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) özelliğinden ayrı bir ayardır; temeli değiştirmek saklanan bağlantı adreslerini yeniden yazmaz ya da mutlak hedefleri değiştirmez.

Örnek, `target.html` gibi bir göreli bağlantı ve `https://example.org/absolute.html` gibi bir mutlak bağlantı içeren bir sunum gerektirir. Mevcut temeli okur, [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/) ile yeni bir temel adresi atar, sunumu kaydeder ve temelin değerini kontrol etmek için tekrar açar. Ardından temeli `u""` ile temizler ve ayrı bir kaydedilmiş dosyada boş değeri doğrular. Örnek temel adresi, bağlantılı dosyalarınızın konumuyla değiştirin.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

İki doğrulama mesajı da `True` yazdırmalıdır. Temelin temizlenmesi, bireysel köprü adreslerini etkilemez.

Temel `old` klasörüne işaret ederken `target.pptx` göreli bağlantısı `old/target.pptx` dosyasını açtı. Temel `new` klasörüne değiştirildikten, kaydedilip sunum tekrar açıldığında aynı bağlantı `new/target.pptx` dosyasını açtı. Mutlak bağlantı aynı dosyayı açmaya devam etti. PowerPoint’te, sunumu taşıma veya temelini değiştirmeden önce ve sonra göreli bağlantılarınızı test edin.

## **Özelleştirilmiş Sunum Özellikleri Ekleme**

Özelleştirilmiş özellikler, karşılık gelen bir gömülü alanı olmayan meta verileri saklar. [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) bir özelliğin adını kullanarak değer atamanıza olanak verir. Bu örnek bir sunum oluşturur, iki metin değeri ve bir tam sayı sürüm değeri ekler ve sunumu [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) ile kaydeder. Var olan bir ada değer atamak, o özelliğin değerini değiştirir.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Özelleştirilmiş Özellikleri Erişme ve Değiştirme**

Bu örnek, özelleştirilmiş özellikler içeren bir sunumu açar ve [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) ile bunları dolaşır. [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) sıfır tabanlı bir dizin alır ve [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) ve [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) tarafından kullanılan adı döndürür. Örnek, her özgün adı ve değeri yazdırır, her değeri tipine bakılmaksızın numaralı bir dizeyle değiştirir ve değişiklikleri kaydeder. Özelleştirilmiş özellik yoksa döngü hiçbir değişiklik yapmaz.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **Canlı Örnek**

Belge özellikleriyle Aspose.Slides API’si kullanarak nasıl çalışılacağını görmek için çevrimiçi uygulama **[View & Edit PowerPoint Metadata](https://products.aspose.app/slides/metadata)**’yi deneyin:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **SSS**

**Bir sunumdan gömülü bir özelliği nasıl kaldırabilirim?**

Gömülü özellikler sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli bir özellik izin veriyorsa değerlerini değiştirebilir veya boş olarak ayarlayabilirsiniz.

**Zaten mevcut bir özelleştirilmiş özellik eklersem ne olur?**

Zaten mevcut bir özelleştirilmiş özellik eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Özelliği önceden kaldırmanıza veya kontrol etmenize gerek yoktur; Aspose.Slides otomatik olarak özelliğin değerini günceller.

**Sunumu tam olarak yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) ardından [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) kullanarak bir [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) örneği oluşturmadan saklanan belge meta verilerini okuyabilirsiniz. Tam raporlama örneği ve biçime özgü sınırlamalar için **[Build a Lightweight Presentation Inventory](/slides/tr/cpp/examine-presentation/)** bölümüne bakın.

**Şifreli bir sunumun genel özelliklerini açma şifresi olmadan okuyabilir miyim?**

Evet. Sunum, [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) metoduna `false` aktararak şifrelenmiş olmalı ve [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) metoduna `true` aktararak yüklenmiş olmalıdır.

**Belge‑özellikleri‑yalnızca modunda şifreli bir PPTX dosyasını güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalıdır; bu nedenle şifreli bir PPTX dosyasını güncellemek, doğru açma şifresiyle tam sunumu yüklemeyi gerektirir.