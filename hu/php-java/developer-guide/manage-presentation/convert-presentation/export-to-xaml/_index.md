---
title: Prezentációk exportálása XAML-be PHP-ben
linktitle: Prezentáció XAML-be
type: docs
weight: 30
url: /hu/php-java/export-to-xaml/
keywords:
- PowerPoint exportálása
- OpenDocument exportálása
- prezentáció exportálása
- PowerPoint átalakítása
- OpenDocument átalakítása
- prezentáció átalakítása
- PowerPoint XAML-ba
- OpenDocument XAML-ba
- prezentáció XAML-ba
- PPT XAML-ba
- PPTX XAML-ba
- ODP XAML-ba
- PPT mentése XAML-ként
- PPTX mentése XAML-ként
- ODP mentése XAML-ként
- PPT exportálása XAML-ba
- PPTX exportálása XAML-ba
- ODP exportálása XAML-ba
- PHP
- Aspose.Slides
description: "PowerPoint és OpenDocument diákat konvertál XAML-be az Aspose.Slides for PHP Java-n keresztül — gyors, Office-mentes megoldás, amely megőrzi az elrendezést."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint‑prezentációkat XAML‑formátumba exportálni az Aspose.Slides segítségével. Rövid bevezetést nyújt a XAML‑ba, megmutatja, hogyan menthet egy prezentációt XAML‑ba alapértelmezett beállításokkal, és bemutatja, hogyan testreszabható az export a [XamlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xamloptions/) segítségével, beleértve a rejtett diák exportálását is. A cikk válaszol néhány gyakori kérdésre is, amelyek a tartalék betűtípusokra, a XAML‑verem kompatibilitására és a rejtett diák exportálási viselkedésére vonatkoznak.

## **A XAML‑ról**

A XAML egy leíró programozási nyelv, amely lehetővé teszi felhasználói felületek felépítését vagy írását alkalmazásokhoz, különösen azokhoz, amelyek a WPF‑et (Windows Presentation Foundation), az UWP‑t (Universal Windows Platform) vagy a Xamarin Forms‑t használják.  

A XAML, amely XML‑alapú nyelv, a Microsoft változata a GUI leírására. A legtöbb esetben valószínűleg a tervezőt használja a XAML‑fájlok szerkesztéséhez, de továbbra is írhat és szerkeszthet GUI‑t. 

## **Prezentációk exportálása XAML‑ba alapértelmezett beállításokkal**

Ez a PHP‑kód megmutatja, hogyan exportálhat egy prezentációt XAML‑ba alapértelmezett beállításokkal:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Prezentációk exportálása XAML‑ba egyéni beállításokkal**

A [XamlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xamloptions/) osztályból választhat beállításokat, amelyek szabályozzák az exportfolyamot, és meghatározzák, hogyan exportálja az Aspose.Slides a prezentációt XAML‑ba.

Például, ha azt szeretné, hogy az Aspose.Slides a prezentációból rejtett diákat is hozzáadja az XAML‑ba exportáláskor, használhatja a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xamloptions/setexporthiddenslides/) metódust a `true` értékkel. Lásd ezt a példakódot PHP‑ban:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Hogyan biztosíthatom a kiszámítható betűtípusokat, ha az eredeti betűtípus nem érhető el a gépen?**

Állítson be egy [alapértelmezett normál betűtípust](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) a [XamlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xamloptions/)‑ban — ez lesz a tartalék betűtípus, ha az eredeti hiányzik. Ez segít elkerülni a váratlan helyettesítéseket.

**Az exportált XAML csak WPF‑hez szánt, vagy más XAML‑veremekben is használható?**

A XAML egy általános UI jelölőnyelv, amely a WPF‑ben, az UWP‑ben és a Xamarin.Forms‑ban használatos. Az export a Microsoft XAML‑veremekkel való kompatibilitásra irányul; a pontos viselkedés és az egyes szerkezetek támogatása a célplatformtól függ. Tesztelje a jelölést a saját környezetében.

**Támogatottak a rejtett diák, és hogyan akadályozhatom meg, hogy alapértelmezésben exportálásra kerüljenek?**

Alapértelmezés szerint a rejtett diák nincsenek belefoglalva. Ezt a viselkedést a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xamloptions/setexporthiddenslides/) metódussal a [XamlOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/xamloptions/)‑ban szabályozhatja — hagyja letiltva, ha nem szükséges exportálni őket.