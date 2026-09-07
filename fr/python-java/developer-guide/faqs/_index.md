---
title: FAQ
type: docs
weight: 340
url: /fr/python-java/faqs/
keywords:
- FAQ
- format de présentation
- erreur de mémoire insuffisante
- taille de diapositive
- extraction de texte
- taille de paragraphe
- bordures de tableau
- police
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Trouvez les réponses aux questions fréquentes sur Aspose.Slides pour Python via Java, y compris les formats de fichiers, l'utilisation de la mémoire, les tailles de diapositives, le texte, les tableaux, les images et les polices."
---
## **Vue d'ensemble**

Cette FAQ couvre les formats de fichiers pris en charge, l'utilisation de la mémoire avec les présentations volumineuses, les tailles et les aperçus des diapositives, l'extraction de texte, les bordures des tableaux, le positionnement des images et les différences de polices lors de la conversion des présentations en PDF ou en images.

## **FAQ**

### **Formats de fichiers pris en charge**

**Quels formats de fichiers Aspose.Slides pour Python via Java prend-il en charge ?**

See [Formats de fichiers pris en charge](/slides/fr/python-java/supported-file-formats/) pour les formats de présentation, de document et d'image pris en charge ainsi que leurs capacités d'importation et d'exportation.

### **Exceptions**

**Pourquoi obtient‑je une erreur de mémoire insuffisante lors du chargement d'une grande présentation avec des images ? Existe‑t‑il une limite de taille de fichier ?**

Il n'existe pas de seuil de taille de fichier unique permettant de prévoir si une présentation tiendra en mémoire. Les exigences en matière de mémoire dépendent de la structure de la présentation, des images décompressées, des effets et des opérations que vous effectuez. Les images peuvent occuper beaucoup plus de mémoire que leur taille compressée sur le disque.

Aspose.Slides for Python via Java utilise le moteur Java via JPype, de sorte que le tas de la JVM doit disposer de suffisamment d'espace pour le traitement. La RAM système disponible à elle seule n'indique pas la quantité de mémoire que la JVM peut utiliser. Libérez les présentations avec [Presentation.dispose](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#dispose) lorsque vous avez fini de les utiliser. Pour la configuration de l'environnement, consultez [Exigences du système](/slides/fr/python-java/system-requirements/) et [Installation](/slides/fr/python-java/installation/).

### **Travailler avec les diapositives**

**Puis‑je modifier la taille des diapositives dans une présentation ?**

Oui. Utilisez [Presentation.getSlideSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getslidesize) pour accéder aux paramètres de taille des diapositives de la présentation, puis utilisez [SlideSize.setSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesize/#setsize) pour définir les dimensions et choisir comment le contenu existant est mis à l'échelle.

**Les diapositives d'une même présentation peuvent‑elles avoir des tailles différentes ?**

Non. Les documents Microsoft PowerPoint définissent la taille des diapositives au niveau de la présentation, de sorte que toutes les diapositives partagent les mêmes dimensions.

**Puis‑je prévisualiser une diapositive avant d'enregistrer la présentation ?**

Oui. Rendu la diapositive en image et affichez cette image dans votre application. Vous n'avez pas besoin d'enregistrer la présentation au préalable.

### **Travailler avec le texte**

**Puis‑je extraire tout le texte d'une présentation ?**

Oui. La classe [SlideUtil](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideutil/) fournit des méthodes pour extraire le texte des présentations et des diapositives individuelles.

**Pourquoi les tailles de paragraphe diffèrent‑elles sous Windows et Linux ?**

Les dimensions des paragraphes dépendent des métriques des polices utilisées pour rendre le texte. Si une police est manquante, un substitut peut avoir des largeurs de caractères et des hauteurs de ligne différentes, ce qui modifie le retour à la ligne et les dimensions du paragraphe. Installez les mêmes polices sur les deux systèmes ou chargez les mêmes fichiers de police avec [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsloader/#loadexternalfonts) avant de créer ou de charger des présentations.

### **Mise en forme et images**

**Comment définir la couleur d'une bordure de tableau ?**

Utilisez [Cell.getCellFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cell/#getcellformat) pour accéder au format de bordure de chaque cellule et définir la couleur de remplissage des bordures concernées. Pour modifier chaque bordure, parcourez toutes les cellules. Pour ne modifier que le contour du tableau, mettez à jour uniquement les bordures extérieures des cellules situées le long de ses bords.

**Quelles unités sont utilisées pour positionner et dimensionner les images ?**

Les coordonnées et dimensions des formes sont exprimées en points. Un pouce équivaut à 72 points ; ces valeurs ne sont pas des coordonnées en pixels.

### **Travailler avec les polices**

**Pourquoi les polices changent‑elles lors de la conversion d'une présentation en PDF ou en images ?**

Les polices requises peuvent être absentes de la machine qui effectue la conversion. Installez les polices d'origine ou utilisez [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsloader/#loadexternalfonts) pour ajouter les dossiers les contenant. Chargez les polices externes avant de créer ou d'ouvrir des présentations.

L'exemple suivant enregistre un dossier de polices. Remplacez le chemin par un dossier existant contenant vos fichiers de police. Il suppose l'environnement décrit dans [Installation](/slides/fr/python-java/installation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

L'exemple laisse la JVM en cours d'exécution pour les opérations de présentation ultérieures. Pour l'utilisation dans les notebooks et les restrictions du cycle de vie de la JVM, consultez [Limitations et différences d'API](/slides/fr/python-java/limitations-and-api-differences/).