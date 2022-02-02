---
title: ISequence Class
type: docs
weight: 300
url: /python-net/api-reference/aspose.slides.animation/isequence/
---

Represents sequence (collection of effects).

**Namespace:** [aspose.slides.animation](/slides/python-net/api-reference/aspose.slides.animation/)

**Full Class Name:** aspose.slides.animation.ISequence



The ISequence type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|count|Returns the number of effects in a sequense.<br/>            Read-only|
|trigger_shape|Returns or sets shape target for INTERACTIVE sequence.<br/>            If sequence is not interactive then returns null.<br/>            Read/write [IShape](/slides/python-net/api-reference/aspose.slides/ishape/).|
|as_ienumerable|Allows to get base IEnumerable interface.<br/>            Read-only list.|
## **Indexer**
|**Name**|**Description**|
| :- | :- |
|[index]|Returns an effect at the specified index.|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|add_effect(shape, effect_type, subtype, trigger_type)|Add new effect to the end of sequence.|
|add_effect(paragraph, effect_type, subtype, trigger_type)|Add new animation effect for paragraph to the end of sequence.|
|add_effect(chart, type, index, effect_type, subtype, trigger_type)|Adds the new chart animation effect for category or series to the end of sequence.|
|add_effect(chart, type, series_index, categories_index, effect_type, subtype, trigger_type)|Adds the new chart animation effect for elements in category or series to the end of sequence.|
|remove(item)|Removes specified effect from a collection.|
|remove_at(index)|Removes an effect from a collection.|
|clear()|Removes all effects from a collection.|
|remove_by_shape(shape)|Remove effect for the specified shape.|
|get_effects_by_shape(shape)|Returns array of effects for the specified shape.|
|get_effects_by_paragraph(paragraph)|Returns array of effects for the specified paragraph.|
|get_count(shape)|Returns count of effects for the specified shape.|
