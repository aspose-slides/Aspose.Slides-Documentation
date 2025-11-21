---
title: Créer une présentation PowerPoint en JavaScript
linktitle: Créer une présentation
type: docs
weight: 10
url: /fr/nodejs-java/create-presentation/
keywords: créer ppt java, créer présentation ppt, créer pptx java
description: Apprenez comment créer des présentations PowerPoint, par ex. PPT, PPTX en JavaScript à partir de zéro.
---

## **Créer une présentation PowerPoint**

Pour ajouter une simple ligne droite à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous:

1. Créez une instance de la classe Presentation.
1. Obtenez la référence d’une diapositive en utilisant son Index.
1. Ajoutez une AutoShape de type Ligne en utilisant la méthode addAutoShape exposée par l’objet Shapes.
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté une ligne à la première diapositive de la présentation.
```javascript
// Instancier un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter une autoshape de type ligne
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Quels formats puis‑je enregistrer une nouvelle présentation ?**

Vous pouvez enregistrer au format [PPTX, PPT, and ODP](/slides/fr/nodejs-java/save-presentation/), et exporter vers [PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/fr/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/fr/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/fr/nodejs-java/convert-powerpoint-to-png/), et [images](/slides/fr/nodejs-java/convert-powerpoint-to-png/), parmi d’autres.

**Puis‑je commencer à partir d’un modèle (POTX/POTM) et l’enregistrer en PPTX ordinaire ?**

Oui. Chargez le modèle et enregistrez-le au format souhaité ; les formats POTX/POTM/PPTM et similaires [are supported](/slides/fr/nodejs-java/supported-file-formats/).

**Comment contrôler la taille/ratio d’aspect d’une diapositive lors de la création d’une présentation ?**

Définissez la [slide size](/slides/fr/nodejs-java/slide-size/) (y compris les préréglages tels que 4:3 et 16:9 ou des dimensions personnalisées) et choisissez comment le contenu doit être mis à l’échelle.

**Dans quelles unités les tailles et coordonnées sont‑elles mesurées ?**

En points : 1 pouce équivaut à 72 unités.

**Comment gérer de très grandes présentations (avec de nombreux fichiers multimédias) pour réduire l’utilisation de la mémoire ?**

Utilisez les [BLOB management strategies](/slides/fr/nodejs-java/manage-blob/), limitez le stockage en mémoire en exploitant les fichiers temporaires, et privilégiez les flux de travail basés sur des fichiers plutôt que les flux purement en mémoire.

**Puis‑je créer/enregistrer des présentations en parallèle ?**

Vous ne pouvez pas opérer sur la même instance de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) depuis [multiple threads](/slides/fr/nodejs-java/multithreading/). Exécutez des instances séparées et isolées par thread ou processus.

**Comment supprimer le filigrane d’essai et les limitations ?**

[Apply a license](/slides/fr/nodejs-java/licensing/) une fois par processus. Le XML de licence doit rester inchangé, et la configuration de licence doit être synchronisée si plusieurs threads sont impliqués.

**Puis‑je signer numériquement le PPTX que je crée ?**

Oui. Les [Digital signatures](/slides/fr/nodejs-java/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

**Les macros (VBA) sont‑elles prises en charge dans les présentations créées ?**

Oui. Vous pouvez [create/edit VBA projects](/slides/fr/nodejs-java/presentation-via-vba/) et enregistrer des fichiers macro‑activés tels que PPTM/PPSM.