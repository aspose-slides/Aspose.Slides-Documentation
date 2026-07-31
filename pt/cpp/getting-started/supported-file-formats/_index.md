---
title: Formatos de Arquivo Suportados
type: docs
weight: 20
url: /pt/cpp/supported-file-formats/
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
- C++
- Aspose.Slides
description: "Descubra todos os formatos de arquivo que o Aspose.Slides para C++ pode abrir, salvar e converter — incluindo PPT, PPTX e ODP — com notas claras de suporte à importação/exportação."
---
## **Visão geral**

Aspose.Slides suporta arquivos de apresentação do Microsoft PowerPoint 97 até Office 365, incluindo Microsoft PowerPoint para Mac. Este artigo lista as versões do PowerPoint suportadas pela biblioteca e fornece uma tabela de formatos de arquivo que podem ser carregados, salvos ou ambos.

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
- Microsoft PowerPoint para MAC
- Office 365

## **Formatos de arquivo suportados**
Esta tabela contém os formatos de arquivo que o Aspose.Slides for C++ pode carregar e salvar:

|**Formato**|**Descrição**|**Carregar**|**Salvar**|**Observações**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Apresentação PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|Modelo PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|Apresentação automática PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Apresentação PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|Modelo PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|Apresentação automática PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Apresentação PowerPoint com macros ativadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Apresentação automática PowerPoint com macros ativadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|Modelo PowerPoint com macros ativadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|Apresentação OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[OTP](https://docs.fileformat.com/presentation/otp/)|Modelo de apresentação OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formato de arquivo de imagem Tag Image File Format| |{{< emoticons/tick >}}| |
|[EMF](https://docs.fileformat.com/image/emf/)|Formato Enhanced Metafile| |{{< emoticons/tick >}}| |
|[PDF](https://docs.fileformat.com/pdf/)|Formato de Documento Portátil|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Especificação XML Paper| |{{< emoticons/tick >}}| |
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Joint Photographic Experts Group| |{{< emoticons/tick >}}| |
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics| |{{< emoticons/tick >}}| |
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format| |{{< emoticons/tick >}}| |
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap independente de dispositivo| |{{< emoticons/tick >}}| |
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics| |{{< emoticons/tick >}}| |
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format| |{{< emoticons/tick >}}| |
|[HTML](https://docs.fileformat.com/web/html/)|Linguagem de Marcação de Hipertexto|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language| |{{< emoticons/tick >}}| |
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown| |{{< emoticons/tick >}}| |
|[XML](https://docs.fileformat.com/web/xml/)|Apresentação XML do PowerPoint| |{{< emoticons/tick >}}| |

## **Perguntas frequentes**

**Posso salvar apresentações em PDF que atendam aos padrões de arquivamento e acessibilidade (PDF/A e PDF/UA)?**

Sim. Aspose.Slides suporta exportação para PDF com níveis de conformidade como PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, bem como PDF/UA através da configuração [compliance](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/set_compliance/) em [opções de exportação PDF](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/).

**A biblioteca suporta incorporação de fontes ao exportar para PDF, com controle detalhado sobre o que é incorporado?**

Sim. Você pode controlar se as fontes são totalmente incorporadas ou subdefinidas (apenas glifos usados), especificar como fontes de sistema comuns são tratadas e configurar o comportamento para texto ASCII através das [opções de exportação PDF](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/).

**Posso detectar se um arquivo está protegido por senha antes de realmente carregá‑lo?**

Sim. Usando a [API de inspeção baseada em fábrica](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentationfactory/), você pode consultar um arquivo de apresentação para determinar se está protegido por senha sem abri‑lo completamente.

**Existem mecanismos de fallback de fonte e suporte a fontes personalizadas?**

Sim. A biblioteca suporta [carregamento](/slides/pt/cpp/custom-font/) e [incorporação](/slides/pt/cpp/embedded-font/) de fontes personalizadas e fornece [regras de fallback de fonte](/slides/pt/cpp/fallback-font/) para impedir glifos ausentes durante a renderização e conversão.

**Posso exportar slides para XPS e há opções para ajustar a saída XPS?**

Sim. [Exportar para XPS](/slides/pt/cpp/convert-powerpoint-to-xps/) é suportado, e você pode ajustar as [opções de salvamento relevantes](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/xpsoptions/) para controlar a qualidade e o conteúdo do documento XPS.