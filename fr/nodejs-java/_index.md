---
title: Aspose.Slides pour Node.js via Java
second_title: Aspose.Slides pour Node.js
type: docs
weight: 47
url: /fr/nodejs-java/
keywords:
- documentation
- traitement de présentations
- conversion de présentations
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Commencez ici : installez Aspose.Slides pour Node.js via Java, créez votre première présentation et consultez les guides pour les tâches courantes, la référence de l'API et le support."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides pour Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides pour Node.js via Java est une bibliothèque permettant de créer, lire, modifier et convertir des présentations PowerPoint et OpenDocument dans des applications Node.js, sans Microsoft PowerPoint.

Elle charge et enregistre les formats PPT, PPTX, PPS, POT et ODP, y compris les variantes avec macros et modèles, et exporte vers PDF, XPS, HTML, SVG, TIFF, Markdown et images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Commencer</b></p>
<hr>
<p>COMMENCER</p>
<ul>
<li><a href="/slides/fr/nodejs-java/installation/">Installation</a></li>
<li><a href="/slides/fr/nodejs-java/create-presentation/">Créer votre première présentation</a></li>
<li><a href="/slides/fr/nodejs-java/getting-started/">Guide de démarrage</a></li>
</ul>
<p>ÉVALUER</p>
<ul>
<li><a href="/slides/fr/nodejs-java/supported-file-formats/">Formats de fichiers pris en charge</a></li>
<li><a href="/slides/fr/nodejs-java/evaluate-aspose-slides/">Limitations de l'essai</a></li>
<li><a href="/slides/fr/nodejs-java/licensing/">Licence</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Créer avec Slides</b></p>
<hr>
<p>TÂCHES COURANTES</p>
<ul>
<li><a href="/slides/fr/nodejs-java/open-presentation/">Ouvrir une présentation</a></li>
<li><a href="/slides/fr/nodejs-java/save-presentation/">Enregistrer une présentation</a></li>
<li><a href="/slides/fr/nodejs-java/convert-powerpoint-to-pdf/">Convertir en PDF</a></li>
<li><a href="/slides/fr/nodejs-java/convert-slide/">Rendu des diapositives en images</a></li>
<li><a href="/slides/fr/nodejs-java/manage-text/">Modifier le texte et les formes</a></li>
</ul>
<p>FLUX DE TRAVAIL SLIDES</p>
<ul>
<li><a href="/slides/fr/nodejs-java/powerpoint-charts/">Graphiques</a></li>
<li><a href="/slides/fr/nodejs-java/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/fr/nodejs-java/manage-media-files/">Audio et vidéo</a></li>
<li><a href="/slides/fr/nodejs-java/presentation-design/">Conception de diapositives</a></li>
<li><a href="/slides/fr/nodejs-java/merge-presentation/">Fusionner des présentations</a></li>
</ul>
<p>EXEMPLES</p>
<ul>
<li><a href="/slides/fr/nodejs-java/examples/">Exemples par élément de diapositive</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Référence &amp; Support</b></p>
<hr>
<p>RÉFÉRENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">Référence de l'API</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">Notes de version</a></li>
<li><a href="/slides/fr/nodejs-java/known-issues/">Problèmes connus</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">Télécharger</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum d'assistance gratuit</a></li>
<li><a href="https://helpdesk.aspose.com/">Service d'assistance payant</a></li>
</ul>
</div>
</div>

------

## **Votre première présentation**

En plus de Node.js 20 ou ultérieur, le package nécessite un Java Development Kit (JDK), Python et une chaîne d'outils de construction C++, car npm compile son pont `java` pendant l'installation. Voir [Installation](/slides/fr/nodejs-java/installation/) pour les étapes sur chaque système d'exploitation. Créez ensuite un projet et installez le package depuis npm :

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Enregistrez ce code sous *hello.js* dans le dossier du projet :

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides s'exécute dans une machine virtuelle Java qui maintient Node.js en cours d'exécution, il faut donc terminer le processus explicitement.
process.exit(0);
```

Exécutez‑le avec `node hello.js`. Le script enregistre *hello.pptx* avec une diapositive contenant une zone de texte. Sans licence, le fichier enregistré porte un filigrane d'évaluation — voir [Licence](/slides/fr/nodejs-java/licensing/). Pour d'autres manières de créer et de remplir une présentation, voir [Créer des présentations](/slides/fr/nodejs-java/create-presentation/).