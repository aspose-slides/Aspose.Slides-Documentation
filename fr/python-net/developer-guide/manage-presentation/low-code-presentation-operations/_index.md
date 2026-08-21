---
title: Opérations de présentation low-code en Python
linktitle: API low-code
type: docs
weight: 50
url: /fr/python-net/low-code-presentation-operations/
keywords:
- API de présentation low-code
- convertir une présentation
- fusionner des présentations
- collecter des formes
- compresser une présentation
- supprimer les diapositives maîtres inutilisées
- supprimer les diapositives de mise en page inutilisées
- compresser les polices intégrées
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Utilisez l'API low-code Aspose.Slides en Python pour convertir et fusionner des présentations, collecter des formes et réduire la taille de la présentation."
---
## **Vue d'ensemble**

Le module [aspose.slides.lowcode](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/) fournit des classes d'assistance pour les opérations courantes sur les présentations. Ces assistants encapsulent les flux de travail du modèle d'objet fréquemment utilisés dans des méthodes ciblées, vous permettant de convertir ou fusionner des fichiers, de collecter des formes et de supprimer le contenu inutilisé avec moins de code.

Les assistants low-code sont les plus utiles lorsque l'opération s'applique à un fichier ou une présentation entière et que le flux de travail par défaut correspond à vos besoins. Utilisez le [Aspose.Slides object model](https://reference.aspose.com/slides/fr/python-net/aspose.slides/) complet lorsque vous avez besoin d'un contrôle granulaire sur les diapositives individuelles, les maîtres, les mises en page, les formes, les paramètres d'exportation ou les relations entre les éléments de la présentation.

Le tableau suivant résume les assistants disponibles :

| Assistant | Utilisation |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/convert/) | Convertir une présentation vers un autre format avec un appel direct fichier à fichier. |
| [Merger](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/merger/) | Combiner des fichiers de présentation complets du même format. |
| [Collect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/collect/) | Récupérer les formes de la présentation entière pour un traitement ou une analyse répétés. |
| [Compress](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/) | Supprimer les maîtres et mises en page inutilisés et réduire les données de polices intégrées. |

## **Convertir une présentation**

Utilisez [Convert.auto_by_extension](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/convert/auto_by_extension/) lorsque l'extension du fichier de sortie suffit à sélectionner le format d'exportation. La méthode ouvre la présentation source, détermine le format requis à partir du chemin de sortie et écrit le résultat.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

La classe [Convert](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/convert/) fournit également des méthodes dédiées pour la sortie PDF, SVG, JPEG, PNG et TIFF. Utilisez le modèle d'objet complet lorsque vous devez inspecter ou modifier la présentation avant l'exportation ou configurer une option d'exportation qui n'est pas exposée par l'assistant sélectionné. Consultez [Convertir une présentation](/python-net/convert-presentation/) pour les flux de travail et les options spécifiques à chaque format.

## **Fusionner des présentations**

Utilisez [Merger.process](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/merger/process/) pour combiner des fichiers de présentation complets en un seul appel. Les présentations d'entrée doivent avoir le même format de fichier.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

Cet assistant est approprié lorsque toutes les diapositives doivent être ajoutées à un seul résultat sans les sélectionner ou les remapper individuellement. Utilisez le modèle d'objet complet lorsque vous devez fusionner des diapositives sélectionnées, appliquer un maître ou une mise en page de destination, préserver explicitement les sections ou concilier des tailles de diapositives différentes. Consultez [Fusionner des présentations](/python-net/merge-presentation/) pour ces scénarios.

## **Collecter des formes**

Utilisez [Collect.shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/collect/shapes/) lorsque vous avez besoin d'une collection de toutes les formes d'une présentation. Ceci est utile lorsque le même ensemble sera filtré, compté ou traité plusieurs fois.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Utilisez des boucles de collecte directes lorsque l'ordre de traversée, la sortie anticipée, le filtrage avant le traitement ou le contrôle détaillé parent‑enfant sont importants.

## **Compresser le contenu de la présentation**

La classe [Compress](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/) peut supprimer les éléments structurels inutilisés et réduire les données de polices intégrées :

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) supprime les diapositives de mise en page qui ne sont référencées par aucune diapositive normale.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) supprime les diapositives maîtres qui ne sont plus utilisées.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) supprime les caractères inutilisés des polices intégrées.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Supprimez d'abord les mises en page inutilisées, puis les maîtres inutilisés afin qu'un maître devenu non référencé après le nettoyage des mises en page puisse également être supprimé. Enregistrez la présentation optimisée dans un nouveau fichier si vous avez besoin ultérieurement des maîtres, mises en page ou données de polices intégrées complètes d'origine. Pour plus de détails, consultez [Maître de diapositive](/python-net/slide-master/) et [Police intégrée](/python-net/embedded-font/).

## **FAQ**

**Quand devrais-je utiliser l'API low-code au lieu du modèle d'objet complet ?**

Utilisez les assistants low-code lorsqu'une opération standard s'applique à un fichier ou une présentation complète et ne nécessite pas de contrôle détaillé sur les éléments individuels. Utilisez le modèle d'objet complet lorsque vous devez sélectionner des diapositives spécifiques, contrôler les relations entre maîtres et mises en page, inspecter l'état intermédiaire ou configurer un comportement que l'assistant n'expose pas.

**Le Merger peut-il combiner des présentations dans différents formats de fichier ?**

Non. [Merger.process](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/merger/process/) nécessite que les présentations d'entrée soient dans le même format. Convertissez d'abord les fichiers d'entrée vers un format commun, par exemple avec [Convert.auto_by_extension](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/convert/auto_by_extension/), puis fusionnez les fichiers convertis.

**Que comprend Collect.shapes ?**

[Collect.shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/collect/shapes/) récupère les formes de la présentation afin qu'elles puissent être conservées, filtrées, comptées ou parcourues plusieurs fois. Utilisez des boucles de collecte directes lorsque vous avez besoin d'un contrôle précis sur les types de diapositives ou les objets imbriqués visités.

**Compress rend-il toujours le fichier de présentation plus petit ?**

Pas nécessairement. Le résultat dépend de la présence ou non de mises en page inutilisées, de maîtres inutilisés ou de polices intégrées contenant des caractères inutilisés. Si aucun de ces éléments n'est présent, les opérations [Compress](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/) correspondantes peuvent ne pas réduire la taille du fichier.

**Les modifications apportées par Compress sont-elles enregistrées automatiquement ?**

Non. Ces assistants opèrent sur l'objet [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) chargé en mémoire. Après avoir exécuté [Compress](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/), appelez [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/) pour écrire le résultat.

## **Articles associés**

- [Convertir une présentation](/python-net/convert-presentation/)
- [Fusionner des présentations](/python-net/merge-presentation/)
- [Maître de diapositive](/python-net/slide-master/)
- [Gérer la zone de texte](/python-net/manage-textbox/)
- [Police intégrée](/python-net/embedded-font/)