---
title: Změna velikosti tvarů na snímcích prezentace
type: docs
weight: 100
url: /cs/cpp/re-sizing-shapes-on-slide/
keywords:
- změna velikosti tvaru
- úprava velikosti tvaru
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Snadno změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro C++—automatizujte úpravy rozvržení snímků a zvyšte produktivitu."
---
## **Přehled**

Jednou z nejčastějších otázek zákazníků Aspose.Slides pro C++ je, jak změnit velikost tvarů tak, aby při změně velikosti snímku nedošlo k oříznutí dat. Tento stručný technický článek ukazuje, jak to provést.

## **Změna velikosti tvarů**

Cílem je zabránit nesprávnému zarovnání tvarů při změně velikosti snímku; aktualizujte pozici a rozměry každého tvaru tak, aby odpovídaly novému rozvržení snímku.

```cpp
// Načtěte soubor prezentace.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Get the original slide size.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Change the slide size without scaling existing shapes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Get the new slide size.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Resize and reposition shapes on every slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Změňte velikost tvaru.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Změňte pozici tvaru.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}} 
Pokud snímek obsahuje tabulku, výše uvedený kód nebude fungovat správně. V takovém případě je třeba upravit velikost každé buňky v tabulce.
{{% /alert %}} 

Použijte následující kód na své straně pro změnu velikosti snímků, které obsahují tabulky. Pro tabulky je nastavení šířky nebo výšky zvláštní případ: musíte upravit výšky jednotlivých řádků a šířky sloupců, aby se změnila celková velikost tabulky.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Získejte původní velikost snímku.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Změňte velikost snímku bez škálování existujících tvarů.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Získejte novou velikost snímku.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Změňte velikost tvaru.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Změňte pozici tvaru.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Změňte velikost tvaru.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Změňte pozici tvaru.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Změňte velikost tvaru.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Změňte pozici tvaru.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Často kladené otázky**

**Proč jsou tvary po změně velikosti snímku deformovány nebo oříznuty?**

Při změně velikosti snímku si tvary zachovávají původní pozici a velikost, pokud není měřítko výslovně změněno. To může způsobit oříznutí obsahu nebo nesprávné zarovnání tvarů.

**Funguje poskytnutý kód pro všechny typy tvarů?**

Základní příklad funguje pro většinu typů tvarů (textová pole, obrázky, grafy atd.). U tabulek však musíte zpracovávat řádky a sloupce samostatně, protože výška a šířka tabulky jsou určeny rozměry jednotlivých buněk.

**Jak změním velikost tabulek při změně velikosti snímku?**

Musíte projít všechny řádky a sloupce tabulky a změnit jejich výšku a šířku úměrně, jak je ukázáno ve druhém ukázkovém kódu.

**Bude tato změna velikosti fungovat u hlavních snímků a rozvržových snímků?**

Ano, ale měli byste také projít [Masters](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_masters/) a [Layout slides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_layoutslides/) a použít stejnou logiku škálování na jejich tvary, aby byla zajištěna konzistence napříč celou prezentací.

**Mohu změnit orientaci snímku (na výšku/na šířku) spolu se změnou velikosti?**

Ano. K změně orientace můžete použít [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidesize/set_orientation/). Ujistěte se, že podle toho nastavíte logiku škálování, aby byl zachován rozvrh.

**Existuje limit na velikost snímku, kterou mohu nastavit?**

Aspose.Slides podporuje vlastní velikosti, ale velmi velké rozměry mohou ovlivnit výkon nebo kompatibilitu s některými verzemi PowerPointu.

**Jak mohu zabránit deformaci tvarů se zamknutým poměrem stran?**

Můžete před škálováním zkontrolovat metodu `get_AspectRatioLocked` tvaru. Pokud je poměr stran uzamčen, upravte šířku nebo výšku úměrně místo samostatného škálování.