---
title: Ellipsen zu Präsentationen in C++ hinzufügen
linktitle: Ellipse
type: docs
weight: 30
url: /de/cpp/ellipse/
keywords:
- Ellipse
- Form
- Ellipse hinzufügen
- Ellipse erstellen
- Ellipse zeichnen
- formatierte Ellipse
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Ellipsenformen in Aspose.Slides für C++ in PPT- und PPTX‑Präsentationen erstellen, formatieren und manipulieren – C++‑Codebeispiele inklusive."
---

## **Ellipse erstellen**
In diesem Thema stellen wir Entwicklern das Hinzufügen von Ellipsenformen zu ihren Folien mit Aspose.Slides für C++ vor. Aspose.Slides für C++ bietet einen einfacheren Satz von APIs, um verschiedene Arten von Formen mit nur wenigen Codezeilen zu zeichnen. Um einer ausgewählten Folie der Präsentation eine einfache Ellipse hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)
2. Holen Sie die Referenz einer Folie mittels ihres Index
3. Fügen Sie mit der AddAutoShape‑Methode des IShapes‑Objekts eine AutoShape vom Typ Ellipse hinzu
4. Schreiben Sie die geänderte Präsentation als PPTX‑Datei

Im nachfolgenden Beispiel haben wir einer ersten Folie eine Ellipse hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **Formatierte Ellipse erstellen**
Um einer Folie eine besser formatierte Ellipse hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Holen Sie die Referenz einer Folie mittels ihres Index.
3. Fügen Sie mit der AddAutoShape‑Methode des IShapes‑Objekts eine AutoShape vom Typ Ellipse hinzu.
4. Setzen Sie den Fülltyp der Ellipse auf Solid.
5. Setzen Sie die Farbe der Ellipse über die SolidFillColor.Color‑Eigenschaft, die vom FillFormat‑Objekt des zugehörigen IShape‑Objekts bereitgestellt wird.
6. Setzen Sie die Farbe der Linien der Ellipse.
7. Setzen Sie die Breite der Linien der Ellipse.
8. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir der ersten Folie der Präsentation eine formatierte Ellipse hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **FAQ**

**Wie lege ich die genaue Position und Größe einer Ellipse in Bezug auf die Einheiten der Folie fest?**

Koordinaten und Größen werden normalerweise **in Punkten** angegeben. Für vorhersehbare Ergebnisse sollten Sie Ihre Berechnungen auf der Foliengröße basieren und erforderliche Millimeter oder Zoll vor der Zuweisung in Punkte umrechnen.

**Wie kann ich eine Ellipse über oder unter anderen Objekten platzieren (Stapelhöhe steuern)?**

Passen Sie die Zeichenreihenfolge des Objekts an, indem Sie es nach vorne oder nach hinten bringen. Dadurch kann die Ellipse andere Objekte überlagern oder die darunter liegenden sichtbar machen.

**Wie animiere ich das Erscheinen oder die Hervorhebung einer Ellipse?**

[Anwenden](/slides/de/cpp/shape-animation/) Eingangs-, Hervorhebungs‑ oder Ausgangseffekte auf die Form anwenden und Trigger sowie Timing konfigurieren, um zu steuern, wann und wie die Animation abgespielt wird.