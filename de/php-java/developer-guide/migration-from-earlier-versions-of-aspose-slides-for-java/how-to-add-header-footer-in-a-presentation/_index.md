---
title: So fügen Sie Header und Footer in eine Präsentation ein
type: docs
weight: 20
url: /php-java/how-to-add-header-footer-in-a-presentation/
---

{{% alert color="primary" %}} 

Eine neue [Aspose.Slides for PHP via Java API](https://docs.aspose.com/slides/php-java/) wurde veröffentlicht und jetzt unterstützt dieses Einzelprodukt die Fähigkeit, PowerPoint-Dokumente von Grund auf zu erstellen und bestehende zu bearbeiten.

{{% /alert %}} 
## **Unterstützung für Legacy-Code**
Um den Legacy-Code, der mit Aspose.Slides for PHP via Java-Versionen älter als 13.x entwickelt wurde, zu verwenden, müssen Sie einige kleine Änderungen an Ihrem Code vornehmen, und der Code wird wie früher funktionieren. Alle Klassen, die in der alten Aspose.Slides for PHP via Java unter den Namespaces Aspose.Slide und Aspose.Slides.Pptx vorhanden waren, sind jetzt in den einzelnen Namespace Aspose.Slides zusammengeführt. Bitte sehen Sie sich den folgenden einfachen Codeausschnitt zum Hinzufügen von Header und Footer in eine Präsentation in der Legacy Aspose.Slides API an und folgen Sie den Schritten, die beschreiben, wie man zur neuen zusammengeführten API migriert.
## **Legacy Aspose.Slides for PHP via Java-Ansatz**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTXFooter-SetPPTXFooter.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTFooter-SetPPTFooter.java" >}}
## **Neuer Aspose.Slides for PHP via Java 13.x-Ansatz**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPresentationFooter-SetPresentationFooter.java" >}}