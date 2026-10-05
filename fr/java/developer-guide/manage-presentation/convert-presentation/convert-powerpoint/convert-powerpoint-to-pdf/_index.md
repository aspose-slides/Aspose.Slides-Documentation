---
title: Convertir PPT et PPTX en PDF avec Java [Fonctionnalités avancées incluses]
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
  - enregistrer PowerPoint en PDF
  - enregistrer PPT en PDF
  - enregistrer PPTX en PDF
  - exporter PPT en PDF
  - exporter PPTX en PDF
  - pièce jointe
  - PDF/A1a
  - PDF/A1b
  - PDF/UA
  - Java
  - Aspose.Slides
description: "Convertir des fichiers PowerPoint PPT/PPTX en PDF de haute qualité et recherchables en Java avec Aspose.Slides, avec des exemples de code rapides et des options de conversion avancées."
---
## **Aperçu**

Convertir des présentations PowerPoint (PPT, PPTX, ODP, etc.) en format PDF avec Java offre plusieurs avantages, notamment la compatibilité entre différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint en PDF**

Avec Aspose.Slides, vous pouvez convertir les présentations dans les formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, transmettez le nom du fichier en argument à la classe [Présentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) puis enregistrez la présentation au format PDF à l’aide de la méthode [enregistrer](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). La classe [Présentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) expose la méthode [enregistrer](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) qui est généralement utilisée pour convertir une présentation en PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Java insère ses informations d’API et le numéro de version dans les documents de sortie. Par exemple, lors de la conversion d’une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur sous la forme "*Aspose.Slides v XX.XX*". **Remarque** : vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents de sortie.

{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des présentations entières en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations en PDF, en veillant à ce que les PDF résultants correspondent étroitement aux présentations d’origine. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Formatage du texte
* Formatage des paragraphes
* Hyperliens
* En-têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus standard de conversion PowerPoint‑vers‑PDF utilise les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant des paramètres optimaux aux niveaux de qualité maximale.

L’exemple suivant charge une présentation et enregistre toutes les diapositives visibles en PDF en utilisant les paramètres d’exportation par défaut.

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

Aspose propose un [**convertisseur PowerPoint en PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) en ligne gratuit qui montre le processus de conversion présentation‑vers‑PDF. Vous pouvez effectuer un test avec ce convertisseur pour une implémentation en direct de la procédure décrite ici.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisées — des propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) — qui vous permettent de personnaliser le PDF résultant, de verrouiller le PDF avec un mot de passe ou de spécifier le déroulement du processus de conversion.

### **Convertir PowerPoint en PDF avec Options Personnalisées**

À l’aide d’options de conversion personnalisées, vous pouvez définir votre paramètre de qualité préféré pour les images raster, préciser comment les métafichiers doivent être traités, définir un niveau de compression pour le texte, configurer le DPI des images, etc.

L’exemple suivant exporte une présentation en PDF 1.5 avec une qualité JPEG de 90, une résolution d’image de 300 DPI, les métafichiers enregistrés en PNG et une compression de texte Flate.

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

### **Conserver les fichiers OLE intégrés en tant que pièces jointes PDF**

Si une présentation contient un classeur Excel intégré, vous pouvez souhaiter que les destinataires du PDF accèdent aux données du classeur ainsi qu’aux diapositives. Appelez [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) avec `true` pour conserver les fichiers OLE intégrés en tant que pièces jointes dans le PDF résultant.

La valeur par défaut est `false` : l’image d’aperçu ou l’icône de l’objet OLE est rendue sur la page PDF, mais son fichier intégré n’est pas inclus en tant que pièce jointe. Mettre l’option à `true` ajoute également les données du fichier. L’aperçu reste une représentation visuelle ; la pièce jointe permet aux destinataires d’ouvrir ou d’enregistrer le fichier intégré séparément. L’objet OLE ne devient pas une feuille de calcul Excel interactive sur la page PDF.

L’exemple suivant charge une présentation contenant déjà un classeur Excel intégré et l’exporte en PDF avec le classeur attaché.

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

1. Ouvrez le PDF exporté dans un lecteur qui prend en charge les pièces jointes, tel qu’Adobe Acrobat Reader.
2. Ouvrez le panneau **Attachments** du lecteur et localisez le classeur intégré.
3. Enregistrez la pièce jointe et ouvrez‑la dans Excel pour examiner ses données, ou ouvrez‑la directement si le lecteur le permet. L’aperçu sur la page PDF est séparé de la pièce jointe.

{{% alert color="info" title="Note" %}}

Les normes PDF/A imposent des restrictions sur les pièces jointes : PDF/A‑1 interdit les fichiers intégrés, PDF/A‑2 n’autorise que les pièces jointes PDF/A, et PDF/A‑3 autorise d’autres types de fichiers, y compris les classeurs Excel. Ce sont des exigences des normes, pas des restrictions spécifiques à Aspose.Slides. Cet exemple utilise le paramètre de conformité PDF par défaut et ne montre pas l’exportation PDF/A.

{{% /alert %}}

### **Convertir PowerPoint en PDF avec Diapositives Masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) de la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) pour inclure les diapositives masquées en tant que pages dans le PDF résultant.

L’exemple suivant exporte une présentation en PDF, en incluant les diapositives masquées.

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

L’exemple suivant exporte une présentation en PDF qui nécessite le mot de passe `password` pour être ouvert. Les autorisations d’accès permettent l’impression, y compris l’impression de haute qualité.

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

Aspose.Slides fournit la méthode [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) sous la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), vous permettant de détecter les substitutions de polices pendant le processus de conversion présentation‑vers‑PDF.

L’exemple suivant exporte une présentation en PDF et affiche les avertissements de substitution de police dans la console. Un avertissement est affiché uniquement lorsqu’une police indisponible est substituée lors de l’exportation.

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

Pour plus d’informations sur les substitutions de polices, consultez l’article [Substitution de Polices](/slides/fr/java/font-substitution/).

{{% /alert %}} 

## **Convertir des Diapositives Sélectionnées de PowerPoint en PDF**

L’exemple suivant exporte les diapositives 1 et 3 d’une présentation en PDF. Les numéros de diapositive dans ce tableau sont indexés à partir de 1, et la présentation d’entrée doit contenir au moins trois diapositives.

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

L’exemple suivant copie la première diapositive d’une présentation dans une nouvelle présentation avec une taille de diapositive de 612 × 792 points (8,5 × 11 pouces). Il met à l’échelle le contenu de la diapositive pour l’ajuster et exporte la diapositive unique en PDF.

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

L’exemple suivant exporte une présentation en PDF, plaçant les notes du présentateur de chaque diapositive sous la diapositive. Utilisez une présentation contenant des notes du présentateur pour voir le résultat.

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

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en utilisant l’une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code montre un processus de conversion PowerPoint‑vers‑PDF qui produit plusieurs PDF selon différentes normes de conformité :

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

Aspose.Slides supporte les opérations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats de fichiers populaires. Vous pouvez effectuer des conversions [PDF vers HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF vers image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF vers JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) et [PDF vers PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). D’autres opérations de conversion PDF vers des formats spécialisés — [PDF vers SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF vers TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), et [PDF vers XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — sont également prises en charge.

{{% /alert %}}

> **Remarque** : lors de l’exportation vers PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, les graphiques et les formules comme une seule figure. Les éléments de chemin individuels ne sont pas conservés comme contenu séparé et peuvent être marqués comme artefacts ; le texte alternatif est fourni uniquement pour la figure entière.

## **FAQ**

**Puis‑je convertir plusieurs fichiers PowerPoint en PDF en lot ?**

Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion par programme.

**Est‑il possible de protéger le PDF converti par mot de passe ?**

Oui. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) pour définir un mot de passe et spécifier les autorisations d’accès pendant le processus de conversion.

**Comment inclure les diapositives masquées dans le PDF ?**

Appelez [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) avec `true` dans la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) pour inclure les diapositives masquées dans le PDF résultant.

**Aspose.Slides peut‑il maintenir une haute qualité d’image dans le PDF ?**

Oui, vous pouvez contrôler la qualité des images en utilisant des méthodes telles que [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) et [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) dans la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) pour garantir des images de haute qualité dans votre PDF.

**Aspose.Slides prend‑il en charge les normes de conformité PDF/A ?**

Oui, Aspose.Slides vous permet d’exporter des PDF conformes aux [différentes normes](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), notamment PDF/A1a, PDF/A1b et PDF/UA, assurant que vos documents répondent aux exigences d’accessibilité et d’archivage.

## **Ressources supplémentaires**

- [Documentation Aspose.Slides pour Java](/slides/fr/java/)
- [Référence API Aspose.Slides pour Java](https://reference.aspose.com/slides/java/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/conversion)