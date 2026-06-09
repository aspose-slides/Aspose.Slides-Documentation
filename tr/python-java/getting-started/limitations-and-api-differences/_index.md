---
title: Sınırlamalar ve API Farklılıkları
type: docs
weight: 100
url: /tr/python-java/limitations-and-api-differences/
keywords: "düğüm, powerpoint, kısıtlama, api, farklılıklar"
description: "Java üzerinden Python için Aspose.Slides sınırlamaları ve api farklılıkları."
---
## **Bilinen Hatalar/Kısıtlamalar**
Paket dışındaki Java sınıfları (`default` içinde) içe aktarılamaz.
JVM desteği eksik olduğundan, JVM'i kapatıp yeniden başlatamazsınız. Ayrıca birden fazla JVM kopyasını başlatamazsınız.
64 bit Python ile 32 bit Java'yi ve tersini karıştırmak, jpype modülünün içe aktarımı sırasında çökme meydana getirir.

## **Genel API Farklılıkları**
Aşağıdaki liste (örnek kod bölümleriyle) Java için Aspose.Slides ile Java API'ları üzerinden Python için Aspose.Slides arasındaki bazı farklılıkları gösterir.

### **Kütüphane İçe Aktarma (Paket Karşılaştırmaları)**

**Aspose.Slides for Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

jpype.shutdownJVM()

```

### **Yeni Bir Sunum Oluşturma**

**Aspose.Slides for Java**

```java
Presentation pres = new Presentation();
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation

pres = Presentation();

jpype.shutdownJVM()
```

### **Dosyaları ve Sabitleri Akış Halinde İşleme**

**Aspose.Slides for Java**

```java
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input = open("presentation.pptx", mode="rb")
data = input.read()
pres = Presentation.createPresentationFromBytes(data)
pres.save("result.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

### **Java API'sine kıyasla Java API üzerinden Python için Aspose.Slides'in Diğer Kısıtlamaları**

Diğer kısıtlamalar hakkında daha fazla bilgi için lütfen jpype belgelerine bakın:
- https://jpype.readthedocs.io/en/latest/