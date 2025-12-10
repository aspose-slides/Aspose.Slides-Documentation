---
title: إدارة كائنات الحبر في العروض التقديمية بلغة C++
linktitle: إدارة الحبر
type: docs
weight: 95
url: /ar/cpp/manage-ink/
keywords:
- حبر
- كائن حبر
- آثار الحبر
- إدارة الحبر
- رسم الحبر
- الرسم
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة كائنات الحبر في PowerPoint — إنشاء وتعديل وتنسيق الحبر الرقمي باستخدام Aspose.Slides لـ C++. احصل على أمثلة شفرة للآثار ولون الفرشاة وحجمها."
---

PowerPoint يوفر وظيفة الحبر لتسمح لك برسم أشكال غير قياسية، والتي يمكن استخدامها لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر محددة في الشريحة. 

Aspose.Slides يوفر الواجهة [Aspose.Slides.Ink](https://reference.aspose.com/slides/cpp/aspose.slides.ink/) التي تحتوي على الأنواع التي تحتاجها لإنشاء وإدارة كائنات الحبر. 

## **الاختلافات بين الكائنات العادية وكائنات الحبر**

الكائنات على شريحة PowerPoint عادةً ما يتم تمثيلها بكائنات الشكل. كائن الشكل، بأبسط صوره، هو حاوية تُحدد مساحة الكائن نفسها (الإطار) جنبًا إلى جنب مع خصائصه. تشمل الأخيرة حجم مساحة الحاوية، وشكل الحاوية، وخلفية الحاوية، وغيرها. للمعلومات، راجع [Shape Layout Format](https://docs.aspose.com/slides/cpp/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم مساحة الحاوية بواسطة قيم `width` و `height` القياسية:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار شكل الحبر**

الآثار هي عنصر أساسي أو معيار يُستخدم لتسجيل مسار القلم عندما يكتب المستخدم حبرًا رقمياً. الآثار هي تسجيلات تصف تسلسلات من النقاط المتصلة. 

أبسط شكل من الترميز يحدد إحداثيات X و Y لكل نقطة عينة. عندما يتم عرض جميع النقاط المتصلة، ينتج عنها صورة مثل هذه:

![ink_powerpoint2](ink_powerpoint2.png)

## **خصائص الفرشاة للرسم**

يمكنك استخدام فرشاة لرسم خطوط توصل نقاط عناصر الأثر. للفرشاة لونها وحجمها الخاص، ويتطابقان مع خصائص `Brush.Color` و `Brush.Size`. 

### **ضبط لون فرشاة الحبر**

يعرض هذا الكود C++ كيفية تعيين اللون للفرشاة:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```


### **ضبط حجم فرشاة الحبر** 

يعرض هذا الكود C++ كيفية تعيين الحجم للفرشاة:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```


عمومًا، لا يتطابق عرض وارتفاع الفرشاة، لذا لا يعرض PowerPoint حجم الفرشاة (القسم المتعلق بالبيانات مظلل بالرمادي). ولكن عندما يتطابق عرض وارتفاع الفرشاة، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

للتوضيح، لنزيد ارتفاع كائن الحبر ونستعرض الأبعاد المهمة: 

![ink_powerpoint4](ink_powerpoint4.png)

الحاوية (الإطار) لا تأخذ في الاعتبار حجم الفرشاة--دائمًا ما تفترض أن سمك الخط صفر (انظر الصورة الأخيرة). 

وبالتالي، لتحديد المنطقة المرئية لكامل كائن الحبر، يجب أن نأخذ في الاعتبار حجم فرشاة كائنات الأثر. هنا، تم تحجيم الكائن المستهدف (كائن أثر النص المكتوب يدويًا) إلى حجم الحاوية (الإطار). عندما يتغير حجم الحاوية (الإطار)، يظل حجم الفرشاة ثابتًا والعكس بالعكس. 

![ink_powerpoint5](ink_powerpoint5.png)

يعرض PowerPoint نفس السلوك عند التعامل مع النصوص:

![ink_powerpoint6](ink_powerpoint6.png)

**قراءة إضافية**

* لقراءة حول الأشكال بشكل عام، راجع قسم [PowerPoint Shapes](https://docs.aspose.com/slides/cpp/powerpoint-shapes/). 
* لمزيد من المعلومات حول القيم الفعّالة، راجع [Shape Effective Properties](https://docs.aspose.com/slides/cpp/shape-effective-properties/#get-effective-font-height-value).