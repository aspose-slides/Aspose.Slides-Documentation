---
title: Mesterdia
type: docs
weight: 30
url: /hu/cpp/examples/elements/master-slide/
keywords:
- kód példa
- mesterdia
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for C++ mesterdia példákat: hozzon létre, szerkesszen és formázza a mestereket, helyőrzőket és sablonokat PPT, PPTX és ODP formátumokban világos C++ kóddal."
---
A mesterdiák a diaöröklési hierarchia legfelső szintjét alkotják a PowerPointban. Egy **mesterdia** közös tervezési elemeket definiál, például háttérképeket, logókat és szövegformázást. A **layout diák** a mesterdiókból öröklődnek, és a **normál diák** a layout diákból öröklődnek.

Ez a cikk bemutatja, hogyan hozhatók létre, módosíthatók és kezelhetők a mesterdiák az Aspose.Slides for C++ segítségével.

## **Mesterdia hozzáadása**

Ez a példa bemutatja, hogyan hozhatunk létre egy új mesterdát az alapértelmezett klónozásával. Ezután egy vállalati név bannerét adja hozzá az összes diához a layout öröklésén keresztül.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Az alapértelmezett mesterdia klónozása.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Céges név banner hozzáadása a mesterdia tetejéhez.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Az új mesterdia hozzárendelése egy layout diához.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // A layout dia hozzárendelése a prezentáció első diájához.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Note 1:** A mesterdiák lehetővé teszi a konzisztens márkázás vagy közös tervezési elemek alkalmazását az összes dián. A mesterben végzett módosítások automatikusan tükröződnek a függő layout és normál diákon.  
> 
> 💡 **Note 2:** A mesterdiára hozzáadott formák vagy formázások öröklődnek a layout diákra, és továbbá az azokhoz a layouthoz tartozó összes normál diára.  
> 
> Az alábbi kép szemlélteti, hogyan jelenik meg automatikusan egy mesterdiára felvett szövegdoboz a végső dián.

![Mester öröklődés példája](master-slide-banner.png)

## **Mesterdia elérése**

A mesterdiákhoz a prezentáció mestergyűjteményén keresztül férhet hozzá. Íme, hogyan kérdezheti le és dolgozhat velük:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // A háttér típusának megváltoztatása.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Mesterdia eltávolítása**

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Mesterdia eltávolítása index alapján.
    presentation->get_Masters()->RemoveAt(0);

    // Mesterdia eltávolítása hivatkozás alapján.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Nem használt mesterdiák eltávolítása**

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Az összes nem használt mesterdia eltávolítása (még a Preserve-nek jelölteket is).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```