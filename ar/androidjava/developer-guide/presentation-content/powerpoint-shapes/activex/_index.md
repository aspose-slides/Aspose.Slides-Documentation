---
title: "إدارة عناصر تحكم ActiveX في العروض التقديمية على Android"
linktitle: "ActiveX"
type: docs
weight: 80
url: /ar/androidjava/activex/
keywords:
- "ActiveX"
- "تحكم ActiveX"
- "إدارة ActiveX"
- "إضافة ActiveX"
- "تعديل ActiveX"
- "مشغل وسائط"
- "PowerPoint"
- "عرض تقديمي"
- "Android"
- "Java"
- "Aspose.Slides"
description: "تعرّف على كيفية استفادة Aspose.Slides للأندرويد عبر Java من ActiveX لأتمتة وتحسين عروض PowerPoint التقديمية، مما يمنح المطورين تحكمًا قويًا في الشرائح."
---

{{% alert color="primary" %}} 

تُستخدم عناصر تحكم ActiveX في العروض التقديمية. يتيح Aspose.Slides for Android عبر Java إضافة وإدارة عناصر تحكم ActiveX، لكنها تكون أكثر تعقيدًا قليلاً مقارنةً بالأشكال العادية في العرض. لقد نفّذنا دعم إضافة عنصر تحكم ActiveX لمشغل الوسائط في Aspose.Slides. لاحظ أن عناصر تحكم ActiveX ليست أشكالًا؛ فهي ليست جزءًا من [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) في العرض. بل هي جزء من [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/) المنفصل. في هذا الموضوع، سنوضح لك كيفية العمل معها.

{{% /alert %}} 

## **إضافة عنصر تحكم ActiveX لمشغل الوسائط إلى شريحة**
لإضافة عنصر تحكم ActiveX لمشغل الوسائط، قم بما يلي:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وإنشاء عرض تقديمي فارغ.  
2. الوصول إلى الشريحة المستهدفة في [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
3. إضافة عنصر تحكم ActiveX لمشغل الوسائط باستخدام الطريقة [addControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) المعروضة من قبل [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/).  
4. الوصول إلى عنصر تحكم ActiveX لمشغل الوسائط وتعيين مسار الفيديو باستخدام خصائصه.  
5. حفظ العرض التقديمي كملف PPTX.  

```java
// إنشاء نسخة عرض تقديمي فارغة
Presentation pres = new Presentation();
try {
    // إضافة عنصر تحكم ActiveX لمشغل الوسائط
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // الوصول إلى عنصر تحكم ActiveX لمشغل الوسائط وتعيين مسار الفيديو
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // حفظ العرض التقديمي
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعديل عنصر تحكم ActiveX**
{{% alert color="primary" %}} 

تأتي إصدارات Aspose.Slides for Android عبر Java 7.1.0 وما بعدها مزودة بمكونات لإدارة عناصر تحكم ActiveX. يمكنك الوصول إلى عنصر التحكم ActiveX المضاف مسبقًا في العرض التقديمي وتعديله أو حذفه عبر خصائصه.

{{% /alert %}} 

لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر بسيط على شريحة، قم بما يلي:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على عناصر تحكم ActiveX.  
2. الحصول على مرجع إلى الشريحة عبر فهرسها.  
3. الوصول إلى عناصر تحكم ActiveX في الشريحة عبر [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/).  
4. الوصول إلى عنصر تحكم ActiveX TextBox1 باستخدام كائن [IControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/).  
5. تعديل خصائص عنصر تحكم ActiveX TextBox1 التي تشمل النص، الخط، ارتفاع الخط، وموقع الإطار.  
6. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.  
7. تغيير تسمية الزر، الخط، والموقع.  
8. تحريك موقع إطارات عناصر تحكم ActiveX.  
9. كتابة العرض التقديمي المعدل إلى ملف PPTX.  

```java
// الوصول إلى العرض التقديمي الذي يحتوي على عناصر تحكم ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // الوصول إلى الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // تعديل نص مربع النص
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // تغيير صورة البديل. سيستبدل PowerPoint هذه الصورة أثناء تفعيل ActiveX،
        // لذا قد يكون من المقبول ترك الصورة دون تغيير في بعض الأحيان.
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

    // تعديل تسمية الزر
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

            // تحريك كل العناصر 100 نقطة للأسفل
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // إزالة عناصر التحكم
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```


## **الأسئلة الشائعة**

**هل يحتفظ Aspose.Slides بعناصر تحكم ActiveX عند القراءة وإعادة الحفظ إذا لم يمكن تنفيذها في بيئة تشغيل Java؟**  
نعم. يعتبر Aspose.Slides هذه العناصر جزءًا من العرض ويمكنه قراءة/تعديل خصائصها وإطاراتها؛ لا يلزم تنفيذ عناصر التحكم نفسها للحفاظ عليها.

**كيف تختلف عناصر تحكم ActiveX عن كائنات OLE في العرض التقديمي؟**  
عناصر تحكم ActiveX هي عناصر تحكم تفاعلية مُدارة (أزرار، مربعات نص، مشغّل وسائط)، بينما يشير [OLE](/slides/ar/androidjava/manage-ole/) إلى كائنات تطبيق مضمّنة (مثل ورقة عمل Excel). يتم تخزينها ومعالجتها بطريقة مختلفة ولها نماذج خصائص متميزة.

**هل تعمل أحداث ActiveX والماكروات VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟**  
يحافظ Aspose.Slides على العلامات الوصفية والبيانات الموجودة؛ ومع ذلك، يتم تشغيل الأحداث والماكروات فقط داخل PowerPoint على Windows عندما تسمح الأمان بذلك. المكتبة لا تنفّذ VBA.