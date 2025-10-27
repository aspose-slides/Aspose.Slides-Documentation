---
title: Convertir des présentations en plusieurs formats avec Python
linktitle: Convertir des présentations
type: docs
weight: 70
url: /fr/python-net/convert-presentation/
keywords:
- convertir présentation
- exporter présentation
- PPT en PPTX
- PPT en PDF
- PPTX en PDF
- PPT en XPS
- PPTX en XPS
- PPT en TIFF
- PPTX en TIFF
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Convertir les présentations PowerPoint et OpenDocument en PPTX, PDF, XPS, TIFF et plus avec Aspose.Slides pour Python via .NET. Simple, conversion de haute qualité."
---

## **Introduction**

Cette page offre un aperçu de la conversion de présentations avec Aspose.Slides pour Python via .NET. Elle résume les scénarios pris en charge et renvoie vers des guides spécifiques montrant le code exact pour exporter des présentations et des diapositives vers des formats tels que PDF, XPS, TIFF, ainsi que pour convertir entre PPT et PPTX. Le cas échéant, les articles liés mettent en évidence les options propres à chaque format — par exemple, le rendu des notes ou l’ajustement de la qualité d’image — et les limitations connues comme le support partiel des chemins PPT→PPTX. Utilisez cette page pour choisir un format cible, puis suivez la procédure liée.

## **Conversion PPT en PPTX**

### **À propos de PPT/PPTX**

PPT est l’ancien format binaire PowerPoint (97–2003), tandis que PPTX est le format Open XML empaqueté en ZIP introduit dans PowerPoint 2007. Comparé à PPT, PPTX produit généralement des fichiers plus petits, prend en charge les fonctionnalités modernes, fonctionne bien avec l’automatisation de documents et est recommandé pour le stockage à long terme et les flux de travail multiplateformes.

### **Convertir PPT en PPTX**

Aspose.Slides prend en charge la conversion des présentations PPT au format PPTX. L’avantage principal d’utiliser l’API Aspose.Slides pour cette tâche est la simplicité du flux de travail nécessaire pour obtenir le résultat souhaité. En pratique, vous pouvez effectuer la conversion avec un code minimal tout en conservant une haute fidélité des diapositives, des mises en page et des médias.

{{% alert color="primary" %}}
En savoir plus : [Convertir PPT en PPTX avec Python](/slides/fr/python-net/convert-ppt-to-pptx/).
{{% /alert %}}

## **Conversion de présentation en PDF**

### **À propos du PDF**

Le [Portable Document Format](https://en.wikipedia.org/wiki/PDF) (PDF) est un format de fichier créé par Adobe Systems pour l’échange de documents entre organisations. Son but est d’assurer que le contenu d’un document s’affiche avec le même aspect visuel quel que soit la plateforme sur laquelle le document est visualisé.

### **Convertir des présentations en PDF**

Tout fichier de présentation pouvant être chargé dans Aspose.Slides peut être converti en document PDF. Vous pouvez exporter directement les présentations au format PDF avec le composant Aspose.Slides ; aucune bibliothèque tierce ni le composant Aspose.PDF ne sont requis.

{{% alert color="primary" %}}
En savoir plus : [Convertir PPT & PPTX en PDF avec Python](/slides/fr/python-net/convert-powerpoint-to-pdf/).
{{% /alert %}}

## **Conversion de présentation en XPS**

### **À propos de XPS**

La [XML Paper Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) (XPS) est un langage de description de page et un format de document fixe développé à l’origine par Microsoft. À l’instar du PDF, XPS est un format de document à mise en page fixe conçu pour préserver la fidélité du document et offrir un rendu indépendant du dispositif.

### **Convertir des présentations en XPS**

Toute présentation pouvant être chargée par Aspose.Slides peut être convertie au format XPS. Aspose.Slides utilise un moteur de mise en page et de rendu à haute fidélité pour produire une sortie au format XPS à mise en page fixe. Notamment, Aspose.Slides génère le XPS directement sans dépendre de Windows Presentation Foundation (WPF).

{{% alert color="primary" %}}
En savoir plus : [Convertir les présentations PowerPoint en XPS avec Python](/slides/fr/python-net/convert-powerpoint-to-xps/).
{{% /alert %}}

## **Conversion de présentation en TIFF**

### **À propos du TIFF**

Le [Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF) (TIFF) est un format d’image raster connu pour stocker plusieurs images (pages) dans un même fichier. Développé à l’origine par Aldus, il est largement pris en charge par les applications de numérisation, de télécopie et d’autres traitements d’image.

### **Convertir des présentations en TIFF**

Tout document pouvant être chargé dans Aspose.Slides peut également être converti directement en fichier TIFF sans aucun composant tiers. Vous pouvez également, de façon optionnelle, spécifier la taille de l’image pour les pages du TIFF résultant.

{{% alert color="primary" %}}
En savoir plus : [Convertir les présentations PowerPoint en TIFF avec Python](/slides/fr/python-net/convert-powerpoint-to-tiff/).
{{% /alert %}}

## **FAQ**

**Puis-je inclure les diapositives cachées lors de l'exportation en PDF/XPS ?**

Oui. L’exportation prend en charge l’inclusion des diapositives cachées via l’option correspondante dans les paramètres du [PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)/[XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/).

**La sauvegarde au format PDF/A (pour l'archivage) est‑elle prise en charge ?**

Oui, les niveaux de conformité PDF/A [sont disponibles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/) (y compris A-2a/A-2b/A-2u et A-3a/A-3b) lors de l’exportation.

**Que se passe-t-il pour les polices lors de la conversion : sont‑elles incorporées ou remplacées ?**

Il existe des options flexibles : vous pouvez [incorporer tous les glyphes ou seulement les sous‑ensembles utilisés](/slides/fr/python-net/embedded-font/), spécifier une [police de secours](/slides/fr/python-net/fallback-font/), et [contrôler le comportement](/slides/fr/python-net/font-substitution/) lorsqu’une police manque de certains styles.

**Comment puis‑je contrôler la qualité et la taille du PDF résultant ?**

Des options sont disponibles pour la [qualité JPEG](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/), la [compression du texte](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/), et un seuil de [résolution suffisante](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) pour les images, plus un mode qui sélectionne la [meilleure compression pour les images](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/).

**Puis‑je exporter uniquement une plage de diapositives (par exemple, 5–12) ?**

Oui, l’exportation prend en charge la sélection d’un sous‑ensemble de diapositives.

**Le traitement multi‑cœur de plusieurs fichiers en même temps est‑il pris en charge ?**

Il est acceptable de traiter différentes présentations en parallèle dans des processus distincts. Important : le même objet [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ne doit pas être chargé ou enregistré depuis [plusieurs threads](/slides/fr/python-net/multithreading/).

**Existe‑t‑il des risques lors de l'application de la licence depuis différents threads ?**

Oui, les appels de [définition de licence](/slides/fr/python-net/licensing/) ne sont pas thread‑safe et nécessitent une synchronisation.