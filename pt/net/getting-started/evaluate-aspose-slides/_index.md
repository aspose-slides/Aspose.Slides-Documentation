---
title: Avaliar Aspose.Slides
type: docs
weight: 120
url: /pt/net/evaluate-aspose-slides/
keywords:
- avaliar Aspose.Slides
- avaliação Aspose.Slides
- versão de avaliação
- funcionalidade completa
- marca d'água de avaliação
- comprar Aspose.Slides
- limitação
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Avalie Aspose.Slides para .NET e explore os recursos da API para apresentações PowerPoint (PPT, PPTX) e OpenDocument (ODP) — inicie seu teste gratuito."
---
## **Avaliação do Aspose.Slides**

Você pode baixar facilmente o Aspose.Slides para avaliação. O pacote de avaliação é o mesmo do pacote comprado. A versão de avaliação simplesmente se torna licenciada após você adicionar algumas linhas de código para aplicar a licença. 

A versão de avaliação do Aspose.Slides (sem licença especificada) fornece funcionalidade completa do produto, mas insere uma marca d’água de avaliação no topo do documento ao abrir e salvar. Você também está limitado a um slide ao extrair textos dos slides de apresentação.


![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="info" %}} 

Se você quiser testar o Aspose.Slides sem as limitações da versão de avaliação, pode solicitar uma **Licença Temporária de 30 Dias**. Consulte [Como obter uma Licença Temporária?](https://purchase.aspose.com/temporary-license) para mais informações.

{{% /alert %}}

## **Instalar o Pacote de Avaliação**

```bash
dotnet add package Aspose.Slides.NET
```

## **Aplicar uma Licença**

Estas são as “poucas linhas de código” que transformam o pacote de avaliação em um licenciado. Aplique a licença uma vez na inicialização da aplicação, antes que qualquer objeto `Presentation` seja criado — uma apresentação construída anteriormente mantém a marca d’água de avaliação.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` também aceita um `Stream`, que é a melhor opção quando a licença é distribuída como recurso incorporado em vez de um arquivo no disco. Se o caminho estiver errado ou o arquivo expirou, a chamada lança exceção, de modo que falhas aparecem imediatamente na inicialização ao invés de reverter silenciosamente para o modo de avaliação.

Depois que a licença é aplicada, a marca d’água desaparece e o limite de extração de texto de um slide é removido.

## **Perguntas Frequentes**

### Posso testar várias apresentações em paralelo em diferentes threads no modo de avaliação?

Sim. Você pode processar diferentes documentos em paralelo; não deve compartilhar o mesmo objeto de apresentação [entre threads](/slides/pt/net/multithreading/). O modo de avaliação não afeta isso.

### Preciso instalar o Microsoft PowerPoint para avaliar a biblioteca em um servidor ou em CI?

Não. Aspose.Slides é um motor independente e não requer o PowerPoint instalado nem para avaliação nem para produção.

### Posso testar completamente a conversão de PPT/PPTX para PDF e imagens no modo de avaliação?

Sim. Os [conversores](/slides/pt/net/convert-presentation/) funcionam; a saída incluirá uma marca d’água.

### Posso usar uma licença temporária para teste de carga sem marca d’água?

Sim. Uma licença temporária de 30 dias remove as limitações do modo de avaliação e permite testar sem marca d’água.