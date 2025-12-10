---
title: Fehlerbalken in Diagrammen von Präsentationen mit C++ anpassen
linktitle: Fehlerbalken
type: docs
url: /de/cpp/error-bar/
keywords:
- Fehlerbalken
- benutzerdefinierter Wert
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Fehlerbalken in Diagrammen mit Aspose.Slides für C++ hinzufügen und anpassen – optimieren Sie die Datenvisualisierung in PowerPoint-Präsentationen."
---

## **Fehlerbalken hinzufügen**
Aspose.Slides für C++ bietet eine einfache API zur Verwaltung von Fehlerbalkenwerten. Der Beispielcode gilt, wenn ein benutzerdefinierter Werttyp verwendet wird. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der **DataPoints**‑Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
2. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
3. Greifen Sie auf die erste Diagrammserie zu und legen Sie das X‑Format des Fehlerbalkens fest.
4. Greifen Sie auf die erste Diagrammserie zu und legen Sie das Y‑Format des Fehlerbalkens fest.
5. Festlegen von Balkenwerten und -format.
6. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Benutzerdefinierte Fehlerbalken hinzufügen**
Aspose.Slides für C++ bietet eine einfache API zur Verwaltung benutzerdefinierter Fehlerbalkenwerte. Der Beispielcode gilt, wenn die Eigenschaft **IErrorBarsFormat.ValueType** den Wert **Custom** hat. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der **DataPoints**‑Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
2. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
3. Greifen Sie auf die erste Diagrammserie zu und legen Sie das X‑Format des Fehlerbalkens fest.
4. Greifen Sie auf die erste Diagrammserie zu und legen Sie das Y‑Format des Fehlerbalkens fest.
5. Greifen Sie auf die einzelnen Datenpunkte der Diagrammserie zu und legen Sie die Fehlerbalkenwerte für einen einzelnen Datenpunkt der Serie fest.
6. Festlegen von Balkenwerten und -format.
7. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**Was passiert mit Fehlerbalken beim Exportieren einer Präsentation in PDF oder Bilder?**

Sie werden als Teil des Diagramms gerendert und bei der Konvertierung zusammen mit der restlichen Diagrammformatierung erhalten, vorausgesetzt, es wird eine kompatible Version oder ein kompatibler Renderer verwendet.

**Können Fehlerbalken mit Markern und Datenbeschriftungen kombiniert werden?**

Ja. Fehlerbalken sind ein separates Element und sind mit Markern und Datenbeschriftungen kompatibel; wenn Elemente überlappen, müssen Sie möglicherweise die Formatierung anpassen.

**Wo finde ich die Liste der Eigenschaften und Enums für die Arbeit mit Fehlerbalken in der API?**

In der API‑Referenz: die Klasse [ErrorBarsFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbarsformat/) und die zugehörigen Enums [ErrorBarType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbartype/) sowie [ErrorBarValueType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/errorbarvaluetype/).