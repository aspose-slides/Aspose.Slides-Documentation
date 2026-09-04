---
title: 限制和 API 差异
type: docs
weight: 100
url: /zh/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides for Python via Java
- API 差异
- Python
- Java
- JPype
- JVM 限制
- PowerPoint
description: "了解 Aspose.Slides for Java 与通过 Java 的 Python 之间的 JVM 限制和 API 差异，包括导入、资源清理和文件处理。"
---
## **概述**

Aspose.Slides for Python via Java 使用 JPype 从 Python 访问 Java 库。下面的示例比较了两个 API 中的包导入、演示文稿创建和文件处理。

## **已知限制**

- **JVM 生命周期：** JPype 在每个 Python 进程中仅支持一个 JVM。关闭后，不能在同一进程中重新启动。请启动一次并在后续的演示文稿操作中重复使用。
- **架构兼容性：** Python 和 Java 必须具有匹配的架构。有关详细信息，请参阅[System Requirements](/slides/zh/python-java/system-requirements/#python-java-and-jpype-requirements)。

请参阅[JPype User Guide](https://jpype.readthedocs.io/en/latest/userguide.html)了解这些限制和 Java 互操作性的详细信息。

## **公共 API 差异**

比较下面的 Java 和 Python 示例。有关 Python via Java 成员详情，请参阅[API Reference](/slides/zh/python-java/api-reference/)。

### **导入库**

Java 从 `com.aspose.slides` 导入类。 在 Python 中，先在启动 JVM 之前导入 `asposeslides`，然后在 JVM 运行后从 `asposeslides.api` 导入类。 使用[jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted) 可避免启动已经运行的 JVM。

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
The Python examples leave the JVM running until the Python process exits. In a notebook, reuse the active JVM across cells. If it has already been shut down, restart the notebook kernel before using Java objects again.
{{% /alert %}}

### **创建演示文稿**

Java 使用 `new` 关键字；Python 直接调用[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类。 在 `finally` 块中使用[Presentation.dispose](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#dispose) 释放演示文稿资源。

两个示例都使用[Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save)和[SaveFormat.Pptx](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#pptx) 保存空白演示文稿。

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

### **读取文件并使用格式常量**

Java 可以从 Java 输入流加载演示文稿。 在 Python 中，将文件读取为二进制数据，并将得到的字节传递给[Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#createpresentationfrombytes)。 Python 的文件对象不是 Java 输入流。

下面的示例需要工作目录中存在 `presentation.pptx`，并将副本保存为 `result.pptx`。 两者都关闭输入文件并释放演示文稿资源。 Python 示例将整个输入文件读取到内存中。

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

## **常见问题**

**我是否需要为每个演示文稿重新启动 JVM？**

不需要。保持 JVM 运行，根据需要创建和释放演示文稿对象。关闭 JVM 将阻止在同一 Python 进程中进行进一步的 Java 操作。

**我可以直接从文件路径打开演示文稿吗？**

可以。[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 构造函数接受文件路径。当演示文稿数据已经以 Python 字节形式可用时，请使用基于字节的帮助方法。

**在将 Java 示例转换为 Python 时，我需要更改格式常量名称吗？**

不需要。例如，[SaveFormat.Pptx](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#pptx) 在两个 API 中的拼写和大小写完全相同。