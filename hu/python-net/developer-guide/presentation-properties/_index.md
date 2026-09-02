---
title: Prezentációs tulajdonságok kezelése Pythonban
linktitle: Prezentációs tulajdonságok
type: docs
weight: 70
url: /hu/python-net/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentációs tulajdonságok
- dokumentumtulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- haladó tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- helyesírási nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Mesterműként kezelje a prezentációs tulajdonságokat az Aspose.Slides for Python via .NET segítségével, és egyszerűsítse a keresést, a márkaépítést és a munkafolyamatot PowerPoint fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípust könnyedén elérheti és kezelheti az Aspose.Slides API segítségével.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentumtulajdonságokkal a [DocumentProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/) osztályon keresztül dolgozzon. Ennek az osztálynak egy példánya a [Presentation.document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/document_properties/) tulajdonságon keresztül érhető el. A következő példák bemutatják, hogyan olvashatja, módosíthatja és kezelheti ezeket a tulajdonságokat.

{{% alert color="info" title="Megjegyzés" %}}
Kérjük, vegye figyelembe, hogy a **Application** és **Producer** mezők értékét nem állíthatja be, mivel az Aspose Ltd. és az Aspose.Slides for Python via .NET x.x.x megjelenik ezekben a mezőkben.
{{% /alert %}} 

## **Prezentáció Tulajdonságok Kezelése**

A Microsoft PowerPoint lehetővé teszi, hogy néhány tulajdonságot hozzáadjon a prezentáció fájlokhoz. Ezek a dokumentumtulajdonságok lehetővé teszik, hogy hasznos információkat tároljunk a dokumentumokkal (prezentáció fájlok). Kétféle dokumentumtulajdonság létezik:

- Rendszer által definiált (Beépített) Tulajdonságok
- Felhasználó által definiált (Egyéni) Tulajdonságok

**Beépített** tulajdonságok általános információkat tartalmaznak a dokumentumról, mint például a dokumentum címe, a szerző neve, a dokumentum statisztikái és így tovább. **Egyéni** tulajdonságok azok, amelyeket a felhasználók **Név/Érték** párok formájában definiálnak, ahol mind a név, mind az érték a felhasználó által van megadva. Az Aspose.Slides for Python via .NET segítségével a fejlesztők hozzáférhetnek és módosíthatják a beépített és az egyéni tulajdonságok értékeit. A Microsoft PowerPoint 2007 lehetővé teszi a prezentáció fájlok dokumentumtulajdonságainak kezelését. Ehhez csak a Microsoft PowerPoint 2007 Office ikonra kell kattintani, majd a **Prepare | Properties | Advanced Properties** menüpontot kiválasztani. A **Advanced Properties** menüpont kiválasztása után egy párbeszédablak jelenik meg, amely lehetővé teszi a PowerPoint fájl dokumentumtulajdonságainak kezelését. A **Properties Dialog**‑ban több fülnél is látható, például **General, Summary, Statistics, Contents and Custom**. Ezek a fülek különböző információk konfigurálását teszik lehetővé a PowerPoint fájlokhoz. A **Custom** fül az egyéni tulajdonságok kezelésére szolgál.

## **Beépített Tulajdonságok Elérése**
Ezeket a tulajdonságokat a **IDocumentProperties** objektum teszi elérhetővé, többek között: **Creator(Author)**, **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Utolsó nyomtatás dátuma), **LastModifiedBy**, **Keywords**, **SharedDoc** (Megosztott különböző készítők között?), **PresentationFormat**, **Subject** és **Title**
```py
import aspose.slides as slides

# Példányosítsa a prezentációt képviselő Presentation osztályt
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Hozzon létre egy hivatkozást a Presentation-hez kapcsolódó objektumra
    documentProperties = pres.document_properties

    # A beépített tulajdonságok megjelenítése
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **Beépített Tulajdonságok Módosítása**

A beépített tulajdonságok módosítása a prezentáció fájlokban olyan egyszerű, mint azok elérése. Egyszerűen hozzárendelhet egy karakterlánc értéket a kívánt tulajdonsághoz, és a tulajdonság értéke módosul. Az alább bemutatott példában azt mutatjuk be, hogyan módosíthatja a prezentáció fájl beépített dokumentumtulajdonságait.
```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely a Presentation-t képviseli
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Hozzon létre egy hivatkozást a Presentation-hez kapcsolódó objektumra
    documentProperties = presentation.document_properties

    # Állítsa be a beépített tulajdonságokat
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Mentse el a prezentációt egy fájlba
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Egyéni Prezentációs Tulajdonságok Hozzáadása**

Az Aspose.Slides for Python via .NET lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak hozzá a prezentáció dokumentumtulajdonságokhoz. Az alábbi példa bemutatja, hogyan állítható be egyéni tulajdonság egy prezentációhoz.
```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt
with slides.Presentation() as presentation:
    # Dokumentumtulajdonságok lekérése
    documentProperties = presentation.document_properties

    # Egyéni tulajdonságok hozzáadása
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Tulajdonság nevének lekérése adott indexnél
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Kiválasztott tulajdonság eltávolítása
    documentProperties.remove_custom_property(getPropertyName)

    # Prezentáció mentése
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Egyéni Tulajdonságok Elérése és Módosítása**

Az Aspose.Slides for Python via .NET lehetővé teszi a fejlesztők számára, hogy hozzáférjenek az egyéni tulajdonságok értékeihez. Az alábbi példa megmutatja, hogyan érheti el és módosíthatja ezeket az egyéni tulajdonságokat egy prezentációban.
```py
import aspose.slides as slides

# Példányosítsa a PPTX-et reprezentáló Presentation osztályt
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Hozzon létre hivatkozást a Presentation-hez kapcsolódó document_properties objektumra
    documentProperties = presentation.document_properties

    # Egyéni tulajdonságok elérése és módosítása
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Egyéni tulajdonságok neveinek és értékeinek megjelenítése
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Egyéni tulajdonságok értékeinek módosítása
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Mentse el a prezentációt egy fájlba
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` visszaadja az értéket a második argumentumként átadott egyelemes listán keresztül, és a tárolt érték a listában már meglévő elem típusára lesz átkonvertálva. A fenti példa `[""]`-t használ, így karakterlánc tulajdonságokat olvas; egy számként tárolt tulajdonság olvasásához adjon át numerikus helykitöltőt, például `[0]` — ellenkező esetben `InvalidCastException` kivételt kap.

## **Helyesírási Nyelv Beállítása**

Az Aspose.Slides biztosítja a `Language_Id` tulajdonságot (amelyet a [PortionFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/) osztály tesz közzé), hogy beállíthassa a helyesírási nyelvet egy PowerPoint dokumentumhoz. A helyesírási nyelv az a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Ez a Python‑kód megmutatja, hogyan állítható be a helyesírási nyelv egy PowerPoint‑ban:
```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # állítsa be a helyesírási nyelv azonosítóját
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Alapértelmezett Nyelv Beállítása**

Ez a Python‑kód megmutatja, hogyan állítható be az alapértelmezett nyelv egy teljes PowerPoint‑prezentációhoz:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **Élő Példa**

Próbálja ki a [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API‑n keresztül:

[![PowerPoint metaadatok megtekintése és szerkesztése](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## **Gyakran Ismételt Kérdések**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, ezért nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket, vagy (ha az adott tulajdonság engedi) üresre állíthatja őket.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő érték felül lesz írva az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti annak értékét.

**Elérhetem a prezentáció tulajdonságait a prezentáció teljes betöltése nélkül?**

Igen. Használja a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/) metódust, majd a [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/read_document_properties/) metódust a tárolt dokumentumadatok olvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/python-net/examine-presentation/) oldalt egy teljes jelentési példáért és a formátumspecifikus korlátozásokért.