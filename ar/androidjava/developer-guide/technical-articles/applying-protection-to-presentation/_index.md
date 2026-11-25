---
title: تقييد تعديل العروض باستخدام أقفال الشكل على Android
linktitle: تقييد تعديل العرض
type: docs
weight: 60
url: /ar/androidjava/applying-protection-to-presentation/
keywords:
- منع التعديلات
- حماية من التعديل
- قفل الشكل
- قفل الموقع
- قفل الاختيار
- قفل تغيير الحجم
- قفل التجميع
- PowerPoint
- PPTX
- عرض
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية قفل وإلغاء قفل الأشكال في عروض PPTX باستخدام Aspose.Slides للـ Android عبر Java لتقييد الاختيار، الحركة، تغيير الحجم، والتجميع."
---
## **نظرة عامة**

استخدام شائع لـ Aspose.Slides for Android via Java هو إنشاء وتحديث وحفظ عروض PowerPoint (PPTX) كجزء من سير عمل مؤتمت. عندما يستلم المستخدمون هذه العروض، يمكن أن يساعد تقييد التغييرات على الأشكال في الحفاظ على التخطيط والمحتوى المقصود.

تشرح هذه المقالة كيفية تنظيم الأشكال على الشرائح وكيفية تطبيق وإزالة أقفال الأشكال في عرض PPTX. تسمح هذه الأقفال لك بتقييد عمليات التحرير المحددة على كل شكل على حدة.

## **تكوين الشريحة**

تتكون شريحة العرض من مكوّنات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجموعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for Android via Java، يُمثَّل كل عنصر على الشريحة بكيان يطبق واجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) أو يرث منها.

أنواع الأشكال المختلفة تُظهر خيارات قفل مختلفة. واجهة [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) هي الواجهة الأساسية لأقفال الأشكال. توفر Aspose.Slides for Android via Java واجهات القفل التالية:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) تقفل الأشكال التلقائية.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) تقفل أشكال الموصلات.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) تقفل الكائنات الرسومية.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) تقفل الأشكال المجموعة.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) تقفل إطارات الصور.  

لتطبيق الأقفال عبر [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)، قم بالتكرار عبر شرائحه واضبط الأقفال المناسبة على كل شكل مدعوم.

## **تطبيق وإزالة الحماية**

تستخدم محررات العروض المتوافقة أقفال الأشكال لتقييد عمليات التحرير الفردية. تشفير الملفات وحماية الكتابة على مستوى المستند هي إعدادات [حماية العرض](/slides/ar/androidjava/password-protected-presentation/) منفصلة.

### **تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for Android via Java واجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) للعمل مع الأشكال على الشريحة.

تستدعي المثال [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-) و[setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) و[setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) بـ`true` للأشكال التلقائية، مع أقفال مكافئة لأشكال المجموعات، الموصلات، وإطارات الصور. تستخدم الموصلات [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) للتحرك؛ وتستخدم المجموعات أيضًا [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) لتقييد التجميع.

يقوم المثال بتحميل عرض PPTX موجود، يتحقق من الأشكال في مجموعة أشكال كل شريحة، ويحفظ نسخة مع تطبيق هذه القيود. تُترك الأشكال خارج الأنواع الأربعة المعالجة دون تغيير. لا يتجول الحلقة داخل الأشكال الفرعية داخل مجموعة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **إزالة الحماية**

لإزالة قفل الشكل، اضبط قيمته إلى `false`. يحمل المثال التالي عرضًا يحتوي على أقفال أشكال ويزيل قيود التحديد، الحركة، وتغيير الحجم عبر [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/)، و[IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). كما يزيل قيد التجميع بتمرير `false` إلى [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) ويحفظ نسخة من العرض. تُترك إعدادات الأقفال الأخرى دون تغيير.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **الحفاظ على قص الصورة**

ضع صورة باسم `photo.jpg` في دليل العمل. يقتطع المثال 12٪ من اليسار و8٪ من اليمين، ثم يستدعي [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) على قفل إطار الصورة. تمرير `true` يقيّد المزيد من القص ويحافظ على القص الحالي.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` يخزن قفل القص كـ`true`. في PowerPoint، يصبح أمر **Crop** مُعطَّلًا عندما تُحدَّد الصورة.

### **إبقاء المخطط مجموعًا**

يقوم المثال بتجميع مستطيل وسهم، ثم يستدعي [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) على قفل المجموعة لإبقاء مكوّنات المخطط معًا. تظل عمليات تحرير أخرى، مثل تحريك المجموعة أو تغيير تعبئة مكوّن، متاحة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` يخزن قفل فك التجميع كـ`true`. في PowerPoint، يصبح أمر **Ungroup** مُعطَّلًا عندما يُحدَّد المخطط بالكامل.

### **الإبلاغ عن أقفال الأشكال الموجودة**

لمراجعة قالب، افتحه واقرأ كائن القفل لكل شكل. تُعيد طريقة [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) القيمة `true` عندما تكون جميع العلامات في ذلك الكائن غير مفعلة و`false` عندما تكون على الأقل إحداها مفعلة. للمجموعة وأطفالها كائنات قفل منفصلة، لذا فحص الأطفال حتى عندما لا تحتوي المجموعة على أقفال.

يفحص هذا المثال الحركة للأشكال التلقائية، إطارات الصور، والمجموعات. كما يفحص القص للصور وفك التجميع للمجموعات. تُدرج التقرير العلامات المفعلة التي يتعرف عليها وتُميّز أنواع الأشكال التي لا يتم فحصها.

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

افترض أن الشريحة 1 من `Sample.pptx` تحتوي على مجموعة باسم `Layout` بقفل فك التجميع، وصورة باسم `Photo` داخلها بقفل القص، ومستطيل غير مقفل باسم `Free`. يتخطى التقرير `Free` ويطبع السطرين التاليين:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

يقرأ التقرير علامات تعديل المستوى الشكلية المخزنة دون تغييرها أو حفظ العرض. حماية الكتابة على مستوى المستند هي إعداد منفصل، وتطبيق كل علامة يعتمد على المحرر.

### **الاستنتاج**

تمكنك Aspose.Slides for Android via Java من تقييد عمليات تحرير محددة على أشكال فردية أو تطبيق نفس القيود عبر الشرائح. اختر الأقفال المدعومة من كل نوع شكل، واضبط قيمها إلى `false` عندما تحتاج إلى إزالة تلك القيود.

## **الأسئلة الشائعة**

**هل يمكنني دمج قفل الأشكال وحماية كلمة المرور في نفس العرض التقديمي؟**

نعم. قفل الأشكال يقيّد عمليات تحرير محددة، بينما [حماية كلمة المرور](/slides/ar/androidjava/password-protected-presentation/) يمكنها تقييد فتح أو تعديل العرض. يمكنك استخدام الاثنين في نفس الملف.

**هل يمكنني تقييد التحرير على شرائح محددة دون التأثير على غيرها؟**

نعم. طبق الأقفال فقط على الأشكال في الشرائح المختارة. هذا لا يغير إعدادات الأقفال على الشرائح الأخرى.

**كيف يمكنني تطبيق أقفال على أشكال فردية داخل مجموعة؟**

قم بالتكرار عبر المجموعة باستخدام طريقة [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) وطبق الأقفال المناسبة على كل شكل فرعي. كرر ذلك لأي مجموعات متداخلة، متبعًا طريقة التجول في مثال التقرير.