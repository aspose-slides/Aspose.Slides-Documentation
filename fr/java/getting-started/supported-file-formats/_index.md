---
title: Formats de fichiers pris en charge
type: docs
weight: 106
url: /fr/java/supported-file-formats/
keywords:
- formats de fichiers pris en charge
- charger une présentation
- importer PDF
- importer HTML
- enregistrer une présentation
- rendre les diapositives
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- Java
- Aspose.Slides
description: "Découvrez quels formats de fichiers Aspose.Slides for Java peut charger, importer, enregistrer et rendre, et quelle API lit ou écrit chacun d’eux."
---
## **Aperçu**

Aspose.Slides for Java ouvre et enregistre des présentations PowerPoint et OpenDocument. Il importe également du contenu PDF et HTML dans des diapositives, enregistre les présentations dans des formats document, web et image, et rend des diapositives et des formes individuelles sous forme d’images. Cet article répertorie chaque format pris en charge et indique l’API qui le lit ou l’écrit.

Pour un aperçu des fonctionnalités d’édition, voir [Aperçu des fonctionnalités](/slides/fr/java/features-overview/).

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
- Microsoft PowerPoint pour Mac
- PowerPoint pour Microsoft 365 (anciennement Office 365)

{{% alert color="info" title="Remarque" %}}

Les présentations enregistrées avec PowerPoint 95 et les versions antérieures ne peuvent pas être ouvertes. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) reconnaît un fichier PowerPoint 95 et indique `LoadFormat.Ppt95`, mais le constructeur [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) lève [PptUnsupportedFormatException](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pptunsupportedformatexception/) dans ce cas.

{{% /alert %}}

## **Formats de fichiers pris en charge**

Le tableau utilise quatre opérations :

- **Charger** : le constructeur [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) ouvre le fichier comme une présentation modifiable.
- **Importer** : une méthode de [SlideCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidecollection/) crée des diapositives à partir du contenu du fichier et les ajoute à une présentation existante. Le constructeur Presentation ne convertit pas ces fichiers en diapositives.
- **Enregistrer** : [Presentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) écrit la présentation dans un fichier ou un flux. Chaque format sauf XAML est sélectionné avec une valeur de [SaveFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/saveformat/).
- **Rendre** : une méthode de rendu dessine une diapositive ou une forme sous forme d’image. Les formats qui ne sont que rendus ne sont pas des valeurs SaveFormat.

|**Format**|**Description**|**Charger / Importer**|**Enregistrer / Rendre**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Présentation PowerPoint 97-2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Modèle PowerPoint 97-2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Diaporama PowerPoint 97-2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Présentation PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Modèle PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Diaporama PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Présentation PowerPoint avec macros|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Modèle PowerPoint avec macros|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Diaporama PowerPoint avec macros|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Présentation OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Présentation OpenDocument XML plate|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Modèle de présentation OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Présentation PowerPoint XML|Load|Save|`SaveFormat.Xml`; les fichiers chargés indiquent `SourceFormat.Xml` (il n’existe pas de valeur `LoadFormat`)|
|[PDF](https://docs.fileformat.com/pdf/)|Format de document portable|Import|Save|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Langage de balisage hypertexte|Import|Save|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Spécification XML Paper|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Format de fichier image balisé|—|Save, Render|`SaveFormat.Tiff` (une page par diapositive); `ImageFormat.Tiff` (une diapositive)|
|[GIF](https://docs.fileformat.com/image/gif/)|Format d’échange graphique|—|Save, Render|`SaveFormat.Gif` (animé, toutes les diapositives); `ImageFormat.Gif` (une diapositive)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Petit format Web (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Langage de balisage d’application extensible|—|Save|`Presentation.save(IXamlOptions)`, un fichier XAML par diapositive ; pas de valeur `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Graphiques réseau portables|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Image JPEG|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Image BMP|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Métafile amélioré|—|Render|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Graphiques vectoriels évolutifs|—|Render|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Charger et importer**

- **Charger :** transmettez un chemin de fichier ou un flux au constructeur [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). Le format est détecté à partir du contenu ; [LoadOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/) fournit des paramètres comme un mot de passe. Pour vérifier un fichier avant de l’ouvrir, appelez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-), qui indique une valeur de [LoadFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadformat/). Il indique `LoadFormat.Unknown` pour le XML PowerPoint, mais le constructeur ouvre ce type de fichier, et [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getSourceFormat--) renvoie alors `SourceFormat.Xml`. Voir [Ouvrir des présentations](/slides/fr/java/open-presentation/) et [Déterminer le format d’origine d’une présentation](/slides/fr/java/detect-presentation-source-format/).
- **Importer :** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) ajoute une diapositive par page PDF à la fin d’une présentation. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) ajoute des diapositives créées à partir de HTML, et [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) les insère à une position donnée. Le constructeur Presentation n’importe pas : il lève [PptUnsupportedFormatException](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pptunsupportedformatexception/) pour un fichier PDF et ne convertit pas le balisage HTML en contenu de diapositive. Voir [Importer des présentations depuis PDF ou HTML](/slides/fr/java/import-presentation/).

## **Enregistrer et rendre**

- **Enregistrer :** [Presentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) écrit la présentation selon la valeur d’un [SaveFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/saveformat/). Les surcharges qui acceptent également un objet d’options contrôlent la sortie, par exemple [PdfOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/fr/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/tiffoptions/), et [GifOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/gifoptions/). Les surcharges qui prennent un tableau de positions de diapositives, à partir de 1, écrivent uniquement ces diapositives ; elles acceptent PDF, XPS, TIFF, HTML, HTML5, SWF, GIF et Markdown, mais pas les formats de présentation ni le XML PowerPoint. XAML possède sa propre surcharge, [Presentation.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), qui accepte [IXamlOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ixamloptions/). Voir [Enregistrer des présentations](/slides/fr/java/save-presentation/), [Convertir des présentations](/slides/fr/java/convert-presentation/), et [Exporter des présentations vers XAML](/slides/fr/java/export-to-xaml/).
- **Rendre :** [Slide.getImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slide/#getImage-float-float-) et [Shape.getImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#getImage--) renvoient un [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/), et [IImage.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/#save-java.lang.String-int-) l’écrit en PNG, JPEG, BMP, GIF ou TIFF, sélectionné avec une valeur [ImageFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imageformat/). [Presentation.getImages](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) rend toutes les diapositives ou les diapositives sélectionnées en une fois. [Slide.writeAsSvg](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) et [Shape.writeAsSvg](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) écrivent du SVG, et [Slide.writeAsEmf](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) écrit du EMF. Voir [Convertir des diapositives de présentation en images](/slides/fr/java/convert-slide/) et [Rendre des diapositives de présentation en images SVG](/slides/fr/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Avertissement" %}}

ImageFormat possède également les valeurs `Emf`, `Wmf`, `Icon`, `Exif` et `MemoryBmp`, mais IImage.save ne produit pas ces formats : le fichier écrit contient des données PNG. Pour obtenir une image EMF d’une diapositive, utilisez Slide.writeAsEmf.

{{% /alert %}}

## **FAQ**

**Puis-je convertir une présentation PPT en PPTX ou ODP ?**

Oui. Ouvrez le fichier PPT avec le constructeur Presentation et enregistrez‑le avec `SaveFormat.Pptx` ou `SaveFormat.Odp`. Voir [Convertir PPT en PPTX](/slides/fr/java/convert-ppt-to-pptx/).

**Puis‑je ouvrir un fichier PDF ou HTML comme une présentation ?**

Non. Le constructeur Presentation lève PptUnsupportedFormatException pour un fichier PDF et ne convertit pas le balisage HTML en diapositives. Créez ou ouvrez une présentation, importez les pages PDF ou le contenu HTML avec les méthodes de collection de diapositives décrites ci‑dessus, puis enregistrez‑la dans n’importe quel format pris en charge.

**Puis‑je charger une image PNG ou SVG exportée comme présentation modifiable ?**

Non. La sortie image enregistre l’apparence d’une diapositive, pas son texte, ses formes ou ses graphiques. Conservez la présentation source si vous devez la modifier ultérieurement.

**Puis‑je enregistrer des documents PDF/A ou PDF/UA ?**

Oui. Transmettez une valeur [PdfCompliance](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfcompliance/) à [PdfOptions.setCompliance](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfoptions/#setCompliance-int-)\: PDF/A‑1a, PDF/A‑1b, PDF/A‑2a, PDF/A‑2b, PDF/A‑2u, PDF/A‑3a, PDF/A‑3b ou PDF/UA.

**Puis‑je vérifier si un fichier est protégé par mot de passe avant de l’ouvrir ?**

Oui. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) examine le fichier sans créer d’objet Presentation, et [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) indique si un mot de passe est requis. Voir [Protéger les présentations par mot de passe](/slides/fr/java/password-protected-presentation/).