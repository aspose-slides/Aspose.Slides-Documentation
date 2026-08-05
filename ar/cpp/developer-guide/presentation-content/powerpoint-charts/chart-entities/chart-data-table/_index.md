---
title: تخصيص جداول بيانات المخططات في العروض التقديمية باستخدام C++
linktitle: جدول البيانات
type: docs
url: /ar/cpp/chart-data-table/
keywords:
- بيانات المخطط
- جدول البيانات
- خصائص الخط
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تخصيص جداول بيانات المخططات بلغة C++ لملفات PPT و PPTX باستخدام Aspose.Slides لتعزيز الكفاءة والجاذبية في العروض التقديمية."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع جداول بيانات المخططات في Aspose.Slides. تُظهر كيفية عرض جدول بيانات للمخطط وتخصيص تنسيق النص عن طريق تعيين خصائص الخط مثل النمط العريض وارتفاع الخط. يوضح المثال تحميل عرض تقديمي، إضافة مخطط، تمكين جدول بيانات المخطط، تطبيق إعدادات الخط، وحفظ العرض المحدث.

## **تعيين خصائص الخط لجدول بيانات المخطط**
تتيح Aspose.Slides for C++ تغيير خصائص الخط لجدول بيانات المخطط. 

1. إنشاء كائن من فئة[Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
1. إضافة مخطط إلى الشريحة.
1. تعيين جدول المخطط.
1. تعيين ارتفاع الخط.
1. حفظ العرض التقديمي المعدل.

تم تقديم مثال عينة أدناه. 

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **الأسئلة الشائعة**

**هل يمكنني إظهار مفاتيح الأسطورة الصغيرة بجوار القيم في جدول بيانات المخطط؟**

نعم. يدعم جدول البيانات [مفاتيح الأسطورة](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts.datatable/set_showlegendkey/)، ويمكنك تشغيلها أو إيقافها.

**هل سيتم حفظ جدول البيانات عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**

نعم. تقوم Aspose.Slides برسم المخطط كجزء من الشريحة، لذا فإن الـ[PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/ar/cpp/convert-powerpoint-to-html/)/[image](/slides/ar/cpp/convert-powerpoint-to-png/) المصدّر يتضمن المخطط مع جدول بياناته.

**هل يتم دعم جداول البيانات للمخططات التي تأتي من ملف قالب؟**

نعم. لأي مخطط تم تحميله من عرض تقديمي موجود أو قالب، يمكنك التحقق وتغيير ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/chart/set_hasdatatable/) باستخدام خصائص المخطط.

**كيف يمكنني العثور بسرعة على أي المخططات في ملف ما لديها جدول بيانات مُمكّن؟**

افحص خاصية كل مخطط التي تشير إلى ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/chart/get_hasdatatable/) وتنقّل عبر الشرائح لتحديد المخططات التي تم تمكين جدول البيانات فيها.