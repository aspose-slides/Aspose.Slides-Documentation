---
title: Referência de API
type: docs
weight: 50
url: /pt/nodejs-net/api-reference/
description: "Aspose.Slides for Node.js via .NET é documentado pela referência de API do Aspose.Slides for .NET. Veja como os nomes de classes e membros .NET são mapeados para JavaScript."
---
## **Visão geral**

Aspose.Slides for Node.js via .NET não tem sua própria referência de API. O pacote expõe as classes do Aspose.Slides for .NET para JavaScript com os mesmos nomes, com nomes de membros em camelCase, de modo que a [Referência de API do Aspose.Slides para .NET](https://reference.aspose.com/slides/pt/net/) documenta suas classes, membros e enumerações.

## **Mapeamento de Nomes .NET para JavaScript**

Para usar um membro que você encontra na referência de API .NET, aplique estas regras:

- **Classes e enumerações mantêm seus nomes .NET**, assim como os valores de enumeração: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Importe‑os do pacote: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **Propriedades e métodos começam com letra minúscula.** `Presentation.Slides` torna‑se `presentation.slides` e `ShapeCollection.AddAutoShape` torna‑se `shapes.addAutoShape`. As propriedades permanecem propriedades: você as lê e atribui sem parênteses.
- **Itens de coleções são lidos com `get(index)`**, e o número de itens com `count`: `presentation.slides.get(0)` em vez de `presentation.Slides[0]`.
- **Algumas sobrecargas recebem nomes diferentes.** Por exemplo, a sobrecarga `Slide.GetImage(Size)` é `slide.getImageWithImageSize({ width, height })`. Outras compartilham um único método com argumentos opcionais adicionais: `presentation.save(path, format, options, slides)` cobre várias sobrecargas de `Presentation.Save`, e `new Presentation(null, buffer)` abre uma apresentação a partir de um `Buffer`. Cada classe está em um arquivo na pasta `lib` do pacote (por exemplo, `node_modules/aspose.slides.via.net/lib/Slide.js`), onde você pode consultar os nomes exatos.
- **Libere apresentações com `dispose`** quando terminar de usá‑las; o JavaScript não possui a instrução `using`.

O pacote não encapsula todos os membros .NET. Se um membro da referência de API .NET estiver ausente no arquivo da classe, ele não estará disponível em JavaScript.

## **Exemplo**

O script a seguir usa as regras acima. Cada comentário mostra a chamada .NET que a linha seguinte corresponde. Ele adiciona um retângulo com texto ao primeiro slide, renderiza o slide como uma imagem PNG de 960 × 540 pixels e salva a apresentação como PDF. Execute‑o a partir de uma pasta de projeto onde o pacote está instalado conforme descrito em [Instalação](/slides/pt/nodejs-net/installation/).

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

O script grava `slide.png` e `slide.pdf` na pasta atual. Ambos exibem o retângulo com seu texto. Sem uma licença, eles também exibem uma marca d'água de avaliação; veja [Licenciamento](/slides/pt/nodejs-net/licensing/).

Para detalhes sobre os membros usados aqui, veja [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/pt/net/aspose.slides/textframe/text/) e [Slide.GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/getimage/) na referência de API do Aspose.Slides para .NET.