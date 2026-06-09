---
title: Perguntas frequentes
type: docs
weight: 340
url: /pt/cpp/faqs/
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
- C++
- Aspose.Slides
description: "Obtenha respostas às perguntas frequentes sobre Aspose.Slides para C++, abrangendo suporte a PowerPoint e OpenDocument, orientações de instalação, licenciamento e resolução de problemas."
---
## **Visão geral**

Esta FAQ fornece respostas para perguntas comuns sobre Aspose.Slides. Ela cobre formatos de arquivo suportados, tratamento de exceções ao trabalhar com apresentações grandes, alteração de tamanhos de slides, visualização de slides, recuperação de texto de apresentações, formatação de bordas de tabelas, posicionamento de imagens e resolução de problemas relacionados a fontes ao converter apresentações para PDF ou imagens.

## **Formatos de Arquivo Suportados**

**Q: Quais formatos de arquivo o Aspose.Slides para C++ suporta?**

**A**: O Aspose.Slides para C++ suporta os formatos de arquivo descritos em [Formatos de Arquivo Suportados](/slides/pt/cpp/supported-file-formats/).

## **Exceções**

**Q: Estou recebendo uma exceção de falta de memória ao carregar um arquivo PPT grande com imagens. Existe alguma limitação no Aspose.Slides em relação ao tamanho do arquivo?**

**A**: Não há uma fórmula específica para calcular o tamanho da apresentação suportado pelo Aspose.Slides. Deve haver espaço suficiente para acomodar toda a estrutura da apresentação e as imagens na memória. Normalmente, as imagens na memória ocupam mais espaço que no disco rígido, especialmente quando possuem efeitos adicionais.

Em geral, o Aspose.Slides para C++ pode manipular facilmente arquivos de apresentação de aproximadamente 300 MB em um servidor com 4 GB de RAM.

## **Trabalhando com Slides**

**Q: Posso alterar o tamanho dos slides em uma apresentação?**

**A**: Você pode usar o método `get_SlideSize` exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) para definir o tamanho dos slides em uma apresentação.

**Q: Existe uma maneira de definir slides de tamanho diferente em uma apresentação?**

**A**: Como o tamanho dos slides é definido ao nível da apresentação nos documentos do Microsoft PowerPoint, não há como fazer isso.

**Q: O Aspose.Slides para C++ suporta a visualização de um slide antes de salvá-lo?**

**A**: Você pode renderizar os slides da apresentação em imagens e usar essas imagens para pré‑visualizar os slides.

## **Trabalhando com Texto**

**Q: É possível recuperar todo o texto de uma apresentação?**

**A**: O Aspose.Slides para C++ fornece a classe [SlideUtil](https://reference.aspose.com/slides/pt/cpp/aspose.slides.util/slideutil/) no namespace `Aspose::Slides::Util` que oferece vários métodos para recuperar todo o texto das apresentações.

**Q: Por que os tamanhos de parágrafo são diferentes nos sistemas operacionais Windows e Linux?**

**A**: O cálculo dos tamanhos de parágrafo baseia‑se no cálculo do tamanho do texto que representa o parágrafo dado. O cálculo do tamanho do texto depende das métricas da fonte especificada na apresentação do PowerPoint. Se a fonte especificada estiver ausente, ela será substituída pela fonte mais semelhante, mas essa fonte possui métricas diferentes das originais. Como resultado, o cálculo dos tamanhos de parágrafo em sistemas diferentes produz resultados diferentes, dependendo do conjunto de fontes instaladas. Para obter o mesmo resultado em diferentes sistemas operacionais, é necessário instalar as mesmas fontes nos sistemas ou carregá‑las em tempo de execução como [fontes externas](/slides/pt/cpp/custom-font/).

## **Formatação e Imagens**

**Q: Como posso definir a cor da borda de uma tabela?**

**A**: Você pode alterar a cor de todas as bordas da tabela ou apenas da borda ao redor da tabela inteira. Para alterar todas as bordas, use o método `get_CellFormat` da interface [ICell](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icell/). Para a borda da tabela inteira, itere pelas células e altere a cor das bordas externas.

**Q: Qual medida o Aspose.Slides para C++ usa para posicionar imagens?**

**A**: As coordenadas e tamanhos de todas as formas nos slides são medidos em pontos (72 dpi).

## **Trabalhando com Fontes**

**Q: Ao converter PPT para PDF ou imagens, por que as fontes são diferentes nos documentos de saída?**

**A**: Esse problema pode indicar que as fontes usadas na apresentação estão ausentes no sistema operacional onde o código foi executado. Você deve instalar as fontes no sistema operacional ou carregá‑las como fontes externas usando a classe [FontsLoader](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsloader/) conforme mostrado abaixo:
```cpp
auto folders = MakeObject<Array<String>>(1, "path_to_a_folder_with_fonts");
FontsLoader::LoadExternalFonts(folders);
```