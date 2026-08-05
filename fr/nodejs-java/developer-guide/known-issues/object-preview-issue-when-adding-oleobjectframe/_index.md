---
title: Problème d'aperçu de l'objet lors de l'ajout d'OleObjectFrame
linktitle: Problème d'objet OLE
type: docs
weight: 10
url: /fr/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problème d'aperçu
- objet incorporé
- fichier incorporé
- objet modifié
- aperçu de l'objet
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Découvrez pourquoi le message EMBEDDED OLE OBJECT apparaît lors de l'ajout d'OleObjectFrame dans Aspose.Slides pour Node.js et comment résoudre les problèmes d'aperçu dans les présentations PPT, PPTX et ODP."
---
## **Introduction**

Avec Aspose.Slides for Java, lorsque vous ajoutez [OleObjectFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/oleobjectframe/) à une diapositive, un message **\"EMBEDDED OLE OBJECT\"** s’affiche sur la diapositive de sortie. Ce message est intentionnel et N'EST PAS un bug.

Pour plus d’informations sur la manipulation des objets OLE, voir [Manage OLE](/slides/fr/nodejs-java/manage-ole/). 

## **Explication et solution**

Aspose.Slides affiche le message **\"EMBEDDED OLE OBJECT\"** pour vous informer que l’objet OLE a été modifié et que l’image d’aperçu doit être mise à jour. 

Par exemple, si vous ajoutez un graphique Microsoft Excel en tant qu[OleObjectFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/oleobjectframe/) à une diapositive (pour plus de détails, voir l’article « Manage OLE ») et que vous ouvrez ensuite la présentation dans Microsoft PowerPoint, vous verrez cette image sur la diapositive :

![Message d'objet OLE](OLE_object_message.png)

Si vous souhaitez vérifier et confirmer que votre objet OLE a bien été ajouté à la diapositive, vous devez double‑cliquer sur le message **\"EMBEDDED OLE OBJECT\"**, ou bien faire un clic droit dessus et choisir l’option **Object > Edit**.

![Objet OLE > Modifier](OLE_object_edit.png)

PowerPoint ouvre alors l’objet OLE incorporé.

![Données d’objet OLE](OLE_object_data.png)

La diapositive peut conserver le message **\"EMBEDDED OLE OBJECT\"**. Une fois que vous cliquez sur l’objet OLE, l’aperçu de la diapositive est mis à jour et le message **\"EMBEDDED OLE OBJECT\"** est remplacé par l’image réelle de l’objet OLE. 

![Aperçu d’objet OLE](OLE_object_preview.png)

Vous pouvez maintenant enregistrer votre présentation afin de vous assurer que l’image de l’objet OLE est correctement mise à jour. Ainsi, après avoir enregistré la présentation, lorsque vous l’ouvrirez de nouveau, vous ne verrez PAS le message **\"EMBEDDED OLE OBJECT\"**. 

## **Autres solutions**

### **Solution 1 : Remplacer le message « Embedded OLE Object » par une image**

Si vous ne souhaitez pas supprimer le message **\"EMBEDDED OLE OBJECT\"** en ouvrant la présentation dans PowerPoint puis en l’enregistrant, vous pouvez remplacer ce message par l’image d’aperçu de votre choix. Le code suivant illustre le processus :

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Ajouter une image aux ressources de la présentation.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Définir un titre et l'image pour l'aperçu de l'objet OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

La diapositive contenant le `OleObjectFrame` devient alors :

![Nouvelle image d’objet OLE](OLE_object_new_image.png)

### **Solution 2 : Créer un module complémentaire pour PowerPoint**

Vous pouvez également créer un module complémentaire pour Microsoft PowerPoint qui met à jour tous les objets OLE lors de l’ouverture des présentations dans le programme.