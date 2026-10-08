---
title: Convertir PPT et PPTX en PDF en Java [Fonctionnalités avancées incluses]
linktitle: PowerPoint en PDF
type: docs
weight: 40
url: /fr/java/convert-powerpoint-to-pdf/
keywords:
- convertir PowerPoint
- convertir présentation
- PowerPoint en PDF
- présentation en PDF
- PPT en PDF
- convertir PPT en PDF
- PPTX en PDF
- convertir PPTX en PDF
- enregistrer PowerPoint au format PDF
- enregistrer PPT au format PDF
- enregistrer PPTX au format PDF
- exporter PPT en PDF
- exporter PPTX en PDF
- pièce jointe
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Convertir des présentations PowerPoint PPT/PPTX en PDF de haute qualité et interrogeables en Java avec Aspose.Slides, en fournissant des exemples de code rapides et des options de conversion avancées."
---
## **Vue d'ensemble**

Convertir des présentations PowerPoint (PPT, PPTX, ODP, etc.) au format PDF en Java offre plusieurs avantages, notamment la compatibilité avec différents appareils et la conservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint vers PDF**

Avec Aspose.Slides, vous pouvez convertir des présentations des formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, transmettez le nom du fichier en argument au class [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) puis enregistrez la présentation au format PDF à l’aide de la méthode [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Le class [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) expose la méthode [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) généralement utilisée pour convertir une présentation en PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Java insère ses informations API et son numéro de version dans les documents de sortie. Par exemple, lors de la conversion d’une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur sous la forme "*Aspose.Slides v XX.XX*". **Note** que vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents de sortie.

{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des présentations complètes en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations vers PDF, en veillant à ce que les PDF générés correspondent étroitement aux présentations d’origine. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Hyperliens
* En‑têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus standard de conversion PowerPoint‑to‑PDF utilise les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant des réglages optimaux au niveau de qualité maximal.

L’exemple suivant charge une présentation et enregistre toutes les diapositives visibles au format PDF en utilisant les paramètres d’exportation par défaut.

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

Aspose propose un [**convertisseur PowerPoint vers PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) en ligne gratuit qui démontre le processus de conversion présentation‑to‑PDF. Vous pouvez tester ce convertisseur pour voir une implémentation en direct de la procédure décrite ici.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisées — des propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) — qui vous permettent de personnaliser le PDF résultant, de le verrouiller par mot de passe ou de spécifier comment le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec Options Personnalisées**

À l’aide d’options de conversion personnalisées, vous pouvez définir votre réglage de qualité préféré pour les images raster, spécifier la manière dont les métafichiers doivent être gérés, définir un niveau de compression pour le texte, configurer les DPI pour les images, etc.

L’exemple suivant exporte une présentation vers PDF 1.5 avec une qualité JPEG de 90, une résolution d’image de 300 DPI, les métafichiers enregistrés en PNG et une compression texte Flate.

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

### **Conserver les Fichiers OLE Incorporés comme Pièces Jointes PDF**

Si une présentation contient un classeur Excel incorporé, vous pouvez souhaiter que les destinataires du PDF accèdent aux données du classeur tout en visualisant les diapositives. Appelez [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) avec `true` pour conserver les fichiers OLE incorporés comme pièces jointes dans le PDF résultant.

La valeur par défaut est `false` : l’image d’aperçu ou l’icône de l’objet OLE est rendue sur la page PDF, mais son fichier incorporé n’est pas inclus comme pièce jointe. Passer l’option à `true` ajoute également les données du fichier. L’aperçu reste une représentation visuelle ; la pièce jointe permet aux destinataires d’ouvrir ou d’enregistrer le fichier incorporé séparément. L’objet OLE ne devient pas une feuille Excel interactive sur la page PDF.

L’exemple suivant charge une présentation contenant déjà un classeur Excel incorporé et l’exporte vers PDF avec le classeur joint.

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

1. Ouvrez le PDF exporté dans un lecteur prenant en charge les pièces jointes, tel qu’Adobe Acrobat Reader.
2. Ouvrez le panneau **Attachments** du lecteur et localisez le classeur incorporé.
3. Enregistrez la pièce jointe et ouvrez‑la dans Excel pour inspecter ses données, ou ouvrez‑la directement si le lecteur le permet. L’aperçu sur la page PDF est distinct de la pièce jointe.

{{% alert color="info" title="Note" %}}

Les normes PDF/A imposent des restrictions sur les pièces jointes : PDF/A‑1 interdit les fichiers incorporés, PDF/A‑2 autorise uniquement les pièces jointes PDF/A, et PDF/A‑3 autorise d’autres types de fichiers, y compris les classeurs Excel. Il s’agit d’exigences des normes, pas de restrictions spécifiques à Aspose.Slides. Cet exemple utilise le paramètre de conformité PDF par défaut et ne montre pas d’export PDF/A.

{{% /alert %}}

### **Convertir PowerPoint en PDF avec Diapositives Masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) de la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) pour inclure les diapositives masquées comme pages dans le PDF résultant.

L’exemple suivant exporte une présentation vers PDF, en incluant les diapositives masquées.

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

### **Convertir PowerPoint en PDF Protégé par Mot de Passe**

L’exemple suivant exporte une présentation vers un PDF qui nécessite le mot de passe `password` pour être ouvert. Les autorisations d’accès permettent l’impression, y compris l’impression de haute qualité.

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

### **Détecter les Substitutions de Polices**

Aspose.Slides fournit la méthode [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) de la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), permettant de détecter les substitutions de polices pendant le processus de conversion présentation‑to‑PDF.

L’exemple suivant exporte une présentation vers PDF et affiche les avertissements de substitution de police dans la console. Un avertissement n’est affiché que lorsqu’une police indisponible est substituée lors de l’export.

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

Pour plus d’informations sur la substitution de polices, consultez l’article [Font Substitution](/slides/fr/java/font-substitution/).

{{% /alert %}} 

### **Gérer les Polices Sans Variante Grasse Dédiée**

Une présentation peut appliquer le gras à du texte même si sa police ne possède pas de variante grasse dédiée. Le texte peut alors apparaître en gras grâce au « synthetic bolding », qui épaissit artificiellement les glyphes normaux. Lorsque ce texte paraît trop lourd ou diffère de l’apparence attendue dans le PDF, essayez d’appeler [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) avec `true`. Cette option rend le texte concerné sous forme de bitmap lors de l’export PDF et peut améliorer son apparence pour certaines polices. Sa valeur par défaut est `false`.

La présentation d’exemple contient deux zones de texte : une avec du texte normal et une avec le même texte en gras alors que la police ne possède pas de variante grasse dédiée. L’exemple suivant charge la présentation, active la rasterisation des styles de police non pris en charge et l’exporte vers PDF :

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

Les aperçus suivants montrent la sortie désactivée et la sortie activée. Dans cet exemple, le texte en gras possède des traits plus épais avec l’option désactivée. Avec l’option activée, ses traits sont plus fins ; le texte normal reste inchangé. Comparez les résultats avant de choisir le réglage pour votre présentation.

| Option désactivée (`false`, valeur par défaut) | Option activée (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Dans cet exemple, l’activation de l’option ne transforme en bitmap que le texte en gras : il ne peut pas être sélectionné, copié ou recherché comme texte sans OCR, et ses bords apparaissent plus souples à 800 % de zoom. Le texte normal reste recherchable. Avec l’option désactivée, les deux chaînes restent du texte.

Cette option rasterise le texte mis en gras lorsqu’une police ne possède pas de variante grasse dédiée. La [Font substitution](/slides/fr/java/font-substitution/) sélectionne plutôt une autre police lorsque l’originale est indisponible.

## **Convertir des Diapositives Sélectionnées de PowerPoint en PDF**

L’exemple suivant exporte les diapositives 1 et 3 d’une présentation vers PDF. Les numéros de diapositive dans ce tableau sont basés sur 1, et la présentation d’entrée doit contenir au moins trois diapositives.

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

## **Convertir PowerPoint en PDF avec Taille de Diapositive Personnalisée**

L’exemple suivant copie la première diapositive d’une présentation dans une nouvelle présentation avec une taille de diapositive de 612 × 792 points (8,5 × 11 pouces). Il ajuste le contenu de la diapositive pour l’adapter et exporte la diapositive unique vers PDF.

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

## **Convertir PowerPoint en PDF en Vue des Notes de Diapositive**

L’exemple suivant exporte une présentation vers PDF, plaçant les notes du présentateur de chaque diapositive sous la diapositive. Utilisez une présentation contenant des notes de présentateur pour voir le résultat.

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

## **Accessibilité et Normes de Conformité pour le PDF**

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en appliquant l’une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code démontre un processus de conversion PowerPoint‑to‑PDF qui produit plusieurs PDF selon différentes normes de conformité :

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

Aspose.Slides prend en charge les opérations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats courants. Vous pouvez réaliser des conversions [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) et [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). D’autres conversions PDF vers des formats spécialisés — [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), et [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — sont également prises en charge.

{{% /alert %}}

> **Note :** Lors de l’exportation vers PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, graphiques et formules comme une figure unique. Les éléments de chemin individuels ne sont pas conservés comme contenu séparé et peuvent être marqués comme artefacts ; le texte alternatif est fourni uniquement pour la figure entière.

## **FAQ**

**Puis‑je convertir plusieurs fichiers PowerPoint en PDF en masse ?**

Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion programmatiquement.

**Est‑il possible de protéger le PDF converti par mot de passe ?**

Oui. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) pour définir un mot de passe et définir les permissions d’accès pendant le processus de conversion.

**Comment inclure les diapositives masquées dans le PDF ?**

Appelez [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) avec `true` dans la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) pour inclure les diapositives masquées dans le PDF résultant.

**Aspose.Slides peut‑il maintenir une haute qualité d’image dans le PDF ?**

Oui, vous pouvez contrôler la qualité des images en utilisant des méthodes telles que [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) et [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) dans la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) pour garantir des images haute qualité dans votre PDF.

**Aspose.Slides prend‑il en charge les normes de conformité PDF/A ?**

Oui, Aspose.Slides vous permet d’exporter des PDF conformes aux [various standards](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), y compris PDF/A1a, PDF/A1b et PDF/UA, assurant que vos documents répondent aux exigences d’accessibilité et d’archivage.

## **Ressources supplémentaires**

- [Documentation Aspose.Slides pour Java](/slides/fr/java/)
- [Référence API Aspose.Slides pour Java](https://reference.aspose.com/slides/java/)
- [Convertisseurs En Ligne Gratuits Aspose](https://products.aspose.app/slides/conversion)