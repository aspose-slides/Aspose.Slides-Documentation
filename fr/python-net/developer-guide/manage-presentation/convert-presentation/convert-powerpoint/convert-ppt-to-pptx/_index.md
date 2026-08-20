---
title: Convertir PPT en PPTX en Python
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/python-net/convert-ppt-to-pptx/
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
- Aspose.Slides
description: "Convertir des fichiers PPT hérités en PPTX en Python avec Aspose.Slides. Inclut des exemples pour la conversion d’un seul fichier et par lots, la gestion des erreurs et des notes de fidélité."
---
## **Vue d'ensemble**

PPT est le format binaire hérité de PowerPoint, tandis que PPTX est le format Open XML plus récent. Aspose.Slides for Python via .NET peut charger un fichier PPT et l’enregistrer en PPTX sans Microsoft PowerPoint. Cet article montre comment convertir un fichier ou un répertoire de fichiers et explique ce qu’il faut vérifier après la conversion.

## **Convertir un fichier PPT en PPTX**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/), puis appelez [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/) avec [SaveFormat.PPTX](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveformat/). L’instruction `with` libère la présentation et ses ressources lorsque le bloc se termine.

```python
import aspose.slides as slides

# Charger la présentation PPT héritée.
with slides.Presentation("presentation.ppt") as presentation:
    # Enregistrer la présentation au format PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

L’extension du fichier ne sélectionne pas le format de sortie à elle seule ; c’est l’argument [SaveFormat.PPTX](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveformat/) qui le fait. Conservez des chemins d’entrée et de sortie différents si vous devez conserver le fichier PPT original.

## **Convertir plusieurs fichiers PPT**

L’exemple suivant convertit chaque fichier `.ppt` présent dans un répertoire. Chaque fichier est traité indépendamment, de sorte qu’une conversion échouée n’arrête pas le reste du lot.

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

Pour les charges de travail en production, consignez l’exception complète, décidez si un fichier de sortie existant peut être écrasé, et écrivez les noms des fichiers échoués dans une file de réessai ou de révision. Les fichiers corrompus, les fichiers protégés par mot de passe ouverts sans le mot de passe requis, les chemins inaccessibles et le contenu non pris en charge peuvent tous entraîner un échec de conversion. Consultez [Présentations protégées par mot de passe](/python-net/password-protected-presentation/) pour charger des fichiers chiffrés.

## **Fidélité et fonctionnalités héritées**

La conversion conserve généralement les diapositives, les arrière‑plans, les mises en page, le texte, les formes, les images, les tableaux et les graphiques. Cependant, PPT et PPTX ne représentent pas chaque fonctionnalité de la même façon. Une fonctionnalité héritée qui n’a pas d’équivalent PPTX, ou qui n’est pas prise en charge par la bibliothèque, peut être normalisée, omitée ou affichée différemment.

Vérifiez le fichier converti lorsqu’il contient des animations, des transitions, des objets OLE incorporés ou liés, des contrôles ActiveX, des médias intégrés, des polices rares ou des macros VBA. Un fichier PPTX standard n’est pas un format activé pour les macros, utilisez donc un flux de travail approprié lorsqu’il faut conserver les macros VBA. Vérifiez également que les polices requises et les ressources externes sont présentes dans l’environnement où la présentation convertie sera ouverte ou rendue.

Pour les documents importants, rouvrez le PPTX généré par programme et inspectez le nombre de diapositives clés et le contenu, puis comparez son apparence et son comportement en mode diaporama dans le visualiseur prévu. Ne considérez pas qu’un appel réussi à [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/) prouve que chaque fonctionnalité héritée possède une représentation PPTX exacte.

## **Quand utiliser PPTX**

Utilisez PPTX lorsque la présentation sera éditée avec les versions actuelles de PowerPoint, échangée avec des systèmes qui travaillent avec des packages Open XML, ou stockée dans un format plus facile à inspecter et à récupérer que le PPT binaire hérité. Conservez le PPT original comme copie d’archivage ou de restauration jusqu’à ce que la présentation convertie ait passé vos contrôles de fidélité.

Si vous avez besoin de PDF, HTML, images, XPS ou d’un autre type de sortie, suivez les directives spécifiques au format dans [Convertir des présentations vers plusieurs formats](/python-net/convert-presentation/) plutôt que de supposer que toutes les cibles conservent les fonctionnalités éditables de PowerPoint.

## **Convertisseur en ligne**

Pour un fichier occasionnel ou une comparaison rapide, vous pouvez utiliser le [convertisseur en ligne PPT en PPTX](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx). Pour des conversions récurrentes, un traitement par lots ou une gestion des erreurs au niveau de l’application, utilisez l’API Python.

## **Articles associés**

- [PPT vs PPTX](/python-net/ppt-vs-pptx/)
- [Enregistrer des présentations en Python](/python-net/save-presentation/)
- [Formats de fichiers pris en charge](/python-net/supported-file-formats/)
- [Ouvrir des présentations en Python](/python-net/open-presentation/)

## **FAQ**

**Puis-je convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui. Aspose.Slides for Python via .NET charge et enregistre les fichiers de présentation sans nécessiter Microsoft PowerPoint.

**La conversion PPT‑vers‑PPTX préserve‑t‑elle tout le contenu exactement ?**

Elle préserve le contenu de présentation commun, mais la fidélité exacte n’est pas garantie pour chaque fonctionnalité héritée ou non prise en charge. Vérifiez le fichier généré lorsqu’il contient des macros, des objets OLE ou ActiveX, des médias, des animations spécialisées ou des polices rares.

**Puis‑je convertir un fichier PPT protégé par mot de passe ?**

Oui, si vous fournissez le mot de passe correct lors du chargement du fichier. L’absence ou l’erreur du mot de passe entraîne l’échec du chargement.

**Dois‑je supprimer le fichier PPT après la conversion ?**

Conservez l’original jusqu’à ce que vous ayez vérifié le PPTX dans les visualiseurs et les flux de travail qui vous importent. Cela vous fournit une copie de secours si une fonctionnalité héritée se convertit différemment.