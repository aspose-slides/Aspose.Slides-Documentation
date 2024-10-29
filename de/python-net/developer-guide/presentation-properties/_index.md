---
title: Präsentationseigenschaften
type: docs
weight: 70
url: /de/python-net/presentation-properties/
keywords: "PowerPoint-Eigenschaften, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "PowerPoint-Präsentationseigenschaften in Python"
---


## **Lebendes Beispiel**
Versuchen Sie die [**Aspose.Slides-Metadaten**](https://products.aspose.app/slides/metadata) Online-Anwendung, um zu sehen, wie Sie mit Dokumenteigenschaften über die Aspose.Slides API arbeiten können:

[](https://products.aspose.app/slides/metadata)

[![todo:image_alt_text](slides-metadata.png)](https://products.aspose.app/slides/metadata)


## **Über Präsentationseigenschaften**
Wie bereits erwähnt, unterstützt Aspose.Slides für Python über .NET zwei Arten von Dokumenteigenschaften, nämlich **Eingebaute** und **Benutzerdefinierte** Eigenschaften. Entwickler können beide Arten von Eigenschaften mit Hilfe der Aspose.Slides für Python über .NET API zugreifen. Aspose.Slides für Python über .NET bietet eine Klasse [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) an, die die mit einer Präsentationsdatei verknüpften Dokumenteigenschaften darstellt über die [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) Eigenschaft. Entwickler können die durch das **Presentation**-Objekt bereitgestellte [IDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/idocumentproperties/) Eigenschaft verwenden, um auf die Dokumenteigenschaften der Präsentationsdateien zuzugreifen, wie unten beschrieben:



{{% alert color="primary" %}} 

Bitte beachten Sie, dass Sie keine Werte für die **Anwendung** und **Produzenten** Felder festlegen können, da Aspose Ltd. und Aspose.Slides für Python über .NET x.x.x in diesen Feldern angezeigt werden.

{{% /alert %}} 


## **Verwalten von Präsentationseigenschaften**
Microsoft PowerPoint bietet eine Funktion, um einige Eigenschaften zu den Präsentationsdateien hinzuzufügen. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (Eingebaute) Eigenschaften
- Benutzerdefinierte (Custom) Eigenschaften

**Eingebaute** Eigenschaften enthalten allgemeine Informationen über das Dokument, wie den Dokumenttitel, den Namen des Autors, Dokumentstatistiken usw. **Benutzerdefinierte** Eigenschaften sind solche, die von den Benutzern als **Name/Wert**-Paare definiert werden, wobei sowohl der Name als auch der Wert vom Benutzer festgelegt werden. Mit Aspose.Slides für Python über .NET können Entwickler auf die Werte von eingebauten Eigenschaften sowie benutzerdefinierten Eigenschaften zugreifen und diese ändern. Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften der Präsentationsdateien. Alles, was Sie tun müssen, ist, auf das Office-Symbol zu klicken und dann das Menü **Vorbereiten | Eigenschaften | Erweiterte Eigenschaften** von Microsoft PowerPoint 2007 zu wählen. Wenn Sie das Menü **Erweiterte Eigenschaften** auswählen, erscheint ein Dialogfeld, mit dem Sie die Dokumenteigenschaften der PowerPoint-Datei verwalten können. Im **Eigenschafts-Dialog** können Sie sehen, dass es viele Registerkarten wie **Allgemein, Zusammenfassung, Statistiken, Inhalte und Benutzerdefiniert** gibt. Alle diese Registerkarten ermöglichen die Konfiguration verschiedener Arten von Informationen im Zusammenhang mit den PowerPoint-Dateien. Die **Benutzerdefiniert**-Registerkarte wird verwendet, um die benutzerdefinierten Eigenschaften der PowerPoint-Dateien zu verwalten.
## **Zugriff auf Eingebaute Eigenschaften**
Diese durch das **IDocumentProperties**-Objekt bereitgestellten Eigenschaften umfassen: **Ersteller(Autor)**, **Beschreibung**, **Schlüsselwörter**, **Erstellt** (Erstellungsdatum), **Ändert** (Änderungsdatum), **Gedruckt** (Letztes Druckdatum), **Letzte geänderte von**, **Schlüsselwörter**, **SharedDoc** (Ist zwischen verschiedenen Produzenten geteilt?), **Präsentationsformat**, **Betreff** und **Titel**
```py
import aspose.slides as slides

# Instanziieren Sie die Präsentationsklasse, die die Präsentation darstellt
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Erstellen Sie eine Referenz auf das mit der Präsentation verknüpfte Objekt
    documentProperties = pres.document_properties

    # Anzeigen der eingebauten Eigenschaften
    print("Kategorie : " + documentProperties.category)
    print("Aktueller Status : " + documentProperties.content_status)
    print("Erstellungsdatum : " + str(documentProperties.created_time))
    print("Autor : " + documentProperties.author)
    print("Beschreibung : " + documentProperties.comments)
    print("Schlüsselwörter : " + documentProperties.keywords)
    print("Letzte Änderung von : " + documentProperties.last_saved_by)
    print("Vorgesetzter : " + documentProperties.manager)
    print("Änderungsdatum : " + str(documentProperties.last_saved_time))
    print("Präsentationsformat : " + documentProperties.presentation_format)
    print("Letztes Druckdatum : " + str(documentProperties.last_printed))
    print("Ist zwischen Produzenten geteilt : " + str(documentProperties.shared_doc))
    print("Betreff : " + documentProperties.subject)
    print("Titel : " + documentProperties.title)
```
## **Modifizieren von Eingebauten Eigenschaften**
Die Modifizierung der eingebauten Eigenschaften von Präsentationsdateien ist ebenso einfach wie der Zugriff darauf. Sie können einfach einen Stringwert einer gewünschten Eigenschaft zuweisen, und der Eigenschaftswert wird geändert. Im folgenden Beispiel haben wir demonstriert, wie wir die eingebauten Dokumenteigenschaften der Präsentationsdatei ändern können.

```py
import aspose.slides as slides

# Instanziieren Sie die Präsentationsklasse, die die Präsentation darstellt
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Erstellen Sie eine Referenz auf das mit der Präsentation verknüpfte Objekt
    documentProperties = presentation.document_properties

    # Setzen der eingebauten Eigenschaften
    documentProperties.author = "Aspose.Slides für .NET"
    documentProperties.title = "Ändern der Präsentationseigenschaften"
    documentProperties.subject = "Aspose Betreff"
    documentProperties.comments = "Aspose Beschreibung"
    documentProperties.manager = "Aspose Manager"

    # Speichern Sie Ihre Präsentation in einer Datei
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hinzufügen von Benutzerdefinierten Präsentationseigenschaften**
Aspose.Slides für Python über .NET ermöglicht es Entwicklern auch, benutzerdefinierte Werte für die Dokumenteigenschaften der Präsentation hinzuzufügen. Ein Beispiel ist unten gegeben, das zeigt, wie man die benutzerdefinierten Eigenschaften für eine Präsentation festlegt.

```py
import aspose.slides as slides

# Instanziieren Sie die Präsentationsklasse
with slides.Presentation() as presentation:
    # Dokumenteigenschaften abrufen
    documentProperties = presentation.document_properties

    # Benutzerdefinierte Eigenschaften hinzufügen
    documentProperties.set_custom_property_value("Neue Benutzerdefinierte", 12)
    documentProperties.set_custom_property_value("Mein Name", "Mudassir")
    documentProperties.set_custom_property_value("Benutzerdefiniert", 124)

    # Abrufen des Eigenschaftsnames an einem bestimmten Index
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Entfernen der ausgewählten Eigenschaft
    documentProperties.remove_custom_property(getPropertyName)

    # Speichern der Präsentation
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugriff und Modifikation von Benutzerdefinierten Eigenschaften**
Aspose.Slides für Python über .NET erlaubt es Entwicklern ebenfalls, auf die Werte der benutzerdefinierten Eigenschaften zuzugreifen. Ein Beispiel ist unten gegeben, das zeigt, wie Sie auf alle diese benutzerdefinierten Eigenschaften für eine Präsentation zugreifen und sie ändern können.

```py
import aspose.slides as slides

# Instanziieren Sie die Präsentationsklasse, die die PPTX darstellt
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Erstellen Sie eine Referenz auf das mit der Präsentation verknüpfte document_properties-Objekt
    documentProperties = presentation.document_properties

    # Zugriff und Modifikation benutzerdefinierter Eigenschaften
    for i in range(documentProperties.count_of_custom_properties):
        # Anzeigen der Namen und Werte benutzerdefinierter Eigenschaften
        print("Benutzerdefinierte Eigenschaftsname : " + documentProperties.get_custom_property_name(i))
        print("Benutzerdefinierte Eigenschaftswert : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Modifizieren der Werte benutzerdefinierter Eigenschaften
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "Neuer Wert " + str(i + 1))
    # Speichern Sie Ihre Präsentation in einer Datei
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Überprüfen, ob die Präsentation geändert oder erstellt wurde**
Aspose.Slides für Python über .NET stellt eine Funktion bereit, um zu überprüfen, ob eine Präsentation geändert oder erstellt wurde. Ein Beispiel ist unten gegeben, das zeigt, wie festgestellt werden kann, ob die Präsentation erstellt oder geändert wurde.

```py
import aspose.slides as slides

info =slides.PresentationFactory.instance.get_presentation_info(path + "AccessModifyingProperties.pptx")
props = info.read_document_properties()

print(props.name_of_application)
print(props.app_version)
```

## **Sprache für die Rechtschreibprüfung festlegen**

Aspose.Slides bietet die `Language_Id`-Eigenschaft (bereitgestellt durch die [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) Klasse), um Ihnen zu ermöglichen, die Sprache für die Rechtschreibprüfung für ein PowerPoint-Dokument festzulegen. Die Sprache für die Rechtschreibprüfung ist die Sprache, für die Rechtschreibung und Grammatik in der PowerPoint überprüft werden.

Dieser Python-Code zeigt Ihnen, wie Sie die Sprache für die Rechtschreibprüfung für ein PowerPoint festlegen:

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

    # Festlegen der Id einer Prüfungsprache
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Standardsprache festlegen**

Dieser Python-Code zeigt Ihnen, wie Sie die Standardsprache für eine gesamte PowerPoint-Präsentation festlegen:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "Neuer Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```