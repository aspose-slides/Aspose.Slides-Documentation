---
title: Szövegrészek kezelése prezentációkban C++ segítségével
linktitle: Szövegrész
type: docs
weight: 70
url: /hu/cpp/portion/
keywords:
- szövegrész
- szövegrészlet
- szöveg koordináták
- szöveg pozíció
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhet szövegrészeket PowerPoint prezentációkban az Aspose.Slides for C++ segítségével, javítva a teljesítményt és testreszabhatóságot."
---
## **Bevezetés**

A szövegrész egy adott szövegrészletet képvisel egy bekezdésen belül, és lehetővé teszi, hogy a környező tartalomtól függetlenül dolgozzon vele. Az Aspose.Slides‑ban a részeket akkor használhatja, amikor egy szövegrészlet pozícióját szeretné lekérdezni, csak a bekezdés egy részére kíván formázást alkalmazni, vagy részletesebb szintű szövegműködést szeretne vezérelni.

## **A szövegrész koordinátáinak lekérése**
**GetCoordinates()** módszer lett hozzáadva az IPortion és Portion osztályhoz, amely lehetővé teszi a rész elejének koordinátáinak lekérését:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **GYIK**

**Alkalmazhatok hivatkozást csak a szöveg egy részére egyetlen bekezdésen belül?**

Igen, a [hivatkozás hozzárendelése](/slides/hu/cpp/manage-hyperlinks/) egy egyedi részhez lehetséges; csak ez a szövegrész lesz kattintható, nem pedig a teljes bekezdés.

**Hogyan működik a stílusöröklődés: mit felülír a Portion, és mi származik a Paragraph/TextFrame‑ből?**

A Portion‑szintű tulajdonságok a legmagasabb precedenciával rendelkeznek. Ha egy tulajdonság nincs beállítva a [Portion](https://reference.aspose.com/slides/hu/cpp/aspose.slides/portion/), a motor a [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) értékét veszi; ha ott sem, akkor a [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframe/) vagy a [theme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/theme/) stílusából.

**Mi történik, ha egy Portion számára megadott betűtípus hiányzik a célgépen/kiszolgálón?**

[Betűtípus helyettesítési szabályok](/slides/hu/cpp/font-selection-sequence/) érvényesek. A szöveg újraáramlhat: a metrikák, a szóelválasztás és a szélesség változhat, ami fontos a pontos elhelyezéshez.

**Beállíthatok-e egy Portion‑specifikus szövegtöltő átlátszóságot vagy színátmenetet a bekezdés többi részétől függetlenül?**

Igen, a szövegszín, a kitöltés és az átlátszóság a [Portion](https://reference.aspose.com/slides/hu/cpp/aspose.slides/portion/) szintjén eltérhet a szomszédos szövegrészeketől.