---
title: PowerPoint-prezentációk konvertálása XML-be .NET-ben
linktitle: PowerPoint XML-re
type: docs
weight: 145
url: /hu/net/convert-powerpoint-to-xml/
keywords:
- PowerPoint konvertálása XML-be
- prezentáció konvertálása XML-be
- PPT XML-be
- PPTX XML-be
- ODP XML-be
- PowerPoint XML prezentáció
- SaveFormat.Xml
- prezentáció mentése XML-ként
- prezentáció exportálása XML-be
- XML adatfolyam
- .NET
- C#
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk konvertálása PowerPoint XML fájlokká vagy adatfolyamokká C#-ban az Aspose.Slides for .NET használatával."
---
## **Áttekintés**

Az Aspose.Slides for .NET képes PowerPoint‑prezentációkat PowerPoint XML Presentation formátumba konvertálni. Az XML‑kimenet akkor hasznos, ha szöveges reprezentációra van szükség a prezentáció felépítésének vizsgálatához, a generált dokumentumok hibakereséséhez, a kimenet összehasonlításához automatizált tesztekben, vagy egy olyan munkafolyamathoz való integráláshoz, amely XML‑t fogyaszt a prezentációcsomag helyett.

Használja a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) felsorolás `Xml` értékével. Az eredményt közvetlenül fájlba vagy streambe írhatja.

{{% alert color="info" title="Megjegyzés" %}}
`SaveFormat.Xml` PowerPoint XML Presentation fájlt hoz létre. Nem bontja ki a PPTX‑csomagban tárolt egyedi Office Open XML részeket. Ha a pontos PPTX‑csomagrészekre, például a `ppt/presentation.xml` fájlra vagy az egyedi dia XML‑fájlokra van szüksége, vizsgálja meg magát a PPTX‑csomagot.
{{% /alert %}}

## **Prezentáció konvertálása XML fájlra**

Töltsön be egy forrásprezentációt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztállyal, majd adja meg a kimeneti elérési utat és a `SaveFormat.Xml` értéket a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) hívásakor. A forrás lehet bármely, a betöltéshez támogatott formátum, például PPT, PPTX vagy ODP.

Az alábbi példa egy PPTX‑prezentációt XML fájlba konvertál:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Az XML kimenet írása streambe**

Használja a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) stream‑túlterhelését, ha az XML‑nek a memóriában kell maradnia, vagy egy másik komponensnek kell átadni, például egy webszolgáltatásnak, tárolási szolgáltatónak vagy XML‑feldolgozó csővezetéknek. Az alábbi példa az eredményt egy [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream)‑be írja, majd visszaállítja olvasásra:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Átadja az xmlStream-et a munkafolyamat következő komponensének.
```

## **Az XML összehasonlítása a prezentációval és az export formátumokkal**

Válassza ki a kimeneti formátumot a felhasználás módja szerint:

| Formátum | Kimenet | Tipikus használat |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML prezentáció | Felépítés vizsgálata, hibakeresés, generált kimenet összehasonlítása, XML‑alapú integráció |
| PPT (`.ppt`) | Örökölt bináris prezentációfájl | Kompatibilitás a régebbi PowerPoint munkafolyamatokkal |
| PPTX (`.pptx`) | Office Open XML csomag több részzel | Szokásos PowerPoint szerkesztés és prezentációcsere |
| PDF vagy TIFF | Rögzített elrendezésű oldalak vagy többoldalas kép | Megtekintés, nyomtatás és archiválás |
| PNG, JPEG vagy SVG | Egy adott dia megjelenített ábrázolása | Bélyegképek, előnézetek és kép erőforrások |
| HTML vagy HTML5 | Weborientált prezentáció kimenet | Böngészőben való megtekintés és webes közzététel |

A PPT‑ és PPTX‑formátumokkal ellentétben az XML‑kimenet elsősorban vizsgálatra és adatorientált munkafolyamatokra készült. A PDF‑, TIFF‑, HTML‑ és dia‑kép formátumokkal ellentétben nem ábrázolja a diákat oldalakon vagy vizuális eszközökön, hanem a prezentáció adatstruktúráját adja vissza. A [supported file formats](/slides/hu/net/supported-file-formats/) táblázat a PowerPoint XML Presentation‑t csak mentésre támogatott formátumként sorolja fel, ezért ne használja, ha a munkafolyamatnak vissza kell töltenie a kiexportált fájlt az Aspose.Slides‑be a további szerkesztéshez.

## **GYIK**

**Ugyanaz-e a `SaveFormat.Xml` mint egy PPTX fájl mentése?**

Nem. A PPTX egy csomag, amely több Office Open XML részt tartalmaz, míg a `SaveFormat.Xml` egy PowerPoint XML Presentation fájlt hoz létre.

**Menthetem az XML‑kimenetet anélkül, hogy fájlt hoznék létre a lemezen?**

Igen. Adj át egy írható streamet a [Presentation.Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/save/) metódusnak. Például használj egy [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream)‑et a memóriában történő feldolgozáshoz.

**Az Aspose.Slides képes betölteni a exportált XML‑fájlt?**

Nem. A PowerPoint XML Presentation jelenleg csak mentésre támogatott, betöltésre nem. Használj PPTX‑et vagy más támogatott prezentációs formátumot, ha körkörös szerkesztésre van szükség.

**Az XML‑konverzió minden diát oldalra vagy képre renderel?**

Nem. Az XML‑konverzió strukturált prezentációs adatot ír. Használj PDF‑et vagy TIFF‑et oldalorientált kimenethez, illetve PNG‑t, JPEG‑t vagy SVG‑t egyedi dia‑képekhez.