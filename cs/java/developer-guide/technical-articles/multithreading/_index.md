---
title: Vícevláknové zpracování v Aspose.Slides pro Java
linktitle: Vícevláknové
type: docs
weight: 310
url: /cs/java/multithreading/
keywords:
- vícevláknové
- více vláken
- paralelní práce
- převod snímků
- snímky na obrázky
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Vícevláknové zpracování v Aspose.Slides pro Java zrychluje zpracování PowerPoint a OpenDocument. Objevte osvědčené postupy pro efektivní pracovní postupy s prezentacemi."
---
## **Úvod**

Zatímco paralelní práce s prezentacemi je možná (kromě parsování/načítání/klonování) a většinou vše funguje správně, existuje malá šance, že získáte nesprávné výsledky při použití knihovny ve více vláknech.

Doporučujeme důrazně, abyste **ne**používali jedinou [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) instanci v prostředí s více vlákny, protože to může vést k nepředvídatelným chybám nebo selháním, která není snadné detekovat.

Není **bezpečné** načítat, ukládat a/nebo klonovat instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) ve více vláknech. Takové operace **nejsou** podporovány. Pokud potřebujete provádět takové úkoly, musíte operace paralelizovat pomocí několika jednovlákých procesů – a každý z těchto procesů by měl používat vlastní instanci prezentace.

## **Převod snímků prezentace na obrázky paralelně**

Předpokládejme, že chceme převést všechny snímky PowerPoint prezentace na PNG obrázky paralelně. Protože je nebezpečné používat jednu instanci `Presentation` ve více vláknech, rozdělíme snímky do samostatných prezentací a převádíme snímky na obrázky paralelně, přičemž každou prezentaci používáme v samostatném vlákně. Následující ukázkový kód ukazuje, jak to provést.

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Extrahujte snímek i do samostatné prezentace.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // Převěďte snímek na obrázek v samostatném úkolu.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// Počkejte, až všechny úkoly dokončí.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **Často kladené otázky**

**Musím volat nastavení licence v každém vlákně?**

Ne. Stačí to provést jednou na proces/aplikaci před spuštěním vláken. Pokud může být [nastavení licence](/slides/cs/java/licensing/) vyvoláno současně (například během líné inicializace), synchronizujte tento volání, protože samotná metoda nastavení licence není vlákny bezpečná.

**Mohu předávat objekty `Presentation` nebo `Slide` mezi vlákny?**

Předávání „živých“ objektů prezentace mezi vlákny se nedoporučuje: použijte nezávislé instance na vlákno nebo předem vytvořte samostatné prezentace/kontejnery snímků pro každé vlákno. Tento přístup vychází z obecného doporučení nesdílet jedinou instanci prezentace napříč vlákny.

**Je bezpečné paralelizovat export do různých formátů (PDF, HTML, obrázky), pokud má každé vlákno vlastní instanci `Presentation`?**

Ano. S nezávislými instancemi a samostatnými výstupními cestami se takové úkoly obvykle paralelizují správně; vyhněte se sdíleným objektům prezentace a sdíleným I/O proudům.

**Co mám dělat s globálním nastavením fontů (složky, substituce) v multithreadingu?**

Inicializujte všechna globální [nastavení fontů](/slides/cs/java/powerpoint-fonts/) před spuštěním vláken a během paralelní práce je neměňte. Tím se odstraní závody při přístupu ke sdíleným zdrojům fontů.