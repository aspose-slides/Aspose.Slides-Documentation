---
title: Instalar com Instalador MSI
type: docs
weight: 20
url: /pt/reportingservices/install-with-msi-installer/
keywords:
- Instalador MSI
- Instalação
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Instale Aspose.Slides for Reporting Services com seu instalador MSI: o que o instalador precisa, o que ele altera em cada instância do servidor de relatórios e como verificar o resultado."
---
## **Instalação**

O instalador MSI é a maneira mais simples de instalar Aspose.Slides for Reporting Services. Ele requer .NET Framework 3.5 e direitos de administrador no servidor de relatórios; consulte [Requisitos de Sistema](/slides/pt/reportingservices/system-requirements/).

1. Baixe o instalador MSI, *Aspose.Slides for Reporting Services XX.XX*, da [página de download](https://releases.aspose.com/slides/reportingservices/) e copie‑o para o servidor de relatórios.
1. Execute‑o como administrador. Se o .NET Framework 3.5 estiver ausente, o instalador para com uma mensagem; instale os recursos do .NET Framework 3.5 e execute‑o novamente.
1. Aceite o contrato de licença.
1. Na página **Custom Setup**, a árvore de recursos lista cada instância do SQL Server Reporting Services e do Power BI Report Server que o instalador detecta na máquina. Para deixar uma instância inalterada, clique em seu ícone e selecione **Entire feature will be unavailable**. As edições Express não suportam extensões de renderização, portanto não selecione uma instância Express. O instalador oculta instâncias Express do SQL Server 2016 e anteriores.
1. Selecione **Next**, e depois **Install**.

O recurso opcional **Rpl Export** não é selecionado por padrão. Ele adiciona uma extensão oculta que salva relatórios no formato RPL, o que é útil quando você envia um relatório de problema para a Aspose; consulte [Exportando Relatórios para o Formato RPL](/slides/pt/reportingservices/exporting-reports-to-rpl-format/).

## **O que o Instalador Modifica**

O instalador mantém seus arquivos em *Aspose\Aspose.Slides for Reporting Services* na pasta Program Files — *Program Files (x86)* em Windows de 64 bits, porque o instalador é um pacote de 32 bits. Em seguida, para cada instância selecionada, ele:

- copia *Aspose.Slides.ReportingServices.dll* para a pasta *ReportServer\bin* da instância — a compilação para SQL Server 2005, ou a compilação para SQL Server 2008 e posteriores e Power BI Report Server;
- adiciona seis extensões de renderização — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS e ASODP — ao elemento `<Render>` de *rsreportserver.config*;
- adiciona um grupo de código que concede total confiança ao assembly em *rssrvpolicy.config*;
- salva uma cópia de cada arquivo de configuração que ele altera, com *.bak* acrescentado ao nome do arquivo.

[Instale Manualmente](/slides/pt/reportingservices/install-manually/) mostra essas alterações passo a passo.

Se uma instância não puder ser configurada, o instalador a nomeia em uma mensagem e grava os detalhes em *rserrors<date>.log* na pasta de instalação. Instale a extensão nessa instância manualmente.

## **Verifique a Instalação**

Abra um relatório paginado no portal web (Report Manager no SQL Server 2014 e anteriores) e abra a lista **Export**. Agora ela inclui estes formatos:

- PPT - Apresentação PowerPoint via Aspose.Slides
- PPS - Apresentação de Slides PowerPoint via Aspose.Slides
- PPTX - Apresentação PowerPoint 2007 via Aspose.Slides
- PPSX - Apresentação de Slides PowerPoint 2007 via Aspose.Slides
- ODP - Apresentação OpenDocument via Aspose.Slides
- XPS - via Aspose.Slides

Sem uma licença, os arquivos exportados apresentam uma marca d'água de avaliação; consulte [Licenciamento](/slides/pt/reportingservices/license-aspose-slides-for-reporting-services/).

## **Quando Instalar Manualmente**

Instale a extensão [manualmente](/slides/pt/reportingservices/install-manually/) em vez disso quando:

- o instalador não puder configurar uma instância, por exemplo devido às configurações de segurança no servidor;
- após uma atualização, você quiser substituir apenas o assembly em vez de desinstalar a versão antiga e executar o novo instalador.

Desinstalar o produto remove o assembly e as entradas de configuração de cada instância.