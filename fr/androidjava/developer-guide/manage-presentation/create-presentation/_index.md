---
title: Créer des présentations sur Android
linktitle: Créer une présentation
type: docs
weight: 10
url: /fr/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Créez des présentations en Java avec Aspose.Slides pour Android — produisez des fichiers PPT, PPTX et ODP, bénéficiez de la prise en charge d'OpenDocument et enregistrez-les programmatiquement pour des résultats fiables."
---

## **Créer une présentation PowerPoint**
Pour ajouter une simple ligne droite à une diapositive sélectionnée de la présentation, suivez les étapes ci-dessous :

1. Créez une instance de la classe Presentation.
2. Obtenez la référence d’une diapositive en utilisant son indice.
3. Ajoutez une AutoShape de type Ligne en utilisant la méthode addAutoShape exposée par l’objet Shapes.
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté une ligne à la première diapositive de la présentation.
```java
// Instanciez un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation();
try {
    // Obtenez la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajoutez une forme auto de type ligne
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Quels formats puis‑je enregistrer une nouvelle présentation ?**

Vous pouvez enregistrer au format [PPTX, PPT et ODP](/slides/fr/androidjava/save-presentation/), et exporter vers [PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/fr/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/fr/androidjava/convert-powerpoint-to-html/), [SVG](/slides/fr/androidjava/convert-powerpoint-to-png/), et [images](/slides/fr/androidjava/convert-powerpoint-to-png/), entre autres.

**Puis‑je partir d’un modèle (POTX/POTM) et l’enregistrer comme un PPTX standard ?**

Oui. Chargez le modèle et enregistrez‑le dans le format souhaité ; les formats POTX/POTM/PPTM et similaires [sont pris en charge](/slides/fr/androidjava/supported-file-formats/).

**Comment contrôler la taille/rapport d’aspect des diapositives lors de la création d’une présentation ?**

Définissez la [taille des diapositives](/slides/fr/androidjava/slide-size/) (y compris les préréglages tels que 4:3 et 16:9 ou des dimensions personnalisées) et choisissez comment le contenu doit être mis à l’échelle.

**Dans quelles unités les tailles et coordonnées sont‑elles mesurées ?**

En points : 1 pouce équivaut à 72 unités.

**Comment gérer des présentations très volumineuses (avec de nombreux fichiers multimédias) pour réduire la consommation de mémoire ?**

Utilisez les [stratégies de gestion des BLOB](/slides/fr/androidjava/manage-blob/), limitez le stockage en mémoire en utilisant des fichiers temporaires, et privilégiez les flux de travail basés sur des fichiers plutôt que des flux purement en mémoire.

**Puis‑je créer/enregistrer des présentations en parallèle ?**

Vous ne pouvez pas manipuler la même instance de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/androidjava/multithreading/). Exécutez des instances séparées et isolées par thread ou processus.

**Comment supprimer le filigrane d’évaluation et les limitations ?**

[Appliquez une licence](/slides/fr/androidjava/licensing/) une fois par processus. Le XML de licence doit rester inchangé, et la configuration de licence doit être synchronisée si plusieurs threads sont impliqués.

**Puis‑je signer numériquement le PPTX que je crée ?**

Oui. Les [signatures numériques](/slides/fr/androidjava/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

**Les macros (VBA) sont‑elles prises en charge dans les présentations créées ?**

Oui. Vous pouvez [créer/modifier des projets VBA](/slides/fr/androidjava/presentation-via-vba/) et enregistrer des fichiers activés par macro tels que PPTM/PPSM.