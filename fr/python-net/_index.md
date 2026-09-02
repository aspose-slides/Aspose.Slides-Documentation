---
title: Aspose.Slides pour Python via .NET
second_title: Aspose.Slides pour Python
type: docs
weight: 35
url: /fr/python-net/
is_root: true
keywords:
- Aspose.Slides pour Python
- Automatisation PowerPoint Python
- Bibliothèque PPT Python
- Exporter PowerPoint en PDF Python
- Exporter PowerPoint en SVG Python
- Modifier PowerPoint en Python
- PowerPoint Python sans Microsoft Office
- Gérer PPTX avec Python
- Aperçu des diapositives Python
- Python ajouter audio aux diapositives
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides pour Python via .NET offre un ensemble complet de fonctionnalités, notamment la gestion du texte, des formes, des tableaux et des animations, l'ajout d'audio et de vidéo aux diapositives, l'aperçu des diapositives et l'exportation vers SVG, PDF et plus encore."
---
{{% alert color="info" %}}

**Bienvenue sur Aspose.Slides pour Python via .NET**

![Logo du produit Aspose.Slides pour Python via .NET](aspose_slides-for-python.png)

Aspose.Slides pour Python via .NET est une bibliothèque de classes robuste qui permet à vos applications de lire et d'écrire des présentations PowerPoint® sans nécessiter Microsoft PowerPoint®.

C'est le premier et le seul composant offrant une gestion complète des documents PowerPoint® pour les développeurs Python.

Aspose.Slides pour Python via .NET comprend un large éventail de fonctionnalités telles que la manipulation du texte, des formes, des tableaux et des animations ; l'ajout d'audio et de vidéo ; l'aperçu des diapositives ; et l'exportation des diapositives vers des formats comme SVG, PDF et bien d'autres.

{{% /alert %}}

## Installer Aspose.Slides pour Python via .NET

```bash
pip install aspose.slides
```

Le package comprend le runtime .NET dont il a besoin, il n'y a donc rien d'autre à installer et Microsoft PowerPoint n'est pas requis. Python 3.7 ou ultérieur sur Windows, Linux ou macOS.

## Créer une présentation PowerPoint en Python

Cet exemple crée une présentation, ajoute une forme avec du texte à la première diapositive et enregistre le résultat à la fois au format PPTX et PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

L'exécution crée `presentation.pptx` (environ 34 KB) et `presentation.pdf` (environ 36 KB) dans le répertoire de travail.

Sans licence, la bibliothèque fonctionne en mode d'évaluation, ce qui ajoute un filigrane et limite le nombre de diapositives. Voir [Licence](/slides/fr/python-net/licensing/) pour en appliquer une.

## Ressources Aspose.Slides pour Python via .NET

Explorez ces ressources utiles::

- [Documentation en ligne d'Aspose.Slides pour Python via .NET](/slides/fr/python-net/)
- [Fonctionnalités d'Aspose.Slides pour Python via .NET](/slides/fr/python-net/features-overview/)
- [Notes de version d'Aspose.Slides pour Python via .NET](https://releases.aspose.com/slides/fr/python-net/release-notes/)
- [Page produit d'Aspose.Slides pour Python via .NET](https://products.aspose.com/slides/fr/python-net/)
- [Télécharger Aspose.Slides pour Python via .NET](https://releases.aspose.com/slides/fr/python-net/)
- [Installer le package PyPi d'Aspose.Slides pour Python via .NET](https://pypi.org/project/aspose.slides/)
- [Guide de référence API d'Aspose.Slides pour Python via .NET](https://reference.aspose.com/slides/fr/python-net/)
- [Forum de support gratuit d'Aspose.Slides pour Python via .NET](https://forum.aspose.com/c/slides/fr/11)
- [Service d'assistance payant d'Aspose.Slides pour Python via .NET](https://helpdesk.aspose.com/)

## FAQ

### Qu’est‑ce qu’Aspose.Slides pour Python via .NET ?

Aspose.Slides pour Python via .NET est une bibliothèque Python puissante qui vous permet de créer, modifier et convertir des présentations PowerPoint (PPT, PPTX, ODP) de manière programmatique sans Microsoft PowerPoint installé.

### Quelles fonctionnalités de présentation Aspose.Slides prend‑il en charge ?

La bibliothèque prend en charge la gestion du texte, des formes, des tableaux, des graphiques, des animations, des diapositives maîtres, de l’audio, de la vidéo, et plus encore. Elle permet également l’aperçu des diapositives, le rendu et l’exportation vers des formats tels que PDF, SVG, HTML et des images.

### Puis‑je convertir des présentations vers d’autres formats avec Aspose.Slides ?

Oui. Aspose.Slides permet la conversion des fichiers PowerPoint en PDF, SVG, HTML, JPG, PNG, TIFF et d’autres formats avec une haute fidélité et de bonnes performances.

### Microsoft PowerPoint est‑il nécessaire pour utiliser Aspose.Slides ?

Non. Aspose.Slides est une API autonome et ne nécessite ni Microsoft Office ni aucun logiciel tiers.

### Quelles plateformes Aspose.Slides pour Python via .NET prend‑il en charge ?

Il est multiplateforme et fonctionne sous les environnements Windows, Linux et macOS.

### Comment démarrer avec Aspose.Slides pour Python ?

Vous pouvez l’installer via PyPi et explorer le [Guide du développeur](/slides/fr/python-net/developer-guide/) pour commencer avec des exemples, des références API et des tutoriels.