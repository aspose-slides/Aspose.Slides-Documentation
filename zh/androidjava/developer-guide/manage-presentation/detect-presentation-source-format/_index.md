---
title: 在 Android 上确定原始演示文稿格式
linktitle: 源格式
type: docs
weight: 35
url: /zh/androidjava/detect-presentation-source-format/
keywords:
- 源格式
- 检测演示文稿格式
- PowerPoint
- OpenDocument
- 演示文稿
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android（通过 Java）读取在 Android 上加载的演示文稿的原始格式，比较检测 API，并处理文件、流和旧版格式。"
---
## **概述**

加载演示文稿后，调用[Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getSourceFormat--)方法以确定其原始格式。该方法也可通过[IPresentation.getSourceFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--)获得。当后续处理依赖于当前实例加载时的格式时，请使用它。

源格式不同于为输出文件选择的[SaveFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/saveformat/)。将文件保存为其他格式不会更改现有实例的源格式。

示例使用 Java 和文件路径。在 Android 上，请将示例路径替换为应用可访问存储中的路径，例如应用的内部文件目录。

## **读取文件的源格式**

此示例需要一个已有的 `sample.pptx` 文件。它加载文件并使用[Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getSourceFormat--)选择应用处理策略，而不是依据文件名。将输入路径更改为其他格式进行尝试。示例打印所选策略；请将消息替换为您的应用逻辑。

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

[SourceFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/sourceformat/) 类定义了区分以下演示文稿格式的整数常量。下面的扩展名是常规扩展名，而不是原始文件名的重建。

| SourceFormat 值 | 扩展名 | 格式 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 演示文稿 |
| `Pptx` | `.pptx` | Office Open XML 演示文稿 |
| `Pptm` | `.pptm` | 启用宏的 Office Open XML 演示文稿 |
| `Pps` | `.pps` | PowerPoint 97–2003 幻灯片放映 |
| `Ppsx` | `.ppsx` | Office Open XML 幻灯片放映 |
| `Ppsm` | `.ppsm` | 启用宏的 Office Open XML 幻灯片放映 |
| `Pot` | `.pot` | PowerPoint 97–2003 模板 |
| `Potx` | `.potx` | Office Open XML 模板 |
| `Potm` | `.potm` | 启用宏的 Office Open XML 模板 |
| `Odp` | `.odp` | OpenDocument 演示文稿 |
| `Otp` | `.otp` | OpenDocument 演示文稿模板 |
| `Fodp` | `.fodp` | Flat XML ODF 演示文稿 |
| `Xml` | `.xml` | PowerPoint XML 演示文稿 |

## **读取流的源格式**

此示例需要一个已有的 `sample.pps` 文件。将其字节读取到内存流中，模拟未带文件名的输入，如数据库值或上传的字节数组。[Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 构造函数仅接受流。

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
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

PPT、PPS 和 POT 使用相同的底层二进制格式。通过文件路径加载时，扩展名可以帮助区分幻灯片放映或模板。没有文件名时，旧版 PPS 和 POT 内容可能被报告为 `SourceFormat.Ppt`；上面的 PPS 示例会打印 `SourceFormat.Ppt` 的整数值。

如果您的应用必须保留此区别，请单独保存原始文件名或子类型元数据。扩展名对这些旧子类型是有用的提示，但不应作为识别任意演示文稿内容的唯一依据。

## **比较加载前后的检测结果**

当需要在加载完整演示文稿对象模型之前检查文件时，请使用[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)和[IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--)。实例已经存在时，请使用[Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getSourceFormat--)。

此示例需要 `sample.pptx`，并分别打印 `LoadFormat.Pptx` 和 `SourceFormat.Pptx` 的整数值。在生产环境中，根据处理阶段选择适当的 API；已经加载的演示文稿无需再次检查即可获取其源格式。

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

结果使用来自不同类的常量：[LoadFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/loadformat/) 和 [SourceFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/sourceformat/)。不要比较它们的数值，也不要假设每种格式的检测结果完全相同。PowerPoint XML 在加载前可能报告为 `LoadFormat.Unknown`，加载后则报告为 `SourceFormat.Xml`。

## **保持源格式和输出格式分离**

此示例需要 `sample.pptx` 并写入 `converted.odp`。它在保存原始实例前后均打印 `SourceFormat.Pptx` 的整数值。只有从 ODP 输出加载的新的实例才会报告 `Odp`。

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

使用 `new Presentation()` 从头创建的演示文稿报告 `SourceFormat.Pptx`。它没有输入文件：这是一 个新创建实例的默认值，并不表明加载了 PPTX 文件。如果区分是创建还是加载很重要，请在应用中单独跟踪该信息。

## **将源格式映射到扩展名**

以下示例需要 `sample.pptx`。它将当前所有受支持的 [SourceFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/sourceformat/) 值映射到常规扩展名，而不解析输入文件名。回退机制避免对未识别的值默默分配扩展名。

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

此映射并不转换文件或恢复在流加载期间丢失的旧版 PPS/POT 子类型。实际保存时，请明确选择[SaveFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/saveformat/)，或使用[在原始格式中保存演示文稿](/slides/zh/androidjava/save-presentation/#save-presentations-in-their-original-format)中展示的转换方式。

## **通过保存和重新打开验证格式**

此自包含示例创建一个演示文稿并在工作目录写入三个文件，覆盖同名文件。它分别通过路径和内存流重新打开每个输出文件。对于 PPTX 和 ODP，两种方式均报告已保存的格式。对于 PPS，路径加载报告 `Pps`，而在没有文件名的情况下加载相同字节则报告 `Ppt`。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
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

下表概述了具有匹配扩展名的演示文稿的源格式识别。名称表示常量；Java 示例打印其整数值：

| 保存的格式 | 来自文件路径的 SourceFormat | 来自无名称流的 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX、PPTM | `Pptx`、`Pptm` 分别 | 与文件路径相同 |
| PPS | `Pps` | `Ppt` |
| PPSX、PPSM | `Ppsx`、`Ppsm` 分别 | 与文件路径相同 |
| POT | `Pot` | `Ppt` |
| POTX、POTM | `Potx`、`Potm` 分别 | 与文件路径相同 |
| ODP、OTP | `Odp`、`Otp` 分别 | 与文件路径相同 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT 内容在无名称流中被识别为 `Ppt`。该表描述了格式识别，而非在转换过程中保留每个演示文稿特性的完整性。

## **常见问题**

**保存为 ODP 会更改从 PPTX 加载的演示文稿的源格式吗？**

不会。现有实例仍报告 `Pptx`。从已保存的 ODP 文件加载的实例报告 `Odp`。

**流能否始终区分旧版演示文稿、幻灯片放映和模板？**

不能。PPT、PPS 和 POT 共享二进制格式。当需要此区分时，请单独保留文件名或子类型元数据。

**如果演示文稿已经加载，我应该使用哪个 API？**

读取[Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getSourceFormat--)。在加载前检查时，请使用[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)。