---
title: Kopieren von Absatz und Teil in PPTX
type: docs
weight: 80
url: /net/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

Um den Präsentationstext zu formatieren, müssen wir das auf **Absatz**- und **Teil**-Ebene formatieren. Es gibt einige Text-Eigenschaften, die auf Absatz-Ebene gesetzt werden können, und einige, die auf Teil-Ebene gesetzt werden. Wenn es einen Absatz oder Teil im Text gibt, den wir in neu hinzugefügte Absätze oder Teile kopieren müssen, müssen wir alle Eigenschaften des jeweiligen Absatzes oder Teils in den neu hinzugefügten Absatz oder Teil kopieren.

{{% /alert %}} 
## **Einen Absatz kopieren**
Die Eigenschaften des **Absatzes** können in der **ParagraphFormat**-Instanz der **Paragraph**-Klasse zugegriffen werden. Wir müssen alle Eigenschaften des Quellabsatzes in den Zielabsatz kopieren. Im folgenden Beispiel wird die **CopyParagraph**-Methode bereitgestellt, die den zu kopierenden Absatz als Argument entgegennimmt. Sie kopiert alle Eigenschaften des Quellabsatzes in einen temporären Absatz und gibt denselben zurück. Der Zielabsatz erhält die kopierten Werte.



## **Einen Teil kopieren**
Die Eigenschaften des **Teils** können in der **PortionFormat**-Instanz der **Portion**-Klasse zugegriffen werden. Wir müssen alle Eigenschaften des Quellteils in den Zielteil kopieren. Im folgenden Beispiel wird die **CopyPortion**-Methode bereitgestellt, die den zu kopierenden Teil als Argument entgegennimmt. Sie kopiert alle Eigenschaften des Quellteils in einen temporären Teil und gibt denselben zurück. Der Zielteil erhält die kopierten Werte.