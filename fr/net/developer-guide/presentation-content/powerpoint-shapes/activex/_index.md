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
description: "Modifiez les zones de texte et les boutons ActiveX, mettez à jour les aperçus des contrôles et réutilisez un contrôle Windows Media Player dans les présentations PowerPoint avec Aspose.Slides pour .NET."
---
## **Introduction**

Les contrôles ActiveX offrent à une diapositive PowerPoint des éléments interactifs tels que des zones de texte, des boutons de commande et des lecteurs multimédias. Aspose.Slides pour .NET expose les contrôles d’une diapositive via [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/). Utilisez cette collection pour modifier un contrôle, le déplacer sur la diapositive ou le supprimer.

## **Lister les contrôles ActiveX et leurs propriétés stockées**

Pour examiner un modèle inconnu, ouvrez‑le en lecture et parcourez les contrôles de chaque diapositive. L’exemple indique le numéro de la diapositive, le nom du contrôle, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/), et chaque paire clé‑valeur dans [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties). Il lit la présentation sans activer les contrôles, sans invoquer d’événements ou de macros, sans modifier les valeurs, ni enregistrer le fichier.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

La sortie sélectionnée de `ActiveX.pptm` montre une zone de texte et un bouton de commande.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Une collection de propriétés vide apparaît sous la forme `[]`. Pour les contrôles qui utilisent le stockage binaire, `Properties` peut renvoyer `null`, affiché comme `Properties unavailable`. Si vous avez uniquement besoin des noms, utilisez [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) après la vérification de null. Le rapport répertorie les propriétés disponibles dans la présentation. Un contrôle peut prendre en charge des propriétés supplémentaires à l’exécution.

## **Modifier les contrôles ActiveX**

L’exemple suppose une présentation avec macros contenant une zone de texte nommée `TextBox1` et un bouton de commande nommé `CommandButton1` sur la première diapositive. Il utilise la [collection de propriétés du contrôle](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) pour modifier la valeur de la zone de texte et le libellé du bouton. Chaque contrôle possède également un aperçu statique que PowerPoint peut afficher avant l’activation. Fournissez un fichier PNG pour chaque contrôle montrant le texte et l’apparence mis à jour. L’exemple assigne ces images via [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/).

L’exemple déplace chaque contrôle de la première diapositive vers le bas de 100 points en modifiant son [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/). Il enregistre la présentation modifiée au format PPTM, puis utilise [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) pour enregistrer une seconde copie dont tous les contrôles ActiveX ont été retirés de cette diapositive.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **Ajouter un contrôle ActiveX Lecteur multimédia**

Pour réutiliser un contrôle Windows Media Player configuré, commencez avec un modèle dont la première diapositive contient un lecteur nommé `WindowsMediaPlayer1`. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) copie la diapositive entière dans une nouvelle présentation. L’exemple définit l’`URL` du lecteur dans sa [collection de propriétés](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) et enregistre la diapositive dupliquée comme unique diapositive du résultat. La vidéo reste externe, choisissez donc un chemin accessible au lecteur lors de la lecture.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Aspose.Slides peut‑il conserver les contrôles ActiveX sans les exécuter ?**

Oui. Aspose.Slides peut lire et enregistrer les contrôles, y compris leurs propriétés et leurs positions, sans les activer.

**En quoi les contrôles ActiveX diffèrent‑ils des objets OLE ?**

Les contrôles ActiveX permettent aux utilisateurs d’interagir avec une diapositive, par exemple en saisissant du texte ou en cliquant sur un bouton. Un [objet OLE](/slides/fr/net/manage-ole/) permet à une diapositive de contenir ou de lier du contenu géré par une autre application, comme une feuille de calcul Excel.

**Les événements ActiveX déclencheront‑ils toujours les macros VBA après avoir enregistré une présentation avec Aspose.Slides ?**

Enregistrez la présentation dans un format compatible avec les macros, tel que PPTM, pour conserver son projet VBA. PowerPoint pour Windows peut exécuter les gestionnaires d’événements existants lorsque ses paramètres de sécurité autorisent à la fois les contrôles ActiveX et les macros.