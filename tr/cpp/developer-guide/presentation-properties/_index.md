---
title: "C++'ta Sunum Özelliklerini Yönet"
linktitle: "Sunum Özellikleri"
type: docs
weight: 70
url: /tr/cpp/presentation-properties/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta sunum özelliklerini yönetin ve PowerPoint ve OpenDocument dosyalarınızda arama, marka oluşturma ve iş akışını kolaylaştırın."
---
## **Giriş**

Aspose.Slides iki tür belge özelliğini destekler: **Built-in** ve **Custom**. Bu özellik türlerinin her ikisi de Aspose.Slides API'si kullanılarak kolayca erişilebilir ve yönetilebilir.

Aspose.Slides, sunum belge özellikleriyle çalışmanıza [IDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/) arayüzü üzerinden izin verir. Bu arayüzün bir örneği [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_documentproperties/) tarafından döndürülür. Aşağıdaki örnekler bu özellikleri okuma, değiştirme ve yönetme yollarını gösterir.

{{% alert color="info" title="Note" %}}
Lütfen **Application** ve **Producer** alanlarına değer atayamayacağınızı unutmayın, çünkü Aspose Ltd. ve Aspose.Slides for C++ x.x.x bu alanlarda görüntülenecektir.
{{% /alert %}} 

## **Sunum Özelliklerini Yönet**

Microsoft PowerPoint, sunum dosyalarına bazı özellikler ekleme özelliği sağlar. Bu belge özellikleri, belgelerle (sunum dosyalarıyla) birlikte faydalı bilgilerin depolanmasına olanak tanır. Aşağıdaki gibi iki tür belge özelliği bulunur

- Sistem Tanımlı (Built-in) Özellikler
- Kullanıcı Tanımlı (Custom) Özellikler

**Built-in** özellikler, belge başlığı, yazarın adı, belge istatistikleri gibi genel bilgileri içerir. **Custom** özellikler ise kullanıcılar tarafından **İsim/Değer** çiftleri olarak tanımlanan, hem isim hem de değerin kullanıcı tarafından belirlediği özelliklerdir. Aspose.Slides for C++ kullanarak geliştiriciler, hem yerleşik (built-in) hem de özel (custom) özelliklerin değerlerine erişebilir ve bunları değiştirebilir. Microsoft PowerPoint 2007, sunum dosyalarının belge özelliklerini yönetmeye olanak tanır. Tek yapmanız gereken Office simgesine tıklamak ve ardından Microsoft PowerPoint 2007'de **Prepare | Properties | Advanced Properties** menü öğesini seçmektir. **Advanced Properties** menü öğesini seçtikten sonra, PowerPoint dosyasının belge özelliklerini yönetmenizi sağlayan bir iletişim kutusu açılır. **Properties Dialog** içinde **General, Summary, Statistics, Contents ve Custom** gibi birçok sekme sayfası gördüğünüzü fark edeceksiniz. Bu sekme sayfaları, PowerPoint dosyalarıyla ilgili farklı bilgi türlerini yapılandırmanıza olanak tanır. **Custom** sekmesi, PowerPoint dosyalarının özel özelliklerini yönetmek için kullanılır.

## **Şifreli Bir Sunumdan Genel Özellikleri Okuma**

Açma parolası genellikle hem sunum içeriğini hem de belge özelliklerini korur. Bir sunum, [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/)’a `false` geçirilerek şifrelenirse, belge özellikleri genel olarak kalır. Daha sonra bir uygulama, [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/)’a `true` geçirerek açma parolasını sağlamadan genel meta verileri okuyabilir.

`set_OnlyLoadDocumentProperties`, Aspose.Slides'ın neyi yükleyeceğini kontrol eder; hiçbir şeyi çözmez. Özellikler şifreleme içinde yer alıyorsa, parolasız yükleme başarısız olur. Sunum şifrelenmemişse, seçenek yok sayılır ve tam sunum yüklenir.

Aşağıdaki örnek, yükleme modunu [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) üzerinden doğrular ve ardından [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_documentproperties/) aracılığıyla yerleşik (built-in) özellikleri okur:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

Bu modda, slayt içeriği yüklenmez. Slaytlar, masterlar, düzenler, şekiller, medya ve diğer sunum nesneleri kullanılamaz. Uygulamalar, tam sunum nesne modelini gerektiren bir işlem yapmadan önce her zaman `get_IsOnlyDocumentPropertiesLoaded` kontrol etmelidir.

{{% alert color="warning" title="Warning" %}}
Genel meta veriler yazar adlarını, başlıkları, konuları, anahtar kelimeleri, şirket bilgilerini, yorumları ve özel değerleri ifşa edebilir. Hassas özellikleri sunumla birlikte şifreleyin. Bunları yalnızca indeksleme, sınıflandırma, arama veya belge yönetim sistemlerinin parola olmadan erişim gerektirdiği durumlarda genel olarak bırakın.
{{% /alert %}}

## **Şifreli Bir Sunumun Özelliklerini Güncelleme**

Şifreli bir PPTX dosyası için, `set_OnlyLoadDocumentProperties(true)` çağrıldıktan sonra yüklenen sunum, genel meta verileri okumak içindir. Aspose.Slides, yalnızca meta veri nesnesinden değiştirilen özellikleri kaydedemez çünkü genel özellikler, şifreli sunum içindeki ilgili verilerle tutarlı olmalıdır. Bu nedenle güncelleme, doğru açma parolasını ve tam bir yüklemeyi gerektirir.

Aşağıdaki örnek, sunumu [LoadOptions::set_Password](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_password/) ile açar, genel yerleşik (built-in) özellikleri günceller ve sonucu kaydeder. Ardından şifrelemenin korunduğunu doğrulamak için [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) kullanır ve yeni değerleri doğrulamak için parolasız olarak genel meta verileri yeniden açar:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

Bir uygulamanın sunum içeriğini çözüp yüklemesine izin verilmiyorsa, şifreli bir PPTX dosyasının genel özelliklerini yalnızca okunabilir olarak ele almalıdır.

## **Yerleşik Özelliklere Erişim**

Bu özellikler, **IDocumentProperties** nesnesi tarafından sunulan: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Oluşturma Tarihi), **Modified** (Değiştirme Tarihi), **Printed** (Son Yazdırma Tarihi), **LastModifiedBy**, **Keywords**, **SharedDoc** (Farklı üreticiler arasında paylaşılıyor mu?), **PresentationFormat**, **Subject** ve **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Yerleşik Özellikleri Değiştirme**

Sunum dosyalarının yerleşik (built-in) özelliklerini değiştirmek, onlara erişmek kadar kolaydır. İstediğiniz herhangi bir özelliğe basitçe bir string değer atayabilir ve özellik değeri değişir. Aşağıdaki örnekte, sunum dosyasının yerleşik belge özelliklerini nasıl değiştirebileceğimizi gösterdik.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Özel Sunum Özellikleri Ekleme**

Aspose.Slides for C++, geliştiricilerin sunum belge özellikleri için özel değerler eklemesine de izin verir. Aşağıda bir sunum için özel özelliklerin nasıl ayarlanacağını gösteren bir örnek verilmiştir.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation sınıfını örnekle
auto presentation = System::MakeObject<Presentation>();

// Belge Özelliklerini Almak
auto documentProperties = presentation->get_DocumentProperties();

// Özel özellikler ekleme
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Belirli bir indeksteki özellik adını alma
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Seçili özelliği kaldırma
documentProperties->RemoveCustomProperty(getPropertyName);

// Sunumu kaydetme
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Özel Özelliklere Erişme ve Değiştirme**

Aspose.Slides for C++, geliştiricilerin özel özelliklerin değerlerine erişmesine de izin verir. Aşağıda bir sunum için bu özel özelliklerin tümüne nasıl erişileceği ve değiştirileceği gösteren bir örnek verilmiştir.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Düzeltme Dilini Ayarlama**

Aspose.Slides, bir PowerPoint belgesi için düzeltme (proofing) dilini ayarlamanıza izin veren [LanguageId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_languageid/) özelliğini ([PortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/portionformat/) sınıfı tarafından sunulan) sağlar. Düzeltme dili, PowerPoint'te yazım ve dilbilgisi denetiminin yapıldığı dildir.

Bu C++ kodu, bir PowerPoint için düzeltme dilinin nasıl ayarlanacağını gösterir:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// düzeltme dilinin kimliğini ayarla

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Varsayılan Dili Ayarlama**

Bu C++ kodu, tüm bir PowerPoint sunumu için varsayılan dilin nasıl ayarlanacağını gösterir:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Yeni bir dikdörtgen şekli ve metin ekler
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// İlk kısmın dilini kontrol eder
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Canlı Örnek**

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/tr/metadata) çevrimiçi uygulamasını deneyerek Aspose.Slides API'si üzerinden belge özellikleriyle nasıl çalışılacağını görün:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/tr/metadata)

## **SSS**

**Bir sunumdan yerleşik bir özelliği nasıl kaldırabilirim?**

Yerleşik özellikler, sunumun ayrılmaz bir parçasıdır ve tamamen kaldırılamaz. Ancak, belirli özellik izin veriyorsa, değerlerini değiştirebilir veya boş olarak ayarlayabilirsiniz.

**Zaten mevcut bir özel özellik eklersem ne olur?**

Zaten var olan bir özel özellik eklerseniz, mevcut değeri yeni değerle üzerine yazılır. Aspose.Slides özelliğin değerini otomatik olarak güncellediği için önceden silmenize veya kontrol etmenize gerek yoktur.

**Sunumu tamamen yüklemeden sunum özelliklerine erişebilir miyim?**

Evet. [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) kullanın ve ardından bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneği oluşturmadan depolanmış belge meta verilerini okumak için [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) kullanın. Tam bir raporlama örneği ve format‑spesifik sınırlamalar için [Build a Lightweight Presentation Inventory](/slides/tr/cpp/examine-presentation/) bölümüne bakın.

**Şifreli bir sunumun genel özelliklerini açma parolası olmadan okuyabilir miyim?**

Evet. Sunum, `set_EncryptDocumentProperties`'e `false` geçirilerek şifrelenmiş olmalı ve `set_OnlyLoadDocumentProperties`'e `true` geçirilerek yüklenmiş olmalıdır.

**Şifreli bir PPTX dosyasını yalnızca belge‑özellikleri modunda güncelleyebilir miyim?**

Hayır. Genel ve şifreli özellik verileri tutarlı olmalıdır; bu yüzden şifreli bir PPTX dosyasını güncellemek, doğru açma parolasıyla tam bir sunum yüklemeyi gerektirir.