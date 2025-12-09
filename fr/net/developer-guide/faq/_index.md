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
- extraire le texte
- récupérer le texte
- taille de paragraphe
- mise en forme des tables
- police
- .NET
- C#
- Aspose.Slides
description: "Obtenez des réponses aux FAQ sur Aspose.Slides pour .NET, couvrant le support PowerPoint et OpenDocument, les conseils d'installation, la licence, le dépannage."
---

## **Formats de fichiers pris en charge**

**Q: Quels formats de fichiers Aspose.Slides pour .NET prend‑il en charge ?**  
**A**: Aspose.Slides for .NET prend en charge les formats de fichiers décrits dans [Supported File Formats](/slides/fr/net/supported-file-formats/).

## **Exceptions**

**Q: Je reçois une OutOfMemoryException lors du chargement d'un gros fichier PPT contenant des images. Y a‑t‑il une limitation dans Aspose.Slides concernant la taille des fichiers ?**  
**A**: Il n'existe pas de formule spécifique pour calculer la taille de présentation prise en charge par Aspose.Slides. Il doit y avoir suffisamment d'espace pour contenir toute la structure de la présentation et les images en mémoire. Normalement, les images en mémoire occupent plus d'espace que sur le disque dur, surtout lorsque les images ont des effets supplémentaires.

En général, Aspose.Slides pour .NET peut facilement gérer des fichiers de présentation d'environ 300 Mo sur un serveur disposant de 4 Go de RAM.

## **Travailler avec les diapositives**

**Q: Puis‑je modifier la taille des diapositives dans une présentation ?**  
**A**: Vous pouvez utiliser la propriété `SlideSize` exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) pour définir la taille des diapositives dans une présentation.

**Q: Existe‑t‑il un moyen de définir des diapositives de tailles différentes dans une présentation ?**  
**A**: Étant donné que la taille des diapositives est définie au niveau de la présentation dans les documents Microsoft PowerPoint, il n'est pas possible de le faire.

**Q: Aspose.Slides pour .NET prend‑il en charge la prévisualisation d'une diapositive avant l'enregistrement ?**  
**A**: Vous pouvez rendre les diapositives de la présentation sous forme d'images et utiliser ces images pour prévisualiser les diapositives.

## **Travailler avec le texte**

**Q: Est‑il possible de récupérer tout le texte d'une présentation ?**  
**A**: Aspose.Slides for .NET fournit la classe [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) dans l'espace de noms `Aspose.Slides.Util` qui propose diverses méthodes pour récupérer l'intégralité du texte des présentations.

**Q: Pourquoi les tailles de paragraphe diffèrent‑elles entre les systèmes d'exploitation Windows et Linux ?**  
**A**: Le calcul des tailles de paragraphe repose sur le calcul de la taille du texte représentant le paragraphe donné. Le calcul de la taille du texte s'appuie sur les métriques de la police spécifiée dans la présentation PowerPoint. Si la police spécifiée est absente, elle est remplacée par la police la plus similaire, mais cette police possède des métriques différentes de l'originale. En conséquence, le calcul des tailles de paragraphe sur différents systèmes donnera des résultats différents selon l'ensemble des polices installées. Pour obtenir le même résultat sur différents systèmes d'exploitation, vous devez installer les mêmes polices sur les systèmes ou les charger au moment de l'exécution en tant que [external fonts](/slides/fr/net/custom-font/).

## **Mise en forme et images**

**Q: Comment définir la couleur d'une bordure de tableau ?**  
**A**: Vous pouvez changer la couleur de toutes les bordures du tableau ou uniquement la bordure autour du tableau entier. Pour modifier toutes les bordures, veuillez utiliser la propriété `CellFormat` de l'interface [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/). Pour la bordure du tableau complet, vous devez parcourir les cellules et changer la couleur des bordures extérieures.

**Q: Quelle unité de mesure Aspose.Slides pour .NET utilise‑t‑il pour placer les images ?**  
**A**: Les coordonnées et les tailles de toutes les formes sur les diapositives sont mesurées en points (72 dpi).

## **Travailler avec les polices**

**Q: Lors de la conversion de PPT en PDF ou images, pourquoi les polices diffèrent‑elles dans les documents de sortie ?**  
**A**: Ce problème peut indiquer que les polices utilisées dans la présentation sont absentes du système d'exploitation sur lequel le code a été exécuté. Vous devez installer les polices sur le système d'exploitation ou les charger en tant que polices externes à l'aide de la classe [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) comme indiqué ci‑dessous :
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```
