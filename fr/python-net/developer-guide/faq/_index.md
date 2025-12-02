---
title: FAQ
type: docs
weight: 340
url: /fr/python-net/faq/
keywords:
- FAQ
- format de présentation
- erreur de mémoire insuffisante
- taille de diapositive
- extraction de texte
- récupération de texte
- taille de paragraphe
- mise en forme des tableaux
- police
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Obtenez des réponses aux FAQ sur Aspose.Slides pour Python via .NET, couvrant la prise en charge de PowerPoint et OpenDocument, les conseils d'installation, la licence et le dépannage."
---

## **Formats de fichiers pris en charge**

**Q : Quels formats de fichiers Aspose.Slides pour Python via .NET prend‑il en charge ?**

**A** : Aspose.Slides pour Python via .NET prend en charge les formats de fichiers décrits dans [Formats de fichiers pris en charge](/slides/fr/python-net/supported-file-formats/).

## **Exceptions**

**Q : Je reçois une exception « out of memory » lors du chargement d’un gros fichier PPT contenant des images. Existe‑t‑il une limitation de taille de fichier dans Aspose.Slides ?**

**A** : Il n’existe pas de formule précise pour calculer la taille de présentation prise en charge par Aspose.Slides. Il doit y avoir suffisamment d’espace pour accueillir l’ensemble de la structure de la présentation et les images en mémoire. En général, les images en mémoire occupent plus d’espace que sur le disque dur, surtout lorsqu’elles possèdent des effets supplémentaires.

En règle générale, Aspose.Slides pour Python via .NET peut facilement gérer des fichiers de présentation d’environ 300 Mo sur un serveur disposant de 4 Go de RAM.

## **Travail avec les diapositives**

**Q : Puis‑je modifier la taille des diapositives d’une présentation ?**

**A** : Vous pouvez utiliser la propriété `slide_size` exposée par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour définir la taille des diapositives d’une présentation.

**Q : Existe‑t‑il un moyen de définir des diapositives de tailles différentes dans une même présentation ?**

**A** : La taille des diapositives est définie au niveau de la présentation dans les documents Microsoft PowerPoint ; il n’est pas possible de le faire différemment.

**Q : Aspose.Slides pour Python via .NET prend‑il en charge l’aperçu d’une diapositive avant l’enregistrement ?**

**A** : Vous pouvez rendre les diapositives de la présentation sous forme d’images et utiliser ces images pour l’aperçu des diapositives.

## **Travail avec le texte**

**Q : Est‑il possible de récupérer tout le texte d’une présentation ?**

**A** : Aspose.Slides pour Python via .NET fournit la classe [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) dans l’espace de noms `aspose.slides.util` qui propose diverses méthodes pour extraire l’ensemble du texte des présentations.

**Q : Pourquoi les tailles de paragraphe diffèrent‑elles entre les systèmes d’exploitation Windows et Linux ?**

**A** : Le calcul des tailles de paragraphe repose sur le calcul de la taille du texte représentant le paragraphe donné. Cette taille de texte est basée sur les métriques de la police spécifiée dans la présentation PowerPoint. Si la police spécifiée est manquante, elle est remplacée par la police la plus similaire, mais celle‑ci possède des métriques différentes de l’originale. En conséquence, le calcul des tailles de paragraphe sur différents systèmes peut donner des résultats différents selon l’ensemble de polices installées. Pour obtenir le même résultat sur différents systèmes d’exploitation, vous devez installer les mêmes polices sur les systèmes ou les charger à l’exécution comme [polices externes](/slides/fr/python-net/custom-font/).

## **Mise en forme et images**

**Q : Comment définir la couleur de la bordure d’un tableau ?**

**A** : Vous pouvez modifier la couleur de toutes les bordures du tableau ou uniquement la bordure entourant le tableau entier. Pour changer toutes les bordures, utilisez la propriété `cell_format` de la classe [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/). Pour la bordure du tableau complet, il faut parcourir les cellules et changer la couleur des bordures extérieures.

**Q : Quelle unité de mesure Aspose.Slides pour Python via .NET utilise‑t‑il pour placer les images ?**

**A** : Les coordonnées et les tailles de toutes les formes sur les diapositives sont mesurées en points (72 dpi).

## **Travail avec les polices**

**Q : Lors de la conversion d’un PPT en PDF ou en images, pourquoi les polices diffèrent‑elles dans les documents de sortie ?**

**A** : Ce problème peut indiquer que les polices utilisées dans la présentation sont manquantes sur le système d’exploitation où le code a été exécuté. Vous devez installer les polices sur le système d’exploitation ou les charger comme polices externes en utilisant la classe [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) comme indiqué ci‑dessous :
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```
