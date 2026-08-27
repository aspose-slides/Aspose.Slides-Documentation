---
title: Hantera textrutor i presentationer med C++
linktitle: Hantera textruta
type: docs
weight: 20
url: /sv/cpp/manage-textbox/
keywords:
- textruta
- textram
- lägga till text
- uppdatera text
- skapa textruta
- kontrollera textruta
- lägga till textkolumn
- lägga till hyperlänk
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Aspose.Slides för C++ gör det enkelt att skapa, redigera och klona textrutor i PowerPoint- och OpenDocument-filer, vilket förbättrar din presentationsautomatisering."
---
## **Introduktion**

Texter på bilder finns vanligtvis i textrutor eller former. Därför, för att lägga till text på en bild, måste du lägga till en textruta och sedan placera lite text i textrutan. Aspose.Slides för C++ tillhandahåller gränssnittet [IAutoShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_auto_shape) som låter dig lägga till en form som innehåller text.

{{% alert title="Info" color="info" %}}

Aspose.Slides tillhandahåller också gränssnittet [IShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_shape) som låter dig lägga till former på bilder. Dock kan inte alla former som läggs till via `IShape`‑gränssnittet innehålla text. Men former som läggs till via [IAutoShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_auto_shape)‑gränssnittet kan innehålla text.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Därför, när du hanterar en form som du vill lägga till text i, kan du vilja kontrollera och bekräfta att den har kastats via `IAutoShape`‑gränssnittet. Endast då kan du arbeta med [TextFrame](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.text_frame), som är en egenskap under `IAutoShape`. Se avsnittet [Update Text](https://docs.aspose.com/slides/sv/cpp/manage-textbox/#update-text) på den här sidan. 

{{% /alert %}}

## **Skapa en textruta på en bild**

För att skapa en textruta på en bild, gå igenom dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation). 
2. Hämta en referens till den första bilden i den nyss skapade presentationen. 
3. Lägg till ett [IAutoShape]‑objekt med [ShapeType] satt till `Rectangle` på en specificerad position på bilden och hämta referensen till det nyss tillagda `IAutoShape`‑objektet. 
4. Lägg till en `TextFrame`‑egenskap till `IAutoShape`‑objektet som ska innehålla text. I exemplet nedan lade vi till följande text: *Aspose TextBox*
5. Skriv slutligen PPTX‑filen via `Presentation`‑objektet. 

Den här C++‑koden—en implementation av stegen ovan—visar hur du lägger till text på en bild:

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

// Instansierar Presentation
auto pres = System::MakeObject<Presentation>();

// Hämtar den första bilden i presentationen
auto sld = pres->get_Slides()->idx_get(0);

// Lägger till en AutoShape med typen satt till Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Lägger till TextFrame i rektangeln
ashp->AddTextFrame(u" ");

// Får åtkomst till textramen
auto txtFrame = ashp->get_TextFrame();

// Skapar Paragraph-objektet för textramen
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Skapar ett Portion-objekt för paragrafen
auto portion = para->get_Portions()->idx_get(0);

// Sätter text
portion->set_Text(u"Aspose TextBox");

// Sparar presentationen till disk
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Kontrollera om en form är en textruta**

Aspose.Slides tillhandahåller metoden [get_IsTextBox](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/get_istextbox/) från [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/)‑gränssnittet, så att du kan undersöka former och identifiera textrutor.

![Text box and shape](istextbox.png)

Den här C++‑koden visar hur du kontrollerar om en form skapades som en textruta: 

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

Observera att om du helt enkelt lägger till en autoform med `AddAutoShape`‑metoden från [IShapeCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/)‑gränssnittet, kommer `get_IsTextBox`‑metoden för autoformen att returnera `false`. Efter att du har lagt till text i autoformen med `AddTextFrame`‑metoden eller `set_Text`‑metoden, kommer `get_IsTextBox`‑metoden att returnera `true`.

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
// shape1->get_IsTextBox() returnerar false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() returnerar true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() returnerar false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() returnerar true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() returnerar false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() returnerar false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() returnerar false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() returnerar false
```

## **Hitta formen som äger en TextFrame**

I generisk textbehandlingskod kan du få ett [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) utan att redan veta vilket presentationsobjekt som innehåller det. Använd [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/get_parentshape/) för att navigera tillbaka till den ägande [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/).

För en TextFrame som tillhör en [IAutoShape] eller en annan textinnehållande form, returnerar [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/get_parentshape/) ägaren och [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/get_parentcell/) returnerar `nullptr`. Båda metoderna ger endast läs‑navigation, så att anropa dem ändrar inte ägandet. Kontrollera alltid det returnerade värdet för `nullptr` innan du får åtkomst till formen.

För ett fullständigt exempel som identifierar form‑ och tabell‑cell‑ägare, inklusive former kopplade till SmartArt‑noder, se [Search and Replace Text](/slides/sv/cpp/search-and-replace-text/).

## **Lägg till kolumner i en textruta**

Aspose.Slides tillhandahåller metoderna [set_ColumnCount](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) och [set_ColumnSpacing](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (från gränssnittet [ITextFrameFormat] och klassen [TextFrameFormat]) som låter dig lägga till kolumner i textrutor. Du kan specificera antalet kolumner i en textruta och ange avståndet i punkter mellan kolumnerna. 

Den här C++‑koden demonstrerar den beskrivna operationen: 

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
// Hämtar den första bilden i presentationen
auto slide = presentation->get_Slides()->idx_get(0);

// Lägg till en AutoShape med typen satt till Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Lägg till TextFrame i rektangeln
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Hämtar textformatet för TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Anger antalet kolumner i TextFrame
format->set_ColumnCount(3);

// Anger avståndet mellan kolumnerna
format->set_ColumnSpacing(10);

// Sparar presentationen
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Lägg till kolumner i en TextFrame**

Aspose.Slides för C++ tillhandahåller metoden [set_ColumnCount](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (från gränssnittet [ITextFrameFormat]) som låter dig lägga till kolumner i TextFrames. Med denna metod kan du ange önskat antal kolumner i en TextFrame. 

Den här C++‑koden visar hur du lägger till en kolumn i en TextFrame:

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

## **Uppdatera text**

Aspose.Slides låter dig ändra eller uppdatera texten i en textruta eller all text i en presentation. 

Den här C++‑koden demonstrerar en operation där all text i en presentation uppdateras eller ändras:

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
                    //Ändrar text
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Ändrar formatering
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Sparar modifierad presentation
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Lägg till en textruta med en hyperlänk** 

Du kan infoga en länk i en textruta. När textrutan klickas på, leds användarna till att öppna länken. 

För att lägga till en textruta som innehåller en länk, gå igenom dessa steg:

1. Skapa en instans av klassen `Presentation`. 
2. Hämta en referens till den första bilden i den nyss skapade presentationen. 
3. Lägg till ett `AutoShape`‑objekt med `ShapeType` satt till `Rectangle` på en specificerad position på bilden och hämta en referens till det nyss tillagda AutoShape‑objektet.
4. Lägg till en `TextFrame` till `AutoShape`‑objektet som innehåller *Aspose TextBox* som standardtext. 
5. Instansiera klassen `IHyperlinkManager`. 
6. Tilldela `IHyperlinkManager`‑objektet till metoden [set_HyperlinkClick](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) som är associerad med den önskade delen av `TextFrame`. 
7. Skriv slutligen PPTX‑filen via `Presentation`‑objektet. 

Den här C++‑koden—en implementation av stegen ovan—visar hur du lägger till en textruta med en hyperlänk på en bild:

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

// Instansierar en Presentation-klass som representerar en PPTX
auto presentation = System::MakeObject<Presentation>();

// Hämtar den första bilden i presentationen
auto slide = presentation->get_Slides()->idx_get(0);

// Lägger till ett AutoShape-objekt med typen satt till Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Kastar formen till AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Får åtkomst till ITextFrame-egenskapen som är associerad med AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Lägger till lite text i ramen
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Ställer in hyperlänken för portionens text
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Sparar PPTX-presentationen
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Vad är skillnaden mellan en textruta och en text‑platshållare när du arbetar med master‑bilder?**

En [placeholder](/slides/sv/cpp/manage-placeholder/) ärver stil/position från [master](https://reference.aspose.com/slides/sv/cpp/aspose.slides/masterslide/) och kan åsidosättas på [layouts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/layoutslide/), medan en vanlig textruta är ett självständigt objekt på en specifik bild och ändras inte när du byter layout.

**Hur kan jag utföra en massutbyte av text i hela presentationen utan att påverka text i diagram, tabeller och SmartArt?**

Begränsa din iteration till autoformer som har textramar och uteslut inbäddade objekt ([charts](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/sv/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/sv/cpp/aspose.slides.smartart/smartart/)) genom att gå igenom deras samlingar separat eller hoppa över dessa objekttyper.