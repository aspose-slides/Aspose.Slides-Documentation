---
title: Prezentáció tulajdonságok kezelése Pythonban
linktitle: Prezentáció tulajdonságok
type: docs
weight: 70
url: /hu/python-java/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságok
- dokumentum tulajdonságok
- beépített tulajdonságok
- egyedi tulajdonságok
- haladó tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- ellenőrző nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Mestere a prezentáció tulajdonságoknak az Aspose.Slides for Python via Java-ban, és egyszerűsíti a keresést, a márkázást és a munkafolyamatot a PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for Python via Java támogatja a **beépített** és **egyedi** dokumentumtulajdonságokat. Ezeket a tulajdonságokat használhatja a bemutató metaadatainak olvasására és frissítésére, például a szerző, a cím és a felhasználó által megadott értékek esetén.

Az Aspose.Slides lehetővé teszi a bemutató dokumentumtulajdonságokkal való munkát a [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) osztályon keresztül. Ennek az osztálynak egy példánya a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) hívásával kapható vissza. A következő példák bemutatják, hogyan lehet ezeket a tulajdonságokat olvasni, módosítani és kezelni.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides kezeli az alkalmazás és a gyártó metaadatait a bemutatók mentésekor; ezek a mezők azonosítják a kimenetet előállító szoftvert.
{{% /alert %}}

## **A bemutató tulajdonságainak kezelése**

A dokumentumtulajdonságok leíró információkat tárolnak a bemutató tartalma mellett. Két kategóriába sorolhatók:

- **Beépített tulajdonságok** szabványos metaadatokat tartalmaznak, például a címet, a szerzőt és a dokumentumstatisztikákat.
- **Egyedi tulajdonságok** felhasználó által meghatározott név/érték párokat tárolnak.

Az Aspose.Slides for Python via Java hozzáférést biztosít mindkét kategóriához. PowerPointban válassza a **File → Info → Properties → Advanced Properties** menüpontot a dokumentum metaadatainak megtekintéséhez. A párbeszédablak információkat csoportosít fülekre, mint a **Summary**, **Statistics**, **Contents** és **Custom**. Az **Custom** fül használatával kezelheti a felhasználó által definiált tulajdonságokat.

## **Nyilvános tulajdonságok olvasása titkosított bemutatóból**

A nyitó jelszó általában a bemutató tartalmát és a dokumentumtulajdonságokat is védi. Ha a bemutatót a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) `False` értékkel történő meghívása után titkosítják, a dokumentumtulajdonságok nyilvánosak maradnak. Egy alkalmazás ekkor a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `True` értékkel hívhatja meg, és a nyitó jelszó megadása nélkül olvashatja a nyilvános metaadatokat.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) szabályozza, hogy az Aspose.Slides mit tölt be; nem hajt végre semmilyen dekódolást. Ha a tulajdonságok a titkosítás részei voltak, a jelszó nélkül történő betöltés meghiúsul. Ha a bemutató nincs titkosítva, az opció figyelmen kívül marad, és a teljes bemutató betöltődik.

A példa egy titkosított bemutatót igényel, amelynek a dokumentumtulajdonságai nyilvánosak maradtak. A betöltési módot a [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) segítségével ellenőrzi, majd a beépített tulajdonságokat a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) segítségével olvassa:

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

Ebben a módban a dia tartalma nem töltődik be. A diák, mesterdiák, elrendezések, alakzatok, média és egyéb bemutatóobjektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) állapotát, mielőtt olyan műveletet végeznek, amely a teljes bemutató objektummodellt igényli.

{{% alert color="warning" title="Warning" %}}
A nyilvános metaadatok felfedhetik a szerző neveit, címeket, tárgyakat, kulcsszavakat, vállalati információkat, megjegyzéseket és egyedi értékeket. Titkosítsa az érzékeny tulajdonságokat a bemutatóval együtt. Csak akkor hagyja nyilvánosnak, ha indexelés, besorolás, keresés vagy dokumentumkezelő rendszereknek kifejezett igényük van a jelszó nélküli hozzáférésre.
{{% /alert %}}

## **Titkosított bemutató tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `True` értékkel történő meghívása után betöltött bemutató csak a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja menteni a módosított tulajdonságokat ebből a kizárólag metaadatokat tartalmazó objektumból, mivel a nyilvános tulajdonságoknak összhangban kell lenniük a titkosított bemutató megfelelő adataival. Ennek frissítése ezért a megfelelő nyitó jelszót és a teljes betöltést igényli.

A példa egy titkosított PPTX bemutatót igényel, amelynek a dokumentumtulajdonságai nyilvánosak, és egy ismert nyitó jelszóval rendelkezik. A teljes bemutatót a [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword) segítségével nyitja meg, frissíti a nyilvános beépített tulajdonságokat, és elmenti az eredményt. Ezután a [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) használatával ellenőrzi, hogy a titkosítás megmaradt-e, és a jelszó nélkül újra megnyitja a nyilvános metaadatokat az új értékek ellenőrzéséhez:

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

Ha egy alkalmazás nem engedélyezett a bemutató tartalmának dekódolására vagy betöltésére, akkor a titkosított PPTX fájl nyilvános tulajdonságait csak olvasási módban kell kezelnie.

## **Beépített tulajdonságok elérése**

A [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) osztály getter metódusokkal teszi elérhetővé a beépített metaadatokat, többek között a [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) és a [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime) metódusokkal. Ez a példa megnyit egy meglévő bemutatót, és a tárolt metaadatait a konzolra írja ki. Az értékek a bemeneti bemutatótól függenek; egyes mezők üresek lehetnek.

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

## **Beépített tulajdonságok módosítása**

A beépített metaadatok frissítéséhez használja a setter metódusokat a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) által visszaadott objektumon. Ez a példa megnyit egy meglévő bemutatót, meghívja a [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) és [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager) metódusokat, majd a [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) segítségével elmenti a frissített bemutatót. A mentett PPTX a új metaadatokat tartalmazza.

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

## **A hiperhivatkozás alapjának kezelése**

A [DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) visszaadja a dokumentumszintű alapot a relatív hiperhivatkozásokhoz. A [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) használatával módosítható vagy törölhető ez az alap. Hasznos, ha egy bemutatót és a hozzá kapcsolódó fájlokat más helyre helyezi. Ez különálló az egyes hiperhivatkozások [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) metódusától: az alap módosítása nem írja felül a tárolt hivatkozási címeket, és nem változtatja meg az abszolút célokat.

A példa olyan bemutatót igényel, amely tartalmaz egy relatív hivatkozást, például `target.html`, valamint egy abszolút hivatkozást, például `https://example.org/absolute.html`. Kiolvassa a meglévő alapot, új alapcímre állítja, majd elmenti és újra megnyitja a bemutatót az érték ellenőrzéséhez. Ezután egy üres karakterlánccal törli az alapot, és egy külön mentett fájlban ellenőrzi az üres értéket. Cserélje le a példában szereplő alapcímet a saját hivatkozott fájljai helyére.

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

A két ellenőrző üzenetnek `True` értéket kell kiírnia. Az alap törlése nem érinti az egyes hiperhivatkozások címét.

Egy relatív hivatkozás a `target.pptx` fájlra az `old/target.pptx`-t nyitotta meg, amikor az alap az `old` mappára mutatott. Az alap `new` mappára való módosítása, a mentés és a bemutató újbóli megnyitása után ugyanaz a hivatkozás a `new/target.pptx`-t nyitotta meg. Egy abszolút hivatkozás továbbra is ugyanazt a fájlt nyitotta meg. Tesztelje a relatív hivatkozásait a PowerPointban a bemutató áthelyezése vagy az alap megváltoztatása előtt és után.

## **Egyedi bemutatótulajdonságok hozzáadása**

Az egyedi tulajdonságok olyan metaadatokat tárolnak, amelyeknek nincs megfelelő beépített mezője. A [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) metódus lehetővé teszi a tulajdonság nevének megadásával történő érték hozzárendelését. Ez a példa létrehoz egy bemutatót, hozzáad két szöveges értéket és egy egész verzióértéket (a `jpype.JInt` használatával Java egész szám átadásához), majd a [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) segítségével elmenti a bemutatót. Egy meglévő névhez érték hozzárendelése felülírja a tulajdonság értékét.

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

## **Egyedi tulajdonságok elérése és módosítása**

Ez a példa megnyit egy olyan bemutatót, amely egyedi tulajdonságokat tartalmaz, és a [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) segítségével iterálja őket. A [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) nulla-alapú indexet fogad és visszaadja a [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) által használt nevet. A példa kiírja minden eredeti nevet és értéket, minden értéket egy számozott karakterláncra cserél az eredeti típusától függetlenül, és elmenti a változtatásokat. Ha nincsenek egyedi tulajdonságok, a ciklus nem hajt végre változtatást.

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

## **Élő példa**

Próbálja ki a [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) online alkalmazást, hogy lássa, hogyan lehet a dokumentumtulajdonságokkal dolgozni az Aspose.Slides API használatával:

[![PowerPoint metaadatok megtekintése és szerkesztése](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy bemutatóból?**

A beépített tulajdonságok a bemutató integrált részét képezik, és nem távolíthatók el teljesen. Azonban megváltoztathatja az értékeiket, vagy ha a konkrét tulajdonság engedi, beállíthatja őket üresnek.

**Mi történik, ha olyan egyedi tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyedi tulajdonságot ad hozzá, amely már létezik, a meglévő értéke felülíródik az újjal. Nem szükséges a tulajdonságot előzetesen eltávolítani vagy ellenőrizni, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Elérhetem a bemutató tulajdonságait anélkül, hogy teljesen betölteném a bemutatót?**

Igen. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) és ezután a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) metódusokat, hogy a tárolt dokumentum metaadatait olvassa anélkül, hogy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/python-java/examine-presentation/) példát a teljes jelentéskészítési példa és a formátumspecifikus korlátozások megtekintéséhez.

**Olvashatok nyilvános tulajdonságokat egy titkosított bemutatóból a nyitó jelszó nélkül?**

Igen. A bemutatónak úgy kell titkosítva lennie, hogy a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) `False` értékkel lett meghívva, és a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `True` értékkel történő meghívása után lett betöltve.

**Frissíthetek egy titkosított PPTX fájlt csak a dokumentumtulajdonságok módjában?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak összhangban kell maradniuk, ezért egy titkosított PPTX fájl frissítéséhez a teljes bemutatót a megfelelő nyitó jelszóval kell betölteni.