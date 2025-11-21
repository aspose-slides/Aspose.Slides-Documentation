---
title: ActiveX
type: docs
weight: 80
url: /ar/nodejs-java/activex/
---

{{% alert color="primary" %}} 

تُستخدم عناصر التحكم ActiveX في العروض التقديمية. يتيح Aspose.Slides for Node.js عبر Java إضافة وإدارة عناصر التحكم ActiveX، لكنها أصعب قليلاً في الإدارة مقارنةً بأشكال العرض العادية. لقد نفّذنا دعم إضافة عنصر التحكم Media Player Active في Aspose.Slides. لاحظ أن عناصر التحكم ActiveX ليست أشكالًا؛ فهي ليست جزءًا من العرض التقديمي ‎[ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/)‎. إنها جزء من ‎[ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/)‎ المنفصل بدلاً من ذلك. في هذا الموضوع، سنوضح لك كيفية العمل معها.

{{% /alert %}} 

## **إضافة عنصر تحكم Media Player ActiveX إلى الشريحة**
لإضافة عنصر تحكم Media Player ActiveX، قم بالآتي:

1. إنشاء نسخة من الفئة ‎[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)‎ وتوليد عرض تقديمي فارغ.
2. الوصول إلى الشريحة المستهدفة في ‎[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)‎.
3. إضافة عنصر تحكم Media Player ActiveX باستخدام الطريقة ‎[addControl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-)‎ المتوفرة في ‎[ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/)‎.
4. الوصول إلى عنصر تحكم Media Player ActiveX وتعيين مسار الفيديو باستخدام خصائصه.
5. حفظ العرض التقديمي كملف ‎PPTX‎.

يعرض هذا نموذج الشيفرة المستند إلى الخطوات أعلاه كيفية إضافة عنصر تحكم Media Player ActiveX إلى شريحة:
```javascript
// إنشاء نسخة فارغة من العرض التقديمي
var pres = new aspose.slides.Presentation();
try {
    // إضافة عنصر التحكم Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // الوصول إلى عنصر التحكم Media Player ActiveX وتعيين مسار الفيديو
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // حفظ العرض التقديمي
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعديل عنصر التحكم ActiveX**
لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر على شريحة، قم بالآتي:

1. إنشاء نسخة من الفئة ‎[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)‎ وتحميل العرض التقديمي الذي يحتوي على عناصر تحكم ActiveX.
2. الحصول على مرجع الشريحة بواسطة الفهرس.
3. الوصول إلى عناصر التحكم ActiveX في الشريحة عبر ‎[ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/)‎.
4. الوصول إلى عنصر التحكم TextBox1 ActiveX باستخدام كائن ‎[Control](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/)‎.
5. تعديل خصائص عنصر التحكم TextBox1 ActiveX التي تشمل النص والخط وارتفاع الخط وموقع الإطار.
6. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.
7. تغيير تسمية الزر والخط والموقع.
8. تحريك مواقع إطارات عناصر التحكم ActiveX.
9. كتابة العرض التقديمي المعدل إلى ملف ‎PPTX‎.

يعرض هذا نموذج الشيفرة المستند إلى الخطوات أعلاه كيفية إدارة عنصر تحكم ActiveX بسيط:
```javascript
const imageio = java.import("javax.imageio.ImageIO");
// الوصول إلى العرض التقديمي مع عناصر التحكم ActiveX
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // الوصول إلى الشريحة الأولى في العرض التقديمي
    var slide = pres.getSlides().get_Item(0);
    // تغيير نص مربع النص
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // تغيير الصورة البديلة. سيستبدل PowerPoint هذه الصورة أثناء تنشيط ActiveX،
        // لذا قد يكون من المقبول ترك الصورة دون تغيير.
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // تغيير تسمية الزر
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // تغيير البديل
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // تحريك 100 نقطة للأسفل
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // إزالة عناصر التحكم
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**هل يحتفظ Aspose.Slides بعناصر التحكم ActiveX عند القراءة وإعادة الحفظ إذا لم يمكن تنفيذها في بيئة Python؟**

نعم. يتعامل Aspose.Slides معها كجزء من العرض التقديمي ويمكنه قراءة/تعديل خصائصها وإطاراتها؛ لا يلزم تنفيذ عناصر التحكم نفسها للحفاظ عليها.

**كيف تختلف عناصر التحكم ActiveX عن كائنات OLE في العرض التقديمي؟**

عناصر التحكم ActiveX هي عناصر تفاعلية مُدارة (أزرار، مربعات نص، مشغِّل إعلام)، بينما يشير ‎[OLE](/slides/ar/nodejs-java/manage-ole/)‎ إلى كائنات تطبيق مدمجة (مثلاً، ورقة عمل Excel). يتم تخزينها ومعالجتها بصورة مختلفة وتملك نماذج خصائص متميزة.

**هل تعمل أحداث ActiveX وماكرو VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟**

يحافظ Aspose.Slides على العلامات الوصفية والبيانات الموجودة؛ ومع ذلك، تُنفَّذ الأحداث والماكروهات فقط داخل PowerPoint على Windows عندما تسمح الأمان بذلك. لا تُنفِّذ المكتبة VBA.