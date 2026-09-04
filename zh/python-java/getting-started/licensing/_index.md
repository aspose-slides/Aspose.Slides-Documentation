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
description: "在 Aspose.Slides for Python via Java 中应用文件、基于字节或计量许可证，并消除您应用程序中的评估限制。"
---
## **概述**

Aspose.Slides for Python via Java 可以在评估模式或已授权模式下运行。本文说明如何从文件或字节数组应用许可证以及如何配置计量授权。

有关购买选项，请参阅[定价信息](https://purchase.aspose.com/pricing/slides/zh/family)。有关通用授权与购买问题，请参阅[购买政策和常见问题](https://purchase.aspose.com/policies)。

有关评估限制以及如何请求临时许可证，请参阅[评估 Aspose.Slides](/slides/zh/python-java/evaluate-aspose-slides/)。临时许可证的应用方式与已购买许可证文件相同。

## **关于许可证**

许可证文件包含产品名称、授权开发人员数量以及订阅到期日期等信息。该文件是经过数字签名的 XML。

{{% alert color="warning" title="警告" %}}
请勿编辑许可证文件。即使是多余的换行也会使其数字签名失效。
{{% /alert %}}

在创建演示文稿或执行其他 Aspose.Slides 操作之前，请在每个应用程序或进程中仅应用一次许可证。对于许可证文件，请使用[License](https://reference.aspose.com/slides/zh/python-java/aspose.slides/license/)类。计量授权使用公钥和私钥对，而不是许可证文件。

## **应用许可证**

以下示例假设已安装 Aspose.Slides for Python via Java 及其前置条件。每个示例都是独立脚本，启动 JVM、导入 API 并应用许可证。在您的应用程序中，请在应用许可证后执行演示文稿操作，并仅在所有 Aspose.Slides 工作完成后关闭 JVM。

### **从文件应用许可证**

将许可证文件路径传递给[License.setLicense](https://reference.aspose.com/slides/zh/python-java/aspose.slides/license/#setLicense)。将 `Aspose.Slides.lic` 替换为您的许可证文件路径。

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # 在此执行演示文稿操作，在关闭 JVM 之前。
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

使用完整的文件名，包括扩展名。例如，如果文件名为 `Aspose.Slides.lic.xml`，请在路径中包含 `.xml`。使用绝对路径可以避免对应用程序工作目录产生歧义。

示例使用[License.isLicensed](https://reference.aspose.com/slides/zh/python-java/aspose.slides/license/#isLicensed)检查许可证是否已应用。

### **从字节数组应用许可证**

当许可证以 Python 字节形式可用时，使用[License.setLicenseFromBytes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/license/#setLicenseFromBytes)。以下示例以二进制方式读取文件并在应用许可证前关闭文件。

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
        # 在此执行演示文稿操作，在关闭 JVM 之前。
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

保持原始字节不变。不要在应用之前对许可证内容进行解码、重新格式化或其他修改。

## **应用计量许可证**

计量授权根据 API 使用情况计费。获取计量许可证后，请使用[Metered.setMeteredKey](https://reference.aspose.com/slides/zh/python-java/aspose.slides/metered/#setMeteredKey)应用其公钥和私钥。在应用程序启动时初始化[Metered](https://reference.aspose.com/slides/zh/python-java/aspose.slides/metered/)对象并一次性应用密钥。

以下示例从 `ASPOSE_METERED_PUBLIC_KEY` 和 `ASPOSE_METERED_PRIVATE_KEY` 环境变量读取密钥。运行脚本前请设置这两个变量。

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # 在此执行演示文稿操作，在关闭 JVM 之前。
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="注意" %}}
计量授权需要互联网连接以验证密钥并报告使用情况。请将私钥保存在源代码和日志之外。有关连接和计费细节，请参阅[计量授权 FAQ](https://purchase.aspose.com/faqs/licensing/metered)。
{{% /alert %}}

## **常见问题**

**购买许可证后需要安装不同的包吗？**

不需要。对与评估时使用的相同包应用许可证即可。

**是否需要为每个演示文稿都应用许可证？**

不需要。在应用程序启动时一次性应用，在创建或加载演示文稿之前完成即可。

**可以重命名许可证文件吗？**

可以。请在代码中使用新的完整文件名，并保持文件内容不变。

**可以在基于字节的示例中使用临时许可证吗？**

可以。将临时许可证文件以字节形式读取，并以与已购买许可证相同的方式应用。