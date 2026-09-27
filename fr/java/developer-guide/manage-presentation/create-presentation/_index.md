---
title: Créer des présentations en Java
linktitle: Créer une présentation
type: docs
weight: 10
url: /fr/java/create-presentation/
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
- Java
- Aspose.Slides
description: "Créez des présentations en Java avec Aspose.Slides - créez des fichiers PPT, PPTX et ODP, profitez de la prise en charge d'OpenDocument et enregistrez-les programmatiquement pour des résultats fiables."
---
## **Vue d'ensemble**

Cet article montre comment créer une présentation dans Aspose.Slides, ajouter une forme avec du texte à sa première diapositive et enregistrer le résultat sous forme de fichier PPTX. Pour ouvrir une présentation existante et l'enregistrer dans un autre format, voir [Open Presentations](/slides/fr/java/open-presentation/) et [Save Presentations](/slides/fr/java/save-presentation/). Une courte FAQ à la fin couvre les questions courantes concernant les formats, les modèles, la taille des diapositives, les unités, la consommation de mémoire, le multithreading, la licence, les signatures numériques et la prise en charge VBA.

Avant de commencer, ajoutez Aspose.Slides for Java à votre projet depuis le référentiel Maven d'Aspose. Consultez [Installation](/slides/fr/java/installation/) pour la configuration Maven et pour ce dont Linux a besoin en plus.

## **Créer une présentation**

Créer un fichier PowerPoint à partir de zéro dans Aspose.Slides for Java commence par une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/). Le constructeur fournit une présentation vierge avec une seule diapositive, prête pour des formes, du texte, des graphiques ou tout autre contenu dont votre application a besoin. Une fois que vous avez modifié cette diapositive ou ajouté de nouvelles, vous pouvez enregistrer le résultat aux formats PPTX, PPT legacy ou OpenDocument.

Pour créer une présentation et placer une forme avec du texte sur sa première diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/). Une nouvelle présentation contient déjà une diapositive vide.  
2. Récupérez cette diapositive par son index 0, à partir de la collection renvoyée par [getSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getSlides--).  
3. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) de type `Cloud` à l'aide de la méthode [addAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-), et définissez son texte avec [setText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#setText-java.lang.String-).  
4. Enregistrez la présentation au format PPTX avec la méthode [save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-java.lang.String-int-).

L'exemple ci‑dessous est un programme complet. Dans le projet Maven provenant de [Installation](/slides/fr/java/installation/), enregistrez‑le sous *src/main/java/HelloSlides.java* et exécutez `mvn compile exec:java`.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Créer une présentation. Elle contient déjà une diapositive vide.
        Presentation presentation = new Presentation();
        try {
            // Obtenir la première diapositive.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Ajouter une forme nuage et y mettre du texte.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Enregistrer la présentation au format PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Le coin supérieur gauche du nuage se trouve à 20 points du bord gauche et à 20 points du bord supérieur de la diapositive, et la forme mesure 200 points de largeur sur 80 points de hauteur. Le programme enregistre *new_presentation.pptx* avec une diapositive contenant le nuage et son texte. Sans licence, Aspose.Slides ajoute également un filigrane d'évaluation à chaque diapositive enregistrée ; voir [Licensing](/slides/fr/java/licensing/).

Le résultat :

![La nouvelle présentation](new_presentation.png)

## **FAQ**

### Quels formats puis‑je enregistrer une nouvelle présentation ?

Vous pouvez enregistrer au format [PPTX, PPT et ODP](/slides/fr/java/save-presentation/), et exporter vers [PDF](/slides/fr/java/convert-powerpoint-to-pdf/), [XPS](/slides/fr/java/convert-powerpoint-to-xps/), [HTML](/slides/fr/java/convert-powerpoint-to-html/), [SVG](/slides/fr/java/render-a-slide-as-an-svg-image/) et [images](/slides/fr/java/convert-powerpoint-to-png/), entre autres.

### Puis‑je partir d'un modèle (POTX/POTM) et enregistrer en PPTX standard ?

Oui. Chargez le modèle et enregistrez‑le dans le format souhaité ; les formats POTX/POTM/PPTM et similaires [sont pris en charge](/slides/fr/java/supported-file-formats/).

### Comment contrôler la taille/le rapport d'aspect des diapositives lors de la création d'une présentation ?

Définissez la [taille des diapositives](/slides/fr/java/slide-size/) (y compris les préréglages comme 4:3 et 16:9 ou des dimensions personnalisées) et choisissez comment le contenu doit être mis à l’échelle.

### En quelles unités les tailles et coordonnées sont‑elles mesurées ?

En points : 1 pouce équivaut à 72 unités.

### Comment gérer des présentations très volumineuses (avec de nombreux fichiers multimédias) pour réduire l'utilisation de la mémoire ?

Utilisez les [stratégies de gestion des BLOB](/slides/fr/java/manage-blob/), limitez le stockage en mémoire en exploitant des fichiers temporaires, et privilégiez les flux de travail basés sur des fichiers plutôt que les flux purement en mémoire.

### Puis‑je créer/enregistrer des présentations en parallèle ?

Vous ne pouvez pas exploiter la même instance de [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/java/multithreading/). Exécutez des instances distinctes et isolées par thread ou processus.

### Comment supprimer le filigrane d'évaluation et les limitations ?

[Appliquez une licence](/slides/fr/java/licensing/) une fois par processus. Le XML de licence doit rester inchangé, et la configuration de la licence doit être synchronisée si plusieurs threads sont impliqués.

### Puis‑je signer numériquement le PPTX que je crée ?

Oui. Les [signatures numériques](/slides/fr/java/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

### Les macros (VBA) sont‑elles prises en charge dans les présentations créées ?

Oui. Vous pouvez [créer/modifier des projets VBA](/slides/fr/java/presentation-via-vba/) et enregistrer des fichiers avec macros tels que PPTM/PPSM.