---
title: إدارة عناصر التحكم ActiveX في العروض التقديمية على Android
linktitle: ActiveX
type: docs
weight: 80
url: /ar/androidjava/activex/
keywords:
- ActiveX
- عنصر تحكم ActiveX
- إدارة ActiveX
- إضافة ActiveX
- تعديل ActiveX
- مشغل وسائط
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تحرير صناديق نصوص وزران ActiveX، تحديث معاينات عناصر التحكم، وإعادة استخدام عنصر تحكم مشغل وسائط Windows Media Player في عروض PowerPoint التقديمية باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **المقدمة**

توفر عناصر التحكم ActiveX لشرائح PowerPoint عناصر تفاعلية مثل صناديق النصوص وأزرار الأوامر ومشغلات الوسائط. يتيح Aspose.Slides for Android عبر Java الوصول إلى عناصر التحكم في الشريحة من خلال [IBaseSlide.getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getControls--). استخدم هذه المجموعة لتعديل عنصر التحكم أو تحريكه على الشريحة أو إزالته. في الأمثلة أدناه، استخدم مسارات ملفات يمكن لتطبيق Android قراءتها واختر موقعًا قابلًا للكتابة لكل عرض تقديمي ناتج.

## **قائمة عناصر التحكم ActiveX وخصائصها المخزنة**

لفحص قالب غير مألوف، افتحه للقراءة وتصفح عناصر التحكم في كل شريحة. يوضح المثال رقم الشريحة، اسم عنصر التحكم، [getClassId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getClassId--)، وكل زوج مفتاح‑قيمة في [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--). يقرأ العرض التقديمي دون تنشيط عناصر التحكم أو استدعاء الأحداث أو الماكرو أو تغيير القيم أو حفظ الملف.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

المخرجات المختارة من `ActiveX.pptm` تُظهر صندوق نص وزر أمر.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

تظهر مجموعة الخصائص الفارغة كـ `[]`. بالنسبة لعناصر التحكم التي تستخدم التخزين الثنائي، قد تُعيد [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) القيمة `null`، وتُعرض كـ `Properties unavailable`. إذا كنت بحاجة فقط إلى الأسماء، استخدم [getNamesOfProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) بعد التحقق من عدم كون القيمة `null`. تُدرج التقرير الخصائص المتاحة من العرض التقديمي. قد تدعم عنصر التحكم خصائص إضافية أثناء زمن التشغيل.

## **تعديل عناصر التحكم ActiveX**

يتوقع المثال عرضًا تقديميًا مُمكّنًا للماكرو يحتوي على صندوق نص اسمه `TextBox1` وزر أمر اسمه `CommandButton1` في الشريحة الأولى. يستخدم [مجموعة خصائص عنصر التحكم](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) لتغيير قيمة صندوق النص وعنوان الزر. لكل عنصر تحكم معاينة ثابتة يمكن لبرنامج PowerPoint عرضها قبل التنشيط. زوّد كل عنصر بصورة PNG تُظهر النص والمظهر المحدثين. يعيّن المثال هذه الصور عبر [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

يقوم المثال بتحريك كل عنصر تحكم في الشريحة الأولى إلى الأسفل بمقدار 100 نقطة عن طريق ضبط إطاره باستخدام [IControl.setFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). يحفظ العرض التقديمي المعدّل بصيغة PPTM، ثم يستخدم [IControlCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/#clear--) لحفظ نسخة ثانية بدون أي عناصر تحكم ActiveX في تلك الشريحة.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    IPPImage textBoxPreview;
    IPPImage buttonPreview;
    try (FileInputStream textBoxStream = new FileInputStream("text-box-preview.png");
         FileInputStream buttonStream = new FileInputStream("button-preview.png")) {
        textBoxPreview = presentation.getImages().addImage(textBoxStream);
        buttonPreview = presentation.getImages().addImage(buttonStream);
    }
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **إضافة عنصر تحكم مشغل وسائط ActiveX**

لإعادة استخدام عنصر تحكم Windows Media Player مُكوّن مسبقًا، ابدأ بقالب يحتوي على الشريحة الأولى مشغلًا اسمه `WindowsMediaPlayer1`. ينسخ [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) الشريحة بالكامل إلى عرض تقديمي جديد. يحدد المثال خاصية `URL` للمشغل في [مجموعة الخصائص الخاصة به](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) ويحفظ الشريحة المستنسخة كالشريحة الوحيدة في المخرج. يبقى الفيديو خارجيًا، لذا اختر مسارًا يمكن للمشغل الوصول إليه أثناء التشغيل.

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");

        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides حفظ عناصر التحكم ActiveX دون تشغيلها؟**

نعم. يمكن لـ Aspose.Slides قراءة عناصر التحكم وحفظها، بما في ذلك خصائصها ومواقعها، دون تنشيطها.

**كيف تختلف عناصر التحكم ActiveX عن كائنات OLE؟**

تتيح عناصر التحكم ActiveX للمستخدمين التفاعل مع الشريحة، مثل إدخال نص أو النقر على زر. بينما يتيح [OLE object](/slides/ar/androidjava/manage-ole/) للشفرة أن تحتوي الشريحة على محتوى أو رابط إلى محتوى تديره تطبيقات أخرى، مثل ورقة عمل Excel.

**هل ستظل أحداث ActiveX تُطلق ماكروهات VBA بعد حفظ العرض التقديمي باستخدام Aspose.Slides؟**

احفظ العرض التقديمي بصيغة تدعم الماكرو مثل PPTM للاحتفاظ بمشروع VBA الخاص به. يمكن لبرنامج PowerPoint لنظام Windows تشغيل المعالجات الحدثية الموجودة عندما تسمح إعدادات الأمان بتمكين كل من عناصر التحكم ActiveX والماكروهات.