---
title: Convertir PPT & PPTX en PDF avec Python | Options avancées
linktitle: PowerPoint en PDF
type: docs
weight: 40
url: /fr/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
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
description: "Guide étape par étape pour convertir PPT, PPTX et ODP en PDF de haute qualité, conformes aux WCAG, avec Aspose.Slides en Python — inclut la protection par mot de passe, la sélection de diapositives et le contrôle de la qualité d'image."
showReadingTime: true
---
## **Vue d'ensemble**

Convertir des présentations PowerPoint (PPT, PPTX, ODP) au format PDF en Python offre plusieurs avantages, notamment garantir la compatibilité sur différents appareils et préserver la mise en page ainsi que le formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les documents PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions de PowerPoint vers PDF**

À l'aide d'Aspose.Slides, vous pouvez convertir des présentations dans ces formats en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF avec Python, il suffit de passer le nom du fichier en argument à la classe [Presentation](https://docs.aspose.com/slides/fr/python-net/api-reference/aspose.slides/presentation/) puis d'enregistrer la présentation au format PDF à l'aide de la méthode [Save](https://docs.aspose.com/slides/fr/python-net/api-reference/aspose.slides/presentation/#methods). La classe [Presentation](https://docs.aspose.com/slides/fr/python-net/api-reference/aspose.slides/presentation/) expose la méthode [Save] qui est généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides pour Python écrit directement les informations d'API et le numéro de version dans les documents de sortie. Par exemple, lorsqu'il convertit une présentation en PDF, Aspose.Slides pour Python remplit le champ Application avec la valeur '*Aspose.Slides*' et le champ PDF Producer avec une valeur sous la forme '*Aspose.Slides v XX.XX*'. **Remarque** vous ne pouvez pas demander à Aspose.Slides pour Python de modifier ou de supprimer ces informations des documents de sortie.
{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des présentations complètes en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations au format PDF, en veillant à ce que le contenu des PDF résultants corresponde étroitement aux présentations originales. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Hyperliens
* En-têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

L'opération standard de conversion PowerPoint en PDF est exécutée avec les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant les paramètres optimaux aux niveaux de qualité maximale. Ce code Python vous montre comment convertir un PowerPoint en PDF :

_Étapes : conversions PowerPoint en PDF avec Python_

Le code d'exemple suivant explique ces conversions en utilisant Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Étapes : convertir PowerPoint en PDF avec Python via .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Étapes : convertir PPT en PDF avec Python via .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Étapes : convertir PPTX en PDF avec Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Étapes : convertir ODP en PDF avec Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Étapes : convertir PPS en PDF avec Python via .NET</a></strong>

_Étapes du code :_

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) et fournissez‑lui le fichier PowerPoint.
  * Extension _.ppt_ pour charger le fichier **PPT** dans la classe _Presentation_.
  * Extension _.pptx_ pour charger le fichier **PPTX** dans la classe _Presentation_.
  * Extension _.odp_ pour charger le fichier **ODP** dans la classe _Presentation_.
  * Extension _.pps_ pour charger le fichier **PPS** dans la classe _Presentation_.
- Enregistrez la _Presentation_ au format **PDF** en appelant la méthode **Save** et en utilisant l'énumération **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Instancie une classe Presentation qui représente un fichier PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Enregistre la présentation au format PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 
Aspose propose un [**convertisseur PowerPoint en PDF**](https://products.aspose.app/slides/fr/conversion/ppt-to-pdf) gratuit en ligne qui montre le processus de conversion d'une présentation en PDF. Pour une implémentation en direct de la procédure décrite ici, vous pouvez effectuer un test avec le convertisseur.
{{% /alert %}}

## **Convertir PowerPoint en PDF avec options**

Aspose.Slides fournit des options personnalisées—des propriétés de la classe [PdfOptions](https://docs.aspose.com/slides/fr/python-net/api-reference/aspose.slides.export/pdfoptions/)—qui vous permettent de personnaliser le PDF (résultant du processus de conversion), de verrouiller le PDF avec un mot de passe, ou même de spécifier le déroulement du processus de conversion.

### **Convertir PowerPoint en PDF avec des options personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre réglage de qualité préféré pour les images raster, spécifier la manière dont les métafichiers doivent être traités, définir un niveau de compression pour le texte, définir le DPI pour les images, etc.

L'exemple de code ci‑dessous montre une opération dans laquelle une présentation PowerPoint est convertie en PDF avec plusieurs options personnalisées :
```python
import aspose.slides as slides

# Instancie la classe PdfOptions
pdf_options = slides.export.PdfOptions()

# Définit la qualité des images JPG
pdf_options.jpeg_quality = 90

# Définit le DPI des images
pdf_options.sufficient_resolution = 300

# Définit le comportement des métafichiers
pdf_options.save_metafiles_as_png = True

# Définit le niveau de compression du texte pour le contenu textuel
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Définit le mode de conformité du PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Instancie la classe Presentation qui représente un document PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Enregistre la présentation au format PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Convertir PowerPoint en PDF avec diapositives masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser une option personnalisée—la propriété `show_hidden_slides` de la classe [PdfOptions](https://docs.aspose.com/slides/fr/python-net/api-reference/aspose.slides.export/pdfoptions/)—pour indiquer à Aspose.Slides d'inclure les diapositives masquées comme pages dans le PDF résultant.

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

# Définit le mot de passe PDF et les permissions d'accès
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Enregistre la présentation au format PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Convertir des diapositives sélectionnées d’un PowerPoint en PDF**

Ce code Python vous montre comment convertir des diapositives spécifiques d’une présentation PowerPoint en PDF :
```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Définit un tableau des positions des diapositives
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

        # Définit la taille personnalisée de la diapositive.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Clone la première diapositive de la présentation d'origine.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Enregistre la présentation redimensionnée au format PDF avec notes.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Convertir PowerPoint en PDF en vue des notes de diapositive**

Ce code Python vous montre comment convertir un PowerPoint en notes PDF :
```python
import aspose.slides as slides

# Instancie une classe Presentation qui représente un fichier PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Enregistre la présentation en notes PDF
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Normes d’accessibilité et de conformité pour le PDF**

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Directives d’accessibilité du contenu Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en utilisant l’une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code Python montre une opération de conversion PowerPoint en PDF dans laquelle plusieurs PDF basés sur différentes normes de conformité sont obtenus :
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
Le support d’Aspose.Slides pour les opérations de conversion PDF s’étend à la conversion du PDF vers les formats de fichiers les plus populaires. Vous pouvez effectuer des conversions [PDF vers HTML](https://products.aspose.com/slides/fr/python-net/conversion/pdf-to-html/), [PDF vers image](https://products.aspose.com/slides/fr/python-net/conversion/pdf-to-image/), [PDF vers JPG](https://products.aspose.com/slides/fr/python-net/conversion/pdf-to-jpg/), et [PDF vers PNG](https://products.aspose.com/slides/fr/python-net/conversion/pdf-to-png/). D’autres opérations de conversion PDF vers des formats spécialisés—[PDF vers SVG](https://products.aspose.com/slides/fr/python-net/conversion/pdf-to-svg/), [PDF vers TIFF](https://products.aspose.com/slides/fr/python-net/conversion/pdf-to-tiff/), et [PDF vers XML](https://products.aspose.com/slides/fr/python-net/conversion/pdf-to-xml/)—sont également prises en charge.
{{% /alert %}}

> **Note** : Lors de l'exportation vers PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, les graphiques et les formules comme une seule figure. Les éléments de chemin individuels ne sont pas conservés comme contenu séparé et peuvent être marqués comme artefacts ; le texte alternatif est fourni uniquement pour la figure entière.

## **FAQ**

**Aspose.Slides pour Python peut‑il supprimer les informations d’application du PDF ?**  
Non, Aspose.Slides pour Python inclut automatiquement les informations d’API et le numéro de version dans le PDF généré. Ces informations ne peuvent pas être modifiées ou supprimées.

**Comment inclure uniquement des diapositives spécifiques dans la conversion PDF ?**  
Vous pouvez spécifier les indices des diapositives que vous souhaitez convertir en passant un tableau de positions de diapositives à la méthode `save`.

**Est‑il possible de protéger le PDF par mot de passe lors de la conversion ?**  
Oui, vous pouvez définir un mot de passe et les permissions d’accès en utilisant la classe `PdfOptions` avant d’enregistrer la présentation au format PDF.

**Aspose.Slides prend‑il en charge la conversion de PDF vers d’autres formats ?**  
Oui, Aspose.Slides prend en charge la conversion de PDFs vers des formats tels que HTML, les formats d’image (JPG, PNG), SVG, TIFF et XML.

**Comment garantir que mon PDF respecte les normes d’accessibilité ?**  
Définissez la propriété `compliance` dans `PdfOptions` sur des normes telles que `PDF_A1A`, `PDF_A1B` ou `PDF_UA` afin de garantir la conformité aux directives d’accessibilité.

**Puis‑je inclure les diapositives masquées dans le PDF généré ?**  
Oui, en définissant la propriété `show_hidden_slides` dans `PdfOptions` à `True`, les diapositives masquées seront incluses dans le PDF.

**Comment ajuster la qualité et la résolution des images lors de la conversion ?**  
Utilisez les propriétés `jpeg_quality` et `sufficient_resolution` dans `PdfOptions` pour contrôler la qualité et la résolution des images dans le PDF résultant.

**Aspose.Slides gère‑t‑il automatiquement les substitutions de polices ?**  
Aspose.Slides détecte les substitutions de polices lors de la conversion, et vous pouvez les gérer à l’aide de la propriété `warning_callback` dans `SaveOptions` (actuellement limitée).

## **Ressources supplémentaires**

- [Documentation Aspose.Slides pour .NET](https://docs.aspose.com/slides/fr/python-net/)
- [Référence API Aspose.Slides](https://reference.aspose.com/slides/fr/python-net/)
- [Convertisseurs en ligne gratuits d’Aspose](https://products.aspose.app/slides/fr/conversion)