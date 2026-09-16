---
title: 在 .NET 中将演示文稿导出为 XAML
linktitle: 演示文稿转 XAML
type: docs
weight: 30
url: /zh/net/export-to-xaml/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出演示文稿
- 转换 PowerPoint
- 转换 OpenDocument
- 转换演示文稿
- PowerPoint 转 XAML
- OpenDocument 转 XAML
- 演示文稿转 XAML
- PPT 转 XAML
- PPTX 转 XAML
- ODP 转 XAML
- 将 PPT 保存为 XAML
- 将 PPTX 保存为 XAML
- 将 ODP 保存为 XAML
- 导出 PPT 为 XAML
- 导出 PPTX 为 XAML
- 导出 ODP 为 XAML
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 将 PowerPoint 和 OpenDocument 幻灯片转换为 XAML——快速、无需 Office 的解决方案，保持布局完整。"
---
## **概述**

本文介绍如何使用 Aspose.Slides 将 PowerPoint 演示文稿导出为 XAML。内容包括对 XAML 的简要介绍，演示使用默认设置将演示文稿保存为 XAML 的方法，以及通过 [XamlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export.xaml/xamloptions/) 自定义导出，包括导出隐藏幻灯片。本文还回答了有关回退字体、XAML 堆栈兼容性以及隐藏幻灯片导出行为的常见问题。

## **关于 XAML**

XAML 是一种基于 XML 的标记语言，用于在 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin.Forms 等框架中描述用户界面。

您可以在可视化设计器中使用 XAML 文件，也可以直接编写和编辑标记。

## **使用默认选项将演示文稿导出为 XAML**

以下 C# 示例演示如何使用默认设置将演示文稿导出为 XAML：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

默认情况下，导出的幻灯片会保存在进程当前工作目录的 `pres` 子文件夹中，该目录由 [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory) 返回。该文件夹会自动创建，所需的图像也会保存在其中。

输出文件夹名称来源于源文件名（不含扩展名）。例如，对于 `pres.pptx`，输出文件为 `pres/Slide_1.xaml`、`pres/Slide_2.xaml` 等。即使您传入演示文稿的绝对路径，输出文件夹也会相对于当前工作目录创建，而不是与输入文件并列。

## **使用自定义选项将演示文稿导出为 XAML**

使用 [IXamlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export.xaml/ixamloptions/) 接口可以控制 Aspose.Slides 将演示文稿导出为 XAML 的方式。

要将输出保存到自定义位置，实现 [IXamlOutputSaver](https://reference.aspose.com/slides/zh/net/aspose.slides.export.xaml/ixamloutputsaver/) 并将实现实例分配给 [XamlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export.xaml/xamloptions/) 的 [OutputSaver](https://reference.aspose.com/slides/zh/net/aspose.slides.export.xaml/xamloptions/outputsaver/) 属性。

要在 XAML 输出中包含隐藏幻灯片，请将 [ExportHiddenSlides](https://reference.aspose.com/slides/zh/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) 属性设为 `true`，如下 C# 示例所示：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **捕获所有生成的 XAML 工件**

XAML 导出可能为每张导出幻灯片生成一个 XAML 文档，并产生单独的图像和支持资源。将自定义的 [IXamlOutputSaver](https://reference.aspose.com/slides/zh/net/aspose.slides.export.xaml/ixamloutputsaver/) 分配给 [XamlOptions.OutputSaver](https://reference.aspose.com/slides/zh/net/aspose.slides.export.xaml/xamloptions/outputsaver/)，以接收这些工件，而不是使用默认的文件系统保存器。使用接受 XAML 选项的 XAML‑specific [Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/) 重载启动导出。

### **了解回调生命周期**

导出器会针对每个生成的工件单独调用 [IXamlOutputSaver.Save](https://reference.aspose.com/slides/zh/net/aspose.slides.export.xaml/ixamloutputsaver/save/)：

- `path` 标识工件，可包含相对目录。请保留此信息，因为 XAML 可能使用相对路径引用资源。
- `data` 包含工件的字节。图像和其他二进制资源不能作为文本解码。
- 保存器负责在返回前保留或持久化这些数据。示例将每个字节数组复制到应用程序拥有的内存中。
- 仅在演示文稿保存操作返回且每个回调成功完成后，才视导出为成功。不要吞掉存储错误或启动未观察的后台写入。如果持久化在之后进行，仅在该步骤也成功后才报告整体成功。

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/zh/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) 同样适用于自定义保存器。其默认值 `false` 会排除隐藏幻灯片的 XAML 文档。将其设为 `true` 可包括这些文档及其导出所需的所有资源。资源数量取决于演示文稿；不要假设每张幻灯片对应一个回调或回调顺序固定。

### **导出到内存并检查工件**

下面的完整示例加载 `pres.pptx`，将每个工件收集到 [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) 中，并打印其名称、类型和字节数。示例严格保留提供的名称。名称重复会导致集合失败，而不是悄悄覆盖工件。

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // 仅在需要文本检查时对 XAML 进行解码。
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

在您的应用程序中调用 `InMemoryXamlExample.Run`。检查时可使用扩展名；保留所有工件，包括不熟悉的资源类型。存储或传输时保持字节不变。仅对需要文本处理的 XAML 使用 [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring)。

### **将收集的工件打包成 ZIP 存档**

此独立示例收集导出结果，验证名称，并将原始字节写入 ZIP 存档。唯一的存档名称用于区分并发的导出任务。ZIP 条目使用正斜杠并保留相对目录。出现不安全名称或规范化后冲突时，会在写入前拒绝整个包。

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // ZIP 目录已在报告成功之前通过释放完成。
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

在您的应用程序中调用 `ZipXamlExample.Run`。示例使用 [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) 写入本地存档；导出器本身不写入松散的 XAML 或图像文件。对于远程存储，可将写入阶段替换为对收集的字节数组进行上传。使用导出作业标识加上完整相对工件名称作为 Blob 键，或将作业标识、相对名称和二进制数据存入数据库行。仅在所有上传完成或数据库事务提交后才发布作业。若持久化失败，请清理部分输出。

对于大型演示文稿，自定义保存器可以直接将每个工件持久化到应用存储，以避免在应用内存中保留整个导出的额外副本。导出器仍会在调用保存器之前将所有生成的工件收集到内存中。保持每个回调对导出器而言是同步的：仅在目标接受字节后返回，并让失败传递给调用者。

### **保留资源名称并验证引用**

- 当目标要求时规范化路径分隔符，但保留相对目录。除非每个生成的名称已知唯一且资源引用仍然有效，否则不要仅使用 [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename)。
- 应用目标特定的名称验证。写入松散文件时，拒绝根路径和遍历段，使用 [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) 解析目标，并确认其仍位于预期的导出目录之下（在包含检查中包括目录分隔符）。使用不含可能重定向写入的符号链接的受控目录。
- 为每个导出作业使用独立的保存器和存储命名空间。根据目标的大小写敏感规则，在分隔符规范化后检测冲突。
- 发布前，将每个 XAML 文档解析为 XML，检查其基于文件的资源引用，如图像的 `Source` 或 `ImageSource` 属性。将每个相对 URI 相对于包含该 XAML 工件的目录进行解析，规范化得到的存储名称，并确认对应的字典键、ZIP 条目或存储对象存在。将外部 URI 和 XAML 标记表达式与相对文件名分开处理。

例如，若 `pres/Slide_1.xaml` 引用 `images/image1.png`，则存储的资源必须以 `pres/images/image1.png` 形式可用。仅保留 `image1.png` 会破坏这种关系。对于对象存储，请在作业前缀下保持相同的布局，并使这些资源 URL 对 XAML 消费者可访问。重新打开完成的 ZIP，验证条目名称和资源字节，并在目标 XAML 环境中加载代表性幻灯片，以确认图像能够正确解析。

## **常见问题**

**如何在原始字体在机器上不可用时确保字体可预测？**

在 [XamlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export.xaml/xamloptions/) 中设置 [DefaultRegularFont](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveoptions/defaultregularfont/)，在导出时原始字体缺失时使用该回退字体。这并不保证生成的 XAML 会引用回退字体，也不保证目标机器上拥有该字体。请确保 XAML 引用的字体在显示环境中可用。

**导出的 XAML 仅用于 WPF 吗，还是也能在其他 XAML 堆栈中使用？**

Aspose.Slides 通过其公共 API 导出 WPF XAML。对其他 XAML 堆栈（如 UWP 和 Xamarin.Forms）的兼容性不保证。请在目标环境中测试生成的标记。

**是否支持隐藏幻灯片，如何避免默认导出它们？**

默认情况下不包括隐藏幻灯片。您可以通过在 [XamlOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export.xaml/xamloptions/) 中的 [ExportHiddenSlides](https://reference.aspose.com/slides/zh/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) 来控制此行为——如果不需要导出隐藏幻灯片，请保持其禁用状态。