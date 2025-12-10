---
title: Empêcher les modifications de la présentation avec des verrous de forme
linktitle: Empêcher les modifications de la présentation
type: docs
weight: 60
url: /fr/java/applying-protection-to-presentation/
keywords:
- empêcher les modifications
- protéger contre la modification
- verrouiller la forme
- verrouiller la position
- verrouiller la sélection
- verrouiller la taille
- verrouiller le groupement
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for Java verrouille ou déverrouille les formes dans les fichiers PPT, PPTX et ODP, sécurisant les présentations tout en permettant des modifications contrôlées et une livraison plus rapide."
---

## **Contexte**

Une utilisation courante d’Aspose.Slides consiste à créer, mettre à jour et enregistrer des présentations Microsoft PowerPoint (PPTX) dans le cadre d’un flux de travail automatisé. Les utilisateurs d’applications qui emploient Aspose.Slides de cette façon ont accès aux présentations générées, ainsi la protection contre la modification est une préoccupation fréquente. Il est important que les présentations générées automatiquement conservent leur mise en forme et leur contenu d’origine.

Cet article explique comment les présentations et les diapositives sont structurées et comment Aspose.Slides for Java peut appliquer une protection à une présentation puis la supprimer. Il fournit aux développeurs un moyen de contrôler l’utilisation des présentations générées par leurs applications.

## **Composition d’une diapositive**

Une diapositive de présentation est composée d’éléments tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d’image, des cadres vidéo, des connecteurs et d’autres éléments utilisés pour créer une présentation. Dans Aspose.Slides for Java, chaque élément d’une diapositive est représenté par un objet qui implémente l’interface [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) ou hérite d’une classe qui le fait.

La structure du PPTX est complexe, de sorte qu’à la différence du PPT, où un verrou générique peut être utilisé pour tous les types de formes, différents types de formes nécessitent des verrous différents. L’interface [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) est la classe de verrouillage générique pour le PPTX. Les types de verrous suivants sont pris en charge dans Aspose.Slides for Java pour le PPTX :

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) verrouille les formes automatiques.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) verrouille les formes de connecteur.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) verrouille les objets graphiques.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) verrouille les formes groupées.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) verrouille les cadres d’image.  

Toute action effectuée sur tous les objets forme dans un objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) est appliquée à l’ensemble de la présentation.

## **Appliquer et supprimer la protection**

Appliquer une protection garantit qu’une présentation ne peut pas être modifiée. C’est une technique utile pour protéger le contenu de la présentation.

### **Appliquer la protection aux formes PPTX**

Aspose.Slides for Java fournit l’interface [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) pour travailler avec les formes d’une diapositive.

Comme indiqué précédemment, chaque classe de forme possède une classe de verrouillage de forme associée pour la protection. Cet article se concentre sur les verrous NoSelect, NoMove et NoResize. Ces verrous assurent que les formes ne peuvent pas être sélectionnées (par clics de souris ou autres méthodes de sélection) et qu’elles ne peuvent pas être déplacées ou redimensionnées.

L’exemple de code qui suit applique une protection à tous les types de forme d’une présentation.
```java
// Instancier la classe Presentation qui représente un fichier PPTX.
Presentation presentation = new Presentation("Sample.pptx");

// Parcourir toutes les diapositives de la présentation.
for (ISlide slide : presentation.getSlides()) {

    // Parcourir toutes les formes de la diapositive.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Conversion du type de la forme en forme automatique et récupération de son verrou.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // Conversion du type de la forme en forme groupe et récupération de son verrou.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // Conversion du type de la forme en connecteur et récupération de son verrou.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // Conversion du type de la forme en cadre d'image et récupération de son verrou.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// Enregistrement du fichier de présentation.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **Supprimer la protection**

Pour déverrouiller une forme, définissez la valeur du verrou appliqué sur `false`. L’exemple de code suivant montre comment déverrouiller les formes dans une présentation verrouillée.
```java
// Instancier la classe Presentation qui représente un fichier PPTX.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// Parcourir toutes les diapositives de la présentation.
for (ISlide slide : presentation.getSlides()) {

    // Parcourir toutes les formes de la diapositive.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Conversion du type de la forme en forme automatique et récupération de son verrou.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // Conversion du type de la forme en forme groupée et récupération de son verrou.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // Conversion du type de la forme en forme de connecteur et récupération de son verrou.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // Conversion du type de la forme en cadre d'image et récupération de son verrou.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// Enregistrement du fichier de présentation.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Conclusion**

Aspose.Slides offre plusieurs options pour protéger les formes d’une présentation. Vous pouvez verrouiller une forme individuelle ou parcourir toutes les formes d’une présentation et en verrouiller chacune afin de sécuriser efficacement l’ensemble du fichier. Vous pouvez supprimer la protection en réglant la valeur du verrou sur `false`.

## **FAQ**

**Puis-je combiner les verrous de forme et la protection par mot de passe dans la même présentation ?**

Oui. Les verrous limitent la modification des objets à l’intérieur du fichier, tandis que la [protection par mot de passe](/slides/fr/java/password-protected-presentation/) contrôle l’accès à l’ouverture et/ou à l’enregistrement des modifications. Ces mécanismes se complètent et fonctionnent ensemble.

**Puis-je restreindre la modification de certaines diapositives sans affecter les autres ?**

Oui. Appliquez des verrous aux formes des diapositives sélectionnées ; les diapositives restantes resteront modifiables.

**Les verrous de forme s’appliquent-ils aux objets groupés et aux connecteurs ?**

Oui. Des types de verrous dédiés sont pris en charge pour les groupes, les connecteurs, les objets graphiques et les autres types de forme.