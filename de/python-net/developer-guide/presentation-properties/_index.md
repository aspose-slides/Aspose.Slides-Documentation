---
title: Präsentationseigenschaften verwalten mit Python
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/python-net/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- Eingebaute Eigenschaften
- Benutzerdefinierte Eigenschaften
- Erweiterte Eigenschaften
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
description: "Steuern Sie Präsentationseigenschaften in Aspose.Slides für Python über .NET und optimieren Sie Suche, Branding und Arbeitsabläufe in Ihren PowerPoint-Dateien."
---
## **Einleitung**

Aspose.Slides für Python über .NET unterstützt **eingebaute** und **benutzerdefinierte** Dokumenteigenschaften. Verwenden Sie diese Eigenschaften, um Präsentationsmetadaten zu lesen und zu aktualisieren, z. B. den Autor, den Titel und benutzerdefinierte Werte.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteigenschaften von Präsentationen über die [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) Klasse. Eine Instanz dieser Klasse wird von [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) zurückgegeben. Die folgenden Beispiele zeigen, wie diese Eigenschaften gelesen, geändert und verwaltet werden.

{{% alert color="info" title="Note" %}}
Aspose.Slides verwaltet die Anwendungs- und Hersteller‑Metadaten beim Speichern von Präsentationen; diese Felder identifizieren die Software, die die Ausgabe erstellt hat.
{{% /alert %}}

## **Präsentationseigenschaften verwalten**

Dokumenteigenschaften speichern beschreibende Informationen zusammen mit dem Präsentationsinhalt. Sie lassen sich in zwei Kategorien einteilen:

- **Eingebaute Eigenschaften** enthalten standardisierte Metadaten, wie Titel, Autor und Dokumentstatistiken.
- **Benutzerdefinierte Eigenschaften** speichern benutzerdefinierte Namens‑/Wert‑Paare.

Aspose.Slides für Python über .NET bietet Zugriff auf beide Kategorien. In PowerPoint wählen Sie **Datei → Info → Eigenschaften → Erweiterte Eigenschaften**, um die Dokumentmetadaten zu prüfen. Der Dialog gruppiert Informationen in Registerkarten wie **Zusammenfassung**, **Statistiken**, **Inhalte** und **Benutzerdefiniert**. Verwenden Sie die Registerkarte **Benutzerdefiniert**, um benutzerdefinierte Eigenschaften zu verwalten.

## **Öffentliche Eigenschaften aus einer verschlüsselten Präsentation lesen**

Ein Öffnungskennwort schützt normalerweise sowohl den Präsentationsinhalt als auch die Dokumenteigenschaften. Wenn eine Präsentation mit [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) auf `False` verschlüsselt ist, bleiben ihre Dokumenteigenschaften öffentlich. Eine Anwendung kann dann [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) auf `True` setzen und die öffentlichen Metadaten lesen, ohne das Öffnungskennwort anzugeben.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) steuert, was Aspose.Slides lädt; es entschlüsselt nichts. Wenn die Eigenschaften in die Verschlüsselung einbezogen wurden, schlägt das Laden ohne Kennwort fehl. Ist die Präsentation nicht verschlüsselt, wird die Option ignoriert und die vollständige Präsentation geladen.

Das Beispiel benötigt eine verschlüsselte Präsentation, deren Dokumenteigenschaften öffentlich belassen wurden. Es prüft den Lademodus über [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) und liest anschließend eingebaute Eigenschaften über [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

In diesem Modus wird der Folieninhalt nicht geladen. Folien, Folienmaster, Layouts, Formen, Medien und andere Präsentationsobjekte stehen nicht zur Verfügung. Anwendungen sollten stets [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) prüfen, bevor sie eine Operation ausführen, die das vollständige Präsentationsobjektmodell erfordert.

{{% alert color="warning" title="Security" %}}
Öffentliche Metadaten können Autorennamen, Titel, Themen, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte offenbaren. Verschlüsseln Sie sensible Eigenschaften zusammen mit der Präsentation. Lassen Sie sie nur dann öffentlich, wenn Indexierung, Klassifizierung, Suche oder Dokumenten‑Management‑Systeme eine spezielle Anforderung haben, ohne Kennwort darauf zuzugreifen.
{{% /alert %}}

## **Eigenschaften einer verschlüsselten Präsentation aktualisieren**

Für eine verschlüsselte PPTX‑Datei ist eine Präsentation, die mit [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) geladen wird, zum Lesen öffentlicher Metadaten gedacht. Aspose.Slides kann geänderte Eigenschaften aus diesem reinen Metadaten‑Objekt nicht speichern, da die öffentlichen Eigenschaften mit den entsprechenden Daten der verschlüsselten Präsentation konsistent bleiben müssen. Das Aktualisieren erfordert daher das korrekte Öffnungskennwort und ein vollständiges Laden.

Das Beispiel benötigt eine verschlüsselte PPTX‑Präsentation mit öffentlichen Dokumenteigenschaften und einem bekannten Öffnungskennwort. Es öffnet die vollständige Präsentation mit [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/), aktualisiert öffentliche eingebaute Eigenschaften und speichert das Ergebnis. Anschließend wird [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) verwendet, um zu prüfen, dass die Verschlüsselung erhalten bleibt, und die öffentlichen Metadaten ohne Kennwort erneut geöffnet, um die neuen Werte zu prüfen:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
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

Wenn einer Anwendung das Entschlüsseln oder Laden des Präsentationsinhalts nicht gestattet ist, muss sie öffentliche Eigenschaften einer verschlüsselten PPTX‑Datei als schreibgeschützt behandeln.

## **Zugriff auf eingebaute Eigenschaften**

Die Klasse [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) stellt eingebaute Metadaten über typisierte Eigenschaften bereit, darunter [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) und [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). Dieses Beispiel öffnet eine vorhandene Präsentation und gibt deren gespeicherte Metadaten in der Konsole aus. Die Werte hängen von der Eingabepäsentation ab; einige Felder können leer sein.

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

## **Eingebaute Eigenschaften ändern**

Um eingebaute Metadaten zu aktualisieren, weisen Sie den beschreibbaren Eigenschaften, die von [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) bereitgestellt werden, Werte zu. Dieses Beispiel öffnet eine vorhandene Präsentation, setzt [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/) und [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/) und speichert die aktualisierte Präsentation mit [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Die gespeicherte PPTX‑Datei enthält die neuen Metadaten.

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Verwalten der Hyperlink‑Basis**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) speichert die dokumentweite Basis für relative Hyperlinks. Dies ist nützlich, wenn eine Präsentation und ihre verknüpften Dateien an einen anderen Ort verschoben werden. Es ist getrennt vom einzelnen Hyperlink‑Attribut [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/): Das Ändern der Basis überschreibt nicht die gespeicherten Linkadressen oder ändert absolute Ziele.

Das Beispiel benötigt eine Präsentation, die sowohl einen relativen Link, z. B. `target.html`, als auch einen absoluten Link zu einer Datei oder Website enthält. Es liest die vorhandene Basis, weist eine neue Basisadresse zu und speichert und öffnet die Präsentation erneut, um den Wert zu prüfen. Anschließend wird die Basis mit `""` geleert und der leere Wert in einer separaten gespeicherten Datei überprüft. Ersetzen Sie die Beispiel‑Basisadresse durch den Speicherort Ihrer verknüpften Dateien.

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

Die beiden Verifizierungsnachrichten sollten `True` ausgeben. Das Leeren der Basis lässt die einzelnen Hyperlink‑Adressen unverändert.

Ein relativer Link zu `target.pptx` öffnete `old/target.pptx`, als die Basis auf den Ordner `old` zeigte. Nach dem Ändern der Basis auf den Ordner `new`, dem Speichern und dem erneuten Öffnen der Präsentation öffnete derselbe Link `new/target.pptx`. Ein absoluter Link öffnete weiterhin dieselbe Datei. Testen Sie Ihre relativen Links in PowerPoint vor und nach dem Verschieben der Präsentation oder dem Ändern ihrer Basis.

## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**

Benutzerdefinierte Eigenschaften speichern Metadaten, für die kein entsprechendes eingebautes Feld existiert. Die Methode [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) ermöglicht das Zuweisen eines Wertes anhand des Eigenschaftsnamens. Dieses Beispiel erstellt eine Präsentation, fügt zwei Textwerte und einen ganzzahligen Versionswert hinzu und speichert die Präsentation mit [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Das Zuweisen eines Wertes zu einem bestehenden Namen ersetzt den Wert dieser Eigenschaft.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**

Dieses Beispiel öffnet eine Präsentation, die benutzerdefinierte Eigenschaften enthält, und verwendet [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) , um über sie zu iterieren. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) akzeptiert einen nullbasierten Index und gibt den Namen zurück, der von [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) verwendet wird. Das Beispiel benötigt eine Präsentation, deren benutzerdefinierte Eigenschaften alle Zeichenketten sind. Es gibt jeden ursprünglichen Namen und Wert aus, ersetzt jeden Wert durch eine nummerierte Zeichenkette und speichert die Änderungen. Gibt es keine benutzerdefinierten Eigenschaften, nimmt die Schleife keine Änderungen vor.

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) gibt den Wert über die ein‑elementige Liste zurück, die als zweites Argument übergeben wird. Der Platzhalter muss dem Typ der gespeicherten Eigenschaft entsprechen: Verwenden Sie `[""]` für eine Zeichenkette oder `[0]` für eine Ganzzahl. Ein nicht übereinstimmender Typ löst eine `InvalidCastException` aus; wählen Sie den Platzhalter gemäß Ihrem benutzerdefinierten Eigenschaftsschema.

## **Live‑Beispiel**

Probieren Sie die Online‑App [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata), um zu sehen, wie man mit Dokumenteigenschaften über die Aspose.Slides‑API arbeitet:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch ihre Werte ändern oder sie, sofern die jeweilige Eigenschaft dies zulässt, auf leer setzen.

**Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**

Wenn Sie eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufügen, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Eigenschaftswert automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die Präsentation vollständig zu laden?**

Ja. Verwenden Sie [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) und anschließend [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/), um gespeicherte Dokumentmetadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Instanz zu erzeugen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/python-net/examine-presentation/) für ein vollständiges Reporting‑Beispiel und format‑spezifische Einschränkungen.

**Kann ich öffentliche Eigenschaften einer verschlüsselten Präsentation ohne ihr Öffnungskennwort lesen?**

Ja. Die Präsentation muss mit [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) auf `False` verschlüsselt worden sein und muss mit [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) auf `True` geladen werden.

**Kann ich eine verschlüsselte PPTX‑Datei im Nur‑Dokument‑Eigenschaften‑Modus aktualisieren?**

Nein. Öffentliche und verschlüsselte Eigenschaftsdaten müssen konsistent bleiben, daher erfordert das Aktualisieren einer verschlüsselten PPTX‑Datei das Laden der vollständigen Präsentation mit dem korrekten Öffnungskennwort.