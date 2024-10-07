---
title: البرمجة المتعددة في Aspose.Slides
type: docs
weight: 310
url: /androidjava/multithreading/
keywords:
- PowerPoint
- تقديم
- البرمجة المتعددة
- العمل المتوازي
- تحويل الشرائح
- الشرائح إلى صور
- أندرويد
- جافا
- Aspose.Slides لأندرويد عبر جافا
---

## **مقدمة**

بينما العمل المتوازي مع العروض التقديمية ممكن (بجانب التحليل/التحميل/النسخ) وكل شيء يسير بشكل جيد (معظم الأوقات)، توجد فرصة صغيرة للحصول على نتائج غير صحيحة عند استخدام المكتبة في عدة خيوط.

نوصي بشدة بعدم استخدام مثيل واحد من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) في بيئة متعددة الخيوط لأنه قد يؤدي إلى أخطاء أو فشل غير متوقعة يصعب اكتشافها.

ليس من الآمن تحميل أو حفظ أو نسخ مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) في عدة خيوط. مثل هذه العمليات **غير مدعومة**. إذا كنت بحاجة إلى تنفيذ مثل هذه المهام، عليك بالتوازي تنفيذ العمليات باستخدام عدة عمليات ذات خيط واحد—ويجب أن يستخدم كل من هذه العمليات مثيل عرضه الخاص.

## **تحويل شرائح العرض إلى صور بشكل متوازي**

لنقل أننا نريد تحويل جميع الشرائح من عرض PowerPoint إلى صور PNG بشكل متوازي. نظرًا لأنه غير آمن استخدام مثيل واحد من `Presentation` في عدة خيوط، نقوم بتقسيم شرائح العرض إلى عروض منفصلة ونحول الشرائح إلى صور بشكل متوازي، باستخدام كل عرض في خيط منفصل. المثال البرمجي التالي يوضح كيفية القيام بذلك.

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
	// استخرج الشريحة i إلى عرض منفصل.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// حول الشريحة إلى صورة في مهمة منفصلة.
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

// انتظر حتى تكتمل جميع المهام.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```