---
title: Formato de Presentación
type: docs
weight: 10
url: /es/python-net/presentation-format/
---

Aspose.Slides para Python a través de .NET proporciona la clase [**PresentationFactory**](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/) que se utiliza para obtener el formato de presentación incluso antes de cargarlo.

Para obtener el formato de presentación, siga los pasos a continuación:

1. Cree una instancia de la clase [**IPresentationInfo**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationinfo/).
2. Obtenga información sobre el formato de presentación.

En el ejemplo dado a continuación, hemos obtenido el formato de presentación:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info(path + "HelloWorld.pptx")
if info.load_format == slides.LoadFormat.PPTX:
    print("PPTX")
elif info.load_format == slides.LoadFormat.UNKNOWN:
    print("UNKNOWN")
```