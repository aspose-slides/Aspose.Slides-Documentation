---
title: Visão geral dos recursos
type: docs
weight: 104
url: /pt/java/features-overview/
keywords:
- recursos
- plataformas suportadas
- formatos de arquivo
- conversão
- renderização
- conteúdo da apresentação
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Revise o que o Aspose.Slides for Java cobre antes de avaliá-lo: plataformas suportadas, formatos de arquivo, renderização de slides e o conteúdo que você pode criar e editar."
---
## **Visão geral**

Aspose.Slides for Java é uma biblioteca de classes para criar, ler, editar, converter e renderizar apresentações PowerPoint e OpenDocument. Não possui interface de usuário própria e não requer Microsoft PowerPoint ou Microsoft Office. Este artigo resume o que a biblioteca cobre e fornece links para os artigos que descrevem cada área.

## **Plataformas suportadas**

Aspose.Slides for Java é um único arquivo JAR, publicado no repositório Maven da Aspose com o classificador `jdk16`. É escrito em Java puro: o JAR não contém bibliotecas nativas e não depende de outros pacotes.

- **Java:** Java 8 ou posterior. Aspose.Slides for Java 26.9 e versões anteriores também são compatíveis com Java 6 e 7, o que a versão 26.10 não suporta mais; veja as [notas de versão 26.9](https://releases.aspose.com/slides/pt/java/release-notes/2026/aspose-slides-for-java-26-9-release-notes/).
- **Sistemas operacionais:** qualquer sistema operacional com runtime Java, como Windows, Linux e macOS. No Linux, a biblioteca fontconfig e ao menos uma fonte devem estar instaladas.

[Instalação](/slides/pt/java/installation/) mostra como adicionar a biblioteca a um projeto e lista os pré‑requisitos para Linux. [Requisitos do sistema](/slides/pt/java/system-requirements/) lista as plataformas suportadas em detalhe.

## **Formatos de arquivo e conversões**

Aspose.Slides abre e salva apresentações PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP e PowerPoint XML. Importa conteúdo PDF e HTML em slides e salva apresentações como PDF, XPS, HTML, HTML5, TIFF, GIF animado, SWF, Markdown e XAML. [Formatos de arquivo suportados](/slides/pt/java/supported-file-formats/) lista cada formato com a API que o lê ou grava.

|**Recurso**|**Descrição**|
| :- | :- |
|[PPT e PPTX](/slides/pt/java/ppt-vs-pptx/)|Ler e gravar tanto o formato binário PowerPoint 97‑2003 quanto o formato Office Open XML.|
|[Conversão de PPT para PPTX](/slides/pt/java/convert-ppt-to-pptx/)|Converter apresentações PPT legadas para PPTX.|
|[Conversão de ODP para PPTX](/slides/pt/java/convert-odp-to-pptx/)|Abrir e salvar apresentações ODP, OTP e FODP, e converter apresentações ODP para PPTX.|
|[Portable Document Format (PDF)](/slides/pt/java/convert-powerpoint-to-pdf/)|Exportar apresentações para PDF, incluindo documentos PDF/A e PDF/UA.|
|[XML Paper Specification (XPS)](/slides/pt/java/convert-powerpoint-to-xps/)|Exportar apresentações para documentos XPS.|
|[Tagged Image File Format (TIFF)](/slides/pt/java/convert-powerpoint-to-tiff/)|Exportar apresentações para imagens TIFF multipágina, uma página por slide.|
|[HTML](/slides/pt/java/convert-powerpoint-to-html/)|Exportar apresentações para HTML e HTML5.|
|[Importação de PDF e HTML](/slides/pt/java/import-presentation/)|Criar slides a partir de páginas PDF e conteúdo HTML.|

## **Renderização de apresentações**

Aspose.Slides renderiza slides e formas individuais como imagens PNG, JPEG, BMP, GIF, TIFF e SVG, e slides como metafiles EMF. Veja [Converter slides de apresentação em imagens](/slides/pt/java/convert-slide/), [Renderizar slides de apresentação como imagens SVG](/slides/pt/java/render-a-slide-as-an-svg-image/), e [Criar miniaturas de formas de apresentação](/slides/pt/java/create-shape-thumbnails/).

## **Recursos de conteúdo**

Aspose.Slides permite criar, ler e modificar quase todo o conteúdo de uma apresentação:

|**Área**|**O que você pode fazer**|
| :- | :- |
|[Slides](/slides/pt/java/presentation-slide/)|Adicionar, clonar, reorganizar e remover slides; aplicar layouts e mestres; organizar slides em seções; alterar o tamanho do slide.|
|[Design](/slides/pt/java/presentation-design/)|Definir planos de fundo, cores de tema, cabeçalhos e rodapés, e fontes.|
|[Texto](/slides/pt/java/manage-text/)|Criar e editar quadros de texto, parágrafos e trechos; definir fontes, cores, marcadores e alinhamento; localizar e substituir texto.|
|[Formas](/slides/pt/java/powerpoint-shapes/)|Criar AutoShapes, linhas, conectores, formas agrupadas e quadros de imagem; definir posição, tamanho, linha e preenchimento sólido, gradiente ou padrão; localizar uma forma pelo seu texto alternativo.|
|[Tabelas](/slides/pt/java/powerpoint-table/), [gráficos](/slides/pt/java/powerpoint-charts/), e [SmartArt](/slides/pt/java/powerpoint-smartart/)|Criar e editar tabelas, gráficos do Microsoft Office e diagramas SmartArt.|
|[Mídia](/slides/pt/java/manage-media-files/), [objetos OLE](/slides/pt/java/manage-ole/), e [controles ActiveX](/slides/pt/java/activex/)|Adicionar quadros de áudio e vídeo incorporados ou vinculados, incorporar objetos OLE e adicionar, modificar ou remover controles ActiveX.|
|[Notas](/slides/pt/java/presentation-notes/) e [comentários](/slides/pt/java/presentation-comments/)|Adicionar, ler e editar notas do apresentador e comentários de revisão.|
|[Animação](/slides/pt/java/powerpoint-animation/) e [transições](/slides/pt/java/slide-transition/)|Aplicar efeitos de animação a formas, definir transições de slide e configurar as opções de apresentação.|
|[Segurança](/slides/pt/java/presentation-security/)|Criptografar apresentações com senha, definir proteção contra gravação e trabalhar com [assinaturas digitais](/slides/pt/java/digital-signature-in-powerpoint/).|
|[Macros VBA](/slides/pt/java/presentation-via-vba/)|Adicionar, extrair e remover módulos VBA em apresentações com macro habilitada.|
|[Propriedades](/slides/pt/java/presentation-properties/)|Ler e editar propriedades do documento.|

## **Perguntas frequentes**

**Preciso instalar o Microsoft PowerPoint no servidor ou PC para que a biblioteca funcione?**

Não. O PowerPoint não é necessário; o Aspose.Slides é um mecanismo independente para criar, editar, converter e renderizar apresentações.

**Como funciona o multithreading? O processamento pode ser paralelizado?**

É seguro processar documentos diferentes em threads distintas; o mesmo objeto [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) não deve ser usado por [várias threads](/slides/pt/java/multithreading/) ao mesmo tempo.

**Senhas de arquivos e criptografia são suportadas?**

Sim. [Você pode](/slides/pt/java/password-protected-presentation/) abrir apresentações criptografadas, definir ou remover uma senha de abertura e gravação, e verificar o status de proteção.

**Preciso me preocupar com fontes em contêineres Linux?**

Sim. No Linux, a biblioteca fontconfig e ao menos uma fonte devem estar instaladas, e as fontes usadas nas suas apresentações, ou substitutos adequados, precisam estar instaladas para que o texto seja renderizado corretamente. Você também pode [especificar diretórios de fontes](/slides/pt/java/custom-font/) em sua aplicação. Veja [Instalação](/slides/pt/java/installation/#linux).

**Existem limitações na versão de avaliação?**

Sim. Sem uma [licença](/slides/pt/java/licensing/), o Aspose.Slides adiciona uma marca d'água de avaliação a cada slide que salva e trunca o texto que seu código lê através da API. Uma [licença temporária de 30 dias](https://purchase.aspose.com/temporary-license/) está disponível para testes de todos os recursos.

**A importação de formatos externos para uma apresentação (PDF ou HTML para PPTX) é suportada?**

Sim. Você pode adicionar [páginas PDF e conteúdo HTML](/slides/pt/java/import-presentation/) a uma apresentação, transformando-os em slides.