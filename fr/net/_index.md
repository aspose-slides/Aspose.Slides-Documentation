---
title: Aspose.Slides for .NET
second_title: Aspose.Slides for .NET
type: docs
weight: 10
url: /fr/net/
keywords:
- documentation
- traitement de présentation
- conversion de présentation
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Commencez ici : installez Aspose.Slides for .NET, créez une première présentation, et trouvez les guides pour les tâches courantes, la référence API et le support."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET est une bibliothèque de classes pour créer, lire, modifier et convertir des présentations PowerPoint et OpenDocument dans des applications .NET, sans Microsoft PowerPoint ni automatisation Office.

Elle charge et enregistre les formats PPT, PPTX, PPS, POT et ODP, y compris les variantes macro‑activées et les modèles, et exporte vers PDF, XPS, HTML, SVG, TIFF, Markdown et images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Premiers pas</b></p>
<hr>
<p>DÉMARRAGE</p>
<ul>
<li><a href="/slides/fr/net/installation/">Installation</a></li>
<li><a href="/slides/fr/net/create-presentation/">Créer votre première présentation</a></li>
<li><a href="/slides/fr/net/getting-started/">Guide de démarrage</a></li>
</ul>
<p>ÉVALUER</p>
<ul>
<li><a href="/slides/fr/net/supported-file-formats/">Formats de fichiers pris en charge</a></li>
<li><a href="/slides/fr/net/evaluate-aspose-slides/">Limitations de l’essai</a></li>
<li><a href="/slides/fr/net/licensing/">Licence</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Développer avec Slides</b></p>
<hr>
<p>TÂCHES COURANTES</p>
<ul>
<li><a href="/slides/fr/net/open-presentation/">Ouvrir une présentation</a></li>
<li><a href="/slides/fr/net/save-presentation/">Enregistrer une présentation</a></li>
<li><a href="/slides/fr/net/convert-powerpoint-to-pdf/">Convertir en PDF</a></li>
<li><a href="/slides/fr/net/convert-slide/">Rendre les diapositives en images</a></li>
<li><a href="/slides/fr/net/manage-text/">Modifier le texte et les formes</a></li>
</ul>
<p>FLUX DE TRAVAIL SLIDES</p>
<ul>
<li><a href="/slides/fr/net/powerpoint-charts/">Graphiques</a></li>
<li><a href="/slides/fr/net/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/fr/net/manage-media-files/">Audio et vidéo</a></li>
<li><a href="/slides/fr/net/presentation-design/">Conception de diapositives</a></li>
<li><a href="/slides/fr/net/merge-presentation/">Fusionner des présentations</a></li>
</ul>
<p>EXEMPLES</p>
<ul>
<li><a href="/slides/fr/net/examples/">Exemples par élément de diapositive</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Examples on GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Référence &amp; Support</b></p>
<hr>
<p>RÉFÉRENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/fr/net/">Référence API</a></li>
<li><a href="https://releases.aspose.com/slides/fr/net/release-notes/">Notes de version</a></li>
<li><a href="/slides/fr/net/known-issues/">Problèmes connus</a></li>
<li><a href="https://releases.aspose.com/slides/fr/net/">Télécharger</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/fr/11">Forum d’assistance gratuit</a></li>
<li><a href="https://helpdesk.aspose.com/">Service d’assistance payant</a></li>
</ul>
</div>
</div>

------

## **Votre première présentation**

Créez une application console avec le SDK .NET 6 ou ultérieur :

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Puis ajoutez un package pour votre plateforme :

- Sur Windows : `dotnet add package Aspose.Slides.NET`
- Sur Linux et macOS : `dotnet add package Aspose.Slides.NET6.CrossPlatform` — voir [Installation](/slides/fr/net/installation/) pour le prérequis Linux et pour les systèmes qui nécessitent Aspose.Slides.NET à la place.

Remplacez le contenu de *Program.cs* par ce code et exécutez `dotnet run` :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Le programme enregistre *hello.pptx* avec une diapositive contenant une zone de texte. Sans licence, le fichier enregistré porte un filigrane d’évaluation — voir [Licensing](/slides/fr/net/licensing/). Pour d’autres façons de créer et remplir une présentation, voir [Create Presentations](/slides/fr/net/create-presentation/).