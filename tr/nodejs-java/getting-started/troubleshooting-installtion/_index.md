---
title: Aspose.Slides for Node.js via Java Kurulum Sorunlarını Giderme
linktitle: Kurulum Sorunlarını Giderme
type: docs
weight: 75
url: /tr/nodejs-java/troubleshooting-installation/
keywords:
- Aspose.Slides indirme
- Aspose.Slides kurma
- kurulum sorunlarını giderme
- sürüm gereksinimleri
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kurulum sorunlarını giderin, yaygın hataları ve bağımlılıkları düzeltin ve PPT, PPTX ve ODP ile sorunsuz çalışma sağlayın."
---
## **Giriş**

npm kullanarak `aspose.slides.via.java` [installing](/slides/tr/nodejs-java/installation/) yaparken, `java` ve `node-gyp` modüllerinin derlemesi sırasında hataların oluştuğu durumlar vardır. Bu hataları daha ayrıntılı olarak araştırdık ve yüklü programlar ve paketler için belirli sürüm gereksinimlerini belirledik. 

## **Sürüm gereksinimleri**

1. Node.js 12 ve daha eski sürümler için:
   - Python 3.10'dan yüksek olmamalıdır.
   - Windows için, 2017'den yeni olmayan Visual Studio Build Tools kurulması önerilir.
   - npm java paketi sürümü: 0.12.1.

2. Node.js 13 için:
   - Node.js 12 için olan aynı gereksinimler.

3. Node.js 14 için:
   - Python 3.10.
   - npm java paketi sürümü: 0.14.0.

4. Node.js 15 için:
   - Python 3.12.
   - npm java paketi sürümü: 0.14.0.

5. Node.js 16 ve daha yeni sürümler için:
   - Python 3.12.
   - npm java paketi sürümü: 0.14.0.

**Aşağıdaki talimatları izleyerek gerekli programları kurun.**

### **Unix'ta Kurulum**

- [Node.js](https://nodejs.org/en/download) kurun.
- [Python](https://devguide.python.org/versions/) kurun.
- Java (JDK 1.8) kurun.
- [GCC](https://gcc.gnu.org) gibi uygun bir C/C++ derleyici araç zinciri kurun.

### **macOS'ta Kurulum**

- [Node.js](https://nodejs.org/en/download) kurun.
- [Python](https://devguide.python.org/versions/) kurun.
- Java (JDK 1.8) kurun ve `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` dosyasındaki JVMCapabilities bölümünü root yetkisiyle değiştirin. `jdk1.8.x_xxx.jdk` dosyası jdk sürümünüze bağlıdır. Aşağıdaki gibi görünmelidir: 
```
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
- `Xcode Command Line Tools` paketini `xcode-select --install` komutuyla tek başına kurun. -- OR -- Alternatif olarak, zaten [tam Xcode yüklüyse](https://developer.apple.com/xcode/download/), menüde `Xcode -> Open Developer Tool -> More Developer Tools...` yolunu izleyerek Command Line Tools'u kurabilirsiniz.

### **Windows'ta Kurulum**

- [Node.js](https://nodejs.org/en/download) kurun.
- [Python](https://devguide.python.org/versions/) paketini [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation) üzerinden kurun.
- Java (JDK 1.8) kurun.
- [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) kurun (VS2019 öncesi bir sürüm kullanıyorsanız “Visual C++ build tools” seçeneğini, aksi takdirde “Desktop development with C++” iş yükünü ya da “Desktop development with C++” iş yüküyle birlikte [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) kullanın).

Node.js, Python ve Java’nın PATH değişkenine eklendiğinden emin olun.

## **Node.js sürüm 14 ve üzeri için Java aracılığıyla Aspose.Slides for Node.js kurulumu**

Aşağıdaki komutu kullanın:
```
npm i aspose.slides.via.java
```

## **Node.js sürüm 12 veya 13 için Java aracılığıyla Aspose.Slides for Node.js kurulumu**

Aspose.Slides for Node.js via Java manuel olarak kurulmalıdır. Aşağıdaki komutu kullanın:

- Node.js 12 için:
```
npm i java@0.12.1
```
- Node.js 13 için: 
```
npm i java@0.13.0
```

Daha sonra [aspose.slides.via.java](https://releases.aspose.com/slides/tr/nodejs-java/) paketini indirin ve `node_modules/aspose.slides.via.java` klasörüne çıkarın.

## **Kurulumu doğrulama**

Kurulumu doğrulamak için projenizin kök dizininde aşağıdaki içeriğe sahip bir `index.js` dosyası oluşturun:

```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

Bu dosyayı `node index.js` komutuyla çalıştırın.

## **Ek Bilgiler**

Bu makalenin kapsamı içinde tüm olası sorunları ele almak mümkün değildir. Sorunlar `java` ve `node-gyp` modüllerinin derlemesinden kaynaklandığı için aşağıdaki bağlantılar da yararlı olacaktır:
- [java kurulumu](https://www.npmjs.com/package/java#installation) 
- [node-gyp kurulumu](https://www.npmjs.com/package/node-gyp#installation)