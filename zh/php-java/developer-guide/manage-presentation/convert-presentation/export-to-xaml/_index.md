---
title: 在 PHP 中将演示文稿导出为 XAML
linktitle: 演示文稿转 XAML
type: docs
weight: 30
url: /zh/php-java/export-to-xaml/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 通过 Java 将 PowerPoint 和 OpenDocument 幻灯片转换为 XAML —— 快速、无需 Office 的解决方案，保持布局完整。"
---
## **概述**

本文说明如何使用 Aspose.Slides 将 PowerPoint 演示文稿导出为 XAML。文中简要介绍了 XAML，展示了使用默认设置将演示文稿保存为 XAML 的方法，并演示了如何通过 [XamlOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/xamloptions/) 自定义导出，包括导出隐藏幻灯片。文章还回答了一些常见问题，涉及回退字体、XAML 栈兼容性以及隐藏幻灯片导出行为。

## **关于 XAML**

XAML 是一种基于 XML 的标记语言，用于在 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin.Forms 等框架中描述用户界面。

您可以在可视化设计器中使用 XAML 文件，也可以直接编写并编辑标记。

## **使用默认选项将演示文稿导出为 XAML**

下面的 PHP 示例演示了如何使用默认设置将演示文稿导出为 XAML。运行本文中的示例之前，请先初始化 PHP Java Bridge 并加载 `aspose.slides.php`。将 `pres.pptx` 放在 Java Bridge 服务器的工作目录中，或提供该服务器可访问的绝对路径。

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

默认情况下，导出的幻灯片会保存在 Java Bridge 服务器当前工作目录的 `pres` 子文件夹中。该文件夹会自动创建，任何所需的图像也会保存在其中。

输出文件夹名称取自源文件名（不含扩展名）。例如 `pres.pptx`，输出文件为 `pres/Slide_1.xaml`、`pres/Slide_2.xaml` 等。即使您传入的是演示文稿的绝对路径，输出文件夹也会相对于 Java Bridge 服务器的当前工作目录创建，而不是与输入文件并列。

## **使用自定义选项将演示文稿导出为 XAML**

使用 [IXamlOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ixamloptions/) 接口来控制 Aspose.Slides 将演示文稿导出为 XAML 的方式。

若要将输出保存到自定义位置，请实现一个 Java 代理实现 [IXamlOutputSaver](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ixamloutputsaver/)，并将该实现的实例传递给 [XamlOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/xamloptions/) 的 [setOutputSaver](https://reference.aspose.com/slides/zh/php-java/aspose.slides/xamloptions/#setOutputSaver) 方法。

若要在 XAML 输出中包含隐藏幻灯片，请在以下 PHP 示例中调用 [setExportHiddenSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) 并传入 `true`：

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **捕获所有生成的 XAML 产物**

XAML 导出可能为每个导出的幻灯片生成一个 XAML 文档，并生成单独的图像和支持资源。为 [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/zh/php-java/aspose.slides/xamloptions/#setOutputSaver) 分配自定义的 [IXamlOutputSaver](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ixamloutputsaver/)，以接收这些产物，而不是使用默认的文件系统保存器。使用接受 XAML 选项的 XAML 专用 [Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save) 重载启动导出。

PHP Java Bridge 的 `java_closure` 函数将 PHP 对象公开为 Java 接口。请在导出完成前保持 PHP saver 及其代理存活。接口链接指向由代理实现的 Java API。

### **了解回调生命周期**

导出器会针对每个生成的产物单独调用 [IXamlOutputSaver::save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-)：

- `path` 标识产物，可能包含相对目录。请保留此信息，因为 XAML 可能使用相对路径引用资源。
- `data` 包含产物的字节。图像和其他二进制资源不能被解码为文本。
- saver 负责在返回前保留或持久化这些数据。示例将每个 Java 字节数组转换为由应用程序拥有的 PHP 二进制字符串。
- 仅当演示文稿保存操作返回且所有回调均成功完成时，才视为导出成功。不要吞掉存储错误或启动未监控的后台写入。如果持久化在之后才发生，请在该步骤成功后才报告整体成功。

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) 同样适用于自定义 saver。默认设置 `false` 会排除隐藏幻灯片的 XAML 文档。传入 `true` 将包括它们以及导出所需的所有资源。资源数量取决于演示文稿，不能假设每张幻灯片对应一个回调或回调顺序固定。

### **导出到内存并检查产物**

下面的完整示例加载 `pres.pptx`，将每个产物收集到 PHP 关联数组的二进制字符串中，并打印其名称、类型和字节数。示例严格保留提供的名称。若出现重复名称，集合视为无效而非悄悄覆盖产物。示例在使用结果之前会进行此检查。

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // 仅将 XAML 视为 UTF-8 文本进行可选检查。
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

扩展名检查对检查非常有帮助；请保留所有产物，包括不熟悉的资源类型。存储或传输时不要更改字节。PHP 字符串可以容纳二进制数据，包括零字节。仅在检查 XAML 时将字符串视为 UTF-8 文本；不要对图像或资源字节进行转码。

### **将收集的产物打包为 ZIP 存档**

下面的独立示例收集导出产物，验证名称，并将原始字节写入 ZIP 存档。专用的作业目录用于分离并发导出作业。该示例需要启用了 ZIP 支持的 PHP Phar 扩展。ZIP 条目使用正斜杠并保留相对目录。出现不安全的名称或标准化后冲突的名称时，会在写入之前拒绝整个包。

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

示例使用 [PharData](https://www.php.net/manual/en/class.phardata.php) 在 PHP 进程的工作目录中写入本地 ZIP 存档；导出器本身不写入松散的 XAML 或图像文件。若需远程存储，请将写入阶段替换为上传收集的二进制字符串。使用导出作业标识符加完整相对产物名称作为 blob 键，或在数据库行中存储作业标识符、相对名称和二进制数据。仅在所有上传完成或数据库事务提交后发布作业。若持久化失败，请清理部分输出。

对于大文件的演示文稿，可使用自定义 saver 将每个产物直接持久化到应用存储，以避免在应用内存中保留整个导出的副本。保持每个回调对导出器而言是同步的：仅在目的地接受字节后返回，并让失败传播给调用方。

### **保留资源名称并验证引用**

- 当目标要求时归一化路径分隔符，但保留相对目录。除非确认每个生成的名称都是唯一且资源引用仍然有效，否则不要仅使用 [basename](https://www.php.net/manual/en/function.basename.php)。
- 应用目标特定的名称验证。写入松散文件时，拒绝根路径和路径遍历段，解析目标为绝对路径，并确认其仍位于预期的导出目录下（包含目录分隔符的包含检查）。使用不含符号链接的受控目录，以防写入被重定向。
- 为每个导出作业使用独立的 saver 和存储命名空间。根据目标的大小写敏感规则，在分隔符归一化后检测冲突。
- 在发布之前，将每个 XAML 文档解析为 XML，检查其基于文件的资源引用，如图像的 `Source` 或 `ImageSource` 属性。将每个相对 URI 相对于包含该 XAML 产物的目录进行解析，归一化得到的存储名称，并确认对应的映射键、ZIP 条目或存储对象存在。将外部 URI 与相对文件名分开处理。

例如，若 `pres/Slide_1.xaml` 引用了 `images/image1.png`，则必须以 `pres/images/image1.png` 形式存储该资源。仅保留 `image1.png` 会导致关系断裂。若使用对象存储，请在作业前缀下保持相同的层次结构，并使这些资源 URL 对 XAML 消费者可访问。重新打开完成的 ZIP 以验证条目名称和资源字节，并在目标 XAML 环境中加载代表性幻灯片，以确认图像能够正确解析。

## **常见问题解答**

**如果原始字体在机器上不可用，如何确保字体可预测？**

在 [XamlOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/xamloptions/) 中调用 [setDefaultRegularFont](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) —— 当原始字体缺失时，它会作为回退字体使用。但这并不保证生成的 XAML 会引用回退字体，也不保证目标机器上存在该字体。请确保 XAML 中引用的字体在显示环境中可用。

**导出的 XAML 只针对 WPF 吗，还是可以在其他 XAML 栈中使用？**

Aspose.Slides 通过其公开 API 导出 WPF XAML。对其他 XAML 栈（如 UWP 和 Xamarin.Forms）的兼容性不作保证。请在目标环境中测试生成的标记。

**是否支持隐藏幻灯片，如何防止默认导出它们？**

默认情况下，隐藏幻灯片不会被包含。您可以通过在 [XamlOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/xamloptions/) 中使用 [setExportHiddenSlides](https://reference.aspose.com/slides/zh/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) 来控制此行为——如果不需要导出隐藏幻灯片，请保持该设置为禁用状态。