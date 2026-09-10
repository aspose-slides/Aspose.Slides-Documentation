---
title: Správa tagů a vlastních dat v prezentacích pomocí Pythonu
linktitle: Tagy a vlastní data
type: docs
weight: 300
url: /cs/python-java/managing-tags-and-custom-data/
keywords:
- vlastnosti dokumentu
- tag
- vlastní data
- vlastní XML
- vlastní XML část
- XML metadata
- ItemId
- přidat tag
- párové hodnoty
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak spravovat tagy a vlastní XML data v prezentacích PowerPoint pomocí Aspose.Slides pro Python prostřednictvím Javy, včetně přidávání, čtení, aktualizace, auditu a odstraňování vlastních XML částí."
---
## **Přehled**

Tento článek vysvětluje, jak Aspose.Slides pracuje s tagy a vlastními daty v prezentacích PowerPoint. Data specifická pro prezentaci lze uložit jako tagy nebo vlastní XML části. Tagy jsou jednoduché páry klíč‑hodnota ve formě řetězců, zatímco vlastní XML části mohou ukládat strukturovaná metadata a aplikací specifické XML užitečné informace.

Aspose.Slides poskytuje rozhraní API pro přidávání, čtení, aktualizaci, audit a odstraňování vlastních XML částí na úrovni prezentace, snímku i tvaru. Vlastní XML části jsou užitečné pro integrace, které ukládají informace jako identifikátory správy dokumentů, stav pracovního postupu, metadata souladu, data pro vazbu na šablonu nebo jiné strukturované aplikační údaje uvnitř prezentace.

## **Ukládání dat v souborech prezentací**

Soubory PPTX – soubory s příponou `.pptx` – jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Office Open XML definuje strukturu balíčku a vztahy používané k ukládání obsahu prezentace a souvisejících dat.

Prezentace obsahuje více částí propojených vztahy. Například část snímku obsahuje obsah jednoho snímku a může mít explicitní vztahy k dalším částem definovaným v normě ISO/IEC 29500.

Vlastní data lze uložit jako tagy ([TagCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tagcollection/)) nebo vlastní XML části ([CustomXmlPartCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpartcollection/)). Obě jsou dostupné prostřednictvím třídy [CustomData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customdata/).

{{% alert color="info" title="Note" %}}
Tagy ukládají jednoduché řetězcové páry klíč‑hodnota. Vlastní XML části ukládají strukturovaná XML data a mohou být asociovány s prezentací, snímkem nebo tvarem.
{{% /alert %}}

## **Práce s vlastními XML částmi**

Metoda [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customdata/#getCustomXmlParts) vrací kolekci vlastních XML částí přiřazených konkrétnímu objektu prezentace. Například:

- Kolekce [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customdata/#getCustomXmlParts) prezentace obsahuje vlastní XML části přiřazené samotné prezentaci.
- Kolekce [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customdata/#getCustomXmlParts) snímku obsahuje vlastní XML části přiřazené konkrétnímu snímku.
- Kolekce [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customdata/#getCustomXmlParts) tvaru obsahuje vlastní XML části přiřazené konkrétnímu tvaru.

Použijte [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getAllCustomXmlParts), když potřebujete prozkoumat všechny vlastní XML části v prezentaci bez ohledu na to, ke kterému objektu jsou přiřazeny.

### **Přidání vlastní XML části do prezentace**

Použijte [CustomXmlPartCollection.add](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpartcollection/#add) k přidání XML dat do kolekce vlastní XML části. XML musí být platné a nesmí být prázdné.

Následující příklad přidává strukturovaná metadata do kolekce vlastních dat na úrovni prezentace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add přiřazuje identifikátor automaticky. Nastavte konkrétní UUID jen v případě potřeby.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metoda [add](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpartcollection/#add) může také přijímat XML jako pole bajtů nebo vstupní proud, což je užitečné, pokud je XML obsah již k dispozici v binární podobě.

### **Přidání vlastní XML části do snímku nebo tvaru**

Vlastní XML data lze přiřadit konkrétnímu snímku nebo tvaru místo celé prezentace. To je užitečné, když metadata popisují jen jeden objekt, například klíč šablony, externí identifikátor záznamu nebo informace o vazbě.

Následující příklad přidává jednu vlastní XML část do snímku a další do tvaru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Úroveň, na které je část přidána, určuje, která kolekce [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customdata/#getCustomXmlParts) obsahuje vztah k této části. Data na úrovni prezentace jsou vhodná pro metadata celého dokumentu, data na úrovni snímku pro informace, které patří konkrétnímu snímku, a data na úrovni tvaru pro metadata svázaná s jednotlivým tvarem.

### **Výpis a audit všech vlastních XML částí**

Použijte [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getAllCustomXmlParts) k načtení všech vlastních XML částí z prezentace. Každý [CustomXmlPart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/) expose svůj identifikátor, XML obsah a související schémata jmenných prostorů.

Následující příklad vypisuje všechny vlastní XML části a jejich schémata jmenných prostorů:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

Metoda [CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) vrací XML schémata spojená s vlastní XML částí. Tato informace může být užitečná při auditu prezentací, které obsahují XML vytvořené externími systémy.

### **Čtení a aktualizace XML obsahu a ItemId**

Použijte [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#getXmlAsString) a [setXmlAsString](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#setXmlAsString) k práci s XML jako řetězcem UTF‑8, nebo [getXmlData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#getXmlData) a [setXmlData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#setXmlData) k práci s původními bajty XML.

Metoda [CustomXmlPart.getItemId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#getItemId) vrací UUID, který identifikuje vlastní XML část v dokumentu Office Open XML. Použijte [setItemId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#setItemId), když integrace vyžaduje nový identifikátor.

Následující příklad aktualizuje XML obsah a identifikátor:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # Přečtěte aktuální XML jako text.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # Aktualizujte XML jako řetězec UTF-8.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData poskytuje stejný obsah XML jako surové bajty.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # Nahraďte identifikátor, pokud to vyžaduje integrace.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

Při volání [setXmlAsString](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#setXmlAsString) nebo [setXmlData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#setXmlData) poskytujte platné, ne‑prázdné XML. Použijte buďto jeden nebo druhý způsob v závislosti na tom, zda aplikace pracuje hlavně s řetězci nebo s bajtovými daty.

### **Odstranění vlastní XML části**

Aspose.Slides nabízí několik způsobů, jak odstranit vlastní XML data:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#remove) odstraňuje vlastní XML část z prezentace.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpartcollection/#remove) odstraňuje konkrétní část z kolekce vlastní XML části.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpartcollection/#removeAt) odstraňuje část na zadaném indexu kolekce.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpartcollection/#clear) odstraňuje všechny části z konkrétní kolekce.

Následující příklad odstraňuje jednu vlastní XML část na úrovni prezentace pomocí reference:

```python
import jpase
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pokud již máte [CustomXmlPart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/) a chcete odstranit tuto část z prezentace místo adresování konkrétní kolekce, zavolejte [CustomXmlPart.remove](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#remove).

Můžete také odstranit položku podle indexu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **Vymazání všech vlastní XML částí z kolekce**

Použijte [clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpartcollection/#clear), když je potřeba odstranit všechny vlastní XML části přiřazené konkrétnímu objektu prezentace.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpartcollection/#clear) ovlivňuje jen vybranou kolekci. Například vymazání kolekce snímku nevymaže kolekce na úrovni prezentace ani tvaru.

Pro odstranění každé vlastní XML části v prezentaci iterujte přes [getAllCustomXmlParts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getAllCustomXmlParts) a odstraňte každou část:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Zpracování propojených nebo sdílených vlastní XML částí**

V prezentaci Office Open XML může být stejná vlastní XML část odkazována z více objektů prezentace. Například existující soubor může obsahovat vztahy z více snímků nebo tvarů na stejnou podkladovou vlastní XML část.

Sdílenou část je třeba považovat za jeden datový objekt s více odkazy:

- Aktualizace pomocí [setXmlAsString](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#setXmlData) nebo [setItemId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#setItemId) mění podkladovou vlastní XML část, takže změna se projeví všude, kde je část odkazována.
- [getItemId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#getItemId) lze použít k identifikaci stejné vlastní XML části při auditu kolekcí na úrovni objektu.
- Odstranění části z konkrétní kolekce [getCustomXmlParts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customdata/#getCustomXmlParts) ji odstraní jen z této kolekce. Použijte [CustomXmlPart.remove](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#remove), když má být část samotná odstraněna z prezentace.
- Před smazáním nebo nahrazením sdílené části prozkoumejte kolekce na úrovni objektu, abyste zjistili, zda ji stále odkazují jiné snímky nebo tvary.

Přetížení [add](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpartcollection/#add) vytváří novou vlastní XML část z XML obsahu; nepřijímají existující [CustomXmlPart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/). Proto se sdílené vztahy nejčastěji vyskytují při načítání prezentací, které je již obsahují.

Následující příklad auditu kolekcí na úrovni prezentace, snímku a tvaru podle `ItemId` a výpisu částí odkazovaných z více míst:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

Tento typ auditu je užitečný před úpravou nebo smazáním vlastních XML dat v prezentacích vytvořených externími systémy, protože stejná metadata mohou být součástí více vztahů.

## **Získání hodnot tagů**

V Slides odpovídá tag metodě [DocumentProperties.getKeywords](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#getKeywords). Tento ukázkový kód ukazuje, jak získat hodnotu tagu pomocí Aspose.Slides pro Python via Java pro [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **Přidání tagů do prezentací**

Aspose.Slides umožňuje přidávat tagy do prezentací. Tag obvykle sestává ze dvou položek:

- názvu vlastnosti, například `MyTag`;
- hodnoty vlastnosti, například `My Tag Value`.

Pokud potřebujete klasifikovat prezentace podle konkrétního pravidla nebo vlastnosti, můžete přidat tagy pro tento účel. Například pokud chcete kategorizovat prezentace ze zemí Severní Ameriky, můžete vytvořit tag pro Severní Ameriku a přiřadit jako hodnotu příslušnou zemi.

Tento ukázkový kód ukazuje, jak přidat tag do [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) pomocí Aspose.Slides pro Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

Tagy lze také nastavit pro [Slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

Nebo pro jednotlivý [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **Omezení**

Tagy přidané přes kolekci [CustomData.getTags](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customdata/#getTags) jsou uloženy jen v souboru PowerPoint. **Nejsou** přenášeny do struktury tagů PDF při exportu prezentace do PDF. V důsledku toho nelze z PDF souboru získat vlastní identifikátor uložený jako tag.

**Obcházení**: můžete uložit vlastní identifikátor do **Alt Text** objektu (například [Shape.setAlternativeText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#setAlternativeText) s hodnotou `"MyId"`). Po exportu do PDF se Alt Text může objevit ve struktuře tagů PDF.

## **Často kladené otázky**

**Mohu odstranit všechny tagy z prezentace, snímku nebo tvaru jedním krokem?**

Ano. Kolekce [tag collection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tagcollection/) podporuje operaci [clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tagcollection/#clear), která najednou smaže všechny páry klíč‑hodnota.

**Jak mohu smazat jeden tag podle jeho názvu, aniž bych procházel celou kolekci?**

Použijte [remove](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tagcollection/#remove) na [tag collection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tagcollection/) a smažte tag podle jeho klíče.

**Jak mohu získat úplný seznam názvů tagů pro analytiku nebo filtrování?**

Použijte [getNamesOfTags](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tagcollection/#getNamesOfTags) na [tag collection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tagcollection/); vrátí pole všech názvů tagů.

**Jak mohu najít všechny vlastní XML části, bez ohledu na to, kde jsou uloženy?**

Použijte [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getAllCustomXmlParts) k načtení všech vlastních XML částí v prezentaci.

**Mám použít [getXmlAsString](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#getXmlAsString)/[setXmlAsString](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#setXmlAsString) nebo [getXmlData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#getXmlData)/[setXmlData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#setXmlData) pro aktualizaci vlastní XML části?**

Použijte [getXmlAsString](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#getXmlAsString) a [setXmlAsString](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#setXmlAsString), když aplikace pracuje s textem XML v kódování UTF‑8. Použijte [getXmlData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#getXmlData) a [setXmlData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/customxmlpart/#setXmlData), když je XML již dostupné jako pole bajtů nebo je výhodnější binární zpracování. Obě reprezentace odkazují na XML obsah téže vlastní XML části.