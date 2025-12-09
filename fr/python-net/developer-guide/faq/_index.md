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
description: "Obtenez des réponses aux FAQ sur Aspose.Slides pour Python via .NET, couvrant la prise en charge de PowerPoint et OpenDocument, les conseils d'installation, la licence, le dépannage."
---

## **Formats de fichiers pris en charge**

**Q:** Quels formats de fichiers Aspose.Slides for Python via .NET prend-il en charge?  
**A:** Aspose.Slides for Python via .NET prend en charge les formats de fichiers décrits dans [Supported File Formats](/slides/fr/python-net/supported-file-formats/).

## **Exceptions**

**Q:** Je reçois une exception "out of memory" lors du chargement d'un gros fichier PPT avec des images. Existe-t-il une limitation de taille de fichier dans Aspose.Slides?  
**A:** Il n'existe pas de formule précise pour calculer la taille de présentation prise en charge par Aspose.Slides. Il doit y avoir assez d'espace pour contenir toute la structure de la presentation et les images en mémoire. Normalement, les images en memoire occupent plus d'espace que sur le disque dur, surtout lorsqu'elles possedent des effets supplementaires.

En general, Aspose.Slides for Python via .NET peut facilement gerer des fichiers de presentation d'environ 300 Mo sur un serveur disposant de 4 Go de RAM.

## **Travail avec les diapositives**

**Q:** Puis-je modifier la taille des diapositives d'une presentation?  
**A:** Vous pouvez utiliser la propriete `slide_size` exposee par la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour definir la taille des diapositives d'une presentation.

**Q:** Existe-t-il un moyen de definir des diapositives de tailles differentes dans une meme presentation?  
**A:** Comme la taille des diapositives est définie au niveau de la presentation dans les documents Microsoft PowerPoint, il n'est pas possible de le faire.

**Q:** Aspose.Slides for Python via .NET permet-il d'afficher un aperçu d'une diapositive avant l'enregistrement?  
**A:** Vous pouvez rendre les diapositives de la presentation sous forme d'images et utiliser ces images pour previsualiser les diapositives.

## **Travail avec le texte**

**Q:** Est-il possible de recuperer tout le texte d'une presentation?  
**A:** Aspose.Slides for Python via .NET fournit la classe [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) dans l'espace de noms `aspose.slides.util` qui propose diverses methodes pour extraire le texte complet des presentations.

**Q:** Pourquoi les tailles de paragraphe diferent-elles sous Windows et Linux?  
**A:** Le calcul des tailles de paragraphe se base sur le calcul de la taille du texte representant le paragraphe donne. Le calcul de la taille du texte repose sur les metriques de la police specifiee dans la presentation PowerPoint. Si la police specifiee est manquante, elle est remplacee par la police la plus similaire, mais ses metriques differents de l'originale. Ainsi, le calcul des tailles de paragraphe sur differents systemes conduit a des resultats differents selon l'ensemble de polices installees. Pour obtenir le meme resultat sur differents systemes d'exploitation, vous devez installer les memes polices sur les machines ou les charger a l'execution en tant que [external fonts](/slides/fr/python-net/custom-font/).

## **Mise en forme et images**

**Q:** Comment definir la couleur du contour d'un tableau?  
**A:** Vous pouvez modifier la couleur de tous les contours du tableau ou uniquement le contour entourant l'ensemble du tableau. Pour modifier tous les contours, utilisez la propriete `cell_format` de la classe [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/). Pour le contour du tableau complet, il faut parcourir les cellules et changer la couleur des bordures externes.

**Q:** Quelle unite de mesure Aspose.Slides for Python via .NET utilise-t-il pour placer les images?  
**A:** Les coordonnees et les tailles de toutes les formes sur les diapositives sont mesurees en points (72 dpi).

## **Travail avec les polices**

**Q:** Lors de la conversion PPT en PDF ou en images, pourquoi les polices diffèrent-elles dans les documents de sortie?  
**A:** Ce probleme peut indiquer que les polices utilisees dans la presentation sont absentes du systeme d'exploitation sur lequel le code a ete execute. Vous devez installer les polices sur le systeme d'exploitation ou les charger en tant que polices externes a l'aide de la classe [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) comme illustré ci-dessous:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```
