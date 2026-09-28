---
title: Formats de fichiers pris en charge
type: docs
weight: 96
url: /fr/net/supported-file-formats/
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
- .NET
- C#
- Aspose.Slides
description: "Découvrez quels formats de fichiers Aspose.Slides pour .NET peut charger, importer, enregistrer et rendre, et quelle API lit ou écrit chacun d’eux."
---
## **Vue d'ensemble**

Aspose.Slides for .NET ouvre et enregistre des présentations PowerPoint et OpenDocument. Il importe également du contenu PDF et HTML dans des diapositives, enregistre les présentations aux formats document, web et image, et rend les diapositives et formes individuelles sous forme d’images. Cet article répertorie chaque format pris en charge et indique l’API qui le lit ou l’écrit.

Les deux packages NuGet, Aspose.Slides.NET et Aspose.Slides.NET6.CrossPlatform, prennent en charge les mêmes formats ; consultez [Installation](/slides/fr/net/installation/) pour choisir l’un d’eux. Pour une vue d’ensemble des fonctions d’édition, see [Features Overview](/slides/fr/net/features-overview/).

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
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Note" %}}

Les présentations enregistrées avec PowerPoint 95 et les versions antérieures ne peuvent pas être ouvertes. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/presentationfactory/getpresentationinfo/) reconnaît un fichier PowerPoint 95 et renvoie `LoadFormat.Ppt95`, mais le constructeur [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/presentation/) lève une [PptUnsupportedFormatException](https://reference.aspose.com/slides/fr/net/aspose.slides/pptunsupportedformatexception/) pour ce fichier.

{{% /alert %}}

## **Formats de fichier pris en charge**

Le tableau utilise quatre opérations :

- **Charge** : le constructeur [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/presentation/) ouvre le fichier comme une présentation modifiable.
- **Importation** : une méthode de [SlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/slidecollection/) crée des diapositives à partir du contenu du fichier et les ajoute à une présentation existante. Le constructeur Presentation ne charge pas ces fichiers comme présentations.
- **Enregistrement** : [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) écrit la présentation dans un fichier ou un flux. Chaque format sauf XAML est sélectionné avec une valeur [SaveFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/).
- **Rendu** : une méthode de rendu dessine une diapositive ou une forme sous forme d’image. Les formats qui ne sont rendus que sont pas des valeurs SaveFormat.

|**Format**|**Description**|**Charge / Import**|**Enregistre / Rendu**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Présentation PowerPoint 97‑2003|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|Modèle PowerPoint 97‑2003|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|Diaporama PowerPoint 97‑2003|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Présentation PowerPoint|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|Modèle PowerPoint|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Diaporama PowerPoint|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Présentation PowerPoint avec macros|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|Modèle PowerPoint avec macros|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Diaporama PowerPoint avec macros|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|Présentation OpenDocument|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Présentation OpenDocument XML plat|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|Modèle de présentation OpenDocument|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|Présentation PowerPoint XML|Load|Save|`SaveFormat.Xml`; les fichiers chargés renvoient `SourceFormat.Xml` (pas de valeur `LoadFormat`)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Save, Render|`SaveFormat.Tiff`; `ImageFormat.Tiff` (une diapositive)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Save, Render|`SaveFormat.Gif` (animé, toutes les diapositives); `ImageFormat.Gif` (une diapositive)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Save|`Presentation.Save(IXamlOptions)`, un fichier XAML par diapositive ; pas de valeur `SaveFormat`|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Image JPEG|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Image Bitmap|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Chargement et importation**

- **Charge** : passez un chemin de fichier ou un flux au constructeur [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/presentation/). Le format est détecté à partir du contenu ; [LoadOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/) fournit des paramètres tels qu’un mot de passe. Pour vérifier un fichier avant de l’ouvrir, appelez [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/presentationfactory/getpresentationinfo/), qui renvoie une valeur [LoadFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/loadformat/). Il renvoie `LoadFormat.Unknown` pour le PowerPoint XML, mais le constructeur ouvre tout de même ce fichier, et [Presentation.SourceFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/sourceformat/) renvoie alors `SourceFormat.Xml`. Voir [Open Presentations](/slides/fr/net/open-presentation/) et [Determine the Original Presentation Format](/slides/fr/net/detect-presentation-source-format/).
- **Importation** : [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/fr/net/aspose.slides/slidecollection/addfrompdf/) ajoute une diapositive par page PDF à la fin d’une présentation. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/fr/net/aspose.slides/slidecollection/addfromhtml/) ajoute des diapositives créées à partir de HTML, et [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/fr/net/aspose.slides/slidecollection/insertfromhtml/) les insère à une position donnée. Le constructeur Presentation n’effectue pas d’importation : il lève une [PptUnsupportedFormatException](https://reference.aspose.com/slides/fr/net/aspose.slides/pptunsupportedformatexception/) pour un fichier PDF et ne convertit pas le balisage HTML en contenu de diapositive. Voir [Import Presentations from PDF or HTML](/slides/fr/net/import-presentation/).

## **Enregistrement et rendu**

- **Enregistrement** : [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) écrit la présentation au format indiqué par une valeur [SaveFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/). Les surcharges qui prennent également un objet d’options contrôlent la sortie, par exemple [PdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/fr/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/), et [GifOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/gifoptions/). Les surcharges qui acceptent un tableau de positions de diapositives, à partir de 1, n’écrivent que ces diapositives ; elles acceptent PDF, XPS, TIFF, HTML, HTML5, SWF, GIF et Markdown, mais pas les formats de présentation ni le PowerPoint XML. XAML possède sa propre surcharge qui accepte [IXamlOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export.xaml/ixamloptions/). Voir [Save Presentations](/slides/fr/net/save-presentation/), [Convert Presentations](/slides/fr/net/convert-presentation/), et [Export Presentations to XAML](/slides/fr/net/export-to-xaml/).
- **Rendu** : [Slide.GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/slide/getimage/) et [Shape.GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/getimage/) renvoient un [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/), et [IImage.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/save/) l’enregistre en PNG, JPEG, BMP, GIF ou TIFF, sélectionné avec une valeur [ImageFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/imageformat/). [Presentation.GetImages](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/getimages/) rend toutes les diapositives ou les diapositives sélectionnées en une seule fois. [Slide.WriteAsSvg](https://reference.aspose.com/slides/fr/net/aspose.slides/slide/writeassvg/) et [Shape.WriteAsSvg](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/writeassvg/) écrivent du SVG, et [Slide.WriteAsEmf](https://reference.aspose.com/slides/fr/net/aspose.slides/slide/writeasemf/) écrit du EMF. Voir [Convert Presentation Slides to Images](/slides/fr/net/convert-slide/) et [Render a Slide as an SVG Image](/slides/fr/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat possède également les valeurs `Emf`, `Wmf`, `Icon`, `Exif` et `MemoryBmp`, mais IImage.Save ne produit pas ces formats : le fichier qu’il écrit contient des données PNG. Pour obtenir une image EMF d’une diapositive, utilisez Slide.WriteAsEmf.

{{% /alert %}}

## **FAQ**

**Puis‑je convertir une présentation PPT en PPTX ou ODP ?**

Oui. Ouvrez le fichier PPT avec le constructeur Presentation et enregistrez‑le avec `SaveFormat.Pptx` ou `SaveFormat.Odp`. Voir [Convert PPT to PPTX](/slides/fr/net/convert-ppt-to-pptx/).

**Puis‑je ouvrir un fichier PDF ou HTML comme une présentation ?**

Non. Créez ou ouvrez une présentation, importez les pages PDF ou le contenu HTML à l’aide des méthodes de collection de diapositives décrites ci‑dessus, puis enregistrez‑la dans n’importe quel format pris en charge.

**Puis‑je charger une image PNG ou SVG exportée comme présentation modifiable ?**

Non. La sortie d’image enregistre l’apparence d’une diapositive, pas son texte, ses formes ou ses graphiques. Conservez la présentation source si vous devez la modifier ultérieurement.

**Puis‑je enregistrer des documents PDF/A ou PDF/UA ?**

Oui. Définissez [PdfOptions.Compliance](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/compliance/) sur une valeur [PdfCompliance](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfcompliance/) : PDF/A‑1a, PDF/A‑1b, PDF/A‑2a, PDF/A‑2b, PDF/A‑2u, PDF/A‑3a, PDF/A‑3b ou PDF/UA.

**Puis‑je vérifier si un fichier est protégé par mot de passe avant de l’ouvrir ?**

Oui. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/presentationfactory/getpresentationinfo/) examine un fichier sans créer d’objet Presentation, et sa propriété [IsPasswordProtected](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/ispasswordprotected/) indique si un mot de passe est requis. Voir [Password‑Protect Presentations](/slides/fr/net/password-protected-presentation/).

**Les deux packages NuGet prennent‑ils en charge des formats différents ?**

Non. Aspose.Slides.NET et Aspose.Slides.NET6.CrossPlatform possèdent les mêmes valeurs LoadFormat et SaveFormat ainsi que les mêmes méthodes d’importation et de rendu. Ils diffèrent par les plateformes sur lesquelles ils s’exécutent et les exigences de ces plateformes ; voir [Installation](/slides/fr/net/installation/).