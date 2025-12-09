---
title: Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame
linktitle: Problème d'objet OLE
type: docs
weight: 10
url: /fr/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problème d'aperçu
- objet intégré
- fichier intégré
- objet modifié
- aperçu d'objet
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Découvrez pourquoi EMBEDDED OLE OBJECT apparaît lors de l'ajout d'OleObjectFrame dans Aspose.Slides for Java et comment corriger les problèmes d'aperçu dans les présentations PPT, PPTX et ODP."
---

## **Introduction**

En utilisant Aspose.Slides for Java, lorsque vous ajoutez un [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe/) à une diapositive, le message «EMBEDDED OLE OBJECT» apparaît sur la diapositive de sortie. Ce message est intentionnel et n’est pas un bug.

Pour plus d’informations sur la manipulation des objets OLE, consultez [Gérer OLE](/slides/fr/java/manage-ole/).

## **Explication et solution**

Aspose.Slides affiche le message «EMBEDDED OLE OBJECT» pour vous indiquer que l’objet OLE a été modifié et que l’image de prévisualisation doit être mise à jour.

Par exemple, si vous ajoutez un graphique Microsoft Excel en tant que [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe/) à une diapositive (pour plus de détails, voir l’article «Gérer OLE») puis ouvrez la présentation dans Microsoft PowerPoint, vous verrez cette image sur la diapositive :

![Message d'objet OLE](OLE_object_message.png)

Si vous souhaitez vérifier et confirmer que votre objet OLE a bien été ajouté à la diapositive, vous devez double-cliquer sur le message «EMBEDDED OLE OBJECT», ou faire un clic droit dessus et choisir l’option **Objet > Modifier**.

![Objet OLE > Modifier](OLE_object_edit.png)

PowerPoint ouvre alors l’objet OLE intégré.

![Données de l'objet OLE](OLE_object_data.png)

La diapositive peut conserver le message «EMBEDDED OLE OBJECT». Une fois que vous cliquez sur l’objet OLE, la prévisualisation de la diapositive est mise à jour et le message «EMBEDDED OLE OBJECT» est remplacé par l’image réelle de l’objet OLE.

![Prévisualisation de l'objet OLE](OLE_object_preview.png)

Vous pouvez maintenant enregistrer votre présentation pour vous assurer que l’image de l’objet OLE est correctement mise à jour. Ainsi, après avoir enregistré la présentation, lorsque vous l’ouvrirez à nouveau, vous ne verrez PAS le message «EMBEDDED OLE OBJECT».

## **Autres solutions**

### **Solution 1: Remplacer le message «Embedded OLE Object» par une image**

Si vous ne souhaitez pas supprimer le message «EMBEDDED OLE OBJECT» en ouvrant la présentation dans PowerPoint puis en l’enregistrant, vous pouvez remplacer le message par votre image de prévisualisation préférée. Ces lignes de code illustrent le processus :
```java
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

![Nouvelle image d'objet OLE](OLE_object_new_image.png)

### **Solution 2: Créer un module complémentaire pour PowerPoint**

Vous pouvez également créer un module complémentaire pour Microsoft PowerPoint qui met à jour tous les objets OLE lorsque vous ouvrez des présentations dans le programme.