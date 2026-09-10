---
title: Verwalten von Tags und benutzerdefinierten Daten in Präsentationen mit Python
linktitle: Tags und benutzerdefinierte Daten
type: docs
weight: 300
url: /de/python-java/managing-tags-and-custom-data/
keywords:
- Dokumenteigenschaften
- Tag
- benutzerdefinierte Daten
- benutzerdefiniertes XML
- benutzerdefinierter XML-Teil
- XML-Metadaten
- ItemId
- Tag hinzufügen
- Wertpaare
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte XML-Daten in PowerPoint-Präsentationen mit Aspose.Slides für Python via Java verwalten, einschließlich Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML-Teile."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint‑Präsentationen arbeitet. Präsentationsspezifische Daten können als Tags oder benutzerdefinierte XML‑Teile gespeichert werden. Tags sind einfache Schlüssel‑Wert‑String‑Paare, während benutzerdefinierte XML‑Teile strukturierte Metadaten und anwendungsspezifische XML‑Payloads speichern können.

Aspose.Slides stellt APIs zum Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML‑Teile auf Präsentations‑, Folien‑ und Form‑Ebene bereit. Benutzerdefinierte XML‑Teile sind nützlich für Integrationen, die Informationen wie Dokument‑Management‑Kennungen, Workflow‑Zustand, Compliance‑Metadaten, Vorlagen‑Bindungsdaten oder andere strukturierte Anwendungsdaten in einer Präsentation speichern.

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien – Dateien mit der Endung `.pptx` – werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Office Open XML definiert die Paketstruktur und die Beziehungen, die zum Speichern von Präsentationsinhalt und zugehörigen Daten verwendet werden.

Eine Präsentation enthält mehrere Teile, die durch Beziehungen verbunden sind. Beispielsweise enthält ein Folienteil den Inhalt einer einzelnen Folie und kann explizite Beziehungen zu anderen Teilen haben, die durch ISO/IEC 29500 definiert sind.

Benutzerdefinierte Daten können als Tags ([TagCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/tagcollection/)) oder benutzerdefinierte XML‑Teile ([CustomXmlPartCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpartcollection/)) gespeichert werden. Beide sind über die Klasse [CustomData](https://reference.aspose.com/slides/de/python-java/aspose.slides/customdata/) verfügbar.

{{% alert color="info" title="Note" %}}

Tags speichern einfache String‑Schlüssel‑Wert‑Paare. Benutzerdefinierte XML‑Teile speichern strukturierte XML‑Daten und können einer Präsentation, Folie oder Form zugeordnet werden.

{{% /alert %}}

## **Arbeiten mit benutzerdefinierten XML‑Teilen**

Die Methode [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/de/python-java/aspose.slides/customdata/#getCustomXmlParts) gibt die Sammlung der benutzerdefinierten XML‑Teile zurück, die mit einem bestimmten Präsentationsobjekt verknüpft sind. Beispielsweise:

- Die [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/de/python-java/aspose.slides/customdata/#getCustomXmlParts)-Sammlung der Präsentation enthält benutzerdefinierte XML‑Teile, die mit der Präsentation selbst verknüpft sind.
- Die [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/de/python-java/aspose.slides/customdata/#getCustomXmlParts)-Sammlung der Folie enthält benutzerdefinierte XML‑Teile, die mit einer bestimmten Folie verknüpft sind.
- Die [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/de/python-java/aspose.slides/customdata/#getCustomXmlParts)-Sammlung der Form enthält benutzerdefinierte XML‑Teile, die mit einer bestimmten Form verknüpft sind.

Verwenden Sie [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getAllCustomXmlParts), wenn Sie alle benutzerdefinierten XML‑Teile in der Präsentation prüfen möchten, unabhängig davon, wo sie verknüpft sind.

### **Einen benutzerdefinierten XML‑Teil zu einer Präsentation hinzufügen**

Verwenden Sie [CustomXmlPartCollection.add](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpartcollection/#add), um XML‑Daten zu einer benutzerdefinierten XML‑Teilsammlung hinzuzufügen. Das XML muss gültig und nicht leer sein.

Das folgende Beispiel fügt strukturierte Metadaten zur präsentationsbezogenen benutzerdefinierten Datensammlung hinzu:

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

    # add weist automatisch einen Bezeichner zu. Setze eine bestimmte UUID nur bei Bedarf.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die [add](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpartcollection/#add)-Methode kann auch XML als Byte‑Array oder Eingabestream akzeptieren, was nützlich ist, wenn XML‑Inhalt bereits in binärer Form vorliegt.

### **Einen benutzerdefinierten XML‑Teil zu einer Folie oder Form hinzufügen**

Benutzerdefinierte XML‑Daten können mit einer bestimmten Folie oder Form verknüpft werden, anstatt mit der gesamten Präsentation. Das ist nützlich, wenn Metadaten nur ein Objekt beschreiben, zum Beispiel einen Vorlagenschlüssel, eine externe Datensatz‑Kennung oder Bindungsinformationen.

Das folgende Beispiel fügt einen benutzerdefinierten XML‑Teil zu einer Folie und einen weiteren zu einer Form hinzu:

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

Die Ebene, auf der ein Teil hinzugefügt wird, bestimmt, welche [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/de/python-java/aspose.slides/customdata/#getCustomXmlParts)-Sammlung die Beziehung zu diesem Teil enthält. Präsentationsbezogene Daten eignen sich für dokumentspezifische Metadaten, folienbezogene Daten für Informationen, die zu einer bestimmten Folie gehören, und formbezogene Daten für Metadaten, die an eine einzelne Form gebunden sind.

### **Alle benutzerdefinierten XML‑Teile auflisten und prüfen**

Verwenden Sie [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getAllCustomXmlParts), um alle benutzerdefinierten XML‑Teile einer Präsentation abzurufen. Jeder [CustomXmlPart](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/) gibt seine Kennung, den XML‑Inhalt und die zugehörigen Namespace‑Schemas zurück.

Das folgende Beispiel listet alle benutzerdefinierten XML‑Teile und deren Namespace‑Schemas auf:

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

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) liefert die XML‑Schemas, die dem benutzerdefinierten XML‑Teil zugeordnet sind. Diese Information kann beim Prüfen von Präsentationen nützlich sein, die XML von externen Systemen enthalten.

### **XML‑Inhalt und ItemId lesen und aktualisieren**

Verwenden Sie [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#getXmlAsString) und [setXmlAsString](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#setXmlAsString), um mit XML als UTF‑8‑String zu arbeiten, oder [getXmlData](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#getXmlData) und [setXmlData](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#setXmlData), um mit den rohen XML‑Bytes zu arbeiten.

Die Methode [CustomXmlPart.getItemId](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#getItemId) gibt die UUID zurück, die den benutzerdefinierten XML‑Teil im Office Open XML‑Dokument identifiziert. Verwenden Sie [setItemId](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#setItemId), wenn eine Integration eine neue Kennung benötigt.

Das folgende Beispiel aktualisiert den XML‑Inhalt und die Kennung:

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

        # Lese das aktuelle XML als Text.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # Aktualisiere das XML als UTF-8-String.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData liefert denselben XML-Inhalt als Rohbytes.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # Ersetze die Kennung, wenn die Integration sie benötigt.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

Beim Aufruf von [setXmlAsString](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#setXmlAsString) oder [setXmlData](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#setXmlData) geben Sie gültiges, nicht leeres XML an. Verwenden Sie die eine oder die andere Darstellung, je nachdem, ob die Anwendung hauptsächlich mit Strings oder Binärdaten arbeitet.

### **Einen benutzerdefinierten XML‑Teil entfernen**

Aspose.Slides bietet verschiedene Möglichkeiten, benutzerdefinierte XML‑Daten zu entfernen:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#remove) entfernt den benutzerdefinierten XML‑Teil aus der Präsentation.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpartcollection/#remove) entfernt einen bestimmten Teil aus einer benutzerdefinierten XML‑Teilsammlung.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpartcollection/#removeAt) entfernt den Teil an einem angegebenen Sammlungs‑Index.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpartcollection/#clear) entfernt alle Teile aus einer bestimmten Sammlung.

Das folgende Beispiel entfernt einen präsentationsbezogenen benutzerdefinierten XML‑Teil per Referenz:

```python
import jpype
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

Falls Sie bereits ein [CustomXmlPart](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/) besitzen und diesen Teil aus der Präsentation entfernen möchten, anstatt eine bestimmte Sammlung anzusprechen, rufen Sie [CustomXmlPart.remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#remove) auf.

Sie können ein Element auch nach Index entfernen:

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

### **Alle benutzerdefinierten XML‑Teile einer Sammlung leeren**

Verwenden Sie [clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpartcollection/#clear), wenn alle benutzerdefinierten XML‑Teile, die mit einem bestimmten Präsentationsobjekt verknüpft sind, entfernt werden sollen.

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

[clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpartcollection/#clear) wirkt nur auf die ausgewählte Sammlung. Das Leeren der Sammlung einer Folie löscht beispielsweise nicht die präsentations‑ oder formbezogenen Sammlungen.

Um jeden benutzerdefinierten XML‑Teil in der Präsentation zu entfernen, iterieren Sie über [getAllCustomXmlParts](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getAllCustomXmlParts) und entfernen Sie jeden Teil:

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

### **Verknüpfte oder geteilte benutzerdefinierte XML‑Teile verarbeiten**

In einer Office Open XML‑Präsentation kann derselbe benutzerdefinierte XML‑Teil von mehr als einem Präsentationsobjekt referenziert werden. Beispielsweise kann eine vorhandene Datei Beziehungen von mehreren Folien oder Formen zu demselben zugrunde liegenden benutzerdefinierten XML‑Teil enthalten.

Ein geteilter Teil sollte als ein Datenobjekt mit mehreren Verweisen behandelt werden:

- Das Aktualisieren mit [setXmlAsString](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#setXmlData) oder [setItemId](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#setItemId) ändert den zugrunde liegenden benutzerdefinierten XML‑Teil, sodass die Änderung überall wirksam wird, wo dieser Teil referenziert wird.
- [getItemId](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#getItemId) kann verwendet werden, um denselben benutzerdefinierten XML‑Teil beim Prüfen von objektbezogenen Sammlungen zu identifizieren.
- Das Entfernen eines Teils aus einer bestimmten [getCustomXmlParts](https://reference.aspose.com/slides/de/python-java/aspose.slides/customdata/#getCustomXmlParts)-Sammlung entfernt ihn nur aus dieser Sammlung. Verwenden Sie [CustomXmlPart.remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#remove), wenn der Teil selbst aus der Präsentation gelöscht werden soll.
- Vor dem Löschen oder Ersetzen eines geteilten Teils sollten die objektbezogenen Sammlungen geprüft werden, um festzustellen, ob andere Folien oder Formen noch darauf verweisen.

Die [add](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpartcollection/#add)-Überladungen erstellen einen neuen benutzerdefinierten XML‑Teil aus XML‑Inhalt; sie akzeptieren keinen bereits bestehenden [CustomXmlPart](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/). Daher treten geteilte Beziehungen am häufigsten beim Laden von Präsentationen auf, die bereits solche Verknüpfungen enthalten.

Das folgende Beispiel prüft Präsentations‑, Folien‑ und Form‑Sammlungen nach `ItemId` und gibt Teile aus, die von mehr als einem Ort referenziert werden:

```python
import jpile
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

Diese Art von Prüfung ist vor dem Ändern oder Löschen benutzerdefinierter XML‑Daten in von externen Systemen erstellten Präsentationen nützlich, weil derselbe Metadaten‑Teil an mehreren Beziehungen teilnehmen kann.

## **Werte von Tags abrufen**

In Slides entspricht ein Tag der Methode [DocumentProperties.getKeywords](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#getKeywords). Dieser Beispielcode zeigt, wie ein Tag‑Wert mit Aspose.Slides für Python via Java für [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) abgerufen wird:

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

## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen:

- dem Namen einer benutzerdefinierten Eigenschaft, zum Beispiel `MyTag`;
- dem Wert der benutzerdefinierten Eigenschaft, zum Beispiel `My Tag Value`.

Wenn Sie Präsentationen nach einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie dafür Tags hinzufügen. Beispiel: Möchten Sie Präsentationen aus nordamerikanischen Ländern kategorisieren, können Sie einen „North American“-Tag erstellen und das jeweilige Land als Wert zuweisen.

Der folgende Beispielcode zeigt, wie ein Tag zu einer [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) mithilfe von Aspose.Slides für Python via Java hinzugefügt wird:

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

Tags können auch für eine [Slide](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/) gesetzt werden:

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

Oder für eine einzelne [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/):

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

### **Einschränkungen**

Tags, die über die [CustomData.getTags](https://reference.aspose.com/slides/de/python-java/aspose.slides/customdata/#getTags)-Sammlung hinzugefügt werden, werden nur in der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übernommen, wenn die Präsentation nach PDF exportiert wird. Daher kann ein als Tag zugewiesener benutzerdefinierter Identifier nicht aus dem getaggten PDF abgerufen werden.

**Workaround**: Sie können einen benutzerdefinierten Identifier im **Alt‑Text** des Objekts speichern (z. B. [Shape.setAlternativeText](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#setAlternativeText) mit dem Wert `"MyId"`). Nach dem Export nach PDF kann der Alt‑Text in der PDF‑Tag‑Struktur erscheinen.

## **FAQ**

**Kann ich alle Tags einer Präsentation, Folie oder Form in einem Schritt entfernen?**

Ja. Die [tag collection](https://reference.aspose.com/slides/de/python-java/aspose.slides/tagcollection/) unterstützt eine [clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/tagcollection/#clear)-Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag nach Namen, ohne die gesamte Sammlung zu iterieren?**

Verwenden Sie [remove](https://reference.aspose.com/slides/de/python-java/aspose.slides/tagcollection/#remove) auf der [tag collection](https://reference.aspose.com/slides/de/python-java/aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu entfernen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [getNamesOfTags](https://reference.aspose.com/slides/de/python-java/aspose.slides/tagcollection/#getNamesOfTags) auf der [tag collection](https://reference.aspose.com/slides/de/python-java/aspose.slides/tagcollection/); sie liefert ein Array aller Tag‑Namen.

**Wie finde ich alle benutzerdefinierten XML‑Teile, unabhängig davon, wo sie gespeichert sind?**

Verwenden Sie [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getAllCustomXmlParts), um alle benutzerdefinierten XML‑Teile in der Präsentation abzurufen.

**Soll ich [getXmlAsString](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#getXmlAsString)/[setXmlAsString](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#setXmlAsString) oder [getXmlData](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#getXmlData)/[setXmlData](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#setXmlData) verwenden, um einen benutzerdefinierten XML‑Teil zu aktualisieren?**

Verwenden Sie [getXmlAsString](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#getXmlAsString) und [setXmlAsString](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#setXmlAsString), wenn die Anwendung mit UTF‑8‑XML‑Text arbeitet. Verwenden Sie [getXmlData](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#getXmlData) und [setXmlData](https://reference.aspose.com/slides/de/python-java/aspose.slides/customxmlpart/#setXmlData), wenn das XML bereits als Byte‑Array vorliegt oder eine binär‑orientierte Verarbeitung bequemer ist. Beide Darstellungen beziehen sich auf den XML‑Inhalt desselben benutzerdefinierten XML‑Teils.