---
title: 授权
type: docs
weight: 80
url: /zh/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- 许可证文件
- 临时许可证
- 计量授权
- 评估限制
description: "在 Aspose.Slides for Python via Java 中应用文件许可证、基于字节的许可证或计量许可证，并消除应用程序中的评估限制。"
---
## **概述**

Aspose.Slides for Python via Java 可以在评估模式或许可模式下运行。在评估模式下，它会在每个保存的演示文稿的每张幻灯片上添加评估水印文字框，并截断代码从演示文稿读取的文本。本文说明如何从文件或字节应用许可证以及如何配置计量授权。

有关购买选项，请参阅[定价信息](https://purchase.aspose.com/pricing/slides/zh/family)。有关一般授权和购买问题，请参阅[购买政策和常见问题解答](https://purchase.aspose.com/policies)。

有关评估限制以及如何请求临时许可证，请参阅[评估 Aspose.Slides](/slides/zh/python-java/evaluate-aspose-slides/)。临时许可证的应用方式与购买的许可证文件相同。

## **关于许可证**

许可证文件包含产品名称、授权开发人员数量、订阅到期日期等信息。该文件是经过数字签名的 XML。

{{% alert color="warning" title="Warning" %}}
请勿编辑许可证文件。即使多一个换行也可能使其数字签名失效。
{{% /alert %}}

在每个应用程序或进程中仅需一次应用许可证，且必须在创建演示文稿或执行其他 Aspose.Slides 操作之前进行。对于许可证文件，请使用[License](https://reference.aspose.com/slides/zh/python-java/aspose.slides/license/)类。计量授权使用公私钥对，而不是许可证文件。

## **应用许可证**

以下示例假设已安装 Aspose.Slides for Python via Java 及其前置条件。每个示例都是一个独立脚本，负责启动 JVM、导入 API 并应用许可证。在您的应用程序中，请在应用许可证后再执行演示文稿操作，并在所有 Aspose.Slides 工作完成后才关闭 JVM。

### **从文件应用许可证**

将许可证文件路径传递给[License.setLicense](https://reference.aspose.com/slides/zh/python-java/aspose.slides/license/#setLicense)。将 `Aspose.Slides.lic` 替换为您的许可证文件的路径。

```python
from pathlib import Path

import jpype
import asposeslides

jpime.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # 在关闭 JVM 之前执行演示文稿操作。
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpime.shutdownJVM()
```

使用完整的文件名，包括扩展名。例如，如果文件名为 `Aspose.Slides.lic.xml`，请在路径中包含 `.xml`。使用绝对路径可避免应用程序工作目录的歧义。

示例使用[License.isLicensed](https://reference.aspose.com/slides/zh/python-java/aspose.slides/license/#isLicensed)来检查许可证是否已应用。

### **从字节应用许可证**

当许可证以 Python 字节形式提供时，请使用[License.setLicenseFromBytes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/license/#setLicenseFromBytes)。以下示例以二进制模式读取文件，并在应用许可证前关闭它。

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # 在关闭 JVM 之前执行演示文稿操作。
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

保持原始字节不变。不要在应用之前对许可证内容进行解码、重新格式化或其他任何修改。

## **应用计量许可证**

计量授权会根据 API 使用量计费。获取计量许可证后，使用[Metered.setMeteredKey](https://reference.aspose.com/slides/zh/python-java/aspose.slides/metered/#setMeteredKey)来应用其公钥和私钥。初始化[Metered](https://reference.aspose.com/slides/zh/python-java/aspose.slides/metered/)对象，并在应用启动时一次性应用这些密钥。

以下示例从环境变量 `ASPOSE_METERED_PUBLIC_KEY` 和 `ASPOSE_METERED_PRIVATE_KEY` 中读取密钥。请在运行脚本前设置这两个变量。

```python
import os

import jpime
import asposeslides

jpime.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # 在关闭 JVM 之前执行演示文稿操作。
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpime.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
计量授权需要网络连接以验证密钥并报告使用情况。请将私钥保持在源代码和日志之外。有关连接性和计费细节，请参阅[计量授权常见问题解答](https://purchase.aspose.com/faqs/licensing/metered)。
{{% /alert %}}

## **常见问题**

**购买许可证后我需要安装不同的包吗？**  
不需要。将许可证应用于您用于评估的相同包。

**我需要为每个演示文稿都应用许可证吗？**  
不需要。在应用程序启动时一次性应用许可证，且在创建或加载演示文稿之前。

**我可以重命名许可证文件吗？**  
可以。请在代码中使用新的完整文件名，并保持文件内容不变。

**我可以在基于字节的示例中使用临时许可证吗？**  
可以。将临时许可证文件读取为字节，并以与购买许可证相同的方式应用。