---
title: C++ ile Sunum Bilgilerini Al ve Güncelle
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
description: "C++ kullanarak PowerPoint ve OpenDocument sunumlarında slaytları, yapıyı ve meta verileri keşfedin, daha hızlı içgörüler ve daha akıllı içerik denetimleri sağlayın."
---
## **Overview**

Bu makale, Aspose.Slides'te sunum bilgilerini nasıl inceleyeceğinizi gösterir. Tam dosyayı yüklemeden bir sunumun mevcut formatını belirlemeyi, belge özelliklerini okumayı ve gerektiğinde bu özellikleri güncellemeyi açıklar.

Örnekler, [PresentationInfo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentationinfo/) ve [DocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/documentproperties/) API'lerine dayanır ve sunum meta verileriyle çalışmak için tipik işlemleri gösterir.

## **Sunum Formatını Kontrol Et**

Bir sunum üzerinde çalışmaya başlamadan önce, sunumun şu anda hangi formatta (PPT, PPTX, ODP ve diğerleri) olduğunu öğrenmek isteyebilirsiniz.

Sunumun formatını sunumu yüklemeden kontrol edebilirsiniz. Aşağıdaki C++ koduna bakın:

``` cpp
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

Bu C++ kodu, sunum özelliklerini (sunum hakkındaki bilgileri) nasıl alacağınızı gösterir:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **Sunum Özelliklerini Güncelle**

Aspose.Slides, sunum özelliklerinde değişiklik yapmanıza olanak tanıyan [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) yöntemini sağlar.

Aşağıda gösterilen belge özelliklerine sahip bir PowerPoint sunumumuz olduğunu varsayalım.

![PowerPoint sunumunun orijinal belge özellikleri](input_properties.png)

Bu kod örneği, bazı sunum özelliklerini nasıl düzenleyeceğinizi gösterir:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Belge özelliklerini değiştirmenin sonuçları aşağıda gösterilmiştir.

![PowerPoint sunumunun değiştirilen belge özellikleri](output_properties.png)

## **Faydalı Bağlantılar**

Bir sunum ve güvenlik nitelikleri hakkında daha fazla bilgi edinmek için aşağıdaki bağlantılar yararlı olabilir:

- [Bir Sunumun Şifrelenip Şifrelenmediğini Kontrol Etme](https://docs.aspose.com/slides/tr/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Bir Sunumun Yazma Koruması (salt okunur) olup olmadığını kontrol etme](https://docs.aspose.com/slides/tr/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Sunumu Yüklemeden Önce Şifreyle Korunup Korunmadığını Kontrol Etme](https://docs.aspose.com/slides/tr/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Sunumu Korumak İçin Kullanılan Şifreyi Doğrulama](https://docs.aspose.com/slides/tr/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **SSS**

**Yazı tiplerinin gömülü olup olmadığını ve hangileri olduğunu nasıl kontrol edebilirim?**

Sunum seviyesinde [embedded-font information](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/getembeddedfonts/) arayın, ardından bu girdileri içerik boyunca gerçekten kullanılan [içerik boyunca gerçekten kullanılan yazı tipleri](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/getfonts/) kümesiyle karşılaştırarak hangi yazı tiplerinin render için kritik olduğunu belirleyin.

**Dosyada gizli slaytların olup olmadığını ve sayısını hızlıca nasıl öğrenebilirim?**

[slayt koleksiyonu](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slidecollection/) üzerinden döngü oluşturun ve her slaytın [görünürlük bayrağı](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/get_hidden/) özelliğini inceleyin.

**Özel slayt boyutu ve yönünün kullanılıp kullanılmadığını ve varsayılanlardan farklı olup olmadığını tespit edebilir miyim?**

Evet. Mevcut [slayt boyutu ve yönü](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_slidesize/)’ı standart ön ayarlarla karşılaştırın; bu, baskı ve dışa aktarım davranışını öngörmeye yardımcı olur.

**Grafiklerin harici veri kaynaklarına başvurup başvurmadığını hızlıca görmek için bir yol var mı?**

Evet. Tüm [grafikler](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chart/) dolaşın, [veri kaynağı](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/get_datasourcetype/)’larını kontrol edin ve verinin dahili mi yoksa bağlantı temelli mi olduğunu, ayrıca kırık bağlantıları da not edin.

**Render veya PDF dışa aktarımını yavaşlatabilecek 'ağır' slaytları nasıl değerlendirebilirim?**

Her slayt için nesne sayılarını sayın ve büyük resimler, şeffaflık, gölgeler, animasyonlar ve multimedya gibi öğeleri arayın; olası performans sorunlarını işaretlemek için kaba bir karmaşıklık puanı atayın.