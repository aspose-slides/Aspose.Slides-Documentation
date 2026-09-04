---
title: Sınırlamalar ve API Farklılıkları
type: docs
weight: 100
url: /tr/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides for Python via Java
- API farklılıkları
- Python
- Java
- JPype
- JVM sınırlamaları
- PowerPoint
description: "Aspose.Slides for Java ve Python via Java arasındaki JVM sınırlamaları ve API farklılıkları hakkında, içe aktarmalar, kaynak temizliği ve dosya işlemleri dahil olmak üzere bilgi edinin."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, JPype kullanarak Java kitaplığını Python'dan erişir. Aşağıdaki örnekler, paket içe aktarmalarını, sunum oluşturmayı ve iki API'deki dosya işlemlerini karşılaştırır.

## **Bilinen Kısıtlamalar**

- **JVM yaşam döngüsü:** JPype, her Python işlemi için bir JVM destekler. JVM kapatıldıktan sonra aynı işlem içinde yeniden başlatılamaz. JVM'i bir kez başlatın ve sonraki sunum işlemleri için yeniden kullanın.
- **Mimari uyumluluğu:** Python ve Java, aynı mimariye sahip olmalıdır. Ayrıntılar için [System Requirements](/slides/tr/python-java/system-requirements/#python-java-and-jpype-requirements) sayfasına bakın.

Bu kısıtlamalar ve Java birlikte çalışabilirliği hakkında ayrıntılar için [JPype User Guide](https://jpype.readthedocs.io/en/latest/userguide.html) sayfasına göz atın.

## **Genel API Farklılıkları**

Aşağıdaki Java ve Python örneklerini karşılaştırın. Python via Java üye detayları için [API Reference](/slides/tr/python-java/api-reference/) bölümüne bakın.

### **Kütüphaneyi İçe Aktarma**

Java, sınıfları `com.aspose.slides` paketinden içe aktarır. Python’da, JVM’i başlatmadan önce `asposeslides` paketini, JVM çalıştıktan sonra ise `asposeslides.api` paketinden sınıfları içe aktarın. Zaten çalışan bir JVM’i yeniden başlatmayı önlemek için [jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted) yöntemini kullanın.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
```

{{% alert color="info" title="Note" %}}
Python örnekleri, JVM’i Python süreci sona erene kadar çalışır durumda bırakır. Bir notebook içinde, aktif JVM’i hücreler arasında yeniden kullanın. JVM zaten kapatıldıysa, Java nesnelerini tekrar kullanmadan önce notebook çekirdeğini yeniden başlatın.
{{% /alert %}}

### **Sunum Oluşturma**

Java `new` anahtar kelimesini kullanır; Python doğrudan [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfını çağırır. Sunum kaynaklarını `finally` bloğunda [Presentation.dispose](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#dispose) ile serbest bırakın.

Her iki örnek de boş bir sunumu [Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save) ve [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#pptx) kullanarak kaydeder.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.save("new-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Dosyaları Okuma ve Biçim Sabitlerini Kullanma**

Java, bir Java giriş akışından sunumu yükleyebilir. Python’da dosyayı ikili veri olarak okuyun ve elde edilen baytları [Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#createpresentationfrombytes) metoduna aktarın. Bir Python dosya nesnesi, Java giriş akışı değildir.

Aşağıdaki örnekler, çalışma dizininde mevcut bir `presentation.pptx` dosyası gerektirir ve bir kopyasını `result.pptx` olarak kaydeder. Her iki örnek de giriş dosyasını kapatır ve sunum kaynaklarını **serbest** bırakır. Python örneği, tüm giriş dosyasını belleğe okur.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileInputStream;
import java.io.InputStream;

try (InputStream inputStream = new FileInputStream("presentation.pptx")) {
    Presentation presentation = new Presentation(inputStream);
    try {
        presentation.save("result.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

with open("presentation.pptx", "rb") as input_file:
    data = input_file.read()

presentation = Presentation.createPresentationFromBytes(data)
try:
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Her sunum için JVM’i yeniden başlatmam gerekiyor mu?**

Hayır. JVM’i çalışır durumda tutun ve gerektiğinde sunum nesnelerini oluşturup serbest bırakın. JVM’i kapatmak, aynı Python işlemi içinde daha fazla Java işlemi yapmayı engeller.

**Sunumu doğrudan dosya yolundan açabilir miyim?**

Evet. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) oluşturucusu bir dosya yolunu kabul eder. Sunum verileri zaten Python baytları olarak mevcutsa bayt tabanlı yardımcıyı kullanın.

**Java örneklerindeki biçim sabiti adlarını Python’a çevirirken değiştirmeli miyim?**

Hayır. Örneğin, [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/python-java/aspose.slides/saveformat/#pptx) her iki API’de de aynı yazım ve büyük‑küçük harf duyarlılığına sahiptir.