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
description: "Verwalten Sie Präsentationseigenschaften in Aspose.Slides für Python via .NET und optimieren Sie Suche, Branding und Arbeitsabläufe in Ihren PowerPoint‑Dateien."
---
## **Einleitung**

Aspose.Slides für Python via .NET unterstützt **eingebaute** und **benutzerdefinierte** Dokumenteigenschaften. Verwenden Sie diese Eigenschaften, um Präsentationsmetadaten zu lesen und zu aktualisieren, z. B. den Autor, den Titel und benutzerdefinierte Werte.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteigenschaften von Präsentationen über die Klasse [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) . Eine Instanz dieser Klasse wird von [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" title="Note" %}}
Aspose.Slides verwaltet die Anwendungs‑ und Hersteller‑Metadaten beim Speichern von Präsentationen; diese Felder identifizieren die Software, die die Ausgabe erzeugt hat.
{{% /alert %}}

## **Präsentationseigenschaften verwalten**

Dokumenteigenschaften speichern beschreibende Informationen zusammen mit dem Präsentationsinhalt. Sie lassen sich in zwei Kategorien einteilen:

- **Eingebaute Eigenschaften** enthalten standardisierte Metadaten, wie Titel, Autor und Dokumentstatistiken.
- **Benutzerdefinierte Eigenschaften** speichern benutzerdefinierte Namens‑/Wert‑Paare.

Aspose.Slides für Python via .NET bietet Zugriff auf beide Kategorien. In PowerPoint wählen Sie **Datei → Info → Eigenschaften → Erweiterte Eigenschaften**, um die Dokumentmetadaten zu prüfen. Der Dialog gruppiert die Informationen in Registerkarten wie **Zusammenfassung**, **Statistik**, **Inhalt** und **Benutzerdefiniert**. Verwenden Sie die Registerkarte **Benutzerdefiniert**, um benutzerdefinierte Eigenschaften zu verwalten.

## **Öffentliche Eigenschaften aus einer verschlüsselten Präsentation lesen**

Ein Öffnungspasswort schützt normalerweise sowohl den Präsentationsinhalt als auch die Dokumenteigenschaften. Wenn eine Präsentation mit [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) auf `False` verschlüsselt ist, bleiben ihre Dokumenteigenschaften öffentlich. Eine Anwendung kann dann [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) auf `True` setzen und die öffentlichen Metadaten lesen, ohne das Öffnungspasswort anzugeben.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) steuert, was Aspose.Slides lädt; es entschlüsselt nichts. Wenn die Eigenschaften in die Verschlüsselung einbezogen wurden, schlägt das Laden ohne Passwort fehl. Ist die Präsentation nicht verschlüsselt, wird die Option ignoriert und die gesamte Präsentation geladen.

Das Beispiel erfordert eine verschlüsselte Präsentation, deren Dokumenteigenschaften öffentlich belassen wurden. Es prüft den Lademodus über [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) und liest anschließend eingebaute Eigenschaften über [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) :

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

In diesem Modus wird der Folieninhalt nicht geladen. Folien, Folienmaster, Layouts, Formen, Medien und andere Präsentationsobjekte sind nicht verfügbar. Anwendungen sollten stets [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) prüfen, bevor sie einen Vorgang ausführen, der das vollständige Präsentationsobjektmodell erfordert.

{{% alert color="warning" title="Security" %}}
Öffentliche Metadaten können Autorennamen, Titel, Betreff, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte offenbaren. Verschlüsseln Sie sensible Eigenschaften zusammen mit der Präsentation. Lassen Sie sie nur dann öffentlich, wenn Indexierungs‑, Klassifizierungs‑, Such‑ oder Dokumentenverwaltungssysteme eine spezifische Anforderung haben, ohne Passwort darauf zuzugreifen.
{{% /alert %}}

## **Eigenschaften einer verschlüsselten Präsentation aktualisieren**

Für eine verschlüsselte PPTX‑Datei ist eine Präsentation, die mit [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) geladen wurde, zum Lesen öffentlicher Metadaten gedacht. Aspose.Slides kann geänderte Eigenschaften aus diesem rein metadata‑basierten Objekt nicht speichern, da die öffentlichen Eigenschaften mit den entsprechenden Daten in der verschlüsselten Präsentation konsistent bleiben müssen. Die Aktualisierung erfordert daher das korrekte Öffnungspasswort und einen vollständigen Ladevorgang.

Das Beispiel erfordert eine verschlüsselte PPTX‑Präsentation mit öffentlichen Dokumenteigenschaften und einem bekannten Öffnungspasswort. Es öffnet die komplette Präsentation mit [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) , aktualisiert öffentliche eingebaute Eigenschaften und speichert das Ergebnis. Anschließend wird mit [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) geprüft, dass die Verschlüsselung erhalten bleibt, und die öffentlichen Metadaten werden ohne Passwort erneut geöffnet, um die neuen Werte zu verifizieren :

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

Ist einer Anwendung das Entschlüsseln oder Laden des Präsentationsinhalts nicht gestattet, muss sie öffentliche Eigenschaften einer verschlüsselten PPTX‑Datei als schreibgeschützt behandeln.

## **Zugriff auf eingebaute Eigenschaften**

Die Klasse [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) stellt eingebaute Metadaten über typisierte Eigenschaften bereit, einschließlich [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) und [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). Dieses Beispiel öffnet eine vorhandene Präsentation und gibt ihre gespeicherten Metadaten in der Konsole aus. Die Werte hängen von der Eingabepäsentation ab; einige Felder können leer sein.

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

### **Revisionsnummer und Bearbeitungszeit melden**

Um die Revisionsnummer und die gesamte Bearbeitungszeit für jede PPTX‑Datei im Ordner `presentations` zu melden, verwenden Sie [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) , um dessen [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) abzurufen, ohne die Folien für die Bearbeitung zu laden. Python zeigt die Dauer als `timedelta` an, wobei bei einer Aufzeichnungszeit von 24 Stunden der Tag‑Zähler mit einbezogen wird.

```python
from pathlib import Path

import aspose.slides as slides

print("File | RevisionNumber | TotalEditingTime")
for path in Path("presentations").glob("*.pptx"):
    if path.is_file():
        info = slides.PresentationFactory.instance.get_presentation_info(str(path))
        properties = info.read_document_properties()
        print(f"{path.name} | {properties.revision_number} | {properties.total_editing_time}")
```

Für eine Präsentation mit 1 Tag, 2 Stunden und 5 Minuten aufgezeichneter Bearbeitungszeit enthält der Bericht die folgende Zeile.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1 day, 2:05:00
```

[DocumentProperties.revision_number](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/revision_number/) ist schreibbare Metadaten. Sein Wert allein kann nicht bestimmen, wie oft die Präsentation gespeichert wurde oder die Versionshistorie rekonstruieren.

[DocumentProperties.total_editing_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/total_editing_time/) gibt die in der Datei gespeicherte Bearbeitungsdauer an. Ein Wert von `0:00:00` bedeutet, dass die aufgezeichnete Dauer null beträgt, selbst wenn jemand die Präsentation bearbeitet hat.

## **Eingebaute Eigenschaften ändern**

Um eingebaute Metadaten zu aktualisieren, weisen Sie den schreibbaren Eigenschaften, die von [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) bereitgestellt werden, Werte zu. Dieses Beispiel öffnet eine vorhandene Präsentation, setzt [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/) und [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/), speichert anschließend die aktualisierte Präsentation mit [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Die gespeicherte PPTX‑Datei enthält die neuen Metadaten.

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

## **Hyperlink‑Basis verwalten**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) speichert die dokumentweite Basis für relative Hyperlinks. Dies ist nützlich, wenn eine Präsentation und ihre verknüpften Dateien an einen anderen Ort verschoben werden. Sie ist von der einzelnen Hyperlink‑Eigenschaft [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) getrennt: Das Ändern der Basis überschreibt nicht die gespeicherten Link‑Adressen und ändert keine absoluten Ziele.

Das Beispiel erfordert eine Präsentation, die sowohl einen relativen Link, z. B. `target.html`, als auch einen absoluten Link zu einer Datei oder Website enthält. Es liest die vorhandene Basis, weist eine neue Basisadresse zu und speichert sowie öffnet die Präsentation erneut, um den Wert zu prüfen. Anschließend wird die Basis mit `""` geleert und der leere Wert in einer separaten gespeicherten Datei verifiziert. Ersetzen Sie die Beispiel‑Basisadresse durch den Ort Ihrer verknüpften Dateien.

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

Ein relativer Link zu `target.pptx` öffnete `old/target.pptx`, als die Basis auf den Ordner `old` zeigte. Nach dem Ändern der Basis auf den Ordner `new`, dem Speichern und erneutem Öffnen der Präsentation öffnete derselbe Link `new/target.pptx`. Ein absoluter Link öffnete weiterhin dieselbe Datei. Testen Sie Ihre relativen Links in PowerPoint vor und nach dem Verschieben der Präsentation oder dem Ändern ihrer Basis.

## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**

Benutzerdefinierte Eigenschaften speichern Metadaten, für die es kein entsprechendes eingebautes Feld gibt. Die Methode [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) ermöglicht das Zuweisen eines Werts anhand des Eigenschaftsnamens. Dieses Beispiel erstellt eine Präsentation, fügt zwei Textwerte und einen ganzzahligen Versionswert hinzu und speichert die Präsentation mit [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Das Zuweisen eines Werts zu einem bereits bestehenden Namen überschreibt den Wert dieser Eigenschaft.

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

Dieses Beispiel öffnet eine Präsentation, die benutzerdefinierte Eigenschaften enthält, und verwendet [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/), um über sie zu iterieren. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) akzeptiert einen nullbasierten Index und gibt den Namen zurück, der von [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) verwendet wird. Das Beispiel erfordert eine Präsentation, deren benutzerdefinierte Eigenschaften ausschließlich Zeichenketten sind. Es gibt jeden ursprünglichen Namen und Wert aus, ersetzt jeden Wert durch eine nummerierte Zeichenkette und speichert die Änderungen. Gibt es keine benutzerdefinierten Eigenschaften, nimmt die Schleife keine Änderungen vor.

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

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) gibt den Wert über die ein‑Element‑Liste zurück, die als zweites Argument übergeben wird. Der Platzhalter muss dem Typ der gespeicherten Eigenschaft entsprechen: Verwenden Sie `[""]` für eine Zeichenkette oder `[0]` für eine Ganzzahl. Ein nicht passender Typ löst eine `InvalidCastException` aus; wählen Sie den Platzhalter gemäß Ihrem benutzerdefinierten Eigenschaftsschema.

## **Live‑Beispiel**

Probieren Sie die Online‑App [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) aus, um zu sehen, wie Sie mit Dokumenteigenschaften mithilfe der Aspose.Slides‑API arbeiten können:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder sie, sofern dies für die jeweilige Eigenschaft zulässig ist, auf leer setzen.

**Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**

Wird eine bereits existent­e benutzerdefinierte Eigenschaft hinzugefügt, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die Präsentation vollständig zu laden?**

Ja. Verwenden Sie [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) und anschließend [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/), um die gespeicherten Dokumentmetadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Instanz zu erzeugen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/python-net/examine-presentation/) für ein vollständiges Bericht‑Beispiel und format‑spezifische Einschränkungen.

**Kann ich öffentliche Eigenschaften einer verschlüsselten Präsentation ohne ihr Öffnungspasswort lesen?**

Ja. Die Präsentation muss mit [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) auf `False` verschlüsselt sein und mit [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) auf `True` geladen werden.

**Kann ich eine verschlüsselte PPTX‑Datei im Dokument‑Eigenschaften‑Nur‑Lademodus aktualisieren?**

Nein. Öffentliche und verschlüsselte Eigenschaftsdaten müssen konsistent bleiben, sodass das Aktualisieren einer verschlüsselten PPTX‑Datei das Laden der kompletten Präsentation mit dem korrekten Öffnungspasswort erfordert.