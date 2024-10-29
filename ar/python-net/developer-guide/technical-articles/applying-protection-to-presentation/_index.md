---
title: تطبيق الحماية على العروض التقديمية
type: docs
weight: 70
url: /ar/python-net/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

الاستخدام الشائع لـ Aspose.Slides هو إنشاء وتحديث وحفظ عروض Microsoft PowerPoint 2007 (PPTX) كجزء من سير عمل تلقائي. يحصل مستخدمو التطبيق الذي يستخدم Aspose.Slides بهذه الطريقة على الوصول إلى العروض الناتجة. تعتبر حمايتها من التعديل قضية شائعة. من المهم أن تحتفظ العروض التلقائية بالتنسيق والمحتوى الأصلي.

تشرح هذه المقالة كيفية [إنشاء العروض والشرائح](/slides/ar/python-net/applying-protection-to-presentation/) وكيف يمكن لـ Aspose.Slides للغة بايثون عبر .NET [تطبيق الحماية على](/slides/ar/python-net/applying-protection-to-presentation/)، ثم [إزالتها من](/slides/ar/python-net/applying-protection-to-presentation/) العرض التقديمي. هذه الميزة فريدة من نوعها بالنسبة لـ Aspose.Slides، وفي وقت كتابة هذه المقالة، ليست متاحة في Microsoft PowerPoint. إنها تمنح المطورين وسيلة للتحكم في كيفية استخدام العروض التي تقوم تطبيقاتهم بإنشائها.

{{% /alert %}} 
## **تكوين الشريحة**
تتكون شريحة PPTX من عدد من المكونات مثل الأشكال التلقائية، والجداول، وكائنات OLE، والأشكال المجمعة، وإطارات الصور، وإطارات الفيديو، والموصلات والعناصر المختلفة الأخرى المتاحة لبناء عرض تقديمي.

في Aspose.Slides للغة بايثون عبر .NET، يتم تحويل كل عنصر على الشريحة إلى كائن Shape. بعبارة أخرى، كل عنصر على الشريحة هو إما كائن Shape أو كائن مشتق من كائن Shape.

بنية PPTX معقدة، لذا على عكس PPT، حيث يمكن استخدام قفل عام لجميع أنواع الأشكال، هناك أنواع مختلفة من الأقفال لكل نوع شكل. فئة BaseShapeLock هي فئة القفل العامة لـ PPTX. الأنواع التالية من الأقفال مدعومة في Aspose.Slides للغة بايثون عبر .NET لـ PPTX.

- AutoShapeLock تقفل الأشكال التلقائية.
- ConnectorLock تقفل الأشكال الموصل.
- GraphicalObjectLock تقفل الكائنات الرسومية.
- GroupshapeLock تقفل الأشكال المجمعة.
- PictureFrameLock تقفل إطارات الصور.

أي إجراء يتم تنفيذه على جميع كائنات Shape في كائن العرض التقديمي يتم تطبيقه على العرض التقديمي بالكامل.
## **تطبيق وإزالة الحماية**
تطبيق الحماية يضمن عدم إمكانية تعديل العرض التقديمي. إنها تقنية مفيدة لحماية محتوى العرض التقديمي.
### **تطبيق الحماية على أشكال PPTX**
توفر Aspose.Slides للغة بايثون عبر .NET فئة Shape للتعامل مع شكل على الشريحة.

كما تم الإشارة إليها سابقًا، تحتوي كل فئة شكل على فئة قفل شكل مرتبطة للحماية. تركز هذه المقالة على أقفال NoSelect و NoMove و NoResize. تضمن هذه الأقفال عدم إمكانية اختيار الأشكال (من خلال نقرات الماوس أو طرق الاختيار الأخرى)، ولا يمكن تحريكها أو تغيير حجمها.

تطبق نماذج الشيفرة التي تلي ذلك الحماية على جميع أنواع الأشكال في عرض تقديمي.

```py
import aspose.slides as slides

#Instantiate Presentation class that represents a PPTX file
with slides.Presentation(path + "RectPicFrame.pptx") as pres:
    #ISlide object for accessing the slides in the presentation
    slide = pres.slides[0]

    #Traversing through all the slides in the presentation
    for slide in pres.slides:
        for shape in slide.shapes:
            #if shape is autoshape
            if type(shape) is slides.AutoShape:
                auto_shape_lock = shape.shape_lock

                #Applying shapes locks
                auto_shape_lock.position_locked = True
                auto_shape_lock.select_locked = True
                auto_shape_lock.size_locked = True

            #if shape is group shape
            elif type(shape) is slides.GroupShape:
                group_shape_lock = shape.shape_lock

                #Applying shapes locks
                group_shape_lock.grouping_locked = True
                group_shape_lock.position_locked = True
                group_shape_lock.select_locked = True
                group_shape_lock.size_locked = True

            #if shape is a connector
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                #Applying shapes locks
                connector_lock.position_move = True
                connector_lock.select_locked = True
                connector_lock.size_locked = True
            #if shape is picture frame
            elif type(shape) is slides.PictureFrame:
                #Type casting to pitcture frame shape and  getting picture frame shape lock
                picture_lock = shape.shape_lock

                #Applying shapes locks
                picture_lock.position_locked = True
                picture_lock.select_locked = True
                picture_lock.size_locked = True

    #Saving the presentation file
    pres.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```


### **إزالة الحماية**
يمكن إزالة الحماية المطبقة باستخدام Aspose.Slides للغة بايثون عبر .NET فقط مع Aspose.Slides للغة بايثون عبر .NET. لإلغاء قفل شكل، قم بتعيين قيمة القفل المطبق إلى false. تظهر نموذج الشيفرة التي تلي ذلك كيفية إلغاء قفل الأشكال في عرض تقديمي مقفل.

```py
import aspose.slides as slides

#Open the desired presentation
with slides.Presentation("ProtectedSample.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            
            if type(shape) is slides.AutoShape: 
                auto_shape_lock = shape.shape_lock

                #Applying shapes locks
                auto_shape_lock.position_locked = False
                auto_shape_lock.select_locked = False
                auto_shape_lock.size_locked = False
            
            elif type(shape) is slides.GroupShape:  
                group_shape_lock = shape.shape_lock

                #Applying shapes locks
                group_shape_lock.grouping_locked = False
                group_shape_lock.position_locked = False
                group_shape_lock.select_locked = False
                group_shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                #Applying shapes locks
                connector_lock.position_move = False
                connector_lock.select_locked = False
                connector_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                picture_lock = shape.shape_lock

                #Applying shapes locks
                picture_lock.position_locked = False
                picture_lock.select_locked = False
                picture_lock.size_locked = False
    #Saving the presentation file
    pres.save("RemoveProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```



### **الملخص**
{{% alert color="primary" %}} 

يوفر Aspose.Slides عددًا من الخيارات لتطبيق الحماية على الأشكال في عرض تقديمي. من الممكن قفل شكل معين، أو الدوران عبر جميع الأشكال في عرض تقديمي وإغلاق جميعها لقفل العرض التقديمي بشكل فعال.

يمكن فقط لـ Aspose.Slides للغة بايثون عبر .NET إزالة الحماية من عرض تقديمي كان قد تم حمايته سابقًا. قم بإزالة الحماية من خلال تعيين قيمة القفل إلى false.

{{% /alert %}} 