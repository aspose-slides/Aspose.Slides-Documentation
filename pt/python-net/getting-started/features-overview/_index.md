---
title: Visão Geral de Recursos
type: docs
weight: 20
url: /pt/python-net/features-overview/
keywords:
- recursos
- plataformas suportadas
- formato de arquivo
- conversão
- renderização
- impressão
- formatação
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Descubra Aspose.Slides for Python via .NET: uma API poderosa para criar, editar, automatizar e converter apresentações PowerPoint e OpenDocument de forma eficiente."
---
## **Plataformas Suportadas**
As plataformas Aspose.Slides for Python via .NET podem ser usadas no Windows x64 ou x86 e em uma ampla variedade de distribuições Linux com Python 3.5 ou posterior instalado. Há requisitos adicionais para a plataforma Linux alvo:
- Bibliotecas de tempo de execução GCC-6 (ou posterior)
- Dependências do .NET Core Runtime. A instalação do .NET Core Runtime em si NÃO é necessária
- Para Python 3.5-3.7: é necessário o build `pymalloc` do Python. A opção de build `--with-pymalloc` está habilitada por padrão. Normalmente, o build `pymalloc` do Python é marcado com o sufixo `m` no nome do arquivo.
- Biblioteca compartilhada `libpython`. A opção de build `--enable-shared` está desativada por padrão; algumas distribuições Python não contêm a biblioteca compartilhada `libpython`. Em algumas plataformas Linux, a biblioteca `libpython` pode ser instalada via gerenciador de pacotes, por exemplo: `sudo apt-get install libpython3.7`. O problema comum é que a biblioteca `libpython` é instalada em um local diferente do local padrão do sistema para bibliotecas compartilhadas. O problema pode ser resolvido usando as opções de build do Python para definir caminhos alternativos de biblioteca ao compilar o Python, ou criando um link simbólico para o arquivo da biblioteca `libpython` no local padrão do sistema. Normalmente, o nome do arquivo da biblioteca compartilhada `libpython` é `libpythonX.Ym.so.1.0` para Python 3.5-3.7, ou `libpythonX.Y.so.1.0` para Python 3.8 ou posterior (por exemplo: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Se precisar de suporte para mais plataformas, procure os produtos “irmãos gêmeos” Aspose.Slides for .NET ou Aspose.Slides for Java.

## **Formatos de Arquivo e Conversões**
Aspose.Slides for Python via .NET suporta a maioria dos formatos de documentos PowerPoint. Também permite exportá-los para os formatos populares que as organizações usam amplamente e trocam entre si. Veja os detalhes:

|**Recurso**|**Descrição**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/pt/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET fornece o processamento mais rápido para este formato de documento de apresentação.|
|[Conversão de PPT para PPTX](/slides/pt/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET suporta a conversão de PPT para PPTX.|
|[Portable Document Format (PDF)](/slides/pt/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Você pode exportar todos os formatos de arquivo suportados para documentos Adobe Portable Document Format (PDF) com um único método.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/pt/python-net/convert-powerpoint-to-xps/)|Você pode exportar todos os formatos de arquivo suportados para documentos XML Parser Specification (XPS) com um único método.|
|[Tagged Image File Format (TIFF)](/slides/pt/python-net/convert-powerpoint-to-tiff/)|Você pode exportar todos os formatos de apresentação suportados para Tagged Image File Format (TIFF).|
|[Conversão de PPTX para HTML](/slides/pt/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET suporta a conversão de PresentationEx para o formato HTML.|

## **Renderização e Impressão**
Aspose.Slides for Python via .NET suporta renderização de alta fidelidade de slides nos documentos de apresentação para vários formatos gráficos. Veja os detalhes:

|**Recurso**|**Descrição**|
| :- | :- |
|Formatos de Imagem Compatíveis com .NET|Com Aspose.Slides for Python via .NET, você pode renderizar slides de apresentação e imagens nos slides para todos os formatos gráficos suportados pelo .NET, como TIFF, PNG, BMP, JPEG, GIF e metafiles.|
|Formato SVG|Aspose.Slides for Python via .NET também fornece métodos integrados que permitem exportar slides de apresentação para formatos Scalable Vector Graphics (SVG).|
|Impressão de Apresentação|As versões mais recentes de Aspose.Slides for Python via .NET fornecem métodos de impressão integrados com diferentes opções.|

## **Recursos de Conteúdo**
Aspose.Slides for Python via .NET permite acessar, modificar ou criar quase todos os itens ou conteúdos de documentos de apresentação. Veja os detalhes:

|**Recurso**|**Descrição**|
| :- | :- |
|Slides Mestre|Os Slides Mestre definem o layout dos slides normais. Aspose.Slides for Python via .NET permite acessar e modificar os Slides Mestre dos documentos de apresentação.|
|Slides Normais|Com Aspose.Slides for Python via .NET, você pode criar novos slides de diferentes tipos; também pode acessar e modificar slides existentes nas apresentações.|
|Clonagem / Copiando Slides|Existem métodos integrados fornecidos por Aspose.Slides for Python via .NET que permitem clonar ou copiar slides existentes dentro de uma apresentação. Você também pode usar slides copiados e clonados de uma apresentação para outra. Como um slide herda seu layout do slide mestre, os métodos de clonagem incorporados copiam automaticamente o mestre ao clonar.|
|Gerenciando Seções de Slides|Métodos para organizar slides em diferentes seções dentro de uma apresentação.|
|Espaços Reservados e Espaços de Texto|Você pode acessar os espaços reservados e espaços de texto em um slide. Além disso, pode criar um slide com espaços de texto do zero usando o método adequado.|
|Cabeçalhos e Rodapés|Aspose.Slides for Python via .NET facilita o manuseio de cabeçalhos/rodapés em slides.|
|Anotações nos Slides|Com Aspose.Slides for Python via .NET, você pode acessar e modificar anotações associadas a um slide e também adicionar novas anotações.|
|Encontrando uma Forma|Você também pode encontrar uma forma específica em um slide usando o texto alternativo associado à forma.|
|Fundos|Aspose.Slides for Python via .NET permite trabalhar com fundos associados a um slide mestre ou normal em uma apresentação.|
|Caixas de Texto|Caixas de texto podem ser criadas do zero. Você pode acessar caixas de texto existentes. Também pode modificar seus textos sem perder o formato original.|
|Formas de Retângulo|Você pode criar ou modificar formas de retângulo com Aspose.Slides for Python via .NET.|
|Formas de Linha Poligonal|Você pode criar ou modificar formas de linha poligonal com Aspose.Slides for Python via .NET.|
|Formas de Elipse|Você pode criar ou modificar formas de elipse com Aspose.Slides for Python via .NET.|
|Formas Agrupadas|Aspose.Slides for Python via .NET suporta formas agrupadas.|
|Formas Automáticas|Aspose.Slides for Python via .NET suporta formas automáticas.|
|SmartArt|Aspose.Slides for Python via .NET fornece suporte para formas SmartArt no MS PowerPoint.|
|Gráficos|Aspose.Slides for Python via .NET fornece suporte para Gráficos MSO no PowerPoint.|
|Serialização de Formas|Aspose.Slides for Python via .NET suporta um grande número de formas. Quando Aspose.Slides for Python via .NET não oferece suporte a uma forma, você pode usar um método de serialização que permite serializar essa forma de um slide existente. Dessa forma, você pode reutilizar a forma conforme suas necessidades.|
|Molduras de Imagem|Você pode gerenciar imagens em molduras de imagem com Aspose.Slides for Python via .NET.|
|Molduras de Áudio|Você pode vincular ou incorporar arquivos de áudio em molduras de áudio nos slides com Aspose.Slides for Python via .NET.|
|Molduras de Vídeo|Você pode manipular arquivos de vídeo em molduras de vídeo. Aspose.Slides for Python via .NET também fornece suporte para vídeos vinculados e incorporados.|
|Moldura OLE|Você pode gerenciar objetos OLE em molduras OLE com Aspose.Slides for Python via .NET.|
|Tabelas|Aspose.Slides for Python via .NET suporta tabelas em slides.|
|Controles ActiveX|Suporte a controles ActiveX.|
|Macros VBA|Suporte ao gerenciamento de macros VBA dentro de apresentações.|
|Quadro de Texto|Você pode acessar o texto de qualquer forma através do quadro de texto associado a essa forma.|
|Digitalização de Texto|Você pode digitalizar texto em uma apresentação no nível da apresentação ou do slide por meio de métodos de digitalização integrados.|
|Animações|Você pode aplicar animações em formas.|
|Apresentações de Slides|Aspose.Slides for Python via .NET suporta apresentações de slides e transições de slides.|

## **Recursos de Formatação**
Com Aspose.Slides for Python via .NET, você pode formatar textos e formas em slides de apresentações. Veja os detalhes:

|**Recurso**|**Descrição**|
| :- | :- |
|Formatação de Texto|<p>No Aspose.Slides for Python via .NET, você pode gerenciar textos por meio dos quadros de texto associados às formas. Assim, você pode formatar textos usando os parágrafos e porções associados aos quadros de texto. Esses elementos de texto podem ser formatados através do Aspose.Slides for Python via .NET.</p><p>- Tipo de Fonte</p><p>- Tamanho da Fonte</p><p>- Cor da Fonte</p><p>- Tons da Fonte</p><p>- Alinhamento de Parágrafo</p><p>- Marcadores de Parágrafo</p><p>- Orientação de Parágrafo</p>|
|Formatação de Forma|<p>No Aspose.Slides for Python via .NET, o elemento básico de um slide é uma forma. Você pode formatar esses elementos de forma com Aspose.Slides for Python via .NET:</p><p>- Posição</p><p>- Tamanho</p><p>- Linha</p><p>- Preenchimento (incluindo Padrão, Gradiente, Sólido)</p><p>- Texto</p><p>- Imagem</p>|

## **Perguntas Frequentes**

**Preciso instalar o Microsoft PowerPoint no servidor/PC para que a biblioteca funcione?**

Não. O PowerPoint não é necessário; Aspose.Slides é um motor autônomo para criar, editar, converter e renderizar apresentações.

**Como o multithreading funciona? O processamento pode ser paralelizado?**

É seguro processar documentos diferentes em threads diferentes; o mesmo [apresentação](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) não deve ser usado por [múltiplas threads](/slides/pt/python-net/multithreading/) ao mesmo tempo.

**São suportadas senhas de arquivo e criptografia?**

Sim. [Você pode](/slides/pt/python-net/password-protected-presentation/) abrir apresentações criptografadas, definir ou remover senha de abertura e gravação, e verificar o status da proteção.

**Preciso me preocupar com pacotes de fontes em contêineres Linux?**

Sim. É recomendado instalar pacotes de fontes comuns e/ou [especificar diretórios de fontes](/slides/pt/python-net/custom-font/) explicitamente em sua aplicação para evitar substituições inesperadas.

**Existem limitações na versão de avaliação?**

No [modo de avaliação](/slides/pt/python-net/licensing/), uma marca d'água é adicionada à saída e certas limitações se aplicam; uma [licença temporária de 30 dias](https://purchase.aspose.com/temporary-license/) está disponível para testes completos de recursos.

**É suportada a importação de formatos externos para uma apresentação (PDF/HTML → PPTX)?**

Sim. Você pode adicionar [páginas PDF e conteúdo HTML](/slides/pt/python-net/import-presentation/) a uma apresentação, transformando-os em slides.