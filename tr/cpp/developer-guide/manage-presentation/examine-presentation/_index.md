---
title: C++'ta Sunum Bilgilerini Getirme ve Güncelleme
linktitle: Sunum Bilgileri
type: docs
weight: 30
url: /tr/cpp/examine-presentation/
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
- C++
- Aspose.Slides
description: "C++ kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve üst verileri keşfedin; daha hızlı içgörüler ve daha akıllı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumun formatını tanımlayabilir ve tam bir sunum nesne modelini oluşturmadan belge üst verilerini okuyabilir. Bu, dosyaları sınıflandırmanız, bir envanter oluşturmanız veya sunum içeriğini yükleyip işlemeye karar vermeden önce özellikleri incelemeniz gerektiğinde yararlıdır.

Bu makale, hafif incelemeyi [PresentationFactory](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentationfactory/) ve [IPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/) aracılığıyla, ayrıca hedefli güncellemeleri [IDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/) üzerinden göstermektedir.

## **Sunum Formatını Kontrol Et**

[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) kullanarak bir dosyayı [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneği oluşturmadan inceleyebilirsiniz. [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/get_loadformat/) yöntemi tespit edilen formatı, örneğin PPTX, PPT veya ODP, bildirir.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Hafif Bir Sunum Envanteri Oluştur**

Birçok sunum dosyasını işlerken, doğrulama, indeksleme veya bir belge yönetim sistemi için kompakt bir envantere ihtiyaç duyabilirsiniz. Bu senaryoda, bir [IPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/) nesnesi elde etmek için [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) kullanın ve ardından belge üst verilerini okumak için [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) metodunu çağırın. Bu yaklaşım bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneği oluşturmaz ve tam sunum nesne modelini dolaşmanızı gerektirmez.

[IDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/) tarafından ortaya çıkarılan genişletilmiş özellikler aşağıdaki envanter değerlerini sağlar:

| Yöntem | Envanter değeri |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_slides/) | Toplam slayt sayısı. |
| [get_HiddenSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Gizli slaytların sayısı. |
| [get_Notes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_notes/) | Not içeren slaytların sayısı. |
| [get_Paragraphs](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Mevcut olduğunda toplam paragraf sayısı. |
| [get_Words](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_words/) | Toplam kelime sayısı. |
| [get_MultimediaClips](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Toplam ses ve video klip sayısı. |

Aşağıdaki örnek, bu değerleri bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesi oluşturulmadan okur ve kompakt bir envanter yazdırır. Ayrıca [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_headingpairs/) ve [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) birleştirerek yazı tipleri, temalar ve slayt başlıkları gibi içerik gruplarını gösterir.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Her bir [IHeadingPair](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iheadingpair/) grup adını [IHeadingPair::get_Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iheadingpair/get_name/) aracılığıyla ve o gruptaki öğe sayısını [IHeadingPair::get_Count](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iheadingpair/get_count/) aracılığıyla sağlar. [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) düz, sıralı bir dizi döndürür; bu nedenle her başlık çifti tarafından belirtilen ardışık başlık sayısını tüketin.

### **Depolanmış Üst Veriler ve Biçim Sınırlamaları**

[IPresentationInfo::ReadDocumentProperties] tarafından döndürülen envanter özellikleri, kaynak belgede bulunan üst verileri yansıtır. Aspose.Slides bu çağrı için bu değerleri yeniden hesaplamak üzere sunum nesne modelini yükleyip dolaşmaz. Eksik özellikler varsayılan değerlerle temsil edilir ve saklanan değerler, dosyayı son kaydeden uygulama belge özelliklerini güncellememişse eski olabilir.

- **PPTX:** Biçim, slayt, not, gizli slayt, paragraf, kelime ve multimedya sayımları için genişletilmiş belge özellikleri, ayrıca başlık çiftleri ve parça başlıkları sağlar. Kullanılabilirlik, belge üreticisinin hangi özellikleri yazdığına bağlıdır.
- **PPT:** İkili biçim, karşılık gelen belge özeti özelliklerini saklayabilir. Bir özellik eksikse veya belge üreticisi tarafından güncellenmemişse, Aspose.Slides bu özelliği slaytlardan hesaplamak yerine saklanan veya varsayılan değerini döndürür.
- **ODP:** OpenDocument üst verileri, sayfa, paragraf ve kelime sayısı gibi genel belge istatistikleri sağlar, ancak bu değerler her PowerPoint'e özgü genişletilmiş özelliğe eşlenmez. Gizli slayt, not slaytı, multimedya, başlık çifti ve parça başlığı üst verileri mevcut olmayabilir ve envanter özellikleri varsayılan değerler döndürebilir. Sıfır değerini veya boş bir diziyi ilgili içeriğin yokluğunun kesin kanıtı olarak değerlendirmeyin.

Envanterler ve ön kontroller için hafif üst veri yaklaşımını kullanın. Sonucun bellekteki değişiklikleri yansıtması gerektiğinde veya gerçek sunum içeriğini doğrulamanız gerektiğinde sunumu yükleyip canlı nesne modelini inceleyin.

## **Sunum Özelliklerini Güncelle**

[IPresentationInfo::ReadDocumentProperties] tarafından döndürülen özellikler, bir [Presentation] örneği oluşturmadan da değiştirilebilir. Değişiklikleri [IPresentationInfo::UpdateDocumentProperties] ile uygulayın ve ardından bağlı sunumu [IPresentationInfo::WriteBindedPresentation] ile yazın.

Aşağıdaki görsel, özgün belge özelliklerini göstermektedir.

![PowerPoint sunumunun özgün belge özellikleri](input_properties.png)

Aşağıdaki örnek, başlığı ve son kaydetme zamanını değiştirir ve sonucu yeni bir dosyaya yazar:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

![PowerPoint sunumunun değiştirilmiş belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

İlgili güvenlik kontrolleri ve koruma ayarları için aşağıdaki makalelere bakın:

- [Parola Korumalı Sunumlar](/slides/tr/cpp/password-protected-presentation/)
- [Yazma Korumalı Sunumlar](/slides/tr/cpp/write-protected-presentation/)

## **Sıkça Sorulan Sorular**

**Yazı tiplerinin gömülü olup olmadığını ve hangi yazı tiplerinin gömülü olduğunu nasıl kontrol edebilirim?**

Sunumu yükleyin ve [Presentation::get_FontsManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_fontsmanager/) kullanın. Gömülü yazı tiplerini elde etmek için [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/getembeddedfonts/), sunum tarafından kullanılan yazı tiplerini elde etmek için ise [FontsManager::GetFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/getfonts/) metodunu çağırın. İki sonucu karşılaştırarak, render için gerekli ancak gömülmemiş yazı tiplerini bulun.

**Dosyada gizli slaytların olup olmadığını ve sayısını nasıl hızlı bir şekilde öğrenebilirim?**

Depolanan belge üst verileri yeterli olduğunda, [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) ve [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) aracılığıyla [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) okuyun. Bu, hafif bir envanter için uygundur. Sunum bellek içinde değiştirilmişse, depolanan üst veriler eksik veya eski olabilir; ya da canlı değerleri doğrulamanız gerekiyorsa, [Presentation::get_Slides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_slides/) üzerinden döngü yapıp her slaydın [Slide::get_Hidden](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/get_hidden/) metodunu inceleyin.

**Özel slayt boyutu ve yöneliminin kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Sunumu yükleyin ve [Presentation::get_SlideSize](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_slidesize/) metodunu okuyun. Mevcut ayarları beklenen ön ayar ve boyutlarla karşılaştırmak için [ISlideSize::get_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidesize/get_size/), ve [ISlideSize::get_Orientation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidesize/get_orientation/) özelliklerini inceleyin.

**Grafiklerin harici veri kaynaklarına başvurup başvurmadığını hızlı bir şekilde görmenin bir yolu var mı?**

Evet. Her bir [Chart](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chart/) öğesini bulun ve [ChartData::get_DataSourceType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) özelliğini inceleyin. Harici bir çalışma kitabı için [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) değerini okuyun. Veri kaynağı türü ve yolu dış referansı gösterir, ancak hedefin mevcut olup olmadığını doğrulamak ayrı bir kaynak kontrolü gerektirir.

**Render süresini veya PDF dışa aktarmayı yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Tek bir karmaşıklık özelliği yoktur. [Presentation::get_Slides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_slides/) ve her slaydın [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/get_shapes/) koleksiyonunu dolaşın. Şekil sayısını ve büyük görseller, efektler, animasyonlar veya multimedya varlığını tarama sinyalleri olarak kullanın ve bir slaydın performans darboğazı olduğunu kesinleştirmeden önce temsilî bir render veya dışa aktarma ölçümü yapın.