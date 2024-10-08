---
title: FAQs
type: docs
weight: 340
url: /fr/net/faqs/
keywords:
- FAQ
- PowerPoint
- format de présentation
- exception d\'insuffisance de mémoire
- taille de diapositive
- extraire le texte
- récupérer le texte
- taille de paragraphe
- mise en forme des tableaux
- police
- C#
- .NET
- Aspose.Slides pour .NET
---

## **Formats de fichier pris en charge**

**Q: Quels formats de fichier Aspose.Slides pour .NET prend-il en charge ?**

**A**: Aspose.Slides pour .NET prend en charge les formats de fichier décrits dans [Formats de fichier pris en charge](/slides/fr/net/supported-file-formats/).

## **Exceptions**

**Q: Je reçois une OutOfMemoryException en chargeant un grand fichier PPT avec des images. Y a-t-il une limitation dans Aspose.Slides concernant la taille des fichiers ?**

**A**: Il n'existe pas de formule spécifique pour calculer la taille de présentation prise en charge par Aspose.Slides. Il devrait y avoir suffisamment d'espace pour accueillir la structure de la présentation et les images en mémoire. Normalement, les images en mémoire occupent plus d'espace que sur le disque dur, surtout lorsque les images ont des effets supplémentaires.

En général, Aspose.Slides pour .NET peut facilement gérer des fichiers de présentation d'environ 300 Mo sur un serveur avec 4 Go de RAM.

## **Travailler avec les diapositives**

**Q: Puis-je modifier la taille des diapositives dans une présentation ?**

**A**: Vous pouvez utiliser la propriété `SlideSize` exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) pour définir la taille des diapositives dans une présentation.

**Q: Existe-t-il un moyen de définir des diapositives de taille différente dans une présentation ?**

**A**: Puisque la taille des diapositives est définie au niveau de la présentation dans les documents Microsoft PowerPoint, il n'est pas possible de faire cela.

**Q: Aspose.Slides pour .NET prend-il en charge l'aperçu d'une diapositive avant l'enregistrement ?**

**A**: Vous pouvez rendre les diapositives de présentation en images et utiliser ces images pour prévisualiser les diapositives.

## **Travailler avec le texte**

**Q: Est-il possible de récupérer tout le texte d'une présentation ?**

**A**: Aspose.Slides pour .NET fournit la classe [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) sous l'espace de noms `Aspose.Slides.Util` qui offre diverses méthodes pour récupérer l'intégralité du texte des présentations.

**Q: Pourquoi les tailles de paragraphe sont-elles différentes sur les systèmes d'exploitation Windows et Linux ?**

**A**: Le calcul des tailles de paragraphe est basé sur le calcul de la taille du texte représentant le paragraphe donné. Le calcul de la taille du texte est basé sur les métriques de la police spécifiée dans la présentation PowerPoint. Si la police spécifiée est manquante, elle est remplacée par la police la plus similaire, mais cette police a des métriques différentes de celles d'origine. En conséquence, le calcul des tailles de paragraphe sur différents systèmes entraînera des résultats différents selon l'ensemble de polices installées. Pour obtenir le même résultat sur différents systèmes d'exploitation, vous devez installer les mêmes polices sur les systèmes ou les charger à l'exécution en tant que [polices externes](/slides/fr/net/custom-font/).

## **Mise en forme et images**

**Q: Comment puis-je définir la couleur d'une bordure de tableau ?**

**A**: Vous pouvez changer la couleur de toutes les bordures de tableau ou juste la bordure autour de l'ensemble du tableau. Pour changer toutes les bordures, veuillez utiliser la propriété `CellFormat` de l'interface [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/). Pour la bordure de l'ensemble du tableau, vous devez itérer sur les cellules et changer la couleur des bordures extérieures.

**Q: Quelle mesure Aspose.Slides pour .NET utilise-t-il pour placer des images ?**

**A**: Les coordonnées et tailles de toutes les formes sur les diapositives sont mesurées en points (72 dpi).

## **Travailler avec les polices**

**Q: Lors de la conversion de PPT en PDF ou en images, pourquoi les polices sont-elles différentes dans les documents de sortie ?**

**A**: Ce problème pourrait indiquer que les polices utilisées dans la présentation sont manquantes sur le système d'exploitation sur lequel le code a été exécuté. Vous devez installer les polices sur le système d'exploitation ou les charger en tant que polices externes en utilisant la classe [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) comme indiqué ci-dessous :
```cs
var folders = new string[] { "chemin_vers_un_dossier_avec_des_polices" };
FontsLoader.LoadExternalFonts(folders);
```