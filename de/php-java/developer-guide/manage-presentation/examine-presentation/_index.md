---
title: Präsentation Untersuchen
type: docs
weight: 30
url: /php-java/präsentation-untersuchen/
keywords:
- PowerPoint
- präsentation
- präsentationsformat
- präsentationseigenschaften
- dokumenteigenschaften
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

Die Klassen [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) und [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) enthalten die Eigenschaften und Methoden, die hier in den Operationen verwendet werden.

{{% /alert %}} 

## **Präsentationsformat Überprüfen**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP und andere) sich die Präsentation im Moment befindet.

Sie können das Format einer Präsentation überprüfen, ohne die Präsentation zu laden. Sehen Sie sich diesen PHP-Code an:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Präsentationseigenschaften Abrufen**

Dieser PHP-Code zeigt Ihnen, wie Sie Präsentationseigenschaften (Informationen über die Präsentation) abrufen:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

Sie möchten möglicherweise die [Eigenschaften unter der DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--) Klasse ansehen.

## **Präsentationseigenschaften Aktualisieren**

Aspose.Slides bietet die Methode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), die es Ihnen ermöglicht, Änderungen an den Präsentationseigenschaften vorzunehmen.

Angenommen, wir haben eine PowerPoint-Präsentation mit den unten angezeigten Dokumenteigenschaften.

![Ursprüngliche Dokumenteigenschaften der PowerPoint-Präsentation](input_properties.png)

Dieses Code-Beispiel zeigt Ihnen, wie Sie einige Präsentationseigenschaften bearbeiten:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("Mein Titel");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Die Ergebnisse der Änderung der Dokumenteigenschaften sind unten angezeigt.

![Geänderte Dokumenteigenschaften der PowerPoint-Präsentation](output_properties.png)

## **Nützliche Links**

Um mehr Informationen über eine Präsentation und ihre Sicherheitsattribute zu erhalten, finden Sie diese Links nützlich:

- [Überprüfen, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Überprüfen, ob eine Präsentation schreibgeschützt (nur lesbar) ist](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Überprüfen, ob eine Präsentation vor dem Laden passwortgeschützt ist](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigen des Passworts, das verwendet wurde, um eine Präsentation zu schützen](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).