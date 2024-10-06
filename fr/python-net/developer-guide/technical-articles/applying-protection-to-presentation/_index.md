---
title: Appliquer la protection à la présentation
type: docs
weight: 70
url: /python-net/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Une utilisation courante d'Aspose.Slides est de créer, mettre à jour et enregistrer des présentations Microsoft PowerPoint 2007 (PPTX) dans le cadre d'un flux de travail automatisé. Les utilisateurs de l'application qui utilise Aspose.Slides de cette manière ont accès aux présentations de sortie. Les protéger contre la modification est une préoccupation courante. Il est important que les présentations générées automatiquement conservent leur formatage et leur contenu d'origine.

Cet article explique comment [les présentations et les diapositives sont construites](/slides/python-net/applying-protection-to-presentation/) et comment Aspose.Slides pour Python via .NET peut [appliquer une protection à](/slides/python-net/applying-protection-to-presentation/) puis [la supprimer de](/slides/python-net/applying-protection-to-presentation/) une présentation. Cette fonctionnalité est exclusive à Aspose.Slides et, au moment de la rédaction, n'est pas disponible dans Microsoft PowerPoint. Cela donne aux développeurs un moyen de contrôler comment les présentations créées par leurs applications sont utilisées.

{{% /alert %}} 
## **Composition d'une Diapositive**
Une diapositive PPTX est composée d'un certain nombre de composants comme des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d'image, des cadres vidéo, des connecteurs et d'autres éléments divers disponibles pour constituer une présentation.

Dans Aspose.Slides pour Python via .NET, chaque élément sur une diapositive est transformé en un objet Shape. En d'autres termes, chaque élément sur la diapositive est soit un objet Shape, soit un objet dérivé de l'objet Shape.

La structure de PPTX est complexe, donc contrairement à PPT, où un verrou générique peut être utilisé pour tous les types de formes, il existe différents types de verrous pour différents types de formes. La classe BaseShapeLock est la classe de verrouillage générique pour PPTX. Les types de verrous suivants sont pris en charge dans Aspose.Slides pour Python via .NET pour PPTX.

- AutoShapeLock verrouille les formes automatiques.
- ConnectorLock verrouille les formes connecteurs.
- GraphicalObjectLock verrouille les objets graphiques.
- GroupshapeLock verrouille les formes groupées.
- PictureFrameLock verrouille les cadres d'image.

Toute action effectuée sur tous les objets Shape dans un objet Presentation est appliquée à l'ensemble de la présentation.
## **Appliquer et supprimer la protection**
Appliquer une protection garantit qu'une présentation ne peut pas être modifiée. C'est une technique utile pour protéger le contenu d'une présentation.
### **Appliquer la protection aux formes PPTX**
Aspose.Slides pour Python via .NET fournit la classe Shape pour gérer une forme sur la diapositive.

Comme mentionné précédemment, chaque classe de forme a une classe de verrou associée pour la protection. Cet article se concentre sur les verrous NoSelect, NoMove et NoResize. Ces verrous garantissent que les formes ne peuvent pas être sélectionnées (par des clics de souris ou d'autres méthodes de sélection), et qu'elles ne peuvent pas être déplacées ou redimensionnées.

Les exemples de code qui suivent appliquent la protection à tous les types de formes dans une présentation.

```py
import aspose.slides as slides

#Instatiate Presentation class that represents a PPTX file
with slides.Presentation(path + "RectPicFrame.pptx") as pres:
    #ISlide object for accessing the slides in the presentation
    slide = pres.slides[0]

    #Traversing through all the slides in the presentation
    for slide in pres.slides:
        for shape in slide.shapes:
            #if shape is autoshape
            if type(shape) is slides.AutoShape:
                auto_shape_lock = shape.shape_lock

                #Applying shapes locks
                auto_shape_lock.position_locked = True
                auto_shape_lock.select_locked = True
                auto_shape_lock.size_locked = True

            #if shape is group shape
            elif type(shape) is slides.GroupShape:
                group_shape_lock = shape.shape_lock

                #Applying shapes locks
                group_shape_lock.grouping_locked = True
                group_shape_lock.position_locked = True
                group_shape_lock.select_locked = True
                group_shape_lock.size_locked = True

            #if shape is a connector
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                #Applying shapes locks
                connector_lock.position_move = True
                connector_lock.select_locked = True
                connector_lock.size_locked = True
            #if shape is picture frame
            elif type(shape) is slides.PictureFrame:
                #Type casting to pitcture frame shape and getting picture frame shape lock
                picture_lock = shape.shape_lock

                #Applying shapes locks
                picture_lock.position_locked = True
                picture_lock.select_locked = True
                picture_lock.size_locked = True

    #Saving the presentation file
    pres.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```


### **Supprimer la protection**
La protection appliquée à l'aide d'Aspose.Slides pour Python via .NET ne peut être supprimée qu'avec Aspose.Slides pour Python via .NET. Pour déverrouiller une forme, il suffit de définir la valeur du verrou appliqué sur false. L'exemple de code qui suit montre comment déverrouiller des formes dans une présentation verrouillée.

```py
import aspose.slides as slides

#Open the desired presentation
with slides.Presentation("ProtectedSample.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            
            if type(shape) is slides.AutoShape: 
                auto_shape_lock = shape.shape_lock

                #Applying shapes locks
                auto_shape_lock.position_locked = False
                auto_shape_lock.select_locked = False
                auto_shape_lock.size_locked = False
            
            elif type(shape) is slides.GroupShape:  
                group_shape_lock = shape.shape_lock

                #Applying shapes locks
                group_shape_lock.grouping_locked = False
                group_shape_lock.position_locked = False
                group_shape_lock.select_locked = False
                group_shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                #Applying shapes locks
                connector_lock.position_move = False
                connector_lock.select_locked = False
                connector_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                picture_lock = shape.shape_lock

                #Applying shapes locks
                picture_lock.position_locked = False
                picture_lock.select_locked = False
                picture_lock.size_locked = False
    #Saving the presentation file
    pres.save("RemoveProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```



### **Résumé**
{{% alert color="primary" %}} 

Aspose.Slides propose plusieurs options pour appliquer une protection aux formes d'une présentation. Il est possible de verrouiller une forme particulière ou de parcourir toutes les formes d'une présentation et de les verrouiller toutes pour verrouiller efficacement la présentation.

Seule Aspose.Slides pour Python via .NET peut supprimer la protection d'une présentation qui a été précédemment protégée. Retirez la protection en définissant la valeur d'un verrou sur false.

{{% /alert %}} 