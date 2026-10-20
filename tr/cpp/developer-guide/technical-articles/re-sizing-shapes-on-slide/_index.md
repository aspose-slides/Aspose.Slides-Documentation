---
title: C++'ta Sunum Slaytlarında Şekilleri Yeniden Boyutlandır
type: docs
weight: 130
url: /tr/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/re-sizing-shapes-on-slide/
  - /tr/cpp/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandır
- şekil boyutunu değiştir
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument slaytlarında şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Bir sunumun slayt boyutunu değiştirdiğinizde, şekilleri yeni boyutlara sığdırmak için yeniden boyutlandırmanız ve konumlarını yeniden ayarlamanız da gerekebilir. Bu makale, şekilleri manuel olarak nasıl ölçeklendireceğinizi ve slaytlardaki, masterlardaki ve düzenlerdeki tabloları nasıl işleyeceğinizi gösterir.

## **Şekilleri Yeniden Boyutlandır**

Her bir şeklin göreceli konumunu ve boyutunu korumak için, yatay koordinatlarını ve genişliğini yeni slayt genişliğinin orijinal genişliğe oranı ile çarpın. Aynı şekilde, dikey koordinatları ve yüksekliği de ilgili yükseklik oranı ile çarpın.

İlk örnek, slaytlarında tablo içermeyen bir sunumu yükler, slayt boyutunu A4 olarak değiştirir ve sonucu kaydeder. Ölçeklemeyi sonraki döngünün kontrol etmesi için [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) ile [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) kullanır. Oranlar birimsizdir; şekil konumları ve boyutları puan cinsinden ölçülür. Farklı genişlik ve yükseklik oranları şekilleri bozabilir ve bir şeklin boyutlarını değiştirmek, yazı tipi boyutlarını ölçeklemez.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculate independent horizontal and vertical scale factors.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Tablolar ayrı bir işlem gerektirir: tablo genişliği ve yüksekliği yerine sütun genişliklerini ve satır yüksekliklerini ölçeklendirin. Hücre içeriği daha fazla alan gerektiriyorsa, satır yükseklikleri istenenden büyük kalabilir.
{{% /alert %}}

İkinci örnek, tabloları destekler ve yeniden boyutlandırılmış sunumu kaydetmeden önce master ve düzenlerdeki şekilleri ve bireysel slaytları işler. Yardımcısı, her bir [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) öğesini [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) ve [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) ölçeklendirerek ele alır. Ardından tablonun konumunu, genel boyutlarını ayrı ayrı ölçeklendirmeden ölçeklendirir.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Bağımsız yatay ve dikey ölçek faktörlerini hesaplayın.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // Tablo boyutları sütun genişlikleri ve satır yüksekliğiyle kontrol edilir.
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// Resize shapes defined on masters and layouts as well as individual slides.
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**Neden slaytı yeniden boyutlandırdıktan sonra şekiller bozulur veya kesilir?**

Slayt boyutunu şekilleri ölçeklendirmeden değiştirirseniz, şekiller orijinal konum ve boyutlarını korur ve slayttan taşabilir. Genişlik ve yüksekliği farklı oranlarda ölçeklemek de şekilleri bozabilir.

**Sağlanan kod tüm şekil türleri için çalışıyor mu?**

İlk örnek şekil sınırlarını doğrudan değiştirir ve tablo içermeyen slaytlar için tasarlanmıştır. İkinci örnek tabloları ayrı olarak işler. Sonucu düzeni, özellikle metin ve tabloları kontrol edin, çünkü bu örnekler yazı tipi boyutlarını ölçeklemez ve tablo içeriği satır yüksekliklerini kısıtlayabilir.

**Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?**

Sütun genişliklerini genişlik oranı, minimum satır yüksekliklerini ise yükseklik oranı ile ölçeklendirin, ardından tabloların konumunu ikinci örnekte gösterildiği gibi ölçeklendirin.

**Bu yeniden boyutlandırma master slaytlar ve düzen slaytları için de çalışır mı?**

Evet. İkinci örnek, [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) ve her master'ın [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) üzerinden döner ve şekillerine aynı yeniden boyutlandırma mantığını uygular.

**Yeniden boyutlandırma ile birlikte bir slaytın yönünü (dikey/yatay) değiştirebilir miyim?**

Evet. Slayt boyutunu değiştirdikten ve hedef boyutları okumadan önce [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) ayarlayın, böylece ölçek faktörleri son yönelimi yansıtır.

**Ayarlayabileceğim bir slayt boyutu sınırı var mı?**

[SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) ile özel slayt boyutları belirtebilirsiniz. Desteklenen boyutlar ayrıca sunum formatına ve dosyayı açan uygulamaya bağlıdır.

**Sabit en-boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?**

Genişlik ve yükseklik için aynı ölçek faktörünü kullanın. Orijinal düzeni yeni slayt boyutlarına sığdırmak için, her iki boyut ve konum için genişlik ve yükseklik oranlarından daha küçük olanı kullanın. Bu, oranları korur ancak bir kenarda kullanılmayan boşluk bırakabilir.