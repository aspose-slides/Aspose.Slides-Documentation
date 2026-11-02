---
title: Verwalten von Präsentationseigenschaften in JavaScript
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
- Dokumentmetadaten
- Metadaten bearbeiten
- Korrektursprache
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Steuern Sie Präsentationseigenschaften in Aspose.Slides für Node.js via Java und optimieren Sie Suche, Branding und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einleitung**

Aspose.Slides für Node.js via Java unterstützt **eingebaute** und **benutzerdefinierte** Dokumenteigenschaften. Verwenden Sie diese Eigenschaften, um Metadaten der Präsentation zu lesen und zu aktualisieren, z. B. den Autor, den Titel und benutzerdefinierte Werte.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteigenschaften von Präsentationen über die Klasse [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties). Eine Instanz dieser Klasse wird von [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) zurückgegeben. Die folgenden Beispiele zeigen, wie diese Eigenschaften gelesen, geändert und verwaltet werden können.

{{% alert color="info" title="Note" %}}
Aspose.Slides verwaltet die Anwendungs- und Erzeugermetadaten beim Speichern von Präsentationen; diese Felder identifizieren die Software, die die Ausgabe erstellt hat.
{{% /alert %}}

## **Präsentationseigenschaften verwalten**

Dokumenteigenschaften speichern beschreibende Informationen neben dem Präsentationsinhalt. Sie werden in zwei Kategorien eingeteilt:

- **Eingebaute Eigenschaften** enthalten standardisierte Metadaten, wie Titel, Autor und Dokumentstatistiken.
- **Benutzerdefinierte Eigenschaften** speichern benutzerdefinierte Name/Wert-Paare.

Aspose.Slides für Node.js via Java bietet Zugriff auf beide Kategorien. In PowerPoint wählen Sie **File → Info → Properties → Advanced Properties**, um die Dokumentmetadaten zu prüfen. Der Dialog gruppiert Informationen in Registerkarten wie **Summary**, **Statistics**, **Contents** und **Custom**. Verwenden Sie die Registerkarte **Custom**, um benutzerdefinierte Eigenschaften zu verwalten.

## **Öffentliche Eigenschaften einer verschlüsselten Präsentation lesen**

Ein Öffnungspasswort schützt normalerweise sowohl den Präsentationsinhalt als auch die Dokumenteigenschaften. Wenn eine Präsentation nach dem Aufruf von [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) mit `false` verschlüsselt wird, bleiben ihre Dokumenteigenschaften öffentlich. Eine Anwendung kann dann [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) mit `true` aufrufen und die öffentlichen Metadaten lesen, ohne das Öffnungspasswort anzugeben.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) steuert, was Aspose.Slides lädt; es entschlüsselt nichts. Wenn die Eigenschaften in die Verschlüsselung einbezogen wurden, schlägt das Laden ohne Passwort fehl. Ist die Präsentation nicht verschlüsselt, wird die Option ignoriert und die komplette Präsentation geladen.

Das Beispiel erfordert eine verschlüsselte Präsentation, deren Dokumenteigenschaften öffentlich belassen wurden. Es überprüft den Lademodus über [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) und liest anschließend eingebaute Eigenschaften über [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

In diesem Modus wird der Folieninhalt nicht geladen. Folien, Master, Layouts, Formen, Medien und andere Präsentationsobjekte stehen nicht zur Verfügung. Anwendungen sollten stets [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) prüfen, bevor sie eine Operation ausführen, die das vollständige Präsentationsobjektmodell erfordert.

{{% alert color="warning" title="Warning" %}}
Öffentliche Metadaten können Autorennamen, Titel, Betreffzeilen, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte preisgeben. Verschlüsseln Sie empfindliche Eigenschaften zusammen mit der Präsentation. Lassen Sie sie nur dann öffentlich, wenn Indexierungs-, Klassifizierungs-, Such- oder Dokumentenverwaltungssysteme spezifisch darauf angewiesen sind, ohne Passwort darauf zuzugreifen.
{{% /alert %}}

## **Eigenschaften einer verschlüsselten Präsentation aktualisieren**

Für eine verschlüsselte PPTX‑Datei ist eine Präsentation, die nach dem Aufruf von [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) mit `true` geladen wurde, zum Lesen öffentlicher Metadaten gedacht. Aspose.Slides kann geänderte Eigenschaften aus diesem rein metadatenbasierten Objekt nicht speichern, da die öffentlichen Eigenschaften mit den entsprechenden Daten in der verschlüsselten Präsentation konsistent bleiben müssen. Daher erfordert das Aktualisieren das korrekte Öffnungspasswort und einen kompletten Ladevorgang.

Das Beispiel erfordert eine verschlüsselte PPTX‑Präsentation mit öffentlichen Dokumenteigenschaften und einem bekannten Öffnungspasswort. Es öffnet die komplette Präsentation mit [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword), aktualisiert öffentliche eingebaute Eigenschaften und speichert das Ergebnis. Anschließend wird [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) verwendet, um zu prüfen, dass die Verschlüsselung erhalten bleibt, und die öffentlichen Metadaten werden ohne Passwort erneut geöffnet, um die neuen Werte zu verifizieren:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
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

Falls einer Anwendung das Entschlüsseln oder Laden des Präsentationsinhalts nicht gestattet ist, muss sie die öffentlichen Eigenschaften einer verschlüsselten PPTX‑Datei als schreibgeschützt behandeln.

## **Auf eingebaute Eigenschaften zugreifen**

Die Klasse [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) stellt eingebaute Metadaten über Getter‑Methoden bereit, darunter [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) und [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). Dieses Beispiel öffnet eine vorhandene Präsentation und gibt deren gespeicherte Metadaten in der Konsole aus. Die Werte hängen von der Eingabepräsentation ab; einige Felder können leer sein.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Eingebaute Eigenschaften ändern**

Um eingebaute Metadaten zu aktualisieren, verwenden Sie die Setter‑Methoden des Objekts, das von [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) zurückgegeben wird. Dieses Beispiel öffnet eine vorhandene Präsentation, ruft [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) und [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager) auf und speichert die aktualisierte Präsentation mit [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Die gespeicherte PPTX‑Datei enthält die neuen Metadaten.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hyperlink‑Basis verwalten**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) gibt die dokumentweite Basis für relative Hyperlinks zurück. Mit [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) kann sie geändert oder geleert werden. Das ist nützlich, wenn eine Präsentation und ihre verknüpften Dateien an einen anderen Ort verschoben werden. Es ist getrennt vom [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) eines einzelnen Hyperlinks: Das Ändern der Basis überschreibt nicht die gespeicherten Linkadressen und ändert keine absoluten Ziele.

Das Beispiel erfordert eine Präsentation, die sowohl einen relativen Link wie `target.html` als auch einen absoluten Link wie `https://example.org/absolute.html` enthält. Es liest die vorhandene Basis, weist eine neue Basisadresse zu und speichert die Präsentation, um anschließend die Präsentation erneut zu öffnen und den Wert zu prüfen. Anschließend wird die Basis mit einer leeren Zeichenfolge geleert und der leere Wert in einer separaten gespeicherten Datei verifiziert. Ersetzen Sie die Beispiel‑Basisadresse durch den Pfad zu Ihren verknüpften Dateien.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

Die beiden Verifizierungsnachrichten sollten `true` ausgeben. Das Leeren der Basis lässt die einzelnen Hyperlink‑Adressen unverändert.

Ein relativer Link zu `target.pptx` öffnete `old/target.pptx`, als die Basis auf den Ordner `old` zeigte. Nach dem Ändern der Basis auf den Ordner `new`, dem Speichern und dem erneuten Öffnen der Präsentation öffnete derselbe Link `new/target.pptx`. Ein absoluter Link öffnete weiterhin dieselbe Datei. Testen Sie Ihre relativen Links in PowerPoint vor und nach dem Verschieben der Präsentation oder dem Ändern ihrer Basis.

## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**

Benutzerdefinierte Eigenschaften speichern Metadaten, für die kein entsprechendes eingebautes Feld existiert. Die Methode [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) ermöglicht das Zuweisen eines Wertes anhand des Eigenschaftsnamens. Dieses Beispiel erstellt eine Präsentation, fügt zwei Textwerte und einen ganzzahligen Versionswert hinzu und speichert die Präsentation mit [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Das Zuweisen eines Wertes zu einem bereits bestehenden Namen ersetzt den Wert dieser Eigenschaft.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Benutzerdefinierte Eigenschaften zugreifen und ändern**

Dieses Beispiel öffnet eine Präsentation, die benutzerdefinierte Eigenschaften enthält, und verwendet [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties), um über sie zu iterieren. [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) akzeptiert einen nullbasierten Index und liefert den Namen zurück, der von [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) verwendet wird. Das Beispiel gibt jeden ursprünglichen Namen und Wert aus, ersetzt jeden Wert durch einen nummerierten String, unabhängig vom ursprünglichen Typ, und speichert die Änderungen. Gibt es keine benutzerdefinierten Eigenschaften, nimmt die Schleife keine Änderungen vor.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Live‑Beispiel**

Probieren Sie die Online‑App [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) aus, um zu sehen, wie man mit Dokumenteigenschaften über die Aspose.Slides‑API arbeitet:

[![PowerPoint‑Metadaten anzeigen & bearbeiten](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, sofern die jeweilige Eigenschaft dies zulässt, sie auf leer setzen.

**Was passiert, wenn ich eine bereits bestehende benutzerdefinierte Eigenschaft hinzufüge?**

Wenn Sie eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufügen, wird deren bestehender Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert der Eigenschaft automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden?**

Ja. Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo), und anschließend [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties), um gespeicherte Dokumentmetadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)‑Instanz zu erstellen. Siehe [Leichtgewichtigen Präsentations‑Inventar erstellen](/slides/de/nodejs-java/examine-presentation/) für ein vollständiges Bericht-Beispiel und format‑spezifische Beschränkungen.

**Kann ich öffentliche Eigenschaften einer verschlüsselten Präsentation ohne ihr Öffnungspasswort lesen?**

Ja. Die Präsentation muss nach dem Aufruf von [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) mit `false` verschlüsselt worden sein und muss nach dem Aufruf von [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) mit `true` geladen werden.

**Kann ich eine verschlüsselte PPTX‑Datei im Nur‑Dokument‑Eigenschaften‑Modus aktualisieren?**

Nein. Öffentliche und verschlüsselte Eigenschaftsdaten müssen konsistent bleiben, daher erfordert das Aktualisieren einer verschlüsselten PPTX‑Datei das Laden der vollständigen Präsentation mit dem korrekten Öffnungspasswort.