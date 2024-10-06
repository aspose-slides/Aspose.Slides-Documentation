---
title: Format de Présentation
type: docs
weight: 10
url: /python-net/presentation-format/
---

Aspose.Slides pour Python via .NET fournit la classe [**PresentationFactory** ](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/) qui est utilisée pour obtenir le format de présentation avant même de le charger.

Afin d'obtenir le format de présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [**IPresentationInfo** ](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationinfo/).
1. Obtenez des informations sur le format de présentation.

Dans l'exemple ci-dessous, nous avons obtenu le format de présentation :

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info(path + "HelloWorld.pptx")
if info.load_format == slides.LoadFormat.PPTX:
    print("PPTX")
elif info.load_format == slides.LoadFormat.UNKNOWN:
    print("UNKNOWN")
```