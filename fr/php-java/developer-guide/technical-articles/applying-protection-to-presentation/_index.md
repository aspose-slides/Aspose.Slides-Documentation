---
title: Restreindre les éditions de présentation avec des verrous de forme en PHP
linktitle: Restreindre les éditions de présentation
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
description: "Apprenez comment verrouiller et déverrouiller les formes dans les présentations PPTX avec Aspose.Slides for PHP via Java afin de restreindre la sélection, le déplacement, le redimensionnement et le groupement."
---
## **Vue d'ensemble**

Une utilisation courante d'Aspose.Slides for PHP via Java consiste à créer, mettre à jour et enregistrer des présentations PowerPoint (PPTX) dans le cadre d'un flux de travail automatisé. Lorsque les utilisateurs reçoivent ces présentations, restreindre les modifications des formes peut aider à préserver la disposition et le contenu prévus.

Cet article explique comment les formes sont organisées sur les diapositives et comment appliquer et supprimer les verrous de forme dans une présentation PPTX. Ces verrous vous permettent de restreindre des opérations d'édition spécifiques sur des formes individuelles.

## **Composition d'une diapositive**

Une diapositive de présentation est composée d'éléments tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d'image, des cadres vidéo, des connecteurs et d'autres éléments utilisés pour créer une présentation. Dans Aspose.Slides for PHP via Java, chaque élément d'une diapositive est représenté par un objet qui hérite de la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

Différents types de forme offrent différentes options de verrouillage. La classe [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) est la classe de base pour les verrous de forme. Aspose.Slides for PHP via Java fournit les classes de verrou suivantes :

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) verrouille les formes automatiques.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) verrouille les formes de connecteur.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) verrouille les objets graphiques.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) verrouille les formes groupées.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) verrouille les cadres d'image.  

Pour appliquer des verrous à travers une [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), parcourez ses diapositives et définissez les verrous appropriés sur chaque forme prise en charge.

## **Appliquer et supprimer la protection**

Les verrous de forme restreignent des opérations telles que la sélection, le déplacement et le redimensionnement des formes. Ils ne rendent pas l'ensemble de la présentation non modifiable.

### **Appliquer la protection aux formes PPTX**

Aspose.Slides for PHP via Java fournit la classe [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) pour travailler avec les formes sur une diapositive.

L'exemple appelle [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) et [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) avec `true` pour les formes automatiques, avec des verrous équivalents pour les formes groupées, les connecteurs et les cadres d'image. Les connecteurs utilisent [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) pour le déplacement ; les groupes utilisent également [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) pour restreindre le groupement.

L'exemple charge une présentation PPTX existante, vérifie les formes dans la collection de formes de chaque diapositive, et enregistre une copie avec ces restrictions appliquées. Les formes en dehors des quatre types gérés restent inchangées. La boucle ne parcourt pas les formes enfants à l'intérieur d'un groupe.

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

Pour supprimer un verrou de forme, définissez sa valeur sur `false`. L'exemple suivant charge une présentation avec des verrous de forme et supprime les restrictions de sélection, de déplacement et de redimensionnement via [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) et [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Il supprime également la restriction de groupement en passant `false` à [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) et enregistre une copie de la présentation. Les autres paramètres de verrouillage restent inchangés.

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

### **Conclusion**

Aspose.Slides for PHP via Java vous permet de restreindre des opérations d'édition spécifiques sur des formes individuelles ou d'appliquer les mêmes restrictions à travers les diapositives. Choisissez les verrous pris en charge par chaque type de forme, et définissez leurs valeurs sur `false` lorsque vous devez supprimer ces restrictions.

## **FAQ**

**Puis-je combiner les verrous de forme et la protection par mot de passe dans la même présentation ?**

Oui. Les verrous de forme restreignent des opérations d'édition spécifiques, tandis que la [protection par mot de passe](/slides/fr/php-java/password-protected-presentation/) peut restreindre l'ouverture ou la modification de la présentation. Vous pouvez utiliser les deux dans le même fichier.

**Puis-je restreindre l'édition sur des diapositives spécifiques sans affecter les autres ?**

Oui. Appliquez les verrous uniquement aux formes des diapositives sélectionnées. Cela ne modifie pas les paramètres de verrouillage des autres diapositives.

**Comment appliquer des verrous aux formes individuelles à l'intérieur d'un groupe ?**

Parcourez la collection renvoyée par la méthode [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) du groupe et appliquez les verrous appropriés à chaque forme enfant. Répétez cela pour tous les groupes imbriqués. Les exemples ci‑dessus traitent uniquement la collection de formes de la diapositive, ils ne définissent donc pas de verrous sur les membres individuels d'un groupe.