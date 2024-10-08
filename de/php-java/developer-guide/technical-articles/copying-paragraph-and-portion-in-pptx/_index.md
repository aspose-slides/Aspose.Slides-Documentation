---
title: Kopieren von Absatz und Teil in PPTX
type: docs
weight: 70
url: /de/php-java/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

Um Text in einer Präsentation zu formatieren, müssen wir dies auf **Absatz**- und **Teil**-Ebene tun. Es gibt einige Text Eigenschaften, die auf Absatz-Ebene festgelegt werden können, und einige werden auf Teil-Ebene festgelegt. Wenn es einen Absatz oder Teil im Text gibt, den wir in neu hinzugefügte Absätze oder Teile kopieren müssen, müssen wir alle Eigenschaften des jeweiligen Absatzes oder Teils in den neu hinzugefügten Absatz oder Teil kopieren.

{{% /alert %}} 
## **Einen Absatz kopieren**
Die Eigenschaften des **Absatzes** können über die **ParagraphFormat**-Instanz der **Paragraph**-Klasse zugegriffen werden. Wir müssen alle Eigenschaften des Quellabsatzes in den Zielabsatz kopieren. Im folgenden Beispiel wird die Methode **CopyParagraph** geteilt, die den zu kopierenden Absatz als Argument nimmt. Sie kopiert alle Eigenschaften des Quellabsatzes in einen temporären Absatz und gibt diesen zurück. Der Zielabsatz erhält die kopierten Werte.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyParagraph-CopyParagraph.java" >}}


## **Einen Teil kopieren**
Die Eigenschaften des **Teils** können über die **PortionFormat**-Instanz der **Portion**-Klasse zugegriffen werden. Wir müssen alle Eigenschaften des Quellteils in den Zielteil kopieren. Im folgenden Beispiel wird die Methode **CopyPortion** geteilt, die den zu kopierenden Teil als Argument nimmt. Sie kopiert alle Eigenschaften des Quellteils in einen temporären Teil und gibt diesen zurück. Der Zielteil erhält die kopierten Werte.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyPortion-CopyPortion.java" >}}