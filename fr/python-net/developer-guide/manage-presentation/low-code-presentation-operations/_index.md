---
title: Opérations de présentation Low-Code en Python
linktitle: API Low-Code
type: docs
weight: 50
url: /fr/python-net/low-code-presentation-operations/
keywords:
- API présentation low-code
- convertir une présentation
- fusionner des présentations
- collecter des formes
- compresser la présentation
- supprimer les diapositives maîtres inutilisées
- supprimer les diapositives de mise en page inutilisées
- compresser les polices intégrées
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Utilisez l'API low-code d'Aspose.Slides en Python pour convertir et fusionner des présentations, collecter des formes et réduire la taille des présentations."
---
## **Aperçu**

Le module [aspose.slides.lowcode](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/) fournit des classes d’assistance pour les opérations courantes sur les présentations. Ces assistants encapsulent des flux de travail fréquemment utilisés du modèle d’objets dans des méthodes ciblées, de sorte que vous pouvez convertir ou fusionner des fichiers, collecter des formes et supprimer le contenu inutilisé avec moins de code.

Les assistants low‑code sont les plus utiles lorsque l’opération s’applique à un fichier ou une présentation entiers et que le flux de travail par défaut correspond à vos besoins. Utilisez le modèle d’objet complet [Aspose.Slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/) lorsque vous avez besoin d’un contrôle granulaire sur des diapositives individuelles, des maîtres, des mises en page, des formes, des paramètres d’exportation ou les relations entre les éléments de la présentation.

Le tableau suivant résume les assistants disponibles :

| Assistant | Utilisation |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/convert/) | Convertir une présentation vers un autre format avec un appel direct fichier‑à‑fichier. |
| [Merger](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/merger/) | Combiner des fichiers de présentation complets du même format. |
| [Collect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/collect/) | Récupérer les formes de l’ensemble de la présentation pour un traitement ou une analyse répétés. |
| [Compress](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/) | Supprimer les maîtres et les mises en page inutilisés et réduire les données de polices intégrées. |

## **Convertir une présentation**

Utilisez [Convert.auto_by_extension](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/convert/auto_by_extension/) lorsque l’extension du fichier de sortie suffit à sélectionner le format d’exportation. La méthode ouvre la présentation source, détermine le format requis à partir du chemin de sortie et écrit le résultat.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

La classe [Convert](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/convert/) propose également des méthodes dédiées pour la sortie PDF, SVG, JPEG, PNG et TIFF. Utilisez le modèle d’objet complet lorsque vous devez inspecter ou modifier la présentation avant l’exportation ou configurer une option d’exportation qui n’est pas exposée par l’assistant sélectionné. Voir [Convert Presentation](/slides/fr/python-net/convert-presentation/) pour les flux de travail et options spécifiques à chaque format.

## **Fusionner des présentations**

Utilisez [Merger.process](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/merger/process/) pour combiner des fichiers de présentation complets en un seul appel. Les présentations d’entrée doivent avoir le même format de fichier.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

L’assistant est approprié lorsque toutes les diapositives doivent être ajoutées à un résultat unique sans les sélectionner ou les remapper individuellement. Utilisez le modèle d’objet complet lorsque vous devez fusionner des diapositives sélectionnées, appliquer un maître ou une mise en page de destination, préserver explicitement les sections, ou concilier des tailles de diapositives différentes. Voir [Merge Presentations](/slides/fr/python-net/merge-presentation/) pour ces scénarios.

## **Collecter les formes**

Utilisez [Collect.shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/collect/shapes/) lorsque vous avez besoin d’une collection de toutes les formes d’une présentation. Cela est utile lorsque le même ensemble sera filtré, compté ou traité plusieurs fois.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Utilisez des boucles de collecte directes lorsque l’ordre de traversée, la sortie anticipée, le filtrage avant traitement ou le contrôle détaillé parent‑enfant sont importants.

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

Supprimez d’abord les mises en page inutilisées, puis les maîtres inutilisés, afin qu’un maître devenu non référencé après le nettoyage des mises en page puisse également être supprimé. Enregistrez la présentation optimisée dans un nouveau fichier si vous devez éventuellement récupérer les maîtres, les mises en page ou les données complètes de polices intégrées d’origine. Pour plus de détails, consultez [Slide Master](/slides/fr/python-net/slide-master/) et [Embedded Font](/slides/fr/python-net/embedded-font/).

## **FAQ**

**Quand faut‑il utiliser l’API low‑code plutôt que le modèle d’objet complet ?**

Utilisez les assistants low‑code lorsqu’une opération standard s’applique à un fichier ou une présentation complète et ne nécessite pas de contrôle détaillé sur des éléments individuels. Utilisez le modèle d’objet complet lorsque vous devez sélectionner des diapositives spécifiques, contrôler les relations entre maîtres et mises en page, inspecter l’état intermédiaire ou configurer un comportement que l’assistant n’expose pas.

**Le Merger peut‑il combiner des présentations dans des formats de fichier différents ?**

Non. [Merger.process](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/merger/process/) exige que les présentations d’entrée soient dans le même format. Convertissez d’abord les fichiers d’entrée vers un format commun, par exemple avec [Convert.auto_by_extension](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/convert/auto_by_extension/), puis fusionnez les fichiers convertis.

**Que comprend Collect.shapes ?**

[Collect.shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/collect/shapes/) récupère les formes de la présentation afin qu’elles puissent être conservées, filtrées, comptées ou parcourues plusieurs fois. Utilisez des boucles de collecte directes lorsque vous avez besoin d’un contrôle précis sur les types de diapositives ou les objets imbriqués à visiter.

**Compress réduit‑il toujours la taille du fichier de présentation ?**

Pas nécessairement. Le résultat dépend de la présence ou non de mises en page inutilisées, de maîtres inutilisés ou de polices intégrées contenant des caractères inutilisés. Si aucun de ces éléments n’est présent, les opérations correspondantes de [Compress](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/) peuvent ne pas réduire la taille du fichier.

**Les modifications apportées par Compress sont‑elles enregistrées automatiquement ?**

Non. Ces assistants opèrent sur l’objet [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) chargé en mémoire. Après avoir exécuté [Compress](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/), appelez [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/) pour écrire le résultat.

## **Articles associés**

- [Convert Presentation](/slides/fr/python-net/convert-presentation/)
- [Merge Presentations](/slides/fr/python-net/merge-presentation/)
- [Slide Master](/slides/fr/python-net/slide-master/)
- [Manage Text Box](/slides/fr/python-net/manage-textbox/)
- [Embedded Font](/slides/fr/python-net/embedded-font/)