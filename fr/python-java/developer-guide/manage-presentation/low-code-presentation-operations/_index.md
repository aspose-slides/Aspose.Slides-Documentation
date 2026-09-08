---
title: Opérations de présentation low-code en Python via Java
linktitle: API low-code
type: docs
weight: 50
url: /fr/python-java/low-code-presentation-operations/
keywords:
- API de présentation low-code
- convertir une présentation
- fusionner des présentations
- parcourir les diapositives
- parcourir les formes
- parcourir le texte
- collecter les formes
- compresser la présentation
- supprimer les diapositives master inutilisées
- supprimer les diapositives de mise en page inutilisées
- compresser les polices incorporées
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Utilisez l'API low-code Aspose.Slides en Python via Java pour convertir et fusionner des présentations, parcourir le contenu, collecter des formes et réduire la taille de la présentation."
---
## **Vue d'ensemble**

L'API [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/fr/python-java/aspose.slides/) fournit des classes d'assistance statiques pour les operations courantes sur les presentations. Ces assistants encapsulent des flux de travail du modele d'objet frequemment utilises dans des methodes ciblees, ce qui vous permet de convertir ou de fusionner des fichiers, de traiter les elements de presentation, de collecter les formes et de supprimer le contenu inutilise avec moins de code.

Les assistants low-code sont les plus utiles lorsque l'operation s'applique a un fichier ou une presentation entiere et que le flux de travail par defaut correspond a vos besoins. Utilisez le [modele d'objet complet d'Aspose.Slides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/) lorsque vous avez besoin d'un controle granular sur les diapositives individuelles, les masters, les mises en page, les formes, les parametres d'exportation ou les relations entre les elements de la presentation.

Le tableau suivant resume les assistants disponibles :

| Assistant | A utiliser pour |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fr/python-java/aspose.slides/convert/) | Conversion d'une presentation vers un autre format avec un appel direct fichier-a-fichier. |
| [Merger](https://reference.aspose.com/slides/fr/python-java/aspose.slides/merger/) | Combination de fichiers de presentation complets du meme format. |
| [ForEach](https://reference.aspose.com/slides/fr/python-java/aspose.slides/foreach/) | Execution d'une action pour chaque diapositive, forme, paragraphe ou portion de texte. |
| [Collect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/collect/) | Recuperation des formes de l'ensemble de la presentation pour un traitement ou une analyse repeats. |
| [Compress](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compress/) | Suppression des masters et mises en page inutilises et reduction des donnees de polices incorporees. |

## **Convertir une presentation**

Utilisez [Convert.autoByExtension](https://reference.aspose.com/slides/fr/python-java/aspose.slides/convert/#autoByExtension) lorsque l'extension du fichier de sortie suffit a selectionner le format d'exportation. La methode ouvre la presentation source, determine le format requis a partir du chemin de sortie et ecrit le resultat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

La classe [Convert](https://reference.aspose.com/slides/fr/python-java/aspose.slides/convert/) propose egalement des methodes dediees pour les sorties PDF, SVG, JPEG, PNG et TIFF. Utilisez le modele d'objet complet lorsque vous devez inspecter ou modifier la presentation avant l'exportation ou configurer une option d'exportation qui n'est pas exposee par l'assistant selectionne. Consultez [Convert Presentation](/slides/fr/python-java/convert-presentation/) pour les flux de travail et options specifics a chaque format.

## **Fusionner des presentations**

Utilisez [Merger.process](https://reference.aspose.com/slides/fr/python-java/aspose.slides/merger/#process) pour combiner des fichiers de presentation complets en un seul appel. Les presentations en entree doivent avoir le meme format de fichier.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

L'assistant est approprie lorsque toutes les diapositives doivent etre ajoutees a un resultat unique sans les selectionner ou les remapper individuellement. Utilisez le modele d'objet complet lorsque vous devez fusionner des diapositives selectionnees, appliquer un master ou une mise en page de destination, conserver explicitement les sections, ou concilier des tailles de diapositive differentes. Consultez [Merge Presentations](/slides/fr/python-java/merge-presentation/) pour ces scenarios.

## **Parcourir les elements de la presentation**

La classe [ForEach](https://reference.aspose.com/slides/fr/python-java/aspose.slides/foreach/) invoque un rappel pour chaque type d'element de presentation demande. Elle evite les boucles imbriquees de collections et est pratique pour l'inspection ou la modification de mise en forme a l'echelle de la presentation.

L'exemple suivant utilise [ForEach.slide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/foreach/#paragraph) et [ForEach.portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/foreach/#portion) pour inspecter les elements correspondants :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

Par defaut, le parcours des formes et du texte a l'echelle de la presentation inclut les diapositives normales, masters et de mise en page. Les surcharges avec un parametre `includeNotes` peuvent egalement traiter les diapositives de notes. Utilisez des boucles de collection directes lorsque l'ordre de parcours, la sortie prematurée, le filtrage avant l'appel du rappel ou un controle detaille parent-enfant sont importants.

## **Collecter les formes**

Utilisez [Collect.shapes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/collect/#shapes) lorsque vous avez besoin d'une collection de toutes les formes d'une presentation plutot que d'un rappel pour chaque forme. Cela est utile lorsque le meme ensemble sera filtre, compte ou traite plusieurs fois.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Utilisez plutot [ForEach.shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/foreach/#shape) lorsque chaque forme peut etre traitee immediatement et que vous n'avez pas besoin de conserver le resultat collecte.

## **Compresser le contenu de la presentation**

La classe [Compress](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compress/) peut supprimer les elements structurels inutilises et reduire les donnees de polices incorporees :

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) supprime les diapositives de mise en page qui ne sont referencees par aucune diapositive normale.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compress/#removeUnusedMasterSlides) supprime les diapositives masters qui ne sont plus utilisees.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compress/#compressEmbeddedFonts) supprime les caracteres inutilises des polices incorporees.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Supprimez d'abord les mises en page inutilisees avant les masters inutilises afin qu'un master devenu non reference après le nettoyage des mises en page puisse egalement etre supprime. Enregistrez la presentation optimise dans un nouveau fichier si vous avez besoin ultérieurement des masters, des mises en page ou des donnees completes de polices incorporees d'origine. Pour plus de details, consultez [Slide Master](/slides/fr/python-java/slide-master/) et [Embedded Font](/slides/fr/python-java/embedded-font/).

## **FAQ**

**Quand devrais-je utiliser l'API low-code plutôt que le modele d'objet complet ?**

Utilisez les assistants low-code lorsque une operation standard s'applique a un fichier ou une presentation complete et ne nécessite pas de controle detaille sur les elements individuels. Utilisez le modele d'objet complet lorsque vous devez selectionner des diapositives specifiquees, controler les relations entre masters et mises en page, inspecter l'etat intermediaire, ou configurer un comportement que l'assistant n'expose pas.

**Le Merger peut-il combiner des presentations dans différents formats de fichier ?**

Non. [Merger.process](https://reference.aspose.com/slides/fr/python-java/aspose.slides/merger/#process) necessite que les presentations d'entree soient dans le meme format. Convertissez d'abord les fichiers d'entree vers un format commun, par exemple avec [Convert.autoByExtension](https://reference.aspose.com/slides/fr/python-java/aspose.slides/convert/#autoByExtension), puis fusionnez les fichiers convertis.

**ForEach traite-t-il les diapositives masters, de mise en page et de notes ?**

[ForEach.slide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/foreach/#slide) parcourt les diapositives normales de la presentation. Les operations [ForEach.shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/foreach/#paragraph) et [ForEach.portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/foreach/#portion) a l'echelle de la presentation incluent par defaut les diapositives normales, masters et de mise en page. Utilisez leurs surcharges avec `includeNotes` regulé sur `True` pour inclure les diapositives de notes.

**Quelle est la difference entre ForEach.shape et Collect.shapes ?**

Utilisez [ForEach.shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/foreach/#shape) pour traiter chaque forme immediatement via un rappel. Utilisez [Collect.shapes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/collect/#shapes) lorsque vous avez besoin d'un resultat iterabl qui peut etre conserve, filtre, compte ou traverse plusieurs fois.

**Compress rend-il toujours le fichier de presentation plus petit ?**

Pas necessairement. Le resultat depend du fait que la presentation contienne ou non des mises en page inutilisees, des masters inutilises ou des polices incorporees avec des caracteres non utilises. Si aucun de ces elements n'est present, les operations correspondantes de [Compress](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compress/) peuvent ne pas reduire la taille du fichier.

**Les modifications apportées par ForEach ou Compress sont-elles sauvegardees automatiquement ?**

Non. Ces assistants agissent sur l'objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) charge en memoire. Apres avoir modifie des elements dans un rappel [ForEach](https://reference.aspose.com/slides/fr/python-java/aspose.slides/foreach/) ou execute [Compress](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compress/), appelez [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) pour ecrire le resultat.

## **Articles lies**

- [Convert Presentation](/slides/fr/python-java/convert-presentation/)
- [Merge Presentations](/slides/fr/python-java/merge-presentation/)
- [Slide Master](/slides/fr/python-java/slide-master/)
- [Manage Text Box](/slides/fr/python-java/manage-textbox/)
- [Embedded Font](/slides/fr/python-java/embedded-font/)