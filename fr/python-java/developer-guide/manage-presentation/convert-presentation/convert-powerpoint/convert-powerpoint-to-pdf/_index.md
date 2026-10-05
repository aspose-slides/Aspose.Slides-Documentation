---
title: Convertir PPT et PPTX en PDF avec Python via Java [Fonctionnalités avancées incluses]
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
- pièce jointe
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Convertir les PPT/PPTX PowerPoint en PDF de haute qualité et recherchables avec Python via Java en utilisant Aspose.Slides, avec des exemples de code rapides et des options de conversion avancées."
---
## **Vue d'ensemble**

Convertir des présentations PowerPoint (PPT, PPTX, ODP, etc.) au format PDF en Python via Java offre plusieurs avantages, notamment la compatibilité sur différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint en PDF**

Avec Aspose.Slides, vous pouvez convertir des présentations des formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, transmettez le nom du fichier en argument au classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) puis enregistrez la présentation au format PDF en utilisant la méthode [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). La classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) expose la méthode [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) qui est généralement utilisée pour convertir une présentation en PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java insère les informations de son API ainsi que le numéro de version dans les documents générés. Par exemple, lors de la conversion d’une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur au format "*Aspose.Slides v XX.XX*". **Note** que vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents générés.
{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des présentations complètes en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte des présentations vers PDF, en veillant à ce que les PDF résultants correspondent étroitement aux présentations d’origine. Les éléments et attributs sont rendus avec précision lors de la conversion, y compris :

* Images
* Zone de texte et formes
* Formatage du texte
* Formatage des paragraphes
* Hyperliens
* En-têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

La conversion standard utilise les paramètres d’exportation PDF par défaut. Utilisez des options personnalisées lorsque vous devez contrôler la qualité des images, le contenu des pages ou la conformité du PDF.

Installez [Aspose.Slides pour Python via Java](/slides/fr/python-java/installation/) et un runtime Java compatible avant d’exécuter les exemples. Chaque exemple lit `presentation.pptx` depuis le répertoire de travail courant ; remplacez-le par votre fichier PPT, PPTX ou ODP. Démarrez la JVM une fois par processus Python.

L’exemple suivant charge une présentation et enregistre toutes les diapositives visibles en PDF en utilisant les paramètres d’exportation par défaut.

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
Aspose propose un [**convertisseur PowerPoint en PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratuit en ligne qui montre le processus de conversion de présentation en PDF. Vous pouvez effectuer un test avec ce convertisseur pour une implémentation en direct de la procédure décrite ici.
{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides propose des options personnalisées—des propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)—qui vous permettent de personnaliser le PDF résultant, de verrouiller le PDF avec un mot de passe ou de spécifier le déroulement du processus de conversion.

### **Convertir PowerPoint en PDF avec Options Personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir le paramètre de qualité souhaité pour les images raster, spécifier comment les métafichiers doivent être traités, définir un niveau de compression pour le texte, configurer les DPI pour les images, etc.

L’exemple suivant exporte une présentation en PDF 1.5 avec une qualité JPEG réglée à 90, une résolution d’image de 300 DPI, les métafichiers enregistrés au format PNG et une compression de texte Flate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Conserver les fichiers OLE incorporés comme pièces jointes PDF**

Si une présentation contient un classeur Excel incorporé, vous pouvez souhaiter que les destinataires du PDF accèdent aux données du classeur ainsi qu’aux diapositives. Appelez [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) avec `True` pour conserver les fichiers OLE incorporés comme pièces jointes dans le PDF résultant.

La valeur par défaut est `False` : l’image d’aperçu ou l’icône de l’objet OLE est rendue sur la page PDF, mais son fichier incorporé n’est pas inclus en tant que pièce jointe. Mettre l’option à `True` inclut en plus les données du fichier. L’aperçu reste une représentation visuelle ; la pièce jointe permet aux destinataires d’ouvrir ou d’enregistrer le fichier incorporé séparément. L’objet OLE ne devient pas une feuille de calcul Excel interactive sur la page PDF.

L’exemple suivant charge une présentation contenant déjà un classeur Excel incorporé et l’exporte en PDF avec le classeur joint.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Pour vérifier le résultat :

1. Ouvrez le PDF exporté dans un lecteur prenant en charge les pièces jointes, tel qu’Adobe Acrobat Reader.
2. Ouvrez le panneau **Attachments** du lecteur et localisez le classeur incorporé.
3. Enregistrez la pièce jointe et ouvrez‑la dans Excel pour examiner ses données, ou ouvrez‑la directement si le lecteur le permet. L’aperçu sur la page PDF est distinct de la pièce jointe.

{{% alert color="info" title="Note" %}}
Les normes PDF/A imposent des restrictions sur les pièces jointes : PDF/A‑1 interdit les fichiers incorporés, PDF/A‑2 n’autorise que les pièces jointes PDF/A, et PDF/A‑3 autorise d’autres types de fichiers, y compris les classeurs Excel. Il s’agit d’exigences des normes, et non de restrictions propres à Aspose.Slides. Cet exemple utilise le paramètre de conformité PDF par défaut et ne montre pas l’exportation PDF/A.
{{% /alert %}}

### **Convertir PowerPoint en PDF avec Diapositives Masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) de la classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) pour inclure les diapositives masquées comme pages dans le PDF résultant.

L’exemple suivant exporte une présentation en PDF, en incluant toutes les diapositives masquées.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Convertir PowerPoint en PDF protégé par mot de passe**

L’exemple suivant exporte une présentation en PDF qui nécessite le mot de passe `password` pour être ouvert. Les autorisations d’accès permettent l’impression, y compris l’impression haute qualité.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Détecter les Substitutions de Polices**

Aspose.Slides fournit la méthode [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) sous la classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/), vous permettant de détecter les substitutions de polices pendant le processus de conversion de présentation en PDF.

L’exemple suivant exporte une présentation en PDF et affiche les avertissements de substitution de police dans la console. Un avertissement est affiché uniquement lorsqu’une police indisponible est substituée lors de l’exportation. Utilisez un proxy JPype pour recevoir les rappels d’avertissement de l’API Java. Convertissez la chaîne de description Java en chaîne Python avant de vérifier son préfixe :

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


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Pour plus d’informations sur la substitution de polices, consultez l’article [Substitution de Polices](/slides/fr/python-java/font-substitution/).
{{% /alert %}}

## **Convertir des Diapositives Sélectionnées de PowerPoint en PDF**

Les numéros de diapositives transmis à [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) sont basés à 1. Cet exemple exporte les diapositives 1 et 3 lorsqu’elles existent toutes deux :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Convertir PowerPoint en PDF avec Taille de Diapositive Personnalisée**

Cet exemple exporte la première diapositive sur une page mesurant 612 par 792 points (US Letter). Il clone la diapositive dans une nouvelle présentation avec la taille spécifiée et met à l’échelle le contenu de la diapositive pour l’ajuster.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # Supprimer la diapositive vierge créée avec la nouvelle présentation.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Convertir PowerPoint en PDF en Vue des Notes**

L’exemple suivant exporte une présentation en PDF, en plaçant les notes du présentateur de chaque diapositive sous la diapositive. Utilisez une présentation contenant des notes du présentateur pour voir le résultat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Normes d’Accessibilité et de Conformité pour le PDF**

Lors de la création de PDF accessibles, consultez les [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Utilisez [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) pour sélectionner une norme de sortie : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code montre un processus de conversion PowerPoint‑en‑PDF qui génère plusieurs PDF selon différentes normes de conformité :

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

> **Note :** Lors de l’exportation en PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, les graphiques et les formules comme une seule figure. Les éléments de chemin individuels ne sont pas conservés comme contenu séparé et peuvent être marqués comme des artefacts ; le texte alternatif est fourni uniquement pour la figure entière.

## **FAQ**

**Puis‑je convertir plusieurs fichiers PowerPoint en PDF en masse ?**

Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion par programmation.

**Est‑il possible de protéger le PDF converti par mot de passe ?**

Oui. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) pour définir un mot de passe et spécifier les autorisations d’accès lors du processus de conversion.

**Comment inclure les diapositives masquées dans le PDF ?**

Appelez [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) avec `True` dans la classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) pour inclure les diapositives masquées dans le PDF résultant.

**Aspose.Slides peut‑il conserver une haute qualité d’image dans le PDF ?**

Oui, vous pouvez contrôler la qualité des images en utilisant des méthodes telles que [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) et [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) dans la classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) pour garantir des images de haute qualité dans votre PDF.

**Aspose.Slides prend‑il en charge les normes de conformité PDF/A ?**

Oui, Aspose.Slides vous permet d’exporter des PDF conformes à [diverses normes](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), notamment PDF/A1a, PDF/A1b et PDF/UA, pour l’accessibilité ou l’archivage. Choisissez la norme appropriée et vérifiez la sortie par rapport à vos exigences.

## **Ressources supplémentaires**

- [Documentation Aspose.Slides pour Python via Java](/slides/fr/python-java/)
- [Référence API Aspose.Slides pour Python via Java](https://reference.aspose.com/slides/python-java/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/conversion)