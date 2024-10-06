---
title: FAQs
type: docs
weight: 340
url: /cpp/faqs/
keywords:
- FAQ
- PowerPoint
- format de présentation
- exception de mémoire insuffisante
- taille de diapositive
- extraire du texte
- récupérer du texte
- taille de paragraphe
- mise en forme des tableaux
- police
- С++
- Aspose.Slides pour С++
---

## **Formats de Fichier Pris en Charge**

**Q: Quels formats de fichier Aspose.Slides pour C++ supporte-t-il ?**

**A**: Aspose.Slides pour C++ supporte les formats de fichier décrits dans [Formats de Fichier Pris en Charge](/slides/cpp/supported-file-formats/).

## **Exceptions**

**Q: Je reçois une exception de mémoire insuffisante en chargeant un gros fichier PPT avec des images. Y a-t-il une limitation dans Aspose.Slides concernant la taille des fichiers ?**

**A**: Il n'y a pas de formule spécifique pour calculer la taille de présentation prise en charge par Aspose.Slides. Il doit y avoir suffisamment d'espace pour accueillir l'ensemble de la structure de présentation et des images en mémoire. Normalement, les images en mémoire occupent plus d'espace que le disque dur, surtout lorsque les images ont des effets supplémentaires.

En général, Aspose.Slides pour C++ peut facilement gérer des fichiers de présentation d'environ 300 Mo sur un serveur avec 4 Go de RAM.

## **Travailler avec les Diapositives**

**Q: Puis-je changer la taille des diapositives dans une présentation ?**

**A**: Vous pouvez utiliser la méthode `get_SlideSize` exposée par la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) pour définir la taille des diapositives dans une présentation.

**Q: Existe-t-il un moyen de définir des diapositives de tailles différentes dans une présentation ?**

**A**: Étant donné que la taille des diapositives est définie au niveau de la présentation dans les documents Microsoft PowerPoint, il n'est pas possible de faire cela.

**Q: Aspose.Slides pour C++ supporte-t-il l'aperçu d'une diapositive avant de sauvegarder ?**

**A**: Vous pouvez rendre les diapositives de présentation en images et utiliser ces images pour prévisualiser les diapositives.

## **Travailler avec du Texte**

**Q: Est-il possible de récupérer tout le texte d'une présentation ?**

**A**: Aspose.Slides pour C++ fournit la classe [SlideUtil](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/) sous le namespace `Aspose::Slides::Util` qui propose divers méthodes pour récupérer l'ensemble du texte des présentations.

**Q: Pourquoi les tailles de paragraphe sont-elles différentes sur les systèmes d'exploitation Windows et Linux ?**

**A**: Le calcul des tailles de paragraphe est basé sur le calcul de la taille de texte représentant le paragraphe donné. Le calcul de la taille du texte est basé sur les métriques de la police spécifiée dans la présentation PowerPoint. Si la police spécifiée est manquante, elle est remplacée par la police la plus similaire, mais cette police a des métriques différentes de celles d'origine. En conséquence, le calcul des tailles de paragraphe dans différents systèmes donnera des résultats différents selon l'ensemble des polices installées. Pour obtenir le même résultat sur différents systèmes d'exploitation, vous devez installer les mêmes polices sur les systèmes ou les charger au moment de l'exécution comme [polices externes](/slides/cpp/custom-font/).

## **Mise en Forme et Images**

**Q: Comment puis-je définir la couleur d'une bordure de tableau ?**

**A**: Vous pouvez changer la couleur de toutes les bordures de tableau ou seulement la bordure autour de l'ensemble du tableau. Pour changer toutes les bordures, veuillez utiliser la méthode `get_CellFormat` de l'interface [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/). Pour la bordure de l'ensemble du tableau, vous devez itérer les cellules et changer la couleur des bordures extérieures.

**Q: Quelle mesure Aspose.Slides pour C++ utilise-t-il pour placer des images ?**

**A**: Les coordonnées et tailles de toutes les formes sur les diapositives sont mesurées en points (72 dpi).

## **Travailler avec les Polices**

**Q: Lors de la conversion d'un PPT en PDF ou en images, pourquoi les polices sont-elles différentes dans les documents de sortie ?**

**A**: Ce problème peut indiquer que les polices utilisées dans la présentation sont manquantes sur le système d'exploitation sur lequel le code a été exécuté. Vous devez installer les polices sur le système d'exploitation ou les charger comme polices externes en utilisant la classe [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) comme montré ci-dessous:
```cpp
auto folders = MakeObject<Array<String>>(1, "path_to_a_folder_with_fonts");
FontsLoader::LoadExternalFonts(folders);
```