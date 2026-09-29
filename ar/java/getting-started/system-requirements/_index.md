---
title: متطلبات النظام
type: docs
weight: 60
url: /ar/java/system-requirements/
keywords:
- متطلبات النظام
- المنصات المدعومة
- إصدارات Java
- JDK
- JRE
- fontconfig
- خطوط
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحقق مما يحتاجه Aspose.Slides for Java قبل تثبيته: إصدارات Java المدعومة وأنظمة التشغيل، ومكتبة الخطوط والخطوط التي يتطلبها Linux."
---
## **المقدمة**

Aspose.Slides for Java هي مكتبة مستقلة: لا تحتاج إلى Microsoft PowerPoint أو Microsoft Office. هي ملف JAR واحد، منشور في مستودع Maven الخاص بـ Aspose. يحتوي ملف JAR على فئات Java والموارد فقط، دون أي مكتبات أصلية، ولا يُعلن عن أي تبعيات على مكتبات أخرى. وبالتالي يعمل نفس الملف على كل نظام تشغيل ومعالج يتوفر له بيئة تشغيل Java مدعومة.

تُدرج هذه المقالة إصدارات Java المدعومة وأنظمة التشغيل ومكتبة الخطوط والخطوط التي يحتاجها Linux، وتختتم ببرنامج قصير يتحقق من إعدادك. لإضافة المكتبة إلى مشروع، انظر [التثبيت](/slides/ar/java/installation/).

## **الإصدارات المدعومة من Java**

Aspose.Slides for Java يعمل على Java 8 أو أحدث، مع JDK أو JRE. يشمل ذلك إصدارات الدعم طويل الأمد Java 8، 11، 17، 21، و 25، والإصدارات اللاحقة مثل Java 26 و Java 27. يمكن أن يأتي وقت تشغيل Java من أي بائع، مثل Eclipse Temurin أو Amazon Corretto أو Oracle أو حزم OpenJDK الخاصة بتوزيعة Linux.

Aspose.Slides لا تحتاج إلى خيارات JVM، مثل `--add-opens`، على أي من هذه الإصدارات. في Java 11، يطبع JVM تحذيرًا يبدأ بـ "WARNING: An illegal reflective access operation has occurred"؛ لا يؤثر التحذير على النتيجة.

{{% alert color="warning" title="Warning" %}}
تم إهمال Java 6 و Java 7. لا يزال Aspose.Slides for Java 26.9 يعمل عليهما لكنه يطبع تحذير إهمال. بدءًا من الإصدار 26.10، يعتبر Java 8 الحد الأدنى، ولم يعد يتم دعم Java 6 و Java 7.
{{% /alert %}}

يتطلب مشروع Maven والأوامر في [التثبيت](/slides/ar/java/installation/) JDK 11 أو أحدث. مع Java 8، قم بترجمة وتشغيل برنامجك كما هو موضح في [تحقق من إعدادك](#check-your-setup).

## **أنظمة التشغيل المدعومة**

نظرًا لأن ملف JAR لا يحتوي على أي كود أصلي، فإن Aspose.Slides for Java يعمل على Windows و Linux و macOS، على أي بنية معالج يدعمها وقت تشغيل Java، مثل x64 و ARM64. وقت تشغيل Java هو المتطلب الوحيد على Windows. على Linux، تحتاج دعم الخطوط في Java أيضًا إلى مكتبة الخطوط والخطوط الموضحة في [Linux](#linux).

## **Linux**

Aspose.Slides for Java يقوم بترتيب ورسم النص باستخدام دعم الخطوط في وقت تشغيل Java. على Linux، يتطلب هذا الدعم مكتبة fontconfig وعلى الأقل خطًا واحدًا مُثبتًا. غالبًا ما لا تحتوي صور الحاوية الرسمية لتوزيعات Linux على أي منهما. بدونها، يفشل المثال الأول في [إنشاء عروض تقديمية](/slides/ar/java/create-presentation/) عند حفظ العرض التقديمي، يترك ملفًا فارغًا، ويُبلّغ عن هذا الخطأ:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

تحتوي صور الحاوية الرسمية `eclipse-temurin`، لأوبونتو و Alpine Linux، بالفعل على fontconfig وخطوط DejaVu، لذا لا يلزم تثبيت شيء عليها. على الأنظمة الأخرى، قم بتثبيت الحزم أدناه. الأوامر الخاصة بـ Debian و Ubuntu و Red Hat تستخدم `sudo`؛ في ملف Dockerfile، نفّذها في تعليمية `RUN` دون `sudo`. خطوط DejaVu كافية لتشغيل Aspose.Slides؛ الخطوط التي تستخدمها عروضك مغطاة في [الخطوط](#fonts).

### **دبيان وأوبونتو**

إذا قمت بتثبيت Java من حزم Debian أو Ubuntu باستخدام إعدادات apt-get الافتراضية، كما في الأمر الموجود في [التثبيت](/slides/ar/java/installation/#linux)، فإن حزم Java تقوم أيضًا بتثبيت مكتبة fontconfig وخطوط DejaVu ومكتبة HarfBuzz التي تحتاجها هذه الحزم، ولا يتطلب أي شيء آخر.

مع وقت تشغيل Java من مصدر آخر، مثل أرشيف Eclipse Temurin، قم بتثبيت fontconfig وخطوط DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

غالبًا ما يقوم Dockerfile بتثبيت حزم Java من Debian أو Ubuntu، مثل `openjdk-21-jdk-headless` أو `default-jdk-headless`، باستخدام خيار `--no-install-recommends`، الذي يتخطى الثلاثة. قم بتثبيت fontconfig وخطوط DejaVu بالأمر أعلاه، وثبّت HarfBuzz أيضًا:

```bash
sudo apt-get install -y libharfbuzz0b
```

بدون HarfBuzz، تطبع هذه الحزم رسالة `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`، ويتفشل الحفظ بخطأ `UnsatisfiedLinkError` يُشير إلى أنه لا يمكن فتح `libharfbuzz.so.0`.

### **Red Hat Enterprise Linux**

حزم `java-<version>-openjdk-headless` في Red Hat Enterprise Linux لا تقوم بتثبيت مكتبة fontconfig. قم بتثبيتها مع خطوط DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

حزم `java-<version>-openjdk` الكاملة تثبت fontconfig والخطوط كاعتمادات، وكذلك حزم Amazon Corretto لنظام Amazon Linux 2023، مثل `java-21-amazon-corretto-headless`.

### **Alpine Linux**

في Dockerfile يعتمد على Alpine Linux، قم بتثبيت fontconfig وخطوط DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

في إصدارات Alpine الحالية، يقوم `ttf-dejavu` بتثبيت الحزمة `font-dejavu`. قم بتثبيت Java باستخدام حزمة `openjdk<version>-jre` أو `openjdk<version>-jdk`، مثل `openjdk25-jdk`. حزم `openjdk<version>-jre-headless` في Alpine Linux لا تحتوي على مكتبة الخطوط الخاصة بـ Java، لذا مع هذه الحزم يفشل البرنامج بـ `UnsatisfiedLinkError: no fontmanager in system library path`، حتى عندما تكون الخطوط مثبتة.

### **الخطوط**

لكي يتم عرض النص بالخطوط والقياسات الصحيحة، يجب تثبيت الخطوط التي تستخدمها عروضك، أو بدائل مناسبة، على النظام أو تحميلها بواسطة تطبيقك. راجع [نشر الخطوط](/slides/ar/java/deploy-fonts/)، [استبدال الخط](/slides/ar/java/font-substitution/)، و[خطوط مخصصة](/slides/ar/java/custom-font/).

## **تحقق من إعدادك**

للتحقق من أن المكتبة ومتطلبات تشغيلها متوفرة، شغّل برنامجًا يحفظ عرضًا تقديميًا ويُظهر شريحة كصورة. تستخدم عملية الحفظ والعرض دعم الخطوط في وقت تشغيل Java، وهو ما توفره متطلبات Linux المذكورة أعلاه.

احفظ الشيفرة أدناه كملف *CheckSetup.java* في المجلد الذي يحتوي على ملف JAR الخاص بـ Aspose.Slides. لتنزيل ملف JAR، انظر [استخدام ملف JAR بدون Maven](/slides/ar/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // أضف مستطيلًا يحتوي على نص إلى الشريحة الأولى واحفظ العرض التقديمي.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // عرض الشريحة بنقطة واحدة لكل نقطة واحفظ الصورة.
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

مع JDK 11 أو أحدث، شغّل البرنامج في ذلك المجلد باستخدام الأمر أدناه. إذا كان اسم ملف JAR مختلفًا، غيّر الاسم في الأوامر.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

مع Java 8، أو على نظام يحتوي فقط على JRE، قم بترجمة البرنامج باستخدام `javac` من JDK ثم شغّل الفئة المترجمة. على Linux و macOS، شغّل:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

على Windows، شغّل أمر `javac` نفسه، ثم شغّل الفئة باستخدام فاصلة منقوطة كفاصل لمسار الفئات. احتفظ بالأقواس المزدوجة، حتى لا يتعامل PowerShell مع الفاصلة المنقوطة كأنه نهاية الأمر: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

يقوم البرنامج بإضافة مستطيل يحتوي على نص إلى الشريحة الأولى ويحفظ العرض التقديمي كملف *hello.pptx* باستخدام طريقة [save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-). ثم يُظهر الشريحة باستخدام [getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slide/#getImage-float-float-) ويحفظ النتيجة كملف *hello.png* باستخدام [IImage.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/#save-java.lang.String-int-) بصيغة [ImageFormat.Png](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imageformat/). عوامل المقياس 1 تُظهر بكسلًا واحدًا لكل نقطة، لذا تتحول الشريحة الافتراضية 720 × 540 نقطة إلى صورة 720 × 540 بكسل، مع ظهور النص داخل المستطيل. بدون ترخيص، يحمل كلا الملفين علامة مائية للتقييم؛ راجع [Licensing](/slides/ar/java/licensing/). إذا كان هناك متطلب مفقود، يتوقف البرنامج بأحد الأخطاء الموضحة في [Linux](#linux).

## **أدوات التطوير**

يمكنك بناء تطبيقات تستخدم Aspose.Slides باستخدام أي JDK من إصدار Java مدعوم. استخدم Apache Maven مع مستودع Maven الخاص بـ Aspose، كما هو موضح في [التثبيت](/slides/ar/java/installation/)، أو أي أداة بناء أخرى يمكنها استخدام مستودع Maven. يمكنك أيضًا إضافة ملف JAR إلى مسار الفئات في IDE أو أداة البناء يدويًا.

## **الأسئلة الشائعة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint للتحويلات والعرض؟**

لا، لا يلزم PowerPoint. Aspose.Slides هو محرك مستقل لـ [إنشاء](/slides/ar/java/create-presentation/)، تعديل، [تحويل](/slides/ar/java/convert-presentation/)، و[عرض](/slides/ar/java/convert-powerpoint-to-png/) العروض.

**هل تحتاج Aspose.Slides for Java إلى شاشة أو بيئة سطح مكتب على خادم Linux؟**

لا. لا يحتاج Aspose.Slides إلى خادم X أو شاشة، لذا يعمل على الخوادم وفي الحاويات. على Linux، يحتاج فقط إلى مكتبة الخطوط والخطوط المذكورة في [Linux](#linux).

**ما هي الخطوط المطلوبة للعرض الصحيح؟**

يجب أن تكون الخطوط المستخدمة في العرض التقديمي، أو [البدائل](/slides/ar/java/font-substitution/)، متاحة. على Linux و macOS، ثبّت حزم الخطوط التي تحتاجها عروضك للحصول على عرض متسق.

**لماذا يُظهر خط مخصص كنص بديل أو مفقود على Linux؟**

إذا كان ملف الخط يحتوي على سجلات جدول أسماء غير متسقة أو تالفة، قد يختار مكدس مطابقة الخطوط في Linux (FreeType/fontconfig) سجلًا غير صالح، مما يؤدي إلى عدم حل الخط. استخدام نسخة من الخط مع سجلات جدول أسماء مصححة أو تثبيت بديل متسق يحل المشكلة.