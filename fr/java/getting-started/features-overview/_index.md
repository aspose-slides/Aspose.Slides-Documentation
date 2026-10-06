---
title: Vue d'ensemble des fonctionnalités
type: docs
weight: 104
url: /fr/java/features-overview/
keywords:
- fonctionnalités
- plates-formes prises en charge
- formats de fichiers
- conversion
- rendu
- contenu de présentation
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Passez en revue ce que Aspose.Slides for Java couvre avant de l'évaluer : plates-formes prises en charge, formats de fichiers, rendu des diapositives et le contenu que vous pouvez créer et modifier."
---
## **Aperçu**

Aspose.Slides for Java est une bibliothèque de classes permettant de créer, lire, modifier, convertir et rendre des présentations PowerPoint et OpenDocument. Elle ne possède pas d'interface utilisateur propre et ne nécessite pas Microsoft PowerPoint ni Microsoft Office. Cet article résume ce que couvre la bibliothèque et renvoie aux articles qui décrivent chaque domaine.

## **Plateformes prises en charge**

Aspose.Slides for Java est un fichier JAR unique, publié dans le référentiel Maven d'Aspose avec le classificateur `jdk16`. Il est écrit en Java pur : le JAR ne contient aucune bibliothèque native et ne dépend d'aucun autre paquet.

- **Java** : Java 8 ou version ultérieure. Aspose.Slides for Java 26.9 et les versions antérieures fonctionnent également sur Java 6 et 7, que la version 26.10 ne prend plus en charge ; consultez les [notes de version 26.9](https://releases.aspose.com/slides/fr/java/release-notes/2026/aspose-slides-for-java-26-9-release-notes/).
- **Systèmes d'exploitation** : tout système d'exploitation disposant d'un runtime Java, tel que Windows, Linux et macOS. Sous Linux, la bibliothèque fontconfig et au moins une police doivent être installées.

[Installation](/slides/fr/java/installation/) montre comment ajouter la bibliothèque à un projet et répertorie les prérequis Linux. [System Requirements](/slides/fr/java/system-requirements/) répertorie en détail les plateformes prises en charge.

## **Formats de fichiers et conversions**

Aspose.Slides ouvre et enregistre les présentations PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP et PowerPoint XML. Il importe du contenu PDF et HTML dans les diapositives, et il enregistre les présentations au format PDF, XPS, HTML, HTML5, TIFF, GIF animé, SWF, Markdown et XAML. [Supported File Formats](/slides/fr/java/supported-file-formats/) répertorie chaque format avec l'API qui le lit ou l'écrit.

|**Fonctionnalité**|**Description**|
| :- | :- |
|[PPT et PPTX](/slides/fr/java/ppt-vs-pptx/)|Lire et écrire à la fois le format binaire PowerPoint 97-2003 et le format Office Open XML.|
|[Conversion PPT vers PPTX](/slides/fr/java/convert-ppt-to-pptx/)|Convertir les présentations PPT héritées en PPTX.|
|[Conversion ODP en PPTX](/slides/fr/java/convert-odp-to-pptx/)|Ouvrir et enregistrer les présentations ODP, OTP et FODP, et convertir les présentations ODP en PPTX.|
|[Format de document portable (PDF)](/slides/fr/java/convert-powerpoint-to-pdf/)|Exporter les présentations au format PDF, y compris les documents PDF/A et PDF/UA.|
|[Spécification XML Paper (XPS)](/slides/fr/java/convert-powerpoint-to-xps/)|Exporter les présentations au format XPS.|
|[Format d'image balisé (TIFF)](/slides/fr/java/convert-powerpoint-to-tiff/)|Exporter les présentations en images TIFF multi‑pages, une page par diapositive.|
|[HTML](/slides/fr/java/convert-powerpoint-to-html/)|Exporter les présentations au format HTML et HTML5.|
|[Importation PDF et HTML](/slides/fr/java/import-presentation/)|Créer des diapositives à partir de pages PDF et de contenu HTML.|

## **Rendu de présentations**

Aspose.Slides rend les diapositives et les formes individuelles en images PNG, JPEG, BMP, GIF, TIFF et SVG, et les diapositives en métafilens EMF. Voir [Convert Presentation Slides to Images](/slides/fr/java/convert-slide/), [Render Presentation Slides as SVG Images](/slides/fr/java/render-a-slide-as-an-svg-image/) et [Create Thumbnails of Presentation Shapes](/slides/fr/java/create-shape-thumbnails/).

## **Fonctionnalités du contenu**

Aspose.Slides vous permet de créer, lire et modifier presque tout le contenu d’une présentation :

|**Domaine**|**Ce que vous pouvez faire**|
| :- | :- |
|[Diapositives](/slides/fr/java/presentation-slide/)|Ajouter, dupliquer, réorganiser et supprimer des diapositives ; appliquer des dispositions et des maîtres ; organiser les diapositives en sections ; modifier la taille des diapositives.|
|[Design](/slides/fr/java/presentation-design/)|Définir les arrière‑plans, les couleurs du thème, les en‑têtes et pieds de page, ainsi que les polices.|
|[Texte](/slides/fr/java/manage-text/)|Créer et éditer des cadres de texte, paragraphes et portions ; définir les polices, couleurs, puces et alignement ; rechercher et remplacer du texte.|
|[Formes](/slides/fr/java/powerpoint-shapes/)|Créer des AutoShapes, lignes, connecteurs, groupes de formes et cadres d’image ; définir la position, la taille, le contour et le remplissage plein, dégradé ou motif ; rechercher une forme par son texte alternatif.|
|[Tables](/slides/fr/java/powerpoint-table/), [graphes](/slides/fr/java/powerpoint-charts/), et [SmartArt](/slides/fr/java/powerpoint-smartart/)|Créer et éditer des tableaux, des graphiques Microsoft Office et des diagrammes SmartArt.|
|[Médias](/slides/fr/java/manage-media-files/), [objets OLE](/slides/fr/java/manage-ole/), et [contrôles ActiveX](/slides/fr/java/activex/)|Ajouter des cadres audio et vidéo intégrés ou liés, incorporer des objets OLE, et ajouter, modifier ou supprimer des contrôles ActiveX.|
|[Notes](/slides/fr/java/presentation-notes/) et [commentaires](/slides/fr/java/presentation-comments/)|Ajouter, lire et éditer les notes du présentateur et les commentaires de révision.|
|[Animation](/slides/fr/java/powerpoint-animation/) et [transitions](/slides/fr/java/slide-transition/)|Appliquer des effets d’animation aux formes, définir les transitions entre diapositives et configurer les paramètres du diaporama.|
|[Sécurité](/slides/fr/java/presentation-security/)|Chiffrer les présentations avec un mot de passe, définir la protection en écriture et travailler avec les [digital signatures](/slides/fr/java/digital-signature-in-powerpoint/).|
|[Macros VBA](/slides/fr/java/presentation-via-vba/)|Ajouter, extraire et supprimer des modules VBA dans les présentations compatibles macro.|
|[Propriétés](/slides/fr/java/presentation-properties/)|Lire et éditer les propriétés du document.|

## **FAQ**

**Dois-je installer Microsoft PowerPoint sur le serveur ou le PC pour que la bibliothèque fonctionne ?**

Non. PowerPoint n’est pas requis ; Aspose.Slides est un moteur autonome pour créer, éditer, convertir et rendre des présentations.

**Comment le multithreading fonctionne‑t‑il ? Le traitement peut‑il être parallélisé ?**

Il est sûr de traiter différents documents dans des threads différents ; le même [Presentation](/slides/fr/java/multithreading/) ne doit pas être utilisé par plusieurs threads en même temps.

**Les mots de passe de fichier et le chiffrement sont‑ils pris en charge ?**

Oui. Vous pouvez [ouvrir des présentations chiffrées](/slides/fr/java/password-protected-presentation/), définir ou supprimer un mot de passe d’ouverture et d’écriture, et vérifier l’état de protection.

**Dois‑je me préoccuper des polices dans les conteneurs Linux ?**

Oui. Sous Linux, la bibliothèque fontconfig et au moins une police doivent être installées, et les polices utilisées dans vos présentations, ou des substituts appropriés, doivent être présentes pour que le texte s’affiche correctement. Vous pouvez également [spécifier les répertoires de polices](/slides/fr/java/custom-font/) dans votre application. Voir [Installation](/slides/fr/java/installation/#linux).

**Existe‑t‑il des limitations dans la version d’évaluation ?**

Oui. Sans [licence](/slides/fr/java/licensing/), Aspose.Slides ajoute un filigrane d’évaluation à chaque diapositive sauvegardée et tronque le texte que votre code lit via l’API. Une [licence temporaire de 30 jours](https://purchase.aspose.com/temporary-license/) est disponible pour tester toutes les fonctionnalités.

**L’importation de formats externes dans une présentation (PDF ou HTML vers PPTX) est‑elle prise en charge ?**

Oui. Vous pouvez ajouter des [pages PDF et du contenu HTML](/slides/fr/java/import-presentation/) à une présentation, les transformant en diapositives.