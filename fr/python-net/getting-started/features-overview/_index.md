---
title: Aperçu des fonctionnalités
type: docs
weight: 20
url: /fr/python-net/features-overview/
keywords:
- fonctionnalités
- plates-formes prises en charge
- format de fichier
- conversion
- rendu
- impression
- mise en forme
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez Aspose.Slides pour Python via .NET : une API puissante pour créer, modifier, automatiser et convertir efficacement les présentations PowerPoint et OpenDocument."
---

## **Plateformes prises en charge**
Les plateformes Aspose.Slides pour Python via .NET peuvent être utilisées sous Windows x64 ou x86 et sur un large éventail de distributions Linux avec Python 3.5 ou version ultérieure installé. Des exigences supplémentaires s’appliquent à la plateforme Linux cible :
- Bibliothèques d’exécution GCC-6 (ou ultérieures)
- Dépendances du .NET Core Runtime. L’installation du .NET Core Runtime lui‑même n’est PAS requise
- Pour Python 3.5‑3.7 : la version `pymalloc` de Python est nécessaire. L’option de construction `--with-pymalloc` de Python est activée par défaut. Généralement, la version `pymalloc` de Python est marquée du suffixe `m` dans le nom du fichier.
- `libpython` bibliothèque Python partagée. L’option de construction `--enable-shared` de Python est désactivée par défaut, certaines distributions Python ne contiennent pas la bibliothèque partagée `libpython`. Pour certaines plateformes Linux, la bibliothèque partagée `libpython` peut être installée via le gestionnaire de paquets, par exemple : `sudo apt-get install libpython3.7`. Le problème fréquent est que la bibliothèque `libpython` est installée dans un emplacement différent de l’emplacement standard du système pour les bibliothèques partagées. Le problème peut être résolu en utilisant les options de construction de Python pour définir des chemins de bibliothèque alternatifs lors de la compilation de Python, ou en créant un lien symbolique vers le fichier de bibliothèque `libpython` dans l’emplacement standard du système pour les bibliothèques partagées. En général, le nom du fichier de la bibliothèque partagée `libpython` est `libpythonX.Ym.so.1.0` pour Python 3.5‑3.7, ou `libpythonX.Y.so.1.0` pour Python 3.8 ou version ultérieure (par exemple : `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Si vous avez besoin de prise en charge pour d’autres plateformes, recherchez les produits « frères jumeaux » Aspose.Slides pour .NET ou Aspose.Slides pour Java.

## **Formats de fichiers et conversions**
Aspose.Slides pour Python via .NET prend en charge la plupart des formats de documents PowerPoint. Il vous permet également de les exporter vers les formats populaires largement utilisés et échangés par les organisations. Consultez ces détails :

|**Fonctionnalité**|**Description**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/fr/python-net/ppt-vs-pptx/)|Aspose.Slides pour Python via .NET offre le traitement le plus rapide pour ce format de document de présentation.|
|[Conversion PPT vers PPTX](/slides/fr/python-net/convert-ppt-to-pptx/)|Aspose.Slides pour Python via .NET prend en charge la conversion de PPT vers PPTX.|
|[Portable Document Format (PDF)](/slides/fr/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Vous pouvez exporter tous les formats de fichiers pris en charge vers des documents Adobe Portable Document Format (PDF) avec une seule méthode.|
|[XML Paper Specification (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|Vous pouvez exporter tous les formats de fichiers pris en charge vers des documents XML Paper Specification (XPS) avec une seule méthode.|
|[Tagged Image File Format (TIFF)](/slides/fr/python-net/convert-powerpoint-to-tiff/)|Vous pouvez exporter tous les formats de fichiers de présentation pris en charge vers le format Tagged Image File Format (TIFF).|
|[Conversion PPTX vers HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides pour Python via .NET prend en charge la conversion de PresentationEx vers le format HTML.|

## **Rendu et impression**
Aspose.Slides pour Python via .NET prend en charge le rendu haute fidélité des diapositives dans les documents de présentation vers divers formats graphiques. Consultez ces détails :

|**Fonctionnalité**|**Description**|
| :- | :- |
|Formats d’image pris en charge par .NET|Avec Aspose.Slides pour Python via .NET, vous pouvez rendre les diapositives de présentation et les images sur les diapositives vers tous les formats graphiques pris en charge par .NET tels que TIFF, PNG, BMP, JPEG, GIF et les méta‑fichiers.|
|Format SVG|Aspose.Slides pour Python via .NET fournit également des méthodes intégrées qui permettent d’exporter les diapositives de présentation vers les formats Scalable Vector Graphics (SVG).|
|Impression de présentation|Les dernières versions d’Aspose.Slides pour Python via .NET offrent des méthodes d’impression intégrées avec différentes options.|

## **Fonctionnalités de contenu**
Aspose.Slides pour Python via .NET vous permet d’accéder, de modifier ou de créer presque tous les éléments ou contenus des documents de présentation. Consultez ces détails :

|**Fonctionnalité**|**Description**|
| :- | :- |
|Diapositives maîtres|Les diapositives maîtres définissent la disposition des diapositives normales. Aspose.Slides pour Python via .NET vous permet d’accéder et de modifier les diapositives maîtres des documents de présentation.|
|Diapositives normales|Avec Aspose.Slides pour Python via .NET, vous pouvez créer de nouvelles diapositives de différents types ; vous pouvez également accéder et modifier les diapositives existantes dans les présentations.|
|Clonage / Copie de diapositives|Des méthodes intégrées fournies par Aspose.Slides pour Python via .NET permettent de cloner ou copier des diapositives existantes au sein d’une présentation. Vous pouvez également utiliser des diapositives copiées ou clonées d’une présentation à une autre. Comme une diapositive hérite de sa disposition de la diapositive maîtresse, les méthodes de clonage intègrent automatiquement la maître lors du clonage.|
|Gestion des sections de diapositives|Méthodes pour organiser les diapositives en différentes sections au sein d’une présentation.|
|Espaces réservés et zones de texte|Vous pouvez accéder aux espaces réservés et aux zones de texte d’une diapositive. De plus, vous pouvez créer une diapositive avec des zones de texte à partir de zéro en utilisant la méthode appropriée.|
|En‑têtes et pieds de page|Aspose.Slides pour Python via .NET facilite la gestion des en‑têtes/pieds de page dans les diapositives.|
|Notes dans les diapositives|Avec Aspose.Slides pour Python via .NET, vous pouvez accéder et modifier les notes associées à une diapositive ainsi qu’ajouter de nouvelles notes.|
|Recherche d’une forme|Vous pouvez également retrouver une forme particulière d’une diapositive en utilisant le texte alternatif associé à la forme.|
|Arrières‑plans|Aspose.Slides pour Python via .NET vous permet de travailler avec les arrières‑plans associés à une diapositive maîtresse ou normale dans une présentation.|
|Zone de texte|Des zones de texte peuvent être créées à partir de zéro. Vous pouvez accéder aux zones de texte existantes. Vous pouvez également modifier leurs textes sans perdre le format d’origine.|
|Formes rectangulaires|Vous pouvez créer ou modifier des formes rectangulaires avec Aspose.Slides pour Python via .NET.|
|Formes de polyligne|Vous pouvez créer ou modifier des formes de polyligne avec Aspose.Slides pour Python via .NET.|
|Formes d’ellipse|Vous pouvez créer ou modifier des formes d’ellipse avec Aspose.Slides pour Python via .NET.|
|Formes groupées|Aspose.Slides pour Python via .NET prend en charge les formes groupées.|
|Formes automatiques|Aspose.Slides pour Python via .NET prend en charge les formes automatiques.|
|SmartArt|Aspose.Slides pour Python via .NET fournit la prise en charge des formes SmartArt dans MS PowerPoint.|
|Graphiques|Aspose.Slides pour Python via .NET fournit la prise en charge des graphiques MSO dans PowerPoint.|
|Sérialisation des formes|Aspose.Slides pour Python via .NET prend en charge un grand nombre de formes. Lorsqu’Aspose.Slides pour Python via .NET ne supporte pas une forme, vous pouvez utiliser une méthode de sérialisation qui vous permet de sérialiser cette forme à partir d’une diapositive existante. Ainsi, vous pouvez réutiliser la forme selon vos besoins.|
|Cadres d’image|Vous pouvez gérer les images dans les cadres d’image avec Aspose.Slides pour Python via .NET.|
|Cadres audio|Vous pouvez lier ou intégrer des fichiers audio dans des cadres audio sur les diapositives avec Aspose.Slides pour Python via .NET.|
|Cadres vidéo|Vous pouvez gérer les fichiers vidéo dans les cadres vidéo. Aspose.Slides pour Python via .NET fournit également la prise en charge des vidéos liées et intégrées.|
|Cadre OLE|Vous pouvez gérer les objets OLE dans les cadres OLE avec Aspose.Slides pour Python via .NET.|
|Tableaux|Aspose.Slides pour Python via .NET prend en charge les tableaux dans les diapositives.|
|Contrôles ActiveX|Prise en charge des contrôles ActiveX.|
|Macros VBA|Prise en charge de la gestion des macros VBA dans les présentations.|
|Cadre de texte|Vous pouvez accéder au texte de toute forme via le cadre de texte associé à cette forme.|
|Analyse de texte|Vous pouvez analyser le texte dans une présentation au niveau de la présentation ou de la diapositive grâce à des méthodes d’analyse intégrées.|
|Animations|Vous pouvez appliquer des animations sur les formes.|
|Diaporamas|Aspose.Slides pour Python via .NET prend en charge les diaporamas et les transitions de diapositives.|

## **Fonctionnalités de mise en forme**
Avec Aspose.Slides pour Python via .NET, vous pouvez formater les textes et les formes sur les diapositives des présentations. Consultez ces détails :

|**Fonctionnalité**|**Description**|
| :- | :- |
|Mise en forme du texte|<p>Dans Aspose.Slides pour Python via .NET, vous pouvez gérer le texte via les cadres de texte associés aux formes. Ainsi, vous pouvez mettre en forme le texte en utilisant les paragraphes et les portions associés aux cadres de texte. Ces éléments de texte peuvent être mis en forme avec Aspose.Slides pour Python via .NET.</p><p>- Type de police</p><p>- Taille de police</p><p>- Couleur de police</p><p>- Nuances de police</p><p>- Alignement du paragraphe</p><p>- Puces du paragraphe</p><p>- Orientation du paragraphe</p>|
|Mise en forme des formes|<p>Dans Aspose.Slides pour Python via .NET, l’élément de base d’une diapositive est une forme. Vous pouvez mettre en forme ces éléments de forme avec Aspose.Slides pour Python via .NET :</p><p>- Position</p><p>- Taille</p><p>- Ligne</p><p>- Remplissage (y compris Motif, Dégradé, Uni)</p><p>- Texte</p><p>- Image</p>|

## **FAQ**

**Dois‑je installer Microsoft PowerPoint sur le serveur/PC pour que la bibliothèque fonctionne ?**

Non. PowerPoint n’est pas requis ; Aspose.Slides est un moteur autonome pour créer, modifier, convertir et rendre des présentations.

**Comment le multithreading fonctionne‑t‑il ? Le traitement peut‑il être parallélisé ?**

Il est sûr de traiter différents documents dans différents threads ; le même [présentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ne doit pas être utilisé par [plusieurs threads](/slides/fr/python-net/multithreading/) en même temps.

**Les mots de passe de fichiers et le chiffrement sont‑ils pris en charge ?**

Oui. Vous pouvez [ouvrir](/slides/fr/python-net/password-protected-presentation/) des présentations chiffrées, définir ou supprimer un mot de passe d’ouverture et d’écriture, et vérifier le statut de protection.

**Dois‑je m’occuper des packages de polices dans les conteneurs Linux ?**

Oui. Il est recommandé d’installer des packages de polices courants et/ou de [spécifier explicitement les répertoires de polices](/slides/fr/python-net/custom-font/) dans votre application afin d’éviter des substitutions inattendues.

**Existe‑t‑il des limitations dans la version d’évaluation ?**

En [mode évaluation](/slides/fr/python-net/licensing/), un filigrane est ajouté à la sortie et certaines limitations s’appliquent ; une [licence temporaire de 30 jours](https://purchase.aspose.com/temporary-license/) est disponible pour des tests complets des fonctionnalités.

**L’importation de formats externes dans une présentation (PDF/HTML → PPTX) est‑elle prise en charge ?**

Oui. Vous pouvez ajouter des [pages PDF et du contenu HTML](/slides/fr/python-net/import-presentation/) à une présentation, les transformant en diapositives.