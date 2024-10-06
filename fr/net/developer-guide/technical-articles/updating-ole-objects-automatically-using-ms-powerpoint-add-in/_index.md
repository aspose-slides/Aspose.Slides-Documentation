---  
title: Mise à jour automatique des objets OLE à l'aide d'un complément MS PowerPoint  
type: docs  
weight: 10  
url: /net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/  
---  

## **À propos de la mise à jour automatique des objets OLE**  
L'une des questions les plus fréquentes posées par les clients d'Aspose.Slides pour .NET est comment créer ou modifier des graphiques modifiables ou tout autre objet OLE et les faire mettre à jour automatiquement lors de l'ouverture de la présentation. Malheureusement, PowerPoint ne prend pas en charge les macros automatiques, qui sont disponibles dans Excel et Word. Les seules disponibles sont les macros Auto_Open et Auto_Close. Cependant, celles-ci ne s'exécutent automatiquement que depuis un complément. Ce bref conseil technique montre comment y parvenir.  

Tout d'abord, plusieurs compléments gratuits ajoutent la fonctionnalité de macro Auto_Open à PowerPoint, par exemple [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) et [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).  

Après avoir installé un tel complément, il suffit d'ajouter la macro Auto_Open() (OnPresentationOpen() dans le cas de "Event Generator") à votre présentation modèle comme indiqué ci-dessous :  

```c#  
public void Auto_Open()  
{  
    Shape oShape;  
    Slide oSlide;  
    object oGraph;  

    // Boucle à travers chaque diapositive de la présentation.  
    foreach (var oSlide in ActivePresentation.Slides)  
    {  

        // Boucle à travers toutes les formes de la diapositive actuelle.  
        foreach (var oShape in oSlide.Shapes)  
        {  

            // Vérifier si la forme est un objet OLE.  
            if (oShape.Type == msoEmbeddedOLEObject)  
            {  

                // Objet OLE trouvé ; obtenir la référence de l'objet, puis mettre à jour.  
                oObject = oShape.OLEFormat.Object;  
                oObject.Application.Update();  

                // Maintenant, quittez le programme serveur OLE. Cela libère  
                // de la mémoire et prévient tout problème. De plus, mettez oObject égal  
                // à Nothing pour libérer l'objet.  
                oObject.Application.Quit();  
                oObject = null;  
            }  
        }  
    }  
}  
```  

{{% alert color="primary" %}}  

Tout changement apporté aux objets OLE avec Aspose.Slides pour .NET sera mis à jour automatiquement lorsque PowerPoint ouvrira la présentation. Si vous avez de nombreux objets OLE dans une présentation et que vous ne souhaitez pas tous les mettre à jour, il suffit d'ajouter une balise personnalisée aux formes que vous devez traiter et de la vérifier dans la macro.  

{{% /alert %}}  