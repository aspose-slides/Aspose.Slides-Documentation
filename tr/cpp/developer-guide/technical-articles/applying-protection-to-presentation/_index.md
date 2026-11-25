---
title: C++'ta Şekil Kilitleriyle Sunum Düzenlemelerini Kısıtlayın
linktitle: Sunum Düzenlemelerini Kısıtla
type: docs
weight: 10
url: /tr/cpp/applying-protection-to-presentation/
keywords:
- düzenlemeleri önle
- düzenlemeden koru
- şekli kilitle
- konumu kilitle
- seçimi kilitle
- yeniden boyutlandırmayı kilitle
- gruplamayı kilitle
- PowerPoint
- PPTX
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PPTX sunumlarındaki şekilleri nasıl kilitleyeceğinizi ve kilidini kaldıracağınızı öğrenin; seçim, hareket, yeniden boyutlandırma ve gruplamayı kısıtlayın."
---
## **Arka Plan**

Aspose.Slides for C++ için yaygın bir kullanım, otomatik bir iş akışının parçası olarak PowerPoint (PPTX) sunumları oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldıklarında, şekillerdeki değişiklikleri kısıtlamak, amaçlanan düzeni ve içeriği korumaya yardımcı olabilir.

Bu makale, şekillerin slaytlarda nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulandığını ve kaldırıldığını açıklar. Bu kilitler, tek tek şekillerde belirli düzenleme işlemlerini kısıtlamanızı sağlar.

## **Bir Slaytın Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for C++ içinde, bir slayttaki her öğe, [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) arayüzünü uygulayan veya bu arayüzü miras alan bir nesneyle temsil edilir.

Farklı şekil türleri farklı kilitleme seçenekleri sunar. [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) arayüzü, şekil kilitleri için temel arayüzdür. Aspose.Slides for C++ aşağıdaki kilit arayüzlerini sağlar:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) otomatik şekilleri kilitler.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) bağlayıcı şekilleri kilitler.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) grafik nesneleri kilitler.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) grup şekilleri kilitler.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) resim çerçevelerini kilitler.

Bir [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) içinde kilitleri uygulamak için, slaytları arasında döngü yapın ve desteklenen her şekil üzerinde uygun kilitleri ayarlayın.

## **Koruma Uygulama ve Kaldırma**

Uyumlu sunum düzenleyicileri, tek tek düzenleme işlemlerini kısıtlamak için şekil kilitlerini kullanır. Dosya şifrelemesi ve belge seviyesindeki yazma koruması ayrı [sunum koruma ayarları](/slides/tr/cpp/password-protected-presentation/) olarak bulunur.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for C++ bir slayttaki şekillerle çalışmak için [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) arayüzünü sağlar.

Örnek, otomatik şekiller için [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) ve [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) metoduna `true` geçirir; grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitler uygulanır. Bağlayıcılar hareket için [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) metodunu kullanır; gruplar ayrıca gruplayıcıyı kısıtlamak için [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) metodunu kullanır.

Örnek, mevcut bir PPTX sunumunu yükler, her slaydın şekil koleksiyonundaki şekilleri kontrol eder ve bu kısıtlamalar uygulanmış bir kopyasını kaydeder. Dört ele alınan tür dışındaki şekiller değişmeden bırakılır. Döngü, bir grup içindeki alt şekilleri dolaşmaz.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(true);
            autoShapeLock->set_SelectLocked(true);
            autoShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(true);
            groupShapeLock->set_PositionLocked(true);
            groupShapeLock->set_SelectLocked(true);
            groupShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(true);
            connectorShapeLock->set_SelectLocked(true);
            connectorShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(true);
            pictureFrameLock->set_SelectLocked(true);
            pictureFrameLock->set_SizeLocked(true);
        }
    }
}

presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Koruma Kaldırma**

Bir şekil kilidini kaldırmak için, değerini `false` olarak ayarlayın. Aşağıdaki örnek, şekil kilitleri içeren bir sunumu yükler ve seçme, hareket ve yeniden boyutlandırma kısıtlamalarını [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) ve [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) aracılığıyla temizler. Ayrıca [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) metodunu da temizler ve sunumun bir kopyasını kaydeder. Diğer kilit ayarları değişmeden bırakılır.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(false);
            autoShapeLock->set_SelectLocked(false);
            autoShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(false);
            groupShapeLock->set_PositionLocked(false);
            groupShapeLock->set_SelectLocked(false);
            groupShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(false);
            connectorShapeLock->set_SelectLocked(false);
            connectorShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(false);
            pictureFrameLock->set_SelectLocked(false);
            pictureFrameLock->set_SizeLocked(false);
        }
    }
}

presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Resim Kırpmasını Koru**

Çalışma dizinine `photo.jpg` adlı bir fotoğraf yerleştirin. Örnek, soldan %12 ve sağdan %8 kırpar, ardından resim çerçevesi kilidinde [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) metodunu çağırarak kırpmayı korur ve daha fazla kırpmayı kısıtlar.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto photoBytes = File::ReadAllBytes(u"photo.jpg");
auto photo = presentation->get_Images()->AddImage(photoBytes);

auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, photo);
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_CropLeft(12);
pictureFormat->set_CropRight(8);

auto pictureFrameLock = pictureFrame->get_PictureFrameLock();
pictureFrameLock->set_AspectRatioLocked(false);
pictureFrameLock->set_CropLocked(true);

presentation->Save(u"PictureLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`PictureLocked.pptx` kırpma kilidini `true` olarak saklar. PowerPoint'te fotoğraf seçildiğinde **Crop** komutu devre dışı bırakılır.

### **Bir Diyagramı Gruplayı Koru**

Örnek, bir dikdörtgen ve bir okı gruplar, ardından grup kilidinde [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) metodunu çağırarak diyagram bileşenlerinin birlikte kalmasını sağlar. Grubu taşıma veya bir bileşenin dolgusunu değiştirme gibi diğer düzenlemeler kullanılabilir durumda kalır.

```cpp
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto groupShape = shapes->AddGroupShape();
auto groupShapes = groupShape->get_Shapes();
groupShapes->AddAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
groupShapes->AddAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
groupShape->get_GroupShapeLock()->set_UngroupingLocked(true);

presentation->Save(u"DiagramLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`DiagramLocked.pptx` ayrıma kilidini `true` olarak saklar. PowerPoint'te tüm diyagram seçildiğinde **Ungroup** komutu devre dışı bırakılır.

### **Mevcut Şekil Kilitlerini Raporla**

Bir şablonu incelemek için, şablonu açın ve her şekil için kilit nesnesini okuyun. [get_NoLocks](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/get_nolocks/) o nesnedeki tüm bayraklar devre dışı olduğunda `true`, en az biri etkin olduğunda `false` döndürür. Bir grup ve onun alt öğeleri ayrı kilit nesnelerine sahiptir, bu yüzden grup hiç kilit içermese bile alt öğeleri inceleyin.

Bu örnek, otomatik şekiller, resim çerçeveleri ve gruplar için hareketi, resimler için kırpmayı ve gruplar için ayrıma (ungroup) kontrol eder. Tanıdığı bayrakları raporlar ve incelemediği şekil türlerini işaretler.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/list.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <functional>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

std::function<void(SharedPtr<IShapeCollection>, int, String)> inspect;
inspect = [&inspect](SharedPtr<IShapeCollection> shapes, int slideNumber, String prefix)
{
    for (auto&& shape : IterateOver(shapes))
    {
        auto path = prefix + shape->get_Name();
        auto label = String::Format(u"Slide {0} | {1} | {2}", slideNumber, path, shape->GetType().get_Name());
        auto flags = MakeObject<List<String>>();
        auto group = AsCast<IGroupShape>(shape);

        if (group)
        {
            auto locks = group->get_GroupShapeLock();
            if (locks->get_UngroupingLocked()) flags->Add(u"UngroupingLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto picture = AsCast<IPictureFrame>(shape))
        {
            auto locks = picture->get_PictureFrameLock();
            if (locks->get_CropLocked()) flags->Add(u"CropLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto autoShape = AsCast<IAutoShape>(shape))
        {
            if (autoShape->get_AutoShapeLock()->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else
        {
            Console::WriteLine(label + u" | Uninspected");
            continue;
        }

        if (!shape->get_ShapeLock()->get_NoLocks())
        {
            auto restrictions = flags->get_Count() ? String::Join(u", ", flags->ToArray()) : String(u"Active flag not identified");
            Console::WriteLine(label + u" | " + restrictions);
        }

        if (group)
            inspect(group->get_Shapes(), slideNumber, path + u"/");
    }
};

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    inspect(slide->get_Shapes(), slide->get_SlideNumber(), u"");
}
presentation->Dispose();
```

`Sample.pptx` dosyasının 1. slaytının, ayrıma kilitli `Layout` adlı bir grup, içinde kırpma kilitli `Photo` adlı bir resim ve kilitsiz `Free` adlı bir dikdörtgen içerdiğini varsayalım. Rapor, `Free` öğesini atlar ve bu iki satırı yazdırır:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Rapor, sunumu değiştirmeden veya kaydetmeden saklanan şekil seviyesindeki düzenleme bayraklarını okur. Belge seviyesindeki yazma koruması ayrı bir ayardır ve her bayrağın uygulanması editöre bağlıdır.

### **Sonuç**

Aspose.Slides for C++, tek tek şekillerde belirli düzenleme işlemlerini kısıtlamanıza veya aynı kısıtlamaları slaytlar arasında uygulamanıza olanak tanır. Her şekil türü tarafından desteklenen kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `false` olarak ayarlayın.

## **SSS**

**Şekil kilitlerini ve şifre korumasını aynı sunumda birleştirebilir miyim?**

Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlarken, [şifre koruması](/slides/tr/cpp/password-protected-presentation/) sunumun açılmasını veya değiştirilmesini kısıtlayabilir. İkisini aynı dosyada kullanabilirsiniz.

**Belirli slaytlarda düzenlemeyi diğer slaytlara etki etmeden kısıtlayabilir miyim?**

Evet. Kilitleri yalnızca seçili slaytlardaki şekillere uygularsınız. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Bir grup içindeki tek tek şekillere nasıl kilit uygulayabilirim?**

Grubun [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) metodu tarafından döndürülen koleksiyon üzerinde döngü yapın ve her alt şekle uygun kilitleri uygulayın. İç içe gruplar için de bunu tekrarlayın; raporlama örneğindeki dolaşımı izleyin.