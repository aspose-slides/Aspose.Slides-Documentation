---
title: Vue d'ensemble des fonctionnalités
type: docs
weight: 94
url: /fr/net/features-overview/
keywords:
- fonctionnalités
- plates-formes prises en charge
- formats de fichier
- conversion
- rendu
- contenu de présentation
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Examinez ce que couvre Aspose.Slides for .NET avant de l'évaluer : plates-formes prises en charge, formats de fichier, rendu des diapositives et le contenu que vous pouvez créer et modifier."
---
## **Vue d'ensemble**

Aspose.Slides for .NET est une bibliothèque de classes permettant de créer, lire, modifier, convertir et rendre des présentations PowerPoint et OpenDocument. Elle ne possède pas d'interface utilisateur et ne nécessite pas Microsoft PowerPoint ou Office, vous pouvez donc l'utiliser dans des applications console, des applications de bureau telles que Windows Forms, des applications web et des services web. Cet article résume ce que couvre la bibliothèque et fournit des liens vers les articles décrivant chaque domaine.

## **Plateformes prises en charge**

Aspose.Slides for .NET est distribué sous forme de deux packages NuGet avec la même API :

|**Package**|**Assemblages dans le package**|**Systèmes d'exploitation**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0 et .NET 6. Utilisez-le avec .NET Framework 4.6.2 ou version ultérieure, ou avec .NET 6 ou version ultérieure.|Windows. Linux et macOS avec la bibliothèque `libgdiplus` et l'option `System.Drawing.EnableUnixSupport`.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. Utilisez-le avec .NET 6 ou version ultérieure.|Windows (x86, x64), Linux (x64 avec glibc 2.23 ou version ultérieure, ARM64 avec glibc 2.39 ou version ultérieure) et macOS (x64, ARM64).|

[Installation](/slides/fr/net/installation/) explique quel package choisir et ce dont chacun a besoin sous Linux. [Exigences système](/slides/fr/net/system-requirements/) répertorie en détail les plateformes prises en charge.

## **Formats de fichier et conversions**

Aspose.Slides ouvre et enregistre les présentations PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP et les présentations PowerPoint XML. Il importe du contenu PDF et HTML dans les diapositives, et il enregistre les présentations au format PDF, XPS, HTML, HTML5, TIFF, GIF animé, SWF, Markdown et XAML. [Formats de fichier pris en charge](/slides/fr/net/supported-file-formats/) répertorie chaque format avec l'API qui le lit ou l'écrit.

|**Fonctionnalité**|**Description**|
| :- | :- |
|[PPT et PPTX](/slides/fr/net/ppt-vs-pptx/)|Lire et écrire à la fois le format binaire PowerPoint 97-2003 et le format Office Open XML.|
|[Conversion PPT vers PPTX](/slides/fr/net/convert-ppt-to-pptx/)|Convertir les présentations PPT héritées en PPTX.|
|[Format de document portable (PDF)](/slides/fr/net/convert-powerpoint-to-pdf/)|Exporter les présentations en PDF, y compris les documents PDF/A et PDF/UA.|
|[Spécification de papier XML (XPS)](/slides/fr/net/convert-powerpoint-to-xps/)|Exporter les présentations en documents XPS.|
|[Format d'image balisé (TIFF)](/slides/fr/net/convert-powerpoint-to-tiff/)|Exporter les présentations en images TIFF.|
|[HTML](/slides/fr/net/convert-powerpoint-to-html/)|Exporter les présentations en HTML et HTML5.|
|[Importation PDF et HTML](/slides/fr/net/import-presentation/)|Créer des diapositives à partir de pages PDF et de contenu HTML.|

## **Rendu de présentation**

Aspose.Slides rend les diapositives et les formes individuelles au format PNG, JPEG, BMP, GIF, TIFF et SVG, et les diapositives au format métafile EMF. Voir [Convertir les diapositives de présentation en images](/slides/fr/net/convert-slide/), [Rendre une diapositive en image SVG](/slides/fr/net/render-a-slide-as-an-svg-image/) et [Créer des vignettes de forme](/slides/fr/net/create-shape-thumbnails/).

## **Fonctionnalités de contenu**

Aspose.Slides vous permet de créer, lire et modifier presque tout le contenu d'une présentation :

|**Zone**|**Ce que vous pouvez faire**|
| :- | :- |
|[Diapositives](/slides/fr/net/presentation-slide/)|Ajouter, cloner, réorganiser et supprimer des diapositives ; appliquer des dispositions et des maîtres ; organiser les diapositives en sections ; modifier la taille de la diapositive.|
|[Design](/slides/fr/net/presentation-design/)|Définir les arrière-plans, les couleurs du thème, les en-têtes et pieds de page, ainsi que les polices.|
|[Texte](/slides/fr/net/manage-text/)|Créer et modifier des cadres de texte, paragraphes et portions ; définir les polices, les couleurs, les puces et l'alignement ; rechercher et remplacer du texte.|
|[Formes](/slides/fr/net/powerpoint-shapes/)|Créer des AutoShapes, lignes, connecteurs, formes groupées et cadres d'image ; définir la position, la taille, le contour et le remplissage uni, dégradé ou motif ; trouver une forme par son texte alternatif.|
|[Tableaux](/slides/fr/net/powerpoint-table/), [charts](/slides/fr/net/powerpoint-charts/), et [SmartArt](/slides/fr/net/powerpoint-smartart/)|Créer et modifier des tableaux, des graphiques Microsoft Office et des diagrammes SmartArt.|
|[Médias](/slides/fr/net/manage-media-files/), [objets OLE](/slides/fr/net/manage-ole/), et [contrôles ActiveX](/slides/fr/net/activex/)|Ajouter des cadres audio et vidéo embarqués ou liés, intégrer des objets OLE, et ajouter, modifier ou supprimer des contrôles ActiveX.|
|[Notes](/slides/fr/net/presentation-notes/) et [commentaires](/slides/fr/net/presentation-comments/)|Ajouter, lire et modifier les notes du présentateur et les commentaires d'examen.|
|[Animation](/slides/fr/net/powerpoint-animation/) et [transitions](/slides/fr/net/slide-transition/)|Appliquer des effets d'animation aux formes, définir les transitions de diapositive et configurer les paramètres du diaporama.|
|[Sécurité](/slides/fr/net/presentation-security/)|Chiffrer les présentations avec un mot de passe, définir une protection en écriture et travailler avec des signatures numériques.|
|[Macros VBA](/slides/fr/net/presentation-via-vba/)|Ajouter, extraire et supprimer des modules VBA dans les présentations activées par macros.|
|[Propriétés](/slides/fr/net/presentation-properties/)|Lire et modifier les propriétés du document.|

## **FAQ**

**Dois-je installer Microsoft PowerPoint sur le serveur ou le PC pour que la bibliothèque fonctionne ?**

Non. PowerPoint n'est pas requis ; Aspose.Slides est un moteur autonome pour créer, modifier, convertir et rendre des présentations.

**Comment le multithreading fonctionne-t-il ? Le traitement peut-il être parallélisé ?**

Il est sûr de traiter différents documents dans des threads distincts ; le même objet [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) ne doit pas être utilisé par [multiple threads](/slides/fr/net/multithreading/) simultanément.

**Les mots de passe de fichiers et le chiffrement sont-ils pris en charge ?**

Oui. [Vous pouvez](/slides/fr/net/password-protected-presentation/) ouvrir des présentations chiffrées, définir ou supprimer un mot de passe d'ouverture et d'écriture, et vérifier l'état de protection.

**Dois-je m'occuper des polices dans les conteneurs Linux ?**

Oui. Les polices utilisées dans vos présentations, ou des substituts appropriés, doivent être installées sur le système pour que le texte s'affiche correctement. Vous pouvez également [spécifier les répertoires de polices](/slides/fr/net/custom-font/) dans votre application. [Installation](/slides/fr/net/installation/) répertorie les prérequis Linux de chaque package.

**Existe-t-il des limitations dans la version d'évaluation ?**

Oui. Sans [licence](/slides/fr/net/licensing/), Aspose.Slides ajoute un filigrane d'évaluation à chaque diapositive qu'il enregistre et tronque le texte lu depuis les présentations. Une [licence temporaire de 30 jours](https://purchase.aspose.com/temporary-license/) est disponible pour tester toutes les fonctionnalités.

**L'importation de formats externes dans une présentation (PDF ou HTML vers PPTX) est-elle prise en charge ?**

Oui. Vous pouvez ajouter des [pages PDF et du contenu HTML](/slides/fr/net/import-presentation/) à une présentation, les transformant en diapositives.