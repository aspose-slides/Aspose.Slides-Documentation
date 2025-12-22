---
title: التعدد الخيوط في Aspose.Slides لنظام Android عبر Java
linktitle: التعدد الخيوط
type: docs
weight: 310
url: /ar/androidjava/multithreading/
keywords:
- تعدد الخيوط
- خيوط متعددة
- عمل متوازي
- تحويل الشرائح
- شرائح إلى صور
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "يُحسّن تعدد الخيوط في Aspose.Slides لنظام Android عبر Java معالجة PowerPoint وOpenDocument. اكتشف أفضل الممارسات لتدفقات عمل العروض التقديمية الفعّالة."
---

## **مقدمة**

في حين أن العمل المتوازي مع العروض التقديمية ممكن (إلى جانب التحليل/التحميل/الاستنساخ) ويجري كل شيء على ما يرام (في الغالب)، هناك احتمال صغير أن تحصل على نتائج غير صحيحة عند استخدام المكتبة في عدة خيوط.

نوصي بشدة بعدم استخدام نسخة واحدة من كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) في بيئة متعددة الخيوط لأن ذلك قد يؤدي إلى أخطاء أو فشل غير متوقع يصعب اكتشافه.

ليس من الآمن تحميل أو حفظ أو/أو استنساخ نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) في عدة خيوط. هذه العمليات غير مدعومة. إذا كنت بحاجة إلى أداء مثل هذه المهام، عليك تنفيذها بالتوازي باستخدام عدة عمليات منفردة الخيط—ويجب على كل عملية أن تستخدم نسخة العرض الخاصة بها.

## **تحويل شرائح العرض إلى صور بشكل متوازي**

لنفترض أننا نريد تحويل جميع الشرائح من عرض PowerPoint إلى صور PNG بشكل متوازي. نظرًا لأن استخدام نسخة `Presentation` واحدة في عدة خيوط غير آمن، نقسم شرائح العرض إلى عروض منفصلة ونحول الشرائح إلى صور بالتوازي، باستخدام كل عرض في خيط منفصل. يوضح المثال البرمجي التالي كيفية القيام بذلك.
```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// استخراج الشريحة i في عرض تقديمي منفصل.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// تحويل الشريحة إلى صورة في مهمة منفصلة.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
			IImage image = null;
			try {
				ISlide slide = slidePresentation.getSlides().get_Item(0);

				image = slide.getImage(imageScale, imageScale);
				String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
				image.save(imageFilePath, ImageFormat.Png);
			} finally {
				if (image != null) image.dispose();
				slidePresentation.dispose();
			}
		}
	}));
}

// انتظار انتهاء جميع المهام.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```


## **الأسئلة الشائعة**

**هل أحتاج إلى استدعاء إعداد الترخيص في كل خيط؟**

لا. يكفي القيام بذلك مرة واحدة لكل عملية/نطاق تطبيق قبل بدء الخيوط. إذا كان من الممكن استدعاء [license setup](/slides/ar/androidjava/licensing/) بشكل متزامن (على سبيل المثال، أثناء التهيئة البطيئة)، فقم بمزامنة هذا الاستدعاء لأن طريقة إعداد الترخيص نفسها ليست آمنة للاستخدام المتعدد الخيوط.

**هل يمكنني تمرير كائنات `Presentation` أو `Slide` بين الخيوط؟**

لا يُنصح بتمرير كائنات العرض "الحية" بين الخيوط: استخدم نسخ مستقلة لكل خيط أو أنشئ مسبقًا عروضًا/حاويات شرائح منفصلة لكل خيط. يتماشى هذا النهج مع التوصية العامة بعدم مشاركة نسخة عرض واحدة عبر الخيوط.

**هل من الآمن تنفيذ تصدير متوازي إلى صيغ مختلفة (PDF، HTML، صور) شريطة أن يحتوي كل خيط على نسخة `Presentation` خاصة به؟**

نعم. مع نسخ مستقلة ومسارات إخراج منفصلة، عادةً ما يتم تنفيذ هذه المهام بشكل متوازي صحيح؛ تجنب أي كائنات عرض مشتركة أو تدفقات I/O مشتركة.

**ماذا يجب أن أفعل بإعدادات الخطوط العامة (المجلدات، الاستبدالات) في بيئة متعددة الخيوط؟**

قم بتهيئة جميع [font settings](/slides/ar/androidjava/powerpoint-fonts/) العامة قبل بدء الخيوط ولا تغيرها أثناء العمل المتوازي. هذا يزيل التعارضات عند الوصول إلى موارد الخطوط المشتركة.