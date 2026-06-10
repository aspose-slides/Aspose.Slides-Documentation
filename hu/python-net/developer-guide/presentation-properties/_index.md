---
title: Prezentációtulajdonságok kezelése Pythonban
linktitle: Prezentációtulajdonságok
type: docs
weight: 70
url: /hu/python-net/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentációtulajdonságok
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
description: "Kezelje a prezentációtulajdonságokat az Aspose.Slides for Python via .NET segítségével, és egyszerűsítse a keresést, a márkázást és a munkamenetet a PowerPoint fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípust könnyen elérheti és kezelheti az Aspose.Slides API használatával.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentumtulajdonságokkal a [DocumentProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/) osztályon keresztül dolgozzon. Ennek az osztálynak egy példánja a [Presentation.document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/document_properties/) tulajdonságon keresztül érhető el. Az alábbi példák bemutatják, hogyan olvashat, módosíthat és kezelhet ezeket a tulajdonságokat.

{{% alert color="primary" %}} 
Kérjük, vegye figyelembe, hogy a **Application** és **Producer** mezők értékét nem állíthatja be, mivel az Aspose Ltd. és az Aspose.Slides for Python via .NET x.x.x értékek jelennek meg ezekben a mezőkben.
{{% /alert %}} 

## **Prezentációtulajdonságok kezelése**

A Microsoft PowerPoint lehetővé teszi bizonyos tulajdonságok hozzáadását a prezentációs fájlokhoz. Ezek a dokumentumtulajdonságok hasznos információk tárolását teszik lehetővé a dokumentumokkal (prezentációs fájlokkal) együtt. Kétféle dokumentumtulajdonság létezik:

- Rendszer által definiált (Beépített) tulajdonságok
- Felhasználó által definiált (Egyéni) tulajdonságok

A **Beépített** tulajdonságok általános információkat tartalmaznak a dokumentumról, például a dokumentum címét, a szerző nevét, a dokumentum statisztikáit stb. A **Egyéni** tulajdonságok olyanok, amelyeket a felhasználók **Név/Érték** párokként definiálnak, ahol a név és az érték egyaránt a felhasználó által megadott. Az Aspose.Slides for Python via .NET használatával a fejlesztők hozzáférhetnek és módosíthatják a beépített és az egyéni tulajdonságok értékeit is. A Microsoft PowerPoint 2007 lehetővé teszi a prezentációs fájlok dokumentumtulajdonságainak kezelését. Csak kattintson az Office ikonra, majd a **Prepare | Properties | Advanced Properties** menüpontra a Microsoft PowerPoint 2007-ben. Miután kiválasztja a **Advanced Properties** menüpontot, megjelenik egy párbeszédablak, amely a PowerPoint‑fájl dokumentumtulajdonságainak kezelését teszi lehetővé. A **Properties Dialog** ablakban számos fület láthat, például **General, Summary, Statistics, Contents** és **Custom**. Ezek a fülek különböző információk konfigurálását teszik lehetővé a PowerPoint‑fájlokhoz. A **Custom** fül a PowerPoint‑fájlok egyéni tulajdonságainak kezelésére szolgál.

## **Beépített tulajdonságok elérése**

Ezeket a tulajdonságokat, amelyeket az **IDocumentProperties** objektum mutat, a következők tartalmazzák: **Creator(Author)**, **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **Keywords**, **SharedDoc** (Megosztva van‑e különböző termelők között?), **PresentationFormat**, **Subject** és **Title**.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely a prezentációt reprezentálja
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Hozzon létre egy hivatkozást a Presentation-hez kapcsolódó objektumra
    documentProperties = pres.document_properties

    # Mutassa ki a beépített tulajdonságokat
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

## **Beépített tulajdonságok módosítása**

A prezentációs fájlok beépített tulajdonságainak módosítása ugyanolyan egyszerű, mint azok elérése. Egyszerűen egy karakterlánc értéket rendelhet bármely kívánt tulajdonsághoz, és a tulajdonság értéke módosul. Az alábbi példában bemutattuk, hogyan módosíthatjuk a prezentációs fájl beépített dokumentumtulajdonságait.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely a Prezentációt reprezentálja
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Hozzon létre egy hivatkozást a Presentation-hez kapcsolódó objektumra
    documentProperties = presentation.document_properties

    # Állítsa be a beépített tulajdonságokat
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Mentse a prezentációt egy fájlba
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Egyéni prezentációtulajdonságok hozzáadása**

Az Aspose.Slides for Python via .NET lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak a prezentáció dokumentumtulajdonságaihoz. Az alábbi példa bemutatja, hogyan állíthatók be az egyéni tulajdonságok egy prezentációhoz.

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

    # Tulajdonság nevének lekérése adott indexen
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Kiválasztott tulajdonság eltávolítása
    documentProperties.remove_custom_property(getPropertyName)

    # Prezentáció mentése
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides for Python via .NET lehetővé teszi a fejlesztők számára, hogy hozzáférjenek az egyéni tulajdonságok értékeihez. Az alábbi példa bemutatja, hogyan érheti el és módosíthatja az összes egyéni tulajdonságot egy prezentációban.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely a PPTX-et képviseli
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Hozzon létre egy hivatkozást a Presentation-hez kapcsolódó document_properties objektumra
    documentProperties = presentation.document_properties

    # Egyéni tulajdonságok elérése és módosítása
    for i in range(documentProperties.count_of_custom_properties):
        # Egyéni tulajdonságok nevének és értékének megjelenítése
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Egyéni tulajdonságok értékeinek módosítása
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # Mentse a prezentációt egy fájlba
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Helyesírási nyelv beállítása**

Az Aspose.Slides a `Language_Id` tulajdonságot (amelyet a [PortionFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/) osztály biztosít) biztosítja, hogy beállíthassa a helyesírási nyelvet egy PowerPoint‑dokumentumhoz. A helyesírási nyelv az a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Az alábbi Python‑kód megmutatja, hogyan állítható be a helyesírási nyelv egy PowerPoint‑ban:

```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # set the Id of a proofing language
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Alapértelmezett nyelv beállítása**

Az alábbi Python‑kód megmutatja, hogyan állítható be az alapértelmezett nyelv egy teljes PowerPoint‑prezentációhoz:

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

## **Élő példa**

Próbálja ki a [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan lehet a dokumentumtulajdonságokkal dolgozni az Aspose.Slides API‑n keresztül:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket, vagy ha a konkrét tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő érték felül lesz írva az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Hozzáférhetek a prezentáció tulajdonságaihoz anélkül, hogy teljesen betölteném a prezentációt?**

Igen, a prezentáció tulajdonságaihoz hozzáférhet anélkül, hogy a teljes prezentációt betöltené, a [get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/) metódus használatával a [PresentationFactory](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/) osztályból. Ezután a [PresentationInfo](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/) osztály [read_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/read_document_properties/) metódusával olvashatja a tulajdonságokat hatékonyan, így memória takarít meg és javítja a teljesítményt.