---
title: C++'ta Sunum Görünüm Özelliklerini Al ve Güncelle
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/cpp/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- anahat içeriği
- anahat ikonları
- dikey bölücüyü yakala
- tek görünüm
- çubuk durumu
- boyut ölçüsü
- otomatik ayar
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ görünüm özelliklerini keşfedin; PPT, PPTX ve ODP slayt formatlarını özelleştirin—düzenleri, yakınlaştırma seviyelerini ve görüntü ayarlarını ayarlayın."
---
## **Giriş**

Normal görünüm üç içerik bölgesinden oluşur: slayt kendisi, bir yan içerik bölgesi ve bir alt içerik bölgesi. Farklı içerik bölgelerinin konumlandırılmasına ilişkin özellikler. Bu bilgi uygulamanın görünüm durumunu dosyaya kaydetmesini sağlar, böylece yeniden açıldığında görünüm, sunum son kaydedildiğinde olduğu aynı durumda olur.

Method [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) sunumun normal görünüm özelliklerine erişim sağlamak için eklendi. 

[INormalViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/inormalviewrestoredproperties/) arabirimleri ve onların türevleri, [SplitterBarStateType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/splitterbarstatetype/) enumu eklendi.

## **INormalViewProperties Hakkında**

Normal görünüm özelliklerini temsil eder.

Property **ShowOutlineIcons**, normal görünüm modundaki herhangi bir içerik bölgesinde anahat içeriği görüntüleniyorsa uygulamanın simge gösterip göstermeyeceğini belirtir.

Property **SnapVerticalSplitter**, yan bölge yeterince küçük olduğunda dikey bölücünün küçültülmüş bir duruma kilitlenip kilitlenmeyeceğini belirtir.

Property **PreferSingleView**, kullanıcının üç içerik bölgesiyle standart normal görünüm yerine tam pencere tek içerik bölgesi görmeyi tercih edip etmediğini belirtir. Etkinleştirildiğinde, uygulama içerik bölgelerinden birini tüm pencereye yayarak görüntülemeyi seçebilir.

Properties **VerticalBarState** ve **HorizontalBarState**, yatay veya dikey bölücü çubuğunun hangi durumda gösterileceğini belirtir. Yatay bölücü çubuk, slaytı slayt altındaki içerik bölgesinden ayırırken, dikey bölücü çubuk slaytı yan içerik bölgesinden ayırır. Olası değerler: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** ve **SplitterBarStateType.Restored**.

Properties **RestoredLeft** ve **RestoredTop**, **VerticalBarState** ve **HorizontalBarState** için **SplitterBarStateType.Restored** değeri uygulandığında normal görünümdeki üst veya yan slayt bölgesinin boyutlandırılmasını belirtir.

## **INormalViewProperties Geri Yükleme Hakkında**

Normal görünümde bölgenin değişken geri yüklenmiş bir boyutta (ne küçültülmüş ne de büyütülmüş) olduğu durumda slayt bölgesinin (RestoredTop çocuğu olduğunda genişlik, RestoredLeft çocuğu olduğunda yükseklik) boyutlandırılmasını belirtir.

Property **DimensionSize**, slayt bölgesinin (restoredTop çocuğu olduğunda genişlik, restoredLeft çocuğu olduğunda yükseklik) boyutunu belirtir.

Property **AutoAdjust**, pencere yeniden boyutlandırıldığında yan içerik bölgesinin yeni boyuta göre telafi edilip edilmeyeceğini belirtir.

Aşağıda verilen örnek, bir sunum için **ViewProperties.NormalViewProperties** özelliklerine nasıl erişileceğini gösterir.

``` cpp
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

## **Varsayılan Yakınlaştırma Değerini Ayarlama**

Aspose.Slides for C++ artık sunum için varsayılan yakınlaştırma değerini ayarlamayı destekliyor; böylece sunum açıldığında yakınlaştırma zaten ayarlanmış olur. Bu, bir sunumun [ViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/) ayarlanarak yapılabilir. Slayt Görünüm Özellikleri ve ayrıca [get_NotesViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/get_notesviewproperties/) programlı olarak ayarlanabilir. Bu konuda, Aspose.Slides'te bir sunumun Görünüm Özelliklerini bir örnekle nasıl ayarlayacağımızı göreceğiz.

Görünüm özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun
1. Sunumun Görünüm [Properties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/) ayarlarını belirleyin
1. Sunumu bir PPTX dosyası olarak kaydedin

Aşağıda verilen örnekte, slayt görünümü ve notlar görünümü için yakınlaştırma değeri ayarlanmıştır.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Sunumun görünüm özelliklerini ayarlama
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Slayt görünümü için yüzde cinsinden yakınlaştırma değeri
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Not görünümü için yüzde cinsinden yakınlaştırma değeri 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Izgara Aralığını Ayarlama**

[Presentation::get_ViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_viewproperties/) kullanarak sunum genelindeki görünüm ayarlarına erişin. [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iviewproperties/get_gridspacing/) ve [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iviewproperties/set_gridspacing/) yöntemleri temel düzenleme ızgarasının aralığını okur veya değiştirir. Bu ayar bireysel bir slayta değil bütün sunuma uygulanır. Izgara aralığı puan cinsinden belirtilir; 72 puan bir inçtir. API belgelerinde belirtildiği gibi pozitif bir değer kullanın.

Aşağıdaki örnek, mevcut bir `demo.pptx` dosyasını açar, mevcut ızgara aralığını yazdırır, çeyrek inçlik bir aralık ayarlar ve sonucu kaydeder.

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

Izgara, [çizim kılavuzlarından](/slides/tr/cpp/drawing-guides/) farklıdır. Izgara aralığı düzenli bir aralığı kontrol ederken, çizim kılavuzları bireysel olarak konumlandırılmış yatay veya dikey hizalama çizgileridir. Çizim kılavuzlarını eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

Izgara ve çizim kılavuzları her ikisi de düzenleme yardımcılarıdır. PDF, resimler, SVG veya slayt gösterisinde slayt içeriği olarak işlenmezler. Izgara aralığının depolanması, bir düzenleyicinin ızgarayı göstereceğini garanti etmez; görünürlüğü ayrıca görüntüleyicinin veya düzenleyicinin tercihine bağlıdır.

## **Sunumu Açarken Yorumları Gösterme veya Gizleme**

[Presentation::get_ViewProperties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_viewproperties/) kullanarak sunum genelindeki görünüm ayarlarına erişin. [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iviewproperties/get_showcomments/) ve [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iviewproperties/set_showcomments/) kullanarak yorumların PowerPoint'te veya başka bir uyumlu editörde sunum açıldığında gösterilip gösterilmeyeceği tercihini saklayın.

Bu ayar yalnızca saklanan görünüm tercihini kontrol eder. Yorum ekleme, kaldırma, düzenleme veya çözümleme yapmaz. Yorumları gizlemek, içeriklerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumların kendisini değiştiren işlemler için [Presentation Comments](/slides/tr/cpp/presentation-comments/) sayfasına bakın.

Aşağıdaki örnek, yorum içeren mevcut bir `comments.pptx` dosyasını gerektirir. Mevcut görünürlük ayarını yazdırır, yorumların gizlenmesini talep eder ve yorumları kaldırmadan yeni bir PPTX kaydeder. Ayrıca yorum görünürlüğüyle birlikte başlangıç düzenleme görünümünü yapılandırmak için [IViewProperties::set_LastView](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iviewproperties/set_lastview/) ve [ViewType::SlideView](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewtype/) kullanır.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Bu ayar, yorumların PDF, HTML, görüntü, notlar veya el ilanı dışa aktarımlarına dahil edilip edilmeyeceğini belirlemez. İlgili dışa aktarım seçeneklerini ayrı ayrı yapılandırın.

## **SSS**

**Sunumu yeniden açtıktan sonra ızgara neden görünmüyor?**  
Dosya ızgara aralığını saklar, ancak ızgaranın görüntülenip görüntülenmeyeceği editör tarafından kontrol edilir. Editörün ızgara görünürlük ayarlarını kontrol edin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**  
Hayır. Çizim kılavuzları ve ızgara aralığı bağımsız ayarlardır. Kılavuzları temizlemek, saklanan ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri için farklı görünüm ayarları belirleyebilir miyim?**  
[View settings](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_viewproperties/) sunum seviyesinde tanımlanır ([Normal View](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/tr/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), bölüm bazında değil; bu yüzden tek bir parametre seti sunum açıldığında tüm belgeye uygulanır.

**Farklı kullanıcılar için önceden tanımlı farklı görünüm durumları belirleyebilir miyim?**  
Hayır. Ayarlar dosyada saklanır ve paylaşılır. Görüntüleyici uygulamalar kullanıcı tercihlerine saygı gösterebilir, ancak dosya kendisi tek bir görünüm özelliği seti içerir.

**Önceden tanımlı Görünüm Özelliklerine sahip bir şablon hazırlayabilir ve yeni sunumların aynı şekilde açılmasını sağlayabilir miyim?**  
Evet. [view properties](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_viewproperties/) sunum seviyesinde saklandığı için, bunları bir şablona dahil edebilir ve aynı başlangıç görünüm yapılandırmasıyla yeni belgeler oluşturabilirsiniz.