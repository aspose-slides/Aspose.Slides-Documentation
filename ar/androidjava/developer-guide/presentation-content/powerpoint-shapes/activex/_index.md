---
title: "إدارة عناصر التحكم ActiveX في العروض التقديمية على Android"
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
description: "تعرف على كيفية استفادة Aspose.Slides for Android عبر Java من ActiveX لأتمتة وتعزيز عروض PowerPoint التقديمية، مما يمنح المطورين تحكمًا قويًا في الشرائح."
---

{{% alert color="primary" %}} 

تُستخدم عناصر التحكم ActiveX في العروض التقديمية. يتيح Aspose.Slides for Android عبر Java إضافة وإدارة عناصر التحكم ActiveX، لكنها تكون أصعب قليلاً في الإدارة مقارنة بالأشكال العادية في العرض. لقد قمنا بتطبيق دعم لإضافة عنصر تحكم Media Player ActiveX في Aspose.Slides. لاحظ أن عناصر التحكم ActiveX ليست أشكالاً؛ فهي ليست جزءًا من مجموعة الأشكال [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IShapeCollection). بل هي جزء من مجموعة التحكم المنفصلة [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection). في هذا الموضوع، سنوضح لك كيفية العمل معها.

{{% /alert %}} 

## **إضافة عنصر تحكم Media Player ActiveX إلى شريحة**
لإضافة عنصر تحكم Media Player ActiveX، قم بما يلي:

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وابدأ عرضًا تقديميًا فارغًا.
2. احصل على الشريحة المستهدفة في [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
3. أضف عنصر تحكم Media Player ActiveX باستخدام طريقة [addControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) التي توجد في [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection).
4. احصل على عنصر تحكم Media Player ActiveX واضبط مسار الفيديو باستخدام خصائصه.
5. احفظ العرض التقديمي كملف PPTX.

هذا مثال برمجي، بناءً على الخطوات أعلاه، يوضح كيفية إضافة عنصر تحكم Media Player ActiveX إلى شريحة:
```java
// إنشاء مثال عرض تقديمي فارغ
Presentation pres = new Presentation();
try {
    // إضافة عنصر تحكم Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // الوصول إلى عنصر تحكم Media Player ActiveX وتعيين مسار الفيديو
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // حفظ العرض التقديمي
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعديل عنصر تحكم ActiveX**
{{% alert color="primary" %}} 

تتوفر في Aspose.Slides for Android عبر Java الإصدار 7.1.0 وما بعده مكوّنات لإدارة عناصر التحكم ActiveX. يمكنك الوصول إلى عنصر التحكم ActiveX المضاف مسبقًا في عرضك التقديمي وتعديله أو حذفه عبر خصائصه.

{{% /alert %}} 

لإدارة عنصر تحكم ActiveX بسيط مثل صندوق نص وزر أمر بسيط على شريحة، قم بما يلي:

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وحمّل العرض الذي يحتوي على عناصر تحكم ActiveX.
2. احصل على مرجع الشريحة عبر فهرستها.
3. ادخل إلى عناصر التحكم في الشريحة عبر [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection).
4. احصل على عنصر التحكم TextBox1 ActiveX باستخدام كائن [IControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControl).
5. غير خصائص عنصر التحكم TextBox1 ActiveX التي تشمل النص، الخط، ارتفاع الخط، وموقع الإطار.
6. احصل على عنصر التحكم الثاني المسمى CommandButton1.
7. غير تسمية الزر، الخط، والموقع.
8. قم بتحريك مواقع إطارات عناصر التحكم ActiveX.
9. اكتب العرض التقديمي المعدل إلى ملف PPTX.

هذا مثال برمجي، بناءً على الخطوات أعلاه، يوضح كيفية إدارة عنصر تحكم ActiveX بسيط:
```java
// الوصول إلى العرض التقديمي مع عناصر التحكم ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // الوصول إلى الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);

    // تغيير نص صندوق النص
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // تغيير صورة الاستبدال. سيستبدل PowerPoint هذه الصورة أثناء تنشيط ActiveX،
        // لذلك في بعض الأحيان يمكن ترك الصورة دون تغيير.
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
        // تغيير الاستبدال
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

            // نقل الأسفل 100 نقطة
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

**هل يحتفظ Aspose.Slides بعناصر التحكم ActiveX عند القراءة وإعادة الحفظ إذا لم يمكن تنفيذها في بيئة تشغيل Java؟**

نعم. يتعامل Aspose.Slides مع هذه العناصر كجزء من العرض التقديمي ويمكنه قراءة/تعديل خصائصها وإطاراتها؛ لا يلزم تنفيذ العناصر نفسها للحفاظ عليها.

**كيف تختلف عناصر التحكم ActiveX عن كائنات OLE في العرض التقديمي؟**

عناصر التحكم ActiveX هي عناصر تفاعلية مُدارة (أزرار، صناديق نص، مشغل وسائط)، بينما يشير [OLE](/slides/ar/androidjava/manage-ole/) إلى كائنات تطبيق مدمجة (مثل ورقة عمل Excel). يتم تخزينها ومعالجتها بشكل مختلف وتملك نماذج خصائص مختلفة.

**هل تعمل أحداث ActiveX والماكروهات VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟**

يحافظ Aspose.Slides على العلامات الوصفية والبيانات الموجودة؛ ومع ذلك، تُنفّذ الأحداث والماكروهات فقط داخل PowerPoint على نظام Windows عندما تسمح الأمان بذلك. المكتبة لا تقوم بتنفيذ VBA.