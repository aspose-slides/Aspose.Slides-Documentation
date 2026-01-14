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
- Korrektursprache
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Präsentationseigenschaften in Aspose.Slides für PHP via Java und optimieren Sie Suche, Branding und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---

{{% alert color="primary" %}} 

Microsoft PowerPoint bietet eine Funktion, mit der einige Eigenschaften zu den Präsentationsdateien hinzugefügt werden können. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (eingebaute) Eigenschaften
- Benutzerdefinierte (eigene) Eigenschaften

**Eingebaute** Eigenschaften enthalten allgemeine Informationen zum Dokument, wie Dokumenttitel, Namen des Autors, Dokumentstatistiken usw. **Eigene** Eigenschaften sind solche, die von den Benutzern als **Name/Wert**‑Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides for PHP via Java können Entwickler sowohl die Werte eingebauter Eigenschaften als auch eigener Eigenschaften abrufen und ändern.

{{% /alert %}} 

## **Dokumenteigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften der Präsentationsdateien. Sie müssen lediglich das Office‑Symbol anklicken und anschließend den Menüpunkt **Prepare | Properties | Advanced Properties** von Microsoft PowerPoint 2007, wie unten gezeigt, auswählen:

{{% alert color="primary" %}} 

Bitte beachten Sie, dass Sie keine Werte für die Felder **Application** und **Producer** festlegen können, da dort Aspose Ltd. und Aspose.Slides for PHP via Java x.x.x angezeigt werden.

{{% /alert %}} 

|**Auswahl des Menüpunkts Erweiterte Eigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Nachdem Sie den Menüpunkt **Advanced Properties** ausgewählt haben, erscheint ein Dialog, der Ihnen ermöglicht, die Dokumenteigenschaften der PowerPoint‑Datei zu verwalten, wie in der untenstehenden Abbildung gezeigt:

|**Eigenschaften‑Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Im oben gezeigten **Properties Dialog** sehen Sie, dass es mehrere Registerkarten gibt, z. B. **General**, **Summary**, **Statistics**, **Contents** und **Custom**. Alle diese Registerkarten ermöglichen die Konfiguration verschiedener Arten von Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Custom** wird verwendet, um die eigenen Eigenschaften der PowerPoint‑Dateien zu verwalten.

## **Arbeiten mit Dokumenteigenschaften mit Aspose.Slides for PHP via Java**

Wie bereits beschrieben, unterstützt Aspose.Slides for PHP via Java zwei Arten von Dokumenteigenschaften, nämlich **Built-in** und **Custom** Eigenschaften. Entwickler können somit über die Aspose.Slides for PHP via Java‑API auf beide Arten von Eigenschaften zugreifen. Aspose.Slides for PHP via Java stellt die Klasse [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties) bereit, die die mit einer Präsentationsdatei verbundenen Dokumenteigenschaften über die Eigenschaft **Presentation.DocumentProperties** repräsentiert.

Entwickler können die über das Objekt [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) bereitgestellte Eigenschaft **DocumentProperties** verwenden, um auf die Dokumenteigenschaften der Präsentationsdateien zuzugreifen, wie nachfolgend beschrieben:

## **Zugriff auf eingebauten Eigenschaften**

Diese durch das Objekt [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties) bereitgestellten Eigenschaften umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wird zwischen verschiedenen Produzenten geteilt?), **PresentationFormat**, **Subject** und **Title**.

```php
  # Instanziieren Sie die Presentation-Klasse, die die Präsentation darstellt
  $pres = new Presentation("Presentation.pptx");
  try {
    # Erstellen Sie eine Referenz auf das IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
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


## **Ändern eingebauter Eigenschaften**

Das Ändern eingebauter Eigenschaften von Präsentationsdateien ist ebenso einfach wie der Zugriff darauf. Sie können einfach einen Zeichenkettenwert einer gewünschten Eigenschaft zuweisen und der Eigenschaftswert wird geändert. Im nachstehenden Beispiel haben wir gezeigt, wie man die eingebauten Dokumenteigenschaften einer Präsentationsdatei mithilfe von Aspose.Slides for PHP via Java ändern kann.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Erstellen Sie eine Referenz auf das IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
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


Dieses Beispiel ändert die eingebauten Eigenschaften der Präsentation, wie nachstehend zu sehen ist:

|**Eingebaute Dokumenteigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Eigene Dokumenteigenschaften hinzufügen**

Aspose.Slides for PHP via Java ermöglicht es Entwicklern zudem, benutzerdefinierte Werte für die Dokumenteigenschaften einer Präsentation hinzuzufügen. Im Folgenden wird ein Beispiel gezeigt, das das Festlegen benutzerdefinierter Eigenschaften für eine Präsentation demonstriert.

```php
  $pres = new Presentation();
  try {
    # Abrufen der Dokumenteigenschaften
    $dProps = $pres->getDocumentProperties();
    # Hinzufügen benutzerdefinierter Eigenschaften
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Abrufen des Eigenschaftsnamen an einem bestimmten Index
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Entfernen der ausgewählten Eigenschaft
    $dProps->removeCustomProperty($getPropertyName);
    # Präsentation speichern
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|**Hinzugefügte eigene Dokumenteigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**

Aspose.Slides for PHP via Java ermöglicht es Entwicklern zudem, auf die Werte benutzerdefinierter Eigenschaften zuzugreifen. Im Folgenden wird ein Beispiel gezeigt, das demonstriert, wie Sie alle diese benutzerdefinierten Eigenschaften einer Präsentation abrufen und ändern können.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Erstellen Sie eine Referenz auf das DocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    $dp = $pres->getDocumentProperties();
    # Zugriff auf und Modifikation benutzerdefinierter Eigenschaften
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


Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX ](https://docs.fileformat.com/presentation/pptx/) Präsentation. Die folgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften der Präsentation vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Benutzerdefinierte Eigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteigenschaften**

{{% alert color="primary" %}} 

Neue Methoden [readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) und [writeBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) wurden zu [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) hinzugefügt, die Logik des Setzers für die Eigenschaft [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setLastSavedTime) wurde geändert.

{{% /alert %}} 

Die beiden neuen Methoden [readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) und [updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) wurden zur Klasse [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) hinzugefügt. Sie ermöglichen einen schnellen Zugriff auf Dokumenteigenschaften und erlauben das Ändern und Aktualisieren von Eigenschaften, ohne die gesamte Präsentation zu laden.

Das typische Szenario – Eigenschaften laden, einen Wert ändern und das Dokument aktualisieren – kann wie folgt umgesetzt werden:

```php
  # Informationen der Präsentation lesen
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # aktuelle Eigenschaften erhalten
  $props = $info->readDocumentProperties();
  # neue Werte für Autor- und Titel-Felder setzen
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # Präsentation mit neuen Werten aktualisieren
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


## **Rechtschreibsprache festlegen**

Aspose.Slides stellt die Eigenschaft LanguageId (bereitgestellt durch die Klasse PortionFormat) bereit, mit der Sie die Korrektursprache für ein PowerPoint‑Dokument festlegen können. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint geprüft werden.

Dieser PHP‑Code zeigt, wie Sie die Korrektursprache für ein PowerPoint festlegen: xxx Warum fehlt LanguageId in der Java‑Klasse PortionFormat?

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
    $portionFormat::setLanguageId("zh-CN");// setzt die Id einer Korrektursprache
    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Standard‑Sprache festlegen**

Dieser PHP‑Code zeigt, wie Sie die Standardsprache für eine gesamte PowerPoint‑Präsentation festlegen:

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


## **Live Beispiel**

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) aus, um zu sehen, wie man mit Dokumenteigenschaften über die Aspose.Slides‑API arbeitet:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder sie, sofern die jeweilige Eigenschaft es zulässt, auf leer setzen.

**Was passiert, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?**

Wenn Sie eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufügen, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert der Eigenschaft automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden?**

Ja, Sie können auf Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden, indem Sie die Methode `getPresentationInfo` der Klasse [PresentationFactory](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/) verwenden. Anschließend nutzen Sie die Methode `readDocumentProperties` der Klasse [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/), um die Eigenschaften effizient auszulesen, wodurch Speicher gespart und die Leistung verbessert wird.