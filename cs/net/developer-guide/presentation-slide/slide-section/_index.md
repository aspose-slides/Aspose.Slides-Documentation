---
title: Správa sekcí snímků v prezentacích v .NET
linktitle: Sekce snímků
type: docs
weight: 100
url: /cs/net/slide-section/
keywords:
- vytvořit sekci
- přidat sekci
- upravit sekci
- změnit sekci
- název sekce
- získat snímky sekce
- zpracovat snímky sekce
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spravujte sekce snímků pomocí Aspose.Slides pro .NET: vytvářejte, přejmenovávejte, měňte pořadí, získávejte a zpracovávejte snímky sekcí v PPTX prezentacích."
---
## **Úvod**

Sekce organizují po sobě jdoucí snímky do pojmenovaných skupin, aniž by měnily obsah snímku. S Aspose.Slides pro .NET můžete vytvářet, měnit pořadí, přejmenovávat, prohlížet a odstraňovat sekce prostřednictvím vlastnosti [Presentation.Sections](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/sections/) .

Sekce jsou zvláště užitečné, když:

- velká prezentace musí být rozdělena do logických témat nebo kapitol;
- různé skupiny snímků jsou přiděleny různým spolupracovníkům;
- snímky je potřeba zpracovávat, přesouvat nebo slučovat jako skupiny.

Zvolte stručné názvy sekcí, které popisují účel seskupených snímků. Protože sekce jsou součástí struktury prezentace, použijte API sekcí k určení příslušnosti místo odvozování z pozic snímků.

## **Vytváření a správa sekcí**

K vytvoření sekce zadejte její název a úvodní snímek pomocí [ISectionCollection.AddSection](https://reference.aspose.com/slides/cs/net/aspose.slides/sectioncollection/addsection/) . Aspose.Slides určuje, které snímky patří do sekce, z aktuální struktury sekcí prezentace.

Stejné rozhraní [ISectionCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/isectioncollection/) vám také umožňuje:

- přesunout sekci spolu s jejími snímky pomocí [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/sectioncollection/reordersectionwithslides/) ;
- odstranit pouze definici sekce pomocí [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/cs/net/aspose.slides/sectioncollection/removesection/) , což zachová její snímky;
- odstranit sekci i s jejími snímky pomocí [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/cs/net/aspose.slides/sectioncollection/removesectionwithslides/) ;
- přidat prázdnou sekci na konec pomocí [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/cs/net/aspose.slides/sectioncollection/appendemptysection/) .

Následující příklad vytvoří dvě sekce, přesune jednu z nich, odstraní ji spolu se snímky a přidá prázdnou sekci:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

Po těchto operacích prezentace obsahuje sekci `Introduction` s jejími snímky a prázdnou sekci `Appendix`. Sekce `Results` a její snímky byly odstraněny.

## **Přejmenování sekcí**

Pro přejmenování sekce nastavte její vlastnost [ISection.Name](https://reference.aspose.com/slides/cs/net/aspose.slides/isection/name/) . Snímky a pozice sekce zůstávají nezměněny.

Následující příklad vytvoří sekci a změní její název:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **Získání snímků ze sekcí**

Vlastnost [Presentation.Sections](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/sections/) vrací [ISectionCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/isectioncollection/) , kterou můžete iterovat. Pro každou [ISection](https://reference.aspose.com/slides/cs/net/aspose.slides/isection/) zavolejte [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/cs/net/aspose.slides/isection/getslideslistofsection/) a získáte snímky, které v ní momentálně patří. Metoda vrací [ISectionSlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/isectionslidecollection/) , která poskytuje počet, indexovaný přístup a enumeraci.

Následující příklad vytvoří dvě naplněné sekce a jednu prázdnou, poté vytiskne pro každou sekci [název](https://reference.aspose.com/slides/cs/net/aspose.slides/isection/name/), [identifikátor](https://reference.aspose.com/slides/cs/net/aspose.slides/isection/sectionid/), [úvodní snímek](https://reference.aspose.com/slides/cs/net/aspose.slides/isection/startedfromslide/), počet snímků a čísla snímků. Používá indexér kolekce k načtení prvního snímku a `foreach` k zpracování všech snímků. Pro prázdnou sekci vrácená kolekce má počet nula, indexér není použit a enumerace neprovádí žádné iterace.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

Členství v sekci je určeno strukturou sekcí prezentace. Nepočítejte rozsah sekce ručně z [ISection.StartedFromSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/isection/startedfromslide/), indexů snímků a úvodního snímku následující sekce.

Strukturální úpravy mohou měnit jak snímky vrácené pro sekci, tak i jejich čísla. To zahrnuje změnu pořadí snímků, klonování snímku do sekce, přesunutí sekce spolu s jejími snímky, odstraňování snímků a odstraňování sekcí. Další příklad volá [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/cs/net/aspose.slides/isection/getslideslistofsection/) po každé takové změně místo toho, aby předpokládal dřívější hranice sekce.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

Volajte [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/cs/net/aspose.slides/isection/getslideslistofsection/) znovu kdykoli jsou snímky nebo sekce přeuspořádány, klonovány, přesouvány nebo odstraňovány. Tím zajistíte, že následné zpracování bude odpovídat aktuální struktuře prezentace.

Formát PPT (PowerPoint 97–2003) neuchovává metadata sekcí. Použijte tento postup s formátem, který sekce podporuje, například PPTX; konverze do PPT odstraní strukturu sekcí potřebnou pro pozdější enumeraci.

## **Časté dotazy**

**Zůstávají sekce zachovány při ukládání do formátu PPT (PowerPoint 97–2003)?**

Ne. Formát PPT nepodporuje metadata sekcí, takže při ukládání do .ppt je seskupení sekcí ztraceno.

**Může být celá sekce „skryta“?**

Ne. Sekce nemá stav viditelnosti. Chcete‑li skrýt její obsah, nastavte vlastnost [ISlide.Hidden](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/hidden/) pro každý snímek v sekci.

**Jak mohu najít sekci, která obsahuje konkrétní snímek?**

Projděte [Presentation.Sections](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/sections/), pro každou sekci zavolejte [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/cs/net/aspose.slides/isection/getslideslistofsection/) a porovnejte vrácené snímky s cílovým snímkem. Pro ne‑prázdnou sekci [ISection.StartedFromSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/isection/startedfromslide/) vrací její první snímek; pro prázdnou sekci vrací `null`.