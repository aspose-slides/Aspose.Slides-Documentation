---
title: Verwalten von Präsentationseigenschaften in PHP
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/php-java/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- eingebaute Eigenschaften
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
- PHP
- Aspose.Slides
description: "Verwalten Sie Präsentationseigenschaften in Aspose.Slides für PHP über Java und optimieren Sie Suche, Branding und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einleitung**

Aspose.Slides für PHP über Java unterstützt **eingebaute** und **benutzerdefinierte** Dokumenteneigenschaften. Verwenden Sie diese Eigenschaften, um Präsentationsmetadaten zu lesen und zu aktualisieren, z. B. Autor, Titel und benutzerdefinierte Werte.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteneigenschaften von Präsentationen über die Klasse [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) . Eine Instanz dieser Klasse wird von [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet. Sie gehen davon aus, dass PHP/Java Bridge und der Aspose.Slides PHP‑Wrapper initialisiert sind.

{{% alert color="info" title="Hinweis" %}}
Aspose.Slides verwaltet die Anwendungs‑ und Erzeugermetadaten beim Speichern von Präsentationen; diese Felder geben an, welche Software die Ausgabe erstellt hat.
{{% /alert %}}

## **Präsentationseigenschaften verwalten**

Dokumenteneigenschaften speichern beschreibende Informationen zusammen mit dem Präsentationsinhalt. Sie lassen sich in zwei Kategorien einteilen:

- **Eingebaute Eigenschaften** enthalten Standard‑Metadaten, wie Titel, Autor und Dokumentstatistiken.
- **Benutzerdefinierte Eigenschaften** speichern benutzerdefinierte Namens‑/Wert‑Paare.

Aspose.Slides für PHP über Java bietet Zugriff auf beide Kategorien. In PowerPoint wählen Sie **Datei → Info → Eigenschaften → Erweiterte Eigenschaften**, um die Dokumentmetadaten zu prüfen. Der Dialog gruppiert die Informationen in Registerkarten wie **Zusammenfassung**, **Statistiken**, **Inhalte** und **Benutzerdefiniert**. Verwenden Sie die Registerkarte **Benutzerdefiniert**, um benutzerdefinierte Eigenschaften zu verwalten.

## **Öffentliche Eigenschaften aus einer verschlüsselten Präsentation lesen**

Ein Öffnungs­passwort schützt normalerweise sowohl den Präsentationsinhalt als auch die Dokumenteneigenschaften. Wird eine Präsentation nach dem Aufruf von [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) mit `false` verschlüsselt, bleiben ihre Dokumenteneigenschaften öffentlich. Eine Anwendung kann dann [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) mit `true` aufrufen und die öffentlichen Metadaten lesen, ohne das Öffnungs­passwort anzugeben.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) steuert, was Aspose.Slides lädt; es entschlüsselt nichts. Wenn die Eigenschaften in die Verschlüsselung einbezogen wurden, schlägt das Laden ohne Passwort fehl. Ist die Präsentation nicht verschlüsselt, wird die Option ignoriert und die komplette Präsentation geladen.

Das Beispiel erfordert eine verschlüsselte Präsentation, deren Dokumenteneigenschaften öffentlich belassen wurden. Es überprüft den Lade‑Modus über [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/), und liest anschließend eingebaute Eigenschaften über [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

In diesem Modus wird der Folieninhalt nicht geladen. Folien, Folienmaster, Layouts, Formen, Medien und andere Präsentationsobjekte stehen nicht zur Verfügung. Anwendungen sollten stets [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) prüfen, bevor sie eine Operation ausführen, die das vollständige Präsentationsobjektmodell erfordert.

{{% alert color="warning" title="Warnung" %}}
Öffentliche Metadaten können Autorennamen, Titel, Themen, Stichwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte offenlegen. Verschlüsseln Sie sensible Eigenschaften gemeinsam mit der Präsentation. Lassen Sie sie nur dann öffentlich, wenn Indexierungs-, Klassifizierungs‑, Such‑ oder Dokumenten‑Management‑Systeme eine spezifische Anforderung haben, ohne Passwort auf sie zuzugreifen.
{{% /alert %}}

## **Eigenschaften einer verschlüsselten Präsentation aktualisieren**

Für eine verschlüsselte PPTX‑Datei ist eine Präsentation, die nach dem Aufruf von [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) mit `true` geladen wird, zum Lesen öffentlicher Metadaten vorgesehen. Aspose.Slides kann geänderte Eigenschaften aus diesem reinen Metadaten‑Objekt nicht speichern, da die öffentlichen Eigenschaften mit den entsprechenden Daten in der verschlüsselten Präsentation konsistent bleiben müssen. Daher erfordert das Aktualisieren das korrekte Öffnungs­passwort und ein vollständiges Laden.

Das Beispiel erfordert eine verschlüsselte PPTX‑Präsentation mit öffentlichen Dokumenteneigenschaften und einem bekannten Öffnungs­passwort. Es öffnet die komplette Präsentation mit [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/), aktualisiert öffentliche eingebaute Eigenschaften und speichert das Ergebnis. Anschließend verwendet es [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/), um zu prüfen, dass die Verschlüsselung erhalten bleibt, und öffnet die öffentlichen Metadaten ohne Passwort, um die neuen Werte zu überprüfen:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Darf eine Anwendung die Präsentationsinhalte nicht entschlüsseln oder laden, muss sie öffentliche Eigenschaften einer verschlüsselten PPTX‑Datei als schreibgeschützt behandeln.

## **Zugriff auf eingebaute Eigenschaften**

Die Klasse [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) stellt eingebaute Metadaten über Getter‑Methoden bereit, darunter [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/) und [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/). Dieses Beispiel öffnet eine vorhandene Präsentation und gibt deren gespeicherte Metadaten in der Konsole aus. Die Werte hängen von der Eingabepräsentation ab; einige Felder können leer sein.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

## **Eingebaute Eigenschaften ändern**

Um eingebaute Metadaten zu aktualisieren, verwenden Sie die Setter‑Methoden des Objekts, das von [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) zurückgegeben wird. Dieses Beispiel öffnet eine vorhandene Präsentation, ruft [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/) und [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/) auf und speichert die aktualisierte Präsentation anschließend mit [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Das gespeicherte PPTX enthält die neuen Metadaten.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Hyperlink‑Basis verwalten**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) gibt die dokumentenweite Basis für relative Hyperlinks zurück. Verwenden Sie [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/), um sie zu ändern oder zu leeren. Dies ist nützlich, wenn Sie eine Präsentation und ihre verknüpften Dateien an einen anderen Ort verschieben. Es ist getrennt vom einzelnen Hyperlink‑[Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/): Das Ändern der Basis überschreibt nicht die gespeicherten Link‑Adressen oder ändert absolute Ziele.

Das Beispiel erfordert eine Präsentation, die sowohl einen relativen Link wie `target.html` als auch einen absoluten Link wie `https://example.org/absolute.html` enthält. Es liest die vorhandene Basis, weist eine neue Basisadresse zu und speichert die Präsentation, um sie erneut zu öffnen und den Wert zu prüfen. Anschließend löscht es die Basis mit einer leeren Zeichenkette und überprüft den leeren Wert in einer separaten gespeicherten Datei. Ersetzen Sie die Beispiel‑Basisadresse durch den Speicherort Ihrer verknüpften Dateien.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Die beiden Überprüfungsnachrichten sollten `true` ausgeben. Das Löschen der Basis lässt die einzelnen Hyperlink‑Adressen unverändert.

Ein relativer Link zu `target.pptx` öffnete `old/target.pptx`, wenn die Basis auf den Ordner `old` zeigte. Nach dem Ändern der Basis auf den Ordner `new`, dem Speichern und erneutem Öffnen der Präsentation öffnete derselbe Link `new/target.pptx`. Ein absoluter Link öffnete weiterhin dieselbe Datei. Testen Sie Ihre relativen Links in PowerPoint vor und nach dem Verschieben der Präsentation oder Ändern ihrer Basis.

## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**

Benutzerdefinierte Eigenschaften speichern Metadaten, für die es kein entsprechendes eingebautes Feld gibt. Die Methode [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) ermöglicht das Zuweisen eines Wertes anhand des Eigenschaftsnamens. Dieses Beispiel erstellt eine Präsentation, fügt zwei Textwerte und einen ganzzahligen Versionswert hinzu und speichert die Präsentation mit [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Das Zuweisen eines Wertes zu einem bereits vorhandenen Namen ersetzt den Wert dieser Eigenschaft.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zugriff auf und Änderung benutzerdefinierter Eigenschaften**

Dieses Beispiel öffnet eine Präsentation, die benutzerdefinierte Eigenschaften enthält, und verwendet [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/), um über sie zu iterieren. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) akzeptiert einen nullbasierten Index und liefert den Namen, der von [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) verwendet wird. Das Beispiel gibt jeden ursprünglichen Namen und Wert aus, ersetzt jeden Wert durch einen nummerierten String unabhängig vom ursprünglichen Typ und speichert die Änderungen. Gibt es keine benutzerdefinierten Eigenschaften, nimmt die Schleife keine Änderungen vor.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Live‑Beispiel**

Probieren Sie die Online‑App [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) aus, um zu sehen, wie man mit Dokumenteneigenschaften über die Aspose.Slides‑API arbeitet:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, falls von der jeweiligen Eigenschaft erlaubt, sie auf leer setzen.

**Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**

Wenn Sie eine benutzerdefinierte Eigenschaft hinzufügen, die bereits existiert, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert der Eigenschaft automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die Präsentation vollständig zu laden?**

Ja. Verwenden Sie [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/), und anschließend [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/), um gespeicherte Dokumentmetadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Instanz zu erzeugen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/php-java/examine-presentation/) für ein vollständiges Bericht‑Beispiel und formatabhängige Einschränkungen.

**Kann ich öffentliche Eigenschaften einer verschlüsselten Präsentation ohne ihr Öffnungs­passwort lesen?**

Ja. Die Präsentation muss nach dem Aufruf von [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) mit `false` verschlüsselt worden sein und muss nach dem Aufruf von [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) mit `true` geladen werden.

**Kann ich eine verschlüsselte PPTX‑Datei im Nur‑Dokument‑Eigenschaften‑Modus aktualisieren?**

Nein. Öffentliche und verschlüsselte Eigenschaftsdaten müssen konsistent bleiben, daher erfordert das Aktualisieren einer verschlüsselten PPTX‑Datei das vollständige Laden der Präsentation mit dem korrekten Öffnungs­passwort.