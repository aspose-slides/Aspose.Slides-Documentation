---
title: C++'ta Sunumlarda Çizim Kılavuzlarını Yönetme
linktitle: Çizim Kılavuzları
type: docs
weight: 85
url: /tr/cpp/drawing-guides/
keywords:
- çizim kılavuzu
- yatay kılavuz
- düşey kılavuz
- hizalama kılavuzu
- slayt görünümü
- master slayt
- yerleşim slaytı
- not master
- el kitabı master
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint sunumlarında yatay ve düşey çizim kılavuzlarını ekleyin, erişin ve temizleyin."
---
## **Genel Bakış**

Çizim kılavuzları, kullanıcıların PowerPoint sunumunu düzenlerken şekilleri tutarlı bir şekilde hizalamasına yardımcı olan ayarlanabilir yatay ve düşey çizgilerdir. Özellikle bir uygulama, daha sonra manuel olarak düzenlenecek bir sunum oluşturduğunda faydalıdır: uygulama, yazarların içerik eklerken veya taşırken uyması gereken aynı hizalama yardımcılarını kaydedebilir.

Çizim kılavuzları, kaydırak içeriği değil, düzenleme yardımcılarıdır. Slayt gösterisinde veya oluşturulmuş çıktıda görünmezler. Aspose.Slides for C++ bu kılavuzları [IDrawingGuidesCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idrawingguidescollection/) arabirimi aracılığıyla sunar. Bir kılavuz [IDrawingGuide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idrawingguide/) ile temsil edilir ve bir yönelim, bir konum ve bir renge sahiptir.

Konum, ilgili slayt ya da master’ın sol‑üst köşesinden nokta cinsinden ölçülür. Düşey bir kılavuz, genellikle sıfır ile slayt genişliği arasında değişen yatay bir koordinat kullanır. Yatay bir kılavuz, genellikle sıfır ile slayt yüksekliği arasında değişen dikey bir koordinat kullanır.

## **Kılavuzları Slayt Görünümüne Ekleme**

Normal slaytları düzenlerken görüntülenen kılavuzları yönetmek için [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) kullanın. Bir [Orientation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/orientation/) değeri ve nokta cinsinden bir konumla [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idrawingguidescollection/add/) yöntemini çağırın.

Aşağıdaki örnek, slayt ortasının sağına bir düşey kılavuz ve altına bir yatay kılavuz ekler:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Çizim Kılavuzlarına Erişim**

Mevcut kılavuzlara erişmek için [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idrawingguidescollection/get_count/) ve [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idrawingguidescollection/idx_get/) yöntemleri kullanılır. Bir kılavuzun mevcut özelliklerini almak için [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idrawingguide/get_position/) ve [IDrawingGuide::get_Color](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idrawingguide/get_color/) yöntemleri kullanılır. İlgili ayarlayıcı yöntemler bu özellikleri değiştirebilir.

Aşağıdaki örnek, yukarıda oluşturulan sunumdan slayt‑görünüm kılavuzlarını okur:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **Master ve Layout Slaytlarına Kılavuz Ekleme**

Bir slayt master’ı ve onun her bir layout slaytı kendi çizim‑kılavuz koleksiyonlarına sahip olabilir. Master slayt için [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslide/get_drawingguides/) ve layout slaytı için [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/get_drawingguides/) kullanın.

Aşağıdaki örnek, ilk master slayta bir düşey kılavuz ve ilk layout slayta bir yatay kılavuz ekler:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Not ve El Kitabı Master’larına Kılavuz Ekleme**

Not master’ları ve el kitabı master’ları da çizim kılavuzlarını destekler. Koleksiyonlarına erişmek için [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasternotesslide/get_drawingguides/) ve [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) kullanın. Bir sunum bu master’lardan birini içermiyorsa, [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) veya [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) varsayılan master’ı oluşturur ve döndürür.

Aşağıdaki örnek, bir not master’ına bir yatay kılavuz ve bir el kitabı master’ına bir düşey kılavuz ekler:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoutMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Çizim Kılavuzlarını Temizleme**

Belirli bir koleksiyondaki tüm kılavuzları kaldırmak için [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/tr/cpp/aspose.slides/idrawingguidescollection/clear/) yöntemini çağırın. Bir koleksiyonun temizlenmesi, başka bir kapsamda depolanan kılavuzları etkilemez.

Aşağıdaki örnek, slayt‑görünüm kılavuzlarını ve slayt master’ları, layout slaytları, not master’ı ve el kitabı master’ındaki tüm kılavuzları eksik master oluşturmadan temizler:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**Çizim kılavuzları slayt gösterisinde veya dışa aktarılan görsellerde görünür mü?**

Hayır. Çizim kılavuzları sadece düzenleme sırasında hizalama yardımcısıdır ve sunum içeriği olarak render edilmez.

**Bir çizim kılavuzu doğrudan bireysel normal bir slayta eklenebilir mi?**

Normal slayt düzenleme kılavuzları, sunumun slayt‑görünüm özelliklerinde depolanır. Slayt master’ları, layout slaytları, not master’ları ve el kitabı master’ları için ayrı kılavuz koleksiyonları mevcuttur.

**Kılavuz konumları için hangi birimler kullanılır?**

Konumlar nokta cinsinden belirtilir; 72 nokta bir inçe eşittir. Düşey konumlar sol kenardan, yatay konumlar üst kenardan ölçülür.

**Çizim kılavuzlarını temizlemek şekilleri siler veya slayt içeriğini değiştirir mi?**

Hayır. `Clear` yöntemi yalnızca seçilen koleksiyondaki kılavuzları kaldırır. Şekiller ve diğer slayt içeriği değişmeden kalır.