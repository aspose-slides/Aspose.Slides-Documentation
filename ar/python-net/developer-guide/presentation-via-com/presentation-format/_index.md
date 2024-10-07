---
title: صيغة العرض
type: docs
weight: 10
url: /python-net/presentation-format/
---

توفر Aspose.Slides لـ Python عبر .NET [**PresentationFactory**](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/) الذي يستخدم للحصول على صيغة العرض قبل تحميلها.

للحصول على صيغة العرض، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [**IPresentationInfo**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationinfo/) الفئة.
1. الحصول على معلومات حول صيغة العرض.

في المثال الموضح أدناه، حصلنا على صيغة العرض:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info(path + "HelloWorld.pptx")
if info.load_format == slides.LoadFormat.PPTX:
    print("PPTX")
elif info.load_format == slides.LoadFormat.UNKNOWN:
    print("UNKNOWN")
```