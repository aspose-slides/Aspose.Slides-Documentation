---
title: Copier un Paragraphe et une Portion dans PPTX
type: docs
weight: 70
url: /fr/php-java/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

Afin de formater le texte de la présentation, nous devons le formater au niveau du **Paragraphe** et de la **Portion**. Il existe certaines propriétés de texte qui peuvent être définies au niveau du Paragraphe et d'autres qui sont définies au niveau de la Portion. S'il y a un paragraphe ou une portion dans le texte que nous devons copier dans de nouveaux paragraphes ou portions ajoutés, nous devons copier toutes les propriétés du paragraphe ou de la portion respectif dans le nouveau paragraphe ou la nouvelle portion ajoutée.

{{% /alert %}} 
## **Copier un Paragraphe**
Les propriétés du **Paragraphe** peuvent être accessibles dans l'instance **ParagraphFormat** de la classe **Pargraph**. Nous devons copier toutes les propriétés du paragraphe source vers le paragraphe cible. Dans l'exemple suivant, la méthode **CopyParagraph** est partagée, qui prend le paragraphe à copier comme argument. Elle copie toutes les propriétés du paragraphe source dans un paragraphe temporaire et retourne ce dernier. Le paragraphe cible reçoit les valeurs copiées.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyParagraph-CopyParagraph.java" >}}


## **Copier une Portion**
Les propriétés de la **Portion** peuvent être accessibles dans l'instance **PortionFormat** de la classe **Portion**. Nous devons copier toutes les propriétés de la portion source vers la portion cible. Dans l'exemple suivant, la méthode **CopyPortion** est partagée, qui prend la portion à copier comme argument. Elle copie toutes les propriétés de la portion source dans une portion temporaire et retourne ce dernier. La portion cible reçoit les valeurs copiées.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-CopyPortion-CopyPortion.java" >}}