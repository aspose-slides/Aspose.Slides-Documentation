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
- باوربوينت
- OpenDocument
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "اكتشف متطلبات نظام Aspose.Slides for Python via .NET. تأكد من دعم سلس لـ PowerPoint وOpenDocument على ويندوز، لينكس، وماك أو إس."
---
## **المقدمة**

Aspose.Slides for Python via .NET لا يتطلب أي منتجات طرف ثالث، مثل Microsoft PowerPoint، لتثبيتها. Aspose.Slides هو محرك لإنشاء، تعديل، تحويل، وعرض المستندات بتنسيقات مختلفة، بما في ذلك تنسيقات عروض Microsoft PowerPoint.

## **أنظمة التشغيل المدعومة**

Aspose.Slides for Python يدعم Windows (32‑bit و64‑bit)، macOS، وLinux 64‑bit على أنظمة مثبت عليها Python 3.5 أو أحدث.

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

- مكتبات وقت تشغيل GCC 6 (أو أحدث).
- [libgdiplus](https://github.com/mono/libgdiplus)، تنفيذ مفتوح المصدر لواجهة برمجة تطبيقات GDI+.
- تبعيات .NET Core Runtime. تثبيت .NET Core Runtime نفسه غير مطلوب.
- بالنسبة إلى Python 3.5–3.7: يلزم بناء Python باستخدام `pymalloc`. يتم تمكين خيار البناء `--with-pymalloc` افتراضيًا. عادةً ما يُشار إلى بناء `pymalloc` بلاحقة `m` في اسم الملف.
- مكتبة `libpython` المشتركة. يتم تعطيل خيار بناء Python `--enable-shared` افتراضيًا، ولا تتضمن بعض توزيعات Python مكتبة `libpython` المشتركة. على بعض منصات Linux يمكنك تثبيت مكتبة `libpython` عبر مدير الحزم (مثال: `sudo apt-get install libpython3.7`). مشكلة شائعة هي تثبيت مكتبة `libpython` في موقع غير قياسي للمكتبات المشتركة. يمكنك حل ذلك باستخدام خيارات بناء Python لتعيين مسارات مكتبة بديلة عند تجميع Python، أو بإنشاء رابط رمزي إلى ملف مكتبة `libpython` في موقع المكتبة المشتركة القياسي للنظام. عادةً ما يكون اسم ملف مكتبة `libpython` المشتركة `libpythonX.Ym.so.1.0` لـ Python 3.5–3.7 أو `libpythonX.Y.so.1.0` لـ Python 3.8 أو أحدث (مثال: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **الأسئلة الشائعة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint للتحويلات والعرض؟**

لا، لا يلزم PowerPoint؛ Aspose.Slides هو محرك مستقل لـ [إنشاء](/slides/ar/python-net/create-presentation/)، تعديل، [تحويل](/slides/ar/python-net/convert-presentation/)، و[عرض](/slides/ar/python-net/convert-powerpoint-to-png/) العروض التقديمية.

**هل يلزم وجود إصدار .NET محدد (Core/5+/6+) على الجهاز؟**

تثبيت .NET Runtime نفسه غير مطلوب، ولكن يجب أن تكون تبعياته متاحة على Linux/macOS. وهذا يعني أن النظام يجب أن يحتوي على الحزم التي تُثبت عادةً كاعتمادات .NET، دون تثبيت Runtime بالكامل.

**ما الخطوط المطلوبة للعرض الصحيح؟**

عمليًا، يجب أن تكون الخطوط المستخدمة في العرض أو [البدائل](/slides/ar/python-net/font-substitution/) متاحة. لضمان عرض متسق على Linux/macOS، يُنصح بتثبيت حزم الخطوط الشائعة.

**لماذا يتم عرض خط مخصص كبديل أو نص مفقود على Linux؟**

إذا كان ملف الخط يحتوي على سجلات جدول اسم غير متناسقة أو فاسدة، قد يختار مكدس مطابقة الخطوط في Linux (FreeType/fontconfig) سجلًا غير صالح، مما يؤدي إلى عدم حل الخط. استخدام نسخة خط مع تصحيح سجلات جدول الاسم أو تثبيت بديل متسق يحل المشكلة.