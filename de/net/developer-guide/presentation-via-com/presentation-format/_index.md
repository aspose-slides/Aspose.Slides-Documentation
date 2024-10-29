---
title: Präsentationsformat
type: docs
weight: 10
url: /de/net/presentation-format/
---

Aspose.Slides für .NET bietet die [**PresentationFactory** ](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory)Klasse, die verwendet wird, um das Präsentationsformat zu erhalten, bevor es überhaupt geladen wird.

Um das Präsentationsformat zu erhalten, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [**IPresentationInfo** ](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo)Klasse.
2. Holen Sie sich Informationen über das Präsentationsformat.

Im unten stehenden Beispiel haben wir das Präsentationsformat erhalten:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("HelloWorld.pptx");
switch (info.LoadFormat)
{
    case LoadFormat.Pptx:
        {
            break;
        }

    case LoadFormat.Unknown:
        {
            break;
        }
}
```