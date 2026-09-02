---
title: تحسين إدارة الصور في العروض التقديمية على Android
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/androidjava/image/
keywords:
- إضافة صورة
- إضافة صورة
- استبدال صورة
- مجموعة الصور
- إطار صورة
- صورة مرتبطة
- خلفية
- إضافة PNG
- إضافة JPG
- إضافة SVG
- تحويل SVG إلى أشكال
- موارد SVG الخارجية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعرّف على كيفية إضافة، إعادة استخدام، ربط، استبدال وإدارة الصور النقطية وSVG في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **المقدمة**

توفر Aspose.Slides للـ Android عبر Java عدة طرق للعمل مع الصور، وكل طريقة تخدم هدفًا مختلفًا. يمكنك تخزين صورة في عرض تقديمي، عرضها في إطار صورة، استخدامها كخلفية شريحة، ربطها بصورة خارجية، استبدال مورد صورة مشترك، أو تحويل محتوى SVG إلى أشكال قابلة للتحرير.

تركز هذه المقالة على موارد الصور وكيفية استخدامها عبر العرض التقديمي. للحصول على معلومات حول القص، الشفافية، التأثيرات، التمدد، وتنسيقات أخرى تُطبق على إطار صورة منفرد، راجع [إطار الصورة](/slides/ar/androidjava/picture-frame/).

## **فهم نموذج الصورة**

المفاهيم التالية في واجهة برمجة التطبيقات مرتبطة ارتباطًا وثيقًا ولكنها ليست قابلة للتبادل:

- تجمع [presentation image collection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagecollection/) يخزن موارد الصور المستخدمة في العرض التقديمي. استخدم [ImageCollection.addImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imagecollection/) لإضافة بيانات صورة والحصول على مورد [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/).
- [picture frame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) هو شكل يعرض صورة على شريحة أو تخطيط أو ماستر. استخدم [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/) لوضع مورد صورة على شريحة.
- خلفية الشريحة تستخدم صورة كجزء من تعبئة الشريحة بدلاً من كونها شكلًا. لذلك لا تتصرف كإطار صورة.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) يستبدل مورد صورة. إذا استخدم عدة عناصر في العرض التقديمي ذلك المورد، فإن جميعها يستخدمون الاستبدال.
- تحويل SVG إلى أشكال يُنشئ أشكال شريحة قابلة للتحرير. بعد التحويل، لا يُدار المحتوى كموارد صورة واحدة.

وبالتالي فإن سير العمل النموذجي هو: إضافة بيانات الصورة إلى تجمع الصور، استلام [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/)، ثم استخدام ذلك المورد في إطار صورة أو تعبئة واحدة أو أكثر.

## **إضافة صورة مدمجة**

لإدراج صورة محلية، حمّل الملف، أضفه إلى تجمع الصور، وأنشئ إطار صورة يستخدم `IPPImage` المرتجع.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الصورة المضافة بهذه الطريقة تكون مدمجة في العرض التقديمي، لذا لا يعتمد الملف الناتج على بقاء ملف الصورة الأصلي متاحًا.

### **إضافة صورة من الويب**

عند توفر صورة عبر HTTP أو HTTPS، قم بتنزيل بايتاتها، أضفها إلى تجمع صور العرض التقديمي، واستخدم مورد الصورة المرتجع بنفس طريقة الصورة المحلية.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

في التطبيقات طويلة التشغيل، أعد استخدام عميل HTTP أو استراتيجية إدارة الاتصالات المناسبة للتطبيق بدلاً من إنشاء بنية تحتية شبكية غير ضرورية بشكل متكرر. كما يُنصح بالتحقق من عناوين URL البعيدة، أحجام الاستجابات، وأنواع المحتوى عندما لا يكون المصدر موثوقًا.

## **إعادة استخدام الصور عبر الشرائح**

إذا كانت الحاجة إلى نفس الصورة أكثر من مرة، أضفها إلى العرض التقديمي مرة واحدة وأعد استخدام [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) المرتجع عند إنشاء أطر صورة إضافية. هذا يُجنب تحميل بيانات المصدر نفسها مرارًا ويجعل العلاقة بين مورد الصورة المشترك واستخداماته واضحة.

للرسومات التي يجب أن تظهر تلقائيًا على العديد من الشرائح، مثل شعار الشركة، ضع إطار الصورة على [slide master](/slides/ar/androidjava/slide-master/) أو التخطيط بدلاً من إضافة شكل مكافئ إلى كل شريحة.

## **استخدام صورة كخلفية شريحة**

تُعيّن صورة الخلفية إلى تعبئة الشريحة؛ لا تُضاف كشكل إطار صورة. هذا مفيد عندما يجب أن تغطي الصورة خلفية الشريحة ولا ينبغي تعديلها ككائن شريحة عادي.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لمزيد من خيارات الخلفية، بما في ذلك خلفيات الماستر والتخطيط، راجع [Presentation Background](/slides/ar/androidjava/presentation-background/).

## **الصور المدمجة والصور المرتبطة**

الصور المدمجة والمرتبطة لها مقايضات مختلفة من حيث القابلية للنقل وحجم الملف:

- **صورة مدمجة:** تُخزن بيانات الصورة داخل العرض التقديمي. يكون العرض التقديمي مكتملًا ذاتيًا، لكن حجم الملف يشمل بيانات الصورة.
- **صورة مرتبطة:** يخزن العرض التقديمي مسارًا أو URL إلى صورة خارجية. يمكن أن يقلل ذلك من حجم العرض التقديمي، لكن المورد الخارجي يجب أن يظل متاحًا عند فتح أو عرض العرض.

يمكن إنشاء صورة مرتبطة عن طريق تعيين المسار أو URL الخارجي عبر [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidespicture/) بدلاً من دمج بيانات الصورة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

استخدم الصور المرتبطة فقط عندما يكون بيئة النشر قادرة على الوصول إلى المورد الخارجي بثقة. بالنسبة للعرض التقديمي الذي يجب أن يعمل دون اتصال أو يُنقل بين الأنظمة، تكون الصور المدمجة عادةً أكثر أمانًا.

## **العمل مع صور SVG**

SVG هو تنسيق متجktor، لذا يمكن أن يكون مفيدًا للأيقونات والرسوم التخطيطية والرسومات الأخرى التي يجب أن تتوسع دون فقدان التفاصيل كما في الصور النقطية. تدعم Aspose.Slides SVG كموارد صورة ومصدر لأشكال شريحة قابلة للتحرير.

### **إضافة SVG كصورة**

أنشئ [SvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/svgimage/)، أضفه إلى تجمع الصور، وضع مورد الصورة الناتج في إطار صورة.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ملفات SVG ذات الموارد الخارجية**

يمكن أن يشير SVG إلى صور أو أوراق أنماط أو خطوط خارجية. في هذه الحالات، يوفر [SvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/svgimage/) مُنشئات تقبل [IExternalResourceResolver](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iexternalresourceresolver/) وURI أساسي. يمكن للمُحَلٍّ تحويل URI نسبي إلى URI مطلق مسموح وإرجاع تدفق للمورد المطلوب.

المُحَلٍّ يجعل الموارد الخارجية متاحة أثناء معالجة Aspose.Slides للـ SVG، لكنه لا يُعيد كتابة الـ SVG إلى مستند مستقل. إذا كان يجب أن يبقى الـ SVG قابلًا للنقل، قم بدمج موارده المطلوبة داخل الـ SVG نفسه، على سبيل المثال باستخدام عناوين `data:` للصور المرتبطة.

عند جلب ملفات SVG من مصادر غير موثوقة، قُم بتقييد المخططات، مواقع الملفات، والمضيفين التي يمكن للمُحَلٍّ الوصول إليها. يجب أن تطبق حلول الشبكة أيضًا مهلات، حدود حجم الاستجابة، والتحقق من المحتوى.

### **تحويل SVG إلى أشكال قابلة للتحرير**

يمكن لـ Aspose.Slides تحويل SVG إلى مجموعة من أشكال شريحة قابلة للتحرير، مشابهًا لأمر PowerPoint المقابل.

![قائمة منبثقة في PowerPoint](img_01_01.png)

استخدم التحميل الزائد لـ [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/) الذي يقبل [ISvgImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isvgimage/) لأداء التحويل.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

استخدم تحويل SVG إلى أشكال عندما تحتاج إلى تعديل عناصر المتجه الفردية كأشكال PowerPoint. إذا كان الهدف فقط عرض الـ SVG، يبقى الاحتفاظ به كصورة أبسط ويُجنب إنشاء الكثير من الأشكال المنفصلة.

## **استبدال مورد صورة موجود**

استخدم [IPPImage.replaceImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) عندما تريد استبدال مورد صورة موجود. هذا مفيد بشكل خاص للرسومات المشتركة مثل الشعارات.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إذا استخدمت أطر صورة أو خلفيات أو ماسترات أو تخطيطات متعددة نفس مورد الصورة، فإن استبدال ذلك المورد سيُحدّث جميع تلك الاستخدامات. إذا كان يجب تغيير إطار صورة واحد فقط، فعيّن صورة مختلفة لذلك الإطار بدلاً من استبدال المورد المشترك.

`replaceImage` يوفر أيضًا تحميلًا زائدًا يقبل مصفوفة بايت أو [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) آخر.

## **إرشادات عملية لإدارة الصور**

### **التحكم في حجم العرض التقديمي**

يمكن للصور النقطية الكبيرة أن تجعل العرض التقديمي كبيرًا بلا داعٍ. استخدم صورًا بأبعاد مناسبة لحجم العرض المستهدف، أعد استخدام موارد الصور المشتركة حيثما أمكن، وتجنب دمج نسخ مكررة من نفس الرسمة عالية الدقة.

للصور النقطية التي تم وضعها بالفعل في أطر الصورة، يمكن لـ [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipicturefillformat/) تقليل بيانات الصورة وفقًا للدقة المختارة وإعدادات القطع. هذا معالجة لإطار الصورة وليس لإدارة تجمع الصور، لذا راجع [إطار الصورة](/slides/ar/androidjava/picture-frame/) للعمليات التنسيقية ذات الصلة.

### **الاختيار بين المحتوى المدمج والمرتبط**

الدمج يجعل العرض التقديمي محمولًا لأن جميع بيانات الصورة المطلوبة تنتقل مع الملف. الارتباط يمكن أن يقلل حجم الملف، لكنه يُدخل اعتمادًا خارجيًا. استخدم الروابط فقط عندما يكون هذا الاعتماد مقبولًا ومستقرًا.

### **إعادة استخدام العلامة التجارية المشتركة**

للشعارات المتكررة أو العلامات المائية أو الرسومات الزخرفية، استخدم مورد صورة واحد وأعد استخدامه. إذا كان العنصر الرسومي جزءًا من تصميم العرض وليس محتوى الشريحة، ضعّه على ماستر أو تخطيط لتوريثه إلى الشرائح المناسبة.

### **الحفاظ على موارد SVG قابلة للنقل**

SVG المستقل أسهل في النقل والعرض بثبات مقارنةً بـ SVG يعتمد على ملفات أو موارد شبكة خارجية. عندما يكون ذلك ممكنًا، دمج الموارد المطلوبة قبل استيراد الـ SVG. حوّل SVG إلى أشكال فقط عندما تحتاج إلى تعديل عناصر المتجه الفردية.

### **استخدام واجهة برمجة الصور الحديثة متعددة المنصات**

للكود الجديد للـ Android عبر Java، استخدم واجهات Aspose.Slides [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/) و[Images](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/images/) بدلاً من واجهة برمجة التطبيقات العامة القديمة القائمة على `android.graphics.Bitmap`. راجع [Modern API](/slides/ar/androidjava/modern-api/) للحصول على إرشادات الترحيل.

تتطلب WMF وEMF اعتبارًا خاصًا. عندما يتم تمرير هذه التنسيقات عبر [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/)، يقوم [ImageCollection.addImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imagecollection/) بتحويل ملف الميتا إلى تمثيل PNG نقطي قبل الإدراج. إذا كان الحفاظ على بيانات الميتا مهمًا، استخدم التحميل الزائد لـ [ImageCollection.addImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imagecollection/) القائم على التدفق. إنشاء محتوى EMF من جداول البيانات أو منتجات أخرى هو سير عمل تكامل منفصل ولا يندرج ضمن نطاق هذه المقالة.

## **الأسئلة الشائعة**

**ما الفرق بين تجمع الصور وإطار الصورة؟**

تجمع الصور يخزن موارد الصور القابلة لإعادة الاستخدام. إطار الصورة هو شكل شريحة يعرض أحد تلك الموارد ويوفر تنسيقات خاصة بالصورة مثل القص والتأثيرات.

**ما هي أفضل طريقة لاستبدال الشعار نفسه في كل مكان؟**

إذا كان الشعار مُشاركًا كمورد صورة واحد، استبدل ذلك المورد باستخدام [IPPImage.replaceImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/). للعلامة التجارية على مستوى العرض التقديمي، يمكن أيضًا وضع الشعار على ماستر أو تخطيط لتقليل المحتوى المكرر في الشرائح.

**لماذا تختفي الصورة المرتبطة على جهاز كمبيوتر آخر؟**

الصورة المرتبطة تعتمد على ملفها الخارجي أو URL الخاص بها. إذا تعذر الوصول إلى ذلك المورد من الكمبيوتر الآخر، قد تصبح الصورة المرتبطة غير متوفرة. دمج الصورة عندما يجب أن يكون العرض التقديمي مكتملًا ذاتيًا.

**هل يمكن تحرير SVG المدخل كأشكال PowerPoint؟**

نعم. حوّل SVG باستخدام [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/)؛ المجموعة الناتجة تحتوي على أشكال شريحة قابلة للتحرير بدلًا من صورة SVG واحدة.

**كيف يمكنني الحفاظ على عروض تقديمية تحتوي على الكثير من الصور أصغر حجمًا؟**

أعد استخدام موارد الصور المشتركة، تجنّب مصادر نقطية كبيرة غير ضرورية، اضغط الصور النقطية المناسبة عندما يكون ذلك مناسبًا، احتفظ بالعلامة التجارية المتكررة على ماسترات أو تخطيطات، واستخدم الصور المرتبطة فقط عندما يكون الاعتماد الخارجي مقبولًا.