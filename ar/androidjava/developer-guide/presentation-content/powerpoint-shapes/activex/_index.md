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
description: "تعلم كيف يستخدم Aspose.Slides for Android عبر Java تقنية ActiveX لأتمتة وتحسين عروض PowerPoint، مما يمنح المطورين تحكمًا قويًا في الشرائح."
---
## **المقدمة**

تُستخدم عناصر التحكم ActiveX في العروض التقديمية. يتيح لك Aspose.Slides for Android via Java إضافة وإدارة عناصر التحكم ActiveX، لكنها أصعب قليلًا في الإدارة مقارنةً بالأشكال العادية في العرض. قمنا بتنفيذ دعم لإضافة عنصر التحكم Media Player Active في Aspose.Slides. لاحظ أن عناصر التحكم ActiveX ليست أشكالًا؛ فهي ليست جزءًا من عرض التقديم الخاص بـ[IShapeCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/). بل هي جزء من [IControlCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icontrolcollection/) المنفصل. في هذا الموضوع، سنوضح لك كيفية العمل معها.

## **إضافة عنصر تحكم Media Player ActiveX إلى شريحة**
لإضافة عنصر تحكم Media Player ActiveX، قم بما يلي:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) وتوليد عرض تقديمي فارغ.  
2. الوصول إلى الشريحة المستهدفة في [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).  
3. إضافة عنصر التحكم Media Player ActiveX باستخدام الطريقة [addControl](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) التي توفرها [IControlCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icontrolcollection/).  
4. الوصول إلى عنصر التحكم Media Player ActiveX وتعيين مسار الفيديو باستخدام خصائصه.  
5. حفظ العرض التقديمي كملف PPTX.

```java
import com.aspose.slides.*;

// إنشاء مثال عرض تقديمي فارغ
Presentation pres = new Presentation();
try {
    // إضافة عنصر التحكم Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // الوصول إلى عنصر التحكم Media Player ActiveX وتعيين مسار الفيديو
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // حفظ العرض التقديمي
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعديل عنصر تحكم ActiveX**
{{% alert color="info" %}} 

تأتي Aspose.Slides for Android via Java 7.1.0 والإصدارات الأحدث بها مكونات لإدارة عناصر تحكم ActiveX. يمكنك الوصول إلى عنصر التحكم ActiveX الذي تم إضافته مسبقًا في العرض التقديمي وتعديله أو حذفه من خلال خصائصه.

{{% /alert %}} 

لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر بسيط في شريحة، قم بما يلي:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على عناصر تحكم ActiveX.  
2. الحصول على مرجع الشريحة عن طريق فهرسها.  
3. الوصول إلى عناصر تحكم ActiveX في الشريحة عبر [IControlCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icontrolcollection/).  
4. الوصول إلى عنصر التحكم TextBox1 ActiveX باستخدام كائن [IControl](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icontrol/).  
5. تغيير خصائص عنصر التحكم TextBox1 ActiveX التي تشمل النص، الخط، ارتفاع الخط، وموقع الإطار.  
6. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.  
7. تغيير تسمية الزر، الخط، والموقع.  
8. نقل موقع أطر عناصر التحكم ActiveX.  
9. كتابة العرض التقديمي المعدل إلى ملف PPTX.

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// الوصول إلى العرض التقديمي مع عناصر تحكم ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // الوصول إلى الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // تغيير نص مربع النص
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // تغيير الصورة البديلة. سيستبدل PowerPoint هذه الصورة أثناء تفعيل ActiveX،
        // لذلك قد يكون من المقبول ترك الصورة دون تغيير في بعض الأحيان.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // تغيير تسمية الزر
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);

        // تغيير البديل
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // تحريك 100 نقطة إلى الأسفل
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // إزالة العناصر التحكم
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **الأسئلة الشائعة**

### هل يحتفظ Aspose.Slides بعنصر تحكم ActiveX عند القراءة وإعادة الحفظ إذا لم يمكن تنفيذها في بيئة تشغيل Java؟

نعم. يتعامل Aspose.Slides معها كجزء من العرض التقديمي ويمكنه قراءة/تعديل خصائصها وإطاراتها؛ لا يلزم تنفيذ عناصر التحكم نفسها للحفاظ عليها.

### كيف تختلف عناصر التحكم ActiveX عن كائنات OLE في العرض التقديمي؟

عناصر التحكم ActiveX هي عناصر تفاعلية مُدارة (أزرار، مربعات نص، مشغل وسائط)، بينما يشير [OLE](/slides/ar/androidjava/manage-ole/) إلى كائنات تطبيق مدمجة (مثلاً ورقة عمل Excel). يتم تخزينها ومعالجتها بطريقة مختلفة ولها نماذج خصائص مختلفة.

### هل تعمل أحداث ActiveX وماكرو VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟

يحافظ Aspose.Slides على العلامات الوصفية الحالية والبيانات الوصفية؛ ومع ذلك، تعمل الأحداث والماكرو فقط داخل PowerPoint على نظام Windows عندما تسمح الأمان بذلك. لا تقوم المكتبة بتنفيذ VBA.