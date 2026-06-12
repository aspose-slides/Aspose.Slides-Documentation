---
title: Vícevláknové zpracování v Aspose.Slides pro C++
linktitle: Vícevláknové
type: docs
weight: 200
url: /cs/cpp/multithreading/
keywords:
- vícevláknové zpracování
- více vláken
- paralelní zpracování
- převod snímků
- snímky na obrázky
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Vícevláknové zpracování v Aspose.Slides pro C++ zrychluje zpracování PowerPointu a OpenDocumentu. Objevte osvědčené postupy pro efektivní pracovní postupy s prezentacemi."
---
## **Úvod**

I když je paralelní práce s prezentacemi možná (kromě parsování/nahrávání/klonování) a většinou vše funguje dobře, existuje malá šance, že získáte nesprávné výsledky při používání knihovny ve více vláknech.

Důrazně doporučujeme **ne**používat jedinou [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) instanci v prostředí s více vlákny, protože to může vést k nepředvídatelným chybám nebo selháním, která nejsou snadno zjistitelná.

Není **bezpečné** načítat, ukládat a/nebo klonovat instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) ve více vláknech. Takové operace nejsou **podporovány**. Pokud potřebujete provést takové úkoly, musíte operace paralelizovat pomocí několika jednovláknových procesů a každý z těchto procesů by měl používat vlastní instanci prezentace.

## **Převod snímků prezentace na obrázky paralelně**

Řekněme, že chceme převést všechny snímky z PowerPointové prezentace na PNG obrázky paralelně. Protože je nebezpečné používat jedinou instanci `Presentation` ve více vláknech, rozdělíme snímky prezentace do samostatných prezentací a převedeme je na obrázky paralelně, přičemž každou prezentaci použijeme v samostatném vláknu. Následující ukázkový kód ukazuje, jak to provést.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Extrahovat snímek i do samostatné prezentace.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Převést snímek na obrázek v samostatném úkolu.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// Počkat, až všechny úkoly dokončí.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **Často kladené otázky**

**Musím volat nastavení licence v každém vlákně?**

Ne. Stačí to provést jednou na proces/aplikaci před spuštěním vláken. Pokud může být [license setup](/slides/cs/cpp/licensing/) voláno souběžně (například během líné inicializace), synchronizujte toto volání, protože metoda nastavení licence samotná není thread‑safe.

**Mohu předávat objekty `Presentation` nebo `Slide` mezi vlákny?**

Předávat „živé“ objekty prezentace mezi vlákny se nedoporučuje: použijte nezávislé instance pro každé vlákno nebo předem vytvořte samostatné prezentace/kontejnery snímků pro každé vlákno. Tento přístup odpovídá obecné doporučení nesdílet jedinou instanci prezentace napříč vlákny.

**Je bezpečné paralelizovat export do různých formátů (PDF, HTML, obrázky), pokud má každé vlákno svou vlastní instanci `Presentation`?**

Ano. Při použití nezávislých instancí a samostatných výstupních cest se tyto úkoly obvykle paralelizují správně; vyhněte se sdíleným objektům prezentace a sdíleným I/O tokům.

**Co mám dělat s globálními nastaveními fontů (složky, substituce) při vícevláknovém zpracování?**

Inicializujte všechna globální nastavení fontů před spuštěním vláken a během paralelní práce je neměňte. Tím se eliminují závody při přístupu ke sdíleným fontovým zdrojům.