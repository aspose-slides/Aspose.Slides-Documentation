---
title: Формат презентации
type: docs
weight: 10
url: /net/presentation-format/
---

Aspose.Slides для .NET предоставляет класс [**PresentationFactory** ](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory), который используется для получения формата презентации до её загрузки.

Чтобы получить формат презентации, выполните следующие шаги:

1. Создайте экземпляр класса [**IPresentationInfo** ](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo).
1. Получите информацию о формате презентации.

В приведенном ниже примере мы получили формат презентации:

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