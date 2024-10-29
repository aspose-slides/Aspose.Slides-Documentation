---
title: Appliquer la Protection à la Présentation
type: docs
weight: 60
url: /fr/php-java/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Une utilisation courante d'Aspose.Slides est de créer, mettre à jour et enregistrer des présentations Microsoft PowerPoint 2007 (PPTX) dans le cadre d'un flux de travail automatisé. Les utilisateurs de l'application qui utilise Aspose.Slides de cette manière ont accès aux présentations produites. Les protéger de l'édition est une préoccupation courante. Il est important que les présentations auto-générées conservent leur formatage et leur contenu d'origine.

Cet article explique comment [les présentations et les diapositives sont construites](/slides/fr/php-java/applying-protection-to-presentation/) et comment Aspose.Slides pour PHP via Java peut [appliquer une protection à](/slides/fr/php-java/applying-protection-to-presentation/), et ensuite [la retirer de](/slides/fr/php-java/applying-protection-to-presentation/) une présentation. Cette fonctionnalité est unique à Aspose.Slides et, au moment de l'écriture, n'est pas disponible dans Microsoft PowerPoint. Elle offre aux développeurs un moyen de contrôler comment les présentations créées par leurs applications sont utilisées.

{{% /alert %}} 
## **Composition d'une Diapositive**
Une diapositive PPTX est composée de plusieurs composants tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d'image, des cadres vidéo, des connecteurs et divers autres éléments disponibles pour construire une présentation. Dans Aspose.Slides pour PHP via Java, chaque élément d'une diapositive est transformé en objet Shape. En d'autres termes, chaque élément de la diapositive est soit un objet Shape, soit un objet dérivé de l'objet Shape. La structure de PPTX est complexe, donc à la différence de PPT, où un verrou générique peut être utilisé pour tous les types de formes, il existe différents types de verrous pour différents types de formes. La classe BaseShapeLock est la classe de verrouillage générique pour PPTX. Les types de verrous suivants sont pris en charge dans Aspose.Slides pour PHP via Java pour PPTX.

- AutoShapeLock verrouille les formes automatiques.
- ConnectorLock verrouille les formes connecteurs.
- GraphicalObjectLock verrouille les objets graphiques.
- GroupshapeLock verrouille les formes groupées.
- PictureFrameLock verrouille les cadres d'image.
  Toute action effectuée sur tous les objets Shape dans un objet Presentation est appliquée à l'ensemble de la présentation.
## **Application et Suppression de Protection**
L'application de protection garantit qu'une présentation ne peut pas être éditée. C'est une technique utile pour protéger le contenu d'une présentation.
## **Application de la Protection aux Formes PPTX**
Aspose.Slides pour PHP via Java fournit la classe Shape pour gérer une forme sur la diapositive.

Comme mentionné précédemment, chaque classe de forme a une classe de verrou associé pour la protection. Cet article se concentre sur les verrous NoSelect, NoMove et NoResize. Ces verrous garantissent que les formes ne peuvent pas être sélectionnées (via des clics de souris ou d'autres méthodes de sélection), et qu'elles ne peuvent pas être déplacées ou redimensionnées.

Les exemples de code qui suivent appliquent une protection à tous les types de formes dans une présentation.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-ApplyProtection-ApplyProtection.java" >}}
## **Suppression de la Protection**
La protection appliquée à l'aide d'Aspose.Slides pour .NET/Java ne peut être retirée qu'avec Aspose.Slides pour .NET/Java. Pour déverrouiller une forme, définissez la valeur du verrou appliqué sur faux. L'exemple de code qui suit montre comment déverrouiller des formes dans une présentation verrouillée.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-RemoveProtection-RemoveProtection.java" >}}




## **Résumé**
{{% alert color="primary" %}} 

Aspose.Slides fournit plusieurs options pour appliquer une protection aux formes dans une présentation. Il est possible de verrouiller une forme particulière, ou de parcourir toutes les formes dans une présentation et de les verrouiller toutes pour verrouiller effectivement la présentation. Seule Aspose.Slides pour PHP via Java peut retirer la protection d'une présentation qui a été précédemment protégée. Retirez la protection en définissant la valeur d'un verrou sur faux.

{{% /alert %}}