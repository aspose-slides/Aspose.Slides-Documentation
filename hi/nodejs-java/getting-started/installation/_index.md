---
title: स्थापना
type: docs
weight: 70
url: /hi/nodejs-java/installation/
keywords:
- Aspose.Slides स्थापित करें
- Aspose.Slides डाउनलोड करें
- Aspose.Slides का उपयोग करें
- Aspose.Slides इंस्टॉलेशन
- विंडोज़
- लिनक्स
- मैकोएस
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- नोड.जेएस
- जावास्क्रिप्ट
- Aspose.Slides
description: "जानिए कैसे जल्दी से Aspose.Slides स्थापित करें। चरणबद्ध मार्गदर्शिका, सिस्टम आवश्यकताएँ, और कोड नमूने — आज ही PowerPoint प्रस्तुतियों के साथ काम शुरू करें!"
---
## **परिचय**

Aspose.Slides for Node.js via Java एक प्लेटफ़ॉर्म‑स्वतंत्र API है और इसे किसी भी प्लेटफ़ॉर्म (Windows, Linux और MacOS) पर उपयोग किया जा सकता है जहाँ `Node.js` और [`java`](https://www.npmjs.com/package/java) ब्रिज स्थापित हो।

## **NPM से इंस्टॉल करें**

आप आसानी से Aspose.Slides for Node.js via Java को [NPM](https://www.npmjs.com/) से इंस्टॉल कर सकते हैं।

1. नया फ़ोल्डर बनाएं और निम्नलिखित कमांड का उपयोग करके नया प्रोजेक्ट शुरू करें:
	```
	$ npm init
	```
	
2. शीर्षक और संस्करण फ़ील्ड भरें (बाकी फ़ील्ड को उनके डिफ़ॉल्ट मानों पर छोड़ दें)।

3. निम्नलिखित कमांड का उपयोग करके Aspose.Slides for Node.js via Java इंस्टॉल करें:
	```
	$ npm install aspose.slides.via.java
	```

यदि इंस्टॉल प्रक्रिया के दौरान आपको कोई समस्या आती है, तो कृपया इस [लेख](/slides/hi/nodejs-java/troubleshooting-installation/) को देखें।

**Usage Example**:

अपने प्रोजेक्ट फ़ोल्डर में `hello.js` नाम की फ़ाइल बनाएं और निम्नलिखित उदाहरण कोड जोड़ें:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **ZIP आर्काइव से इंस्टॉल करें**

ZIP आर्काइव से Aspose.Slides for Node.js via Java को इंस्टॉल और उपयोग करने के लिए, नीचे दिए गए निर्देशों का पालन करें:

### **विंडोज**

1. JDK8 इंस्टॉल करें और `JAVA_HOME` पर्यावरण वेरिएबल को कॉन्फ़िगर करें।  
1. Node.js (https://nodejs.org/en/download/) इंस्टॉल करें और node.exe को `PATH` में जोड़ें।  
1. node-gyp इंस्टॉल करें।  
1. Windows Build Tools इंस्टॉल करें।  
1. [`java`](https://www.npmjs.com/package/java) ब्रिज इंस्टॉल करें और कमांड प्रॉम्प्ट में प्रशासक के रूप में ये कमांड चलाएँ:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
6. [Aspose.Slides for Node.js via Java डाउनलोड करें](https://releases.aspose.com/slides/hi/nodejs-java/) और इसे `aspose.slides.nodejs/node_modules/aspose.slides.via.java` में अनज़िप करें।  
7. `aspose.slides.nodejs` फ़ोल्डर में `hello.js` नाम की फ़ाइल बनाएं और निम्नलिखित उदाहरण कोड का उपयोग करें:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
8. अब इसे चलाने के लिए कमांड प्रॉम्प्ट में `node hello.js` चलाएँ।

### **लिनक्स**

1. Node.js (https://nodejs.org/en/download/) इंस्टॉल करें।  
1. लिनक्स के लिए JDK8 इंस्टॉल करें और `JAVA_HOME` पर्यावरण वेरिएबल को कॉन्फ़िगर करें।  
1. python 2.x इंस्टॉल करें  
1. [`java`](https://www.npmjs.com/package/java) ब्रिज इंस्टॉल करें। आप टर्मिनल में ये कमांड चला सकते हैं:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. [Aspose.Slides for Node.js via Java डाउनलोड करें](https://releases.aspose.com/slides/hi/nodejs-java/) और इसे `aspose.slides.nodejs/node_modules/aspose.slides.via.java` में अनज़िप करें।  
6. `aspose.slides.nodejs` फ़ोल्डर में इस उदाहरण कोड का उपयोग करके `hello.js` नाम की टेस्ट फ़ाइल बनाएं:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. अब इसे चलाने के लिए कमांड प्रॉम्प्ट में `node hello.js` चलाएँ।

### **मैक**

1. Node.js (https://nodejs.org/en/download/) इंस्टॉल करें।  
1. मैक के लिए JDK8 इंस्टॉल करें और `JAVA_HOME` पर्यावरण वेरिएबल को कॉन्फ़िगर करें।  
1. `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` में JVMCapabilities सेक्शन को रूट प्रिविलेज के साथ संशोधित करें। `jdk1.8.x_xxx.jdk` आपके JDK संस्करण पर निर्भर करता है। इसे इस प्रकार बनाएं:
	```xml
	<key>JavaVM</key>
		<dict>
			<key>JVMCapabilities</key>
			<array>
					<string>JNI</string>
					<string>BundledApp</string>
					<string>CommandLine</string>
			</array>
	```
4. python 2.x इंस्टॉल करें (यदि पहले से इंस्टॉल नहीं है)।  
5. Xcode Command Line Tools इंस्टॉल करें।  
6. [`java`](https://www.npmjs.com/package/java) ब्रिज इंस्टॉल करें। आप टर्मिनल में नीचे दी गई कमांड चला सकते हैं:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. Aspose.Slides for Node.js via Java डाउनलोड करें और इसे `aspose.slides.nodejs/node_modules/aspose.slides.via.java` में अनज़िप करें।  
8. `aspose.slides.nodejs` फ़ोल्डर में इस उदाहरण कोड का उपयोग करके `hello.js` नाम की टेस्ट फ़ाइल बनाएं:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. अब इसे चलाने के लिए कमांड प्रॉम्प्ट में `node hello.js` चलाएँ।

{{% alert color="primary" %}}
यदि Aspose.Slides for Node.js via Java की इंस्टॉलेशन के दौरान आपको संकलन त्रुटियां आती हैं, तो कृपया निम्नलिखित [लेख](https://docs.aspose.com/slides/hi/nodejs-java/troubleshooting-installation/) का उपयोग करें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कोई मुफ्त संस्करण या ट्रायल सीमा है?**

हाँ, डिफ़ॉल्ट रूप से, Aspose.Slides मूल्यांकन मोड में चलता है, जिससे वॉटरमार्क लगते हैं और अन्य सीमाएँ हो सकती हैं। प्रतिबंध हटाने के लिए, आपको एक वैध [लाइसेंस](/slides/hi/nodejs-java/licensing/) लागू करना होगा।