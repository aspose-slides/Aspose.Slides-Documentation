---
title: Implantação e Ativação
type: docs
weight: 20
url: /pt/sharepoint/deployment-and-activation/
description: "O que a solução Aspose.Slides for SharePoint instala na farm quando é implantada e o que seu recurso de coleção de sites adiciona quando é ativado."
---
## **Implantação**

Durante a implantação, a solução Aspose.Slides for SharePoint:

- Instala seu assembly no Global Assembly Cache e adiciona entradas SafeControl ao arquivo **web.config**. No SharePoint 2010 e posteriores, isso é *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* ou *Aspose.Slides.SharePoint2016.dll* (o pacote SharePoint 2019 também instala *Aspose.Slides.SharePoint2016.dll*). No SharePoint 2007, é *Aspose.Slides.SharePointUI.dll*, junto com *Aspose.Slides.SharePoint.Deployment.dll*.
- Copia a página de conversão, suas imagens e demais arquivos de suporte para as pastas de instalação do SharePoint.
- Instala o recurso e o disponibiliza para ativação em coleções de sites.

## **Ativação**

Aspose.Slides for SharePoint é empacotado como um recurso de coleção de sites e pode ser ativado ou desativado em coleções de sites. Quando é ativado em uma coleção de sites, o recurso adiciona:

- No SharePoint 2010 e posteriores:
  - o item **Converter via Aspose.Slides** ao menu de documentos nas bibliotecas de documentos;
  - a guia de faixa de opções **Ferramentas Aspose** com o botão **Converter Slides**, que converte os documentos selecionados;
  - o item **Visualizar Slides** ao menu de arquivos PPT, PPTX, PPS e PPSX.
- No SharePoint 2007:
  - o item **Converter com Aspose.Slides** ao menu de documentos nas bibliotecas de documentos;
  - o item **Converter tudo com Aspose.Slides** ao menu **Ações** das bibliotecas de documentos.

No SharePoint 2007, a ativação também faz alterações no diretório virtual do aplicativo web pai da coleção de sites. Ela:

- Adiciona a página de configurações de conversão ao arquivo de mapa do site.
- Copia os arquivos de recursos necessários para a pasta App_GlobalResources no diretório virtual.

O programa de instalação ativa o recurso nas coleções de sites que você seleciona durante a [instalação](/slides/pt/sharepoint/installing-aspose-slides-for-sharepoint/).