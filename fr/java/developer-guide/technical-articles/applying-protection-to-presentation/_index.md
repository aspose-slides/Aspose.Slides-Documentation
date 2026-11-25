---
title: Restreindre les modifications de présentation avec les verrous de forme en Java
linktitle: Restreindre les modifications de présentation
type: docs
weight: 60
url: /fr/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Apprenez à verrouiller et déverrouiller les formes dans les présentations PPTX avec Aspose.Slides pour Java afin de restreindre la sélection, le déplacement, le redimensionnement et le groupement."
---
## **Contexte**

Une utilisation courante d'Aspose.Slides for Java consiste à créer, mettre à jour et enregistrer des présentations PowerPoint (PPTX) dans le cadre d'un flux de travail automatisé. Lorsque les utilisateurs reçoivent ces présentations, restreindre les modifications des formes peut aider à préserver la mise en page et le contenu prévus.

Cet article explique comment les formes sont organisées sur les diapositives et comment appliquer et supprimer les verrous de forme dans une présentation PPTX. Ces verrous vous permettent de restreindre des opérations d'édition spécifiques sur des formes individuelles.

## **Composition d’une diapositive**

Une diapositive de présentation est composée d'éléments tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d'image, des cadres vidéo, des connecteurs et d'autres éléments utilisés pour créer une présentation. Dans Aspose.Slides for Java, chaque élément d'une diapositive est représenté par un objet qui implémente l'interface [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) ou hérite d'une classe qui le fait.

Différents types de formes exposent différentes options de verrouillage. L'interface [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) est l'interface de base pour les verrous de forme. Aspose.Slides for Java fournit les interfaces de verrouillage suivantes :
- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) verrouille les formes automatiques.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) verrouille les formes de connecteur.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) verrouille les objets graphiques.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) verrouille les formes groupées.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) verrouille les cadres d’image.  

Pour appliquer des verrous sur une [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), parcourez ses diapositives et définissez les verrous appropriés sur chaque forme prise en charge.

## **Appliquer et supprimer la protection**

Les éditeurs de présentations compatibles utilisent les verrous de forme pour restreindre des opérations d'édition individuelles. Le chiffrement de fichier et la protection en écriture au niveau du document sont des [paramètres de protection de la présentation](/slides/fr/java/password-protected-presentation/) séparés.

### **Appliquer la protection aux formes PPTX**

Aspose.Slides for Java fournit l'interface [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) pour travailler avec les formes sur une diapositive.

L'exemple appelle [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) et [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) avec `true` pour les formes automatiques, avec des verrous équivalents pour les formes groupées, les connecteurs et les cadres d'image. Les connecteurs utilisent [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) pour le déplacement ; les groupes utilisent également [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) pour restreindre le regroupement.

L'exemple charge une présentation PPTX existante, vérifie les formes dans la collection de formes de chaque diapositive et enregistre une copie avec ces restrictions appliquées. Les formes qui ne font pas partie des quatre types gérés restent inchangées. La boucle ne parcourt pas les formes enfants à l'intérieur d'un groupe.

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

Pour supprimer un verrou de forme, définissez sa valeur sur `false`. L'exemple suivant charge une présentation avec des verrous de forme et supprime les restrictions de sélection, de déplacement et de redimensionnement via [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) et [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/). Il supprime également la restriction de groupement en passant `false` à [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) et enregistre une copie de la présentation. Les autres paramètres de verrouillage restent inchangés.

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

### **Conserver le recadrage d'une image**

Placez une photo nommée `photo.jpg` dans le répertoire de travail. L'exemple recadre de 12 % à gauche et de 8 % à droite, puis appelle [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) sur le verrou du cadre d'image. Le passage de `true` restreint tout recadrage supplémentaire et conserve le recadrage existant.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);
    
    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` enregistre le verrou de recadrage comme `true`. Dans PowerPoint, la commande **Recadrer** est désactivée lorsque la photo est sélectionnée.

### **Garder un diagramme groupé**

L'exemple regroupe un rectangle et une flèche, puis appelle [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) sur le verrou du groupe pour maintenir les éléments du diagramme ensemble. D'autres modifications, comme déplacer le groupe ou changer le remplissage d'un composant, restent disponibles.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` enregistre le verrou de désagrégation comme `true`. Dans PowerPoint, la commande **Dégrouper** est désactivée lorsque le diagramme complet est sélectionné.

### **Rapporter les verrous de forme existants**

Pour examiner un modèle, ouvrez‑le et lisez l'objet de verrouillage de chaque forme. La méthode [getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--) renvoie `true` lorsque tous les indicateurs de cet objet sont désactivés et `false` lorsqu'au moins un est activé. Un groupe et ses enfants possèdent des objets de verrouillage séparés, il faut donc inspecter les enfants même si le groupe n’a aucun verrou.

Cet exemple vérifie le déplacement pour les formes automatiques, les cadres d'image et les groupes. Il vérifie également le recadrage pour les images et la désagrégation pour les groupes. Le rapport liste les indicateurs activés qu'il reconnaît et signale les types de formes qu'il n'inspecte pas.

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Supposons que la diapositive 1 de `Sample.pptx` contienne un groupe nommé `Layout` avec le verrouillage de désagrégation activé, une image nommée `Photo` à l'intérieur avec le recadrage verrouillé, et un rectangle déverrouillé nommé `Free`. Le rapport ignore `Free` et affiche ces deux lignes :

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Le rapport lit les indicateurs d'édition stockés au niveau de la forme sans les modifier ni enregistrer la présentation. La protection en écriture au niveau du document est un paramètre distinct, et l'application de chaque indicateur dépend de l'éditeur.

## **Conclusion**

Aspose.Slides for Java vous permet de restreindre des opérations d'édition spécifiques sur des formes individuelles ou d'appliquer les mêmes restrictions sur l'ensemble des diapositives. Choisissez les verrous pris en charge par chaque type de forme, et définissez leurs valeurs sur `false` lorsque vous devez supprimer ces restrictions.

## **FAQ**

**Puis‑je combiner les verrous de forme et la protection par mot de passe dans la même présentation ?**

Oui. Les verrous de forme restreignent des opérations d'édition spécifiques, tandis que la [protection par mot de passe](/slides/fr/java/password-protected-presentation/) peut restreindre l'ouverture ou la modification de la présentation. Vous pouvez utiliser les deux dans le même fichier.

**Puis‑je restreindre l'édition sur des diapositives spécifiques sans affecter les autres ?**

Oui. Appliquez les verrous uniquement aux formes des diapositives sélectionnées. Cela ne modifie pas les paramètres de verrouillage des autres diapositives.

**Comment puis‑je appliquer des verrous à des formes individuelles à l'intérieur d'un groupe ?**

Parcourez la collection retournée par la méthode [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) du groupe et appliquez les verrous appropriés à chaque forme enfant. Répétez cela pour les groupes imbriqués, en suivant le parcours de l'exemple de rapport.