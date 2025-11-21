---
title: متطلبات النظام
type: docs
weight: 60
url: /ar/python-net/system-requirements/
keywords:
- متطلبات النظام
- نظام التشغيل
- التثبيت
- التبعيات
- ويندوز
- لينكس
- ماك أو إس
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف متطلبات نظام Aspose.Slides للغة Python عبر .NET. تأكد من دعم سلس لـ PowerPoint و OpenDocument على Windows و Linux و macOS."
---

## **المقدمة**

Aspose.Slides for Python via .NET لا يتطلب أي منتجات من طرف ثالث، مثل Microsoft PowerPoint، لتثبيتها. Aspose.Slides هو محرك لإنشاء وتعديل وتحويل وعرض المستندات بصيغ مختلفة، بما في ذلك صيغ عروض Microsoft PowerPoint.

## **أنظمة التشغيل المدعومة**

يدعم Aspose.Slides for Python أنظمة Windows (32-بت و64-بت)، macOS، وLinux 64-بت على الأنظمة التي تم تثبيت Python 3.5 أو إصدارات أحدث عليها.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">نظام التشغيل</td>
        <td style="font-weight: bold; width:400px">الإصدارات</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>وغيرها</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **متطلبات النظام لمنصات Linux و macOS المستهدفة**

- مكتبات وقت تشغيل GCC 6 (أو أحدث).
- [libgdiplus](https://github.com/mono/libgdiplus)، تنفيذ مفتوح المصدر لواجهة برمجة تطبيقات GDI+.
- تبعيات .NET Core Runtime. تثبيت .NET Core Runtime نفسه غير مطلوب.
- لـ Python 3.5–3.7: يلزم بناء Python باستخدام `pymalloc`. خيار البناء `--with-pymalloc` مفعل افتراضياً. عادةً ما يُشار إلى بناء `pymalloc` للـ Python بلاحقة `m` في اسم الملف.
- مكتبة `libpython` المشتركة. خيار بناء Python `--enable-shared` معطل افتراضياً، وبعض توزيعات Python لا تتضمن مكتبة `libpython` المشتركة. على بعض منصات Linux، يمكنك تثبيت مكتبة `libpython` المشتركة باستخدام مدير الحزم (مثال: `sudo apt-get install libpython3.7`). إحدى المشكلات الشائعة هي تثبيت مكتبة `libpython` في موقع غير قياسي للمكتبات المشتركة. يمكن حل ذلك باستخدام خيارات بناء Python لتعيين مسارات مكتبة بديلة عند تجميع Python، أو بإنشاء رابط رمزي إلى ملف مكتبة `libpython` في الموقع القياسي للمكتبات المشتركة في النظام. عادةً ما يكون اسم ملف مكتبة `libpython` المشتركة هو `libpythonX.Ym.so.1.0` لـ Python 3.5–3.7 أو `libpythonX.Y.so.1.0` لـ Python 3.8 أو أحدث (مثال: `libpython3.7m.so.1.0`، `libpython3.9.so.1.0`).

## **الأسئلة الشائعة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint للتحويلات والعرض؟**

لا، لا يلزم PowerPoint؛ Aspose.Slides هو محرك مستقل لـ [إنشاء](/slides/ar/python-net/create-presentation/)، تعديل، [تحويل](/slides/ar/python-net/convert-presentation/)، و[عرض](/slides/ar/python-net/convert-powerpoint-to-png/) العروض التقديمية.

**هل يلزم وجود نسخة معينة من .NET (Core/5+/6+) على الجهاز؟**

تثبيت .NET Runtime نفسه غير مطلوب، ولكن يجب توفر تبعياته على Linux/macOS. هذا يعني أن النظام يجب أن يحتوي على الحزم التي تُثبت عادةً كاعتماديات .NET، دون تثبيت Runtime بالكامل.

**ما الخطوط المطلوبة للعرض الصحيح؟**

في الواقع، يجب توفر الخطوط المستخدمة في العرض أو [البدائل](/slides/ar/python-net/font-substitution/) المناسبة. لضمان عرض ثابت على Linux/macOS، يُنصح بتثبيت حزم الخطوط الشائعة.