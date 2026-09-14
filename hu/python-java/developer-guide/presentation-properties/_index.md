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
description: "Művelje a prezentáció tulajdonságait az Aspose.Slides for Python via Java segítségével, és gyorsítsa fel a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides kétféle dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípus könnyen elérhető és kezelhető az Aspose.Slides API segítségével.

Az Aspose.Slides lehetővé teszi, hogy a bemutató dokumentumtulajdonságokkal a [DocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/) osztályon keresztül dolgozzon. Ennek az osztálynak egy példányát a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getDocumentProperties) adja vissza. Az alábbi példák bemutatják, hogyan lehet ezeket a tulajdonságokat beolvasni, módosítani és kezelni.

{{% alert color="info" title="Megjegyzés" %}}
Kérjük, vegye figyelembe, hogy a **Application** és **AppVersion** mezőket nem lehet módosítani. Az Aspose.Slides minden mentéskor felülírja ezeket, így egy mentett bemutató mindig "Aspose.Slides for Java"-t és a létrehozó könyvtár verzióját jelzi. A [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#setNameOfApplication) hívásakor megadott értéket a bemutató írásakor eldobja.
{{% /alert %}}

## **PowerPoint dokumentumtulajdonságok**

A Microsoft PowerPoint 2007 lehetővé teszi a bemutató fájlok dokumentumtulajdonságainak kezelését. Kattintson az Office ikonra, és válassza a **Prepare | Properties | Advanced Properties** menüpontot, ahogyan az alább látható:

|**Az Advanced Properties menüpont kiválasztása**|
| :- |
|![PowerPoint dokumentumtulajdonságok](https://i.imgur.com/ZrmuCD6.jpg)|

Az **Advanced Properties** kiválasztása után egy párbeszédablak jelenik meg, ahol a PowerPoint fájl dokumentumtulajdonságait kezelheti:

|**Tulajdonságok párbeszédablak**|
| :- |
|![PowerPoint dokumentumtulajdonságok](https://i.imgur.com/LibmdQd.jpg)|

A **Properties Dialog** tartalmazza a **General**, **Summary**, **Statistics**, **Contents** és **Custom** füleket. Ezek a fülek lehetővé teszik a PowerPoint fájlok különféle információinak beállítását. Az **Custom** fület használja egyéni tulajdonságok kezeléséhez.

## **Dokumentumtulajdonságok kezelése az Aspose.Slides for Python via Java használatával**

Ahogy korábban leírtuk, az Aspose.Slides for Python via Java mind a **Beépített**, mind az **Egyéni** dokumentumtulajdonságokat támogatja. A [DocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/) osztály egy bemutatófájlhoz kapcsolódó dokumentumtulajdonságokat képviseli.

Használja a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getDocumentProperties) metódust ezeknek a tulajdonságoknak a eléréséhez az alább leírt módon.

## **Nyilvános tulajdonságok olvasása titkosított bemutatóból**

Általában a megnyitási jelszó védi a bemutató tartalmát és a dokumentumtulajdonságokat is. Ha egy bemutatót a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) metódusnak `false` értéket adva titkosítanak, a dokumentumtulajdonságok nyilvánosak maradnak. Ezután egy alkalmazás a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) metódusnak `true` értéket adva a nyilvános metaadatokat a megnyitási jelszó megadása nélkül olvashatja.

A dokumentumtulajdonságok csak betöltése opció meghatározza, mit tölt be az Aspose.Slides; semmit nem dekódol. Ha a tulajdonságok a titkosítás részei voltak, jelszó nélkül a betöltés hibát eredményez. Ha a bemutató nincs titkosítva, az opció figyelmen kívül marad és a teljes bemutató betöltődik.

Az alábbi példa a [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) segítségével ellenőrzi a betöltési módot, majd a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getDocumentProperties) segítségével beolvassa a beépített tulajdonságokat:

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

Ebben a módban a diatartalom nem töltődik be. Diák, mesterdiák, elrendezések, alakzatok, média és egyéb bemutatóobjektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hu/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) metódust, mielőtt olyan műveletet hajtanának végre, amely a teljes bemutató objektummodellt igényli.

{{% alert color="warning" title="Figyelmeztetés" %}}
Nyilvános metaadatok felfedhetik a szerző neveit, címeket, tárgyakat, kulcsszavakat, vállalati információkat, megjegyzéseket és egyéni értékeket. Titkosítsa az érzékeny tulajdonságokat a bemutatóval együtt. Csak olyan esetekben hagyja nyilvánosan, amikor indexelés, osztályozás, keresés vagy dokumentumkezelő rendszereknek konkrétan jelszó nélkül kell hozzáférniük.
{{% /alert %}}

## **Titkosított bemutató tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a dokumentumtulajdonságok csak betöltése módban betöltött bemutató a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja elmenteni a módosított tulajdonságokat ebből a csak metaadatokat tartalmazó objektumból, mert a nyilvános tulajdonságoknak összhangban kell lenniük a titkosított bemutatóban lévő megfelelő adatokkal. Ennek frissítése ezért a helyes megnyitási jelszót és a teljes betöltést igényli.

Az alábbi példa a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setPassword) használatával nyitja meg a bemutatót, frissíti a nyilvános beépített tulajdonságokat, és elmenti az eredményt. Ezután a [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#isEncrypted) segítségével ellenőrzi, hogy a titkosítás megmaradt‑e, és jelszó nélkül újra megnyitja a nyilvános metaadatokat az új értékek ellenőrzéséhez:

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

Ha egy alkalmazásnak nincs joga a bemutató tartalmát dekódolni vagy betölteni, a titkosított PPTX fájl nyilvános tulajdonságait csak olvashatóként kell kezelnie.

## **Beépített tulajdonságok elérése**

A [DocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/) által kínált beépített tulajdonságok: **Creator** (Szerző), **Description**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **Keywords**, **SharedDoc** (Megosztott több készítő között?), **PresentationFormat**, **Subject**, és **Title**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Példányosítsa a Presentation osztályt, amely a bemutatót képviseli
presentation = Presentation("Presentation.pptx")
try:
    # Hozzon létre hivatkozást a Presentation-hez kapcsolódó DocumentProperties objektumra
    properties = presentation.getDocumentProperties()

    # Jelenítse meg a beépített tulajdonságokat
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Beépített tulajdonságok módosítása**

A beépített tulajdonságok módosítása ugyanolyan egyszerű, mint elérésük. Használja a megfelelő setter‑t az új érték hozzárendeléséhez. Az alábbi példa módosítja a beépített dokumentumtulajdonságokat az Aspose.Slides for Python via Java használatával.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Hozzon létre hivatkozást a Presentation-hez kapcsolódó DocumentProperties objektumra
    properties = presentation.getDocumentProperties()

    # Állítsa be a beépített tulajdonságokat
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Mentse el a bemutatót egy fájlba
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ez a példa módosítja a bemutató beépített tulajdonságait, amely az alábbiak szerint tekinthető meg:

|**Beépített dokumentumtulajdonságok módosítás után**|
| :- |
|![PowerPoint dokumentumtulajdonságok](https://i.imgur.com/zz1N9de.jpg)|

## **Egyéni dokumentumtulajdonságok hozzáadása**

Az Aspose.Slides for Python via Java lehetővé teszi a fejlesztők számára, hogy egyéni dokumentumtulajdonságokat adjanak a bemutatókhoz. Az alábbi példa három egyéni tulajdonságot ad hozzá, majd a 2‑es indexen tárolt nevet keresve eltávolítja azt a tulajdonságot, így a mentett bemutató kettőt tartalmaz. Az egyéni tulajdonságok betűrendben vannak indexelve, nem a hozzáadásuk sorrendjében.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Dokumentum tulajdonságok lekérése
    properties = presentation.getDocumentProperties()

    # Egyéni tulajdonságok hozzáadása
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Tulajdonság nevének lekérése egy adott indexen
    property_name = properties.getCustomPropertyName(2)

    # Kiválasztott tulajdonság eltávolítása
    properties.removeCustomProperty(property_name)

    # Bemutató mentése
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Hozzáadott egyéni dokumentumtulajdonságok**|
| :- |
|![PowerPoint dokumentumtulajdonságok](https://i.imgur.com/HdKcxI9.png)|

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides for Python via Java lehetővé teszi a fejlesztők számára, hogy hozzáférjenek az egyéni tulajdonságok értékeihez. Az alábbi példa bemutatja, hogyan lehet elérni és módosítani az összes egyéni tulajdonságot egy bemutatóban.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Hozzon létre hivatkozást a Presentation-hez kapcsolódó DocumentProperties objektumra
    properties = presentation.getDocumentProperties()

    # Egyéni tulajdonságok elérése és módosítása
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Az egyéni tulajdonságok neveinek és értékeinek megjelenítése
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Az egyéni tulajdonságok értékeinek módosítása
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Mentse el a bemutatót egy fájlba
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ez a példa módosítja a [PPTX](https://docs.fileformat.com/presentation/pptx/) bemutató egyéni tulajdonságait. Az alábbi ábrák a bemutató egyéni tulajdonságait mutatják módosítás előtt és után:

|**Egyéni tulajdonságok módosítás előtt**|
| :- |
|![PowerPoint dokumentumtulajdonságok](https://i.imgur.com/Ze7YHvi.jpg)|

|**Egyéni tulajdonságok módosítás után**|
| :- |
|![PowerPoint dokumentumtulajdonságok](https://i.imgur.com/Tofu0CL.jpg)|

## **Haladó dokumentumtulajdonságok**

{{% alert color="info" title="Megjegyzés" %}}
Új módszerek: [readDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) és [writeBindedPresentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) lettek hozzáadva a [PresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/) osztályhoz, és a [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hu/python-java/aspose.slides/documentproperties/#setLastSavedTime) metódus viselkedése megváltozott.
{{% /alert %}}

A két új módszer, a [readDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#readDocumentProperties) és a [updateDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), a [PresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/) osztályhoz lett hozzáadva. Gyors hozzáférést biztosítanak a dokumentumtulajdonságokhoz, és lehetővé teszik a tulajdonságok módosítását anélkül, hogy a teljes bemutatót betöltenék.

A tulajdonságok betöltése, értékeik módosítása és a dokumentum frissítése a következő módon valósítható meg:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Olvassa be a bemutató információit
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Szerezze meg a jelenlegi tulajdonságokat
properties = presentation_info.readDocumentProperties()

# Állítsa be az Author és Title mezők új értékeit
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Frissítse a bemutatót az új értékekkel
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

Létezik egy másik mód is, amelyben egy adott bemutató tulajdonságait sablonként használva frissíthetőek a tulajdonságok más bemutatókban:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

Új sablont lehet üresen létrehozni, majd több bemutató frissítésére használni:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **Helyesírási nyelv beállítása**

Az Aspose.Slides biztosítja a [PortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/#setLanguageId) metódust, amellyel beállíthatja a helyesírási nyelvet egy PowerPoint dokumentumhoz. A helyesírási nyelv az a nyelv, amelynek helyesírását és nyelvtanát a bemutató ellenőrzi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # a helyesírási nyelv azonosítójának beállítása

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Alapértelmezett nyelv beállítása**

Ez a Python kód megmutatja, hogyan állíthatja be az alapértelmezett nyelvet egy teljes PowerPoint bemutatóhoz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # Hozzáad egy téglalap alakzatot szöveggel
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # Ellenőrzi az első rész nyelvét
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Élő példa**

Próbálja ki a [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API-n keresztül:

[![PowerPoint metaadatok megtekintése és szerkesztése](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy bemutatóból?**

A beépített tulajdonságok a bemutató szerves részei, és teljesen nem távolíthatók el. Azonban megváltoztathatja értéküket, vagy ha a konkrét tulajdonság engedi, üresre állíthatja őket.

**Mi történik, ha egy már létező egyéni tulajdonságot adok hozzá?**

Ha egy már létező egyéni tulajdonságot ad hozzá, a meglévő érték fel lesz írva az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti annak értékét.

**Hozzáférhetek a bemutató tulajdonságaihoz anélkül, hogy teljesen betölteném a bemutatót?**

Igen. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust, majd a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationinfo/#readDocumentProperties) metódust a tárolt dokumentum metaadatok beolvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/python-java/examine-presentation/) cikket a teljes jelentéspélda és a formátumspecifikus korlátozások miatt.

**Olvashatok nyilvános tulajdonságokat egy titkosított bemutatóból a megnyitási jelszó nélkül?**

Igen. A dokumentumtulajdonságok titkosításának le kell lennie tiltva, mielőtt a bemutatót titkosítják, és a bemutatót dokumentumtulajdonságok csak betöltése módban kell betölteni.

**Frissíthetek egy titkosított PPTX fájlt dokumentumtulajdonságok csak betöltése módban?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak összhangban kell maradniuk, ezért egy titkosított PPTX fájl frissítése a teljes bemutató helyes megnyitási jelszóval való betöltését igényli.