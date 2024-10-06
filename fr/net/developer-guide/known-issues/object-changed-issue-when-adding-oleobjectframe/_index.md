---
title: Problème d'Objet Changé Lors de l'Ajout d'OleObjectFrame
type: docs
weight: 10
url: /net/object-changed-issue-when-adding-oleobjectframe/
---

{{% alert color="primary" %}} 

En utilisant Aspose.Slides pour .NET, lorsque vous ajoutez **[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)** à une diapositive, un message **Objet Changé** est affiché sur la diapositive de sortie (et NON sur l'objet OLE). Le processus décrit est une action délibérée et NON un bug. 

Pour plus d'informations sur le travail avec des objets OLE, consultez [Gérer OLE](/slides/net/manage-ole/). 

{{% /alert %}} 
## **Explication** et Solution
Aspose.Slides affiche le message **Objet Changé** pour vous notifier que l'objet OLE a été modifié et que l'image de prévisualisation doit être mise à jour. 

Par exemple, si vous ajoutez un graphique Microsoft Excel en tant que **[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)** à une diapositive (pour plus de détails, voir l'article Gérer OLE) et que vous ouvrez ensuite la présentation dans l'application Microsoft PowerPoint, vous verrez cette image sur la diapositive :

~~Remplacer toutes les images par de nouvelles images~~

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

Si vous souhaitez vérifier et confirmer que votre objet OLE a été ajouté à la diapositive, vous devez double-cliquer sur le message **Objet Changé**, ou vous pouvez faire un clic droit dessus et accéder à **Objet de feuille de calcul > Option Modifier.**

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

PowerPoint ouvre alors l'objet OLE intégré

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)



La diapositive peut conserver le message **Objet Changé**. Une fois que vous cliquez sur l'objet OLE, la prévisualisation de la diapositive est mise à jour et le message **Objet Changé** est remplacé par l'image réelle de l'objet OLE. 

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

Maintenant, vous souhaiterez peut-être enregistrer votre présentation pour vous assurer que l'image de l'objet OLE est correctement mise à jour. De cette façon, après avoir enregistré la présentation, lorsque vous rouvrez la présentation, vous ne verrez PLUS le message **Objet Changé**. 

## **Autres Solutions**
### **Solution 1 : Remplacer le Message Objet Changé par une Image**

Si vous ne souhaitez pas retirer le message **Objet Changé** en ouvrant la présentation dans PowerPoint puis en l'enregistrant, vous pouvez remplacer le message par votre image de prévisualisation préférée. Ces lignes de code démontrent le processus :

``` csharp 
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
   ISlide slide = pres.Slides[0];
   IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];
    
   IPPImage oleImage = pres.Images.AddImage(File.ReadAllBytes("my_image.png"));
   oleObjectFrame.SubstitutePictureTitle = "Mon titre";
   oleObjectFrame.SubstitutePictureFormat.Picture.Image = oleImage;
   oleObjectFrame.IsObjectIcon = false;
    
   pres.Save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
}
```

La diapositive contenant le `OleObjectFrame` change alors en ceci :

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

### **Solution 2 : Créer un Add-On pour PowerPoint**
Vous pouvez également créer un add-on pour Microsoft PowerPoint qui met à jour tous les objets OLE lorsque vous ouvrez des présentations dans le programme.