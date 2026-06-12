---
title: Získání celého pozadí snímku z prezentace jako obrázek
linktitle: Celé pozadí snímku
type: docs
weight: 95
url: /cs/net/get-the-entire-presentation-slide-background-as-an-image/
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
- .NET
- C#
- Aspose.Slides
description: "Extrahujte kompletní pozadí snímků jako obrázky z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET, což zjednodušuje vizuální pracovní postupy."
---
## **Přehled**

V prezentacích PowerPoint může pozadí snímku být tvořeno z několika prvků, včetně obrázku pozadí snímku, motivu prezentace, barevného schématu a objektů umístěných na hlavním snímku nebo snímku rozvržení.

V tomto článku je ukázáno, jak pomocí Aspose.Slides pro .NET extrahovat celé pozadí snímku jako obrázek. Protože neexistuje jediné metoda pro tento úkol, postup zahrnuje klonování vybraného snímku do dočasné prezentace, odstranění tvarů snímku a následnou konverzi výsledného pozadí snímku na obrázek.

## **Získání celého pozadí snímku**

Aspose.Slides pro .NET neposkytuje jednoduchou metodu pro extrakci celého pozadí snímku prezentace jako obrázku, ale můžete postupovat podle následujících kroků:
1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte velikost snímku z prezentace.
1. Vyberte snímek.
1. Vytvořte dočasnou prezentaci.
1. Nastavte stejnou velikost snímku v dočasné prezentaci.
1. Zklonujte vybraný snímek do dočasné prezentace.
1. Odstraňte tvary ze zklonovaného snímku.
1. Převeďte zklonovaný snímek na obrázek.

Následující ukázkový kód extrahuje celé pozadí snímku prezentace jako obrázek.
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```

## **Často kladené otázky**

**Zachovají se složité přechody, textury nebo výplně obrázky z hlavního snímku v výsledném obrázku pozadí?**

Ano. Aspose.Slides vykresluje výplně gradientů, obrázků a textur definované na snímku, rozvržení nebo hlavním snímku. Pokud potřebujete oddělit vzhled od zděděných hlavních snímků, [nastavte vlastní pozadí](/slides/cs/net/presentation-background/) na aktuálním snímku před exportem.

**Mohu přidat vodoznak do výsledného obrázku pozadí před jeho uložením?**

Ano. Můžete [přidat vodoznak](/slides/cs/net/watermark/) jako tvar nebo obrázek na pracovní [kopii snímku](/slides/cs/net/clone-slides/) (umístěnou za ostatní obsah) a poté exportovat. To vám umožní vytvořit obrázek pozadí s vodoznakem vloženým přímo do něj.

**Mohu získat pozadí pro konkrétní rozvržení nebo hlavní snímek, aniž bych jej svazoval s existujícím snímkem?**

Ano. Přistupte k požadovanému hlavnímu snímku nebo rozvržení, aplikujte jej na [dočasný snímek](/slides/cs/net/clone-slides/) s požadovanou velikostí a exportujte tento snímek, abyste získali pozadí odvozené z toho rozvržení nebo hlavního snímku.

**Existují omezení licence, která ovlivňují export obrázků?**

Vykreslovací funkce jsou plně k dispozici s [platnou licencí](/slides/cs/net/licensing/). V režimu hodnocení může výstup obsahovat omezení, jako je vodoznak. Aktivujte licenci jednou na proces před spuštěním hromadných exportů.