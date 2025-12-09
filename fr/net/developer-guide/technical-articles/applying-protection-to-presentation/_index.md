---
title: Empêcher les modifications de présentation avec les verrous de forme dans .NET
linktitle: Empêcher les modifications de présentation
type: docs
weight: 70
url: /fr/net/applying-protection-to-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for .NET verrouille ou déverrouille les formes dans les fichiers PPT, PPTX et ODP, sécurisant les présentations tout en permettant des modifications contrôlées."
---

## **Contexte**

Une utilisation courante d’Aspose.Slides consiste à créer, mettre à jour et enregistrer des présentations Microsoft PowerPoint (PPTX) dans le cadre d’un flux de travail automatisé. Les utilisateurs d’applications qui utilisent Aspose.Slides de cette façon ont accès aux présentations générées, il est donc fréquent de vouloir les protéger contre la modification. Il est important que les présentations générées automatiquement conservent leur mise en forme et leur contenu d’origine.

Cet article explique comment les présentations et les diapositives sont structurées et comment Aspose.Slides for .NET peut appliquer une protection à une présentation puis la retirer. Il fournit aux développeurs un moyen de contrôler l’utilisation des présentations que leurs applications génèrent.

## **Composition d’une diapositive**

Une diapositive de présentation se compose d’éléments tels que les formes automatiques, les tableaux, les objets OLE, les formes groupées, les cadres d’image, les cadres vidéo, les connecteurs et d’autres éléments utilisés pour construire une présentation. Dans Aspose.Slides for .NET, chaque élément d’une diapositive est représenté par un objet qui implémente l’interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) ou hérite d’une classe qui le fait.

La structure du PPTX est complexe, de sorte qu’à la différence du PPT, où un verrou générique peut être utilisé pour tous les types de formes, différents types de formes nécessitent des verrous différents. L’interface [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) est la classe de verrouillage générique pour le PPTX. Les types de verrous suivants sont pris en charge dans Aspose.Slides for .NET pour le PPTX :

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) verrouille les formes automatiques.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) verrouille les formes de connecteur.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) verrouille les objets graphiques.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) verrouille les formes groupées.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) verrouille les cadres d’image.  

Toute action effectuée sur tous les objets forme d’un objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) est appliquée à l’ensemble de la présentation.

## **Appliquer et supprimer la protection**

L’application de la protection garantit qu’une présentation ne peut pas être modifiée. C’est une technique utile pour protéger le contenu de la présentation.

### **Appliquer la protection aux formes PPTX**

Aspose.Slides for .NET fournit l’interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) pour travailler avec les formes d’une diapositive.

Comme indiqué précédemment, chaque classe de forme possède une classe de verrouillage de forme associée pour la protection. Cet article se concentre sur les verrous NoSelect, NoMove et NoResize. Ces verrous assurent que les formes ne peuvent pas être sélectionnées (par clics de souris ou autres méthodes de sélection) et qu’elles ne peuvent pas être déplacées ou redimensionnées.

L’exemple de code qui suit applique la protection à tous les types de formes d’une présentation.
```cs
// Instancie la classe Presentation qui représente un fichier PPTX.
using Presentation presentation = new Presentation("Sample.pptx");

// Parcourt toutes les diapositives de la présentation.
foreach (ISlide slide in presentation.Slides)
{
    // Parcourt toutes les formes de la diapositive.
    foreach (IShape shape in slide.Shapes)
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

// Enregistre le fichier de présentation.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```


### **Supprimer la protection**

Pour déverrouiller une forme, définissez la valeur du verrou appliqué sur `false`. L’exemple de code suivant montre comment déverrouiller les formes dans une présentation verrouillée.
```cs
// Instancie la classe Presentation qui représente un fichier PPTX.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Parcourt toutes les diapositives de la présentation.
foreach (ISlide slide in presentation.Slides)
{
    // Parcourt toutes les formes de la diapositive.
    foreach (IShape shape in slide.Shapes)
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

// Enregistre le fichier de présentation.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```


### **Conclusion**

Aspose.Slides propose plusieurs options pour protéger les formes d’une présentation. Vous pouvez verrouiller une forme individuelle ou parcourir toutes les formes d’une présentation et les verrouiller chacune afin de sécuriser efficacement le fichier complet. Vous pouvez supprimer la protection en définissant la valeur du verrou sur `false`.

## **FAQ**

**Puis‑je combiner les verrous de forme et la protection par mot de passe dans la même présentation ?**

Oui. Les verrous limitent la modification des objets à l’intérieur du fichier, tandis que la [protection par mot de passe](/slides/fr/net/password-protected-presentation/) contrôle l’accès à l’ouverture et/ou à l’enregistrement des modifications. Ces mécanismes se complètent et fonctionnent ensemble.

**Puis‑je restreindre la modification sur des diapositives spécifiques sans affecter les autres ?**

Oui. Appliquez des verrous aux formes des diapositives sélectionnées ; les diapositives restantes resteront modifiables.

**Les verrous de forme s’appliquent‑ils aux objets groupés et aux connecteurs ?**

Oui. Des types de verrous dédiés sont pris en charge pour les groupes, les connecteurs, les objets graphiques et les autres sortes de formes.