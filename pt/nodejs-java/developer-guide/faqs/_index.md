---
title: Perguntas frequentes
type: docs
weight: 340
url: /pt/nodejs-java/faqs/
keywords:
- Perguntas frequentes
- formato de apresentação
- erro de falta de memória
- tamanho do slide
- extrair texto
- recuperar texto
- tamanho do parágrafo
- formatação de tabelas
- fonte
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Obtenha respostas às perguntas frequentes sobre Aspose.Slides for Node.js via Java, abordando suporte a PowerPoint e OpenDocument, orientações de instalação, licenciamento e solução de problemas."
---
## **Visão geral**

Esta FAQ fornece respostas às perguntas mais comuns sobre Aspose.Slides. Ela aborda formatos de arquivo suportados, tratamento de exceções ao trabalhar com apresentações grandes, alteração de tamanho de slides, visualização de slides, recuperação de texto de apresentações, formatação de bordas de tabelas, posicionamento de imagens e resolução de problemas relacionados a fontes ao converter apresentações para PDF ou imagens.

## **Formatos de arquivo suportados**

**P: Quais formatos de arquivo o Aspose.Slides for Node.js via Java suporta?**

**R**: O Aspose.Slides for Node.js via Java suporta os formatos de arquivo descritos em [Formatos de arquivo compatíveis](/slides/pt/nodejs-java/supported-file-formats/).

## **Exceções**

**P: Estou recebendo uma exceção de falta de memória ao carregar um arquivo PPT grande com imagens. Existe alguma limitação no Aspose.Slides quanto ao tamanho do arquivo?**

**R**: Não há uma fórmula específica para calcular o tamanho da apresentação suportado pelo Aspose.Slides. Deve haver espaço suficiente para acomodar toda a estrutura da apresentação e as imagens na memória. Normalmente, as imagens na memória ocupam mais espaço que no disco rígido, especialmente quando as imagens têm efeitos adicionais.

Em geral, o Aspose.Slides for Node.js via Java pode lidar facilmente com arquivos de apresentação de aproximadamente 300 MB em um servidor com 4 GB de RAM.

## **Trabalhando com slides**

**P: Posso alterar o tamanho dos slides em uma apresentação?**

**R**: Você pode usar o método `getSlideSize` exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) para definir o tamanho dos slides em uma apresentação.

**P: Existe alguma forma de definir slides de tamanho diferente em uma apresentação?**

**R**: Como o tamanho dos slides é definido no nível da apresentação nos documentos do Microsoft PowerPoint, não há como fazer isso.

**P: O Aspose.Slides for Node.js via Java oferece visualização de um slide antes de salvar?**

**R**: Você pode renderizar os slides da apresentação em imagens e usar essas imagens para visualizar os slides.

## **Trabalhando com texto**

**P: É possível recuperar todo o texto de uma apresentação?**

**R**: O Aspose.Slides for Node.js via Java fornece a classe [SlideUtil](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slideutil/) que oferece vários métodos para recuperar todo o texto das apresentações.

**P: Por que os tamanhos de parágrafo são diferentes nos sistemas operacionais Windows e Linux?**

**R**: O cálculo dos tamanhos de parágrafo baseia‑se no cálculo do tamanho do texto que representa o parágrafo dado. O cálculo do tamanho do texto é baseado nas métricas da fonte especificada na apresentação do PowerPoint. Se a fonte especificada estiver ausente, ela é substituída pela fonte mais semelhante, mas essa fonte tem métricas diferentes das originais. Como resultado, o cálculo dos tamanhos de parágrafo em sistemas diferentes levará a resultados diferentes dependendo do conjunto de fontes instaladas. Para obter o mesmo resultado em diferentes sistemas operacionais, você precisa instalar as mesmas fontes nos sistemas ou carregá‑las em tempo de execução como [fontes externas](/slides/pt/nodejs-java/custom-font/).

## **Formatação e imagens**

**P: Como posso definir a cor da borda de uma tabela?**

**R**: Você pode alterar a cor de todas as bordas da tabela ou apenas a borda ao redor da tabela inteira. Para mudar todas as bordas, use o método `getCellFormat` da classe [Cell](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/cell/). Para a borda da tabela inteira, você deve iterar as células e alterar a cor das bordas externas.

**P: Qual medida o Aspose.Slides for Node.js via Java usa para posicionar imagens?**

**R**: As coordenadas e tamanhos de todas as formas nos slides são medidos em pontos (72 dpi).

## **Trabalhando com fontes**

**P: Ao converter PPT para PDF ou imagens, por que as fontes são diferentes nos documentos de saída?**

**R**: Esse problema pode indicar que as fontes usadas na apresentação estão ausentes no sistema operacional onde o código foi executado. Você deve instalar as fontes no sistema operacional ou carregá‑las como fontes externas usando a classe [FontsLoader](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsloader/) conforme mostrado abaixo:
```javascript
var folders = java.newArray("java.lang.String", ["path_to_a_folder_with_fonts"]));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", folders);
```