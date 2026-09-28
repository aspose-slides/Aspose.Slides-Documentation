---
title: PowerPoint prezentációk XML-re konvertálása .NET-ben
linktitle: PowerPoint XML-re
type: docs
weight: 145
url: /hu/net/convert-powerpoint-to-xml/
keywords:
- PowerPoint konvertálása XML-re
- prezentáció konvertálása XML-re
- PPT XML-re
- PPTX XML-re
- ODP XML-re
- PowerPoint XML prezentáció
- SaveFormat.Xml
- prezentáció mentése XML-ként
- prezentáció exportálása XML-be
- XML folyam
- .NET
- C#
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk konvertálása PowerPoint XML fájlokká vagy folyamatokká C#-ban az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Aspose.Slides for .NET képes a PowerPoint prezentációkat PowerPoint XML prezentáció formátumba konvertálni. Az XML kimenet hasznos, ha szöveges ábrázolásra van szükség a prezentáció struktúrájának vizsgálatához, a generált dokumentumok hibakereséséhez, a kimenet összehasonlításához automatizált tesztekben, vagy egy olyan munkafolyamattal való integrációhoz, amely XML-t fogyaszt a prezentáció csomag helyett.

Használja a [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) metódust a [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) felsorolás `Xml` értékével. Az eredményt közvetlenül fájlba vagy folyamba (stream) írhatja.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` PowerPoint XML prezentációt hoz létre. Nem bontja le a PPTX csomagban tárolt egyedi Office Open XML részeket. Ha a pontos PPTX csomagrészekre van szüksége, például `ppt/presentation.xml` vagy egyedi diák XML fájlokra, ellenőrizze a PPTX csomagot.
{{% /alert %}}

## **Prezentáció konvertálása XML fájlra**

Töltsön be egy forrás prezentációt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztállyal, majd adja át a kimeneti útvonalat és a `SaveFormat.Xml` értéket a [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) metódusnak. A forrás lehet bármely a betöltéshez támogatott prezentációformátum, például PPT, PPTX vagy ODP.

Az alábbi példa egy PPTX prezentációt XML fájlra konvertál:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **XML kimenet írása folyamra**

Használja a [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) folyam (stream) túlterhelését, ha az XML-nek memóriában kell maradnia vagy egy másik komponensnek kell átadni, például egy webszolgáltatásnak, tárolási szolgáltatónak vagy XML feldolgozási csővezetéknek. Az alábbi példa az eredményt egy [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0)‑be írja, és visszatekeri a későbbi olvasáshoz:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Az xmlStream átadása a munkafolyamat következő komponensének.
```

## **XML összehasonlítása prezentációs és export formátumokkal**

Válassza ki a kimeneti formátumot attól függően, hogy hogyan lesz felhasználva az eredmény:

| Formátum | Kimenet | Tipikus használat |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML prezentáció | Strukturavizsgálata, hibakeresés, generált kimenet összehasonlítása és XML-alapú integráció |
| PPT (`.ppt`) | Régi bináris prezentációfájl | Kompatibilitás régebbi PowerPoint munkafolyamatokkal |
| PPTX (`.pptx`) | Office Open XML csomag több részzel | Szokásos PowerPoint szerkesztés és prezentációcsere |
| PDF vagy TIFF | Rögzített elrendezésű oldalak vagy TIFF képek | Megtekintés, nyomtatás és archiválás |
| PNG, JPEG vagy SVG | Egyetlen dia renderelt ábrázolása | Bélyegképek, előnézetek és képeszközök |
| HTML vagy HTML5 | Web-orientált prezentációs kimenet | Böngészőben való megtekintés és webes publikálás |

A PPT és PPTX formátumoktól eltérően az XML kimenet elsősorban ellenőrzésre és adat-orientált munkafolyamatokra szolgál. A PDF, TIFF, HTML és diakép formátumoktól eltérően a prezentáció adatokat reprezentál, nem rendereli a diákat oldalakon vagy vizuális eszközökön. A [supported file formats](/slides/hu/net/supported-file-formats/) táblázat felsorolja az összes formátumot, amelyet az Aspose.Slides be tud tölteni, importálni, menteni vagy renderelni.

## **GYIK**

**A `SaveFormat.Xml` ugyanaz, mint egy PPTX fájl mentése?**  
Nem. A PPTX egy csomag, amely több Office Open XML részt tartalmaz, míg a `SaveFormat.Xml` egy PowerPoint XML prezentációs fájlt hoz létre.

**Menthetem az XML kimenetet anélkül, hogy fájlt hoznék létre a lemezen?**  
Igen. Adjon át egy írható folyamot a [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) metódusnak. Például használjon egy [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0)‑t a memóriában történő feldolgozáshoz.

**Tudja az Aspose.Slides újra betölteni az exportált XML fájlt?**  
Igen. Adja át az XML fájlt vagy egy folyamot a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) konstruktorának. A [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) ekkor `SourceFormat.Xml` értéket ad vissza. A [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) `LoadFormat.Unknown` értéket jelent ennél a formátumnál, ezért ne használja annak eldöntésére, hogy egy XML fájl megnyitható‑e.

**Az XML konverzió minden diát oldal‑ként vagy kép‑ként renderel?**  
Nem. Az XML konverzió strukturált prezentációs adatokat ír. Használjon PDF‑et vagy TIFF‑et oldal‑orientált kimenethez, vagy PNG‑t, JPEG‑t és SVG‑t egyedi diaképekhez.