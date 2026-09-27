---
title: Aspose.Slides for Python via .NET
second_title: Aspose.Slides for Python
type: docs
weight: 35
url: /fr/python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- Automatisation PowerPoint Python
- Bibliothèque PPT Python
- Exporter PowerPoint en PDF Python
- Exporter PowerPoint en SVG Python
- Modifier PowerPoint en Python
- PowerPoint Python sans Microsoft Office
- Gérer PPTX avec Python
- Aperçu des diapositives Python
- Python ajouter de l'audio aux diapositives
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Commencez ici : installez Aspose.Slides for Python via .NET, créez votre première présentation, et retrouvez les guides pour les tâches courantes, la référence API et le support."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET est une bibliothèque Python permettant de créer, lire, modifier et convertir des présentations PowerPoint et OpenDocument, sans Microsoft PowerPoint ni Microsoft Office.

Elle charge et enregistre les fichiers PPT, PPTX, PPS, POT et ODP, y compris les variantes avec macros et les modèles, et exporte vers PDF, XPS, HTML, SVG, TIFF, Markdown et images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Commencer</b></p>
<hr>
<p>DÉMARRAGE</p>
<ul>
<li><a href="/slides/fr/python-net/installation/">Installation</a></li>
<li><a href="/slides/fr/python-net/create-presentation/">Créer votre première présentation</a></li>
<li><a href="/slides/fr/python-net/getting-started/">Guide de démarrage</a></li>
</ul>
<p>ÉVALUER</p>
<ul>
<li><a href="/slides/fr/python-net/supported-file-formats/">Formats de fichiers pris en charge</a></li>
<li><a href="/slides/fr/python-net/evaluate-aspose-slides/">Limitations de l'essai</a></li>
<li><a href="/slides/fr/python-net/licensing/">Licence</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Développer avec Slides</b></p>
<hr>
<p>TÂCHES COURANTES</p>
<ul>
<li><a href="/slides/fr/python-net/open-presentation/">Ouvrir une présentation</a></li>
<li><a href="/slides/fr/python-net/save-presentation/">Enregistrer une présentation</a></li>
<li><a href="/slides/fr/python-net/convert-powerpoint-to-pdf/">Convertir en PDF</a></li>
<li><a href="/slides/fr/python-net/convert-slide/">Rendre les diapositives en images</a></li>
<li><a href="/slides/fr/python-net/manage-text/">Modifier le texte et les formes</a></li>
</ul>
<p>FLUX DE TRAVAIL SLIDES</p>
<ul>
<li><a href="/slides/fr/python-net/powerpoint-charts/">Graphiques</a></li>
<li><a href="/slides/fr/python-net/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/fr/python-net/manage-media-files/">Audio et vidéo</a></li>
<li><a href="/slides/fr/python-net/presentation-design/">Conception de diapositives</a></li>
<li><a href="/slides/fr/python-net/merge-presentation/">Fusionner des présentations</a></li>
</ul>
<p>EXEMPLES</p>
<ul>
<li><a href="/slides/fr/python-net/examples/">Exemples par élément de diapositive</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Exemples sur GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Référence &amp; Support</b></p>
<hr>
<p>RÉFÉRENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">Référence API</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">Notes de version</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">Téléchargement</a></li>
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

Installez le package depuis PyPI :

```bash
pip install aspose.slides
```

Le package inclut le runtime .NET qu'il utilise, vous n'avez donc pas besoin d'installer .NET. Sous Linux, installez également les bibliothèques libgdiplus et ICU, et avec le Python système de Debian ou Ubuntu, exécutez la commande dans un environnement virtuel. macOS possède d'autres prérequis, et nous n'avons pas vérifié l'installation sur cette plateforme. Consultez [Installation](/slides/fr/python-net/installation/) pour les commandes, les prérequis macOS et les versions de Python supportées.

Enregistrez ce code sous le nom *hello.py* :

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:
    # Obtenir la première diapositive.
    slide = presentation.slides[0]

    # Ajouter une forme auto de type CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Enregistrer la présentation au format PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Exécutez‑le avec `python hello.py`. Le script enregistre *new_presentation.pptx* dans le dossier courant, avec une diapositive contenant une forme de nuage affichant « Hello, Aspose! ». Sans licence, le fichier enregistré porte un filigrane d'évaluation — voir [Licence](/slides/fr/python-net/licensing/). Pour d'autres méthodes de créer et remplir une présentation, consultez [Créer des présentations](/slides/fr/python-net/create-presentation/).