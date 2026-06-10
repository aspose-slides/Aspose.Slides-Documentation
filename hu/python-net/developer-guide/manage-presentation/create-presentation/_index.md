---
title: Prezentációk létrehozása Pythonban
linktitle: Prezentáció létrehozása
type: docs
weight: 10
url: /hu/python-net/create-presentation/
keywords:
- prezentáció létrehozása
- új prezentáció
- PPT létrehozása
- új PPT
- PPTX létrehozása
- új PPTX
- ODP létrehozása
- új ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Készítsen PowerPoint prezentációkat Pythonban az Aspose.Slides segítségével – állítson elő PPT, PPTX és ODP fájlokat, élvezze az OpenDocument támogatást, és mentse őket programozottan a megbízható eredményekért."
---
## **Áttekintés**

Az Aspose.Slides for Python lehetővé teszi, hogy teljesen kódból építsünk egy vadonatúj prezentációs fájlt. Ez a cikk a legfontosabb munkafolyamatot mutatja be — egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektum létrehozását, az első dia lekérését, egy egyszerű alakzat beillesztését és az eredmény mentését — hogy láthassa, mennyire kevés beállításra van szükség egy prezentáció generálásához a Microsoft Office nélkül. Mivel ugyanaz az API képes PPT, PPTX és ODP fájlok írására, egyetlen kódbázisból célozhatja meg mind a hagyományos PowerPoint, mind az OpenDocument formátumokat. Az Aspose.Slides asztali, webes vagy szerver környezetekhez egyaránt alkalmas, így a Python alkalmazás számára hatékony kiindulási pontot biztosít a szöveg, kép vagy diagramokhoz hasonló gazdagabb tartalmak hozzáadásához, amint az első diákat elkészítette.

## **Prezentáció létrehozása**

A PowerPoint fájl nulláról történő létrehozása az Aspose.Slides for Python‑ban olyan egyszerű, mint a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztály példányosítása. A konstruktor automatikusan egy üres decket ad egyetlen diával, így azonnal rendelkezik vászonnal alakzatok, szöveg, diagramok vagy egyéb tartalmak elhelyezéséhez. Miután módosította ezt a diát — vagy újakat ad hozzá — a végeredményt mentheti PPTX, régi PPT vagy akár OpenDocument formátumba. Az alábbi rövid kódrészlet bemutatja ezt a munkafolyamatot egy egyszerű alakzat hozzáadásával az első diára.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
1. Szerezze meg a dia hivatkozását az indexe alapján.  
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) objektumot `CLOUD` típusban a `shapes` gyűjtemény által nyújtott `add_auto_shape` metódussal.  
1. Adjon szöveget az auto‑shape-hez.  
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi példában egy felhő alakzat kerül hozzáadásra a prezentáció első diasához.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:
    # Szerezze meg az első diát.
    slide = presentation.slides[0]

    # Adjon hozzá egy CLOUD típusú auto‑shape‑t.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Mentse a prezentációt PPTX fájlként.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The new presentation](new_presentation.png)

## **GYIK**

**Milyen formátumokba menthetem az új prezentációt?**  
Menthet [PPTX, PPT, and ODP](/slides/hu/python-net/save-presentation/) formátumokba, és exportálhat [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/hu/python-net/convert-powerpoint-to-xps/), [HTML](/slides/hu/python-net/convert-powerpoint-to-html/), [SVG](/slides/hu/python-net/convert-powerpoint-to-png/) és [images](/slides/hu/python-net/convert-powerpoint-to-png/) formátumokba, többek között.

**Kezdhetek sablonból (POTX/POTM), és menthetem szabályos PPTX‑ként?**  
Igen. Töltse be a sablont, és mentse a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [are supported](/slides/hu/python-net/supported-file-formats/).

**Hogyan szabályozhatom a dia méretét/méretarányát a prezentáció létrehozásakor?**  
Állítsa be a [slide size](/slides/hu/python-net/slide-size/) értékét (beleértve az előre definiált 4:3 és 16:9 arányokat vagy egyéni méreteket), és válassza ki, hogyan méreteződjön a tartalom.

**Milyen mértékegységben vannak megadva a méretek és koordináták?**  
Pontokban: 1 hüvelyk 72 egységnek felel meg.

**Hogyan kezeljem a nagyon nagy prezentációkat (sok médiával) a memóriahasználat csökkentése érdekében?**  
Használjon [BLOB management strategies](/slides/hu/python-net/manage-blob/), korlátozza a memóriában tárolt adatot ideiglenes fájlokkal, és részesítse előnyben a fájl‑alapú munkafolyamatokat a tisztán memóriában lévő stream‑ekkel szemben.

**Létrehozhatok/menthetek prezentációkat párhuzamosan?**  
Nem működik a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektum egyidejű használata [multiple threads](/slides/hu/python-net/multithreading/) esetén. Indítson külön, izolált példányokat szálanként vagy folyamatanként.

**Hogyan távolíthatom el a próbaverzió vízjelet és korlátozásokat?**  
[Apply a license](/slides/hu/python-net/licensing/) egyszer a folyamatban. A licenc XML‑nek érintetlennek kell maradnia, és a licenc beállítást szinkronizálni kell, ha több szál vesz részt.

**Aláírhatom-e digitálisan a létrehozott PPTX‑et?**  
Igen. A [Digital signatures](/slides/hu/python-net/digital-signature-in-powerpoint/) (hozzáadása és ellenőrzése) támogatott a prezentációkhoz.

**Támogatottak-e a makrók (VBA) a létrehozott prezentációkban?**  
Igen. [Create/edit VBA projects](/slides/hu/python-net/presentation-via-vba/) és a makró‑engedélyezett fájlok, például PPTM/PPSM mentése lehetséges.