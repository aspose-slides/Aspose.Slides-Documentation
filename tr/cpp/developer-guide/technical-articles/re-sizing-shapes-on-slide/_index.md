---
title: Sunum Slaytlarında Şekilleri Yeniden Boyutlandırma
type: docs
weight: 100
url: /tr/cpp/re-sizing-shapes-on-slide/
keywords:
- şekil yeniden boyutlandırma
- şekil boyutunu değiştirme
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument slaytlarındaki şekilleri kolayca yeniden boyutlandırın—slayt düzeni ayarlamalarını otomatikleştirin ve verimliliği artırın."
---
## **Genel Bakış**

Aspose.Slides for C++ müşterilerinin en sık sorulan sorularından biri, slayt boyutu değiştiğinde verinin kesilmemesi için şekilleri nasıl yeniden boyutlandıracaklarıdır. Bu kısa teknik makale bunu nasıl yapacağınızı gösterir.

## **Şekilleri Yeniden Boyutlandır**

Slayt boyutu değiştiğinde şekillerin hizalanmasının bozulmasını önlemek için, her bir şeklin konum ve boyutlarını yeni slayt düzenine uyacak şekilde güncelleyin.

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

// Sunum dosyasını yükleyin.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Orijinal slayt boyutunu alın.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Mevcut şekilleri ölçeklendirmeden slayt boyutunu değiştirin.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Yeni slayt boyutunu alın.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Her slayttaki şekilleri yeniden boyutlandırın ve konumlarını ayarlayın.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Şekil boyutunu ölçeklendirin.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Şekil konumunu ölçeklendirin.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
Bir slayt bir tablo içeriyorsa, yukarıdaki kod doğru çalışmaz. Bu durumda, tablodaki her hücre yeniden boyutlandırılmalıdır.
{{% /alert %}} 

Tablolar içeren slaytları yeniden boyutlandırmak için aşağıdaki kodu kendi tarafınızda kullanın. Tablolar için genişlik veya yükseklik ayarlamak özel bir durumdur: tablonun genel boyutunu değiştirmek için ayrı ayrı satır yüksekliklerini ve sütun genişliklerini ayarlamanız gerekir.

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
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Orijinal slayt boyutunu alın.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Mevcut şekilleri ölçeklendirmeden slayt boyutunu değiştirin.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Yeni slayt boyutunu alın.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Şekil boyutunu ölçeklendirin.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Şekil konumunu ölçeklendirin.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Şekil boyutunu ölçeklendirin.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Şekil konumunu ölçeklendirin.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Şekil boyutunu ölçeklendirin.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Şekil konumunu ölçeklendirin.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

### Şekiller bir slaytı yeniden boyutlandırdıktan sonra neden bozuluyor veya kesiliyor?

Bir slaytı yeniden boyutlandırdığınızda, ölçek açıkça değiştirilmedikçe şekiller orijinal konum ve boyutlarını korur. Bu durum içeriğin kırpılmasına veya şekillerin hizalanmasının bozulmasına neden olabilir.

### Sağlanan kod tüm şekil türleri için çalışıyor mu?

Temel örnek, çoğu şekil türü (metin kutuları, görüntüler, grafikler vb.) için çalışır. Ancak, tablolar için satır ve sütunları ayrı ayrı işlemeniz gerekir, çünkü bir tablonun yüksekliği ve genişliği bireysel hücrelerin boyutlarıyla belirlenir.

### Bir slaytı yeniden boyutlandırırken tabloları nasıl yeniden boyutlandırırım?

Tablonun tüm satır ve sütunları üzerinden döngü yaparak, yüksekliğini ve genişliğini orantılı olarak yeniden boyutlandırmanız gerekir; bu, ikinci kod örneğinde gösterildiği gibidir.

### Bu yeniden boyutlandırma ana slaytlar ve yerleşim slaytları için çalışır mı?

Evet, ancak sunum genelinde tutarlılık sağlamak için [Masters](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_masters/) ve [Layout slides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_layoutslides/) üzerinden de döngü yapmalı ve şekillerine aynı ölçekleme mantığını uygulamalısınız.

### Bir slaytın yönünü (dikey/yatay) yeniden boyutlandırma ile birlikte değiştirebilir miyim?

Evet. Yönü değiştirmek için [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidesize/set_orientation/) kullanabilirsiniz. Yerleşimi korumak için ölçekleme mantığını buna göre ayarladığınızdan emin olun.

### Ayarlayabileceğim slayt boyutu için bir limit var mı?

Aspose.Slides özel boyutları destekler, ancak çok büyük boyutlar performansı etkileyebilir veya bazı PowerPoint sürümleriyle uyumluluğu azaltabilir.

### Sabit en‑boy oranına sahip şekillerin bozulmasını nasıl önleyebilirim?

Şekli ölçeklendirmeden önce `get_AspectRatioLocked` yöntemini kontrol edebilirsiniz. Eğer kilitli ise, genişliği veya yüksekliği ayrı ayrı ölçeklendirmek yerine orantılı olarak ayarlayın.