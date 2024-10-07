---
title: Trendlinie
type: docs
url: /cpp/trend-line/
---

## **Trendlinie hinzufügen**
Aspose.Slides für C++ bietet eine einfache API zur Verwaltung verschiedener Diagramm-Trendlinien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalten Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten und einem gewünschten Typ hinzu (dieses Beispiel verwendet ChartType.ClusteredColumn).
1. Fügen Sie die exponentielle Trendlinie für Diagrammserie 1 hinzu.
1. Fügen Sie die lineare Trendlinie für Diagrammserie 1 hinzu.
1. Fügen Sie die logarithmische Trendlinie für Diagrammserie 2 hinzu.
1. Fügen Sie die gleitende Durchschnittstrendlinie für Diagrammserie 2 hinzu.
1. Fügen Sie die polynomialle Trendlinie für Diagrammserie 3 hinzu.
1. Fügen Sie die Potenztrendlinie für Diagrammserie 3 hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Benutzerdefinierte Linie hinzufügen**
Aspose.Slides für C++ bietet eine einfache API, um benutzerdefinierte Linien in ein Diagramm hinzuzufügen. Um eine einfache gerade Linie auf einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Presentation-Klasse.
- Erhalten Sie die Referenz auf eine Folie, indem Sie deren Index verwenden.
- Erstellen Sie ein neues Diagramm mit der AddChart-Methode, die vom Shapes-Objekt bereitgestellt wird.
- Fügen Sie eine AutoShape vom Linientyp mit der AddAutoShape-Methode hinzu, die vom Shapes-Objekt bereitgestellt wird.
- Setzen Sie die Farbe der Linien der Form.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Der folgende Code wird verwendet, um ein Diagramm mit benutzerdefinierten Linien zu erstellen.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}