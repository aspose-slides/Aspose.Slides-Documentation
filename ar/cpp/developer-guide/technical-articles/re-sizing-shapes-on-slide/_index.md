---
title: تغيير حجم الأشكال على الشريحة
type: docs
weight: 100
url: /cpp/re-sizing-shapes-on-slide/
---

#### **تغيير حجم الأشكال على الشريحة**
واحدة من أكثر الأسئلة تكرارًا التي يطرحها عملاء Aspose.Slides لـ C++ هي كيفية تغيير حجم الأشكال بحيث عند تغيير حجم الشريحة لا يتم قطع البيانات. توضح هذه النصيحة الفنية القصيرة كيفية تحقيق ذلك.

لتجنب تشويش الأشكال، يحتاج كل شكل على الشريحة إلى التحديث وفقًا لحجم الشريحة الجديد.

``` cpp
// تحميل عرض تقديمي
SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"D:\\TestResize.ppt");

// حجم الشريحة القديم
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// تغيير حجم الشريحة
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// حجم الشريحة الجديد
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        // تغيير حجم الموضع
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // تغيير حجم الشكل إذا لزم الأمر
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
    }
}

presentation->Save(u"Resize.pptx", Export::SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

إذا كانت هناك أي جدول في الشريحة فإن الكود أعلاه لن يعمل بشكل مثالي. في هذه الحالة، يحتاج كل خلية من الجدول إلى تغيير الحجم.

{{% /alert %}} 

تحتاج إلى استخدام الكود التالي على جانبك إذا كنت بحاجة إلى تغيير حجم الشرائح التي تحتوي على جداول. تعيين عرض أو ارتفاع الجدول هو حالة خاصة في الأشكال حيث تحتاج إلى تغيير ارتفاع الصف الفردي وعرض العمود لتغيير ارتفاع وعرض الجدول.

``` cpp
SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"D:\\Test.pptx");

// حجم الشريحة القديم
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// تغيير حجم الشريحة
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// حجم الشريحة الجديد
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

for (auto master : presentation->get_Masters())
{
    for (auto shape : master->get_Shapes())
    {
        // تغيير حجم الموضع
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // تغيير حجم الشكل إذا لزم الأمر
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
    }

    for (auto layoutslide : master->get_LayoutSlides())
    {
        for (auto shape : layoutslide->get_Shapes())
        {
            //تغيير حجم الموضع
            shape->set_Height(shape->get_Height() * ratioHeight);
            shape->set_Width(shape->get_Width() * ratioWidth);

            //تغيير حجم الشكل إذا لزم الأمر
            shape->set_Y(shape->get_Y() * ratioHeight);
            shape->set_X(shape->get_X() * ratioWidth);
        }
    }
}

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        // تغيير حجم الموضع
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // تغيير حجم الشكل إذا لزم الأمر 
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = System::ExplicitCast<ITable>(shape);
            for (auto row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * ratioHeight);
                //   row.Height = row.Height * ratioHeight;
            }
            for (auto col : table->get_Columns())
            {
                col->set_Width(col->get_Width() * ratioWidth);
            }
        }
    }
}

presentation->Save(u"D:\\Resize.pptx", Export::SaveFormat::Pptx);
```