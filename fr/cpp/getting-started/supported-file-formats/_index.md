---
title: Formats de fichiers pris en charge
type: docs
weight: 20
url: /fr/cpp/supported-file-formats/
keywords:
- format de fichier
- format pris en charge
- PPT
- POT
- PPS
- PPTX
- POTX
- PPSX
- PPTM
- PPSM
- POTM
- ODP
- FODP
- OTP
- TIFF
- EMF
- PDF
- XPS
- JPEG
- PNG
- GIF
- BMP
- SVG
- SWF
- HTML
- XAML
- MD
- XML
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Découvrez tous les formats de fichiers qu'Aspose.Slides for C++ peut ouvrir, enregistrer et convertir — incluant PPT, PPTX et ODP — avec des notes claires de prise en charge d'import/export."
---
## **Aperçu**

Aspose.Slides prend en charge les fichiers de présentation de Microsoft PowerPoint 97 à Office 365, y compris Microsoft PowerPoint pour Mac. Cet article répertorie les versions de PowerPoint prises en charge par la bibliothèque et fournit un tableau des formats de fichiers qui peuvent être chargés, enregistrés ou les deux.

L’article répond également aux questions courantes concernant la conformité PDF, l’incorporation des polices, les fichiers protégés par mot de passe, les polices personnalisées, le secours des polices et les options d’exportation XPS.

## **Versions Microsoft PowerPoint prises en charge**
- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for MAC
- Office 365

## **Formats de fichiers pris en charge**
Ce tableau contient les formats de fichiers qu’Aspose.Slides for C++ peut charger et enregistrer :

|**Format**|**Description**|**Chargement**|**Enregistrement**|**Remarques**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Présentation PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|Modèle PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|Diaporama PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Présentation PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|Modèle PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|Diaporama PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Présentation PowerPoint avec macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Diaporama PowerPoint avec macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|Modèle PowerPoint avec macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|Présentation OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|Modèle de présentation OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Format de fichier d’image TAG| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|Format Metafile amélioré| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|Format de document portable|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Spécification XML Paper| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap indépendant du périphérique| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|Présentation PowerPoint XML| |{{< emoticons/tick >}}| |

## **FAQ**

**Puis-je enregistrer des présentations en PDF conformes aux normes d'archivage et d'accessibilité (PDF/A et PDF/UA) ?**

Oui. Aspose.Slides prend en charge l’exportation vers PDF avec des niveaux de conformité tels que PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, ainsi que PDF/UA via le paramètre [conformité](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/pdfoptions/set_compliance/) dans les [options d'exportation PDF](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/pdfoptions/).

**La bibliothèque prend-elle en charge l’incorporation de polices lors de l’exportation vers PDF, avec un contrôle granulaire sur ce qui est incorporé ?**

Oui. Vous pouvez contrôler si les polices sont entièrement incorporées ou sous‑ensemble (uniquement les glyphes utilisés), spécifier le traitement des polices système courantes et configurer le comportement pour le texte ASCII via les [options d'exportation PDF](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/pdfoptions/).

**Puis-je détecter si un fichier est protégé par mot de passe avant de le charger réellement ?**

Oui. En utilisant l’[API d’inspection basée sur une usine](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentationfactory/), vous pouvez interroger un fichier de présentation pour déterminer s’il est protégé par mot de passe sans l’ouvrir complètement.

**Existe-t-il des mécanismes de secours de police et la prise en charge des polices personnalisées ?**

Oui. La bibliothèque prend en charge le [chargement](/slides/fr/cpp/custom-font/) et l’[incorporation](/slides/fr/cpp/embedded-font/) de polices personnalisées et fournit des [règles de secours de police](/slides/fr/cpp/fallback-font/) pour éviter les glyphes manquants lors du rendu et de la conversion.

**Puis-je exporter des diapositives vers XPS, et existe-t-il des options pour régler la sortie XPS ?**

Oui. L’[exportation vers XPS](/slides/fr/cpp/convert-powerpoint-to-xps/) est prise en charge, et vous pouvez ajuster les [options d’enregistrement](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/xpsoptions/) pertinentes pour contrôler la qualité et le contenu du document XPS.