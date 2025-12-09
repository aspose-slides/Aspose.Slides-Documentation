---
title: Formats de fichiers pris en charge
type: docs
weight: 30
url: /fr/nodejs-java/supported-file-formats/
---

## **Versions de Microsoft PowerPoint prises en charge**
- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint pour MAC
- Office 365

## **Formats de fichiers pris en charge**
This table contains the file formats that Aspose.Slides for Node.js via Java can load and save:

|**Format**|**Description**|**Chargement**|**Enregistrement**|**Remarques**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Présentation PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POT](https://docs.fileformat.com/presentation/pot/)|Modèle PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPS](https://docs.fileformat.com/presentation/pps/)|Diaporama PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Présentation PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTX](https://docs.fileformat.com/presentation/potx/)|Modèle PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|Diaporama PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Présentation PowerPoint avec macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Diaporama PowerPoint avec macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTM](https://docs.fileformat.com/presentation/potm/)|Modèle PowerPoint avec macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|Présentation OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[OTP](https://docs.fileformat.com/presentation/otp/)|Modèle de présentation OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tag Image File Format||{{< emoticons/tick >}}||
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile Format||{{< emoticons/tick >}}||
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification||{{< emoticons/tick >}}||
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group||{{< emoticons/tick >}}||
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics||{{< emoticons/tick >}}||
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format||{{< emoticons/tick >}}||
|[BMP](https://docs.fileformat.com/image/bmp/)|Device Independent Bitmap||{{< emoticons/tick >}}||
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics||{{< emoticons/tick >}}||
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format||{{< emoticons/tick >}}||
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language||{{< emoticons/tick >}}||
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML Presentation| |{{< emoticons/tick >}}| |

## **FAQ**

**Puis-je enregistrer des présentations au format PDF qui respectent les normes d'archivage et d'accessibilité (PDF/A et PDF/UA) ?**

Oui. Aspose.Slides prend en charge l’exportation vers PDF avec des niveaux de conformité tels que PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, ainsi que PDF/UA via le paramètre [compliance](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setcompliance/) dans les [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**La bibliothèque prend‑elle en charge l’intégration des polices lors de l’exportation en PDF, avec un contrôle granulaire sur ce qui est intégré ?**

Oui. Vous pouvez contrôler si les polices sont entièrement intégrées ou sous‑ensemble (glyphes utilisés uniquement), spécifier la façon dont les polices système courantes sont traitées, et configurer le comportement pour le texte ASCII via les [PDF export options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/).

**Puis‑je détecter si un fichier est protégé par mot de passe avant de le charger réellement ?**

Oui. En utilisant l’[API d’inspection basée sur les factories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/), vous pouvez interroger un fichier de présentation pour déterminer s’il est protégé par mot de passe sans l’ouvrir complètement.

**Existe‑t‑il des mécanismes de repli de police et une prise en charge des polices personnalisées ?**

Oui. La bibliothèque prend en charge le [chargement](/slides/fr/nodejs-java/custom-font/) et l’[intégration](/slides/fr/nodejs-java/embedded-font/) de polices personnalisées et fournit des [règles de repli de police](/slides/fr/nodejs-java/fallback-font/) pour éviter les glyphes manquants lors du rendu et de la conversion.

**Puis‑je exporter des diapositives au format XPS, et existe‑t‑il des options pour ajuster la sortie XPS ?**

Oui. L’[exportation vers XPS](/slides/fr/nodejs-java/convert-powerpoint-to-xps/) est prise en charge, et vous pouvez ajuster les [save options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/) pertinents pour contrôler la qualité et le contenu du document XPS.