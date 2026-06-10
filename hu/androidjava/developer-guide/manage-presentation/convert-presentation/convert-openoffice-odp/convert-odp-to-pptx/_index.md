---
title: ODP konvertálása PPTX-re Androidon
linktitle: ODP PPTX-re
type: docs
weight: 10
url: /hu/androidjava/convert-odp-to-pptx/
keywords:
- OpenDocument konvertálása
- prezentáció konvertálása
- dia konvertálása
- ODP konvertálása
- OpenDocument PPTX-re
- ODP PPTX-re
- ODP mentése PPTX-ként
- ODP exportálása PPTX-be
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "ODP konvertálása PPTX-re az Aspose.Slides for Android segítségével. Tiszta Java kódpéldák, kötegelt tippek és magas minőségű eredmények – nincs szükség PowerPoint-ra."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet egy ODP prezentációt PPTX formátumba konvertálni az Aspose.Slides segítségével.

## **ODP konvertálása PPTX/PPT prezentációvá**
Az Aspose.Slides for Android via Java egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályt kínál, amely egy prezentációs fájlt képvisel. A [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztály most már az ODP-t is eléri a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) konstruktoron keresztül, amikor az objektum példányosítva van. Az alábbi példa bemutatja, hogyan lehet egy ODP prezentációt PPTX prezentációvá konvertálni.

```java
// Az ODP fájl megnyitása
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Az ODP prezentáció mentése PPTX formátumba
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Élő példa**
Látogass el az [**Aspose.Slides Conversion**](https://products.aspose.app/slides/hu/conversion/) webalkalmazásra, amely az **Aspose.Slides API**-val készült. Az alkalmazás bemutatja, hogyan valósítható meg az ODP → PPTX konverzió az Aspose.Slides API segítségével.

## **GYIK**

**Szükséges-e telepíteni a Microsoft PowerPoint vagy a LibreOffice programot az ODP PPTX formátumba konvertálásához?**

Nem. Az Aspose.Slides önállóan működik, és nem igényel harmadik féltől származó alkalmazásokat az ODP/PPTX olvasásához vagy írásához.

**A mesterdiák, elrendezések és témák megmaradnak a konverzió során?**

Igen. A könyvtár egy teljes prezentációs objektummodellt használ, és megőrzi a struktúrát, beleértve a mesterdiákat és az elrendezéseket, így a dizájn a konverzió után is helyes marad.

**Konvertálhatok jelszóval védett ODP fájlokat?**

Igen. Az Aspose.Slides képes észlelni a védelmet, megnyitni és kezelni a [védett prezentációkat](/slides/hu/androidjava/password-protected-presentation/) (beleértve az ODP-t), ha megadod a jelszót, valamint konfigurálni a titkosítást és a dokumentum tulajdonságaihoz való hozzáférést.

**Alkalmas-e az Aspose.Slides felhő- vagy REST-alapú konverziós szolgáltatásokhoz?**

Igen. Használhatod a helyi könyvtárat a saját háttérrendszeredben vagy az [Aspose.Slides Cloud](https://products.aspose.cloud/slides/hu/family/) (REST API) szolgáltatást; mindkét lehetőség támogatja az ODP → PPTX konverziót.