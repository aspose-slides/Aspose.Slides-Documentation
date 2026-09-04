---
title: "Verwalten von Präsentationseigenschaften mit Python"
linktitle: "Präsentationseigenschaften"
type: docs
weight: 70
url: /de/python-net/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- integrierte Eigenschaften
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
description: "Meistern Sie Präsentationseigenschaften in Aspose.Slides für Python via .NET und optimieren Sie Suche, Markenbildung und Arbeitsabläufe in Ihren PowerPoint-Dateien."
---
## **Einleitung**

Aspose.Slides unterstützt zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Beide Eigenschaftstypen können einfach über die Aspose.Slides API zugegriffen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteigenschaften von Präsentationen über die Klasse [DocumentProperties](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/) . Eine Instanz dieser Klasse wird von der Eigenschaft [Presentation.document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/document_properties/) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" title="Hinweis" %}}
Bitte beachten Sie, dass Sie keine Werte für die Felder **Application** und **Producer** festlegen können, da Aspose Ltd. und Aspose.Slides für Python via .NET x.x.x in diesen Feldern angezeigt werden.
{{% /alert %}} 

## **Präsentationseigenschaften verwalten**

Microsoft PowerPoint bietet eine Funktion, um einigen Eigenschaften zu den Präsentationsdateien hinzuzufügen. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt zwei Arten von Dokumenteigenschaften:

- System Definiert (Built-in) Properties
- Benutzerdefiniert (Custom) Properties

**Built-in** Eigenschaften enthalten allgemeine Informationen über das Dokument wie Dokumenttitel, Autorennamen, Dokumentstatistiken usw. **Custom** Eigenschaften sind solche, die von den Benutzern als **Name/Wert**‑Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides für Python via .NET können Entwickler sowohl die Werte integrierter Eigenschaften als auch benutzerdefinierter Eigenschaften abrufen und ändern. Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften von Präsentationsdateien. Sie müssen lediglich das Office‑Symbol anklicken und anschließend **Prepare | Properties | Advanced Properties** im Menü von Microsoft PowerPoint 2007 wählen. Nachdem Sie den Menüpunkt **Advanced Properties** ausgewählt haben, erscheint ein Dialog, der die Verwaltung der Dokumenteigenschaften der PowerPoint‑Datei erlaubt. Im **Properties Dialog** sehen Sie mehrere Registerkarten wie **General, Summary, Statistics, Contents und Custom**. Alle diese Registerkarten erlauben die Konfiguration verschiedener Arten von Informationen, die sich auf die PowerPoint‑Dateien beziehen. Die Registerkarte **Custom** wird verwendet, um die benutzerdefinierten Eigenschaften der PowerPoint‑Dateien zu verwalten.

## **Öffentliche Eigenschaften aus einer verschlüsselten Präsentation lesen**

Ein Öffnungspasswort schützt normalerweise sowohl den Präsentationsinhalt als auch die Dokumenteigenschaften. Wenn eine Präsentation mit [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) auf `False` verschlüsselt wird, bleiben ihre Dokumenteigenschaften öffentlich. Eine Anwendung kann dann [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/only_load_document_properties/) auf `True` setzen und die öffentlichen Metadaten lesen, ohne das Öffnungspasswort anzugeben.

`only_load_document_properties` steuert, was Aspose.Slides lädt; es entschlüsselt nichts. Wenn die Eigenschaften in die Verschlüsselung einbezogen wurden, schlägt das Laden ohne Passwort fehl. Ist die Präsentation nicht verschlüsselt, wird die Option ignoriert und die gesamte Präsentation wird geladen.

Das folgende Beispiel prüft den Lademodus über [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/de/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) und liest dann integrierte Eigenschaften über [Presentation.document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/document_properties/) :

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

In diesem Modus wird der Folieninhalt nicht geladen. Folien, Masterfolien, Layouts, Formen, Medien und andere Präsentationsobjekte sind nicht verfügbar. Anwendungen sollten stets `is_only_document_properties_loaded` prüfen, bevor sie Vorgänge ausführen, die das vollständige Präsentationsobjektmodell erfordern.

{{% alert color="warning" title="Sicherheit" %}}
Öffentliche Metadaten können Autorennamen, Titel, Themen, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte preisgeben. Verschlüsseln Sie sensible Eigenschaften zusammen mit der Präsentation. Lassen Sie sie nur dann öffentlich, wenn Indexierungs‑, Klassifizierungs‑, Such‑ oder Dokumentenmanagementsysteme einen speziellen Bedarf haben, ohne Passwort darauf zuzugreifen.
{{% /alert %}}

## **Eigenschaften einer verschlüsselten Präsentation aktualisieren**

Für eine verschlüsselte PPTX‑Datei ist eine mit `only_load_document_properties` geladene Präsentation zum Lesen öffentlicher Metadaten vorgesehen. Aspose.Slides kann geänderte Eigenschaften aus diesem rein‑metadaten‑Objekt nicht speichern, weil die öffentlichen Eigenschaften konsistent zu den entsprechenden Daten in der verschlüsselten Präsentation bleiben müssen. Eine Aktualisierung erfordert daher das korrekte Öffnungspasswort und ein vollständiges Laden.

Das folgende Beispiel öffnet die Präsentation mit [LoadOptions.password](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/password/), aktualisiert öffentliche integrierte Eigenschaften und speichert das Ergebnis. Anschließend wird mit [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/is_encrypted/) überprüft, dass die Verschlüsselung erhalten bleibt, und die öffentlichen Metadaten werden ohne Passwort erneut geöffnet, um die neuen Werte zu prüfen:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Ist einer Anwendung das Entschlüsseln oder Laden des Präsentationsinhalts nicht gestattet, muss sie öffentliche Eigenschaften einer verschlüsselten PPTX‑Datei als schreibgeschützt behandeln.

## **Zugriff auf integrierte Eigenschaften**
Diese Eigenschaften, die vom **IDocumentProperties**‑Objekt bereitgestellt werden, umfassen: **Creator(Author)**, **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Ausdrucks), **LastModifiedBy**, **SharedDoc** (Wird zwischen verschiedenen Produzenten geteilt?), **PresentationFormat**, **Subject** und **Title**
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die die Präsentation darstellt
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Erstellen Sie eine Referenz auf das mit Presentation verbundene Objekt
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

## **Integrierte Eigenschaften ändern**

Das Ändern integrierter Eigenschaften von Präsentationsdateien ist ebenso einfach wie ihr Zugriff. Sie können einfach einem gewünschten Property einen Zeichenfolgenwert zuweisen und der Property‑Wert wird geändert. Im nachfolgenden Beispiel zeigen wir, wie die integrierten Dokumenteigenschaften einer Präsentationsdatei geändert werden können.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die die Präsentation darstellt
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Erstellen Sie eine Referenz auf das mit Presentation verbundene Objekt
    documentProperties = presentation.document_properties

    # Setzen Sie die integrierten Eigenschaften
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Speichern Sie Ihre Präsentation in einer Datei
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**

Aspose.Slides für Python via .NET ermöglicht es Entwicklern zudem, benutzerdefinierte Werte für Dokumenteigenschaften einer Präsentation hinzuzufügen. Das folgende Beispiel zeigt, wie benutzerdefinierte Eigenschaften für eine Präsentation gesetzt werden.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse
with slides.Presentation() as presentation:
    # Dokumenteigenschaften abrufen
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

## **Zugriff auf und Änderung benutzerdefinierter Eigenschaften**

Aspose.Slides für Python via .NET erlaubt Entwicklern außerdem den Zugriff auf die Werte benutzerdefinierter Eigenschaften. Das nachstehende Beispiel demonstriert, wie Sie alle benutzerdefinierten Eigenschaften einer Präsentation abrufen und ändern können.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die das PPTX darstellt
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Erstellen Sie eine Referenz auf das document_properties-Objekt, das mit der Präsentation verknüpft ist
    documentProperties = presentation.document_properties

    # Zugriff auf und Ändern benutzerdefinierter Eigenschaften
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Anzeigen von Namen und Werten benutzerdefinierter Eigenschaften
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Werte benutzerdefinierter Eigenschaften ändern
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Speichern Sie Ihre Präsentation in einer Datei
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` gibt den Wert über die ein‑Element‑Liste zurück, die als zweites Argument übergeben wird, und der gespeicherte Wert wird in den Typ des bereits in dieser Liste vorhandenen Elements umgewandelt. Das obige Beispiel verwendet `[""]`, wodurch Zeichenketten‑Eigenschaften gelesen werden; um eine als Zahl gespeicherte Eigenschaft zu lesen, übergeben Sie einen numerischen Platzhalter wie `[0]` – andernfalls wirft der Aufruf eine `InvalidCastException`.

## **Korrektursprache festlegen**

Aspose.Slides stellt die Eigenschaft `Language_Id` (zur Verfügung gestellt von der Klasse [PortionFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/)) bereit, um die Korrektursprache für ein PowerPoint‑Dokument festzulegen. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint geprüft werden.

Der folgende Python‑Code zeigt, wie die Korrektursprache für ein PowerPoint‑Dokument festgelegt wird:

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

    # Id einer Korrektursprache festlegen
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Standard‑Sprache festlegen**

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

## **Live‑Beispiel**

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/de/metadata) aus, um zu sehen, wie Sie über die Aspose.Slides‑API mit Dokumenteigenschaften arbeiten:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## **FAQ**

**Wie kann ich eine integrierte Eigenschaft aus einer Präsentation entfernen?**

Integrierte Eigenschaften sind ein fester Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, sofern die jeweilige Eigenschaft es zulässt, auf leer setzen.

**Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**

Wird eine bereits vorhandene benutzerdefinierte Eigenschaft hinzugefügt, wird ihr bestehender Wert durch den neuen überschrieben. Ein vorheriges Entfernen oder Prüfen der Eigenschaft ist nicht erforderlich, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die komplette Präsentation zu laden?**

Ja. Verwenden Sie [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationfactory/get_presentation_info/) und anschließend [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/read_document_properties/), um gespeicherte Dokument‑Metadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Instanz zu erzeugen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/python-net/examine-presentation/) für ein vollständiges Reporting‑Beispiel und format‑spezifische Einschränkungen.

**Kann ich öffentliche Eigenschaften einer verschlüsselten Präsentation ohne ihr Öffnungspasswort lesen?**

Ja. Die Präsentation muss mit `encrypt_document_properties` auf `False` verschlüsselt sein und mit `only_load_document_properties` auf `True` geladen werden.

**Kann ich eine verschlüsselte PPTX‑Datei im Nur‑Dokument‑Eigenschaften‑Modus aktualisieren?**

Nein. Öffentliche und verschlüsselte Eigenschaftsdaten müssen konsistent bleiben, sodass das Aktualisieren einer verschlüsselten PPTX‑Datei das Laden der kompletten Präsentation mit dem korrekten Öffnungspasswort erfordert.