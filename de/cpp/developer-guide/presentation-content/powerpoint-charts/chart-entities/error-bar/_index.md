---
title: "Fehlerbalken in Präsentationsdiagrammen mit C++ anpassen"
linktitle: "Fehlerbalken"
type: docs
url: /de/cpp/error-bar/
keywords:
- "Fehlerbalken"
- "Benutzerdefinierter Wert"
- "PowerPoint"
- "Präsentation"
- "C++"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie Fehlerbalken in Diagrammen mit Aspose.Slides für C++ hinzufügen und anpassen — optimieren Sie Datenvisualisierungen in PowerPoint-Präsentationen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Fehlerbalken in Präsentationsdiagrammen mithilfe von Aspose.Slides arbeitet. Er zeigt, wie Fehlerbalken zu einer Diagrammserie hinzugefügt, X- und Y-Fehlerbalkeneinstellungen konfiguriert und verschiedene Werttypen wie feste, prozentuale und benutzerdefinierte Werte angewendet werden.

Er demonstriert außerdem, wie benutzerdefinierte Fehlerbalkenwerte für einzelne Datenpunkte einer Serie über die entsprechende Datenpunkt‑sammlung zugewiesen werden. Zusätzlich enthält der Artikel kurze Hinweise darauf, wie sich Fehlerbalken beim Export verhalten, ihre Kompatibilität mit Markierungen und Datenbeschriftungen sowie wo die zugehörigen API‑Referenzklassen und Aufzählungen zu finden sind.

## **Fehlerbalken hinzufügen**
Aspose.Slides für C++ bietet eine einfache API zur Verwaltung von Fehlerbalkenwerten. Der Beispielcode gilt, wenn ein benutzerdefinierter Werttyp verwendet wird. Um einen Wert festzulegen, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der **DataPoints**‑Sammlung der Serie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X‑Fehlerbalkenformat.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y‑Fehlerbalkenformat.
1. Festlegen der Balkenwerte und des Formats.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Benutzerdefinierte Fehlerbalken hinzufügen**
Aspose.Slides für C++ bietet eine einfache API zur Verwaltung benutzerdefinierter Fehlerbalkenwerte. Der Beispielcode gilt, wenn die **IErrorBarsFormat.ValueType**‑Eigenschaft auf **Custom** gesetzt ist. Um einen Wert festzulegen, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der **DataPoints**‑Sammlung der Serie:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X‑Fehlerbalkenformat.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y‑Fehlerbalkenformat.
1. Greifen Sie auf die einzelnen Datenpunkte der Diagrammserie zu und setzen Sie die Fehlerbalkenwerte für einen einzelnen Datenpunkt der Serie.
1. Festlegen der Balkenwerte und des Formats.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**Was passiert mit Fehlerbalken, wenn eine Präsentation in PDF oder Bilder exportiert wird?**

Sie werden als Teil des Diagramms gerendert und bei der Konvertierung zusammen mit der restlichen Diagrammformatierung erhalten, vorausgesetzt, es wird eine kompatible Version oder ein kompatibler Renderer verwendet.

**Können Fehlerbalken mit Markierungen und Datenbeschriftungen kombiniert werden?**

Ja. Fehlerbalken sind ein separates Element und sind mit Markierungen und Datenbeschriftungen kompatibel; überschneiden sich die Elemente, müssen Sie ggf. das Format anpassen.

**Wo finde ich die Liste der Eigenschaften und Aufzählungen für die Arbeit mit Fehlerbalken in der API?**

In der API‑Referenz: die Klasse [ErrorBarsFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/errorbarsformat/) und die zugehörigen Aufzählungen [ErrorBarType](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/errorbartype/) und [ErrorBarValueType](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/errorbarvaluetype/).