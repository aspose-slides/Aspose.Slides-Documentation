---
title: Problème d'Objet Changé Lors de l'Ajout d'OleObjectFrame
type: docs
weight: 10
url: /androidjava/object-changed-issue-when-adding-oleobjectframe/
---

## **Déclaration du Problème**
Lorsque les développeurs ajoutent un **OleObjectFrame** à leurs diapositives en utilisant Aspose.Slides pour Android via Java, un message **Objet Changé** s'affiche sur la diapositive de sortie au lieu de l'**Objet OLE**. La plupart des clients d'Aspose.Slides pour Android via Java pensent qu'il s'agit d'un bug ou d'une erreur dans Aspose.Slides pour Android via Java.
## **Analyse et Explication Critiques**
Tout d'abord, il est important de savoir que le message **Objet Changé** affiché par Aspose.Slides pour Android via Java après l'ajout d'un **OleObjectFrame** dans la diapositive n'est **PAS** une erreur ou un bug dans Aspose.Slides pour Android via Java. C'est juste une information ou un message pour notifier les utilisateurs que l'objet est changé et que l'image doit être mise à jour.

Par exemple, si vous ajoutez un **Graphique Microsoft Excel** en tant qu'**OleObjectFrame** à votre diapositive (pour plus de détails et un extrait de code sur l'ajout d'un **OleObjectFrame** à votre diapositive, [cliquez ici](/slides/androidjava/adding-frame-to-the-slide/)) et ouvrez ensuite le fichier de présentation en utilisant MS PowerPoint, alors la diapositive (où l'**Objet OLE** a été ajouté) ressemblera à ceci :

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

**Figure** : Diapositive montrant le message **Objet Changé** après l'ajout de l'**Objet OLE**

Ce n'est pas une erreur et votre Objet OLE est toujours ajouté à la diapositive. Si vous souhaitez le tester, **Double-cliquez** sur le message **Objet Changé** ou **Cliquez avec le bouton droit** dessus et sélectionnez l'option **Objet Feuille de calcul -> Modifier**, comme montré ci-dessous dans la figure :

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

**Figure** : Sélection de l'option **Modifier** pour éditer l'**Objet OLE**

Après avoir sélectionné l'option **Modifier** dans le menu contextuel, vous verrez que l'**Objet OLE Intégré** deviendra visible sous forme modifiable comme montré ci-dessous :

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

**Figure** : **Objet OLE** sous forme modifiable

Vous pouvez toujours voir le message **Objet Changé** sur la diapositive dans le **Panneau de gauche** de MS PowerPoint qui affiche les aperçus des diapositives. Une fois que vous cliquez sur l'**Objet OLE**, vous verrez que l'aperçu de la diapositive sera également modifié et le message **Objet Changé** sera remplacé par l'image de l'**Objet OLE** comme montré ci-dessous :

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

**Figure** : Mise à jour de l'image de l'**Objet OLE**

Maintenant, vous devez **Enregistrer** votre fichier de présentation en utilisant MS PowerPoint afin que l'image de l'**Objet OLE** soit mise à jour. Une fois que vous avez enregistré votre présentation et que vous l'ouvrez à nouveau avec MS PowerPoint, vous verrez qu'il n'y aura plus de message **Objet Changé**.
## **Autres Solutions**
Dans l'analyse critique ci-dessus, nous avons démontré que l'image de l'**Objet OLE** peut être mise à jour en ouvrant le fichier de présentation dans MS PowerPoint puis en l'enregistrant. Mais, il existe deux autres solutions pour gérer le message **Objet Changé**.
## **1ère Solution : Remplacer le Message Objet Changé par une Image**
Si vous n'aimez pas le message **Objet Changé**, vous pouvez également remplacer ce message par votre propre image. Vous pouvez ajouter n'importe quelle image désirée à votre présentation, puis utiliser l'Id de cette image ajoutée pour remplacer le message **Objet Changé**.

Pour ce faire, vous pouvez ajouter ces quelques lignes de code dans votre application après avoir ajouté le **OleObjectFrame** à votre diapositive.
## **Exemple**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplacingObjectChangedMessageWithAnImage-ReplacingObjectChangedMessageWithAnImage.java" >}}

Après avoir ajouté les lignes ci-dessus dans votre application, la diapositive résultante contenant l'**OleObjectFrame** ressemblerait à ceci :

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

**Figure** : Message **Objet Changé** remplacé par une image
## **2ème Solution : Créer un Module Complémentaire pour MS PowerPoint**
Vous pouvez également essayer de créer un module complémentaire pour MS PowerPoint, qui met à jour tous les **Objets OLE** lorsque vous ouvrez la présentation dans MS PowerPoint.