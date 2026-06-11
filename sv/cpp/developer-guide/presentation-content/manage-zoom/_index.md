---
title: "Hantera presentationszoom i C++"
linktitle: "Hantera zoom"
type: docs
weight: 60
url: /sv/cpp/manage-zoom/
keywords:
- zoom
- zoomram
- bildzoom
- sektionzoom
- sammanfattningszoom
- lägg till zoom
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Skapa och anpassa Zoom med Aspose.Slides för C++ — hoppa mellan sektioner, lägg till miniatyrer och övergångar i PPT-, PPTX- och ODP-presentationer."
---
## **Introduktion**

Zoom-funktioner i PowerPoint låter dig hoppa till och från specifika bilder, sektioner och delar av en presentation. När du presenterar kan denna möjlighet att snabbt navigera i innehållet vara mycket användbar. 

![overview_image](Overview.png)

* För att sammanfatta en hel presentation på en enda bild, använd en [Sammanfattningszoom](#Summary-Zoom).
* För att endast visa utvalda bilder, använd en [Bildzoom](#Slide-Zoom).
* För att endast visa en enskild sektion, använd en [Sektionzoom](#Section-Zoom).

## **Bildzoom**
En bildzoom kan göra din presentation mer dynamisk, vilket låter dig navigera fritt mellan bilder i valfri ordning utan att avbryta presentationens flöde. Bildzoomer är utmärkta för korta presentationer utan många sektioner, men du kan ändå använda dem i olika presentationsscenario.

Bildzoomer hjälper dig att gräva ner dig i flera informationsdelar samtidigt som du känner dig på en enda yta. 

![overview_image](slidezoomsel.png)

För bildzoom-objekt tillhandahåller Aspose.Slides uppräkningen [ZoomImageType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/zoomimagetype/) , gränssnittet [IZoomFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/izoomframe/) , och några metoder under gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/) .

### **Skapa zoomramar**

Du kan lägga till en zoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
2. Skapa nya bilder som du avser att länka zoomramarna till. 
3. Lägg till identifieringstext och bakgrund på de skapade bilderna. 
4. Lägg till zoomramar (som innehåller referenser till de skapade bilderna) på den första bilden. 
5. Skriv den modifierade presentationen som en PPTX-fil. 

Den här C++-koden visar hur du skapar en zoomram på en bild: 

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Lägg till nya bilder i presentationen
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Skapar en bakgrund för den andra bilden
SetSlideBackground(slide2, Color::get_Cyan());

// Skapar en textruta för den andra bilden
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Skapar en bakgrund för den tredje bilden
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Skapa en textruta för den tredje bilden
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Lägg till ZoomFrame-objekt
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Sparar presentationen
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Skapa zoomramar med anpassade bilder**
Med Aspose.Slides for C++ kan du skapa en zoomram med en annan bildförhandsvisning på följande sätt: 
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
2. Skapa en ny bild som du avser att länka zoomramen till. 
3. Lägg till identifieringstext och bakgrund på bilden. 
4. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/)‑objekt genom att lägga till en bild i bildsamlingen som är associerad med [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑objektet, vilken kommer att användas för att fylla ramen. 
5. Lägg till zoomramar (som innehåller referensen till den skapade bilden) på den första bilden. 
6. Skriv den modifierade presentationen som en PPTX-fil. 

Den här C++-koden visar hur du skapar en zoomram med en annan bild: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Lägger till en ny bild i presentationen
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

//Skapar en bakgrund för den andra bilden
SetSlideBackground(slide, Color::get_Cyan());

//Skapar en textruta för den tredje bilden
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//Skapar en ny bild för zoom‑objektet
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Lägger till ZoomFrame‑objektet
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

//Sparar presentationen
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formatera zoomramar**
I de föregående avsnitten visade vi hur du skapar enkla zoomramar. För att skapa mer komplicerade zoomramar måste du ändra formateringen på en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på en zoomram. 

Du kan kontrollera formateringen av en zoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
2. Skapa nya bilder som du avser att länka zoomramarna till. 
3. Lägg till identifieringstext och bakgrund på de skapade bilderna. 
4. Lägg till zoomramar (som innehåller referenser till de skapade bilderna) på den första bilden. 
5. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/)‑objekt genom att lägga till en bild i bildsamlingen som är associerad med [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑objektet, vilken kommer att användas för att fylla ramen. 
6. Ställ in en anpassad bild för det första zoomram‑objektet. 
7. Ändra linjeformatet för det andra zoomram‑objektet. 
8. Ta bort bakgrunden från en bild i det andra zoomram‑objektet. 
5. Skriv den modifierade presentationen som en PPTX-fil. 

Den här C++-koden visar hur du ändrar en zoomram‑formatering på en bild: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Lägger till nya bilder i presentationen
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// Skapar en bakgrund för den andra bilden
SetSlideBackground(slide2, Color::get_Cyan());

// Skapar en textruta för den andra bilden
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Skapar en bakgrund för den tredje bilden
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Skapar en textruta för den tredje bilden
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Lägger till ZoomFrame-objekt
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Skapar en ny bild för zoom‑objektet
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Ställer in anpassad bild för zoomFrame1‑objektet
zoomFrame1->set_Image(image);

// Ställer in format för zoomram för zoomFrame2‑objektet
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Inställning för att inte visa bakgrund för zoomFrame2‑objektet
zoomFrame2->set_ShowBackground(false);

// Sparar presentationen
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Sektionzoom**

En sektionzoom är en länk till en sektion i din presentation. Du kan använda sektionzoomer för att återgå till sektioner du vill betona. Eller så kan du använda dem för att visa hur vissa delar av din presentation hänger ihop. 

![overview_image](seczoomsel.png)

För sektionzoom‑objekt tillhandahåller Aspose.Slides gränssnittet [ISectionZoomFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isectionzoomframe/) och några metoder under gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/) .

### **Skapa sektionzoomramar**

Du kan lägga till en sektionzoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
2. Skapa en ny bild. 
3. Lägg till identifieringsbakgrund på den skapade bilden. 
4. Skapa en ny sektion som du avser att länka zoomramen till. 
5. Lägg till en sektionzoomram (som innehåller referenser till den skapade sektionen) på den första bilden. 
6. Skriv den modifierade presentationen som en PPTX-fil. 

Den här C++-koden visar hur du skapar en zoomram på en bild: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Lägger till en ny bild i presentationen
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Lägger till ett nytt avsnitt i presentationen
pres->get_Sections()->AddSection(u"Section 1", slide);

// Lägger till ett SectionZoomFrame-objekt
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Sparar presentationen
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **Skapa sektionzoomramar med anpassade bilder**

Med Aspose.Slides for C++ kan du skapa en sektionzoomram med en annan bildförhandsvisning på följande sätt: 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
2. Skapa en ny bild. 
3. Lägg till identifieringsbakgrund på den skapade bilden. 
4. Skapa en ny sektion som du avser att länka zoomramen till. 
5. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/)‑objekt genom att lägga till en bild i bildsamlingen som är associerad med [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑objektet, vilken kommer att användas för att fylla ramen. 
5. Lägg till en sektionzoomram (som innehåller en referens till den skapade sektionen) på den första bilden. 
6. Skriv den modifierade presentationen som en PPTX‑fil. 

Den här C++‑koden visar hur du skapar en zoomram med en annan bild: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Lägger till en ny bild i presentationen
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Lägger till ett nytt avsnitt i presentationen
pres->get_Sections()->AddSection(u"Section 1", slide);

// Skapar en ny bild för zoom‑objektet
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Lägger till SectionZoomFrame‑objekt
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Sparar presentationen
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formatera sektionzoomramar**

För att skapa mer komplicerade sektionzoomramar måste du ändra formateringen på en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på en sektionzoomram. 

Du kan kontrollera formateringen av en sektionzoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
2. Skapa en ny bild. 
3. Lägg till identifieringsbakgrund på den skapade bilden. 
4. Skapa en ny sektion som du avser att länka zoomramen till. 
5. Lägg till en sektionzoomram (som innehåller referenser till den skapade sektionen) på den första bilden. 
6. Ändra storlek och position för det skapade sektionzoom‑objektet. 
7. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/)‑objekt genom att lägga till en bild i bildsamlingen som är associerad med [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑objektet, vilken kommer att användas för att fylla ramen. 
8. Ställ in en anpassad bild för det skapade sektionzoom‑objektet. 
9. Ställ in *återvänd till originalbilden från den länkade sektionen* . 
10. Ta bort bakgrunden från en bild i sektionzoom‑objektet. 
11. Ändra linjeformatet för det andra zoomram‑objektet. 
12. Ändra övergångens varaktighet. 
13. Skriv den modifierade presentationen som en PPTX‑fil. 

Den här C++‑koden visar hur du ändrar formateringen för en sektionzoomram: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Lägger till en ny bild i presentationen
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Lägger till ett nytt avsnitt i presentationen
pres->get_Sections()->AddSection(u"Section 1", slide);

// Lägg till SectionZoomFrame-objekt
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Formatering för SectionZoomFrame
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// Sparar presentationen
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Sammanfattningszoom**

En sammanfattningszoom är som en landningssida där alla delar av din presentation visas samtidigt. När du presenterar kan du använda zoomen för att gå från en plats i presentationen till en annan i valfri ordning. Du kan vara kreativ, hoppa fram eller återvända till delar av ditt bildspel utan att avbryta presentationens flöde. 

![overview_image](sumzoomsel.png)

För sammanfattningszoom‑objekt tillhandahåller Aspose.Slides gränssnitten [ISummaryZoomFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isummaryzoomsection/), och [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isummaryzoomsectioncollection/) samt några metoder under gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/) .

### **Skapa sammanfattningszoom**

Du kan lägga till en sammanfattningszoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
2. Skapa nya bilder med identifieringsbakgrund och nya sektioner för de skapade bilderna. 
3. Lägg till sammanfattningszoomramen på den första bilden. 
4. Skriv den modifierade presentationen som en PPTX‑fil. 

Den här C++‑koden visar hur du skapar en sammanfattningszoomram på en bild: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Lägger till en ny bild i presentationen
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Lägger till ett nytt avsnitt i presentationen
pres->get_Sections()->AddSection(u"Section 1", slide);

// Lägger till en ny bild i presentationen
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Lägger till ett nytt avsnitt i presentationen
pres->get_Sections()->AddSection(u"Section 2", slide);

// Lägger till en ny bild i presentationen
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Lägger till ett nytt avsnitt i presentationen
pres->get_Sections()->AddSection(u"Section 3", slide);

// Lägger till en ny bild i presentationen
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Lägger till ett nytt avsnitt i presentationen
pres->get_Sections()->AddSection(u"Section 4", slide);

// Lägger till ett SummaryZoomFrame-objekt
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Sparar presentationen
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Lägg till och ta bort en sammanfattningszoomsektion**

Alla sektioner i en sammanfattningszoomram representeras av [ISummaryZoomSection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isummaryzoomsection/)‑objekt, som lagras i [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isummaryzoomsectioncollection/)‑objektet. Du kan lägga till eller ta bort ett sammanfattningszoom‑sektion‑objekt via [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isummaryzoomsectioncollection/)‑gränssnittet på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
2. Skapa nya bilder med identifieringsbakgrund och nya sektioner för de skapade bilderna. 
3. Lägg till en sammanfattningszoomram i den första bilden. 
4. Lägg till en ny bild och sektion i presentationen. 
5. Lägg till den skapade sektionen i sammanfattningszoomramen. 
6. Ta bort den första sektionen från sammanfattningszoomramen. 
7. Skriv den modifierade presentationen som en PPTX‑fil. 

Den här C++‑koden visar hur du lägger till och tar bort sektioner i en sammanfattningszoomram: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Lägger till en ny bild i presentationen
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Lägger till ett nytt avsnitt i presentationen
pres->get_Sections()->AddSection(u"Section 1", slide);

//Lägger till en ny bild i presentationen
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Lägger till ett nytt avsnitt i presentationen
pres->get_Sections()->AddSection(u"Section 2", slide);

// Lägger till SummaryZoomFrame-objekt
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Lägger till en ny bild i presentationen
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Lägger till ett nytt avsnitt i presentationen
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Lägger till en sektion i Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Tar bort sektion från Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Sparar presentationen
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formatera sammanfattningszoomsektioner**

För att skapa mer komplicerade sammanfattningszoom‑sektion‑objekt måste du ändra formateringen på en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på ett sammanfattningszoom‑sektion‑objekt. 

Du kan kontrollera formateringen för ett sammanfattningszoom‑sektion‑objekt i en sammanfattningszoomram på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
2. Skapa nya bilder med identifieringsbakgrund och nya sektioner för de skapade bilderna. 
3. Lägg till en sammanfattningszoomram på den första bilden. 
4. Hämta ett sammanfattningszoom‑sektion‑objekt för det första objektet från `ISummaryZoomSectionCollection` . 
7. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/)‑objekt genom att lägga till en bild i bildsamlingen som är associerad med [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑objektet, vilken kommer att användas för att fylla ramen. 
8. Ställ in en anpassad bild för det skapade sektion‑zoom‑objektet. 
9. Ställ in *återvänd till originalbilden från den länkade sektionen* . 
11. Ändra linjeformatet för det andra zoomram‑objektet. 
12. Ändra övergångens varaktighet. 
13. Skriv den modifierade presentationen som en PPTX‑fil. 

Den här C++‑koden visar hur du ändrar formateringen för ett sammanfattningszoom‑sektion‑objekt: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Lägger till en ny bild i presentationen
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Lägger till ett nytt avsnitt i presentationen
pres->get_Sections()->AddSection(u"Section 1", slide);

//Lägger till en ny bild i presentationen
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Lägger till ett nytt avsnitt i presentationen
pres->get_Sections()->AddSection(u"Section 2", slide);

// Lägger till ett SummaryZoomFrame-objekt
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Hämtar det första SummaryZoomSection-objektet
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Formatering för SummaryZoomSection-objektet
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Sparar presentationen
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Vanliga frågor**

**Kan jag kontrollera återgång till den 'föräldra' bilden efter att ha visat målet?**

Ja. [Zoom frame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/zoomframe/) eller [section](https://reference.aspose.com/slides/sv/cpp/aspose.slides/sectionzoomframe/) har en `set_ReturnToParent`‑metod som skickar tittaren tillbaka till ursprungsbilden efter att de har besökt mål‑innehållet.

**Kan jag justera 'hastigheten' eller varaktigheten för Zoom‑övergången?**

Ja. Zoom stöder att ange en övergångsvaraktighet så att du kan kontrollera hur lång tid hopp‑animationen tar.

**Finns det begränsningar för hur många Zoom‑objekt en presentation kan innehålla?**

Det finns ingen hård API‑gräns dokumenterad. Praktiska gränser beror på presentationens totala komplexitet och mottagarens prestanda. Du kan lägga till många Zoom‑ramar, men bör beakta filstorlek och renderingstid.