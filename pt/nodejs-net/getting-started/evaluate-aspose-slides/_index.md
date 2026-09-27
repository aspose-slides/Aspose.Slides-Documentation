---
title: Avaliar Aspose.Slides
type: docs
weight: 120
url: /pt/nodejs-net/evaluate-aspose-slides/
keywords:
- avaliar Aspose.Slides
- versão de avaliação
- marca d'água de avaliação
- limitações de avaliação
- licença temporária
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "O que a versão de avaliação do Aspose.Slides para Node.js via .NET limita, com um script que mostra ambas as limitações e como removê-las com uma licença."
---
## **Visão geral**

A versão de avaliação do Aspose.Slides for Node.js via .NET é o mesmo pacote npm da versão licenciada. Sem uma licença, ele funciona em modo de avaliação: todos os recursos funcionam, mas as apresentações salvas e a maioria das exportações carregam uma marca d'água, e o texto que seu código lê de volta é truncado. Este artigo descreve ambas as limitações e mostra como removê-las.

## **Limitações da avaliação**

**Marca d'água de avaliação em cada slide.** Quando você salva uma apresentação sem uma licença, Aspose.Slides adiciona uma caixa de texto ao meio de cada slide do arquivo salvo. A caixa de texto está bloqueada e exibe “Evaluation only.” seguido por uma linha de produto e uma linha de direitos autorais. A marca d'água vai para o arquivo salvo, não para a apresentação na memória, e abrir uma apresentação não a adiciona. Um arquivo que foi salvo em modo de avaliação já contém a caixa de texto; portanto, abrir e salvá‑lo novamente adiciona uma segunda marca d'água a cada slide.

A mesma marca d'água é desenhada na saída quando você exporta para PDF, XPS ou HTML, ou renderiza slides como imagens. Se você renderizar uma apresentação que já foi salva em modo de avaliação, a imagem mostra tanto a marca d'água salva quanto a renderizada.

**Texto truncado quando seu código o lê.** Texto que seu código lê através da propriedade `text` de um quadro de texto, parágrafo ou porção é cortado para os primeiros cinco caracteres, seguido pelo aviso “… text has been truncated due to evaluation version limitation.” Texto com cinco caracteres ou menos é retornado integralmente. Isso se aplica a cada slide, e também ao texto que seu código acabou de atribuir. Exportações Markdown e HTML5 são truncadas da mesma forma.

O texto que seu código grava é salvo integralmente: arquivos PPTX, páginas PDF e imagens de slide contêm o texto completo.

## **Ver as limitações em um script**

O script a seguir mostra ambas as limitações. Ele assume que você instalou o pacote conforme descrito em [Installation](/slides/pt/nodejs-net/installation/) e que o executa a partir da pasta do projeto. Ele adiciona um retângulo com uma frase ao primeiro slide, lê a frase de volta, salva a apresentação como `evaluation.pptx` e, em seguida, reabre o arquivo para contar os shapes no slide.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // Sem uma licença, apenas os primeiros cinco caracteres são retornados.
    console.log("Text read back:", rectangle.textFrame.text);

    // Salvar adiciona a marca d'água de avaliação a cada slide do arquivo.
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // O slide agora contém o retângulo e a caixa de texto da marca d'água.
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

Sem uma licença, o script imprime:

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

O segundo shape é a caixa de texto da marca d'água. Abra `evaluation.pptx` para ver a frase completa no retângulo e a marca d'água no meio do slide.

## **Remover as limitações**

Para remover ambas as limitações, aplique uma licença antes de criar qualquer objeto `Presentation`. [Licensing](/slides/pt/nodejs-net/licensing/) mostra como aplicar um arquivo de licença.

{{% alert color="success" title="Tip" %}}
Para testar o Aspose.Slides sem as limitações da avaliação antes de comprar, solicite uma **licença temporária de 30 dias** gratuita. Veja [Como obter uma Licença Temporária?](https://purchase.aspose.com/temporary-license) para detalhes.
{{% /alert %}}

## **Perguntas frequentes**

**O modo de avaliação limita o número de slides?**

Não. Apresentações são criadas, abertas e salvas com todos os seus slides. A marca d'água e o truncamento de texto se aplicam a cada slide de forma idêntica.

**Por que as imagens dos slides exportados mostram a marca d'água duas vezes?**

A apresentação foi salva em modo de avaliação antes de ser renderizada, portanto já contém uma caixa de texto de marca d'água, e a renderização sem licença desenha outra sobre ela.

**Posso verificar se meu código produz o texto correto enquanto estiver no modo de avaliação?**

Sim. Abra o arquivo salvo ou o PDF exportado: eles contêm o texto completo. Apenas o texto que seu código lê de volta, e a saída Markdown ou HTML5, são truncados.