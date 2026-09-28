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
description: "Créer des présentations en Java avec Aspose.Slides pour Android—produire des fichiers PPT, PPTX et ODP, bénéficier de la prise en charge d'OpenDocument et les enregistrer programmatiquement pour des résultats fiables."
---
## **Vue d'ensemble**

Cet article montre comment créer une présentation avec Aspose.Slides for Android via Java, ajouter une zone de texte à la première diapositive et enregistrer le résultat sous forme de fichier dans le stockage de votre application. Pour ouvrir une présentation existante ou l’enregistrer dans un autre format, voir [Ouvrir une présentation](/slides/fr/androidjava/open-presentation/) et [Enregistrer une présentation](/slides/fr/androidjava/save-presentation/). Une courte FAQ à la fin répond aux questions courantes sur les formats, les modèles, la taille des diapositives, les unités, l’utilisation de la mémoire, le multithreading, la licence, les signatures numériques et la prise en charge de VBA.

Avant de commencer, ajoutez Aspose.Slides à votre projet Android depuis le référentiel Maven d’Aspose. Voir [Installation](/slides/fr/androidjava/install-aspose-slides-for-android-via-java/).

## **Créer une présentation PowerPoint**

Pour créer une présentation et placer une zone de texte sur sa première diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Une nouvelle présentation contient déjà une diapositive vide.  
2. Récupérez cette diapositive à partir de la [collection de diapositives](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) par son indice 0.  
3. Ajoutez un rectangle avec la méthode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) de la [collection de formes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) et définissez le texte de son [cadre de texte](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) avec la méthode [setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-).  
4. Enregistrez la présentation en tant que fichier PPTX avec la méthode [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) au format [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/).

Le code s’exécute à l’intérieur d’une `Activity`, par exemple dans sa méthode `onCreate`. Il enregistre le fichier dans le répertoire retourné par la méthode [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()), le stockage privé de votre application, auquel il peut écrire sans demander d’autorisation.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le coin supérieur gauche du rectangle se trouve à 50 points du bord gauche et à 50 points du bord supérieur de la diapositive, et le rectangle mesure 400 points de large sur 100 points de haut. Le fichier enregistré contient une diapositive avec ce rectangle et son texte. Sans licence, Aspose.Slides ajoute également un filigrane d’évaluation à chaque diapositive enregistrée ; voir [Licence](/slides/fr/androidjava/licensing/).

Pour examiner le fichier, ouvrez l’[Explorateur d’appareils](/slides/fr/androidjava/device-explorer/) d’Android Studio et trouvez *hello.pptx* sous *data/data/*, dans le dossier *files* de votre application. Dans une application réelle, traitez les présentations sur un thread d’arrière‑plan afin que l’interface utilisateur reste réactive.

## **FAQ**

### Quels formats puis‑je enregistrer pour une nouvelle présentation ?

Vous pouvez enregistrer au format [PPTX, PPT, and ODP](/slides/fr/androidjava/save-presentation/), et exporter au format [PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/fr/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/fr/androidjava/convert-powerpoint-to-html/), [SVG](/slides/fr/androidjava/render-a-slide-as-an-svg-image/), et [images](/slides/fr/androidjava/convert-powerpoint-to-png/), entre autres.

### Puis‑je démarrer à partir d’un modèle (POTX/POTM) et l’enregistrer comme un PPTX standard ?

Oui. Chargez le modèle et enregistrez-le dans le format souhaité ; les formats POTX/POTM/PPTM et similaires [sont pris en charge](/slides/fr/androidjava/supported-file-formats/).

### Comment contrôler la taille/le rapport d’aspect des diapositives lors de la création d’une présentation ?

Définissez la [taille des diapositives](/slides/fr/androidjava/slide-size/) (y compris les préréglages comme 4 : 3 et 16 : 9 ou des dimensions personnalisées) et choisissez comment le contenu doit être redimensionné.

### Dans quelles unités les tailles et coordonnées sont‑elles mesurées ?

En points : 1 pouce équivaut à 72 unités.

### Comment gérer des présentations très volumineuses (avec de nombreux fichiers multimédias) pour réduire l’utilisation de la mémoire ?

Utilisez les [stratégies de gestion des BLOB](/slides/fr/androidjava/manage-blob/), limitez le stockage en mémoire en utilisant des fichiers temporaires, et privilégiez les flux de travail basés sur des fichiers plutôt que les flux purement en mémoire.

### Puis‑je créer/enregistrer des présentations en parallèle ?

Il n’est pas possible d’opérer sur la même instance de [Presentation](/slides/fr/androidjava/multithreading/) depuis [plusieurs threads](/slides/fr/androidjava/multithreading/). Exécutez des instances séparées et isolées par thread ou processus.

### Comment supprimer le filigrane d’évaluation et les limitations ?

[Appliquer une licence](/slides/fr/androidjava/licensing/) une fois par processus. Le fichier XML de licence doit rester inchangé, et la configuration de la licence doit être synchronisée si plusieurs threads sont impliqués.

### Puis‑je signer numériquement le PPTX que je crée ?

Oui. Les [signatures numériques](/slides/fr/androidjava/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

### Les macros (VBA) sont‑elles prises en charge dans les présentations créées ?

Oui. Vous pouvez [créer/modifier des projets VBA](/slides/fr/androidjava/presentation-via-vba/) et enregistrer des fichiers macro‑activés tels que PPTM/PPSM.