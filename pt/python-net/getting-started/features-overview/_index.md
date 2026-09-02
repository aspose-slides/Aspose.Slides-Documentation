---
title: Visão Geral dos Recursos
type: docs
weight: 20
url: /pt/python-net/features-overview/
keywords:
- recursos
- plataformas suportadas
- formato de arquivo
- conversão
- renderização
- formatação
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Descubra o Aspose.Slides for Python via .NET: uma API poderosa para criar, editar, automatizar e converter apresentações PowerPoint e OpenDocument de forma eficiente."
---
## **Plataformas Suportadas**
As plataformas Aspose.Slides for Python via .NET podem ser usadas no Windows x64 ou x86 e em uma ampla variedade de distribuições Linux com Python 3.5 ou posterior instalado. Existem requisitos adicionais para a plataforma Linux de destino:
- Bibliotecas de tempo de execução GCC-6 (ou posterior)
- Dependências do .NET Core Runtime. A instalação do próprio .NET Core Runtime NÃO é necessária
- Para Python 3.5-3.7: É necessário o build `pymalloc` do Python. A opção de compilação `--with-pymalloc` do Python está habilitada por padrão. Normalmente, o build `pymalloc` do Python tem o sufixo `m` no nome do arquivo.
- `libpython` biblioteca Python compartilhada. A opção de compilação `--enable-shared` do Python está desativada por padrão; algumas distribuições Python não contêm a biblioteca compartilhada `libpython`. Em algumas plataformas Linux, a biblioteca compartilhada `libpython` pode ser instalada usando o gerenciador de pacotes, por exemplo: `sudo apt-get install libpython3.7`. O problema comum é que a biblioteca `libpython` é instalada em um local diferente do local padrão do sistema para bibliotecas compartilhadas. O problema pode ser resolvido usando as opções de compilação do Python para definir caminhos alternativos de biblioteca ao compilar o Python, ou criando um link simbólico para o arquivo da biblioteca `libpython` no local padrão do sistema para bibliotecas compartilhadas. Normalmente, o nome do arquivo da biblioteca compartilhada `libpython` é `libpythonX.Ym.so.1.0` para Python 3.5-3.7, ou `libpythonX.Y.so.1.0` para Python 3.8 ou posterior (por exemplo: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Se precisar de suporte para mais plataformas, procure os produtos “gêmeos” Aspose.Slides for .NET ou Aspose.Slides for Java.

## **Formatos de Arquivo e Conversões**
O Aspose.Slides for Python via .NET suporta a maioria dos formatos de documento do PowerPoint. Ele também permite exportá‑los para os formatos populares que as organizações usam amplamente e trocam entre si. Veja os detalhes a seguir:

|**Recurso**|**Descrição**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/pt/python-net/ppt-vs-pptx/)|O Aspose.Slides for Python via .NET fornece o processamento mais rápido para este formato de documento de apresentação.|
|[Conversão de PPT para PPTX](/slides/pt/python-net/convert-ppt-to-pptx/)|O Aspose.Slides for Python via .NET suporta a conversão de PPT para PPTX.|
|[Formato de Documento Portátil (PDF)](/slides/pt/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|É possível exportar todos os formatos de arquivo suportados para documentos Adobe Portable Document Format (PDF) com um único método.|
|[Especificação XML Parser (XPS)](https://docs.aspose.com/slides/pt/python-net/convert-powerpoint-to-xps/)|É possível exportar todos os formatos de arquivo suportados para documentos XML Parser Specification (XPS) com um único método.|
|[Formato de Arquivo de Imagem Etiquetada (TIFF)](/slides/pt/python-net/convert-powerpoint-to-tiff/)|É possível exportar todos os formatos de arquivo de apresentação suportados para Tagged Image File Format (TIFF).|
|[Conversão de PPTX para HTML](https://docs.aspose.com/slides/pt/python-net/convert-powerpoint-to-html/)|O Aspose.Slides for Python via .NET suporta a conversão de PresentationEx para o formato HTML.|

## **Renderização de Apresentação**
O Aspose.Slides for Python via .NET suporta renderização de alta fidelidade dos slides nos documentos de apresentação para vários formatos gráficos. Veja os detalhes a seguir:

|**Recurso**|**Descrição**|
| :- | :- |
|Formatos de Imagem Compatíveis com .NET|Com Aspose.Slides for Python via .NET, você pode renderizar slides de apresentação e imagens nos slides para todos os formatos gráficos compatíveis com .NET, como TIFF, PNG, BMP, JPEG, GIF e metafiles.|
|Formato SVG|O Aspose.Slides for Python via .NET também fornece métodos internos que permitem exportar slides de apresentação para formatos Scalable Vector Graphics (SVG).|

## **Recursos de Conteúdo**
O Aspose.Slides for Python via .NET permite acessar, modificar ou criar quase todos os itens ou conteúdos de documentos de apresentação. Veja os detalhes a seguir:

|**Recurso**|**Descrição**|
| :- | :- |
|Slides Mestre|Os Slides mestre definem o layout dos slides normais. O Aspose.Slides for Python via .NET permite acessar e modificar os Slides Mestre dos documentos de apresentação.|
|Slides Normais|Com Aspose.Slides for Python via .NET, você pode criar novos slides de diferentes tipos; também pode acessar e modificar slides existentes nas apresentações.|
|Clonagem / Cópia de Slides|Existem métodos internos fornecidos pelo Aspose.Slides for Python via .NET que permitem clonar ou copiar slides existentes dentro de uma apresentação. Você também pode usar slides copiados e clonados de uma apresentação para outra. Como um slide herda seu layout do slide mestre, os métodos de clonagem internos copiam automaticamente o mestre ao clonar.|
|Gerenciamento de Seções de Slides|Métodos para organizar slides em diferentes seções dentro de uma apresentação.|
|Marcadores de Espaço e Marcadores de Texto|Você pode acessar os marcadores de espaço e marcadores de texto em um slide. Além disso, pode criar um slide com marcadores de texto do zero usando o método apropriado.|
|Cabeçalhos e Rodapés|O Aspose.Slides for Python via .NET facilita o tratamento de cabeçalhos/rodapés em slides.|
|Anotações em Slides|Com Aspose.Slides for Python via .NET, você pode acessar e modificar notas associadas a um slide e também adicionar novas notas.|
|Encontrar uma Forma|Você também pode encontrar uma forma específica em um slide usando o texto alternativo associado à forma.|
|Fundos|O Aspose.Slides for Python via .NET permite trabalhar com fundos associados a um slide mestre ou normal em uma apresentação.|
|Caixas de Texto|Caixas de texto podem ser criadas do zero. Você pode acessar caixas de texto existentes. Também pode modificar seus textos sem perder a formatação original.|
|Formas de Retângulo|Você pode criar ou modificar formas de retângulo com Aspose.Slides for Python via .NET.|
|Formas de Polilinha|Você pode criar ou modificar formas de polilinha com Aspose.Slides for Python via .NET.|
|Formas de Elipse|Você pode criar ou modificar formas de Elipse com Aspose.Slides for Python via .NET.|
|Formas Agrupadas|O Aspose.Slides for Python via .NET suporta formas agrupadas.|
|Formas Automáticas|O Aspose.Slides for Python via .NET suporta formas automáticas.|
|SmartArt|O Aspose.Slides for Python via .NET oferece suporte a formas SmartArt no MS PowerPoint.|
|Gráficos|O Aspose.Slides for Python via .NET fornece suporte a gráficos MSO no PowerPoint.|
|Serialização de Formas|O Aspose.Slides for Python via .NET suporta um grande número de formas. Quando o Aspose.Slides for Python via .NET não possui suporte para uma forma, você pode usar um método de serialização que permite serializar essa forma a partir de um slide existente. Dessa forma, você pode reutilizar a forma conforme necessário.|
|Quadros de Imagem|Você pode gerenciar imagens em quadros de imagem com Aspose.Slides for Python via .NET.|
|Quadros de Áudio|Você pode vincular ou incorporar arquivos de áudio em quadros de áudio nos slides com Aspose.Slides for Python via .NET.|
|Quadros de Vídeo|Você pode manipular arquivos de vídeo em quadros de vídeo. O Aspose.Slides for Python via .NET também fornece suporte a vídeos vinculados e incorporados.|
|Quadro OLE|Você pode gerenciar objetos OLE em quadros OLE com Aspose.Slides for Python via .NET.|
|Tabelas|O Aspose.Slides for Python via .NET suporta tabelas em slides.|
|Controles ActiveX|Suporte para controles ActiveX.|
|Macros VBA|Suporte para gerenciamento de macros VBA dentro de apresentações.|
|Quadro de Texto|Você pode acessar o texto de qualquer forma por meio do quadro de texto associado a essa forma.|
|Digitalização de Texto|Você pode digitalizar texto em uma apresentação a nível de apresentação ou de slide por meio de métodos internos de digitalização.|
|Animações|Você pode aplicar animações em formas.|
|Apresentações de Slides|O Aspose.Slides for Python via .NET suporta apresentações de slides e transições de slides.|

## **Recursos de Formatação**
Com Aspose.Slides for Python via .NET, você pode formatar textos e formas em slides de apresentações. Veja os detalhes a seguir:

|**Recurso**|**Descrição**|
| :- | :- |
|Formatação de Texto|<p>No Aspose.Slides for Python via .NET, você pode gerenciar textos através dos quadros de texto associados às formas. Assim, você pode formatar textos usando os parágrafos e trechos associados aos quadros de texto. Esses elementos de texto podem ser formatados através do Aspose.Slides for Python via .NET.</p><p>- Tipo de Fonte</p><p>- Tamanho da Fonte</p><p>- Cor da Fonte</p><p>- Tons da Fonte</p><p>- Alinhamento de Parágrafo</p><p>- Marcadores de Parágrafo</p><p>- Orientação de Parágrafo</p>|
|Formatação de Forma|<p>No Aspose.Slides for Python via .NET, o elemento básico de um slide é uma forma. Você pode formatar esses elementos de forma com Aspose.Slides for Python via .NET:</p><p>- Posição</p><p>- Tamanho</p><p>- Linha</p><p>- Preenchimento (incluindo Padrão, Gradiente, Sólido)</p><p>- Texto</p><p>- Imagem</p>|

## **Perguntas Frequentes**

### Preciso instalar o Microsoft PowerPoint no servidor/PC para que a biblioteca funcione?
Não. O PowerPoint não é necessário; o Aspose.Slides é um mecanismo independente para criar, editar, converter e renderizar apresentações.

### Como o multithreading funciona? O processamento pode ser paralelizado?
É seguro processar documentos diferentes em threads diferentes; o mesmo [apresentação](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) objeto não deve ser usado por [várias threads](/slides/pt/python-net/multithreading/) ao mesmo tempo.

### Senhas de arquivos e criptografia são suportadas?
Sim. [Você pode](/slides/pt/python-net/password-protected-presentation/) abrir apresentações criptografadas, definir ou remover uma senha de abertura e gravação, e verificar o status de proteção.

### Preciso me preocupar com pacotes de fontes em contêineres Linux?
Sim. É recomendável instalar pacotes de fontes comuns e/ou especificar explicitamente [diretórios de fontes](/slides/pt/python-net/custom-font/) em sua aplicação para evitar substituições inesperadas.

### Existem limitações na versão de avaliação?
Em [modo de avaliação](/slides/pt/python-net/licensing/), uma marca d'água é adicionada à saída e certas limitações se aplicam; uma [licença temporária de 30 dias](https://purchase.aspose.com/temporary-license/) está disponível para testes com todos os recursos.

### A importação de formatos externos para uma apresentação (PDF/HTML → PPTX) é suportada?
Sim. Você pode adicionar [páginas PDF e conteúdo HTML](/slides/pt/python-net/import-presentation/) a uma apresentação, convertendo‑os em slides.