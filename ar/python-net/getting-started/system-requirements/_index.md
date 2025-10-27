---
title: متطلبات النظام
type: docs
weight: 60
url: /ar/python-net/system-requirements/
keywords:
- متطلبات النظام
- نظام التشغيل
- تثبيت
- اعتمادات
- ويندوز
- لينكس
- ماك أو إس
- باوربوينت
- OpenDocument
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "اكتشف متطلبات نظام Aspose.Slides for Python عبر .NET. احرص على دعم سلس لباوربوينت وOpenDocument على ويندوز، لينكس، وماك أو إس."
---

## **مقدمة**

لا يتطلب Aspose.Slides for Python عبر .NET أي منتجات طرف ثالث، مثل Microsoft PowerPoint، لتثبيتها. Aspose.Slides هو محرك لإنشاء وتعديل وتحويل وعرض المستندات بصيغ متعددة، بما في ذلك صيغ عروض Microsoft PowerPoint.

## **أنظمة التشغيل المدعومة**

يدعم Aspose.Slides for Python نظام Windows (32‑بت و64‑بت)، macOS، وLinux 64‑بت على الأنظمة التي تم تثبيت Python 3.5 أو أحدث عليها.

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

- مكتبات تشغيل GCC 6 (أو أحدث).
- [libgdiplus](https://github.com/mono/libgdiplus)، تنفيذ مفتوح المصدر لواجهة برمجة تطبيقات GDI+.
- اعتمادات .NET Core Runtime. لا يلزم تثبيت .NET Core Runtime نفسه.
- بالنسبة لـ Python 3.5–3.7: يلزم بناء `pymalloc` من Python. خيار البناء `--with-pymalloc` مُفعَّل افتراضيًا. عادةً ما يُشار إلى بناء `pymalloc` بحرف `m` في اسم الملف.
- مكتبة `libpython` المشتركة. خيار بناء Python `--enable-shared` غير مفعَّل افتراضيًا، وبعض توزيعات Python لا تتضمن مكتبة `libpython` المشتركة. على بعض منصات Linux يمكنك تثبيت مكتبة `libpython` باستخدام مدير الحزم (مثال: `sudo apt-get install libpython3.7`). مشكلة شائعة هي تثبيت مكتبة `libpython` في موقع غير قياسي للمكتبات المشتركة. يمكن حل ذلك باستخدام خيارات بناء Python لتحديد مسارات مكتبة بديلة أثناء التجميع، أو بإنشاء رابط رمزي إلى ملف مكتبة `libpython` في الموقع القياسي للمكتبات المشتركة. عادةً ما يكون اسم ملف مكتبة `libpython` المشتركة `libpythonX.Ym.so.1.0` لـ Python 3.5–3.7 أو `libpythonX.Y.so.1.0` لـ Python 3.8 أو أحدث (مثال: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **الأسئلة الشائعة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint للتحويل والعرض؟**

لا، PowerPoint غير مطلوب؛ Aspose.Slides هو محرك مستقل لـ [إنشاء](/slides/ar/python-net/create-presentation/)، تعديل، [تحويل](/slides/ar/python-net/convert-presentation/)، و[عرض](/slides/ar/python-net/convert-powerpoint-to-png/) العروض التقديمية.

**هل يلزم وجود إصدار .NET محدد (Core/5+/6+) على الجهاز؟**

لا يلزم تثبيت .NET Runtime نفسه، لكن يجب أن تتوفر اعتماداته على Linux/macOS. هذا يعني أن النظام يجب أن يحتوي على الحزم التي تُثبت عادةً كاعتماديات .NET، دون تثبيت Runtime بالكامل.

**ما الخطوط المطلوبة للعرض الصحيح؟**

في الواقع، يجب توفر الخطوط المستخدمة في العرض أو بدائل مناسبة منها عبر [استبدال الخطوط](/slides/ar/python-net/font-substitution/). لضمان عرض متسق على Linux/macOS، يُنصح بتثبيت حزم الخطوط الشائعة.