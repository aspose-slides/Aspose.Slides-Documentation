---
title: "C++-ban a prezentáció hiperhivatkozásainak kezelése"
linktitle: "Hiperhivatkozás kezelése"
type: docs
weight: 20
url: /hu/cpp/manage-hyperlinks/
keywords:
- "URL hozzáadása"
- "hiperhivatkozás hozzáadása"
- "hiperhivatkozás létrehozása"
- "hiperhivatkozás formázása"
- "hiperhivatkozás eltávolítása"
- "hiperhivatkozás frissítése"
- "szöveges hiperhivatkozás"
- "dia hiperhivatkozás"
- "alakzat hiperhivatkozás"
- "kép hiperhivatkozás"
- "videó hiperhivatkozás"
- "módosítható hiperhivatkozás"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "C++"
- "Aspose.Slides"
description: "Könnyedén kezelheti a hiperhivatkozásokat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for C++ segítségével — fokozza az interaktivitást és a munkafolyamatot percek alatt."
---
## **Bevezetés**

A hiperhivatkozás egy objektumra, adatra vagy egy helyre való hivatkozás. Ezek a gyakori hiperhivatkozások a PowerPoint prezentációkban:

* Weboldalakra mutató hivatkozások szövegekben, alakzatokban vagy médiában
* Dia linkek

Az Aspose.Slides for C++ lehetővé teszi, hogy sok feladatot hajtson végre, amelyek hiperhivatkozásokat érintenek a prezentációkban. 

{{% alert color="primary" %}} 
Érdemes megnézni az Aspose egyszerű, [ingyenes online PowerPoint szerkesztő](https://products.aspose.app/slides/hu/editor)
{{% /alert %}} 

## **URL hiperhivatkozások hozzáadása**

### **URL hiperhivatkozások hozzáadása szöveghez**

Ez a C++ kód bemutatja, hogyan adhatunk hozzá egy weboldal hiperhivatkozást egy szöveghez:
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **URL hiperhivatkozások hozzáadása alakzatokhoz vagy keretekhez**

Ez a C++ minta kód bemutatja, hogyan adhatunk hozzá egy weboldal hiperhivatkozást egy alakzathoz:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **URL hiperhivatkozások hozzáadása médiához**

Az Aspose.Slides lehetővé teszi, hogy hiperhivatkozásokat adjunk hozzá képekhez, hang- és videofájlokhoz. 

Ez a minta kód bemutatja, hogyan adhatunk hozzá egy hiperhivatkozást egy **képre**:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// Képet ad a prezentációhoz
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// Létrehozza a képkockát az 1. dián a korábban hozzáadott kép alapján
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

Ez a minta kód bemutatja, hogyan adhatunk hozzá egy hiperhivatkozást egy **hangfájlhoz**:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

Ez a minta kód bemutatja, hogyan adhatunk hozzá egy hiperhivatkozást egy **videóhoz**:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

{{%  alert  title="Tip"  color="primary"  %}} 
Érdemes megnézni a *[OLE kezelése](https://docs.aspose.com/slides/hu/cpp/manage-ole/)*.
{{% /alert %}}

## **Hiperhivatkozások használata Tartalomjegyzék létrehozásához**

Mivel a hiperhivatkozások lehetővé teszik objektumokra vagy helyekre mutató hivatkozások hozzáadását, használhatók tartalomjegyzék létrehozásához. 

Ez a minta kód bemutatja, hogyan hozhat létre egy tartalomjegyzéket hiperhivatkozásokkal:
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```

## **Hiperhivatkozások formázása**

### **Szín**

A [set_ColorSource()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) és a [get_ColorSource()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) metódusok az [IHyperlink](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_hyperlink) interfészben lehetővé teszik, hogy beállítsa a hiperhivatkozások színét, valamint lekérje a színinformációt a hiperhivatkozásokból. A funkció először a PowerPoint 2019-ben került bevezetésre, így a tulajdonságot érintő változások nem vonatkoznak a régebbi PowerPoint verziókra.

Ez a minta kód bemutat egy műveletet, ahol különböző színű hiperhivatkozásokat adtak hozzá ugyanahhoz a diára:
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

## **Hiperhivatkozások eltávolítása a prezentációkból**

### **Hiperhivatkozások eltávolítása szövegből**

Ez a C++ kód bemutatja, hogyan távolítható el a hiperhivatkozás egy szövegből egy prezentáció dián:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

### **Hiperhivatkozások eltávolítása alakzatokból vagy keretekből**

Ez a C++ kód bemutatja, hogyan távolítható el a hiperhivatkozás egy alakzatról egy prezentáció dián: 
``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

## **Módosítható hiperhivatkozás**

A [Hyperlink](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.hyperlink) osztály módosítható. Ezzel az osztállyal megváltoztathatja ezeknek a metódusoknak az értékeit:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

A kódrészlet bemutatja, hogyan adhat hiperhivatkozást egy diára, és később szerkesztheti a tooltipjét:
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **Támogatott metódusok az IHyperlinkQueries-ben**

Az IHyperlinkQueries-t elérheti egy prezentációból, diáiból vagy szövegből, amelyhez a hiperhivatkozás definiálva van. 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

Az IHyperlinkQueries osztály támogatja ezeket a metódusokat: 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **GYIK**

**Hogyan hozhatok létre belső navigációt nem csak egy diára, hanem egy "szakaszra" vagy a szakasz első diájára?**

A PowerPoint szakaszok a diák csoportosításai; a navigáció technikailag egy konkrét diát céloz. A "szakaszra navigáláshoz" általában az első diájára hivatkozunk.

**Csatolhatok hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és elrendezés elemei támogatják a hiperhivatkozásokat. Az ilyen linkek megjelennek az aloldalakon, és a diavetítés során kattinthatók.

**Megmaradnak a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/cpp/convert-powerpoint-to-html/) esetén igen – a linkek általában megmaradnak. A [képek](/slides/hu/cpp/convert-powerpoint-to-png/) és [videó](/slides/hu/cpp/convert-powerpoint-to-video/) exportálásakor a kattintási lehetőség nem marad meg a formátumok természetéből adódóan (a raszteres képkockák/videó nem támogatják a hiperhivatkozásokat).