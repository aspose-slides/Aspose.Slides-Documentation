---
title: ActiveX vezérlők kezelése prezentációkban C++-al
linktitle: ActiveX
type: docs
weight: 80
url: /hu/cpp/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX kezelése
- ActiveX hozzáadása
- ActiveX módosítása
- médialejátszó
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan használja az Aspose.Slides for C++ az ActiveX-et a PowerPoint prezentációk automatizálására és fejlesztésére, lehetővé téve a fejlesztők számára a diák hatékony irányítását."
---
## **Bevezetés**

Az ActiveX vezérlőket prezentációkban használják. Az Aspose.Slides for C++ lehetővé teszi az ActiveX vezérlők kezelését, de ezek kezelése valamivel bonyolultabb és különbözik a normál prezentációs alakzatoktól. Az Aspose.Slides for C++ 18.1 verziótól a komponens támogatja az ActiveX vezérlők kezelését. Jelenleg elérheted a prezentációban már hozzáadott ActiveX vezérlőket, és a különféle tulajdonságaik használatával módosíthatod vagy törölheted őket. Ne feledd, az ActiveX vezérlők nem alakzatok, és nem részei a prezentáció IShapeCollection gyűjteményének, hanem egy külön IControlCollection-nek. Ez a cikk bemutatja, hogyan dolgozhatsz velük.

## **ActiveX vezérlő módosítása**
Egyszerű ActiveX vezérlő, például egy szövegmező és egy egyszerű parancsgomb kezelése egy dián:

1. Hozz létre egy Presentation osztálypéldányt, és töltsd be a benne ActiveX vezérlőket tartalmazó prezentációt.  
1. Szerezz be egy diára mutató hivatkozást az indexe alapján.  
1. Érd el a dián lévő ActiveX vezérlőket az IControlCollection elérésével.  
1. A ControlEx objektum segítségével érj hozzá a TextBox1 ActiveX vezérlőhöz.  
1. Módosítsd a TextBox1 ActiveX vezérlő különböző tulajdonságait, beleértve a szöveget, betűtípust, betűmagasságot és a keret pozícióját.  
1. Érd el a második vezérlőt, a CommandButton1-et.  
1. Módosítsd a gomb feliratát, betűtípusát és pozícióját.  
1. Áthelyezd az ActiveX vezérlők kereteinek pozícióját.  
1. Írd a módosított prezentációt PPTX fájlba.  

Az alábbi kódrészlet frissíti a prezentáció diáin lévő ActiveX vezérlőket a lent látható diához.

``` cpp
// A prezentáció elérése ActiveX vezérlőkkel
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Az első dia elérése a prezentációban
auto slide = presentation->get_Slides()->idx_get(0);

// changing TextBox text
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // helyettesítő kép módosítása. A PowerPoint kicseréli ezt a képet az ActiveX aktiválásakor, ezért néha rendben van, ha a képet változatlanul hagyjuk.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// A gomb feliratának módosítása
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // helyettesítő módosítása
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// ActiveX keretek mozgatása 100 ponttal lefelé
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// A prezentáció mentése módosított ActiveX vezérlőkkel
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Most a vezérlők eltávolítása
slide->get_Controls()->Clear();

// A prezentáció mentése törölt ActiveX vezérlőkkel
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Média lejátszó ActiveX vezérlő hozzáadása**
Az ActiveX vezérlőket prezentációkban használják. Az Aspose.Slides for C++ lehetővé teszi az ActiveX vezérlők hozzáadását és kezelését, de ezek kezelése valamivel bonyolultabb és eltér a normál prezentációs alakzatoktól. Az Aspose.Slides for C++ 18.1 verziótól kezdve támogatott a Media Player ActiveX vezérlő hozzáadása. Ne feledd, az ActiveX vezérlők nem alakzatok, és nem részei a prezentáció IShapeCollection gyűjteményének, hanem egy külön IControlExCollection-nek. Ez a cikk bemutatja, hogyan dolgozhatsz velük. Egy Media Player ActiveX vezérlő kezeléséhez hajtsd végre a következő lépéseket:

1. Hozz létre egy Presentation osztálypéldányt, és töltsd be a Media Player ActiveX vezérlőket tartalmazó minta prezentációt.  
1. Hozz létre egy cél Presentation osztálypéldányt, és generálj egy üres prezentációt.  
1. Klónozd a sablon prezentációban a Media Player ActiveX vezérlőt tartalmazó diát a cél Presentation-be.  
1. Érd el a klónozott diát a cél Presentation-ben.  
1. Érd el a dián lévő ActiveX vezérlőket az IControlCollection elérésével.  
1. Érd el a Media Player ActiveX vezérlőt, és állítsd be a videó útvonalát a tulajdonságai segítségével.  
1. Mentsd a prezentációt PPTX fájlba.  

``` cpp
// A Presentation osztály példányosítása, amely PPTX fájlt képvisel
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Üres prezentáció példány létrehozása
auto newPresentation = System::MakeObject<Presentation>();

// Alapértelmezett dia eltávolítása
newPresentation->get_Slides()->RemoveAt(0);

// Média lejátszó ActiveX vezérlővel rendelkező dia klónozása
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// A Media Player ActiveX vezérlő elérése és a videó útvonalának beállítása
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// A prezentáció mentése
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Megőrzi az Aspose.Slides az ActiveX vezérlőket olvasás és újra mentés során, ha azok nem futtathatók a C++ futtatókörnyezetben?**

Igen. Az Aspose.Slides úgy kezeli őket, mint a prezentáció részét, és képes olvasni/módosítani a tulajdonságaikat és a kereteiket; a vezérlők saját maguknak a végrehajtása nem szükséges a megőrzésükhöz.

**Miben különböznek az ActiveX vezérlők az OLE objektumoktól egy prezentációban?**

Az ActiveX vezérlők interaktív, menedzselt vezérlők (gombok, szövegmezők, média lejátszó), míg az [OLE](/slides/hu/cpp/manage-ole/) beágyazott alkalmazásobjektumokra (például egy Excel munkalapra) utal. Más módon tárolódnak és kezelődnek, és különböző tulajdonsági modelljük van.

**Működnek az ActiveX események és VBA makrók, ha a fájlt az Aspose.Slides módosította?**

Az Aspose.Slides megőrzi a meglévő jelölést és metaadatokat; azonban az események és makrók csak akkor futnak a PowerPointban Windows alatt, ha a biztonsági beállítások ezt engedik. A könyvtár nem hajtja végre a VBA‑t.