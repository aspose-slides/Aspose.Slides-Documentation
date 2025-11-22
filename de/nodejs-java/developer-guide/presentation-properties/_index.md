---
title: Präsentationseigenschaften
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
- Eigenschaften ändern
- Dokumentmetadaten
- Metadaten bearbeiten
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "PowerPoint-Präsentationseigenschaften in JavaScript verwalten"
---

{{% alert color="primary" %}} 

Microsoft PowerPoint bietet eine Funktion, um einigen Eigenschaften zu den Präsentationsdateien hinzuzufügen. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (eingebaute) Eigenschaften
- Benutzerdefinierte (eigene) Eigenschaften

**Eingebaute** Eigenschaften enthalten allgemeine Informationen über das Dokument, wie Dokumenttitel, Autorname, Dokumentstatistiken usw. **Eigene** Eigenschaften sind solche, die von den Benutzern als **Name/Wert**‑Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides für Node.js via Java können Entwickler sowohl die Werte eingebauter Eigenschaften als auch eigener Eigenschaften abrufen und ändern.

{{% /alert %}} 

## **Dokumenteigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften von Präsentationsdateien. Alles, was Sie tun müssen, ist das Office‑Symbol anzuklicken und anschließend den Menüpunkt **Prepare | Properties | Advanced Properties** von Microsoft PowerPoint 2007 wie unten gezeigt auszuwählen:

{{% alert color="primary" %}} 

Bitte beachten Sie, dass Sie keine Werte für die Felder **Application** und **Producer** festlegen können, da Aspose Ltd. und Aspose.Slides for Node.js via Java x.x.x in diesen Feldern angezeigt werden.

{{% /alert %}} 

|**Selecting Advanced Properties menu item**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Nach dem Auswählen des Menüpunktes **Advanced Properties** erscheint ein Dialog, der die Verwaltung der Dokumenteigenschaften der PowerPoint‑Datei ermöglicht, wie in der nachfolgenden Abbildung dargestellt:

|**Eigenschaftendialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Im obigen **Eigenschaftendialog** sehen Sie viele Registerkarten wie **General**, **Summary**, **Statistics**, **Contents** und **Custom**. Alle diese Registerkarten ermöglichen die Konfiguration verschiedener Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Custom** wird verwendet, um die eigenen Eigenschaften der PowerPoint‑Dateien zu verwalten.

Arbeiten mit Dokumenteigenschaften mit Aspose.Slides für Node.js via Java

Wie bereits beschrieben unterstützt Aspose.Slides für Node.js via Java zwei Arten von Dokumenteigenschaften, nämlich **Built-in** und **Custom** Eigenschaften. Entwickler können beide Arten von Eigenschaften über die Aspose.Slides für Node.js via Java API verwenden. Aspose.Slides für Node.js via Java stellt die Klasse [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties) bereit, die die Dokumenteigenschaften einer Präsentationsdatei über die Eigenschaft **Presentation.DocumentProperties** repräsentiert.

Entwickler können die Eigenschaft **DocumentProperties**, die vom Objekt [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) bereitgestellt wird, verwenden, um auf die Dokumenteigenschaften von Präsentationsdateien zuzugreifen, wie unten beschrieben:

## **Zugriff auf eingebaute Eigenschaften**

Diese vom Objekt [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties) bereitgestellten Eigenschaften umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wird zwischen verschiedenen Produzenten geteilt?), **PresentationFormat**, **Subject** und **Title**
```javascript
// Instanziieren Sie die Presentation-Klasse, die die Präsentation darstellt
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Erstellen Sie eine Referenz zum IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    var dp = pres.getDocumentProperties();
    // Anzeigen der eingebauten Eigenschaften
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


## **Einbaute Eigenschaften ändern**

Das Ändern der eingebauten Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einen Zeichenfolgenwert einer gewünschten Eigenschaft zuweisen und der Eigenschaftswert wird geändert. Im nachstehenden Beispiel zeigen wir, wie die eingebauten Dokumenteigenschaften einer Präsentationsdatei mit Aspose.Slides für Node.js via Java geändert werden können.
```javascript
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


Dieses Beispiel ändert die eingebauten Eigenschaften der Präsentation, wie unten dargestellt:

|**Eingebaute Dokumenteigenschaften nach Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Eigene Dokumenteigenschaften hinzufügen**

Aspose.Slides für Node.js via Java ermöglicht Entwicklern außerdem das Hinzufügen benutzerdefinierter Werte zu den Dokumenteigenschaften einer Präsentation. Ein Beispiel unten zeigt, wie benutzerdefinierte Eigenschaften für eine Präsentation festgelegt werden.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Dokumenteigenschaften abrufen
    var dProps = pres.getDocumentProperties();
    // Benutzerdefinierte Eigenschaften hinzufügen
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Eigenschaftsnamen an bestimmtem Index abrufen
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Ausgewählte Eigenschaft entfernen
    dProps.removeCustomProperty(getPropertyName);
    // Präsentation speichern
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

## **Zugriff auf und Änderung benutzerdefinierter Eigenschaften**

Aspose.Slides für Node.js via Java erlaubt Entwicklern außerdem den Zugriff auf die Werte benutzerdefinierter Eigenschaften. Ein Beispiel unten zeigt, wie Sie auf alle diese benutzerdefinierten Eigenschaften einer Präsentation zugreifen und sie ändern können.
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Erstelle eine Referenz zum DocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    var dp = pres.getDocumentProperties();
    // Greife auf benutzerdefinierte Eigenschaften zu und modifiziere sie
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Zeige Namen und Werte der benutzerdefinierten Eigenschaften an
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Werte der benutzerdefinierten Eigenschaften ändern
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


Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX ](https://docs.fileformat.com/presentation/pptx/)Präsentation. Die folgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften der Präsentation vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Benutzerdefinierte Eigenschaften nach Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteigenschaften**

{{% alert color="primary" %}} 

Neue Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), und [WriteBindedPresentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) wurden zu [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo) hinzugefügt, die Logik des Property‑Setters [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) wurde geändert.

{{% /alert %}} 

Die beiden neuen Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) und [UpdateDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) wurden zur Klasse [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo) hinzugefügt. Sie ermöglichen einen schnellen Zugriff auf Dokumenteigenschaften und erlauben das Ändern und Aktualisieren von Eigenschaften, ohne die gesamte Präsentation zu laden.

Ein typisches Szenario, bei dem die Eigenschaften geladen, ein Wert geändert und das Dokument aktualisiert wird, lässt sich wie folgt umsetzen:
```javascript
// Lese die Informationen der Präsentation
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
var props = info.readDocumentProperties();
props.setAuthor("New Author");
props.setTitle("New Title");
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```


Eine weitere Möglichkeit besteht darin, die Eigenschaften einer bestimmten Präsentation als Vorlage zu verwenden, um Eigenschaften in anderen Präsentationen zu aktualisieren:
```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


Eine neue Vorlage kann von Grund auf erstellt und anschließend verwendet werden, um mehrere Präsentationen zu aktualisieren:
```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```


## **Rechtschreibprüfungssprache festlegen**

Aspose.Slides stellt die Eigenschaft LanguageId (bereitgestellt von der Klasse PortionFormat) zur Verfügung, mit der Sie die Rechtschreibprüfungssprache für ein PowerPoint‑Dokument festlegen können. Die Rechtschreibprüfungssprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint geprüft werden.

Dieser JavaScript‑Code zeigt, wie Sie die Rechtschreibprüfungssprache für ein PowerPoint festlegen: xxx Warum fehlt LanguageId in der JavaScript‑Klasse PortionFormat?
```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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


## **Standardsprache festlegen**

Dieser JavaScript‑Code zeigt, wie Sie die Standardsprache für eine gesamte PowerPoint‑Präsentation festlegen können:
```javascript
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


## **Live-Beispiel**

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) aus, um zu sehen, wie Sie über die Aspose.Slides‑API mit Dokumenteigenschaften arbeiten können:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder sie, sofern die jeweilige Eigenschaft dies zulässt, auf leer setzen.

**Was passiert, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?**

Wenn Sie eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufügen, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert der Eigenschaft automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden?**

Ja, Sie können auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden, indem Sie die Methode `getPresentationInfo` der Klasse [PresentationFactory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/) verwenden. Anschließend nutzen Sie die Methode `readDocumentProperties` der Klasse [PresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo/), um die Eigenschaften effizient zu lesen, Speicher zu sparen und die Leistung zu verbessern.