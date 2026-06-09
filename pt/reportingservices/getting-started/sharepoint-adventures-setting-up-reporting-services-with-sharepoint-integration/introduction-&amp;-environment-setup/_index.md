---
title: Introdução &amp; Configuração do Ambiente
type: docs
weight: 10
url: /pt/reportingservices/introduction-&amp;-environment-setup/
---
{{% alert color="primary" %}} 

Houve consultas no passado sobre a Integração do Aspose.Slides para Reporting Services com o SharePoint. Neste artigo, focaremos no SharePoint 2010. Assume-se que já exista um ambiente de fazenda SharePoint configurado. Os exemplos que seguiremos neste artigo serão de um SharePoint Cloud completo, mas as etapas serão semelhantes para um SharePoint Foundation Server. Antes de prosseguir, vamos começar com alguma documentação chave que você pode usar como referência ao fazer isso: 

- [Visão geral da integração do Reporting Services e da tecnologia SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Configurando o Reporting Services para integração com SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Configuração do Ambiente**
A configuração que teremos consiste em **4 servidores**. Isso inclui um **Domain Controller**, um **SQL Server**, um **SharePoint Server** e um servidor para **Reporting Services**. Você pode optar por ter o SharePoint e o Reporting Services na mesma máquina.