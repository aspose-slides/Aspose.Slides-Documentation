---
title: चित्र
type: docs
weight: 50
url: /hi/androidjava/examples/elements/picture/
keywords:
- कोड उदाहरण
- चित्र
- पावरपॉइंट
- ओपनडॉक्युमेंट
- प्रस्तुति
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Aspose.Slides for Android में चित्रों के साथ काम करें: डालें, क्रॉप करें, संकुचित करें, रंग बदलें, और जावा उदाहरणों के साथ PPT, PPTX, और ODP प्रस्तुतियों के लिए छवियों को निर्यात करें।"
---
यह लेख दर्शाता है कि **Aspose.Slides for Android via Java** का उपयोग करके इन‑मेमोरी छवियों से चित्र कैसे सम्मिलित और एक्सेस किए जाएँ। नीचे के उदाहरण मेमोरी में एक छवि बनाते हैं, उसे स्लाइड पर रखते हैं, और फिर उसे प्राप्त करते हैं।

## **चित्र जोड़ें**

यह कोड एक छोटा बिटमैप बनाता है, उसे स्ट्रीम में परिवर्तित करता है, और पहले स्लाइड पर इसे चित्र फ्रेम के रूप में सम्मिलित करता है।

```java
public static void addPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		// एक सरल इन‑मेमोरी छवि बनाएं।
		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		Canvas graphics = new Canvas(bitmap);
		
		Paint paint = new Paint();
		paint.setColor(Color.valueOf(144, 238, 144).toArgb());
		paint.setStyle(Paint.Style.FILL);
		graphics.drawRect(0, 0, 100, 100, paint);

		// बिटमैप को बाइट एरे में परिवर्तित करें।
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		// छवि को प्रस्तुति में जोड़ें।
		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));

		// पहले स्लाइड पर छवि दिखाने वाला चित्र फ्रेम सम्मिलित करें।
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image);

		presentation.save("picture.pptx", SaveFormat.Pptx);
	} finally {
		presentation.dispose();
	}
}
```

## **चित्र तक पहुँचें**

यह उदाहरण सुनिश्चित करता है कि स्लाइड में एक चित्र फ्रेम मौजूद है और फिर वह पहला मिलने वाला चित्र फ्रेम तक पहुँचता है।

```java
public static void accessPicture() throws IOException {
	Presentation presentation = new Presentation();
	try {
		ISlide slide = presentation.getSlides().get_Item(0);

		Bitmap bitmap = Bitmap.createBitmap(100, 100, Bitmap.Config.ARGB_8888);
		ByteArrayOutputStream bitmapStream = new ByteArrayOutputStream();
		bitmap.compress(android.graphics.Bitmap.CompressFormat.PNG,100, bitmapStream);
		byte[] pngBytes = bitmapStream.toByteArray();

		IPPImage image = presentation.getImages().addImage(new ByteArrayInputStream(pngBytes));
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

		IPictureFrame pictureFrame = null;
		for (IShape shape : slide.getShapes()) {
			if (shape instanceof IPictureFrame) {
				pictureFrame = (IPictureFrame) shape;
				break;
			}
		}
	} finally {
		presentation.dispose();
	}
}
```