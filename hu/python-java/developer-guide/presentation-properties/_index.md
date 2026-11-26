---
title: Prezentációs tulajdonságok kezelése Pythonban
linktitle: Prezentációs Tulajdonságok
type: docs
weight: 70
url: /hu/python-java/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentációs tulajdonságok
- dokumentum tulajdonságok
- beépített tulajdonságok
- egyedi tulajdonságok
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
description: "Mester szintű prezentációs tulajdonságok kezelése az Aspose.Slides for Python via Java használatával, és a keresés, márkaépítés és munkafolyamat optimalizálása PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for Python via Java **beépített** és **egyedi** dokumentumtulajdonságokat támogat. Ezeket a tulajdonságokat a prezentáció metaadatainak, például a szerző, cím és felhasználó által definiált értékek olvasására és frissítésére használhatja.

Az Aspose.Slides a prezentáció dokumentumtulajdonságokkal a [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) osztályon keresztül dolgozik. Ennek egy példányát a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) adja vissza. Az alábbi példák bemutatják, hogyan lehet ezeket a tulajdonságokat olvasni, módosítani és kezelni.

{{% alert color="info" title="Note" %}}

Az Aspose.Slides a mentett prezentációk esetén kezeli az alkalmazás- és a készítői metaadatokat; ezek a mezők azonosítják a kimenetet előállító szoftvert.

{{% /alert %}}

## **Prezentáció Tulajdonságainak Kezelése**

A dokumentumtulajdonságok leíró információkat tárolnak a prezentáció tartalma mellett. Két kategóriába sorolhatók:

- **Beépített tulajdonságok** szabványos metaadatokat tartalmaznak, mint a cím, szerző és a dokumentum statisztikái.
- **Egyedi tulajdonságok** felhasználó által definiált név/érték párokat tárolnak.

Az Aspose.Slides for Python via Java mindkét kategóriához hozzáférést biztosít. PowerPointban válassza a **Fájl → Információk → Tulajdonságok → Speciális Tulajdonságok** menüpontot a dokumentum metaadatainak megtekintéséhez. A párbeszédpanel a **Összefoglalás**, **Statisztikák**, **Tartalom** és **Egyedi** fülekre osztja az információkat. Az **Egyedi** fülön kezelheti a felhasználó által definiált tulajdonságokat.

## **Nyilvános Tulajdonságok Olvasása Titkosított Prezentációból**

A megnyitási jelszó általában a prezentáció tartalmát és a dokumentumtulajdonságokat is védi. Ha egy prezentációt a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) `False` értékkel titkosítanak, a dokumentumtulajdonságok nyilvánosak maradnak. Ezután egy alkalmazás a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `True` értékével olvashatja a nyilvános metaadatokat a megnyitási jelszó megadása nélkül.

A [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) arra szabja az Aspose.Slides betöltését; semmit sem titkosít fel. Ha a tulajdonságok részei voltak a titkosításnak, a jelszó nélküli betöltés meghiúsul. Ha a prezentáció nincs titkosítva, a beállítás figyelmen kívül marad, és a teljes prezentáció betöltődik.

A példa egy olyan titkosított prezentációt igényel, amelynek dokumentumtulajdonságai nyilvánosak maradtak. Ellenőrzi a betöltési módot a [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) segítségével, majd a beépített tulajdonságokat a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) olvassa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

Ebben a módban a diák tartalma nem töltődik be. A diák, mesteroldalak, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) értékét, mielőtt olyan műveletet végeznének, amely a teljes prezentációs objektummodellt igényli.

{{% alert color="warning" title="Warning" %}}
A nyilvános metaadatok felfedhetik a szerző neveit, címeket, tárgyakat, kulcsszavakat, céginformációkat, megjegyzéseket és egyedi értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Csak akkor hagyja nyilvánosan, ha indexelés, osztályozás, keresés vagy dokumentumkezelő rendszereknek konkrétan szükségük van rá jelszó nélkül.
{{% /alert %}}

## **Titkosított Prezentáció Tulajdonságainak Frissítése**

Egy titkosított PPTX fájl esetén a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `True` értékű hívása után betöltött prezentáció csak a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja menteni a megváltozott tulajdonságokat ebből a metaadat‑csak objektumból, mert a nyilvános tulajdonságoknak meg kell egyezniük a titkosított prezentáció megfelelő adataival. Frissítésükhöz a helyes megnyitási jelszó és a teljes betöltés szükséges.

A példa egy nyilvános dokumentumtulajdonságokkal rendelkező titkosított PPTX prezentációt és egy ismert megnyitási jelszót igényel. A teljes prezentációt a [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword) segítségével nyitja meg, frissíti a nyilvános beépített tulajdonságokat, majd elmenti az eredményt. Ezután a [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) ellenőrzi, hogy a titkosítás megmaradt‑e, és a nyilvános metaadatot jelszó nélkül újra megnyitja az új értékek ellenőrzéséhez:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

Ha egy alkalmazás nem engedélyezett a prezentáció tartalmának dekódolására vagy betöltésére, a titkosított PPTX fájl nyilvános tulajdonságait csak olvashatóként kell kezelni.

## **Beépített Tulajdonságok Elérése**

A [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) osztály getter metódusokon keresztül hozza elérhetővé a beépített metaadatokat, többek között a [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), a [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) és a [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime) metódusokat. Ez a példa egy meglévő prezentációt nyit meg, és a konzolra írja a tárolt metaadatokat. Az értékek a bemeneti prezentációtól függenek; egyes mezők üresek lehetnek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

### **Revíziószám és Szerkesztési Idő Jelentése**

A `presentations` mappában lévő minden PPTX fájlhoz egy sort jelentve, használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) és a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) metódusokat a [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) beolvasásához a diák betöltése nélkül. A Python via Java API ezredmásodpercben adja vissza a szerkesztési időtartamot. A példa ezt órákra, percekre és másodpercekre formázza, 24 óra vagy annál hosszabb időtartam esetén napokkal együtt.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

factory = PresentationFactory.getInstance()
print("File | RevisionNumber | TotalEditingTime")
for path in sorted(Path("presentations").glob("*.pptx")):
    if not path.is_file():
        continue

    info = factory.getPresentationInfo(str(path))
    properties = info.readDocumentProperties()
    total_seconds = int(properties.getTotalEditingTime()) // 1000
    days, remaining_seconds = divmod(total_seconds, 86400)
    hours, remaining_seconds = divmod(remaining_seconds, 3600)
    minutes, seconds = divmod(remaining_seconds, 60)
    editing_time = f"{hours:02d}:{minutes:02d}:{seconds:02d}"
    if days:
        editing_time = f"{days}.{editing_time}"

    print(f"{path.name} | {properties.getRevisionNumber()} | {editing_time}")
```

Egy olyan prezentáció esetén, amelynek szerkesztési ideje 1 nap, 2 óra és 5 perc, a jelentés a következő kimenetet mutatja.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

A [getRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getRevisionNumber) olyan értéket olvas, amelyet a [setRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setRevisionNumber) módosíthat. A revíziószám önmagában nem határozza meg, hányszor lett a prezentáció mentve, vagy nem állítja helyre annak verziótörténetét.

A [getTotalEditingTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTotalEditingTime) a fájlban tárolt szerkesztési időtartamot adja vissza. A `00:00:00` érték azt jelenti, hogy a tárolt idő nulla, még akkor is, ha valaki szerkesztette a prezentációt.

## **Beépített Tulajdonságok Módosítása**

A beépített metaadatok frissítéséhez használja a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) által visszaadott objektum setter metódusait. Ez a példa egy meglévő prezentációt nyit meg, meghívja a [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), a [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), a [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), a [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) és a [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager) metódusokat, majd a [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) segítségével menti a frissített prezentációt. A mentett PPTX tartalmazza az új metaadatokat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hipernév Alapkezelése**

A [DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) visszaadja a dokumentumszintű alapot a relatív hiperhivatkozásokhoz. A [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) segítségével módosíthatja vagy törölheti azt. Ez akkor hasznos, ha egy prezentációt és a hozzá tartozó fájlokat egy másik helyre mozgatja. Ez különálló az egyes hiperhivatkozások [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) metódusától: az alap módosítása nem írja át a tárolt hivatkozáscímeket, illetve nem változtatja meg az abszolút célpontot.

A példa egy olyan prezentációt igényel, amely tartalmaz egy relatív hivatkozást, például `target.html`, és egy abszolút hivatkozást, például `https://example.org/absolute.html`. A meglévő alapot beolvassa, beállít egy új alapcímét, majd menti és újra megnyitja a prezentációt az érték ellenőrzésére. Ezután egy üres karakterlánccal törli az alapot, és egy külön fájlban ellenőrzi az üres értéket. Cserélje ki a példában szereplő alapcímét a saját hivatkozási fájljai helyére.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

A két ellenőrző üzenetnek **True**‑nak kell kiíródnia. Az alap törlése nem érinti az egyes hiperhivatkozás címeket.

Egy relatív hivatkozás a `target.pptx` fájlra a `old/target.pptx`‑t nyitja meg, amikor az alap a `old` mappára mutat. Az alap `new` mappára változtatása, mentés és újranyitás után ugyanaz a hivatkozás a `new/target.pptx`‑t nyitja meg. Egy abszolút hivatkozás továbbra is ugyanazt a fájlt nyitja. Tesztelje a relatív hivatkozásait PowerPointban a prezentáció mozgatása vagy az alap módosítása előtt és után.

## **Egyedi Prezentációs Tulajdonságok Hozzáadása**

Az egyedi tulajdonságok olyan metaadatot tárolnak, amelynek nincs megfelelő beépített mezője. A [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) metódus lehetővé teszi egy érték hozzárendelését a tulajdonság nevével. Ez a példa létrehoz egy prezentációt, két szöveges és egy egész verzióértéket (a `jpype.JInt` segítségével Java egész szám átadásához) ad hozzá, majd a [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) metódussal menti a prezentációt. Egy már létező névhez egy érték hozzárendelése felülírja a korábbi értéket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Egyedi Tulajdonságok Elérése és Módosítása**

Ez a példa egy olyan prezentációt nyit meg, amely egyedi tulajdonságokat tartalmaz, és a [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) segítségével iterálja őket. A [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) nulla‑alapú indexet fogad, és visszaadja a [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) által használt nevet. A példa minden eredeti nevet és értéket kiír, minden értéket egy sorszámozott szöveggé cserél, függetlenül az eredeti típusától, majd elmenti a módosításokat. Ha nincsenek egyedi tulajdonságok, a ciklus nem hajt végre változtatást.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Élő Példa**

Próbálja ki az online alkalmazást **[View & Edit PowerPoint Metadata](https://products.aspose.app/slides/metadata)**, hogy megismerje a dokumentumtulajdonságok kezelését az Aspose.Slides API-val:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot a prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, ezért nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket, vagy ha a konkrét tulajdonság engedi, üresre állíthatja őket.

**Mi történik, ha már létező egyedi tulajdonságot adok hozzá?**

Ha már létező egyedi tulajdonságot ad hozzá, a meglévő értéke felül lesz írva az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**El tudom-e érni a prezentáció tulajdonságait anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust, majd a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) segítségével olvassa a tárolt dokumentum metaadatait anélkül, hogy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) példányt hozna létre. Lásd a **[Build a Lightweight Presentation Inventory](/slides/hu/python-java/examine-presentation/)** cikket a teljes jelentési példáért és a formátumspecifikus korlátozásokért.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból anélkül, hogy a megnyitási jelszót ismerném?**

Igen. A prezentációt a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) `False` értékű hívása után kell titkosítani, és a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `True` értékével kell betölteni.

**Frissíthetek egy titkosított PPTX fájlt csak dokumentumtulajdonság‑only módban?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak konzisztensnek kell maradniuk, ezért egy titkosított PPTX fájl frissítéséhez a teljes prezentációt a helyes megnyitási jelszóval kell betölteni.