---
title: Callouts in Präsentationsdiagrammen mit C++ verwalten
linktitle: Callout
type: docs
url: /de/cpp/callout/
keywords:
- Diagramm-Callout
- Callout verwenden
- Datenbeschriftung
- Beschriftungsformat
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erstellen und formatieren Sie Callouts in Aspose.Slides für C++ mit prägnanten Codebeispielen, kompatibel mit PPT und PPTX, um Präsentations‑Workflows zu automatisieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie mit Callouts für Diagrammdatenbeschriftungen in Aspose.Slides arbeiten. Er zeigt, wie die Methode `set_ShowLabelAsDataCallout` verwendet wird, um Beschriftungen als Callouts anzuzeigen, wie callout‑bezogene Beschriftungseinstellungen für ein Donut‑Diagramm konfiguriert werden und dass Callouts und ihr Erscheinungsbild erhalten bleiben, wenn Präsentationen in PDF, HTML5, SVG und Raster‑Bildformate exportiert werden.

## **Verwendung von Callouts**
Die neue Eigenschaft **ShowLabelAsDataCallout** wurde zur Klasse **DataLabelFormat** und zur Schnittstelle **IDataLabelFormat** hinzugefügt. Sie bestimmt, ob die Datenbeschriftung eines angegebenen Diagramms als Daten‑Callout oder als Datenbeschriftung angezeigt wird. Im nachstehenden Beispiel haben wir die Callouts festgelegt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Callout für ein Donut-Diagramm festlegen**
Aspose.Slides für C++ bietet Unterstützung zum Festlegen der Callout‑Form der Serien‑Datenbeschriftung für ein Donut‑Diagramm. Im Folgenden ist ein Beispiel angegeben.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**Werden Callouts beim Konvertieren einer Präsentation in PDF, HTML5, SVG oder Bilder erhalten?**

Ja. Callouts sind Teil der Diagrammdarstellung, sodass sie beim Exportieren nach [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/de/cpp/export-to-html5/), [SVG](/slides/de/cpp/render-a-slide-as-an-svg-image/) oder [Raster‑Bildern](/slides/de/cpp/convert-powerpoint-to-png/) zusammen mit der Formatierung der Folie erhalten bleiben.

**Funktionieren benutzerdefinierte Schriftarten in Callouts, und kann ihr Erscheinungsbild beim Export erhalten bleiben?**

Ja. Aspose.Slides unterstützt das [Einbetten von Schriftarten](/slides/de/cpp/embedded-font/) in die Präsentation und steuert das Einbetten von Schriftarten während Exporte wie [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/), sodass die Callouts auf verschiedenen Systemen gleich aussehen.