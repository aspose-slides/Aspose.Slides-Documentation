---
title: Odstranění snímků z prezentací v C++
linktitle: Odstranit snímek
type: docs
weight: 30
url: /cs/cpp/remove-slide-from-presentation/
keywords:
- odstranit snímek
- smazat snímek
- odstranit nepoužívaný snímek
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Jednoduše odstraňujte snímky z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro C++. Získejte přehledné ukázky kódu a zefektivněte svůj pracovní postup."
---
## **Úvod**

Pokud se snímek (nebo jeho obsah) stane nadbytečným, můžete jej smazat. Aspose.Slides poskytuje třídu [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) , která zapouzdřuje [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/), což je úložiště pro všechny snímky v prezentaci. Pomocí ukazatelů (reference nebo indexu) na známý objekt [ISlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/) můžete určit snímek, který chcete odstranit. 

## **Odstranění snímku podle reference**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
1. Získejte referenci na snímek, který chcete odstranit, pomocí jeho ID nebo indexu.
1. Odstraňte referencovaný snímek z prezentace.
1. Uložte upravenou prezentaci. 

Tento C++ kód vám ukazuje, jak odstranit snímek pomocí jeho reference: 

```c++
	// Cesta k adresáři dokumentů
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Vytváří objekt Presentation, který představuje soubor prezentace
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Přistupuje k snímku pomocí jeho indexu v kolekci snímků
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Odstraňuje snímek pomocí jeho reference
	pres->get_Slides()->Remove(slide);

	// Ukládá upravenou prezentaci
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Odstranění snímku podle indexu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
1. Odstraňte snímek z prezentace pomocí jeho pozice v indexu.
1. Uložte upravenou prezentaci. 

Tento C++ kód vám ukazuje, jak odstranit snímek pomocí jeho indexu: 

```c++
	// Cesta k adresáři dokumentů
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Vytváří objekt Presentation, který představuje soubor prezentace
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Odstraňuje snímek pomocí jeho indexu
	pres->get_Slides()->RemoveAt(0);

	// Ukládá upravenou prezentaci
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Odstranění nepoužívaných rozložení snímků**

Aspose.Slides poskytuje metodu [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (z třídy [Compress](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/)), která vám umožní smazat nežádoucí a nepoužívaná rozložení snímků. Tento C++ kód vám ukazuje, jak odstranit rozložení snímku z PowerPoint prezentace:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Odstranění nepoužívaných hlavních snímků**

Aspose.Slides poskytuje metodu [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (z třídy [Compress](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/)), která vám umožní smazat nežádoucí a nepoužívané hlavní snímky. Tento C++ kód vám ukazuje, jak odstranit hlavní snímek z PowerPoint prezentace:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Co se stane s indexy snímků po smazání snímku?**

Po smazání se [kolekce](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidecollection/) přepočítá: každý následující snímek se posune o jednu pozici doleva, takže předchozí čísla indexů jsou neplatná. Pokud potřebujete stabilní odkaz, použijte trvalé ID každého snímku místo jeho indexu.

**Je ID snímku odlišné od jeho indexu a mění se, když jsou smazány sousední snímky?**

Ano. Index je pozice snímku a změní se, když jsou snímky přidány nebo odebrány. ID snímku je trvalý identifikátor a nemění se, když jsou ostatní snímky smazány.

**Jak smazání snímku ovlivní sekce snímků?**

Pokud snímek patřil do sekce, tato sekce bude mít o jeden snímek méně. Struktura sekcí zůstane; pokud sekce zůstane prázdná, můžete [odstranit nebo reorganizovat sekce](/slides/cs/cpp/slide-section/) podle potřeby.

**Co se stane s poznámkami a komentáři připojenými ke snímku, když je smazán?**

[Notes](/slides/cs/cpp/presentation-notes/) a [comments](/slides/cs/cpp/presentation-comments/) jsou navázány na konkrétní snímek a jsou s ním odstraněny. Obsah na ostatních snímcích zůstává nedotčen.

**Jak se liší mazání snímků od čištění nepoužívaných rozložení/mistrů?**

Mazání odstraňuje konkrétní běžné snímky z prezentace. Čištění nepoužívaných rozložení/mistrů odstraňuje rozložení nebo hlavní snímky, na které se nic nedodává, čímž snižuje velikost souboru, aniž by měnilo obsah zbývajících snímků. Tyto akce jsou doplňkové: obvykle se nejprve maže, poté se čistí.