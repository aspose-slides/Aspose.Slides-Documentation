---
title: Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame
linktitle: Problème d'objet OLE
type: docs
weight: 10
url: /fr/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problème d'aperçu
- objet incorporé
- fichier incorporé
- objet modifié
- aperçu de l'objet
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Découvrez pourquoi le message EMBEDDED OLE OBJECT apparaît lors de l'ajout d'OleObjectFrame dans Aspose.Slides pour Java et comment résoudre les problèmes d'aperçu dans les présentations PPT, PPTX et ODP."
---
## **Introduction**

En utilisant Aspose.Slides pour Java, lorsque vous ajoutez [OleObjectFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/oleobjectframe/) à une diapositive, un message « EMBEDDED OLE OBJECT » s’affiche sur la diapositive de sortie. Ce message est intentionnel et n’est PAS un bug.

Pour plus d’informations sur la manipulation des objets OLE, consultez [Manage OLE](/slides/fr/java/manage-ole/). 

## **Explication et solution**

Aspose.Slides affiche le message « EMBEDDED OLE OBJECT » pour vous informer que l’objet OLE a été modifié et que l’image d’aperçu doit être mise à jour. 

Par exemple, si vous ajoutez un graphique Microsoft Excel comme [OleObjectFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/oleobjectframe/) à une diapositive (pour plus de détails, voir l’article « Manage OLE ») puis ouvrez la présentation dans Microsoft PowerPoint, vous verrez cette image sur la diapositive :

![Message d’objet OLE](OLE_object_message.png)

Si vous voulez vérifier et confirmer que votre objet OLE a bien été ajouté à la diapositive, vous devez double‑cliquer sur le message « EMBEDDED OLE OBJECT », ou vous pouvez faire un clic droit dessus et choisir l’option **Object > Edit**.

![Objet OLE > Modifier](OLE_object_edit.png)

PowerPoint ouvre alors l’objet OLE incorporé.

![Données de l’objet OLE](OLE_object_data.png)

La diapositive peut conserver le message « EMBEDDED OLE OBJECT ». Une fois que vous cliquez sur l’objet OLE, l’aperçu de la diapositive est mis à jour et le message « EMBEDDED OLE OBJECT » est remplacé par l’image réelle de l’objet OLE. 

![Aperçu de l’objet OLE](OLE_object_preview.png)

Vous pouvez maintenant enregistrer votre présentation afin que l’image de l’objet OLE soit correctement mise à jour. Ainsi, après avoir enregistré la présentation, lorsque vous l’ouvrirez à nouveau, vous ne verrez plus le message « EMBEDDED OLE OBJECT ». 

## **Autre solution**

Si vous ne voulez pas supprimer le message « EMBEDDED OLE OBJECT » en ouvrant la présentation dans PowerPoint puis en l’enregistrant, vous pouvez remplacer le message par votre image d’aperçu préférée. Ces lignes de code illustrent le processus :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Ajouter une image aux ressources de la présentation.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Définir un titre et l'image pour l'aperçu de l'objet OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

La diapositive contenant le `OleObjectFrame` devient alors :

![Nouvelle image d’objet OLE](OLE_object_new_image.png)