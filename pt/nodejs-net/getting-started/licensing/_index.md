---
title: Licenciamento
description: "Aplique um arquivo de licença ao Aspose.Slides for Node.js via .NET, veja quais são as limitações da versão de avaliação e obtenha uma licença temporária gratuita de 30 dias para testes."
type: docs
weight: 80
url: /pt/nodejs-net/licensing/
---
## **Visão geral**

Aspose.Slides for Node.js via .NET é um pacote npm tanto para avaliação quanto para produção. Sem uma licença, ele funciona no modo de avaliação. Depois de comprar uma licença, ou obter uma licença temporária gratuita de 30 dias, você a aplica com algumas linhas de código, e as limitações da avaliação deixam de ser aplicadas.

{{% alert color="info" title="Note" %}}

Políticas gerais sobre como avaliar, licenciar e comprar produtos Aspose são reunidas em [Políticas de Compra e FAQ](https://purchase.aspose.com/policies). Os preços estão listados na [Informações de Preços](https://purchase.aspose.com/pricing/slides/pt/family).

{{% /alert %}}

## **Limitações da Versão de Avaliação**

A versão de avaliação fornece toda a funcionalidade do produto, com duas limitações:

- **Marca d'água.** Cada slide de cada apresentação que você salvar recebe uma marca d'água de avaliação: uma caixa de texto bloqueada no meio do slide que exibe "Evaluation only". A mesma marca d'água é aplicada nas exportações PDF, XPS e HTML e nas imagens dos slides.
- **Texto truncado.** O texto que seu código lê de um quadro de texto, parágrafo ou porção é reduzido aos primeiros cinco caracteres, seguido do aviso "... text has been truncated due to evaluation version limitation." As exportações Markdown e HTML5 são truncadas da mesma forma. O texto que seu código grava é salvo integralmente.

[ Avaliar Aspose.Slides](/slides/pt/nodejs-net/evaluate-aspose-slides/) descreve ambas as limitações em detalhes e inclui um script que as demonstra.

{{% alert color="success" title="Tip" %}}

Para testar Aspose.Slides sem as limitações de avaliação, solicite uma licença temporária gratuita de **30 dias**. Veja [Como obter uma Licença Temporária?](https://purchase.aspose.com/temporary-license) para mais detalhes.

{{% /alert %}}

## **Sobre a Licença**

A licença é um arquivo XML de texto simples que contém detalhes como o nome do produto, o número de desenvolvedores licenciados e a data de expiração da assinatura. O arquivo é assinado digitalmente, portanto não o modifique: até mesmo uma quebra de linha extra inserida por engano o invalida.

## **Aplicar uma Licença**

Aplique a licença com o método `setLicense` da classe `License`. Chame-o uma vez por processo, antes de criar qualquer objeto `Presentation`. Chamá-lo novamente não causa dano, mas repete trabalho já realizado.

O script a seguir aplica uma licença de um arquivo chamado `Aspose.Slides.lic`. Substitua o nome pelo nome ou caminho completo do seu arquivo de licença; o arquivo pode ter qualquer nome.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

Um nome de arquivo ou caminho relativo é resolvido em relação à pasta atual, aquela de onde você executa `node`. Mantenha o arquivo de licença na pasta do seu projeto e execute seus scripts a partir daí, ou passe o caminho completo.

Se o arquivo não for encontrado, ou não for uma licença válida, `setLicense` lança um erro, e Aspose.Slides permanece no modo de avaliação. O script captura o erro e imprime sua mensagem. Para um arquivo ausente, a mensagem começa com `License "Aspose.Slides.lic" doesn't exist or access is restricted.` e lista todas as localizações pesquisadas.

Neste pacote, a licença é aplicada apenas a partir de um arquivo. `License` não aceita um stream, e o pacote não expõe licenciamento por medição. Para a classe que o pacote encapsula, consulte [License](https://reference.aspose.com/slides/pt/net/aspose.slides/license/) na referência da API Aspose.Slides for .NET.