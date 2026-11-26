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
- fejlett tulajdonságok
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
description: "Kezelje a prezentáció tulajdonságait az Aspose.Slides for Python via .NET segítségével, és egyszerűsítse a keresést, a márkajelzést és a munkafolyamatot PowerPoint fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for Python via .NET **beépített** és **egyéni** dokumentumtulajdonságokat támogat. Ezeket a tulajdonságokat a prezentáció metaadatainak olvasására és frissítésére használhatja, például a szerző, a cím és a felhasználó által meghatározott értékek esetén.

Az Aspose.Slides lehetővé teszi a prezentáció dokumentumtulajdonságok kezelését a [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) osztályon keresztül. Ennek az osztálynak egy példánya a [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) által kerül visszaadásra. Az alábbi példák bemutatják, hogyan olvashatja, módosíthatja és kezelheti ezeket a tulajdonságokat.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides a mentéskor kezeli az alkalmazás- és a gyártó metaadatait; ezek a mezők azonosítják a kimenetet létrehozó szoftvert.
{{% /alert %}}

## **Prezentációtulajdonságok kezelése**

A dokumentumtulajdonságok leíró információkat tárolnak a prezentáció tartalma mellett. Két kategóriába sorolhatók:

- **Beépített tulajdonságok** tartalmazzák a szabványos metaadatokat, például a címet, a szerzőt és a dokumentum statisztikákat.
- **Egyéni tulajdonságok** felhasználó által definiált név/érték párokat tárolnak.

Az Aspose.Slides for Python via .NET mindkét kategóriához hozzáférést biztosít. PowerPointban válassza a **File → Info → Properties → Advanced Properties** menüpontot a dokumentum metaadatainak megtekintéséhez. A párbeszédpanel információkat csoportosít fülekbe, például **Summary**, **Statistics**, **Contents** és **Custom**. Az **Custom** fül használatával kezelheti a felhasználó által definiált tulajdonságokat.

## **Nyilvános tulajdonságok olvasása titkosított prezentációból**

Az nyitó jelszó általában védi a prezentáció tartalmát és a dokumentumtulajdonságokat is. Ha egy prezentációt úgy titkosítanak, hogy a [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) **False** értékre van állítva, a dokumentumtulajdonságok nyilvánosak maradnak. Egy alkalmazás ezután a [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) **True** értékre állításával beolvashatja a nyilvános metaadatokat anélkül, hogy megadná a nyitó jelszót.

A [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) vezérli, hogy az Aspose.Slides mit tölt be; semmit nem fejti meg. Ha a tulajdonságok részei a titkosításnak, a jelszó nélkül történő betöltés meghiúsul. Ha a prezentáció nincs titkosítva, a beállítás figyelmen kívül marad, és a teljes prezentáció betöltődik.

A példa egy olyan titkosított prezentációt igényel, amelynek dokumentumtulajdonságai nyilvánosak. Ellenőrzi a betöltési módot a [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) segítségével, majd a beépített tulajdonságokat a [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) segítségével olvassa be:

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

Ebben a módban a diák tartalma nem kerül betöltésre. Diák, masterek, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem állnak rendelkezésre. Az alkalmazásoknak mindig ellenőrizniük kell a [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) értékét, mielőtt olyan műveletet hajtanának végre, amely a teljes prezentációs objektummodellt igényli.

{{% alert color="warning" title="Security" %}}
A nyilvános metaadatok felfedhetik a szerző nevét, a címeket, a tárgyakat, a kulcsszavakat, a céginformációkat, a megjegyzéseket és az egyéni értékeket. Titkosítsa a érzékeny tulajdonságokat a prezentációval együtt. Csak akkor hagyja nyilvánosra, ha indexelés, osztályozás, keresés vagy dokumentumkezelő rendszereknek kifejezett igényük van a jelszó nélküli hozzáférésre.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) által betöltött prezentáció a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja elmenteni a módosított tulajdonságokat ebből a csak metaadatokat tartalmazó objektumból, mert a nyilvános tulajdonságoknak konzisztensnek kell lenniük a titkosított prezentációban lévő adatokkal. Ennek frissítése ezért a helyes nyitó jelszó és a teljes betöltés szükséges.

A példa egy nyilvános dokumentumtulajdonságokkal rendelkező titkosított PPTX prezentációt és egy ismert nyitó jelszót igényel. A teljes prezentációt a [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) segítségével nyitja meg, frissíti a nyilvános beépített tulajdonságokat, majd elmenti az eredményt. Ezután a [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) segítségével ellenőrzi, hogy a titkosítás megmaradt-e, és jelszó nélkül újra megnyitja a nyilvános metaadatokat az új értékek ellenőrzéséhez:

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

Ha egy alkalmazás nem engedélyezi a prezentáció tartalmának visszafejtését vagy betöltését, a titkosított PPTX fájl nyilvános tulajdonságait csak olvasásra tekintheti.

## **Beépített tulajdonságok elérése**

A [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) osztály a beépített metaadatokat típusos tulajdonságokon keresztül teszi elérhetővé, többek között a [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), a [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) és a [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/) tulajdonságokat. Ez a példa egy létező prezentációt nyit meg és a konzolra írja a tárolt metaadatokat. Az értékek a bemeneti prezentációtól függnek; egyes mezők üresek lehetnek.

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

### **Revíziószám és szerkesztési idő jelentése**

A `presentations` mappában lévő minden PPTX fájl revíziószámának és teljes szerkesztési idejének jelentéséhez használja a [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) metódust, amely a [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) objektumot adja vissza a diák betöltése nélkül. A Python a `timedelta` formátumban jeleníti meg az időtartamot, beleértve a napok számát is, ha a feljegyzett idő meghaladja a 24 órát.

```python
from pathlib import Path

import aspose.slides as slides

print("File | RevisionNumber | TotalEditingTime")
for path in Path("presentations").glob("*.pptx"):
    if path.is_file():
        info = slides.PresentationFactory.instance.get_presentation_info(str(path))
        properties = info.read_document_properties()
        print(f"{path.name} | {properties.revision_number} | {properties.total_editing_time}")
```

Egy olyan prezentáció esetén, amelynek rögzített szerkesztési ideje 1 nap, 2 óra és 5 perc, a jelentés a következő sort tartalmazza.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1 day, 2:05:00
```

A [DocumentProperties.revision_number](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/revision_number/) írható metaadat. Az értéke önmagában nem határozza meg, hogy hányszor mentették a prezentációt, vagy hogy milyen a verziótörténete.

A [DocumentProperties.total_editing_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/total_editing_time/) a fájlban tárolt szerkesztési időt adja vissza. A `0:00:00` érték azt jelenti, hogy a rögzített időtartam nulla, még akkor is, ha valaki szerkesztette a prezentációt.

## **Beépített tulajdonságok módosítása**

A beépített metaadatok frissítéséhez adja meg az értékeket a [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) által biztosított írható tulajdonságoknak. Ez a példa egy meglévő prezentációt nyit meg, beállítja a [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), a [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), a [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), a [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/) és a [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/) értékeket, majd elmenti a frissített prezentációt a [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) metódussal. A mentett PPTX tartalmazza az új metaadatokat.

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

## **A Hyperlink Base kezelése**

A [DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) tárolja a dokumentumszintű alapot a relatív hiperhivatkozásokhoz. Ez akkor hasznos, ha egy prezentációt és a kapcsolódó fájlokat egy másik helyre mozgatja. Ez különálló az egyes hiperhivatkozások [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) tulajdonságától: az alap módosítása nem írja át a tárolt hivatkozáscímeket, és nem változtatja meg a abszolút célokat.

A példa egy olyan prezentációt igényel, amely tartalmaz relatív hivatkozást (például `target.html`) és egy abszolút hivatkozást egy fájlra vagy weboldalra. A meglévő alapot beolvassa, új alapcímre állítja, elmenti és újra megnyitja a prezentációt az ellenőrzéshez. Ezután az alapot `""` értékre törli, és egy külön mentett fájlban ellenőrzi az üres értéket. Cserélje ki a példa alapcímét a saját kapcsolt fájljai helyére.

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

A két ellenőrző üzenetnek `True`-t kell kiírnia. Az alap törlése nem érinti az egyes hiperhivatkozás címét.

Egy relatív hivatkozás a `target.pptx` fájlra `old/target.pptx`-t nyitott meg, amikor az alap az `old` mappára mutatott. Az alap `new` mappára történő módosítása, a mentés és a prezentáció újranyitása után ugyanaz a hivatkozás a `new/target.pptx`-t nyitja meg. Egy abszolút hivatkozás továbbra is ugyanazt a fájlt nyitja meg. Tesztelje a relatív hivatkozásokat PowerPointban a prezentáció áthelyezése vagy az alap módosítása előtt és után.

## **Egyéni prezentációtulajdonságok hozzáadása**

Az egyéni tulajdonságok olyan metaadatokat tárolnak, amelyekhez nincs megfelelő beépített mező. A [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) metódus lehetővé teszi egy érték hozzárendelését a tulajdonság nevéhez. Ez a példa egy prezentációt hoz létre, hozzáad két szöveges értéket és egy egész számú verzióértéket, majd a [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) metódussal elmenti a prezentációt. Egy meglévő névhez érték hozzárendelése felülírja az adott tulajdonság értékét.

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

Ez a példa egy olyan prezentációt nyit meg, amely egyéni tulajdonságokat tartalmaz, és a [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) segítségével iterál rajtuk. A [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) nulla alapú indexet fogad, és visszaadja a [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) által használt nevet. A példa egy olyan prezentációt igényel, amelynek minden egyéni tulajdonsága string. Minden eredeti nevet és értéket kiír, minden értéket egy számozott stringre cserél, majd elmenti a módosításokat. Ha nincsenek egyéni tulajdonságok, a ciklus nem hajt végre változtatást.

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

A [DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) a második paraméterként átadott egyelemű listán keresztül adja vissza az értéket. A helyőrzőnek meg kell egyeznie a tárolt tulajdonság típusával: használjon `[""]`-t stringhez vagy `[0]`-t egész számhoz. A típuseltérés `InvalidCastException`-t eredményez; válassza a helyőrzőt a saját egyéni‑tulajdonság‑sémája szerint.

## **Élő példa**

Próbálja ki az online alkalmazást a [**PowerPoint metaadatok megtekintése és szerkesztése**](https://products.aspose.app/slides/metadata) segítségével, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API-val:

[![PowerPoint metaadatok megtekintése és szerkesztése](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot a prezentációból?**

A beépített tulajdonságok a prezentáció integrált részét képezik, és nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket, vagy ha a konkrét tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő érték felülíródik az újjal. Nem kell előre eltávolítania vagy ellenőriznie a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti annak értékét.

**Elérhetem a prezentáció tulajdonságait anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) metódust, majd a [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) segítségével olvassa a tárolt dokumentum metaadatait anélkül, hogy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/python-net/examine-presentation/) cikket a teljes jelentés példájáért és a formátumspecifikus korlátozásokért.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból a nyitó jelszó nélkül?**

Igen. A prezentációnak úgy kell lennie titkosítva, hogy a [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) **False** értékre legyen állítva, és a betöltéskor a [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) **True** értéket kell használni.

**Frissíthetek egy titkosított PPTX fájlt csak dokumentumtulajdonság‑csak‑mód esetén?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak konzisztensnek kell maradniuk, ezért egy titkosított PPTX fájl frissítéséhez a teljes prezentációt a megfelelő nyitó jelszóval kell betölteni.