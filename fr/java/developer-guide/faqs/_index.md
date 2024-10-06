---
title: FAQs
type: docs
weight: 340
url: /java/faqs/
keywords:
- FAQ
- PowerPoint
- format de présentation
- erreur de mémoire insuffisante
- taille de diapositive
- extraire du texte
- récupérer du texte
- taille de paragraphe
- formatage de tableaux
- police
- Java
- Aspose.Slides pour Java
---

## **Formats de fichier pris en charge**

**Q : Quels formats de fichier Aspose.Slides pour Java prend-il en charge ?**

**R** : Aspose.Slides pour Java prend en charge les formats de fichier décrits dans [Formats de fichier pris en charge](/slides/java/supported-file-formats/).

## **Exceptions**

**Q : Je reçois une exception de mémoire insuffisante en chargeant un grand fichier PPT avec des images. Y a-t-il une limitation dans Aspose.Slides concernant la taille du fichier ?**

**R** : Il n'y a pas de formule spécifique pour calculer la taille de présentation prise en charge par Aspose.Slides. Il doit y avoir suffisamment d'espace pour accueillir toute la structure de la présentation et les images en mémoire. Normalement, les images en mémoire occupent plus d'espace que sur le disque dur, surtout lorsque les images ont des effets supplémentaires.

En général, Aspose.Slides pour Java peut facilement gérer des fichiers de présentation d'environ 300 Mo sur un serveur avec 4 Go de RAM.

## **Travailler avec les diapositives**

**Q : Puis-je changer la taille des diapositives dans une présentation ?**

**R** : Vous pouvez utiliser la méthode `getSlideSize` exposée par la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) pour définir la taille des diapositives dans une présentation.

**Q : Existe-t-il un moyen de définir des diapositives de taille différente dans une présentation ?**

**R** : Étant donné que la taille des diapositives est définie au niveau de la présentation dans les documents Microsoft PowerPoint, il n’est pas possible de faire cela.

**Q : Aspose.Slides pour Java prend-il en charge l'aperçu d'une diapositive avant l'enregistrement ?**

**R** : Vous pouvez rendre les diapositives de présentation en images et utiliser ces images pour prévisualiser les diapositives.

## **Travailler avec le texte**

**Q : Est-il possible de récupérer tout le texte d'une présentation ?**

**R** : Aspose.Slides pour Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/slideutil/) qui propose diverses méthodes pour récupérer l'intégralité du texte des présentations.

**Q : Pourquoi les tailles de paragraphe sont-elles différentes sur les systèmes d'exploitation Windows et Linux ?**

**R** : Le calcul des tailles de paragraphe est basé sur le calcul de la taille du texte représentant le paragraphe donné. Le calcul de la taille du texte est basé sur les métriques de la police spécifiée dans la présentation PowerPoint. Si la police spécifiée est manquante, elle est remplacée par la police la plus similaire, mais cette police a des métriques différentes de celles d'origine. En conséquence, le calcul des tailles de paragraphe sur différents systèmes entraînera des résultats différents en fonction de l'ensemble des polices installées. Pour obtenir le même résultat sur différents systèmes d'exploitation, vous devez installer les mêmes polices sur les systèmes ou les charger en temps réel en tant que [polices externes](/slides/java/custom-font/).

## **Formatage et images**

**Q : Comment puis-je définir la couleur d'une bordure de tableau ?**

**R** : Vous pouvez changer la couleur de toutes les bordures de tableau ou juste la bordure autour de l'ensemble du tableau. Pour changer toutes les bordures, veuillez utiliser la méthode `getCellFormat` de l'interface [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/). Pour la bordure de l'ensemble du tableau, vous devez itérer sur les cellules et changer la couleur des bordures extérieures.

**Q : Quelle mesure Aspose.Slides pour Java utilise-t-il pour placer des images ?**

**R** : Les coordonnées et les tailles de toutes les formes sur les diapositives sont mesurées en points (72 dpi).

## **Travailler avec les polices**

**Q : Lors de la conversion de PPT en PDF ou en images, pourquoi les polices sont-elles différentes dans les documents de sortie ?**

**R** : Ce problème pourrait indiquer que les polices utilisées dans la présentation manquent sur le système d'exploitation sur lequel le code a été exécuté. Vous devez installer les polices sur le système d'exploitation ou les charger en tant que polices externes en utilisant la classe [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) comme indiqué ci-dessous :
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```