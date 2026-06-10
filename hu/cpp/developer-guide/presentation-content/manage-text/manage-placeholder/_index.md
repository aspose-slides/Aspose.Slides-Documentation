---
title: C++-ban prezentációs helyettesítők kezelése
linktitle: Helyettesítők kezelése
type: docs
weight: 10
url: /hu/cpp/manage-placeholder/
keywords:
- helyettesítő
- szöveghelyettesítő
- képhelyettesítő
- diagramhelyettesítő
- felszólító szöveg
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Az Aspose.Slides for C++ segítségével egyszerűen kezelheti a helyettesítőket: szöveg cseréje, felszólítások testreszabása és képek átlátszóságának beállítása PowerPoint és OpenDocument formátumokban."
---
## **Overview**

Az Aspose.Slides lehetővé teszi, hogy programozottan kezelje a bemutatóhelyettesítőket. Ez a cikk bemutatja, hogyan találhat helyettesítőket a diákon és módosíthatja a szövegüket, hogyan állíthat be egyéni felszólító szöveget a helyettesítő elrendezésekhez, valamint hogyan állíthatja be egy kép átlátszóságát, amely helyettesítő háttérként szolgál. Emellett tartalmaz egy rövid GYIK-et, amely tisztázza az alaphelyettesítők és a helyi alakzatok közötti különbséget, elmagyarázza, hogyan alkalmazhatók a helyettesítő módosítások elrendezéseken vagy mestereken keresztül, és útmutatást ad a fejléc és lábléc helyettesítőinek kezeléséhez.

## **Change Text in a Placeholder**
Az [Aspose.Slides for C++](/slides/hu/cpp/) segítségével megtalálhatja és módosíthatja a helyettesítőket a diákban található prezentációkban. Az Aspose.Slides lehetővé teszi a helyettesítő szövegének módosítását.

**Prerequisite**: Szüksége van egy helyettesítőt tartalmazó prezentációra. Ilyen prezentációt a szokásos Microsoft PowerPoint alkalmazásban hozhat létre.

Így használhatja az Aspose.Slides‑t a helyettesítő szövegének cseréjére ebben a prezentációban:

1. Példányosítsa a [`Presentation`](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation/) osztályt, és adja meg argumentumként a prezentációt.
2. Kapjon meg egy dia hivatkozást az indexén keresztül.
3. Iteráljon a formákon, hogy megtalálja a helyettesítőt.
4. Típuskonvertálja a helyettesítő formát egy [`AutoShape`](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.auto_shape/) típusra, és módosítsa a szöveget a hozzá tartozó [`TextFrame`](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.text_frame/) segítségével.
5. Mentse el a módosított prezentációt.

Ez a C++ kód bemutatja, hogyan lehet megváltoztatni a szöveget egy helyettesítőben:

```c++
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Betölti a kívánt prezentációt
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Eléri az első diát
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Eléri a dián az első és második helyettesítőt, és AutoShape‑ként típuskonvertálja
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
    
// Mentse a prezentációt a lemezen
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Set Prompt Text in a Placeholder**
A szabványos és előre elkészített elrendezések tartalmaznak helyettesítő felszólító szövegeket, például ***Kattintson a cím hozzáadásához*** vagy ***Kattintson az alcím hozzáadásához***. Az Aspose.Slides segítségével saját kedvenc felszólító szövegeit illesztheti be a helyettesítő elrendezésekbe.

Ez a C++ kód megmutatja, hogyan állítható be a felszólító szöveg egy helyettesítőben:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Ha nincs benne szöveg, a PowerPoint a "Click to add title" feliratot jeleníti meg. 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Ugyanezt teszi az alcímhez.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Set Placeholder Image Transparency**

Az Aspose.Slides lehetővé teszi a háttérkép átlátszóságának beállítását egy szöveges helyettesítőben. A kép átlátszóságának beállításával egy ilyen keretben kiemelheti a szöveget vagy a képet (a szöveg és a kép színeitől függően).

Ez a C++ kód megmutatja, hogyan állítható be egy kép háttérnek az átlátszósága (alakzaton belül):

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

**What is a base placeholder, and how is it different from a local shape on a slide?**

Egy alaphelyettesítő az a kiinduló forma egy elrendezésen vagy a mesteren, amelyből a dia alakzata örököl – típusa, pozíciója és egyes formázásai innen származnak. A helyi alakzat független; ha nincs alaphelyettesítő, az öröklődés nem alkalmazandó.

**How can I update all titles or captions across a presentation without iterating over every slide?**

Szerkessze a megfelelő helyettesítőt az elrendezésen vagy a mesteren. Az azok alapján készült diák automatikusan örökölni fogják a módosítást.

**How do I control the standard header/footer placeholders—date & time, slide number, and footer text?**

Használja a HeaderFooter kezelőket a megfelelő hatókörben (normál diák, elrendezések, mester, jegyzetek/elosztók), hogy be- vagy kikapcsolja ezeket a helyettesítőket, és beállítsa a tartalmukat.