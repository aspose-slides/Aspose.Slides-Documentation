---
title: Szövegrész határainak lekérése prezentációkból C++-ban
linktitle: Rész határai
type: docs
weight: 47
url: /hu/cpp/portion-bounds/
keywords:
- szövegrész határai
- szövegrész
- szöveg rész
- szöveg koordináták
- szöveg pozíció
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a szövegrész határait PowerPoint prezentációkban az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

A szövegrész egy bekezdésen belüli adott szövegtöredéket képvisel, és lehetővé teszi, hogy ezzel a töredékkel a környező tartalomtól függetlenül dolgozzunk. Az Aspose.Slides-ben a szövegrészek akkor használhatók, amikor meg kell határozni egy szövegtöredék határait, csak a bekezdés egy részére kell formázást alkalmazni, vagy részletesebb szinten kell szabályozni a szöveg viselkedését.

Ez a cikk bemutatja, hogyan lehet lekérni egy szövegrész határoló téglalapját a [IPortion::GetRect](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/getrect/) használatával. Emellett megmutatja, hogyan lehet lekérni egy szövegrész elejének koordinátáit a [IPortion::GetCoordinates](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/getcoordinates/) segítségével. Továbbá kiemeli a szövegrészhez kapcsolódó gyakori helyzeteket, például egy hiperhivatkozás alkalmazását egyetlen szövegtöredékre, a formázás hogyan kerül feloldásra a szövegrész, bekezdés, szövegdoboz és téma öröklődésén keresztül, valamint a megadott betűkészlet hiányának kezelését.

## **A szövegrész határainak lekérése**

A szövegrész határoló téglalapjának lekéréséhez használja a [IPortion::GetRect](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/getrect/) metódust:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **A szövegrész koordinátáinak lekérése**

A szövegrész elejének koordinátáinak lekéréséhez használja a [IPortion::GetCoordinates](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/getcoordinates/) metódust:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **GYIK**

**Alkalmazhatok hiperhivatkozást csak a bekezdésen belüli szöveg egy részére?**

Igen, a [hiperhivatkozás hozzárendelése](/slides/hu/cpp/manage-hyperlinks/) lehetséges egy egyedi szövegrészhez; csak ez a töredék lesz kattintható, nem az egész bekezdés.

**Hogyan működik a stílus öröklődés: mit felülír egy szövegrész, és mi kerül át a bekezdésből vagy szövegdobozból?**

A szövegrész szintű tulajdonságok a legmagasabb precedenciával rendelkeznek. Ha egy tulajdonság nincs beállítva az [IPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/), az Aspose.Slides a [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) értékét veszi át. Ha ott sem van beállítva, akkor az Aspose.Slides a [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) vagy a [theme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/theme/) stílusát használja.

**Mi történik, ha a szövegrészhez megadott betűkészlet hiányzik a célgép vagy szerver gépén?**

[A betűkészlet helyettesítési szabályok](/slides/hu/cpp/font-selection-sequence/) érvényesek. A szöveg átrendeződhet: a metrikák, elválasztás és a szélesség változhat, ami fontos a pontos elhelyezésnél.

**Beállíthatok szövegrész-specifikus kitöltési átlátszóságot vagy színátmenetet a bekezdés többi részétől függetlenül?**

Igen, a szövegszín, a kitöltés és az átlátszóság az [IPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/) szintjén eltérhet a szomszédos töredékektől.