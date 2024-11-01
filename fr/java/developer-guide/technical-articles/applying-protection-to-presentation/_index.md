---
title: Application de la Protection à la Présentation
type: docs
weight: 60
url: /fr/java/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Un usage courant d'Aspose.Slides est de créer, mettre à jour et enregistrer des présentations Microsoft PowerPoint 2007 (PPTX) dans le cadre d'un flux de travail automatisé. Les utilisateurs de l'application utilisant Aspose.Slides de cette manière ont accès aux présentations générées. Les protéger contre la modification est une préoccupation commune. Il est important que les présentations générées automatiquement conservent leur formatage et leur contenu d'origine.

Cet article explique comment [les présentations et les diapositives sont construites](/slides/fr/java/applying-protection-to-presentation/) et comment Aspose.Slides pour Java peut [appliquer une protection à](/slides/fr/java/applying-protection-to-presentation/) et ensuite [la retirer de](/slides/fr/java/applying-protection-to-presentation/) une présentation. Cette fonctionnalité est unique à Aspose.Slides et, au moment de la rédaction, n'est pas disponible dans Microsoft PowerPoint. Elle offre aux développeurs un moyen de contrôler comment les présentations créées par leurs applications sont utilisées.

{{% /alert %}} 
## **Composition d'une Diapositive**
Une diapositive PPTX est composée de plusieurs composants comme des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d'image, des cadres vidéo, des connecteurs et divers autres éléments disponibles pour construire une présentation. Dans Aspose.Slides pour Java, chaque élément sur une diapositive est transformé en un objet Shape. En d'autres termes, chaque élément sur la diapositive est soit un objet Shape soit un objet dérivé de l'objet Shape. La structure du PPTX est complexe, donc contrairement au PPT, où un verrou général peut être utilisé pour tous les types de formes, il existe différents types de verrous pour différents types de formes. La classe BaseShapeLock est la classe de verrouillage générique pour PPTX. Les types de verrous suivants sont supportés dans Aspose.Slides pour Java pour PPTX.

- AutoShapeLock verrouille les formes automatiques.
- ConnectorLock verrouille les formes connecteurs.
- GraphicalObjectLock verrouille les objets graphiques.
- GroupshapeLock verrouille les formes groupées.
- PictureFrameLock verrouille les cadres d'image.
  Toute action effectuée sur tous les objets Shape dans un objet Présentation est appliquée à l'ensemble de la présentation.
## **Application et Retrait de la Protection**
Appliquer une protection garantit qu'une présentation ne peut pas être modifiée. C'est une technique utile pour protéger le contenu d'une présentation.
## **Application de la Protection aux Formes PPTX**
Aspose.Slides pour Java fournit la classe Shape pour gérer une forme sur la diapositive.

Comme mentionné précédemment, chaque classe de forme a une classe de verrouillage de forme associée pour la protection. Cet article se concentre sur les verrous NoSelect, NoMove et NoResize. Ces verrous garantissent que les formes ne peuvent pas être sélectionnées (par des clics de souris ou d'autres méthodes de sélection), et qu'elles ne peuvent pas être déplacées ou redimensionnées.

Les exemples de code qui suivent appliquent une protection à tous les types de formes dans une présentation.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-ApplyProtection-ApplyProtection.java" >}}
## **Retrait de la Protection**
La protection appliquée à l'aide d'Aspose.Slides pour .NET/Java ne peut être retirée qu'avec Aspose.Slides pour .NET/Java. Pour déverrouiller une forme, définissez la valeur du verrou appliqué sur faux. L'exemple de code qui suit montre comment déverrouiller des formes dans une présentation verrouillée.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-RemoveProtection-RemoveProtection.java" >}}




## **Résumé**
{{% alert color="primary" %}} 

Aspose.Slides fournit plusieurs options pour appliquer une protection aux formes d'une présentation. Il est possible de verrouiller une forme particulière, ou de parcourir toutes les formes d'une présentation et de les verrouiller toutes pour effectivement verrouiller la présentation. Seul Aspose.Slides pour Java peut retirer la protection d'une présentation qu'il a précédemment protégée. Retirez la protection en définissant la valeur d'un verrou sur faux.

{{% /alert %}}