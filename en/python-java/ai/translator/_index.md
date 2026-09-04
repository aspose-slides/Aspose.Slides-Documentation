---
title: AI-Powered Presentation Translator
linktitle: AI-Powered Translator
type: docs
weight: 20
url: /python-java/ai/translator/
keywords:
- AI presentation translator
- AI slide translator
- multilingual presentation
- presentation translation
- slide translation
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Translate presentations with AI using Aspose.Slides for Python via Java. Localize slide text and save the translated presentation as PowerPoint or PDF."
---

## **Introduction**

Aspose.Slides for Python via Java provides an AI Presentation Translation API for localizing slide content. Translate an existing presentation into a specified language, then save the translated version in the format your audience needs.

## **How It Works**

[SlidesAIAgent](https://reference.aspose.com/slides/python-java/aspose.slides/slidesaiagent/) communicates with an external AI service through an AI client. The examples use the built-in [OpenAIWebClient](https://reference.aspose.com/slides/python-java/aspose.slides/openaiwebclient/).

[SlidesAIAgent.translate](https://reference.aspose.com/slides/python-java/aspose.slides/slidesaiagent/#translate) updates the presentation passed to it. Aspose.Slides processes the AI responses and replaces slide text while retaining the existing layout and formatting. Review the result: translated text may be longer than the original and require layout adjustments.

## **Prerequisites**

Follow [Installation](/slides/python-java/installation/) to configure the library and its runtime. Set the `OPENAI_API_KEY` and `OPENAI_MODEL` environment variables before running the examples. Choose a model supported by the built-in client and available to your API account.

{{% alert color="info" title="Note" %}}

Translation requires an internet connection and sends presentation text to the configured AI service. Its API access and usage charges are separate from your Aspose.Slides license.

{{% /alert %}}

The examples reuse an active JVM or start it if necessary. See [JVM lifecycle guidance](/slides/python-java/limitations-and-api-differences/#import-the-library) for notebook usage.

## **Translate a Presentation**

Place `sample.pptx` in the working directory. This example loads it with [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), translates its text into Japanese, and saves the result as a PDF. It releases the presentation and closes the AI client even if an operation fails.

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

## **Configure the HTTP Connection**

By default, [OpenAIWebClient](https://reference.aspose.com/slides/python-java/aspose.slides/openaiwebclient/) manages its HTTP connection internally. Its four-argument constructor also accepts an externally managed Java [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html). Use this overload when you need to configure a proxy or connection timeouts.

The following example creates a Java HTTP proxy with [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) and opens a connection through [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)). Replace `proxy.example.com` and the port with your proxy settings. The connection is passed directly through JPype; a Python HTTP session cannot be used in its place.

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

## **Key Benefits**

Automated translation helps prepare multilingual training materials, product presentations, and client reports while reusing the existing slide design. Save an editable presentation for further review or export a PDF for distribution.

## **FAQ**

**Does translation create a separate presentation object?**

No. [SlidesAIAgent.translate](https://reference.aspose.com/slides/python-java/aspose.slides/slidesaiagent/#translate) modifies the supplied presentation. Save it under a new file name to keep the original file unchanged.

**How do I specify the target language?**

Pass the language name, such as `"Japanese"` or `"Spanish"`, as the second argument. Translation quality and language coverage depend on the selected model.

**Can I translate without using a proxy?**

Yes. Use the three-argument client constructor shown in the first example. The custom connection example is only needed when your application requires explicit connection settings.
