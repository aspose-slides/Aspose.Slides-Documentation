---
title: Формат презентации
type: docs
weight: 10
url: /ru/python-net/presentation-format/
---

Aspose.Slides для Python через .NET предоставляет класс [**PresentationFactory** ](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/), который используется для получения формата презентации даже до ее загрузки.

Чтобы получить формат презентации, выполните следующие шаги:

1. Создайте экземпляр класса [**IPresentationInfo** ](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationinfo/).
2. Получите информацию о формате презентации.

В приведенном ниже примере мы получили формат презентации:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info(path + "HelloWorld.pptx")
if info.load_format == slides.LoadFormat.PPTX:
    print("PPTX")
elif info.load_format == slides.LoadFormat.UNKNOWN:
    print("UNKNOWN")
```