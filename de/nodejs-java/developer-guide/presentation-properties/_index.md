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
- Integrierte Eigenschaften
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
description: "Beherrschen Sie Präsentationseigenschaften in Aspose.Slides für Node.js via Java und optimieren Sie Suche, Markenauftritt und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einleitung**

Aspose.Slides unterstützt zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Beide Eigenschaftstypen können leicht über die Aspose.Slides‑API zugegriffen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Präsentations‑Dokumenteigenschaften über die [DocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/)‑Klasse. Eine Instanz dieser Klasse wird von der [Presentation.getDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getDocumentProperties)‑Methode zurückgegeben. Die folgenden Beispiele zeigen, wie diese Eigenschaften gelesen, geändert und verwaltet werden können.

{{% alert color="info" title="Hinweis" %}}
Bitte beachten Sie, dass die Felder **Application** und **AppVersion** nicht geändert werden können. Aspose.Slides überschreibt sie bei jedem Speichern, sodass eine gespeicherte Präsentation immer "Aspose.Slides for Node.js via Java" und die Version der Bibliothek, die sie erzeugt hat, meldet. Jeder an `setNameOfApplication` übergebene Wert wird beim Schreiben der Präsentation verworfen.
{{% /alert %}} 

## **Präsentationseigenschaften verwalten**

Microsoft PowerPoint bietet eine Funktion, um einige Eigenschaften zu den Präsentationsdateien hinzuzufügen. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (Built-in) Eigenschaften
- Benutzerdefinierte (Custom) Eigenschaften

**Built-in**‑Eigenschaften enthalten allgemeine Informationen über das Dokument wie Dokumenttitel, Autorenname, Dokumentstatistiken usw. **Custom**‑Eigenschaften sind solche, die von den Benutzern als **Name/Wert**‑Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides für Node.js via Java können Entwickler die Werte integrierter Eigenschaften sowie benutzerdefinierter Eigenschaften abrufen und ändern.

## **Dokumenteigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht das Verwalten der Dokumenteigenschaften von Präsentationsdateien. Klicken Sie einfach auf das Office‑Symbol und anschließend auf **Prepare | Properties | Advanced Properties** im Menü von Microsoft PowerPoint 2007, wie unten gezeigt:

|**Auswahl des Menüpunkts Erweiterte Eigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Nach dem Auswählen des Menüpunkts **Advanced Properties** erscheint ein Dialog, der Ihnen das Verwalten der Dokumenteigenschaften der PowerPoint‑Datei ermöglicht, wie in der nachfolgenden Abbildung dargestellt:

|**Eigenschaftendialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Im obigen **Eigenschaftendialog** sehen Sie viele Registerkarten wie **General**, **Summary**, **Statistics**, **Contents** und **Custom**. Alle diese Registerkarten erlauben die Konfiguration verschiedener Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Custom** wird verwendet, um die benutzerdefinierten Eigenschaften der PowerPoint‑Dateien zu verwalten.

### Arbeiten mit Dokumenteigenschaften mit Aspose.Slides für Node.js via Java

Wie bereits beschrieben, unterstützt Aspose.Slides für Node.js via Java zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Entwickler können beide Arten von Eigenschaften über die Aspose.Slides‑API nutzen. Aspose.Slides für Node.js via Java stellt die Klasse [DocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties) bereit, die die Dokumenteigenschaften einer Präsentationsdatei über die **Presentation.DocumentProperties**‑Eigenschaft repräsentiert.

Entwickler können die **DocumentProperties**‑Eigenschaft, die vom [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation)‑Objekt bereitgestellt wird, nutzen, um die Dokumenteigenschaften der Präsentationsdateien wie unten beschrieben abzurufen:

## **Zugriff auf **Built-in** Eigenschaften**

Diese über das [DocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties)‑Objekt bereitgestellten Eigenschaften umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Letztes Druckdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wird zwischen verschiedenen Produzenten geteilt?), **PresentationFormat**, **Subject** und **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziiere die Presentation-Klasse, die die Präsentation darstellt
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz zum IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    var dp = pres.getDocumentProperties();
    // Zeige die integrierten Eigenschaften an
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

## **Integrierte Eigenschaften ändern**

Das Ändern integrierter Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einem gewünschten Property einen String‑Wert zuweisen und der Property‑Wert wird geändert. Im nachfolgenden Beispiel zeigen wir, wie die integrierten Dokumenteigenschaften einer Präsentationsdatei mit Aspose.Slides für Node.js via Java geändert werden können.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz zum IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    var dp = pres.getDocumentProperties();
    // Setze die integrierten Eigenschaften
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

Dieses Beispiel ändert die integrierten Eigenschaften der Präsentation, wie unten dargestellt:

|**Integrierte Dokumenteigenschaften nach Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Benutzerdefinierte Dokumenteigenschaften hinzufügen**

Aspose.Slides für Node.js via Java ermöglicht es Entwicklern zudem, benutzerdefinierte Werte für Präsentations‑Dokumenteigenschaften hinzuzufügen. Das folgende Beispiel zeigt, wie benutzerdefinierte Eigenschaften für eine Präsentation gesetzt werden können.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Abrufen der Dokumenteigenschaften
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

|**Hinzugefügte benutzerdefinierte Dokumenteigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**

Aspose.Slides für Node.js via Java ermöglicht es Entwicklern außerdem, die Werte benutzerdefinierter Eigenschaften abzurufen. Das folgende Beispiel zeigt, wie Sie alle diese benutzerdefinierten Eigenschaften einer Präsentation abrufen und ändern können.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz zum DocumentProperties-Objekt, das mit der Präsentation verbunden ist
    var dp = pres.getDocumentProperties();
    // Zugriff auf und Ändern benutzerdefinierter Eigenschaften
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

Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Präsentation. Die nachfolgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Benutzerdefinierte Eigenschaften nach Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteigenschaften**

{{% alert color="info" title="Hinweis" %}}
Neue Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), und [WriteBindedPresentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) wurden zu [PresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PresentationInfo) hinzugefügt, die Logik des Setters für die Eigenschaft [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) wurde geändert.
{{% /alert %}} 

Die beiden neuen Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) und [UpdateDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) wurden zur Klasse [PresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/PresentationInfo) hinzugefügt. Sie ermöglichen einen schnellen Zugriff auf Dokumenteigenschaften und erlauben das Ändern und Aktualisieren von Eigenschaften, ohne die gesamte Präsentation zu laden.

Das typische Szenario, bei dem die Eigenschaften geladen, ein Wert geändert und das Dokument aktualisiert wird, lässt sich wie folgt umsetzen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// lese die Informationen der Präsentation
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// erhalte die aktuellen Eigenschaften
var props = info.readDocumentProperties();
// setze die neuen Werte der Felder Author und Title
props.setAuthor("New Author");
props.setTitle("New Title");
// aktualisiere die Präsentation mit neuen Werten
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

Eine neue Vorlage kann von Grund auf erstellt und dann verwendet werden, um mehrere Präsentationen zu aktualisieren:

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

## **Rechtschreibsprache festlegen**

Aspose.Slides stellt die Eigenschaft LanguageId (bereitgestellt durch die Klasse PortionFormat) bereit, um die Rechtschreibsprache für ein PowerPoint‑Dokument festzulegen. Die Rechtschreibsprache ist die Sprache, für die Rechtschreibung und Grammatik im PowerPoint geprüft werden.

Dieser JavaScript‑Code zeigt, wie die Rechtschreibsprache für ein PowerPoint‑Dokument gesetzt wird: xxx Warum fehlt LanguageId in der JavaScript‑PortionFormat‑Klasse?

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
    portionFormat.setLanguageId("zh-CN");// set the Id of a proofing language
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Standard‑Sprache festlegen**

Dieser JavaScript‑Code zeigt, wie die Standardsprache für eine gesamte PowerPoint‑Präsentation gesetzt wird:

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

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/de/metadata) aus, um zu sehen, wie Sie über die Aspose.Slides‑API mit Dokumenteigenschaften arbeiten können:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## **FAQ**

**Wie kann ich eine integrierte Eigenschaft aus einer Präsentation entfernen?**

Integrierte Eigenschaften sind ein fester Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch ihre Werte ändern oder, sofern die jeweilige Eigenschaft dies zulässt, auf einen leeren Wert setzen.

**Was passiert, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?**

Wird eine bereits vorhandene benutzerdefinierte Eigenschaft hinzugefügt, wird ihr vorhandener Wert durch den neuen überschrieben. Ein vorheriges Entfernen oder Überprüfen der Eigenschaft ist nicht nötig, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden?**

Ja. Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) und anschließend [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/), um gespeicherte Dokumentmetadaten zu lesen, ohne ein [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)‑Objekt zu erstellen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/nodejs-java/examine-presentation/) für ein vollständiges Berichtbeispiel und formatspezifische Einschränkungen.