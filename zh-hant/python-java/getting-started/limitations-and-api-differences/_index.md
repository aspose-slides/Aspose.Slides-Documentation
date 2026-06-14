---
title: 限制與 API 差異
type: docs
weight: 100
url: /zh-hant/python-java/limitations-and-api-differences/
keywords: "節點, PowerPoint, 限制, API, 差異"
description: "Aspose.Slides for Python via Java 的限制與 API 差異。"
---
## **已知錯誤/限制**
位於套件之外（即 `default`）的 Java 類別無法匯入。  
由於缺乏 JVM 支援，您無法關閉 JVM 後再重新啟動，也無法同時啟動超過一個 JVM 實例。  
在匯入 jpype 模組時，混合 64 位元 Python 與 32 位元 Java（或相反）會導致崩潰。

## **公開 API 差異**
以下列表（含範例程式碼段落）展示了 Aspose.Slides for Java 與 Aspose.Slides for Python via Java API 之間的一些差異。

### **匯入函式庫（套件比較）**

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

### **實例化新簡報**

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

### **串流檔案與常數**

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

### **相較於 Aspose.Slides for Java API，Aspose.Slides for Python via Java API 的其他限制**

欲取得其他限制的更多資訊，請參考 jpype 文件：  
- https://jpype.readthedocs.io/en/latest/