---
title: Convertir PPT et PPTX en PDF avec Python | Options avancées
linktitle: PowerPoint en PDF
type: docs
weight: 40
url: /fr/python-net/convert-powerpoint-to-pdf/
keywords:
- convertir PowerPoint
- présentation
- PowerPoint en PDF
- PPT en PDF
- PPTX en PDF
- enregistrer PowerPoint en PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Guide étape par étape pour convertir PPT, PPTX et ODP en PDF de haute qualité conformes aux WCAG avec Python et Aspose.Slides — inclut la protection par mot de passe, la sélection de diapositives et le contrôle de la qualité des images."
showReadingTime: true
---
## **Aperçu**

Convertir des présentations PowerPoint (PPT, PPTX, ODP) en format PDF avec Python offre plusieurs avantages, notamment la garantie de compatibilité sur différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les PDF par mot de passe, détecter les substitutions de police, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint vers PDF**

À l’aide d’Aspose.Slides, vous pouvez convertir des présentations de ces formats en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF avec Python, il suffit de passer le nom du fichier en argument de la classe [Presentation](https://docs.aspose.com/slides/fr/python-net/api-reference/aspose.slides/presentation/) puis d’enregistrer la présentation au format PDF en utilisant la méthode [Save](https://docs.aspose.com/slides/fr/python-net/api-reference/aspose.slides/presentation/#methods). La classe [Presentation](https://docs.aspose.com/slides/fr/python-net/api-reference/aspose.slides/presentation/) expose la méthode [Save](https://docs.aspose.com/slides/fr/python-net/api-reference/aspose.slides/presentation/#methods) généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides pour Python inscrit directement les informations d’API et le numéro de version dans les documents de sortie. Par exemple, lorsqu’il convertit une présentation en PDF, Aspose.Slides pour Python remplit le champ Application avec la valeur '*Aspose.Slides*' et le champ PDF Producer avec une valeur sous la forme '*Aspose.Slides v XX.XX*'. **Note** : vous ne pouvez pas demander à Aspose.Slides pour Python de modifier ou de supprimer ces informations des documents de sortie.

{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Présentations entières en PDF
* Diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations en PDF, en veillant à ce que le contenu des PDF résultants corresponde étroitement aux présentations originales. Les éléments et attributs sont rendus avec précision lors de la conversion, y compris :

* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Hyperliens
* En‑têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

L’opération standard de conversion PowerPoint → PDF s’exécute avec les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant des paramètres optimaux aux niveaux de qualité maximale. Ce code Python vous montre comment convertir un PowerPoint en PDF :

_Étapes : conversions PowerPoint en PDF avec Python_

Le code d’exemple suivant explique ces conversions en Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Étapes : convertir PowerPoint en PDF avec Python via .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Étapes : convertir PPT en PDF avec Python via .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Étapes : convertir PPTX en PDF avec Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Étapes : convertir ODP en PDF avec Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Étapes : convertir PPS en PDF avec Python via .NET</strong></a>

_Étapes du code_ :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) et fournissez‑lui le fichier PowerPoint.  
  * extension _.ppt_ pour charger le fichier **PPT** dans la classe _Presentation_.  
  * extension _.pptx_ pour charger le fichier **PPTX** dans la classe _Presentation_.  
  * extension _.odp_ pour charger le fichier **ODP** dans la classe _Presentation_.  
  * extension _.pps_ pour charger le fichier **PPS** dans la classe _Presentation_.  
- Enregistrez la _Presentation_ au format **PDF** en appelant la méthode **Save** et en utilisant l’énumération **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Instancie une classe Presentation qui représente un fichier PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Enregistre la présentation au format PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose propose un [**convertisseur PowerPoint → PDF**](https://products.aspose.app/slides/fr/conversion/ppt-to-pdf) en ligne gratuit qui montre le processus de conversion présentation → PDF. Pour une implémentation en direct de la procédure décrite ici, vous pouvez effectuer un test avec le convertisseur.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec options**

Aspose.Slides fournit des options personnalisées – des propriétés de la classe [PdfOptions](https://docs.aspose.com/slides/fr/python-net/api-reference/aspose.slides.export/pdfoptions/) – qui vous permettent de personnaliser le PDF (résultat du processus de conversion), de verrouiller le PDF par mot de passe ou même de spécifier le déroulement de la conversion.

### **Convertir PowerPoint en PDF avec options personnalisées**

À l’aide d’options de conversion personnalisées, vous pouvez définir votre réglage de qualité préféré pour les images raster, spécifier la gestion des métafichiers, définir un niveau de compression pour les textes, fixer le DPI des images, etc.

L’exemple de code ci‑dessous montre une opération où une présentation PowerPoint est convertie en PDF avec plusieurs options personnalisées :

```python
import aspose.slides as slides

# Instancie la classe PdfOptions
pdf_options = slides.export.PdfOptions()

# Définit la qualité pour les images JPG
pdf_options.jpeg_quality = 90

# Définit le DPI pour les images
pdf_options.sufficient_resolution = 300

# Définit le comportement pour les métafichiers
pdf_options.save_metafiles_as_png = True

# Définit le niveau de compression du texte pour le contenu textuel
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Définit le mode de conformité PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Instancie la classe Presentation qui représente un document PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Enregistre la présentation en tant que document PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Convertir PowerPoint en PDF avec diapositives masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser une option personnalisée – la propriété `show_hidden_slides` de la classe [PdfOptions](https://docs.aspose.com/slides/fr/python-net/api-reference/aspose.slides.export/pdfoptions/) – pour demander à Aspose.Slides d’inclure les diapositives masquées comme pages dans le PDF résultant.

Ce code Python vous montre comment convertir une présentation PowerPoint en PDF avec les diapositives masquées incluses :

```python
import aspose.slides as slides

# Instancie une classe Presentation qui représente un fichier PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Instancie la classe PdfOptions
pdfOptions = slides.export.PdfOptions()

# Ajoute les diapositives masquées
pdfOptions.show_hidden_slides = True

# Enregistre la présentation au format PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Convertir PowerPoint en PDF protégé par mot de passe**

Ce code Python vous montre comment convertir un PowerPoint en PDF protégé par mot de passe (en utilisant les paramètres de protection de la classe [PdfOptions](https://docs.aspose.com/slides/fr/python-net/api-reference/aspose.slides.export/pdfoptions/)) :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Instancie la classe PdfOptions
pdfOptions = slides.export.PdfOptions()

# Définit le mot de passe PDF et les autorisations d'accès
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Enregistre la présentation au format PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Détecter les substitutions de police**

Aspose.Slides fournit la propriété `warning_callback` de la classe [SaveOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveoptions/) pour vous permettre de détecter les substitutions de police lors d’une conversion présentation → PDF.

Ce code Python vous montre comment détecter les substitutions de police :

```python
[TODO[SLIDESPYNET-91]: callbacks are not supported for now]
```

{{%  alert color="primary"  %}} 

Pour plus d’informations sur les substitutions de police, consultez l’article [Font Substitution](https://docs.aspose.com/slides/fr/python-net/font-substitution/).

{{% /alert %}} 

## **Convertir des diapositives sélectionnées d’un PowerPoint en PDF**

Ce code Python vous montre comment convertir des diapositives spécifiques d’une présentation PowerPoint en PDF :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Définit un tableau de positions de diapositives
slides_array = [ 1, 3 ]

# Enregistre la présentation au format PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Convertir PowerPoint en PDF avec taille de diapositive personnalisée**

Ce code Python vous montre comment convertir un PowerPoint dont la taille de diapositive est spécifiée en PDF :

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Instancie la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Crée une nouvelle présentation avec une taille de diapositive ajustée.
    with slides.Presentation() as resized_presentation:

        # Définit la taille de diapositive personnalisée.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Clone la première diapositive de la présentation originale.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Enregistre la présentation redimensionnée au format PDF avec les notes.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Convertir PowerPoint en PDF en mode notes de diapositive**

Ce code Python vous montre comment convertir un PowerPoint en PDF notes :

```python
import aspose.slides as slides

# Instancie une classe Presentation qui représente un fichier PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Enregistre la présentation en notes PDF
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Normes d’accessibilité et de conformité pour les PDF**

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en respectant l’une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code Python montre une opération de conversion PowerPoint → PDF où plusieurs PDF basés sur différentes normes de conformité sont obtenus :

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert title="Note" color="warning" %}} 

Le support d’Aspose.Slides pour les opérations de conversion PDF s’étend à la conversion du PDF vers les formats de fichiers les plus populaires. Vous pouvez réaliser des conversions [PDF en HTML](https://products.aspose.com/slides/fr/python-net/conversion/pdf-to-html/), [PDF en image](https://products.aspose.com/slides/fr/python-net/conversion/pdf-to-image/), [PDF en JPG](https://products.aspose.com/slides/fr/python-net/conversion/pdf-to-jpg/), et [PDF en PNG](https://products.aspose.com/slides/fr/python-net/conversion/pdf-to-png/). D’autres conversions PDF vers des formats spécialisés – [PDF en SVG](https://products.aspose.com/slides/fr/python-net/conversion/pdf-to-svg/), [PDF en TIFF](https://products.aspose.com/slides/fr/python-net/conversion/pdf-to-tiff/), et [PDF en XML](https://products.aspose.com/slides/fr/python-net/conversion/pdf-to-xml/) – sont également prises en charge.

{{% /alert %}}

> **Note :** lors de l’exportation vers PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, les diagrammes et les formules comme une figure unique. Les éléments de chemin individuels ne sont pas conservés comme contenu séparé et peuvent être marqués comme artefacts ; le texte alternatif n’est fourni que pour la figure entière.

## **FAQ**

**Aspose.Slides pour Python peut‑il supprimer les informations d’application du PDF ?**

Non, Aspose.Slides pour Python inclut automatiquement les informations d’API et le numéro de version dans le PDF de sortie. Ces informations ne peuvent pas être modifiées ou supprimées.

**Comment n’inclure que des diapositives spécifiques dans la conversion PDF ?**

Vous pouvez spécifier les indices des diapositives à convertir en transmettant un tableau de positions de diapositives à la méthode `save`.

**Est‑il possible de protéger le PDF par mot de passe lors de la conversion ?**

Oui, vous pouvez définir un mot de passe et spécifier les autorisations d’accès en utilisant la classe `PdfOptions` avant d’enregistrer la présentation au format PDF.

**Aspose.Slides prend‑il en charge la conversion de PDF vers d’autres formats ?**

Oui, Aspose.Slides prend en charge la conversion des PDF vers des formats tels que HTML, les formats d’image (JPG, PNG), SVG, TIFF et XML.

**Comment garantir que mon PDF respecte les normes d’accessibilité ?**

Définissez la propriété `compliance` dans `PdfOptions` sur des normes comme `PDF_A1A`, `PDF_A1B` ou `PDF_UA` pour assurer la conformité aux directives d’accessibilité.

**Puis‑je inclure les diapositives masquées dans le PDF final ?**

Oui, en définissant la propriété `show_hidden_slides` dans `PdfOptions` sur `True`, les diapositives masquées seront incluses dans le PDF.

**Comment ajuster la qualité et la résolution des images lors de la conversion ?**

Utilisez les propriétés `jpeg_quality` et `sufficient_resolution` dans `PdfOptions` pour contrôler la qualité et la résolution des images dans le PDF résultant.

**Aspose.Slides gère‑t‑il automatiquement les substitutions de police ?**

Aspose.Slides détecte les substitutions de police pendant la conversion, et vous pouvez les gérer à l’aide de la propriété `warning_callback` dans `SaveOptions` (actuellement limitée).

## **Ressources supplémentaires**

- [Documentation Aspose.Slides pour .NET](https://docs.aspose.com/slides/fr/python-net/)
- [Référence API Aspose.Slides](https://reference.aspose.com/slides/fr/python-net/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/fr/conversion)