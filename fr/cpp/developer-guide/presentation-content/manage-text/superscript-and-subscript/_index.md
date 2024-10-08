---
title: Superscript et Subscript
type: docs
weight: 80
url: /fr/cpp/superscript-and-subscript/
---

## **Gérer le texte en Super Script et Sub Script**
Vous pouvez ajouter du texte en super script et en sub script dans n'importe quelle portion de paragraphe. Pour ajouter du texte en Superscript ou Subscript dans le cadre de texte d'Aspose.Slides, il faut utiliser les propriétés **Escapement** de la classe PortionFormat.

Cette propriété renvoie ou définit le texte en superscript ou subscript (valeur de -100% (subscript) à 100% (superscript)). Par exemple :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenir la référence d'une diapositive en utilisant son index.
- Ajouter une IAutoShape de type Rectangle à la diapositive.
- Accéder à l'ITextFrame associé à l'IAutoShape.
- Effacer les Paragraphes existants.
- Créer un nouvel objet de paragraphe pour contenir le texte en super script et l'ajouter à la collection IParagraphs de l'ITextFrame.
- Créer un nouvel objet de portion.
- Définir la propriété Escapement pour la portion entre 0 et 100 pour ajouter le super script. (0 signifie pas de super script)
- Définir du texte pour la Portion et l'ajouter ensuite dans la collection de portions du paragraphe.
- Créer un nouvel objet de paragraphe pour contenir le texte en sub script et l'ajouter à la collection IParagraphs de l'ITextFrame.
- Créer un nouvel objet de portion.
- Définir la propriété Escapement pour la portion entre 0 et -100 pour ajouter le sub script. (0 signifie pas de sub script)
- Définir du texte pour la Portion et l'ajouter ensuite dans la collection de portions du paragraphe.
- Enregistrer la présentation en tant que fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}