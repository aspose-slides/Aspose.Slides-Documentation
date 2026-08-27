---
title: C++ Kullanarak Sunumlarda Metin Kutularını Yönetme
linktitle: Metin Kutusunu Yönet
type: docs
weight: 20
url: /tr/cpp/manage-textbox/
keywords:
- metin kutusu
- metin çerçevesi
- metin ekle
- metni güncelle
- metin kutusu oluştur
- metin kutusunu kontrol et
- metin sütunu ekle
- hiperbağlantı ekle
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++, PowerPoint ve OpenDocument dosyalarında metin kutularını oluşturmayı, düzenlemeyi ve kopyalamayı kolaylaştırarak sunum otomasyonunuzu geliştirir."
---
## **Giriş**

Slaytlardaki metinler genellikle metin kutularında veya şekillerde bulunur. Bu nedenle, bir slayta metin eklemek için önce bir metin kutusu eklemeli ve ardından metni bu kutuya yerleştirmelisiniz. Aspose.Slides for C++, içinde metin bulunduran bir şekil eklemenizi sağlayan [IAutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape) arayüzünü sunar.

{{% alert title="Info" color="info" %}}
Aspose.Slides ayrıca slaytlara şekil eklemenizi sağlayan [IShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_shape) arayüzünü sunar. Ancak, `IShape` arayüzü üzerinden eklenen tüm şekiller metin tutamaz. `IShape` arayüzü üzerinden eklenen şekillerin bazıları metin içerebilir, ancak [IAutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape) arayüzü üzerinden eklenen şekiller metin içerebilir. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Bu nedenle, metin eklemek istediğiniz bir şekille çalışırken, şeklin `IAutoShape` arayüzü üzerinden dönüştürülüp dönüştürülmediğini kontrol edip doğrulamak isteyebilirsiniz. Ancak o zaman `IAutoShape` altında bir özellik olan [TextFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.text_frame) ile çalışabileceksiniz. Bu sayfadaki [Metni Güncelle](https://docs.aspose.com/slides/tr/cpp/manage-textbox/#update-text) bölümüne bakın. 
{{% /alert %}}

## **Bir Slayta Metin Kutusu Oluşturma**

Bir slayta metin kutusu oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun. 
2. Yeni oluşturulan sunumdaki ilk slayt için bir referans alın. 
3. Slayt üzerindeki belirli bir konuma `Rectangle` olarak ayarlanmış [ShapeType](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) ile bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_auto_shape) nesnesi ekleyin ve yeni eklenen `IAutoShape` nesnesinin referansını alın. 
4. Metin içerecek bir `TextFrame` özelliğini `IAutoShape` nesnesine ekleyin. Aşağıdaki örnekte bu metni ekledik: *Aspose TextBox* 
5. Son olarak, `Presentation` nesnesi aracılığıyla PPTX dosyasını yazın. 

Yukarıdaki adımların C++ kodu ile uygulaması, bir slayta metin eklemenizi gösterir:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Sunumu Örnekleştirir
auto pres = System::MakeObject<Presentation>();

// Sunumda ilk slaytı alır
auto sld = pres->get_Slides()->idx_get(0);

// Tipi Dikdörtgen olarak ayarlanmış bir AutoShape ekler
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Dikdörtgene TextFrame ekler
ashp->AddTextFrame(u" ");

// Metin çerçevesine erişir
auto txtFrame = ashp->get_TextFrame();

// Metin çerçevesi için Paragraph nesnesi oluşturur
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Paragraph için Portion nesnesi oluşturur
auto portion = para->get_Portions()->idx_get(0);

// Metni ayarlar
portion->set_Text(u"Aspose TextBox");

// Sunumu diske kaydeder
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Metin Kutusu Şekli Kontrolü**

Aspose.Slides, şekilleri incelemenize ve metin kutularını tanımlamanıza olanak tanıyan [get_IsTextBox](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/get_istextbox/) metodunu [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) arayüzünden sağlar.

![Metin kutusu ve şekil](istextbox.png)

Bu C++ kodu, bir şeklin metin kutusu olarak oluşturulup oluşturulmadığını nasıl kontrol edeceğinizi gösterir: 

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Dikkat edin, bir otomatik şekli [IShapeCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/) arayüzünün `AddAutoShape` yöntemiyle doğrudan eklediğinizde, otomatik şeklin `get_IsTextBox` metodu `false` döndürür. Ancak, otomatik şekle `AddTextFrame` yöntemi veya `set_Text` yöntemiyle metin eklediğinizde, `get_IsTextBox` metodu `true` döndürür.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() false döner
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() true döner

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() false döner
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() true döner

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() false döner
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() false döner

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() false döner
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() false döner
```

## **Metin Çerçevesine Sahip Şekli Bulma**

Genel metin işleme kodunda, hangi sunum nesnesinin bir [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) içerdiğini önceden bilmeden alabilirsiniz. Sahibi olan [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) nesnesine geri gitmek için [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_parentshape/) yöntemini kullanın.

[IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) veya başka bir metin içeren şekle ait bir metin çerçevesi için, [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_parentshape/) sahibi döndürür ve [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_parentcell/) `nullptr` döndürür. Her iki yöntem de salt‑okunur gezinme sağlar; bu yüzden onları çağırmak sahipliği değiştirmez. Şekle erişmeden önce her zaman dönen değerin `nullptr` olup olmadığını kontrol edin.

Şekil ve tablo‑hücre sahipliğini tanımlayan, SmartArt düğümleriyle ilişkili şekilleri de içeren tam bir örnek için, [Metin Arama ve Değiştirme](/slides/tr/cpp/search-and-replace-text/) bölümüne bakın.

## **Metin Kutusuna Sütun Ekleme**

Aspose.Slides, bir metin kutusuna sütun eklemenizi sağlayan [set_ColumnCount](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) ve [set_ColumnSpacing](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) metodlarını ([ITextFrameFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_text_frame_format) arayüzü ve [TextFrameFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_text_frame_format) sınıfı) sunar. Metin kutusundaki sütun sayısını ve sütunlar arasındaki nokta cinsinden boşluk miktarını belirleyebilirsiniz. 

Bu C++ kodu, açıklanan işlemi gösterir: 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
// Sunumdaki ilk slaytı alır
auto slide = presentation->get_Slides()->idx_get(0);

// Tipi Dikdörtgen olarak ayarlanmış bir AutoShape ekler
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Dikdörtgene TextFrame ekler
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// TextFrame'in metin biçimini alır
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// TextFrame'deki sütun sayısını belirler
format->set_ColumnCount(3);

// Sütunlar arasındaki boşluğu belirler
format->set_ColumnSpacing(10);

// Sunumu kaydeder
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Metin Çerçevesine Sütun Ekleme**
Aspose.Slides for C++ , metin çerçevelerine sütun eklemenizi sağlayan [set_ColumnCount](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) metodunu ([ITextFrameFormat](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_text_frame_format) arayüzü) sunar. Bu yöntemle bir metin çerçevesinde tercih ettiğiniz sütun sayısını belirtebilirsiniz. 

Bu C++ kodu, bir metin çerçevesine nasıl sütun ekleyeceğinizi gösterir:

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Metni Güncelleme**

Aspose.Slides, bir metin kutusundaki veya bir sunumdaki tüm metinleri değiştirmenize veya güncellemenize olanak tanır. 

Aşağıdaki C++ kodu, bir sunumdaki tüm metinlerin güncellenmesi veya değiştirilmesi işlemini göstermektedir:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
                {
                    //Metni değiştirir
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Biçimlendirmeyi değiştirir
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Değiştirilmiş sunumu kaydeder
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Hipermetin Bağlantılı Metin Kutusu Ekleme** 

Bir metin kutusuna bir bağlantı ekleyebilirsiniz. Metin kutusuna tıklandığında kullanıcılar bağlantıyı açmak için yönlendirilir. 

Bir bağlantı içeren metin kutusu eklemek için şu adımları izleyin:

1. `Presentation` sınıfının bir örneğini oluşturun. 
2. Yeni oluşturulan sunumdaki ilk slayt için bir referans alın. 
3. Slayt üzerindeki belirli bir konuma `Rectangle` olarak ayarlanmış `ShapeType` ile bir `AutoShape` nesnesi ekleyin ve yeni eklenen AutoShape nesnesinin referansını alın. 
4. `AutoShape` nesnesine *Aspose TextBox* varsayılan metnine sahip bir `TextFrame` ekleyin. 
5. `IHyperlinkManager` sınıfını örnekleyin. 
6. Tercih ettiğiniz `TextFrame` kısmına [set_HyperlinkClick](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) metodunu kullanarak `IHyperlinkManager` nesnesini atayın. 
7. Son olarak, `Presentation` nesnesi aracılığıyla PPTX dosyasını yazın. 

Bu C++ kodu, bir slayta hipermetin bağlantılı bir metin kutusu eklemenizi gösterir:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// PPTX'i temsil eden bir Presentation sınıfını örnekler
auto presentation = System::MakeObject<Presentation>();

// Sunumdaki ilk slaytı alır
auto slide = presentation->get_Slides()->idx_get(0);

// Tipi Dikdörtgen olarak ayarlanmış bir AutoShape nesnesi ekler
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Şekli AutoShape tipine dönüştürür
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// AutoShape ile ilişkili ITextFrame özelliğine erişir
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Çerçeveye bazı metinler ekler
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Parça metni için Hipermetni ayarlar
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// PPTX Sunumunu kaydeder
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **SSS**

**Ana slaytlarla çalışırken bir metin kutusu ile bir metin yer tutucu arasındaki fark nedir?**

Bir [yer tutucu](/slides/tr/cpp/manage-placeholder/) stil/konumu **master**(https://reference.aspose.com/slides/tr/cpp/aspose.slides/masterslide/) üzerinden miras alır ve **layout**(https://reference.aspose.com/slides/tr/cpp/aspose.slides/layoutslide/) üzerinde geçersiz kılınabilir, oysa normal bir metin kutusu belirli bir slaytta bağımsız bir nesnedir ve düzen değiştirildiğinde değişmez.

**Sunumda grafik, tablo ve SmartArt içindeki metinlere dokunmadan toplu metin değiştirme işlemini nasıl yapabilirim?**

Yinelemeyi, metin çerçevesi olan otomatik şekillerle sınırlayın ve gömülü nesneleri ([grafikler](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chart/), [tablolar](https://reference.aspose.com/slides/tr/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/tr/cpp/aspose.slides.smartart/smartart/)) ayrı koleksiyonlar halinde dolaşarak veya bu nesne türlerini atlayarak dışarıda bırakın.