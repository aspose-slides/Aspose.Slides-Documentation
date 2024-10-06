---
title: FAQ
type: docs
weight: 340
url: /python-net/faqs/
keywords:
- FAQ
- PowerPoint
- format de présentation
- erreur de mémoire insuffisante
- taille de diapositive
- extraire le texte
- récupérer le texte
- taille de paragraphe
- formatage des tableaux
- police
- Python
- Aspose.Slides pour Python via .NET
---

## **Formats de Fichier Pris en Charge**

**Q : Quels formats de fichier Aspose.Slides pour Python via .NET prend-il en charge ?**

**R** : Aspose.Slides pour Python via .NET prend en charge les formats de fichier décrits dans [Formats de Fichier Pris en Charge](/slides/python-net/supported-file-formats/).

## **Exceptions**

**Q : Je reçois une exception de mémoire insuffisante lors du chargement d'un gros fichier PPT avec des images. Y a-t-il une limitation dans Aspose.Slides concernant la taille des fichiers ?**

**R** : Il n'existe pas de formule spécifique pour calculer la taille de présentation prise en charge par Aspose.Slides. Il doit y avoir suffisamment d'espace pour accueillir toute la structure de présentation et les images en mémoire. Normalement, les images en mémoire occupent plus d'espace que sur le disque dur, en particulier lorsque les images ont des effets supplémentaires.

En général, Aspose.Slides pour Python via .NET peut facilement gérer des fichiers de présentation d'environ 300 Mo sur un serveur avec 4 Go de RAM.

## **Travailler avec les Diapositives**

**Q : Puis-je modifier la taille des diapositives dans une présentation ?**

**R** : Vous pouvez utiliser la propriété `slide_size` exposée par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour définir la taille des diapositives dans une présentation.

**Q : Existe-t-il un moyen de définir des diapositives de tailles différentes dans une présentation ?**

**R** : Étant donné que la taille des diapositives est définie au niveau de la présentation dans les documents Microsoft PowerPoint, il n'est pas possible de faire cela.

**Q : Aspose.Slides pour Python via .NET prend-il en charge l'aperçu d'une diapositive avant l'enregistrement ?**

**R** : Vous pouvez rendre les diapositives de présentation en images et utiliser ces images pour prévisualiser les diapositives.

## **Travailler avec le Texte**

**Q : Est-il possible de récupérer tout le texte d'une présentation ?**

**R** : Aspose.Slides pour Python via .NET fournit la classe [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) sous l'espace de noms `aspose.slides.util`, qui fournit diverses méthodes pour récupérer l'ensemble du texte des présentations.

**Q : Pourquoi les tailles de paragraphe diffèrent-elles entre les systèmes d'exploitation Windows et Linux ?**

**R** : Le calcul des tailles de paragraphe est basé sur le calcul de la taille du texte représentant le paragraphe donné. Le calcul de la taille du texte est basé sur les métriques de la police spécifiée dans la présentation PowerPoint. Si la police spécifiée est manquante, elle est remplacée par la police la plus similaire, mais cette police a des métriques différentes de celles d'origine. En conséquence, le calcul des tailles de paragraphe sur différents systèmes entraînera des résultats différents en fonction de l'ensemble des polices installées. Pour obtenir le même résultat sur différents systèmes d'exploitation, vous devez installer les mêmes polices sur les systèmes ou les charger à l'exécution en tant que [polices externes](/slides/python-net/custom-font/).

## **Formatage et Images**

**Q : Comment puis-je définir la couleur d'une bordure de tableau ?**

**R** : Vous pouvez changer la couleur de toutes les bordures de tableau ou juste la bordure autour du tableau entier. Pour changer toutes les bordures, veuillez utiliser la propriété `cell_format` de la classe [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/). Pour la bordure du tableau entier, vous devez itérer sur les cellules et changer la couleur des bordures extérieures.

**Q : Quelle mesure Aspose.Slides pour Python via .NET utilise-t-il pour placer des images ?**

**R** : Les coordonnées et tailles de toutes les formes sur les diapositives sont mesurées en points (72 dpi).

## **Travailler avec les Polices**

**Q : Lors de la conversion de PPT en PDF ou en images, pourquoi les polices sont-elles différentes dans les documents de sortie ?**

**R** : Ce problème peut indiquer que les polices utilisées dans la présentation sont manquantes sur le système d'exploitation sur lequel le code a été exécuté. Vous devez installer les polices sur le système d'exploitation ou les charger en tant que polices externes en utilisant la classe [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) comme indiqué ci-dessous :
```cs
folders = [ "chemin_vers_un_dossier_avec_des_polices" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```