---
title: Präsentationseigenschaften mit Python verwalten
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/python-net/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- Standard-Eigenschaften
- Benutzerdefinierte Eigenschaften
- Erweiterte Eigenschaften
- Eigenschaften verwalten
- Eigenschaften ändern
- Dokumentmetadaten
- Metadaten bearbeiten
- Rechtschreibprüfungssprache
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Beherrschen Sie Präsentationseigenschaften in Aspose.Slides für Python via .NET und optimieren Sie Suche, Markenkennzeichnung und Arbeitsabläufe in Ihren PowerPoint-Dateien."
---
## **Einleitung**

Aspose.Slides unterstützt zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Beide Eigenschaftstypen können einfach über die Aspose.Slides API zugegriffen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteigenschaften von Präsentationen über die Klasse [DocumentProperties](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/) . Eine Instanz dieser Klasse wird über die Eigenschaft [Presentation.document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/document_properties/) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" title="Hinweis" %}}
Bitte beachten Sie, dass Sie keine Werte für die Felder **Application** und **Producer** setzen können, da Aspose Ltd. und Aspose.Slides for Python via .NET x.x.x in diesen Feldern angezeigt werden.
{{% /alert %}} 

## **Präsentationseigenschaften verwalten**

Microsoft PowerPoint bietet eine Funktion, um einige Eigenschaften zu Präsentationsdateien hinzuzufügen. Diese Dokumenteigenschaften ermöglichen das Speichern nützlicher Informationen zusammen mit den Dokumenten (Präsentationsdateien). Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (Built-in) Eigenschaften
- Benutzerdefinierte (Custom) Eigenschaften

**Built-in**‑Eigenschaften enthalten allgemeine Informationen über das Dokument wie Dokumenttitel, Autorname, Dokumentstatistiken usw. **Custom**‑Eigenschaften sind solche, die von den Benutzern als **Name/Wert**‑Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides for Python via .NET können Entwickler auf die Werte eingebauter Eigenschaften sowie benutzerdefinierter Eigenschaften zugreifen und sie ändern. Microsoft PowerPoint 2007 erlaubt das Verwalten der Dokumenteigenschaften von Präsentationsdateien. Alles, was Sie tun müssen, ist, auf das Office‑Symbol zu klicken und anschließend den Menüpunkt **Vorbereiten | Eigenschaften | Erweiterte Eigenschaften** von Microsoft PowerPoint 2007 auszuwählen. Nachdem Sie den Menüpunkt **Erweiterte Eigenschaften** gewählt haben, erscheint ein Dialog, der Ihnen das Verwalten der Dokumenteigenschaften der PowerPoint‑Datei ermöglicht. Im **Eigenschaften‑Dialog** sehen Sie viele Registerkarten wie **Allgemein, Zusammenfassung, Statistiken, Inhalte und Benutzerdefiniert**. All diese Registerkarten ermöglichen die Konfiguration verschiedener Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Benutzerdefiniert** wird verwendet, um die benutzerdefinierten Eigenschaften der PowerPoint‑Dateien zu verwalten.

## **Zugriff auf Built-in Eigenschaften**
Diese Eigenschaften, die vom **IDocumentProperties**‑Objekt bereitgestellt werden, umfassen: **Creator(Author)**, **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wird zwischen verschiedenen Produzenten geteilt?), **PresentationFormat**, **Subject** und **Title**
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die die Präsentation darstellt
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Erstellen Sie eine Referenz auf das Objekt, das mit Presentation verknüpft ist
    documentProperties = pres.document_properties

    # Anzeige der integrierten Eigenschaften
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

## **Built-in Eigenschaften ändern**
Das Ändern der eingebauten Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einen Zeichenkettenwert einer gewünschten Eigenschaft zuweisen und der Eigenschaftswert wird geändert. Im untenstehenden Beispiel haben wir gezeigt, wie man die eingebauten Dokumenteigenschaften der Präsentationsdatei ändern kann.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die die Präsentation darstellt
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Erstellen Sie eine Referenz auf das Objekt, das mit Presentation verknüpft ist
    documentProperties = presentation.document_properties

    # Setzen Sie die integrierten Eigenschaften
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # speichern Sie Ihre Präsentation in einer Datei
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**
Aspose.Slides for Python via .NET ermöglicht es Entwicklern auch, benutzerdefinierte Werte für Präsentations‑Dokumenteigenschaften hinzuzufügen. Ein Beispiel wird unten gezeigt, das demonstriert, wie benutzerdefinierte Eigenschaften für eine Präsentation festgelegt werden.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse
with slides.Presentation() as presentation:
    # Abrufen der Dokumenteigenschaften
    documentProperties = presentation.document_properties

    # Hinzufügen benutzerdefinierter Eigenschaften
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Abrufen des Eigenschaftsnamens an einem bestimmten Index
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Entfernen der ausgewählten Eigenschaft
    documentProperties.remove_custom_property(getPropertyName)

    # Speichern der Präsentation
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**
Aspose.Slides for Python via .NET ermöglicht es Entwicklern ebenfalls, auf die Werte benutzerdefinierter Eigenschaften zuzugreifen. Ein Beispiel wird unten gezeigt, das zeigt, wie Sie alle diese benutzerdefinierten Eigenschaften einer Präsentation zugreifen und ändern können.

```py
import aspose.slides as slides

# Instanzieren Sie die Presentation-Klasse, die die PPTX darstellt
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Erstellen Sie eine Referenz auf das document_properties-Objekt, das mit der Präsentation verknüpft ist
    documentProperties = presentation.document_properties

    # Zugriff auf und Ändern benutzerdefinierter Eigenschaften
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Anzeige von Namen und Werten benutzerdefinierter Eigenschaften
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Werte benutzerdefinierter Eigenschaften ändern
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Speichern Sie Ihre Präsentation in einer Datei
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` returns the value through the one-element list passed as its second argument, and the stored value is cast to the type of the element already in that list. The example above uses `[""]`, so it reads string properties; to read a property stored as a number, pass a numeric placeholder such as `[0]`—otherwise the call raises an `InvalidCastException`.

## **Rechtschreibprüfungssprache festlegen**
Aspose.Slides stellt die `Language_Id`‑Eigenschaft (bereitgestellt von der Klasse [PortionFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/) ) zur Verfügung, um die Rechtschreibprüfungssprache für ein PowerPoint‑Dokument festzulegen. Die Rechtschreibprüfungssprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint geprüft werden.

Dieser Python‑Code zeigt, wie Sie die Rechtschreibprüfungssprache für ein PowerPoint festlegen:

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

    # Legen Sie die Id einer Korrektursprache fest
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Standardsprache festlegen**
Dieser Python‑Code zeigt, wie Sie die Standardsprache für eine gesamte PowerPoint‑Präsentation festlegen:

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

Versuchen Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/de/metadata), um zu sehen, wie man mit Dokumenteigenschaften über die Aspose.Slides API arbeitet:

[![Ansicht & Bearbeiten PowerPoint-Metadaten](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## **FAQ**

**Wie kann ich eine Built-in‑Eigenschaft aus einer Präsentation entfernen?**

Built-in‑Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch ihre Werte ändern oder, sofern die jeweilige Eigenschaft es zulässt, auf leer setzen.

**Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**

Wenn Sie eine benutzerdefinierte Eigenschaft hinzufügen, die bereits existiert, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich Präsentationseigenschaften zugreifen, ohne die Präsentation vollständig zu laden?**

Ja. Verwenden Sie [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationfactory/get_presentation_info/) und anschließend [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/read_document_properties/), um gespeicherte Dokumentmetadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Instanz zu erstellen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/python-net/examine-presentation/) für ein vollständiges Reporting‑Beispiel und format‑spezifische Einschränkungen.