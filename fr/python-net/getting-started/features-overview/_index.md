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
- impression
- formatage
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez Aspose.Slides for Python via .NET : une puissante API pour créer, modifier, automatiser et convertir efficacement les présentations PowerPoint et OpenDocument."
---

## **Plateformes prises en charge**
Les plateformes sur lesquelles Aspose.Slides for Python via .NET peut être utilisé sont Windows x64 ou x86 ainsi qu'un large éventail de distributions Linux avec Python 3.5 ou supérieur installé. Des exigences supplémentaires sont requises pour la plateforme Linux cible :

- bibliothèques d'exécution GCC‑6 (ou ultérieures)
- dépendances du runtime .NET Core. L'installation du runtime .NET Core n'est PAS requise
- pour Python 3.5‑3.7 : la version de Python compilée avec `pymalloc` est nécessaire. L'option de compilation `--with-pymalloc` est activée par défaut. Généralement, la version `pymalloc` de Python porte le suffixe `m` dans le nom de fichier.
- Bibliothèque Python partagée `libpython`. L'option de compilation `--enable-shared` est désactivée par défaut ; certaines distributions de Python ne contiennent pas la bibliothèque partagée `libpython`. Sur certaines plateformes Linux, la bibliothèque partagée `libpython` peut être installée via le gestionnaire de paquets, par exemple : `sudo apt-get install libpython3.7`. Le problème fréquent est que la bibliothèque `libpython` est installée à un emplacement différent de l'emplacement standard du système pour les bibliothèques partagées. Ce problème peut être résolu en utilisant les options de compilation de Python pour définir des chemins de bibliothèque alternatifs lors de la compilation, ou en créant un lien symbolique vers le fichier de bibliothèque `libpython` dans l'emplacement standard du système. En général, le nom du fichier de la bibliothèque partagée `libpython` est `libpythonX.Ym.so.1.0` pour Python 3.5‑3.7, ou `libpythonX.Y.so.1.0` pour Python 3.8 ou supérieur (par exemple : `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Si vous avez besoin de prise en charge de davantage de plateformes, recherchez les produits « frères jumeaux » Aspose.Slides for .NET ou Aspose.Slides for Java.

## **Formats de fichier et conversions**
Aspose.Slides for Python via .NET prend en charge la plupart des formats de documents PowerPoint. Il vous permet également de les exporter vers les formats populaires largement utilisés et échangés par les organisations. Consultez les détails ci‑dessous :

|**Fonctionnalité**|**Description**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/fr/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET offre le traitement le plus rapide pour ce format de document de présentation.|
|[PPT to PPTX conversion](/slides/fr/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET prend en charge la conversion de PPT vers PPTX.|
|[Portable Document Format (PDF)](/slides/fr/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Vous pouvez exporter tous les formats de fichier pris en charge vers des documents Adobe Portable Document Format (PDF) avec une seule méthode.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|Vous pouvez exporter tous les formats de fichier pris en charge vers des documents XML Parser Specification (XPS) avec une seule méthode.|
|[Tagged Image File Format (TIFF)](/slides/fr/python-net/convert-powerpoint-to-tiff/)|Vous pouvez exporter tous les formats de fichiers de présentation pris en charge vers le format Tagged Image File Format (TIFF).|
|[PPTX To HTML Conversion](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET prend en charge la conversion de PresentationEx vers le format HTML.|

## **Rendu et impression**
Aspose.Slides for Python via .NET prend en charge le rendu haute fidélité des diapositives des documents de présentation vers différents formats graphiques. Consultez les détails ci‑dessous :

|**Fonctionnalité**|**Description**|
| :- | :- |
|Formats d'image pris en charge par .NET|Avec Aspose.Slides for Python via .NET, vous pouvez rendre les diapositives de présentation et les images sur les diapositives vers tous les formats graphiques pris en charge par .NET tels que TIFF, PNG, BMP, JPEG, GIF et les métafichiers.|
|Format SVG|Aspose.Slides for Python via .NET propose également des méthodes intégrées vous permettant d'exporter les diapositives de présentation vers des formats Scalable Vector Graphics (SVG).|
|Impression de présentation|Les dernières versions d'Aspose.Slides for Python via .NET offrent des méthodes d'impression intégrées avec différentes options.|

## **Fonctionnalités de contenu**
Aspose.Slides for Python via .NET vous permet d'accéder, de modifier ou de créer presque tous les éléments ou contenus des documents de présentation. Consultez les détails ci‑dessous :

|**Fonctionnalité**|**Description**|
| :- | :- |
|Diapositives maîtres|Les diapositives maîtres définissent la mise en page des diapositives normales. Aspose.Slides for Python via .NET vous permet d'accéder et de modifier les diapositives maîtres des documents de présentation.|
|Diapositives normales|Avec Aspose.Slides for Python via .NET, vous pouvez créer de nouvelles diapositives de différents types ; vous pouvez également accéder et modifier les diapositives existantes dans les présentations.|
|Clonage / Copie de diapositives|Des méthodes intégrées fournies par Aspose.Slides for Python via .NET vous permettent de cloner ou copier des diapositives existantes au sein d’une présentation. Vous pouvez également utiliser les diapositives copiées et clonées d’une présentation à une autre. Puisqu’une diapositive hérite de sa mise en page de la diapositive maîtresse, les méthodes de clonage intégrées copient automatiquement la maîtresse lors du clonage.|
|Gestion des sections de diapositives|Méthodes pour organiser les diapositives en différentes sections au sein d’une présentation.|
|Espaces réservés et zones de texte|Vous pouvez accéder aux espaces réservés et aux zones de texte d’une diapositive. De plus, vous pouvez créer une diapositive avec des zones de texte à partir de zéro en utilisant la méthode appropriée.|
|En-têtes et pieds de page|Aspose.Slides for Python via .NET facilite la gestion des en-têtes/pieds de page dans les diapositives.|
|Notes dans les diapositives|Avec Aspose.Slides for Python via .NET, vous pouvez accéder et modifier les notes associées à une diapositive et également ajouter de nouvelles notes.|
|Recherche d'une forme|Vous pouvez également trouver une forme particulière dans une diapositive en utilisant le texte alternatif associé à la forme.|
|Arrières-plans|Aspose.Slides for Python via .NET vous permet de travailler avec les arrière-plans associés à une diapositive maîtresse ou normale dans une présentation.|
|Zones de texte|Les zones de texte peuvent être créées à partir de zéro. Vous pouvez accéder aux zones de texte existantes. Vous pouvez également modifier leur texte sans perdre le format original.|
|Formes rectangulaires|Vous pouvez créer ou modifier des formes rectangulaires avec Aspose.Slides for Python via .NET.|
|Formes polyligne|Vous pouvez créer ou modifier des formes polyligne avec Aspose.Slides for Python via .NET.|
|Formes ellipse|Vous pouvez créer ou modifier des formes ellipse avec Aspose.Slides for Python via .NET.|
|Formes groupées|Aspose.Slides for Python via .NET prend en charge les formes groupées.|
|Formes automatiques|Aspose.Slides for Python via .NET prend en charge les formes automatiques.|
|SmartArt|Aspose.Slides for Python via .NET offre la prise en charge des formes SmartArt dans MS PowerPoint.|
|Graphiques|Aspose.Slides for Python via .NET offre la prise en charge des graphiques MSO dans PowerPoint.|
|Sérialisation des formes|Aspose.Slides for Python via .NET prend en charge un grand nombre de formes. Lorsqu'Aspose.Slides for Python via .NET ne prend pas en charge une forme, vous pouvez utiliser une méthode de sérialisation qui vous permet de sérialiser cette forme à partir d’une diapositive existante. Ainsi, vous pouvez réutiliser la forme selon vos besoins.|
|Cadres d'image|Vous pouvez gérer les images dans les cadres d'image avec Aspose.Slides for Python via .NET.|
|Cadres audio|Vous pouvez lier ou incorporer des fichiers audio dans les cadres audio sur les diapositives avec Aspose.Slides for Python via .NET.|
|Cadres vidéo|Vous pouvez gérer les fichiers vidéo dans les cadres vidéo. Aspose.Slides for Python via .NET offre également la prise en charge des vidéos liées et intégrées.|
|Cadre OLE|Vous pouvez gérer les objets OLE dans les cadres OLE avec Aspose.Slides for Python via .NET.|
|Tableaux|Aspose.Slides for Python via .NET prend en charge les tableaux dans les diapositives.|
|Contrôles ActiveX|Prise en charge des contrôles ActiveX.|
|Macros VBA|Prise en charge de la gestion des macros VBA dans les présentations.|
|Cadre de texte|Vous pouvez accéder au texte de toute forme via le cadre de texte associé à cette forme.|
|Analyse de texte|Vous pouvez analyser le texte d’une présentation au niveau de la présentation ou de la diapositive grâce aux méthodes d’analyse intégrées.|
|Animations|Vous pouvez appliquer des animations sur les formes.|
|Diaporamas|Aspose.Slides for Python via .NET prend en charge les diaporamas et les transitions de diapositives.|

## **Fonctionnalités de formatage**
Aspose.Slides for Python via .NET vous permet de formater le texte et les formes sur les diapositives des présentations. Consultez les détails ci‑dessous :

|**Fonctionnalité**|**Description**|
| :- | :- |
|Text Formatting|<p>Dans Aspose.Slides for Python via .NET, vous pouvez gérer le texte via les cadres de texte associés aux formes. Ainsi, vous pouvez formater le texte en utilisant les paragraphes et les portions associés aux cadres de texte. Ces éléments de texte peuvent être formatés via Aspose.Slides for Python via .NET.</p><p>- Type de police</p><p>- Taille de police</p><p>- Couleur de police</p><p>- Nuances de police</p><p>- Alignement de paragraphe</p><p>- Puces de paragraphe</p><p>- Orientation de paragraphe</p>|
|Shape Formatting|<p>Dans Aspose.Slides for Python via .NET, l'élément de base d'une diapositive est une forme. Vous pouvez formater ces formes avec Aspose.Slides for Python via .NET :</p><p>- Position</p><p>- Taille</p><p>- Ligne</p><p>- Remplissage (y compris Motif, Dégradé, Solide)</p><p>- Texte</p><p>- Image</p>|

## **FAQ**

**Dois‑je installer Microsoft PowerPoint sur le serveur/PC pour que la bibliothèque fonctionne ?**

Non. PowerPoint n'est pas requis ; Aspose.Slides est un moteur autonome pour créer, modifier, convertir et rendre des présentations.

**Comment le multithreading fonctionne‑t‑il ? Le traitement peut‑il être parallélisé ?**

Il est sûr de traiter différents documents dans différents threads ; le même objet [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ne doit pas être utilisé par [plusieurs threads](/slides/fr/python-net/multithreading/) en même temps.

**Les mots de passe de fichiers et le chiffrement sont‑ils pris en charge ?**

Oui. [Vous pouvez](/slides/fr/python-net/password-protected-presentation/) ouvrir des présentations chiffrées, définir ou supprimer un mot de passe d'ouverture et d'écriture, et vérifier le statut de protection.

**Dois‑je m'occuper des paquets de polices dans les conteneurs Linux ?**

Oui. Il est recommandé d'installer les paquets de polices courants et/ou de [spécifier explicitement les répertoires de polices](/slides/fr/python-net/custom-font/) dans votre application afin d'éviter des substitutions inattendues.

**Existe‑t‑il des limitations dans la version d'évaluation ?**

En [mode d'évaluation](/slides/fr/python-net/licensing/), un filigrane est ajouté à la sortie et certaines limitations s'appliquent ; une [licence temporaire de 30 jours](https://purchase.aspose.com/temporary-license/) est disponible pour tester toutes les fonctionnalités.

**L'importation de formats externes dans une présentation (PDF/HTML → PPTX) est‑elle prise en charge ?**

Oui. Vous pouvez ajouter des [pages PDF et du contenu HTML](/slides/fr/python-net/import-presentation/) à une présentation, les transformant en diapositives.