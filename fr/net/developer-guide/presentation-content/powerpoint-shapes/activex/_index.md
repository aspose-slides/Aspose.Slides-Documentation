---
title: Gérer les contrôles ActiveX dans les présentations en .NET
linktitle: ActiveX
type: docs
weight: 80
url: /fr/net/activex/
keywords:
- ActiveX
- Contrôle ActiveX
- gérer ActiveX
- ajouter ActiveX
- modifier ActiveX
- lecteur multimédia
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour .NET exploite ActiveX pour automatiser et améliorer les présentations PowerPoint, offrant aux développeurs un contrôle puissant sur les diapositives."
---

Les contrôles ActiveX sont utilisés dans les présentations. Aspose.Slides pour .NET vous permet de gérer les contrôles ActiveX, mais leur gestion est un peu plus délicate et différente des formes classiques des présentations. À partir d’Aspose.Slides pour .NET 6.9.0, le composant prend en charge la gestion des contrôles ActiveX. Pour l’instant, vous pouvez accéder aux contrôles ActiveX déjà ajoutés dans votre présentation et les modifier ou les supprimer en utilisant leurs différentes propriétés. Rappelez‑vous que les contrôles ActiveX ne sont pas des formes et ne font pas partie de l’IShapeCollection de la présentation, mais de l’IControlCollection distincte. Cet article montre comment les manipuler.  

## **Modifier les contrôles ActiveX**
Pour gérer un contrôle ActiveX simple comme une zone de texte et un bouton de commande sur une diapositive :

1. Créez une instance de la classe Presentation et chargez la présentation contenant des contrôles ActiveX.  
2. Obtenez une référence à la diapositive par son indice.  
3. Accédez aux contrôles ActiveX de la diapositive en accédant à l’IControlCollection.  
4. Accédez au contrôle ActiveX TextBox1 à l’aide de l’objet ControlEx.  
5. Modifiez les différentes propriétés du contrôle ActiveX TextBox1, notamment le texte, la police, la hauteur de la police et la position du cadre.  
6. Accédez au second contrôle, appelé CommandButton1.  
7. Modifiez la légende du bouton, la police et la position.  
8. Déplacez la position des cadres des contrôles ActiveX.  
9. Enregistrez la présentation modifiée dans un fichier PPTX.  

Le fragment de code ci‑dessous met à jour les contrôles ActiveX des diapositives de la présentation comme illustré ci‑après.  
```c#
// Accéder à la présentation contenant des contrôles ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// Accéder à la première diapositive de la présentation
ISlide slide = presentation.Slides[0];

// Modification du texte de la zone de texte
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // Modification de l'image de substitution. PowerPoint remplacera cette image lors de l'activation ActiveX, il est donc parfois acceptable de laisser l'image inchangée.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Modification de la légende du bouton
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // Modification de la substitution
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Déplacement des cadres ActiveX de 100 points vers le bas
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Save the presentation with Edited ActiveX Controls
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Suppression des contrôles
slide.Controls.Clear();

// Enregistrement de la présentation avec les contrôles ActiveX supprimés
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **Ajouter un contrôle ActiveX Media Player**
Pour ajouter un contrôle ActiveX Media Player, suivez les étapes suivantes :

1. Créez une instance de la classe Presentation et chargez la présentation d’exemple contenant des contrôles Media Player ActiveX.  
2. Créez une instance de la classe Presentation cible et générez une instance de présentation vide.  
3. Clonez la diapositive contenant le contrôle Media Player ActiveX de la présentation modèle vers la présentation cible.  
4. Accédez à la diapositive clonée dans la présentation cible.  
5. Accédez aux contrôles ActiveX de la diapositive en accédant à l’IControlCollection.  
6. Accédez au contrôle Media Player ActiveX et définissez le chemin vidéo à l’aide de ses propriétés.  
7. Enregistrez la présentation dans un fichier PPTX.  
```c#
// Instancier la classe Presentation qui représente le fichier PPTX
Presentation presentation = new Presentation("template.pptx");

// Créer une instance de présentation vide
Presentation newPresentation = new Presentation();

// Supprimer la diapositive par défaut
newPresentation.Slides.RemoveAt(0);

// Cloner la diapositive avec le contrôle Media Player ActiveX
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Accéder au contrôle Media Player ActiveX et définir le chemin vidéo
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Enregistrer la présentation
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **FAQ**

**Aspose.Slides préserve‑t‑il les contrôles ActiveX lors de la lecture et de la réenregistrement s’ils ne peuvent pas être exécutés dans le runtime .NET ?**

Oui. Aspose.Slides les considère comme faisant partie de la présentation et peut lire/modifier leurs propriétés et cadres ; l’exécution des contrôles eux‑mêmes n’est pas requise pour les conserver.

**En quoi les contrôles ActiveX diffèrent‑ils des objets OLE dans une présentation ?**

Les contrôles ActiveX sont des contrôles interactifs gérés (boutons, zones de texte, lecteur multimédia), alors que [OLE](/slides/fr/net/manage-ole/) désigne des objets d’application embarqués (par exemple, une feuille de calcul Excel). Ils sont stockés et manipulés différemment et possèdent des modèles de propriétés distincts.

**Les événements ActiveX et les macros VBA fonctionnent‑ils si le fichier a été modifié par Aspose.Slides ?**

Aspose.Slides préserve le balisage et les métadonnées existants ; toutefois, les événements et les macros ne s’exécutent que dans PowerPoint sous Windows lorsque la sécurité le permet. La bibliothèque n’exécute pas le VBA.