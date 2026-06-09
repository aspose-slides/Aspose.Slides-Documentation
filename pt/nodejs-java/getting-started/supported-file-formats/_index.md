---
title: Formatos de Arquivo Suportados
type: docs
weight: 30
url: /pt/nodejs-java/supported-file-formats/
keywords:
  - formato de arquivo
  - formato suportado
  - PPT
  - POT
  - PPS
  - PPTX
  - POTX
  - PPSX
  - PPTM
  - PPSM
  - POTM
  - ODP
  - FODP
  - OTP
  - TIFF
  - EMF
  - PDF
  - XPS
  - JPEG
  - PNG
  - GIF
  - BMP
  - SVG
  - SWF
  - HTML
  - XAML
  - MD
  - XML
  - PowerPoint
  - OpenDocument
  - apresentação
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Descubra todos os formatos de arquivo que o Aspose.Slides para Node.js via Java pode abrir, salvar e converter — incluindo PPT, PPTX e ODP — com notas claras de suporte à importação/exportação."
---
## **Visão geral**

O Aspose.Slides suporta arquivos de apresentação do Microsoft PowerPoint 97 até o Office 365, incluindo o Microsoft PowerPoint para Mac. Este artigo lista as versões do PowerPoint suportadas pela biblioteca e fornece uma tabela de formatos de arquivo que podem ser carregados, salvos ou ambos.

O artigo também responde a perguntas comuns sobre conformidade PDF, incorporação de fontes, arquivos protegidos por senha, fontes personalizadas, fallback de fontes e opções de exportação XPS.

## **Versões do Microsoft PowerPoint suportadas**
- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for MAC
- Office 365

## **Formatos de arquivo suportados**
Esta tabela contém os formatos de arquivo que o Aspose.Slides para Node.js via Java pode carregar e salvar:

|**Formato**|**Descrição**|**Carregar**|**Salvar**|**Observações**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Apresentação do PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|Modelo do PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|Show do PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Apresentação PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|Modelo PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|Show PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Apresentação PowerPoint com macros habilitadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Show PowerPoint com macros habilitadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|Modelo PowerPoint com macros habilitadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|Apresentação OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|Modelo de Apresentação OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formato de Arquivo de Imagem Tag| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|Formato Metafile Aprimorado| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|Formato de Documento Portátil|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Especificação de Papel XML| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Grupo Conjunto de Especialistas em Fotografia| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|Gráficos de Rede Portáteis| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|Formato de Intercâmbio de Gráficos| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Independente de Dispositivo| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Gráficos Vetoriais Escaláveis| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Formato Web Pequeno| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|Linguagem de Marcação de Hipertexto|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|Linguagem de Marcação Aplicável Extensível| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|Apresentação XML do PowerPoint| |{{< emoticons/tick >}}| |

## **Perguntas frequentes**

**Posso salvar apresentações em PDF que atendam aos padrões de arquivamento e acessibilidade (PDF/A e PDF/UA)?**

Sim. O Aspose.Slides suporta exportação para PDF com níveis de conformidade como PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, bem como PDF/UA por meio da configuração [compliance](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pdfoptions/setcompliance/) nas [opções de exportação PDF](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pdfoptions/).

**A biblioteca suporta incorporação de fontes ao exportar para PDF, com controle detalhado sobre o que é incorporado?**

Sim. É possível controlar se as fontes são totalmente incorporadas ou subdefinidas (apenas glifos usados), especificar como as fontes de sistema comuns são tratadas e configurar o comportamento para texto ASCII através das [opções de exportação PDF](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pdfoptions/).

**Posso detectar se um arquivo está protegido por senha antes de carregá-lo?**

Sim. Usando a [API de inspeção baseada em fábrica](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/), você pode consultar um arquivo de apresentação para determinar se está protegido por senha sem abri‑lo completamente.

**Existem mecanismos de fallback de fontes e suporte a fontes personalizadas?**

Sim. A biblioteca suporta [carregamento](/slides/pt/nodejs-java/custom-font/) e [incorporação](/slides/pt/nodejs-java/embedded-font/) de fontes personalizadas e fornece [regras de fallback de fontes](/slides/pt/nodejs-java/fallback-font/) para evitar glifos ausentes durante a renderização e conversão.

**Posso exportar slides para XPS e existem opções para ajustar a saída XPS?**

Sim. A [exportação para XPS](/slides/pt/nodejs-java/convert-powerpoint-to-xps/) é suportada, e você pode ajustar as [opções de salvamento](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xpsoptions/) para controlar a qualidade e o conteúdo da saída do documento XPS.