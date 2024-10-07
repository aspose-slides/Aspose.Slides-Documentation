---
title: Linie
type: docs
weight: 50
url: /cpp/Line/
---

## **Einfache Linie erstellen**
Um eine einfache, schlichte Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Präsentationsklasse](http://www.aspose.com/api/net/slides/aspose.slides/).
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie ein AutoShape vom Typ Linie mit der [AddAutoShape](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addautoshape/index)-Methode hinzu, die vom Shapes-Objekt bereitgestellt wird.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}


## **Pfeilförmige Linie erstellen**
Aspose.Slides für C++ ermöglicht es Entwicklern auch, einige Eigenschaften der Linie so zu konfigurieren, dass sie ansprechender aussieht. Lassen Sie uns versuchen, einige Eigenschaften einer Linie zu konfigurieren, damit sie wie ein Pfeil aussieht. Bitte befolgen Sie die folgenden Schritte, um dies zu tun:

- Erstellen Sie eine Instanz der [Präsentationsklasse](http://www.aspose.com/api/net/slides/aspose.slides/).
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie ein AutoShape vom Typ Linie mit der AddAutoShape-Methode hinzu, die vom Shapes-Objekt bereitgestellt wird.
- Setzen Sie den Linienstil auf einen der von Aspose.Slides für C++ angebotenen Stile.
- Setzen Sie die Breite der Linie.
- Setzen Sie den [Dash-Stil](http://www.aspose.com/api/net/slides/aspose.slides/linedashstyle) der Linie auf einen der von Aspose.Slides für C++ angebotenen Stile.
- Setzen Sie den [Stil des Pfeilkopfes](http://www.aspose.com/api/net/slides/aspose.slides/lineformat) und die Länge des Startpunkts der Linie.
- Setzen Sie den Stil des Pfeilkopfes und die Länge des Endpunkts der Linie.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}