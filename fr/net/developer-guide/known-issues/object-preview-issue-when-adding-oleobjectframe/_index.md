---
title: Placeholder d'aperçu d'objet lors de l'ajout d'OleObjectFrame
linktitle: Placeholder d'aperçu OLE
type: docs
weight: 10
url: /fr/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problème d'aperçu
- placeholder d'aperçu
- par conception
- objet incorporé
- fichier incorporé
- objet modifié
- aperçu de l'objet
- présentation
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Pourquoi un objet OLE ajouté avec Aspose.Slides pour .NET affiche un espace réservé EMBEDDED OLE OBJECT jusqu'à ce que son aperçu soit mis à jour, et comment définir votre propre image d'aperçu."
---
## **Introduction**

En utilisant Aspose.Slides for .NET, lorsque vous ajoutez [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/) à une diapositive, un message "EMBEDDED OLE OBJECT" est affiché sur la diapositive de sortie. Ce message est intentionnel et N'EST PAS un bug.

Pour plus d'informations sur la manipulation des objets OLE, voyez [Gérer OLE](/slides/fr/net/manage-ole/).

## **Explication et solution**

Aspose.Slides affiche le message "EMBEDDED OLE OBJECT" pour vous informer que l'objet OLE a été modifié et que l'image d'aperçu doit être mise à jour.

Par exemple, si vous ajoutez un graphique Microsoft Excel en tant qu'[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/) à une diapositive (pour plus de détails, voyez l'article "Manage OLE") puis ouvrez la présentation dans Microsoft PowerPoint, vous verrez cette image sur la diapositive :

![Message d'objet OLE](OLE_object_message.png)

Si vous souhaitez vérifier et confirmer que votre objet OLE a été ajouté à la diapositive, vous devez double-cliquer sur le message "EMBEDDED OLE OBJECT", ou vous pouvez faire un clic droit dessus et sélectionner l'option **Object > Edit**.

![Objet OLE > Modifier](OLE_object_edit.png)

PowerPoint ouvre alors l'objet OLE intégré.

![Données de l'objet OLE](OLE_object_data.png)

La diapositive peut conserver le message "EMBEDDED OLE OBJECT". Une fois que vous cliquez sur l'objet OLE, l'aperçu de la diapositive est mis à jour et le message "EMBEDDED OLE OBJECT" est remplacé par l'image réelle de l'objet OLE.

![Aperçu de l'objet OLE](OLE_object_preview.png)

Maintenant, vous pouvez vouloir enregistrer votre présentation pour vous assurer que l'image de l'objet OLE est correctement mise à jour. Ainsi, après avoir enregistré la présentation, lorsque vous l'ouvrirez à nouveau, vous ne verrez PAS le message "EMBEDDED OLE OBJECT".

## **Autres solutions**

### **Solution 1 : Remplacer le message « Embedded OLE Object » par une image**

Si vous ne souhaitez pas supprimer le message "EMBEDDED OLE OBJECT" en ouvrant la présentation dans PowerPoint puis en l'enregistrant, vous pouvez remplacer le message par l'image d'aperçu de votre choix. Ces lignes de code illustrent le processus :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set the image for the OLE object preview.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

La diapositive contenant le `OleObjectFrame` change alors en ceci :

![Nouvelle image d'objet OLE](OLE_object_new_image.png)

### **Solution 2 : Créer un module complémentaire pour PowerPoint**

Vous pouvez également créer un module complémentaire pour Microsoft PowerPoint qui met à jour tous les objets OLE lorsque vous ouvrez des présentations dans le programme.