---
title: Hiperhivatkozás
type: docs
weight: 130
url: /hu/cpp/examples/elements/hyperlink/
keywords:
- kódpélda
- hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása és kezelése az Aspose.Slides for C++‑ban: szöveg, alakzatok és képek hivatkozása, célok és műveletek beállítása PPT, PPTX és ODP esetén C++ példákkal."
---
Ez a cikk bemutatja a hiperhivatkozások hozzáadását, elérését, eltávolítását és frissítését alakzatokon a **Aspose.Slides for C++** használatával.

## **Hiperhivatkozás hozzáadása**
Hozzon létre egy téglalap alakzatot, amely egy külső weboldalra mutató hiperhivatkozással rendelkezik.

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **Hiperhivatkozás elérése**
Olvassa el a hiperhivatkozás információit egy alakzat szövegrészéből.

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **Hiperhivatkozás eltávolítása**
Távolítsa el a hiperhivatkozást az alakzat szövegéből.

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **Hiperhivatkozás frissítése**
Módosítsa egy meglévő hiperhivatkozás célját. Használja a `HyperlinkManager`-t a már hiperhivatkozással rendelkező szöveg módosításához, amely a PowerPoint hiperhivatkozások biztonságos frissítését utánzásként valósítja meg.

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // A meglévő szövegben lévő hiperhivatkozás módosítását a következő módon kell végezni:
    // HyperlinkManager használatával, nem pedig közvetlenül a tulajdonság beállításával.
    // Ez a PowerPoint által a hiperhivatkozások biztonságos frissítésének módját utánozza.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```