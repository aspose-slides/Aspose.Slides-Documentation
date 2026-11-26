---
title: إدارة عناصر التحكم ActiveX في العروض التقديمية باستخدام JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /ar/nodejs-java/activex/
keywords:
- ActiveX
- تحكم ActiveX
- إدارة ActiveX
- إضافة ActiveX
- تعديل ActiveX
- مشغل وسائط
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تحرير صناديق نصية وأزرار ActiveX، وتحديث معاينات التحكم، وإعادة استخدام عنصر تحكم مشغل Windows Media Player في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **المقدمة**

تمنح عناصر التحكم ActiveX شريحة PowerPoint عناصر تفاعلية مثل مربعات النص وأزرار الأوامر ومشغلات الوسائط. Aspose.Slides لـ Node.js عبر Java يتيح الوصول إلى عناصر التحكم في الشريحة من خلال [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls). استخدم هذه المجموعة لتحرير عنصر تحكم، أو تحريكه على الشريحة، أو إزالته.

## **قائمة عناصر التحكم ActiveX وخصائصها المخزنة**

لفحص نموذج غير مألوف، افتحه للقراءة وتكرّر عبر عناصر التحكم في كل شريحة. يُظهر المثال رقم الشريحة، اسم عنصر التحكم، [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId)، وكل زوج مفتاح‑قيمة في [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties). يقرأ العرض التقديمي دون تنشيط عناصر التحكم أو استدعاء الأحداث أو الماكروات أو تغيير القيم أو حفظ الملف.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

يعرض الإخراج المختار من `ActiveX.pptm` مربع نص وزر أمر.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

تظهر مجموعة الخصائص الفارغة كـ `[]`. بالنسبة لعناصر التحكم التي تستخدم التخزين الثنائي، يمكن أن تُعيد [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) القيمة `null`، وتُعرض كـ `Properties unavailable`. إذا كنت تحتاج فقط إلى الأسماء، استخدم [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) بعد التحقق من null. يُدرج التقرير الخصائص المتاحة من العرض التقديمي. قد يدعم عنصر التحكم خصائص إضافية أثناء التشغيل.

## **تعديل عناصر التحكم ActiveX**

يفترض المثال عرضًا تمكين الماكرو يحتوي على مربع نص يُدعى `TextBox1` وزر أمر يُدعى `CommandButton1` في الشريحة الأولى. يستخدم [control properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) لتغيير قيمة مربع النص وعنوان الزر. لكل عنصر تحكم معاينة ثابتة يمكن لـ PowerPoint عرضها قبل التنشيط. قدّم ملف PNG لكل عنصر تحكم يُظهر النص والمظهر المحدثين. يعيّن المثال هذه الصور عبر [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat).

يُحرك المثال كل عنصر تحكم في الشريحة الأولى إلى الأسفل بمقدار 100 نقطة عن طريق ضبط إطاره باستخدام [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame). يحفظ العرض التقديمي المعدل بتنسيق PPTM، ثم يستخدم [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) لحفظ نسخة ثانية مع إزالة جميع عناصر التحكم ActiveX من تلك الشريحة.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```

## **إضافة عنصر تحكم مشغل وسائط ActiveX**

لإعادة استخدام مشغل Windows Media Player مُكوّن مسبقًا، ابدأ بقالب يحتوي الشريحة الأولى على مشغل يُدعى `WindowsMediaPlayer1`. ينسخ [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) الشريحة بالكامل إلى عرض تقديمي جديد. يضبط المثال خاصية `URL` للمشغل في [properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) ويحفظ الشريحة المستنسخة كالشريحة الوحيدة في الناتج. يبقى الفيديو خارجيًا، لذا اختر مسارًا يمكن للمشغل الوصول إليه أثناء التشغيل.

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides الحفاظ على عناصر التحكم ActiveX دون تشغيلها؟**

نعم. يمكن لـ Aspose.Slides قراءة وحفظ عناصر التحكم، بما في ذلك خصائصها ومواقعها، دون تنشيطها.

**كيف تختلف عناصر التحكم ActiveX عن كائنات OLE؟**

تسمح عناصر التحكم ActiveX للمستخدمين بالتفاعل مع الشريحة، على سبيل المثال بإدخال نص أو النقر على زر. يتيح [OLE object](/slides/ar/nodejs-java/manage-ole/) أن تحتوي الشريحة على محتوى أو رابط إلى محتوى تُديره تطبيق آخر، مثل ورقة عمل Excel.

**هل ستظل أحداث ActiveX تُفعل ماكرو VBA بعد أن أحفظ عرضًا تقديميًا باستخدام Aspose.Slides؟**

احفظ العرض التقديمي بصيغة تمكين الماكرو مثل PPTM للاحتفاظ بمشروع VBA الخاص به. يمكن لـ PowerPoint لنظام Windows تشغيل معالجات الأحداث الحالية عندما تسمح إعدادات الأمان بوجود كل من عناصر التحكم ActiveX والماكروات.