---
title: Prezentációk fejléceinek és lábléceinek kezelése C++-ban
linktitle: Fejléc és lábléc
type: docs
weight: 140
url: /hu/cpp/presentation-header-and-footer/
keywords:
- fejléc
- fejléc szöveg
- lábléc
- lábléc szöveg
- fejléc beállítása
- lábléc beállítása
- kézikönyv
- jegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Az Aspose.Slides for C++ segítségével fejléceket és lábléceket adhat hozzá és testreszabhat PowerPoint és OpenDocument prezentációkban, hogy professzionális megjelenést érjen el."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi a fejléc és lábléc beállítások kezelését PowerPoint‑prezentációkban. A fejlécek és láblécek a prezentáció mester szintjén kezelhetők, és az API olyan metódusokat biztosít, amelyekkel beállítható a lábléc szövege, módosítható a lábléc láthatósága, és frissíthető a fejléc szövege a mester jegyzetdiaihoz.

A fejlécek és láblécek kezelhetők kézikönyvi és jegyzetdiák esetén is. Ez magában foglalja a fejléc, lábléc, dia szám és dátum‑idő helyőrzőinek láthatóságának és szövegének módosítását a jegyzet mester, az összes gyermek jegyzetdia vagy egy adott jegyzetdia esetén.

## **Fejléc és lábléc szöveg kezelése**

Egyes diák jegyzetei frissíthetők az alábbi példában látható módon:

``` cpp
// Függvény a fejléc/lábléc szövegének beállításához
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// Betölti a prezentációt
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Lábléc beállítása
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Fejléc elérése és frissítése
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Prezentáció mentése
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **Fejlécek és láblécek kezelése a kézikönyvi és jegyzetdiákon**
Aspose.Slides for C++ támogatja a fejlécet és láblécet a kézikönyvi és jegyzetdiákon. Kövesse az alábbi lépéseket:

- Töltsön be egy [Presentation ](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation)videót tartalmazó prezentációt.
- Módosítsa a fejléc és lábléc beállításait a jegyzet mester és az összes jegyzet dia esetén.
- Állítsa a mester jegyzetdiát és az összes gyermek lábléc helyőrzőt láthatóvá.
- Állítsa a mester jegyzetdiát és az összes gyermek dátum‑ és idő helyőrzőt láthatóvá.
- Módosítsa a fejléc és lábléc beállításait csak az első jegyzetdián.
- Állítsa a jegyzetdia fejléc helyőrzőt láthatóvá.
- Állítsa be a szöveget a jegyzetdia fejléc helyőrzőjébe.
- Állítsa be a szöveget a jegyzetdia dátum‑idő helyőrzőjébe.
- Írja ki a módosított prezentációfájlt.

Az alábbi példában megadott kódrészlet.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// A fejlécek és láblécek beállításainak módosítása a jegyzet mester és az összes jegyzet dia számára
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// a mester jegyzet diát és az összes gyermek lábléc helyőrzőt láthatóvá teszi
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// a mester jegyzet diát és az összes gyermek fejléc helyőrzőt láthatóvá teszi
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// a mester jegyzet diát és az összes gyermek dia szám helyőrzőt láthatóvá teszi
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// a mester jegyzet diát és az összes gyermek dátum és idő helyőrzőt láthatóvá teszi
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// szöveget állít be a mester jegyzet dián és az összes gyermek fejléc helyőrzőre
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// szöveget állít be a mester jegyzet dián és az összes gyermek lábléc helyőrzőre
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// szöveget állít be a mester jegyzet dián és az összes gyermek dátum és idő helyőrzőre
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Csak az első jegyzet diára vonatkozó fejlécek és láblécek beállításainak módosítása
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// ezt a jegyzet diát fejléc helyőrzőjét láthatóvá teszi
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// ezt a jegyzet diát lábléc helyőrzőjét láthatóvá teszi
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// ezt a jegyzet diát dia szám helyőrzőjét láthatóvá teszi
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// ezt a jegyzet diát dátum‑idő helyőrzőjét láthatóvá teszi
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// szöveget állít be a jegyzet dia fejléc helyőrzőjére
	headerFooterManager->SetHeaderText(u"New header text");
	// szöveget állít be a jegyzet dia lábléc helyőrzőjére
	headerFooterManager->SetFooterText(u"New footer text");
	// szöveget állít be a jegyzet dia dátum‑idő helyőrzőjére
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Hozzáadhatok "fejlécet" a normál diákhoz?**

PowerPoint‑ban a "Header" csak a jegyzetek és kézikönyvek számára érhető el; a normál diákon a támogatott elemek a lábléc, a dátum/idő és a dia száma. Az Aspose.Slides is ugyanazokat a korlátozásokat tükrözi: fejléc csak a Notes/Handout esetén, a diákon – Footer/DateTime/SlideNumber.

**Mi van, ha az elrendezés nem tartalmaz lábléc területet—bekapcsolhatom a láthatóságát?**

Igen. Ellenőrizze a láthatóságot a fejléc/lábléc kezelőn keresztül, és szükség esetén engedélyezze azt. Ezek az API‑indikátorok és metódusok olyan esetekre lettek tervezve, amikor a helyőrző hiányzik vagy rejtett.

**Hogyan állíthatom be, hogy a dia száma 1‑nél más értékkel induljon?**

Állítsa be a prezentáció [első dia száma](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/set_firstslidenumber/); ezután az összes számozás újraszámítódik. Például kezdheti 0‑val vagy 10‑zel, és elrejtheti a számot a címdia esetén.

**Mi történik a fejlécekkel/láblécekkel PDF/images/HTML exportálásakor?**

Azok a prezentáció szabályos szövegelemeként kerülnek megjelenítésre. Vagyis, ha az elemek láthatók a diákon/jegyzetoldalakon, akkor azok is meg fognak jelenni a kimeneti formátumban a többi tartalommal együtt.