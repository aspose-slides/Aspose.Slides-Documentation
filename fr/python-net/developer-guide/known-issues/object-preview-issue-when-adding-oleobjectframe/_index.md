---
title: "Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame"
linktitle: "Problème d'objet OLE"
type: docs
weight: 10
url: /fr/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problème d'aperçu
- objet intégré
- fichier intégré
- objet modifié
- aperçu de l'objet
- présentation
- PowerPoint
- Python
- Aspose.Slides
description: "Découvrez pourquoi le message EMBEDDED OLE OBJECT apparaît lors de l'ajout d'OleObjectFrame dans Aspose.Slides pour Python et comment résoudre les problèmes d'aperçu dans les présentations PPT, PPTX et ODP."
---

## **Introduction**

En utilisant Aspose.Slides pour Python via .NET, lorsque vous ajoutez [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) à une diapositive, un message "EMBEDDED OLE OBJECT" apparaît sur la diapositive générée. Ce message est intentionnel et NOT a bug.

Pour plus d'informations sur la manipulation des objets OLE, consultez [Manage OLE](/slides/fr/python-net/manage-ole/). 

## **Explication et solution**

Aspose.Slides affiche le message "EMBEDDED OLE OBJECT" pour vous indiquer que l'objet OLE a été modifié et que l'image d'aperçu doit être mise à jour. 

Par exemple, si vous ajoutez un Microsoft Excel сhart en tant qu[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) à une diapositive (pour plus de détails, consultez l'article "Manage OLE") puis ouvrez la présentation dans Microsoft PowerPoint, vous verrez cette image sur la diapositive :

![OLE object message](OLE_object_message.png)

Si vous souhaitez vérifier et confirmer que votre objet OLE a été ajouté à la diapositive, vous devez double-cliquer sur le message "EMBEDDED OLE OBJECT", ou vous pouvez faire un clic droit dessus et choisir l'option **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint ouvre alors l'objet OLE intégré.

![OLE object data](OLE_object_data.png)

La diapositive peut conserver le message "EMBEDDED OLE OBJECT". Une fois que vous cliquez sur l'objet OLE, l'aperçu de la diapositive est mis à jour et le message "EMBEDDED OLE OBJECT" est remplacé par l'image réelle de l'objet OLE. 

![OLE object preview](OLE_object_preview.png)

Vous pouvez maintenant enregistrer votre présentation pour vous assurer que l'image de l'objet OLE est correctement mise à jour. Ainsi, après avoir enregistré la présentation, lorsque vous la rouvrez, vous ne verrez NOT le message "EMBEDDED OLE OBJECT". 

## **Autres solutions**

### **Solution 1 : Remplacer le message "Embedded OLE Object" par une image**

Si vous ne souhaitez pas supprimer le message "EMBEDDED OLE OBJECT" en ouvrant la présentation dans PowerPoint puis en l'enregistrant, vous pouvez remplacer le message par votre image d'aperçu préférée. Les lignes de code suivantes illustrent le processus :
```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Ajouter une image aux ressources de la présentation.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Définir un titre et l'image pour l'aperçu de l'objet OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```


La diapositive contenant le `OleObjectFrame` devient alors :

![New OLE object image](OLE_object_new_image.png)

### **Solution 2 : Créer un add‑on pour PowerPoint**

Vous pouvez également créer un add‑on pour Microsoft PowerPoint qui met à jour tous les objets OLE lorsque vous ouvrez des présentations dans le programme.