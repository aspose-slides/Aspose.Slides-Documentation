---
title: FAQ
type: docs
weight: 340
url: /php-java/faqs/
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
- PHP
- Java
- Aspose.Slides pour PHP via Java
---

## **Formats de Fichiers Supportés**

**Q: Quels formats de fichiers Aspose.Slides pour PHP via Java supporte-t-il ?**

**A**: Aspose.Slides pour PHP via Java supporte les formats de fichiers décrits dans [Formats de Fichiers Supportés](/slides/php-java/supported-file-formats/).

## **Exceptions**

**Q: Je reçois une exception de mémoire insuffisante lors du chargement d'un grand fichier PPT avec des images. Y a-t-il une limitation dans Aspose.Slides concernant la taille des fichiers ?**

**A**: Il n'existe pas de formule spécifique pour calculer la taille de présentation supportée par Aspose.Slides. Il doit y avoir suffisamment d'espace pour accueillir toute la structure de la présentation et les images en mémoire. Normalement, les images en mémoire occupent plus d'espace que le disque dur, surtout lorsque les images ont des effets supplémentaires.

En général, Aspose.Slides pour PHP via Java peut facilement gérer des fichiers de présentation d'environ 300 Mo sur un serveur avec 4 Go de RAM.

## **Travailler avec des Diapositives**

**Q: Puis-je changer la taille des diapositives dans une présentation ?**

**A**: Vous pouvez utiliser la méthode `getSlideSize` exposée par la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) pour définir la taille des diapositives dans une présentation.

**Q: Existe-t-il un moyen de définir des diapositives de tailles différentes dans une présentation ?**

**A**: Étant donné que la taille des diapositives est définie au niveau de la présentation dans les documents Microsoft PowerPoint, il n'y a pas moyen de le faire.

**Q: Aspose.Slides pour PHP via Java supporte-t-il l'aperçu d'une diapositive avant de la sauvegarder ?**

**A**: Vous pouvez rendre les diapositives de présentation en images et utiliser ces images pour prévisualiser les diapositives.

## **Travailler avec le Texte**

**Q: Est-il possible de récupérer tout le texte d'une présentation ?**

**A**: Aspose.Slides pour PHP via Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/) qui offre diverses méthodes pour récupérer tout le texte des présentations.

**Q: Pourquoi les tailles de paragraphe diffèrent-elles sur les systèmes d'exploitation Windows et Linux ?**

**A**: Le calcul des tailles de paragraphe est basé sur le calcul de la taille de texte représentant le paragraphe donné. Le calcul de la taille de texte est basé sur les métriques de la police spécifiée dans la présentation PowerPoint. Si la police spécifiée est manquante, elle est remplacée par la police la plus similaire, mais cette police a des métriques différentes de celles d'origine. Par conséquent, le calcul des tailles de paragraphe sur différents systèmes conduira à des résultats différents selon l'ensemble des polices installées. Pour obtenir le même résultat sur différents systèmes d'exploitation, vous devez installer les mêmes polices sur les systèmes ou les charger à l'exécution en tant que [polices externes](/slides/php-java/custom-font/).

## **Formatage et Images**

**Q: Comment puis-je définir la couleur d'une bordure de tableau ?**

**A**: Vous pouvez changer la couleur de toutes les bordures du tableau ou juste la bordure autour du tableau entier. Pour changer toutes les bordures, veuillez utiliser la méthode `getCellFormat` de la classe [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/). Pour la bordure du tableau entier, vous devez itérer sur les cellules et changer la couleur des bordures extérieures.

**Q: Quelle mesure Aspose.Slides pour PHP via Java utilise-t-il pour placer des images ?**

**A**: Les coordonnées et tailles de toutes les formes sur les diapositives sont mesurées en points (72 dpi).

## **Travailler avec les Polices**

**Q: Lors de la conversion de PPT en PDF ou en images, pourquoi les polices sont-elles différentes dans les documents de sortie ?**

**A**: Ce problème peut indiquer que les polices utilisées dans la présentation sont manquantes sur le système d'exploitation sur lequel le code a été exécuté. Vous devez installer les polices sur le système d'exploitation ou les charger en tant que polices externes en utilisant la classe [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) comme montré ci-dessous :
```cs
$folders = ["chemin_du_dossier_avec_les_polices"];
FontsLoader::loadExternalFonts($folders);
```