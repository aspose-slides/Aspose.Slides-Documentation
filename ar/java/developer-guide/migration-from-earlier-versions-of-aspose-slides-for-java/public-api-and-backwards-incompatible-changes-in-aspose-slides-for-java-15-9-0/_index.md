---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.9.0
linktitle: Aspose.Slides لـ Java 15.9.0
type: docs
weight: 170
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/
keywords:
- الترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتقطعة في Aspose.Slides لـ Java لترحيل حلول عروض PowerPoint PPT و PPTX و ODP بسلاسة."
---
{{% alert color="info" %}} 

تُظهر هذه الصفحة جميع الفئات، الطرق، الخصائص وما إلى ذلك التي تم [أضيفت](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) أو [تمت إزالتها](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-9-0/) مع Aspose.Slides for Java 15.8.0 API.

{{% /alert %}} 
## **التغييرات العامة في واجهة برمجة التطبيقات**
#### **تم إضافة طرق renderToGraphics إلى com.aspose.slides.ISlide، Slide**
تمت إضافة الطرق التالية:

renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, int width, int height);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics, float scale);
renderToGraphics(boolean withNotes, java.awt.Graphics2D graphics);

تمت إضافتها إلى واجهة com.aspose.slides.ISlide وإلى فئة com.aspose.slides.Slide. تسمح هذه الطرق بإنشاء عرض للشريحة على كائن Graphics2D المحدد.

تمت إزالة طرق `renderToGraphics` منذ ذلك الحين من الواجهة العامة لبرمجة التطبيقات. في الإصدارات الحالية، يتم إنشاء عرض للشريحة باستخدام [ISlide.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-)، كما في المثال أدناه:

``` java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("SomePresentation.pptx");

try {

	IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

	try {

		slideImage.save("slide.png", ImageFormat.Png);

	} finally {

		slideImage.dispose();

	}

} finally {

	if (pres != null) pres.dispose();

}

```