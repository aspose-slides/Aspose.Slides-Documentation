---
title: Comment créer des présentations Hello World en .NET
linktitle: Présentation Hello World
type: docs
weight: 10
url: /fr/net/how-to-create-hello-world-presentation-document/
keywords:
- migration
- bonjour monde
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créez une présentation PowerPoint PPT, PPTX et ODP Hello World en .NET avec Aspose.Slides en utilisant les API héritées et modernes dans un guide simple."
---
{{% alert color="info" %}}

Une nouvelle API Aspose.Slides for .NET a été publiée et ce produit unique prend désormais en charge la génération de documents PowerPoint à partir de zéro ainsi que la modification des documents existants.

{{% /alert %}}
## **Prise en charge du code hérité**
Pour utiliser le code hérité développé avec les versions d'Aspose.Slides for .NET antérieures à la 13.x, vous devez apporter quelques modifications mineures à votre code et celui‑ci fonctionnera comme auparavant. Toutes les classes qui étaient présentes dans l'ancienne Aspose.Slides for .NET sous les espaces de noms Aspose.Slide et Aspose.Slides.Pptx sont désormais regroupées dans un seul espace de noms Aspose.Slides. Veuillez consulter le fragment de code simple suivant pour créer un document de présentation Hello World avec l'API Aspose.Slides héritée et suivre les étapes décrivant comment migrer vers la nouvelle API unifiée.
## **Approche legacy Aspose.Slides for .NET**
```c#
using System.Drawing;
using Aspose.Slides;

//Instancie un objet Presentation qui représente un fichier PPT
Presentation pres = new Presentation();

//Crée un objet License
License license = new License();

//Définit la licence d'Aspose.Slides for .NET pour éviter les limitations d'évaluation
license.SetLicense("Aspose.Slides.lic");

//Ajoute une diapositive vide à la présentation et obtient la référence de
//cette diapositive vide
Slide slide = pres.AddEmptySlide();

//Ajoute un rectangle (X=2400, Y=1800, Largeur=1000 & Hauteur=500) à la diapositive
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Masque les lignes du rectangle
rect.LineFormat.ShowLines = false;

//Ajoute un cadre de texte au rectangle avec "Hello World" comme texte par défaut
rect.AddTextFrame("Hello World");

//Supprime la première diapositive de la présentation qui est toujours ajoutée par
//Aspose.Slides for .NET par défaut lors de la création de la présentation
pres.Slides.RemoveAt(0);

//Écrit la présentation sous forme de fichier PPT
pres.Write("C:\\hello.ppt");
```

## **Nouvelle approche Aspose.Slides for .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie une présentation
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```