---
title: Verwalten von Präsentationseigenschaften in Python
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/python-java/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- Standard-Eigenschaften
- Benutzerdefinierte Eigenschaften
- Erweiterte Eigenschaften
- Eigenschaften verwalten
- Eigenschaften ändern
- Dokument-Metadaten
- Metadaten bearbeiten
- Korrektursprache
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie Präsentationseigenschaften in Aspose.Slides für Python via Java und optimieren Sie Suche, Branding und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einleitung**

Aspose.Slides unterstützt zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Beide Eigenschaftstypen können einfach über die Aspose.Slides API zugegriffen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteigenschaften von Präsentationen über die Klasse [DocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/) . Eine Instanz dieser Klasse wird von [Presentation.getDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getDocumentProperties) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" title="Note" %}}
Bitte beachten Sie, dass die Felder **Application** und **AppVersion** nicht geändert werden können. Aspose.Slides überschreibt sie bei jedem Speichern, sodass eine gespeicherte Präsentation immer "Aspose.Slides for Java" und die Version der Bibliothek, die sie erzeugt hat, angibt. Jeder an [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#setNameOfApplication) übergebene Wert wird verworfen, wenn die Präsentation geschrieben wird.
{{% /alert %}}

## **Dokumenteigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht das Verwalten der Dokumenteigenschaften von Präsentationsdateien. Klicken Sie auf das Office‑Symbol und wählen Sie **Prepare | Properties | Advanced Properties**, wie unten gezeigt:

|**Erweiterte Eigenschaften auswählen**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/ZrmuCD6.jpg)|
Nachdem Sie **Advanced Properties** ausgewählt haben, erscheint ein Dialog, in dem Sie die Dokumenteigenschaften der PowerPoint‑Datei verwalten können:

|**Dialogfeld Eigenschaften**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/LibmdQd.jpg)|
Das **Dialogfeld Eigenschaften** enthält Registerkarten wie **General**, **Summary**, **Statistics**, **Contents** und **Custom**. Diese Registerkarten ermöglichen die Konfiguration verschiedener Informationen zu PowerPoint‑Dateien. Verwenden Sie die Registerkarte **Custom**, um benutzerdefinierte Eigenschaften zu verwalten.

## **Arbeiten mit Dokumenteigenschaften mithilfe von Aspose.Slides für Python über Java**

Wie bereits beschrieben, unterstützt Aspose.Slides für Python über Java sowohl **Built-in** als auch **Custom** Dokumenteigenschaften. Die Klasse [DocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/) repräsentiert die Dokumenteigenschaften, die mit einer Präsentationsdatei verbunden sind.

Verwenden Sie [Presentation.getDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getDocumentProperties), um auf diese Eigenschaften zuzugreifen, wie nachfolgend beschrieben.

## **Öffentliche Eigenschaften aus einer verschlüsselten Präsentation lesen**

Ein Öffnungskennwort schützt normalerweise sowohl den Präsentationsinhalt als auch die Dokumenteigenschaften. Wenn eine Präsentation durch Übergeben von `false` an [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) verschlüsselt wird, bleiben ihre Dokumenteigenschaften öffentlich. Eine Anwendung kann dann `true` an [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) übergeben und die öffentlichen Metadaten lesen, ohne das Öffnungskennwort anzugeben.

Die Option „nur Dokumenteigenschaften laden“ steuert, was Aspose.Slides lädt; sie entschlüsselt nichts. Wenn die Eigenschaften in die Verschlüsselung einbezogen wurden, schlägt das Laden ohne Kennwort fehl. Ist die Präsentation nicht verschlüsselt, wird die Option ignoriert und die gesamte Präsentation geladen.

Das folgende Beispiel prüft den Lademodus über [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) und liest dann Built-in‑Eigenschaften über [Presentation.getDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getDocumentProperties):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

In diesem Modus wird der Folieninhalt nicht geladen. Folien, Master‑Folien, Layouts, Formen, Medien und andere Präsentationsobjekte sind nicht verfügbar. Anwendungen sollten stets [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/de/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) prüfen, bevor sie eine Operation ausführen, die das komplette Objektmodell der Präsentation erfordert.

{{% alert color="warning" title="Warning" %}}
Öffentliche Metadaten können Autorennamen, Titel, Themen, Schlüsselwörter, Firmeninformationen, Kommentare und benutzerdefinierte Werte preisgeben. Verschlüsseln Sie sensible Eigenschaften zusammen mit der Präsentation. Lassen Sie sie nur dann öffentlich, wenn Indexierungs‑, Klassifizierungs‑, Such‑ oder Dokumenten‑Management‑Systeme einen spezifischen Zugriff ohne Kennwort benötigen.
{{% /alert %}}

## **Eigenschaften einer verschlüsselten Präsentation aktualisieren**

Für eine verschlüsselte PPTX‑Datei ist eine Präsentation, die im Modus „nur Dokumenteigenschaften“ geladen wurde, zum Lesen öffentlicher Metadaten gedacht. Aspose.Slides kann aus diesem rein‑metadaten‑Objekt keine geänderten Eigenschaften speichern, da die öffentlichen Eigenschaften konsistent mit den entsprechenden verschlüsselten Daten bleiben müssen. Eine Aktualisierung erfordert daher das korrekte Öffnungskennwort und ein vollständiges Laden.

Das folgende Beispiel öffnet die Präsentation mit [LoadOptions.setPassword](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setPassword), aktualisiert öffentliche Built-in‑Eigenschaften und speichert das Ergebnis. Anschließend wird mit [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#isEncrypted) geprüft, ob die Verschlüsselung erhalten blieb, und die öffentlichen Metadaten werden erneut ohne Kennwort geladen, um die neuen Werte zu prüfen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

Ist einer Anwendung das Entschlüsseln oder Laden des Präsentationsinhalts nicht gestattet, muss sie öffentliche Eigenschaften einer verschlüsselten PPTX‑Datei als schreibgeschützt behandeln.

## **Auf Built-in‑Eigenschaften zugreifen**

Die von [DocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/) bereitgestellten Built-in‑Eigenschaften umfassen: **Creator** (Autor), **Description**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Letztes Druckdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Ist zwischen verschiedenen Erstellern geteilt?), **PresentationFormat**, **Subject** und **Title**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Instanziieren der Presentation-Klasse, die die Präsentation darstellt
presentation = Presentation("Presentation.pptx")
try:
    # Erstellen einer Referenz zum DocumentProperties-Objekt, das mit der Presentation verknüpft ist
    properties = presentation.getDocumentProperties()

    # Anzeige der integrierten Eigenschaften
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Built-in‑Eigenschaften ändern**

Das Ändern von Built-in‑Eigenschaften ist genauso einfach wie ihr Zugriff. Verwenden Sie den entsprechenden Setter, um einen neuen Wert zuzuweisen. Das folgende Beispiel ändert Built-in‑Dokumenteigenschaften mithilfe von Aspose.Slides für Python über Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Erstellen einer Referenz zum DocumentProperties-Objekt, das mit der Presentation verknüpft ist
    properties = presentation.getDocumentProperties()

    # Setzen der integrierten Eigenschaften
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Präsentation in einer Datei speichern
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dieses Beispiel ändert die Built-in‑Eigenschaften der Präsentation, wie unten dargestellt:

|**Built-in‑Dokumenteigenschaften nach der Änderung**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/zz1N9de.jpg)|

## **Benutzerdefinierte Dokumenteigenschaften hinzufügen**

Aspose.Slides für Python über Java ermöglicht es Entwicklern außerdem, benutzerdefinierte Dokumenteigenschaften zu Präsentationen hinzuzufügen. Das nachstehende Beispiel fügt drei benutzerdefinierte Eigenschaften hinzu, sucht dann den Namen, der an Index 2 gespeichert ist, und entfernt diese Eigenschaft, sodass die gespeicherte Präsentation zwei davon behält. Benutzerdefinierte Eigenschaften werden alphabetisch sortiert, nicht in der Reihenfolge ihrer Hinzufügung.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Abrufen der Dokumenteigenschaften
    properties = presentation.getDocumentProperties()

    # Hinzufügen benutzerdefinierter Eigenschaften
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Abrufen des Eigenschaftsnames an einem bestimmten Index
    property_name = properties.getCustomPropertyName(2)

    # Ausgewählte Eigenschaft entfernen
    properties.removeCustomProperty(property_name)

    # Präsentation speichern
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Hinzugefügte benutzerdefinierte Dokumenteigenschaften**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/HdKcxI9.png)|

## **Benutzerdefinierte Eigenschaften lesen und ändern**

Aspose.Slides für Python über Java ermöglicht es Entwicklern außerdem, die Werte benutzerdefinierter Eigenschaften auszulesen. Das folgende Beispiel zeigt, wie alle benutzerdefinierten Eigenschaften einer Präsentation gelesen und geändert werden können.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Erstellen einer Referenz zum DocumentProperties-Objekt, das mit der Presentation verknüpft ist
    properties = presentation.getDocumentProperties()

    # Zugriff auf und Änderungen benutzerdefinierter Eigenschaften
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Namen und Werte benutzerdefinierter Eigenschaften anzeigen
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Werte benutzerdefinierter Eigenschaften ändern
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Präsentation in einer Datei speichern
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Präsentation. Die folgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor der Änderung**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Ze7YHvi.jpg)|

|**Benutzerdefinierte Eigenschaften nach der Änderung**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Tofu0CL.jpg)|

## **Erweiterte Dokumenteigenschaften**

{{% alert color="info" title="Note" %}}
Neue Methoden [readDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) und [writeBindedPresentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) wurden zur Klasse [PresentationInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/) hinzugefügt, und das Verhalten der Methode [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#setLastSavedTime) hat sich geändert.
{{% /alert %}}

Die beiden neuen Methoden [readDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#readDocumentProperties) und [updateDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) wurden der Klasse [PresentationInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/) hinzugefügt. Sie ermöglichen schnellen Zugriff auf Dokumenteigenschaften und erlauben das Ändern und Aktualisieren von Eigenschaften, ohne die gesamte Präsentation zu laden.

Der typische Arbeitsablauf zum Laden von Eigenschaften, Ändern ihrer Werte und Aktualisieren des Dokuments kann wie folgt implementiert werden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Präsentationsinformationen lesen
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Aktuelle Eigenschaften abrufen
properties = presentation_info.readDocumentProperties()

# Neue Werte für die Felder Author und Title festlegen
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Präsentation mit den neuen Werten aktualisieren
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

Eine weitere Möglichkeit besteht darin, Eigenschaften einer bestimmten Präsentation als Vorlage zu verwenden, um Eigenschaften in anderen Präsentationen zu aktualisieren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

Eine neue Vorlage kann von Grund auf erstellt und anschließend verwendet werden, um mehrere Präsentationen zu aktualisieren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **Rechtschreibsprache festlegen**

Aspose.Slides stellt die Methode [PortionFormat.setLanguageId](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/#setLanguageId) bereit, mit der Sie die Rechtschreibsprache für ein PowerPoint‑Dokument festlegen können. Die Rechtschreibsprache ist die Sprache, für die Rechtschreibung und Grammatik in der Präsentation geprüft werden.

Dieser Python‑Code zeigt, wie die Rechtschreibsprache für ein PowerPoint‑Dokument festgelegt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # setzt die Id einer Korrektursprache

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Standard‑Sprache festlegen**

Dieser Python‑Code zeigt, wie die Standardsprache für eine gesamte PowerPoint‑Präsentation festgelegt wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # Fügt eine Rechteckform mit Text hinzu
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # Prüft die Sprache des ersten Abschnitts
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Live‑Beispiel**

Probieren Sie die [**Aspose.Slides Metadata**](https://products.aspose.app/slides/de/metadata) Online‑App aus, um zu sehen, wie Sie über die Aspose.Slides‑API mit Dokumenteigenschaften arbeiten:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## **FAQ**

**Wie kann ich eine Built-in‑Eigenschaft aus einer Präsentation entfernen?**

Built-in‑Eigenschaften sind integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, sofern das jeweilige Feld dies zulässt, auf leer setzen.

**Was passiert, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?**

Wird eine bereits vorhandene benutzerdefinierte Eigenschaft hinzugefügt, wird ihr vorhandener Wert durch den neuen überschrieben. Ein vorheriges Entfernen oder Prüfen der Eigenschaft ist nicht nötig, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden?**

Ja. Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationfactory/#getPresentationInfo) und anschließend [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#readDocumentProperties), um gespeicherte Dokumentmetadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Instanz zu erstellen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/python-java/examine-presentation/) für ein vollständiges Reporting‑Beispiel und formatspezifische Einschränkungen.

**Kann ich öffentliche Eigenschaften einer verschlüsselten Präsentation ohne ihr Öffnungskennwort lesen?**

Ja. Die Verschlüsselung der Dokumenteigenschaften muss deaktiviert worden sein, bevor die Präsentation verschlüsselt wurde, und die Präsentation muss im Modus „nur Dokumenteigenschaften“ geladen werden.

**Kann ich eine verschlüsselte PPTX‑Datei im Modus „nur Dokumenteigenschaften“ aktualisieren?**

Nein. Öffentliche und verschlüsselte Eigenschaftsdaten müssen konsistent bleiben, daher erfordert das Aktualisieren einer verschlüsselten PPTX‑Datei das Laden der gesamten Präsentation mit dem korrekten Öffnungskennwort.