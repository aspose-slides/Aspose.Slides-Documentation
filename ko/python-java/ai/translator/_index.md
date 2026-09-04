---
title: AI 기반 프레젠테이션 번역기
linktitle: AI 기반 번역기
type: docs
weight: 20
url: /ko/python-java/ai/translator/
keywords:
- AI 프레젠테이션 번역기
- AI 슬라이드 번역기
- 다국어 프레젠테이션
- 프레젠테이션 번역
- 슬라이드 번역
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "AI를 사용하여 Aspose.Slides for Python via Java로 프레젠테이션을 번역합니다. 슬라이드 텍스트를 현지화하고 번역된 프레젠테이션을 PowerPoint 또는 PDF로 저장합니다."
---
## **소개**

Aspose.Slides for Python via Java은 슬라이드 콘텐츠를 현지화하기 위한 AI 프레젠테이션 번역 API를 제공합니다. 기존 프레젠테이션을 지정된 언어로 번역한 다음, 청중이 필요로 하는 형식으로 번역된 버전을 저장합니다.

## **작동 방식**

[SlidesAIAgent](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidesaiagent/)은 AI 클라이언트를 통해 외부 AI 서비스와 통신합니다. 예제에서는 내장된 [OpenAIWebClient](https://reference.aspose.com/slides/ko/python-java/aspose.slides/openaiwebclient/)를 사용합니다.

[SlidesAIAgent.translate](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidesaiagent/#translate) 은 전달된 프레젠테이션을 업데이트합니다. Aspose.Slides는 AI 응답을 처리하고 기존 레이아웃과 서식을 유지하면서 슬라이드 텍스트를 교체합니다. 결과를 검토하십시오: 번역된 텍스트가 원본보다 길어져 레이아웃 조정이 필요할 수 있습니다.

## **사전 요구 사항**

[Installation](/slides/ko/python-java/installation/) 를 따라 라이브러리와 런타임을 구성하십시오. 예제를 실행하기 전에 `OPENAI_API_KEY` 와 `OPENAI_MODEL` 환경 변수를 설정합니다. 내장 클라이언트가 지원하고 API 계정에서 사용할 수 있는 모델을 선택하십시오.

{{% alert color="info" title="Note" %}}
번역에는 인터넷 연결이 필요하며 프레젠테이션 텍스트를 구성된 AI 서비스에 전송합니다. 해당 API 액세스 및 사용 요금은 Aspose.Slides 라이선스와 별개입니다.
{{% /alert %}}

예제는 활성 JVM을 재사용하거나 필요 시 시작합니다. 노트북 사용에 대해서는 [JVM lifecycle guidance](/slides/ko/python-java/limitations-and-api-differences/#import-the-library) 를 참조하십시오.

## **프레젠테이션 번역**

`sample.pptx` 를 작업 디렉터리에 두십시오. 이 예제는 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 로 파일을 로드하고 텍스트를 일본어로 번역한 뒤 결과를 PDF로 저장합니다. 작업이 실패하더라도 프레젠테이션을 해제하고 AI 클라이언트를 닫습니다.

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

## **HTTP 연결 구성**

기본적으로, [OpenAIWebClient](https://reference.aspose.com/slides/ko/python-java/aspose.slides/openaiwebclient/) 은 HTTP 연결을 내부에서 관리합니다. 네 개 인자를 받는 생성자는 외부에서 관리되는 Java [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html) 도 허용합니다. 프록시나 연결 시간 초과를 구성해야 할 때 이 오버로드를 사용하십시오.

다음 예제는 [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) 으로 Java HTTP 프록시를 생성하고 [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)) 을 통해 연결을 엽니다. `proxy.example.com` 과 포트를 프록시 설정에 맞게 교체하십시오. 연결은 JPype을 통해 직접 전달되며, Python HTTP 세션은 대신 사용할 수 없습니다.

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

## **주요 장점**

자동 번역은 기존 슬라이드 디자인을 재사용하면서 다국어 교육 자료, 제품 프레젠테이션 및 고객 보고서를 준비하는 데 도움이 됩니다. 추가 검토를 위해 편집 가능한 프레젠테이션을 저장하거나 배포용 PDF로 내보낼 수 있습니다.

## **FAQ**

**번역이 별도의 프레젠테이션 객체를 생성합니까?**

아니요. [SlidesAIAgent.translate](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slidesaiagent/#translate) 은 제공된 프레젠테이션을 수정합니다. 원본 파일을 그대로 두려면 새 파일 이름으로 저장하십시오.

**대상 언어는 어떻게 지정합니까?**

두 번째 인자로 `"Japanese"` 혹은 `"Spanish"` 와 같은 언어명을 전달합니다. 번역 품질 및 언어 지원 범위는 선택한 모델에 따라 달라집니다.

**프록시 없이 번역할 수 있습니까?**

예. 첫 번째 예제에 표시된 세 개 인자 클라이언트 생성자를 사용하십시오. 맞춤형 연결 예제는 애플리케이션에서 명시적인 연결 설정이 필요할 때만 사용합니다.