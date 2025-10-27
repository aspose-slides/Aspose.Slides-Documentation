---
title: متطلبات النظام
type: docs
weight: 60
url: /ar/python-net/getting-started/system-requirements/
keywords:
- متطلبات النظام
- نظام التشغيل
- التثبيت
- التبعيات
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- العرض التقديمي
- Python
- Aspose.Slides
description: "اكتشف متطلبات نظام Aspose.Slides for Python عبر .NET. احرص على دعم سلس لـ PowerPoint و OpenDocument على Windows و Linux و macOS."
---

## **مقدمة**

Aspose.Slides for Python عبر .NET لا يتطلب تثبيت أي منتجات طرف ثالث، مثل Microsoft PowerPoint. Aspose.Slides هو محرك لإنشاء وتعديل وتحويل وعرض المستندات بصيغ متعددة، بما في ذلك صيغ عروض Microsoft PowerPoint.

## **أنظمة التشغيل المدعومة**

Aspose.Slides for Python يدعم Windows (32‑bit و 64‑bit)، macOS، و Linux 64‑bit على الأنظمة التي تحتوي على Python 3.5 أو أحدث.

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
                <li>وأخرى</li>
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

- مكتبات وقت تشغيل GCC 6 (أو أحدث).
- [libgdiplus](https://github.com/mono/libgdiplus)، تنفيذ مفتوح المصدر لواجهة برمجة تطبيقات GDI+.
- تبعيات .NET Core Runtime. لا يلزم تثبيت .NET Core Runtime نفسه.
- بالنسبة لـ Python 3.5–3.7: يلزم بناء `pymalloc` من Python. يتم تمكين خيار البناء `--with-pymalloc` افتراضياً. عادةً ما يُشار إلى بناء `pymalloc` بلاحقة `m` في اسم الملف.
- مكتبة `libpython` المشتركة. يكون خيار بناء Python `--enable-shared` معطلاً افتراضياً، وبعض توزيعات Python لا تتضمن مكتبة `libpython` المشتركة. على بعض منصات Linux يمكنك تثبيت مكتبة `libpython` باستخدام مدير الحزم (مثال: `sudo apt-get install libpython3.7`). مشكلة شائعة هي تثبيت مكتبة `libpython` في موقع غير قياسي للمكتبات المشتركة. يمكنك حل ذلك باستخدام خيارات بناء Python لتحديد مسارات مكتبة بديلة عند تجميع Python، أو بإنشاء رابط رمزي إلى ملف مكتبة `libpython` في موقع المكتبة المشتركة القياسي للنظام. عادةً يكون اسم ملف مكتبة `libpython` المشتركة `libpythonX.Ym.so.1.0` لـ Python 3.5–3.7 أو `libpythonX.Y.so.1.0` لـ Python 3.8 أو أحدث (مثال: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **الأسئلة الشائعة**

**هل يلزم تثبيت Microsoft PowerPoint لإجراء التحويلات وعرض المستندات؟**

لا، لا يلزم PowerPoint؛ Aspose.Slides هو محرك مستقل لـ [إنشاء](/slides/ar/python-net/create-presentation/) وتعديل و[تحويل](/slides/ar/python-net/convert-presentation/) و[عرض](/slides/ar/python-net/convert-powerpoint-to-png/) العروض التقديمية.

**هل يلزم وجود نسخة محددة من .NET (Core/5+/6+) على الجهاز؟**

تثبيت .NET Runtime نفسه غير مطلوب، لكن يجب توافر تبعياته على Linux/macOS. يعني ذلك أن النظام يجب أن يحتوي على الحزم التي تُثبت عادةً ك‑تبعيات لـ .NET، دون الحاجة لتثبيت Runtime كامل.

**ما الخطوط المطلوبة للعرض الصحيح؟**

في الواقع، يجب توفر الخطوط المستخدمة في العرض أو بدائل [ملائمة](/slides/ar/python-net/font-substitution/). لضمان عرض ثابت على Linux/macOS، يُنصح بتثبيت حزم الخطوط الشائعة.