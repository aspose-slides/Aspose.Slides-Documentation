---
title: Aperçu des fonctionnalités
type: docs
weight: 20
url: /fr/python-net/features-overview/
keywords:
- fonctionnalités
- plateformes prises en charge
- format de fichier
- conversion
- rendu
- formatage
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez Aspose.Slides pour Python via .NET : une API puissante pour créer, modifier, automatiser et convertir efficacement les présentations PowerPoint et OpenDocument."
---
## **Plateformes prises en charge**
Les plateformes Aspose.Slides for Python via .NET peuvent être utilisées sous Windows x64 ou x86 et un large éventail de distributions Linux avec Python 3.5 ou version ultérieure installé. Il y a des exigences supplémentaires pour la plateforme Linux cible :

- Bibliothèques d'exécution GCC‑6 (ou ultérieures)
- Dépendances du Runtime .NET Core. L'installation du Runtime .NET Core n'est PAS requise
- Pour Python 3.5‑3.7 : la version `pymalloc` de Python est requise. L'option de construction `--with-pymalloc` est activée par défaut. En général, la version `pymalloc` de Python se reconnaît à un suffixe `m` dans le nom de fichier.
- `libpython` bibliothèque Python partagée. L'option de construction `--enable-shared` de Python est désactivée par défaut, certaines distributions Python ne contiennent pas la bibliothèque partagée `libpython`. Pour certaines plateformes Linux, la bibliothèque partagée `libpython` peut être installée via le gestionnaire de paquets, par exemple : `sudo apt-get install libpython3.7`. Le problème fréquent est que la bibliothèque `libpython` est installée dans un emplacement différent de l'emplacement standard du système pour les bibliothèques partagées. Le problème peut être résolu en utilisant les options de construction de Python pour définir des chemins de bibliothèque alternatifs lors de la compilation de Python, ou en créant un lien symbolique vers le fichier de bibliothèque `libpython` dans l'emplacement standard du système. En général, le nom du fichier de bibliothèque partagée `libpython` est `libpythonX.Ym.so.1.0` pour Python 3.5‑3.7, ou `libpythonX.Y.so.1.0` pour Python 3.8 ou supérieur (par exemple : `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Si vous avez besoin de prise en charge pour d'autres plateformes, recherchez les produits « frères jumeaux » Aspose.Slides pour .NET ou Aspose.Slides pour Java.

## **Formats de fichiers et conversions**
Aspose.Slides for Python via .NET prend en charge la plupart des formats de documents PowerPoint. Il vous permet également de les exporter vers les formats populaires largement utilisés et échangés par les organisations. Consultez ces détails :

|**Fonctionnalité**|**Description**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/fr/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET offre le traitement le plus rapide pour ce format de document de présentation.|
|[Conversion PPT vers PPTX](/slides/fr/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET prend en charge la conversion de PPT vers PPTX.|
|[Portable Document Format (PDF)](/slides/fr/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Vous pouvez exporter tous les formats de fichiers pris en charge vers des documents Adobe Portable Document Format (PDF) avec une seule méthode.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/fr/python-net/convert-powerpoint-to-xps/)|Vous pouvez exporter tous les formats de fichiers pris en charge vers des documents XML Parser Specification (XPS) avec une seule méthode.|
|[Tagged Image File Format (TIFF)](/slides/fr/python-net/convert-powerpoint-to-tiff/)|Vous pouvez exporter tous les formats de fichiers de présentation pris en charge vers le format Tagged Image File Format (TIFF).|
|[Conversion PPTX vers HTML](https://docs.aspose.com/slides/fr/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET prend en charge la conversion de PresentationEx au format HTML.|

## **Rendu de présentation**
Aspose.Slides for Python via .NET prend en charge le rendu haute fidélité des diapositives des documents de présentation vers divers formats graphiques. Consultez ces détails :

|**Fonctionnalité**|**Description**|
| :- | :- |
|Formats d'image pris en charge par .NET|Avec Aspose.Slides for Python via .NET, vous pouvez rendre les diapositives de présentation et les images sur les diapositives vers tous les formats graphiques pris en charge par .NET tels que TIFF, PNG, BMP, JPEG, GIF et les métafichiers.|
|SVG Format|Aspose.Slides for Python via .NET fournit également des méthodes intégrées qui vous permettent d'exporter les diapositives de présentation vers des formats Scalable Vector Graphics (SVG).|

## **Fonctions de contenu**
Aspose.Slides for Python via .NET vous permet d'accéder, de modifier ou de créer presque tous les éléments ou contenus des documents de présentation. Consultez ces détails :

|**Fonctionnalité**|**Description**|
| :- | :- |
|Diapositives maîtres|Les diapositives maîtres définissent la mise en page des diapositives normales. Aspose.Slides for Python via .NET vous permet d'accéder et de modifier les diapositives maîtres des documents de présentation|
|Diapositives normales|Avec Aspose.Slides for Python via .NET, vous pouvez créer de nouvelles diapositives de différents types ; vous pouvez également accéder et modifier les diapositives existantes dans les présentations|
|Clonage / copie de diapositives|Des méthodes intégrées fournies par Aspose.Slides for Python via .NET vous permettent de cloner ou copier des diapositives existantes au sein d'une présentation. Vous pouvez également utiliser des diapositives copiées et clonées d'une présentation à une autre. Étant donné qu'une diapositive hérite de sa mise en page de la diapositive maîtresse, les méthodes de clonage intégrées copient automatiquement la maîtresse lors du clonage|
|Gestion des sections de diapositives|Méthodes pour organiser les diapositives en différentes sections au sein d'une présentation|
|Espaces réservés et zones de texte|Vous pouvez accéder aux espaces réservés et aux zones de texte d'une diapositive. De plus, vous pouvez créer une diapositive avec des zones de texte à partir de zéro en utilisant la méthode appropriée|
|En‑têtes et pieds de page|Aspose.Slides for Python via .NET facilite la gestion des en‑têtes/pieds de page dans les diapositives|
|Notes dans les diapositives|Avec Aspose.Slides for Python via .NET, vous pouvez accéder et modifier les notes associées à une diapositive et également ajouter de nouvelles notes|
|Recherche d'une forme|Vous pouvez également trouver une forme particulière dans une diapositive en utilisant le texte alternatif associé à la forme|
|Arrière‑plans|Aspose.Slides for Python via .NET vous permet de travailler avec les arrière‑plans associés à une diapositive maîtresse ou normale dans une présentation|
|Zones de texte|Les zones de texte peuvent être créées à partir de zéro. Vous pouvez accéder aux zones de texte existantes. Vous pouvez également modifier leurs textes sans perdre le format de texte original|
|Formes rectangulaires|Vous pouvez créer ou modifier des formes rectangulaires avec Aspose.Slides for Python via .NET|
|Formes de polyligne|Vous pouvez créer ou modifier des formes de polyligne avec Aspose.Slides for Python via .NET|
|Formes d'ellipse|Vous pouvez créer ou modifier des formes d'ellipse avec Aspose.Slides for Python via .NET|
|Formes groupées|Aspose.Slides for Python via .NET prend en charge les formes groupées|
|Formes automatiques|Aspose.Slides for Python via .NET prend en charge les formes automatiques|
|SmartArt|Aspose.Slides for Python via .NET offre une prise en charge des formes SmartArt dans MS PowerPoint|
|Charts|Aspose.Slides for Python via .NET offre une prise en charge des graphiques MSO dans PowerPoint|
|Sérialisation des formes|Aspose.Slides for Python via .NET prend en charge un grand nombre de formes. Lorsqu'Aspose.Slides for Python via .NET ne prend pas en charge une forme, vous pouvez utiliser une méthode de sérialisation qui vous permet de sérialiser cette forme à partir d'une diapositive existante. Ainsi, vous pouvez réutiliser la forme selon vos besoins |
|Cadres d'image|Vous pouvez gérer les images dans les cadres d'image avec Aspose.Slides for Python via .NET|
|Cadres audio|Vous pouvez lier ou intégrer des fichiers audio dans les cadres audio sur les diapositives avec Aspose.Slides for Python via .NET|
|Cadres vidéo|Vous pouvez gérer les fichiers vidéo dans les cadres vidéo. Aspose.Slides for Python via .NET offre également une prise en charge des vidéos liées et intégrées|
|Cadre OLE|Vous pouvez gérer les objets OLE dans les cadres OLE avec Aspose.Slides for Python via .NET|
|Tables|Aspose.Slides for Python via .NET prend en charge les tables dans les diapositives|
|Contrôles ActiveX|Prise en charge des contrôles ActiveX|
|Macros VBA|Prise en charge de la gestion des macros VBA dans les présentations.|
|Cadre de texte|Vous pouvez accéder au texte de toute forme via le cadre de texte associé à cette forme|
|Analyse de texte|Vous pouvez analyser le texte d'une présentation au niveau de la présentation ou de la diapositive grâce à des méthodes d'analyse intégrées.|
|Animations|Vous pouvez appliquer des animations sur les formes|
|Diaporamas|Aspose.Slides for Python via .NET prend en charge les diaporamas et les transitions de diapositives|

## **Fonctionnalités de formatage**
Avec Aspose.Slides for Python via .NET, vous pouvez formater les textes et les formes sur les diapositives des présentations. Consultez ces détails :

|**Fonctionnalité**|**Description**|
| :- | :- |
|Mise en forme du texte|<p>Dans Aspose.Slides for Python via .NET, vous pouvez gérer les textes via les cadres de texte associés aux formes. Ainsi, vous pouvez formater les textes en utilisant les paragraphes et les portions associés aux cadres de texte. Ces éléments de texte peuvent être formatés à l'aide d'Aspose.Slides for Python via .NET.</p><p>- Type de police</p><p>- Taille de police</p><p>- Couleur de police</p><p>- Nuances de police</p><p>- Alignement du paragraphe</p><p>- Puces du paragraphe</p><p>- Orientation du paragraphe</p>|
|Mise en forme des formes|<p>Dans Aspose.Slides for Python via .NET, l'élément de base d'une diapositive est une forme. Vous pouvez formater ces éléments de forme avec Aspose.Slides for Python via .NET :</p><p>- Position</p><p>- Taille</p><p>- Ligne</p><p>- Remplissage (incluant Motif, Dégradé, Uni)</p><p>- Texte</p><p>- Image</p>|

## **FAQ**

### Ai‑je besoin d'installer Microsoft PowerPoint sur le serveur/PC pour que la bibliothèque fonctionne ?
Non. PowerPoint n'est pas requis ; Aspose.Slides est un moteur autonome destiné à créer, modifier, convertir et rendre des présentations.

### Comment fonctionne le multithreading ? Le traitement peut‑il être parallélisé ?
Il est sûr de traiter différents documents dans des threads différents ; le même [présentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) object must not be used by [plusieurs threads](/slides/fr/python-net/multithreading/) at the same time.

### Les mots de passe de fichiers et le chiffrement sont‑ils pris en charge ?
Oui. [Vous pouvez](/slides/fr/python-net/password-protected-presentation/) ouvrir des présentations chiffrées, définir ou supprimer un mot de passe d'ouverture et d'écriture, et vérifier l'état de protection.

### Est‑il nécessaire de se soucier des paquets de polices dans les conteneurs Linux ?
Oui. Il est recommandé d'installer les paquets de polices courants et/ou de [spécifier explicitement les répertoires de polices](/slides/fr/python-net/custom-font/) dans votre application afin d'éviter des substitutions inattendues.

### Y a‑t‑il des limitations dans la version d'évaluation ?
En [mode d'évaluation](/slides/fr/python-net/licensing/), un filigrane est ajouté à la sortie et certaines limitations s'appliquent ; une [licence temporaire de 30 jours](https://purchase.aspose.com/temporary-license/) est disponible pour des tests complets des fonctionnalités.

### L'importation de formats externes dans une présentation (PDF/HTML → PPTX) est‑elle prise en charge ?
Oui. Vous pouvez ajouter des [pages PDF et du contenu HTML](/slides/fr/python-net/import-presentation/) à une présentation, les transformant en diapositives.