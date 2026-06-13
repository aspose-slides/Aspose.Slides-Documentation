---
title: Aspose.Slides for Android via Java में मल्टीथ्रेडिंग
linktitle: मल्टीथ्रेडिंग
type: docs
weight: 310
url: /hi/androidjava/multithreading/
keywords:
- मल्टीथ्रेडिंग
- एकाधिक थ्रेड्स
- समांतर कार्य
- स्लाइड्स को परिवर्तित करें
- स्लाइड्स से इमेजेज़
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java मल्टीथ्रेडिंग PowerPoint और OpenDocument प्रोसेसिंग को तेज़ बनाता है। कुशल प्रस्तुति कार्यप्रवाहों के लिए सर्वोत्तम प्रथाओं की खोज करें।"
---
## **परिचय**

जबकि समानांतर रूप से प्रस्तुतियों के साथ काम करना (पार्सिंग/लोडिंग/क्लोनिंग अलावा) संभव है और अधिकांश समय सब ठीक चलता है, फिर भी यदि आप लाइब्रेरी को कई थ्रेड्स में उपयोग करते हैं तो गलत परिणाम मिलने की छोटी संभावनाएँ रहती हैं।

हम दृढ़ता से सलाह देते हैं कि आप मल्टी‑थ्रेडिंग वातावरण में एकल [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) उदाहरण का उपयोग **न करें**, क्योंकि इससे अनपेक्षित त्रुटियाँ या विफलताएँ हो सकती हैं जो आसानी से पता नहीं चल पातीं।

एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास की इंस्टेंस को कई थ्रेड्स में लोड, सेव या क्लोन करना **सुरक्षित नहीं** है। ऐसे ऑपरेशंस **समर्थित नहीं** हैं। यदि आपको ऐसे कार्य करने हैं, तो आपको कई सिंगल‑थ्रेडेड प्रोसेस का उपयोग करके ऑपरेशंस को समानांतर बनाना होगा—और इन प्रत्येक प्रोसेस को अपना स्वयं का प्रस्तुति उदाहरण उपयोग करना चाहिए।

## **समांतर रूप से प्रस्तुतिकरण स्लाइड्स को इमेजेज़ में बदलें**

मान लीजिए हम सभी स्लाइड्स को एक PowerPoint प्रस्तुति से PNG इमेजेज़ में समानांतर रूप से बदलना चाहते हैं। चूँकि कई थ्रेड्स में एक ही `Presentation` उदाहरण का उपयोग करना असुरक्षित है, हम प्रस्तुति स्लाइड्स को अलग‑अलग प्रस्तुतियों में विभाजित करते हैं और प्रत्येक थ्रेड में अलग प्रस्तुति का उपयोग करके स्लाइड्स को इमेज में बदलते हैं। नीचे दिया गया कोड उदाहरण इसे दर्शाता है।

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
	// स्लाइड i को एक अलग प्रस्तुति में निकालें।
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// स्लाइड को अलग कार्य में इमेज में बदलें।
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

// सभी कार्यों के समाप्त होने की प्रतीक्षा करें.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे प्रत्येक थ्रेड में लाइसेंस सेटअप को कॉल करना चाहिए?**

नहीं। प्रक्रिया/ऐप डोमेन को शुरू करने से पहले एक बार ही इसे करना पर्याप्त है। यदि [license setup](/slides/hi/androidjava/licensing/) को एक साथ कॉल किया जा सकता है (उदाहरण के लिए, लेज़ी इनिशियलाइज़ेशन के दौरान), तो उस कॉल को सिंक्रनाइज़ करें क्योंकि लाइसेंस सेटअप मेथड स्वयं थ्रेड‑सेफ़ नहीं है।

**क्या मैं `Presentation` या `Slide` ऑब्जेक्ट्स को थ्रेड्स के बीच पास कर सकता हूँ?**

"लाइव" प्रस्तुति ऑब्जेक्ट्स को थ्रेड्स के बीच पास करना अनुशंसित नहीं है: प्रत्येक थ्रेड के लिए स्वतंत्र इंस्टेंस का उपयोग करें या प्रत्येक थ्रेड के लिए अलग-अलग प्रस्तुति/स्लाइड कंटेनर पहले से बना लें। यह सामान्य सिफ़ारिश के अनुरूप है कि एक ही प्रस्तुति इंस्टेंस को थ्रेड्स के बीच साझा न किया जाए।

**क्या प्रत्येक थ्रेड के पास अपना `Presentation` इंस्टेंस होने पर विभिन्न फ़ॉर्मेट्स (PDF, HTML, images) में एक्सपोर्ट को समानांतर बनाना सुरक्षित है?**

हां। स्वतंत्र इंस्टेंस और अलग‑अलग आउटपुट पाथ्स के साथ, ऐसे कार्य सामान्यतः सही ढंग से समानांतर होते हैं; किसी भी साझा प्रस्तुति ऑब्जेक्ट और साझा I/O स्ट्रीम से बचें।

**मल्टीथ्रेडिंग में ग्लोबल फ़ॉन्ट सेटिंग्स (फ़ोल्डर्स, सब्स्टिट्यूशन) के साथ क्या करना चाहिए?**

थ्रेड्स शुरू करने से पहले सभी ग्लोबल [font settings](/slides/hi/androidjava/powerpoint-fonts/) को इनिशियलाइज़ करें और समानांतर कार्य के दौरान उन्हें बदलें नहीं। इससे साझा फ़ॉन्ट संसाधनों तक पहुंचते समय रेस कंडीशन समाप्त हो जाती हैं।