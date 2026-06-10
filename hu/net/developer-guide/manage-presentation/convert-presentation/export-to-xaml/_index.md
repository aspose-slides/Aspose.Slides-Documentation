---
title: Prezentációk exportálása XAML-ba .NET-ben
linktitle: Prezentáció XAML-ba
type: docs
weight: 30
url: /hu/net/export-to-xaml/
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
- .NET
- C#
- Aspose.Slides
description: "PowerPoint és OpenDocument diák konvertálása XAML-ba .NET-ben az Aspose.Slides használatával – gyors, Office‑mentes megoldás, amely megőrzi a elrendezést."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan exportálhatók a PowerPoint‑prezentációk XAML‑ba az Aspose.Slides segítségével. Tartalmaz egy rövid bevezetést a XAML‑ba, megmutatja, hogyan menthető egy prezentáció XAML‑ként alapértelmezett beállításokkal, és bemutatja, hogyan testreszabható az export a [XamlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/xamloptions/), többek között a rejtett diák exportálásával. A cikk válaszol néhány gyakori kérdésre is, amelyek a helyettesítő betűtípusokra, a XAML‑verem kompatibilitásra és a rejtett diák exportálási viselkedésére vonatkoznak.

## **A XAML‑ról**

A XAML egy leíró programnyelv, amely lehetővé teszi felhasználói felületek építését vagy írását alkalmazásokhoz, különösen azokhoz, amelyek a WPF‑et (Windows Presentation Foundation), az UWP‑t (Universal Windows Platform) vagy a Xamarin‑formákat használják.  

A XAML, amely XML‑alapú nyelv, a Microsoft által biztosított változat a grafikus felület leírására. A legtöbb alkalommal valószínűleg egy tervezőt használ a XAML‑fájlok szerkesztéséhez, de továbbra is írhat és szerkeszthet GUI‑t.

## **Prezentációk exportálása XAML‑ba alapértelmezett beállításokkal**

Ez a C# kód megmutatja, hogyan exportálhat egy prezentációt XAML‑ba alapértelmezett beállításokkal:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## **Prezentációk exportálása XAML‑ba egyéni beállításokkal**

Az IXamlOptions interfészben választhatja ki az export folyamatot irányító beállításokat, amelyek meghatározzák, hogyan exportálja az Aspose.Slides a prezentációt XAML‑ba.  

Például, ha azt szeretné, hogy az Aspose.Slides a rejtett diákat is hozzáadja a prezentációhoz az XAML‑ba exportálás során, beállíthatja az [ExportHiddenSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) tulajdonságot true‑ra. Lásd ezt a C# példakódot:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```

## **GYIK**

**Hogyan biztosíthatom a kiszámítható betűtípusokat, ha az eredeti betűtípus nem érhető el a gépen?**

Állítsa be a [DefaultRegularFont](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveoptions/defaultregularfont/) a [XamlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/xamloptions/)‑ban — ez a helyettesítő betűtípus, amikor az eredeti hiányzik. Ez segít elkerülni a váratlan helyettesítéseket.

**Az exportált XAML csak a WPF‑hez szánt, vagy más XAML‑veremekben is használható?**

A XAML egy általános UI leíró nyelv, amelyet a WPF, az UWP és a Xamarin.Forms használ. Az export célja a kompatibilitás a Microsoft XAML‑veremekkel; a pontos viselkedés és a specifikus konstrukciók támogatása a célplatformtól függ. Tesztelje a jelölőt a saját környezetében.

**Támogatottak a rejtett diák, és hogyan akadályozhatom meg, hogy alapértelmezés szerint exportálva legyenek?**

Alapértelmezés szerint a rejtett diák nincsenek benne. Ezt a viselkedést vezérelheti az [ExportHiddenSlides](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) a [XamlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export.xaml/xamloptions/)‑ban — tartsa letiltva, ha nem szeretné exportálni őket.