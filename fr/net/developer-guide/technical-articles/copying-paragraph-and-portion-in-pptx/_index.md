---  
title: Copier un Paragraphe et une Portion dans PPTX  
type: docs  
weight: 80  
url: /net/copying-paragraph-and-portion-in-pptx/  
---  

{{% alert color="primary" %}}  

Pour formater le texte de la présentation, nous devons le formater au niveau du **Paragraphe** et de la **Portion**. Il existe certaines propriétés de texte qui peuvent être définies au niveau du Paragraphe et d'autres qui sont définies au niveau de la Portion. S'il y a un paragraphe ou une portion dans le texte que nous devons copier dans de nouveaux paragraphes ou portions ajoutés, nous devons copier toutes les propriétés du paragraphe ou de la portion respectif au nouveau paragraphe ou à la nouvelle portion ajoutée.  

{{% /alert %}}  
## **Copier un Paragraphe**  
Les propriétés du **Paragraphe** peuvent être accessibles dans l'instance **ParagraphFormat** de la classe **Pargraph**. Nous devons copier toutes les propriétés du paragraphe source au paragraphe cible. Dans l'exemple suivant, la méthode **CopyParagraph** est partagée et prend le paragraphe à copier comme argument. Elle copie toutes les propriétés du paragraphe source dans un paragraphe temporaire et renvoie ce dernier. Le paragraphe cible obtient les valeurs copiées.  

## **Copier une Portion**  
Les propriétés de la **Portion** peuvent être accessibles dans l'instance **PortionFormat** de la classe **Portion**. Nous devons copier toutes les propriétés de la portion source à la portion cible. Dans l'exemple suivant, la méthode **CopyPortion** est partagée et prend la portion à copier comme argument. Elle copie toutes les propriétés de la portion source dans une portion temporaire et renvoie ce dernier. La portion cible obtient les valeurs copiées.  