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
description: "Aspose.Slides för C++ gör det enkelt att skapa, redigera och klona textrutor i PowerPoint- och OpenDocument-filer, vilket förbättrar din presentationsautomation."
---
## **Introduktion**

Texter på bildspel finns vanligtvis i textrutor eller former. Därför måste du för att lägga till text på en bild först lägga till en textruta och sedan placera någon text i textrutan. Aspose.Slides för C++ tillhandahåller gränssnittet [IAutoShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_auto_shape) som låter dig lägga till en form som innehåller text.

{{% alert title="Info" color="info" %}}

Aspose.Slides tillhandahåller också gränssnittet [IShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_shape) som låter dig lägga till former på bilder. Dock kan inte alla former som läggs till via `IShape`‑gränssnittet hålla text. Men former som läggs till via [IAutoShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_auto_shape)‑gränssnittet kan innehålla text. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Därför, när du hanterar en form som du vill lägga till text i, kan du vilja kontrollera och bekräfta att den castas via `IAutoShape`‑gränssnittet. Endast då kan du arbeta med [TextFrame](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.text_frame), som är en egenskap under `IAutoShape`. Se avsnittet [Update Text](https://docs.aspose.com/slides/sv/cpp/manage-textbox/#update-text) på den här sidan. 

{{% /alert %}}

## **Skapa en textruta på en bild**

För att skapa en textruta på en bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation). 
2. Hämta en referens till den första bilden i den nyskapade presentationen. 
3. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_auto_shape)‑objekt med [ShapeType](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) inställt på `Rectangle` på en specificerad position på bilden och hämta referensen till det nyligen tillagda `IAutoShape`‑objektet. 
4. Lägg till en `TextFrame`‑egenskap till `IAutoShape`‑objektet som kommer att innehålla text. I exemplet nedan lade vi till följande text: *Aspose TextBox*
5. Slutligen, skriv PPTX‑filen via `Presentation`‑objektet. 

Denna C++‑kod—en implementering av stegen ovan—visar hur du lägger till text på en bild:

```cpp
// Skapar en Presentation
auto pres = System::MakeObject<Presentation>();

// Hämtar den första bilden i presentationen
auto sld = pres->get_Slides()->idx_get(0);

// Lägger till en AutoShape med typen satt till Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Lägger till en TextFrame till rektangeln
ashp->AddTextFrame(u" ");

// Åtkomst till textramen
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

Aspose.Slides tillhandahåller metoden [get_IsTextBox](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/get_istextbox/) från [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/)‑gränssnittet, vilket låter dig undersöka former och identifiera textrutor.

![Text box and shape](istextbox.png)

Denna C++‑kod visar hur du kontrollerar om en form skapades som en textruta: 

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
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

Observera att om du helt enkelt lägger till en autoshape med `AddAutoShape`‑metoden från [IShapeCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/)‑gränssnittet, så kommer `get_IsTextBox`‑metoden för autoshapen att returnera `false`. Däremot, efter att du har lagt till text till autoshapen med `AddTextFrame`‑metoden eller `set_Text`‑metoden, returnerar `get_IsTextBox`‑metoden `true`.

```cpp
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

## **Lägg till kolumner i en textruta**

Aspose.Slides erbjuder metoderna [set_ColumnCount](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) och [set_ColumnSpacing](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (från gränssnittet [ITextFrameFormat](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_text_frame_format) och klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_text_frame_format)) som låter dig lägga till kolumner i textrutor. Du kan ange antalet kolumner i en textruta och ställa in avståndet i punkter mellan kolumnerna. 

Denna kod i C++ demonstrerar den beskrivna operationen: 

```cpp
auto presentation = System::MakeObject<Presentation>();
// Hämtar den första bilden i presentationen
auto slide = presentation->get_Slides()->idx_get(0);

// Lägg till en AutoShape med typen satt till Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Lägg till en TextFrame till rektangeln
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

## **Lägg till kolumner i en textram**

Aspose.Slides för C++ tillhandahåller metoden [set_ColumnCount](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (från gränssnittet [ITextFrameFormat](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_text_frame_format)) som låter dig lägga till kolumner i textram. Med denna metod kan du ange önskat antal kolumner i en textram. 

Denna C++‑kod visar hur du lägger till en kolumn i en textram:

```cpp
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

Aspose.Slides låter dig ändra eller uppdatera texten som finns i en textruta eller all text i en presentation. 

Denna C++‑kod demonstrerar en operation där all text i en presentation uppdateras eller ändras:

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
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

//Sparar den ändrade presentationen
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Lägg till en textruta med en hyperlänk** 

Du kan infoga en länk i en textruta. När textrutan klickas på, leds användarna till att öppna länken. 

För att lägga till en textruta som innehåller en länk, följ dessa steg:

1. Skapa en instans av klassen `Presentation`. 
2. Hämta en referens till den första bilden i den nyskapade presentationen. 
3. Lägg till ett `AutoShape`‑objekt med `ShapeType` inställt på `Rectangle` på en specificerad position på bilden och hämta en referens till det nyss tillagda AutoShape‑objektet.
4. Lägg till en `TextFrame` till `AutoShape`‑objektet som innehåller *Aspose TextBox* som standardtext. 
5. Instansiera klassen `IHyperlinkManager`. 
6. Tilldela `IHyperlinkManager`‑objektet till metoden [set_HyperlinkClick](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) som är associerad med den önskade delen av `TextFrame`. 
7. Slutligen, skriv PPTX‑filen via `Presentation`‑objektet. 

Denna C++‑kod—en implementering av stegen ovan—visar hur du lägger till en textruta med en hyperlänk på en bild:

```cpp
// Instansierar en Presentation-klass som representerar en PPTX
auto presentation = System::MakeObject<Presentation>();

// Hämtar den första bilden i presentationen
auto slide = presentation->get_Slides()->idx_get(0);

// Lägger till ett AutoShape-objekt med typen satt till Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Castar formen till AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Åtkomst till ITextFrame-egenskapen som är associerad med AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Lägger till lite text i ramen
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Ställer in hyperlänken för portions-texten
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Sparar PPTX-presentationen
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Vad är skillnaden mellan en textruta och en textplatshållare när du arbetar med masterslides?**

En [placeholder](/slides/sv/cpp/manage-placeholder/) ärver stil/position från [master](https://reference.aspose.com/slides/sv/cpp/aspose.slides/masterslide/) och kan åsidosättas på [layouts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/layoutslide/), medan en vanlig textruta är ett fristående objekt på en specifik bild och ändras inte när du byter layout.

**Hur kan jag göra en massutbyte av text i hela presentationen utan att ändra text i diagram, tabeller och SmartArt?**

Begränsa din iteration till autoshapes som har textramar och uteslut inbäddade objekt ([charts](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/sv/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/sv/cpp/aspose.slides.smartart/smartart/)) genom att gå igenom deras samlingar separat eller hoppa över dessa objekttyper.