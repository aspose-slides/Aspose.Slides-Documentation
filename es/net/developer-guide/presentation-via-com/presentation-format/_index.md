---
title: Formato de Presentación
type: docs
weight: 10
url: /net/presentation-format/
---

Aspose.Slides para .NET proporciona la clase [**PresentationFactory** ](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory) que se utiliza para obtener el formato de presentación antes de cargarlo.

Para obtener el formato de presentación, siga los pasos a continuación:

1. Cree una instancia de la clase [**IPresentationInfo** ](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo).
1. Obtenga información sobre el formato de presentación.

En el ejemplo dado a continuación, hemos obtenido el formato de presentación:

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