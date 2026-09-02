---
title: Verwalten von Tags und benutzerdefinierten Daten in Präsentationen mit Python
linktitle: Tags und benutzerdefinierte Daten
type: docs
weight: 300
url: /de/python-net/managing-tags-and-custom-data/
keywords:
- Dokumenteigenschaften
- Tag
- benutzerdefinierte Daten
- benutzerdefiniertes XML
- benutzerdefinierter XML-Teil
- XML-Metadaten
- ItemId
- Tag hinzufügen
- Paarwerte
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte XML‑Daten in PowerPoint‑Präsentationen mit Aspose.Slides für Python via .NET verwalten, einschließlich Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML‑Teile."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint‑Präsentationen arbeitet. Präsentationsspezifische Daten können als Tags oder als benutzerdefinierte XML‑Teile gespeichert werden. Tags sind einfache Schlüssel‑Wert‑Zeichenketten, während benutzerdefinierte XML‑Teile strukturierte Metadaten und anwendungsspezifische XML‑Payloads speichern können.

Aspose.Slides stellt APIs zum Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML‑Teile auf Präsentations‑, Folien‑ und Form‑Ebene bereit. Benutzerdefinierte XML‑Teile sind nützlich für Integrationen, die Informationen wie Dokument‑Management‑Kennungen, Workflow‑Zustände, Compliance‑Metadaten, Vorlagen‑Bindungsdaten oder andere strukturierte Anwendungsdaten innerhalb einer Präsentation speichern.

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien — Dateien mit der Erweiterung `.pptx` — werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Office Open XML definiert die Paketstruktur und die Beziehungen, die zum Speichern von Präsentationsinhalt und zugehörigen Daten verwendet werden.

Eine Präsentation enthält mehrere Teile, die durch Beziehungen verbunden sind. Beispielsweise enthält ein Folien‑Teil den Inhalt einer einzelnen Folie und kann explizite Beziehungen zu anderen Teilen haben, die durch ISO/IEC 29500 definiert sind.

Benutzerdefinierte Daten können als Tags ([TagCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/tagcollection/)) oder als benutzerdefinierte XML‑Teile ([CustomXmlPartCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/customxmlpartcollection/)) gespeichert werden. Beide stehen über die Klasse [`CustomData`](https://reference.aspose.com/slides/de/python-net/aspose.slides/customdata/) zur Verfügung.

{{% alert color="primary" %}}
Tags speichern einfache Zeichenketten‑Schlüssel‑Wert‑Paare. Benutzerdefinierte XML‑Teile speichern strukturierte XML‑Daten und können einer Präsentation, Folie oder Form zugeordnet werden.
{{% /alert %}}

## **Arbeiten mit benutzerdefinierten XML‑Teilen**

Die Eigenschaft [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/de/python-net/aspose.slides/customdata/custom_xml_parts/) gibt die Sammlung der benutzerdefinierten XML‑Teile zurück, die einem bestimmten Präsentationsobjekt zugeordnet sind. Beispiele:

- `presentation.custom_data.custom_xml_parts` enthält benutzerdefinierte XML‑Teile, die der Präsentation selbst zugeordnet sind.
- `slide.custom_data.custom_xml_parts` enthält benutzerdefinierte XML‑Teile, die einer bestimmten Folie zugeordnet sind.
- `shape.custom_data.custom_xml_parts` enthält benutzerdefinierte XML‑Teile, die einer bestimmten Form zugeordnet sind.

Verwenden Sie [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/all_custom_xml_parts/), wenn Sie alle benutzerdefinierten XML‑Teile in der Präsentation prüfen möchten, unabhängig davon, wo sie zugeordnet sind.

### **Einen benutzerdefinierten XML‑Teil zu einer Präsentation hinzufügen**

Verwenden Sie [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/de/python-net/aspose.slides/customxmlpartcollection/add/), um XML‑Daten zu einer Sammlung benutzerdefinierter XML‑Teile hinzuzufügen. Das XML muss gültig und nicht leer sein.

Das folgende Beispiel fügt strukturierte Metadaten zur präsentationsbezogenen benutzerdefinierten Datensammlung hinzu:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add weist automatisch einen Bezeichner zu. Setze eine spezifische GUID nur bei Bedarf.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Die Methode `add` kann außerdem XML als Byte‑Array oder Stream akzeptieren, was praktisch ist, wenn XML‑Inhalt bereits in binärer Form vorliegt.

### **Einen benutzerdefinierten XML‑Teil zu einer Folie oder Form hinzufügen**

Benutzerdefinierte XML‑Daten können einer bestimmten Folie oder Form zugeordnet werden, anstatt der gesamten Präsentation. Dies ist nützlich, wenn Metadaten nur ein Objekt beschreiben, z. B. einen Vorlagen‑Schlüssel, eine externe Datensatz‑Kennung oder Bindungsinformationen.

Das folgende Beispiel fügt einem Folien‑ und einem Form‑Objekt jeweils einen benutzerdefinierten XML‑Teil hinzu:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Die Ebene, auf der ein Teil hinzugefügt wird, bestimmt, welche `custom_data.custom_xml_parts`‑Sammlung die Beziehung zu diesem Teil enthält. Präsentationsbezogene Daten eignen sich für dokumentweite Metadaten, folienbezogene Daten für Informationen, die zu einer bestimmten Folie gehören, und formbezogene Daten für Metadaten, die an einer einzelnen Form hängen.

### **Alle benutzerdefinierten XML‑Teile auflisten und prüfen**

Verwenden Sie [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/all_custom_xml_parts/), um alle benutzerdefinierten XML‑Teile aus einer Präsentation abzurufen. Jeder [`CustomXmlPart`](https://reference.aspose.com/slides/de/python-net/aspose.slides/customxmlpart/) stellt seine Kennung, den XML‑Inhalt und die zugehörigen Namespace‑Schemas bereit.

Das folgende Beispiel listet alle benutzerdefinierten XML‑Teile und ihre Namespace‑Schemas auf:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/de/python-net/aspose.slides/customxmlpart/namespace_schemas/) liefert die XML‑Schemas, die dem benutzerdefinierten XML‑Teil zugeordnet sind. Diese Information kann beim Prüfen von Präsentationen nützlich sein, die XML von externen Systemen enthalten.

### **XML‑Inhalt und ItemId lesen und aktualisieren**

Verwenden Sie [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/de/python-net/aspose.slides/customxmlpart/xml_as_string/), um mit XML als UTF‑8‑Zeichenkette zu arbeiten, oder [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/de/python-net/aspose.slides/customxmlpart/xml_data/), um mit den rohen XML‑Bytes zu arbeiten. Beide Eigenschaften können gelesen und aktualisiert werden.

Die Eigenschaft [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/de/python-net/aspose.slides/customxmlpart/item_id/) enthält die GUID, die den benutzerdefinierten XML‑Teil im Office Open XML‑Dokument identifiziert. Sie kann ebenfalls geändert werden, wenn eine Integration eine neue Kennung benötigt.

Das folgende Beispiel aktualisiert den XML‑Inhalt und die Kennung:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Lese das aktuelle XML als Text.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # Aktualisiere das XML als UTF-8-Zeichenkette.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data liefert denselben XML-Inhalt als Rohbytes.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Ersetze die Kennung, wenn die Integration es verlangt.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Beim Zuweisen von `xml_as_string` oder `xml_data` muss gültiges, nicht leeres XML bereitgestellt werden. Verwenden Sie die eine oder andere Darstellung je nach dem, ob die Anwendung hauptsächlich mit Zeichenketten oder Binärdaten arbeitet.

### **Einen benutzerdefinierten XML‑Teil entfernen**

Aspose.Slides bietet mehrere Möglichkeiten, benutzerdefinierte XML‑Daten zu entfernen:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/de/python-net/aspose.slides/customxmlpart/remove/) entfernt den benutzerdefinierten XML‑Teil aus der Präsentation.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/de/python-net/aspose.slides/customxmlpartcollection/remove/) entfernt einen bestimmten Teil aus einer Sammlung benutzerdefinierter XML‑Teile.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/de/python-net/aspose.slides/customxmlpartcollection/remove_at/) entfernt den Teil an einem angegebenen Sammlungs‑Index.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/de/python-net/aspose.slides/customxmlpartcollection/clear/) entfernt alle Teile aus einer bestimmten Sammlung.

Das folgende Beispiel entfernt einen präsentationsbezogenen benutzerdefinierten XML‑Teil per Referenz:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

Falls Sie bereits ein `CustomXmlPart` besitzen und diesen Teil aus der Präsentation entfernen möchten, anstatt eine bestimmte Sammlung anzusprechen, rufen Sie `custom_xml_part.remove()` auf.

Ein Teil kann auch nach Index entfernt werden:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Alle benutzerdefinierten XML‑Teile einer Sammlung löschen**

Verwenden Sie `clear`, wenn alle benutzerdefinierten XML‑Teile, die einem bestimmten Präsentationsobjekt zugeordnet sind, entfernt werden sollen.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` wirkt nur auf die ausgewählte Sammlung. Das Löschen der Sammlung einer Folie löscht beispielsweise nicht die präsentations‑ oder formbezogenen Sammlungen.

Um jeden benutzerdefinierten XML‑Teil in der gesamten Präsentation zu entfernen, iterieren Sie über `all_custom_xml_parts` und entfernen jeden Teil:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Verknüpfte oder gemeinsam genutzte benutzerdefinierte XML‑Teile handhaben**

In einer Office Open XML‑Präsentation kann derselbe benutzerdefinierte XML‑Teil von mehr als einem Präsentationsobjekt referenziert werden. Beispielsweise kann eine bestehende Datei Beziehungen von mehreren Folien oder Formen zum gleichen zugrunde liegenden XML‑Teil enthalten.

Ein gemeinsam genutzter Teil sollte als ein Datenobjekt mit mehreren Verweisen behandelt werden:

- Das Aktualisieren von `xml_as_string`, `xml_data` oder `item_id` ändert den zugrunde liegenden XML‑Teil, sodass die Änderung überall wirksam wird, wo der Teil referenziert wird.
- `item_id` kann verwendet werden, um denselben benutzerdefinierten XML‑Teil bei der Prüfung von objektbezogenen Sammlungen zu identifizieren.
- Das Entfernen eines Teils aus einer spezifischen `custom_xml_parts`‑Sammlung entfernt ihn nur aus dieser Sammlung. Verwenden Sie `CustomXmlPart.remove()`, wenn der Teil selbst aus der Präsentation gelöscht werden soll.
- Vor dem Löschen oder Ersetzen eines gemeinsam genutzten Teils sollten die objektbezogenen Sammlungen geprüft werden, um festzustellen, ob andere Folien oder Formen noch darauf verweisen.

Die `add`‑Überladungen erstellen einen neuen benutzerdefinierten XML‑Teil aus XML‑Inhalt; sie akzeptieren keinen bestehenden `CustomXmlPart`. Daher treten gemeinsam genutzte Beziehungen meist beim Laden von Präsentationen auf, die bereits solche Beziehungen enthalten.

Das folgende Beispiel prüft Präsentations‑, Folien‑ und Form‑Sammlungen nach `item_id` und meldet Teile, die an mehr als einer Stelle referenziert werden:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

Eine solche Prüfung ist vor dem Ändern oder Löschen benutzerdefinierter XML‑Daten in von externen Systemen erstellten Präsentationen sinnvoll, weil derselbe Metadaten‑Teil an mehreren Beziehungen beteiligt sein kann.

## **Werte von Tags abfragen**

In Slides entspricht ein Tag der Eigenschaft `DocumentProperties.keywords`. Dieses Beispiel zeigt, wie man mit Aspose.Slides für Python via .NET den Tag‑Wert einer [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) abruft:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen:

- dem Namen einer benutzerdefinierten Eigenschaft, z. B. `MyTag`;
- dem Wert der benutzerdefinierten Eigenschaft, z. B. `My Tag Value`.

Falls Sie Präsentationen nach einer bestimmten Regel oder Eigenschaft klassifizieren möchten, können Sie hierfür Tags hinzufügen. Beispiel: Wenn Sie Präsentationen aus nordamerikanischen Ländern kategorisieren wollen, können Sie ein Tag „NorthAmerica“ erstellen und das jeweilige Land als Wert zuweisen.

Das folgende Beispiel zeigt, wie ein Tag zu einer [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) hinzugefügt wird:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

Tags können auch für eine [Slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/) gesetzt werden:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

Oder für eine einzelne [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Einschränkungen**

Tags, die über die Sammlung `custom_data.tags` hinzugefügt werden, werden nur in der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übertragen, wenn die Präsentation nach PDF exportiert wird. Daher kann ein als Tag gespeicherter benutzerdefinierter Identifier nicht aus dem getaggten PDF ausgelesen werden.

**Umgehungslösung**: Sie können einen benutzerdefinierten Identifier im **Alt‑Text** des Objekts speichern (z. B. `shape.alternative_text = "MyId"`). Nach dem Export nach PDF kann der Alt‑Text im PDF‑Tag‑Baum erscheinen.

## **FAQ**

**Kann ich alle Tags einer Präsentation, Folie oder Form in einem einzigen Vorgang entfernen?**

Ja. Die [Tag‑Sammlung](https://reference.aspose.com/slides/de/python-net/aspose.slides/tagcollection/) unterstützt die [clear](https://reference.aspose.com/slides/de/python-net/aspose.slides/tagcollection/clear/)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag anhand seines Namens, ohne die gesamte Sammlung zu iterieren?**

Verwenden Sie `remove(name)` auf der [TagCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/tagcollection/), um das Tag über seinen Schlüssel zu löschen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie `get_names_of_tags` auf der [Tag‑Sammlung](https://reference.aspose.com/slides/de/python-net/aspose.slides/tagcollection/); sie liefert ein Array aller Tag‑Namen.

**Wie finde ich alle benutzerdefinierten XML‑Teile, unabhängig davon, wo sie gespeichert sind?**

Verwenden Sie [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/all_custom_xml_parts/), um alle benutzerdefinierten XML‑Teile in der Präsentation abzurufen.

**Sollte ich `xml_as_string` oder `xml_data` verwenden, um einen benutzerdefinierten XML‑Teil zu aktualisieren?**

Verwenden Sie `xml_as_string`, wenn die Anwendung mit UTF‑8‑XML‑Text arbeitet. Verwenden Sie `xml_data`, wenn das XML bereits als Byte‑Array vorliegt oder eine binärorientierte Verarbeitung praktischer ist. Beide Eigenschaften repräsentieren denselben XML‑Inhalt des jeweiligen benutzerdefinierten XML‑Teils.