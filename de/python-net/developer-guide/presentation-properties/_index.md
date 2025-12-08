---
title: Verwalten von Präsentationseigenschaften mit Python
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/python-net/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- eingebaute Eigenschaften
- benutzerdefinierte Eigenschaften
- erweiterte Eigenschaften
- Eigenschaften verwalten
- Eigenschaften ändern
- Dokumentmetadaten
- Metadaten bearbeiten
- Korrektursprache
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Meistern Sie die Präsentationseigenschaften in Aspose.Slides für Python via .NET und optimieren Sie Suche, Branding und Arbeitsabläufe in Ihren PowerPoint-Dateien."
---

## **Über Präsentationseigenschaften**

Wie bereits beschrieben unterstützt Aspose.Slides für Python via .NET zwei Arten von Dokumenteneigenschaften, nämlich **Built-in** und **Custom** Eigenschaften. Entwickler können also beide Arten von Eigenschaften über die Aspose.Slides für Python via .NET API nutzen. Aspose.Slides für Python via .NET stellt die Klasse [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) bereit, die die Dokumenteneigenschaften einer Präsentationsdatei über die Eigenschaft [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) repräsentiert. Entwickler können die von **Presentation** bereitgestellte [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) Eigenschaft verwenden, um die Dokumenteneigenschaften der Präsentationsdateien wie unten beschrieben zuzugreifen:

{{% alert color="primary" %}} 
Bitte beachten Sie, dass Sie keine Werte für die Felder **Application** und **Producer** festlegen können, da Aspose Ltd. und Aspose.Slides für Python via .NET x.x.x in diesen Feldern angezeigt werden.
{{% /alert %}} 

## **Verwalten von Präsentationseigenschaften**

Microsoft PowerPoint bietet die Möglichkeit, einige Eigenschaften zu einer Präsentationsdatei hinzuzufügen. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (Built-in) Eigenschaften
- Benutzerdefinierte (Custom) Eigenschaften

**Built-in** Eigenschaften enthalten allgemeine Informationen über das Dokument wie Titel, Autorname, Dokumentstatistiken usw. **Custom** Eigenschaften sind vom Benutzer als **Name/Value**‑Paare definierte Eigenschaften, bei denen sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides für Python via .NET können Entwickler sowohl eingebaute als auch benutzerdefinierte Eigenschaften lesen und ändern. Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften von Präsentationsdateien. Sie müssen lediglich das Office‑Symbol anklicken und anschließend **Prepare | Properties | Advanced Properties** im Menü von Microsoft PowerPoint 2007 auswählen. Nachdem Sie den Menüpunkt **Advanced Properties** gewählt haben, erscheint ein Dialog, in dem Sie die Dokumenteigenschaften der PowerPoint‑Datei verwalten können. Im **Properties Dialog** sehen Sie mehrere Registerkarten wie **General**, **Summary**, **Statistics**, **Contents** und **Custom**. Alle diese Registerkarten ermöglichen die Konfiguration verschiedener Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Custom** wird verwendet, um die benutzerdefinierten Eigenschaften der PowerPoint‑Dateien zu verwalten.

## **Zugriff auf eingebaute Eigenschaften**
Diese Eigenschaften, die vom **IDocumentProperties**‑Objekt bereitgestellt werden, umfassen: **Creator(Author)**, **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wird zwischen verschiedenen Produzenten geteilt?), **PresentationFormat**, **Subject** und **Title**
```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, die die Präsentation darstellt
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Erstellen einer Referenz zum mit Presentation verbundenen Objekt
    documentProperties = pres.document_properties

    # Anzeigen der integrierten Eigenschaften
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


## **Eingebaute Eigenschaften ändern**
Das Ändern der eingebauten Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einen Zeichenkettenwert einer beliebigen gewünschten Eigenschaft zuweisen und der Eigenschaftswert wird geändert. Im nachfolgenden Beispiel zeigen wir, wie man die eingebauten Dokumenteigenschaften einer Präsentationsdatei ändern kann.
```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, die die Presentation darstellt
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Erstellen einer Referenz zum mit Presentation verbundenen Objekt
    documentProperties = presentation.document_properties

    # Setzen der integrierten Eigenschaften
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Präsentation in einer Datei speichern
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**
Aspose.Slides für Python via .NET ermöglicht es Entwicklern auch, benutzerdefinierte Werte für Präsentations‑Dokumenteigenschaften hinzuzufügen. Das folgende Beispiel zeigt, wie benutzerdefinierte Eigenschaften für eine Präsentation gesetzt werden.
```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse
with slides.Presentation() as presentation:
    # Dokumenteigenschaften abrufen
    documentProperties = presentation.document_properties

    # Benutzerdefinierte Eigenschaften hinzufügen
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Property-Name an bestimmtem Index abrufen
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Ausgewählte Eigenschaft entfernen
    documentProperties.remove_custom_property(getPropertyName)

    # Präsentation speichern
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**
Aspose.Slides für Python via .NET ermöglicht es Entwicklern zudem, die Werte benutzerdefinierter Eigenschaften zu lesen. Das nachstehende Beispiel zeigt, wie Sie alle benutzerdefinierten Eigenschaften einer Präsentation zugreifen und ändern können.
```py
import aspose.slides as slides

# Instanzieren der Presentation-Klasse, die die PPTX darstellt
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Erstellen einer Referenz zum document_properties-Objekt, das mit der Präsentation verknüpft ist
    documentProperties = presentation.document_properties

    # Auf benutzerdefinierte Eigenschaften zugreifen und diese ändern
    for i in range(documentProperties.count_of_custom_properties):
        # Namen und Werte benutzerdefinierter Eigenschaften anzeigen
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Werte benutzerdefinierter Eigenschaften ändern
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # Präsentation in einer Datei speichern
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Rechtschreibprüfungssprache festlegen**
Aspose.Slides stellt die Eigenschaft `Language_Id` (bereitgestellt von der Klasse [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)) zur Verfügung, um die Rechtschreibprüfungssprache für ein PowerPoint‑Dokument festzulegen. Die Rechtschreibprüfungssprache ist die Sprache, für die Rechtschreibung und Grammatik im PowerPoint geprüft werden.

Dieser Python‑Code zeigt, wie die Rechtschreibprüfungssprache für ein PowerPoint festgelegt wird:
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

    # Setze die Id einer Korrektursprache
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```


## **Standardsprache festlegen**
Dieser Python‑Code zeigt, wie die Standardsprache für eine gesamte PowerPoint‑Präsentation festgelegt wird:
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


## **Live-Beispiel**
Testen Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata), um zu sehen, wie Sie mit Dokumenteigenschaften über die Aspose.Slides‑API arbeiten können:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch ihre Werte ändern oder, sofern die jeweilige Eigenschaft dies zulässt, auf leer setzen.

**Was geschieht, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**

Wenn Sie eine benutzerdefinierte Eigenschaft hinzufügen, die bereits existiert, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich Präsentationseigenschaften abrufen, ohne die gesamte Präsentation zu laden?**

Ja, Sie können Präsentationseigenschaften abrufen, ohne die gesamte Präsentation zu laden, indem Sie die Methode [get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) der Klasse [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/) verwenden. Anschließend nutzen Sie die Methode [read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) der Klasse [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/), um die Eigenschaften effizient zu lesen, was Speicher spart und die Leistung verbessert.