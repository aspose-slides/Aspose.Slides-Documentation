---
title: AI Destekli Sunum Çevirmeni
linktitle: AI Destekli Çevirmen
type: docs
weight: 20
url: /tr/python-java/ai/translator/
keywords:
- AI sunum çevirmeni
- AI slayt çevirmeni
- çok dilli sunum
- sunum çevirisi
- slayt çevirisi
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak AI ile sunumları çevirin. Slayt metnini yerelleştirin ve çevirilen sunumu PowerPoint veya PDF olarak kaydedin."
---
## **Giriş**

Aspose.Slides for Python via Java, slayt içeriğini yerelleştirmek için bir AI Sunum Çeviri API'si sağlar. Mevcut bir sunumu belirli bir dile çevirin ve ardından çevirilen sürümü izleyicinizin ihtiyaç duyduğu formatta kaydedin.

## **Nasıl Çalışır**

[SlidesAIAgent](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesaiagent/) harici bir AI hizmetiyle bir AI istemcisi aracılığıyla iletişim kurar. Örnekler, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/python-java/aspose.slides/openaiwebclient/) kullanır.

[SlidesAIAgent.translate](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesaiagent/#translate) kendisine verilen sunumu günceller. Aspose.Slides, AI yanıtlarını işleyerek slayt metnini mevcut düzeni ve biçimlendirmeyi koruyarak değiştirir. Sonucu inceleyin: çevirilen metin orijinalden daha uzun olabilir ve düzen ayarlamaları gerekebilir.

## **Ön Koşullar**

[Installation](/slides/tr/python-java/installation/) sayfasını izleyerek kütüphaneyi ve çalışma zamanını yapılandırın. Örnekleri çalıştırmadan önce `OPENAI_API_KEY` ve `OPENAI_MODEL` ortam değişkenlerini ayarlayın. Yerleşik istemci tarafından desteklenen ve API hesabınızda mevcut bir modeli seçin.

{{% alert color="info" title="Note" %}}
Çeviri bir internet bağlantısı gerektirir ve sunum metnini yapılandırılmış AI hizmetine gönderir. API erişimi ve kullanım ücretleri, Aspose.Slides lisansınızdan ayrı olarak değerlendirilir.
{{% /alert %}}

Örnekler, aktif bir JVM'yi yeniden kullanır veya gerekirse başlatır. Notebook kullanımına ilişkin [JVM lifecycle guidance](/slides/tr/python-java/limitations-and-api-differences/#import-the-library) bölümüne bakın.

## **Bir Sunumu Çevir**

`sample.pptx` dosyasını çalışma dizinine yerleştirin. Bu örnek, dosyayı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) ile yükler, metnini Japoncaya çevirir ve sonucu PDF olarak kaydeder. Bir işlem başarısız olsa bile sunumu serbest bırakır ve AI istemcisini kapatır.

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

## **HTTP Bağlantısını Yapılandırma**

Varsayılan olarak, [OpenAIWebClient](https://reference.aspose.com/slides/tr/python-java/aspose.slides/openaiwebclient/) HTTP bağlantısını dahili olarak yönetir. Dört argümanlı yapıcı, dışarıdan yönetilen bir Java [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html) da kabul eder. Bir proxy veya bağlantı zaman aşımı yapılandırmanız gerektiğinde bu aşırı yüklemesini kullanın.

Aşağıdaki örnek, [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) kullanarak bir Java HTTP proxy'si oluşturur ve [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)) aracılığıyla bir bağlantı açar. `proxy.example.com` ve bağlantı noktasını proxy ayarlarınızla değiştirin. Bağlantı JPype üzerinden doğrudan geçirilir; yerine bir Python HTTP oturumu kullanılamaz.

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

## **Ana Faydalar**

Otomatik çeviri, mevcut slayt tasarımını yeniden kullanarak çok dilli eğitim materyalleri, ürün sunumları ve müşteri raporları hazırlamaya yardımcı olur. Daha sonraki inceleme için düzenlenebilir bir sunum kaydedin veya dağıtım için bir PDF olarak dışa aktarın.

## **SSS**

**Çeviri ayrı bir sunum nesnesi oluşturur mu?**

Hayır. [SlidesAIAgent.translate](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesaiagent/#translate) sağlanan sunumu değiştirir. Orijinal dosyanın değişmemesi için yeni bir dosya adıyla kaydedin.

**Hedef dili nasıl belirlerim?**

Dil adını, örneğin `"Japanese"` veya `"Spanish"` gibi, ikinci argüman olarak geçirin. Çeviri kalitesi ve dil kapsamı seçilen modele bağlıdır.

**Proxy kullanmadan da çeviri yapabilir miyim?**

Evet. İlk örnekte gösterilen üç argümanlı istemci yapıcısını kullanın. Özel bağlantı örneği, uygulamanızın belirli bağlantı ayarları gerektirdiği durumlarda gereklidir.