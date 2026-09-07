---
title: Convertir PPT en PPTX en Python
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
- exporter PPT vers PPTX
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Convertir les fichiers PPT anciens en PPTX avec Python et Aspose.Slides. Inclut des exemples Python pour la conversion d'un seul fichier et en lot, la gestion des erreurs et des notes de fidélité."
---
## **Aperçu**

Le PPT est le format binaire hérité de PowerPoint, tandis que le PPTX est le format Open XML plus récent. Aspose.Slides for Python via Java peut charger un fichier PPT et l’enregistrer au format PPTX sans Microsoft PowerPoint. Cet article montre comment convertir un fichier ou un répertoire de fichiers et explique ce qu’il faut vérifier après la conversion.

Chaque exemple démarre la machine virtuelle Java si nécessaire et libère la présentation après utilisation. Remplacez les chemins d’exemple par vos propres chemins de fichiers ou de répertoires.

## **Convertir un fichier PPT en PPTX**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/), puis appelez [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Pptx). Le bloc `finally` libère la présentation et libère ses ressources.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Chargement de la présentation PPT héritée.
presentation = Presentation("presentation.ppt")
try:
    # Enregistrement de la présentation au format PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L’extension de fichier ne sélectionne pas le format de sortie par elle-même ; c’est l’argument [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Pptx) qui le fait. Gardez les chemins d’entrée et de sortie différents si vous devez conserver le fichier PPT d’origine.

## **Convertir plusieurs fichiers PPT**

L’exemple suivant convertit chaque fichier `.ppt` d’un répertoire. Chaque fichier est traité indépendamment, ainsi une conversion échouée n’arrête pas le reste du lot.

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

Pour les charges de travail en production, consignez l’exception complète, décidez si un fichier de sortie existant peut être écrasé, et enregistrez les noms de fichiers ayant échoué dans une file de réessai ou de révision. Les fichiers corrompus, les fichiers protégés par mot de passe ouverts sans le mot de passe requis, les chemins inaccessibles et le contenu non pris en charge peuvent tous provoquer un échec de conversion. Voir [Password-Protected Presentations](/slides/fr/python-java/password-protected-presentation/) pour le chargement de fichiers chiffrés.

## **Fidélité et fonctionnalités héritées**

La conversion préserve généralement les diapositives, les maîtres, les dispositions, le texte, les formes, les images, les tables et les graphiques. Cependant, PPT et PPTX ne représentent pas chaque fonctionnalité exactement de la même manière. Une fonctionnalité héritée qui n’a pas d’équivalent PPTX, ou qui n’est pas prise en charge par la bibliothèque, peut être normalisée, omise ou affichée différemment.

Vérifiez le fichier converti lorsqu’il contient des animations, des transitions, des objets OLE incorporés ou liés, des contrôles ActiveX, des médias incorporés, des polices rares ou des macros VBA. Un fichier PPTX simple n’est pas un format prenant en charge les macros, donc utilisez un flux de travail adapté aux macros lorsque VBA doit rester disponible. Vérifiez également que les polices requises et les ressources externes sont présentes dans l’environnement où la présentation convertie sera ouverte ou rendue.

Pour les documents importants, rouvrez le PPTX généré programmelement et inspectez le nombre de diapositives clés ainsi que le contenu, puis comparez son apparence et le comportement du diaporama dans le visualiseur prévu. Ne considérez pas qu’un appel réussi à [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) soit la preuve que chaque fonctionnalité héritée a une représentation PPTX exacte.

## **Quand utiliser PPTX**

Utilisez PPTX lorsque la présentation sera éditée avec les versions actuelles de PowerPoint, échangée avec des systèmes qui travaillent avec des packages Open XML, ou stockée dans un format plus facile à inspecter et à récupérer que le PPT binaire hérité. Conservez le PPT original comme copie d’archivage ou de retour en arrière jusqu’à ce que la présentation convertie ait passé vos contrôles de fidélité.

Si vous avez besoin de PDF, HTML, images, XPS ou d’un autre type de sortie, utilisez les instructions spécifiques au format dans [Convert Presentations to Multiple Formats](/slides/fr/python-java/convert-presentation/) plutôt que de supposer que toutes les cibles conservent les fonctionnalités éditables de PowerPoint.

## **Convertisseur en ligne**

Pour un fichier occasionnel ou une comparaison rapide, vous pouvez utiliser le [online PPT to PPTX converter](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx). Pour des conversions récurrentes, un traitement par lots ou une gestion des erreurs au niveau de l’application, utilisez l’API Python via Java.

## **Articles liés**

- [PPT vs PPTX](/slides/fr/python-java/ppt-vs-pptx/)
- [Enregistrer des présentations en Python](/slides/fr/python-java/save-presentation/)
- [Formats de fichiers pris en charge](/slides/fr/python-java/supported-file-formats/)
- [Ouvrir des présentations en Python](/slides/fr/python-java/open-presentation/)

## **FAQ**

**Puis-je convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui. Aspose.Slides for Python via Java charge et enregistre les fichiers de présentation sans nécessiter Microsoft PowerPoint.

**La conversion PPT en PPTX préserve-t-elle tout le contenu exactement ?**

Elle préserve le contenu de présentation commun, mais la fidélité exacte n’est pas garantie pour chaque fonctionnalité héritée ou non prise en charge. Examinez le fichier généré lorsqu’il contient des macros, des objets OLE ou ActiveX, des médias, des animations spécialisées ou des polices rares.

**Puis-je convertir un fichier PPT protégé par mot de passe ?**

Oui, si vous fournissez le mot de passe correct lors du chargement du fichier. Un mot de passe manquant ou incorrect entraîne l’échec de l’opération de chargement.

**Dois-je supprimer le fichier PPT après la conversion ?**

Conservez l’original jusqu’à ce que vous ayez vérifié le PPTX dans les visualiseurs et flux de travail qui vous importent. Cela fournit une copie de secours si une fonctionnalité héritée est convertie différemment.