---
title: متطلبات النظام
type: docs
weight: 60
url: /python-net/system-requirements/
---
Aspose.Slides لـ Python عبر .NET لا يتطلب أي منتج طرف ثالث مثل Microsoft PowerPoint ليتم تثبيته. Aspose.Slides نفسها هي محرك لإنشاء وتعديل وتحويل وعرض المستندات بتنسيقات مختلفة، بما في ذلك تنسيقات عروض Microsoft PowerPoint.

## أنظمة التشغيل المدعومة

Aspose.Slides لـ Python عبر .NET تدعم أنظمة التشغيل Windows 64 بت و32 بت وmacOS وLinux 64 بت حيث تم تثبيت Python 3.5 أو أحدث.

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
                <li>12 "مونتيري"</li>
            </ul>
        </td>
    </tr>
</table>

## متطلبات النظام لمنصات Linux و macOS المستهدفة

- مكتبات وقت التشغيل GCC-6 (أو أحدث).
- [`libgdiplus`](https://github.com/mono/libgdiplus): تنفيذ مفتوح المصدر لمكتبة GDI+ API.
- اعتماديات .NET Core Runtime. تثبيت .NET Core Runtime نفسه ليس مطلوبًا.
- لـ Python 3.5-3.7: مطلوب بناء `pymalloc` من Python. خيار بناء Python `--with-pymalloc` مفعل بشكل افتراضي. عادةً، يتم تمييز بناء `pymalloc` من Python بـ `m` في نهاية اسم الملف.
- مكتبة Python المشتركة `libpython`. خيار بناء Python `--enable-shared` مُعطل بشكل افتراضي، بعض توزيعات Python لا تحتوي على مكتبة `libpython` المشتركة. بالنسبة لبعض منصات Linux، يمكن تثبيت مكتبة `libpython` المشتركة باستخدام مدير الحزم، على سبيل المثال: `sudo apt-get install libpython3.7`. المشكلة الشائعة هي أن مكتبة `libpython` مثبتة في موقع مختلف عن الموقع القياسي لنظام المكتبات المشتركة. يمكن حل المشكلة باستخدام خيارات بناء Python لتعيين مسارات مكتبات بديلة عند تجميع Python، أو عن طريق إنشاء رابط رمزي إلى ملف مكتبة `libpython` في الموقع القياسي لنظام المكتبات المشتركة. عادةً، يكون اسم ملف مكتبة `libpython` المشتركة هو `libpythonX.Ym.so.1.0` لـ Python 3.5-3.7، أو `libpythonX.Y.so.1.0` لـ Python 3.8 أو أحدث (على سبيل المثال: libpython3.7m.so.1.0، libpython3.9.so.1.0).