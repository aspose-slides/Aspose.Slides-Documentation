---
title: "Nouveau système d'exportation HTML - Aspose.Slides.WebExtensions"
type: docs
weight: 240
url: /fr/net/web-extensions/
keywords:
- extension web
- moteur de modèles
- export PowerPoint
- export OpenDocument
- export de présentation
- export de diapositive
- export PPT
- export PPTX
- export ODP
- PowerPoint vers HTML
- OpenDocument vers HTML
- présentation vers HTML
- diapositive vers HTML
- PPT vers HTML
- PPTX vers HTML
- ODP vers HTML
- .NET
- C#
- Aspose.Slides
description: "Exportez des présentations vers HTML avec des modèles, CSS et JS - pas de SVG. Apprenez la sortie en page unique ou multi-pages, le contrôle des ressources et la personnalisation pour PPT, PPTX et ODP."
---

## **Introduction**

* Dans les anciennes versions de l'API Aspose.Slides, lorsque vous exportez PowerPoint vers HTML, le HTML résultant était représenté sous forme de balisage SVG combiné avec HTML. Chaque diapositive était exportée en tant que conteneur SVG. 
* Dans les nouvelles versions d'Aspose.Slides, lorsque vous utilisez le système WebExtensions pour exporter des présentations PowerPoint vers HTML, vous pouvez personnaliser les paramètres d'exportation HTML afin d'obtenir les meilleurs résultats. 

En utilisant le nouveau système WebExtensions, vous pouvez exporter une présentation complète en HTML avec un ensemble de classes CSS et d'animations JavaScript (sans SVG). Le nouveau système d'exportation offre également un nombre illimité d'options et de méthodes qui définissent le processus d'exportation. 

Le nouveau système WebExtensions est utilisé pour générer du HTML à partir de présentations dans les cas et événements suivants :

* lors de l'utilisation de styles CSS personnalisés ou d'animations ; en remplaçant le balisage pour certains types de formes.  
* lors du remplacement de la structure du document, par exemple en utilisant une navigation personnalisée entre les pages.
* lors de l'enregistrement des fichiers .html, .css, .js dans des dossiers avec une hiérarchie personnalisée, incluant des types de fichiers spécifiques dans différents dossiers. Par exemple, exporter les diapositives vers un dossier basé sur le nom de la section.
* lors de l'enregistrement des fichiers CSS et JS dans des dossiers séparés par défaut, puis de leur ajout à un fichier HTML. Les images et les polices intégrées sont également enregistrées dans des fichiers séparés. Cependant, elles peuvent être intégrées dans un fichier HTML (au format base64). Vous pouvez enregistrer certaines parties des ressources dans les fichiers et intégrer d’autres ressources dans le HTML en base64.

Vous pouvez parcourir les exemples de conversion PowerPoint vers HTML dans le [projet Aspose.Slides.WebExtensions](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) sur GitHub. Ce projet contient 2 parties : **Examples\\SinglePageApp** et **Examples\\MultiPageApp**. Les autres exemples utilisés dans cet article sont également disponibles dans le dépôt GitHub.

### **Modèles**

Pour étendre davantage les capacités d'exportation HTML, nous vous recommandons d'utiliser le système de modèles ASP.NET Razor. L'instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) peut être utilisée avec un ensemble de modèles afin d'obtenir un document HTML en résultat d'exportation.

**Démonstration**

Dans cet exemple, nous allons exporter du texte d'une présentation vers HTML. Tout d'abord, créons le modèle :
``` html
<!DOCTYPE html>
<body>
    @foreach (Slide slide in Model.Object.Slides)    
    {
        foreach (Shape shape in slide.Shapes)
        {
            if(shape is AutoShape)
            {
                ITextFrame textFrame = ((AutoShape)shape).TextFrame;
                <div class="text">@textFrame.Text</div>
            }
        }
    }
</body>
</html>
```

Ce modèle est enregistré sur le disque sous le nom "shape-template-hello-world.html", qui sera utilisé à l'étape suivante.

Dans ce modèle, nous parcourons les cadres de texte des formes de la présentation pour afficher le texte. Générons le fichier HTML à l'aide de WebDocument puis exportons la Presentation dans le fichier :
``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Nous prévoyons d'utiliser le moteur de modèles Razor. D'autres moteurs de modèles peuvent être utilisés en implémentant ITemplateEngine  
        OutputSaver = new FileOutputSaver() // D'autres sauvegardes de résultat peuvent être utilisées en implémentant l'interface IOutputSaver
    };
    WebDocument document = new WebDocument(options);

    // ajouter le document "input" - quelle source sera utilisée pour générer le document HTML
    document.Input
        .AddTemplate<Presentation>( // le modèle aura Presentation comme objet "modèle" (Model.Object) 
        "index", // clé du modèle - requise par le moteur de modèles pour faire correspondre un objet (Presentation) au modèle chargé depuis le disque ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // modèle que nous avons créé précédemment
                
    // ajouter la sortie - à quoi ressemblera le document HTML résultant lorsqu'il sera exporté sur le disque
    document.Output.Add(
        "hello-world.html", // chemin du fichier de sortie
        "index", // clé du modèle qui sera utilisée pour ce fichier (nous l'avons définie dans une instruction précédente)  
        pres); // une instance réelle de Model.Object 
                
    document.Save();
}
```


Par exemple, nous voulons ajouter des styles CSS au résultat d'exportation pour changer la couleur du texte en rouge. Ajoutons le modèle CSS :
``` css
.text {
    color: red;
}
```


Maintenant, nous l'ajoutons aux entrées et sorties :
``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions { TemplateEngine = new RazorTemplateEngine(), OutputSaver = new FileOutputSaver() };
    WebDocument document = new WebDocument(options);

    document.Input.AddTemplate<Presentation>("index", @"custom-templates\shape-template-hello-world.html");
    document.Input.AddTemplate<Presentation>("styles", @"custom-templates\styles\shape-template-hello-world.css");
    document.Output.Add("hello-world.html", "index", pres); 
    document.Output.Add("hello-world.css", "styles", pres);
                
    document.Save();
}
```


Ajoutons la référence aux styles dans le modèle et la classe "text" :
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```


### **Modèles par défaut**

WebExtensions fournit 2 ensembles de modèles de base pour exporter des présentations en HTML :

* Single-page : tout le contenu de la présentation est exporté dans un seul fichier HTML. Toutes les autres ressources (images, polices, styles, etc.) sont exportées dans des fichiers séparés.
* Multi-page : chaque diapositive de la présentation est exportée dans un fichier HTML individuel. La logique d'exportation des ressources par défaut est la même que pour une page unique. 

La classe `PresentationExtensions` peut être utilisée pour simplifier le processus d'exportation de la présentation à l'aide de modèles. La classe `PresentationExtensions` contient un ensemble de méthodes d'extension pour la classe Presentation. Pour exporter une présentation en une seule page, il suffit d'inclure l'espace de noms Aspose.Slides.WebExtensions et d'appeler deux méthodes. La première méthode, `ToSinglePageWebDocument`, crée une instance de `WebDocument`. La deuxième méthode enregistre le document HTML :
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```


La méthode ToSinglePageWebDocument peut prendre deux paramètres : le dossier des modèles et le dossier d'exportation. 

Pour exporter la présentation en plusieurs pages, utilisez la méthode ToMultiPageWebDocument avec les mêmes paramètres :
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```


Dans WebExtensions, chaque modèle utilisé pour la génération du balisage est lié à une clé. La clé peut être utilisée dans les modèles. Par exemple, dans la directive @Include, vous pouvez insérer un certain modèle dans un autre à l'aide de la clé.

Nous pouvons démontrer la procédure avec l'exemple d'utilisation du modèle de portion de texte à l'intérieur du modèle de paragraphe. Vous pouvez trouver l'exemple dans le projet Aspose.Slides.WebExtensions : [Templates\\common\\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). Pour tracer les portions dans un paragraphe, nous les parcourons à l'aide de la directive @foreach du moteur Razor :
``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```


La portion possède son propre modèle [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) et un modèle est généré pour celle‑ci. Ce modèle sera ajouté au modèle de sortie paragraph.html :
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```


Pour chaque type de forme, nous utilisons un modèle personnalisé, qui est ajouté à l’ensemble général de modèles du projet Aspose.Slides.WebExtensions. Les modèles sont combinés dans les méthodes ToSinglePageWebDocument et ToMultiPageWebDocument pour fournir un résultat final. Voici les modèles communs utilisés à la fois pour les pages uniques et multiples :

-templates
+-common
  ¦ +-scripts : scripts javascript pour les animations de transition de diapositive, à titre d'exemple.
  ¦ +-styles : styles CSS communs.
  +-multi-page : modèles d'index, menu, diapositive pour la sortie multi‑page.
  +-single-page : modèles d'index, diapositive pour la sortie à page unique.

Vous pouvez découvrir comment la partie commune est liée à tous les modèles dans la méthode `PresentationExtensions.AddCommonInputOutput` [ici](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).

### **Personnalisation des modèles par défaut**

Vous pouvez modifier n'importe quel élément du modèle du modèle commun. Par exemple, vous pouvez décider de changer les styles de mise en forme du tableau tout en souhaitant que les autres styles de la page unique restent inchangés.

Par défaut, Templates\\common\\table.html est utilisé, et le tableau a la même apparence que le tableau dans PowerPoint. Modifions la mise en forme du tableau en utilisant des styles CSS personnalisés :
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```


Nous pouvons créer la même structure de modèles d'entrée et de fichiers de sortie (telle qu'elle est générée) en appelant la méthode `PresentationExtensions.ToSinglePageWebDocument`. Ajoutons la méthode `ExportCustomTableStyles_AddCommonStructure` à cet effet. La différence entre cette méthode et `ToSinglePageWebDocument` — nous n'avons pas besoin d'ajouter le modèle standard pour le tableau et la page d'index principale (il sera remplacé pour inclure la référence aux styles de tableau personnalisés) :
``` csharp
private static void ExportCustomTableStyles_AddCommonStructure(
    Presentation pres, 
    WebDocument document,
    string templatesPath, 
    string outputPath, 
    bool embedImages)
{
    AddCommonStylesTemplates(document, templatesPath);
            
    document.Input.AddTemplate<Slide>("slide", Path.Combine(templatesPath, "slide.html"));
    document.Input.AddTemplate<AutoShape>("autoshape", Path.Combine(templatesPath, "autoshape.html"));
    document.Input.AddTemplate<TextFrame>("textframe", Path.Combine(templatesPath, "textframe.html"));
    document.Input.AddTemplate<Paragraph>("paragraph", Path.Combine(templatesPath, "paragraph.html"));
    document.Input.AddTemplate<Paragraph>("bullet", Path.Combine(templatesPath, "bullet.html"));
    document.Input.AddTemplate<Portion>("portion", Path.Combine(templatesPath, "portion.html"));
    document.Input.AddTemplate<VideoFrame>("videoframe", Path.Combine(templatesPath, "videoframe.html"));
    document.Input.AddTemplate<PictureFrame>("pictureframe", Path.Combine(templatesPath, "pictureframe.html")); ;
    document.Input.AddTemplate<Shape>("shape", Path.Combine(templatesPath, "shape.html"));

    AddSinglePageCommonOutput(pres, document, outputPath);
            
    AddResourcesOutput(pres, document, embedImages);
            
    AddScriptsOutput(document, templatesPath);
}
```


Ajoutons plutôt un modèle personnalisé :
```csharp
using (Presentation pres = new Presentation("table.pptx"))
{
    const string templatesPath = "templates\\single-page";
    const string outputPath = "custom-table-styles";
                
    var options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(),
        OutputSaver = new FileOutputSaver(),
        EmbedImages = false
    };

    // configurer les valeurs globales du document
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // ajouter la structure commune (sauf le modèle de tableau)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // ajouter le modèle de tableau personnalisé
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // ajouter les styles de tableau personnalisés
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // ajouter un index personnalisé - c'est simplement une copie de l"index.html" standard, mais inclut une référence à "table-custom-style.css"
    document.Input.AddTemplate<Presentation>("index", @"custom-templates\index-table-custom-style.html");
                
    document.Save();
}
```

``` html
@model TemplateContext<Table>

@{
	Table contextObject = Model.Object;
	
	var origin = Model.Local.Get<Point>("origin");
	var positionStyle = string.Format("left: {0}px; top: {1}px; width: {2}px; height: {3}px;",
										(int)contextObject.X + origin.X,
										(int)contextObject.Y + origin.Y,
										(int)contextObject.Width,
										(int)contextObject.Height);
}

	<table class="table custom-table" style="@positionStyle">
	@for (int i = 0; i < contextObject.Rows.Count; i++)
	{
		var rowHeight = string.Format("height: {0}px", contextObject.Rows[i].Height);
		<tr style="@rowHeight">
		@for (int j = 0; j < contextObject.Columns.Count; j++)
		{
			var cell = contextObject[j, i];
			if (cell.FirstRowIndex ==  i && cell.FirstColumnIndex == j)
			{
				var spans = cell.IsMergedCell ? string.Format("rowspan=\"{0}\" colspan=\"{1}\"", cell.RowSpan, cell.ColSpan) : "";
				<td width="@cell.Width px" @Raw(spans)>
					@{
						for(int k = 0; k < cell.TextFrame.Paragraphs.Count; k++)
						{
							var para = (Paragraph)cell.TextFrame.Paragraphs[k];
						
							var subModel = Model.SubModel(para);
							double[] margins = new double[] { cell.MarginLeft, cell.MarginTop, cell.MarginRight, cell.MarginBottom };
							subModel.Local.Put("margins", margins);
							subModel.Local.Put("parent", cell.TextFrame);
							subModel.Local.Put("parentContainerSize", new SizeF((float)cell.Width, (float)cell.Height));
                            subModel.Local.Put("tableContent", true);
							
							@Include("paragraph", subModel)
						}
					}
				</td>
			}
		}
		</tr>
	}
</table>
```


**Remarque** : le modèle de tableau personnalisé a été ajouté avec la même clé « table » que le tableau standard. Ainsi, vous pouvez remplacer un certain modèle par défaut sans le réécrire. Vous pouvez également utiliser les modèles de la structure par défaut avec les mêmes clés. Par exemple, vous pouvez utiliser un modèle de paragraphe standard dans le modèle de tableau ; vous pouvez également le remplacer par la clé.
Vous pouvez aussi utiliser index.html pour inclure la référence aux styles CSS du tableau personnalisé :
``` html
<!DOCTYPE html>    
    
<html     
    xmlns="http://www.w3.org/1999/xhtml"    
    xmlns:svg="http://www.w3.org/2000/svg"    
    xmlns:xlink="http://www.w3.org/1999/xlink">    
<head>    
     ...
    <link rel="stylesheet" type="text/css" href="table-custom-style.css" />
    ...
</head>    
<body>    
    ...
</body>
</html>
```


## **Créer un projet à partir de zéro : transitions de diapositives animées**

WebExtensions vous permet d'exporter des présentations avec des transitions de diapositives animées — il suffit de définir la propriété `AnimateTransitions` dans `WebDocumentOptions` à `true` :
``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... autres options
    AnimateTransitions = true
};
```


Créons un nouveau projet qui utilise Aspose.Slides et Aspose.Slides.WebExtensions pour créer un visualiseur HTML pour PDF avec des transitions de page animées fluides. Ici, nous devons utiliser la fonctionnalité d'importation PDF d'Aspose.Slides.

Créons un projet PdfToPresentationToHtml et ajoutons le package NuGet Aspose.Slides.WebExtensions (le package Aspose.Slides sera également ajouté comme dépendance) :
![NuGet Package](screen.png)

Nous commençons par importer le document PDF, qui sera animé et exporté dans une présentation HTML :
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```


Maintenant, nous pouvons configurer les transitions de diapositives animées (chaque diapositive correspond à une page PDF importée). Nous avons utilisé 9 diapositives dans le document PDF d'exemple. Ajoutons des transitions de diapositives à chacune d'elles (démo lors de la visualisation du HTML) :
``` csharp
pres.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
pres.Slides[1].SlideShowTransition.Type = TransitionType.RandomBar;
pres.Slides[2].SlideShowTransition.Type = TransitionType.Cover;
pres.Slides[3].SlideShowTransition.Type = TransitionType.Dissolve;
pres.Slides[4].SlideShowTransition.Type = TransitionType.Switch;
pres.Slides[5].SlideShowTransition.Type = TransitionType.Pan;
pres.Slides[6].SlideShowTransition.Type = TransitionType.Ferris;
pres.Slides[7].SlideShowTransition.Type = TransitionType.Pull;
pres.Slides[8].SlideShowTransition.Type = TransitionType.Plus;
```


Enfin, exportons-le en HTML à l'aide de `WebDocument` avec la propriété `AnimateTransitions` définie à `true` :
``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    TemplateEngine = new RazorTemplateEngine(),
    OutputSaver = new FileOutputSaver(),
    AnimateTransitions = true
};

WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "animated-pdf");
document.Save();
```


Exemple complet du code source :
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
    pres.Slides[1].SlideShowTransition.Type = TransitionType.RandomBar;
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Cover;
    pres.Slides[3].SlideShowTransition.Type = TransitionType.Dissolve;
    pres.Slides[4].SlideShowTransition.Type = TransitionType.Switch;
    pres.Slides[5].SlideShowTransition.Type = TransitionType.Pan;
    pres.Slides[6].SlideShowTransition.Type = TransitionType.Ferris;
    pres.Slides[7].SlideShowTransition.Type = TransitionType.Pull;
    pres.Slides[8].SlideShowTransition.Type = TransitionType.Plus;

    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(),
        OutputSaver = new FileOutputSaver(),
        AnimateTransitions = true
    };

    WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "animated-pdf");
    document.Save();
}
```


C'est tout ce qu'il faut pour créer du HTML avec les transitions de page animées générées à partir du document PDF. 

* [Télécharger le fichier HTML d'exemple](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).
* [Télécharger le projet d'exemple](/slides/fr/net/web-extensions/sample.zip).