---
title: Format de Présentation
type: docs
weight: 10
url: /fr/net/presentation-format/
---

Aspose.Slides pour .NET fournit la classe [**PresentationFactory** ](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory) qui est utilisée pour obtenir le format de présentation avant même de le charger.

Pour obtenir le format de présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [**IPresentationInfo** ](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo).
1. Obtenez des informations sur le format de présentation.

Dans l'exemple ci-dessous, nous avons obtenu le format de présentation :

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