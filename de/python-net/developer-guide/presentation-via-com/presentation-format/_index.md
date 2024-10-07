---
title: Präsentationsformat
type: docs
weight: 10
url: /python-net/presentation-format/
---

Aspose.Slides für Python über .NET bietet die [**PresentationFactory**](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/) Klasse, die verwendet wird, um das Präsentationsformat zu erhalten, bevor es überhaupt geladen wird.

Um das Präsentationsformat zu erhalten, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [**IPresentationInfo**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationinfo/) Klasse.
1. Holen Sie sich Informationen über das Präsentationsformat.

Im folgenden Beispiel haben wir das Präsentationsformat erhalten:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info(path + "HelloWorld.pptx")
if info.load_format == slides.LoadFormat.PPTX:
    print("PPTX")
elif info.load_format == slides.LoadFormat.UNKNOWN:
    print("UNKNOWN")
```