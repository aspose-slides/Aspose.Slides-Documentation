---
title: Convertir PPT et PPTX en PDF en PHP [Fonctionnalités avancées incluses]
linktitle: PowerPoint vers PDF
type: docs
weight: 40
url: /fr/php-java/convert-powerpoint-to-pdf/
keywords:
- convertir PowerPoint
- convertir présentation
- PowerPoint vers PDF
- présentation vers PDF
- PPT vers PDF
- convertir PPT en PDF
- PPTX vers PDF
- convertir PPTX en PDF
- enregistrer PowerPoint en PDF
- enregistrer PPT en PDF
- enregistrer PPTX en PDF
- exporter PPT en PDF
- exporter PPTX en PDF
- pièce jointe
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Convertir PowerPoint PPT/PPTX en PDF de haute qualité et interrogeables en PHP avec Aspose.Slides, avec des exemples de code rapides et des options de conversion avancées."
---
## **Aperçu**

Convertir des présentations PowerPoint (PPT, PPTX, ODP, etc.) au format PDF en PHP offre plusieurs avantages, notamment la compatibilité avec différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint vers PDF**

À l’aide d’Aspose.Slides, vous pouvez convertir des présentations dans les formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, transmettez le nom du fichier en argument à la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) puis enregistrez la présentation au format PDF à l’aide d’une méthode [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). La classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) expose la méthode [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) qui est généralement utilisée pour convertir une présentation en PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java insère les informations de son API et le numéro de version dans les documents générés. Par exemple, lors de la conversion d’une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur sous la forme "*Aspose.Slides v XX.XX*". **Note** que vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents générés.
{{% /alert %}}

Aspose.Slides permet de convertir :

* Des présentations complètes en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations vers PDF, en veillant à ce que les PDF résultants correspondent étroitement aux présentations originales. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Hyperliens
* En‑têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus de conversion standard PowerPoint‑vers‑PDF utilise les options par défaut. Dans ce cas, Aspose.Slides essaie de convertir la présentation fournie en PDF en utilisant des paramètres optimaux aux niveaux de qualité maximale.

L’exemple suivant charge une présentation et enregistre toutes les diapositives visibles en PDF à l’aide des paramètres d’exportation par défaut.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose propose un **convertisseur PowerPoint en PDF** en ligne gratuit : [PowerPoint to PDF converter](https://products.aspose.app/slides/conversion/ppt-to-pdf) qui démontre le processus de conversion présentation‑vers‑PDF. Vous pouvez tester ce convertisseur pour une implémentation en direct de la procédure décrite ici.
{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisées—des propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—qui vous permettent de personnaliser le PDF résultant, de verrouiller le PDF avec un mot de passe ou de spécifier comment le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec Options Personnalisées**

À l’aide d’options de conversion personnalisées, vous pouvez définir le paramètre de qualité préféré pour les images raster, spécifier le mode de traitement des méta‑fichiers, définir un niveau de compression du texte, configurer le DPI des images, et plus encore.

L’exemple suivant exporte une présentation en PDF 1.5 avec une qualité JPEG réglée à 90, une résolution d’image de 300 DPI, les méta‑fichiers sauvegardés en PNG et une compression de texte Flate.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Sélection Automatique de la Compression d'Image**

Lorsque une présentation contient de nombreuses photographies ou captures d’écran, réduire la taille du PDF exporté peut faciliter l’envoi par courriel ou le téléchargement. Appelez [PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) avec `true` pour sélectionner automatiquement l’algorithme de compression le plus approprié pour chaque image lors de l’exportation PDF.

L’exemple suivant charge une présentation existante, active la sélection automatique de la compression d’image, puis l’enregistre sous forme de document PDF. Tous les autres paramètres d’exportation PDF conservent leurs valeurs par défaut.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Cette option sélectionne un algorithme de compression pour chaque image. Réduire la valeur passée à [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) diminue la qualité JPEG, tandis que réduire la valeur passée à [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) permet de sous‑échantillonner les images à une résolution plus basse, ce qui peut réduire les détails. L’activation de la sélection automatique de la compression n’abaisse pas elle‑même ces réglages.

La sélection d’algorithmes de compression d’image nécessite davantage de temps de traitement et de mémoire. La réduction de taille dépend des images de la présentation et des paramètres d’exportation ; une réduction fixe n’est pas garantie pour chaque présentation.

### **Conserver les Fichiers OLE Intégrés comme Pièces Jointes PDF**

Si une présentation contient un classeur Excel intégré, vous pouvez souhaiter que les destinataires du PDF accèdent aux données du classeur ainsi qu’aux diapositives. Appelez [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) avec `true` pour préserver les fichiers OLE intégrés en tant que pièces jointes dans le PDF résultant.

La valeur par défaut est `false` : l’image d’aperçu ou l’icône de l’objet OLE est rendue sur la page PDF, mais son fichier intégré n’est pas inclus comme pièce jointe. Passer l’option à `true` ajoute également les données du fichier. L’aperçu reste une représentation visuelle ; la pièce jointe permet aux destinataires d’ouvrir ou d’enregistrer le fichier intégré séparément. L’objet OLE ne devient pas une feuille de calcul Excel interactive sur la page PDF.

L’exemple suivant charge une présentation contenant déjà un classeur Excel intégré et l’exporte en PDF avec le classeur joint.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Pour vérifier le résultat :

1. Ouvrez le PDF exporté dans un visualiseur qui prend en charge les pièces jointes, tel qu'Adobe Acrobat Reader.
2. Ouvrez le panneau **Attachments** du visualiseur et localisez le classeur intégré.
3. Enregistrez la pièce jointe et ouvrez‑la dans Excel pour inspecter ses données, ou ouvrez‑la directement si le visualiseur le permet. L'aperçu sur la page PDF est séparé de la pièce jointe.

{{% alert color="info" title="Note" %}}
Les normes PDF/A imposent des restrictions sur les pièces jointes : PDF/A‑1 interdit les fichiers intégrés, PDF/A‑2 n’autorise que les pièces jointes PDF/A, et PDF/A‑3 autorise d’autres types de fichiers, y compris les classeurs Excel. Il s’agit d’exigences des normes, et non de restrictions propres à Aspose.Slides. Cet exemple utilise le paramètre de conformité PDF par défaut et ne montre pas l’exportation PDF/A.
{{% /alert %}}

### **Convertir PowerPoint en PDF avec Diapositives Masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) de la classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) pour inclure les diapositives masquées comme pages dans le PDF résultant.

L’exemple suivant exporte une présentation en PDF, en incluant les éventuelles diapositives masquées.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Convertir PowerPoint en PDF protégé par mot de passe**

L’exemple suivant exporte une présentation en PDF qui nécessite le mot de passe `password` pour être ouvert. Les autorisations d’accès permettent l’impression, y compris l’impression haute qualité.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Détecter les Substitutions de Polices**

Aspose.Slides fournit la méthode [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) de la classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) qui vous permet de détecter les substitutions de polices pendant le processus de conversion présentation‑vers‑PDF.

L’exemple suivant exporte une présentation en PDF et imprime les avertissements de substitution de polices dans la console. Un avertissement n’est affiché que lorsqu’une police indisponible est substituée lors de l’exportation.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Pour plus d'informations sur la substitution de polices, consultez l'article [Font Substitution](/slides/fr/php-java/font-substitution/).
{{% /alert %}} 

### **Gérer les Polices Sans Variante Gras Dédiée**

Une présentation peut appliquer le format gras à du texte même si la police ne possède pas de variante gras dédiée. Le texte peut apparaître gras grâce à un gras synthétique, qui épaissit artificiellement les glyphes normaux. Lorsque ce texte apparaît trop lourd ou diffère de l’apparence attendue dans le PDF, essayez d’appeler [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) avec `true`. Cette option rend le texte concerné sous forme de bitmap lors de l’exportation PDF et peut améliorer son aspect pour certaines polices. Sa valeur par défaut est `false`.

La présentation d’exemple contient deux zones de texte : une avec du texte normal et une avec du texte gras appliqué à la même police, qui ne possède pas de variante gras dédiée. L’exemple suivant charge la présentation, active la rasterisation des styles de police non pris en charge, et l’exporte en PDF :

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Les aperçus suivants montrent le résultat désactivé et le résultat activé. Dans cet exemple, le texte gras possède des traits plus épais avec l’option désactivée. Avec l’option activée, ses traits sont plus fins ; le texte normal reste inchangé. Comparez les résultats avant de choisir le paramètre pour votre présentation.

| Option désactivée (`false`, la valeur par défaut) | Option activée (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Dans cet exemple, l’activation de l’option ne transforme que le texte gras en bitmap : il ne peut pas être sélectionné, copié ou recherché comme texte sans OCR, et ses contours apparaissent plus doux à 800 % de zoom. Le texte normal reste recherchable. Avec l’option désactivée, les deux chaînes restent du texte.

Cette option rasterise le texte mis en gras lorsque la police ne possède pas de variante gras dédiée. La [Font substitution](/slides/fr/php-java/font-substitution/) sélectionne plutôt une autre police lorsque l’originale est indisponible.

## **Convertir des Diapositives Sélectionnées de PowerPoint en PDF**

L’exemple suivant exporte les diapositives 1 et 3 d’une présentation en PDF. Les numéros de diapositive dans ce tableau sont basés sur 1, et la présentation d’entrée doit contenir au moins trois diapositives.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Convertir PowerPoint en PDF avec Taille de Diapositive Personnalisée**

L’exemple suivant copie la première diapositive d’une présentation dans une nouvelle présentation dont la taille de diapositive est de 612 × 792 points (8,5 × 11 pouces). Il redimensionne le contenu de la diapositive pour l’ajuster et exporte la diapositive unique en PDF.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // Supprimer la diapositive vide avec laquelle la nouvelle présentation a été créée.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Convertir PowerPoint en PDF en Vue Notes de Diapositive**

L’exemple suivant exporte une présentation en PDF, en plaçant les notes du présentateur de chaque diapositive sous la diapositive. Utilisez une présentation contenant des notes du présentateur pour voir le résultat.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Normes d'Accessibilité et de Conformité pour le PDF**

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint vers PDF en utilisant l’une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides prend en charge les opérations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats de fichiers populaires. Vous pouvez effectuer des conversions [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), et [PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). D’autres opérations de conversion PDF vers des formats spécialisés—[PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), et [PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—sont également prises en charge.
{{% /alert %}}

> **Note :** Lors de l’exportation vers PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, les graphiques et les formules comme une figure unique. Les éléments de chemin individuels ne sont pas conservés comme contenu séparé et peuvent être marqués comme artefacts ; le texte alternatif n’est fourni que pour la figure entière.

## **FAQ**

**Puis-je convertir plusieurs fichiers PowerPoint en PDF en masse ?**  
Oui, Aspose.Slides prend en charge la conversion par lot de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion programmatiquement.

**Est-il possible de protéger le PDF converti par mot de passe ?**  
Oui. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) pour définir un mot de passe et spécifier les autorisations d’accès lors du processus de conversion.

**Comment inclure les diapositives masquées dans le PDF ?**  
Appelez [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) avec `true` dans la classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) pour inclure les diapositives masquées dans le PDF résultant.

**Aspose.Slides peut-il maintenir une haute qualité d'image dans le PDF ?**  
Oui, vous pouvez contrôler la qualité d’image en utilisant des méthodes telles que [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) et [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) dans la classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) pour garantir des images haute qualité dans votre PDF.

**Aspose.Slides prend-il en charge les normes de conformité PDF/A ?**  
Oui, Aspose.Slides vous permet d’exporter des PDF conformes à [diverses normes](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), y compris PDF/A1a, PDF/A1b et PDF/UA, assurant que vos documents répondent aux exigences d’accessibilité et d’archivage.

## **Ressources supplémentaires**

- [Documentation Aspose.Slides pour PHP via Java](/slides/fr/php-java/)
- [Référence API Aspose.Slides pour PHP via Java](https://reference.aspose.com/slides/php-java/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/conversion)