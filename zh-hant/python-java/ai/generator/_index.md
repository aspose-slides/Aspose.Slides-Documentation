---
title: AI 驅動的多語言投影片產生器
linktitle: AI 驅動的產生器
type: docs
weight: 40
url: /zh-hant/python-java/ai/generator/
keywords:
- 多語言簡報
- 多語言投影片
- AI 簡報產生器
- AI 投影片產生器
- 簡報範本
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 從文字產生多語言簡報。選擇內容詳細程度、套用範本，並匯出為 PowerPoint 或 PDF。"
---
## **簡介**

Aspose.Slides for Python via Java 的 AI 簡報產生器可根據主題說明、摘要、引文或項目符號產生簡報。於提示中指定所需語言、選擇內容量，並可選擇提供簡報範本以定義版面與設計。

產生器會以文字區塊、項目清單與表格結構化內容。它不會產生圖片；您可在產生的簡報完成後自行添加。分享簡報前請檢查產生的內容與版面配置。

## **運作方式**

[SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesaiagent/) 使用 AI 用戶端與外部模型通訊。以下範例使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/openaiwebclient/)。Aspose.Slides 會處理模型回應，並建立可編輯或匯出的簡報。

使用 [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesaiagent/#generatePresentation) 搭配文字說明與 [PresentationContentAmountType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationcontentamounttype/) 值。第三個參數的重載可接受一個簡報作為設計範本。

## **先決條件**

依照 [Installation](/slides/zh-hant/python-java/installation/) 設定 Python、Java、JPype 與 Aspose.Slides。執行範例前請設定 `OPENAI_API_KEY` 與 `OPENAI_MODEL` 環境變數。選擇內建用戶端支援且您 API 帳戶可使用的模型。

{{% alert color="info" title="注意" %}}
AI 服務需要網路連線與單獨的 API 存取權。提示會傳送至設定好的服務，使用費用與您的 Aspose.Slides 授權無關，另計收費。
{{% /alert %}}

每個範例僅在 JVM 尚未啟動時啟動它，並在結束後保持 JVM 可供後續操作使用。將程式碼搬移至 Notebook 時，請參考 [JVM lifecycle guidance](/slides/zh-hant/python-java/limitations-and-api-differences/#import-the-library)。

## **從文字產生簡報**

此範例使用 [Medium](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationcontentamounttype/#Medium) 內容量產生英文簡報，並將其存為 PowerPoint 檔案。

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **使用範本產生簡報**

將 `masterPresentation.pptx` 放在工作目錄中。此範例以 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 載入範本，產生西班牙文的 [Detailed](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationcontentamounttype/#Detailed) 內容簡報，並匯出為 PDF。即使產生或儲存失敗，範本與產生的簡報都會被釋放。

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

若需要設定代理或連線逾時，請參考 [Configure the HTTP Connection](/slides/zh-hant/python-java/ai/translator/#configure-the-http-connection)。亦可將產生的用戶端傳遞給產生器使用。

## **主要優勢**

產生功能可減少培訓教材、產品概覽、客戶報告與內部簡報的初稿工作。透過提示可控制主題與語言，使用範本則能重複使用既有的簡報設計。

## **常見問題**

**如何控制產生簡報的長度？**

選擇 [Brief](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationcontentamounttype/#Brief)、[Medium](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationcontentamounttype/#Medium) 或 [Detailed](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentationcontentamounttype/#Detailed)。這些設定會影響投影片數量與每張投影片的細節程度，並非精確的投影片數量。

**可以產生其他語言的投影片嗎？**

可以。只要在文字說明中加入所需語言。結果取決於所選模型的語言支援能力。

**匯出為 PDF 時可以保留可編輯版本嗎？**

可以。在釋放產生的簡報前，先依照第一個範例的方式另存為 PPTX。