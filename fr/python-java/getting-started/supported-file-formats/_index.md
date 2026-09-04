---
title: Formats de fichiers pris en charge
type: docs
weight: 30
url: /fr/python-java/supported-file-formats/
keywords:
- formats de fichiers pris en charge
- formats de présentation
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- images de diapositives
- Python
- Aspose.Slides for Python via Java
description: "Découvrez les formats de présentation, de document, Web et d'image que Aspose.Slides for Python via Java peut charger, importer, enregistrer et exporter."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java lit et écrit des présentations PowerPoint et OpenDocument. Il importe également du contenu PDF et HTML dans des diapositives et exporte des présentations ou des diapositives individuelles vers des formats de document, Web et image.

Le tableau ci‑dessous distingue le chargement de présentations de l’importation de contenu et du rendu des diapositives. Pour un aperçu des capacités d’édition et de rendu, consultez [Aperçu des fonctionnalités](/slides/fr/python-java/features-overview/).

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
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)


## **Formats de fichiers pris en charge**

Le tableau suivant répertorie les formats d’entrée et de sortie pris en charge. **Load / Import** inclut l’ouverture des fichiers de présentation et l’importation de contenu PDF ou HTML. **Save / Export** inclut l’enregistrement des présentations et le rendu des diapositives en images. Un tiret indique que l’opération correspondante n’est pas prise en charge en tant qu’opération de conversion de présentation.

|**Format**|**Description**|**Load / Import**|**Save / Export**|**Remarques**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Présentation PowerPoint 97‑2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|Modèle PowerPoint 97‑2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|Diaporama PowerPoint 97‑2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Présentation PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|Modèle PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Diaporama PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Présentation PowerPoint avec macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Diaporama PowerPoint avec macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|Modèle PowerPoint avec macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP](https://docs.fileformat.com/presentation/odp/)|Présentation OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Format OpenDocument empaqueté.|
|FODP|Présentation OpenDocument XML plat|{{< emoticons/tick >}}|{{< emoticons/tick >}}|Stocke la présentation dans un seul document XML.|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Modèle de présentation OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Format de fichier image balisé|—|{{< emoticons/tick >}}|Prend en charge la sortie multipage.|
|[EMF](https://docs.fileformat.com/image/emf/)|Méta‑fichier amélioré|—|{{< emoticons/tick >}}|Exporte les diapositives individuelles en images vectorielles.|
|[PDF](https://docs.fileformat.com/pdf/)|Format de document portable|Import|{{< emoticons/tick >}}|Importe les pages PDF comme diapositives ; exporte les présentations au format PDF.|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Spécification XML Paper|—|{{< emoticons/tick >}}|Sortie de document à mise en page fixe.|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Image JPEG|—|{{< emoticons/tick >}}|Rend les diapositives individuelles en images matricielles.|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|{{< emoticons/tick >}}|Rend les diapositives individuelles en images matricielles.|
|[GIF](https://docs.fileformat.com/image/gif/)|Format d’échange d’images GIF|—|{{< emoticons/tick >}}|Sortie image.|
|[BMP](https://docs.fileformat.com/image/bmp/)|Image bitmap|—|{{< emoticons/tick >}}|Rend les diapositives individuelles en images matricielles.|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Graphiques vectoriels évolutifs|—|{{< emoticons/tick >}}|Exporte les diapositives individuelles en images vectorielles.|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Format Web compact|—|{{< emoticons/tick >}}|Sortie Flash.|
|[HTML](https://docs.fileformat.com/web/html/)|Langage de balisage hypertexte|Import|{{< emoticons/tick >}}|Importe le contenu HTML comme diapositives ; prend en charge l’exportation HTML et HTML5.|
|[XAML](https://docs.fileformat.com/web/xaml/)|Langage de balisage d’application extensible|—|{{< emoticons/tick >}}|Exporte le contenu de la présentation en XAML.|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|{{< emoticons/tick >}}|Exporte le contenu de la présentation vers Markdown.|
|[XML](https://docs.fileformat.com/web/xml/)|Présentation XML PowerPoint|—|{{< emoticons/tick >}}|Sortie XML spécifique à PowerPoint, pas du XML arbitraire.|

## **Notes d'importation et d'exportation**

- **Import PDF et HTML:** Utilisez [SlideCollection.addFromPdf](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addfrompdf) ou [SlideCollection.addFromHtml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addfromhtml) pour créer des diapositives à partir du contenu source et les ajouter à une présentation.
- **Sortie de présentation:** [SaveFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/) répertorie les formats d’enregistrement de présentation disponibles, y compris les options d’exportation HTML et HTML5 séparées.
- **Sortie d'image:** Exporter une diapositive en image produit une représentation visuelle de cette diapositive. La colonne d’entrée ne décrit pas si une image peut être insérée dans une présentation.

## **FAQ**

**Puis-je convertir une présentation PPT en PPTX ou ODP ?**

Oui. PPT est pris en charge comme format d’entrée, et PPTX ainsi que ODP sont pris en charge comme formats de sortie. Le résultat de la conversion dépend des fonctionnalités disponibles dans le format de destination.

**L’importation PDF ou HTML ouvre‑t‑elle la source comme un fichier PowerPoint ?**

Non. L’importation crée des diapositives à partir des pages PDF ou du contenu HTML. Vous pouvez ensuite enregistrer la présentation résultante dans un format de présentation pris en charge.

**Puis‑je charger un PNG ou SVG exporté comme présentation modifiable ?**

Non. Ces exportations représentent l’apparence des diapositives. Conservez la présentation source lorsque vous devez modifier ultérieurement son texte, ses formes, graphiques et autres objets.