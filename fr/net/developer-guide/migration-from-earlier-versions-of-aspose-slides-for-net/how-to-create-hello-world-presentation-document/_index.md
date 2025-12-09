---
title: Comment créer des présentations Hello World en .NET
linktitle: Présentation Hello World
type: docs
weight: 10
url: /fr/net/how-to-create-hello-world-presentation-document/
keywords:
- migration
- hello world
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
- description: "Créez une présentation PowerPoint PPT, PPTX et ODP Hello World en .NET avec Aspose.Slides en utilisant à la fois les API legacy et modernes dans un guide simple."
---

{{% alert color="primary" %}} 
Une nouvelle [Aspose.Slides for .NET API](/slides/fr/net/) a été publiée et ce produit unique prend désormais en charge la génération de documents PowerPoint à partir de zéro ainsi que la modification des documents existants.
{{% /alert %}} 
## **Prise en charge du code hérité**
Pour utiliser le code hérité développé avec les versions d'Aspose.Slides pour .NET antérieures à 13.x, vous devez apporter quelques modifications mineures à votre code et celui-ci fonctionnera comme auparavant. Toutes les classes qui se trouvaient dans les anciens espaces de noms Aspose.Slide et Aspose.Slides.Pptx d'Aspose.Slides pour .NET sont désormais fusionnées dans un seul espace de noms Aspose.Slides. Veuillez consulter le fragment de code simple suivant pour créer un document de présentation Hello World avec l'API legacy d'Aspose.Slides et suivre les étapes décrivant comment migrer vers la nouvelle API fusionnée.
## **Approche legacy d'Aspose.Slides pour .NET**
```c#
//Instancie un objet Presentation qui représente un fichier PPT
//Crée un objet License
//Définit la licence d'Aspose.Slides for .NET pour éviter les limitations d'évaluation
//Ajoute une diapositive vide à la présentation et obtient la référence de
//cette diapositive vide
//Ajoute un rectangle (X=2400, Y=1800, Largeur=1000 & Hauteur=500) à la diapositive
//Masque les lignes du rectangle
//Ajoute un cadre de texte au rectangle avec "Hello World" comme texte par défaut
//Supprime la première diapositive de la présentation qui est toujours ajoutée par
//Aspose.Slides for .NET par défaut lors de la création de la présentation
//Écrit la présentation sous forme de fichier PPT
Presentation pres = new Presentation();

License license = new License();

license.SetLicense("Aspose.Slides.lic");

Slide slide = pres.AddEmptySlide();

Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

rect.LineFormat.ShowLines = false;

rect.AddTextFrame("Hello World");

pres.Slides.RemoveAt(0);

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

// Changer la couleur du trait du rectangle en blanc
ashp.ShapeStyle.LineColor.Color = Color.White;

// Supprimer tout format de remplissage de la forme
ashp.FillFormat.FillType = FillType.NoFill;

// Enregistrer la présentation sur le disque
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
