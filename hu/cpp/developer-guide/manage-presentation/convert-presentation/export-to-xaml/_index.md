---
title: Prezentációk exportálása XAML-be C++-ban
linktitle: Prezentáció XAML-be
type: docs
weight: 30
url: /hu/cpp/export-to-xaml/
keywords:
- PowerPoint exportálása
- OpenDocument exportálása
- prezentáció exportálása
- PowerPoint átalakítása
- OpenDocument átalakítása
- prezentáció átalakítása
- PowerPoint XAML-be
- OpenDocument XAML-be
- prezentáció XAML-be
- PPT XAML-be
- PPTX XAML-be
- ODP XAML-be
- PPT mentése XAML-ként
- PPTX mentése XAML-ként
- ODP mentése XAML-ként
- PPT exportálása XAML-be
- PPTX exportálása XAML-be
- ODP exportálása XAML-be
- C++
- Aspose.Slides
description: "PowerPoint és OpenDocument diák konvertálása XAML-be C++ használatával az Aspose.Slides segítségével – gyors, Office-mentes megoldás, amely megőrzi a layout-ot."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan exportálhat PowerPoint‑prezentációkat XAML‑ba az Aspose.Slides használatával. Tartalmaz egy rövid bevezetést a XAML‑ba, bemutatja, hogyan menthető a prezentáció XAML‑ba alapértelmezett beállításokkal, és demonstrálja, hogyan testreszabható az export a [XamlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/xamloptions/) segítségével, beleértve a rejtett diák exportálását is. A cikk néhány gyakori kérdésre is válaszol, amelyek a tartalék betűtípusokra, a XAML‑verem kompatibilitásra és a rejtett diák export viselkedésére vonatkoznak.

## **A XAML-ról**

A XAML egy leíró programozási nyelv, amely lehetővé teszi felhasználói felületek építését vagy írását alkalmazásokhoz, különösen azokhoz, amelyek a WPF‑et (Windows Presentation Foundation), UWP‑t (Universal Windows Platform) és Xamarin Forms‑t használják.  

A XAML, amely XML‑alapú nyelv, a Microsoft változata a GUI leírására. A legtöbb esetben egy tervezőt fogsz használni a XAML‑fájlok szerkesztéséhez, de továbbra is írhatod és szerkesztheted a felhasználói felületet. 

## **Prezentációk exportálása XAML‑ba alapértelmezett beállításokkal**

Ez a C++ kód megmutatja, hogyan exportálhatsz egy prezentációt XAML‑ba alapértelmezett beállításokkal:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **Prezentációk exportálása XAML‑ba egyedi beállításokkal**

Az [IXamlOptions](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.xaml.i_xaml_options) felületen választható beállítások szabályozzák az export folyamatát, és meghatározzák, hogyan exportálja az Aspose.Slides a prezentációdat XAML‑ba. 

Például, ha azt szeretnéd, hogy az Aspose.Slides a rejtett diákat is hozzáadja a prezentációdból az XAML‑ba exportáláskor, akkor a [set_ExportHiddenSlides()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313) metódusnak true értéket adhatod. Lásd ezt a C++ példakódot: 

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **GYIK**

**Hogyan biztosíthatom, hogy a betűtípusok kiszámíthatóak legyenek, ha az eredeti betűtípus nem elérhető a gépen?**

Használd a [set_DefaultRegularFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) metódust a [XamlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/xamloptions/)‑ban — ez tartalék betűtípusként szolgál, ha az eredeti hiányzik. Ez segít elkerülni a váratlan helyettesítéseket.

**Az exportált XAML csak a WPF‑hez szánt, vagy más XAML‑veremekben is használható?**

A XAML egy általános UI jelölőnyelv, amelyet a WPF, UWP és a Xamarin.Forms használ. Az export a Microsoft XAML‑veremekkel való kompatibilitásra irányul; a pontos viselkedés és az egyes konstrukciók támogatása a célplatformtól függ. Teszteld a jelölőt a saját környezetedben.

**Támogatottak a rejtett diák, és hogyan akadályozhatom meg, hogy alapértelmezés szerint exportálásra kerüljenek?**

Alapértelmezés szerint a rejtett diák nem kerülnek bele. Ezt a viselkedést a [set_ExportHiddenSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) metódussal a [XamlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export.xaml/xamloptions/)‑ban szabályozhatod — tartsd letiltva, ha nem szeretnéd exportálni őket.