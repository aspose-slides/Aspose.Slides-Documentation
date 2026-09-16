---
title: إدارة روابط العروض التقديمية على Android
linktitle: إدارة الروابط
type: docs
weight: 20
url: /ar/androidjava/manage-hyperlinks/
keywords:
- إضافة URL
- إضافة رابط تشعبي
- إنشاء رابط تشعبي
- تنسيق رابط تشعبي
- إزالة رابط تشعبي
- تحديث رابط تشعبي
- رابط تشعبي نصي
- رابط تشعبي للشرائح
- رابط تشعبي للشكل
- رابط تشعبي للصورة
- رابط تشعبي للفيديو
- رابط تشعبي قابل للتعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إضافة وتنسيق وتحديث وإزالة الروابط التشعبية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Android عبر Java، مع أمثلة Java."
---
## **مقدمة**

رابط تشعبي يربط محتوى العرض التقديمي بموقع ويب أو موقع داخل العرض التقديمي. في PowerPoint، غالبًا ما يخدم الروابط التشعبية غرضين:

* فتح موقع ويب من النص أو الشكل أو إطار الوسائط.
* الانتقال إلى شريحة أخرى، على سبيل المثال من جدول المحتويات.

Aspose.Slides for Android عبر Java يتيح لك إضافة هذه الروابط، والتحكم في مظهرها وصوتها، وتحديث خصائصها، وإزالتها. توضح الأمثلة أدناه كيفية العمل مع الروابط التشعبية على العناصر الفردية وكيفية الوصول إلى الروابط التشعبية على مستوى العرض التقديمي أو الشريحة أو إطار النص.

{{% alert color="info" title="Note" %}}
يمكنك أيضًا تعديل العروض التقديمية باستخدام [محرر Aspose PowerPoint المجاني عبر الإنترنت](https://products.aspose.app/slides/ar/editor).
{{% /alert %}} 

## **إضافة روابط URL**

يمكنك تعيين عنوان URL لموقع ويب إلى نص أو شكل أو إطار وسائط. العنصر الذي تعين إليه الرابط التشعبي يحدد المنطقة القابلة للنقر: الجزء النصي يربط النص المحدد، بينما الشكل أو الإطار يربط كائن الشريحة.

### **إضافة روابط URL إلى النص**

لربط النص بموقع ويب، مرر كائن [Hyperlink](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/hyperlink/) إلى طريقة [setHyperlinkClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) للجزء النصي، كما هو موضح أدناه. يصبح ذلك الجزء من النص فقط قابلًا للنقر.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **إضافة روابط URL إلى الأشكال وإطارات الوسائط**

لجعل الشكل أو الإطار قابل للنقر، استدعِ طريقة [setHyperlinkClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) الخاصة به. ينتمي الرابط التشعبي إلى الكائن نفسه وليس إلى جزء نص داخلها.

ينطبق نفس النهج على إطارات الصورة والصوت والفيديو: قم بتعيين الرابط التشعبي إلى الإطار واستدعِ طريقة [setTooltip](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) إذا لزم الأمر.

المثال التالي يجعل مستطيلًا قابلًا للنقر:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استخدام الروابط التشعبية لإنشاء جدول محتويات**

تسمح الروابط التشعبية الداخلية للقراء بالانتقال من جدول المحتويات إلى شريحة محددة. يستخدم المثال التالي طريقة [setInternalHyperlinkClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) لربط نص "Page 2" على الشريحة الأولى بالشريحة الثانية.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنسيق الروابط التشعبية**

### **اللون**

طريقة [setColorSource](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) في [IHyperlink](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/) تحدد ما إذا كان الرابط التشعبي يستخدم لون الروابط التشعبية في العرض التقديمي أو تنسيق الجزء النصي. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/hyperlinkcolorsource/) وقم بتعيين لون ملء الجزء. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات القديمة لا تطبق هذا الإعداد.

المثال التالي يضيف رابطين نصيين إلى نفس الشريحة. الأول يستخدم تعبئة نص حمراء، بينما الثاني يحتفظ بلون الرابط التشعبي الافتراضي.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **الصوت**

يمكن للرابط التشعبي أن يشغل صوتًا عند تنشيطه أو يوقف صوتًا قيد التشغيل بالفعل. استخدم الطرق التالية لتكوين هذه السلوكيات:

- [IHyperlink.setSound](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) يحدد الصوت المرتبط بالرابط التشعبي.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) يتحكم فيما إذا كان تنشيط الرابط التشعبي يوقف الصوت السابق.

#### **إضافة صوت إلى الرابط التشعبي**

المثال التالي يحمل `sampleaudio.wav` ويربطه بزر على الشريحة الأولى. النقر على الزر يشغل الصوت وينتقل إلى الشريحة التالية. الشكل الثاني على تلك الشريحة يوقف الصوت السابق عند النقر، دون تنفيذ إجراء تنقل.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **استخراج صوت الرابط التشعبي**

المثال التالي يفتح العرض التقديمي الذي تم إنشاؤه أعلاه ويقرأ الصوت المرتبط بالرابط التشعبي للشكل الأول إلى الذاكرة عبر [getSound](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/#getSound-com.aspose.slides.IAudio-) و[getBinaryData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **إعدادات تلميح الأدات والتفاعل**

يمكنك استدعاء الطرق التالية من [IHyperlink](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/) بعد تعيين رابط تشعبي إلى نص أو شكل:

- [setTooltip](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) يحدد النص الذي يمكن للمشاهد عرضه كتلميح للرابط.
- [setTargetFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) يحدد إطار الهدف داخل مجموعة إطارات HTML الأم، عند الاقتضاء.
- [setHistory](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) يتحكم فيما إذا كان تنشيط الرابط يضيف وجهته إلى قائمة الروابط التي تم عرضها.
- [setHighlightClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) يتحكم فيما إذا كان يتم تمييز الرابط عند النقر.

## **إزالة الروابط التشعبية من العروض التقديمية**

استخدم [getAnyHyperlinks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) لجمع حاويات الروابط التشعبية، بما في ذلك روابط أجزاء النص، قبل تعديلها. يزيل المثال التالي كلا نوعي التنشيط من الشريحة الأولى. لإزالة نوع واحد فقط، استدعِ فقط [removeHyperlinkClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) أو [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); إزالة إجراء النقر لا يزيل المقابل الخاص بالتحريك فوق الفأرة.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

لإزالة غير مشروطة، تقوم [removeAllHyperlinks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) بإزالة كلا نوعي التنشيط في النطاق المحدد في مكالمة واحدة. للتنظيف الانتقائي وتغطية القوالب الرئيسية والتنسيقات والملاحظات، راجع [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **إنشاء جرد شامل للروابط التشعبية**

قبل توزيع عرض تقديمي، قم بجرد الإجراءات التفاعلية بالإضافة إلى روابط الويب الخاصة به. تُرجع [getAnyHyperlinks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) كائنات [IHyperlinkContainer](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkcontainer/)، وليس قائمة مسطحة من سلاسل URL. افحص كلًا من [getHyperlinkClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) و[getHyperlinkMouseOver](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) على كل حاوية. هما مستقلان: يمكن لنفس الحاوية أن تعرض كلا الإجراءين، لذا يتطلب التقرير الكامل حتى صفين لكل حاوية.

قد يؤدي فحص الروابط التشعبية على مستوى الأشكال فقط إلى فقدان الروابط المرفقة بأجزاء النص. استعلم عن النطاق المناسب بدلاً من ذلك، واحتفظ بالحاويات المعادة حتى تتمكن لاحقًا من تحديث أو إزالة إجراءاتها.

### **استعلام عن نطاقات العرض التقديمي والشريحة وإطار النص**

واجهة [IHyperlinkQueries](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkqueries/) متاحة عبر [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), و[ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). يدعم كل نطاق نفس الاستعلامات:

- [getHyperlinkClicks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) يُرجع حاويات ذات إجراء نقرة.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) يُرجع حاويات ذات إجراء تحريك الفأرة فوق.
- [getAnyHyperlinks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) يُرجع حاويات إما بإجراء واحد أو كلا الإجراءين.

المثال التالي يُنشئ ملف `hyperlink-audit-input.pptx` يحتوي على رابط نقرة خارجي، ورابط تحريك فأرة ملف، وتنقّل شرائح داخلي، ورابط تحريك فأرة نص، وإجراء ماكرو. لا ينفذ أيًا من هذه الإجراءات. تعمل الاستعلامات الثلاث نفسها في كل نطاق؛ الأعداد تصف الحاويات، ليست إجمالي الإجراءات. نطاق إطار النص يستثني الروابط الخاصة بالشكل المحيط.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

في هذا المثال، تقارير استعلامات العرض التقديمي والشريحة تُظهر كل منهما ثلاث حاويات نقرة، وحاويتين تحريك فأرة، وثلاث حاويات بأي إجراء. تقرير إطار النص يُظهر حاوية واحدة في كل فئة.

### **تصنيف الإجراءات والوجهات**

استخدم [IHyperlink.getActionType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/#getActionType--) لتفسير الإجراء قبل تفسير وجهته. قيم [HyperlinkActionType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/hyperlinkactiontype/) تغطي أكثر من التنقل عبر الويب:

| القيم | المعنى أثناء التدقيق |
| --- | --- |
| `Hyperlink` | رابط تشعبي خارجي؛ تحقق من عنوان URL ومخططه. |
| `JumpSpecificSlide` | تنقل داخلي إلى شريحة معينة. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | تنقل مدمج في عرض الشرائح، يتم حله في سياق عرض الشرائح. |
| `JumpEndShow`, `StartCustomSlideShow` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `StartMacro` | تنفيذ ماكرو. |
| `StartProgram` | تشغيل برنامج. |
| `OpenFile`, `OpenPresentation` | فتح ملف أو عرض تقديمي آخر؛ راجعه بشكل منفصل عن عناوين URL للويب. |
| `StartStopMedia` | بدء أو إيقاف تشغيل الوسائط. |
| `NoAction`, `Unknown` | لا يوجد إجراء تنقل، أو إجراء غير معروف يحتاج إلى مراجعة. |

اقرأ الوجهات الخارجية من [getExternalUrl](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) والوجهات الداخلية المحددة من [getTargetSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). قد لا تحتوي الإجراءات الداخلية والأوامر المدمجة على URL خارجي؛ URL فارغ لا يعني أن الحاوية لا تحتوي على إجراء. احتفظ بالقيمة التي تُرجعها [getExternalUrlOriginal](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) عندما تختلف عن URL المُطبع، وضمن تلميح الأدات الذي تُرجعه [getTooltip](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) إذا كان متاحًا.

### **الإبلاغ، التطهير، والتحقق من الروابط التشعبية**

المثال التالي بلغة Java يقرأ عرضًا تقديميًا موجودًا (استخدم الملف الذي تم إنشاؤه أعلاه)، يكتب ملف `hyperlink-audit.json`، يطبق سياسة، يحفظ `hyperlink-sanitized.pptx`، ثم يعيد فتحه للتحقق مرة أخرى من كلا نوعي التنشيط. يجمع الحاويات قبل تعديلها ويستخدم مساواة المراجع لتجنب معالجة نفس الحاوية مرتين. تغطي استعلامات العرض التقديمي الشرائح العادية؛ للحصول على جرد على مستوى الحزمة، يستعلم أيضًا صراحةً عن القوالب الرئيسية، والتنسيقات، والملاحظات، وقوالب الملاحظات والنشرات عندما تكون موجودة.

يسجل التقرير فهرس شريحة يبدأ من واحد و[getSlideId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) إذا كان متاحًا. يوفر [ISlideComponent.getSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecomponent/#getSlide--) الشريحة المملوكة للحاويات المدعومة. القوالب الرئيسية، والتنسيقات، والملاحظات لا تملك فهرس شريحة عادي وتُعرف بنطاقها. تُصنّف حاويات الشكل وحاويات تنسيق جزء النص بشكل منفصل؛ تحتفظ الأنواع الأخرى بأسمائها النوعية أثناء وقت التشغيل. يحصل كل حاوية على معرف محلي في التقرير لتتمكن من ربط إجراءيها. يخزن التقرير أنواع الإجراءات كقواميس صحيحة معرفة بواسطة تعداد Java.

تسمح هذه السياسة التطبيقية المقيدة عمدًا فقط بعناوين URL HTTPS المطلقة ووجهات الشرائح الداخلية الصالحة. ترفض الماكروات، والبرامج، وإجراءات الملفات، وإجراءات الشرائح الأخرى، والإجراءات غير المعروفة، وأنواع URL الأخرى. هذه الرفضات هي قرارات سياسة، ليست حكمًا على أمان Aspose.Slides. HTTPS وحده لا يضمن الثقة: أضف قوائم السماح للمضيف وفحوصات أخرى لتطبيقك. يتم فحص كل من عناوين URL الخارجية الأصلية والمُطبع. يراجع المثال البيانات الوصفية دون متابعة الروابط أو تشغيل الإجراءات.

للتصحيح، يدعم [getHyperlinkManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) الخاص بالحاوية [setExternalHyperlinkClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--), و[removeHyperlinkMouseOver](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). هنا، تُستبدل روابط النقر الخارجية المحظورة بصفحة هبوط HTTPS ثابتة؛ تُزال النقرات والمحاور الفأرة المحظورة الأخرى بشكل مستقل. اضبط `replaceExternalClicks` على `false` لإزالة جميع المخالفات السياسية بدلاً من ذلك. اختر صفحة بديلة مملوكة للتطبيق قبل النشر.

يستخدم علم تصدير التقرير سياسة مراجعة PDF متحفظة: يتم وضع علامة على إجراءات التحريك فوق الفأرة وأي شيء غير رابط خارجي أو قفزة شريحة محددة على أنه قد لا يكون مدعومًا. هذه مجرد إشارة للمراجعة، ليست اختبارًا للقدرات أو ضمانًا بأن الروابط غير المعلمة ستبقى بعد التصدير. قد تحتفظ صادرات [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/androidjava/convert-powerpoint-to-html/) المدعومة بالروابط التشعبية، حسب الإجراء وخيارات التصدير والمشاهد. لا يمكن للـ [images](/slides/ar/androidjava/convert-powerpoint-to-png/) النقطية و[video](/slides/ar/androidjava/convert-powerpoint-to-video/) الحفاظ على الروابط التشعبية التفاعلية؛ ضع علامة على كل إجراء عند التدقيق لتلك المخرجات.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // تسلسل الصفوف المسطحة لهذا التقرير دون اعتماد إضافي على JSON.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

مع الإدخال المُنشأ أعلاه، يحتوي التقرير على خمسة صفوف إجراءات. تم إزالة رابط تحريك الفأرة للملف والنقر على الماكرو، بينما تبقى روابط HTTPS والتنقل الداخلي للشرائح. تُظهر التحقق عدم وجود إجراءات محظورة. يطبق إدخال يحتوي على رابط نقرة خارجي محظور فرع الاستبدال أيضًا. حاوية تحتوي على نقرة مسموح بها وتحريك فأرة محظور تحتفظ بإجراء النقر.

هذا التنظيف الانتقائي يختلف عن [removeAllHyperlinks](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) الذي يزيل كلا نوعي التنشيط في جميع أنحاء النطاق المختار بغض النظر عن السياسة. التحقق هنا يختبر فقط إجراءات الروابط التشعبية؛ ولا يزيل مشاريع VBA المضمّنة أو كائنات OLE أو أي محتوى نشط آخر، ولا يتحقق من صحة ملف PDF أو HTML المُصدر.

## **الأسئلة الشائعة**

**كيف يمكنني الربط إلى قسم أو شريحته الأولى؟**

تجمع الأقسام في PowerPoint الشرائح، لكن الرابط التشعبي الداخلي يستهدف شريحة واحدة. لإنشاء تنقل إلى قسم، اربط إلى الشريحة الأولى في ذلك القسم.

**هل يمكنني إرفاق رابط تشعبي لعناصر الشريحة الرئيسية بحيث يعمل على جميع الشرائح؟**

نعم. تدعم عناصر الشريحة الرئيسية والتنسيق الروابط التشعبية. الروابط على هذه العناصر متاحة أثناء عرض الشرائح على الشرائح التي تستخدم الشريحة الرئيسية أو التنسيق المقابل.

**هل سيتم حفظ الروابط التشعبية عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

قد تحتفظ صادرات PDF وHTML المدعومة بالروابط التشعبية؛ ولا يمكن للصور النقطية أو الفيديو الحفاظ عليها. راجع اعتبارات التصدير في [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).