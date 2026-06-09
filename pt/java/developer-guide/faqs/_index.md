---
title: FAQ
type: docs
weight: 340
url: /pt/java/faqs/
keywords:
- FAQ
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
- Java
- Aspose.Slides
description: "Obtenha respostas às perguntas frequentes sobre Aspose.Slides para Java, abrangendo suporte a PowerPoint e OpenDocument, orientações de instalação, licenciamento e solução de problemas."
---
## **Visão geral**

Esta FAQ fornece respostas às perguntas mais comuns sobre o Aspose.Slides. Ela cobre formatos de arquivo suportados, tratamento de exceções ao trabalhar com apresentações grandes, alteração de tamanhos de slides, visualização de slides, recuperação de texto de apresentações, formatação de bordas de tabelas, inserção de imagens e resolução de problemas relacionados a fontes ao converter apresentações para PDF ou imagens.

## **Formatos de arquivo suportados**

**Q: Quais formatos de arquivo o Aspose.Slides for Java suporta?**

**A**: Aspose.Slides for Java suporta os formatos de arquivo descritos em [Formatos de arquivo suportados](/slides/pt/java/supported-file-formats/).

## **Exceções**

**Q: Estou recebendo uma exceção de falta de memória ao carregar um arquivo PPT grande com imagens. Existe alguma limitação no Aspose.Slides em relação ao tamanho do arquivo?**

**A**: Não existe uma fórmula específica para calcular o tamanho de apresentação suportado pelo Aspose.Slides. Deve haver espaço suficiente para acomodar toda a estrutura da apresentação e as imagens na memória. Normalmente, as imagens na memória ocupam mais espaço do que no disco rígido, especialmente quando possuem efeitos adicionais.

Em geral, o Aspose.Slides for Java pode lidar facilmente com arquivos de apresentação de aproximadamente 300 MB em um servidor com 4 GB de RAM.

## **Trabalhando com slides**

**Q: Posso alterar o tamanho dos slides em uma apresentação?**

**A**: Você pode usar o método `getSlideSize` exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) para definir o tamanho dos slides em uma apresentação.

**Q: Existe uma maneira de definir slides de tamanho diferente em uma apresentação?**

**A**: Como o tamanho dos slides é definido a nível de apresentação nos documentos do Microsoft PowerPoint, não há como fazer isso.

**Q: O Aspose.Slides for Java suporta a pré-visualização de um slide antes de salvar?**

**A**: Você pode renderizar os slides da apresentação em imagens e usar essas imagens para pré-visualizar os slides.

## **Trabalhando com texto**

**Q: É possível recuperar todo o texto de uma apresentação?**

**A**: O Aspose.Slides for Java fornece a classe [SlideUtil](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slideutil/) que oferece vários métodos para recuperar todo o texto das apresentações.

**Q: Por que os tamanhos de parágrafo são diferentes nos sistemas operacionais Windows e Linux?**

**A**: O cálculo dos tamanhos de parágrafo baseia‑se no cálculo do tamanho do texto que representa o parágrafo em questão. O cálculo do tamanho do texto utiliza as métricas da fonte especificada na apresentação do PowerPoint. Se a fonte especificada estiver ausente, ela é substituída pela fonte mais semelhante, mas essa fonte tem métricas diferentes das originais. Como resultado, o cálculo dos tamanhos de parágrafo em diferentes sistemas produzirá resultados distintos, dependendo do conjunto de fontes instaladas. Para obter o mesmo resultado em diferentes sistemas operacionais, é necessário instalar as mesmas fontes nos sistemas ou carregá‑las em tempo de execução como [fonte externa](/slides/pt/java/custom-font/).

## **Formatação e imagens**

**Q: Como posso definir a cor da borda de uma tabela?**

**A**: Você pode alterar a cor de todas as bordas da tabela ou apenas da borda ao redor de toda a tabela. Para alterar todas as bordas, use o método `getCellFormat` da interface [ICell](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icell/). Para a borda de toda a tabela, você deve percorrer as células e mudar a cor das bordas externas.

**Q: Qual medida o Aspose.Slides for Java usa para posicionar imagens?**

**A**: As coordenadas e tamanhos de todas as formas nos slides são medidos em pontos (72 dpi).

## **Trabalhando com fontes**

**Q: Ao converter PPT para PDF ou imagens, por que as fontes são diferentes nos documentos de saída?**

**A**: Este problema pode indicar que as fontes usadas na apresentação estão ausentes no sistema operacional onde o código foi executado. Você deve instalar as fontes no sistema operacional ou carregá‑las como fontes externas usando a classe [FontsLoader](https://reference.aspose.com/slides/pt/java/com.aspose.slides/fontsloader/) conforme mostrado abaixo:
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```