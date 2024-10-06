---
title: Comment créer un document de présentation Hello World
type: docs
weight: 10
url: /net/how-to-create-hello-world-presentation-document/
---

{{% alert color="primary" %}} 

Une nouvelle [Aspose.Slides pour .NET API](/slides/net/) a été publiée et maintenant, ce produit unique prend en charge la capacité de générer des documents PowerPoint à partir de zéro et de modifier les documents existants.

{{% /alert %}} 
## **Support pour le code héritée**
Pour utiliser le code héritée développé avec les versions d'Aspose.Slides pour .NET antérieures à 13.x, vous devez apporter quelques modifications mineures dans votre code et celui-ci fonctionnera comme auparavant. Toutes les classes présentes dans l'ancienne Aspose.Slides pour .NET sous les espaces de noms Aspose.Slide et Aspose.Slides.Pptx sont désormais fusionnées dans un seul espace de noms Aspose.Slides. Veuillez consulter le code simple suivant pour créer un document de présentation Hello World dans l'API Aspose.Slides héritée et suivre les étapes décrivant comment migrer vers la nouvelle API fusionnée.
## **Approche Aspose.Slides pour .NET héritée**
```c#
//Instancier un objet Presentation qui représente un fichier PPT
Presentation pres = new Presentation();

//Créer un objet License
License license = new License();

//Définir la licence d'Aspose.Slides pour .NET pour éviter les limitations d'évaluation
license.SetLicense("Aspose.Slides.lic");

//Ajouter une diapositive vide à la présentation et obtenir la référence de
//cette diapositive vide
Slide slide = pres.AddEmptySlide();

//Ajouter un rectangle (X=2400, Y=1800, Largeur=1000 & Hauteur=500) à la diapositive
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Masquer les lignes du rectangle
rect.LineFormat.ShowLines = false;

//Ajouter un cadre de texte au rectangle avec "Hello World" comme texte par défaut
rect.AddTextFrame("Hello World");

//Supprimer la première diapositive de la présentation qui est toujours ajoutée par
//Aspose.Slides pour .NET par défaut lors de la création de la présentation
pres.Slides.RemoveAt(0);

//Écrire la présentation en tant que fichier PPT
pres.Write("C:\\hello.ppt");
```



## **Nouvelle approche Aspose.Slides pour .NET 13.x**
```c#
// Instancier la Présentation
Presentation pres = new Presentation();

// Obtenir la première diapositive
ISlide sld = (ISlide)pres.Slides[0];

// Ajouter une forme automatique de type Rectangle
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Ajouter un ITextFrame au Rectangle
ashp.AddTextFrame("Hello World");

// Changer la couleur du texte en Noir (qui est Blanc par défaut)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Changer la couleur de la ligne du rectangle en Blanc
ashp.ShapeStyle.LineColor.Color = Color.White;

// Supprimer toute mise en forme de remplissage dans la forme
ashp.FillFormat.FillType = FillType.NoFill;

// Enregistrer la présentation sur le disque
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```