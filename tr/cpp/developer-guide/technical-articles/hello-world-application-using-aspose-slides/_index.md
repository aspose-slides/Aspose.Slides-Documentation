---
title: "Aspose.Slides for C++ kullanarak Hello World Uygulaması"
type: docs
weight: 80
url: /tr/cpp/hello-world-application-using-aspose-slides/
keywords:
- "merhaba dünya"
- "uygulama"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides ile ilk C++ uygulamanızı oluşturun, PPT, PPTX ve ODP sunumlarını otomatikleştirmeye hazır bir basit Hello World örneği."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak basit bir **Hello World** PowerPoint sunumu oluşturmayı gösterir. Örnek, yeni bir sunum oluşturmayı, ilk slayta erişmeyi, belirtilen konumda bir dikdörtgen AutoShape eklemeyi, **Hello World** metnini içeren bir metin çerçevesi eklemeyi ve şekil ile metin biçimlendirmesini ayarlamayı gösterir.

Ayrıca, metnin rengini siyaha değiştirerek görünür hâle getirmeyi, çizgi rengini beyaza ayarlayarak şekil kenarlığını gizlemeyi, şekil dolgusunu kaldırmayı ve sunumu PPTX dosyası olarak kaydetmeyi açıklar.

## **Hello World Uygulaması Oluşturma Adımları**

Aspose.Slides for C++ API kullanarak **Hello World** uygulamasını oluşturmak için aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Presentation oluşturulduğunda otomatik olarak oluşturulan sunumdaki ilk slaytın referansını alın
- Slaytın belirli bir konumuna ShapeType'ı Rectangle olan bir AutoShape ekleyin
- AutoShape'e varsayılan metin olarak Hello World içeren bir TextFrame ekleyin
- Metin rengini siyaha değiştirin; varsayılan olarak beyazdır ve beyaz arka planlı slaytta görünmez
- Şekil kenarlığını gizlemek için çizgi rengini beyaza değiştirin
- Şeklin varsayılan Dolgu Biçimini kaldırın
- Son olarak, sunumu Presentation nesnesini kullanarak istenen dosya biçimine kaydedin

Yukarıdaki adımların uygulanması aşağıdaki örnekte gösterilmiştir.

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // ilk slaytı al
    auto slide = pres->get_Slides()->idx_get(0);

    // Dikdörtgen türünde bir AutoShape ekle
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // Dikdörtgene TextFrame ekle
    shape->AddTextFrame(u"Hello World");

    // Metin rengini Siyah olarak değiştir (öntanımlı olarak Beyazdır)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // Dikdörtgenin çizgi rengini Beyaz olarak değiştir
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // Şekildeki tüm dolgu biçimlendirmesini kaldır
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // Sunumu diske kaydet
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```