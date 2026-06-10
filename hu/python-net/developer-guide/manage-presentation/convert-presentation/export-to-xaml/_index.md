---
title: Prezentációk exportálása XAML-be Python-ban
linktitle: Exportálás XAML-be
type: docs
weight: 30
url: /hu/python-net/export-to-xaml/
keywords:
- PowerPoint exportálása
- OpenDocument exportálása
- prezentáció exportálása
- PowerPoint átalakítása
- OpenDocument átalakítása
- prezentáció átalakítása
- PowerPoint XAML-re
- OpenDocument XAML-re
- prezentáció XAML-re
- PPT XAML-re
- PPTX XAML-re
- ODP XAML-re
- Python
- Aspose.Slides
description: "PowerPoint és OpenDocument diák konvertálása XAML-re Pythonban az Aspose.Slides használatával—gyors, Office-független megoldás, amely megőri az elrendezést."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan exportálhatók PowerPoint‑prezentációk XAML formátumba az Aspose.Slides használatával. Rövid bevezetést nyújt az XAML‑ról, megmutatja, hogyan menthető el egy prezentáció XAML‑ként alapértelmezett beállításokkal, és bemutatja, hogyan testreszabható az export a [XamlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.xaml/xamloptions/) segítségével, beleértve a rejtett diák exportálását is. A cikk válaszol néhány gyakori kérdésre a tartalék betűtípusokkal, az XAML‑verem kompatibilitással és a rejtett diák exportálási viselkedésével kapcsolatban.

## **Az XAML‑ról**

Az XAML egy leíró programozási nyelv, amely lehetővé teszi felhasználói felületek építését vagy írását alkalmazásokhoz, különösen azokhoz, amelyek a WPF‑et (Windows Presentation Foundation), UWP‑t (Universal Windows Platform) vagy Xamarin form‑okat használják.  

Az XAML, amely XML‑alapú nyelv, a Microsoft változata a grafikus felület leírásának. A legtöbb esetben valószínűleg egy tervezőprogrammal dolgozik XAML‑fájlokon, de továbbra is kézzel is írhatja és szerkesztheti a felületet.

## **Prezentációk exportálása XAML‑be alapértelmezett beállításokkal**

Ez a Python‑kód megmutatja, hogyan exportálhat egy prezentációt XAML‑be alapértelmezett beállításokkal:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **Prezentációk exportálása XAML‑be egyéni beállításokkal**

A [XamlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.xaml/xamloptions/) osztályból választható beállítások szabályozzák az exportfolyamatot, és meghatározzák, hogy az Aspose.Slides hogyan exportálja a prezentációt XAML‑ba.

Például ha azt szeretné, hogy az Aspose.Slides a rejtett diákra is kiterjedő exportot végezzen XAML‑ba, állítsa be az [export_hidden_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) tulajdonságot **True**‑ra. Lássa a példa Python‑kódot:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **Gyakran Ismételt Kérdések**

**Hogyan biztosíthatom a kiszámítható betűtípusokat, ha az eredeti betűtípus nem érhető el a gépen?**

Állítsa be a [default_regular_font](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) értéket a [XamlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.xaml/xamloptions/)‑ban – ez kerül felhasználásra tartalék betűtípusként, ha az eredeti hiányzik. Ez segít elkerülni a váratlan helyettesítéseket.

**Az exportált XAML csak a WPF‑hez szánt, vagy más XAML‑veremekben is használható?**

Az XAML egy általános UI‑jelölő nyelv, amelyet a WPF, UWP és a Xamarin.Forms használ. Az export a Microsoft XAML‑veremekkel való kompatibilitásra törekszik; a pontos viselkedés és a konkrét konstrukciók támogatása a célplatformtól függ. Tesztelje a jelölést a saját környezetében.

**Támogatottak a rejtett diák, és hogyan akadályozhatom meg, hogy alapértelmezés szerint exportálódjanak?**

Alapértelmezés szerint a rejtett diák nincsenek belefoglalva. Ezt a viselkedést a [export_hidden_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) beállítással szabályozhatja a [XamlOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export.xaml/xamloptions/)‑ban – tartsa letiltott állapotban, ha nem szeretné exportálni őket.