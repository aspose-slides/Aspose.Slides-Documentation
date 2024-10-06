---
title: Application de la protection à la présentation
type: docs
weight: 10
url: /cpp/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Un usage courant d'Aspose.Slides est de créer, mettre à jour et enregistrer des présentations Microsoft PowerPoint 2007 (PPTX) dans le cadre d'un flux de travail automatisé. Les utilisateurs de l'application qui utilise Aspose.Slides de cette manière ont accès aux présentations de sortie. Les protéger contre l'édition est une préoccupation courante. Il est important que les présentations générées automatiquement conservent leur formatage et leur contenu d'origine.

Cet article explique comment [les présentations et les diapositives sont construites](/slides/cpp/applying-protection-to-presentation/) et comment Aspose.Slides pour C++ peut [appliquer une protection à](/slides/cpp/applying-protection-to-presentation/), puis [la retirer de](/slides/cpp/applying-protection-to-presentation/) une présentation. Cette fonctionnalité est unique à Aspose.Slides et, au moment de la rédaction, n'est pas disponible dans Microsoft PowerPoint. Elle donne aux développeurs un moyen de contrôler l'utilisation des présentations créées par leurs applications.

{{% /alert %}} 
## **Composition d'une diapositive**
Une diapositive PPTX est composée de plusieurs composants tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d'image, des cadres vidéo, des connecteurs et divers autres éléments disponibles pour construire une présentation.

Dans Aspose.Slides pour C++, chaque élément sur une diapositive est transformé en un objet Shape. En d'autres termes, chaque élément sur la diapositive est soit un objet Shape soit un objet dérivé de l'objet Shape.

La structure de PPTX est complexe donc contrairement à PPT, où un verrou générique peut être utilisé pour tous les types de formes, il existe différents types de verrous pour différents types de formes. La classe BaseShapeLock est la classe de verrouillage générique pour PPTX. Les types de verrous suivants sont pris en charge dans Aspose.Slides pour C++ pour PPTX.

- AutoShapeLock verrouille les formes automatiques.
- ConnectorLock verrouille les formes connecteurs.
- GraphicalObjectLock verrouille les objets graphiques.
- GroupshapeLock verrouille les formes groupées.
- PictureFrameLock verrouille les cadres d'image.

Toute action effectuée sur tous les objets Shape dans un objet Presentation est appliquée à l'ensemble de la présentation.
## **Application et retrait de la protection**
L'application de la protection garantit qu'une présentation ne peut pas être éditée. C'est une technique utile pour protéger le contenu d'une présentation.
### **Application de la protection aux formes PPTX**
Aspose.Slides pour C++ fournit la classe Shape pour gérer une forme sur la diapositive.

Comme mentionné précédemment, chaque classe de forme a une classe de verrouillage associée pour la protection. Cet article se concentre sur les verrous NoSelect, NoMove et NoResize. Ces verrous garantissent que les formes ne peuvent pas être sélectionnées (par des clics de souris ou d'autres méthodes de sélection), et qu'elles ne peuvent pas être déplacées ou redimensionnées.

Les échantillons de code qui suivent appliquent la protection à tous les types de formes dans une présentation.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ApplyProtection-ApplyProtection.cpp" >}}

### **Retrait de la protection**
La protection appliquée à l'aide d'Aspose.Slides pour C++ ne peut être retirée qu'avec Aspose.Slides pour C++. Pour déverrouiller une forme, il suffit de définir la valeur du verrou appliqué sur false. L'échantillon de code qui suit montre comment déverrouiller des formes dans une présentation verrouillée.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-RemoveProtection-RemoveProtection.cpp" >}}
## **Résumé**
{{% alert color="primary" %}} 

Aspose.Slides offre un certain nombre d'options pour appliquer une protection aux formes dans une présentation. Il est possible de verrouiller une forme particulière, ou de parcourir toutes les formes dans une présentation et de les verrouiller toutes afin de verrouiller efficacement la présentation.

Seul Aspose.Slides pour C++ peut retirer la protection d'une présentation qu'il a protégée précédemment. Retirez la protection en définissant la valeur d'un verrou sur false.

{{% /alert %}} 
### **Articles connexes**
- La classe [ShapeEx](http://docs.aspose.com/display/slidesnet/ShapeEx+Class).
- La classe [BaseShapeLockEx](http://docs.aspose.com/display/slidesnet/BaseShapeLockEx+Class).