---
title: Hantera presentationsplatshållare i C++
linktitle: Hantera platshållare
type: docs
weight: 10
url: /sv/cpp/manage-placeholder/
keywords:
- platshållare
- textplatshållare
- bildplatshållare
- diagramplatshållare
- uppmaningstext
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Hantera enkelt platshållare i Aspose.Slides för C++: ersätt text, anpassa uppmaningar och ställ in bildtransparens i PowerPowerPoint och OpenDocument."
---
## **Översikt**

Aspose.Slides låter dig hantera presentationsplatshållare programatiskt. Denna artikel förklarar hur man hittar platshållare på bilder, ändrar deras text, anger anpassad uppmaningstext för platshållarlayouter och justerar transparensen för en bild som används som bakgrund för en platshållare. Den innehåller också en kort FAQ som klargör skillnaden mellan basplatshållare och lokala former, förklarar hur ändringar av platshållare kan tillämpas via layouter eller mästermallar, och pekar på hantering av huvud‑ och sidfotplatshållare.

## **Ändra text i en platshållare**
Using [Aspose.Slides for C++](/slides/sv/cpp/), you can find and modify placeholders on slides in presentations. Aspose.Slides låter dig göra ändringar i texten i en platshållare.

**Förutsättning**: Du behöver en presentation som innehåller en platshållare. Du kan skapa en sådan presentation i det vanliga Microsoft PowerPoint‑programmet.

Så här använder du Aspose.Slides för att ersätta texten i platshållaren i den presentationen:

1. Skapa en instans av klassen [`Presentation`](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation/) och skicka presentationen som argument.
2. Hämta en bildreferens via dess index.
3. Iterera genom formerna för att hitta platshållaren.
4. Typa om platshållarformen till en [`AutoShape`](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.auto_shape/) och ändra texten med hjälp av den [`TextFrame`](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.text_frame/) som är associerad med [`AutoShape`](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.auto_shape/).
5. Spara den ändrade presentationen.

Denna C++‑kod visar hur man ändrar texten i en platshållare:

```c++
// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


 // Läser in den önskade presentationen
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Hämtar den första bilden
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Hämtar den första och andra platshållaren i bilden och typomvandlar den till en AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// Sparar presentationen till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ange uppmaningstext i en platshållare**
Standard‑ och förbyggda layouter innehåller uppmaningstexter för platshållare såsom ***Klicka för att lägga till en rubrik*** eller ***Klicka för att lägga till en underrubrik***. Med Aspose.Slides kan du infoga dina föredragna uppmaningstexter i platshållar‑layouter.

Denna C++‑kod visar hur du anger uppmaningstexten i en platshållare:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // När det inte finns någon text i den visar PowerPoint "Click to add title". 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Gör samma sak för undertext.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ställ in bildtransparens för platshållare**
Aspose.Slides låter dig ange transparensen för bakgrundsbilden i en text‑platshållare. Genom att justera bildens transparens i ett sådant ramverk kan du få texten eller bilden att framträda tydligare (beroende på textens och bildens färger).

Denna C++‑kod visar hur du anger transparensen för en bildbakgrund (inuti en form):

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```

## **FAQ**

**Vad är en basplatshållare och hur skiljer den sig från en lokal form på en bild?**

En basplatshållare är den ursprungliga formen på en layout eller master som bildens form ärver från – typ, position och viss formatering kommer från den. En lokal form är oberoende; om det inte finns någon basplatshållare gäller ingen arv.

**Hur kan jag uppdatera alla rubriker eller bildtexter i en presentation utan att iterera över varje bild?**

Redigera den motsvarande platshållaren på layouten eller på mastern. Bilder som bygger på dessa layouter/den mastern kommer automatiskt att ärva ändringen.

**Hur styr jag de standardiserade huvud‑/fotplatshållarna – datum & tid, bildnummer och fottext?**

Använd HeaderFooter‑hanterarna i rätt omfattning (vanliga bilder, layouter, master, anteckningar/handout) för att slå på eller av dessa platshållare samt för att ange deras innehåll.