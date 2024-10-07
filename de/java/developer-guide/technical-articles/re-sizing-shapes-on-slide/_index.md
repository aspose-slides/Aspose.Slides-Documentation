---
title: Anpassung von Formen auf Folien
type: docs
weight: 110
url: /java/re-sizing-shapes-on-slide/
---

## **Anpassung von Formen auf Folien**
Eine der häufigsten Fragen, die von den Kunden von Aspose.Slides für Java gestellt werden, ist, wie man Formen anpassen kann, damit beim Ändern der Foliengröße die Daten nicht abgeschnitten werden. Dieser kurze technische Hinweis zeigt, wie man das erreicht.

Um eine Desorientierung der Formen zu vermeiden, muss jede Form auf der Folie entsprechend der neuen Foliengröße aktualisiert werden.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeShape-ResizeShape.java" >}}

{{% alert color="primary" %}} 

Wenn sich eine Tabelle auf der Folie befindet, funktioniert der obige Code nicht perfekt. In diesem Fall muss jede Zelle der Tabelle angepasst werden.

{{% /alert %}} 

Sie müssen den folgenden Code auf Ihrer Seite verwenden, wenn Sie Folien mit Tabellen anpassen möchten. Das Festlegen der Tabellenbreite oder -höhe ist ein Spezialfall bei Formen, bei dem Sie die individuelle Zeilenhöhe und -breite ändern müssen, um die Höhe und Breite der Tabelle anzupassen.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeSlideWithTable-ResizeSlideWithTable.java" >}}