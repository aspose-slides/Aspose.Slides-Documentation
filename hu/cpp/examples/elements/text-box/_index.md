---
title: Szövegdoboz
type: docs
weight: 40
url: /hu/cpp/examples/elements/text-box/
keywords:
- kódrészlet
- szövegdoboz
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Szövegdobozok kezelése az Aspose.Slides for C++‑ban: szöveg hozzáadása, formázása, igazítása, tördelése, automatikus méretezése és stílusozása C++‑ban PPT, PPTX és ODP prezentációkhoz."
---
Az Aspose.Slides‑ben egy **szövegdoboz** egy `AutoShape`‑ként van ábrázolva. Szinte minden alakzat tartalmazhat szöveget, de egy tipikus szövegdoboznak nincs kitöltése vagy kerete, és csak a szöveget jeleníti meg.

Ez az útmutató bemutatja, hogyan lehet programozottan hozzáadni, elérni és eltávolítani a szövegdobozokat.

## **Szövegdoboz hozzáadása**

A szövegdoboz egyszerűen egy `AutoShape`, amelynek nincs kitöltése vagy kerete, és formázott szöveget tartalmaz. Íme, hogyan hozhatja létre egyet:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Hozzon létre egy téglalap alakzatot (alapértelmezés szerint kitöltött, szegéllyel és szöveg nélkül).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Távolítsa el a kitöltést és a szegélyt, hogy egy tipikus szövegdoboznak nézzen ki.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Állítsa be a szövegformázást.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Rendelje hozzá a valós szövegtartalmat.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Megjegyzés:** Bármely `AutoShape`, amely nem üres `TextFrame`‑et tartalmaz, működhet szövegdobozként.

## **Szövegdobozok elérése tartalom alapján**

Az összes olyan szövegdoboz megtalálásához, amely egy adott kulcsszót tartalmaz (pl. „Slide”), iteráljon az alakzatokon, és ellenőrizze a szövegüket:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // Csak az AutoShape-ek tartalmazhatnak szerkeszthető szöveget.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // Tegyen valamit a megfelelő szövegdobozzal.
            }
        }
    }

    presentation->Dispose();
}
```

## **Szövegdobozok eltávolítása tartalom alapján**

Ez a példa megkeresi és törli az első dián lévő összes szövegdobozt, amely egy adott kulcsszót tartalmaz:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **Tipp:** Mindig készítsen másolatot az alakzatgyűjteményről, mielőtt módosítaná azt iteráció közben, hogy elkerülje a gyűjtemény módosításával kapcsolatos hibákat.