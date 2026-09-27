---
title: Kurulum
type: docs
weight: 70
url: /tr/nodejs-java/installation/
keywords:
- Aspose.Slides’i kur
- Aspose.Slides’i indir
- Aspose.Slides’i kullan
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
description: "Windows, Linux ve macOS üzerinde npm'den Java aracılığıyla Node.js için Aspose.Slides'i kurun: ihtiyaç duyduğu JDK, Python ve C++ derleme araçları, npm komutu ve kurulumu kontrol etmek için ilk betik."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Node.js via Java'nin Windows, Linux ve macOS üzerinde nasıl kurulacağını ve kurulumun çalıştığını nasıl kontrol edeceğinizi açıklar.

Aspose.Slides for Node.js via Java, npm üzerinde `aspose.slides.via.java` paketi olarak dağıtılır. [`java`](https://github.com/joeferner/node-java) paketi aracılığıyla Aspose.Slides'i bir Java sanal makinesinde çalıştırır; bu, npm'nin kurulum sırasında bilgisayarınızda derlediği yerel bir Node.js eklentisidir. Bu nedenle kurulum, Node.js'in yanı sıra şunları da gerektirir:

- **Java Development Kit (JDK) 8 veya üzeri.** Tek bir Java çalışma zamanı yeterli değildir: derleme JDK'nin başlık dosyalarına ihtiyaç duyar.
- **Python 3**, derleme aracı [node-gyp](https://github.com/nodejs/node-gyp) tarafından kullanılır.
- **İşletim sisteminiz için bir C++ derleme araç zinciri**.

## **Gereksinimleri Yükleyin**

### **Windows**

1. Node.js 20 veya üzerini [Node.js](https://nodejs.org/en/download) sitesinden yükleyin.
2. Örneğin [Eclipse Temurin](https://adoptium.net/) gibi bir JDK yükleyin ve `JAVA_HOME` ortam değişkenini kurulum klasörüne ayarlayın. Derleme, `JAVA_HOME`'un işaret ettiği JDK'yi kullanır.
3. [Python 3](https://www.python.org/downloads/) yükleyin.
4. [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) paketini **Desktop development with C++** iş yüküyle yükleyin. İş yükünün varsayılan bileşenlerini (örneğin **MSVC v143 - VS 2022 C++ x64/x86 build tools** ve **Windows 11 SDK**) koruyun. Visual Studio 2026 çalışmaz: `java` paketinin derlediği node-gyp sürümü bunu tanımaz.

### **Linux**

Node.js 20 veya üzerini [nodejs.org](https://nodejs.org/en/download) adresinden ya da dağıtımınızın paket kaynağından yükleyin. Ardından bir JDK, Python 3 ve C++ derleme araçlarını kurun. Debian ve Ubuntu için:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

Linux'ta, derleme kurulu JDK'yı ek bir yapılandırma olmadan bulur. Birden fazla JDK yüklüyse, kullanmak istediğiniz JDK'yı `JAVA_HOME` değişkenine ayarlayın.

### **macOS**

Node.js 20 veya üzerini, bir JDK'yı ve Python 3 ile C++ derleyicisini içeren Xcode Command Line Tools'u kurun. macOS'a özgü notlar için [Troubleshooting Installation](/slides/tr/nodejs-java/troubleshooting-installation/) sayfasına bakın.

## **npm'den Yükleme**

Bir proje klasörü oluşturun ve paketi kurun:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm, Aspose.Slides'ı indirir ve birkaç dakika sürebilen `java` köprüsünü derler. Derleme başarısız olursa, [Troubleshooting Installation](/slides/tr/nodejs-java/troubleshooting-installation/) sayfasına bakın.

## **Kurulumu Kontrol Et**

Proje klasöründe *hello.js* adlı bir dosya oluşturun ve aşağıdaki kodu ekleyin. Bu kod bir sunum oluşturur, ilk slaytına bir metin kutusu ekler ve sonucu *hello.pptx* olarak kaydeder:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides, Node.js'in çalışmasını sürdüren bir Java sanal makinesinde çalışır, bu yüzden süreci açıkça sonlandırın.
process.exit(0);
```

Betik çalıştırın:

```bash
node hello.js
```

*hello.pptx* proje klasöründe görünüyorsa kurulum çalışıyor demektir. Aspose.Slides'ı çalıştıran Java sanal makinesi, Node.js'in kendi kendine çıkmasını engeller; bu yüzden betik `process.exit(0)` ile sonlandırılır. Kodu açıklayan sayfaya bakın: [Create Presentations](/slides/tr/nodejs-java/create-presentation/).

## **ZIP Arşivinden Yükleme**

Paket ayrıca npm paketiyle aynı içeriğe sahip bir ZIP arşivi olarak da sunulur. Arşivden yüklemek için:

1. Yukarıda açıklandığı gibi işletim sisteminiz için gereksinimleri kurun.
2. Arşivi [Aspose.Slides for Node.js via Java indirme sayfasından](https://releases.aspose.com/slides/nodejs-java/) indirin.
3. Bir proje klasörü oluşturun:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

4. Arşivi proje klasörünün içinde *aspose.slides.via.java* adlı bir alt klasöre çıkarın; böylece arşivin *package.json* dosyası *hello-slides/aspose.slides.via.java/package.json* yolunda olur.
5. Paketi o klasörden kurun:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm, paketin bağımlı olduğu `java` köprüsünü kurar ve npm paketinde olduğu gibi derler.

6. [Kurulumu Kontrol Et](#check-the-installation) bölümünde açıklandığı gibi kurulumu kontrol edin.

## **FAQ**

**Ücretsiz bir sürüm veya deneme sınırlaması var mı?**

Evet. Lisans olmadan Aspose.Slides değerlendirme modunda çalışır: kaydettiği her slayta bir değerlendirme filigranı ekler ve sunumlardan okunan metni kısaltır. Bu sınırlamaları kaldırmak için geçerli bir [license](/slides/tr/nodejs-java/licensing/) uygulayın.

**Betik tamamlandıktan sonra neden çıkmıyor?**

`java` paketi, Node.js süreci içinde bir Java sanal makinesi başlatır ve bu sanal makine sürecin çalışmasını sürdürür. Betiğiniz işi bittiğinde `process.exit` çağırın.