---
title: Abrufen und Aktualisieren von Präsentationsinformationen in PHP
linktitle: Präsentationsinformationen
type: docs
weight: 30
url: /de/php-java/examine-presentation/
keywords:
- Präsentationsformat
- Präsentationseigenschaften
- Dokumenteigenschaften
- Eigenschaften abrufen
- Eigenschaften lesen
- Eigenschaften ändern
- Eigenschaften modifizieren
- Eigenschaften aktualisieren
- PPTX untersuchen
- PPT untersuchen
- ODP untersuchen
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP für schnellere Erkenntnisse und intelligentere Inhaltsprüfungen."
---

Aspose.Slides for PHP via Java ermöglicht es Ihnen, eine Präsentation zu untersuchen, um ihre Eigenschaften zu ermitteln und ihr Verhalten zu verstehen.

{{% alert title="Info" color="info" %}} 

Die [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo)‑ und [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/)‑Klassen enthalten die hier verwendeten Eigenschaften und Methoden.

{{% /alert %}} 

## **Prüfen des Präsentationsformats**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP usw.) die Präsentation derzeit vorliegt.

Sie können das Format einer Präsentation prüfen, ohne die Präsentation zu laden. Siehe diesen PHP‑Code:
```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP
```


## **Präsentationseigenschaften abrufen**

Dieser PHP‑Code zeigt, wie Sie Präsentationseigenschaften (Informationen zur Präsentation) erhalten:
```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```


Sie können die [Eigenschaften der DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--)‑Klasse einsehen.

## **Präsentationseigenschaften aktualisieren**

Aspose.Slides stellt die Methode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) bereit, mit der Sie Änderungen an den Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint‑Präsentation mit den unten gezeigten Dokumenteneigenschaften.

![Original document properties of the PowerPoint presentation](input_properties.png)

Dieses Code‑Beispiel zeigt, wie einige Präsentationseigenschaften bearbeitet werden können:
```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```


Die Ergebnisse der Änderung der Dokumenteneigenschaften sind unten dargestellt.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Nützliche Links**

Weitere Informationen zu einer Präsentation und ihren Sicherheitsattributen finden Sie unter den folgenden Links:

- [Überprüfen, ob eine Präsentation verschlüsselt ist](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Überprüfen, ob eine Präsentation schreibgeschützt (nur lesbar) ist](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Überprüfen, ob eine Präsentation vor dem Laden passwortgeschützt ist](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bestätigung des zum Schutz einer Präsentation verwendeten Passworts](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche das sind?**

Suchen Sie nach [embedded-font information](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getembeddedfonts/) auf Präsentationsebene und vergleichen Sie diese Einträge mit der Menge der [fonts actually used across content](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getfonts/), um zu ermitteln, welche Schriftarten für die Darstellung kritisch sind.

**Wie kann ich schnell feststellen, ob die Datei verborgene Folien enthält und wie viele?**

Durchlaufen Sie die [slide collection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) und prüfen Sie das [visibility flag](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) jeder Folie.

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und Ausrichtung verwendet werden und ob sie von den Vorgaben abweichen?**

Ja. Vergleichen Sie die aktuelle [slide size](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslidesize/) und Ausrichtung mit den Standard‑Voreinstellungen; das hilft, das Verhalten beim Drucken und Exportieren vorherzusagen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchsuchen Sie alle [charts](https://reference.aspose.com/slides/php-java/aspose.slides/chart/), prüfen Sie deren [data source](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) und stellen Sie fest, ob die Daten intern oder verlinkt sind, einschließlich etwaiger defekter Links.

**Wie kann ich „schwere“ Folien bewerten, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Zählen Sie für jede Folie die Objektanzahl und suchen Sie nach großen Bildern, Transparenz, Schatten, Animationen und Multimedia; vergeben Sie einen groben Komplexitäts‑Score, um potenzielle Leistungs‑Hotspots zu kennzeichnen.