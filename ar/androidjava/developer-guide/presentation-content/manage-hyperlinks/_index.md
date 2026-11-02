---
title: إدارة روابط العرض التقديمي على Android
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
- رابط تشعبي للنص
- رابط تشعبي للشريحة
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
description: "إضافة، تنسيق، تحديث، وإزالة الروابط التشعبية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Android عبر Java، باستخدام أمثلة Java."
---
## **المقدمة**

يُربط الرابط التشعبي محتوى العرض التقديمي بموقع ويب أو بموقع داخل العرض نفسه. في PowerPoint، يُستخدم الرابط التشعبي عادةً لهدفين:

* فتح موقع ويب من النص أو الشكل أو إطار الوسائط.
* الانتقال إلى شريحة أخرى، على سبيل المثال من جدول المحتويات.

يتيح Aspose.Slides for Android عبر Java إضافة هذه الروابط، والتحكم في مظهرها وصوتها، وتحديث خصائصها، وإزالتها. توضح الأمثلة أدناه كيفية العمل مع الروابط التشعبية على العناصر الفردية وكيفية الوصول إلى الروابط على مستوى العرض أو الشريحة أو إطار النص.

{{% alert color="info" title="Note" %}}
يمكنك أيضاً تعديل العروض باستخدام [محرر Aspose PowerPoint المجاني على الإنترنت](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **إضافة روابط URL**

يمكنك إسناد عنوان URL لموقع ويب إلى نص أو شكل أو إطار وسائط. العنصر الذي تُسند إليه الرابط يحدد المنطقة القابلة للنقر: الجزء النصي يربط النص المحدد، بينما الشكل أو الإطار يربط كائن الشريحة.

للعروض التي تحتوي على روابط تشعبية نسبية، راجع [Manage the Hyperlink Base](/slides/ar/androidjava/presentation-properties/#manage-the-hyperlink-base) لقراءة أو تعديل أو مسح الأساس على مستوى المستند.

### **إضافة روابط URL إلى النص**

لربط نص بموقع ويب، مرّر كائن [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlink/) إلى طريقة [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) لجزء النص، كما هو موضح أدناه. يقتصر النقر على ذلك الجزء من النص فقط.

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

لجعل شكل أو إطار قابل للنقر، استدعِ طريقة [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) الخاصة به. ينتمي الرابط التشعبي إلى الكائن نفسه بدلاً من أن يكون جزءًا من النص داخل الكائن.

ينطبق النهج نفسه على إطارات الصور والصوت والفيديو: اسند الرابط إلى الإطار واستدعِ [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) إذا لزم الأمر.

المثال التالي يجعل مستطيلًا قابلاً للنقر:

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

## **استخدام الروابط لإنشاء جدول محتويات**

تتيح الروابط التشعبية الداخلية للقارئ الانتقال من جدول المحتويات إلى شريحة معينة. يستخدم المثال التالي طريقة [setInternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) لربط نص “Page 2” في الشريحة الأولى بالشريحة الثانية.

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

تحدد طريقة [setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) الخاصة بـ[IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) ما إذا كان الرابط يستخدم لون الرابط التشعبي في العرض أو تنسيق جزء النص. لتطبيق لون نص مخصص، اختر [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkcolorsource/) وحدد لون تعبئة الجزء. تم تقديم هذه الميزة في PowerPoint 2019؛ الإصدارات الأقدم لا تطبق هذا الإعداد.

المثال التالي يضيف رابطين نصيين إلى نفس الشريحة. الأول يستخدم تعبئة نص حمراء، بينما يحتفظ الثاني بلون الرابط الافتراضي.

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

يمكن للرابط التشعبي تشغيل صوت عند تنشيطه أو إيقاف صوت قيد التشغيل بالفعل. استخدم الطرق التالية لتكوين هذه السلوكيات:

- [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) يحدد ملف الصوت المرتبط بالرابط.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) يتحكم فيما إذا كان تنشيط الرابط يوقف الصوت السابق.

#### **إضافة صوت للرابط التشعبي**

يقوم المثال التالي بتحميل الملف `sampleaudio.wav` وربطه بزر في الشريحة الأولى. النقر على الزر يشغل الصوت ويُنقلك إلى الشريحة التالية. الشكل الثاني في تلك الشريحة يوقف الصوت السابق عند النقر، دون تنفيذ أي عملية تنقل.

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

#### **استخراج صوت للرابط التشعبي**

يفتح المثال التالي العرض الذي تم إنشاؤه أعلاه ويقرأ الصوت المرتبط بالرابط في الشكل الأول إلى الذاكرة عبر [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getSound--) و[getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

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

### **تلميحات الأدوات وإعدادات التفاعل**

يمكنك استدعاء طرق [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) التالية بعد إسناد رابط إلى نص أو شكل:

- [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) يحدد النص الذي يمكن للمشاهد عرضه كشرح مختصر للرابط.
- [setTargetFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) يحدد إطار الهدف داخل مجموعة إطارات HTML أصلية، إذا كان ذلك مناسبًا.
- [setHistory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) يتحكم فيما إذا كان تنشيط الرابط يضيف هدفه إلى قائمة الروابط المشاهدة.
- [setHighlightClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) يتحكم فيما إذا كان الرابط يُظهر تمييزًا عند النقر.

## **إزالة الروابط من العروض**

استخدم [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) لجمع حاويات الروابط، بما في ذلك روابط أجزاء النص، قبل تعديلها. يزيل المثال التالي كلا نوعي التنشيط من الشريحة الأولى. لإزالة نوع واحد فقط، استدعِ إما [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) أو [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); إزالة فعل النقر لا يزيل الفعل المقابل عند التمرير فوق الفأرة.

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

لإزالة غير مشروطة، تقوم [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) بإزالة كلا نوعي التنشيط في النطاق المحدد بنداء واحد. للحصول على تنظيف انتقائي وتغطية الماسترز، التخطيطات، والملاحظات، راجع [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **إنشاء جرد كامل للروابط التشعبية**

قبل توزيع عرض، قم بجرد الإجراءات التفاعلية وروابط الويب الخاصة به. تُرجع [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) كائنات من نوع [IHyperlinkContainer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/) وليس قائمة مسطحة من سلاسل URL. راجع كلًا من [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) و[getHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) على كل حاوية. هي مستقلة: يمكن لنفس الحاوية أن تعرض كلا الفعلين، لذا يتطلب التقرير الكامل ما يصل إلى صفين لكل حاوية.

قد يؤدي فحص الروابط على مستوى الشكل فقط إلى فقدان الروابط المرفقة بأجزاء النص. استعلم النطاق المناسب بدلًا من ذلك، واحتفظ بالحاويات المسترجعة لتتمكن لاحقًا من تحديث أو إزالة أفعالها.

### **استعلام نطاقات العرض والشريحة وإطار النص**

واجهة [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/) متاحة عبر [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--)، [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--)، و[ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). كل نطاق يدعم نفس الاستعلامات:

- [getHyperlinkClicks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) يُعيد الحاويات التي لها فعل نقر.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) يُعيد الحاويات التي لها فعل تمرير فوق الفأرة.
- [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) يُعيد الحاويات التي لها أحد الفعلين أو كليهما.

ينشئ المثال التالي الملف `hyperlink-audit-input.pptx` مع رابط نقر خارجي، ورابط تمرير فوق ملف، وتنقل داخلي إلى شريحة، ورابط تمرير فوق نص، وإجراء ماكرو. لا يُنفّذ أيًا من هذه الأفعال. تعمل الاستعلامات الثلاثة نفسها في كل نطاق؛ الأعداد تُعطي عدد الحاويات، لا مجموع الأفعال. يستثني نطاق إطار النص الروابط الخاصة بالشكل المحيط.

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

في هذا المثال، تُظهر استعلامات العرض والشريحة ثلاث حاويات نقر، وحاويتين تمرير فوق الفأرة، وثلاث حاويات إما فعلًا أو كلاهما. يُظهر استعلام إطار النص حاوية واحدة في كل فئة.

### **تصنيف الأفعال والوجهات**

استخدم [IHyperlink.getActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getActionType--) لتفسير الفعل قبل تفسير وجهته. تغطي قيم [HyperlinkActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkactiontype/) أكثر من مجرد تنقل ويب:

| القيم | المعنى للتدقيق |
| --- | --- |
| `Hyperlink` | رابط خارجي؛ افحص URL ومخططه. |
| `JumpSpecificSlide` | تنقل داخلي إلى شريحة محددة. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | تنقل ضمن عرض الشرائح المدمج، يُفسر في سياق العرض. |
| `JumpEndShow`, `StartCustomSlideShow` | إنهاء العرض الحالي أو بدء عرض مخصص. |
| `StartMacro` | تشغيل ماكرو. |
| `StartProgram` | إطلاق برنامج. |
| `OpenFile`, `OpenPresentation` | فتح ملف أو عرض تقديمي آخر؛ يُراجع منفصلًا عن روابط الويب. |
| `StartStopMedia` | بدء أو إيقاف تشغيل وسائط. |
| `NoAction`, `Unknown` | لا توجد عملية تنقل، أو فعل غير معروف يتطلب مراجعة. |

اقرأ الوجهات الخارجية من [getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) والوجهات الداخلية المحددة من [getTargetSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). قد لا تحتوي الإجراءات الداخلية أو الأوامر المدمجة على URL خارجي؛ وجود URL فارغ لا يعني أن الحاوية لا تحتوي على فعل. احتفظ بالقيمة التي تُعيدها [getExternalUrlOriginal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) عندما تختلف عن URL المُعْدَل، وتضمّن تلميح الأدوات الذي تُعيده [getTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) إذا كان متوفرًا.

### **التقرير، التنظيف، والتحقق من الروابط**

يعرض مثال Java التالي قراءة عرض موجود (استخدم الملف الذي تم إنشاؤه أعلاه)، كتابة `hyperlink-audit.json`، تطبيق سياسة، حفظ `hyperlink-sanitized.pptx`، وإعادة فتحه للتحقق من كلا نوعي التنشيط مرة أخرى. يجمع الحاويات قبل تعديلها ويستخدم مساواة المرجع لتجنب معالجة نفس الحاوية مرتين. تغطي استعلامات العرض الشرائح العادية؛ للحصول على جرد على مستوى الحزمة، يتم استعلام الماسترز، التخطيطات، الملاحظات، وكذلك ماستر الملاحظات ونشرات اليد عند وجودها.

يسجل التقرير فهرس شريحة يبدأ من 1 و[getSlideId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) عندما يكون متاحًا. توفر [ISlideComponent.getSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecomponent/#getSlide--) الشريحة المالكة للحاويات المدعومة. الماسترز، التخطيطات، والملاحظات لا تملك فهرس شريحة عادي وتُعرّف بنطاقها. تُصنّف حاويات الشكل وحاويات تنسيق جزء النص بشكل منفصل؛ أنواع الحاويات الأخرى تحتفظ باسم نوعها في وقت التشغيل. يحصل كل حاوية على معرف محلي في التقرير لربط فعلَيها. يُخزن التقرير أنواع الأفعال كقيم عددية معرفة في تعداد Java.

تسمح هذه السياسة التطبيقية المقيدة بتطبيق روابط HTTPS مطلقة فقط وأهداف شرائح داخلية صالحة. تُرفض ماكروهات، برامج، إجراءات ملفات، أفعال عروض الشرائح الأخرى، أفعال غير معروفة، ومخططات URL أخرى. هذه الرفضات هي قرارات سياسة، لا حكم أمان من Aspose.Slides. HTTPS وحده لا يضمن الثقة: أضف قوائم السماح للمضيف وفحوصات أخرى لتطبيقك. يتم فحص كل من URL الأصلي والـ URL المُعْدَل. لا يتتبع المثال الروابط أو ينفّذ الأفعال.

للإصلاح، يدعم [getHyperlinkManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) في الحاوية طرقًا مثل [setExternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-)، [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--)، و[removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). هنا، تُستبدل الروابط الخارجية غير المسموح بها بصفحة هبوط HTTPS ثابتة؛ تُزال الروابط والنقرات غير المسموح بها الأخرى بشكل مستقل. اضبط `replaceExternalClicks` إلى `false` لإزالة جميع الانتهاكات. اختر صفحة بديلة مملوكة لتطبيقك قبل النشر.

تستخدم علامة تصدير التقرير سياسة مراجعة PDF متحفظة: تُعلّم أفعال تمرير الفأرة وأي شيء غير رابط خارجي أو قفزة شريحة محددة على أنه قد لا يُدعم. هذه إشارة مراجعة، ليست اختبار قدرة أو ضمان بقاء الروابط غير الموسومة عند التصدير. قد تحافظ عمليات التصدير إلى [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/) و[HTML](/slides/ar/androidjava/convert-powerpoint-to-html/) على الروابط حسب الفعل، خيارات التصدير، والمشاهد. لا يمكن للصور [Raster](/slides/ar/androidjava/convert-powerpoint-to-png/) والفيديو [Video](/slides/ar/androidjava/convert-powerpoint-to-video/) حفظ الروابط التفاعلية؛ علّم كل فعل عندما تُجري تدقيقًا لتلك المخرجات.

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

    // تسلسل صفوف التقرير المسطحة دون اعتماد إضافي على JSON.
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

مع الإدخال الذي تم إنشاؤه أعلاه، يحتوي التقرير على خمسة صفوف أفعال. يُزال رابط تمرير الفأرة للملف والماكرو، بينما تُبقى الروابط HTTPS والتنقل الداخلي إلى الشرائح. يطبع التحقق صفر أفعال محظورة. يُظهر إدخال يحتوي على رابط نقر خارجي محظور فرع الاستبدال. الحاوية ذات النقر المسموح به وتمرير الفأرة المحظور تحتفظ بفعل النقر فقط.

يختلف هذا التنظيف الانتقائي عن [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) الذي يزيل كلا نوعي التنشيط في النطاق المحدد بغض النظر عن السياسة. يختص التحقق هنا بفحص أفعال الروابط فقط؛ لا يزيل مشاريع VBA المضمنة، كائنات OLE، أو محتوى نشط آخر، ولا يتحقق من ملفات PDF أو HTML المصدرة.

## **الأسئلة الشائعة**

**كيف يمكنني ربط قسم أو أول شريحة له؟**

تُجمّع الأقسام في PowerPoint الشرائح، لكن الرابط الداخلي يستهدف شريحة فردية. لإنشاء تنقل إلى قسم، اربط إلى أول شريحة في ذلك القسم.

**هل يمكنني إرفاق رابط تشعبي لعناصر شريحة الماستر بحيث يعمل على جميع الشرائح؟**

نعم. تدعم عناصر شريحة الماستر والتخطيط الروابط التشعبية. تكون الروابط على هذه العناصر متاحة خلال عرض الشرائح على الشرائح التي تستخدم الماستر أو التخطيط المقابل.

**هل ستُحفظ الروابط عند التصدير إلى PDF أو HTML أو صور أو فيديو؟**

قد تحافظ عمليات تصدير PDF وHTML المدعومة على الروابط؛ لا يمكن للصور النقطية والفيديو الحفاظ على الروابط التفاعلية. راجع اعتبار التصدير في [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).