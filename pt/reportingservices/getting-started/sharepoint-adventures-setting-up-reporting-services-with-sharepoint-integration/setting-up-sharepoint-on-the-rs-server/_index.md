---
title: Configurando o SharePoint no Servidor RS
type: docs
weight: 40
url: /pt/reportingservices/setting-up-sharepoint-on-the-rs-server/
---
{{% alert color="primary" %}} 

Então, precisamos fazer o que fizemos para o SharePoint WFE. Primeiro, devemos passar pela instalação dos pré‑requisitos e, depois, iniciar a configuração do SharePoint. 

Para a configuração, escolhemos Farm de Servidor e uma instalação completa para corresponder ao meu SharePoint Box, já que não queremos uma instalação independente para o SharePoint. 

{{% /alert %}} 
### **Configuração do SharePoint**
No Assistente de Configuração do SharePoint, queremos conectar a uma farm existente. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**Figura 13**: Assistente de Configuração do SharePoint 

Em seguida, apontaremos para o banco de dados **SharePoint_Config** que nossa farm está usando. Se você não souber onde ele está, pode descobrir através do Central Admin em **System Settings -> Manager Servers in this farm.** 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**Figura 14**: Assistente de Configuração do SharePoint 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**Figura 15**: Assistente de Configuração do SharePoint 

Quando o assistente terminar, isso é tudo o que precisamos fazer na caixa do Report Server por enquanto. Ao voltar para a URL do ReportServer, veremos outro erro, mas isso ocorre porque ainda não o configuramos através do Central Administrator. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**Figura 16**: Erro do Report Server