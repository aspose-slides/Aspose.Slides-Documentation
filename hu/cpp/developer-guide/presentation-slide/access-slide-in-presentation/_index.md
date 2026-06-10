---
title: C++-ban a prezentáció diainak elérése
linktitle: Dia elérése
type: docs
weight: 20
url: /hu/cpp/access-slide-in-presentation/
keywords:
- dia elérése
- dia index
- dia azonosító
- dia pozíció
- pozíció módosítása
- dia tulajdonságok
- dia száma
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan érheti el és kezelheti a diákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for C++ segítségével. Növelje a hatékonyságot kódpéldákkal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet elérni és kezelni a diákat egy prezentációban az Aspose.Slides használatával. Megmutatja, hogyan lehet a diákat a nullától indexelt pozíció alapján lekérni a diák gyűjteményéből, illetve hogyan lehet egy diát a egyedi azonosítója alapján elérni a `GetSlideById` metódussal.

Megtanulod, hogyan változtatható meg egy dia pozíciója a `set_SlideNumber` metódus használatával, valamint hogyan állítható be a prezentáció első diája száma a `set_FirstSlideNumber` metódussal. A példák bemutatják egy prezentáció betöltését, a diareferenciák lekérését, a dia sorrendjének vagy számozásának frissítését, és a módosított prezentáció mentését.

## **Dia elérése index szerint**

Minden dia egy prezentációban numerikusan van elrendezve a dia pozíciója alapján, 0‑tól kezdve. Az első dia elérhető a 0‑ás indexen; a második dia a 1‑es indexen; stb.

A Presentation osztály, amely egy prezentációs fájlt képvisel, a diákat egy [ISlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidecollection/) gyűjteményként (a [ISlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/) objektumok gyűjteménye) teszi elérhetővé. Ez a C++ kód megmutatja, hogyan lehet egy diát az indexe alapján elérni:

```c++
	// Az útvonal a dokumentumok könyvtárához.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Példányosítja a Presentation osztályt
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Dia referencia lekérése az indexe alapján
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Dia elérése azonosító szerint**

Minden diához egy egyedi azonosító tartozik. A [GetSlideById()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/getslidebyid/) metódus (amely a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályban érhető el) segítségével célozhatod meg ezt az azonosítót. Ez a C++ kód megmutatja, hogyan adható meg egy érvényes diaazonosító, és hogyan érhető el a dia a [GetSlideById()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/getslidebyid/) metódussal:

```c++
	// Az útvonal a dokumentumok könyvtárához.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Példányosítja a Presentation osztályt
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Lekéri a dia azonosítóját
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// A diát azonosítója alapján érjük el
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Dia pozíciójának módosítása**

Az Aspose.Slides lehetővé teszi a dia pozíciójának módosítását. Például megadhatod, hogy az első dia a második legyen.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
1. Szerezd meg a módosítani kívánt dia referenciaját a indexe alapján  
1. Állíts be egy új pozíciót a diához a [set_SlideNumber()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/set_slidenumber/) tulajdonság segítségével.  
1. Mentsd el a módosított prezentációt.

Ez a C++ kód bemutat egy műveletet, amelyben az 1‑es pozícióban lévő dia a 2‑es pozícióba kerül:

```c++
	// Az útvonal a dokumentumok könyvtárához.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Példányosítja a Presentation osztályt
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Lekéri a diát, amelynek a pozíciója megváltozik
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Beállítja a dia új pozícióját
	slide->set_SlideNumber(2);

	// Mentse el a módosított prezentációt
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Az első dia a második lett; a második dia az első. Amikor egy dia pozícióját módosítod, a többi dia automatikusan igazodik.

## **Dia számának beállítása**

A [set_FirstSlideNumber()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/set_firstslidenumber/) tulajdonság (amely a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályban érhető el) segítségével megadhatsz egy új számot az első diához egy prezentációban. Ez a művelet a többi dia számát újraszámolja.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
1. Szerezd meg a dia számát.  
1. Állítsd be a dia számát.  
1. Mentsd el a módosított prezentációt.

Ez a C++ kód bemutat egy műveletet, ahol az első dia száma 10‑re van állítva:

```c++
	// Az útvonal a dokumentumok könyvtárához.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Instantiates a Presentation osztályt
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Lekéri a dia számát
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Beállítja a dia számát
	pres->set_FirstSlideNumber(2);
	
	// Mentse el a módosított prezentációt
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Ha azt szeretnéd, hogy a számozás a második diával kezdődjön (és az első dia számozását elrejtve), ezt így teheted:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Beállítja az első prezentációs dia számát
presentation->set_FirstSlideNumber(0);

// Megjeleníti a dia számokat az összes dián
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Elrejti az első dia számát
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Mentse el a módosított prezentációt
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Megegyezik-e a felhasználó által látott dia száma a gyűjtemény nullától indexelt pozíciójával?**

A diához megjelenített szám tetszőleges értékkel (például 10) indulhat, és nem kell, hogy megegyezzen az indexszel; a kapcsolatot a prezentáció **első dia száma** ( [set_FirstSlideNumber](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/set_firstslidenumber/) ) beállítása határozza meg.

**Hatással vannak-e a rejtett diák az indexelésre?**

Igen. Egy rejtett dia továbbra is szerepel a gyűjteményben, és beleszámít az indexelésbe; a „rejtett” a megjelenítésre vonatkozik, nem a gyűjteményben elfoglalt helyére.

**Módosul-e egy dia indexe, amikor más diák kerülnek hozzáadásra vagy eltávolításra?**

Igen. Az indexek mindig a diák aktuális sorrendjét tükrözik, és újraszámolódnak beszúrás, törlés és áthelyezés műveletek során.