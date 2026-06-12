---
title: Získání celého pozadí snímku z prezentace jako obrázku
linktitle: Celé pozadí snímku
type: docs
weight: 95
url: /cs/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- pozadí snímku
- finální pozadí
- extrahovat pozadí
- celé pozadí
- pozadí na obrázek
- PPT pozadí
- PPTX pozadí
- ODP pozadí
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Extrahovat kompletní pozadí snímků jako obrázky z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro C++, zjednodušující vizuální pracovní procesy."
---
## **Přehled**

V prezentacích PowerPoint může být pozadí snímku vytvořeno z několika elementů, včetně obrázku pozadí snímku, motivu prezentace, schématu barev a objektů umístěných na hlavním snímku nebo snímku rozvržení.

V tomto článku je ukázáno, jak pomocí Aspose.Slides extrahovat celé pozadí snímku jako obrázek. Protože neexistuje jediná metoda pro tento úkol, postup zahrnuje klonování vybraného snímku do dočasné prezentace, odstranění tvarů snímku a následnou konverzi vzniklého pozadí snímku na obrázek.

## **Získání celého pozadí snímku**

Aspose.Slides pro C++ neposkytuje jednoduchou metodu pro extrakci celého pozadí snímku prezentace jako obrázku, ale můžete postupovat podle následujících kroků:
1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte velikost snímku z prezentace.
1. Vyberte snímek.
1. Vytvořte dočasnou prezentaci.
1. Nastavte stejnou velikost snímku v dočasné prezentaci.
1. Klonujte vybraný snímek do dočasné prezentace.
1. Odstraňte tvary z klonovaného snímku.
1. Převeďte klonovaný snímek na obrázek.

Následující ukázka kódu extrahuje celé pozadí snímku prezentace jako obrázek.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```

## **Často kladené otázky**

**Zůstanou složité přechody, textury nebo výplně obrázkem z hlavního snímku zachovány v výsledném obrázku pozadí?**

Ano. Aspose.Slides vykresluje gradientní, obrázkové a texturové výplně definované na snímku, rozvržení nebo hlavním snímku. Pokud potřebujete oddělit vzhled od zděděných hlavních snímků, [nastavte vlastní pozadí](/slides/cs/cpp/presentation-background/) na aktuálním snímku před exportem.

**Mohu přidat vodoznak do výsledného obrázku pozadí před jeho uložením?**

Ano. Můžete [přidat vodoznak](/slides/cs/cpp/watermark/) jako tvar nebo obrázek na pracovní [kopii snímku](/slides/cs/cpp/clone-slides/) (umístěnou za ostatní obsah) a poté exportovat. To vám umožní vygenerovat obrázek pozadí s vodoznakem vloženým přímo do něj.

**Mohu získat pozadí pro konkrétní rozvržení nebo hlavní snímek, aniž by bylo svázáno s existujícím snímkem?**

Ano. Přistupte k požadovanému hlavnímu snímku nebo rozvržení, aplikujte jej na [dočasný snímek](/slides/cs/cpp/clone-slides/) s požadovanou velikostí a exportujte tento snímek, abyste získali pozadí odvozené od daného rozvržení nebo hlavního snímku.

**Existují licenční omezení, která ovlivňují export obrázků?**

Funkce renderování jsou plně k dispozici s [platnou licencí](/slides/cs/cpp/licensing/). V režimu hodnocení může výstup obsahovat omezení, jako je vodoznak. Aktivujte licenci jednou na proces před spuštěním dávkových exportů.