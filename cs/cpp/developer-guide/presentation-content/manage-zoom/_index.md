---
title: Správa zoomu prezentace v C++
linktitle: Správa Zoomu
type: docs
weight: 60
url: /cs/cpp/manage-zoom/
keywords:
- zoom
- rámec zoomu
- zoom snímku
- zoom sekce
- souhrnný zoom
- přidat zoom
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte zoom pomocí Aspose.Slides pro C++ — přecházejte mezi sekcemi, přidávejte miniatury a přechodové efekty v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Zoomy v aplikaci PowerPoint vám umožňují skákat na konkrétní snímky, sekce a části prezentace i zpět. Při prezentování může být tato možnost rychlé navigace napříč obsahem velmi užitečná. 

![overview_image](Overview.png)

* Pro shrnutí celé prezentace na jediném snímku použijte [Souhrnný Zoom](#Summary-Zoom).
* Pro zobrazení pouze vybraných snímků použijte [Zoom snímku](#Slide-Zoom).
* Pro zobrazení jedné sekce použijte [Zoom sekce](#Section-Zoom).

## **Zoom snímku**
Zoom snímku může vaši prezentaci učinit dynamičtější a umožnit vám volně navigovat mezi snímky v libovolném pořadí, aniž byste přerušili tok prezentace. Zoomy snímků jsou skvělé pro krátké prezentace bez mnoha sekcí, ale můžete je použít i v různých prezentačních scénářích.

Zoomy snímků vám pomáhají ponořit se do více informací, přičemž máte pocit, že pracujete na jedné plátně. 

![overview_image](slidezoomsel.png)

Pro objekty zoomu snímku poskytuje Aspose.Slides výčtový typ [ZoomImageType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/zoomimagetype/), rozhraní [IZoomFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/izoomframe/) a některé metody pod rozhraním [IShapeCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/).

### **Vytvoření rámců Zoom**
Můžete přidat rámec zoomu na snímek tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2.	Vytvořte nové snímky, na které chcete odkazovat pomocí rámců zoomu. 
3.	Přidejte identifikační text a pozadí na vytvořené snímky.
4.	Přidejte rámce zoomu (obsahující odkazy na vytvořené snímky) na první snímek.
5.	Zapište upravenou prezentaci jako soubor PPTX.

Tento kód C++ vám ukazuje, jak vytvořit rámec zoomu na snímku:

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

//Přidá nové snímky do prezentace
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Vytvoří pozadí pro druhý snímek
SetSlideBackground(slide2, Color::get_Cyan());

// Vytvoří textové pole pro druhý snímek
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Vytvoří pozadí pro třetí snímek
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Vytvoří textové pole pro třetí snímek
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Adds ZoomFrame objects
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Uloží prezentaci
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Vytvoření rámců Zoom s vlastními obrázky**
S Aspose.Slides pro C++ můžete vytvořit rámec zoomu s jiným náhledem snímku tímto způsobem: 
1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2.	Vytvořte nový snímek, na který chcete odkazovat pomocí rámce zoomu. 
3.	Přidejte identifikační text a pozadí na snímek.
4.	Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) přidáním obrázku do kolekce Images spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), který bude použit k vyplnění rámce.
5.	Přidejte rámce zoomu (obsahující odkaz na vytvořený snímek) na první snímek.
6.	Zapište upravenou prezentaci jako soubor PPTX.

Tento kód C++ vám ukazuje, jak vytvořit rámec zoomu s jiným obrázkem:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Přidá nový snímek do prezentace
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

//Vytvoří pozadí pro druhý snímek
SetSlideBackground(slide, Color::get_Cyan());

//Vytvoří textové pole pro třetí snímek
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//Vytvoří nový obrázek pro objekt zoomu
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Přidá objekt ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

//Uloží prezentaci
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formátování rámců Zoom**
V předchozích sekcích jsme vám ukázali, jak vytvořit jednoduché rámce zoomu. Pro vytvoření složitějších rámců zoomu musíte změnit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na rámec zoomu použít. 

Můžete ovládat formátování rámce zoomu na snímku tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2.	Vytvořte nové snímky, na které chcete odkazovat pomocí rámce zoomu. 
3.	Přidejte nějaký identifikační text a pozadí na vytvořené snímky.
4.	Přidejte rámce zoomu (obsahující odkazy na vytvořené snímky) na první snímek.
5.	Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) přidáním obrázku do kolekce Images spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), který bude použit k vyplnění rámce.
6.	Nastavte vlastní obrázek pro první objekt rámce zoomu.
7.	Změňte formátování linie pro druhý objekt rámce zoomu.
8.	Odstraňte pozadí z obrázku druhého objektu rámce zoomu.
5.	Zapište upravenou prezentaci jako soubor PPTX.

Tento kód C++ vám ukazuje, jak změnit formátování rámce zoomu na snímku: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Přidá nové snímky do prezentace
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// Creates a background for the second slide
SetSlideBackground(slide2, Color::get_Cyan());

// Creates a text box for the second slide
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Creates a background for the third slide
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Creates a text box for the third slide
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Adds ZoomFrame objects
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Creates a new image for the zoom object
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Sets custom image for zoomFrame1 object
zoomFrame1->set_Image(image);

// Sets a zoom frame format for the zoomFrame2 object
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Setting for Do not show background for zoomFrame2 object
zoomFrame2->set_ShowBackground(false);

// Saves the presentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Zoom sekce**

Zoom sekce je odkaz na sekci ve vaší prezentaci. Můžete použít zoomy sekcí k návratu na sekce, které chcete opravdu zdůraznit. Nebo je můžete použít k zvýraznění toho, jak určité části vaší prezentace spolu souvisejí. 

![overview_image](seczoomsel.png)

Pro objekty zoomu sekce poskytuje Aspose.Slides rozhraní [ISectionZoomFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isectionzoomframe/) a některé metody pod rozhraním [IShapeCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/).

### **Vytvoření rámců Zoom sekce**
Můžete přidat rámec zoomu sekce na snímek tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2.	Vytvořte nový snímek. 
3.	Přidejte identifikační pozadí na vytvořený snímek.
4.	Vytvořte novou sekci, na kterou chcete odkazovat pomocí rámce zoomu. 
5.	Přidejte rámec zoomu sekce (obsahující odkazy na vytvořenou sekci) na první snímek.
6.	Zapište upravenou prezentaci jako soubor PPTX.

Tento kód C++ vám ukazuje, jak vytvořit rámec zoomu na snímku:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Přidá nový snímek do prezentace
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Přidá novou sekci do prezentace
pres->get_Sections()->AddSection(u"Section 1", slide);

// Přidá objekt SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Uloží prezentaci
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **Vytvoření rámců Zoom sekce s vlastními obrázky**
Pomocí Aspose.Slides pro C++ můžete vytvořit rámec zoomu sekce s jiným náhledem snímku tímto způsobem: 

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2.	Vytvořte nový snímek.
3.	Přidejte identifikační pozadí na vytvořený snímek.
4.	Vytvořte novou sekci, na kterou chcete odkazovat pomocí rámce zoomu. 
5.	Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) přidáním obrázku do kolekce Images spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), který bude použit k vyplnění rámce.
5.	Přidejte rámec zoomu sekce (obsahující odkaz na vytvořenou sekci) na první snímek.
6.	Zapište upravenou prezentaci jako soubor PPTX.

Tento kód C++ vám ukazuje, jak vytvořit rámec zoomu s jiným obrázkem:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Přidá nový snímek do prezentace
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Přidá novou sekci do prezentace
pres->get_Sections()->AddSection(u"Section 1", slide);

// Vytvoří nový obrázek pro objekt zoomu
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Přidá objekt SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Uloží prezentaci
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formátování rámců Zoom sekce**
Pro vytvoření složitějších rámců zoomu sekce musíte změnit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na rámec zoomu sekce použít. 

Můžete ovládat formátování rámce zoomu sekce na snímku tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2.	Vytvořte nový snímek.
3.	Přidejte identifikační pozadí na vytvořený snímek.
4.	Vytvořte novou sekci, na kterou chcete odkazovat pomocí rámce zoomu. 
5.	Přidejte rámec zoomu sekce (obsahující odkazy na vytvořenou sekci) na první snímek.
6.	Změňte velikost a pozici vytvořeného objektu zoomu sekce.
7.	Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) přidáním obrázku do kolekce Images spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), který bude použit k vyplnění rámce.
8.	Nastavte vlastní obrázek pro vytvořený objekt rámce zoomu sekce.
9.	Nastavte schopnost *návratu na původní snímek z propojené sekce*. 
10.	Odstraňte pozadí z obrázku objektu zoomu sekce.
11.	Změňte formátování linie pro druhý objekt rámce zoomu.
12.	Změňte dobu trvání přechodu.
13.	Zapište upravenou prezentaci jako soubor PPTX.

Tento kód C++ vám ukazuje, jak změnit formátování rámce zoomu sekce:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Přidá nový snímek do prezentace
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Přidá novou sekci do prezentace
pres->get_Sections()->AddSection(u"Section 1", slide);

// Přidá objekt SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Formátování pro SectionZoomFrame
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

// Uloží prezentaci
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Souhrnný Zoom**

Souhrnný Zoom je jako vstupní stránka, kde jsou všechny části vaší prezentace zobrazeny najednou. Když prezentujete, můžete pomocí Zoomu přecházet z jednoho místa prezentace na jiné v libovolném pořadí. Můžete být kreativní, přeskočit dopředu nebo se vrátit k částem prezentace, aniž byste narušili její tok.

![overview_image](sumzoomsel.png)

Pro objekty souhrnného zoomu poskytuje Aspose.Slides rozhraní [ISummaryZoomFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isummaryzoomsection/) a [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isummaryzoomsectioncollection/) a některé metody pod rozhraním [IShapeCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/).

### **Vytvoření souhrnného Zoomu**
Můžete přidat rámec souhrnného Zoomu na snímek tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2.	Vytvořte nové snímky s identifikačním pozadím a novými sekcemi pro vytvořené snímky.
3.	Přidejte rámec souhrnného Zoomu na první snímek.
4.	Zapište upravenou prezentaci jako soubor PPTX.

Tento kód C++ vám ukazuje, jak vytvořit rámec souhrnného Zoomu na snímku:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Přidá nový snímek do prezentace
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Přidá novou sekci do prezentace
pres->get_Sections()->AddSection(u"Section 1", slide);

// Přidá nový snímek do prezentace
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Přidá novou sekci do prezentace
pres->get_Sections()->AddSection(u"Section 2", slide);

// Přidá nový snímek do prezentace
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Přidá novou sekci do prezentace
pres->get_Sections()->AddSection(u"Section 3", slide);

// Přidá nový snímek do prezentace
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Přidá novou sekci do prezentace
pres->get_Sections()->AddSection(u"Section 4", slide);

// Přidá objekt SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Uloží prezentaci
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Přidání a odebrání sekce souhrnného Zoomu**
Všechny sekce v rámci souhrnného Zoomu jsou reprezentovány objekty [ISummaryZoomSection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isummaryzoomsection/), které jsou uloženy v objektu [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isummaryzoomsectioncollection/). Sekci můžete přidat nebo odebrat pomocí rozhraní [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isummaryzoomsectioncollection/) tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2.	Vytvořte nové snímky s identifikačním pozadím a novými sekcemi pro vytvořené snímky.
3.	Přidejte rámec souhrnného Zoomu do první snímky.
4.	Přidejte nový snímek a sekci do prezentace.
5.	Přidejte vytvořenou sekci do rámce souhrnného Zoomu.
6.	Odeberte první sekci z rámce souhrnného Zoomu.
7.	Zapište upravenou prezentaci jako soubor PPTX.

Tento kód C++ vám ukazuje, jak přidat a odebrat sekce v rámci souhrnného Zoomu:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Přidá nový snímek do prezentace
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Přidá novou sekci do prezentace
pres->get_Sections()->AddSection(u"Section 1", slide);

//Přidá nový snímek do prezentace
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Přidá novou sekci do prezentace
pres->get_Sections()->AddSection(u"Section 2", slide);

// Přidá objekt SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Přidá nový snímek do prezentace
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Přidá novou sekci do prezentace
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Přidá sekci do Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Odstraní sekci ze Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Uloží prezentaci
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Formátování sekcí souhrnného Zoomu**
Pro vytvoření složitějších objektů sekcí souhrnného Zoomu musíte změnit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na objekt sekce souhrnného Zoomu použít. 

Můžete ovládat formátování objektu sekce souhrnného Zoomu v rámci souhrnného Zoomu tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2.	Vytvořte nové snímky s identifikačním pozadím a novými sekcemi pro vytvořené snímky.
3.	Přidejte rámec souhrnného Zoomu na první snímek.
4.	Získejte objekt sekce souhrnného Zoomu pro první objekt z `ISummaryZoomSectionCollection`.
7.	Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) přidáním obrázku do kolekce images spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/), který bude použit k vyplnění rámce.
8.	Nastavte vlastní obrázek pro vytvořený objekt rámce sekce zoomu.
9.	Nastavte schopnost *návratu na původní snímek z propojené sekce*. 
11.	Změňte formátování linie pro druhý objekt rámce zoomu.
12.	Změňte dobu trvání přechodu.
13.	Zapište upravenou prezentaci jako soubor PPTX.

Tento kód C++ vám ukazuje, jak změnit formátování objektu sekce souhrnného Zoomu:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Přidá nový snímek do prezentace
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Přidá novou sekci do prezentace
pres->get_Sections()->AddSection(u"Section 1", slide);

//Přidá nový snímek do prezentace
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Přidá novou sekci do prezentace
pres->get_Sections()->AddSection(u"Section 2", slide);

// Přidá objekt SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Získá první objekt SummaryZoomSection
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Formátování objektu SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Uloží prezentaci
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Mohu ovládat návrat na „rodičovský“ snímek po zobrazení cíle?**

Ano. Rámec [Zoom](https://reference.aspose.com/slides/cs/cpp/aspose.slides/zoomframe/) nebo [section](https://reference.aspose.com/slides/cs/cpp/aspose.slides/sectionzoomframe/) má metodu `set_ReturnToParent`, která po návštěvě cílového obsahu vrátí diváky zpět na výchozí snímek.

**Mohu upravit „rychlost“ nebo dobu trvání přechodu Zoomu?**

Ano. Zoom podporuje nastavení trvání přechodu, takže můžete ovládat, jak dlouho trvá animace skoku.

**Existují limity, kolik Zoom objektů může prezentace obsahovat?**

Neexistuje pevně stanovený limit API. Praktické limity závisí na celkové složitosti prezentace a výkonu prohlížeče. Můžete přidat mnoho rámců Zoom, ale zvažte velikost souboru a dobu renderování.