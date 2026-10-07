---
title: Aspose.Slides pour Python via Java
second_title: Aspose.Slides pour Python
type: docs
weight: 47
url: /fr/python-java/
is_root: true
keywords:
- Aspose.Slides pour Python via Java
- Bibliothèque PowerPoint Python
- gérer des présentations PowerPoint en Python
- lire et écrire PowerPoint en Python
- modifier les diapositives PowerPoint en Python
- exporter PowerPoint en PDF en Python
- exporter PowerPoint en SVG en Python
- prévisualiser les diapositives en Python
- ajouter de l'audio et de la vidéo aux diapositives en Python
- PowerPoint sans Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Commencez ici: installez Aspose.Slides pour Python via Java, créez une première présentation, et trouvez les guides pour les tâches courantes, la référence API et le support."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides pour Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java est une bibliothèque permettant de créer, lire, modifier et convertir des présentations PowerPoint et OpenDocument dans des applications Python, sans Microsoft PowerPoint ; elle exécute le moteur Java Aspose.Slides dans votre processus Python via JPype.

Elle charge et enregistre les fichiers PPT, PPTX, PPS, POT et ODP, y compris les variantes avec macros et les modèles, et exporte vers PDF, XPS, HTML, SVG, TIFF, Markdown et images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Commencer</b></p>
<hr>
<p>DÉMARRAGE</p>
<ul>
<li><a href="/slides/fr/python-java/installation/">Installation</a></li>
<li><a href="/slides/fr/python-java/create-presentation/">Créer votre première présentation</a></li>
<li><a href="/slides/fr/python-java/getting-started/">Guide de démarrage</a></li>
</ul>
<p>ÉVALUER</p>
<ul>
<li><a href="/slides/fr/python-java/supported-file-formats/">Formats de fichiers pris en charge</a></li>
<li><a href="/slides/fr/python-java/evaluate-aspose-slides/">Limitations de l'essai</a></li>
<li><a href="/slides/fr/python-java/licensing/">Licence</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Créer avec Slides</b></p>
<hr>
<p>TÂCHES COURANTES</p>
<ul>
<li><a href="/slides/fr/python-java/open-presentation/">Ouvrir une présentation</a></li>
<li><a href="/slides/fr/python-java/save-presentation/">Enregistrer une présentation</a></li>
<li><a href="/slides/fr/python-java/convert-powerpoint-to-pdf/">Convertir en PDF</a></li>
<li><a href="/slides/fr/python-java/convert-slide/">Rendre les diapositives en images</a></li>
<li><a href="/slides/fr/python-java/manage-text/">Modifier le texte et les formes</a></li>
</ul>
<p>FLUX DE TRAVAIL SLIDES</p>
<ul>
<li><a href="/slides/fr/python-java/powerpoint-charts/">Graphiques</a></li>
<li><a href="/slides/fr/python-java/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/fr/python-java/manage-media-files/">Audio et vidéo</a></li>
<li><a href="/slides/fr/python-java/presentation-design/">Conception de diapositives</a></li>
<li><a href="/slides/fr/python-java/merge-presentation/">Fusionner les présentations</a></li>
</ul>
<p>EXEMPLES</p>
<ul>
<li><a href="/slides/fr/python-java/examples/">Exemples par élément de diapositive</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Référence &amp; Support</b></p>
<hr>
<p>RÉFÉRENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">Référence API</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Notes de version</a></li>
<li><a href="/slides/fr/python-java/known-issues/">Problèmes connus</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">Page produit</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Télécharger</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum d'assistance gratuit</a></li>
<li><a href="https://helpdesk.aspose.com/">Assistance payante</a></li>
</ul>
</div>
</div>

------

## **Votre première présentation**

Installez Python et un JDK, définissez `JAVA_HOME`, puis créez et activez un environnement virtuel comme décrit dans [Installation](/slides/fr/python-java/installation/). Ensuite, installez JPype et Aspose.Slides depuis PyPI :

```sh
python -m pip install JPype1 aspose-slides-java
```

Enregistrez ce code sous *hello.py*. Il démarre la machine virtuelle Java, ajoute une forme nuage avec du texte à la première diapositive d'une nouvelle présentation, et enregistre la présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Créer une présentation avec une diapositive vierge.
presentation = Presentation()
try:
    # Obtenir la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajouter une forme nuage et définir son texte.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Enregistrer la présentation au format PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Exécutez-le dans le même environnement virtuel :

```sh
python hello.py
```

Le script enregistre *new_presentation.pptx* avec une diapositive contenant une forme nuage avec le texte "Hello, Aspose!". Sans licence, le fichier enregistré comporte également un filigrane d'évaluation — voir [Licence](/slides/fr/python-java/licensing/). Pour d'autres manières de créer et remplir une présentation, voir [Créer des présentations](/slides/fr/python-java/create-presentation/).