---
title: Präsentationseigenschaften
type: docs
weight: 70
url: /php-java/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPoint bietet eine Funktion, um einige Eigenschaften zu den Präsentationsdateien hinzuzufügen. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt zwei Arten von dokumenteigenschaften:

- Systemdefinierte (Eingebaute) Eigenschaften
- Benutzerdefinierte (Benutzerdefinierte) Eigenschaften

**Eingebaute** Eigenschaften enthalten allgemeine Informationen über das Dokument, wie Dokumenttitel, Name des Autors, Dokumentstatistiken und so weiter. **Benutzerdefinierte** Eigenschaften sind diejenigen, die von den Benutzern als **Name/Wert**-Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides für PHP über Java können Entwickler auf die Werte der eingebauten Eigenschaften sowie der benutzerdefinierten Eigenschaften zugreifen und diese ändern.

{{% /alert %}} 

## **Dokumenteigenschaften in PowerPoint**
Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften der Präsentationsdateien. Alles, was Sie tun müssen, ist, auf das Office-Symbol zu klicken und den Menüpunkt **Vorbereiten | Eigenschaften | Erweiterte Eigenschaften** im Microsoft PowerPoint 2007 auszuwählen, wie unten gezeigt:

{{% alert color="primary" %}} 

Bitte beachten Sie, dass Sie keine Werte für die Felder **Anwendung** und **Hersteller** festlegen können, da Aspose Ltd. und Aspose.Slides für PHP über Java x.x.x in diesen Feldern angezeigt werden.

{{% /alert %}} 

|**Auswahl des Menüpunkts Erweiterte Eigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Nachdem Sie den Menüpunkt **Erweiterte Eigenschaften** ausgewählt haben, erscheint ein Dialog, der es Ihnen ermöglicht, die Dokumenteigenschaften der PowerPoint-Datei zu verwalten, wie unten in der Abbildung gezeigt:

|**Eigenschafts-Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Im obigen **Eigenschafts-Dialog** sehen Sie, dass es viele Registerkarten wie **Allgemein**, **Zusammenfassung**, **Statistiken**, **Inhalte** und **Benutzerdefiniert** gibt. Alle diese Registerkarten ermöglichen die Konfiguration unterschiedlicher Informationen in Bezug auf die PowerPoint-Dateien. Die **Benutzerdefiniert**-Registerkarte wird verwendet, um die benutzerdefinierten Eigenschaften der PowerPoint-Dateien zu verwalten.

### Arbeiten mit Dokumenteigenschaften unter Verwendung von Aspose.Slides für PHP über Java

Wie bereits zuvor beschrieben, unterstützt Aspose.Slides für PHP über Java zwei Arten von Dokumenteigenschaften, nämlich **Eingebaute** und **Benutzerdefinierte** Eigenschaften. Entwickler können beide Arten von Eigenschaften mithilfe der Aspose.Slides für PHP über Java API zugreifen. Aspose.Slides für PHP über Java stellt eine Klasse [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties) zur Verfügung, die die mit einer Präsentationsdatei verbundenen Dokumenteigenschaften über die **Presentation.DocumentProperties**-Eigenschaft darstellt.

Entwickler können die **IDocumentProperties**-Eigenschaft, die vom [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Objekt bereitgestellt wird, verwenden, um auf die Dokumenteigenschaften der Präsentationsdateien wie folgt zuzugreifen:

## **Zugriff auf Eingebaute Eigenschaften**
Diese Eigenschaften, die vom [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties)-Objekt bereitgestellt werden, umfassen: **Creator** (Autor), **Beschreibung**, **Schlüsselwörter**, **Erstellt** (Erstellungsdatum), **Modifiziert** (Änderungsdatum), **Gedruckt** (Letztes Druckdatum), **LastModifiedBy**, **SharedDoc** (Wird zwischen verschiedenen Herstellern geteilt?), **Präsentationsformat**, **Betreff** und **Titel**.

```php
  // Instanziieren Sie die Presentation-Klasse, die die Präsentation darstellt
  $pres = new Presentation("Presentation.pptx");
  try {
    // Erstellen Sie eine Referenz auf das IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    $dp = $pres->getDocumentProperties();
    // Anzeigen der eingebauten Eigenschaften
    echo("Kategorie : " . $dp->getCategory());
    echo("Aktueller Status : " . $dp->getContentStatus());
    echo("Erstellungsdatum : " . $dp->getCreatedTime());
    echo("Autor : " . $dp->getAuthor());
    echo("Beschreibung : " . $dp->getComments());
    echo("Schlüsselwörter : " . $dp->getKeywords());
    echo("Zuletzt geändert von : " . $dp->getLastSavedBy());
    echo("Betreuer : " . $dp->getManager());
    echo("Änderungsdatum : " . $dp->getLastSavedTime());
    echo("Präsentationsformat : " . $dp->getPresentationFormat());
    echo("Letztes Druckdatum : " . $dp->getLastPrinted());
    echo("Wird zwischen Herstellern geteilt : " . $dp->getSharedDoc());
    echo("Betreff : " . $dp->getSubject());
    echo("Titel : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ändern der Eingebauten Eigenschaften**
Das Ändern der eingebauten Eigenschaften von Präsentationsdateien ist so einfach wie der Zugriff darauf. Sie können einfach einen String-Wert einer gewünschten Eigenschaft zuweisen und der Eigenschaftswert wird geändert. Im folgenden Beispiel zeigen wir, wie wir die eingebauten Dokumenteigenschaften der Präsentationsdatei mithilfe von Aspose.Slides für PHP über Java ändern können.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    // Erstellen Sie eine Referenz auf das IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    $dp = $pres->getDocumentProperties();
    // Setzen der eingebauten Eigenschaften
    $dp->setAuthor("Aspose.Slides für PHP über Java");
    $dp->setTitle("Ändern der Präsentationseigenschaften");
    $dp->setSubject("Aspose Betreff");
    $dp->setComments("Aspose Beschreibung");
    $dp->setManager("Aspose Manager");
    // Speichern Sie Ihre Präsentation in einer Datei
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dieses Beispiel ändert die eingebauten Eigenschaften der Präsentation, die wie unten gezeigt angezeigt werden können:

|**Eingebaute Dokumenteigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Benutzerdefinierte Dokumenteigenschaften hinzufügen**
Aspose.Slides für PHP über Java ermöglicht es Entwicklern ebenfalls, die benutzerdefinierten Werte für die Präsentationsdokumenteigenschaften hinzuzufügen. Es wird ein Beispiel unten gegeben, das zeigt, wie man die benutzerdefinierten Eigenschaften für eine Präsentation festlegt.

```php
  $pres = new Presentation();
  try {
    // Abrufen der Dokumenteigenschaften
    $dProps = $pres->getDocumentProperties();
    // Hinzufügen benutzerdefinierter Eigenschaften
    $dProps->set_Item("Neue Benutzerdefiniert", 12);
    $dProps->set_Item("Mein Name", "Mudassir");
    $dProps->set_Item("Benutzerdefiniert", 124);
    // Abrufen des Eigenschaftsnamen an einem bestimmten Index
    $getPropertyName = $dProps->getCustomPropertyName(2);
    // Entfernen der ausgewählten Eigenschaft
    $dProps->removeCustomProperty($getPropertyName);
    // Speichern der Präsentation
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Hinzugefügte benutzerdefinierte Dokumenteigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Zugriff und Änderung von benutzerdefinierten Eigenschaften**
Aspose.Slides für PHP über Java ermöglicht es Entwicklern auch, auf die Werte der benutzerdefinierten Eigenschaften zuzugreifen. Es wird ein Beispiel unten gegeben, das zeigt, wie Sie auf alle diese benutzerdefinierten Eigenschaften für eine Präsentation zugreifen und diese ändern können.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    // Erstellen Sie eine Referenz auf das DocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    $dp = $pres->getDocumentProperties();
    // Zugriff und Änderung von benutzerdefinierten Eigenschaften
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()); $i++) {
      // Anzeigen von Namen und Werten der benutzerdefinierten Eigenschaften
      echo("Name der benutzerdefinierten Eigenschaft : " . $dp->getCustomPropertyName($i));
      echo("Wert der benutzerdefinierten Eigenschaft : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      // Ändern der Werte der benutzerdefinierten Eigenschaften
      $dp->set_Item($dp->getCustomPropertyName($i), "Neuer Wert " . $i + 1);
    }
    // Speichern Sie Ihre Präsentation in einer Datei
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX](https://docs.fileformat.com/presentation/pptx/)-Präsentation. Die folgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften der Präsentation vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Benutzerdefinierte Eigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteigenschaften**
{{% alert color="primary" %}} 

Neue Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) und [WriteBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) wurden zur [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo) hinzugefügt, die Logik des [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) Eigenschaftsetzers wurde geändert.

{{% /alert %}} 

Die beiden neuen Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--) und [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) wurden zur [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo) Schnittstelle hinzugefügt. Sie bieten schnellen Zugriff auf Dokumenteigenschaften und ermöglichen das Ändern und Aktualisieren von Eigenschaften, ohne eine gesamte Präsentation zu laden.

Das typische Szenario lädt die Eigenschaften, ändert einen Wert und aktualisiert das Dokument auf folgende Weise:

```php
  // lesen Sie die Informationen der Präsentation
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  // die aktuellen Eigenschaften abrufen
  $props = $info->readDocumentProperties();
  // setzen Sie die neuen Werte für die Felder Autor und Titel
  $props->setAuthor("Neuer Autor");
  $props->setTitle("Neuer Titel");
  // die Präsentation mit neuen Werten aktualisieren
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");

```

Es gibt einen anderen Weg, die Eigenschaften einer bestimmten Präsentation als Vorlage zu verwenden, um die Eigenschaften in anderen Präsentationen zu aktualisieren:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Vorlagenautor");
  $template->setTitle("Vorlagentitel");
  $template->setCategory("Vorlagenkategorie");
  $template->setKeywords("Schlüsselwort1, Schlüsselwort2, Schlüsselwort3");
  $template->setCompany("Unser Unternehmen");
  $template->setComments("Aus Vorlage erstellt");
  $template->setContentType("Vorlageninhalt");
  $template->setSubject("Vorlagenbetreff");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

Eine neue Vorlage kann von Grund auf neu erstellt und dann verwendet werden, um mehrere Präsentationen zu aktualisieren:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Vorlagenautor");
  $template->setTitle("Vorlagentitel");
  $template->setCategory("Vorlagenkategorie");
  $template->setKeywords("Schlüsselwort1, Schlüsselwort2, Schlüsselwort3");
  $template->setCompany("Unser Unternehmen");
  $template->setComments("Aus Vorlage erstellt");
  $template->setContentType("Vorlageninhalt");
  $template->setSubject("Vorlagenbetreff");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

## **Überprüfen, ob die Präsentation geändert oder erstellt wurde**
Aspose.Slides für PHP über Java bietet die Möglichkeit zu überprüfen, ob eine Präsentation geändert oder erstellt wurde. Ein Beispiel wird unten gegeben, das zeigt, wie man überprüfen kann, ob die Präsentation erstellt oder geändert wurde.

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("props.pptx");
  $props = $info->readDocumentProperties();
  $app = $props->getNameOfApplication();
  $ver = $props->getAppVersion();
  echo("Anwendungsname: " . $app);
  echo("Anwendungsversion: " . $ver);

```

## **Sprache für Korrekturhilfen festlegen**

Aspose.Slides bietet die Eigenschaft LanguageId (bereitgestellt durch die Klasse PortionFormat), um die Sprache für die Rechtschreibprüfung eines PowerPoint-Dokuments festzulegen. Die Korrekturhilfesprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint überprüft werden.

Dieser PHP-Code zeigt Ihnen, wie Sie die Korrekturhilfesprache für eine PowerPoint festlegen: xxx Warum fehlt LanguageId in der Java PortionFormat-Klasse?

```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// setzen Sie die ID einer Korrekturhilfesprache

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Standardsprache festlegen**

Dieser PHP-Code zeigt Ihnen, wie Sie die Standardsprache für eine gesamte PowerPoint-Präsentation festlegen:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    // Fügt eine neue Rechteckform mit Text hinzu
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("Neuer Text");
    // Überprüfen Sie die Sprache der ersten Portion
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```