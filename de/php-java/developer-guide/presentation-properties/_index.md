---
title: Präsentationseigenschaften in PHP verwalten
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/php-java/presentation-properties/
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
- Rechtschreibprüfungssprache
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Präsentationseigenschaften in Aspose.Slides für PHP via Java zentral verwalten und Suche, Markenbildung sowie Workflow in Ihren PowerPoint‑ und OpenDocument‑Dateien optimieren."
---
## **Einleitung**

Aspose.Slides unterstützt zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Beide Eigenschaftstypen können problemlos über die Aspose.Slides‑API abgerufen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Präsentationsdokumenteigenschaften über die Klasse [DocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/) . Eine Instanz dieser Klasse wird durch die Methode [Presentation::getDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getDocumentProperties) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" title="Note" %}}
Bitte beachten Sie, dass die Felder **Application** und **AppVersion** nicht geändert werden können. Aspose.Slides überschreibt sie bei jedem Speichern, sodass eine gespeicherte Präsentation immer „Aspose.Slides for PHP via Java“ und die Version der Bibliothek, die sie erstellt hat, anzeigt. Jeder an `setNameOfApplication` übergebene Wert wird beim Schreiben der Präsentation verworfen.
{{% /alert %}} 

## **Präsentationseigenschaften verwalten**

Microsoft PowerPoint bietet eine Funktion zum Hinzufügen von Eigenschaften zu Präsentationsdateien. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (Built-in) Eigenschaften
- Benutzerdefinierte (Custom) Eigenschaften

**Built-in**‑Eigenschaften enthalten allgemeine Informationen über das Dokument, wie Dokumenttitel, Name des Autors, Dokumentstatistiken usw. **Custom**‑Eigenschaften sind solche, die von den Benutzern als **Name/Wert**‑Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides for PHP via Java können Entwickler sowohl die Werte von Built-in‑Eigenschaften als auch von Custom‑Eigenschaften abrufen und ändern.

## **Dokumenteigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften von Präsentationsdateien. Sie müssen lediglich das Office‑Symbol anklicken und anschließend den Menüpunkt **Prepare | Properties | Advanced Properties** von Microsoft PowerPoint 2007 wie unten dargestellt auswählen:

|**Auswahl des Menüpunkts Erweitere Eigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Nachdem Sie den Menüpunkt **Advanced Properties** ausgewählt haben, erscheint ein Dialog, der es Ihnen ermöglicht, die Dokumenteigenschaften der PowerPoint‑Datei zu verwalten, wie in der folgenden Abbildung gezeigt:

|**Properties Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Im obigen **Properties Dialog** sehen Sie, dass es viele Registerkarten gibt, wie **General**, **Summary**, **Statistics**, **Contents** und **Custom**. Alle diese Registerkarten ermöglichen die Konfiguration verschiedener Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Custom** wird verwendet, um die benutzerdefinierten Eigenschaften der PowerPoint‑Dateien zu verwalten.

Arbeiten mit Dokumenteigenschaften mithilfe von Aspose.Slides for PHP via Java

Wie bereits beschrieben unterstützt Aspose.Slides for PHP via Java zwei Arten von Dokumenteigenschaften, nämlich **Built-in** und **Custom**‑Eigenschaften. Entwickler können daher beide Arten von Eigenschaften über die Aspose.Slides for PHP via Java API nutzen. Aspose.Slides for PHP via Java stellt die Klasse [DocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties) bereit, die die mit einer Präsentationsdatei verbundenen Dokumenteigenschaften über die Eigenschaft **Presentation.DocumentProperties** repräsentiert.

Entwickler können die Eigenschaft **DocumentProperties**, die vom [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation)-Objekt bereitgestellt wird, verwenden, um auf die Dokumenteigenschaften der Präsentationsdateien zuzugreifen, wie unten beschrieben:

## **Öffentliche Eigenschaften aus einer verschlüsselten Präsentation lesen**

Ein Öffnungspasswort schützt normalerweise sowohl den Präsentationsinhalt als auch die Dokumenteigenschaften. Wenn eine Präsentation verschlüsselt wird, indem `false` an [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) übergeben wird, bleiben ihre Dokumenteigenschaften öffentlich. Eine Anwendung kann dann `true` an [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) übergeben und die öffentlichen Metadaten lesen, ohne das Öffnungspasswort anzugeben.

Die Option „nur Dokumenteigenschaften laden“ steuert, was Aspose.Slides lädt; sie entschlüsselt nichts. Wenn die Eigenschaften in die Verschlüsselung einbezogen wurden, schlägt das Laden ohne Passwort fehl. Ist die Präsentation nicht verschlüsselt, wird die Option ignoriert und die komplette Präsentation geladen.

Das folgende Beispiel prüft den Lademodus über [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) und liest anschließend Built-in‑Eigenschaften über [Presentation::getDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

In diesem Modus werden Folieninhalte nicht geladen. Folien, Master‑Folien, Layouts, Formen, Medien und andere Präsentationsobjekte stehen nicht zur Verfügung. Anwendungen sollten stets [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/de/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) prüfen, bevor sie einen Vorgang ausführen, der das vollständige Objektmodell der Präsentation erfordert.

{{% alert color="warning" title="Warning" %}}
Öffentliche Metadaten können Autorennamen, Titel, Betreff, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte preisgeben. Verschlüsseln Sie sensible Eigenschaften zusammen mit der Präsentation. Lassen Sie sie nur dann öffentlich, wenn Indexierungs‑, Klassifizierungs‑, Such‑ oder Dokument‑Management‑Systeme sie ohne Passwort benötigen.
{{% /alert %}}

## **Eigenschaften einer verschlüsselten Präsentation aktualisieren**

Für eine verschlüsselte PPTX‑Datei ist eine Präsentation, die im Modus „nur Dokumenteigenschaften laden“ geöffnet wurde, zum Lesen öffentlicher Metadaten gedacht. Aspose.Slides kann geänderte Eigenschaften aus diesem rein‑metadaten‑Objekt nicht speichern, da die öffentlichen Eigenschaften mit den entsprechenden Daten in der verschlüsselten Präsentation konsistent bleiben müssen. Das Aktualisieren erfordert daher das korrekte Öffnungspasswort und einen vollständigen Ladevorgang.

Das folgende Beispiel öffnet die Präsentation mit [LoadOptions::setPassword](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setPassword), aktualisiert öffentliche Built-in‑Eigenschaften und speichert das Ergebnis. Anschließend wird [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#isEncrypted) verwendet, um zu prüfen, dass die Verschlüsselung erhalten bleibt, und die öffentlichen Metadaten ohne Passwort erneut geöffnet, um die neuen Werte zu prüfen:

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
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
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
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Wird einer Anwendung das Entschlüsseln oder Laden des Präsentationsinhalts untersagt, muss sie die öffentlichen Eigenschaften einer verschlüsselten PPTX‑Datei als schreibgeschützt behandeln.

## **Zugriff auf Built-in‑Eigenschaften**

Diese über das [DocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties)-Objekt bereitgestellte Eigenschaften umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **Keywords**, **SharedDoc** (Ist das Dokument zwischen verschiedenen Erstellern geteilt?), **PresentationFormat**, **Subject** und **Title**

```php
  # Instanziieren Sie die Presentation-Klasse, die die Präsentation darstellt
  $pres = new Presentation("Presentation.pptx");
  try {
    # Erstellen Sie eine Referenz auf das IDocumentProperties-Objekt, das mit der Presentation verknüpft ist
    $dp = $pres->getDocumentProperties();
    # Zeigen Sie die integrierten Eigenschaften an
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Built-in‑Eigenschaften ändern**

Das Ändern der Built-in‑Eigenschaften von Präsentationsdateien ist ebenso einfach wie das Abrufen. Sie können einfach einen Zeichenkettenwert einer gewünschten Eigenschaft zuweisen, und der Eigenschaftswert wird geändert. Im nachstehenden Beispiel wird gezeigt, wie die Built-in‑Dokumenteigenschaften der Präsentationsdatei mit Aspose.Slides for PHP via Java geändert werden können.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Erstellen Sie eine Referenz auf das IDocumentProperties-Objekt, das mit der Presentation verknüpft ist
    $dp = $pres->getDocumentProperties();
    # Setzen Sie die integrierten Eigenschaften
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Speichern Sie Ihre Präsentation in einer Datei
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dieses Beispiel ändert die Built-in‑Eigenschaften der Präsentation, die wie folgt dargestellt werden können:

|**Built-in‑Dokumenteigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Benutzerdefinierte Dokumenteigenschaften hinzufügen**

Aspose.Slides for PHP via Java ermöglicht es Entwicklern auch, benutzerdefinierte Werte für Dokumenteigenschaften einer Präsentation hinzuzufügen. Das nachstehende Beispiel zeigt, wie benutzerdefinierte Eigenschaften für eine Präsentation festgelegt werden.

```php
  $pres = new Presentation();
  try {
    # Abrufen der Dokumenteigenschaften
    $dProps = $pres->getDocumentProperties();
    # Hinzufügen benutzerdefinierter Eigenschaften
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Abrufen des Eigenschaftsnames an einem bestimmten Index
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Entfernen der ausgewählten Eigenschaft
    $dProps->removeCustomProperty($getPropertyName);
    # Speichern der Präsentation
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Hinzugefügte benutzerdefinierte Dokumenteigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**

Aspose.Slides for PHP via Java ermöglicht es Entwicklern zudem, die Werte benutzerdefinierter Eigenschaften zu lesen. Das nachstehende Beispiel zeigt, wie Sie alle diese benutzerdefinierten Eigenschaften einer Präsentation abrufen und ändern können.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Erstellen Sie eine Referenz auf das DocumentProperties-Objekt, das mit der Presentation verknüpft ist
    $dp = $pres->getDocumentProperties();
    # Zugriff auf benutzerdefinierte Eigenschaften und deren Änderung
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Anzeigen von Namen und Werten benutzerdefinierter Eigenschaften
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Werte benutzerdefinierter Eigenschaften ändern
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Speichern Sie Ihre Präsentation in einer Datei
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Präsentation. Die folgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Benutzerdefinierte Eigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteigenschaften**

{{% alert color="info" title="Note" %}}
Neue Methoden [readDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) und [writeBindedPresentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) wurden zu [PresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/PresentationInfo) hinzugefügt, die Logik des Setters der Eigenschaft [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#setLastSavedTime) wurde geändert.
{{% /alert %}} 

Die beiden neuen Methoden [readDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) und [updateDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) wurden zur Klasse [PresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/PresentationInfo) hinzugefügt. Sie bieten schnellen Zugriff auf Dokumenteigenschaften und ermöglichen das Ändern und Aktualisieren von Eigenschaften, ohne die gesamte Präsentation zu laden.

Das typische Szenario – Eigenschaften laden, einen Wert ändern und das Dokument aktualisieren – kann folgendermaßen implementiert werden:

```php
  # Lese die Informationen der Präsentation
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # Erhalte die aktuellen Eigenschaften
  $props = $info->readDocumentProperties();
  # Setze die neuen Werte für die Felder Autor und Titel
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # Aktualisiere die Präsentation mit neuen Werten
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Eine weitere Möglichkeit besteht darin, die Eigenschaften einer bestimmten Präsentation als Vorlage zu verwenden, um Eigenschaften in anderen Präsentationen zu aktualisieren:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

Eine neue Vorlage kann von Grund auf erstellt und dann verwendet werden, um mehrere Präsentationen zu aktualisieren:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **Rechtschreibprüfungssprache festlegen**

Aspose.Slides stellt die Eigenschaft LanguageId (bereitgestellt durch die Klasse PortionFormat) zur Verfügung, um die Rechtschreibprüfungssprache für ein PowerPoint‑Dokument festzulegen. Die Rechtschreibprüfungssprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint geprüft werden.

Dieser PHP‑Code zeigt, wie die Rechtschreibprüfungssprache für ein PowerPoint‑Dokument festgelegt wird: xxx Warum fehlt LanguageId in der Java‑Klasse PortionFormat?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// setzt die ID einer Korrektursprache
    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Standardsprache festlegen**

Dieser PHP‑Code zeigt, wie die Standardsprache für eine gesamte PowerPoint‑Präsentation festgelegt wird:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Fügt eine neue Rechteckform mit Text hinzu
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Prüft die Sprache der ersten Portion
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Live‑Beispiel**

Testen Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/de/metadata), um zu sehen, wie Sie mit Dokumenteigenschaften über die Aspose.Slides‑API arbeiten:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## **FAQ**

**Wie kann ich eine Built-in‑Eigenschaft aus einer Präsentation entfernen?**

Built-in‑Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder (sofern die jeweilige Eigenschaft es zulässt) auf einen leeren Wert setzen.

**Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**

Wird eine bereits vorhandene benutzerdefinierte Eigenschaft hinzugefügt, wird ihr vorhandener Wert durch den neuen überschrieben. Ein vorheriges Entfernen oder Prüfen der Eigenschaft ist nicht erforderlich, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden?**

Ja. Verwenden Sie [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationfactory/) und anschließend [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#readDocumentProperties), um gespeicherte Dokumentmetadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Instanz zu erstellen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/php-java/examine-presentation/) für ein vollständiges Berichtbeispiel und format‑spezifische Einschränkungen.

**Kann ich öffentliche Eigenschaften einer verschlüsselten Präsentation ohne das Öffnungspasswort lesen?**

Ja. Die Verschlüsselung der Dokumenteigenschaften muss vor der Verschlüsselung der Präsentation deaktiviert worden sein, und die Präsentation muss im Modus „nur Dokumenteigenschaften laden“ geöffnet werden.

**Kann ich eine verschlüsselte PPTX‑Datei im Modus „nur Dokumenteigenschaften laden“ aktualisieren?**

Nein. Öffentliche und verschlüsselte Eigenschaftsdaten müssen konsistent bleiben; daher erfordert das Aktualisieren einer verschlüsselten PPTX‑Datei das Laden der kompletten Präsentation mit dem korrekten Öffnungspasswort.