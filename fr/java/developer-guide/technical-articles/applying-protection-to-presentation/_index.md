---
title: Restreindre les modifications de présentation avec des verrous de forme en Java
linktitle: Restreindre les modifications de présentation
type: docs
weight: 60
url: /fr/java/applying-protection-to-presentation/
keywords:
- éviter les modifications
- protéger contre la modification
- verrouiller la forme
- verrouiller la position
- verrouiller la sélection
- verrouiller le redimensionnement
- verrouiller le regroupement
- PowerPoint
- PPTX
- présentation
- Java
- Aspose.Slides
description: "Apprenez comment verrouiller et déverrouiller les formes dans les présentations PPTX avec Aspose.Slides for Java afin de restreindre la sélection, le déplacement, le redimensionnement et le regroupement."
---
## **Contexte**

Une utilisation courante d’Aspose.Slides for Java consiste à créer, mettre à jour et enregistrer des présentations PowerPoint (PPTX) dans le cadre d’un flux de travail automatisé. Lorsque les utilisateurs reçoivent ces présentations, restreindre les modifications des formes peut aider à préserver la disposition et le contenu prévus.

Cet article explique comment les formes sont organisées sur les diapositives et comment appliquer et supprimer les verrous de forme dans une présentation PPTX. Ces verrous vous permettent de restreindre des opérations de modification spécifiques sur des formes individuelles.

## **Composition d’une diapositive**

Une diapositive de présentation est composée d’éléments tels que les formes automatiques, les tableaux, les objets OLE, les formes groupées, les cadres d’image, les cadres vidéo, les connecteurs et d’autres éléments utilisés pour créer une présentation. Dans Aspose.Slides for Java, chaque élément d’une diapositive est représenté par un objet qui implémente l’interface [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) ou hérite d’une classe qui le fait.

Différents types de formes exposent différentes options de verrouillage. L’interface [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) est l’interface de base pour les verrous de forme. Aspose.Slides for Java fournit les interfaces de verrouillage suivantes :

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) verrouille les formes automatiques.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) verrouille les formes de connecteur.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) verrouille les objets graphiques.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) verrouille les formes groupées.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) verrouille les cadres d’image.  

Pour appliquer des verrous à travers une [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), parcourez ses diapositives et définissez les verrous appropriés sur chaque forme prise en charge.

## **Appliquer et supprimer la protection**

Les verrous de forme restreignent des opérations telles que la sélection, le déplacement et le redimensionnement des formes. Ils ne rendent pas l’ensemble de la présentation non modifiable.

### **Appliquer la protection aux formes PPTX**

Aspose.Slides for Java fournit l’interface [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) pour travailler avec les formes sur une diapositive.

L’exemple appelle [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), et [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) avec `true` pour les formes automatiques, avec des verrous équivalents pour les formes groupées, les connecteurs et les cadres d’image. Les connecteurs utilisent [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) pour le déplacement ; les groupes utilisent également [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) pour restreindre le regroupement.

L’exemple charge une présentation PPTX existante, vérifie les formes de la collection de formes de chaque diapositive et enregistre une copie avec ces restrictions appliquées. Les formes qui ne font pas partie des quatre types gérés restent inchangées. La boucle ne parcourt pas les formes enfants à l’intérieur d’un groupe.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Supprimer la protection**

Pour supprimer un verrou de forme, définissez sa valeur sur `false`. L’exemple suivant charge une présentation avec des verrous de forme et supprime les restrictions de sélection, de déplacement et de redimensionnement via [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/), et [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). Il supprime également la restriction de regroupement en passant `false` à [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) et enregistre une copie de la présentation. Les autres paramètres de verrouillage restent inchangés.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Conclusion**

Aspose.Slides for Java vous permet de restreindre des opérations d’édition spécifiques sur des formes individuelles ou d’appliquer les mêmes restrictions sur plusieurs diapositives. Choisissez les verrous pris en charge par chaque type de forme, et définissez leurs valeurs sur `false` lorsque vous devez supprimer ces restrictions.

## **FAQ**

**Puis‑je combiner les verrous de forme et la protection par mot de passe dans la même présentation ?**

Oui. Les verrous de forme restreignent des opérations d’édition spécifiques, tandis que la [protection par mot de passe](/slides/fr/java/password-protected-presentation/) peut restreindre l’ouverture ou la modification de la présentation. Vous pouvez les utiliser tous les deux dans le même fichier.

**Puis‑je restreindre la modification sur des diapositives spécifiques sans affecter les autres ?**

Oui. Appliquez les verrous uniquement aux formes des diapositives sélectionnées. Cela ne modifie pas les paramètres de verrouillage des autres diapositives.

**Comment puis‑je appliquer des verrous à des formes individuelles à l’intérieur d’un groupe ?**

Parcourez la collection renvoyée par la méthode [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) du groupe et appliquez les verrous appropriés à chaque forme enfant. Répétez l’opération pour les groupes imbriqués. Les exemples ci‑dessus ne traitent que la collection de formes de la diapositive, ils ne définissent donc pas de verrous sur les membres individuels du groupe.