---
title: C++'ta Sunum Görünüm Özelliklerini Getirme ve Güncelleme
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/cpp/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- taslak içeriği
- taslak simgeleri
- dikey bölmeyi yakala
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
description: "PowerPoint sunumlarında normal görünüm düzenini, slayt ve not yakınlaştırmasını, ızgara aralığını ve yorum görünürlüğünü yapılandırmak için C++ için Aspose.Slides kullanın."
---
## **Giriş**

PowerPoint'in normal görünümünde, slayt, küçük resimler ya da taslak için bir yan bölme ile alttaki not bölmesi arasında görünür. Aspose.Slides for C++ sunumun kaydedilmiş düzenleme tercihlerini [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) aracılığıyla ortaya koyar. Bunlar arasında bölme düzeni, yakınlaştırma seviyeleri, ızgara aralığı ve yorum görünürlüğü bulunur.

## **INormalViewProperties Hakkında**

Şu andaki [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) kullanarak [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/) arayüzüne erişin. [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) taslakta slayt başlıklarının yanında simgelerin görünüp görünmeyeceğini kontrol eder. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) kullanıcı yan bölmeyi daralttığında yan bölmenin küçültülmüş durumuna tutunmasını sağlar. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) tüm pencerede tek bir bölmenin gösterilmesi tercihini gösterir.

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) yan bölme ile slayt arasındaki ayırıcıyı kontrol eder. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) not bölmesinin üzerindeki ayırıcıyı kontrol eder. İkisi de `Minimized`, `Maximized` veya `Restored` değerlerinden birini alan [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) değerini kabul eder.

## **INormalViewProperties Yeniden Yüklenmesi Hakkında**

Bir ayırıcı geri yüklendiğinde, [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) yan bölmenin kaydedilmiş boyutunu, [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) ise üst slayt alanının kaydedilmiş boyutunu sağlar. İkisi de [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/) aracılığıyla erişilir. Bunun [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) yöntemi 0 ile 100 arasında bir yüzde alır ve [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) pencere yeniden boyutlandırıldığında düzenleyicinin boyutu ayarlayıp ayarlamayacağını kontrol eder.

Bu örnek mevcut bir sunumu günceller. Yatay ayırıcıyı geri yükler, [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) ile erişilen üst slayt alanının boyutunu %80 olarak ayarlar ve otomatik ayarlamayı etkinleştirir, ayrıca dikey ayırıcıyı maksimize eder. Taslak görünümü için ayrıca [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) ile taslak simgelerini etkinleştirir.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```
## **Varsayılan Yakınlaştırma Değerini Ayarla**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) ve [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) düzenleyici için bağımsız yakınlaştırma ayarlarını depolar. Bu ayarlar slayt boyutlarını, slayt gösterisi oynatımını veya görüntü dışa aktarma çözünürlüğünü etkilemez.

Bu örnek mevcut bir sunumu açar ve slaytı düzenleme penceresine sığdırmak için [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) ile otomatik ölçeklemeyi etkinleştirir. Not sayfası için otomatik ölçeklemeyi devre dışı bırakır ve sabit %80 yakınlaştırma ayarlamak üzere [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) kullanır.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```
## **Izgara Boşluğunu Ayarla**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) sunum boyunca düzenleme ızgara çizgileri arasındaki mesafeyi belirler. 72 puan başına inç olarak pozitif bir değer alır. Bu örnek mevcut bir sunumda geçerli boşluğu yazdırır ve aralığı 18 puana ayarlayarak çeyrek inçlik bir ızgara kaydeder.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```
Izgara sabit bir aralıkta tekrar eder. [Drawing guides](/slides/tr/cpp/drawing-guides/) tek tek yatay veya dikey konumları işaretler. İkisi de düzenleme yardımıdır ve yalnızca bunları gösteren editörlerde görünür. Slayt gösterileri ve PDF, görüntü veya SVG olarak dışa aktarmalar bunları içermez.

## **Sunumu Açarken Yorumları Göster veya Gizle**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) sunumu açarken uyumlu editörlerin kullandığı bir tercih kaydeder. Yorumlu mevcut bir sunum için bu örnek geçerli ayarı yazdırır ve yorumlar gizli bir kopya kaydeder. Ayrıca kopyanın slayt görünümünde açılması için [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) metodunu [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) ile çağırır.

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

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```
Yorumları gizlemek, metinlerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumların kendisini değiştirmek için [Presentation Comments](/slides/tr/cpp/presentation-comments/) bölümüne bakın. Dışa aktarma ayarları, yorumların PDF, HTML, görüntüler, notlar veya el ilanlarında görünüp görünmeyeceğini kontrol eder.

## **SSS**

**Sunumu yeniden açtığımda ızgara neden gizleniyor?**

Sunum ızgara aralığını depolar. Izgarayı görmek için editörde ızgara görünürlüğünü etkinleştirin.

**Çizim kılavuzlarını temizlemek ızgara boşluğunu değiştirir mi?**

Hayır. Bir kılavuzu eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri farklı görünüm ayarlarına sahip olabilir mi?**

Hayır. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) tüm sunuma uygulanır.

**Farklı kullanıcılar için farklı görünüm ayarlarını kaydedebilir miyim?**

Dosya herkes için tek bir görünüm özelliği seti saklar. Bir editör ayrıca kullanıcının yerel tercihlerini uygulayabilir.

**Bir şablonda görünüm ayarlarını kaydedebilir miyim?**

Evet. Şablondan oluşturulan sunumlar, kaydedilmiş görünüm ayarlarını devralır.