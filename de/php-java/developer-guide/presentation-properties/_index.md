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
- eingebaute Eigenschaften
- benutzerdefinierte Eigenschaften
- erweiterte Eigenschaften
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
description: "Meistern Sie die Präsentationseigenschaften in Aspose.Slides für PHP via Java und optimieren Sie Suche, Markenauftritt und Arbeitsablauf in Ihren PowerPoint- und OpenDocument-Dateien."
---

{{% alert color="primary" %}} 

Microsoft PowerPoint bietet eine Funktion, um einige Eigenschaften zu den Präsentationsdateien hinzuzufügen. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dokumenten (Präsentationsdateien) zu speichern. Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (eingebaute) Eigenschaften
- Benutzerdefinierte (eigene) Eigenschaften

**Eingebaute** Eigenschaften enthalten allgemeine Informationen über das Dokument, wie Dokumenttitel, Autorname, Dokumentstatistiken usw. **Benutzerdefinierte** Eigenschaften sind solche, die von den Benutzern als **Name/Wert**‑Paare definiert werden, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden. Mit Aspose.Slides for PHP via Java können Entwickler sowohl die Werte eingebauter Eigenschaften als auch benutzerdefinierter Eigenschaften lesen und ändern.

{{% /alert %}} 

## **Dokumenteigenschaften in PowerPoint**

Microsoft PowerPoint 2007 ermöglicht die Verwaltung der Dokumenteigenschaften von Präsentationsdateien. Alles, was Sie tun müssen, ist das Office‑Symbol anzuklicken und anschließend den Menüpunkt **Vorbereiten | Eigenschaften | Erweiterte Eigenschaften** von Microsoft PowerPoint 2007 auszuwählen, wie unten gezeigt:

{{% alert color="primary" %}} 

Bitte beachten Sie, dass Sie keine Werte für die Felder **Application** und **Producer** festlegen können, da Aspose Ltd. und Aspose.Slides for PHP via Java x.x.x in diesen Feldern angezeigt werden.

{{% /alert %}} 

|**Auswahl des Menüpunkts Erweiterte Eigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Nachdem Sie den Menüpunkt **Erweiterte Eigenschaften** ausgewählt haben, erscheint ein Dialog, der die Verwaltung der Dokumenteigenschaften der PowerPoint‑Datei ermöglicht, wie in der Abbildung unten dargestellt:

|**Eigenschaftsdialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Im obigen **Eigenschaftsdialog** sehen Sie viele Registerkarten wie **Allgemein**, **Zusammenfassung**, **Statistik**, **Inhalte** und **Benutzerdefiniert**. Alle diese Registerkarten erlauben die Konfiguration verschiedener Arten von Informationen zu den PowerPoint‑Dateien. Die Registerkarte **Benutzerdefiniert** wird verwendet, um die benutzerdefinierten Eigenschaften der PowerPoint‑Dateien zu verwalten.

### Arbeiten mit Dokumenteigenschaften mit Aspose.Slides for PHP via Java

Wie bereits beschrieben, unterstützt Aspose.Slides for PHP via Java zwei Arten von Dokumenteigenschaften: **Eingebaute** und **Benutzerdefinierte** Eigenschaften. Entwickler können beide Arten von Eigenschaften über die Aspose.Slides for PHP via Java‑API nutzen. Aspose.Slides for PHP via Java stellt die Klasse [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties) bereit, die die Dokumenteigenschaften einer Präsentationsdatei über die Eigenschaft **Presentation.DocumentProperties** repräsentiert.

Entwickler können die **IDocumentProperties**‑Eigenschaft, die vom [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)‑Objekt bereitgestellt wird, verwenden, um die Dokumenteigenschaften der Präsentationsdateien wie unten beschrieben zuzugreifen:

## **Zugriff auf eingebaute Eigenschaften**

Diese Eigenschaften, die vom [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties)‑Objekt bereitgestellt werden, umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **SharedDoc** (Ist zwischen verschiedenen Produzenten geteilt?), **PresentationFormat**, **Subject** und **Title**.
```php
  # Instanziieren Sie die Presentation-Klasse, die die Präsentation darstellt
  $pres = new Presentation("Presentation.pptx");
  try {
    # Erstellen Sie eine Referenz zum IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
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

Das Ändern eingebauter Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einen Zeichenkettenwert einer gewünschten Eigenschaft zuweisen und der Eigenschaftswert wird geändert. Im nachfolgenden Beispiel zeigen wir, wie wir die eingebauten Dokumenteigenschaften einer Präsentationsdatei mit Aspose.Slides for PHP via Java ändern können.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Erstellen Sie eine Referenz zum IDocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    $dp = $pres->getDocumentProperties();
    # Setzen Sie die eingebauten Eigenschaften
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


Dieses Beispiel ändert die eingebauten Eigenschaften der Präsentation, die wie folgt dargestellt werden können:

|**Eingebaute Dokumenteigenschaften nach Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Benutzerdefinierte Dokumenteigenschaften hinzufügen**

Aspose.Slides for PHP via Java ermöglicht Entwicklern außerdem das Hinzufügen benutzerdefinierter Werte für die Dokumenteigenschaften einer Präsentation. Das nachfolgende Beispiel zeigt, wie benutzerdefinierte Eigenschaften für eine Präsentation festgelegt werden.
```php
  $pres = new Presentation();
  try {
    # Abrufen der Dokumenteigenschaften
    $dProps = $pres->getDocumentProperties();
    # Hinzufügen benutzerdefinierter Eigenschaften
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Abrufen des Eigenschaftsnamens an einem bestimmten Index
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


|**Hinzugefügte benutzerdefinierte Dokumenteigenschaften**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**

Aspose.Slides for PHP via Java ermöglicht Entwicklern zudem den Zugriff auf die Werte benutzerdefinierter Eigenschaften. Das nachfolgende Beispiel zeigt, wie Sie alle diese benutzerdefinierten Eigenschaften einer Präsentation lesen und ändern können.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Erstelle eine Referenz zum DocumentProperties-Objekt, das mit der Präsentation verknüpft ist
    $dp = $pres->getDocumentProperties();
    # Zugriff auf und Ändern benutzerdefinierter Eigenschaften
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Anzeige von Namen und Werten benutzerdefinierter Eigenschaften
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Werte benutzerdefinierter Eigenschaften ändern
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


Dieses Beispiel ändert die benutzerdefinierten Eigenschaften einer [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Präsentation. Die folgenden Abbildungen zeigen die benutzerdefinierten Eigenschaften der Präsentation vor und nach der Änderung:

|**Benutzerdefinierte Eigenschaften vor der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Benutzerdefinierte Eigenschaften nach der Änderung**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Erweiterte Dokumenteigenschaften**

{{% alert color="primary" %}} 

Neue Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), und [WriteBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) wurden zu [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo) hinzugefügt, die Logik des Setters für die Eigenschaft [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) wurde geändert.

{{% /alert %}} 

Die beiden neuen Methoden [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--) und [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) wurden dem Interface [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo) hinzugefügt. Sie bieten schnellen Zugriff auf Dokumenteigenschaften und ermöglichen das Ändern und Aktualisieren von Eigenschaften, ohne die gesamte Präsentation zu laden.

Das typische Szenario, die Eigenschaften zu laden, einen Wert zu ändern und das Dokument zu aktualisieren, kann wie folgt implementiert werden:
```php
  # Lese die Informationen der Präsentation
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # Erhalte die aktuellen Eigenschaften
  $props = $info->readDocumentProperties();
  # Setze die neuen Werte der Felder Autor und Titel
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


## **Korrektursprache festlegen**

Aspose.Slides stellt die Eigenschaft LanguageId (exponiert durch die Klasse PortionFormat) zur Verfügung, um die Korrektursprache für ein PowerPoint‑Dokument festzulegen. Die Korrektursprache ist die Sprache, für die Rechtschreibung und Grammatik in PowerPoint überprüft werden.

Dieser PHP‑Code zeigt, wie Sie die Korrektursprache für ein PowerPoint festlegen: xxx Warum fehlt LanguageId in der Java‑PortionFormat‑Klasse?
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
    $portionFormat::setLanguageId("zh-CN");// setzt die ID einer Korrektursprache

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Standardsprache festlegen**

Dieser PHP‑Code zeigt, wie Sie die Standardsprache für eine gesamte PowerPoint‑Präsentation festlegen:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Fügt ein neues Rechteck-Shape mit Text hinzu
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Überprüft die Sprache der ersten Portion
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Live‑Beispiel**

Probieren Sie die Online‑App [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) aus, um zu sehen, wie man mit Dokumenteigenschaften über die Aspose.Slides‑API arbeitet:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, falls die jeweilige Eigenschaft es zulässt, auf leer setzen.

**Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**

Wenn Sie eine benutzerdefinierte Eigenschaft hinzufügen, die bereits existiert, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich Präsentationseigenschaften abrufen, ohne die gesamte Präsentation zu laden?**

Ja, Sie können Präsentationseigenschaften abrufen, ohne die gesamte Präsentation zu laden, indem Sie die Methode `getPresentationInfo` der Klasse [PresentationFactory](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/) verwenden. Anschließend nutzen Sie die Methode `readDocumentProperties` der Klasse [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/), um die Eigenschaften effizient zu lesen, Speicher zu sparen und die Leistung zu verbessern.