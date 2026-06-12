---
title: Přístup k snímkům prezentace v C++
linktitle: Přístup k snímku
type: docs
weight: 20
url: /cs/cpp/access-slide-in-presentation/
keywords:
- přístup k snímku
- index snímku
- ID snímku
- pozice snímku
- změna pozice
- vlastnosti snímku
- číslo snímku
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak přistupovat k snímkům a spravovat je v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro C++. Zvyšte produktivitu pomocí ukázek kódu."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přistupovat k snímkům v prezentaci a spravovat je. Ukazuje, jak získat snímky podle jejich nulového indexu ze sbírky snímků a jak přistoupit k snímku pomocí jeho jedinečného ID pomocí metody `GetSlideById`.

Dozvíte se také, jak změnit pozici snímku pomocí metody `set_SlideNumber` a jak definovat počáteční číslo snímku pro prezentaci pomocí metody `set_FirstSlideNumber`. Příklady ukazují načtení prezentace, získání odkazů na snímky, aktualizaci pořadí nebo číslování snímků a uložení upravené prezentace.

## **Přístup k snímku podle indexu**

Všechny snímky v prezentaci jsou uspořádány číselně podle pozice snímku počínaje 0. První snímek je přístupný pomocí indexu 0; druhý snímek je přístupný pomocí indexu 1; atd.

Třída Presentation, která představuje soubor prezentace, zpřístupňuje všechny snímky jako kolekci [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) (kolekci objektů [ISlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/)). Tento kód v C++ ukazuje, jak přistoupit k snímku podle jeho indexu:

```c++
	// Cesta k adresáři dokumentů.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Vytvoří instanci třídy Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Získá odkaz na snímek pomocí jeho indexu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Přístup k snímku podle ID**

Každý snímek v prezentaci má přiřazené jedinečné ID. K cílení na toto ID můžete použít metodu [GetSlideById()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/getslidebyid/) (zpřístupněnou třídou [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/)). Tento kód v C++ ukazuje, jak zadat platné ID snímku a přistoupit k tomuto snímku přes metodu [GetSlideById()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/getslidebyid/):

```c++
	// Cesta k adresáři dokumentů.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Vytváří instanci třídy Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Získá ID snímku
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Přistupuje k snímku pomocí jeho ID
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Změna pozice snímku**

Aspose.Slides vám umožňuje změnit pozici snímku. Například můžete určit, že první snímek se má stát druhým snímkem.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek (kterého pozici chcete změnit) pomocí jeho indexu
1. Nastavte novou pozici snímku pomocí vlastnosti [set_SlideNumber()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/set_slidenumber/).
1. Uložte upravenou prezentaci.

Tento kód v C++ demonstruje operaci, při které je snímek na pozici 1 přesunut na pozici 2:

```c++
	// Cesta k adresáři dokumentů.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Vytváří instanci třídy Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Získá snímek, jehož pozice bude změněna
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Nastaví novou pozici snímku
	slide->set_SlideNumber(2);

	// Uloží upravenou prezentaci
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

První snímek se stal druhým; druhý snímek se stal prvním. Když změníte pozici snímku, ostatní snímky jsou automaticky upraveny.

## **Nastavení čísla snímku**

Pomocí vlastnosti [set_FirstSlideNumber()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/set_firstslidenumber/) (zpřístupněné třídou [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/)) můžete určit nové číslo pro první snímek v prezentaci. Tato operace způsobí přepočet čísel ostatních snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte číslo snímku.
1. Nastavte číslo snímku.
1. Uložte upravenou prezentaci.

Tento kód v C++ demonstruje operaci, při které je číslo prvního snímku nastaveno na 10:

```c++
	// Cesta k adresáři dokumentů.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Instanci třídy Presentation vytvoří
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Získá číslo snímku
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Nastaví číslo snímku
	pres->set_FirstSlideNumber(2);
	
	// Uloží upravenou prezentaci
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Pokud chcete první snímek přeskočit, můžete zahájit číslování od druhého snímku (a skrýt číslování pro první snímek) tímto způsobem:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

//	Nastaví číslo pro první snímek prezentace
presentation->set_FirstSlideNumber(0);

//	Zobrazí čísla snímků pro všechny snímky
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

//	Skryje číslo snímku pro první snímek
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

//	Uloží upravenou prezentaci
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Často kladené dotazy**

**Odpovídá číslo snímku, které uživatel vidí, nulovému indexu ve sbírce?**

Číslo zobrazené na snímku může začínat libovolnou hodnotou (např. 10) a nemusí odpovídat indexu; vztah řídí nastavení [prvního čísla snímku](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/set_firstslidenumber/) v prezentaci.

**Ovlivňují skryté snímky indexování?**

Ano. Skrytý snímek zůstává ve sbírce a je započítán do indexování; „skrytý“ se vztahuje na zobrazování, nikoli na jeho pozici ve sbírce.

**Mění se index snímku, když jsou přidány nebo odebrány jiné snímky?**

Ano. Indexy vždy odrážejí aktuální pořadí snímků a jsou přepočítány při vložení, smazání nebo přesunu.