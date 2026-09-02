---
title: PowerPoint prezentációk konvertálása XML-be C++-ban
linktitle: PowerPoint XML-re
type: docs
weight: 145
url: /hu/cpp/convert-powerpoint-to-xml/
keywords:
- PowerPoint konvertálása XML-re
- prezentáció konvertálása XML-re
- PPT XML-re
- PPTX XML-re
- ODP XML-re
- PowerPoint XML prezentáció
- SaveFormat::Xml
- prezentáció mentése XML-ként
- prezentáció exportálása XML-be
- XML adatfolyam
- C++
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk konvertálása PowerPoint XML fájlokba vagy adatfolyamokba C++-ban az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

Az Aspose.Slides for C++ képes PowerPoint‑prezentációkat PowerPoint XML Presentation formátumba konvertálni. Az XML‑kimenet hasznos, ha szöveges ábrázolásra van szükség a prezentáció felépítésének ellenőrzéséhez, a generált dokumentumok hibakereséséhez, a kimenet összehasonlításához automatizált tesztekben, vagy egy olyan munkafolyamat integrálásához, amely XML‑t fogyaszt a prezentációcsomag helyett.

Használja a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveformat/) felsorolás `Xml` értékével. Az eredményt közvetlenül egy fájlba vagy adatfolyamba írhatja.

{{% alert color="info" title="Megjegyzés" %}}

`SaveFormat::Xml` PowerPoint XML Presentation fájlt hoz létre. Nem bontja ki a PPTX csomagban tárolt egyedi Office Open XML részeket. Ha a pontos PPTX‑csomag részeire van szükség, például a `ppt/presentation.xml`‑ra vagy egyedi diák XML‑fájlokra, akkor a PPTX‑csomagot kell megvizsgálnia.

{{% /alert %}}

## **Prezentáció konvertálása XML-fájlra**

Töltsön be egy forrás‑prezentációt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztállyal, majd adja meg a kimeneti útvonalat és a `SaveFormat::Xml` értéket a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódusnak. A forrás lehet bármely, a betöltéshez támogatott formátum, például PPT, PPTX vagy ODP.

Az alábbi példa egy PPTX prezentációt XML‑fájllá konvertál:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **Az XML‑kimenet írása egy adatfolyamra**

Használja a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) adatfolyam‑túlterhelését, amikor az XML‑nek memóriában kell maradnia, vagy egy másik komponensnek kell átadni, például egy webszolgáltatásnak, tárolási szolgáltatónak vagy XML‑feldolgozó csővezetéknek. Az alábbi példa a kimenetet egy [MemoryStream](https://reference.aspose.com/slides/hu/cpp/system.io/memorystream/)‑ba írja, majd visszatekeri a további olvasáshoz:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// Az xmlStream-et átadja a munkafolyamat következő komponensének.
```

## **XML összehasonlítása a prezentációval és az exportformátumokkal**

Válassza ki a kimeneti formátumot a felhasználási mód szerint:

| Formátum | Kimenet | Tipikus felhasználás |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML prezentáció | A struktúra ellenőrzése, hibakeresés, a generált kimenet összehasonlítása, és XML‑alapú integráció |
| PPT (`.ppt`) | Örökölt bináris prezentációfájl | Kompatibilitás a régebbi PowerPoint munkafolyamatokkal |
| PPTX (`.pptx`) | Office Open XML csomag több részzel | Szokásos PowerPoint szerkesztés és prezentációcsere |
| PDF vagy TIFF | Rögzített elrendezésű oldalak vagy többoldalas kép | Megtekintés, nyomtatás, és archiválás |
| PNG, JPEG vagy SVG | Egyedi dia renderelt ábrázolása | Bélyegképek, előnézeti képek, és kép erőforrások |
| HTML vagy HTML5 | Weborientált prezentációkimenet | Böngészőben való megtekintés és webes közzététel |

A PPT‑ és PPTX‑formátumoktól eltérően az XML‑kimenet elsősorban ellenőrzésre és adatközpontú munkafolyamatokhoz készült. A PDF, TIFF, HTML és dia‑kép formátumoktól eltérően az XML a prezentáció adatát reprezentálja, nem pedig a diákat oldalként vagy vizuális eszközként jeleníti meg. 

A [támogatott fájlformátumok](/slides/hu/cpp/supported-file-formats/) táblázata a PowerPoint XML Presentation‑t csak mentési formátumként sorolja fel, ezért ne használja, ha a munkafolyamatnak vissza kell töltenie a exportált fájlt az Aspose.Slides‑be a további szerkesztéshez.

## **Gyakran Ismételt Kérdések**

**Ugyanaz-e a `SaveFormat::Xml` és egy PPTX fájl mentése?**  
Nem. A PPTX egy több Office Open XML részt tartalmazó csomag, míg a `SaveFormat::Xml` egy PowerPoint XML prezentációs fájlt hoz létre.

**Menthetők az XML‑kimenetek anélkül, hogy fájlt hoznának létre a lemezen?**  
Igen. Adj át egy írható adatfolyamot a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódusnak. Például használj egy [MemoryStream](https://reference.aspose.com/slides/hu/cpp/system.io/memorystream/)‑t memóriabeli feldolgozáshoz.

**Az Aspose.Slides képes újra betölteni az exportált XML‑fájlt?**  
Nem. A PowerPoint XML Presentation jelenleg csak mentésre van támogatva, betöltésre nem. Használj PPTX‑et vagy más támogatott prezentációformátumot, ha körkörös szerkesztésre van szükség.

**Az XML‑konverzió minden diát oldal‑ vagy képként renderel?**  
Nem. Az XML‑konverzió strukturált prezentációs adatot ír. Használj PDF‑et vagy TIFF‑et oldal‑orientált kimenethez, vagy PNG‑t, JPEG‑t és SVG‑t egyedi dia‑képekhez.