---
title: Implantação e Ativação
type: docs
weight: 20
url: /pt/sharepoint/deployment-and-activation/
---
## **Implantação**
Durante a implantação, Aspose.Slides for SharePoint: 

- Instala o **Aspose.Slides.SharePoint.dll** no Global Assembly Cache e adiciona uma entrada SafeControl ao arquivo **web.config**.
- Instala o manifesto de recurso e outros arquivos necessários nos diretórios apropriados.
- Registra o recurso no banco de dados do SharePoint e o torna disponível para ativação no escopo do recurso.
## **Ativação**
Aspose.Slides for SharePoint é empacotado como um recurso de nível de site (coleção de sites) e pode ser ativado ou desativado em coleções de sites. Durante a ativação, o recurso faz algumas alterações no diretório virtual da aplicação web pai da coleção de sites. Ele: 

- Adiciona a página de configurações de conversão ao arquivo sitemap.
- Copia os arquivos de recursos necessários para a pasta App_GlobalResources no diretório virtual.