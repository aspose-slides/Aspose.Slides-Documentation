---
title: "متطلبات النظام"
type: docs
weight: 60
url: /ar/python-net/system-requirements/
keywords:
- "متطلبات النظام"
- "نظام التشغيل"
- "التثبيت"
- "التبعيات"
- "ويندوز"
- "لينكس"
- "ماك أو إس"
- "باوربوينت"
- "أوبن دوكيومنت"
- "عرض تقديمي"
- "بايثون"
- "Aspose.Slides"
description: "اكتشف Aspose.Slides لبايثون عبر .NET ومتطلبات النظام. تأكد من الدعم السلس لباوربوينت وأوبن دوكيومنت على ويندوز، لينكس، وماك أو إس."
---

## **المقدمة**

لا يتطلب Aspose.Slides لبايثون عبر .NET أي منتجات طرف ثالث، مثل Microsoft PowerPoint، لتثبيتها. Aspose.Slides هو محرك لإنشاء وتعديل وتحويل وعرض المستندات بصيغ متعددة، بما في ذلك صيغ عروض Microsoft PowerPoint.

## **أنظمة التشغيل المدعومة**

Aspose.Slides لبايثون يدعم Windows (32‑bit و64‑bit)، macOS، وLinux 64‑bit على الأنظمة التي تم تثبيت Python 3.5 أو أحدث عليها.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">نظام التشغيل</td>
        <td style="font-weight: bold; width:400px">الإصدارات</td>
    </tr>
    <tr>
        <td>مايكروسوفت ويندوز</td>
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
        <td>لينكس</td>
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

## **متطلبات النظام لأنظمة Linux و macOS المستهدفة**

- مكتبات وقت التشغيل GCC 6 (أو أحدث).  
- [libgdiplus](https://github.com/mono/libgdiplus)، تنفيذ مفتوح المصدر لواجهة برمجة تطبيقات GDI+.  
- تبعيات .NET Core Runtime. تثبيت .NET Core Runtime نفسه غير مطلوب.  
- بالنسبة لـ Python 3.5–3.7: يلزم بنية `pymalloc` من Python. يتم تفعيل خيار البناء `--with-pymalloc` افتراضيًا. عادةً ما يكون لملف بنية `pymalloc` لاحقة `m` في الاسم.  
- مكتبة `libpython` المشتركة. يتم تعطيل خيار البناء `--enable-shared` في Python افتراضيًا، ولا تتضمن بعض توزيعات Python مكتبة `libpython` المشتركة. على بعض منصات Linux، يمكنك تثبيت مكتبة `libpython` عبر مدير الحزم (مثال: `sudo apt-get install libpython3.7`). مشكلة شائعة هي تثبيت مكتبة `libpython` في موقع غير قياسي للمكتبات المشتركة. يمكن حل ذلك باستخدام خيارات بناء Python لتحديد مسارات مكتبة بديلة عند التجميع، أو بإنشاء رابط رمزي إلى ملف مكتبة `libpython` في الموقع القياسي للمكتبات المشتركة في النظام. عادةً ما يكون اسم ملف مكتبة `libpython` المشتركة على النحو `libpythonX.Ym.so.1.0` لـ Python 3.5–3.7 أو `libpythonX.Y.so.1.0` لـ Python 3.8 أو أحدث (مثال: `libpython3.7m.so.1.0`، `libpython3.9.so.1.0`).  

## **الأسئلة المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint للتحويلات والعرض؟**

لا، لا يلزم وجود PowerPoint؛ Aspose.Slides هو محرك مستقل لـ[إنشاء](/slides/ar/python-net/create-presentation/)، تعديل، [تحويل](/slides/ar/python-net/convert-presentation/)، و[عرض](/slides/ar/python-net/convert-powerpoint-to-png/) العروض.

**هل يتطلب الجهاز نسخة معينة من .NET (Core/5+/6+ )؟**

تثبيت .NET Runtime نفسه غير مطلوب، ولكن يجب توفر تبعياته على Linux/macOS. هذا يعني أن النظام يجب أن يحتوي على الحزم التي تُثبت عادةً كـ .NET تبعيات، دون تثبيت Runtime كاملًا.

**ما الخطوط المطلوبة للعرض الصحيح؟**

في الواقع، يجب توفر الخطوط المستخدمة في العرض أو بدائلها المناسبة. لضمان عرض متسق على Linux/macOS، يُنصح بتثبيت حزم الخطوط الشائعة.