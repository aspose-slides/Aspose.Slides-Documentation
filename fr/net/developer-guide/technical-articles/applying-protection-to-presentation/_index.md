---
title: Restreindre les modifications de présentation avec les verrous de forme dans .NET
linktitle: Restreindre les modifications de présentation
type: docs
weight: 70
url: /fr/net/applying-protection-to-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Apprenez à verrouiller et déverrouiller les formes dans les présentations PPTX avec Aspose.Slides pour .NET afin de restreindre la sélection, le déplacement, le redimensionnement et le groupement."
---
## **Contexte**

Une utilisation courante d'Aspose.Slides for .NET consiste à créer, mettre à jour et enregistrer des présentations PowerPoint (PPTX) dans le cadre d'un flux de travail automatisé. Lorsque les utilisateurs reçoivent ces présentations, restreindre les modifications des formes peut aider à préserver la disposition et le contenu prévus.

Cet article explique comment les formes sont organisées sur les diapositives et comment appliquer et supprimer les verrous de formes dans une présentation PPTX. Ces verrous vous permettent de restreindre des opérations d'édition spécifiques sur des formes individuelles.

## **Composition d'une diapositive**

Une diapositive de présentation est composée d'éléments tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d'image, des cadres vidéo, des connecteurs et d'autres éléments utilisés pour créer une présentation. Dans Aspose.Slides for .NET, chaque élément d'une diapositive est représenté par un objet qui implémente l'interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) ou hérite d'une classe qui le fait.

Différents types de formes exposent différentes options de verrouillage. L'interface [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) est l'interface de base pour les verrous de forme. Aspose.Slides for .NET fournit les interfaces de verrouillage suivantes :

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) verrouille les formes automatiques.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) verrouille les formes de connecteur.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) verrouille les objets graphiques.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) verrouille les formes groupées.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) verrouille les cadres d'image.  

Pour appliquer des verrous sur une [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), parcourez ses diapositives et définissez les verrous appropriés sur chaque forme prise en charge.

## **Appliquer et supprimer la protection**

Les éditeurs de présentations compatibles utilisent les verrous de forme pour restreindre les opérations d'édition individuelles. Le chiffrement de fichier et la protection en écriture au niveau du document sont des [paramètres de protection de la présentation](/slides/fr/net/password-protected-presentation/) distincts.

### **Appliquer la protection aux formes PPTX**

Aspose.Slides for .NET fournit l'interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) pour travailler avec les formes sur une diapositive.

L'exemple définit [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) et [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) à `true` pour les formes automatiques, avec des verrous équivalents pour les formes groupées, les connecteurs et les cadres d'image. Les connecteurs utilisent [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) pour le déplacement ; les groupes utilisent également [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) pour restreindre le groupement.

L'exemple charge une présentation PPTX existante, examine les formes de la collection de formes de chaque diapositive et enregistre une copie avec ces restrictions appliquées. Les formes en dehors des quatre types gérés restent inchangées. La boucle ne parcourt pas les formes enfants à l'intérieur d'un groupe.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Supprimer la protection**

Pour supprimer un verrou de forme, définissez sa valeur sur `false`. L'exemple suivant charge une présentation avec des verrous de forme et supprime les restrictions de sélection, de déplacement et de redimensionnement via [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/), et [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). Il supprime également [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) et enregistre une copie de la présentation. Les autres paramètres de verrouillage restent inchangés.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Conserver le recadrage d'une image**

Placez une photo nommée `photo.jpg` dans le répertoire de travail. L'exemple recadre de 12 % à gauche et de 8 % à droite, puis définit [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) sur le cadre d'image. Ce drapeau restreint tout nouveau recadrage et conserve le recadrage existant.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` enregistre le verrou de recadrage comme `true`. Dans PowerPoint, la commande **Crop** est désactivée lorsque la photo est sélectionnée.

### **Conserver un diagramme groupé**

L'exemple groupe un rectangle et une flèche, puis définit [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) sur le groupe lui‑même pour maintenir les composants du diagramme ensemble. D'autres modifications, comme le déplacement du groupe ou le changement du remplissage d'un composant, restent disponibles.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` enregistre le verrou de dégrouper comme `true`. Dans PowerPoint, la commande **Ungroup** est désactivée lorsque le diagramme complet est sélectionné.

### **Rapporter les verrous de forme existants**

Pour examiner un modèle, ouvrez‑le et lisez l'objet de verrouillage de chaque forme. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) vaut `true` lorsque tous les drapeaux de cet objet sont désactivés et `false` lorsqu'au moins un est activé. Un groupe et ses enfants possèdent des objets de verrouillage séparés, il faut donc inspecter les enfants même si le groupe n'a aucun verrou.

Cet exemple vérifie le déplacement pour les formes automatiques, les cadres d'image et les groupes, le recadrage pour les images, et le dégrouper pour les groupes. Il rapporte les drapeaux qu'il reconnaît et indique les types de forme qu'il n'inspecte pas.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

Supposons que la diapositive 1 de `Sample.pptx` contienne un groupe nommé `Layout` avec le dégrouper verrouillé, une image nommée `Photo` à l'intérieur avec le recadrage verrouillé, et un rectangle non verrouillé nommé `Free`. Le rapport ignore `Free` et affiche ces deux lignes :

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Le rapport lit les drapeaux d'édition au niveau de la forme stockés sans les modifier ni enregistrer la présentation. La protection en écriture au niveau du document est un paramètre distinct, et l'application de chaque drapeau dépend de l'éditeur.

### **Conclusion**

Aspose.Slides for .NET vous permet de restreindre des opérations d'édition spécifiques sur des formes individuelles ou d'appliquer les mêmes restrictions sur plusieurs diapositives. Choisissez les verrous pris en charge par chaque type de forme, et définissez leurs valeurs sur `false` lorsque vous devez supprimer ces restrictions.

## **FAQ**

**Puis-je combiner les verrous de forme et la protection par mot de passe dans la même présentation ?**

Oui. Les verrous de forme restreignent des opérations d'édition spécifiques, tandis que la [protection par mot de passe](/slides/fr/net/password-protected-presentation/) peut restreindre l'ouverture ou la modification de la présentation. Vous pouvez utiliser les deux dans le même fichier.

**Puis-je restreindre l'édition sur des diapositives spécifiques sans affecter les autres ?**

Oui. Appliquez les verrous uniquement aux formes des diapositives sélectionnées. Cela ne modifie pas les paramètres de verrouillage des autres diapositives.

**Comment puis‑je appliquer des verrous à des formes individuelles à l'intérieur d'un groupe ?**

Parcourez la collection [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) du groupe et appliquez les verrous appropriés à chaque forme enfant. Répétez l'opération pour les groupes imbriqués, en suivant le parcours de l'exemple de reporting.