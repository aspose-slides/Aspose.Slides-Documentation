---
title: Évaluer Aspose.Slides
type: docs
weight: 120
url: /fr/nodejs-net/evaluate-aspose-slides/
keywords:
- évaluer Aspose.Slides
- version d'évaluation
- filigrane d'évaluation
- limitations de la version d'essai
- licence temporaire
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Ce que la version d'évaluation d'Aspose.Slides pour Node.js via .NET limite, avec un script qui montre les deux limitations et comment les supprimer avec une licence."
---
## **Vue d'ensemble**

La version d'évaluation d'Aspose.Slides pour Node.js via .NET est le même package npm que la version sous licence. Sans licence, elle fonctionne en mode d'évaluation : toutes les fonctionnalités fonctionnent, mais les présentations enregistrées et la plupart des exportations portent un filigrane, et le texte que votre code relit est tronqué. Cet article décrit les deux limitations et montre comment les supprimer.

## **Limitations d'évaluation**

**Un filigrane d'évaluation sur chaque diapositive.**  
Lorsque vous enregistrez une présentation sans licence, Aspose.Slides ajoute une zone de texte au milieu de chaque diapositive du fichier enregistré. La zone de texte est verrouillée et indique "Evaluation only." suivi d'une ligne de produit et d'une ligne de droits d'auteur. Le filigrane est intégré au fichier enregistré, pas à la présentation en mémoire, et l'ouverture d'une présentation n'en ajoute pas. Cependant, un fichier enregistré en mode d'évaluation contient déjà la zone de texte, de sorte qu'ouvrir et l'enregistrer à nouveau ajoute un deuxième filigrane à chaque diapositive.

Le même filigrane est ajouté à la sortie lorsque vous exportez en PDF, XPS ou HTML, ou que vous rendez les diapositives sous forme d'images. Si vous rendez une présentation déjà enregistrée en mode d'évaluation, l'image montre à la fois le filigrane enregistré et celui rendu.

**Texte tronqué lorsque votre code le lit.**  
Le texte que votre code lit via la propriété `text` d'un cadre de texte, d'un paragraphe ou d'une portion est limité aux cinq premiers caractères, suivi de la mention "... text has been truncated due to evaluation version limitation." Le texte de cinq caractères ou moins est renvoyé intégralement. Cela s'applique à chaque diapositive, même au texte que votre code vient d'assigner. Les exportations Markdown et HTML5 sont tronquées de la même manière.

Le texte que votre code écrit est enregistré en totalité : les fichiers PPTX, les pages PDF et les images de diapositives contiennent le texte complet.

## **Voir les limitations dans un script**

Le script suivant montre les deux limitations. Il suppose que vous avez installé le package comme décrit dans [Installation](/slides/fr/nodejs-net/installation/) et que vous l'exécutez depuis le dossier du projet. Il ajoute un rectangle contenant une phrase à la première diapositive, lit la phrase, enregistre la présentation sous `evaluation.pptx`, puis rouvre le fichier pour compter les formes sur la diapositive.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // Sans licence, seuls les cinq premiers caractères sont renvoyés.
    console.log("Text read back:", rectangle.textFrame.text);

    // L'enregistrement ajoute le filigrane d'évaluation à chaque diapositive du fichier.
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // La diapositive contient désormais le rectangle et la zone de texte du filigrane.
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

Sans licence, le script affiche :

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

La deuxième forme est la zone de texte du filigrane. Ouvrez `evaluation.pptx` pour voir la phrase complète dans le rectangle et le filigrane au centre de la diapositive.

## **Supprimer les limitations**

Pour supprimer les deux limitations, appliquez une licence avant de créer tout objet `Presentation`. [Licensing](/slides/fr/nodejs-net/licensing/) montre comment appliquer un fichier de licence.

{{% alert color="success" title="Tip" %}}
Pour tester Aspose.Slides sans les limitations d'évaluation avant d'acheter, demandez une **licence temporaire de 30 jours** gratuite. Voir [Comment obtenir une licence temporaire?](https://purchase.aspose.com/temporary-license) pour plus de détails.
{{% /alert %}}

## **FAQ**

**Le mode d'évaluation limite-t-il le nombre de diapositives ?**  
Non. Les présentations sont créées, ouvertes et enregistrées avec toutes leurs diapositives. Le filigrane et la troncation du texte s'appliquent de la même façon à chaque diapositive.

**Pourquoi mes images de diapositives exportées affichent-elles le filigrane deux fois ?**  
La présentation a été enregistrée en mode d'évaluation avant que vous ne la rendiez, elle contient donc déjà une zone de texte de filigrane, et le rendu sans licence dessine une autre zone au-dessus.

**Puis-je vérifier que mon code produit le texte correct en mode d'évaluation ?**  
Oui. Ouvrez le fichier enregistré ou le PDF exporté : ils contiennent le texte complet. Seuls le texte que votre code relit, ainsi que la sortie Markdown ou HTML5, sont tronqués.