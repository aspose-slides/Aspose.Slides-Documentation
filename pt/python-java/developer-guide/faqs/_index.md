---
title: "Perguntas Frequentes"
type: docs
weight: 340
url: /pt/python-java/faqs/
keywords:
- FAQ
- formato de apresentação
- erro de falta de memória
- tamanho de slide
- extrair texto
- tamanho de parágrafo
- bordas de tabela
- fonte
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Encontre respostas para perguntas comuns sobre Aspose.Slides para Python via Java, incluindo formatos de arquivo, uso de memória, tamanhos de slide, texto, tabelas, imagens e fontes."
---
## **Visão geral**

Esta FAQ cobre formatos de arquivo suportados, uso de memória com apresentações grandes, tamanhos e visualizações de slides, extração de texto, bordas de tabelas, posicionamento de imagens e diferenças de fontes ao converter apresentações para PDF ou imagens.

## **FAQ**

### **Formatos de Arquivo Suportados**

**Quais formatos de arquivo o Aspose.Slides for Python via Java suporta?**

Consulte [Supported File Formats](/slides/pt/python-java/supported-file-formats/) para os formatos de apresentação, documento e imagem suportados e suas capacidades de importação e exportação.

### **Exceções**

**Por que recebo um erro de falta de memória ao carregar uma apresentação grande com imagens? Existe um limite de tamanho de arquivo?**

Não existe um limite único de tamanho de arquivo que indique se uma apresentação caberá na memória. Os requisitos de memória dependem da estrutura da apresentação, das imagens descompactadas, dos efeitos e das operações que você realiza. As imagens podem ocupar muito mais memória do que seu tamanho comprimido no disco.

O Aspose.Slides for Python via Java usa o mecanismo Java através do JPype, portanto o heap da JVM deve ter espaço suficiente para o processamento. A RAM do sistema disponível por si só não indica quanta memória a JVM pode usar. Libere as apresentações com [Presentation.dispose](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#dispose) quando terminar de usá-las. Para configuração do ambiente, veja [System Requirements](/slides/pt/python-java/system-requirements/) e [Installation](/slides/pt/python-java/installation/).

### **Trabalhando com Slides**

**Posso alterar o tamanho dos slides em uma apresentação?**

Sim. Use [Presentation.getSlideSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getslidesize) para acessar as configurações de tamanho de slide da apresentação, depois use [SlideSize.setSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidesize/#setsize) para definir as dimensões e escolher como o conteúdo existente será dimensionado.

**Os slides na mesma apresentação podem ter tamanhos diferentes?**

Não. Os documentos do Microsoft PowerPoint definem o tamanho do slide ao nível da apresentação, portanto todos os slides compartilham as mesmas dimensões.

**Posso visualizar um slide antes de salvar a apresentação?**

Sim. Renderize o slide para uma imagem e exiba essa imagem em sua aplicação. Não é necessário salvar a apresentação primeiro.

### **Trabalhando com Texto**

**Posso recuperar todo o texto de uma apresentação?**

Sim. A classe [SlideUtil](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideutil/) fornece métodos para recuperar texto de apresentações e de slides individuais.

**Por que os tamanhos de parágrafo são diferentes no Windows e no Linux?**

As dimensões dos parágrafos dependem das métricas das fontes usadas para renderizar o texto. Se uma fonte estiver ausente, um substituto pode ter larguras de caractere e alturas de linha diferentes, o que altera a quebra de linha e as dimensões do parágrafo. Instale as mesmas fontes em ambos os sistemas ou carregue os mesmos arquivos de fonte com [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsloader/#loadexternalfonts) antes de criar ou carregar apresentações.

### **Formatação e Imagens**

**Como posso definir a cor da borda de uma tabela?**

Use [Cell.getCellFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/cell/#getcellformat) para acessar a formatação de borda de cada célula e definir a cor de preenchimento para as bordas relevantes. Para alterar todas as bordas, processe todas as células. Para alterar apenas o contorno da tabela, atualize somente as bordas externas das células ao longo de suas bordas.

**Quais unidades são usadas para posicionar e dimensionar imagens?**

As coordenadas e dimensões das formas são medidas em pontos. Uma polegada equivale a 72 pontos; esses valores não são coordenadas de pixel.

### **Trabalhando com Fontes**

**Por que as fontes mudam ao converter uma apresentação para PDF ou imagens?**

As fontes necessárias podem estar ausentes na máquina que realiza a conversão. Instale as fontes originais ou use [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsloader/#loadexternalfonts) para adicionar pastas que as contenham. Carregue fontes externas antes de criar ou abrir apresentações.

O exemplo abaixo registra uma pasta de fontes. Substitua o caminho por uma pasta existente que contenha seus arquivos de fonte. Ele assume o ambiente descrito em [Installation](/slides/pt/python-java/installation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

O exemplo mantém a JVM em execução para operações subsequentes de apresentação. Para uso em notebooks e restrições de ciclo de vida da JVM, veja [Limitations and API Differences](/slides/pt/python-java/limitations-and-api-differences/).