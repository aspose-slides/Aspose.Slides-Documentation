---
title: Rechteck
type: docs
weight: 80
url: /cpp/rectangle/
---


## **Einfaches Rechteck erstellen**
Wie in den vorherigen Themen geht es auch hier darum, eine Form hinzuzufügen, und dieses Mal ist die Form, über die wir sprechen werden, das Rechteck. In diesem Thema haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke in ihre Folien mit Aspose.Slides für C++ hinzufügen können. Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation-Klasse](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie eine IAutoShape vom Typ Rechteck mit der AddAutoShape-Methode hinzu, die vom IShapes-Objekt bereitgestellt wird.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Formatiertes Rechteck erstellen**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation-Klasse](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie eine IAutoShape vom Typ Rechteck mit der AddAutoShape-Methode hinzu, die vom IShapes-Objekt bereitgestellt wird.
1. Setzen Sie den Fülltyp des Rechtecks auf Solid.
1. Setzen Sie die Farbe des Rechtecks mithilfe der SolidFillColor.Color-Eigenschaft, wie sie vom FillFormat-Objekt bereitgestellt wird, das mit dem IShape-Objekt verknüpft ist.
1. Setzen Sie die Farbe der Linien des Rechtecks.
1. Setzen Sie die Breite der Linien des Rechtecks.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.
   Die obigen Schritte sind im folgenden Beispiel umgesetzt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}