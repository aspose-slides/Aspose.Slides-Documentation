---
title: Vícevláknové zpracování v Aspose.Slides pro Node.js přes Java
linktitle: Vícevláknové zpracování
type: docs
weight: 310
url: /cs/nodejs-java/multithreading/
keywords:
- vícevláknové zpracování
- více vláken
- paralelní práce
- převod snímků
- snímky na obrázky
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vícevláknové zpracování v Aspose.Slides pro Node.js přes Java zvyšuje výkon při zpracování PowerPointu a OpenDocument. Objevte osvědčené postupy pro efektivní pracovní postupy s prezentacemi."
---
## **Úvod**

Ačkoli je možné provádět paralelní práci s prezentacemi (kromě parsování/nahrávání/klonování) a většinou vše funguje správně, existuje malá pravděpodobnost, že při použití knihovny ve více vláknech získáte nesprávné výsledky.

Důrazně doporučujeme **ne** používat jedinou instanci [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) v prostředí s více vlákny, protože to může vést k nepředvídatelným chybám nebo selháním, které není snadné detekovat.

Není **bezpečné** načítat, ukládat a/nebo klonovat instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) ve více vláknech. Takové operace **nejsou** podporovány. Pokud potřebujete provádět takové úkoly, musíte operace paralelizovat pomocí několika jednovláknových procesů – a každý z těchto procesů by měl používat svoji vlastní instanci prezentace.

## **Převod snímků prezentace na obrázky paralelně**

Předpokládejme, že chceme převést všechny snímky z PowerPointové prezentace na PNG obrázky paralelně. Vzhledem k tomu, že není bezpečné používat jedinou instanci `Presentation` ve více vláknech, rozdělíme snímky prezentace do samostatných prezentací a převádíme snímky na obrázky paralelně, přičemž každou prezentaci používáme v samostatném vlákně. Následující ukázkový kód ukazuje, jak to provést.

```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // Extrahujte snímek i do samostatné prezentace.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // Počkejte, až budou všechny úlohy dokončeny.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```

## **FAQ**

**Musím volat nastavení licence v každém vlákně?**

Ne. Stačí to provést jednou na proces/app domain před spuštěním vláken. Pokud by se [nastavení licence](/slides/cs/nodejs-java/licensing/) mohlo volat současně (například během líné inicializace), synchronizujte tento volání, protože samotná metoda nastavení licence není vlákny bezpečná.

**Mohu předávat objekty `Presentation` nebo `Slide` mezi vlákny?**

Předávání „živých“ objektů prezentace mezi vlákny se nedoporučuje: použijte nezávislé instance pro každé vlákno nebo předem vytvořte samostatné prezentace/kontejnery snímků pro každé vlákno. Tento přístup vychází z obecného doporučení nesdílet jedinou instanci prezentace napříč vlákny.

**Je bezpečné paralelizovat export do různých formátů (PDF, HTML, obrázky), pokud má každé vlákno svou vlastní instanci `Presentation`?**

Ano. S nezávislými instancemi a samostatnými výstupními cestami se takové úkoly obvykle paralelizují správně; vyhněte se sdíleným objektům prezentace a sdíleným I/O proudům.

**Co mám dělat s globálním nastavením fontů (složky, substituce) při vícevlákném provozu?**

Inicializujte všechna globální nastavení fontů před spuštěním vláken a během paralelní práce je neměňte. Tím se odstraní závody při přístupu ke sdíleným fontovým zdrojům.