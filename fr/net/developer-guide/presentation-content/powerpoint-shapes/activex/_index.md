---
title: Gérer les contrôles ActiveX dans les présentations en .NET
linktitle: ActiveX
type: docs
weight: 80
url: /fr/net/activex/
keywords:
- ActiveX
- contrôle ActiveX
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

Les contrôles ActiveX sont utilisés dans les présentations. Aspose.Slides pour .NET vous permet de gérer les contrôles ActiveX, mais leur gestion est un peu plus délicate et différente des formes normales des présentations. À partir d'Aspose.Slides pour .NET 6.9.0, le composant prend en charge la gestion des contrôles ActiveX. Pour le moment, vous pouvez accéder aux contrôles ActiveX déjà ajoutés dans votre présentation et les modifier ou les supprimer en utilisant leurs différentes propriétés. Gardez à l'esprit que les contrôles ActiveX ne sont pas des formes et ne font pas partie de l'IShapeCollection de la présentation, mais du IControlCollection distinct. Cet article montre comment les utiliser.
## **Modifier les contrôles ActiveX**
1. Créez une instance de la classe Presentation et chargez la présentation contenant des contrôles ActiveX.
1. Obtenez une référence de diapositive par son index.
1. Accédez aux contrôles ActiveX dans la diapositive en accédant à l'IControlCollection.
1. Accédez au contrôle ActiveX TextBox1 en utilisant l'objet ControlEx.
1. Modifiez les différentes propriétés du contrôle ActiveX TextBox1, y compris le texte, la police, la hauteur de police et la position du cadre.
1. Accédez au deuxième contrôle d'accès appelé CommandButton1.
1. Modifiez la légende du bouton, la police et la position.
1. Décalez la position des cadres des contrôles ActiveX.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

Le fragment de code ci-dessous met à jour les contrôles ActiveX sur les diapositives de la présentation comme indiqué ci-dessous.
```c#
// Accéder à la présentation avec des contrôles ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// Accéder à la première diapositive de la présentation
ISlide slide = presentation.Slides[0];

// modification du texte du TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // modification de l'image de substitution. PowerPoint remplacera cette image lors de l'activation d'ActiveX, il est donc parfois acceptable de laisser l'image inchangée.

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

// modification du texte du Button caption
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // modification de la substitution
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

// déplacement des cadres ActiveX de 100 points vers le bas
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Save the presentation with Edited ActiveX Controls
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// suppression des contrôles
slide.Controls.Clear();

// enregistrement de la présentation avec les contrôles ActiveX supprimés
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **Ajouter le contrôle ActiveX Media Player**
1. Créez une instance de la classe Presentation et chargez la présentation d'exemple contenant des contrôles ActiveX Media Player.
1. Créez une instance de la classe Presentation cible et générez une instance de présentation vide.
1. Clonez la diapositive contenant le contrôle ActiveX Media Player de la présentation modèle vers la présentation cible.
1. Accédez à la diapositive clonée dans la présentation cible.
1. Accédez aux contrôles ActiveX dans la diapositive en accédant à l'IControlCollection.
1. Accédez au contrôle ActiveX Media Player et définissez le chemin vidéo en utilisant ses propriétés.
1. Enregistrez la présentation dans un fichier PPTX.
```c#
// Instancie la classe Presentation qui représente le fichier PPTX
Presentation presentation = new Presentation("template.pptx");

// Crée une instance de présentation vide
Presentation newPresentation = new Presentation();

// Supprime la diapositive par défaut
newPresentation.Slides.RemoveAt(0);

// Clone la diapositive avec le contrôle ActiveX Media Player
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Accède au contrôle ActiveX Media Player et définit le chemin de la vidéo
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Enregistre la présentation
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **FAQ**

**Aspose.Slides conserve-t-il les contrôles ActiveX lors de la lecture et du réenregistrement s'ils ne peuvent pas être exécutés dans l'environnement Python ?**

Oui. Aspose.Slides les considère comme faisant partie de la présentation et peut lire/modifier leurs propriétés et leurs cadres ; l'exécution des contrôles eux‑mêmes n'est pas nécessaire pour les conserver.

**En quoi les contrôles ActiveX diffèrent-ils des objets OLE dans une présentation ?**

Les contrôles ActiveX sont des contrôles interactifs gérés (boutons, zones de texte, lecteur multimédia), tandis que [OLE](/slides/fr/net/manage-ole/) désigne des objets d'application intégrés (par exemple, une feuille de calcul Excel). Ils sont stockés et gérés différemment et possèdent des modèles de propriétés différents.

**Les événements ActiveX et les macros VBA fonctionnent-ils si le fichier a été modifié par Aspose.Slides ?**

Aspose.Slides conserve le balisage et les métadonnées existants ; cependant, les événements et les macros ne s'exécutent que dans PowerPoint sous Windows lorsque la sécurité le permet. La bibliothèque n'exécute pas le VBA.