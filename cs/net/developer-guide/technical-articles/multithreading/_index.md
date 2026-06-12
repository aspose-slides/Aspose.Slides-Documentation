---
title: Vícevláknové zpracování v Aspose.Slides pro .NET
linktitle: Vícevláknové
type: docs
weight: 310
url: /cs/net/multithreading/
keywords:
- vícevláknové
- více vláken
- paralelní práce
- převod snímků
- snímky na obrázky
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vícevláknové zpracování v Aspose.Slides pro .NET zrychluje zpracování PowerPointu a OpenDocumentu. Objevte osvědčené postupy pro efektivní pracovní postupy s prezentacemi."
---
## **Úvod**

I když je paralelní práce s prezentacemi možná (kromě parsování/nahrávání/klonování) a většinou vše funguje dobře, existuje malá pravděpodobnost, že při použití knihovny ve více vláknech získáte nesprávné výsledky.

Důrazně doporučujeme, abyste **ne**používali jedinou instanci [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) v prostředí s více vlákny, protože to může vést k nepředvídatelným chybám nebo selháním, která není snadno odhalitelná. 

Není **bezpečné** načítat, ukládat a/nebo klonovat instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) ve více vláknech. Takové operace nejsou **podporovány**. Pokud potřebujete provádět takové úkoly, musíte operace paralelizovat pomocí několika jednovláknových procesů a každý z těchto procesů by měl používat vlastní instanci prezentace. 

## **Konvertovat snímky prezentace na obrázky paralelně**

Řekněme, že chceme všechny snímky z PowerPointové prezentace převést na PNG obrázky paralelně. Protože není bezpečné používat jedinou instanci `Presentation` ve více vláknech, rozdělíme snímky prezentace do samostatných prezentací a převádíme snímky na obrázky paralelně, přičemž každou prezentaci používáme v odděleném vláknu. Následující ukázkový kód ukazuje, jak to provést.

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // Extrahovat snímek i do samostatné prezentace.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Převést snímek na obrázek v samostatném úkolu.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```

## **Často kladené otázky**

**Musím provádět nastavení licence v každém vlákně?**

Ne. Stačí to provést jednou na proces/aplikaci před spuštěním vláken. Pokud by [license setup](/slides/cs/net/licensing/) mohl být vyvolán souběžně (například během líné inicializace), synchronizujte tento volání, protože samotná metoda nastavení licence není vláknově bezpečná.

**Mohu předávat objekty `Presentation` nebo `Slide` mezi vlákny?**

Předávat „živé“ objekty prezentace mezi vlákny se nedoporučuje: používejte nezávislé instance na vlákno nebo předem vytvořte samostatné prezentace/kontejnery snímků pro každé vlákno. Tento přístup vychází z obecného doporučení nesdílet jedinou instanci prezentace mezi vlákny.

**Je bezpečné paralelizovat export do různých formátů (PDF, HTML, obrázky), pokud má každé vlákno vlastní instanci `Presentation`?**

Ano. S nezávislými instancemi a samostatnými výstupními cestami se takové úlohy obvykle paralelizují správně; vyhněte se sdíleným objektům prezentace a sdíleným I/O tokům.

**Co mám dělat s globálními nastaveními fontů (složky, substituce) v multithreadingu?**

Inicializujte všechna globální nastavení fontů před spuštěním vláken a během paralelní práce je neměňte. Tím se eliminují závody při přístupu ke sdíleným zdrojům fontů.