---
title: Präsentation Untersuchen
type: docs
weight: 30
url: /de/php-java/examine-presentation/
keywords:
- PowerPoint
- präsentation
- präsentationsformat
- präsentationseigenschaften
- dokumentspezifikationen
- eigenschaften abrufen
- eigenschaften lesen
- eigenschaften ändern
- eigenschaften modifizieren
- PPTX
- PPT
- PHP
- Java
description: "Lesen und Ändern von PowerPoint-Präsentationseigenschaften in PHP über Java"
---

Aspose.Slides für PHP über Java ermöglicht es Ihnen, eine Präsentation zu untersuchen, um ihre Eigenschaften herauszufinden und ihr Verhalten zu verstehen.

{{% alert title="Info" color="info" %}} 

Die [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) und [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) Klassen enthalten die Eigenschaften und Methoden, die hier in den Operationen verwendet werden.

{{% /alert %}} 

## **Überprüfen eines Präsentationsformats**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und andere) sich die Präsentation derzeit befindet.

Sie können das Format einer Präsentation überprüfen, ohne die Präsentation zu laden. Siehe diesen PHP-Code:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP
```

## **Präsentationseigenschaften abrufen**

Dieser PHP-Code zeigt Ihnen, wie Sie Präsentationseigenschaften (Informationen über die Präsentation) abrufen:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

Sie möchten möglicherweise die [Eigenschaften unter der DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--) Klasse sehen.

## **Präsentationseigenschaften aktualisieren**

Aspose.Slides bietet die [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) Methode, die es Ihnen ermöglicht, Änderungen an Präsentationseigenschaften vorzunehmen.

Angenommen, wir haben eine PowerPoint-Präsentation mit den unten angezeigten Dokumenteigenschaften.

![Originaldokumenteigenschaften der PowerPoint-Präsentation](input_properties.png)

Dieses Codebeispiel zeigt Ihnen, wie Sie einige Präsentationseigenschaften bearbeiten:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("Mein Titel");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Die Ergebnisse der Änderung der Dokumenteigenschaften sind unten gezeigt.

![Geänderte Dokumenteigenschaften der PowerPoint-Präsentation](output_properties.png)

## **Nützliche Links**

Um mehr Informationen über eine Präsentation und ihre Sicherheitsattribute zu erhalten, finden Sie diese Links möglicherweise hilfreich:

- [Überprüfen, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Überprüfen, ob eine Präsentation schreibgeschützt (nur lesen) ist](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Überprüfen, ob eine Präsentation passwortgeschützt ist, bevor sie geladen wird](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigung des Passworts, das zum Schutz einer Präsentation verwendet wurde](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).
