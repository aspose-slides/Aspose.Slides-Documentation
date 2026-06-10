---
title: PPTX konvertálása PPT‑vé Pythonban
linktitle: PPTX PPT-re
type: docs
weight: 21
url: /hu/python-net/convert-pptx-to-ppt/
keywords:
- PPTX PPT-re
- PPTX konvertálása PPT-re
- PowerPoint konvertálása
- prezentáció konvertálása
- Python
- Aspose.Slides
description: "Az Aspose.Slides for Python .NET-en keresztül könnyedén konvertálja a PPTX-et PPT‑vé – biztosítva a PowerPoint formátumok zökkenőmentes kompatibilitását, miközben megőrzi a bemutató elrendezését és minőségét."
---
## **Áttekintés**

Aspose.Slides for Python lehetővé teszi, hogy a modern PPTX bemutatókat kódból konvertálja a régi PPT formátumba. Nyisson meg egy PPTX-et, és exportálja PPT‑ként, miközben megőrzi a bemutató tartalmát és elrendezését, így az eredmény kompatibilis a régebbi PowerPoint verziókkal. Ugyanez a munkafolyamat más kimeneteket is előállíthat – például PDF, XPS, ODP, HTML vagy képek – így zökkenőmentesen beilleszthető szkriptekbe, CI csővezetékekbe és kötegelt feldolgozásba.

## **PPTX átalakítása PPT‑vé**

A PPTX PPT‑vé konvertálásához egyszerűen adja meg a fájlnevet és a mentési formátumot a [save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/save/) metódusnak a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályban. Az alábbi Python példa az alapértelmezett beállításokkal alakítja át a bemutatót PPTX‑ből PPT‑vé.

```py
import aspose.slides as slides

# Hozzon létre egy Presentation osztálypéldányt, amely egy PPTX fájlt képvisel.
presentation = slides.Presentation("presentation.pptx")

# Mentse a bemutatót PPT fájlként.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **GYIK**

**Megmaradnak-e minden PPTX hatás és funkció a régi PPT (97–2003) formátumba mentéskor?**

Nem mindig. A PPT formátum nem tartalmazza a legújabb képességeket (például bizonyos hatásokat, objektumokat és viselkedéseket), ezért a funkciók egyszerűsödhetnek vagy raszterizálódhatnak a konvertálás során.

**Konvertálhatok csak kiválasztott diákat PPT‑vé a teljes bemutató helyett?**

A közvetlen mentés az egész bemutatót célozza. Kiválasztott diák konvertálásához hozza létre egy új bemutatót csak ezekkel a diákokkal, és mentse PPT‑ként; alternatívaként használjon olyan szolgáltatást/API‑t, amely per-diapontú konvertálási paramétereket támogat.

**Támogatottak-e a jelszóval védett bemutatók?**

Igen. Felismerheti, ha egy fájl védett, megnyithatja jelszóval, és a mentett PPT‑hez is [configure protection/encryption settings](/slides/hu/python-net/password-protected-presentation/) konfigurálható.

**Lásd még:**
- [Convert PPT & PPTX to PDF in Python | Advanced Options](/slides/hu/python-net/convert-powerpoint-to-pdf/)
- [Convert PowerPoint Presentations to XPS in Python](/slides/hu/python-net/convert-powerpoint-to-xps/)
- [Convert PowerPoint Presentations to HTML in Python](/slides/hu/python-net/convert-powerpoint-to-html/)
- [Convert PowerPoint Slides to PNG in Python](/slides/hu/python-net/convert-powerpoint-to-png/)