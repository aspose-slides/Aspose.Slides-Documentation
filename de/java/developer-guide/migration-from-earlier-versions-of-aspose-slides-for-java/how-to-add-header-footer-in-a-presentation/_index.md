---
title: Wie man in Java Kopf‑ und Fußzeilen zu Präsentationen hinzufügt
linktitle: Kopf‑ und Fußzeile hinzufügen
type: docs
weight: 20
url: /de/java/how-to-add-header-footer-in-a-presentation/
keywords:
- Migration
- Kopfzeile hinzufügen
- Fußzeile hinzufügen
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie in Java Kopf‑ und Fußzeilen in PowerPoint‑PPT-, PPTX‑ und ODP‑Präsentationen mit sowohl den Legacy‑ als auch den modernen Aspose.Slides‑APIs hinzufügen."
---
{{% alert color="info" %}} 

Eine neue [Aspose.Slides for Java API](https://docs.aspose.com/slides/de/java/) wurde veröffentlicht und unterstützt nun die Möglichkeit, PowerPoint‑Dokumente von Grund auf zu erzeugen und vorhandene zu bearbeiten.

{{% /alert %}} 
## **Unterstützung für Legacy‑Code**
Um den mit älteren Aspose.Slides for Java‑Versionen vor 13.x entwickelten Legacy‑Code zu verwenden, müssen Sie einige kleine Änderungen an Ihrem Code vornehmen, damit dieser wie zuvor funktioniert. Alle Klassen, die im alten Aspose.Slides for Java unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, sind jetzt im einzigen Namespace Aspose.Slides zusammengeführt. Bitte sehen Sie sich das folgende einfache Code‑Snippet zum Hinzufügen von Kopf‑ und Fußzeile in einer Präsentation im Legacy‑Aspose.Slides‑API an und folgen Sie den Schritten, die beschreiben, wie Sie zur neuen zusammengeführten API migrieren.
## **Legacy Aspose.Slides for Java Ansatz**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTXFooter-SetPPTXFooter.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTFooter-SetPPTFooter.java" >}}
## **Neuer Aspose.Slides for Java 13.x Ansatz**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPresentationFooter-SetPresentationFooter.java" >}}