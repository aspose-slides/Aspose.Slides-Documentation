---
title: Convertir PowerPoint en PDF avec Python
linktitle: Convertir PowerPoint en PDF
type: docs
weight: 40
url: /fr/python-net/convert-powerpoint-to-pdf/
keywords:
- convertir PowerPoint
- présentation
- PowerPoint en PDF
- PPT en PDF
- PPTX en PDF
- sauvegarder PowerPoint en PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides pour Python
description: "Convertir des présentations PowerPoint en PDF avec Python. Sauvegarder PowerPoint en PDF en respectant les normes de conformité ou d'accessibilité."
---

## **Aperçu**

La conversion de documents PowerPoint en format PDF offre plusieurs avantages, notamment l'assurance de la compatibilité sur différents appareils et la préservation de la mise en page et du format de votre présentation. Cet article vous montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure des diapositives cachées, protéger par mot de passe les documents PDF, détecter les substitutions de police, sélectionner des diapositives pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint en PDF**

Avec Aspose.Slides, vous pouvez convertir des présentations dans ces formats en PDF :

* PPT
* PPTX
* ODP

Pour convertir une présentation en PDF avec Python, il vous suffit de passer le nom du fichier en argument dans la classe [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) puis de sauvegarder la présentation en PDF en utilisant une méthode [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods). La classe [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) expose la méthode [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) qui est généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides pour Python écrit directement les informations API et le numéro de version dans les documents de sortie. Par exemple, lorsqu'il convertit une présentation en PDF, Aspose.Slides pour Python remplit le champ Application avec la valeur '*Aspose.Slides*' et le champ PDF Producer avec une valeur sous la forme '*Aspose.Slides v XX.XX*'. **Remarque** que vous ne pouvez pas demander à Aspose.Slides pour Python de modifier ou de supprimer ces informations des documents de sortie.

{{% /alert %}}

Aspose.Slides vous permet de convertir :

* une présentation entière en PDF
* des diapositives spécifiques dans une présentation en PDF
* une présentation 

Aspose.Slides exporte des présentations en PDF d'une manière qui rend le contenu des PDF résultants très similaire à celui des présentations originales. Ces éléments et attributs connus sont souvent rendus correctement dans les conversions de présentation en PDF :

* images
* zones de texte et autres formes
* textes et leur formatage
* paragraphes et leur formatage
* hyperliens
* en-têtes et pieds de page
* puces
* tableaux

## **Convertir PowerPoint en PDF**

L'opération standard de conversion PowerPoint en PDF est exécutée en utilisant des options par défaut. Dans ce cas, Aspose.Slides essaie de convertir la présentation fournie en PDF en utilisant des paramètres optimaux aux niveaux de qualité maximum. Ce code Python vous montre comment convertir un PowerPoint en PDF :

_Étapes : Conversions PowerPoint en PDF avec Python_

Le code d'exemple suivant explique ces conversions en utilisant Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Étapes : Convertir PowerPoint en PDF en utilisant Python via .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Étapes : Convertir PPT en PDF en utilisant Python via .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Étapes : Convertir PPTX en PDF en utilisant Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Étapes : Convertir ODP en PDF en utilisant Python via .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Étapes : Convertir PPS en PDF en utilisant Python via .NET</a></strong>

_Code des étapes :_

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et lui fournir le fichier PowerPoint.
  * _.ppt_ pour charger un fichier **PPT** dans la classe _Presentation_.
  * _.pptx_ pour charger un fichier **PPTX** dans la classe _Presentation_.
  * _.odp_ pour charger un fichier **ODP** dans la classe _Presentation_.
  * _.pps_ pour charger un fichier **PPS** dans la classe _Presentation_.
- Sauvegarder la _Presentation_ au format **PDF** en appelant la méthode **Save** et en utilisant l’énumération **SaveFormat.PDF**.
  

```python
import aspose.slides as slides

# Instancie une classe Presentation qui représente un fichier PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Sauvegarde la présentation en tant que PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose propose un [**convertisseur PowerPoint en PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) en ligne gratuit qui démontre le processus de conversion de présentation en PDF. Pour une mise en œuvre en direct de la procédure décrite ici, vous pouvez faire un test avec le convertisseur.

{{% /alert %}}

## Convertir PowerPoint en PDF avec options

Aspose.Slides fournit des options personnalisées — des propriétés sous la classe [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) — qui vous permettent de personnaliser le PDF (résultant du processus de conversion), de verrouiller le PDF avec un mot de passe ou même de spécifier comment le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec options personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre paramètre de qualité préféré pour les images raster, spécifier comment les métadonnées doivent être gérées, définir un niveau de compression pour les textes, définir les DPI pour les images, etc.

L'exemple de code ci-dessous démontre une opération dans laquelle une présentation PowerPoint est convertie en PDF avec plusieurs options personnalisées :

```python
import aspose.slides as slides

# Instancie la classe PdfOptions
pdf_options = slides.export.PdfOptions()

# Définit la qualité pour les images JPG
pdf_options.jpeg_quality = 90

# Définit les DPI pour les images
pdf_options.sufficient_resolution = 300

# Définit le comportement pour les métadonnées
pdf_options.save_metafiles_as_png = True

# Définit le niveau de compression du texte pour le contenu textuel
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Définit le mode de conformité du PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Instancie la classe Presentation qui représente un document PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Sauvegarde la présentation comme document PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Convertir PowerPoint en PDF avec diapositives cachées**

Si une présentation contient des diapositives cachées, vous pouvez utiliser une option personnalisée — la propriété `show_hidden_slides` de la classe [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/) — pour indiquer à Aspose.Slides d'inclure les diapositives cachées en tant que pages dans le PDF résultant.

Ce code Python vous montre comment convertir une présentation PowerPoint en PDF avec les diapositives cachées incluses :

```python
import aspose.slides as slides

# Instancie une classe Presentation qui représente un fichier PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Instancie la classe PdfOptions
pdfOptions = slides.export.PdfOptions()

# Ajoute des diapositives cachées
pdfOptions.show_hidden_slides = True

# Sauvegarde la présentation en tant que PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Convertir PowerPoint en PDF protégé par mot de passe**

Ce code Python vous montre comment convertir un PowerPoint en PDF protégé par mot de passe (en utilisant les paramètres de protection de la classe [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)) :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Instancie la classe PdfOptions
pdfOptions = slides.export.PdfOptions()

# Définit le mot de passe du PDF et les autorisations d'accès
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Sauvegarde la présentation en tant que PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Détecter les substitutions de police**

Aspose.Slides fournit la propriété `warning_callback` sous la classe [SaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/) pour vous permettre de détecter les substitutions de police dans un processus de conversion de présentation en PDF. 

Ce code Python vous montre comment détecter les substitutions de police :  

```python
[TODO[SLIDESPYNET-91]: les callbacks ne sont pas pris en charge pour le moment]
```

{{%  alert color="primary"  %}} 

Pour plus d'informations sur les substitutions de police, consultez l'article [Substitution de police](https://docs.aspose.com/slides/python-net/font-substitution/).

{{% /alert %}} 

## **Convertir des diapositives sélectionnées de PowerPoint en PDF**

Ce code Python vous montre comment convertir des diapositives spécifiques d'une présentation PowerPoint en PDF :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Définit un tableau de positions de diapositives
slides_array = [ 1, 3 ]

# Sauvegarde la présentation en tant que PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Convertir PowerPoint en PDF avec taille de diapositive personnalisée**

Ce code Python vous montre comment convertir un PowerPoint lorsque sa taille de diapositive est spécifiée en un PDF :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier PowerPoint 
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# Définit le type et la taille de la diapositive 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Convertir PowerPoint en PDF en vue des notes de diapositive**

Ce code Python vous montre comment convertir un PowerPoint en PDF notes :

```python
import aspose.slides as slides

# Instancie une classe Presentation qui représente un fichier PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Sauvegarde la présentation en tant que PDF notes
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Normes d'accessibilité et de conformité pour PDF**

Aspose.Slides vous permet d'utiliser une procédure de conversion qui respecte les [lignes directrices pour l'accessibilité du contenu Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en utilisant l'une de ces normes de conformité : **PDF/A1a**, **PDF/A1b**, et **PDF/UA**.

Ce code Python démontre une opération de conversion PowerPoint en PDF dans laquelle plusieurs PDFs basés sur différentes normes de conformité sont obtenus :

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

Le support d'Aspose.Slides pour les opérations de conversion PDF s'étend à vous permettre également de convertir le PDF dans les formats de fichier les plus populaires. Vous pouvez effectuer des conversions [PDF en HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF en image](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF en JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), et [PDF en PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). D'autres opérations de conversion de PDF vers des formats spécialisés — [PDF en SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF en TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), et [PDF en XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) — sont également prises en charge.

{{% /alert %}}