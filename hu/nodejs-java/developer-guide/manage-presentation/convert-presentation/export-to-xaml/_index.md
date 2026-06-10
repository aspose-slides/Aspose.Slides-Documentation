---
title: Prezentációk exportálása XAML-ba JavaScriptben
linktitle: Prezentáció XAML-ba
type: docs
weight: 30
url: /hu/nodejs-java/export-to-xaml/
keywords:
- PowerPoint exportálása
- OpenDocument exportálása
- prezentáció exportálása
- PowerPoint konvertálása
- OpenDocument konvertálása
- prezentáció konvertálása
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
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint és OpenDocument diák konvertálása XAML-ra JavaScriptben az Aspose.Slides for Node.js segítségével – gyors, Office-mentes megoldás, amely megőrzi a layoutot."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan exportálhatók PowerPoint‑bemutatók XAML‑formátumba az Aspose.Slides segítségével. Rövid bemutatót nyújt a XAML‑ról, megmutatja, hogyan menthető el egy bemutató XAML‑ként alapértelmezett beállításokkal, és bemutatja, hogyan testreszabható az export a [XamlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xamloptions/) használatával, beleértve a rejtett diák exportálását is. A cikk néhány gyakori kérdésre is válaszol a tartalék betűtípusokkal, a XAML‑verem kompatibilitással és a rejtett diák export viselkedésével kapcsolatban.

## **A XAML‑ról**

A XAML egy leíró programozási nyelv, amely lehetővé teszi felhasználói osztályok létrehozását vagy írását alkalmazásokhoz, különösen azokhoz, amelyek a WPF‑et (Windows Presentation Foundation), UWP‑t (Universal Windows Platform) vagy Xamarin Forms‑t használják.

Az XAML, amely XML‑alapú nyelv, a Microsoft által a GUI leírására kidolgozott változata. A legtöbb esetben valószínűleg egy tervezőt fog használni az XAML fájlok szerkesztéséhez, de továbbra is kézzel is írhatja és módosíthatja a felhasználói felületet.

## **Prezentációk exportálása XAML‑ba alapértelmezett beállításokkal**

Ez a JavaScript‑kód bemutatja, hogyan exportálhat egy prezentációt XAML‑ba alapértelmezett beállításokkal:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Prezentációk exportálása XAML‑ba egyéni beállításokkal**

Választhat beállításokat a [XamlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/XamlOptions) osztályból, amelyek vezérlik az exportfolyamatot és meghatározzák, hogyan exportálja az Aspose.Slides a prezentációt XAML‑ba.

Például, ha azt szeretné, hogy az Aspose.Slides a rejtett diákat is belevegye a prezentációból az XAML‑ba exportáláskor, állítsa a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) metódust true értékre. Lásd ezt a példa JavaScript‑kódot:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Hogyan biztosíthatom a kiszámítható betűtípusokat, ha az eredeti betűtípus nem érhető el a gépen?**

Használja a [setDefaultRegularFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) metódust a [XamlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xamloptions/)‑ban – ez tartalék betűtípusként szolgál, ha az eredeti hiányzik. Ez segít elkerülni a váratlan helyettesítéseket.

**Az exportált XAML csak a WPF‑hez szánt, vagy más XAML‑veremekben is használható?**

A XAML egy általános UI‑jelölőnyelv, amelyet a WPF, UWP és a Xamarin.Forms használ. Az export célja a Microsoft XAML‑veremekkel való kompatibilitás; a pontos viselkedés és a specifikus szerkezetek támogatása a célplatformtól függ. Tesztelje a jelölést a saját környezetében.

**Támogatottak a rejtett diák, és hogyan akadályozhatom meg, hogy alapértelmezés szerint exportálódjanak?**

Alapértelmezés szerint a rejtett diák nem kerülnek bele. Ezt a viselkedést a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) metóduson keresztül szabályozhatja a [XamlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xamloptions/)‑ban – hagyja letiltva, ha nem szeretné exportálni őket.