---
title: Prezentációk exportálása XAML-be Androidon
linktitle: Prezentáció XAML-be
type: docs
weight: 30
url: /hu/androidjava/export-to-xaml/
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
  - Android
  - Java
  - Aspose.Slides
description: "PowerPoint és OpenDocument diák konvertálása XAML-be Java-ban az Aspose.Slides for Android használatával – gyors, Office-mentes megoldás, amely megőrzi az elrendezést."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint‑prezentációkat XAML‑be exportálni az Aspose.Slides használatával. Tartalmaz egy rövid bevezetést az XAML‑ba, megmutatja, hogyan menthet egy prezentációt XAML‑ba alapértelmezett beállításokkal, és bemutatja, hogyan testreszabható az export a [XamlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xamloptions/) segítségével, beleértve a rejtett diák exportálását is. A cikk továbbá válaszol néhány gyakori kérdésre a helyettesítő betűtípusokkal, az XAML‑verem kompatibilitással és a rejtett diák exportálási viselkedésével kapcsolatban.

## **Az XAML-ról**

Az XAML egy leíró programozási nyelv, amely lehetővé teszi felhasználói felületek építését vagy írását alkalmazások számára, különösen azok számára, amelyek WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) és Xamarin formákat használnak.  

Az XAML, amely XML‑alapú nyelv, a Microsoft változata a GUI leírására. Valószínűleg egy tervezőt fog használni XAML‑fájlok szerkesztésére a legtöbb esetben, de továbbra is írhat és szerkeszthet GUI‑ját. 

## **Prezentációk exportálása XAML‑ba alapértelmezett beállításokkal**

Ez a Java kód megmutatja, hogyan exportálhat egy prezentációt XAML‑ba alapértelmezett beállításokkal:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Prezentációk exportálása XAML‑ba egyedi beállításokkal**

A [IXamlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IXamlOptions) felületen kiválaszthatja az export folyamatot vezérlő beállításokat, amelyek meghatározzák, hogyan exportálja az Aspose.Slides a prezentációt XAML‑ba.

Például, ha azt szeretné, hogy az Aspose.Slides a rejtett diákot is hozzáadja a prezentációból az XAML‑ba exportáláskor, beállíthatja az [ExportHiddenSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) tulajdonságot true‑ra. Lásd ezt a példa Java kódot:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

## **GYIK**

**Hogyan biztosíthatom a kiszámítható betűtípusokat, ha az eredeti betűtípus nem áll rendelkezésre a gépen?**

Állítson be egy [alapértelmezett normál betűtípust](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) a [XamlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xamloptions/)‑ban — ez helyettesítő betűtípusként kerül felhasználásra, ha az eredeti hiányzik. Ez segít elkerülni a váratlan helyettesítéseket.

**Az exportált XAML csak WPF‑hez szól, vagy más XAML‑veremekben is használható?**

Az XAML egy általános UI jelölőnyelv, amelyet a WPF, UWP és Xamarin.Forms használ. Az export célja a Microsoft XAML‑veremekkel való kompatibilitás; a pontos viselkedés és a konkrét szerkezetek támogatása a célnak megfelelő platformtól függ. Tesztelje a jelölőnyelvet a saját környezetében.

**Támogatottak a rejtett diák, és hogyan akadályozhatom meg, hogy alapértelmezés szerint exportálásra kerüljenek?**

Alapértelmezés szerint a rejtett diák nem kerülnek bele. Ezt a viselkedést a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) segítségével szabályozhatja a [XamlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/xamloptions/)‑ban — tartsa letiltva, ha nem szeretné őket exportálni.