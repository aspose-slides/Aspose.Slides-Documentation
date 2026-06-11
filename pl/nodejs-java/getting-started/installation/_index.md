---
title: Instalacja
type: docs
weight: 70
url: /pl/nodejs-java/installation/
keywords:
- instalacja Aspose.Slides
- pobranie Aspose.Slides
- użycie Aspose.Slides
- instalacja Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak szybko zainstalować Aspose.Slides. Przewodnik krok po kroku, wymagania systemowe i przykłady kodu — rozpocznij pracę z prezentacjami PowerPoint już dziś!"
---
## **Wprowadzenie**

Aspose.Slides for Node.js via Java jest niezależnym od platformy API i może być używany na dowolnej platformie (Windows, Linux i macOS), na której zainstalowane są `Node.js` i most [`java`](https://www.npmjs.com/package/java) .

## **Instalacja z NPM**

Możesz łatwo zainstalować Aspose.Slides for Node.js via Java z [NPM](https://www.npmjs.com/).

1. Utwórz nowy folder i zainicjuj nowy projekt, używając następującego polecenia:
	```
	$ npm init
```
	
2. Wypełnij pola tytułu i wersji (pozostałe pola pozostaw z wartościami domyślnymi).

3. Zainstaluj Aspose.Slides for Node.js via Java, używając następującego polecenia:
	```
	$ npm install aspose.slides.via.java
```

Jeśli napotkasz jakikolwiek problem podczas procesu instalacji, odwołaj się do tego [artykułu](/slides/pl/nodejs-java/troubleshooting-installation/).

**Przykład użycia**:

Utwórz plik o nazwie `hello.js` w folderze projektu i dodaj poniższy przykładowy kod:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **Instalacja z archiwum ZIP**

Aby zainstalować i używać Aspose.Slides for Node.js via Java z archiwum ZIP, postępuj zgodnie z poniższymi instrukcjami:

### **Windows**

1. Zainstaluj JDK8 i skonfiguruj zmienną środowiskową `JAVA_HOME`.
1. Zainstaluj Node.js (https://nodejs.org/en/download/) i dodaj node.exe do `PATH`.
1. Zainstaluj node-gyp.
1. Zainstaluj Windows Build Tools.
1. Zainstaluj most [`java`](https://www.npmjs.com/package/java) i uruchom te polecenia w wierszu poleceń jako administrator:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
```
6. [Pobierz Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/pl/nodejs-java/) i rozpakuj go do `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Utwórz plik o nazwie `hello.js` w folderze `aspose.slides.nodejs` używając poniższego przykładowego kodu:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
```

8. Teraz uruchom `node hello.js` w wierszu poleceń, aby go uruchomić.

### **Linux**

1. Zainstaluj Node.js (https://nodejs.org/en/download/).
1. Zainstaluj JDK8 dla Linuxa i skonfiguruj zmienną środowiskową `JAVA_HOME`.
1. Zainstaluj python 2.x
1. Zainstaluj most [`java`](https://www.npmjs.com/package/java). Możesz uruchomić te polecenia w terminalu:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
```
5. [Pobierz Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/pl/nodejs-java/) i rozpakuj go do `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Utwórz plik testowy o nazwie `hello.js` używając tego przykładowego kodu w folderze `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. Teraz uruchom `node hello.js` w wierszu poleceń, aby go uruchomić.

### **Mac**

1. Zainstaluj Node.js (https://nodejs.org/en/download/).
1. Zainstaluj JDK8 dla Mac i skonfiguruj zmienną środowiskową `JAVA_HOME`.
1. Zmodyfikuj sekcję JVMCapabilities w `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` z uprawnieniami administratora. `jdk1.8.x_xxx.jdk` zależy od wersji twojego JDK. Powinno to wyglądać tak:
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
4. Zainstaluj python 2.x (jeśli nie jest zainstalowany).
5. Zainstaluj Xcode Command Line Tools.
6. Zainstaluj most [`java`](https://www.npmjs.com/package/java). Poniżej możesz uruchomić polecenia w terminalu:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
```
7. Pobierz Aspose.Slides for Node.js via Java i rozpakuj go do `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Utwórz plik testowy o nazwie `hello.js` używając tego przykładowego kodu w folderze `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. Teraz uruchom `node hello.js` w wierszu poleceń, aby go uruchomić.


{{% alert color="primary" %}}

Proszę skorzystać z następującego [artykułu](https://docs.aspose.com/slides/pl/nodejs-java/troubleshooting-installation/), jeśli napotkasz błędy kompilacji podczas instalacji Aspose.Slides for Node.js via Java.

{{% /alert %}}

## **FAQ**

**Czy istnieje wersja darmowa lub ograniczenia wersji próbnej?**

Tak, domyślnie Aspose.Slides działa w trybie ewaluacyjnym, który umieszcza znaki wodne i może mieć inne ograniczenia. Aby usunąć ograniczenia, musisz zastosować ważną [licencję](/slides/pl/nodejs-java/licensing/).