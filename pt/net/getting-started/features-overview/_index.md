---
title: Visão geral dos recursos
type: docs
weight: 94
url: /pt/net/features-overview/
keywords:
- recursos
- plataformas suportadas
- formatos de arquivo
- conversão
- renderização
- conteúdo de apresentação
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Revise o que o Aspose.Slides for .NET oferece antes de avaliá-lo: plataformas suportadas, formatos de arquivo, renderização de slides e o conteúdo que você pode criar e editar."
---
## **Visão geral**

Aspose.Slides for .NET é uma biblioteca de classes para criar, ler, editar, converter e renderizar apresentações PowerPoint e OpenDocument. Não possui interface de usuário própria e não requer Microsoft PowerPoint ou Office, de modo que você pode usá‑la em aplicativos de console, aplicativos de desktop como Windows Forms, aplicativos web e serviços web. Este artigo resume o que a biblioteca abrange e inclui links para os artigos que descrevem cada área.

## **Plataformas suportadas**

Aspose.Slides for .NET é distribuído como dois pacotes NuGet com a mesma API:

|**Pacote**|**Compilações no pacote**|**Sistemas operacionais**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0 e .NET 6. Use‑o com .NET Framework 4.6.2 ou posterior, ou com .NET 6 ou posterior.|Windows. Linux e macOS com a biblioteca `libgdiplus` e a opção `System.Drawing.EnableUnixSupport`.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. Use‑o com .NET 6 ou posterior.|Windows (x86, x64), Linux (x64 com glibc 2.23 ou posterior, ARM64 com glibc 2.39 ou posterior) e macOS (x64, ARM64).|

[A Instalação](/slides/pt/net/installation/) explica qual pacote escolher e o que cada um necessita no Linux. [Requisitos do sistema](/slides/pt/net/system-requirements/) lista as plataformas suportadas em detalhe.

## **Formatos de arquivo e conversões**

Aspose.Slides abre e salva apresentações PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP e PowerPoint XML. Ele importa conteúdo PDF e HTML para os slides e salva apresentações como PDF, XPS, HTML, HTML5, TIFF, GIF animado, SWF, Markdown e XAML. A [Formatos de arquivo suportados](/slides/pt/net/supported-file-formats/) lista cada formato com a API que o lê ou grava.

|**Recurso**|**Descrição**|
| :- | :- |
|[PPT e PPTX](/slides/pt/net/ppt-vs-pptx/)|Leia e grave tanto o formato binário PowerPoint 97‑2003 quanto o formato Office Open XML.|
|[Conversão de PPT para PPTX](/slides/pt/net/convert-ppt-to-pptx/)|Converta apresentações PPT legadas para PPTX.|
|[Formato de Documento Portátil (PDF)](/slides/pt/net/convert-powerpoint-to-pdf/)|Exporte apresentações para PDF, incluindo documentos PDF/A e PDF/UA.|
|[Especificação de Papel XML (XPS)](/slides/pt/net/convert-powerpoint-to-xps/)|Exporte apresentações para documentos XPS.|
|[Formato de Imagem Etiquetado (TIFF)](/slides/pt/net/convert-powerpoint-to-tiff/)|Exporte apresentações para imagens TIFF.|
|[HTML](/slides/pt/net/convert-powerpoint-to-html/)|Exporte apresentações para HTML e HTML5.|
|[Importação de PDF e HTML](/slides/pt/net/import-presentation/)|Crie slides a partir de páginas PDF e conteúdo HTML.|

## **Renderização de apresentações**

Aspose.Slides renderiza slides e formas individuais como imagens PNG, JPEG, BMP, GIF, TIFF e SVG, e slides como metafiles EMF. Consulte [Converter slides de apresentação em imagens](/slides/pt/net/convert-slide/), [Renderizar um slide como imagem SVG](/slides/pt/net/render-a-slide-as-an-svg-image/) e [Criar miniaturas de forma](/slides/pt/net/create-shape-thumbnails/).

## **Recursos de conteúdo**

Aspose.Slides permite criar, ler e modificar quase todo o conteúdo de uma apresentação:

|**Área**|**O que você pode fazer**|
| :- | :- |
|[Slides](/slides/pt/net/presentation-slide/)|Adicionar, clonar, reordenar e remover slides; aplicar layouts e masters; organizar slides em seções; alterar o tamanho do slide.|
|[Design](/slides/pt/net/presentation-design/)|Definir fundos, cores de tema, cabeçalhos e rodapés, e fontes.|
|[Texto](/slides/pt/net/manage-text/)|Criar e editar quadros de texto, parágrafos e trechos; definir fontes, cores, marcadores e alinhamento; localizar e substituir texto.|
|[Formas](/slides/pt/net/powerpoint-shapes/)|Criar AutoShapes, linhas, conectores, formas agrupadas e quadros de imagem; definir posição, tamanho, contorno e preenchimento sólido, gradiente ou padrão; localizar uma forma pelo seu texto alternativo.|
|[Tabelas](/slides/pt/net/powerpoint-table/), [gráficos](/slides/pt/net/powerpoint-charts/), e [SmartArt](/slides/pt/net/powerpoint-smartart/)|Criar e editar tabelas, gráficos do Microsoft Office e diagramas SmartArt.|
|[Mídia](/slides/pt/net/manage-media-files/), [objetos OLE](/slides/pt/net/manage-ole/), e [controles ActiveX](/slides/pt/net/activex/)|Adicionar quadros de áudio e vídeo incorporados ou vinculados, incorporar objetos OLE e adicionar, modificar ou remover controles ActiveX.|
|[Notas](/slides/pt/net/presentation-notes/) e [comentários](/slides/pt/net/presentation-comments/)|Adicionar, ler e editar notas do apresentador e comentários de revisão.|
|[Animação](/slides/pt/net/powerpoint-animation/) e [transições](/slides/pt/net/slide-transition/)|Aplicar efeitos de animação a formas, definir transições de slide e configurar as opções de apresentação.|
|[Segurança](/slides/pt/net/presentation-security/)|Criptografar apresentações com senha, definir proteção contra gravação e trabalhar com assinaturas digitais.|
|[Macros VBA](/slides/pt/net/presentation-via-vba/)|Adicionar, extrair e remover módulos VBA em apresentações habilitadas para macro.|
|[Propriedades](/slides/pt/net/presentation-properties/)|Ler e editar propriedades do documento.|

## **FAQ**

**Preciso instalar o Microsoft PowerPoint no servidor ou PC para que a biblioteca funcione?**

Não. O PowerPoint não é necessário; Aspose.Slides é um mecanismo independente para criar, editar, converter e renderizar apresentações.

**Como funciona o multithreading? O processamento pode ser paralelizado?**

É seguro processar documentos diferentes em threads distintas; o mesmo objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) não deve ser usado por [múltiplas threads](/slides/pt/net/multithreading/) ao mesmo tempo.

**Senhas de arquivo e criptografia são suportadas?**

Sim. [Você pode](/slides/pt/net/password-protected-presentation/) abrir apresentações criptografadas, definir ou remover uma senha de abertura e gravação, e verificar o status de proteção.

**Preciso me preocupar com fontes em contêineres Linux?**

Sim. As fontes usadas nas suas apresentações, ou substitutas adequadas, devem estar instaladas no sistema para que o texto seja renderizado corretamente. Você também pode [especificar diretórios de fontes](/slides/pt/net/custom-font/) em sua aplicação. A [Instalação](/slides/pt/net/installation/) lista os pré‑requisitos Linux de cada pacote.

**Existem limitações na versão de avaliação?**

Sim. Sem uma [licença](/slides/pt/net/licensing/), Aspose.Slides adiciona uma marca d'água de avaliação a cada slide que salva e trunca o texto lido das apresentações. Uma [licença temporária de 30 dias](https://purchase.aspose.com/temporary-license/) está disponível para testes com todos os recursos.

**A importação de formatos externos para uma apresentação (PDF ou HTML para PPTX) é suportada?**

Sim. Você pode adicionar [páginas PDF e conteúdo HTML](/slides/pt/net/import-presentation/) a uma apresentação, transformando‑os em slides.