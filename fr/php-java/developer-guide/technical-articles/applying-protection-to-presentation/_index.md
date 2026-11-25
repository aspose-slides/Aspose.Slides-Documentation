---
title: Restreindre les modifications de présentation avec des verrous de forme en PHP
linktitle: Restreindre les modifications de présentation
type: docs
weight: 60
url: /fr/php-java/applying-protection-to-presentation/
keywords:
- empêcher les modifications
- protéger contre la modification
- verrouiller la forme
- verrouiller la position
- verrouiller la sélection
- verrouiller le redimensionnement
- verrouiller le groupement
- PowerPoint
- PPTX
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à verrouiller et déverrouiller les formes dans les présentations PPTX avec Aspose.Slides pour PHP via Java afin de restreindre la sélection, le déplacement, le redimensionnement et le groupement."
---
## **Vue d'ensemble**

Une utilisation courante d'Aspose.Slides pour PHP via Java consiste à créer, mettre à jour et enregistrer des présentations PowerPoint (PPTX) dans le cadre d’un flux de travail automatisé. Lorsque les utilisateurs reçoivent ces présentations, restreindre les modifications des formes peut aider à préserver la mise en page et le contenu prévus.

Cet article explique comment les formes sont organisées sur les diapositives et comment appliquer et supprimer les verrous de forme dans une présentation PPTX. Ces verrous vous permettent de restreindre des opérations d’édition spécifiques sur des formes individuelles.

## **Composition d'une diapositive**

Une diapositive de présentation est composée d’éléments tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d’image, des cadres vidéo, des connecteurs et d’autres éléments utilisés pour construire une présentation. Dans Aspose.Slides pour PHP via Java, chaque élément d’une diapositive est représenté par un objet qui hérite de la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).

Différents types de forme exposent différentes options de verrouillage. La classe [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) est la classe de base pour les verrous de forme. Aspose.Slides pour PHP via Java fournit les classes de verrouillage suivantes :

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) verrouille les formes automatiques.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) verrouille les formes connecteur.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) verrouille les objets graphiques.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) verrouille les formes groupées.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) verrouille les cadres d’image.  

Pour appliquer des verrous sur une [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), parcourez ses diapositives et définissez les verrous appropriés sur chaque forme prise en charge.

## **Appliquer et supprimer la protection**

Les éditeurs de présentations compatibles utilisent les verrous de forme pour restreindre des opérations d’édition individuelles. Le chiffrement de fichier et la protection en écriture au niveau du document sont des [paramètres de protection de présentation](/slides/fr/php-java/password-protected-presentation/) distincts.

### **Appliquer la protection aux formes PPTX**

Aspose.Slides pour PHP via Java fournit la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) pour travailler avec les formes d’une diapositive.

L’exemple appelle [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) et [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) avec `true` pour les formes automatiques, avec les verrous équivalents pour les formes groupées, les connecteurs et les cadres d’image. Les connecteurs utilisent [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) pour le mouvement ; les groupes utilisent également [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) pour restreindre le groupement.

L’exemple charge une présentation PPTX existante, examine les formes de la collection de formes de chaque diapositive, puis enregistre une copie avec ces restrictions appliquées. Les formes qui ne font pas partie des quatre types gérés restent inchangées. La boucle ne parcourt pas les formes enfant à l’intérieur d’un groupe.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Supprimer la protection**

Pour supprimer un verrou de forme, définissez sa valeur sur `false`. L’exemple suivant charge une présentation avec des verrous de forme et supprime les restrictions de sélection, de déplacement et de redimensionnement via [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) et [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Il supprime également la restriction de groupement en passant `false` à [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) et enregistre une copie de la présentation. Les autres paramètres de verrou restent inchangés.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Conserver le recadrage d'une image**

Placez une photo nommée `photo.jpg` dans le répertoire de travail. L’exemple recadre de 12 % à gauche et de 8 % à droite, puis appelle [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) sur le verrou du cadre d’image. Passer `true` restreint tout recadrage supplémentaire et conserve le recadrage existant.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` enregistre le verrou de recadrage comme `true`. Dans PowerPoint, la commande **Crop** est désactivée lorsque la photo est sélectionnée.

### **Conserver un diagramme groupé**

L’exemple regroupe un rectangle et une flèche, puis appelle [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) sur le verrou du groupe afin de garder les composants du diagramme ensemble. D’autres modifications, comme le déplacement du groupe ou le changement du remplissage d’un composant, restent disponibles.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` enregistre le verrou de dégrouppage comme `true`. Dans PowerPoint, la commande **Ungroup** est désactivée lorsque le diagramme complet est sélectionné.

### **Rapporter les verrous de forme existants**

Pour examiner un modèle, ouvrez‑le et lisez l’objet verrou pour chaque forme. La méthode [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) renvoie `true` lorsque tous les indicateurs de cet objet sont désactivés et `false` lorsqu’au moins un est activé. Un groupe et ses enfants possèdent des objets de verrou séparés, il faut donc inspecter les enfants même si le groupe ne possède aucun verrou.

Cet exemple vérifie le déplacement pour les formes automatiques, les cadres d’image et les groupes. Il vérifie également le recadrage pour les images et le dégrouppage pour les groupes. Le rapport répertorie les indicateurs activés qu’il reconnaît et indique les types de forme qu’il n’inspecte pas.

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

Supposons que la diapositive 1 de `Sample.pptx` contienne un groupe nommé `Layout` avec le dégrouppage verrouillé, une image nommée `Photo` à l’intérieur avec le recadrage verrouillé, et un rectangle non verrouillé nommé `Free`. Le rapport ignore `Free` et imprime ces deux lignes :

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Le rapport lit les indicateurs d’édition stockés au niveau de la forme sans les modifier ni enregistrer la présentation. La protection en écriture au niveau du document est un paramètre distinct, et l’application de chaque indicateur dépend de l’éditeur.

### **Conclusion**

Aspose.Slides pour PHP via Java vous permet de restreindre des opérations d’édition spécifiques sur des formes individuelles ou d’appliquer les mêmes restrictions sur plusieurs diapositives. Choisissez les verrous pris en charge par chaque type de forme et définissez leurs valeurs sur `false` lorsque vous devez supprimer ces restrictions.

## **FAQ**

**Puis‑je combiner les verrous de forme et la protection par mot de passe dans la même présentation ?**

Oui. Les verrous de forme restreignent des opérations d’édition spécifiques, tandis que la [password protection](/slides/fr/php-java/password-protected-presentation/) peut restreindre l’ouverture ou la modification de la présentation. Vous pouvez les utiliser tous les deux dans le même fichier.

**Puis‑je restreindre l’édition sur des diapositives spécifiques sans affecter les autres ?**

Oui. Appliquez les verrous uniquement aux formes des diapositives sélectionnées. Cela ne modifie pas les paramètres de verrouillage des autres diapositives.

**Comment appliquer des verrous aux formes individuelles à l’intérieur d’un groupe ?**

Parcourez la collection renvoyée par la méthode [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) du groupe et appliquez les verrous appropriés à chaque forme enfant. Répétez l’opération pour les groupes imbriqués, en suivant le parcours présenté dans l’exemple de rapport.