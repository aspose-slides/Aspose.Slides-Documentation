---
title: Python használatával a prezentációs tulajdonságok kezelése
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
description: "Az Aspose.Slides for Python via .NET-ben a prezentációs tulajdonságok kezelésével egyszerűsítheti a keresést, a márkaépítést és a munkafolyamatot a PowerPoint fájljaiban."
---
## **Bevezetés**

Aspose.Slides for Python via .NET támogatja a **beépített** és **egyéni** dokumentumtulajdonságokat. Használja ezeket a tulajdonságokat a prezentáció metaadatainak olvasásához és frissítéséhez, például a szerző, a cím és a felhasználó által meghatározott értékek.

Aspose.Slides lehetővé teszi a prezentáció dokumentumtulajdonságokkal való munkát a [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) osztályon keresztül. Ennek az osztálynak egy példányát a [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) adja vissza. A következő példák bemutatják, hogyan olvashatók, módosíthatók és kezelhetők ezek a tulajdonságok.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides kezeli az alkalmazás- és gyártó metaadatokat a prezentációk mentésekor; ezek a mezők azonosítják a kimenetet előállító szoftvert.
{{% /alert %}}

## **A prezentáció tulajdonságainak kezelése**

A dokumentumtulajdonságok leíró információkat tárolnak a prezentáció tartalma mellett. Két kategóriába sorolhatók:

- **Beépített tulajdonságok** tartalmaznak szabványos metaadatokat, például a címet, a szerzőt és a dokumentum statisztikákat.
- **Egyéni tulajdonságok** tárolják a felhasználó által meghatározott név/érték párokat.

Az Aspose.Slides for Python via .NET hozzáférést biztosít mindkét kategóriához. A PowerPointban válassza a **File → Info → Properties → Advanced Properties** menüpontot a dokumentum metaadatainak megtekintéséhez. A párbeszédablak információkat csoportosít fülekbe, például **Összegzés**, **Statisztikák**, **Tartalom**, és **Egyéni**. Használja a **Egyéni** fület a felhasználó által meghatározott tulajdonságok kezeléséhez.

## **Nyilvános tulajdonságok olvasása egy titkosított prezentációból**

Egy megnyitási jelszó általában védi a prezentáció tartalmát és a dokumentumtulajdonságokat is. Ha egy prezentációt úgy titkosítanak, hogy a [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) `False` értékre van állítva, a dokumentumtulajdonságok nyilvánosak maradnak. Egy alkalmazás ekkor beállíthatja a [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) `True` értékre, és a nyilvános metaadatokat a megnyitási jelszó megadása nélkül olvashatja.

A [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) szabályozza, hogy az Aspose.Slides mit tölt be; semmit sem dekódol. Ha a tulajdonságok a titkosítás részét képezték, a jelszó nélkül történő betöltés sikertelen. Ha a prezentáció nincs titkosítva, a beállítást figyelmen kívül hagyja, és a teljes prezentációt betölti.

A példához egy titkosított prezentáció szükséges, amelynek a dokumentumtulajdonságai nyilvánosak maradtak. A betöltési módot a [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) ellenőrzi, majd a beépített tulajdonságokat a [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) segítségével olvassa:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Ebbe a módban a diatartalom nem kerül betöltésre. Diák, mesterdiák, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) értékét, mielőtt olyan műveletet végeznek, amely a teljes prezentációs objektummodellt igényli.

{{% alert color="warning" title="Security" %}}
A nyilvános metaadatok felfedhetik a szerző nevét, a címeket, a tárgyakat, a kulcsszavakat, a vállalati információkat, a megjegyzéseket és az egyéni értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Csak akkor hagyja őket nyilvánosan, ha indexelés, osztályozás, keresés vagy dokumentumkezelő rendszereknek speciális igényük van rá.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Egy titkosított PPTX fájl esetén a [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) használatával betöltött prezentáció csak a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja menteni a módosított tulajdonságokat ebből a csak metaadatot tartalmazó objektumból, mivel a nyilvános tulajdonságoknak összhangban kell lenniük a titkosított prezentáció megfelelő adataival. Ezért a frissítéshez a helyes megnyitási jelszó és a teljes betöltés szükséges.

A példához egy titkosított PPTX prezentáció szükséges, amelynek a dokumentumtulajdonságai nyilvánosak, valamint egy ismert megnyitási jelszó. A teljes prezentációt a [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) segítségével nyitja meg, frissíti a nyilvános beépített tulajdonságokat, és elmenti az eredményt. Ezután a [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) ellenőrzi, hogy a titkosítás megmaradt-e, és a nyilvános metaadatokat jelszó nélkül nyitja újra a új értékek ellenőrzésére:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
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

Ha egy alkalmazásnak nem engedélyezett a prezentáció tartalmának dekódolása vagy betöltése, a titkosított PPTX fájl nyilvános tulajdonságait csak olvashatóként kell kezelnie.

## **Beépített tulajdonságok elérése**

A [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) osztály a beépített metaadatokat típusos tulajdonságokon keresztül teszi elérhetővé, beleértve a [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), a [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) és a [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/) elemeket. Ez a példa egy létező prezentációt nyit meg, és a tárolt metaadatokat kiírja a konzolra. Az értékek a bemeneti prezentációtól függenek; egyes mezők üresek lehetnek.

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

## **Beépített tulajdonságok módosítása**

A beépített metaadatok frissítéséhez írható értékeket kell hozzárendelni a [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) által nyújtott tulajdonságokhoz. Ez a példa egy létező prezentációt nyit meg, beállítja a [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/) és [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/) értékeket, majd a [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) segítségével elmenti a frissített prezentációt. A mentett PPTX tartalmazni fogja az új metaadatokat.

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **A hiperhivatkozás alapjának kezelése**

A [DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) tárolja a dokumentumszintű alapot a relatív hiperhivatkozásokhoz. Ez hasznos, ha a prezentációt és a kapcsolódó fájlokat egy másik helyre mozgatja. Ez különálló az egyes hiperhivatkozások [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) értékétől: az alap módosítása nem írja felül a tárolt hivatkozási címeket, és nem változtatja meg a abszolút célpontokat.

A példához egy olyan prezentáció szükséges, amely tartalmaz egy relatív hivatkozást, például `target.html`, valamint egy abszolút hivatkozást egy fájlra vagy weboldalra. A példa beolvassa a meglévő alapot, új alapcímre állítja, majd elmenti és újra megnyitja a prezentációt az érték ellenőrzéséhez. Ezután `""`-vel törli az alapot, és egy külön mentett fájlban ellenőrzi az üres értéket. Cserélje ki a példában szereplő alapcímet a saját kapcsolt fájljai helyére.

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

A két ellenőrző üzenetnek `True` értéket kell kiírnia. Az alap törlése megtartja az egyes hiperhivatkozás címeket.

Egy relatív hivatkozás a `target.pptx`-hez `old/target.pptx`-t nyitott meg, amikor az alap a `old` mappára mutatott. Az alap `new` mappára történő módosítása, a mentés és a prezentáció újbóli megnyitása után ugyanaz a hivatkozás `new/target.pptx`-t nyitott meg. Egy abszolút hivatkozás továbbra is ugyanazt a fájlt nyitotta. Tesztelje a relatív hivatkozásait a PowerPointban a prezentáció áthelyezése vagy az alap módosítása előtt és után.

## **Egyéni prezentációtulajdonságok hozzáadása**

Az egyéni tulajdonságok olyan metaadatot tárolnak, amelyhez nincs megfelelő beépített mező. A [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) metódus lehetővé teszi, hogy a tulajdonságnév alapján értéket rendeljünk. Ez a példa egy prezentációt hoz létre, hozzáad két szöveges értéket és egy egész számú verzióértéket, majd a [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) segítségével elmenti a prezentációt. Egy meglévő névhez érték hozzárendelése felülírja a tulajdonság értékét.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Egyéni tulajdonságok elérése és módosítása**

Ez a példa egy olyan prezentációt nyit meg, amely egyéni tulajdonságokat tartalmaz, és a [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) segítségével iterál rajtuk. A [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) nulla alapú indexet fogad, és visszaadja a [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) által használt nevet. A példa egy olyan prezentációt feltételez, amelyben az egyéni tulajdonságok mind stringek. Kiírja minden eredeti nevet és értéket, minden értéket számozott sztringgel helyettesíti, és elmenti a változásokat. Ha nincsenek egyéni tulajdonságok, a ciklus nem hajt végre változtatást.

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

A [DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) visszaadja az értéket a második argumentumként átadott egyelemes listán keresztül. A helyőrzőnek meg kell egyeznie a tárolt tulajdonság típusával: használjon `[""]`‑t stringhez vagy `[0]`‑t egész számhoz. A nem megfelelő típus `InvalidCastException`-t okoz; válassza a helyőrzőt a saját egyéni tulajdonság‑sémája szerint.

## **Élő példa**

Próbálja ki a [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) online alkalmazást, hogy megismerje, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API használatával:

[![Nézet és szerkesztés PowerPoint metaadatok](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban megváltoztathatja értékeiket, vagy ha a konkrét tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha egy már létező egyéni tulajdonságot adok hozzá?**

Ha egy már létező egyéni tulajdonságot ad hozzá, a meglévő érték felül lesz írva az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Hozzáférhetek a prezentáció tulajdonságaihoz a teljes prezentáció betöltése nélkül?**

Igen. Használja a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) és aztán a [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) metódusokat a tárolt dokumentum metaadatok olvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) példányt hozna létre. Lásd a [Könnyű prezentációs leltár készítése](/slides/hu/python-net/examine-presentation/) cikket a teljes jelentési példához és a formátumspecifikus korlátozásokhoz.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból a megnyitási jelszó nélkül?**

Igen. A prezentációt úgy kell titkosítani, hogy a [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) `False` értékre legyen állítva, és a betöltéskor a [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) `True` legyen.

**Frissíthetek egy titkosított PPTX fájlt csak dokumentumtulajdonságok módjában?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak összhangban kell lenniük, ezért egy titkosított PPTX fájl frissítéséhez a teljes prezentációt a helyes megnyitási jelszóval kell betölteni.