---
title: تخصيص جداول بيانات المخططات في العروض باستخدام С++
linktitle: جدول البيانات
type: docs
url: /ar/cpp/chart-data-table/
keywords:
- بيانات المخطط
- جدول البيانات
- خصائص الخط
- PowerPoint
- عرض تقديمي
- С++
- Aspose.Slides
description: "تخصيص جداول بيانات المخططات في С++ لملفات PPT و PPTX باستخدام Aspose.Slides لتعزيز الكفاءة وجاذبية العروض التقديمية."
---

## **تعيين خصائص الخط لجدول بيانات المخطط**
يتيح Aspose.Slides لـ C++ تغيير خصائص الخط لجدول بيانات المخطط.

1. إنشاء كائن فئة [العرض التقديمي](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. إضافة مخطط إلى الشريحة.
1. تعيين جدول المخطط.
1. تعيين ارتفاع الخط.
1. حفظ العرض التقديمي المعدل.

المثال التالي موضح.  
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```


## **الأسئلة الشائعة**

**هل يمكنني عرض مفاتيح وسيلة صغيرة بجوار القيم في جدول بيانات المخطط؟**  
نعم. يدعم جدول البيانات [مفاتيح الوسيلة](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datatable/set_showlegendkey/)، ويمكنك تشغيلها أو إيقافها.

**هل سيُحفظ جدول البيانات عند تصدير العرض التقديمي إلى PDF أو HTML أو صور؟**  
نعم. يقوم Aspose.Slides برسم المخطط كجزء من الشريحة، لذا فإن الـ[PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/ar/cpp/convert-powerpoint-to-html/)/[image](/slides/ar/cpp/convert-powerpoint-to-png/) المُصدَّر يتضمن المخطط مع جدول بياناته.

**هل يتم دعم جداول البيانات للمخططات التي تأتي من ملف قالب؟**  
نعم. لأي مخطط تم تحميله من عرض تقديمي أو قالب موجود، يمكنك التحقق وتغيير ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/set_hasdatatable/) باستخدام خصائص المخطط.

**كيف يمكنني بسرعة العثور على المخططات في ملف ما التي لديها جدول بيانات مفعل؟**  
تحقق من خاصية كل مخطط التي تشير إلى ما إذا كان جدول البيانات [معروضًا](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_hasdatatable/) وتكرّر عبر الشرائح لتحديد المخططات التي تم تمكينه فيها.