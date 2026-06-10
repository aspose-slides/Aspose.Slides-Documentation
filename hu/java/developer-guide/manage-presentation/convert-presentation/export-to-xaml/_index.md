---
title: Prezentációk exportálása XAML-be Java-ban
linktitle: Prezentáció XAML-be
type: docs
weight: 30
url: /hu/java/export-to-xaml/
keywords:
- PowerPoint exportálása
- OpenDocument exportálása
- prezentáció exportálása
- PowerPoint konvertálása
- OpenDocument konvertálása
- prezentáció konvertálása
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
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument diák konvertálása XAML-be Java-ban az Aspose.Slides használatával - gyors, Office-mentes megoldás, amely megőrzi a felület elrendezését."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet a PowerPoint‑prezentációkat XAML‑be exportálni az Aspose.Slides használatával. Tartalmaz egy rövid bevezetést a XAML‑ba, bemutatja, hogyan lehet alapértelmezett beállításokkal menteni egy prezentációt XAML‑be, és bemutatja, hogyan lehet testre szabni az exportálást a [XamlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xamloptions/)‑on keresztül, beleértve a rejtett diák exportálását is. A cikk válaszol néhány gyakori kérdésre, amelyek a helyettesítő betűtípusokra, a XAML‑stakk kompatibilitásra és a rejtett diák exportálásának viselkedésére vonatkoznak.

## **A XAML‑ról**

A XAML egy leíró programozási nyelv, amely lehetővé teszi felhasználói felületek építését vagy írását alkalmazásokhoz, különösen azokhoz, amelyek a WPF‑et (Windows Presentation Foundation), az UWP‑t (Universal Windows Platform) és a Xamarin form‑okat használják.  

A XAML, amely egy XML‑alapú nyelv, a Microsoft változata egy GUI leírására. A legtöbb esetben valószínűleg egy tervezőt használ a XAML‑fájlok szerkesztéséhez, de továbbra is írhatja és szerkesztheti a felhasználói felületet. 

## **Prezentációk exportálása XAML‑be alapértelmezett beállításokkal**

Ez a Java‑kód megmutatja, hogyan lehet egy prezentációt XAML‑be exportálni alapértelmezett beállításokkal:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save(new XamlOptions());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Prezentációk exportálása XAML‑be egyedi beállításokkal**

A [IXamlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IXamlOptions) felületen választhat beállításokat, amelyek vezérlik az exportálási folyamatot, és meghatározzák, hogyan exportálja az Aspose.Slides a prezentációt XAML‑be.  

Például, ha szeretné, hogy az Aspose.Slides a prezentációból rejtett diákat is hozzáadja az XAML‑exportálás során, beállíthatja az [ExportHiddenSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) tulajdonságot true‑ra. Lássa ezt a példakódot Java‑ban: 

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

**Hogyan biztosíthatom a kiszámítható betűtípusokat, ha az eredeti betűtípus nem elérhető a gépen?**

Állítson be egy [alapértelmezett normál betűtípust](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) az [XamlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xamloptions/) segítségével — ez helyettesítő betűtípusként szolgál, ha az eredeti hiányzik. Ez segít elkerülni a váratlan helyettesítéseket.

**Az exportált XAML csak a WPF‑hez készült, vagy használható más XAML‑stakokban is?**

A XAML egy általános UI jelölőnyelv, amelyet a WPF, UWP és a Xamarin.Forms használ. Az exportálás a Microsoft XAML‑stakkok kompatibilitását célozza; a pontos viselkedés és a specifikus konstrukciók támogatása a célplatformtól függ. Tesztelje a jelölőnyelvet a saját környezetében.

**Támogatottak a rejtett diák, és hogyan lehet megakadályozni, hogy alapértelmezés szerint exportálva legyenek?**

Alapértelmezés szerint a rejtett diák nem szerepelnek. Ezt a viselkedést a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) a [XamlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/xamloptions/) segítségével szabályozhatja — tartsa letiltva, ha nem kívánja exportálni őket.