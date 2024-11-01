---
title: تنسيق العرض
type: docs
weight: 10
url: /ar/net/presentation-format/
---

تقدم Aspose.Slides لـ .NET فئة [**PresentationFactory** ](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory) التي تُستخدم للحصول على تنسيق العرض قبل حتى التحميل.

للحصول على تنسيق العرض. يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [**IPresentationInfo** ](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo).
1. الحصول على معلومات حول تنسيق العرض.

في المثال المعطى أدناه، حصلنا على تنسيق العرض:

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