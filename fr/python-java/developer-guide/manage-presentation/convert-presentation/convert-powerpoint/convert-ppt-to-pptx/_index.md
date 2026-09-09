---
title: Convertir PPT en PPTX avec Python
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/python-java/convert-ppt-to-pptx/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- PPT en PPTX
- enregistrer PPT en PPTX
- exporter PPT en PPTX
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Convertir les fichiers PPT hérités en PPTX avec Python et Aspose.Slides. Inclut des exemples Python pour la conversion d'un seul fichier et par lots, la gestion des erreurs et des notes sur la fidélité."
---
## **Vue d'ensemble**

PPT est le format binaire hérité de PowerPoint, tandis que PPTX est le format Open XML plus récent. Aspose.Slides for Python via Java peut charger un fichier PPT et l'enregistrer au format PPTX sans Microsoft PowerPoint. Cet article montre comment convertir un fichier ou un répertoire de fichiers et explique ce qu'il faut vérifier après la conversion.

Chaque exemple démarre la machine virtuelle Java si nécessaire et libère la présentation après utilisation. Remplacez les chemins d'exemple par vos propres chemins de fichiers ou de répertoires.

## **Convertir un fichier PPT en PPTX**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/), puis appelez [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Pptx). Le bloc `finally` libère la présentation et ses ressources.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Charger la présentation PPT héritée.
presentation = Presentation("presentation.ppt")
try:
    # Enregistrer la présentation au format PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L'extension de fichier ne sélectionne pas le format de sortie à elle seule ; c'est l'argument [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Pptx) qui le fait. Conservez des chemins d'entrée et de sortie différents si vous devez conserver le fichier PPT original.

## **Convertir plusieurs fichiers PPT**

L'exemple suivant convertit chaque fichier `.ppt` d'un répertoire. Chaque fichier est traité de façon indépendante, ainsi une conversion échouée n'arrête pas le reste du lot.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

Pour les charges de travail de production, consignez l'exception complète, décidez si un fichier de sortie existant peut être écrasé, et enregistrez les noms de fichiers ayant échoué dans une file d'attente de réessai ou de révision. Les fichiers corrompus, les fichiers protégés par mot de passe ouverts sans le mot de passe requis, les chemins inaccessibles et le contenu non pris en charge peuvent tous provoquer un échec de conversion. Consultez [Password-Protected Presentations](/slides/fr/python-java/password-protected-presentation/) pour charger des fichiers chiffrés.

## **Fidélité et fonctionnalités héritées**

La conversion préserve généralement les diapositives, les maîtres, les dispositions, le texte, les formes, les images, les tableaux et les graphiques. Cependant, PPT et PPTX ne représentent pas chaque fonctionnalité de la même manière exacte. Une fonctionnalité héritée qui n'a pas d'équivalent PPTX, ou qui n'est pas prise en charge par la bibliothèque, peut être normalisée, omise ou affichée différemment.

Vérifiez le fichier converti lorsqu'il contient des animations, des transitions, des objets OLE incorporés ou liés, des contrôles ActiveX, des médias intégrés, des polices rares ou des macros VBA. Un fichier PPTX ordinaire n'est pas un format activé pour les macros, il faut donc utiliser un flux de travail approprié pour les macros lorsque VBA doit rester disponible. Vérifiez également que les polices requises et les ressources externes sont présentes dans l'environnement où la présentation convertie sera ouverte ou rendue.

Pour les documents importants, rouvrez le PPTX généré de façon programmatique et inspectez le nombre de diapositives clés et le contenu, puis comparez son apparence et le comportement du diaporama dans le visualiseur prévu. Ne considérez pas qu'un appel réussi à [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) prouve que chaque fonctionnalité héritée a une représentation PPTX exacte.

## **Quand utiliser PPTX**

Utilisez PPTX lorsque la présentation sera éditée dans les versions actuelles de PowerPoint, échangée avec des systèmes qui travaillent avec des packages Open XML, ou stockée dans un format plus facile à inspecter et à récupérer que le PPT binaire hérité. Conservez le PPT original comme copie d'archivage ou de secours jusqu'à ce que la présentation convertie ait passé vos contrôles de fidélité.

Si vous avez besoin de PDF, HTML, d'images, XPS ou d'un autre type de sortie à la place, utilisez les conseils spécifiques au format dans [Convert Presentations to Multiple Formats](/slides/fr/python-java/convert-presentation/) plutôt que de supposer que toutes les cibles conservent les fonctionnalités PowerPoint éditables.

## **Convertisseur en ligne**

Pour un fichier occasionnel ou une comparaison rapide, vous pouvez utiliser le [convertisseur PPT en PPTX en ligne](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx). Pour des conversions récurrentes, un traitement par lots ou une gestion d'erreurs au niveau de l'application, utilisez l'API Python via Java.

## **Articles associés**

- [PPT vs PPTX](/slides/fr/python-java/ppt-vs-pptx/)
- [Enregistrer des présentations en Python](/slides/fr/python-java/save-presentation/)
- [Formats de fichiers pris en charge](/slides/fr/python-java/supported-file-formats/)
- [Ouvrir des présentations en Python](/slides/fr/python-java/open-presentation/)

## **FAQ**

**Puis-je convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui. Aspose.Slides for Python via Java charge et enregistre les fichiers de présentation sans nécessiter Microsoft PowerPoint.

**La conversion de PPT en PPTX préservera-t-elle tout le contenu exactement ?**

Elle préserve le contenu de présentation courant, mais la fidélité exacte n'est pas garantie pour chaque fonctionnalité héritée ou non prise en charge. Vérifiez le fichier généré lorsqu'il contient des macros, des objets OLE ou ActiveX, des médias, des animations spécialisées ou des polices rares.

**Puis-je convertir un fichier PPT protégé par mot de passe ?**

Oui, si vous fournissez le mot de passe correct lors du chargement du fichier. Un mot de passe manquant ou incorrect entraîne l'échec de l'opération de chargement.

**Dois-je supprimer le fichier PPT après la conversion ?**

Conservez l'original jusqu'à ce que vous ayez vérifié le PPTX dans les visualiseurs et flux de travail qui vous importent. Cela vous fournit une copie de secours si une fonctionnalité héritée se convertit différemment.