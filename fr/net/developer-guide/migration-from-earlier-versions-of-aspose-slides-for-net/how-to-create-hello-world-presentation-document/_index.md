---
title: Comment créer des présentations Hello World en .NET
linktitle: Présentation Hello World
type: docs
weight: 10
url: /fr/net/how-to-create-hello-world-presentation-document/
keywords:
- migration
- bonjour le monde
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
description: "Créez une présentation PowerPoint Hello World au format PPT, PPTX et ODP en .NET avec Aspose.Slides en utilisant les API legacy et modernes dans un guide simple."
---

{{% alert color="primary" %}} 

Une nouvelle [API Aspose.Slides pour .NET](/slides/fr/net/) a été publiée et ce produit unique prend désormais en charge la génération de documents PowerPoint à partir de zéro ainsi que la modification des documents existants.

{{% /alert %}} 
## **Prise en charge du code hérité**
Afin d’utiliser le code hérité développé avec les versions d’Aspose.Slides pour .NET antérieures à 13.x, vous devez apporter quelques modifications mineures à votre code et celui‑ci fonctionnera comme auparavant. Toutes les classes qui existaient dans l’ancienne version d’Aspose.Slides pour .NET sous les espaces de noms Aspose.Slide et Aspose.Slides.Pptx sont maintenant regroupées dans un seul espace de noms Aspose.Slides. Veuillez consulter le fragment de code simple suivant pour créer un document de présentation Hello World avec l’API legacy d’Aspose.Slides et suivez les étapes décrivant comment migrer vers la nouvelle API fusionnée.
## **Approche Legacy Aspose.Slides pour .NET**
```c#
//Instancier un objet Presentation qui représente un fichier PPT
Presentation pres = new Presentation();

//Créer un objet License
License license = new License();

//Définir la licence d'Aspose.Slides pour .NET afin d'éviter les limitations d'évaluation
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
// Instancier une présentation
Presentation pres = new Presentation();

// Obtenir la première diapositive
ISlide sld = (ISlide)pres.Slides[0];

// Ajouter une AutoShape de type Rectangle
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Ajouter ITextFrame au rectangle
ashp.AddTextFrame("Hello World");

// Changer la couleur du texte en noir (qui est blanc par défaut)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Changer la couleur de la ligne du rectangle en blanc
ashp.ShapeStyle.LineColor.Color = Color.White;

// Supprimer tout format de remplissage de la forme
ashp.FillFormat.FillType = FillType.NoFill;

// Enregistrer la présentation sur le disque
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
