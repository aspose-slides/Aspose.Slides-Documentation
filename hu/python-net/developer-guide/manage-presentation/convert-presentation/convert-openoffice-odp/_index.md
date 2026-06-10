---
title: OpenDocument prezentációk konvertálása Pythonban
linktitle: OpenDocument konvertálása
type: docs
weight: 10
url: /hu/python-net/convert-openoffice-odp/
keywords:
- OpenDocument konvertálása
- ODP konvertálása
- ODP PDF-re
- ODP PPT-re
- ODP PPTX-re
- ODP XPS-re
- ODP HTML-re
- ODP TIFF-re
- ODP SWF-re
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "OpenDocument ODP konvertálása PDF-re, PPT-re, PPTX-re, XPS-re, HTML-re, TIFF-re vagy SWF-re Pythonban az Aspose.Slides segítségével: kód példák, nagy hűség, kötegelt konvertálás és testreszabás."
---
## **Bevezetés**

[**Aspose.Slides API**](https://products.aspose.com/slides/hu/python-net/) lehetővé teszi, hogy az OpenDocument (ODP) prezentációkat sok formátumba (HTML, PDF, TIFF, SWF, XPS, stb.) konvertálja. Az ODP fájlok más dokumentumformátumokba konvertálásához használt API ugyanaz, mint a PowerPoint (PPT és PPTX) konverziójához használt.

Például, ha ODP prezentációt PDF‑be kell konvertálni, azt a következő módon teheti:

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **GYIK**

**Átkonvertálhatom az ODP‑t PPTX‑be LibreOffice vagy OpenOffice telepítése nélkül?**  
Igen. Az Aspose.Slides egy teljesen önálló könyvtár, amely kezeli a PowerPoint és az OpenOffice formátumokat is, külső alkalmazás nélkül.

**Megnyitja és menti a jelszóval védett ODP/OTP fájlokat az Aspose.Slides?**  
Igen. [titkosított prezentációk betöltése](/slides/hu/python-net/password-protected-presentation/) lehetséges, ha megadja a jelszót, és menthet prezentációkat titkosítással és védelembeállításokkal is.

**Kinyerhetek beágyazott médiafájlokat (hang/videó) egy ODP‑ből a konvertálás előtt?**  
Igen. Az Aspose.Slides lehetővé teszi, hogy hozzáférjen és kinyerje a beágyazott [hang](/slides/hu/python-net/audio-frame/) és [videó](/slides/hu/python-net/video-frame/) fájlokat a prezentációkból, ami hasznos a konvertálás előtti feldolgozáshoz vagy különálló újrafelhasználáshoz.

**Menthetem a konvertált ODP‑t Strict Office Open XML formátumban?**  
Igen. PPTX mentésekor engedélyezhető a Strict OOXML a [mentési beállítások](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/pptxoptions/) segítségével a szigorúbb megfelelőségi követelmények teljesítéséhez.