---
title: C++'ta Sunum Bilgilerini Al ve Güncelle
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
- PPTX incel
- PPT incel
- ODP incel
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "C++ kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin, daha hızlı içgörüler ve daha akıllı içerik denetimleri sağlayın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum bilgilerini nasıl inceleyeceğinizi gösterir. Sunumun tam dosyasını yüklemeden geçerli formatını belirleme, belge özelliklerini okuma ve gerektiğinde bu özellikleri güncelleme konularını açıklar.

Örnekler, [PresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentationinfo/) ve [DocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/documentproperties/) API'lerine dayanır ve sunum meta verileriyle çalışmak için tipik işlemleri sergiler.

## **Sunum Biçimini Kontrol Et**

Bir sunumla çalışmadan önce, o anki sunumun hangi formatta (PPT, PPTX, ODP ve diğerleri) olduğunu öğrenmek isteyebilirsiniz.

Sunumun formatını sunumu yüklemeden kontrol edebilirsiniz. Aşağıdaki C++ koduna bakın:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Sunum Özelliklerini Al**

Bu C++ kodu, sunum özelliklerini (sunum hakkında bilgiler) nasıl alacağınızı gösterir:

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ..
```

## **Sunum Özelliklerini Güncelle**

Aspose.Slides, sunum özelliklerinde değişiklik yapmanıza olanak tanıyan [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) yöntemini sağlar.

Aşağıda gösterilen belge özelliklerine sahip bir PowerPoint sunumumuz var.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Bu kod örneği, bazı sunum özelliklerini nasıl düzenleyeceğinizi gösterir:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Belge özelliklerinin değiştirilmesinin sonuçları aşağıda gösterilmiştir.

![PowerPoint sunumunun değiştirilen belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

Sunum ve güvenlik öznitelikleri hakkında daha fazla bilgi edinmek isterseniz aşağıdaki bağlantılar yararlı olabilir:

- [Sunumları Parola ile Koruma](/slides/tr/cpp/password-protected-presentation/)
- [Sunumları Yazma Koruması](/slides/tr/cpp/write-protected-presentation/)

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangi tiplerin gömülü olduğunu nasıl kontrol ederim?**

Sunum düzeyinde [embedded-font information](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/getembeddedfonts/) arayın, ardından bu girişleri [belgeler içinde gerçekte kullanılan yazı tipleri](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/getfonts/) kümesiyle karşılaştırarak hangi yazı tiplerinin render için kritik olduğunu belirleyin.

**Dosyada gizli slaytlar olup olmadığını ve sayısının kaç olduğunu hızlıca nasıl öğrenirim?**

[slide collection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slidecollection/) içinde döngü yapın ve her slaydın [visibility flag](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/get_hidden/) özelliğini inceleyin.

**Özel slayt boyutu ve yöneliminin kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını nasıl tespit ederim?**

Evet. Mevcut [slide size and orientation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_slidesize/) değerini standart ön ayarlarla karşılaştırın; bu, yazdırma ve dışa aktarma davranışını öngörmeye yardımcı olur.

**Grafiklerin dış veri kaynaklarına başvurup başvurmadığını hızlıca nasıl görebilirim?**

Evet. Tüm [charts](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chart/) öğelerini dolaşın, [data source](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) türünü kontrol edin ve verinin dahili mi yoksa bağlantı temelli mi olduğunu, kırık bağlantılar dahil, not edin.

**Render veya PDF dışa aktarımını yavaşlatabilecek 'ağır' slaytları nasıl değerlendiririm?**

Her slayt için nesne sayılarını toplayın ve büyük resimler, şeffaflık, gölgeler, animasyonlar ve multimedya öğeleri arayın; potansiyel performans sorunlarını işaretlemek için kabaca bir karmaşıklık puanı atayın.