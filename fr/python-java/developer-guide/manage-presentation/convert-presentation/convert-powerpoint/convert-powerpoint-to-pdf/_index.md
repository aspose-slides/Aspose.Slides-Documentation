---
title: Convertir PPT et PPTX en PDF en Python via Java [Fonctionnalités avancées incluses]
linktitle: PowerPoint en PDF
type: docs
weight: 40
url: /fr/python-java/convert-powerpoint-to-pdf/
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Convertir les fichiers PowerPoint PPT/PPTX en PDFs de haute qualité et recherchables en Python via Java à l'aide d'Aspose.Slides, avec des exemples de code rapides et des options de conversion avancées."
---
## **Vue d'ensemble**

Convertir des présentations PowerPoint (PPT, PPTX, ODP, etc.) au format PDF en Python via Java offre plusieurs avantages, notamment la compatibilité sur différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions de PowerPoint vers PDF**

En utilisant Aspose.Slides, vous pouvez convertir des présentations dans les formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, transmettez le nom du fichier en argument à la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) puis enregistrez la présentation au format PDF en utilisant la méthode [save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save). La classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) expose la méthode [save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) qui est généralement utilisée pour convertir une présentation en PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java insère les informations de son API et le numéro de version dans les documents de sortie. Par exemple, lors de la conversion d'une présentation en PDF, Aspose.Slides remplit le champ Application avec « *Aspose.Slides* » et le champ PDF Producer avec une valeur sous la forme « *Aspose.Slides v XX.XX* ». **Note** que vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents de sortie.
{{% /alert %}}

Aspose.Slides vous permet de convertir :
* Toutes les présentations en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations en PDF, garantissant que les PDF résultants correspondent étroitement aux présentations d'origine. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :
* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Hyperliens
* En-têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

La conversion standard utilise les paramètres d'exportation PDF par défaut. Utilisez des options personnalisées lorsque vous devez contrôler la qualité des images, le contenu des pages ou la conformité du PDF.

Installez [Aspose.Slides for Python via Java](/slides/fr/python-java/installation/) et un runtime Java compatible avant d'exécuter les exemples. Chaque exemple lit `presentation.pptx` depuis le répertoire de travail courant ; remplacez-le par votre fichier PPT, PPTX ou ODP. Démarrez la JVM une fois par processus Python.

Ce code convertit une présentation en PDF :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose propose un convertisseur en ligne gratuit [**PowerPoint en PDF**](https://products.aspose.app/slides/fr/conversion/ppt-to-pdf) qui montre le processus de conversion d’une présentation en PDF. Vous pouvez effectuer un test avec ce convertisseur pour une mise en œuvre en direct de la procédure décrite ici.
{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisées — des propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/) — qui vous permettent de personnaliser le PDF résultant, de verrouiller le PDF avec un mot de passe, ou de spécifier comment le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec Options Personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre réglage de qualité préféré pour les images raster, spécifier la façon dont les métafichiers doivent être traités, définir un niveau de compression pour le texte, configurer le DPI des images, etc.

L'exemple de code ci‑dessous montre comment convertir une présentation PowerPoint en PDF avec plusieurs options personnalisées.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Convertir PowerPoint en PDF avec Diapositives Masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) de la classe [PdfOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/) pour inclure les diapositives masquées en tant que pages dans le PDF résultant.

Le code montre comment convertir une présentation PowerPoint en PDF avec les diapositives masquées incluses :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Convertir PowerPoint en PDF protégé par mot de passe**

Ce code montre comment convertir une présentation PowerPoint en PDF protégé par mot de passe en utilisant les paramètres de protection de la classe [PdfOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Détecter les Substitutions de Polices**

Aspose.Slides fournit la méthode [setWarningCallback](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveoptions/#setWarningCallback) de la classe [PdfOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/), vous permettant de détecter les substitutions de polices lors du processus de conversion présentation‑vers‑PDF.

Utilisez un proxy JPype pour recevoir les rappels d’avertissement de l’API Java. Convertissez la chaîne de description Java en chaîne Python avant de vérifier son préfixe :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Pour plus d’informations sur la réception de rappels d’avertissement pour les substitutions de polices pendant le processus de rendu, consultez [Obtenir des rappels d’avertissement pour la substitution de polices](/slides/fr/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pour plus d’informations sur la substitution de polices, consultez l’article [Font Substitution](/slides/fr/python-java/font-substitution/).
{{% /alert %}}

## **Convertir des Diapositives Sélectionnées de PowerPoint en PDF**

Les numéros de diapositives passés à [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) commencent à 1. Cet exemple exporte les diapositives 1 et 3 lorsqu’elles existent toutes les deux :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **Convertir PowerPoint en PDF avec Taille de Diapositive Personnalisée**

Cet exemple exporte la première diapositive sur une page mesurant 612 × 792 points (US Letter). Il duplique la diapositive dans une nouvelle présentation avec la taille spécifiée :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **Convertir PowerPoint en PDF en Vue Notes**

Ce code montre comment convertir une présentation PowerPoint en PDF incluant les notes :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Accessibilité et Normes de Conformité pour le PDF**

Lors de la création de PDFs accessibles, consultez les [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Utilisez [PdfOptions.setCompliance](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/#setCompliance) pour sélectionner une norme de sortie : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code montre un processus de conversion PowerPoint‑vers‑PDF qui produit plusieurs PDFs selon différentes normes de conformité :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **Note :** Lors de l’exportation vers PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, les graphiques et les formules comme une seule figure. Les éléments de tracé individuels ne sont pas conservés en tant que contenu séparé et peuvent être marqués comme artefacts ; le texte alternatif est fourni uniquement pour la figure entière.

## **FAQ**

**Puis‑je convertir plusieurs fichiers PowerPoint en PDF en masse ?**  
Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion de manière programmatique.

**Est‑il possible de protéger le PDF converti par mot de passe ?**  
Oui. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/) pour définir un mot de passe et spécifier les autorisations d’accès pendant le processus de conversion.

**Comment inclure les diapositives masquées dans le PDF ?**  
Utilisez la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) de la classe [PdfOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/) pour inclure les diapositives masquées dans le PDF résultant.

**Aspose.Slides peut‑il maintenir une haute qualité d’image dans le PDF ?**  
Oui, vous pouvez contrôler la qualité des images en utilisant des méthodes telles que [setJpegQuality](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/#setJpegQuality) et [setSufficientResolution](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/#setSufficientResolution) dans la classe [PdfOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/) pour garantir des images de haute qualité dans votre PDF.

**Aspose.Slides prend‑il en charge les normes de conformité PDF/A ?**  
Oui, Aspose.Slides permet d’exporter des PDFs conformes à [diverses normes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfcompliance/), notamment PDF/A1a, PDF/A1b et PDF/UA, pour l’accessibilité ou l’archivage. Choisissez la norme appropriée et vérifiez le résultat par rapport à vos exigences.

## **Ressources supplémentaires**

- [Documentation d’Aspose.Slides pour Python via Java](/slides/fr/python-java/)
- [Référence API d’Aspose.Slides pour Python via Java](https://reference.aspose.com/slides/fr/python-java/)
- [Convertisseurs en ligne gratuits d’Aspose](https://products.aspose.app/slides/fr/conversion)