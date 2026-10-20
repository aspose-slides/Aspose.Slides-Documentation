---
title: تقييد تحرير العروض باستخدام أقفال الشكل في .NET
linktitle: تقييد تحرير العروض
type: docs
weight: 70
url: /ar/net/applying-protection-to-presentation/
keywords:
- منع التحرير
- الحماية من التحرير
- قفل الشكل
- قفل الموضع
- قفل الاختيار
- قفل تغيير الحجم
- قفل التجميع
- PowerPoint
- PPTX
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides for .NET لتقييد الاختيار والحركة وتغيير الحجم والتجميع."
---
## **الخلفية**

استخدام شائع لـ Aspose.Slides for .NET هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل آلي. عند تلقي المستخدمين لهذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

تشرح هذه المقالة كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تسمح هذه الأقفال لك بتقييد عمليات تحرير محددة على أشكال فردية.

## **تكوين شريحة**

شريحة العرض تتكون من مكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for .NET، يتم تمثيل كل عنصر على الشريحة بكائن ينفذ واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) أو يرث من فئة تقوم بذلك.

أنواع الأشكال المختلفة تكشف عن خيارات قفل مختلفة. واجهة [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) هي الواجهة الأساسية لأقفال الأشكال. يقدم Aspose.Slides for .NET الواجهات القفل التالية:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) يقفل الأشكال التلقائية.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) يقفل أشكال الموصلات.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) يقفل الكائنات الرسومية.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) يقفل الأشكال المجمعة.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) يقفل إطارات الصور.  

لتطبيق أقفال عبر [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، قم بالتكرار خلال شرائحه واضبط الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

أقفال الأشكال تقيد عمليات مثل اختيار الأشكال، نقلها، وتغيير حجمها. هي لا تجعل العرض بالكامل غير قابل للتحرير.

### **تطبيق الحماية على أشكال PPTX**

يوفر Aspose.Slides for .NET واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) للعمل مع الأشكال على الشريحة.

يضبط المثال [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/)، [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/)، و[SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) إلى `true` للأشكال التلقائية، مع أقفال مكافئة لأشكال المجموعات، الموصلات، وإطارات الصور. تستخدم الموصلات [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) للحركة؛ المجموعات تستخدم أيضًا [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) لتقييد التجميع.

يقوم المثال بتحميل عرض PPTX موجود، يتحقق من الأشكال في مجموعة الأشكال لكل شريحة، ويحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال خارج الأنواع الأربعة المعالجة دون تغيير. لا يتجول الحلقة داخل الأشكال الفرعية داخل مجموعة.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **إزالة الحماية**

لإزالة قفل شكل، اضبط قيمته إلى `false`. يحمل المثال التالي عرضًا يحتوي على أقفال أشكال ويزيل قيود الاختيار، النقل، وتغيير الحجم عبر [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/)، و[IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). كما يزيل [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) ويحفظ نسخة من العرض. تُترك إعدادات الأقفال الأخرى دون تغيير.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **الخلاصة**

يتيح Aspose.Slides for .NET لك تقييد عمليات تحرير محددة على أشكال فردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، واضبط قيمها إلى `false` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة الشائعة**

**هل يمكنني دمج أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. أقفال الأشكال تقيد عمليات تحرير محددة، بينما [حماية كلمة المرور](/slides/ar/net/password-protected-presentation/) يمكن أن تقيد فتح أو تعديل العرض. يمكنك استخدام كليهما في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على الآخرين؟**

نعم. طبّق الأقفال فقط على الأشكال في الشرائح المختارة. هذا لا يغيّر إعدادات الأقفال في الشرائح الأخرى.

**كيف يمكنني تطبيق أقفال على أشكال فردية داخل مجموعة؟**

قم بالتكرار عبر مجموعة [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) الخاصة بالمجموعة وطبق الأقفال المناسبة على كل شكل فرعي. كرّر ذلك لأي مجموعات متداخلة. الأمثلة أعلاه تعالج فقط مجموعة أشكال الشريحة، لذا فهي لا تضبط أقفالًا على أعضاء المجموعة الفرديين.