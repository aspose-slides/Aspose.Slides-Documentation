---
title: Gerador Multilíngue de Slides com IA
linktitle: Gerador com IA
type: docs
weight: 40
url: /pt/python-java/ai/generator/
keywords:
- apresentação multilíngue
- slide multilíngue
- gerador de apresentações com IA
- gerador de slides com IA
- modelo de apresentação
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Gere apresentações multilíngues a partir de texto com Aspose.Slides para Python via Java. Escolha o detalhe do conteúdo, aplique um modelo e exporte para PowerPoint ou PDF."
---
## **Introdução**

O Gerador de Apresentações de IA no Aspose.Slides para Python via Java cria apresentações a partir de descrições de tópicos, resumos, citações ou marcadores. Especifique o idioma desejado no seu prompt, escolha a quantidade de conteúdo e, opcionalmente, forneça um modelo de apresentação para definir o layout e o design.

O gerador estrutura o conteúdo usando blocos de texto, listas de marcadores e tabelas. Ele não gera imagens; você pode adicioná-las à apresentação resultante posteriormente. Revise o conteúdo e o layout gerados antes de compartilhar a apresentação.

## **Como funciona**

[SlidesAIAgent](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidesaiagent/) usa um cliente de IA para se comunicar com um modelo externo. Os exemplos abaixo utilizam o [OpenAIWebClient](https://reference.aspose.com/slides/pt/python-java/aspose.slides/openaiwebclient/) incorporado. Aspose.Slides processa as respostas do modelo e cria uma apresentação que você pode editar ou exportar.

Use [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidesaiagent/#generatePresentation) com uma descrição em texto e um valor de [PresentationContentAmountType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationcontentamounttype/). A sobrecarga com um terceiro argumento aceita uma apresentação para usar como modelo de design.

## **Pré-requisitos**

Siga as instruções de [Installation](/slides/pt/python-java/installation/) para configurar Python, Java, JPype e Aspose.Slides. Defina as variáveis de ambiente `OPENAI_API_KEY` e `OPENAI_MODEL` antes de executar os exemplos. Escolha um modelo compatível com o cliente incorporado e disponível na sua conta de API.

{{% alert color="info" title="Note" %}}
O serviço de IA requer uma conexão à internet e acesso à API separado. Os prompts são enviados ao serviço configurado, e as cobranças de uso são aplicadas independentemente da sua licença Aspose.Slides.
{{% /alert %}}

Cada exemplo inicia a JVM apenas se ela ainda não estiver em execução e a deixa disponível para operações subsequentes. Consulte a [JVM lifecycle guidance](/slides/pt/python-java/limitations-and-api-differences/#import-the-library) ao adaptar o código para notebooks.

## **Gerar uma apresentação a partir de texto**

Este exemplo gera uma apresentação em inglês com uma quantidade de conteúdo [Medium](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationcontentamounttype/#Medium) e a salva como um arquivo PowerPoint.

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

## **Gerar uma apresentação usando um modelo**

Coloque `masterPresentation.pptx` no diretório de trabalho. Este exemplo o carrega com [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/), gera uma apresentação em espanhol com conteúdo [Detailed](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationcontentamounttype/#Detailed) e exporta-a para PDF. Tanto o modelo quanto a apresentação gerada são liberados, mesmo que a geração ou a gravação falhem.

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

Se precisar configurar um proxy ou limites de tempo de conexão, consulte [Configure the HTTP Connection](/slides/pt/python-java/ai/translator/#configure-the-http-connection). Você também pode passar o cliente resultante para o gerador.

## **Principais benefícios**

A geração pode reduzir o trabalho inicial de elaboração de materiais de treinamento, visões gerais de produtos, relatórios de clientes e apresentações internas. Os prompts controlam o tópico e o idioma, enquanto um modelo permite reutilizar um design de apresentação existente.

## **FAQ**

**Como controlo o comprimento da apresentação gerada?**

Escolha [Brief](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationcontentamounttype/#Medium) ou [Detailed](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationcontentamounttype/#Detailed). Essas configurações influenciam tanto o número de slides quanto o nível de detalhe em cada slide; elas não especificam uma contagem exata de slides.

**Posso gerar slides em outro idioma?**

Sim. Inclua o idioma solicitado na descrição em texto. O resultado depende das capacidades de idioma do modelo selecionado.

**Posso manter uma versão editável ao exportar para PDF?**

Sim. Antes de descartar a apresentação gerada, salve-a também como PPTX usando a abordagem do primeiro exemplo.