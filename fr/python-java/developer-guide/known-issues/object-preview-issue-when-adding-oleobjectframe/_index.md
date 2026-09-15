---
title: Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame
linktitle: Problème d'objet OLE
type: docs
weight: 10
url: /fr/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problème d'aperçu
- objet incorporé
- fichier incorporé
- objet modifié
- aperçu de l'objet
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez pourquoi le message EMBEDDED OLE OBJECT apparaît lors de l'ajout d'OleObjectFrame dans Aspose.Slides pour Python via Java et comment corriger les problèmes d'aperçu dans les présentations PPT, PPTX et ODP."
---
## **Introduction**

Lorsque vous utilisez Aspose.Slides for Python via Java pour ajouter un [OleObjectFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/) à une diapositive, un message « EMBEDDED OLE OBJECT » apparaît sur la diapositive générée. Ce message est intentionnel et n’est pas un bug.

Pour plus d’informations sur la manipulation des objets OLE, voir [Manage OLE](/slides/fr/python-java/manage-ole/).

## **Explication et solution**

Aspose.Slides affiche le message « EMBEDDED OLE OBJECT » pour vous notifier que l’objet OLE a été modifié et que l’image d’aperçu doit être mise à jour.

Par exemple, si vous ajoutez un graphique Microsoft Excel en tant qu[OleObjectFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/) à une diapositive (pour plus de détails, voir l’article « Manage OLE »), puis ouvrez la présentation dans Microsoft PowerPoint, vous verrez cette image sur la diapositive :

![OLE object message](OLE_object_message.png)

Pour confirmer que votre objet OLE a bien été ajouté à la diapositive, double-cliquez sur le message « EMBEDDED OLE OBJECT », ou faites un clic droit dessus et choisissez **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint ouvre alors l’objet OLE intégré.

![OLE object data](OLE_object_data.png)

La diapositive peut conserver le message « EMBEDDED OLE OBJECT ». Une fois que vous cliquez sur l’objet OLE, l’aperçu de la diapositive est mis à jour et le message « EMBEDDED OLE OBJECT » est remplacé par l’image réelle de l’objet OLE.

![OLE object preview](OLE_object_preview.png)

Enregistrez votre présentation pour conserver l’image d’aperçu mise à jour de l’objet OLE. Lorsque vous rouvrirez la présentation, vous ne verrez plus le message « EMBEDDED OLE OBJECT ».

## **Autre solution**

Si vous ne souhaitez pas supprimer le message « EMBEDDED OLE OBJECT » en ouvrant la présentation dans PowerPoint puis en l’enregistrant, vous pouvez remplacer le message par l’image d’aperçu de votre choix. Le code suivant illustre le processus :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Ajouter une image aux ressources de la présentation.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Définir un titre et l'image pour l'aperçu de l'objet OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La diapositive contenant l[OleObjectFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/) se transforme alors en :

![New OLE object image](OLE_object_new_image.png)

## **FAQ**

**Pourquoi le message « EMBEDDED OLE OBJECT » apparaît‑il ?**

Le message indique que l’objet OLE a été modifié et que son image d’aperçu doit être mise à jour. Ce comportement est intentionnel.

**Comment mettre à jour l’aperçu dans PowerPoint ?**

Double‑cliquez sur le message ou choisissez **Object > Edit** pour ouvrir l’objet OLE intégré. Cliquez sur l’objet OLE pour mettre à jour l’aperçu, puis enregistrez la présentation.

**Puis‑je remplacer le message sans ouvrir la présentation dans PowerPoint ?**

Oui. Vous pouvez attribuer une image d’aperçu de votre choix à l’objet OLE, comme le montre l’exemple de code ci‑dessus.