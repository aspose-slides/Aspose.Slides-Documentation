---
title: Hello World alkalmazás az Aspose.Slides for C++ használatával
type: docs
weight: 80
url: /hu/cpp/hello-world-application-using-aspose-slides/
keywords:
- helló világ
- alkalmazás
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Készítsd el az első C++ alkalmazásodat az Aspose.Slides segítségével, egy egyszerű Hello World példával, amely felkészít a PPT, PPTX és ODP prezentációk automatizálására."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozható létre egy egyszerű **Hello World** PowerPoint prezentáció az Aspose.Slides használatával. A példa bemutatja, hogyan hozhatunk létre egy új prezentációt, érhetjük el az első diát, adhatunk hozzá egy téglalap AutoShape-et egy megadott pozícióban, illeszthetünk be egy szövegkeretet, amely a **Hello World** szöveget tartalmazza, és módosíthatjuk az alakzat és a szöveg formázását. Az is bemutatja, hogyan tehető láthatóvá a szöveg a szín feketére változtatásával, hogyan rejthető el az alakzat kerete a vonalszín fehérre állításával, hogyan távolítható el az alakzat kitöltése, és hogyan menthető a prezentáció PPTX fájlként.

## **A Hello World alkalmazás létrehozásának lépései**

Kövesse az alábbi lépéseket egy **Hello World** alkalmazás létrehozásához az Aspose.Slides for C++ API használatával:

- Hozzon létre egy példányt a Presentation osztályból
- Szerezze meg az első dia hivatkozását a prezentációban, amely a Presentation példányosításakor jön létre
- Adjon hozzá egy AutoShape-et, ShapeType-ként Rectangle, a dia egy megadott pozíciójába
- Adjon hozzá egy TextFrame-et az AutoShape-hez, amely alapértelmezett szövegként a Hello World-ot tartalmazza
- Módosítsa a szöveg színét feketére, mivel alapértelmezés szerint fehér, és nem látható a fehér háttérrel rendelkező dián
- Állítsa be az alakzat vonalszínét fehérre, hogy elrejtse az alakzat szegélyét
- Távolítsa el az alakzat alapértelmezett kitöltési formátumát
- Végül írja ki a prezentációt a kívánt fájlformátumba a Presentation objektum segítségével

A fenti lépések megvalósítása az alábbi példában van bemutatva.

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // az első dia lekérése
    auto slide = pres->get_Slides()->idx_get(0);

    // adj hozzá egy téglalap típusú AutoShape-et
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // adj egy TextFrame-et a téglalaphoz
    shape->AddTextFrame(u"Hello World");

    // állítsd be a szöveg színét feketére (alapértelmezés szerint fehér)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // állítsd be a téglalap vonalszínét fehérre
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // távolítsd el az alakzat kitöltési formázását
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // mentsd el a prezentációt a lemezen
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```