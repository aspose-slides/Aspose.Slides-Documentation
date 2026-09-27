---
title: التثبيت
type: docs
weight: 70
url: /ar/python-net/installation/
keywords:
- تنزيل Aspose.Slides
- تثبيت Aspose.Slides
- استخدام Aspose.Slides
- تثبيت Aspose.Slides
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "تثبيت Aspose.Slides للغة Python عبر .NET من PyPI باستخدام pip على أنظمة Windows وLinux وmacOS، وتثبيت المكتبات الأصلية التي تحتاجها أنظمة Linux وmacOS."
---
## **نظرة عامة**

تشرح هذه المقالة طريقة تثبيت Aspose.Slides للغة Python عبر .NET على أنظمة Windows وLinux وmacOS. الحزمة مُنشورة على [PyPI](https://pypi.org/project/aspose.slides/) ويتم تثبيتها باستخدام pip. وتُضمّن وقت التشغيل الخاص بـ .NET الذي تستخدمه، لذا لا تحتاج إلى تثبيت .NET بنفسك. على نظامي Linux وmacOS، يتطلب وقت التشغيل مكتبات أصلية قد لا تشملها نظام التشغيل؛ الأقسام أدناه تُسمي هذه المكتبات.

يدعم Aspose.Slides للغة Python عبر .NET إصدارات Python من 3.5 إلى 3.14. يوفر PyPI حزمًا لأنظمة Windows (32‑bit و64‑bit)، Linux (x86_64 وARM64)، وmacOS (Intel وApple silicon).

## **ويندوز**

على نظام Windows، قم بتثبيت الحزمة باستخدام pip. لا توجد مكتبات أخرى مطلوبة.

```bash
pip install aspose.slides
```

## **لينكس**

على نظام Linux، يحتاج وقت تشغيل .NET المدمج في الحزمة إلى مكتبتين:

- **libgdiplus**، تنفيذ لواجهة برمجة تطبيقات الرسومات Windows GDI+. بدونها، يفشل حفظ العرض التقديمي مع الخطأ `The type initializer for 'Gdip' threw an exception`.
- **ICU** (International Components for Unicode). بدونها، ينتهي عملية Python عند أول استدعاء لـ Aspose.Slides بالرسالة `Couldn't find a valid ICU package installed on the system`.

على توزيعات Debian وUbuntu، قم بتثبيت كلا المكتبتين باستخدام apt:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

اسم حزمة ICU يحتوي على رقم الإصدار: `libicu76` هي الحزمة لـ Debian 13. على Debian 12، ثبّت `libicu72` بدلاً من ذلك، وعلى Ubuntu 24.04 استخدم `libicu74`. لتحديد الاسم على نظامك، نفّذ الأمر:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

بعد ذلك، ثبّت الحزمة داخل بيئة افتراضية. في إصدارات Debian وUbuntu الحالية، لا يسمح Python系统 بتنفيذ `pip install` خارج بيئة افتراضية ويظهر الخطأ `externally-managed-environment`.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

شغّل السكريبتات الخاصة بك مع تفعيل نفس البيئة الافتراضية. إذا كنت تستخدم نسخة Python لا تُديرها توزيعتك، مثل تلك الموجودة في صور Docker الرسمية لـ `python`، يمكنك أيضًا تشغيل `pip install aspose.slides` دون بيئة افتراضية.

يجب تثبيت الخطوط المستخدمة في عروضك التقديمية، أو بدائل مناسبة، على النظام لكي يتم عرض النص بشكل صحيح عند تحويل الشرائح إلى PDF أو صور.

## **macOS**

لم نتحقق بعد من عملية التثبيت على macOS. على نظام macOS، يحتاج Aspose.Slides إلى المتطلبات المسبقة التالية:

- **Python مع مكتبات مشتركة**، أي Python مُبنَى مع خيار التكوين `--enable-shared`. إذا قمت بتثبيت Python عبر [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos)، عيّن متغيّر البيئة `PYTHON_CONFIGURE_OPTS` إلى `--enable-shared` عند تثبيت نسخة Python.
- **مكتبة libpython في دليل مكتبة النظام**. يحتفظ Python المثبت عبر pyenv بمكتبة libpython الخاصة به، مثل *libpython3.9.dylib*، داخل *~/.pyenv/versions*؛ أنشئ رابطًا رمزيًا لها في */usr/local/lib*.
- **libgdiplus**، تنفيذ لواجهة برمجة تطبيقات الرسومات Windows GDI+. يوفر Homebrew هذه المكتبة عبر حزمة `mono-libgdiplus`.

ثم ثبّت الحزمة باستخدام pip.

## **التحقق من التثبيت**

للتحقق من التثبيت، احفظ المثال الأول في [Create Presentations](/slides/ar/python-net/create-presentation/) كملف *hello.py* ثم شغّل الأمر `python hello.py`. سيحفظ الملف *new_presentation.pptx* في المجلد الحالي.

## **ترقية**

لترقية تثبيت موجود إلى أحدث نسخة، نفّذ هذا الأمر في البيئة التي قُمت بتثبيت الحزمة فيها:

```bash
pip install --upgrade aspose.slides
```

## **الأسئلة المتكررة**

**هل يمكنني تثبيت Aspose.Slides في بيئة افتراضية؟**

نعم. يمكنك تثبيته في أي بيئة افتراضية لـ Python باستخدام pip. المكتبات الأصلية التي تحتاجها أنظمة Linux وmacOS تُثبت على النظام، وليس داخل البيئة الافتراضية.

**هل يمكنني استخدام Aspose.Slides في حاويات Docker؟**

نعم. يجب أن تحتوي الصورة على نفس المكتبات الأصلية الموجودة في نظام Linux — libgdiplus وICU — بالإضافة إلى الخطوط المستخدمة في عروضك التقديمية.

**هل هناك نسخة مجانية أو قيود على النسخة التجريبية؟**

نعم. بدون ترخيص، يعمل Aspose.Slides في وضع التقييم: يضيف علامة مائية تقييم إلى كل شريحة يتم حفظها ويقتصر النص المقروء من العروض. لإزالة هذه القيود، طبّق [ترخيص](/slides/ar/python-net/licensing/).