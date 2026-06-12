---
title: Správa hypertextových odkazů v C++
linktitle: Spravovat hypertextový odkaz
type: docs
weight: 20
url: /cs/cpp/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odstranit hypertextový odkaz
- aktualizovat hypertextový odkaz
- hypertextový odkaz v textu
- hypertextový odkaz na snímek
- hypertextový odkaz na tvar
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- měnitelný hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Jednoduše spravujte hypertextové odkazy v PowerPoint a OpenDocument prezentacích pomocí Aspose.Slides pro C++ — zvyšte interaktivitu a efektivitu během několika minut."
---
## **Úvod**

Hyperlink je odkaz na objekt, data nebo místo v něčem. Toto jsou běžné hypertextové odkazy v prezentacích PowerPoint:

* Odkazy na webové stránky v textech, tvarech nebo médiích
* Odkazy na snímky

Aspose.Slides pro C++ vám umožňuje provádět řadu úkolů souvisejících s hypertextovými odkazy v prezentacích. 

{{% alert color="primary" %}} 

Můžete si vyzkoušet jednoduchý, [bezplatný online editor PowerPointu.](https://products.aspose.app/slides/cs/editor)

{{% /alert %}} 

## **Přidání hypertextových odkazů URL**

### **Přidání hypertextových odkazů URL k textu**

Tento C++ kód ukazuje, jak přidat hypertextový odkaz na webovou stránku do textu:

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

### **Přidání hypertextových odkazů URL k objektům nebo rámečkům**

Tento ukázkový kód v C++ ukazuje, jak přidat hypertextový odkaz na webovou stránku do objektu:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **Přidání hypertextových odkazů URL k médiím**

Aspose.Slides vám umožňuje přidávat hypertextové odkazy k obrázkům, audio a video souborům. 

Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz k **obrázku**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// Přidá obrázek do prezentace
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// Vytvoří rámeček obrázku na snímku 1 na základě dříve přidaného obrázku
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

 Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz k **audio souboru**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

 Tento ukázkový kód ukazuje, jak přidat hypertextový odkaz k **videu**:

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

Můžete si prohlédnout *[Spravovat OLE](https://docs.aspose.com/slides/cs/cpp/manage-ole/)*.

{{% /alert %}}



## **Použití hypertextových odkazů k vytvoření obsahu**

Protože hypertextové odkazy umožňují přidávat odkazy na objekty nebo místa, můžete je použít k vytvoření obsahu. 

Tento ukázkový kód ukazuje, jak vytvořit obsah s hypertextovými odkazy:

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


## **Formátování hypertextových odkazů**

### **Barva**

S metodami [set_ColorSource()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) a [get_ColorSource()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) v rozhraní [IHyperlink](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_hyperlink) můžete nastavit barvu hypertextových odkazů a také získat informaci o barvě z hypertextových odkazů. Tato funkce byla poprvé představena v PowerPointu 2019, takže změny týkající se této vlastnosti se nepoužijí na starší verze PowerPointu.

Tento ukázkový kód demonstruje operaci, při které byly na stejný snímek přidány hypertextové odkazy s různými barvami:

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


## **Odstranění hypertextových odkazů z prezentací**

### **Odstranění hypertextových odkazů z textu**

Tento C++ kód ukazuje, jak odstranit hypertextový odkaz z textu v snímku prezentace:

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

### **Odstranění hypertextových odkazů z objektů nebo rámečků**

Tento C++ kód ukazuje, jak odstranit hypertextový odkaz z objektu v snímku prezentace: 

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```



## **Měnitelný hypertextový odkaz**

Třída [Hyperlink](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.hyperlink) je měnitelná. S touto třídou můžete měnit hodnoty následujících metod:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

Tento úryvek kódu ukazuje, jak přidat hypertextový odkaz do snímku a později upravit jeho tooltip:

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




## **Podporované metody v IHyperlinkQueries**

K IHyperlinkQueries můžete přistupovat z prezentace, snímku nebo textu, pro který je hypertextový odkaz definován. 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

Třída IHyperlinkQueries podporuje tyto metody: 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **Často kladené dotazy**

**Jak mohu vytvořit vnitřní navigaci nejen k snímku, ale k „sekci“ nebo prvnímu snímku sekce?**

Sekce v PowerPointu jsou seskupení snímků; navigace technicky cílí na konkrétní snímek. Pro „navigaci do sekce“ obvykle odkazujete na její první snímek.

**Mohu přiřadit hypertextový odkaz k prvkům hlavní snímku, aby fungoval na všech snímcích?**

Ano. Prvky hlavního snímku a rozložení podporují hypertextové odkazy. Tyto odkazy se zobrazí na podřízených snímcích a jsou klikatelné během prezentace.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

V [PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/cpp/convert-powerpoint-to-html/) ano – odkazy jsou obvykle zachovány. Při exportu do [obrázků](/slides/cs/cpp/convert-powerpoint-to-png/) a [videí](/slides/cs/cpp/convert-powerpoint-to-video/) klikatelnost nepřetrvá kvůli povaze těchto formátů (rasterové snímky/videa nepodporují hypertextové odkazy).