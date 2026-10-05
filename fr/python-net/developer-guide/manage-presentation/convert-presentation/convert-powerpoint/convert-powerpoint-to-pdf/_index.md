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
- pièce jointe
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides pour Python
description: "Guide étape par étape pour convertir PPT, PPTX et ODP en PDF de haute qualité conformes aux normes WCAG en Python avec Aspose.Slides — comprend la protection par mot de passe, la sélection de diapositives et le contrôle de la qualité des images."
showReadingTime: true
---
## **Vue d'ensemble**

Convertir des présentations PowerPoint (PPT, PPTX, ODP) au format PDF en Python offre plusieurs avantages, notamment garantir la compatibilité sur différents appareils et préserver la mise en page et le formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger par mot de passe les documents PDF, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion, et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint en PDF**

Avec Aspose.Slides, vous pouvez convertir des présentations dans ces formats en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF en Python, il vous suffit de transmettre le nom du fichier en argument à la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) puis d’enregistrer la présentation au format PDF à l’aide d’une méthode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). La classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expose la méthode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) qui est généralement utilisée pour convertir une présentation en PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python insère ses informations d’API et le numéro de version dans les documents de sortie. Par exemple, lorsqu’il convertit une présentation en PDF, Aspose.Slides for Python remplit le champ Application avec la valeur '*Aspose.Slides*' et le champ PDF Producer avec une valeur sous la forme '*Aspose.Slides v XX.XX*'. **Note** que vous ne pouvez pas demander à Aspose.Slides for Python de modifier ou de supprimer ces informations des documents de sortie.
{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des présentations complètes en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte des présentations en PDF, en veillant à ce que le contenu des PDF résultants corresponde étroitement aux présentations originales. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Hyperliens
* En‑têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus standard de conversion PowerPoint‑vers‑PDF utilise les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant des paramètres optimaux aux niveaux de qualité maximale.

L’exemple suivant charge une présentation et enregistre toutes les diapositives visibles en PDF en utilisant les paramètres d’exportation par défaut.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose propose un [**convertisseur PowerPoint en PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) en ligne gratuit qui montre le processus de conversion d’une présentation en PDF. Pour une mise en œuvre en direct de la procédure décrite ici, vous pouvez tester le convertisseur.
{{% /alert %}}

## **Convertir PowerPoint en PDF avec options**

Aspose.Slides fournit des options personnalisées—des propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—qui vous permettent de personnaliser le PDF (issu du processus de conversion), de verrouiller le PDF avec un mot de passe, ou même de spécifier le déroulement du processus de conversion.

### **Convertir PowerPoint en PDF avec options personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir le réglage de qualité préféré pour les images matricielles, spécifier la façon dont les métafichiers doivent être traités, définir un niveau de compression pour le texte, définir le DPI pour les images, etc.

L’exemple suivant exporte une présentation en PDF 1.5 avec une qualité JPEG réglée à 90, une résolution d’image de 300 DPI, les métafichiers enregistrés au format PNG, et une compression texte Flate.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Conserver les fichiers OLE intégrés comme pièces jointes PDF**

Si une présentation contient un classeur Excel intégré, vous pouvez souhaiter que les destinataires du PDF puissent accéder aux données du classeur ainsi que visualiser les diapositives. Réglez [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) sur `True` pour préserver les fichiers OLE intégrés en tant que pièces jointes dans le PDF résultant.

La valeur par défaut est `False` : l’image d’aperçu ou l’icône de l’objet OLE est rendue sur la page PDF, mais son fichier intégré n’est pas inclus en tant que pièce jointe. Mettre l’option à `True` ajoute également les données du fichier. L’aperçu reste une représentation visuelle ; la pièce jointe permet aux destinataires d’ouvrir ou d’enregistrer le fichier intégré séparément. L’objet OLE ne devient pas une feuille de calcul Excel interactive sur la page PDF.

L’exemple suivant charge une présentation contenant déjà un classeur Excel intégré et l’exporte en PDF avec le classeur attaché.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Pour vérifier le résultat :

1. Ouvrez le PDF exporté dans un lecteur qui prend en charge les pièces jointes, tel qu’Adobe Acrobat Reader.
2. Ouvrez le panneau **Attachments** du lecteur et localisez le classeur intégré.
3. Enregistrez la pièce jointe et ouvrez‑la dans Excel pour inspecter ses données, ou ouvrez‑la directement si le lecteur le permet. L’aperçu sur la page PDF est séparé de la pièce jointe.

{{% alert color="info" title="Note" %}}
Les normes PDF/A imposent des restrictions sur les pièces jointes : PDF/A‑1 prohibe les fichiers intégrés, PDF/A‑2 ne permet que les pièces jointes PDF/A, et PDF/A‑3 autorise d’autres types de fichiers, y compris les classeurs Excel. Il s’agit d’exigences des normes, pas de limitations propres à Aspose.Slides. Cet exemple utilise le paramètre de conformité PDF par défaut et ne montre pas l’exportation PDF/A.
{{% /alert %}}

### **Convertir PowerPoint en PDF avec diapositives masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser une option personnalisée—la propriété [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) de la classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—pour demander à Aspose.Slides d’inclure les diapositives masquées en tant que pages dans le PDF résultant.

L’exemple suivant exporte une présentation en PDF, en incluant les éventuelles diapositives masquées.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Convertir PowerPoint en PDF protégé par mot de passe**

L’exemple suivant exporte une présentation en PDF qui nécessite le mot de passe `password` pour être ouvert. Les permissions d’accès autorisent l’impression, y compris l’impression de haute qualité.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Convertir des diapositives sélectionnées de PowerPoint en PDF**

L’exemple suivant exporte les diapositives 1 et 3 d’une présentation en PDF. Les numéros de diapositives dans ce tableau commencent à 1, et la présentation d’entrée doit contenir au moins trois diapositives.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Convertir PowerPoint en PDF avec taille de diapositive personnalisée**

L’exemple suivant copie la première diapositive d’une présentation dans une nouvelle présentation avec une taille de diapositive de 612 × 792 points (8,5 × 11 pouces). Il ajuste le contenu de la diapositive pour l’adapter et exporte la diapositive unique en PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Supprimer la diapositive vierge créée avec la nouvelle présentation.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Convertir PowerPoint en PDF en vue notes de diapositive**

L’exemple suivant exporte une présentation en PDF, en plaçant les notes du présentateur de chaque diapositive sous la diapositive. Utilisez une présentation contenant des notes du présentateur pour voir le résultat.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Normes d’accessibilité et de conformité pour le PDF**

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en utilisant l’une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

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

{{% alert color="info" title="Note" %}}
Le support d’Aspose.Slides pour les opérations de conversion PDF vous permet de convertir les PDF vers les formats de fichiers les plus populaires. Vous pouvez effectuer des conversions [PDF vers HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF vers image](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF vers JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) et [PDF vers PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). D’autres opérations de conversion PDF vers des formats spécialisés—[PDF vers SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF vers TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/) et [PDF vers XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—sont également prises en charge.
{{% /alert %}}

> **Note :** Lors de l’exportation vers PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, les graphiques et les formules comme une figure unique. Les éléments de chemin individuels ne sont pas conservés comme contenu séparé et peuvent être marqués comme artefacts ; le texte alternatif est fourni uniquement pour la figure entière.

## **FAQ**

**Aspose.Slides pour Python peut‑il supprimer les informations d’application du PDF ?**

Non, Aspose.Slides pour Python inclut automatiquement les informations d’API et le numéro de version dans le PDF de sortie. Ces informations ne peuvent pas être modifiées ou supprimées.

**Comment inclure uniquement des diapositives spécifiques dans la conversion PDF ?**

Vous pouvez spécifier les indices des diapositives à convertir en passant un tableau de positions de diapositives à la méthode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**Est‑il possible de protéger le PDF par mot de passe lors de la conversion ?**

Oui, vous pouvez définir un mot de passe et spécifier les permissions d’accès en utilisant la classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) avant d’enregistrer la présentation en PDF.

**Aspose.Slides prend‑il en charge la conversion de PDF vers d’autres formats ?**

Oui, Aspose.Slides prend en charge la conversion des PDF vers des formats tels que HTML, les formats d’image (JPG, PNG), SVG, TIFF et XML.

**Comment garantir que mon PDF est conforme aux normes d’accessibilité ?**

Définissez la propriété [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) dans [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) sur des normes telles que `PDF_A1A`, `PDF_A1B` ou `PDF_UA` pour garantir la conformité aux directives d’accessibilité.

**Puis‑je inclure les diapositives masquées dans le PDF généré ?**

Oui, en définissant la propriété [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) dans [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) sur `True`, les diapositives masquées seront incluses dans le PDF.

**Comment ajuster la qualité et la résolution des images lors de la conversion ?**

Utilisez les propriétés [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) et [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) dans [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) pour contrôler la qualité et la résolution des images dans le PDF résultant.

**Aspose.Slides gère‑t‑il automatiquement les substitutions de polices ?**

Aspose.Slides détecte les substitutions de polices lors de la conversion, et vous pouvez les gérer à l’aide de la propriété `warning_callback` dans `SaveOptions` (actuellement limitée).

## **Ressources supplémentaires**

- [Documentation Aspose.Slides pour Python via .NET](/slides/fr/python-net/)
- [Référence API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/conversion)