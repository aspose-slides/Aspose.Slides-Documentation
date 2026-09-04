---
title: Tradutor de Apresentação com IA
linktitle: Tradutor com IA
type: docs
weight: 20
url: /pt/python-java/ai/translator/
keywords:
- tradutor de apresentação com IA
- tradutor de slide com IA
- apresentação multilíngue
- tradução de apresentação
- tradução de slide
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Traduza apresentações com IA usando Aspose.Slides for Python via Java. Localize o texto dos slides e salve a apresentação traduzida como PowerPoint ou PDF."
---
## **Introdução**

Aspose.Slides for Python via Java fornece uma API de Tradução de Apresentação com IA para localizar o conteúdo dos slides. Traduza uma apresentação existente para um idioma especificado e, em seguida, salve a versão traduzida no formato que seu público precisa.

## **Como funciona**

[SlidesAIAgent](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidesaiagent/) comunica‑se com um serviço de IA externo por meio de um cliente de IA. Os exemplos usam o [OpenAIWebClient](https://reference.aspose.com/slides/pt/python-java/aspose.slides/openaiwebclient/).

[SlidesAIAgent.translate](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidesaiagent/#translate) atualiza a apresentação passada. Aspose.Slides processa as respostas da IA e substitui o texto dos slides mantendo o layout e a formatação existentes. Revise o resultado: o texto traduzido pode ser mais longo que o original e exigir ajustes de layout.

## **Pré‑requisitos**

Siga [Installation](/slides/pt/python-java/installation/) para configurar a biblioteca e seu tempo de execução. Defina as variáveis de ambiente `OPENAI_API_KEY` e `OPENAI_MODEL` antes de executar os exemplos. Escolha um modelo suportado pelo cliente incorporado e disponível para sua conta da API.

{{% alert color="info" title="Note" %}}
A tradução requer conexão com a internet e envia o texto da apresentação para o serviço de IA configurado. Seu acesso à API e as cobranças de uso são independentes da sua licença Aspose.Slides.
{{% /alert %}}

Os exemplos reutilizam uma JVM ativa ou a iniciam se necessário. Veja [JVM lifecycle guidance](/slides/pt/python-java/limitations-and-api-differences/#import-the-library) para uso em notebooks.

## **Traduzir uma apresentação**

Coloque `sample.pptx` no diretório de trabalho. Este exemplo o carrega com [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/), traduz seu texto para japonês e salva o resultado como PDF. Ele libera a apresentação e fecha o cliente de IA mesmo se uma operação falhar.

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

## **Configurar a conexão HTTP**

Por padrão, [OpenAIWebClient](https://reference.aspose.com/slides/pt/python-java/aspose.slides/openaiwebclient/) gerencia sua conexão HTTP internamente. Seu construtor com quatro argumentos também aceita um [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html) Java gerenciado externamente. Use essa sobrecarga quando precisar configurar um proxy ou tempos limite de conexão.

O exemplo a seguir cria um proxy HTTP Java com [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) e abre uma conexão através de [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)). Substitua `proxy.example.com` e a porta pelas configurações do seu proxy. A conexão é passada diretamente através do JPype; uma sessão HTTP Python não pode ser usada no seu lugar.

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

## **Principais benefícios**

A tradução automatizada ajuda a preparar materiais de treinamento multilíngues, apresentações de produtos e relatórios de clientes, reutilizando o design existente dos slides. Salve uma apresentação editável para revisão adicional ou exporte um PDF para distribuição.

## **FAQ**

**A tradução cria um objeto de apresentação separado?**

Não. [SlidesAIAgent.translate](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidesaiagent/#translate) modifica a apresentação fornecida. Salve-a com um novo nome de arquivo para manter o arquivo original inalterado.

**Como especifico o idioma de destino?**

Passe o nome do idioma, como `"Japanese"` ou `"Spanish"`, como segundo argumento. A qualidade da tradução e a cobertura de idiomas dependem do modelo selecionado.

**Posso traduzir sem usar um proxy?**

Sim. Use o construtor de cliente com três argumentos mostrado no primeiro exemplo. O exemplo de conexão personalizada só é necessário quando sua aplicação requer configurações de conexão explícitas.