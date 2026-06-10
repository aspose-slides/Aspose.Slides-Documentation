---
title: OpenDocument prezentációk konvertálása C++-ban
linktitle: OpenDocument konvertálása
type: docs
weight: 10
url: /hu/cpp/convert-openoffice-odp/
keywords:
- ODP konvertálása
- ODP képformátumba
- ODP GIF-re
- ODP HTML-re
- ODP JPG-re
- ODP MD-re
- ODP PDF-re
- ODP PNG-re
- ODP PPT-re
- ODP PPTX-re
- ODP TIFF-re
- ODP videóra
- ODP Word-re
- ODP XPS-re
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Az Aspose.Slides for C++ lehetővé teszi, hogy egyszerűen konvertálja az ODP-t PDF, HTML és képformátumokra. Növelje C++ alkalmazásai teljesítményét gyors és pontos prezentációkonvertálással."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/hu/cpp/) lehetővé teszi az OpenDocument (ODP) prezentációk konvertálását számos formátumba (HTML, PDF, TIFF, SWF, XPS stb.). Az ODP fájlok más dokumentumformátumokra történő konvertálásához használt API ugyanaz, mint a PowerPoint (PPT és PPTX) konvertálási műveletekhez használt API.

Például, ha ODP prezentációt kell PDF-re konvertálni, azt a következő módon teheti meg:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```