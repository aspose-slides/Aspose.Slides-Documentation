---
title: Textové pole
type: docs
weight: 40
url: /cs/cpp/examples/elements/text-box/
keywords:
- příklad kódu
- textové pole
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Pracujte s textovými poli v Aspose.Slides pro C++: přidávejte, formátujte, zarovnávejte, zalamujte, automaticky přizpůsobujte a stylizujte text pomocí C++ pro prezentace PPT, PPTX a ODP."
---
V Aspose.Slides je **textové pole** reprezentováno pomocí `AutoShape`. Téměř jakýkoli tvar může obsahovat text, ale typické textové pole nemá výplň ani okraj a zobrazuje pouze text.

Tento průvodce vysvětluje, jak programově přidávat, získávat a odebírat textová pole.

## **Přidat textové pole**

Textové pole je jednoduše `AutoShape` bez výplně a okraje a s určitým formátovaným textem. Zde je návod, jak takové pole vytvořit:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Vytvořte obdélníkový tvar (standardně je vyplněný okrajem a bez textu).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Odstraňte výplň a okraj, aby vypadal jako typické textové pole.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Nastavte formátování textu.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Přiřaďte skutečný textový obsah.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Poznámka:** Jakýkoli `AutoShape`, který obsahuje neprázdný `TextFrame`, může fungovat jako textové pole.

## **Přístup k textovým polím podle obsahu**

Chcete‑li najít všechna textová pole obsahující konkrétní klíčové slovo (např. „Slide“), projděte tvary a zkontrolujte jejich text:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // Pouze AutoShapes mohou obsahovat editovatelný text.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // Proveďte něco s odpovídajícím textovým polem.
            }
        }
    }

    presentation->Dispose();
}
```

## **Odstranit textová pole podle obsahu**

Tento příklad najde a odstraní všechna textová pole na první slidu, která obsahují konkrétní klíčové slovo:

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

> 💡 **Tip:** Vždy vytvořte kopii kolekce tvarů před jejím upravováním během iterace, abyste předešli chybám při modifikaci kolekce.