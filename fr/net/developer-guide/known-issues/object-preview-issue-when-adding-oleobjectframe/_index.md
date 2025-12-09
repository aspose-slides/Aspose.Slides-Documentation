---
title: "Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame"
linktitle: "Problème d'objet OLE"
type: docs
weight: 10
url: /fr/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problème d'aperçu
- objet incorporé
- fichier incorporé
- objet modifié
- aperçu d'objet
- présentation
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Apprenez pourquoi le message EMBEDDED OLE OBJECT apparaît lors de l'ajout d'OleObjectFrame dans Aspose.Slides pour .NET et comment résoudre les problèmes d'aperçu dans les présentations PPT, PPTX et ODP."
---

## **Introduction**

En utilisant Aspose.Slides pour .NET, lorsque vous ajoutez [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) à une diapositive, un message "EMBEDDED OLE OBJECT" s'affiche sur la diapositive de sortie. Ce message est intentionnel et N'EST PAS un bogue.

Pour plus d'informations sur la manipulation des objets OLE, voir [Manage OLE](/slides/fr/net/manage-ole/). 

## **Explication et solution**

Aspose.Slides affiche le message "EMBEDDED OLE OBJECT" pour vous informer que l'objet OLE a été modifié et que l'image d'aperçu doit être mise à jour. 

Par exemple, si vous ajoutez un graphique Microsoft Excel en tant qu'[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) à une diapositive (pour plus de détails, voir l'article "Manage OLE") puis ouvrez la présentation dans Microsoft PowerPoint, vous verrez cette image sur la diapositive :

![OLE object message](OLE_object_message.png)

Si vous souhaitez vérifier et confirmer que votre objet OLE a été ajouté à la diapositive, vous devez double‑cliquer sur le message "EMBEDDED OLE OBJECT", ou vous pouvez faire un clic droit dessus et choisir l'option **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint ouvre alors l'objet OLE intégré.

![OLE object data](OLE_object_data.png)

La diapositive peut conserver le message "EMBEDDED OLE OBJECT". Une fois que vous cliquez sur l'objet OLE, l'aperçu de la diapositive est mis à jour et le message "EMBEDDED OLE OBJECT" est remplacé par l'image réelle de l'objet OLE. 

![OLE object preview](OLE_object_preview.png)

À présent, vous pouvez vouloir enregistrer votre présentation pour vous assurer que l'image de l'objet OLE est correctement mise à jour. Ainsi, après avoir enregistré la présentation, lorsque vous la rouvrirez, vous ne verrez PAS le message "EMBEDDED OLE OBJECT". 

## **Autres solutions**

### **Solution 1 : remplacer le message "Embedded OLE Object" par une image**

Si vous ne souhaitez pas supprimer le message "EMBEDDED OLE OBJECT" en ouvrant la présentation dans PowerPoint puis en l'enregistrant, vous pouvez remplacer le message par l'image d'aperçu de votre choix. Ces lignes de code illustrent le processus :
```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```


La diapositive contenant le `OleObjectFrame` devient alors :

![New OLE object image](OLE_object_new_image.png)

### **Solution 2 : créer un add‑on pour PowerPoint**

Vous pouvez également créer un add‑on pour Microsoft PowerPoint qui met à jour tous les objets OLE lorsque vous ouvrez des présentations dans le programme.