---
title: "Vícevláknové zpracování v Aspose.Slides pro Android pomocí Javy"
linktitle: "Vícevláknové"
type: docs
weight: 310
url: /cs/androidjava/multithreading/
keywords:
- "vícevláknové"
- "více vláken"
- "paralelní práce"
- "převod snímků"
- "snímky na obrázky"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Vícevláknové zpracování Aspose.Slides pro Android pomocí Javy urychluje zpracování PowerPointu a OpenDocumentu. Objevte osvědčené postupy pro efektivní workflow prezentací."
---
## **Úvod**

I když je paralelní práce s prezentacemi možná (kromě parsování/nahrávání/klonování) a většinou vše funguje (většinou), existuje malé riziko, že při použití knihovny ve více vláknech získáte nesprávné výsledky.

Důrazně doporučujeme **ne** používat jedinou instanci [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) v multithreadovém prostředí, protože může vést k nepředvídatelným chybám nebo selháním, které nejsou snadno detekovatelné.

Není **bezpečné** načítat, ukládat a/nebo klonovat instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) ve více vláknech. Takové operace **nejsou** podporovány. Pokud potřebujete tyto úkoly provést, musíte operace paralelizovat pomocí několika jednovlákných procesů – a každý z těchto procesů by měl používat vlastní instanci prezentace.

## **Převod snímků prezentace na obrázky paralelně**

Řekněme, že chceme převést všechny snímky z PowerPointové prezentace na PNG obrázky paralelně. Protože není bezpečné používat jedinou instanci `Presentation` ve více vláknech, rozdělíme snímky prezentace do samostatných prezentací a převádíme snímky na obrázky paralelně, přičemž každou prezentaci použijeme v samostatném vláknu. Následující ukázkový kód ukazuje, jak to provést.

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// Extrahovat snímek i do samostatné prezentace.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Převeďte snímek na obrázek v samostatném úkolu.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
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
		}
	}));
}

// Počkejte na dokončení všech úkolů.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **Často kladené otázky**

**Musím volat licenční nastavení v každém vláknu?**

Ne. Stačí to provést jednou na proces/aplikaci domény před spuštěním vláken. Pokud by se [licenční nastavení](/slides/cs/androidjava/licensing/) mohl volat souběžně (například během líné inicializace), synchronizujte tento hovor, protože metoda nastavení licence sama o sobě není thread‑safe.

**Mohu předávat objekty `Presentation` nebo `Slide` mezi vlákny?**

Přenos „živých“ objektů prezentace mezi vlákny se nedoporučuje: použijte nezávislé instance pro každé vlákno nebo předem vytvořte samostatné prezentace/kontajnery snímků pro každé vlákno. Tento přístup vychází z obecného doporučení nesdílet jedinou instanci prezentace napříč vlákny.

**Je bezpečné paralelizovat export do různých formátů (PDF, HTML, obrázky), pokud má každé vlákno vlastní instanci `Presentation`?**

Ano. S nezávislými instancemi a samostatnými výstupními cestami se takové úkoly obvykle paralelizují správně; vyhněte se sdíleným objektům prezentace a sdíleným I/O proudům.

**Co mám dělat s globálními nastaveními fontů (složky, substituce) v multithreadingu?**

Inicializujte všechna globální [nastavení fontů](/slides/cs/androidjava/powerpoint-fonts/) před spuštěním vláken a během paralelní práce je neměňte. Tím se odstraní závody při přístupu ke sdíleným fontovým zdrojům.