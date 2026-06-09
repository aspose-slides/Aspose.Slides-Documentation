---
title: Perguntas frequentes
type: docs
weight: 340
url: /pt/python-net/faq/
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
- Python
- Aspose.Slides
description: "Obtenha respostas para perguntas frequentes sobre Aspose.Slides for Python via .NET, cobrindo suporte a PowerPoint e OpenDocument, orientações de instalação, licenciamento e solução de problemas."
---
## **Visão geral**

Este FAQ fornece respostas às perguntas comuns sobre Aspose.Slides. Ele aborda formatos de arquivo suportados, tratamento de exceções ao trabalhar com apresentações grandes, alteração de tamanhos de slides, visualização de slides, recuperação de texto de apresentações, formatação de bordas de tabelas, inserção de imagens e resolução de problemas relacionados a fontes ao converter apresentações para PDF ou imagens.

## **Formatos de Arquivo Compatíveis**

**Q: Quais formatos de arquivo o Aspose.Slides for Python via .NET suporta?**

**A**: O Aspose.Slides for Python via .NET suporta os formatos de arquivo descritos em [Formatos de Arquivo Compatíveis](/slides/pt/python-net/supported-file-formats/).

## **Exceções**

**Q: Estou recebendo uma exceção de falta de memória ao carregar um arquivo PPT grande com imagens. Há alguma limitação no Aspose.Slides em relação ao tamanho do arquivo?**

**A**: Não existe uma fórmula específica para calcular o tamanho da apresentação suportado pelo Aspose.Slides. Deve haver espaço suficiente para acomodar toda a estrutura da apresentação e as imagens na memória. Normalmente, as imagens na memória ocupam mais espaço do que no disco rígido, especialmente quando as imagens têm efeitos adicionais.

Em geral, o Aspose.Slides for Python via .NET pode manipular facilmente arquivos de apresentação de aproximadamente 300 MB em um servidor com 4 GB RAM.

## **Trabalhando com Slides**

**Q: Posso alterar o tamanho dos slides em uma apresentação?**

**A**: Você pode usar a propriedade `slide_size` exposta pela classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) para definir o tamanho dos slides em uma apresentação.

**Q: Há alguma forma de definir slides de tamanho diferente em uma apresentação?**

**A**: Como o tamanho dos slides é definido no nível da apresentação em documentos do Microsoft PowerPoint, não há como fazer isso.

**Q: O Aspose.Slides for Python via .NET suporta a visualização de um slide antes de salvar?**

**A**: Você pode renderizar os slides da apresentação em imagens e usar essas imagens para visualizar os slides.

## **Trabalhando com Texto**

**Q: É possível recuperar todo o texto de uma apresentação?**

**A**: O Aspose.Slides for Python via .NET fornece a classe [SlideUtil](https://reference.aspose.com/slides/pt/python-net/aspose.slides.util/slideutil/) no namespace `aspose.slides.util`, que oferece vários métodos para recuperar todo o texto das apresentações.

**Q: Por que os tamanhos dos parágrafos são diferentes nos sistemas operacionais Windows e Linux?**

**A**: O cálculo dos tamanhos dos parágrafos baseia-se no cálculo do tamanho do texto que representa o respectivo parágrafo. O cálculo do tamanho do texto utiliza as métricas da fonte especificada na apresentação do PowerPoint. Se a fonte especificada estiver ausente, ela é substituída pela fonte mais semelhante, mas essa fonte possui métricas diferentes das originais. Como resultado, o cálculo dos tamanhos dos parágrafos em sistemas diferentes produzirá resultados distintos, dependendo do conjunto de fontes instaladas. Para obter o mesmo resultado em diferentes sistemas operacionais, é necessário instalar as mesmas fontes nos sistemas ou carregá‑las em tempo de execução como [fontes externas](/slides/pt/python-net/custom-font/).

## **Formatação e Imagens**

**Q: Como posso definir a cor da borda de uma tabela?**

**A**: Você pode alterar a cor de todas as bordas da tabela ou apenas a borda ao redor de toda a tabela. Para alterar todas as bordas, use a propriedade `cell_format` da classe [Cell](https://reference.aspose.com/slides/pt/python-net/aspose.slides/cell/). Para a borda da tabela inteira, você deve iterar pelas células e mudar a cor das bordas externas.

**Q: Qual medida o Aspose.Slides for Python via .NET usa para posicionar imagens?**

**A**: As coordenadas e tamanhos de todas as formas nos slides são medidos em pontos (72 dpi).

## **Trabalhando com Fontes**

**Q: Ao converter PPT para PDF ou imagens, por que as fontes são diferentes nos documentos gerados?**

**A**: Esse problema pode indicar que as fontes usadas na apresentação estão ausentes no sistema operacional onde o código foi executado. Você deve instalar as fontes no sistema operacional ou carregá‑las como fontes externas usando a classe [FontsLoader](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsloader/) conforme mostrado abaixo:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```