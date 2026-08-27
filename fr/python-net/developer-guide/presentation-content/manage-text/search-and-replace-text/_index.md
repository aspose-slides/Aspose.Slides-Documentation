---
title: Recherche et remplacement de texte dans les présentations PowerPoint avec Python
linktitle: Recherche et remplacement de texte
type: docs
weight: 55
url: /fr/python-net/search-and-replace-text/
keywords:
- recherche de texte
- mise en évidence du texte
- remplacement de texte
- expression régulière
- cadre de texte
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Recherchez, mettez en évidence et remplacez du texte dans les présentations PowerPoint avec Aspose.Slides pour Python via .NET."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET peut rechercher, mettre en évidence et remplacer du texte dans un cadre de texte individuel ou dans toute la présentation. Ces capacités sont utiles pour la révision, la rédaction, les vérifications de terminologie, le nettoyage de modèles et d’autres flux de travail automatisés de traitement de documents.

Dans les premiers exemples ci‑dessous, nous utilisons un fichier nommé "sample.pptx", qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d'exemple](sample_text.png)

## **Choisir la portée de la recherche**

Utilisez les méthodes de [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) pour limiter une opération à un seul cadre de texte. Utilisez les méthodes de [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour traiter tout le texte applicable de la présentation.

| Opération | Un cadre de texte | Toute la présentation |
|---|---|---|
| Highlight literal text | [TextFrame.highlight_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/highlight_text/) |
| Highlight regular-expression matches | [TextFrame.highlight_regex](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/highlight_regex/) |
| Replace literal text | [TextFrame.replace_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/replace_text/) |
| Replace regular-expression matches | [TextFrame.replace_regex](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/replace_regex/) |

## **Configurer la correspondance de texte**

Pour les opérations de texte littéral, utilisez [TextSearchOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textsearchoptions/) pour contrôler la correspondance :

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textsearchoptions/whole_words_only/) limite les correspondances aux mots complets.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textsearchoptions/case_sensitive/) contrôle si la casse des caractères doit correspondre.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textsearchoptions/include_notes/) inclut les notes de diapositive dans les opérations de recherche, de remplacement et de mise en évidence au niveau de la présentation.

Les opérations d’expression régulière utilisent une chaîne de motif, de sorte que les règles de correspondance telles que la sensibilité à la casse et les frontières de mots sont définies par l’expression elle‑même.

## **Identifier le propriétaire d'un cadre de texte**

Les flux de traitement de texte génériques reçoivent souvent un [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) lors de la recherche, du remplacement, de la validation ou de l’exportation de texte. Utilisez [TextFrame.parent_shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/parent_shape/) et [TextFrame.parent_cell](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/parent_cell/) pour déterminer quel objet de la présentation possède le cadre de texte.

Les valeurs attendues dépendent du propriétaire :

| Propriétaire du cadre de texte | `parent_shape` | `parent_cell` |
|---|---|---|
| Une AutoShape ou une autre forme contenant du texte | La [Shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/) propriétaire | `None` |
| Une cellule de tableau | `None` | La [Cell](https://reference.aspose.com/slides/fr/python-net/aspose.slides/cell/) propriétaire |

Les deux propriétés sont des propriétés de navigation en lecture seule. Les lire ne déplace pas le cadre de texte et ne change pas son propriétaire. Le code générique doit vérifier les deux valeurs pour `None` et gérer la possibilité qu’aucun propriétaire ne soit disponible.

L’exemple suivant utilise [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/fr/python-net/aspose.slides.util/slideutil/get_all_text_frames/) pour parcourir les cadres de texte d’une présentation. Pour les formes, il indique le nom de la forme, le type d’exécution Python et la diapositive contenant. Pour les cellules de tableau, il indique les coordonnées de colonne et de ligne (indice zéro) et la diapositive contenant.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

Pour le contenu SmartArt, parcourez les formes dans [SmartArtNode.shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides.smartart/smartartnode/shapes/) et accédez à chaque [ISmartArtShape.text_frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides.smartart/ismartartshape/text_frame/). Le cadre de texte peut être retracé jusqu’à sa forme associée via [TextFrame.parent_shape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/parent_shape/), tandis que [TextFrame.parent_cell](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/parent_cell/) est `None`. Par conséquent, la branche de forme dans l’exemple gère également le texte des nœuds SmartArt.

## **Mettre en évidence du texte**

Utilisez la méthode [TextFrame.highlight_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/highlight_text/) pour mettre en évidence les correspondances de texte littéral dans un cadre de texte. Passez un [TextSearchOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textsearchoptions/) pour contrôler la recherche.

L’exemple de code ci‑dessous met en évidence toutes les occurrences des caractères **"try"** puis ne met en évidence que le mot complet **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Mettre en évidence chaque occurrence de "try" dans le cadre de texte.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Mettre en évidence uniquement le mot complet "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Le texte mis en évidence](highlighted_text.png)

## **Mettre en évidence du texte à l’aide d’expressions régulières**

La méthode [TextFrame.highlight_regex](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/highlight_regex/) met en évidence les correspondances de texte trouvées par une expression régulière dans un cadre de texte.

Le code suivant met en évidence tous les mots contenant sept caractères ou plus :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

Le résultat :

![Le texte mis en évidence avec l’expression régulière](highlighted_text_using_regex.png)

## **Mettre en évidence du texte dans toute la présentation**

Utilisez [Presentation.highlight_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/highlight_text/) et [Presentation.highlight_regex](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/highlight_regex/) pour rechercher tous les cadres de texte applicables d’une présentation. L’exemple suivant met en évidence un terme littéral et toutes les adresses e‑mail :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Remplacer le texte dans un cadre de texte**

Utilisez [TextFrame.replace_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/replace_text/) pour le texte littéral et [TextFrame.replace_regex](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/replace_regex/) pour le remplacement basé sur un motif. Ces méthodes mettent à jour le texte correspondant à l’intérieur du cadre de texte existant, ce qui conserve le formatage des portions environnantes au lieu de reconstruire le cadre de texte à partir d’une chaîne brute.

L’exemple suivant uniformise une variante orthographique puis remplace les libellés de version :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

Si une correspondance couvre des portions avec un formatage différent, examinez le résultat pour confirmer quel formatage doit s’appliquer au texte de remplacement.

## **Remplacer le texte dans toute la présentation**

Utilisez [Presentation.replace_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/replace_text/) et [Presentation.replace_regex](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/replace_regex/) pour appliquer les mêmes opérations sur l’ensemble de la présentation. Cela est utile pour le nettoyage de modèles, les mises à jour de terminologie et la rédaction.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **FAQ**

**Comment rechercher uniquement une zone de texte au lieu de toute la présentation ?**

Obtenez le cadre de texte de la forme et appelez [TextFrame.highlight_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/replace_text/) ou [TextFrame.replace_regex](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/replace_regex/) sur ce cadre de texte. Les méthodes au niveau de la présentation traitent toutes les cadres de texte applicables.

**Comment correspondre à des mots complets avec la bonne capitalisation ?**

Définissez [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textsearchoptions/whole_words_only/) et [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textsearchoptions/case_sensitive/) sur `True`, puis passez les options à une méthode de mise en évidence ou de remplacement de texte littéral. Pour les expressions régulières, définissez les limites de mots et la sensibilité à la casse dans le motif même.

**La recherche et le remplacement peuvent‑ils inclure le texte des notes de diapositive ?**

Oui. Définissez [TextSearchOptions.include_notes](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textsearchoptions/include_notes/) sur `True` lors de l’utilisation d’une opération de texte littéral au niveau de la présentation.

**Le remplacement du texte préserve‑t‑il son formatage ?**

[TextFrame.replace_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/replace_text/) et [TextFrame.replace_regex](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/replace_regex/) modifient le texte correspondant à l’intérieur du cadre de texte existant et conservent le formatage des portions environnantes. Si une correspondance s’étend sur des parties avec un formatage différent, inspectez le résultat pour vous assurer que le remplacement utilise le style souhaité.