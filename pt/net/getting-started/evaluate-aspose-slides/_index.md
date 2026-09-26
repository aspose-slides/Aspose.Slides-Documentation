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
description: "Avalie o Aspose.Slides para .NET e explore os recursos da API para apresentações PowerPoint (PPT, PPTX) e OpenDocument (ODP) — inicie seu teste gratuito."
---
## **Aspose.Slides Avaliação**

Você pode baixar o Aspose.Slides para avaliação. O pacote de avaliação é o mesmo que o pacote adquirido; ele se torna licenciado depois que você adiciona algumas linhas de código para aplicar a licença.

Sem uma licença, o Aspose.Slides fornece sua funcionalidade completa no modo de avaliação, com duas limitações: ele adiciona uma caixa de texto com marca d'água de avaliação a cada slide de cada apresentação que salva, e o texto que seu código lê de uma apresentação é truncado para os primeiros caracteres, seguido por um aviso sobre a limitação da avaliação. O texto que seu código grava é salvo integralmente.

![Um slide com a marca d'água de avaliação](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
Se você quiser testar o Aspose.Slides sem as limitações da versão de avaliação, pode solicitar uma **Licença Temporária de 30 Dias**. Consulte [Como obter uma Licença Temporária?](https://purchase.aspose.com/temporary-license) para mais informações.
{{% /alert %}}

## **Instalar o Pacote de Avaliação**

```bash
dotnet add package Aspose.Slides.NET
```

No Linux e macOS, você pode usar o pacote Aspose.Slides.NET6.CrossPlatform; veja [Instalação](/slides/pt/net/installation/).

## **Aplicar uma Licença**

Estas são as “poucas linhas de código” que transformam o pacote de avaliação em um licenciado. Aplique a licença uma única vez na inicialização da aplicação, antes que qualquer objeto `Presentation` seja criado — uma apresentação criada antes mantém a marca d'água de avaliação.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` também aceita um `Stream`, que é a melhor opção quando a licença é enviada como um recurso incorporado em vez de um arquivo no disco. Se o caminho estiver errado ou o arquivo tiver expirado, a chamada lança exceção, de modo que falhas aparecem imediatamente na inicialização ao invés de reverter silenciosamente para o modo de avaliação.

Depois que a licença for aplicada, as apresentações salvas não carregam mais a marca d'água, e o texto é lido integralmente.

## **FAQ**

### Posso testar múltiplas apresentações em paralelo em diferentes threads no modo de avaliação?

Sim. Você pode processar documentos diferentes em paralelo; não deve compartilhar o mesmo objeto de apresentação [entre threads](/slides/pt/net/multithreading/). O modo de avaliação não afeta isso.

### Preciso instalar o Microsoft PowerPoint para avaliar a biblioteca em um servidor ou em CI?

Não. O Aspose.Slides é um motor autônomo e não requer o PowerPoint instalado, seja para avaliação ou produção.

### Posso testar completamente a conversão de PPT/PPTX para PDF e imagens no modo de avaliação?

Sim. Os [conversores](/slides/pt/net/convert-presentation/) funcionam; a saída incluirá uma marca d'água.

### Posso usar uma licença temporária para testes de carga sem marca d'água?

Sim. Uma licença temporária de 30 dias remove as limitações do modo de avaliação e permite testar sem marca d'água.