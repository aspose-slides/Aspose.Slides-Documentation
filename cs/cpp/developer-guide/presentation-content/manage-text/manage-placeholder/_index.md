---
title: "Správa zástupných prvků prezentace v C++"
linktitle: "Spravovat zástupné prvky"
type: docs
weight: 10
url: /cs/cpp/manage-placeholder/
keywords:
  - zástupný prvek
  - textový zástupný prvek
  - obrázkový zástupný prvek
  - grafový zástupný prvek
  - výzva text
  - PowerPoint
  - OpenDocument
  - prezentace
  - C++
  - Aspose.Slides
description: "Jednoduše spravujte zástupné prvky v Aspose.Slides pro C++: nahrazujte text, přizpůsobujte výzvy a nastavujte průhlednost obrázků v PowerPoint a OpenDocument."
---
## **Přehled**

Aspose.Slides vám umožňuje programově spravovat zástupné prvky prezentace. Tento článek vysvětluje, jak najít zástupné prvky na snímcích a změnit jejich text, nastavit vlastní výzvu pro rozvržení zástupných prvků a upravit průhlednost obrázku použitého jako pozadí zástupného prvku. Obsahuje také krátkou sekci FAQ, která objasňuje rozdíl mezi základními zástupnými prvky a místními tvary, vysvětluje, jak lze změny zástupných prvků aplikovat prostřednictvím rozvržení nebo hlavních šablon, a odkazuje na správu zástupných prvků záhlaví a zápatí.

## **Změna textu ve zástupném prvku**
Pomocí [Aspose.Slides for C++](/slides/cs/cpp/) můžete najít a upravit zástupné prvky na snímcích v prezentacích. Aspose.Slides vám umožňuje provádět změny textu ve zástupném prvku.

**Požadavek**: Potřebujete prezentaci, která obsahuje zástupný prvek. Takovou prezentaci můžete vytvořit v běžné aplikaci Microsoft PowerPoint.

Takto použijete Aspose.Slides k nahrazení textu ve zástupném prvku v této prezentaci:

1. Vytvořte instanci třídy [`Presentation`](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation/) a jako argument předávejte prezentaci.
2. Získejte referenci na snímek přes jeho index.
3. Procházejte tvary a najděte zástupný prvek.
4. Přetypujte tvar zástupného prvku na [`AutoShape`](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.auto_shape/) a změňte text pomocí [`TextFrame`](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.text_frame/) spojeného s [`AutoShape`](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.auto_shape/).
5. Uložte upravenou prezentaci.

Tento C++ kód ukazuje, jak změnit text ve zástupném prvku:

```c++
// Cesta do adresáře dokumentů.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Načte požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Získá první snímek
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Získá první a druhý zástupný prvek ve snímku a přetypuje jej na AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// Uloží prezentaci na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Nastavení textu výzvy ve zástupném prvku**
Standardní a předpřipravená rozvržení obsahují výzvy, jako je ***Click to add a title*** nebo ***Click to add a subtitle***. Pomocí Aspose.Slides můžete do rozvržení zástupných prvků vložit své vlastní výzvy.

Tento C++ kód vám ukazuje, jak nastavit text výzvy ve zástupném prvku:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Když v něm není žádný text, PowerPoint zobrazí "Click to add title". 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Dělá to samé pro podtitul.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Nastavení průhlednosti obrázku ve zástupném prvku**

Aspose.Slides vám umožňuje nastavit průhlednost obrázku na pozadí textového zástupného prvku. Úpravou průhlednosti obrázku v takovém rámci můžete zvýraznit text nebo obrázek (v závislosti na barvách textu a obrázku).

Tento C++ kód ukazuje, jak nastavit průhlednost pozadí obrázku (uvnitř tvaru):

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

**Co je základní zástupný prvek a jak se liší od místního tvaru na snímku?**

Základní zástupný prvek je původní tvar v rozvržení nebo hlavní šabloně, ze kterého dědí tvar snímku – typ, umístění a část formátování pochází z něj. Místní tvar je nezávislý; pokud neexistuje žádný základní zástupný prvek, dědičnost se nepoužije.

**Jak mohu aktualizovat všechny nadpisy nebo popisky v celé prezentaci, aniž bych procházel každý snímek?**

Upravte odpovídající zástupný prvek v rozvržení nebo v hlavní šabloně. Snímky založené na těchto rozvrženích/této hlavní šabloně automaticky dědí změnu.

**Jak mohu ovládat standardní zástupné prvky záhlaví/zápatí – datum a čas, číslo snímku a text zápatí?**

Použijte správce HeaderFooter v příslušném rozsahu (normální snímky, rozvržení, hlavní šablona, poznámky/rozptýlené listy) k zapnutí nebo vypnutí těchto zástupných prvků a k nastavení jejich obsahu.