---
title: خصائص عرض الشريحة
type: docs
url: /ar/python-net/presentation-view-properties/
keywords: "عارض PowerPoint، خصائص العارض، عروض PowerPoint، Python، Aspose.Slides لـ Python عبر .NET"
description: "خصائص عارض عروض PowerPoint في Python"
---

{{% alert color="primary" %}} 

تتكون العرضة العادية من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموقع المناطق المختلفة للمحتوى. هذه المعلومات تسمح للتطبيق بحفظ حالة العرض في الملف، بحيث عندما يتم إعادة فتحه، يكون العرض في نفس الحالة كما كان عند آخر حفظ للعروض.

تم إضافة خاصية [**IViewProperties.NormalViewProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/iviewproperties/) لتوفير الوصول إلى خصائص العرض العادي للعروض. 

تمت إضافة واجهات [**INormalViewProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewproperties/) و[**INormalViewRestoredProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewrestoredproperties/) وسياقاتها الفرعية، وفئة [**SplitterBarStateType**](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) الفرعية.

{{% /alert %}} 



## **حول INormalViewProperties** 

تمثل خصائص العرض العادي.

تحدد خاصية **ShowOutlineIcons** ما إذا كان يجب على التطبيق عرض الرموز عند عرض محتوى المخطط في أي من مناطق محتوى وضع العرض العادي.

تحدد خاصية **SnapVerticalSplitter** ما إذا كان ينبغي أن ينقر الفاصل العمودي إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

تحدد خاصية **PreferSingleView** ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة كاملة على عرض قياسي عادي مع ثلاث مناطق محتوى. إذا تم تمكين ذلك، قد يختار التطبيق عرض واحدة من مناطق المحتوى في النافذة بأكملها.

تحدد خصائص **VerticalBarState** و**HorizontalBarState** الحالة التي يجب عرض شريط الفاصل الأفقي أو العمودي فيها. يفصل شريط الفاصل الأفقي الشريحة عن منطقة المحتوى أسفل الشريحة، ويفصل شريط الفاصل العمودي الشريحة عن منطقة المحتوى الجانبية. القيم الممكنة هي: **SplitterBarStateType.Minimized، SplitterBarStateType.Maximized** و**SplitterBarStateType.Restored.**

تحدد خصائص **RestoredLeft** و**RestoredTop** حجم منطقة الشريحة العليا أو الجانبية من العرض العادي، عندما يتم تطبيق قيمة **SplitterBarStateType.Restored** على **VerticalBarState** و**HorizontalBarState** على التوالي.



## **حول INormalViewRestoredProperties** 

تحدد حجم منطقة الشريحة ((العرض عندما تكون طفلاً لـ RestoredTop، الارتفاع عندما تكون طفلاً لـ RestoredLeft) من العرض العادي، عندما تكون المنطقة بحجم مستعيد متغير (لا مصغرة ولا مكبرة). 

تحدد خاصية **DimensionSize** حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ restoredTop، الارتفاع عندما تكون طفلاً لـ restoredLeft).

تحدد خاصية **AutoAdjust** ما إذا كان يجب أن يعوض حجم منطقة المحتوى الجانبية عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

يوضح المثال أدناه كيف يمكنك الوصول إلى خصائص **ViewProperties.NormalViewProperties** لعروض تقديمية.

```py
import aspose.slides as slides

#Instantiate a presentation object that represents a presentation file
with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```




## **تعيين قيمة الزوم الافتراضية**
تدعم Aspose.Slides لـ Python عبر .NET الآن تعيين قيمة الزوم الافتراضية للعروض التقديمية بحيث عند فتح العرض، يتم تعيين الزوم بالفعل. يمكن القيام بذلك عن طريق تعيين [**view_properties**](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) لعرض تقديمي. يمكن تعيين خصائص عرض الشريحة وكذلك [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) برمجياً. في هذا الموضوع، سنرى مع مثال كيفية تعيين خصائص العرض للعروض التقديمية في Aspose.Slides.

لتعيين خصائص العرض، يرجى اتباع الخطوات أدناه:

1. إنشاء نموذج من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 
1. تعيين خصائص العرض [Properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) للعرض التقديمي
1. كتابة العرض التقديمي كملف PPTX

في المثال المعطى أدناه، قمنا بتعيين قيمة الزوم لعرض الشريحة وكذلك لعرض الملاحظات.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Setting View Properties of Presentation
    presentation.view_properties.slide_view_properties.scale = 100 # Zoom value in percentages for slide view
    presentation.view_properties.notes_view_properties.scale = 100 # Zoom value in percentages for notes view 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```



## **تعيين خصائص العرض**
لتعيين خصائص العرض، يرجى اتباع الخطوات أدناه:

1. إنشاء نموذج من فئة Presentation.
1. تعيين خصائص العرض للعرض التقديمي.
1. كتابة العرض التقديمي كملف PPTX.

في المثال المعطى أدناه، قمنا بتعيين قيمة الزوم لعرض الشريحة وكذلك لعرض الملاحظات.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Setting View Properties of Presentation
    presentation.view_properties.slide_view_properties.scale = 100 # Zoom value in percentages for slide view
    presentation.view_properties.notes_view_properties.scale = 100 # Zoom value in percentages for notes view 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```