---
title: AI驱动的演示文稿翻译器
linktitle: AI驱动的翻译器
type: docs
weight: 20
url: /zh/python-java/ai/translator/
keywords:
- AI演示文稿翻译器
- AI幻灯片翻译器
- 多语言演示文稿
- 演示文稿翻译
- 幻灯片翻译
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 通过 AI 翻译演示文稿。对幻灯片文本进行本地化，并将翻译后的演示文稿保存为 PowerPoint 或 PDF。"
---
## **介绍**

Aspose.Slides for Python via Java 提供了用于本地化幻灯片内容的 AI 演示文稿翻译 API。将现有演示文稿翻译为指定语言，然后以受众需要的格式保存翻译后的版本。

## **工作原理**

[SlidesAIAgent](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidesaiagent/) 通过 AI 客户端与外部 AI 服务通信。示例使用内置的 [OpenAIWebClient](https://reference.aspose.com/slides/zh/python-java/aspose.slides/openaiwebclient/)。

[SlidesAIAgent.translate](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidesaiagent/#translate) 更新传入的演示文稿。Aspose.Slides 处理 AI 响应，替换幻灯片文本，同时保留现有布局和格式。请检查结果：翻译后的文本可能比原文更长，需要进行布局调整。

## **先决条件**

按照 [Installation](/slides/zh/python-java/installation/) 配置库及其运行时。在运行示例前设置 `OPENAI_API_KEY` 和 `OPENAI_MODEL` 环境变量。选择内置客户端支持且您的 API 账户可用的模型。

{{% alert color="info" title="注意" %}}
翻译需要网络连接，并将演示文稿文本发送到配置的 AI 服务。其 API 访问和使用费用与您的 Aspose.Slides 许可证分开。
{{% /alert %}}

示例会复用已启动的 JVM，必要时会启动它。有关笔记本使用，请参阅 [JVM 生命周期指南](/slides/zh/python-java/limitations-and-api-differences/#import-the-library)。

## **翻译演示文稿**

将 `sample.pptx` 放在工作目录中。本示例使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 加载它，将文本翻译为日语，并将结果保存为 PDF。即使操作失败，也会释放演示文稿并关闭 AI 客户端。

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    presentation = Presentation("sample.pptx")
    try:
        ai_agent = SlidesAIAgent(ai_client)
        ai_agent.translate(presentation, "Japanese")
        presentation.save("sample_ja.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **配置 HTTP 连接**

默认情况下，[OpenAIWebClient](https://reference.aspose.com/slides/zh/python-java/aspose.slides/openaiwebclient/) 在内部管理 HTTP 连接。其四参数构造函数还接受外部管理的 Java [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html)。当需要配置代理或连接超时时，请使用此重载。

下面的示例使用 [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) 创建 Java HTTP 代理，并通过 [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)) 打开连接。将 `proxy.example.com` 和端口替换为您的代理设置。该连接直接通过 JPype 传递，无法使用 Python HTTP 会话代替。

```python
import os
import jpype
import jpype.imports
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.net import InetSocketAddress, Proxy, URL
from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
proxy_address = InetSocketAddress("proxy.example.com", 8080)
proxy = Proxy(Proxy.Type.HTTP, proxy_address)
endpoint = URL("https://api.openai.com/v1/chat/completions")
connection = endpoint.openConnection(proxy)
try:
    connection.setConnectTimeout(30000)
    connection.setReadTimeout(60000)
    ai_client = OpenAIWebClient(model, api_key, None, connection)
    try:
        presentation = Presentation("sample.pptx")
        try:
            ai_agent = SlidesAIAgent(ai_client)
            ai_agent.translate(presentation, "Japanese")
            presentation.save("sample_ja.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        ai_client.close()
finally:
    connection.disconnect()
```

## **主要优势**

自动翻译可帮助准备多语言培训材料、产品演示和客户报告，同时重用现有的幻灯片设计。可将演示文稿保存为可编辑格式以便进一步审阅，或导出 PDF 进行分发。

## **常见问题**

**翻译会创建单独的演示文稿对象吗？**

不会。[SlidesAIAgent.translate](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidesaiagent/#translate) 会修改提供的演示文稿。请使用新文件名保存，以保持原始文件不变。

**如何指定目标语言？**

将语言名称（例如 `"Japanese"` 或 `"Spanish"`）作为第二个参数传递。翻译质量和语言覆盖范围取决于所选模型。

**可以在不使用代理的情况下翻译吗？**

可以。使用第一个示例中显示的三参数客户端构造函数。仅当您的应用程序需要显式的连接设置时才需要自定义连接示例。