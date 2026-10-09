---
title: "متطلبات النظام"
type: docs
weight: 60
url: /ar/java/system-requirements/
keywords:
- "متطلبات النظام"
- "المنصات المدعومة"
- "إصدارات Java"
- "JDK"
- "JRE"
- "fontconfig"
- "خطوط"
- "Docker"
- "Alpine"
- "Windows"
- "Linux"
- "macOS"
- "PowerPoint"
- "OpenDocument"
- "العرض التقديمي"
- "Java"
- "Aspose.Slides"
description: "تحقق مما تحتاجه Aspose.Slides for Java قبل تثبيتها: إصدارات Java المدعومة وأنظمة التشغيل، ومكتبة الخطوط والخطوط التي يتطلبها Linux."
---
## **المقدمة**

Aspose.Slides for Java هي مكتبة مستقلة: لا تحتاج إلى Microsoft PowerPoint أو Microsoft Office. إنها ملف JAR واحد، يتم نشره في مستودع Maven الخاص بـ Aspose. يحتوي ملف JAR على فئات Java والموارد فقط، دون مكتبات أصلية، ولا يعلن عن أي تبعيات على مكتبات أخرى. وبالتالي يعمل هذا الملف على جميع أنظمة التشغيل والمعالجات التي يتوفر لها بيئة تشغيل Java مدعومة.

هذه المقالة تسرد إصدارات Java المدعومة وأنظمة التشغيل ومكتبة الخطوط والخطوط التي يحتاجها Linux، وتنتهي ببرنامج بسيط يتحقق من إعدادك. لإضافة المكتبة إلى مشروع، راجع [التثبيت](/slides/ar/java/installation/).

## **إصدارات Java المدعومة**

Aspose.Slides for Java تعمل على Java 8 أو أحدث، مع JDK أو JRE. هذا يشمل إصدارات الدعم الطويل Java 8, 11, 17, 21, و 25، وإصدارات لاحقة مثل Java 26 و Java 27. يمكن أن تأتي بيئة تشغيل Java من أي موزع، مثل Eclipse Temurin أو Amazon Corretto أو Oracle أو حزم OpenJDK لتوزيعات Linux.

Aspose.Slides لا تحتاج إلى أي خيارات JVM، مثل `--add-opens`، على أي من هذه الإصدارات. في Java 11، تطبع JVM تحذيراً يبدأ بـ "WARNING: An illegal reflective access operation has occurred"؛ التحذير لا يؤثر على النتيجة.

{{% alert color="warning" title="تحذير" %}}
Java 6 و Java 7 مهملان. لا يزال Aspose.Slides for Java 26.9 يعمل عليهما لكنه يعرض تحذير إهمال. بدءاً من الإصدار 26.10، الحد الأدنى هو Java 8، ولم يعد الدعم متاحاً لـ Java 6 و Java 7.
{{% /alert %}}

يتطلب مشروع Maven والأوامر في [التثبيت](/slides/ar/java/installation/) JDK 11 أو أحدث. باستخدام Java 8، قم بترجمة وتشغيل برنامجك كما هو موضح في [تحقق من إعدادك](#check-your-setup).

## **أنظمة التشغيل المدعومة**

نظرًا لأن ملف JAR لا يحتوي على أي كود أصلي، فإن Aspose.Slides for Java تعمل على Windows و Linux و macOS، على أي بنية معالج تدعمها بيئة تشغيل Java، مثل x64 و ARM64. بيئة تشغيل Java هي المتطلب الوحيد على Windows. على Linux، تحتاج دعم الخطوط في Java أيضاً إلى مكتبة الخطوط والخطوط الموضحة في [Linux](#linux).

## **Linux**

Aspose.Slides for Java تُنَسّق وترسم النص باستخدام دعم الخطوط في بيئة تشغيل Java. على Linux، يتطلب هذا الدعم مكتبة fontconfig وعلى الأقل خطًا واحدًا مُثبتًا. غالبًا ما تفتقر صور الحاويات الرسمية لتوزيعات Linux إلى كليهما. بدونهما، يفشل المثال الأول في [إنشاء عروض تقديمية](/slides/ar/java/create-presentation/) عند حفظ العرض، ويترك ملفًا فارغًا، ويُظهر هذا الخطأ:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

تحتوي صور الحاوية الرسمية `eclipse-temurin`، لكل من Ubuntu و Alpine Linux، بالفعل على fontconfig وخطوط DejaVu، لذلك لا يلزم تثبيت شيء عليها. على الأنظمة الأخرى، ثبّت الحزم المذكورة أدناه. تستخدم أوامر Debian و Ubuntu `sudo`؛ في ملف Dockerfile، نفّذها في تعليمة `RUN` بدون `sudo`. خطوط DejaVu كافية لتشغيل Aspose.Slides؛ الخطوط التي تستخدمها عروضك مغطاة في قسم [الخطوط](#fonts).

### **دبيان وأوبونتو**

إذا قمت بتثبيت Java من حزم Debian أو Ubuntu باستخدام إعدادات `apt-get` الافتراضية، كما هو موضح في الأمر في [التثبيت](/slides/ar/java/installation/#linux)، فإن حزم Java تثبت أيضًا مكتبة fontconfig، وخطوط DejaVu، ومكتبة HarfBuzz التي تحتاجها هذه الحزم، ولا يلزم شيء آخر.

مع بيئة تشغيل Java من مصدر آخر، مثل أرشيف Eclipse Temurin، ثبّت fontconfig وخطوط DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

غالبًا ما يثبت ملف Dockerfile حزم Java الخاصة بـ Debian أو Ubuntu، مثل `openjdk-21-jdk-headless` أو `default-jdk-headless`، مع خيار `--no-install-recommends`، مما يتخطى الثلاثة. ثبّت fontconfig وخطوط DejaVu بالأمر أعلاه، وثبّت HarfBuzz أيضًا:

```bash
sudo apt-get install -y libharfbuzz0b
```

بدون HarfBuzz، تطبع هذه الحزم Java الرسالة `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`، ويفشل الحفظ مع `UnsatisfiedLinkError` يذكر أن `libharfbuzz.so.0` لا يمكن فتحه.

### **ريد هات إنتربرايز لينكس**

حزم `java-<version>-openjdk-headless` في Red Hat Enterprise Linux لا تثبت مكتبة fontconfig. ثبّتها مع خطوط DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

حزم `java-<version>-openjdk` الكاملة تثبت fontconfig والخطوط كاعتمادات، وكذلك حزم Amazon Corretto لـ Amazon Linux 2023، مثل `java-21-amazon-corretto-headless`.

### **ألباين لينكس**

في ملف Dockerfile يعتمد على Alpine Linux، ثبّت fontconfig وخطوط DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

في إصدارات Alpine الحالية، يثبّت `ttf-dejavu` حزمة `font-dejavu`. ثبّت Java باستخدام حزمة `openjdk<version>-jre` أو `openjdk<version>-jdk`، مثل `openjdk25-jdk`. حزم `openjdk<version>-jre-headless` في Alpine Linux لا تحتوي على مكتبة الخطوط الخاصة بـ Java، لذا يفشل البرنامج مع `UnsatisfiedLinkError: no fontmanager in system library path` حتى وإن تم تثبيت الخطوط.

### **الخطوط**

لكي يُظهر النص الخطوط الصحيحة والقياسات المطلوبة، يجب أن تكون الخطوط المستخدمة في عروضك، أو بدائل مناسبة، مثبتة على النظام أو محمّلة بواسطة التطبيق. راجع [نشر الخطوط](/slides/ar/java/deploy-fonts/)، [استبدال الخطوط](/slides/ar/java/font-substitution/)، و[خطوط مخصصة](/slides/ar/java/custom-font/).

## **تحقق من إعدادك**

للتحقق من أن المكتبة ومتطلباتها موجودة، شغّل برنامجًا يحفظ عرضًا تقديميًا ويرسم شريحة إلى صورة. عملية الحفظ والرسم تستخدم دعم الخطوط في بيئة تشغيل Java، وهو ما توفره متطلبات Linux المذكورة أعلاه.

احفظ الكود أدناه كملف *CheckSetup.java* في المجلد الذي يحتوي على ملف JAR الخاص بـ Aspose.Slides. لتنزيل ملف JAR، راجع [استخدام ملف JAR دون Maven](/slides/ar/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // إضافة مستطيل يحتوي على نص إلى الشريحة الأولى وحفظ العرض التقديمي.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // رسم الشريحة بنقطة واحدة لكل نقطة وحفظ الصورة.
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

مع JDK 11 أو أحدث، شغّل البرنامج في ذلك المجلد بالأمر أدناه. إذا كان اسم ملف JAR مختلفًا، عدّل الاسم في الأوامر.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

مع Java 8، أو على نظام لا يحتوي سوى على JRE، قم بترجمة البرنامج باستخدام `javac` من JDK ثم شغّله. على Linux و macOS، نفّذ:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

على Windows، شغّل نفس أمر `javac`، ثم شغّل الصنف باستخدام فاصلة منقوطة كفاصل لمسار الأصناف. احتفظ بعلامات الاقتباس حتى لا يتعامل PowerShell مع الفاصلة المنقوطة كنهاية للأمر: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

يضيف البرنامج مستطيلًا يحتوي على نص إلى الشريحة الأولى ويحفظ العرض باسم *hello.pptx* باستخدام طريقة [حفظ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). ثم يرسم الشريحة باستخدام [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) ويحفظ النتيجة باسم *hello.png* عبر [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) بصيغة [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/). معامل التدرج 1 يرسم بكسلًا واحدًا لكل نقطة، لذا تتحول الشريحة الافتراضية ذات 720 × 540 نقطة إلى صورة 720 × 540 بكسل، مع ظهور النص داخل المستطيل. بدون ترخيص، يحمل كلا الملفين علامة مائية تجريبية؛ راجع [التراخيص](/slides/ar/java/licensing/). إذا كان هناك متطلب مفقود، يتوقف البرنامج بأحد الأخطاء الموضحة في [Linux](#linux).

## **أدوات التطوير**

يمكنك بناء تطبيقات تستخدم Aspose.Slides باستخدام أي JDK من إصدارات Java المدعومة. استخدم Apache Maven مع مستودع Maven الخاص بـ Aspose، كما هو موضح في [التثبيت](/slides/ar/java/installation/)، أو أي أداة بناء أخرى تستطيع استهلاك مستودع Maven. يمكنك أيضًا إضافة ملف JAR إلى مسار الأصناف في IDE أو أداة البناء يدويًا.

## **الأسئلة المتكررة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint للتحويل والعرض؟**

لا، لا يُطلب PowerPoint. Aspose.Slides هو محرك مستقل لـ [إنشاء](/slides/ar/java/create-presentation/) العروض، تعديلها، [تحويل](/slides/ar/java/convert-presentation/) العروض، و[عرض](/slides/ar/java/convert-powerpoint-to-png/) العروض.

**هل يحتاج Aspose.Slides for Java إلى شاشة أو بيئة سطح مكتب على خادم Linux؟**

لا. لا يحتاج Aspose.Slides إلى خادم X أو شاشة، لذا يمكن تشغيله على الخوادم وفي الحاويات. على Linux، يحتاج فقط إلى مكتبة الخطوط والخطوط الموضحة في [Linux](#linux).

**ما الخطوط المطلوبة للعرض الصحيح؟**

يجب أن تكون الخطوط المستخدمة في العرض، أو [بدائل](/slides/ar/java/font-substitution/) مناسبة، متاحة. على Linux و macOS، ثبّت حزم الخطوط التي تحتاجها عروضك للحصول على عرض متسق.

**لماذا تُظهر خطوط مخصصة كنص بديل أو مفقود على Linux؟**

إذا كان ملف الخط يحتوي على سجلات جدول أسماء غير متسقة أو تالفة، قد يختار مكدس مطابقة الخطوط في Linux (FreeType/fontconfig) سجلاً غير صالح، مما يؤدي إلى عدم حل الخط. استخدام نسخة خط ذات سجلات جدول أسماء مصححة أو تثبيت بديل متسق يحل المشكلة.