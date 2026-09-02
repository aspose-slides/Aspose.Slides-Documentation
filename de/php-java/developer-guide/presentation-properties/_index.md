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
- PHP
- Aspose.Slides
description: "Verwalten Sie Präsentationseigenschaften in Aspose.Slides für PHP via Java und optimieren Sie Suche, Markenbildung und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einleitung**

Aspose.Slides unterstützt zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Beide Eigenschaftstypen können problemlos über die Aspose.Slides‑API abgerufen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteigenschaften von Präsentationen über die Klasse [DocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/) . Eine Instanz dieser Klasse wird von der Methode [Presentation::getDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getDocumentProperties) zurückgegeben. Die folgenden Beispiele zeigen, wie diese Eigenschaften gelesen, geändert und verwaltet werden können.

{{% alert color="info" title="Note" %}}
Bitte beachten Sie, dass die Felder **Application** und **AppVersion** nicht geändert werden können. Aspose.Slides überschreibt sie bei jedem Speichern, sodass eine gespeicherte Präsentation stets „Aspose.Slides for PHP via Java“ und die Version der Bibliothek, die sie erzeugt hat, anzeigt. Jeder an `setNameOfApplication` übergebene Wert wird beim Schreiben der Präsentation verworfen.
{{% /alert %}} 

## **Präsentationseigenschaften verwalten**

Microsoft PowerPoint bietet eine Funktion, um einigen Präsentationsdateien Eigenschaften hinzuzufügen. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt folgende zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (Built-in) Eigenschaften
- Benutzerdefinierte (Custom) Eigenschaften

**Built-in**‑Eigenschaften enthalten allgemeine Informationen zum Dokument, wie Dokumenttitel, Namen des Autors, Dokumentstatistiken usw. **Custom**‑Eigenschaften sind solche, die von Benutzern als **Name/Wert**‑Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides for PHP via Java können Entwickler sowohl die Werte von Built-in‑ als auch von Custom‑Eigenschaften abrufen und ändern.

## **Dokumenteigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften von Präsentationsdateien. Alles, was Sie tun müssen, ist das Office‑Symbol zu klicken und anschließend den Menüeintrag **Prepare | Properties | Advanced Properties** in Microsoft PowerPoint 2007 wie unten gezeigt auszuwählen:

|**Auswahl des Menüpunkts Erweiterte Eigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Nach der Auswahl des Menüpunkts **Advanced Properties** erscheint ein Dialog, der die Verwaltung der Dokumenteigenschaften der PowerPoint‑Datei ermöglicht, wie in der folgenden Abbildung dargestellt:

|**Eigenschaftsdialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Im obigen **Eigenschaftsdialog** sehen Sie mehrere Registerkarten wie **General**, **Summary**, **Statistics**, **Contents** und **Custom**. All diese Registerkarten erlauben die Konfiguration verschiedener Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Custom** wird verwendet, um die benutzerdefinierten Eigenschaften der PowerPoint‑Dateien zu verwalten.

### Arbeiten mit Dokumenteigenschaften mit Aspose.Slides for PHP via Java

Wie bereits beschrieben, unterstützt Aspose.Slides for PHP via Java zwei Arten von Dokumenteigenschaften: **Built-in**‑ und **Custom**‑Eigenschaften. Entwickler können also beide Arten von Eigenschaften über die Aspose.Slides for PHP via Java‑API abrufen. Aspose.Slides for PHP via Java stellt die Klasse [DocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties) bereit, die die Dokumenteigenschaften einer Präsentationsdatei über die Eigenschaft **Presentation.DocumentProperties** repräsentiert.

Entwickler können die von dem Objekt [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation) bereitgestellte Eigenschaft **DocumentProperties** verwenden, um die Dokumenteigenschaften von Präsentationsdateien wie unten beschrieben zuzugreifen:

## **Zugriff auf Built-in‑Eigenschaften**

Diese über das Objekt [DocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties) bereitgestellten Eigenschaften umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wird zwischen verschiedenen Erstellern geteilt?), **PresentationFormat**, **Subject** und **Title**

```php
  # Instanziere die Presentation-Klasse, die die Präsentation darstellt
  $pres = new Presentation("Presentation.pptx");
  try {
    # Erstelle eine Referenz auf das IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    $dp = $pres->getDocumentProperties();
    # Zeige die integrierten Eigenschaften an
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

Das Ändern der Built-in‑Eigenschaften von Präsentationsdateien ist genauso einfach wie das Abrufen. Sie können einfach einen Zeichenkettenwert einer beliebigen Eigenschaft zuweisen, und der Eigenschaftswert wird geändert. Im nachstehenden Beispiel haben wir gezeigt, wie die Built-in‑Dokumenteigenschaften einer Präsentationsdatei mit Aspose.Slides for PHP via Java geändert werden können.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Erstelle eine Referenz auf das IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    $dp = $pres->getDocumentProperties();
    # Setze die integrierten Eigenschaften
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Speichere deine Präsentation in einer Datei
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dieses Beispiel ändert die Built-in‑Eigenschaften der Präsentation, die unten dargestellt werden:

|**Built-in‑Dokumenteigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Benutzerdefinierte Dokumenteigenschaften hinzufügen**

Aspose.Slides for PHP via Java ermöglicht es Entwicklern außerdem, benutzerdefinierte Werte zu den Dokumenteigenschaften einer Präsentation hinzuzufügen. Das folgende Beispiel zeigt, wie benutzerdefinierte Eigenschaften für eine Präsentation festgelegt werden.

```php
  $pres = new Presentation();
  try {
    # Abrufen von Dokumenteigenschaften
    $dProps = $pres->getDocumentProperties();
    # Hinzufügen benutzerdefinierter Eigenschaften
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Abrufen des Eigenschaftsnamens an einem bestimmten Index
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

Aspose.Slides for PHP via Java ermöglicht es Entwicklern außerdem, die Werte benutzerdefinierter Eigenschaften abzurufen. Das folgende Beispiel zeigt, wie Sie alle diese benutzerdefinierten Eigenschaften einer Präsentation abrufen und ändern können.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Erstelle eine Referenz auf das DocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    $dp = $pres->getDocumentProperties();
    # Zugriff auf und Ändern benutzerdefinierter Eigenschaften
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Anzeigen von Namen und Werten benutzerdefinierter Eigenschaften
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Ändern der Werte benutzerdefinierter Eigenschaften
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Speichere deine Präsentation in einer Datei
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Dieses Beispiel ändert die benutzerdefinierten Eigenschaften der [PPTX ](https://docs.fileformat.com/presentation/pptx/)‑Präsentation. Die folgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften der Präsentation vor und nach der Änderung:

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

Die beiden neuen Methoden [readDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) und [updateDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) wurden zur Klasse [PresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/PresentationInfo) hinzugefügt. Sie ermöglichen schnellen Zugriff auf Dokumenteigenschaften und erlauben das Ändern und Aktualisieren von Eigenschaften, ohne eine gesamte Präsentation zu laden.

Das typische Szenario, die Eigenschaften zu laden, einen Wert zu ändern und das Dokument zu aktualisieren, kann wie folgt umgesetzt werden:

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

Eine neue Vorlage kann von Grund auf erstellt und anschließend verwendet werden, um mehrere Präsentationen zu aktualisieren:

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

## **Korrektursprache festlegen**

Aspose.Slides stellt die Eigenschaft LanguageId (bereitgestellt von der Klasse PortionFormat) zur Verfügung, mit der Sie die Korrektursprache für ein PowerPoint‑Dokument festlegen können. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint geprüft werden.

Dieser PHP‑Code zeigt, wie die Korrektursprache für ein PowerPoint festgelegt wird: xxx Warum fehlt LanguageId in der Java‑PortionFormat‑Klasse?

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
    $portionFormat->setLanguageId("zh-CN");// setze die ID einer Korrektursprache

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Standard‑Sprache festlegen**

Dieser PHP‑Code zeigt, wie die Standardsprache für eine gesamte PowerPoint‑Präsentation festgelegt wird:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Fügt ein neues Rechteck-Shape mit Text hinzu
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Überprüft die Sprache des ersten Abschnitts
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Live‑Beispiel**

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/de/metadata) aus, um zu sehen, wie Sie mit Dokumenteigenschaften über die Aspose.Slides‑API arbeiten können:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## **FAQ**

**Wie kann ich eine Built-in‑Eigenschaft aus einer Präsentation entfernen?**

Built-in‑Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, sofern die jeweilige Eigenschaft dies zulässt, auf leer setzen.

**Was passiert, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?**

Wenn Sie eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufügen, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich Präsentationseigenschaften abrufen, ohne die Präsentation vollständig zu laden?**

Ja. Verwenden Sie [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationfactory/) und anschließend [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/#readDocumentProperties), um gespeicherte Dokumentmetadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Instanz zu erzeugen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/php-java/examine-presentation/) für ein umfassendes Berichtbeispiel und formatbezogene Einschränkungen.