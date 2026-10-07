---
title: Aspose.Slides pour Node.js via .NET
second_title: Aspose.Slides pour Node.js
type: docs
weight: 47
url: /fr/nodejs-net/
keywords:
- documentation
- traitement de présentations
- conversion de présentations
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Commencez ici: installez Aspose.Slides pour Node.js via .NET, créez une première présentation et retrouvez les guides pour les tâches courantes, la licence, la référence API et le support."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET est une bibliothèque pour créer, lire, modifier et convertir des présentations PowerPoint et OpenDocument dans des applications Node.js, sans Microsoft PowerPoint ni automatisation Office. Elle exécute Aspose.Slides for .NET via le pont edge‑js, de sorte que son API JavaScript reflète l’API .NET, avec des noms de membres camelCase.

Elle charge et enregistre les formats PPT, PPTX, PPS, POT et ODP, y compris les variantes à macros et les modèles, et exporte vers PDF, XPS, HTML, TIFF, Markdown et images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Commencer</b></p>
<hr>
<p>COMMENCER</p>
<ul>
<li><a href="/slides/fr/nodejs-net/installation/">Installation</a></li>
<li><a href="/slides/fr/nodejs-net/create-presentation/">Créez votre première présentation</a></li>
<li><a href="/slides/fr/nodejs-net/developer-guide/">Guide du développeur</a></li>
</ul>
<p>EVALUER</p>
<ul>
<li><a href="/slides/fr/nodejs-net/evaluate-aspose-slides/">Limites de l’évaluation</a></li>
<li><a href="/slides/fr/nodejs-net/licensing/">Licence</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Développer avec Slides</b></p>
<hr>
<p>TÂCHES COURANTES</p>
<ul>
<li><a href="/slides/fr/nodejs-net/open-presentation/">Ouvrir et enregistrer une présentation</a></li>
<li><a href="/slides/fr/nodejs-net/convert-powerpoint-to-pdf/">Convertir en PDF</a></li>
<li><a href="/slides/fr/nodejs-net/convert-slide/">Rendre les diapositives en images</a></li>
<li><a href="/slides/fr/nodejs-net/manage-text/">Modifier le texte</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Référence &amp; Support</b></p>
<hr>
<p>RÉFÉRENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Référence API .NET</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Notes de version</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">Page produit</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Téléchargement</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum d’assistance gratuit</a></li>
<li><a href="https://helpdesk.aspose.com/">Assistance payante</a></li>
</ul>
</div>
</div>

------

## **Votre première présentation**

Vous avez besoin de Node.js 22 ou 24 et du .NET SDK 8 ou ultérieur ; Linux nécessite également quelques paquets système. [Installation](/slides/fr/nodejs-net/installation/) répertorie ces exigences et les plates‑formes testées. Créez un projet, ajoutez une surcharge indiquant à npm quelle version d’edge‑js installer, puis installez le package :

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Une fois par machine, restaurez les packages .NET dont dépend la bibliothèque. Enregistrez le fichier `deps.csproj` depuis [Restore the .NET Dependencies](/slides/fr/nodejs-net/installation/#restore-the-net-dependencies) dans un dossier `deps` à l’intérieur du dossier du projet, puis exécutez :

```sh
dotnet restore deps/deps.csproj
```

Enregistrez ce code sous *hello.js* dans le dossier du projet :

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Une nouvelle présentation contient une diapositive vide.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // La position et la taille sont en points (1/72 pouce) : x, y, largeur, hauteur.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Libérez l’objet .NET qui sous-tend la présentation.
    presentation.dispose();
}
```

Exécutez‑le depuis le dossier du projet :

```sh
node hello.js
```

Le script affiche `Saved hello.pptx` et enregistre *hello.pptx* contenant une diapositive avec un rectangle affichant le texte. Sans licence, le fichier enregistré porte un filigrane d’évaluation — voir [Licensing](/slides/fr/nodejs-net/licensing/). Pour d’autres façons de créer et remplir une présentation, consultez [Create a Presentation](/slides/fr/nodejs-net/create-presentation/).