---
title: Créer des présentations en JavaScript
linktitle: Créer une présentation
type: docs
weight: 10
url: /fr/nodejs-java/create-presentation/
keywords:
- créer une présentation
- nouvelle présentation
- créer PPT
- nouveau PPT
- créer PPTX
- nouveau PPTX
- créer ODP
- nouveau ODP
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer des présentations avec Aspose.Slides - produire des fichiers PPT, PPTX et ODP, profiter du support OpenDocument, et les enregistrer programmatiquement pour des résultats fiables."
---
## **Vue d'ensemble**

Cet article montre comment créer une présentation dans Aspose.Slides, ajouter une zone de texte à sa première diapositive et enregistrer le résultat dans un fichier.

Avant de commencer, installez le package `aspose.slides.via.java` depuis npm, ainsi que le JDK, Python et les outils de compilation C++ dont il a besoin. Voir [Installation](/slides/fr/nodejs-java/installation/).

## **Créer une présentation PowerPoint**

Pour créer une présentation et ajouter une zone de texte sur sa première diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/). Une nouvelle présentation contient déjà une diapositive vide.  
2. Obtenez cette diapositive à partir de la [collection de diapositives](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getslides/) par son indice, 0.  
3. Ajoutez un rectangle avec la méthode [addAutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/addautoshape/) et définissez son texte avec [setText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/settext/).  
4. Enregistrez la présentation au format PPTX avec la méthode [save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/save/).  
5. Libérez la présentation avec la méthode [dispose](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/dispose/) et terminez le processus.  

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides s'exécute dans une machine virtuelle Java qui empêche Node.js de se fermer, il faut donc terminer le processus explicitement.
process.exit(0);
```

Le coin supérieur gauche du rectangle se trouve à 50 points du bord gauche et à 50 points du bord supérieur de la diapositive, et le rectangle mesure 400 points de large et 100 points de haut. Enregistrez le code sous *hello.js* dans le dossier de votre projet et exécutez `node hello.js` : il enregistre *hello.pptx*, contenant une diapositive avec ce rectangle et son texte, dans le dossier courant.

Aspose.Slides s'exécute dans une machine virtuelle Java que le package `java` démarre à l'intérieur du processus Node.js. Cette machine virtuelle empêche Node.js de se terminer automatiquement une fois le script achevé, c'est pourquoi l'exemple se conclut par `process.exit(0)`.

Sans licence, Aspose.Slides ajoute également un filigrane d'évaluation à chaque diapositive enregistrée ; voir [Licence](/slides/fr/nodejs-java/licensing/).

## **FAQ**

### Quels formats puis‑je enregistrer pour une nouvelle présentation ?

Vous pouvez enregistrer au format [PPTX, PPT et ODP](/slides/fr/nodejs-java/save-presentation/), et exporter vers [PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/fr/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/fr/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/fr/nodejs-java/render-a-slide-as-an-svg-image/) et [images](/slides/fr/nodejs-java/convert-powerpoint-to-png/), entre autres.

### Puis‑je partir d'un modèle (POTX/POTM) et l'enregistrer en PPTX standard ?

Oui. Chargez le modèle et enregistrez‑le dans le format souhaité ; les formats POTX/POTM/PPTM et similaires [sont pris en charge](/slides/fr/nodejs-java/supported-file-formats/).

### Comment contrôler la taille/le rapport d'aspect des diapositives lors de la création d'une présentation ?

Définissez la [taille des diapositives](/slides/fr/nodejs-java/slide-size/) (y compris les préréglages tels que 4 : 3 et 16 : 9 ou des dimensions personnalisées) et choisissez la façon dont le contenu doit être mis à l'échelle.

### En quelles unités sont mesurées les tailles et les coordonnées ?

En points : 1 pouce équivaut à 72 unités.

### Comment gérer des présentations très volumineuses (avec de nombreux fichiers multimédias) afin de réduire la consommation de mémoire ?

Utilisez les [stratégies de gestion des BLOB](/slides/fr/nodejs-java/manage-blob/), limitez le stockage en mémoire en exploitant des fichiers temporaires, et privilégiez les flux basés sur des fichiers plutôt que les flux uniquement en mémoire.

### Puis‑je créer/enregistrer des présentations en parallèle ?

Vous ne pouvez pas manipuler la même instance de [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/nodejs-java/multithreading/). Exécutez des instances séparées et isolées par thread ou processus.

### Comment supprimer le filigrane d'évaluation et les limitations ?

[Appliquez une licence](/slides/fr/nodejs-java/licensing/) une fois par processus. Le fichier XML de licence doit rester inchangé, et la configuration de la licence doit être synchronisée si plusieurs threads sont impliqués.

### Puis‑je signer numériquement le PPTX que je crée ?

Oui. Les [signatures numériques](/slides/fr/nodejs-java/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

### Les macros (VBA) sont‑elles prises en charge dans les présentations créées ?

Oui. Vous pouvez [créer/modifier des projets VBA](/slides/fr/nodejs-java/presentation-via-vba/) et enregistrer des fichiers avec macros tels que PPTM/PPSM.