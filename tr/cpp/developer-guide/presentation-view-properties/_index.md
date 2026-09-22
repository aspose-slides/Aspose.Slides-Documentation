---
title: C++'ta Sunum Görünüm Özelliklerini Al ve Güncelle
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/cpp/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içerik
- taslak ikonları
- dikey bölücüyü yakala
- tek görünüm
- çubuk durumu
- boyut ölçüsü
- otomatik ayarlama
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, yan içerik bölgesi ve alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırılmasıyla ilgili özellikler. Bu bilgi uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm sunumun en son kaydedildiği durumla aynı olur.

Sunumun normal görünüm özelliklerine erişim sağlamak için [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) yöntemi eklenmiştir.

[INormalViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/inormalviewrestoredproperties/) arabirimi ve türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/splitterbarstatetype/) enumı eklenmiştir.

## **INormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

Property **ShowOutlineIcons** özelliği, normal görünüm modunda içerik bölgelerinden herhangi birinde taslak içeriği gösterirken uygulamanın ikonları gösterip göstermeyeceğini belirler.

Property **SnapVerticalSplitter** özelliği, yan bölge yeterince küçük olduğunda dikey bölücünün küçültülmüş bir duruma kilitlenip kilitlenmeyeceğini belirtir.

Property **PreferSingleView** özelliği, kullanıcının üç içerik bölgesi içeren standart normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirler. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencerede göstermeyi seçebilir.

Properties **VerticalBarState** ve **HorizontalBarState** özellikleri, yatay veya dikey bölücü çubuğunun hangi durumda gösterileceğini belirtir. Yatay bölücü çubuk slaytı slaytın altındaki içerik bölgesinden ayırırken, dikey bölücü çubuk slaytı yan içerik bölgesinden ayırır. Olabilecek değerler: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** ve **SplitterBarStateType.Restored**.

Properties **RestoredLeft** ve **RestoredTop** özellikleri, **VerticalBarState** ve **HorizontalBarState** için **SplitterBarStateType.Restored** değeri uygulandığında normal görünümde üst veya yan slayt bölgesinin boyutlandırılmasını belirtir.

## **INormalViewProperties Kurtarılması Hakkında**

Normal görünümde bölgenin değişken bir kurtarılmış boyutta (ne küçültülmüş ne de büyütülmüş) olması durumunda slayt bölgesinin (RestoredTop çocuğu olduğunda genişlik, RestoredLeft çocuğu olduğunda yükseklik) boyutlandırılmasını belirtir.

Property **DimensionSize** özelliği, slayt bölgesinin (restoredTop çocuğu olduğunda genişlik, restoredLeft çocuğu olduğunda yükseklik) boyutunu belirtir.

Property **AutoAdjust** özelliği, uygulama içinde görünümü içeren pencere yeniden boyutlandırıldığında yan içerik bölgesinin boyutunun yeni boyuta göre ayarlanıp ayarlanmayacağını belirler.

Aşağıda verilen örnek, bir sunum için **ViewProperties.NormalViewProperties** özelliklerine nasıl erişileceğini gösterir.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Sunumun görünüm özelliklerini geri yükle
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```
## **Varsayılan Yakınlaştırma Değerini Ayarla**

Aspose.Slides for C++ artık sunum için varsayılan yakınlaştırma değerini ayarlamayı destekliyor; böylece sunum açıldığında yakınlaştırma zaten ayarlanmış olur. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/) ayarlanarak yapılabilir. Slayt Görünüm Özellikleri ayrıca [get_NotesViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/get_notesviewproperties/) programlı olarak ayarlanabilir. Bu konuda, Aspose.Slides içinde bir sunumun Görünüm Özelliklerini nasıl ayarlayacağınızı bir örnekle göreceğiz.

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun
1. Sunumun View [Properties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/) ayarlarını belirleyin
1. Sunumu bir PPTX dosyası olarak kaydedin

Aşağıda verilen örnekte, slayt görünümü ve notlar görünümü için yakınlaştırma değerini ayarladık.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Sunumun görünüm özelliklerini ayarlama
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Slayt görünümü için yüzde cinsinden yakınlaştırma değeri
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Notlar görünümü için yüzde cinsinden yakınlaştırma değeri

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```
## **Izgara Boşluğunu Ayarla**

[Presentation::get_ViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_viewproperties/) kullanarak sunum genelindeki görünüm ayarlarına erişin. [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iviewproperties/get_gridspacing/) ve [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iviewproperties/set_gridspacing/) yöntemleri temel düzenleme ızgarasının aralığını okur veya değiştirir. Bu ayar tek bir slayta değil, tüm sunuma uygulanır. Izgara boşluğu, 72 puanın bir inç olduğu nokta cinsinden belirtilir. API belgelerinde belirtildiği gibi pozitif bir değer kullanın.

Aşağıdaki örnek mevcut bir `demo.pptx` dosyasını açar, mevcut ızgara boşluğunu yazdırır, çeyrek inçlik bir aralık ayarlar ve sonucu kaydeder.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Izgara, [çizim kılavuzlarından](/slides/tr/cpp/drawing-guides/) farklıdır. Izgara boşluğu düzenli bir aralığı kontrol ederken, çizim kılavuzları bireysel olarak konumlandırılmış yatay veya dikey hizalama çizgileridir. Çizim kılavuzlarını eklemek, taşımak veya silmek ızgara boşluğunu değiştirmez.

Izgara ve çizim kılavuzları her ikisi de düzenleme yardımıdır. PDF, resimler, SVG veya slayt gösterisinde slayt içeriği olarak işlenmezler. Izgara boşluğunun dosyada saklanması, bir düzenleyicinin ızgarayı göstereceğini garanti etmez; görünürlüğü ayrıca izleyici veya düzenleyicinin tercihine bağlıdır.

## **SSS**

**Sunumu yeniden açtıktan sonra ızgara neden görünmüyor?**

Dosya ızgara boşluğunu saklar, ancak düzenleyici ızgaranın gösterilip gösterilmeyeceğini kontrol eder. Düzenleyicinin ızgara görünürlüğü ayarlarını kontrol edin.

**Çizim kılavuzlarını silmek ızgara boşluğunu değiştirir mi?**

Hayır. Çizim kılavuzları ve ızgara boşluğu bağımsız ayarlardır. Kılavuzları silmek, saklanan ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**

Görünüm ayarları sunum seviyesinde (Normal Görünüm/Slayt Görünümü) tanımlanır, bölüm bazında değil, bu nedenle açıldığında tüm belgeye tek bir parametre kümesi uygulanır.

**Farklı kullanıcılar için farklı görünüm durumları önceden tanımlayabilir miyim?**

Hayır. Ayarlar dosyada saklanır ve paylaşılandır. Görüntüleyici uygulamalar kullanıcı tercihlerine saygı gösterebilir, ancak dosya kendisi tek bir görünüm özelliği kümesi içerir.

**Yeni sunumların aynı şekilde açılması için önceden tanımlı Görünüm Özelliklerine sahip bir şablon hazırlayabilir miyim?**

Evet. Görünüm özellikleri sunum seviyesinde saklandığından, bunları bir şablona gömebilir ve yeni belgeleri aynı ilk görünüm yapılandırmasıyla oluşturabilirsiniz.