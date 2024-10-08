---
title: ActiveX
type: docs
weight: 80
url: /fr/net/activex/
keywords: "ActiveX, contrôles ActiveX, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Gérer les contrôles ActiveX dans une présentation PowerPoint en C# ou .NET"
---

Les contrôles ActiveX sont utilisés dans les présentations. Aspose.Slides pour .NET vous permet de gérer les contrôles ActiveX, mais leur gestion est un peu plus délicate et différente de celle des formes de présentation normales. À partir de Aspose.Slides pour .NET 6.9.0, le composant prend en charge la gestion des contrôles ActiveX. Pour le moment, vous pouvez accéder aux contrôles ActiveX déjà ajoutés dans votre présentation et les modifier ou les supprimer en utilisant leurs différentes propriétés. Rappelez-vous que les contrôles ActiveX ne sont pas des formes et ne font pas partie de la IShapeCollection de la présentation, mais de la IControlCollection distincte. Cet article montre comment travailler avec eux.
## **Modifier les contrôles ActiveX**
Pour gérer un contrôle ActiveX simple comme une zone de texte et un bouton de commande simple sur une diapositive :

1. Créez une instance de la classe Presentation et chargez la présentation contenant des contrôles ActiveX.
1. Obtenez une référence à la diapositive par son index.
1. Accédez aux contrôles ActiveX dans la diapositive en accédant à la IControlCollection.
1. Accédez au contrôle ActiveX TextBox1 en utilisant l'objet ControlEx.
1. Modifiez les différentes propriétés du contrôle ActiveX TextBox1, y compris le texte, la police, la hauteur de police et la position du cadre.
1. Accédez au deuxième contrôle d'accès appelé CommandButton1.
1. Changez le texte du bouton, la police et la position.
1. Déplacez la position des cadres des contrôles ActiveX.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Le fragment de code ci-dessous met à jour les contrôles ActiveX sur les diapositives de présentation comme indiqué ci-dessous.

```c#
// Accès à la présentation avec des contrôles ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// Accès à la première diapositive de la présentation
ISlide slide = presentation.Slides[0];

// modification du texte de TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Texte modifié";
    control.Properties["Value"] = newText;

    // modification de l'image de remplacement. PowerPoint remplacera cette image lors de l'activation ActiveX, il est donc parfois acceptable de laisser l'image inchangée.

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

// modification de la légende du bouton
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // modification de l'image de remplacement
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

// Enregistrer la présentation avec les contrôles ActiveX modifiés
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Maintenant, suppression des contrôles
slide.Controls.Clear();

// Enregistrer la présentation avec les contrôles ActiveX supprimés
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **Ajouter le contrôle ActiveX Media Player**
Pour ajouter le contrôle ActiveX Media Player, veuillez effectuer les étapes suivantes :

1. Créez une instance de la classe Presentation et chargez la présentation exemple avec des contrôles ActiveX Media Player.
1. Créez une instance de la classe Presentation cible et générez une instance de présentation vide.
1. Clonez la diapositive avec le contrôle ActiveX Media Player dans la présentation modèle vers la présentation cible.
1. Accédez à la diapositive clonée dans la présentation cible.
1. Accédez aux contrôles ActiveX dans la diapositive en accédant à la IControlCollection.
1. Accédez au contrôle ActiveX Media Player et définissez le chemin vidéo en utilisant ses propriétés.
1. Enregistrez la présentation dans un fichier PPTX.

```c#
// Instancier la classe Presentation qui représente le fichier PPTX
Presentation presentation = new Presentation("template.pptx");

// Créer une instance de présentation vide
Presentation newPresentation = new Presentation();

// Supprimer la diapositive par défaut
newPresentation.Slides.RemoveAt(0);

// Cloner la diapositive avec le contrôle ActiveX Media Player
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Accéder au contrôle ActiveX Media Player et définir le chemin vidéo
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Enregistrer la présentation
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```