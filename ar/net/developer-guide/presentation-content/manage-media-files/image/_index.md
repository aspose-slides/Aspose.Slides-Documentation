---
title: تحسين إدارة الصور في العروض التقديمية في .NET
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/net/image/
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
- SVG إلى أشكال
- موارد SVG الخارجية
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرّف على كيفية إضافة وإعادة استخدام وربط واستبدال وإدارة الصور النقطية و SVG في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for .NET."
---
## **المقدمة**

توفر Aspose.Slides for .NET عدة طرق للعمل مع الصور، ولكل منها هدف مختلف. يمكنك تخزين صورة في العرض التقديمي، عرضها في إطار صورة، استخدامها كخلفية شريحة، الربط بصورة خارجية، استبدال مصدر صورة مشتركة، أو تحويل محتوى SVG إلى أشكال قابلة للتحرير.

تركّز هذه المقالة على موارد الصور وكيفية استخدامها عبر العرض التقديمي. للحصول على معلومات حول القصّ، الشفافية، التأثيرات، التمدد، وتنسيق آخر يُطبق على إطار صورة فردي، راجع [Picture Frame](/slides/ar/net/picture-frame/).

## **فهم نموذج الصورة**

المفاهيم البرمجية التالية مرتبطة ارتباطًا وثيقًا لكنها ليست قابلة للاستبدال:

- مجموعة صور العرض التقديمي ([presentation image collection](https://reference.aspose.com/slides/ar/net/aspose.slides/iimagecollection/)) تخزن موارد الصور المستخدمة في العرض. استخدم [ImageCollection.AddImage](https://reference.aspose.com/slides/ar/net/aspose.slides/imagecollection/addimage/) لإضافة بيانات الصورة والحصول على مورد [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/).
- إطار الصورة ([picture frame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/)) هو شكل يعرض صورة على شريحة أو تخطيط أو ماستر. استخدم [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addpictureframe/) لوضع مورد صورة على شريحة.
- خلفية الشريحة تستخدم صورة كجزء من تعبئة الشريحة بدلاً من كونها شكلًا؛ لذلك لا تتصرف مثل إطار الصورة.
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/replaceimage/) يستبدل مورد صورة. إذا استخدم عدة عناصر في العرض هذا المورد، فستُستبدل جميعها.
- تحويل SVG إلى أشكال ينشئ أشكال شرائح قابلة للتحرير. بعد التحويل، لا تُدار المحتويات كموارد صورة واحدة.

وبالتالي فإن سير العمل النموذجي هو: إضافة بيانات الصورة إلى مجموعة الصور، الحصول على [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/)، ثم استخدام هذا المورد في إطار صورة أو تعبئة واحدة أو أكثر.

## **إضافة صورة مضمّنة**

لإدراج صورة محلية، اقرأ الملف، أضف بياناته إلى مجموعة الصور، وأنشئ إطار صورة يستخدم الـ `IPPImage` المعاد.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

الصورة التي تُضاف بهذه الطريقة تُضمّن في العرض التقديمي، لذا فإن الملف الناتج لا يعتمد على بقاء ملف الصورة الأصلية متاحًا.

### **إضافة صورة من الويب**

عندما تكون الصورة متاحة عبر HTTP أو HTTPS، قم بتحميل بايتاتها باستخدام `HttpClient`، أضفها إلى مجموعة صور العرض، واستخدم مورد الصورة المعاد بنفس طريقة الصورة المحلية.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

في التطبيقات طويلة التشغيل، أعد استخدام `HttpClient` بدلاً من إنشاء نسخة جديدة لكل طلب. كذلك تحقق من عناوين URL البعيدة، حجميات الاستجابة، وأنواع المحتوى عندما لا يكون المصدر موثوقًا.

## **إعادة استخدام الصور عبر الشرائح**

إذا كانت هناك حاجة لاستخدام نفس الصورة أكثر من مرة، أضفها إلى العرض مرة واحدة وأعد استخدام الـ [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) المعاد عند إنشاء أطر صور إضافية. يوفّر ذلك تحميل البيانات المصدرية نفسها مرارًا ويجعل العلاقة بين مورد الصورة المشترك واستخداماته واضحة.

بالنسبة للرسومات التي يجب أن تظهر تلقائيًا على العديد من الشرائح، مثل شعار الشركة، ضع إطار الصورة على [slide master](/slides/ar/net/slide-master/) أو التخطيط بدلاً من إضافة شكل مكافئ إلى كل شريحة.

## **استخدام صورة كخلفية شريحة**

تُحدَّد صورة الخلفية لتعبئة الشريحة؛ ولا تُضاف كشكل إطار صورة. هذا مفيد عندما يجب أن تغطي الصورة خلفية الشريحة ولا تُعامل ككائن شريحة عادي.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

لخيارات خلفية إضافية، بما في ذلك خلفيات الماستر والتخطيط، راجع [Presentation Background](/slides/ar/net/presentation-background/).

## **الصور المضمّنة والمرتبطة**

للصور المضمّنة والمرتبطة مقايضات مختلفة من حيث القابلية للنقل وحجم الملف:

- **صورة مضمّنة:** تُخزن بيانات الصورة داخل العرض التقديمي. يكون العرض ذاتيًا، لكن حجم الملف يتضمن بيانات الصورة.
- **صورة مرتبطة:** يخزن العرض مسارًا أو عنوان URL لصورة خارجية. يمكن أن يقلل هذا من حجم العرض، لكن يجب أن يبقى المصدر الخارجي متاحًا عند فتح أو عرض العرض.

يمكن إنشاء صورة مرتبطة عن طريق تعيين المسار أو عنوان URL الخارجي عبر [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/ar/net/aspose.slides/islidespicture/linkpathlong/) بدلاً من تضمين بيانات الصورة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

استخدم الصور المرتبطة فقط عندما يكون ببيئة النشر إمكانية موثوقة للوصول إلى المصدر الخارجي. بالنسبة للعرض التقديمي الذي يجب أن يعمل دون اتصال أو يُنقل بين الأنظمة، تكون الصور المضمّنة عادةً أكثر أمانًا.

## **العمل مع صور SVG**

SVG هو تنسيق متجه، لذا يمكن أن يكون مفيدًا للأيقونات، المخططات، والرسومات الأخرى التي يجب أن تتدرّج دون فقدان التفاصيل كما هو الحال مع الصور النقطية. تدعم Aspose.Slides تنسيق SVG كموارد صورة ومصدر لأشكال شرائح قابلة للتحرير.

### **إضافة SVG كصورة**

أنشئ كائنًا من نوع [SvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/svgimage/)، أضفه إلى مجموعة الصور، وضع مورد الصورة الناتج في إطار صورة.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **ملفات SVG ذات الموارد الخارجية**

يمكن أن يشير SVG إلى صور أو أوراق أنماط أو خطوط خارجية. لهذه الحالات، يقدم [SvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/svgimage/) مُنشئات تقبل كائنًا من نوع [IExternalResourceResolver](https://reference.aspose.com/slides/ar/net/aspose.slides.import/iexternalresourceresolver/) وعنوان URI أساسي. يمكن للمُحَلِّل ربط URI نسبي بـ URI مطلق مسموح به وإرجاع تدفق للموارد المطلوبة.

يتيح المُحَلِّل الموارد الخارجية أثناء معالجة Aspose.Slides للـ SVG، لكنه لا يعيد كتابة الـ SVG إلى مستند ذاتي الاِحتواء. إذا كان من الضروري أن يظل الـ SVG قابلًا للنقل، فقم بتضمين موارده المطلوبة داخل الـ SVG نفسه، على سبيل المثال باستخدام عناوين `data:` للصور المرتبطة.

عند جلب ملفات SVG من مصادر غير موثوقة، قُصِّ نطاق المخططات، مواقع الملفات، والمضيفين التي يمكن للمُحَلِّل الوصول إليها. ينبغي على المحللات الشبكية أيضًا تطبيق مهلات، حدود حجم الاستجابة، والتحقق من المحتوى.

### **تحويل SVG إلى أشكال قابلة للتحرير**

يمكن لـ Aspose.Slides تحويل SVG إلى مجموعة من أشكال الشرائح القابلة للتحرير، مماثلة للأمر المقابل في PowerPoint.

![قائمة منبثقة في PowerPoint](img_01_01.png)

استخدم الدالة الزائدة [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addgroupshape/) التي تقبل كائنًا من نوع [ISvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage/) لتنفيذ التحويل.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

استخدم تحويل SVG إلى أشكال عندما تحتاج العناصر المتجهة الفردية إلى تعديلها كأشكال PowerPoint. إذا كان الـ SVG يُعرض فقط، فاحتفظ به كصورة لتبسيط العملية وتفادي إنشاء العديد من الأشكال المنفصلة.

## **استبدال مورد صورة موجود**

استخدم [IPPImage.ReplaceImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/replaceimage/) عندما تريد استبدال مورد صورة موجود. هذا مفيد بشكل خاص للرسومات المشتركة مثل الشعارات.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

إذا كانت أطر صور، خلفيات، ماسترات أو تخطيطات متعددة تستخدم نفس مورد الصورة، فإن استبدال ذلك المورد يحدث تحديثًا لجميع تلك الاستخدامات. إذا كان يجب تغيير إطار صورة واحد فقط، فعيّن صورة مختلفة لذلك الإطار بدلاً من استبدال المورد المشترك.

توفر الدالة `ReplaceImage` أيضًا توابع زائدة تقبل كائنًا من نوع [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) أو [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) آخر.

## **إرشادات عملية لإدارة الصور**

### **التحكم في حجم العرض التقديمي**

يمكن للصور النقطية الكبيرة أن تجعل العرض التقديمي كبيرًا بشكل غير ضروري. استخدم صورًا ذات أبعاد مناسبة لحجم العرض المستهدف، وأعد استخدام موارد الصور المشتركة حيثما أمكن، وتجنّب تضمين نسخ مكررة من نفس الرسوم ذات الدقة الكاملة.

بالنسبة للصور النقطية التي تم وضعها بالفعل في أطر الصور، يمكن لـ [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/compressimage/) تقليل بيانات الصورة وفقًا للدقة وإعدادات القصّ المحددة. هذا يُعَدّ معالجة لإطار الصورة وليس لإدارة مجموعة الصور، لذا راجع [Picture Frame](/slides/ar/net/picture-frame/) للعمليات ذات الصلة.

### **الاختيار بين المحتوى المضمّن والمرتبط**

التضمين يجعل العرض قابلًا للنقل لأن جميع بيانات الصورة المطلوبة تسافر مع الملف. الربط قد يقلل من حجم الملف، لكنه يضيف اعتمادًا خارجيًا. استخدم الروابط فقط عندما يكون هذا الاعتماد مقبولًا ومستقرًا.

### **إعادة استخدام العلامة التجارية المشتركة**

للشعارات المتكررة، العلامات المائية، أو الرسومات الزخرفية، استخدم مورد صورة واحد وأعد استعماله. إذا كان الرسم جزءًا من تصميم العرض بدلاً من محتوى الشريحة، ضعّه على ماستر أو تخطيط لكي يورثه الشرائح المناسبة.

### **الحفاظ على موارد SVG قابلة للنقل**

SVG ذاتي الاِحتواء يكون أسهل للنقل والعرض المتسق مقارنةً بـ SVG يعتمد على ملفات أو موارد شبكة خارجية. عندما يكون ذلك ممكنًا، ضمّن الموارد المطلوبة قبل استيراد الـ SVG. حوِّل SVG إلى أشكال فقط عندما تحتاج إلى تعديل العناصر المتجهة الفردية.

### **استخدام واجهة برمجة تطبيقات الصور الحديثة المتعددة المنصات**

لكود .NET الجديد، استخدم واجهات Aspose.Slides [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) و [Images](https://reference.aspose.com/slides/ar/net/aspose.slides/images/) بدلًا من الاعتماد على `System.Drawing.Image` أو `Bitmap`. راجع [Modern API](/slides/ar/net/modern-api/) للحصول على إرشادات الترحيل.

تتطلب تنسيقات WMF و EMF اعتبارًا خاصًا. عند تمرير هذه التنسيقات عبر كائن [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/)، يقوم [ImageCollection.AddImage](https://reference.aspose.com/slides/ar/net/aspose.slides/imagecollection/addimage/) بتحويل ملف الميتافايل إلى تمثيل PNG نقطي قبل الإدراج. إذا كان الحفاظ على بيانات الميتافايل مهمًا، استخدم نسخة الدالة الزائدة المستندة إلى تدفق من [ImageCollection.AddImage](https://reference.aspose.com/slides/ar/net/aspose.slides/imagecollection/addimage/). إنشاء محتوى EMF من جداول البيانات أو منتجات أخرى هو سير عمل تكامل منفصل وخارج نطاق هذه المقالة.

## **الأسئلة الشائعة**

**ما الفرق بين مجموعة الصور وإطار الصورة؟**

مجموعة الصور تخزّن موارد الصور القابلة لإعادة الاستخدام. إطار الصورة هو شكل شريحة يعرض أحد هذه الموارد ويوفر تنسيقات خاصة بالصور مثل القصّ والتأثيرات.

**ما هي أفضل طريقة لاستبدال الشعار نفسه في كل مكان؟**

إذا كان الشعار مشتركًا كموارد صورة واحدة، استبدل ذلك المورد باستخدام [IPPImage.ReplaceImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/replaceimage/). للعلامة التجارية على مستوى العرض كله، يمكن أيضًا وضع الشعار على ماستر أو تخطيط لتقليل تكرار محتوى الشرائح.

**لماذا تختفي الصورة المرتبطة على كمبيوتر آخر؟**

الصورة المرتبطة تعتمد على ملفها الخارجي أو عنوان URL الخاص بها. إذا تعذّر الوصول إلى ذلك المورد من الكمبيوتر الآخر، قد تصبح الصورة المرتبطة غير متاحة. قم بتضمين الصورة عندما يجب أن يكون العرض ذاتيًا.

**هل يمكن تعديل SVG مُدرج كأشكال PowerPoint؟**

نعم. حوّل الـ SVG باستخدام [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addgroupshape/)؛ المجموعة الناتجة تحتوي على أشكال شريحة قابلة للتحرير بدلاً من صورة SVG واحدة.

**كيف يمكنني الحفاظ على حجم العروض التي تحتوي على عدد كبير من الصور؟**

أعد استخدام موارد الصور المشتركة، وتجنّب مصادر نقطية كبيرة غير ضرورية، وضغط الصور النقطية المناسبة عندما يلزم، واحتفظ بالعلامات التجارية المتكررة على ماسترات أو تخطيطات، واستخدم الصور المرتبطة فقط عندما يكون الاعتماد الخارجي مقبولًا.