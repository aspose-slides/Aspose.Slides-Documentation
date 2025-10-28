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
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف متطلبات النظام لـ Aspose.Slides for Python via .NET. تأكد من دعم سلس لكل من PowerPoint وOpenDocument على Windows وLinux وmacOS."
---

## **المقدمة**

Aspose.Slides for Python via .NET لا يتطلب أي منتجات طرف ثالث، مثل Microsoft PowerPoint، لتثبيتها. Aspose.Slides هو محرك لإنشاء المستندات وتعديلها وتحويلها وعرضها بصيغ مختلفة، بما في ذلك صيغ عروض Microsoft PowerPoint.

## **أنظمة التشغيل المدعومة**

Aspose.Slides for Python يدعم نظام Windows (32-بت و64-بت)، macOS، وLinux 64-بت على الأنظمة التي تم تثبيت Python 3.5 أو أحدث عليها.

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
- تبعيات .NET Core Runtime. تثبيت .NET Core Runtime نفسه غير مطلوب.
- بالنسبة لـ Python 3.5–3.7: يلزم بناء `pymalloc` من Python. يتم تمكين خيار البناء `--with-pymalloc` افتراضيًا. عادةً ما يُشار إلى بناء `pymalloc` في اسم الملف بلاحقة `m`.
- مكتبة `libpython` المشتركة. يتم تعطيل خيار بناء Python `--enable-shared` افتراضيًا، ولا تتضمن بعض توزيعات Python مكتبة `libpython` المشتركة. على بعض منصات Linux يمكنك تثبيت مكتبة `libpython` المشتركة باستخدام مدير الحزم (على سبيل المثال، `sudo apt-get install libpython3.7`). مشكلة شائعة هي أن مكتبة `libpython` تُثبت في موقع غير قياسي للمكتبات المشتركة. يمكنك حل ذلك باستخدام خيارات بناء Python لتحديد مسارات مكتبة بديلة عند تجميع Python، أو بإنشاء رابط رمزي لملف مكتبة `libpython` في الموقع القياسي للمكتبات المشتركة بالنظام. عادةً ما يكون اسم ملف مكتبة `libpython` المشتركة هو `libpythonX.Ym.so.1.0` لـ Python 3.5–3.7 أو `libpythonX.Y.so.1.0` لـ Python 3.8 أو أحدث (على سبيل المثال، `libpython3.7m.so.1.0`، `libpython3.9.so.1.0`).

## **الأسئلة الشائعة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint للتحويلات والعرض؟**

لا، لا حاجة لـ PowerPoint؛ Aspose.Slides هو محرك مستقل لـ [إنشاء](/slides/ar/python-net/create-presentation/)، والتعديل، و[التحويل](/slides/ar/python-net/convert-presentation/)، و[العرض](/slides/ar/python-net/convert-powerpoint-to-png/) للعروض التقديمية.

**هل يلزم وجود إصدار .NET محدد (Core/5+/6+) على الجهاز؟**

تثبيت .NET Runtime نفسه غير مطلوب، لكن يجب أن تكون تبعياته موجودة على Linux/macOS. يعني ذلك أن النظام يجب أن يحتوي على الحزم التي تُثبت عادةً كاعتماديات .NET، دون تثبيت الـ Runtime بالكامل.

**ما الخطوط المطلوبة للعرض الصحيح؟**

في الواقع، يجب أن تكون الخطوط المستخدمة في العرض أو [البدائل المناسبة](/slides/ar/python-net/font-substitution/) متوفرة. لضمان عرض متسق على Linux/macOS، يوصى بتثبيت حزم الخطوط الشائعة.