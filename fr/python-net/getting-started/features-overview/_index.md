---
title: Aperçu des fonctionnalités
type: docs
weight: 20
url: /fr/python-net/features-overview/
---

## **Plateformes prises en charge**
Les plateformes Aspose.Slides pour Python via .NET peuvent être utilisées sur Windows x64 ou x86 et sur un large éventail de distributions Linux avec Python 3.5 ou une version ultérieure installée. Il y a des exigences supplémentaires pour la plateforme Linux ciblée :
- Bibliothèques d'exécution GCC-6 (ou ultérieures)
- Dépendances de .NET Core Runtime. L'installation de .NET Core Runtime lui-même n'est PAS requise
- Pour Python 3.5-3.7 : La version `pymalloc` de Python est nécessaire. L'option de construction Python `--with-pymalloc` est activée par défaut. En général, la version `pymalloc` de Python est marquée avec le suffixe `m` dans le nom de fichier.
- Bibliothèque partagée Python `libpython`. L'option de construction Python `--enable-shared` est désactivée par défaut, certaines distributions Python ne contiennent pas la bibliothèque partagée `libpython`. Pour certaines plateformes Linux, la bibliothèque partagée `libpython` peut être installée à l'aide du gestionnaire de paquets, par exemple : `sudo apt-get install libpython3.7`. Le problème commun est que la bibliothèque `libpython` est installée dans un emplacement différent de l'emplacement standard du système pour les bibliothèques partagées. Ce problème peut être résolu en utilisant les options de construction Python pour définir des chemins de bibliothèque alternatifs lors de la compilation de Python, ou en créant un lien symbolique vers le fichier de bibliothèque `libpython` dans l'emplacement standard du système pour les bibliothèques partagées. En général, le nom de fichier de la bibliothèque partagée `libpython` est `libpythonX.Ym.so.1.0` pour Python 3.5-3.7, ou `libpythonX.Y.so.1.0` pour Python 3.8 ou ultérieur (par exemple : `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Si vous avez besoin de support pour plus de plateformes, recherchez les produits "frères jumeaux", Aspose.Slides pour .NET ou Aspose.Slides pour Java.


## **Formats de fichiers et conversions**
Aspose.Slides pour Python via .NET prend en charge la plupart des formats de documents PowerPoint. Il vous permet également de les exporter vers les formats populaires couramment utilisés et échangés par les organisations. Consultez ces détails :

|**Fonctionnalité**|**Description**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/fr/python-net/ppt-vs-pptx/)|Aspose.Slides pour Python via .NET fournit le traitement le plus rapide pour ce format de document de présentation.|
|[Conversion PPT en PPTX](/slides/fr/python-net/convert-ppt-to-pptx/)|Aspose.Slides pour Python via .NET prend en charge la conversion de PPT en PPTX.|
|[Format de document portable (PDF)](/slides/fr/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Vous pouvez exporter tous les formats de fichiers pris en charge vers des documents au format PDF (Portable Document Format) d'Adobe avec une méthode unique.|
|[Spécification du parseur XML (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|Vous pouvez exporter tous les formats de fichiers pris en charge vers des documents au format XML Parser Specification (XPS) avec une méthode unique.|
|[Format de fichier image tagué (TIFF)](/slides/fr/python-net/convert-powerpoint-to-tiff/)|Vous pouvez exporter tous les formats de fichiers de présentation pris en charge vers le format de fichier image tagué (TIFF).|
|[Conversion PPTX en HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides pour Python via .NET prend en charge la conversion de PresentationEx au format HTML.|

## **Rendu et impression**
Aspose.Slides pour Python via .NET prend en charge le rendu de haute fidélité des diapositives dans les documents de présentation vers divers formats graphiques. Consultez ces détails :

|**Fonctionnalité**|**Description**|
| :- | :- |
|Formats d'image pris en charge par .NET|Avec Aspose.Slides pour Python via .NET, vous obtenez un rendu des diapositives de présentation et des images sur diapositives dans tous les formats graphiques pris en charge par .NET tels que TIFF, PNG, BMP, JPEG, GIF et mét fichiers.|
|Format SVG|Aspose.Slides pour Python via .NET fournit également des méthodes intégrées qui vous permettent d'exporter des diapositives de présentation vers des formats Scalable Vector Graphics (SVG).|
|Impression de présentation|Les dernières versions d'Aspose.Slides pour Python via .NET fournissent des méthodes d'impression intégrées avec différentes options.|
## **Fonctionnalités du contenu**
Aspose.Slides pour Python via .NET vous permet d'accéder, de modifier ou de créer presque tous les éléments ou contenus des documents de présentation. Consultez ces détails :

|**Fonctionnalité**|**Description**|
| :- | :- |
|Diapositives maîtresses|Les diapositives maîtresses définissent la mise en page des diapositives normales. Aspose.Slides pour Python via .NET vous permet d'accéder et de modifier les diapositives maîtresses des documents de présentation.|
|Diapositives normales|Avec Aspose.Slides pour Python via .NET, vous pouvez créer de nouvelles diapositives de différents types ; vous pouvez également accéder et modifier les diapositives existantes dans les présentations.|
|Clonage / Copie de diapositives|Des méthodes intégrées fournies par Aspose.Slides pour Python via .NET vous permettent de cloner ou de copier des diapositives existantes au sein d'une présentation. Vous pouvez également utiliser des diapositives copiées et clonées d'une présentation à une autre. Étant donné qu'une diapositive hérite de sa mise en page de la diapositive maîtresse, les méthodes de clonage intégrées copient automatiquement la maîtresse lors du clonage.|
|Gestion des sections de diapositives|Méthodes pour organiser les diapositives dans différentes sections à l'intérieur d'une présentation.|
|Espaces réservés et zones de texte|Vous pouvez accéder aux espaces réservés et aux zones de texte dans une diapositive. De plus, vous pouvez créer une diapositive avec des zones de texte à partir de zéro en utilisant la méthode appropriée.|
|En-têtes et pieds de page|Aspose.Slides pour Python via .NET facilite la gestion des en-têtes/des pieds de page dans les diapositives.|
|Notes dans les diapositives|Avec Aspose.Slides pour Python via .NET, vous pouvez accéder et modifier les notes associées à une diapositive et également ajouter de nouvelles notes.|
|Recherche d'une forme|Vous pouvez également trouver une forme particulière à partir d'une diapositive en utilisant le texte alternatif associé à la forme.|
|Arrière-plans|Aspose.Slides pour Python via .NET vous permet de travailler avec les arrière-plans associés à une diapositive maîtresse ou normale dans une présentation.|
|Zones de texte|Les zones de texte peuvent être créées à partir de zéro. Vous pouvez accéder aux zones de texte existantes. Vous pouvez également modifier leur texte sans perdre le format texte d'origine.|
|Formes rectangulaires|Vous pouvez créer ou modifier des formes rectangulaires avec Aspose.Slides pour Python via .NET.|
|Formes en polyligne|Vous pouvez créer ou modifier des formes en polyligne avec Aspose.Slides pour Python via .NET.|
|Formes elliptiques|Vous pouvez créer ou modifier des formes elliptiques avec Aspose.Slides pour Python via .NET.|
|Formes groupées|Aspose.Slides pour Python via .NET prend en charge les formes groupées.|
|Formes automatiques|Aspose.Slides pour Python via .NET prend en charge les formes automatiques.|
|SmartArt|Aspose.Slides pour Python via .NET fournit un support pour les formes SmartArt dans MS PowerPoint.|
|Graphiques|Aspose.Slides pour Python via .NET fournit un support pour les graphiques MSO dans PowerPoint.|
|Sérialisation des formes|Aspose.Slides pour Python via .NET prend en charge un grand nombre de formes. Lorsque Aspose.Slides pour Python via .NET n'a pas de support pour une forme, vous pouvez utiliser une méthode de sérialisation par laquelle vous pouvez sérialiser cette forme à partir d'une diapositive existante. De cette manière, vous pouvez utiliser la forme plus tard selon vos besoins.|
|Cadres d'images|Vous pouvez gérer des images dans des cadres d'images avec Aspose.Slides pour Python via .NET.|
|Cadres audio|Vous pouvez lier ou intégrer des fichiers audio dans des cadres audio sur les diapositives avec Aspose.Slides pour Python via .NET.|
|Cadres vidéo|Vous pouvez gérer des fichiers vidéo dans des cadres vidéo. Aspose.Slides pour Python via .NET fournit également un support pour les vidéos liées et intégrées.|
|Cadre OLE|Vous pouvez gérer des objets OLE dans des cadres OLE avec Aspose.Slides pour Python via .NET.|
|Tableaux|Aspose.Slides pour Python via .NET prend en charge les tableaux dans les diapositives.|
|Contrôles ActiveX|Support pour les contrôles ActiveX.|
|Macros VBA|Support pour la gestion des macros VBA à l'intérieur des présentations.|
|Cadre de texte|Vous pouvez accéder au texte associé à n'importe quelle forme par le biais du cadre de texte associé à cette forme.|
|Analyse de texte|Vous pouvez analyser le texte d'une présentation au niveau de la présentation ou de la diapositive grâce à des méthodes d'analyse intégrées.|
|Animations|Vous pouvez appliquer des animations sur des formes.|
|Diaporamas|Aspose.Slides pour Python via .NET prend en charge les diaporamas et les transitions de diapositives.|

## **Fonctionnalités de mise en forme**
Avec Aspose.Slides pour Python via .NET, vous pouvez formater des textes et des formes sur des diapositives dans des présentations. Consultez ces détails :

|**Fonctionnalité**|**Description**|
| :- | :- |
|Mise en forme du texte|<p>Dans Aspose.Slides pour Python via .NET, vous pouvez gérer des textes à travers les cadres de texte associés aux formes. Ainsi, vous pouvez formater les textes en utilisant les paragraphes et les portions associés aux cadres de texte. Ces éléments de texte peuvent être formatés grâce à Aspose.Slides pour Python via .NET.</p><p>- Type de police</p><p>- Taille de police</p><p>- Couleur de police</p><p>- Ombres de police</p><p>- Alignement des paragraphes</p><p>- Puces des paragraphes</p><p>- Orientation des paragraphes</p>|
|Mise en forme des formes|<p>Dans Aspose.Slides pour Python via .NET, l'élément de base d'une diapositive est une forme. Vous pouvez formater ces éléments de forme avec Aspose.Slides pour Python via .NET :</p><p>- Position</p><p>- Taille</p><p>- Ligne</p><p>- Remplissage (y compris le motif, le dégradé, le solide)</p><p>- Texte</p><p>- Image</p>|