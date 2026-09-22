---
title: C++'ta Sunum Bilgilerini Alma ve Güncelleme
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
description: "C++ kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin; daha hızlı içgörüler ve daha akıllı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumun formatını tanımlayabilir ve tam bir sunum nesne modelini oluşturmadan belge meta verilerini okuyabilir. Bu, dosyaları sınıflandırmanız, bir envanter oluşturmanız veya içerikleri yükleyip işlemeye karar vermeden önce özellikleri incelemeniz gerektiğinde faydalıdır.

Bu makale, [PresentationFactory](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentationfactory/) ve [IPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/) aracılığıyla hafif denetimi ve [IDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/) ile hedefe yönelik güncellemeleri gösterir.

## **Bir Sunum Formatını Kontrol Etme**

Yüklenmiş bir sunumunuz zaten varsa, yüklemeden sonra tespit için [Determine the Original Presentation Format](/slides/tr/cpp/detect-presentation-source-format/) bölümüne ve eski PPT, PPS ve POT akışlarının sınırlamalarına bakın.

Bir dosyayı [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneği oluşturmayarak incelemek için [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) kullanın. [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/get_loadformat/) yöntemi, PPTX, PPT veya ODP gibi tespit edilen formatı raporlar.

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

## **Hafif Bir Sunum Envanteri Oluşturma**

Birçok sunum dosyasını işlediğinizde, doğrulama, indeksleme veya belge yönetim sistemi için kompakt bir envantere ihtiyacınız olabilir. Bu senaryoda, [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) kullanarak bir [IPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/) nesnesi alın ve ardından [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) çağırarak belge meta verilerini okuyun. Bu yaklaşım bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneği oluşturmaz ve tam sunum nesne modelinde gezinmeyi gerektirmez.

[IDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/) tarafından sunulan genişletilmiş özellikler aşağıdaki envanter değerlerini sağlar:

| Yöntem | Envanter değeri |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_slides/) | Toplam slayt sayısı. |
| [get_HiddenSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Gizli slaytların sayısı. |
| [get_Notes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_notes/) | Not içeren slaytların sayısı. |
| [get_Paragraphs](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Mevcut olduğunda toplam paragraf sayısı. |
| [get_Words](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_words/) | Toplam kelime sayısı. |
| [get_MultimediaClips](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Toplam ses ve video klip sayısı. |

Aşağıdaki örnek bu değerleri bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesi oluşturmadan okur ve kompakt bir envanter yazdırır. Ayrıca [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_headingpairs/) ile [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) birleştirilerek yazı tipleri, temalar ve slayt başlıkları gibi içerik grupları gösterilir.

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

Her [IHeadingPair](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iheadingpair/) grup adını [IHeadingPair::get_Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iheadingpair/get_name/) aracılığıyla ve bu gruptaki öğe sayısını [IHeadingPair::get_Count](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iheadingpair/get_count/) aracılığıyla sağlar. [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) düz, sıralı bir dizi döndürdüğünden, her başlık çiftinde belirtilen ardışık başlık sayısını tüketin.

### **Depolanmış Meta Veri ve Format Sınırlamaları**

[IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) tarafından döndürülen envanter özellikleri, kaynak belgede mevcut meta verileri yansıtır. Aspose.Slides bu çağrı için bu değerleri yeniden hesaplamak üzere sunum nesne modelini yüklemez ve gezmez. Eksik özellikler varsayılan değerlerle temsil edilir ve depolanmış değerler, dosyayı son kaydeden uygulama belge özelliklerini güncellemediyse eski olabilir.

- **PPTX:** Format, slayt, not, gizli‑slayt, paragraf, kelime ve multimedya sayımları ile başlık çiftleri ve bölüm başlıkları için genişletilmiş belge özellikleri sağlar. Kullanılabilirlik, belge üreticisinin hangi özellikleri yazdığına bağlıdır.
- **PPT:** İkili format, karşılık gelen belge‑özet özelliklerini saklayabilir. Bir özellik yoksa veya belge üreticisi tarafından yenilenmemişse, Aspose.Slides bu özelliği slaytlardan hesaplamak yerine depolanmış ya da varsayılan değerini döndürür.
- **ODP:** OpenDocument meta verileri, sayfa, paragraf ve kelime sayısı gibi genel belge istatistikleri sağlar, ancak bu değerler her PowerPoint‑özel genişletilmiş özelliğe eşlenmez. Gizli‑slayt, not‑slayt, multimedya, başlık‑çifti ve bölüm‑başlığı meta verileri mevcut olmayabilir ve envanter özellikleri varsayılan değerleri döndürebilir. Sıfır değeri veya boş dizi, ilgili içeriğin yok olduğunun kesin kanıtı olarak değerlendirilmemelidir.

Envanter ve ön kontrol için hafif meta veri yaklaşımını kullanın. Sonuçların bellek içi değişiklikleri yansıtması gerektiğinde veya gerçek sunum içeriğini doğrulamanız gerektiğinde sunumu yükleyin ve canlı nesne modelini inceleyin.

## **Sunum Özelliklerini Güncelleme**

[IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) tarafından döndürülen özellikler, bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneği oluşturulmadan da değiştirilebilir. Değişiklikleri [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) ile uygulayın ve ardından bağlı sunumu [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/) ile yazın.

Aşağıdaki görsel, orijinal belge özelliklerini gösterir.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Aşağıdaki örnek başlığı ve son‑kaydetme zamanını değiştirir ve sonucu yeni bir dosyaya yazar:

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

Aşağıdaki görsel, güncellenmiş belge özelliklerini gösterir.

![PowerPoint sunumunun değiştirilmiş belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

İlgili güvenlik kontrolleri ve koruma ayarları için aşağıdaki makalelere bakın:

- [Password-Protect Presentations](/slides/tr/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/tr/cpp/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunumu yükleyin ve [Presentation::get_FontsManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_fontsmanager/) kullanın. Gömülü yazı tiplerini elde etmek için [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/getembeddedfonts/), sunumda kullanılan yazı tiplerini elde etmek için ise [FontsManager::GetFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/getfonts/) çağırın. İki sonucu karşılaştırarak render için gerekli ama gömülü olmayan yazı tiplerini bulun.

**Dosyanın gizli slaytları olup olmadığını ve kaç tane olduğunu hızlıca nasıl öğrenebilirim?**

Depolanmış belge meta verileri yeterli olduğunda, [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) ve [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) aracılığıyla [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) okuyun. Bu, hafif bir envanter için uygundur. Sunum bellek içinde değiştirilmişse, depolanmış meta veriler eksik veya eski olabilir; ya da canlı değerleri doğrulamanız gerekiyorsa, [Presentation::get_Slides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_slides/) üzerinden döngü kurun ve her slaydın [Slide::get_Hidden](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/get_hidden/) metodunu inceleyin.

**Özel slayt boyutu ve yöneliminin kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını nasıl tespit edebilirim?**

Evet. Sunumu yükleyin ve [Presentation::get_SlideSize](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_slidesize/) okuyun. Mevcut ayarları beklenen ön ayar ve boyutlarla karşılaştırmak için [ISlideSize::get_Type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidesize/get_size/) ve [ISlideSize::get_Orientation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidesize/get_orientation/) özelliklerini inceleyin.

**Grafiklerin harici veri kaynaklarına başvurup başvurmadığını hızlıca görmenin bir yolu var mı?**

Evet. Her bir [Chart](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chart/) bulun ve [ChartData::get_DataSourceType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) incele. Harici bir çalışma kitabı için [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) okuyun. Veri kaynağı türü ve yol, harici bir referansı tanımlar; ancak hedefin mevcut olup olmadığını doğrulamak ayrı bir kaynak kontrolü gerektirir.

**Render veya PDF dışa aktarmayı yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Tek bir karmaşıklık özelliği yoktur. [Presentation::get_Slides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_slides/) ve her slaydın [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/get_shapes/) koleksiyonunu dolaşın. Şekil sayısı, büyük görüntüler, efektler, animasyonlar veya multimedya varlığı gibi sinyalleri tarama işareti olarak kullanın ve bir slaydın kesin bir performans darboğazı olduğunu doğrulamak için temsili bir render ya da dışa aktarım ölçümü yapın.