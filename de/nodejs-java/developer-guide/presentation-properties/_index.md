---
title: Präsentationseigenschaften in JavaScript verwalten
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/nodejs-java/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- Eingebaute Eigenschaften
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Beherrschen Sie Präsentationseigenschaften in Aspose.Slides für Node.js via Java und optimieren Sie Suche, Branding und Arbeitsablauf in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einführung**

Aspose.Slides unterstützt zwei Arten von Dokumenteneigenschaften: **Eingebaute** und **Benutzerdefinierte**. Beide Eigenschaftstypen können mit der Aspose.Slides‑API einfach zugegriffen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteneigenschaften von Präsentationen über die Klasse [DocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/) . Eine Instanz dieser Klasse wird von der Methode [Presentation.getDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getDocumentProperties) zurückgegeben. Die folgenden Beispiele zeigen, wie diese Eigenschaften gelesen, geändert und verwaltet werden können.

{{% alert color="info" title="Hinweis" %}}
Bitte beachten Sie, dass die Felder **Application** und **AppVersion** nicht geändert werden können. Aspose.Slides überschreibt sie bei jedem Speichern, sodass eine gespeicherte Präsentation immer "Aspose.Slides for Node.js via Java" und die Version der Bibliothek, die sie erstellt hat, meldet. Jeder an `setNameOfApplication` übergebene Wert wird beim Schreiben der Präsentation verworfen.
{{% /alert %}} 

## **Präsentationseigenschaften verwalten**

Microsoft PowerPoint bietet eine Funktion, um einigen Präsentationsdateien Eigenschaften hinzuzufügen. Diese Dokumenteneigenschaften ermöglichen das Speichern nützlicher Informationen zusammen mit den Dokumenten (Präsentationsdateien). Es gibt zwei Arten von Dokumenteneigenschaften:

- Systemdefinierte (eingebaute) Eigenschaften
- Benutzerdefinierte (eigene) Eigenschaften

**Eingebaute** Eigenschaften enthalten allgemeine Informationen über das Dokument, wie Dokumenttitel, Autorenname, Dokumentstatistiken usw. **Benutzerdefinierte** Eigenschaften sind solche, die von den Benutzern als **Name/Wert**‑Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides für Node.js via Java können Entwickler sowohl die Werte eingebauter als auch benutzerdefinierter Eigenschaften abrufen und ändern.

## **Dokumenteneigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht das Verwalten der Dokumenteneigenschaften von Präsentationsdateien. Klicken Sie einfach auf das Office‑Symbol und anschließend auf den Menüpunkt **Vorbereiten | Eigenschaften | Erweiterte Eigenschaften** von Microsoft PowerPoint 2007, wie unten dargestellt:

|**Auswahl des Menüpunkts Erweiterte Eigenschaften**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Nachdem Sie den Menüpunkt **Erweiterte Eigenschaften** ausgewählt haben, erscheint ein Dialog, der das Verwalten der Dokumenteneigenschaften der PowerPoint‑Datei ermöglicht, wie in der Abbildung unten zu sehen ist:

|**Eigenschaftendialog**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
In dem obigen **Eigenschaftendialog** sehen Sie viele Registerkarten wie **Allgemein**, **Zusammenfassung**, **Statistik**, **Inhalt** und **Benutzerdefiniert**. Alle diese Registerkarten erlauben das Konfigurieren verschiedener Informationen, die mit den PowerPoint‑Dateien verbunden sind. Die Registerkarte **Benutzerdefiniert** wird verwendet, um benutzerdefinierte Eigenschaften zu verwalten.

Arbeiten mit Dokumenteneigenschaften mit Aspose.Slides für Node.js via Java

Wie bereits beschrieben, unterstützt Aspose.Slides für Node.js via Java zwei Arten von Dokumenteneigenschaften, nämlich **Eingebaute** und **Benutzerdefinierte** Eigenschaften. Entwickler können beide Arten von Eigenschaften über die Aspose.Slides‑API nutzen. Aspose.Slides für Node.js via Java stellt die Klasse [DocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties) bereit, die die Dokumenteneigenschaften einer Präsentationsdatei über die Eigenschaft **Presentation.DocumentProperties** repräsentiert.

Entwickler können die über das Objekt [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation) bereitgestellte **DocumentProperties**‑Eigenschaft verwenden, um die Dokumenteneigenschaften der Präsentationsdateien wie unten beschrieben abzurufen:

## **Öffentliche Eigenschaften einer verschlüsselten Präsentation lesen**

Ein Öffnungskennwort schützt normalerweise sowohl den Präsentationsinhalt als auch die Dokumenteneigenschaften. Wenn eine Präsentation verschlüsselt wird, indem `false` an [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) übergeben wird, bleiben ihre Dokumenteneigenschaften öffentlich. Eine Anwendung kann dann `true` an [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) übergeben und die öffentlichen Metadaten lesen, ohne das Öffnungskennwort anzugeben.

Die Option „nur Dokumenteneigenschaften laden“ steuert, was Aspose.Slides lädt; sie entschlüsselt nichts. Wenn die Eigenschaften in die Verschlüsselung einbezogen wurden, schlägt das Laden ohne Kennwort fehl. Ist die Präsentation nicht verschlüsselt, wird die Option ignoriert und die vollständige Präsentation geladen.

Das folgende Beispiel prüft den Lademodus über [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) und liest dann eingebaute Eigenschaften über [Presentation.getDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

In diesem Modus werden Folieninhalte nicht geladen. Folien, Vorlagen, Layouts, Formen, Medien und andere Präsentationsobjekte sind nicht verfügbar. Anwendungen sollten stets [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) prüfen, bevor sie Vorgänge ausführen, die das vollständige Präsentationsobjektmodell benötigen.

{{% alert color="warning" title="Warnung" %}}
Öffentliche Metadaten können Autorennamen, Titel, Betreff, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte preisgeben. Verschlüsseln Sie sensible Eigenschaften zusammen mit der Präsentation. Lassen Sie sie nur öffentlich, wenn Indexierungs‑, Klassifizierungs‑, Such‑ oder Dokumenten‑Management‑Systeme einen spezifischen Zugriff ohne Kennwort benötigen.
{{% /alert %}}

## **Eigenschaften einer verschlüsselten Präsentation aktualisieren**

Für eine verschlüsselte PPTX‑Datei ist eine im Modus „nur Dokumenteneigenschaften“ geladene Präsentation zum Lesen öffentlicher Metadaten gedacht. Aspose.Slides kann geänderte Eigenschaften aus diesem metadata‑only‑Objekt nicht speichern, da die öffentlichen Eigenschaften mit den entsprechenden Daten in der verschlüsselten Präsentation konsistent bleiben müssen. Das Aktualisieren erfordert daher das korrekte Öffnungskennwort und ein vollständiges Laden.

Das folgende Beispiel öffnet die Präsentation mit [LoadOptions.setPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setPassword), aktualisiert öffentliche eingebaute Eigenschaften und speichert das Ergebnis. Anschließend wird mit [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) geprüft, ob die Verschlüsselung erhalten bleibt, und die öffentlichen Metadaten werden ohne Kennwort erneut geöffnet, um die neuen Werte zu prüfen:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Darf eine Anwendung die Präsentationsinhalte nicht entschlüsseln oder laden, muss sie die öffentlichen Eigenschaften einer verschlüsselten PPTX‑Datei als schreibgeschützt behandeln.

## **Zugriff auf eingebaute Eigenschaften**

Diese von [DocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties) bereitgestellten Eigenschaften umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **Keywords**, **SharedDoc** (Ist das Dokument zwischen verschiedenen Erstellern geteilt?), **PresentationFormat**, **Subject** und **Title**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziiere die Presentation‑Klasse, die die Präsentation darstellt
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz zum IDocumentProperties‑Objekt, das mit der Präsentation verknüpft ist
    var dp = pres.getDocumentProperties();
    // Zeige die eingebauten Eigenschaften an
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Eingebaute Eigenschaften ändern**

Das Ändern der eingebauten Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einem gewünschten Feld einen String‑Wert zuweisen und der Eigenschaftenwert wird geändert. Im nachfolgenden Beispiel zeigen wir, wie die eingebauten Dokumenteneigenschaften einer Präsentation mit Aspose.Slides für Node.js via Java geändert werden können.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz zum IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    var dp = pres.getDocumentProperties();
    // Setze die eingebauten Eigenschaften
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Speichere deine Präsentation in einer Datei
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Dieses Beispiel ändert die eingebauten Eigenschaften der Präsentation, wie unten zu sehen:

|**Eingebaute Dokumenteigenschaften nach Änderung**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Benutzerdefinierte Dokumenteigenschaften hinzufügen**

Aspose.Slides für Node.js via Java ermöglicht Entwicklern auch das Hinzufügen benutzerdefinierter Werte zu den Dokumenteneigenschaften einer Präsentation. Das folgende Beispiel zeigt, wie benutzerdefinierte Eigenschaften für eine Präsentation gesetzt werden.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Abrufen von Dokumenteigenschaften
    var dProps = pres.getDocumentProperties();
    // Hinzufügen benutzerdefinierter Eigenschaften
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Abrufen des Eigenschaftsnamens an einem bestimmten Index
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Entfernen der ausgewählten Eigenschaft
    dProps.removeCustomProperty(getPropertyName);
    // Speichern der Präsentation
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Hinzugefügte benutzerdefinierte Dokumenteigenschaften**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Benutzerdefinierte Eigenschaften anzeigen und ändern**

Aspose.Slides für Node.js via Java ermöglicht Entwicklern auch das Abrufen und Ändern benutzerdefinierter Eigenschaften. Das folgende Beispiel zeigt, wie alle diese benutzerdefinierten Eigenschaften einer Präsentation gelesen und geändert werden können.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz zum DocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    var dp = pres.getDocumentProperties();
    // Greife auf benutzerdefinierte Eigenschaften zu und ändere sie
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Zeige Namen und Werte benutzerdefinierter Eigenschaften an
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Ändere Werte benutzerdefinierter Eigenschaften
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Speichere deine Präsentation in einer Datei
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Präsentation. Die nachstehenden Abbildungen zeigen die benutzerdefinierten Eigenschaften vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor der Änderung**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Benutzerdefinierte Eigenschaften nach der Änderung**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteneigenschaften**

{{% alert color="info" title="Hinweis" %}}
Neue Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), und [WriteBindedPresentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) wurden zu [PresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PresentationInfo) hinzugefügt, die Logik des Setters der Eigenschaft [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) wurde geändert.
{{% /alert %}} 

Die beiden neuen Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) und [UpdateDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) wurden zur Klasse [PresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PresentationInfo) hinzugefügt. Sie ermöglichen schnellen Zugriff auf Dokumenteneigenschaften und erlauben das Ändern und Aktualisieren von Eigenschaften, ohne die gesamte Präsentation zu laden.

Das typische Szenario, Eigenschaften zu laden, einen Wert zu ändern und das Dokument zu aktualisieren, lässt sich wie folgt umsetzen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Lese die Informationen der Präsentation
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// Erhalte die aktuellen Eigenschaften
var props = info.readDocumentProperties();
// Setze die neuen Werte für die Felder Autor und Titel
props.setAuthor("New Author");
props.setTitle("New Title");
// Aktualisiere die Präsentation mit den neuen Werten
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Eine weitere Möglichkeit besteht darin, die Eigenschaften einer bestimmten Präsentation als Vorlage zu verwenden, um Eigenschaften in anderen Präsentationen zu aktualisieren:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Eine neue Vorlage kann von Grund auf erstellt und dann zum Aktualisieren mehrerer Präsentationen verwendet werden:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Korrektursprache festlegen**

Aspose.Slides stellt die Eigenschaft LanguageId (exponiert durch die Klasse PortionFormat) bereit, um die Korrektursprache für ein PowerPoint‑Dokument festzulegen. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint geprüft werden.

Der folgende JavaScript‑Code zeigt, wie die Korrektursprache für ein PowerPoint‑Dokument festgelegt wird: xxx Warum fehlt LanguageId in der JavaScript‑Klasse PortionFormat?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// setzt die ID einer Korrektursprache
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Standard‑Sprache festlegen**

Der folgende JavaScript‑Code zeigt, wie die Standardsprache für eine gesamte PowerPoint‑Präsentation festgelegt wird:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Fügt eine neue Rechteckform mit Text hinzu
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Prüft die Sprache des ersten Abschnitts
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Live‑Beispiel**

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/de/metadata) aus, um zu sehen, wie Sie über die Aspose.Slides‑API mit Dokumenteneigenschaften arbeiten:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## **FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind integraler Bestandteil einer Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder sie, sofern die jeweilige Eigenschaft dies zulässt, auf leer setzen.

**Was passiert, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?**

Wird eine bereits vorhandene benutzerdefinierte Eigenschaft hinzugefügt, wird ihr bestehender Wert durch den neuen überschrieben. Es ist nicht nötig, die Eigenschaft vorher zu entfernen oder zu prüfen, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden?**

Ja. Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) und anschließend [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/), um gespeicherte Dokumentenmetadaten zu lesen, ohne ein [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Objekt zu erstellen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/nodejs-java/examine-presentation/) für ein vollständiges Reporting‑Beispiel und formatbezogene Einschränkungen.

**Kann ich öffentliche Eigenschaften einer verschlüsselten Präsentation ohne deren Öffnungskennwort lesen?**

Ja. Die Verschlüsselung der Dokumenteneigenschaften muss vor dem Verschlüsseln der Präsentation deaktiviert worden sein, und die Präsentation muss im Modus „nur Dokumenteneigenschaften“ geladen werden.

**Kann ich eine verschlüsselte PPTX‑Datei im Modus „nur Dokumenteneigenschaften“ aktualisieren?**

Nein. Öffentliche und verschlüsselte Eigenschaftsdaten müssen konsistent bleiben; das Aktualisieren einer verschlüsselten PPTX‑Datei erfordert das Laden der vollständigen Präsentation mit dem korrekten Öffnungskennwort.