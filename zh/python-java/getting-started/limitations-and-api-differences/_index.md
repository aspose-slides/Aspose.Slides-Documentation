---
title: 限制和 API 差异
type: docs
weight: 100
url: /python-java/limitations-and-api-differences/
keywords: "节点, powerpoint, 限制, api, 差异"
description: "Aspose.Slides for Python via Java 的限制和 API 差异。"
---
## **已知错误/限制**
包外的 Java 类（在 `default` 中）无法被导入。
由于缺乏 JVM 支持，您无法关闭 JVM 然后重新启动它。您也不能同时启动多个 JVM 实例。
将 64 位 Python 与 32 位 Java 结合使用，反之亦然，在导入 jpype 模块时会崩溃。

## **公共 API 差异**
以下列表（带示例代码片段）显示了 Aspose.Slides for Java 和 Aspose.Slides for Python via Java API 之间的一些差异。

### **导入库（包比较）**

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

### **实例化一个新的演示文稿**

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

### **流文件和常量**

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

### **与 Aspose.Slides for Java API 相比，Aspose.Slides for Python via Java API 的其他限制**

有关其他限制的更多信息，请参考 jpype 文档：
- https://jpype.readthedocs.io/en/latest/