---
title: Formen auf Folie neu skalieren
type: docs
weight: 110
url: /php-java/re-sizing-shapes-on-slide/
---

## **Formen auf Folie neu skalieren**
Eine der häufigsten Fragen von Kunden von Aspose.Slides für PHP über Java ist, wie man Formen neu skaliert, sodass die Daten nicht abgeschnitten werden, wenn die Foliengröße geändert wird. Dieser kurze technische Tipp zeigt, wie man das erreicht.

Um eine Desorientierung der Formen zu vermeiden, muss jede Form auf der Folie entsprechend der neuen Foliengröße aktualisiert werden.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeShape-ResizeShape.java" >}}

{{% alert color="primary" %}} 

Wenn sich eine Tabelle auf der Folie befindet, funktioniert der obige Code nicht perfekt. In diesem Fall muss jede Zelle der Tabelle neu skaliert werden.

{{% /alert %}} 

Sie müssen den folgenden Code verwenden, wenn Sie die Folien mit Tabellen neu skalieren möchten. Die Einstellung der Tabellenbreite oder -höhe ist ein Spezialfall bei Formen, bei dem Sie die individuelle Zeilenhöhe und Spaltenbreite ändern müssen, um die Tabellenhöhe und -breite zu ändern.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeSlideWithTable-ResizeSlideWithTable.java" >}}