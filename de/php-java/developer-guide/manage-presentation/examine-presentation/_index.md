---
title: Präsentationsinformationen in PHP abrufen und aktualisieren
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
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP, um schnellere Einblicke und intelligentere Inhaltsprüfungen zu erhalten."
---
## **Übersicht**

Dieser Artikel zeigt, wie Sie Präsentationsinformationen in Aspose.Slides untersuchen können. Er erklärt, wie Sie das aktuelle Format einer Präsentation ermitteln, ohne die gesamte Datei zu laden, ihre Dokumenteigenschaften lesen und diese bei Bedarf aktualisieren.

Die Beispiele basieren auf den APIs [PresentationInfo](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationinfo/) und [DocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/) und demonstrieren typische Vorgänge für die Arbeit mit Präsentationsmetadaten.

## **Prüfen des Präsentationsformats**

Bevor Sie an einer Präsentation arbeiten, möchten Sie möglicherweise herausfinden, in welchem Format (PPT, PPTX, ODP usw.) sich die Präsentation momentan befindet.

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

Möglicherweise möchten Sie die [properties under the DocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#DocumentProperties--) Klasse einsehen.

## **Präsentationseigenschaften aktualisieren**

Aspose.Slides stellt die Methode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) bereit, mit der Sie Änderungen an Präsentationseigenschaften vornehmen können.

Angenommen, wir haben eine PowerPoint‑Präsentation mit den unten gezeigten Dokumenteigenschaften.

![Original document properties of the PowerPoint presentation](input_properties.png)

Dieses Codebeispiel zeigt, wie Sie einige Präsentationseigenschaften bearbeiten können:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Die Ergebnisse der Änderungen der Dokumenteigenschaften werden unten dargestellt.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Nützliche Links**

Um weitere Informationen über eine Präsentation und ihre Sicherheitsattribute zu erhalten, könnten diese Links nützlich sein:

- [Password-Protect Presentations](/slides/de/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/de/php-java/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche das sind?**

Suchen Sie nach [embedded-font information](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/getembeddedfonts/) auf Präsentationsebene und vergleichen Sie diese Einträge mit der Menge der [fonts actually used across content](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsmanager/getfonts/), um zu ermitteln, welche Schriftarten für die Darstellung kritisch sind.

**Wie kann ich schnell erkennen, ob die Datei versteckte Folien enthält und wie viele?**

Durchlaufen Sie die [slide collection](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/) und prüfen Sie das [visibility flag](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/gethidden/) jeder Folie.

**Kann ich feststellen, ob eine benutzerdefinierte Foliengröße und Orientierung verwendet werden und ob sie von den Vorgabewerten abweichen?**

Ja. Vergleichen Sie die aktuelle [slide size](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/getslidesize/) und Orientierung mit den Standardvoreinstellungen; dies hilft, das Verhalten für Druck und Export vorherzusehen.

**Gibt es eine schnelle Möglichkeit zu sehen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Durchsuchen Sie alle [charts](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/), prüfen Sie deren [data source](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/getdatasourcetype/) und stellen Sie fest, ob die Daten intern oder verlinkt sind, einschließlich eventueller defekter Links.

**Wie kann ich „schwere“ Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Für jede Folie zählen Sie Objektanzahlen und achten auf große Bilder, Transparenz, Schatten, Animationen und Multimedia; vergeben Sie eine grobe Komplexitätsbewertung, um potenzielle Leistungsengpässe zu kennzeichnen.