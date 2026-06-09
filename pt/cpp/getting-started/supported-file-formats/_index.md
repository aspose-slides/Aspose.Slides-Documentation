---
title: Formatos de Arquivo Suportados
type: docs
weight: 20
url: /pt/cpp/supported-file-formats/
keywords:
- "formato de arquivo"
- "formato suportado"
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
- "apresentação"
- C++
- Aspose.Slides
description: "Descubra todos os formatos de arquivo que o Aspose.Slides para C++ pode abrir, salvar e converter — incluindo PPT, PPTX e ODP — com notas claras de suporte de importação/exportação."
---
## **Visão geral**

Aspose.Slides oferece suporte a arquivos de apresentação do Microsoft PowerPoint 97 até o Office 365, incluindo o Microsoft PowerPoint para Mac. Este artigo lista as versões do PowerPoint suportadas pela biblioteca e fornece uma tabela de formatos de arquivo que podem ser carregados, salvos ou ambos.

O artigo também responde a perguntas comuns sobre conformidade de PDF, incorporação de fontes, arquivos protegidos por senha, fontes personalizadas, fallback de fontes e opções de exportação XPS.

## **Versões suportadas do Microsoft PowerPoint**
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
Esta tabela contém os formatos de arquivo que o Aspose.Slides para С++ pode carregar e salvar:

|**Formato**|**Descrição**|**Carregar**|**Salvar**|**Observações**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Apresentação PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POT](https://docs.fileformat.com/presentation/pot/)|Modelo PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPS](https://docs.fileformat.com/presentation/pps/)|Show PowerPoint 97-2003|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Apresentação PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTX](https://docs.fileformat.com/presentation/potx/)|Modelo PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSX ](https://docs.fileformat.com/presentation/ppsx/)|Show PowerPoint|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|Apresentação PowerPoint habilitada para macro|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|Show PowerPoint habilitado para macro|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[POTM](https://docs.fileformat.com/presentation/potm/)|Modelo PowerPoint habilitado para macro|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[ODP/FODP](https://docs.fileformat.com/presentation/odp/)|Apresentação OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[OTP](https://docs.fileformat.com/presentation/otp/)|Modelo de apresentação OpenDocument|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[TIFF](https://docs.fileformat.com/image/tiff/)|Formato de Arquivo de Imagem Tag||{{< emoticons/tick >}}||
|[EMF](https://docs.fileformat.com/image/emf/)|Formato Metarquivo Avançado||{{< emoticons/tick >}}||
|[PDF](https://docs.fileformat.com/pdf/)|Formato de Documento Portátil|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|Especificação de Documento XML||{{< emoticons/tick >}}||
|[JPEG](https://docs.fileformat.com/image/jpeg/)|Formato JPEG (Joint Photographic Experts Group)||{{< emoticons/tick >}}||
|[PNG](https://docs.fileformat.com/image/png/)|Gráficos de Rede Portáteis||{{< emoticons/tick >}}||
|[GIF](https://docs.fileformat.com/image/gif/)|Formato de Intercâmbio de Gráficos||{{< emoticons/tick >}}||
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Independente de Dispositivo||{{< emoticons/tick >}}||
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Gráficos Vetoriais Escaláveis||{{< emoticons/tick >}}||
|[SWF](https://docs.fileformat.com/page-description-language/swf/)||{{< emoticons/tick >}}||
|[HTML](https://docs.fileformat.com/web/html/)|Linguagem de Marcação de Hipertexto|{{< emoticons/tick >}}|{{< emoticons/tick >}}||
|[XAML](https://docs.fileformat.com/web/xaml/)|Linguagem de Marcação de Aplicação Extensível||{{< emoticons/tick >}}||
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown||{{< emoticons/tick >}}||
|[XML](https://docs.fileformat.com/web/xml/)|Apresentação PowerPoint XML||{{< emoticons/tick >}}||

## **Perguntas frequentes**

**Posso salvar apresentações em PDF que atendam aos padrões de arquivamento e acessibilidade (PDF/A e PDF/UA)?**

Sim. Aspose.Slides oferece suporte à exportação para PDF com níveis de conformidade como PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, bem como PDF/UA através da configuração [compliance](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/set_compliance/) em [PDF export options](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/).

**A biblioteca oferece suporte à incorporação de fontes ao exportar para PDF, com controle detalhado sobre o que é incorporado?**

Sim. Você pode controlar se as fontes são totalmente incorporadas ou subdefinidas (apenas glifos usados), especificar como as fontes de sistema comuns são tratadas e configurar o comportamento para texto ASCII através das [PDF export options](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pdfoptions/).

**Posso detectar se um arquivo está protegido por senha antes de carregá-lo?**

Sim. Usando a [factory-based inspection API](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentationfactory/), você pode consultar um arquivo de apresentação para determinar se ele está protegido por senha sem abri‑lo completamente.

**Existem mecanismos de fallback de fontes e suporte a fontes personalizadas?**

Sim. A biblioteca oferece suporte ao [loading](/slides/pt/cpp/custom-font/) e [embedding](/slides/pt/cpp/embedded-font/) de fontes personalizadas e fornece regras de [fallback de fontes](/slides/pt/cpp/fallback-font/) para evitar ausência de glifos durante a renderização e conversão.

**Posso exportar slides para XPS e há opções para ajustar a saída XPS?**

Sim. [Export to XPS](/slides/pt/cpp/convert-powerpoint-to-xps/) é suportado, e você pode ajustar as [save options](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/xpsoptions/) relevantes para controlar a qualidade e o conteúdo do documento XPS.