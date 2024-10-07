---
title: Fehlerbalken
type: docs
url: /cpp/error-bar/
---

## **Fehlerbalken hinzufügen**
Aspose.Slides für C++ bietet eine einfache API zur Verwaltung von Fehlerbalkenwerten. Der Beispielcode gilt beim Verwenden eines benutzerdefinierten Werttyps. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues** Eigenschaft eines bestimmten Datenpunkts in der **DataPoints** Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Format des Fehlerbalkens für die X-Achse.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Format des Fehlerbalkens für die Y-Achse.
1. Setzen der Balkenwerte und -formate.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}


## **Benutzerdefinierten Fehlerbalken hinzufügen**
Aspose.Slides für C++ bietet eine einfache API zur Verwaltung von benutzerdefinierten Fehlerbalkenwerten. Der Beispielcode gilt, wenn die **IErrorBarsFormat.ValueType** Eigenschaft gleich **Custom** ist. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues** Eigenschaft eines bestimmten Datenpunkts in der **DataPoints** Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Format des Fehlerbalkens für die X-Achse.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Format des Fehlerbalkens für die Y-Achse.
1. Greifen Sie auf die einzelnen Datenpunkte der Diagrammserie zu und setzen Sie die Fehlerbalkenwerte für einen einzelnen Serien-Datenpunkt.
1. Setzen der Balkenwerte und -formate.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}