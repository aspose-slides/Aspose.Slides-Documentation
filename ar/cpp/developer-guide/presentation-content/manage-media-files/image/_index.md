---
title: تحسين إدارة الصور في العروض التقديمية باستخدام C++
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/cpp/image/
keywords:
- إضافة صورة
- إضافة صورة
- استبدال صورة
- مجموعة الصور
- إطار الصورة
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
- C++
- Aspose.Slides
description: "تعرّف على كيفية إضافة الصور وإعادة استخدامها وربطها واستبدالها وإدارتها، سواء كانت raster أو SVG، في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ C++."
---
## **المقدمة**

توفر Aspose.Slides للـ C++ عدة طرق للعمل مع الصور، وكل طريقة تخدم غرضًا مختلفًا. يمكنك تخزين صورة في عرض تقديمي، عرضها في إطار صورة، استخدامها كخلفية شريحة، ربطها بصورة خارجية، استبدال مورد صورة مشترك، أو تحويل محتوى SVG إلى أشكال قابلة للتحرير.

يركز هذا المقال على موارد الصور وكيفية استخدامها عبر العرض التقديمي. لتقصير، الشفافية، التأثيرات، التمدد، وتنسيقات أخرى تُطبق على إطار صورة فردي، راجع [إطار الصورة](/slides/ar/cpp/picture-frame/).

## **فهم نموذج الصورة**

المفاهيم البرمجية التالية مترابطة لكنها ليست قابلة للاستبدال:

- مجموعة صور العرض التقديمي [IImageCollection]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimagecollection/) تخزن موارد الصور المستخدمة في العرض. استخدم [IImageCollection::AddImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimagecollection/addimage/) لإضافة بيانات الصورة والحصول على مورد [IPPImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/).
- إطار الصورة [IPictureFrame]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) هو شكل يعرض صورة على شريحة أو تخطيط أو ماستر. استخدم [IShapeCollection::AddPictureFrame]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/addpictureframe/) لوضع مورد صورة على شريحة.
- خلفية الشريحة تستخدم صورة كجزء من تعبئة الشريحة وليس كشكل، لذا لا تتصرف كإطار صورة.
- [IPPImage::ReplaceImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/replaceimage/) تستبدل مورد صورة. إذا كان عدة عناصر في العرض تستخدم ذلك المورد، فإنها جميعًا تستخدم البديل.
- تحويل SVG إلى أشكال ينشئ أشكال شريحة قابلة للتحرير. بعد التحويل، لا يُدار المحتوى كموارد صورة واحدة.

لذا، سير العمل النموذجي هو: إضافة بيانات الصورة إلى مجموعة الصور، الحصول على [IPPImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/)، ثم استخدام هذا المورد في إطار صورة واحد أو أكثر أو في التعبئات.

## **إضافة صورة مدمجة**

لإدراج صورة محلية، اقرأ الملف، أضف بياناتها إلى مجموعة الصور، وأنشئ إطار صورة يستخدم مورد [IPPImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) المُعاد.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

الصورة المضافة بهذه الطريقة مدمجة في العرض التقديمي، لذا الملف الناتج لا يعتمد على بقاء ملف الصورة الأصلي متوفرًا.

### **إضافة صورة من الويب**

عند توفر صورة عبر HTTP أو HTTPS، حمّل بايتاتها، أضفها إلى مجموعة صور العرض، واستخدم المورد المُعاد بنفس طريقة الصورة المحلية.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

تحقق من صحة عناوين URL البعيدة، أحجام الاستجابة، وأنواع المحتوى عندما لا تكون المصدر موثوقًا. في التطبيقات التي تستخدم عميل HTTP آخر، يمكنك تحميل الصورة بالعميل نفسه وتمرير البايتات أو الدفق إلى [IImageCollection::AddImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimagecollection/addimage/).

## **إعادة استخدام الصور عبر الشرائح**

إذا احتجت نفس الصورة أكثر من مرة، أضفها إلى العرض مرة واحدة وأعد استخدام [IPPImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) المُعاد عند إنشاء أطر صور إضافية. هذا يتجنب تحميل بيانات المصدر نفسها مرارًا ويجعل العلاقة بين مورد الصورة المشترك واستخداماته واضحة.

للرسومات التي يجب أن تظهر تلقائيًا على العديد من الشرائح، مثل شعار الشركة، فكر في وضع إطار الصورة على [ماستر الشريحة](/slides/ar/cpp/slide-master/) أو التخطيط بدلاً من إضافة شكل مكافئ إلى كل شريحة.

## **استخدام صورة كخلفية شريحة**

تُعيَّن صورة الخلفية إلى تعبئة الشريحة؛ ولا تُضاف كشكل إطار صورة. هذا مفيد عندما يجب أن تغطي الصورة خلفية الشريحة ولا تُعامل ككائن شريحة عادي.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

لخيارات خلفية إضافية، بما في ذلك خلفيات الماستر والتخطيط، راجع [خلفية العرض التقديمي](/slides/ar/cpp/presentation-background/).

## **الصور المدمجة والصور المرتبطة**

للطابع المدمج والصور المرتبطة ميزات مختلفة من حيث قابلية النقل وحجم الملف:

- **صورة مدمجة:** تُخزن بيانات الصورة داخل العرض التقديمي. يكون العرض مكتفيًا ذاتيًا، لكن حجم الملف يشمل بيانات الصورة.
- **صورة مرتبطة:** يخزن العرض مسارًا أو عنوان URL لصورة خارجية. يمكن أن يقلل هذا من حجم العرض، لكن المورد الخارجي يجب أن يبقى متاحًا عند فتح أو عرض العرض.

يمكن إنشاء صورة مرتبطة عن طريق تعيين المسار أو URL الخارجي عبر [ISlidesPicture::set_LinkPathLong]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidespicture/set_linkpathlong/) بدلاً من دمج بيانات الصورة.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

استخدم الصور المرتبطة فقط عندما يمكن لبيئة النشر الوصول بشكل موثوق إلى المورد الخارجي. بالنسبة للعرض الذي يجب أن يعمل دون اتصال أو يُنقل بين الأنظمة، تكون الصور المدمجة عادةً أكثر أمانًا.

## **العمل مع صور SVG**

SVG هو تنسيق متجه، لذا يمكن أن يكون مفيدًا للأيقونات والمخططات والرسومات الأخرى التي يجب أن تتوسع دون فقدان التفاصيل كما هو الحال مع الصور النقطية. تدعم Aspose.Slides SVG كموارد صورة ومصدر لأشكال شريحة قابلة للتحرير.

### **إضافة SVG كصورة**

أنشئ [SvgImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/svgimage/)، أضفه إلى مجموعة الصور، وضع مورد الصورة الناتج في إطار صورة.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **ملفات SVG ذات الموارد الخارجية**

يمكن لـ SVG الإشارة إلى صور أو أوراق أنماط أو خطوط خارجية. لهذه الحالات، يوفر [SvgImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/svgimage/) منشئات تقبل [IExternalResourceResolver]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides.import/iexternalresourceresolver/) وURI أساسي. يستطيع المُحَلّ تحويل URI نسبي إلى URI مطلق مسموح وإرجاع دفق للمورد المطلوب.

يُتيح المُحَلّ الموارد الخارجية أثناء معالجة Aspose.Slides للـ SVG، لكنه لا يعيد كتابة الـ SVG إلى مستند مكتفي ذاتيًا. إذا كان يجب أن يبقى الـ SVG قابلًا للنقل، دمج موارده المطلوبة داخل الـ SVG نفسه، على سبيل المثال باستخدام عناوين `data:` للصور المرتبطة.

عند جلب ملفات SVG من مصادر غير موثوقة، قصر المخططات ومواقع الملفات والمضيفين التي يمكن للمُحَلّ الوصول إليها. يجب أن تطبق حلول الشبكة مهلات زمنية، حدود حجم الاستجابة، والتحقق من المحتوى.

### **تحويل SVG إلى أشكال قابلة للتحرير**

يمكن لـ Aspose.Slides تحويل SVG إلى مجموعة من أشكال شريحة قابلة للتحرير، مشابهة للأمر المقابل في PowerPoint.

![قائمة منبثقة في PowerPoint](img_01_01.png)

استخدم تجاوز [IShapeCollection::AddGroupShape]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/addgroupshape/) الذي يقبل [ISvgImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/) لإجراء التحويل.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

استخدم التحويل من SVG إلى أشكال عندما تحتاج عناصر المتجه الفردية إلى تعديل كأشكال PowerPoint. إذا كان الـ SVG يحتاج فقط إلى عرض، فالحفاظ عليه كصورة أبسط ويجنب إنشاء العديد من الأشكال المنفصلة.

## **استبدال مورد صورة موجود**

استخدم [IPPImage::ReplaceImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/replaceimage/) عندما تريد استبدال مورد صورة موجود. هذا مفيد خصوصًا للرسومات المشتركة مثل الشعارات.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

إذا استخدمت أطر صور أو خلفيات أو ماسترات أو تخطيطات متعددة نفس مورد الصورة، فإن استبدال هذا المورد يحدث تحديثًا لجميع تلك الاستخدامات. إذا كان يجب تغيير إطار صورة واحد فقط، عيّن صورة مختلفة لذلك الإطار بدلاً من استبدال المورد المشترك.

[IPPImage::ReplaceImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/replaceimage/) يوفر أيضًا تجاوزات تقبل [IImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) أو [IPPImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) آخر.

## **إرشادات عملية لإدارة الصور**

### **التحكم في حجم العرض التقديمي**

يمكن للصور النقطية الكبيرة أن تجعل العرض كبيرًا بشكل غير ضروري. استخدم صورًا بأبعاد مناسبة لحجم العرض المقصود، وأعد استخدام موارد الصور المشتركة حيثما أمكن، وتجنب دمج نسخ مكررة من نفس الرسمة عالية الدقة.

للصور النقطية التي تم وضعها بالفعل في أطر الصور، يمكن لـ [IPictureFillFormat::CompressImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/compressimage/) تقليل بيانات الصورة وفقًا للدقة وإعدادات القص المحددة. هذا معالجة لإطار الصورة وليس لإدارة مجموعة الصور، لذا راجع [إطار الصورة](/slides/ar/cpp/picture-frame/) للعمليات ذات الصلة.

### **الاختيار بين المحتوى المدمج والمرتبط**

يمنح الدمج العرض قابلًا للنقل لأن جميع بيانات الصورة الضرورية تسافر مع الملف. يمكن للربط تقليل حجم الملف، لكنه يضيف اعتمادًا خارجيًا. استخدم الروابط فقط عندما يكون ذلك الاعتماد مقبولًا ومستقرًا.

### **إعادة استخدام العلامة التجارية المشتركة**

للشعارات المتكررة أو العلامات المائية أو الرسومات الزخرفية، استخدم مورد صورة واحد وأعد استخدامه. إذا كان العنصر الرسومي يخص تصميم العرض أكثر من محتوى الشريحة، ضعّه على ماستر أو تخطيط بحيث يُورث إلى الشرائح المناسبة.

### **إبقاء موارد SVG قابلة للنقل**

SVG مكتفي ذاتيًا أسهل في النقل والعرض المتسق مقارنة بـ SVG يعتمد على ملفات أو موارد شبكة خارجية. عندما يكون ممكنًا، دمج الموارد المطلوبة قبل استيراد الـ SVG. حوِّل الـ SVG إلى أشكال فقط عندما تحتاج عناصر المتجه الفردية إلى تعديل.

### **استخدام واجهة برمجة تطبيقات صور Aspose.Slides**

لأنشطة صور C++، استخدم واجهتي [IImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) و[Images]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/images/) عندما تحتاج كائن صورة، واستخدم [IImageCollection::AddImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimagecollection/addimage/) عندما تحتاج لتسجيل بيانات الصورة كمورد عرض تقديمي. تدعم تجاوزات المجموعة أيضًا مصفوفات بايتات وتدفقات، وهي مفيدة عندما تأتي بيانات الصورة من ملفات أو عملاء شبكة أو قواعد بيانات أو مكتبات أخرى.

إن توليد محتوى EMF من جداول بيانات أو منتج آخر هو سير عمل تكامل منفصل وهو خارج نطاق هذه المقالة. إذا كان ملف WMF أو EMF موجودًا فقط يحتاج إلى إدراجه في عرض تقديمي، مرّر بياناته إلى تجاوز مناسب من [IImageCollection::AddImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimagecollection/addimage/) دون إضافة اعتماد منتج ثانٍ إلى سير عمل إدارة الصور.

## **الأسئلة المتكررة**

**ما الفرق بين مجموعة الصور وإطار الصورة؟**

مجموعة الصور تخزن موارد صور قابلة لإعادة الاستخدام. إطار الصورة هو شكل شريحة يعرض أحد تلك الموارد ويوفر تنسيقات صورة محددة مثل القص والتأثيرات.

**ما هي الطريقة الأفضل لاستبدال الشعار نفسه في كل مكان؟**

إذا كان الشعار مُشاركًا كمورد صورة واحد، استبدل ذلك المورد باستخدام [IPPImage::ReplaceImage]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/replaceimage/). للعلامة التجارية على مستوى العرض كله، يمكن أيضًا وضع الشعار على ماستر أو تخطيط لتقليل تكرار محتوى الشرائح.

**لماذا تختفي الصورة المرتبطة على جهاز كمبيوتر آخر؟**

الصورة المرتبطة تعتمد على ملفها الخارجي أو URL. إذا تعذّر الوصول إلى ذلك المورد من الجهاز الآخر، قد تصبح الصورة غير متاحة. دمج الصورة عندما يجب أن يكون العرض مكتفيًا ذاتيًا.

**هل يمكن تحرير SVG مدخل كأشكال PowerPoint؟**

نعم. حوِّل الـ SVG باستخدام [IShapeCollection::AddGroupShape]​(https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/addgroupshape/)؛ المجموعة الناتجة تحتوي على أشكال شريحة قابلة للتحرير بدلاً من صورة SVG واحدة.

**كيف يمكنني الحفاظ على حجم العروض التقديمية التي تحتوي على الكثير من الصور أصغر؟**

أعد استخدام موارد الصور المشتركة، تجنّب مصادر raster الكبيرة غير الضرورية، ضغط الصور النقطية المناسبة عند الحاجة، احتفظ بالعلامات المتكررة على الماستر أو التخطيط، واستخدم الصور المرتبطة فقط عندما يكون الاعتماد الخارجي مقبولًا.