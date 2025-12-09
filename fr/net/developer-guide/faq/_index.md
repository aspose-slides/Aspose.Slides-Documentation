---
title: FAQ
type: docs
weight: 340
url: /fr/net/faqs/
keywords:
- FAQ
- PowerPoint
- format de présentation
- erreur de mémoire insuffisante
- taille de diapositive
- extraction de texte
- récupération de texte
- taille de paragraphe
- mise en forme des tableaux
- police
- .NET
- C#
- Aspose.Slides
description: "Obtenez les réponses aux FAQ sur Aspose.Slides for .NET, couvrant la prise en charge de PowerPoint et OpenDocument, les instructions d'installation, la licence, le dépannage."
---

## **Formats de fichier pris en charge**

**Q:** Quels formats de fichier Aspose.Slides for .NET prend‑il en charge ?  
**A:** Aspose.Slides for .NET prend en charge les formats de fichier décrits dans [Supported File Formats](/slides/fr/net/supported-file-formats/).

## **Exceptions**

**Q:** Je reçois une OutOfMemoryException lors du chargement d'un gros fichier PPT avec des images. Existe‑t‑il une limitation dans Aspose.Slides concernant la taille du fichier ?  
**A:** Il n'existe pas de formule spécifique pour calculer la taille de présentation prise en charge par Aspose.Slides. Il doit y avoir suffisamment d'espace pour contenir toute la structure de la présentation et les images en mémoire. Normalement, les images en mémoire occupent plus d'espace que sur le disque dur, notamment lorsque les images ont des effets supplémentaires.  
En général, Aspose.Slides for .NET peut gérer facilement des fichiers de présentation d'environ 300 Mo sur un serveur disposant de 4 Go de RAM.

## **Travailler avec les diapositives**

**Q:** Puis‑je changer la taille des diapositives dans une présentation ?  
**A:** Vous pouvez utiliser la propriété `SlideSize` exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) pour définir la taille des diapositives dans une présentation.

**Q:** Existe‑t‑il un moyen de définir des diapositives de tailles différentes dans une présentation ?  
**A:** Étant donné que la taille des diapositives est définie au niveau de la présentation dans les documents Microsoft PowerPoint, il n'est pas possible de le faire.

**Q:** Aspose.Slides for .NET prend‑il en charge l'aperçu d'une diapositive avant l'enregistrement ?  
**A:** Vous pouvez rendre les diapositives de la présentation en images et utiliser ces images pour prévisualiser les diapositives.

## **Travailler avec le texte**

**Q:** Est‑il possible de récupérer tout le texte d'une présentation ?  
**A:** Aspose.Slides for .NET fournit la classe [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) dans l'espace de noms `Aspose.Slides.Util` qui offre diverses méthodes pour récupérer l'ensemble du texte des présentations.

**Q:** Pourquoi les tailles de paragraphe diffèrent‑elles entre les systèmes d'exploitation Windows et Linux ?  
**A:** Le calcul des tailles de paragraphe repose sur le calcul de la taille du texte représentant le paragraphe donné. Le calcul de la taille du texte s'appuie sur les métriques de la police spécifiée dans la présentation PowerPoint. Si la police spécifiée est absente, elle est remplacée par la police la plus similaire, mais cette police possède des métriques différentes de l'originale. En conséquence, le calcul des tailles de paragraphe sur différents systèmes donnera des résultats différents selon l'ensemble de polices installées. Pour obtenir le même résultat sur différents systèmes d'exploitation, vous devez installer les mêmes polices sur les systèmes ou les charger à l'exécution en tant que [polices externes](/slides/fr/net/custom-font/).

## **Mise en forme et images**

**Q:** Comment puis‑je définir la couleur d'une bordure de tableau ?  
**A:** Vous pouvez changer la couleur de toutes les bordures du tableau ou seulement de la bordure autour du tableau entier. Pour changer toutes les bordures, veuillez utiliser la propriété `CellFormat` de l'interface [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/). Pour la bordure du tableau entier, vous devez parcourir les cellules et changer la couleur des bordures externes.

**Q:** Quelle unité Aspose.Slides for .NET utilise‑t‑il pour placer les images ?  
**A:** Les coordonnées et les tailles de toutes les formes sur les diapositives sont mesurées en points (72 dpi).

## **Travailler avec les polices**

**Q:** Lors de la conversion de PPT en PDF ou en images, pourquoi les polices diffèrent‑elles dans les documents de sortie ?  
**A:** Ce problème peut indiquer que les polices utilisées dans la présentation sont absentes du système d'exploitation sur lequel le code a été exécuté. Vous devez installer les polices sur le système d'exploitation ou les charger en tant que polices externes à l'aide de la classe [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) comme indiqué ci‑dessous :
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```
