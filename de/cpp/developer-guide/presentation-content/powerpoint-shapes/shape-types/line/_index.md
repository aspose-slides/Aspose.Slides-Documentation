---
title: Linienformen zu Präsentationen in C++ hinzufügen
linktitle: Linie
type: docs
weight: 50
url: /de/cpp/line/
keywords:
- Linie
- Linie erstellen
- Linie hinzufügen
- einfache Linie
- Linie konfigurieren
- Linie anpassen
- Strichstil
- Pfeilspitze
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie die Linienformatierung in PowerPoint-Präsentationen mit Aspose.Slides für C++ manipulieren. Entdecken Sie Eigenschaften, Methoden und Beispiele."
---

## **Eine einfache Linie erstellen**
Um einer ausgewählten Folie der Präsentation eine einfache gerade Linie hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

- Erzeugen Sie eine Instanz der [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie mit der vom Shapes-Objekt bereitgestellten [AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/)‑Methode ein AutoShape vom Typ Linie hinzu.
- Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Im nachfolgenden Beispiel haben wir einer ersten Folie der Präsentation eine Linie hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}


## **Eine pfeilförmige Linie erstellen**
Aspose.Slides for C++ ermöglicht es Entwicklern ebenfalls, einige Eigenschaften der Linie zu konfigurieren, damit sie ansprechender aussieht. Versuchen wir, einige Eigenschaften einer Linie so zu konfigurieren, dass sie wie ein Pfeil aussieht. Bitte folgen Sie den untenstehenden Schritten, um dies zu tun:

- Erzeugen Sie eine Instanz der [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie mit der vom Shapes-Objekt bereitgestellten AddAutoShape‑Methode ein AutoShape vom Typ Linie hinzu.
- Setzen Sie den Linienstil auf einen der von Aspose.Slides für C++ bereitgestellten Stile.
- Setzen Sie die Breite der Linie.
- Setzen Sie den [Dash Style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/)‑Stil der Linie auf einen der von Aspose.Slides für C++ bereitgestellten Stile.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/cpp/aspose.slides/lineformat/)‑Stil und die Länge des Startpunkts der Linie.
- Setzen Sie den Pfeilspitzenstil und die Länge des Endpunkts der Linie.
- Schreiben Sie die geänderte Präsentation als PPTX-Datei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **FAQ**

**Kann ich eine normale Linie in einen Connector umwandeln, damit sie an Formen "schnappt"?**

Nein. Eine normale Linie (ein [AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/)) wird nicht automatisch zu einem Connector. Um sie an Formen schnappen zu lassen, verwenden Sie den dedizierten [Connector](https://reference.aspose.com/slides/cpp/aspose.slides/connector/)‑Typ und die [corresponding APIs](/slides/de/cpp/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Theme geerbt werden und es schwer ist, die endgültigen Werte zu bestimmen?**

[Lesen Sie die effektiven Eigenschaften](/slides/de/cpp/shape-effective-properties/) über die Schnittstellen [ILineFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformateffectivedata/) – diese berücksichtigen bereits Vererbung und Theme‑Stile.

**Kann ich eine Linie gegen Bearbeitung (Verschieben, Größ ändern) sperren?**

Ja. Shapes stellen [lock objects](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/get_autoshapelock/) bereit, mit denen Sie [disallow editing operations](/slides/de/cpp/applying-protection-to-presentation/) verhindern.