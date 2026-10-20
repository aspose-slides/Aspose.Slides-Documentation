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
- pièce jointe
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Convertir les fichiers PowerPoint PPT/PPTX en PDF de haute qualité et consultables en Python via Java avec Aspose.Slides, en proposant des exemples de code rapides et des options de conversion avancées."
---
## **Vue d'ensemble**

Convertir des présentations PowerPoint (PPT, PPTX, ODP, etc.) au format PDF en Python via Java offre plusieurs avantages, notamment la compatibilité entre différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de police, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions de PowerPoint en PDF**

Avec Aspose.Slides, vous pouvez convertir des présentations dans les formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, passez le nom du fichier en argument à la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) puis enregistrez la présentation au format PDF à l’aide de la méthode [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). La classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) expose la méthode [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) qui est généralement utilisée pour convertir une présentation en PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java insère ses informations d’API et son numéro de version dans les documents de sortie. Par exemple, lors de la conversion d’une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur du type "*Aspose.Slides v XX.XX*". **Note** que vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents de sortie.

{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des présentations entières en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations vers PDF, en veillant à ce que les PDF résultants correspondent étroitement aux présentations d’origine. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Hyperliens
* En-têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

La conversion standard utilise les paramètres d’exportation PDF par défaut. Utilisez des options personnalisées lorsque vous devez contrôler la qualité des images, le contenu des pages ou la conformité PDF.

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

Aspose propose un [**convertisseur PowerPoint en PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratuit en ligne qui montre le processus de conversion de présentation en PDF. Vous pouvez exécuter un test avec ce convertisseur pour une mise en œuvre en direct de la procédure décrite ici.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisées – propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) – qui vous permettent de personnaliser le PDF résultant, de verrouiller le PDF avec un mot de passe ou de spécifier comment le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec Options Personnalisées**

À l’aide d’options de conversion personnalisées, vous pouvez définir le réglage de qualité préféré pour les images matricielles, préciser comment les métaphores doivent être traitées, définir un niveau de compression du texte, configurer le DPI des images, etc.

L’exemple suivant exporte une présentation en PDF 1.5 avec une qualité JPEG de 90, une résolution d’image de 300 DPI, les métaphores enregistrées au format PNG et la compression de texte Flate.

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

### **Sélection automatique de la compression d’image**

Lorsqu’une présentation contient de nombreuses photographies ou captures d’écran, réduire la taille du PDF exporté facilite l’envoi par e‑mail ou le téléchargement. Appelez [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setBestImagesCompressionRatio) avec `True` pour sélectionner automatiquement l’algorithme de compression le plus approprié pour chaque image lors de l’exportation PDF.

L’exemple suivant charge une présentation existante, active la sélection automatique de la compression des images et l’enregistre en tant que document PDF. Tous les autres paramètres d’exportation PDF conservent leurs valeurs par défaut.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setBestImagesCompressionRatio(True)

presentation = Presentation("image-heavy.pptx")
try:
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Cette option sélectionne un algorithme de compression pour chaque image. Diminuer la valeur passée à [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) réduit la qualité JPEG, tandis que diminuer la valeur passée à [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) autorise le sous‑échantillonnage des images à une résolution inférieure, ce qui peut réduire les détails. L’activation de la sélection automatique de la compression n’abaisse pas ces réglages en elle‑même.

Sélectionner les algorithmes de compression d’image nécessite un temps de traitement et une mémoire supplémentaires. La réduction de taille dépend des images de la présentation et des paramètres d’exportation ; aucune réduction fixe n’est garantie pour chaque présentation.

### **Conserver les fichiers OLE intégrés comme pièces jointes PDF**

Si une présentation contient un classeur Excel intégré, vous pouvez vouloir que les destinataires du PDF puissent également accéder aux données du classeur. Appelez [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) avec `True` pour conserver les fichiers OLE intégrés comme pièces jointes dans le PDF résultant.

La valeur par défaut est `False` : l’image de prévisualisation ou l’icône de l’objet OLE est rendue sur la page PDF, mais le fichier intégré n’est pas inclus en tant que pièce jointe. Le réglage à `True` ajoute également les données du fichier. La prévisualisation reste une représentation visuelle ; la pièce jointe permet aux destinataires d’ouvrir ou d’enregistrer le fichier intégré séparément. L’objet OLE ne devient pas une feuille de calcul Excel interactive sur la page PDF.

L’exemple suivant charge une présentation contenant déjà un classeur Excel intégré et l’exporte en PDF avec le classeur joint.

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

1. Ouvrez le PDF exporté dans un lecteur qui prend en charge les pièces jointes, tel qu’Adobe Acrobat Reader.
2. Ouvrez le panneau **Attachments** du lecteur et localisez le classeur intégré.
3. Enregistrez la pièce jointe et ouvrez‑la dans Excel pour inspecter les données, ou ouvrez‑la directement si le lecteur le permet. La prévisualisation sur la page PDF est distincte de la pièce jointe.

{{% alert color="info" title="Note" %}}

Les normes PDF/A imposent des restrictions sur les pièces jointes : PDF/A‑1 interdit les fichiers intégrés, PDF/A‑2 autorise uniquement les pièces jointes PDF/A, et PDF/A‑3 autorise d’autres types de fichiers, y compris les classeurs Excel. Il s’agit d’exigences des normes, pas de restrictions propres à Aspose.Slides. Cet exemple utilise le réglage de conformité PDF par défaut et ne montre pas l’exportation PDF/A.

{{% /alert %}}

### **Convertir PowerPoint en PDF avec Diapositives Masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) de la classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) pour inclure les diapositives masquées en tant que pages dans le PDF résultant.

L’exemple suivant exporte une présentation en PDF, en incluant les éventuelles diapositives masquées.

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

### **Convertir PowerPoint en PDF protégé par Mot de Passe**

L’exemple suivant exporte une présentation en PDF qui nécessite le mot de passe `password` pour s’ouvrir. Les autorisations d’accès permettent l’impression, y compris l’impression de haute qualité.

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

### **Détection des Substitutions de Police**

Aspose.Slides fournit la méthode [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) de la classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) qui vous permet de détecter les substitutions de police pendant le processus de conversion de la présentation en PDF.

L’exemple suivant exporte une présentation en PDF et imprime les avertissements de substitution de police dans la console. Un avertissement n’est affiché que lorsqu’une police indisponible est substituée lors de l’exportation. Utilisez un proxy JPype pour recevoir les rappels d’avertissement depuis l’API Java. Convertissez la chaîne de description Java en chaîne Python avant de vérifier son préfixe :

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

Pour plus d’informations sur la substitution de police, consultez l’article [Substitution de police](/slides/fr/python-java/font-substitution/).

{{% /alert %}}

### **Gestion des Polices Sans Variante Gras Dédiée**

Une présentation peut appliquer un format gras à du texte même si sa police ne possède pas de variante gras dédiée. Le texte peut néanmoins apparaître en gras grâce au gras synthétique, qui épaissit artificiellement les glyphes normaux. Lorsque ce texte apparaît trop lourd ou diffère de l’apparence attendue dans le PDF, essayez d’appeler [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) avec `True`. Cette option rend le texte concerné sous forme de bitmap lors de l’exportation PDF et peut améliorer son apparence pour certaines polices. Sa valeur par défaut est `False`.

La présentation d’exemple contient deux zones de texte : une avec du texte normal et une avec du texte en gras appliqué à la même police, qui n’a pas de variante gras dédiée. L’exemple suivant charge la présentation, active la rasterisation des styles de police non pris en charge et l’exporte en PDF :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Les aperçus suivants montrent le résultat désactivé et le résultat activé. Dans cet exemple, le texte en gras a des traits plus épais lorsque l’option est désactivée. Avec l’option activée, ses traits sont plus fins ; le texte normal reste inchangé. Comparez les résultats avant de choisir le réglage pour votre présentation.

| Option désactivée (`False`, par défaut) | Option activée (`True`) |
|---|---|
| ![PDF avec rasterisation du style de police non pris en charge désactivée](unsupported-bold-disabled.png) | ![PDF avec rasterisation du style de police non pris en charge activée](unsupported-bold-enabled.png) |

Dans cet exemple, l’activation de l’option ne transforme en bitmap que le texte en gras : il ne peut pas être sélectionné, copié ou recherché comme texte sans OCR, et ses contours apparaissent plus souples à un zoom de 800 %. Le texte normal reste recherchable. Lorsque l’option est désactivée, les deux chaînes restent du texte.

Cette option rasterise le texte mis en gras lorsque sa police n’a pas de variante gras dédiée. La [substitution de police](/slides/fr/python-java/font-substitution/) choisit à la place une autre police lorsque l’originale est indisponible.

## **Convertir les Diapositives Sélectionnées de PowerPoint en PDF**

Les numéros de diapositives passés à [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) sont indexés à partir de 1. Cet exemple exporte les diapositives 1 et 3 lorsqu’elles existent toutes les deux :

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

Cet exemple exporte la première diapositive sur une page mesurant 612 × 792 points (US Letter). Il clone la diapositive dans une nouvelle présentation avec la taille spécifiée et adapte le contenu de la diapositive pour qu’il rentre.

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

    # Supprimer la diapositive vide avec laquelle la nouvelle présentation a été créée.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Convertir PowerPoint en PDF en Vue des Notes de Diapositive**

L’exemple suivant exporte une présentation en PDF, plaçant les notes du présentateur de chaque diapositive sous la diapositive. Utilisez une présentation contenant des notes du présentateur pour voir le résultat.

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

## **Accessibilité et Normes de Conformité pour le PDF**

Lors de la préparation de PDF accessibles, consultez les [Directives d’accessibilité du contenu Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Utilisez [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) pour sélectionner une norme de sortie : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code montre un processus de conversion PowerPoint‑to‑PDF qui produit plusieurs PDF selon différentes normes de conformité :

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

> **Note** : lors de l’exportation en PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, les graphiques et les formules comme une figure unique. Les éléments de chemin individuels ne sont pas conservés comme contenu séparé et peuvent être marqués comme artefacts ; le texte alternatif est fourni uniquement pour la figure entière.

## **FAQ**

**Puis‑je convertir plusieurs fichiers PowerPoint en PDF par lots ?**

Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion programmatiquement.

**Est‑il possible de protéger le PDF converti par mot de passe ?**

Oui. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) pour définir un mot de passe et spécifier les autorisations d’accès lors du processus de conversion.

**Comment inclure les diapositives masquées dans le PDF ?**

Appelez [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) avec `True` dans la classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) pour inclure les diapositives masquées dans le PDF résultant.

**Aspose.Slides peut‑il maintenir une haute qualité d’image dans le PDF ?**

Oui, vous pouvez contrôler la qualité des images en utilisant des méthodes telles que [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) et [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) de la classe [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) pour garantir des images de haute qualité dans votre PDF.

**Aspose.Slides prend‑il en charge les normes de conformité PDF/A ?**

Oui, Aspose.Slides vous permet d’exporter des PDF conformes à [diverses normes](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), notamment PDF/A1a, PDF/A1b et PDF/UA, pour l’accessibilité ou l’archivage. Choisissez la norme appropriée et vérifiez la sortie par rapport à vos exigences.

## **Ressources supplémentaires**

- [Documentation Aspose.Slides for Python via Java](/slides/fr/python-java/)
- [Référence API Aspose.Slides for Python via Java](https://reference.aspose.com/slides/python-java/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/conversion)