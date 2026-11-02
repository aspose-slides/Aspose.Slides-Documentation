---
title: Verwalten von Präsentationseigenschaften in Java
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/java/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- eingebaute Eigenschaften
- benutzerdefinierte Eigenschaften
- erweiterte Eigenschaften
- Eigenschaften verwalten
- Eigenschaften ändern
- Dokumentmetadata
- Metadaten bearbeiten
- Korrektursprache
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Meistern Sie Präsentationseigenschaften in Aspose.Slides für Java und optimieren Sie Suche, Markenbildung und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einleitung**

Aspose.Slides for Java unterstützt **eingebaute** und **benutzerdefinierte** Dokumenteigenschaften. Verwenden Sie diese Eigenschaften, um Metadaten der Präsentation zu lesen und zu aktualisieren, wie z. B. den Autor, den Titel und benutzerdefinierte Werte.

Aspose.Slides ermöglicht es Ihnen, mit den Dokumenteigenschaften einer Präsentation über das [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) Interface zu arbeiten. Eine Instanz dieses Interfaces wird von [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" title="Note" %}}
Aspose.Slides verwaltet die Anwendungs- und Hersteller-Metadaten beim Speichern von Präsentationen; diese Felder identifizieren die Software, die die Ausgabe erzeugt hat.
{{% /alert %}}

## **Präsentationseigenschaften verwalten**

Dokumenteigenschaften speichern beschreibende Informationen zusammen mit dem Präsentationsinhalt. Sie lassen sich in zwei Kategorien einteilen:

- **Eingebaute Eigenschaften** enthalten standardisierte Metadaten, wie Titel, Autor und Dokumentstatistiken.
- **Benutzerdefinierte Eigenschaften** speichern benutzerdefinierte Namens/Wert-Paare.

Aspose.Slides for Java bietet Zugriff auf beide Kategorien. In PowerPoint wählen Sie **Datei → Info → Eigenschaften → Erweiterte Eigenschaften**, um die Dokumentmetadaten zu prüfen. Der Dialog gruppiert Informationen in Registerkarten wie **Zusammenfassung**, **Statistik**, **Inhalte** und **Benutzerdefiniert**. Verwenden Sie die Registerkarte **Benutzerdefiniert**, um benutzerdefinierte Eigenschaften zu verwalten.

## **Öffentliche Eigenschaften einer verschlüsselten Präsentation lesen**

Ein Öffnungspasswort schützt normalerweise sowohl den Präsentationsinhalt als auch die Dokumenteigenschaften. Wird eine Präsentation verschlüsselt, nachdem [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) mit `false` aufgerufen wurde, bleiben ihre Dokumenteigenschaften öffentlich. Eine Anwendung kann dann [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) mit `true` aufrufen und die öffentlichen Metadaten lesen, ohne das Öffnungspasswort anzugeben.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) steuert, was Aspose.Slides lädt; es entschlüsselt nichts. Wenn die Eigenschaften in die Verschlüsselung einbezogen wurden, schlägt das Laden ohne das Passwort fehl. Ist die Präsentation nicht verschlüsselt, wird die Option ignoriert und die gesamte Präsentation geladen.

Das Beispiel benötigt eine verschlüsselte Präsentation, deren Dokumenteigenschaften öffentlich geblieben sind. Es prüft den Lademodus über [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) und liest anschließend eingebaute Eigenschaften über [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--):
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

In diesem Modus wird der Folieninhalt nicht geladen. Folien, Master‑Folien, Layouts, Formen, Medien und andere Präsentationsobjekte stehen nicht zur Verfügung. Anwendungen sollten stets [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) prüfen, bevor sie einen Vorgang ausführen, der das komplette Präsentations‑Objektmodell erfordert.

{{% alert color="warning" title="Warning" %}}
Öffentliche Metadaten können Autorennamen, Titel, Betreff, Schlüsselwörter, Firmeninformationen, Kommentare und benutzerdefinierte Werte offenbaren. Verschlüsseln Sie sensible Eigenschaften zusammen mit der Präsentation. Lassen Sie sie nur öffentlich, wenn Indexierungs‑, Klassifizierungs‑, Such‑ oder Dokument‑Management‑Systeme eine spezifische Anforderung haben, ohne Passwort auf sie zuzugreifen.
{{% /alert %}}

## **Eigenschaften einer verschlüsselten Präsentation aktualisieren**

Für eine verschlüsselte PPTX‑Datei ist eine Präsentation, die nach dem Aufruf von [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) mit `true` geladen wird, zum Lesen öffentlicher Metadaten vorgesehen. Aspose.Slides kann geänderte Eigenschaften dieses rein metadata‑basierten Objekts nicht speichern, da die öffentlichen Eigenschaften mit den entsprechenden Daten in der verschlüsselten Präsentation konsistent bleiben müssen. Daher erfordert das Aktualisieren dieser Eigenschaften das korrekte Öffnungspasswort und einen vollständigen Ladevorgang.

Das Beispiel benötigt eine verschlüsselte PPTX‑Präsentation mit öffentlichen Dokumenteigenschaften und einem bekannten Öffnungspasswort. Es öffnet die komplette Präsentation mit [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), aktualisiert öffentliche eingebaute Eigenschaften und speichert das Ergebnis. Anschließend wird [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) verwendet, um zu prüfen, ob die Verschlüsselung erhalten bleibt, und es werden die öffentlichen Metadaten ohne Passwort erneut geöffnet, um die neuen Werte zu verifizieren:
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");

    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Falls einer Anwendung das Entschlüsseln oder Laden des Präsentationsinhalts nicht gestattet ist, muss sie die öffentlichen Eigenschaften einer verschlüsselten PPTX‑Datei als schreibgeschützt behandeln.

## **Zugriff auf eingebaute Eigenschaften**

Das [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) Interface stellt eingebaute Metadaten über Getter‑Methoden bereit, darunter [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--) und [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--). Dieses Beispiel öffnet eine vorhandene Präsentation und gibt deren gespeicherte Metadaten in der Konsole aus. Die Werte hängen von der Eingabepräsentation ab; einige Felder können leer sein.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Eingebaute Eigenschaften ändern**

Um eingebaute Metadaten zu aktualisieren, verwenden Sie die Setter‑Methoden des Objekts, das von [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) zurückgegeben wird. Dieses Beispiel öffnet eine vorhandene Präsentation, ruft [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-) und [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) auf und speichert anschließend die aktualisierte Präsentation mit [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Das gespeicherte PPTX enthält die neuen Metadaten.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hyperlink‑Basis verwalten**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) liefert die dokumentweite Basis für relative Hyperlinks. Verwenden Sie [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-), um sie zu ändern oder zu leeren. Dies ist nützlich, wenn eine Präsentation und ihre verknüpften Dateien an einen anderen Ort verschoben werden. Es ist getrennt von der einzelnen Hyperlink‑Methode [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--): Das Ändern der Basis überschreibt nicht die gespeicherten Linkadressen oder ändert absolute Ziele.

Das Beispiel benötigt eine Präsentation, die sowohl einen relativen Link, z. B. `target.html`, als auch einen absoluten Link, z. B. `https://example.org/absolute.html`, enthält. Es liest die vorhandene Basis, weist eine neue Basisadresse zu und speichert die Präsentation, um beim erneuten Öffnen den Wert zu prüfen. Anschließend wird die Basis mit einem leeren String geleert und der leere Wert in einer separaten gespeicherten Datei verifiziert. Ersetzen Sie die Beispiel‑Basisadresse durch den Speicherort Ihrer verknüpften Dateien.
```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
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

Die beiden Prüfmeldungen sollten `true` ausgeben. Das Leeren der Basis lässt die einzelnen Hyperlink‑Adressen unverändert.

Ein relativer Link zu `target.pptx` öffnete `old/target.pptx`, als die Basis auf den Ordner `old` zeigte. Nach dem Ändern der Basis auf den Ordner `new`, dem Speichern und erneuten Öffnen der Präsentation öffnete derselbe Link `new/target.pptx`. Ein absoluter Link öffnete weiterhin dieselbe Datei. Testen Sie Ihre relativen Links in PowerPoint vor und nach dem Verschieben der Präsentation oder dem Ändern ihrer Basis.

## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**

Benutzerdefinierte Eigenschaften speichern Metadaten, für die es kein entsprechendes eingebautes Feld gibt. Die Methode [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) ermöglicht es, einen Wert anhand des Eigenschaftsnamens zuzuweisen. Dieses Beispiel erstellt eine Präsentation, fügt zwei Textwerte und einen ganzzahligen Versionswert hinzu und speichert die Präsentation mit [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Das Zuweisen eines Wertes zu einem bestehenden Namen ersetzt den Wert dieser Eigenschaft.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Benutzerdefinierte Eigenschaften zugreifen und ändern**

Dieses Beispiel öffnet eine Präsentation, die benutzerdefinierte Eigenschaften enthält, und verwendet [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--), um über sie zu iterieren. [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) akzeptiert einen nullbasierten Index und liefert den Namen, der von [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) verwendet wird. Das Beispiel gibt jeden ursprünglichen Namen und Wert aus, ersetzt jeden Wert durch einen nummerierten String, unabhängig vom ursprünglichen Typ, und speichert die Änderungen. Gibt es keine benutzerdefinierten Eigenschaften, nimmt die Schleife keine Änderungen vor.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Live‑Beispiel**

Probieren Sie die Online‑App [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) aus, um zu sehen, wie man mit Dokumenteigenschaften über die Aspose.Slides‑API arbeitet:
[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder sie, sofern von der jeweiligen Eigenschaft erlaubt, auf leer setzen.

**Was passiert, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?**

Wenn Sie eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufügen, wird ihr bestehender Wert mit dem neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert der Eigenschaft automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation vollständig zu laden?**

Ja. Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) und anschließend [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--), um gespeicherte Dokumentmetadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)-Instanz zu erzeugen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/java/examine-presentation/) für ein vollständiges Reporting‑Beispiel und format‑spezifische Einschränkungen.

**Kann ich öffentliche Eigenschaften einer verschlüsselten Präsentation ohne ihr Öffnungspasswort lesen?**

Ja. Die Präsentation muss nach dem Aufruf von [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) mit `false` verschlüsselt worden sein und muss nach dem Aufruf von [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) mit `true` geladen werden.

**Kann ich eine verschlüsselte PPTX‑Datei im Nur‑Dokument‑Eigenschaften‑Modus aktualisieren?**

Nein. Öffentliche und verschlüsselte Eigenschaftsdaten müssen konsistent bleiben, daher erfordert das Aktualisieren einer verschlüsselten PPTX‑Datei das Laden der vollständigen Präsentation mit dem korrekten Öffnungspasswort.