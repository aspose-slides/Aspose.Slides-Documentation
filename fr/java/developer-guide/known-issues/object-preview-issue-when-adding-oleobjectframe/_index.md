---
title: Espace réservé d'aperçu d'objet lors de l'ajout d'OleObjectFrame
linktitle: Espace réservé d'aperçu OLE
type: docs
weight: 10
url: /fr/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problème d'aperçu
- espace réservé d'aperçu
- par conception
- objet incorporé
- fichier incorporé
- objet modifié
- aperçu d'objet
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Pourquoi un objet OLE ajouté avec Aspose.Slides pour Java affiche un espace réservé EMBEDDED OLE OBJECT jusqu'à ce que son aperçu soit mis à jour, et comment définir votre propre image d'aperçu."
---
## **Introduction**

En utilisant Aspose.Slides for Java, lorsque vous ajoutez un [OleObjectFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/oleobjectframe/) à une diapositive, le message « EMBEDDED OLE OBJECT » apparaît sur la diapositive résultante. Ce message est intentionnel et **n’est pas** un bug.

Pour plus d’informations sur la gestion des objets OLE, consultez [Manage OLE](/slides/fr/java/manage-ole/).

## **Explication et solution**

Aspose.Slides affiche le message « EMBEDDED OLE OBJECT » pour vous indiquer que l’objet OLE a été modifié et que l’image d’aperçu doit être mise à jour.

Par exemple, si vous ajoutez un graphique Microsoft Excel en tant qu’[OleObjectFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/oleobjectframe/) à une diapositive (voir l’article « Manage OLE » pour plus de détails) puis ouvrez la présentation dans Microsoft PowerPoint, vous verrez cette image sur la diapositive :

![Message d'objet OLE](OLE_object_message.png)

Si vous voulez vérifier et confirmer que votre objet OLE a bien été ajouté à la diapositive, double‑cliquez sur le message « EMBEDDED OLE OBJECT », ou faites un clic droit dessus et choisissez l’option **Objet > Modifier**.

![Objet OLE > Modifier](OLE_object_edit.png)

PowerPoint ouvre alors l’objet OLE incorporé.

![Données de l'objet OLE](OLE_object_data.png)

La diapositive peut conserver le message « EMBEDDED OLE OBJECT ». Dès que vous cliquez sur l’objet OLE, l’aperçu de la diapositive est mis à jour et le message « EMBEDDED OLE OBJECT » est remplacé par l’image réelle de l’objet OLE.

![Aperçu de l'objet OLE](OLE_object_preview.png)

Vous pouvez alors enregistrer votre présentation afin que l’image de l’objet OLE soit correctement mise à jour. Ainsi, après avoir enregistré la présentation, lors de la prochaine ouverture, vous ne verrez **pas** le message « EMBEDDED OLE OBJECT ».

## **Autre solution**

Si vous ne souhaitez pas supprimer le message « EMBEDDED OLE OBJECT » en ouvrant la présentation dans PowerPoint puis en l’enregistrant, vous pouvez remplacer le message par votre image d’aperçu préférée. Ces lignes de code illustrent le processus. Elles supposent que la première forme de la première diapositive de *embeddedOLE.pptx* est le cadre d’objet OLE et que *myImage.png* contient l’image à afficher, et elles enregistrent le résultat sous *embeddedOLE-newImage.pptx* :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Ajouter une image aux ressources de la présentation.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // Définir l'image pour l'aperçu de l'objet OLE.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La diapositive contenant le `OleObjectFrame` devient alors :

![Nouvelle image d'objet OLE](OLE_object_new_image.png)