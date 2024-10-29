---
title: إدارة الحبر
type: docs
weight: 95
url: /ar/cpp/manage-ink/
keywords: "الحبر في PowerPoint، أدوات الحبر، C++ الحبر، الرسم في PowerPoint، تقديم PowerPoint، C++، CPP، Aspose.Slides لـ C++"
description: "استخدم أدوات الحبر لرسم الكائنات في PowerPoint C++"
---

يوفر PowerPoint وظيفة الحبر للسماح لك برسم أشكال غير قياسية، والتي يمكن استخدامها لتسليط الضوء على كائنات أخرى، وإظهار الاتصالات والعمليات، وجذب الانتباه إلى عناصر معينة في الشريحة. 

توفر Aspose.Slides واجهة [Aspose.Slides.Ink](https://reference.aspose.com/slides/cpp/aspose.slides.ink/) التي تحتوي على الأنواع التي تحتاجها لإنشاء وإدارة كائنات الحبر. 

## **الاختلافات بين الكائنات العادية وكائنات الحبر**

عادةً ما يتم تمثيل الكائنات على شريحة PowerPoint بواسطة كائنات الشكل. كائن الشكل، في أبسط صوره، هو حاوية تحدد منطقة الكائن نفسه (إطاره) جنبًا إلى جنب مع خصائصه. تشمل هذه الخصائص حجم منطقة الحاوية، وشكل الحاوية، وخلفية الحاوية، وما إلى ذلك. لمزيد من المعلومات، انظر [شكل تنسيق التخطيط](https://docs.aspose.com/slides/cpp/shape-manipulations/#access-layout-formats-for-shape).

ومع ذلك، عندما يتعامل PowerPoint مع كائن حبر، فإنه يتجاهل جميع خصائص إطار الكائن (الحاوية) باستثناء حجمه. يتم تحديد حجم منطقة الحاوية بواسطة قيم `width` و `height` القياسية:

![ink_powerpoint1](ink_powerpoint1.png)

## **آثار شكل الحبر**

الأثر هو عنصر أساسي أو معيار يُستخدم لتسجيل المسار الذي يسلكه القلم أثناء كتابة المستخدم للحبر الرقمي. الآثار هي تسجيلات تصف تسلسلات من النقاط المتصلة. 

أبسط شكل من أشكال الترميز يحدد إحداثيات X و Y لكل نقطة عينة. عندما يتم عرض جميع النقاط المتصلة، فإنها تنتج صورة مثل هذه:

![ink_powerpoint2](ink_powerpoint2.png)

## خصائص الفرشاة للرسم 

يمكنك استخدام فرشاة لرسم خطوط تربط نقاط عناصر الأثر. تحتوي الفرشاة على لونها وحجمها الخاص، بما يتوافق مع خصائص `Brush.Color` و `Brush.Size`. 

### **تعيين لون فرشاة الحبر**

يظهر لك هذا الرمز C++ كيفية تعيين اللون لفرشاة:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **تعيين حجم فرشاة الحبر** 

يظهر لك هذا الرمز C++ كيفية تعيين الحجم لفرشاة:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

بشكل عام، لا يتطابق عرض وارتفاع الفرشاة، لذلك لا يعرض PowerPoint حجم الفرشاة (قسم البيانات مظلل). ولكن عندما يتطابق عرض وارتفاع الفرشاة، يعرض PowerPoint حجمه بهذه الطريقة:

![ink_powerpoint3](ink_powerpoint3.png)

لتوضيح الأمر، دعونا نزيد ارتفاع كائن الحبر ونراجع الأبعاد المهمة: 

![ink_powerpoint4](ink_powerpoint4.png)

لا تأخذ الحاوية (الإطار) بعين الاعتبار حجم الفرشات--فهي تفترض دائمًا أن سمك الخط هو صفر (انظر الصورة الأخيرة). 

لذلك، لتحديد المساحة المرئية لكامل كائن الحبر، يجب أن نأخذ في الاعتبار حجم فرشاة كائنات الأثر. هنا، تم تغيير حجم الكائن المستهدف (كائن أثر النص المكتوب بخط اليد) ليتناسب مع حجم الحاوية (الإطار). عندما يتغير حجم الحاوية (الإطار)، يبقى حجم الفرشاة ثابتًا والعكس صحيح. 

![ink_powerpoint5](ink_powerpoint5.png)

يظهر PowerPoint نفس السلوك عند التعامل مع النصوص:

![ink_powerpoint6](ink_powerpoint6.png)

**قراءة إضافية**

* لقراءة حول الأشكال بشكل عام، انظر قسم [أشكال PowerPoint](https://docs.aspose.com/slides/cpp/powerpoint-shapes/). 
* لمزيد من المعلومات حول القيم الفعالة، انظر [خواص الشكل الفعالة](https://docs.aspose.com/slides/cpp/shape-effective-properties/#get-effective-font-height-value). 