---
title: 在 Java 中打开演示文稿
linktitle: 打开演示文稿
type: docs
weight: 20
url: /zh/java/open-presentation/
keywords:
- 打开 PowerPoint
- 打开演示文稿
- 打开 PPTX
- 打开 PPT
- 打开 ODP
- 加载演示文稿
- 加载 PPTX
- 加载 PPT
- 加载 ODP
- 受保护的演示文稿
- 大型演示文稿
- 外部资源
- 二进制对象
- Java
- Aspose.Slides
description: "了解如何在 Java 中打开 PowerPoint 和 OpenDocument 演示文稿，提供打开密码，控制资源加载，并使用 Aspose.Slides for Java 减少内存使用。"
---
## **简介**

[Aspose.Slides for Java](https://products.aspose.com/slides/zh/java/) 可以从文件和流中加载 PowerPoint 和 OpenDocument 演示文稿。加载演示文稿后，您可以检查其结构、编辑幻灯片、管理资源，并以原始格式或其他受支持的格式保存。

加载行为可以通过 [LoadOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/) 类进行自定义。例如，您可以提供打开密码、将大型二进制对象保留在 Java 堆外、控制外部资源，或省略嵌入的二进制数据。

## **打开演示文稿**

要打开现有演示文稿，只需将其文件路径传递给 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 构造函数。使用完毕后请释放演示文稿，以便及时释放文件句柄、临时数据和其他资源。

以下 Java 示例演示了如何打开演示文稿并获取幻灯片数量：

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **打开受密码保护的演示文稿**

打开密码会对演示文稿内容进行加密。要加载完整的演示文稿，请将正确的密码传递给 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) 并将选项提供给 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 构造函数。如果密码缺失或不正确，加载将失败。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

有关密码检测、验证和加密工作流，请参阅 [Password-Protect Presentations](/slides/zh/java/password-protected-presentation/)。如果加密的演示文稿被有意保存了公共文档属性，则可以在不提供密码的情况下读取这些属性；参见 [Manage Presentation Properties](/slides/zh/java/presentation-properties/)。

## **打开大型演示文稿**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) 返回控制 Aspose.Slides 如何处理图像、音频和视频等二进制大型对象的选项。您可以保持源文件锁定、允许使用临时文件，并限制保留在内存中的 BLOB 数据量。

以下 Java 代码演示了加载大型演示文稿（例如 2 GB）：

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
使用 [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) 时，源文件会保持锁定状态，直到释放演示文稿实例。期间请勿移动、覆盖或删除源文件。

Aspose.Slides 在加载时可能会复制输入流的内容。对于大型演示文稿，文件路径通常比流更高效。有关其他存储和内存管理选项，请参阅 [Manage BLOBs](/slides/zh/java/manage-blob/)。
{{% /alert %}}

## **控制外部资源**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) 接受一个 [IResourceLoadingCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iresourceloadingcallback/) 实现。回调可以提供替代数据、重定向资源、使用默认加载器或跳过资源。当演示文稿包含必须根据特定安全或存储规则解析的外部图像时，这非常有用。

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **加载不含嵌入二进制对象的演示文稿**

演示文稿可能包含应用程序不需要或不想保留的嵌入二进制数据。例如：

- VBA 项目，可通过 [IPresentation.getVbaProject](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentation/#getVbaProject--) 获取；
- 嵌入的 OLE 数据，可通过 [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) 获取；
- ActiveX 控件数据，可通过 [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icontrol/#getActiveXControlBinary--) 获取。

将 [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) 设置为 `true`，即可在加载时删除这些二进制数据。将加载后的演示文稿保存以持久化已清理的结果。

此选项可降低不需要的嵌入负载风险，但它并不是完整的恶意软件检测或内容消毒系统。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**如何判断文件已经损坏而无法打开？**

Aspose.Slides 在加载期间会抛出解析或格式异常。请将此类失败与密码错误区分处理，以便应用程序能够准确报告原因。

**如果缺少必需的字体会怎样？**

演示文稿仍可加载，但渲染和导出时可能会替换字体。您可以 [配置字体替换](/slides/zh/java/font-substitution/) 或 [提供自定义字体](/slides/zh/java/custom-font/) 以使输出更可预测。

**加载演示文稿时是否会同时加载其嵌入的媒体？**

嵌入的音频和视频会通过演示文稿对象模型提供。外部资源会根据配置的资源加载行为进行解析；如果无法访问其位置，则可能不可用。