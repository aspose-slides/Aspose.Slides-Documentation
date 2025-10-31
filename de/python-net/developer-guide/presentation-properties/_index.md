---
title: "Verwalten von Präsentations‑Eigenschaften mit Python"
linktitle: "Präsentations‑Eigenschaften"
type: docs
weight: 70
url: /de/python-net/presentation-properties/
keywords:
- "PowerPoint-Eigenschaften"
- "Präsentations‑Eigenschaften"
- "Dokument‑Eigenschaften"
- "Integrierte Eigenschaften"
- "Benutzerdefinierte Eigenschaften"
- "Erweiterte Eigenschaften"
- "Eigenschaften verwalten"
- "Eigenschaften ändern"
- "Dokument‑Metadaten"
- "Metadaten bearbeiten"
- "Korrektursprache"
- "Standardsprache"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "Python"
- "Aspose.Slides"
description: "Meistern Sie die Präsentations‑Eigenschaften in Aspose.Slides für Python via .NET und optimieren Sie Suche, Branding und Arbeitsabläufe in Ihren PowerPoint‑Dateien."
---

## **Über Präsentations‑Eigenschaften**

Wie bereits beschrieben, unterstützt Aspose.Slides für Python via .NET zwei Arten von Dokument‑Eigenschaften: **Integrierte** und **Benutzerdefinierte** Eigenschaften. Entwickler können beide Arten von Eigenschaften über die Aspose.Slides‑API für Python via .NET nutzen. Aspose.Slides für Python via .NET stellt die Klasse [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) bereit, die die Dokument‑Eigenschaften einer Präsentationsdatei über die Eigenschaft [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) abbildet. Entwickler können die von dem **Presentation**‑Objekt bereitgestellte [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/)-Eigenschaft verwenden, um auf die Dokument‑Eigenschaften der Präsentationsdateien zuzugreifen, wie im Folgenden beschrieben:

{{% alert color="primary" %}} 
Bitte beachten Sie, dass Sie keine Werte für die Felder **Application** und **Producer** festlegen können, da Aspose Ltd. und Aspose.Slides für Python via .NET x.x.x in diesen Feldern angezeigt werden.
{{% /alert %}} 

## **Verwalten von Präsentations‑Eigenschaften**

Microsoft PowerPoint bietet eine Funktion zum Hinzufügen von Eigenschaften zu Präsentationsdateien. Diese Dokument‑Eigenschaften ermöglichen das Speichern nützlicher Informationen zusammen mit den Dateien. Es gibt zwei Arten von Dokument‑Eigenschaften:

- Systemdefinierte (Integrierte) Eigenschaften  
- Benutzerdefinierte (Benutzerdefinierte) Eigenschaften  

**Integrierte** Eigenschaften enthalten allgemeine Informationen zum Dokument, wie Titel, Autor, Statistiken usw. **Benutzerdefinierte** Eigenschaften sind vom Benutzer als **Name/Wert**‑Paare definierte Einträge. Mit Aspose.Slides für Python via .NET können Entwickler sowohl integrierte als auch benutzerdefinierte Eigenschaften lesen und ändern. Microsoft PowerPoint 2007 ermöglicht das Verwalten der Dokument‑Eigenschaften einer Präsentation. Klicken Sie dafür auf das Office‑Symbol und anschließend auf **Datei → Informationen → Eigenschaften → Erweiterte Eigenschaften**. Nach Auswahl von **Erweiterte Eigenschaften** erscheint ein Dialog, in dem Sie die Dokument‑Eigenschaften der PowerPoint‑Datei verwalten können. Im **Eigenschaften‑Dialog** gibt es mehrere Registerkarten wie **Allgemein, Zusammenfassung, Statistik, Inhalt und Benutzerdefiniert**. Die Registerkarte **Benutzerdefiniert** dient zur Verwaltung benutzerdefinierter Eigenschaften.

## **Zugriff auf integrierte Eigenschaften**
Zu den von **IDocumentProperties** bereitgestellten integrierten Eigenschaften gehören: **Creator (Autor)**, **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (letztes Druckdatum), **LastModifiedBy**, **SharedDoc** (wird zwischen Produzenten geteilt?), **PresentationFormat**, **Subject** und **Title**.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, die die Präsentation darstellt
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Erstellen Sie eine Referenz zum mit der Presentation verknüpften Objekt
    documentProperties = pres.document_properties

    # Integrierte Eigenschaften anzeigen
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

## **Ändern integrierter Eigenschaften**

Das Ändern integrierter Eigenschaften ist genauso einfach wie deren Zugriff. Sie können einfach einen Zeichenkettenwert einer gewünschten Eigenschaft zuweisen, wodurch der Wert geändert wird. Im folgenden Beispiel wird gezeigt, wie integrierte Dokument‑Eigenschaften einer Präsentation geändert werden können.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, die die Präsentation darstellt
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Erstellen Sie eine Referenz zum mit der Presentation verknüpften Objekt
    documentProperties = presentation.document_properties

    # Integrierte Eigenschaften festlegen
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Präsentation in eine Datei speichern
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hinzufügen benutzerdefinierter Präsentations‑Eigenschaften**

Aspose.Slides für Python via .NET ermöglicht es Entwicklern ebenfalls, benutzerdefinierte Werte für Dokument‑Eigenschaften einer Präsentation zu setzen. Das folgende Beispiel zeigt, wie benutzerdefinierte Eigenschaften einer Präsentation hinzugefügt werden.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse
with slides.Presentation() as presentation:
    # Dokument‑Eigenschaften abrufen
    documentProperties = presentation.document_properties

    # Benutzerdefinierte Eigenschaften hinzufügen
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Eigenschaftsnamen an einem bestimmten Index abrufen
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Ausgewählte Eigenschaft entfernen
    documentProperties.remove_custom_property(getPropertyName)

    # Präsentation speichern
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugriff und Ändern benutzerdefinierter Eigenschaften**

Aspose.Slides für Python via .NET ermöglicht es Entwicklern zudem, die Werte benutzerdefinierter Eigenschaften auszulesen und zu ändern. Das folgende Beispiel demonstriert, wie alle benutzerdefinierten Eigenschaften einer Präsentation abgefragt und geändert werden können.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, die die PPTX darstellt
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Referenz zum document_properties‑Objekt, das mit der Präsentation verknüpft ist, erstellen
    documentProperties = presentation.document_properties

    # Benutzerdefinierte Eigenschaften lesen und ändern
    for i in range(documentProperties.count_of_custom_properties):
        # Namen und Werte benutzerdefinierter Eigenschaften anzeigen
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Werte benutzerdefinierter Eigenschaften ändern
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # Präsentation in eine Datei speichern
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Korrektursprache festlegen**

Aspose.Slides stellt die Eigenschaft `language_id` (exponiert durch die Klasse [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)) bereit, um die Korrektursprache eines PowerPoint‑Dokuments festzulegen. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik im PowerPoint geprüft werden.

Dieses Python‑Beispiel zeigt, wie die Korrektursprache festgelegt wird:

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

    # Die Id einer Korrektursprache festlegen
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Standardsprache festlegen**

Dieses Python‑Beispiel zeigt, wie die Standardsprache für eine gesamte PowerPoint‑Präsentation festgelegt wird:

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

## **Live‑Beispiel**

Probieren Sie die Online‑App **[Aspose.Slides Metadata](https://products.aspose.app/slides/metadata)**, um zu sehen, wie Sie mit Dokument‑Eigenschaften über die Aspose.Slides‑API arbeiten können:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Wie kann ich eine integrierte Eigenschaft aus einer Präsentation entfernen?**  
Integrierte Eigenschaften sind ein fester Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, sofern die jeweilige Eigenschaft es zulässt, auf leer setzen.

**Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**  
Wird eine bereits vorhandene benutzerdefinierte Eigenschaft erneut hinzugefügt, wird ihr vorhandener Wert durch den neuen überschrieben. Ein vorheriges Entfernen oder Prüfen der Eigenschaft ist nicht nötig, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich Präsentations‑Eigenschaften auslesen, ohne die gesamte Präsentation zu laden?**  
Ja. Sie können die Eigenschaften auslesen, indem Sie die Methode [get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) der Klasse [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/) verwenden. Anschließend nutzen Sie die Methode [read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) der Klasse [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/), um die Eigenschaften effizient zu lesen, was Speicher spart und die Leistung verbessert.