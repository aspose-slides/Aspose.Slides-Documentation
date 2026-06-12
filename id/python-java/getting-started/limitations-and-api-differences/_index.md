---
title: Batasan dan Perbedaan API
type: docs
weight: 100
url: /id/python-java/limitations-and-api-differences/
keywords: "node, powerpoint, batasan, api, perbedaan"
description: "Batasan dan perbedaan API Aspose.Slides untuk Python via Java."
---
## **Bug/Limitasi yang Diketahui**
Kelas Java di luar paket (di `default`) tidak dapat diimpor.  
Karena tidak adanya dukungan JVM, Anda tidak dapat mematikan JVM dan kemudian memulainya kembali. Anda juga tidak dapat menjalankan lebih dari satu salinan JVM.  
Mencampur Python 64‑bit dengan Java 32‑bit dan sebaliknya menyebabkan crash saat mengimpor modul jpype.

## **Perbedaan API Publik**
Daftar berikut (dengan segmen kode contoh) menunjukkan beberapa perbedaan antara Aspose.Slides untuk Java dan Aspose.Slides untuk Python melalui API Java.

### **Mengimpor perpustakaan (Perbandingan Paket)**

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

### **Membuat Presentasi baru**

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

### **Streaming File dan Konstanta**

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

### **Batasan Lain dari Aspose.Slides untuk Python melalui API Java dibandingkan dengan Aspose.Slides untuk API Java**

Untuk informasi lebih lanjut tentang batasan lainnya, silakan merujuk ke dokumentasi jpype: 
- https://jpype.readthedocs.io/en/latest/