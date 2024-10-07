---
title: Ellipse
type: docs
weight: 30
url: /cpp/ellipse/
---


## **Ellipse erstellen**
In diesem Thema werden wir Entwicklern vorstellen, wie man Ellipsenformen zu ihren Folien mit Aspose.Slides für C++ hinzufügt. Aspose.Slides für C++ bietet eine einfachere API-Schnittstelle, um verschiedene Arten von Formen mit nur wenigen Codezeilen zu zeichnen. Um eine einfache Ellipse zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation-Klasse](http://www.aspose.com/api/net/slides/aspose.slides/)
1. Erhalten Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Fügen Sie eine AutoShape vom Typ Ellipse mit der Methode AddAutoShape hinzu, die vom Objekt IShapes bereitgestellt wird.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Ellipse zur ersten Folie hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}


## **Formattierte Ellipse erstellen**
Um eine besser formatierte Ellipse zu einer Folie hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation-Klasse](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Erhalten Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Fügen Sie eine AutoShape vom Typ Ellipse mit der Methode AddAutoShape hinzu, die vom Objekt IShapes bereitgestellt wird.
1. Setzen Sie den Fülltyp der Ellipse auf Solid.
1. Setzen Sie die Farbe der Ellipse mit der Eigenschaft SolidFillColor.Color, die vom FillFormat-Objekt bereitgestellt wird, das mit dem IShape-Objekt assoziiert ist.
1. Setzen Sie die Farbe der Linien der Ellipse.
1. Setzen Sie die Breite der Linien der Ellipse.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine formatierte Ellipse zur ersten Folie der Präsentation hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}