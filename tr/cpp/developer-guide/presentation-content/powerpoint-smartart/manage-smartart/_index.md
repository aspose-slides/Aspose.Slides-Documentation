---
title: C++ Kullanarak PowerPoint Sunumlarında SmartArt Yönetimi
linktitle: SmartArt Yönetimi
type: docs
weight: 10
url: /tr/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt metni
- düzen türü
- gizli özelliği
- organizasyon şeması
- resimli organizasyon şeması
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint SmartArt'ı oluşturmayı ve düzenlemeyi, slayt tasarımını ve otomasyonunu hızlandıran net kod örnekleri kullanarak öğrenin."
---
## **Genel Bakış**

SmartArt, düğümler, düğüm şekilleri ve bir düzen kullanılarak oluşturulan bir PowerPoint diyagramıdır. Aspose.Slides for C++ ile SmartArt oluşturabilir, düğümlerinden metin okuyabilir, düzenini değiştirebilir, gizli düğümleri inceleyebilir, organizasyon şeması düzenlerini yapılandırabilir ve resimli organizasyon şemaları oluşturabilirsiniz.

## **SmartArt Nesnesinden Metin Alma**

Bir SmartArt düğümü bir veya daha fazla şekil içerebilir. Düğüm şekillerinden metin okumak için [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/) üzerinden yineleme yapın, ardından [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/) tarafından döndürülen [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) öğesini okuyun.

Örnek, en az bir slaytı ve o slayttaki ilk şekil olarak bir SmartArt nesnesi içeren bir sunum gerektirir. Her kullanılabilir metin çerçevesini konsola yazdırır.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **SmartArt Nesnesinin Düzen Türünü Değiştirme**

SmartArt düzeni, düğümlerin nasıl düzenlendiğini ve bağlandığını kontrol eder. Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` değerine sahip bir SmartArt nesnesi oluşturur, bunu `BasicProcess` değerine değiştirir ve sunumu kaydeder. [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/)’a geçirilen konum ve boyut puan cinsindendir. Düzeni değiştirmek için [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) kullanın.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SmartArt Düğümünün Gizli Olup Olmadığını Kontrol Etme**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) , düğümün SmartArt veri modelinde gizli olup olmadığını gösterir. Seçilen düzen, düğümleri görünür diyagram öğeleri olarak göstermese bile gizli düğümler yapıda var olabilir.

Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` değerini kullanan bir SmartArt nesnesine bir düğüm ekler ve eklenen düğümün gizli durumunu kontrol eder. Düğüm gizli ise bir mesaj yazdırır ve diyagramı kaydeder.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Organizasyon Şeması Düzenini Alma veya Ayarlama**

Organizasyon şeması düzeni kullanan SmartArt diyagramları için, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) ve [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) alt düğümlerin bir üst düğüm altında nasıl düzenleneceğini tanımlar. Örneğin, seçilen [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/)’a bağlı olarak alt düğümleri soldan, sağdan veya her iki tarafından sarkıtacak şekilde ayarlayabilirsiniz.

Aşağıdaki örnek bir organizasyon şeması oluşturur ve ilk düğüm için düzeni [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` değerine ayarlar. Sıfır tabanlı indeks `0`, ilk üst düzey düğümü seçer; alt düğümler seçilen düzeni kullanır. Değiştirilen sunum daha sonra kaydedilir.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Resimli Organizasyon Şeması Oluşturma**

Resimli organizasyon şeması, görüntü yer tutucuları içeren hiyerarşi diyagramları için tasarlanmış bir SmartArt düzenidir. SmartArt nesnesini bir slayta eklerken [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` değerini kullanın. Bu örnek, görüntü yer tutucuları içeren bir diyagramı kaydeder; yer tutuculara görüntü eklemez.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Eski Diyagramları Şekil Gruplarına Dönüştürme**

Mevcut bir sunumu modernleştirirken, PowerPoint 97–2003'te oluşturulmuş bir organizasyon şemasını güncellemeniz gerekebilir. Aspose.Slides, bu eski diyagramları [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/) nesneleri olarak temsil eder. Bir diyagramı, bireysel görsel öğeleri düzenleyebilmek için bir şekil grubuna dönüştürmek üzere [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/) kullanın. Ayrıntılar için [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/) bölümüne bakın.

Dönüştürme, orijinal diyagramı kaldırmadan şekil koleksiyonuna yeni bir grup ekler. Başarılı dönüşümden sonra, yinelenen içeriği önlemek için orijinali [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) ile kaldırın. Şekil ekleme ve kaldırmanın yinelemeyi bozmasını önlemek için dönüşümden önce eski diyagramları bir vektöre toplayın.

Aşağıdaki örnek bir sunumu açar, her slaytı arar, diyagramları şekil gruplarına dönüştürür ve güncellenmiş sunumu PPTX olarak kaydeder.

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kaydedilen sunum, dönüştürülmüş eski diyagramların yerine düzenlenebilir şekil grupları içerir; yanlarında orijinal diyagram kalmaz. Her grup içindeki metin, dolgu veya konum gibi bireysel öğeleri düzenlemek için PPTX'i PowerPoint'te açın.

## **SSS**

**SmartArt, RTL dilleri için yansıtma veya ters çevirme destekliyor mu?**

Evet. Seçilen SmartArt düzeni ters çevirmeyi desteklediğinde, [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) yöntemi diyagram yönünü soldan sağa’dan sağdan sola’ya değiştirir veya geri alır.

**SmartArt'ı aynı slayta veya başka bir sunuma biçimlendirmeyi koruyarak nasıl kopyalayabilirim?**

SmartArt şekli, [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) kullanarak [SmartArt şekli klonla](/slides/tr/cpp/shape-manipulations/) ile çoğaltabilir veya SmartArt'ı içeren slaytı [tüm slaytı klonla](/slides/tr/cpp/clone-slides/) ile çoğaltabilirsiniz. Her iki yöntem de boyut, konum ve biçimlendirmeyi korur.

**SmartArt'ı önizleme veya web dışa aktarımı için raster görüntüye nasıl render ederim?**

[Slaytı renderla](/slides/tr/cpp/convert-powerpoint-to-png/) veya tüm sunumu PNG veya JPEG olarak dışa aktarın. SmartArt slaytın bir parçası olarak renderlanır.

**Bir slaytta birden fazla SmartArt nesnesi varsa belirli bir SmartArt nesnesini nasıl bulabilirim?**

SmartArt şekline ayırt edici bir [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) veya [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) değeri ayarlayın, bu değeri [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) içinde arayın ve ardından eşleşen şeklin bir [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/) olduğundan emin olun.