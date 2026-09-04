---
title: AI 驅動的簡報翻譯器
linktitle: AI 驅動的翻譯器
type: docs
weight: 20
url: /zh-hant/python-java/ai/translator/
keywords:
- AI 簡報翻譯器
- AI 投影片翻譯器
- 多語言簡報
- 簡報翻譯
- 投影片翻譯
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 以 AI 翻譯簡報。將投影片文字本機化，並將翻譯後的簡報儲存為 PowerPoint 或 PDF。"
---
## **簡介**

Aspose.Slides for Python via Java 提供 AI 演示文稿翻譯 API，用於本地化投影片內容。將現有的演示文稿翻譯成指定語言，然後將翻譯後的版本儲存為您的觀眾所需的格式。

## **運作方式**

[SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesaiagent/) 透過 AI 用戶端與外部 AI 服務通訊。範例使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/openaiwebclient/)。

[SlidesAIAgent.translate](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesaiagent/#translate) 更新傳入的演示文稿。Aspose.Slides 處理 AI 回應，並在保留現有版面配置和格式的同時替換投影片文字。檢視結果：翻譯後的文字可能比原文更長，需調整版面。

## **先決條件**

依照 [Installation](/slides/zh-hant/python-java/installation/) 設定函式庫及其執行環境。  
在執行範例之前，設定 `OPENAI_API_KEY` 和 `OPENAI_MODEL` 環境變數。  
選擇內建用戶端支援且您的 API 帳戶可使用的模型。

{{% alert color="info" title="Note" %}}
翻譯需要網際網路連線，且會將投影片文字傳送至已設定的 AI 服務。其 API 存取與使用費用與您的 Aspose.Slides 授權分開計算。
{{% /alert %}}

範例會重複使用已啟動的 JVM，必要時會啟動它。請參閱 [JVM lifecycle guidance](/slides/zh-hant/python-java/limitations-and-api-differences/#import-the-library) 以了解筆記本使用方式。

## **翻譯演示文稿**

將 `sample.pptx` 放置於工作目錄。此範例使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 載入它，將文字翻譯成日文，並將結果儲存為 PDF。即使操作失敗，仍會釋放演示文稿並關閉 AI 用戶端。

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

## **設定 HTTP 連線**

預設情況下，OpenAIWebClient 使用內部管理的 HTTP 連線。其四參數建構子也接受由外部管理的 Java HttpURLConnection。當需要設定代理伺服器或連線逾時時，使用此重載。

以下範例使用 [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) 建立 Java HTTP 代理，並透過 [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)) 開啟連線。將 `proxy.example.com` 以及埠號替換為您的代理設定。此連線直接透過 JPype 傳遞，無法改用 Python HTTP 工作階段。

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

## **主要優點**

自動翻譯有助於製作多語言的訓練教材、產品簡報與客戶報告，同時重複使用現有的投影片設計。可將可編輯的演示文稿儲存以便進一步審閱，或匯出 PDF 以供分發。

## **FAQ**

**翻譯會建立獨立的演示文稿物件嗎？**

不會。[SlidesAIAgent.translate](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesaiagent/#translate) 會修改提供的演示文稿。請以新檔名儲存，以保持原始檔案不變。

**如何指定目標語言？**

將語言名稱（例如 `"Japanese"` 或 `"Spanish"`）作為第二個參數傳入。翻譯品質與語言覆蓋範圍取決於所選模型。

**我可以在不使用代理的情況下翻譯嗎？**

可以。使用第一個範例中示範的三參數用戶端建構子。僅在您的應用程式需要明確的連線設定時，才需要自訂連線範例。