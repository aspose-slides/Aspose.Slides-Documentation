---
title: Kurulum
type: docs
weight: 70
url: /tr/nodejs-java/installation/
keywords:
- Aspose.Slides'i kur
- Aspose.Slides'i indir
- Aspose.Slides'i kullan
- Aspose.Slides kurulumu
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides'i hızlıca nasıl kuracağınızı öğrenin. Adım adım kılavuz, sistem gereksinimleri ve kod örnekleri — bugün PowerPoint sunumlarıyla çalışmaya başlayın!"
---
## **Giriş**

Aspose.Slides for Node.js via Java platformdan bağımsız bir API'dir ve `Node.js` ve [`java`](https://www.npmjs.com/package/java) köprüsü yüklü olduğu herhangi bir platformda (Windows, Linux ve macOS) kullanılabilir.

## **NPM'den Yükleme**

Aspose.Slides for Node.js via Java'i kolayca [NPM](https://www.npmjs.com/) üzerinden yükleyebilirsiniz.

1. Yeni bir klasör oluşturun ve aşağıdaki komutu kullanarak yeni bir proje başlatın:
	```
	$ npm init
	```
	
2. Fill in the title and version fields (leave the remaining fields with their default values).

3. Install Aspose.Slides for Node.js via Java using the following command:
	```
	$ npm install aspose.slides.via.java
	```

If you encounter any problem during the installation process, please refer to this [article](/slides/tr/nodejs-java/troubleshooting-installation/).

**Usage Example**:

Create a file named `hello.js` in your project folder and add the following sample code:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **ZIP arşivinden Yükleme**

Aspose.Slides for Node.js via Java'i bir ZIP arşivinden yüklemek ve kullanmak için aşağıdaki talimatları izleyin:

### **Windows**

1. JDK8'i kurun ve `JAVA_HOME` ortam değişkenini yapılandırın.
1. Node.js (https://nodejs.org/en/download/) kurun ve node.exe dosyasını `PATH` değişkenine ekleyin.
1. node-gyp'i kurun.
1. Windows Build Tools'u kurun.
1. [`java`](https://www.npmjs.com/package/java) köprüsünü kurun ve bu komutları Yönetici olarak bir Komut İstemi'nde çalıştırın:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
6. [Aspose.Slides for Node.js via Java'i indirin](https://releases.aspose.com/slides/tr/nodejs-java/) ve `aspose.slides.nodejs/node_modules/aspose.slides.via.java` konumuna çıkarın.
7. Aşağıdaki örnek kodu kullanarak `aspose.slides.nodejs` klasöründe `hello.js` adlı bir dosya oluşturun:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
8. Şimdi `node hello.js` komut satırında çalıştırın.

### **Linux**

1. Node.js (https://nodejs.org/en/download/) kurun.
1. Linux için JDK8'i kurun ve `JAVA_HOME` ortam değişkenini yapılandırın.
1. python 2.x kurun.
1. [`java`](https://www.npmjs.com/package/java) köprüsünü kurun. Terminalde aşağıdaki komutları çalıştırabilirsiniz:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. [Aspose.Slides for Node.js via Java'i indirin](https://releases.aspose.com/slides/tr/nodejs-java/) ve `aspose.slides.nodejs/node_modules/aspose.slides.via.java` konumuna çıkarın.
6. `aspose.slides.nodejs` klasöründe aşağıdaki örnek kodu kullanarak `hello.js` adlı bir test dosyası oluşturun:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. Şimdi `node hello.js` komut satırında çalıştırın.

### **Mac**

1. Node.js (https://nodejs.org/en/download/) kurun.
1. Mac için JDK8'i kurun ve `JAVA_HOME` ortam değişkenini yapılandırın.
1. `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` içindeki JVMCapabilities bölümünü root yetkisiyle değiştirin. `jdk1.8.x_xxx.jdk` kısmı jdk sürümünüze bağlıdır. Aşağıdaki gibi görünmelidir:
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
4. python 2.x kurun (yüklü değilse).
5. Xcode Command Line Tools'u kurun.
6. [`java`](https://www.npmjs.com/package/java) köprüsünü kurun. Terminalde aşağıdaki komutları çalıştırabilirsiniz:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. Aspose.Slides for Node.js via Java'i indirin ve `aspose.slides.nodejs/node_modules/aspose.slides.via.java` klasörüne çıkarın.
8. Aşağıdaki örnek kodu kullanarak `aspose.slides.nodejs` klasöründe `hello.js` adlı bir test dosyası oluşturun:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. Şimdi `node hello.js` komut satırında çalıştırın.


{{% alert color="primary" %}}
Aspose.Slides for Node.js via Java kurulum sırasında derleme hatalarıyla karşılaşırsanız lütfen aşağıdaki [makaleyi](https://docs.aspose.com/slides/tr/nodejs-java/troubleshooting-installation/) kullanın.
{{% /alert %}}

## **SSS**

**Ücretsiz bir sürüm veya deneme sınırlaması var mı?**

Evet, varsayılan olarak Aspose.Slides değerlendirme modunda çalışır; bu mod filigran ekler ve diğer sınırlamalara sahip olabilir. Kısıtlamaları kaldırmak için geçerli bir [lisans](/slides/tr/nodejs-java/licensing/) uygulamanız gerekir.