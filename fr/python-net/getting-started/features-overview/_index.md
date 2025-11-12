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
description: "Découvrez Aspose.Slides pour Python via .NET : une API puissante pour créer, modifier, automatiser et convertir efficacement des présentations PowerPoint et OpenDocument."
---

## **Plateformes prises en charge**
Les plateformes sur lesquelles Aspose.Slides pour Python via .NET peut être utilisé sont Windows x64 ou x86 ainsi qu’une large gamme de distributions Linux avec Python 3.5 ou ultérieur installé. Des exigences supplémentaires s’appliquent à la plateforme Linux cible :
- Bibliothèques d’exécution GCC‑6 (ou plus récentes)
- Dépendances du .NET Core Runtime. L’installation du .NET Core Runtime lui‑même n’est PAS requise
- Pour Python 3.5‑3.7 : la version `pymalloc` de Python est nécessaire. L’option de construction `--with-pymalloc` est activée par défaut. En général, la version `pymalloc` de Python est signalée par le suffixe `m` dans le nom du fichier.
- Bibliothèque partagée Python `libpython`. L’option de construction Python `--enable-shared` est désactivée par défaut, certaines distributions Python ne contiennent pas la bibliothèque partagée `libpython`. Sur certaines plateformes Linux, la bibliothèque partagée `libpython` peut être installée via le gestionnaire de paquets, par exemple : `sudo apt-get install libpython3.7`. Le problème courant est que la bibliothèque `libpython` est installée à un emplacement différent de l’emplacement système standard des bibliothèques partagées. Le problème peut être résolu en utilisant les options de compilation de Python pour définir des chemins de bibliothèque alternatifs, ou en créant un lien symbolique vers le fichier de bibliothèque `libpython` dans l’emplacement système standard. En général, le nom du fichier de la bibliothèque partagée est `libpythonX.Ym.so.1.0` pour Python 3.5‑3.7, ou `libpythonX.Y.so.1.0` pour Python 3.8 ou ultérieur (par exemple : `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Si vous avez besoin de prendre en charge davantage de plateformes, recherchez les produits « frère jumeau » Aspose.Slides pour .NET ou Aspose.Slides pour Java.

## **Formats de fichier et conversions**
Aspose.Slides pour Python via .NET prend en charge la plupart des formats de documents PowerPoint. Il vous permet également de les exporter vers les formats populaires largement utilisés et échangés entre organisations. Parcourez les détails ci‑dessous :

|**Fonctionnalité**|**Description**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/fr/python-net/ppt-vs-pptx/)|Aspose.Slides pour Python via .NET offre le traitement le plus rapide pour ce format de document de présentation.|
|[Conversion de PPT vers PPTX](/slides/fr/python-net/convert-ppt-to-pptx/)|Aspose.Slides pour Python via .NET prend en charge la conversion de PPT vers PPTX.|
|[Portable Document Format (PDF)](/slides/fr/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Vous pouvez exporter tous les formats de fichier pris en charge vers des documents Adobe Portable Document Format (PDF) avec une seule méthode.|
|[Spécification du parseur XML (XPS)](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)|Vous pouvez exporter tous les formats de fichier pris en charge vers des documents XML Parser Specification (XPS) avec une seule méthode.|
|[Tagged Image File Format (TIFF)](/slides/fr/python-net/convert-powerpoint-to-tiff/)|Vous pouvez exporter tous les formats de présentation pris en charge vers le format Tagged Image File Format (TIFF).|
|[Conversion PPTX vers HTML]((https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/))|Aspose.Slides pour Python via .NET prend en charge la conversion de PresentationEx vers le format HTML.|

## **Rendu et impression**
Aspose.Slides pour Python via .NET prend en charge le rendu haute fidélité des diapositives des documents de présentation vers divers formats graphiques. Parcourez les détails ci‑dessous :

|**Fonctionnalité**|**Description**|
| :- | :- |
|Formats d’image pris en charge par .NET|Avec Aspose.Slides pour Python via .NET, vous pouvez rendre les diapositives de présentation et les images sur les diapositives vers tous les formats graphiques pris en charge par .NET tels que TIFF, PNG, BMP, JPEG, GIF et les métafichiers.|
|Format SVG|Aspose.Slides pour Python via .NET propose également des méthodes intégrées permettant d’exporter les diapositives de présentation vers les formats Scalable Vector Graphics (SVG).|
|Impression de présentation|Les dernières versions d’Aspose.Slides pour Python via .NET offrent des méthodes d’impression intégrées avec différentes options.|

## **Fonctionnalités de contenu**
Aspose.Slides pour Python via .NET vous permet d’accéder, de modifier ou de créer presque tous les éléments ou contenus des documents de présentation. Parcourez les détails ci‑dessous :

|**Fonctionnalité**|**Description**|
| :- | :- |
|Diapositives maîtres|Les diapositives maîtres définissent la mise en page des diapositives normales. Aspose.Slides pour Python via .NET vous permet d’accéder et de modifier les diapositives maîtres des documents de présentation.|
|Diapositives normales|Avec Aspose.Slides pour Python via .NET, vous pouvez créer de nouvelles diapositives de différents types ; vous pouvez également accéder et modifier les diapositives existantes dans les présentations.|
|Clonage / copie de diapositives|Des méthodes intégrées fournies par Aspose.Slides pour Python via .NET vous permettent de cloner ou de copier des diapositives existantes au sein d’une présentation. Vous pouvez également utiliser des diapositives copiées ou clonées d’une présentation à une autre. Comme une diapositive hérite de sa mise en page de la diapositive maître, les méthodes de clonage intégrées copient automatiquement le maître lors du clonage.|
|Gestion des sections de diapositives|Méthodes pour organiser les diapositives en différentes sections à l’intérieur d’une présentation.|
|Espaces réservés et zones de texte|Vous pouvez accéder aux espaces réservés et aux zones de texte d’une diapositive. De plus, vous pouvez créer une diapositive avec des zones de texte à partir de zéro en utilisant la méthode appropriée.|
|En‑têtes et pieds de page|Aspose.Slides pour Python via .NET facilite la gestion des en‑têtes/pieds de page dans les diapositives.|
|Notes dans les diapositives|Avec Aspose.Slides pour Python via .NET, vous pouvez accéder et modifier les notes associées à une diapositive ainsi que créer de nouvelles notes.|
|Recherche d’une forme|Vous pouvez également rechercher une forme particulière dans une diapositive en utilisant le texte alternatif associé à la forme.|
|Arrière‑plans|Aspose.Slides pour Python via .NET vous permet de travailler avec les arrière‑plans associés à une diapositive maître ou normale dans une présentation.|
|Zones de texte|Des zones de texte peuvent être créées à partir de zéro. Vous pouvez accéder aux zones de texte existantes. Vous pouvez également modifier leur texte sans perdre le format d’origine.|
|Formes rectangulaires|Vous pouvez créer ou modifier des formes rectangulaires avec Aspose.Slides pour Python via .NET.|
|Formes de polyligne|Vous pouvez créer ou modifier des formes de polyligne avec Aspose.Slides pour Python via .NET.|
|Formes d’ellipse|Vous pouvez créer ou modifier des formes d’ellipse avec Aspose.Slides pour Python via .NET.|
|Formes groupées|Aspose.Slides pour Python via .NET prend en charge les formes groupées.|
|Formes automatiques|Aspose.Slides pour Python via .NET prend en charge les formes automatiques.|
|SmartArt|Aspose.Slides pour Python via .NET fournit la prise en charge des formes SmartArt dans MS PowerPoint.|
|Graphiques|Aspose.Slides pour Python via .NET fournit la prise en charge des graphiques MSO dans PowerPoint.|
|Sérialisation des formes|Aspose.Slides pour Python via .NET prend en charge un grand nombre de formes. Lorsqu’une forme n’est pas prise en charge, vous pouvez utiliser une méthode de sérialisation vous permettant de sérialiser cette forme à partir d’une diapositive existante. Ainsi, vous pouvez réutiliser la forme selon vos besoins.|
|Cadres d’image|Vous pouvez gérer les images dans des cadres d’image avec Aspose.Slides pour Python via .NET.|
|Cadres audio|Vous pouvez lier ou incorporer des fichiers audio dans des cadres audio sur les diapositives avec Aspose.Slides pour Python via .NET.|
|Cadres vidéo|Vous pouvez gérer les fichiers vidéo dans des cadres vidéo. Aspose.Slides pour Python via .NET prend également en charge les vidéos liées et incorporées.|
|Cadre OLE|Vous pouvez gérer les objets OLE dans les cadres OLE avec Aspose.Slides pour Python via .NET.|
|Tableaux|Aspose.Slides pour Python via .NET prend en charge les tableaux dans les diapositives.|
|Contrôles ActiveX|Prise en charge des contrôles ActiveX.|
|Macros VBA|Prise en charge de la gestion des macros VBA dans les présentations.|
|Cadre de texte|Vous pouvez accéder au texte de n’importe quelle forme via le cadre de texte associé à cette forme.|
|Analyse de texte|Vous pouvez analyser le texte d’une présentation au niveau de la présentation ou de la diapositive grâce aux méthodes d’analyse intégrées.|
|Animations|Vous pouvez appliquer des animations sur les formes.|
|Diaporamas|Aspose.Slides pour Python via .NET prend en charge les diaporamas et les transitions de diapositives.|

## **Fonctionnalités de formatage**
Avec Aspose.Slides pour Python via .NET, vous pouvez formater les textes et les formes sur les diapositives des présentations. Parcourez les détails ci‑dessous :

|**Fonctionnalité**|**Description**|
| :- | :- |
|Formatage du texte|<p>Avec Aspose.Slides pour Python via .NET, vous gérez les textes via les cadres de texte associés aux formes. Vous pouvez donc formater les textes à l’aide des paragraphes et des portions associés aux cadres de texte. Ces éléments textuels peuvent être formatés avec Aspose.Slides pour Python via .NET.</p><p>- Type de police</p><p>- Taille de police</p><p>- Couleur de police</p><p>- Nuances de police</p><p>- Alignement du paragraphe</p><p>- Puces du paragraphe</p><p>- Orientation du paragraphe</p>|
|Formatage de la forme|<p>Dans Aspose.Slides pour Python via .NET, l’élément de base d’une diapositive est une forme. Vous pouvez formater ces éléments de forme avec Aspose.Slides pour Python via .NET :</p><p>- Position</p><p>- Taille</p><p>- Ligne</p><p>- Remplissage (y compris Motif, Dégradé, Uni)</p><p>- Texte</p><p>- Image</p>|

## **FAQ**

**Dois‑je installer Microsoft PowerPoint sur le serveur/PC pour que la bibliothèque fonctionne ?**

Non. PowerPoint n’est pas requis ; Aspose.Slides est un moteur autonome pour créer, modifier, convertir et rendre des présentations.

**Comment le multithreading fonctionne‑t‑il ? Le traitement peut‑il être parallélisé ?**

Il est sûr de traiter différents documents dans différents threads ; le même [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ne doit pas être utilisé par [multiple threads](/slides/fr/python-net/multithreading/) simultanément.

**Les mots de passe de fichier et le chiffrement sont‑ils pris en charge ?**

Oui. Vous pouvez [ouvrir](/slides/fr/python-net/password-protected-presentation/) des présentations chiffrées, définir ou supprimer un mot de passe d’ouverture et d’écriture, et vérifier l’état de protection.

**Dois‑je me soucier des packages de polices dans les conteneurs Linux ?**

Oui. Il est recommandé d’installer des packages de polices courants et/ou de [spécifier explicitement les répertoires de polices](/slides/fr/python-net/custom-font/) dans votre application afin d’éviter des substitutions inattendues.

**Y a‑t‑il des limitations dans la version d’évaluation ?**

En [mode d’évaluation](/slides/fr/python-net/licensing/), un filigrane est ajouté à la sortie et certaines limitations s’appliquent ; une [licence temporaire de 30 jours](https://purchase.aspose.com/temporary-license/) est disponible pour tester toutes les fonctionnalités.

**L’importation de formats externes dans une présentation (PDF/HTML → PPTX) est‑elle prise en charge ?**

Oui. Vous pouvez ajouter des [pages PDF et du contenu HTML](/slides/fr/python-net/import-presentation/) à une présentation, les transformant en diapositives.