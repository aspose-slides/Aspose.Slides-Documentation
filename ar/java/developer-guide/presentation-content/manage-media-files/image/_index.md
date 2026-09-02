---
title: تحسين إدارة الصور في العروض التقديمية باستخدام Java
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/java/image/
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
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة وإعادة استخدام وربط واستبدال وإدارة الصور النقطية و SVG في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Java."
---
## **المقدمة**

توفر Aspose.Slides for Java طرقًا متعددة للعمل مع الصور، وكل طريقة تخدم غرضًا مختلفًا. يمكنك تخزين صورة في العرض التقديمي، عرضها في إطار صورة، استخدامها كخلفية شريحة، ربطها بصورة خارجية، استبدال مورد صورة مشترك، أو تحويل محتوى SVG إلى أشكال قابلة للتحرير.

تركز هذه المقالة على موارد الصورة وكيفية استخدامها عبر العرض التقديمي. للحصول على معلومات حول القصّ، الشفافية، التأثيرات، التمدد، وغيرها من التنسيقات المطبقة على إطار صورة منفرد، راجع [إطار الصورة](/slides/ar/java/picture-frame/).

## **فهم نموذج الصورة**

المفاهيم البرمجية التالية ذات صلة وثيقة ولكنها ليست قابلة للتبادل:

- مجموعة صور العرض التقديمي ([presentation image collection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagecollection/)) تخزن موارد الصور المستخدمة في العرض. استخدم [ImageCollection.addImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imagecollection/) لإضافة بيانات الصورة والحصول على مورد [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/).
- إطار الصورة ([picture frame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/)) هو شكل يعرض صورة على شريحة أو تخطيط أو ماستر. استخدم [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/) لوضع مورد صورة على شريحة.
- خلفية الشريحة تستخدم صورة كجزء من تعبئة الشريحة بدلاً من كونها شكلًا. لذلك لا تتصرف كإطار صورة.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) يستبدل مورد صورة. إذا استخدم عدة عناصر في العرض هذا المورد، فستستخدم جميعها الاستبدال.
- تحويل SVG إلى أشكال يخلق أشكال شريحة قابلة للتحرير. بعد التحويل، لا يُدار المحتوى كصورة واحدة.

وبالتالي يكون سير العمل النموذجي: إضافة بيانات الصورة إلى مجموعة الصور، الحصول على [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/)، ثم استخدام ذلك المورد في إطار صورة أو تعبئة واحدة أو أكثر.

## **إضافة صورة مدمجة**

لإدراج صورة محلية، حمِّل الملف، أضفه إلى مجموعة الصور، وأنشئ إطار صورة يستخدم `IPPImage` المتُرجَع.

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

الصورة التي تُضاف بهذه الطريقة تكون مدمجة في العرض، لذا فإن الملف الناتج لا يعتمد على بقاء ملف الصورة الأصلي متاحًا.

### **إضافة صورة من الويب**

عندما تكون الصورة متاحة عبر HTTP أو HTTPS، قم بتنزيل بايتاتها، أضفها إلى مجموعة صور العرض، واستخدم مورد الصورة المتُرجَع بنفس طريقة الصورة المحلية.

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

في التطبيقات الطويلة التشغيل، أعد استخدام عميل HTTP أو استراتيجية إدارة الاتصالات المناسبة للتطبيق بدلاً من إنشاء بنية شبكية غير ضرورية مرارًا. كما يجب التحقق من عناوين URL البعيدة، حجم الاستجابة، وأنواع المحتوى عندما لا يكون المصدر موثوقًا.

## **إعادة استخدام الصور عبر الشرائح**

إذا احتجت نفس الصورة أكثر من مرة، أضفها إلى العرض مرة واحدة وأعد استخدام [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) المتُرجَع عند إنشاء إطارات صور إضافية. هذا يجنّب تحميل نفس البيانات المصدرية مرارًا ويجعل العلاقة بين مورد الصورة المشترك واستخداماته واضحة.

للرسومات التي يجب أن تظهر تلقائيًا على العديد من الشرائح، مثل شعار الشركة، فكر في وضع إطار الصورة على [ماستر الشريحة](/slides/ar/java/slide-master/) أو التخطيط بدلاً من إضافة شكل مكافئ إلى كل شريحة.

## **استخدام صورة كخلفية شريحة**

يُعيّن صورة الخلفية إلى تعبئة الشريحة؛ لا تُضاف كشكل إطار صورة. هذا مفيد عندما يجب أن تغطي الصورة خلفية الشريحة ولا ينبغي معالجتها ككائن شريحة عادي.

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

لخيارات خلفية إضافية، بما في ذلك خلفيات الماستر والتخطيط، راجع [خلفية العرض](/slides/ar/java/presentation-background/).

## **الصور المدمجة والصور المرتبطة**

للصور المدمجة والمرتبطة مقايضات مختلفة من قابلية النقل وحجم الملف:

- **الصورة المدمجة:** تُخزن بيانات الصورة داخل العرض. يكون العرض مكتفًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًة**: البيانات تُخزن داخل العرض. يكون العرض مكتفًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًًً تمامًا، لكن حجم الملف يشمل بيانات الصورة.
- **الصورة المرتبطة:** يخزن العرض مسارًا أو URL لصورة خارجية. يمكن أن يقلل هذا من حجم العرض، لكن المورد الخارجي يجب أن يبقى متاحًا عندما يُفتح أو يُعرض العرض.

يمكن إنشاء صورة مرتبطة عبر تعيين المسار أو URL الخارجي باستخدام [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidespicture/) بدلاً من دمج بيانات الصورة.

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

استخدم الصور المرتبطة فقط عندما يمكن لبيئة النشر الوصول بموثوقية إلى المورد الخارجي. بالنسبة للعرض الذي يجب أن يعمل دون اتصال أو يُنقل بين الأنظمة، تكون الصور المدمجة عادةً أكثر أمانًا.

## **العمل مع صور SVG**

SVG هو تنسيق متجектор، لذا يمكن أن يكون مفيدًا للأيقونات، المخططات، والرسومات الأخرى التي ينبغي أن تُقاس دون فقدان التفاصيل كما هو الحال مع الصور النقطية. تدعم Aspose.Slides SVG كموارد صورة وكذلك كمصدر لأشكال شريحة قابلة للتحرير.

### **إضافة SVG كصورة**

أنشئ كائنًا من نوع [SvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgimage/)، أضفه إلى مجموعة الصور، وضع مورد الصورة الناتج في إطار صورة.

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

### **ملفات SVG مع موارد خارجية**

يمكن لـ SVG الإشارة إلى صور، أوراق نمط، أو خطوط خارجية. في مثل هذه الحالات، يوفر [SvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/svgimage/) منشئات تقبل كائنًا من نوع [IExternalResourceResolver](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iexternalresourceresolver/) وعنوان URI أساسي. يمكن للمُحَلّل أن يطابق URI نسبي إلى URI مطلق مسموح به ويعيد تدفقًا للموارد المطلوبة.

يُتيح المحلّل الموارد الخارجية أثناء معالجة Aspose.Slides للـ SVG، لكنه لا يعيد كتابة الـ SVG إلى مستند مستقل. إذا كان الـ SVG يجب أن يبقى قابلاً للنقل، قم بدمج موارده المطلوبة داخل الـ SVG نفسه، على سبيل المثال باستخدام عناوين `data:` للصور المرتبطة.

عند جلب ملفات SVG من مصادر غير موثوقة، قُم بتقييد المخططات، مواقع الملفات، والمضيفين التي يمكن للمحلّل الوصول إليها. يجب أن تُطبق المحللات الشبكية أيضًا مهلات زمنية، حدود حجم الاستجابة، والتحقق من المحتوى.

### **تحويل SVG إلى أشكال قابلة للتحرير**

يمكن لـ Aspose.Slides تحويل SVG إلى مجموعة من أشكال شريحة قابلة للتحرير، مشابهة للأمر المقابل في PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

استخدم overload [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/) الذي يقبل كائنًا من نوع [ISvgImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isvgimage/) لإجراء التحويل.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

استخدم تحويل SVG إلى أشكال عندما تحتاج إلى تحرير عناصر متجекторية فردية كأشكال PowerPoint. إذا كان الـ SVG يُراد عرضه فقط، فالحفاظ عليه كصورة أبسط ويتجنب إنشاء العديد من الأشكال المنفصلة.

## **استبدال مورد صورة موجود**

استخدم [IPPImage.replaceImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) عندما تريد استبدال مورد صورة موجود. هذا مفيد بشكل خاص للرسومات المشتركة مثل الشعارات.

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

إذا استخدمت إطارات صور، خلفيات، ماستر أو تخطيطات متعددة نفس مورد الصورة، فإن استبدال ذلك المورد يُحدّث جميع تلك الاستخدامات. إذا كان يجب أن يتغير إطار صورة واحد فقط، فقم بتعيين صورة مختلفة لذلك الإطار بدلاً من استبدال المورد المشترك.

`replaceImage` يُوفر أيضًا overloads تقبل مصفوفة بايت أو مورد [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) آخر.

## **إرشادات عملية لإدارة الصور**

### **التحكم في حجم العرض**

يمكن للصور النقطية الكبيرة أن تجعل العرض كبيرًا بشكل غير ضروري. استخدم صورًا بأبعاد مناسبة لحجم العرض المستهدف، أعد استخدام موارد الصور المشتركة حيثما أمكن، وتجنّب دمج نسخ مكررة من نفس الرسمة عالية الدقة.

للصور النقطية التي وُضعت بالفعل في إطارات صور، يمكن لـ [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipicturefillformat/) تقليل بيانات الصورة وفقًا للدقة المختارة وإعدادات القص. هذا يخص معالجة إطارات الصور وليس إدارة مجموعة الصور، لذا راجع [إطار الصورة](/slides/ar/java/picture-frame/) للعمليات ذات الصلة.

### **الاختيار بين المحتوى المدمج والمرتبط**

الدمج يجعل العرض قابلًا للنقل لأن جميع بيانات الصورة المطلوبة تسافر مع الملف. الربط يمكن أن يقلل حجم الملف، لكنه يُدخل اعتمادًا خارجيًا. استخدم الروابط فقط عندما يكون هذا الاعتماد مقبولًا ومستقرًا.

### **إعادة استخدام العلامة التجارية المشتركة**

للشعارات المتكررة أو العلامات المائية أو الرسومات الزخرفية، استخدم مورد صورة واحد وأعد استخدامه. إذا كانت الرسمة تخص تصميم العرض أكثر من محتوى الشريحة، ضعها على ماستر أو تخطيط لتُورث إلى الشرائح المناسبة.

### **حافظ على موارد SVG قابلة للنقل**

يكون الـ SVG المستقل أسهل للنقل والعرض بشكل متسق من الـ SVG الذي يعتمد على ملفات أو موارد شبكية خارجية. عندما يكون ذلك ممكنًا، دمج الموارد المطلوبة قبل استيراد الـ SVG. حوّل الـ SVG إلى أشكال فقط عندما تحتاج إلى تحرير عناصره المتجекторية الفردية.

### **استخدام واجهة برمجة تطبيقات الصور الحديثة المتعددة المنصات**

للشفرة الجديدة في Java، استخدم واجهات Aspose.Slides [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) و [Images](https://reference.aspose.com/slides/ar/java/com.aspose.slides/images/) بدلاً من واجهة برمجة التطبيقات العامة القديمة القائمة على `java.awt.image.BufferedImage`. راجع [الواجهة الحديثة](/slides/ar/java/modern-api/) للحصول على إرشادات الترحيل.

تتطلب WMF و EMF اعتبارًا خاصًا. عند تمرير هذه الصيغ عبر كائن [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/)، يقوم [ImageCollection.addImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imagecollection/) بتحويل ملف الميتا إلى تمثيل PNG نقطي قبل الإدراج. إذا كان الحفاظ على بيانات الميتا مهمًا، استخدم overload المستند إلى تدفق لـ [ImageCollection.addImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imagecollection/). إنشاء محتوى EMF من جداول البيانات أو منتجات أخرى هو سير عمل تكامل منفصل خارج نطاق هذه المقالة.

## **الأسئلة المتكررة**

**ما الفرق بين مجموعة الصور وإطار الصورة؟**

مجموعة الصور تخزن موارد صور قابلة لإعادة الاستخدام. إطار الصورة هو شكل شريحة يعرض أحد تلك الموارد ويوفر تنسيقات خاصة بالصورة مثل القصّ والتأثيرات.

**ما هي أفضل طريقة لاستبدال الشعار نفسه في كل المواضع؟**

إذا كان الشعار مُشارًا إليه كموارد صورة واحدة مشتركة، استبدل ذلك المورد باستخدام [IPPImage.replaceImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/). للعلامة التجارية على مستوى العرض، وضع الشعار على ماستر أو تخطيط يمكن أن يقلل من تكرار محتوى الشرائح.

**لماذا تختفي صورة مرتبطة على جهاز كمبيوتر آخر؟**

الصورة المرتبطة تعتمد على ملفها الخارجي أو URL. إذا تعذّر الوصول إلى ذلك المورد من الجهاز الآخر، قد تصبح الصورة غير متوفرة. دمج الصورة عندما يجب أن يكون العرض مستقلًا.

**هل يمكن تحرير SVG تم إدراجه كأشكال PowerPoint؟**

نعم. حوّل الـ SVG باستخدام [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/)؛ المجموعة الناتجة تحتوي على أشكال شريحة قابلة للتحرير بدلاً من صورة SVG واحدة.

**كيف يمكنني الحفاظ على عروض تقديمية تحتوي على العديد من الصور أصغر حجمًا؟**

أعد استخدام موارد الصور المشتركة، تجنّب المصادر النقطية الكبيرة غير الضرورية، اضغط الصور النقطية المناسبة عندما يكون ذلك ملائمًا، ضع العلامات التجارية المتكررة على الماستر أو التخطيط، واستخدم الصور المرتبطة فقط عندما يكون الاعتماد الخارجي مقبولًا.