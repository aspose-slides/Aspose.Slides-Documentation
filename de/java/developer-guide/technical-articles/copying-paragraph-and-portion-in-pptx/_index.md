---
title: Kopieren von Absatz und Portion in PPTX
type: docs
weight: 70
url: /java/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

Um den Text einer Präsentation zu formatieren, müssen wir dies auf **Absatz**- und **Portion**-Ebene tun. Es gibt einige Textproperties, die auf Absatzebene festgelegt werden können, und einige werden auf Portionsebene festgelegt. Wenn es einen Absatz oder eine Portion im Text gibt, den/die wir in neu hinzugefügte Absätze oder Portionen kopieren müssen, müssen wir alle Eigenschaften des jeweiligen Absatzes oder der Portion in den neu hinzugefügten Absatz oder die neue Portion kopieren.

{{% /alert %}} 
## **Kopieren eines Absatzes**
Die Eigenschaften des **Absatzes** können in der **ParagraphFormat**-Instanz der **Paragraph**-Klasse zugegriffen werden. Wir müssen alle Eigenschaften des Quellabsatzes in den Zielabsatz kopieren. Im folgenden Beispiel wird die Methode **CopyParagraph** vorgestellt, die den zu kopierenden Absatz als Argument übernimmt. Sie kopiert alle Eigenschaften des Quellabsatzes in einen temporären Absatz und gibt denselben zurück. Der Zielabsatz erhält die kopierten Werte.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyParagraph-CopyParagraph.java" >}}


## **Kopieren einer Portion**
Die Eigenschaften der **Portion** können in der **PortionFormat**-Instanz der **Portion**-Klasse zugegriffen werden. Wir müssen alle Eigenschaften der Quellportion in die Zielportion kopieren. Im folgenden Beispiel wird die Methode **CopyPortion** vorgestellt, die die zu kopierende Portion als Argument übernimmt. Sie kopiert alle Eigenschaften der Quellportion in eine temporäre Portion und gibt denselben zurück. Die Zielportion erhält die kopierten Werte.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyPortion-CopyPortion.java" >}}