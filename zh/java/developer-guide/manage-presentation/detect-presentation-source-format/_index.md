---
title: 在 Java 中确定原始演示文稿格式
linktitle: 源格式
type: docs
weight: 35
url: /zh/java/detect-presentation-source-format/
keywords:
- 源格式
- 检测演示文稿格式
- PowerPoint
- OpenDocument
- 演示文稿
- PPT
- PPTX
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 Java 中读取已加载演示文稿的原始格式，比较检测 API，并处理文件、流和传统格式。"
---
## **概述**

加载演示文稿后，调用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSourceFormat--) 方法以确定其原始格式。该方法也可通过 [IPresentation.getSourceFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentation/#getSourceFormat--) 获取。当后续处理取决于当前实例加载时的格式时使用它。

源格式不同于为输出文件选择的 [SaveFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveformat/)。将文件另存为其他格式不会更改现有实例的源格式。

## **读取文件的源格式**

此示例需要一个已有的 `sample.pptx` 文件。它加载该文件并使用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSourceFormat--) 而非文件名来选择应用程序处理策略。更改输入路径可尝试其他格式。示例会打印所选策略；请用自己的业务逻辑替换这些消息。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **识别受支持的值**

[SourceFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/sourceformat/) 类定义了区分以下演示文稿格式的整数常量。下表中的扩展名为常规扩展名，非原始文件名的重建。

| SourceFormat value | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 演示文稿 |
| `Pptx` | `.pptx` | Office Open XML 演示文稿 |
| `Pptm` | `.pptm` | 支持宏的 Office Open XML 演示文稿 |
| `Pps` | `.pps` | PowerPoint 97–2003 幻灯片放映 |
| `Ppsx` | `.ppsx` | Office Open XML 幻灯片放映 |
| `Ppsm` | `.ppsm` | 支持宏的 Office Open XML 幻灯片放映 |
| `Pot` | `.pot` | PowerPoint 97–2003 模板 |
| `Potx` | `.potx` | Office Open XML 模板 |
| `Potm` | `.potm` | 支持宏的 Office Open XML 模板 |
| `Odp` | `.odp` | OpenDocument 演示文稿 |
| `Otp` | `.otp` | OpenDocument 演示文稿模板 |
| `Fodp` | `.fodp` | Flat XML ODF 演示文稿 |
| `Xml` | `.xml` | PowerPoint XML 演示文稿 |

## **读取流的源格式**

此示例需要一个已有的 `sample.pps` 文件。将其字节读取到内存流中，以模拟没有文件名的输入，如数据库值或上传的字节数组。[Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 构造函数仅接受流。

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT、PPS 和 POT 使用相同的底层二进制格式。通过文件路径加载时，扩展名可帮助区分幻灯片放映或模板。没有文件名时，传统的 PPS 和 POT 内容可能被报告为 `SourceFormat.Ppt`；上面的 PPS 示例会打印 `SourceFormat.Ppt` 的整数值。

如果您的应用程序必须保留此区分，请单独保存原始文件名或子类型元数据。扩展名对于这些传统子类型是有用的提示，但不应成为识别任意演示文稿内容的唯一依据。

## **比较加载前后的检测**

使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) 和 [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) 在需要在加载完整演示文稿对象模型之前检查文件时。当实例已存在时使用 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSourceFormat--)。

此示例需要 `sample.pptx` 并分别打印 `LoadFormat.Pptx` 和 `SourceFormat.Pptx` 的整数值。在生产环境中，根据处理阶段选择合适的 API；已经加载的演示文稿无需再次检查仅为获取其源格式。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

结果使用来自不同类的常量：[LoadFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadformat/) 和 [SourceFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/sourceformat/)。不要比较它们的数值，也不要假设每种格式的检测结果完全相同。PowerPoint XML 在加载前可能报告为 `LoadFormat.Unknown`，加载后报告为 `SourceFormat.Xml`。

## **保持源格式和输出格式分离**

此示例需要 `sample.pptx` 并写入 `converted.odp`。它在保存原始实例前后都打印 `SourceFormat.Pptx` 的整数值。仅从 ODP 输出加载的新的实例会报告 `Odp`。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

使用 `new Presentation()` 从头创建的演示文稿报告 `SourceFormat.Pptx`。它没有输入文件：这是新创建实例的默认值，不代表已加载 PPTX 文件。如果区分是自行创建还是加载实例对您重要，请单独跟踪。

## **将源格式映射到扩展名**

以下示例需要 `sample.pptx`。它将每个当前受支持的 [SourceFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/sourceformat/) 值映射到常规扩展名，而不解析输入文件名。回退逻辑避免对未识别的值静默分配扩展名。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

此映射不执行文件转换，也不恢复在流加载期间丢失的传统 PPS/POT 子类型。实际保存时，请显式选择 [SaveFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveformat/)，或使用 [在原始格式中保存演示文稿](/slides/zh/java/save-presentation/#save-presentations-in-their-original-format) 中展示的转换。

## **通过保存和重新打开验证格式**

此独立示例创建一个演示文稿并在工作目录写入三个文件，若同名文件已存在则会覆盖。它分别通过路径和内存流重新打开每个输出。对于 PPTX 和 ODP，两种方式都报告保存的格式。对于 PPS，通过路径加载报告 `Pps`，而在没有文件名的情况下加载相同字节则报告 `Ppt`。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

以下表格总结了具有匹配扩展名的演示文稿的源格式识别。名称表示常量；Java 示例打印它们的整数值：

| 保存的格式 | 文件路径的 SourceFormat | 无文件名流的 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` 分别 | 与文件路径相同 |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` 分别 | 与文件路径相同 |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` 分别 | 与文件路径相同 |
| ODP, OTP | `Odp`, `Otp` 分别 | 与文件路径相同 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT 内容在无文件名的流中被识别为 `Ppt`。该表描述的是格式识别，而非在转换过程中对每个演示文稿特性的保留。

## **FAQ**

**保存为 ODP 是否会更改从 PPTX 加载的演示文稿的源格式？**

否。现有实例仍报告 `Pptx`。从已保存的 ODP 文件加载的实例报告 `Odp`。

**流能否始终区分传统的演示文稿、幻灯片放映和模板？**

否。PPT、PPS 和 POT 共享二进制格式。当需要此区分时，请单独保留文件名或子类型元数据。

**如果演示文稿已经加载，我应该使用哪个 API？**

阅读 [Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSourceFormat--)。在加载前检查请使用 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)。