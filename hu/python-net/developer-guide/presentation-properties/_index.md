---
title: Prezentáció tulajdonságok kezelése Pythonban
linktitle: Prezentáció tulajdonságok
type: docs
weight: 70
url: /hu/python-net/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságok
- dokumentum tulajdonságok
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
description: "Kezelje hatékonyan a prezentáció tulajdonságait az Aspose.Slides for Python via .NET segítségével, és egyszerűsítse a keresést, a márkázást és a munkafolyamatot PowerPoint fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípust egyszerűen el lehet érni és kezelni az Aspose.Slides API segítségével.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentumtulajdonságokkal a [DocumentProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/documentproperties/) osztályon keresztül dolgozzon. Ennek az osztálynak egy példánya a [Presentation.document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/document_properties/) tulajdonságon keresztül érhető el. A következő példák bemutatják, hogyan kell olvasni, módosítani és kezelni ezeket a tulajdonságokat.

{{% alert color="info" title="Note" %}}
Kérjük, vegye figyelembe, hogy nem állíthat be értékeket a **Application** és **Producer** mezőkben, mivel az Aspose Ltd. és az Aspose.Slides for Python via .NET x.x.x jelenik meg ezekben a mezőkben.
{{% /alert %}}

## **Prezentáció tulajdonságok kezelése**

A Microsoft PowerPoint lehetőséget biztosít néhány tulajdonság hozzáadására a prezentáció fájlokhoz. Ezek a dokumentumtulajdonságok hasznos információk tárolását teszik lehetővé a dokumentumok (prezentáció fájlok) mellett. Kétféle dokumentumtulajdonság létezik:

- Rendszer által definiált (Beépített) tulajdonságok
- Felhasználó által definiált (Egyéni) tulajdonságok

**Beépített** tulajdonságok általános információkat tartalmaznak a dokumentumról, például a dokumentum címét, a szerző nevét, a dokumentum statisztikákat stb. **Egyéni** tulajdonságok azok, amelyeket a felhasználók **Név/Érték** pároként definiálnak, ahol a név és az érték is a felhasználó által kerül meghatározásra. Az Aspose.Slides for Python via .NET használatával a fejlesztők hozzáférhetnek és módosíthatják a beépített és egyéni tulajdonságok értékeit. A Microsoft PowerPoint 2007 lehetővé teszi a prezentáció fájlok dokumentumtulajdonságainak kezelését. Csak kattintson az Office ikonra, majd a **Prepare | Properties | Advanced Properties** menüpontra a Microsoft PowerPoint 2007-ben. Miután kiválasztotta a **Advanced Properties** menüpontot, megjelenik egy párbeszédablak, amely lehetővé teszi a PowerPoint fájl dokumentumtulajdonságainak kezelését. A **Properties Dialog** ablaktáblában számos lapot láthat, például **General, Summary, Statistics, Contents and Custom**. Ezek a lapok különböző típusú információk konfigurálását teszik lehetővé a PowerPoint fájlokkal kapcsolatban. A **Custom** lapot a PowerPoint fájlok egyéni tulajdonságainak kezelésére használják.

## **Nyilvános tulajdonságok olvasása titkosított prezentációból**

A nyitó jelszó általában védi a prezentáció tartalmát és a dokumentumtulajdonságokat is. Ha egy prezentáció titkosítva van a [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) `False` értékre állítva, a dokumentumtulajdonságai nyilvánosak maradnak. Ebben az esetben az alkalmazás a [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/only_load_document_properties/) értékét `True`-ra állíthatja, és a nyilvános metaadatokat a nyitó jelszó megadása nélkül olvashatja.

`only_load_document_properties` szabályozza, hogy az Aspose.Slides mit tölt be; semmit sem titkosít fel. Ha a tulajdonságok a titkosítás részét képezik, jelszó nélkül a betöltés sikertelen. Ha a prezentáció nincs titkosítva, az opciót figyelmen kívül hagyják, és a teljes prezentáció betöltődik.

A következő példa a [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/hu/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) segítségével ellenőrzi a betöltési módot, majd a [Presentation.document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/document_properties/) segítségével olvassa a beépített tulajdonságokat:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Ebben a módban a diák tartalma nem kerül betöltésre. A diák, mester diák, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell az `is_only_document_properties_loaded` értéket, mielőtt olyan műveletet végeznek, amely a teljes prezentációs objektummodellt igényli.

{{% alert color="warning" title="Security" %}}
A nyilvános metaadatok felfedhetik a szerző nevét, címeit, témáit, kulcsszavait, vállalati információkat, megjegyzéseket és egyéni értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Csak akkor hagyja nyilvánosnak, ha az indexelés, osztályozás, keresés vagy dokumentumkezelő rendszereknek kifejezett igénye van a jelszó nélküli hozzáférésre.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a `only_load_document_properties`-vel betöltött prezentáció a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja menteni a módosított tulajdonságokat ebből a csak metaadatot tartalmazó objektumból, mivel a nyilvános tulajdonságoknak összhangban kell lenniük a titkosított prezentáción belüli megfelelő adatokkal. Ennek frissítése ezért a helyes nyitó jelszót és a teljes betöltést igényli.

A következő példa a [LoadOptions.password](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/password/) segítségével megnyitja a prezentációt, frissíti a nyilvános beépített tulajdonságokat, majd elmenti az eredményt. Ezután a [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/is_encrypted/) használatával ellenőrzi, hogy a titkosítás megmaradt-e, és jelszó nélkül újra megnyitja a nyilvános metaadatokat az új értékek ellenőrzéséhez:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Ha egy alkalmazásnak nem engedélyezett a prezentáció tartalmának visszafejtése vagy betöltése, a titkosított PPTX fájl nyilvános tulajdonságait csak olvashatóként kell kezelnie.

## **Beépített tulajdonságok elérése**

Ezeket a tulajdonságokat az **IDocumentProperties** objektum biztosítja, beleértve: **Creator(Author)**, **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Utolsó nyomtatás dátuma), **LastModifiedBy**, **Keywords**, **SharedDoc** (Megosztott több gyártó között?), **PresentationFormat**, **Subject** és **Title**.

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely a prezentációt képviseli
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Referencia létrehozása a Presentation-hez kapcsolódó objektumra
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

## **Beépített tulajdonságok módosítása**

A prezentáció fájlok beépített tulajdonságainak módosítása olyan egyszerű, mint azok elérése. Egyszerűen hozzárendelhet egy karakterlánc értéket a kívánt tulajdonsághoz, és a tulajdonság értéke módosul. Az alábbi példában bemutattuk, hogyan lehet módosítani a prezentáció fájl beépített dokumentumtulajdonságait.

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely a prezentációt képviseli
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Létrehozza a Presentation-hez kapcsolódó objektumra mutató referenciát
    documentProperties = presentation.document_properties

    # Beállítja a beépített tulajdonságokat
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Mentse a prezentációt egy fájlba
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Egyéni prezentációs tulajdonságok hozzáadása**

Az Aspose.Slides for Python via .NET lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak a prezentáció dokumentumtulajdonságaihoz. Az alábbi példában bemutatjuk, hogyan kell beállítani a prezentáció egyéni tulajdonságait.

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt
with slides.Presentation() as presentation:
    # A dokumentumtulajdonságok lekérése
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

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides for Python via .NET lehetővé teszi a fejlesztők számára, hogy hozzáférjenek az egyéni tulajdonságok értékeihez. Az alábbi példában megmutatjuk, hogyan érheti el és módosíthatja ezeket az egyéni tulajdonságokat egy prezentációban.

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely a PPTX-et képviseli
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Létrehozza a Presentation-hez kapcsolódó document_properties objektumra mutató referenciát
    documentProperties = presentation.document_properties

    # Egyéni tulajdonságok elérése és módosítása
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Egyéni tulajdonságok nevének és értékének megjelenítése
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Egyéni tulajdonságok értékének módosítása
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # prezentáció mentése egy fájlba
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` a második argumentumban átadott egyelemű listán keresztül adja vissza az értéket, és a tárolt értéket a listában már meglévő elem típusára alakítja. A fenti példában a `[""]`-t használja, így karakterlánc típusú tulajdonságokat olvas; számként tárolt tulajdonság olvasásához adjon át egy numerikus helyőrzőt, például `[0]` – ellenkező esetben a hívás `InvalidCastException`-t dob.

## **Helyesírási nyelv beállítása**

Az Aspose.Slides kínálja a `Language_Id` tulajdonságot (amelyet a [PortionFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/) osztály tesz elérhetővé), hogy beállíthassa a helyesírási nyelvet egy PowerPoint dokumentumhoz. A helyesírási nyelv azt a nyelvet jelenti, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Ez a Python kód megmutatja, hogyan állítható be a helyesírási nyelv egy PowerPoint számára:

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

## **Alapértelmezett nyelv beállítása**

Ez a Python kód megmutatja, hogyan állítható be az alapértelmezett nyelv egy teljes PowerPoint prezentációhoz:

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

A beépített tulajdonságok a prezentáció szerves részei, ezért nem távolíthatók el teljesen. Azonban megváltoztathatja értéküket, vagy ha a konkrét tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő érték felülíródik az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Hozzáférhetek a prezentáció tulajdonságaihoz anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/get_presentation_info/)‑t, majd a [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationinfo/read_document_properties/) metódust a tárolt dokumentum metaadatok olvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/python-net/examine-presentation/) oldalt egy teljes jelentési példáért és formátumspecifikus korlátozásokért.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból anélkül, hogy a nyitó jelszót meg kellene adni?**

Igen. A prezentációnak úgy kell titkosítva lennie, hogy a `encrypt_document_properties` `False` értékre legyen állítva, és `only_load_document_properties` `True` értékkel kell betölteni.

**Frissíthetek egy titkosított PPTX fájlt csak dokumentumtulajdonságok módban?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak összhangban kell maradniuk, ezért egy titkosított PPTX fájl frissítéséhez a teljes prezentációt a megfelelő nyitó jelszóval kell betölteni.