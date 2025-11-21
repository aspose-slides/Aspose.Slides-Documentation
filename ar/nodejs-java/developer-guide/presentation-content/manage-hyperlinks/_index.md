---
title: إدارة الروابط التشعبية
type: docs
weight: 20
url: /ar/nodejs-java/manage-hyperlinks/
keywords: "ارتباط تشعبي PowerPoint, ارتباط تشعبي نص, ارتباط تشعبي شريحة, ارتباط تشعبي شكل, ارتباط تشعبي صورة, ارتباط تشعبي فيديو, Java"
description: "كيفية إضافة ارتباط تشعبي إلى عرض تقديمي PowerPoint باستخدام JavaScript"
---

الارتباط التشعبي هو إشارة إلى كائن أو بيانات أو مكان في شيء ما. هذه أمثلة على الروابط التشعبية الشائعة في عروض PowerPoint التقديمية:

* روابط إلى مواقع ويب داخل النصوص أو الأشكال أو الوسائط
* روابط إلى الشرائح

Aspose.Slides for Node.js via Java يتيح لك تنفيذ العديد من المهام المتعلقة بالروابط التشعبية في العروض التقديمية.

{{% alert color="primary" %}} 
قد ترغب في تجربة Aspose البسيط، [محرر PowerPoint المجاني على الإنترنت.](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **إضافة روابط URL**

### **إضافة روابط URL إلى النصوص**

يظهر لك هذا الشيفرة JavaScript كيفية إضافة ارتباط تشعبي لموقع ويب إلى نص:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


### **إضافة روابط URL إلى الأشكال أو الإطارات**

هذا المثال في JavaScript يوضح كيفية إضافة ارتباط تشعبي لموقع ويب إلى شكل:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **إضافة روابط URL إلى الوسائط**

Aspose.Slides يتيح لك إضافة روابط تشعبية إلى الصور، الملفات الصوتية، وملفات الفيديو.

هذا المثال يوضح كيفية إضافة ارتباط تشعبي إلى **صورة**:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // يضيف صورة إلى العرض التقديمي
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // إنشاء إطار صورة على الشريحة 1 بناءً على الصورة المضافة مسبقًا
    var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pictureFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


هذا المثال يوضح كيفية إضافة ارتباط تشعبي إلى **ملف صوتي**:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var audio = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.mp3")));
    var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
    audioFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


هذا المثال يوضح كيفية إضافة ارتباط تشعبي إلى **فيديو**:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var video = pres.getVideos().addVideo(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "video.avi")));
    var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    videoFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert  title="Tip"  color="primary"  %}} 
قد ترغب في الاطلاع على *[إدارة OLE](/slides/ar/nodejs-java/manage-ole/)*.
{{% /alert %}}

## **استخدام الروابط التشعبية لإنشاء فهرس المحتويات**

نظرًا لأن الروابط التشعبية تتيح لك إضافة مراجع إلى كائنات أو أماكن، يمكنك استخدامها لإنشاء فهرس المحتويات.

هذا المثال يوضح كيفية إنشاء فهرس محتويات باستخدام الروابط التشعبية:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var firstSlide = pres.getSlides().get_Item(0);
    var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
    var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getTextFrame().getParagraphs().clear();
    var paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");
    var linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
    paragraph.getPortions().add(linkPortion);
    contentTable.getTextFrame().getParagraphs().add(paragraph);
    pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تنسيق الروابط التشعبية**

### **اللون**

باستخدام طريقة [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) في فئة [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) يمكنك ضبط اللون للروابط التشعبية وكذلك الحصول على معلومات اللون من الروابط التشعبية. تم تقديم هذه الميزة لأول مرة في PowerPoint 2019، لذا فإن التغييرات المتعلقة بهذه الخاصية لا تنطبق على إصدارات PowerPoint الأقدم.

هذا المثال يوضح عملية إضافة روابط تشعبية بألوان مختلفة إلى الشريحة نفسها:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إزالة الروابط التشعبية في العروض التقديمية**

### **إزالة الروابط التشعبية من النصوص**

هذا الشيفرة JavaScript يوضح كيفية إزالة الرابط التشعبي من نص في شريحة عرض تقديمي:
```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // يتحقق مما إذا كان الشكل يدعم إطار النص (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // يتنقل عبر الفقرات في إطار النص
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // يتنقل عبر كل جزء في الفقرة
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// يغير النص
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// يغير التنسيق
                    }
                }
            }
        }
    }
    // يحفظ العرض التقديمي المعدل
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **إزالة الروابط التشعبية من الأشكال أو الإطارات**

هذا الشيفرة JavaScript يوضح كيفية إزالة الرابط التشعبي من شكل في شريحة عرض تقديمي:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        shape.getHyperlinkManager().removeHyperlinkClick();
    }
    pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الرابط التشعبي القابل للتعديل**

فئة [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) قابلة للتعديل. باستخدام هذه الفئة يمكنك تغيير قيم هذه الخصائص:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

المقتطف البرمجي يوضح كيفية إضافة رابط تشعبي إلى شريحة وتعديل تلميحه لاحقًا:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الخصائص المدعومة في IHyperlinkQueries**

يمكنك الوصول إلى [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) من عرض تقديمي أو شريحة أو نص يتم تعريف الرابط التشعبي فيه.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

فئة [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) تدعم هذه الطرق والخصائص:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **الأسئلة المتكررة**

**كيف يمكنني إنشاء تنقل داخلي ليس فقط إلى شريحة، بل إلى "قسم" أو الشريحة الأولى في قسم؟**

الأقسام في PowerPoint هي تجميعات للشرائح؛ التنقل يستهدف تقنيًا شريحة معينة. لت "التنقل إلى قسم"، عادةً ما يتم ربطه بأول شريحة في ذلك القسم.

**هل يمكنني إرفاق ارتباط تشعبي بعناصر الشريحة الرئيسة بحيث يعمل على جميع الشرائح؟**

نعم. عناصر الشريحة الرئيسة وتخطيطها تدعم الروابط التشعبية. تظهر هذه الروابط على الشرائح الفرعية ويمكن النقر عليها أثناء عرض الشرائح.

**هل سيتم الحفاظ على الروابط التشعبية عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

في [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/)، نعم—عادةً ما تُحفظ الروابط. عند التصدير إلى [الصور](/slides/ar/nodejs-java/convert-powerpoint-to-png/) و[الفيديو](/slides/ar/nodejs-java/convert-powerpoint-to-video/)، لن تُنقل قابلية النقر بسبب طبيعة هذه الصيغ (الإطارات النقطية أو الفيديو لا تدعم الروابط التشعبية).