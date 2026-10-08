---
title: Convertir PPT et PPTX en PDF sur Android [Fonctionnalités avancées incluses]
linktitle: PowerPoint en PDF
type: docs
weight: 40
url: /fr/androidjava/convert-powerpoint-to-pdf/
keywords:
- convertir PowerPoint
- convertir présentation
- PowerPoint en PDF
- présentation en PDF
- PPT en PDF
- convertir PPT en PDF
- PPTX en PDF
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
- Android
- Java
- Aspose.Slides
description: "Convertissez les fichiers PowerPoint PPT/PPTX en PDF de haute qualité et recherchables en Java avec Aspose.Slides pour Android, en utilisant des exemples de code rapides et des options de conversion avancées."
---
## **Vue d'ensemble**

La conversion de présentations PowerPoint (PPT, PPTX, ODP, etc.) en format PDF sur Android offre plusieurs avantages, notamment la compatibilité entre différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de police, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents générés.

## **Conversions PowerPoint vers PDF**

À l'aide d'Aspose.Slides, vous pouvez convertir des présentations dans les formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, transmettez le nom du fichier en argument à la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et enregistrez ensuite la présentation au format PDF à l'aide de la méthode [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). La classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) expose la méthode [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) qui est généralement utilisée pour convertir une présentation en PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java insère les informations de son API ainsi que le numéro de version dans les documents générés. Par exemple, lors de la conversion d'une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur du type "*Aspose.Slides v XX.XX*". **Remarque** que vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents générés.
{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des présentations entières en PDF
* Des diapositives spécifiques d'une présentation en PDF

Aspose.Slides exporte les présentations au format PDF, garantissant que les PDF résultants correspondent étroitement aux présentations d'origine. Les éléments et les attributs sont rendus avec précision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Hyperliens
* En-têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

La conversion standard de PowerPoint en PDF utilise les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant des paramètres optimaux aux niveaux de qualité maximale.

L'exemple suivant charge une présentation et enregistre toutes les diapositives visibles en PDF en utilisant les paramètres d'exportation par défaut.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose propose un [**convertisseur PowerPoint en PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratuit en ligne qui montre le processus de conversion de présentation en PDF. Vous pouvez effectuer un test avec ce convertisseur pour une mise en œuvre en direct de la procédure décrite ici.
{{% /alert %}}

## **Convertir PowerPoint en PDF avec options**

Aspose.Slides fournit des options personnalisées — des propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) — qui vous permettent de personnaliser le PDF généré, de verrouiller le PDF avec un mot de passe ou de spécifier comment le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec options personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre réglage de qualité préféré pour les images raster, spécifier comment les métafichiers doivent être traités, définir un niveau de compression pour le texte, configurer le DPI pour les images, etc.

L'exemple suivant exporte une présentation au format PDF 1.5 avec une qualité JPEG réglée à 90, une résolution d'image de 300 DPI, les métafichiers enregistrés au format PNG et une compression de texte Flate.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Conserver les fichiers OLE incorporés comme pièces jointes PDF**

Si une présentation contient un classeur Excel incorporé, vous pouvez vouloir que les destinataires du PDF accèdent aux données du classeur ainsi qu'aux diapositives. Appelez [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) avec `true` pour conserver les fichiers OLE incorporés comme pièces jointes dans le PDF résultant.

La valeur par défaut est `false` : l'image d'aperçu ou l'icône de l'objet OLE est rendue sur la page PDF, mais son fichier incorporé n'est pas inclus comme pièce jointe. Définir l'option sur `true` ajoute également les données du fichier. L'aperçu reste une représentation visuelle ; la pièce jointe permet aux destinataires d'ouvrir ou d'enregistrer le fichier incorporé séparément. L'objet OLE ne devient pas une feuille de calcul Excel interactive sur la page PDF.

L'exemple suivant charge une présentation contenant déjà un classeur Excel incorporé et l'exporte en PDF avec le classeur joint.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Pour vérifier le résultat :

1. Ouvrez le PDF exporté dans un lecteur prenant en charge les pièces jointes, tel qu'Adobe Acrobat Reader.
2. Ouvrez le panneau **Pièces jointes** du lecteur et localisez le classeur incorporé.
3. Enregistrez la pièce jointe et ouvrez‑la dans Excel pour inspecter ses données, ou ouvrez‑la directement si le lecteur le permet. L'aperçu sur la page PDF est séparé de la pièce jointe.

{{% alert color="info" title="Note" %}}
Les normes PDF/A imposent des restrictions sur les pièces jointes : PDF/A-1 interdit les fichiers incorporés, PDF/A-2 ne permet que les pièces jointes PDF/A, et PDF/A-3 autorise d’autres types de fichiers, y compris les classeurs Excel. Il s'agit d'exigences des normes, et non de restrictions propres à Aspose.Slides. Cet exemple utilise le paramètre de conformité PDF par défaut et ne montre pas d'exportation PDF/A.
{{% /alert %}}

### **Convertir PowerPoint en PDF avec diapositives masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) de la classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) pour inclure les diapositives masquées en tant que pages dans le PDF résultant.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convertir PowerPoint en PDF protégé par mot de passe**

L'exemple suivant exporte une présentation en PDF nécessitant le mot de passe `password` pour être ouvert. Les autorisations d'accès permettent l'impression, y compris l'impression de haute qualité.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Détecter les substitutions de police**

Aspose.Slides fournit la méthode [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) de la classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) vous permettant de détecter les substitutions de police pendant le processus de conversion de présentation en PDF.

L'exemple suivant exporte une présentation en PDF et affiche les avertissements de substitution de police dans la console. Un avertissement n'est affiché que lorsqu'une police indisponible est substituée lors de l'exportation.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Pour plus d'informations sur la substitution de police, consultez l'article [Substitution de police](/slides/fr/androidjava/font-substitution/).
{{% /alert %}} 

### **Gérer les polices sans variante gras dédiée**

Une présentation peut appliquer le format gras à du texte même si la police ne possède pas de variante gras dédiée. Le texte peut néanmoins apparaître en gras grâce au faux gras, qui épaissit artificiellement les glyphes normaux. Lorsque ce texte semble trop lourd ou diffère de l'apparence souhaitée dans le PDF, essayez d'appeler [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) avec `true`. Cette option rend le texte concerné sous forme de bitmap lors de l'exportation PDF et peut améliorer son apparence pour certaines polices. Sa valeur par défaut est `false`.

La présentation d'exemple contient deux zones de texte : une avec du texte normal et une avec le format gras appliqué à la même police, qui n'a pas de variante gras dédiée. L'exemple suivant charge la présentation, active la rasterisation des styles de police non pris en charge, et l'exporte en PDF :

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Les aperçus suivants montrent la sortie désactivée et la sortie activée. Dans cet exemple, le texte en gras a des traits plus épais lorsque l'option est désactivée. Lorsque l'option est activée, ses traits sont plus fins ; le texte normal reste inchangé. Comparez les résultats avant de choisir le paramètre pour votre présentation.

| Option désactivée (`false`, la valeur par défaut) | Option activée (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Dans cet exemple, l'activation de l'option transforme uniquement le texte en gras en bitmap : il ne peut pas être sélectionné, copié ou recherché comme texte sans OCR, et ses bords apparaissent plus doux à 800 % de zoom. Le texte normal reste recherchable. Avec l'option désactivée, les deux chaînes restent du texte.

Cette option rasterise le texte formaté en gras lorsque la police ne possède pas de variante gras dédiée. La [substitution de police](/slides/fr/androidjava/font-substitution/) sélectionne plutôt une autre police lorsque l'originale n'est pas disponible.

## **Convertir des diapositives sélectionnées de PowerPoint en PDF**

L'exemple suivant exporte les diapositives 1 et 3 d'une présentation en PDF. Les numéros de diapositive dans ce tableau sont indexés à partir de 1, et la présentation source doit contenir au moins trois diapositives.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Convertir PowerPoint en PDF avec taille de diapositive personnalisée**

L'exemple suivant copie la première diapositive d'une présentation dans une nouvelle présentation avec une taille de diapositive de 612 × 792 points (8,5 × 11 pouces). Il met à l'échelle le contenu de la diapositive pour l'adapter et exporte la diapositive unique en PDF.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Supprimer la diapositive vide avec laquelle la nouvelle présentation a été créée.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Convertir PowerPoint en PDF avec vue des notes de diapositive**

L'exemple suivant exporte une présentation en PDF, plaçant les notes du présentateur de chaque diapositive sous la diapositive. Utilisez une présentation contenant des notes de présentateur pour voir le résultat.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Normes d'accessibilité et de conformité pour le PDF**

Aspose.Slides vous permet d'utiliser une procédure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en utilisant l'une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code montre un processus de conversion PowerPoint en PDF qui génère plusieurs PDFs selon différentes normes de conformité :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides prend en charge les opérations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats de fichier populaires. Vous pouvez effectuer des conversions [PDF vers HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF vers image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF vers JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), et [PDF vers PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). D'autres opérations de conversion PDF vers des formats spécialisés — [PDF vers SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF vers TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), et [PDF vers XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — sont également prises en charge.
{{% /alert %}}

> **Remarque** : lors de l'exportation vers PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, les graphiques et les formules comme une seule figure. Les éléments de chemin individuels ne sont pas conservés comme contenu séparé et peuvent être marqués comme artefacts ; le texte alternatif est fourni uniquement pour la figure entière.

## **FAQ**

**Puis‑je convertir plusieurs fichiers PowerPoint en PDF en masse ?**

Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion de manière programmatique.

**Est‑il possible de protéger le PDF converti par un mot de passe ?**

Oui. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) pour définir un mot de passe et spécifier les autorisations d'accès pendant le processus de conversion.

**Comment inclure les diapositives masquées dans le PDF ?**

Appelez [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) avec `true` dans la classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) pour inclure les diapositives masquées dans le PDF résultant.

**Aspose.Slides peut‑il conserver une haute qualité d'image dans le PDF ?**

Oui, vous pouvez contrôler la qualité des images en utilisant des méthodes telles que [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) et [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) dans la classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) afin d'assurer des images de haute qualité dans votre PDF.

**Aspose.Slides prend‑il en charge les normes de conformité PDF/A ?**

Oui, Aspose.Slides vous permet d'exporter des PDFs conformes à [diverses normes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), notamment PDF/A1a, PDF/A1b et PDF/UA, garantissant que vos documents répondent aux exigences d'accessibilité et d'archivage.

## **Ressources supplémentaires**

- [Documentation Aspose.Slides pour Android via Java](/slides/fr/androidjava/)
- [Référence API Aspose.Slides pour Android via Java](https://reference.aspose.com/slides/androidjava/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/conversion)