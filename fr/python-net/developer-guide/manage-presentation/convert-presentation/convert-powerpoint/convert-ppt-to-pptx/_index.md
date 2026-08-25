---
title: Convertir PPT en PPTX avec Python
linktitle: PPT vers PPTX
type: docs
weight: 20
url: /fr/python-net/convert-ppt-to-pptx/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- PPT vers PPTX
- enregistrer PPT en tant que PPTX
- exporter PPT en PPTX
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Convertissez les fichiers PPT hérités en PPTX avec Python et Aspose.Slides. Inclut des exemples de conversion d'un seul fichier et par lots, de gestion des erreurs et des notes sur la fidélité."
---
## **Vue d'ensemble**

PPT est le format binaire hérité de PowerPoint, tandis que PPTX est le format Open XML plus récent. Aspose.Slides for Python via .NET peut charger un fichier PPT et l'enregistrer au format PPTX sans Microsoft PowerPoint. Cet article montre comment convertir un fichier ou un répertoire de fichiers et explique ce qu'il faut vérifier après la conversion.

## **Convertir un fichier PPT en PPTX**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) , puis appelez [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/) avec [SaveFormat.PPTX](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveformat/). L'instruction `with` libère la présentation et libère ses ressources lorsque le bloc se termine.

```python
import aspose.slides as slides

# Charger la présentation PPT héritée.
with slides.Presentation("presentation.ppt") as presentation:
    # Enregistrer la présentation au format PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

L'extension du fichier ne sélectionne pas le format de sortie par elle-même ; l'argument [SaveFormat.PPTX](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveformat/) le fait. Conservez des chemins d'entrée et de sortie différents si vous devez conserver le fichier PPT original.

## **Convertir plusieurs fichiers PPT**

L'exemple suivant convertit chaque fichier `.ppt` dans un répertoire. Chaque fichier est traité indépendamment, de sorte qu'une conversion échouée n'arrête pas le reste du lot.

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

Pour les charges de travail en production, consignez l'exception complète, décidez si un fichier de sortie existant peut être écrasé, et écrivez les noms des fichiers échoués dans une file d'attente de réessai ou de révision. Les fichiers corrompus, les fichiers protégés par mot de passe ouverts sans le mot de passe requis, les chemins inaccessibles et le contenu non pris en charge peuvent tous provoquer un échec de conversion. Consultez [Password-Protected Presentations](/slides/fr/python-net/password-protected-presentation/) pour charger des fichiers cryptés.

## **Fidélité et fonctionnalités héritées**

La conversion préserve généralement les diapositives, les masques, les dispositions, le texte, les formes, les images, les tableaux et les graphiques. Cependant, PPT et PPTX ne représentent pas chaque fonctionnalité de la même manière exacte. Une fonctionnalité héritée qui n'a pas d'équivalent PPTX, ou qui n'est pas prise en charge par la bibliothèque, peut être normalisée, omise ou affichée différemment.

Vérifiez le fichier converti lorsqu'il contient des animations, des transitions, des objets OLE incorporés ou liés, des contrôles ActiveX, des médias incorporés, des polices rares ou des macros VBA. Un fichier PPTX ordinaire n'est pas un format prenant en charge les macros, utilisez donc un flux de travail approprié pour les macros lorsque VBA doit rester disponible. Vérifiez également que les polices requises et les ressources externes sont présentes dans l'environnement où la présentation convertie sera ouverte ou rendue.

Pour les documents importants, rouvrez le PPTX généré par programme et inspectez le nombre de diapositives clés et le contenu, puis comparez son apparence et son comportement en diaporama dans le visualiseur prévu. Ne considérez pas un appel réussi à [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/) comme une preuve que chaque fonctionnalité héritée possède une représentation PPTX exacte.

## **Quand utiliser PPTX**

Utilisez PPTX lorsque la présentation sera éditée dans les versions actuelles de PowerPoint, échangée avec des systèmes qui travaillent avec des paquets Open XML, ou stockée dans un format plus facile à inspecter et à récupérer que le PPT binaire hérité. Conservez le PPT original comme copie d'archivage ou de sauvegarde jusqu'à ce que la présentation convertie ait passé vos contrôles de fidélité.

Si vous avez besoin de PDF, HTML, images, XPS ou d'un autre type de sortie, utilisez les consignes spécifiques au format dans [Convert Presentations to Multiple Formats](/slides/fr/python-net/convert-presentation/) plutôt que de supposer que toutes les cibles conservent les fonctionnalités éditables de PowerPoint.

## **Convertisseur en ligne**

Pour un fichier ponctuel ou une comparaison rapide, vous pouvez utiliser le [online PPT to PPTX converter](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx). Pour des conversions répétées, un traitement par lots ou une gestion des erreurs au niveau de l'application, utilisez l'API Python.

## **Articles liés**

- [PPT vs PPTX](/slides/fr/python-net/ppt-vs-pptx/)
- [Save Presentations in Python](/slides/fr/python-net/save-presentation/)
- [Supported File Formats](/slides/fr/python-net/supported-file-formats/)
- [Open Presentations in Python](/slides/fr/python-net/open-presentation/)

## **FAQ**

**Puis-je convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui. Aspose.Slides for Python via .NET charge et enregistre les fichiers de présentation sans nécessiter Microsoft PowerPoint.

**La conversion de PPT en PPTX préservera-t-elle tout le contenu exactement ?**

Elle préserve le contenu de présentation courant, mais la fidélité exacte n'est pas garantie pour chaque fonctionnalité héritée ou non prise en charge. Examinez le fichier généré lorsqu'il contient des macros, des objets OLE ou ActiveX, du multimédia, des animations spécialisées ou des polices rares.

**Puis-je convertir un fichier PPT protégé par mot de passe ?**

Oui, si vous fournissez le mot de passe correct lors du chargement du fichier. Un mot de passe manquant ou incorrect entraîne l'échec de l'opération de chargement.

**Devrais-je supprimer le fichier PPT après la conversion ?**

Conservez l'original jusqu'à ce que vous ayez vérifié le PPTX dans les visualiseurs et les flux de travail qui vous importent. Cela fournit une copie de sauvegarde si une fonctionnalité héritée est convertie différemment.