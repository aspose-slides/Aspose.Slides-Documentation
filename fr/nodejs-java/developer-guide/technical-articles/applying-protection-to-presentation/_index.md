---
title: Restreindre les modifications de présentation avec des verrous de forme dans Node.js
linktitle: Restreindre les modifications de présentation
type: docs
weight: 60
url: /fr/nodejs-java/applying-protection-to-presentation/
keywords:
- empêcher les modifications
- protéger contre la modification
- verrouiller la forme
- verrouiller la position
- verrouiller la sélection
- verrouiller le redimensionnement
- verrouiller le regroupement
- PowerPoint
- PPTX
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez comment verrouiller et déverrouiller des formes dans les présentations PPTX avec Aspose.Slides pour Node.js via Java afin de restreindre la sélection, le déplacement, le redimensionnement et le regroupement."
---
## **Vue d'ensemble**

Une utilisation courante d'Aspose.Slides for Node.js via Java consiste à créer, mettre a jour et enregistrer des presentations PowerPoint (PPTX) dans le cadre d'un flux de travail automate. Lorsque les utilisateurs reçoivent ces presentations, restreindre les modifications des formes peut aider a préserver la mise en page et le contenu prevus.

Cet article explique comment les formes sont organisees sur les diapositives et comment appliquer et supprimer les verrous de forme dans une presentation PPTX. Ces verrous vous permettent de restreindre des operations d'edition specifique sur des formes individuelles.

## **Composition d'une diapositive**

Une diapositive de presentation est composee d'elements tels que des formes automatiques, des tableaux, des objets OLE, des formes groupees, des cadres d'image, des cadres video, des connecteurs et d'autres elements utilises pour creer une presentation. Dans Aspose.Slides for Node.js via Java, chaque element d'une diapositive est represente par un objet qui herite de la classe [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) .

Différents types de formes offrent différentes options de verrouillage. La classe [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) est la classe de base pour les verrous de forme. Aspose.Slides for Node.js via Java fournit les classes de verrouillage suivantes :

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) verrouille les formes automatiques.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) verrouille les formes de connecteur.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) verrouille les objets graphiques.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) verrouille les formes groupees.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) verrouille les cadres d'image.  

Pour appliquer des verrous sur une [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), parcourez ses diapositives et definiissez les verrous appropries sur chaque forme prise en charge.

## **Appliquer et supprimer la protection**

Les verrous de forme restreignent des operations telles que la selection, le deplacement et le redimensionnement des formes. Ils ne rendent pas l'ensemble de la presentation non modifiable.

### **Appliquer la protection aux formes PPTX**

Aspose.Slides for Node.js via Java fournit la classe [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) pour travailler avec les formes d'une diapositive.

L'exemple appelle [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) et [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) avec `true` pour les formes automatiques, avec les verrous equivalents pour les formes groupees, les connecteurs et les cadres d'image. Les connecteurs utilisent [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) pour le deplacement; les groupes utilisent également [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) pour limiter le regroupement.

L'exemple charge une presentation PPTX existante, examine les formes de la collection de formes de chaque diapo et enregistre une copie avec ces restrictions appliquees. Les formes en dehors des quatre types geres restent inchangees. La boucle ne parcourt pas les formes enfants a l'interieur d'un groupe.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Supprimer la protection**

Pour supprimer un verrou de forme, definiissez sa valeur sur `false`. L'exemple suivant charge une presentation contenant des verrous de forme et supprime les restrictions de selection, de deplacement et de redimensionnement via [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/), et [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Il supprime egalement la restriction de regroupement en passant `false` a [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) et enregistre une copie de la presentation. Les autres parametres de verrouillage restent inchanges.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Conclusion**

Aspose.Slides for Node.js via Java vous permet de restreindre des operations d'edition specifique sur des formes individuelles ou d'appliquer les memes restrictions sur plusieurs diapositives. Choisissez les verrous pris en charge par chaque type de forme, et definiissez leurs valeurs sur `false` lorsque vous devez supprimer ces restrictions.

## **FAQ**

**Can I combine shape locks and password protection in the same presentation?**

Oui. Les verrous de forme restreignent des operations d'edition specifiques, tandis que la [protection par mot de passe](/slides/fr/nodejs-java/password-protected-presentation/) peut restreindre l'ouverture ou la modification de la presentation. Vous pouvez les'utiliser tous les deux dans le meme fichier.

**Can I restrict editing on specific slides without affecting others?**

Oui. Appliquez les verrous uniquement aux formes des diapositives selectionnees. Cela ne modifie pas les parametres de verrouillage des autres diapositives.

**How can I apply locks to individual shapes inside a group?**

Parcourrez la collection renvoyee par la methode [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) du groupe et appliquez les verrous appropriés à chaque forme enfant. Répétez cela pour tous les groupes imbriqués. Les exemples ci-dessous ne traitent que la collection de formes de la diapositive, ils ne definissent donc pas de verrous sur les membres individuels d'un groupe.