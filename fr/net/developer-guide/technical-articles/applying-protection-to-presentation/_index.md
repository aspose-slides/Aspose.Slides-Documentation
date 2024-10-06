---
title: Application de la protection à la présentation
type: docs
weight: 70
url: /net/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Une utilisation courante d'Aspose.Slides est de créer, mettre à jour et enregistrer des présentations Microsoft PowerPoint 2007 (PPTX) dans le cadre d'un flux de travail automatisé. Les utilisateurs de l'application qui utilise Aspose.Slides de cette manière ont accès aux présentations exportées. Les protéger contre l'édition est une préoccupation fréquente. Il est important que les présentations générées automatiquement conservent leur formatage et leur contenu d'origine.

Cet article explique comment [les présentations et les diapositives sont construites](/slides/net/applying-protection-to-presentation/) et comment Aspose.Slides pour .NET peut [appliquer la protection à](/slides/net/applying-protection-to-presentation/), puis [la retirer de](/slides/net/applying-protection-to-presentation/) une présentation. Cette fonctionnalité est unique à Aspose.Slides et, au moment de l'écriture, n'est pas disponible dans Microsoft PowerPoint. Elle offre aux développeurs un moyen de contrôler comment les présentations créées par leurs applications sont utilisées.

{{% /alert %}} 
## **Composition d'une diapositive**
Une diapositive PPTX est composée d'un certain nombre de composants tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d'image, des cadres vidéo, des connecteurs et les différents autres éléments disponibles pour construire une présentation.

Dans Aspose.Slides pour .NET, chaque élément sur une diapositive est transformé en objet Shape. En d'autres termes, chaque élément de la diapositive est soit un objet Shape, soit un objet dérivé de l'objet Shape.

La structure du PPTX est complexe, donc contrairement au PPT, où un verrou générique peut être utilisé pour tous les types de formes, il existe différents types de verrous pour différents types de formes. La classe BaseShapeLock est la classe de verrouillage générique pour PPTX. Les types de verrous suivants sont pris en charge dans Aspose.Slides pour .NET pour PPTX.

- AutoShapeLock verrouille les formes automatiques.
- ConnectorLock verrouille les formes de connecteurs.
- GraphicalObjectLock verrouille les objets graphiques.
- GroupshapeLock verrouille les formes de groupe.
- PictureFrameLock verrouille les cadres d'image.

Toute action effectuée sur tous les objets Shape dans un objet Presentation s'applique à l'ensemble de la présentation.
## **Application et retrait de la protection**
Appliquer une protection garantit qu'une présentation ne peut pas être éditée. C'est une technique utile pour protéger le contenu d'une présentation.
### **Application de la protection aux formes PPTX**
Aspose.Slides pour .NET fournit la classe Shape pour gérer une forme sur la diapositive.

Comme mentionné plus tôt, chaque classe de forme a une classe de verrouillage associée pour la protection. Cet article se concentre sur les verrous NoSelect, NoMove et NoResize. Ces verrous garantissent que les formes ne peuvent pas être sélectionnées (via des clics de souris ou d'autres méthodes de sélection), et qu'elles ne peuvent pas être déplacées ou redimensionnées.

Les exemples de code qui suivent appliquent la protection à tous les types de formes dans une présentation.

```c#
//Instanciation de la classe Presentation représentant un fichier PPTX
Presentation pTemplate = new Presentation("RectPicFrame.pptx");
           

//Objet ISlide pour accéder aux diapositives de la présentation
ISlide slide = pTemplate.Slides[0];

//Objet IShape pour contenir des formes temporaires
IShape shape;

//Parcourt de toutes les diapositives dans la présentation
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
    slide = pTemplate.Slides[slideCount];

    //Parcourt de toutes les formes dans les diapositives
    for (int count = 0; count < slide.Shapes.Count; count++)
    {
        shape = slide.Shapes[count];

        //si la forme est une forme automatique
        if (shape is IAutoShape)
        {
            //Conversion en forme automatique et obtention du verrou de forme automatique
            IAutoShape Ashp = shape as IAutoShape;
            IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

            //Application des verrous à la forme
            AutoShapeLock.PositionLocked = true;
            AutoShapeLock.SelectLocked = true;
            AutoShapeLock.SizeLocked = true;
        }

        //si la forme est une forme de groupe
        else if (shape is IGroupShape)
        {
            //Conversion en forme de groupe et obtention du verrou de forme de groupe
            IGroupShape Group = shape as IGroupShape;
            IGroupShapeLock groupShapeLock = Group.ShapeLock;

            //Application des verrous à la forme
            groupShapeLock.GroupingLocked = true;
            groupShapeLock.PositionLocked = true;
            groupShapeLock.SelectLocked = true;
            groupShapeLock.SizeLocked = true;
        }

        //si la forme est un connecteur
        else if (shape is IConnector)
        {
            //Conversion en forme de connecteur et obtention du verrou de forme de connecteur
            IConnector Conn = shape as IConnector;
            IConnectorLock ConnLock = Conn.ShapeLock;

            //Application des verrous à la forme
            ConnLock.PositionMove = true;
            ConnLock.SelectLocked = true;
            ConnLock.SizeLocked = true;
        }

        //si la forme est un cadre d'image
        else if (shape is IPictureFrame)
        {
            //Conversion en forme de cadre d'image et obtention du verrou de forme de cadre d'image
            IPictureFrame Pic = shape as IPictureFrame;
            IPictureFrameLock PicLock = Pic.ShapeLock;

            //Application des verrous à la forme
            PicLock.PositionLocked = true;
            PicLock.SelectLocked = true;
            PicLock.SizeLocked = true;
        }
    }


}
//Enregistrement du fichier de présentation
pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


### **Retrait de la protection**
La protection appliquée à l'aide d'Aspose.Slides pour .NET ne peut être retirée qu'avec Aspose.Slides pour .NET. Pour déverrouiller une forme, définissez la valeur du verrou appliqué sur false. L'exemple de code qui suit montre comment déverrouiller des formes dans une présentation verrouillée.

```c#
//Ouvrir la présentation souhaitée
Presentation pTemplate = new Presentation("ProtectedSample.pptx");

//Objet ISlide pour accéder aux diapositives de la présentation
ISlide slide = pTemplate.Slides[0];

//Objet IShape pour contenir des formes temporaires
IShape shape;

//Parcourt de toutes les diapositives dans la présentation
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
    slide = pTemplate.Slides[slideCount];

    //Parcourt de toutes les formes dans les diapositives
    for (int count = 0; count < slide.Shapes.Count; count++)
    {
        shape = slide.Shapes[count];

        //si la forme est une forme automatique
        if (shape is IAutoShape)
        {
            //Conversion en forme automatique et obtention du verrou de forme automatique
            IAutoShape Ashp = shape as AutoShape;
            IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

            //Application des verrous à la forme
            AutoShapeLock.PositionLocked = false;
            AutoShapeLock.SelectLocked = false;
            AutoShapeLock.SizeLocked = false;
        }

        //si la forme est une forme de groupe
        else if (shape is IGroupShape)
        {
            //Conversion en forme de groupe et obtention du verrou de forme de groupe
            IGroupShape Group = shape as IGroupShape;
            IGroupShapeLock groupShapeLock = Group.ShapeLock;

            //Application des verrous à la forme
            groupShapeLock.GroupingLocked = false;
            groupShapeLock.PositionLocked = false;
            groupShapeLock.SelectLocked = false;
            groupShapeLock.SizeLocked = false;
        }

        //si la forme est une forme de connecteur
        else if (shape is IConnector)
        {
            //Conversion en forme de connecteur et obtention du verrou de forme de connecteur
            IConnector Conn = shape as IConnector;
            IConnectorLock ConnLock = Conn.ShapeLock;

            //Application des verrous à la forme
            ConnLock.PositionMove = false;
            ConnLock.SelectLocked = false;
            ConnLock.SizeLocked = false;
        }

        //si la forme est un cadre d'image
        else if (shape is IPictureFrame)
        {
            //Conversion en forme de cadre d'image et obtention du verrou de forme de cadre d'image
            IPictureFrame Pic = shape as IPictureFrame;
            IPictureFrameLock PicLock = Pic.ShapeLock;

            //Application des verrous à la forme
            PicLock.PositionLocked = false;
            PicLock.SelectLocked = false;
            PicLock.SizeLocked = false;
        }
    }

}
//Enregistrement du fichier de présentation
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



### **Résumé**
{{% alert color="primary" %}} 

Aspose.Slides offre plusieurs options pour appliquer la protection aux formes dans une présentation. Il est possible de verrouiller une forme particulière, ou de parcourir toutes les formes d'une présentation et de toutes les verrouiller pour verrouiller efficacement la présentation.

Seul Aspose.Slides pour .NET peut retirer la protection d'une présentation qu'il a préalablement protégée. Retirez la protection en définissant la valeur d'un verrou sur false.

{{% /alert %}} 