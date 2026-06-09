---
title: Pré-requisitos de Instalação
type: docs
weight: 20
url: /pt/reportingservices/installation-prerequisites/
---
{{% alert color="primary" %}} 

Os pré-requisitos a seguir precisam ser atendidos antes de prosseguirmos com a instalação. 

{{% /alert %}} 
## **Complemento Reporting Services para SharePoint**
O **Complemento Reporting Services para SharePoint** é um dos componentes chave para que a Integração funcione corretamente. O Complemento deve ser instalado em qualquer **Web Front End (WFE)** que esteja na sua fazenda SharePoint, juntamente com o servidor Central Admin. Uma das novidades com SQL 2008 R2 & SharePoint 2010 é que o Complemento 2008 R2 agora é um pré-requisito para a instalação do SharePoint. Isso significa que o Complemento RS será instalado quando você iniciar a instalação do SharePoint. Ele está exibido e realçado na figura abaixo. Isso realmente evita muitos problemas que vimos com SP 2007 e RS 2008 ao instalar o Complemento. 

![todo:image_alt_text](installation-prerequisites_1.png)


**Figura 1**: Complemento Reporting Services para SharePoint 
## **Autenticação no SharePoint**
Antes de mergulhar nas partes de Integração do RS, é importante cuidar de como você configura seu **Site** na fazenda SharePoint. Mais especificamente, como você configura a autenticação para o Site; se será **Clássica** ou **Claims**. Essa escolha é importante no início. Não acredito que você possa mudar essa opção depois de concluída. Caso consiga mudar, não será um processo simples. 

{{% alert color="primary" %}} 

Reporting Services 2008 R2 NÃO é compatível com Claims 

{{% /alert %}} 

Mesmo que você escolha seu site SharePoint para usar **Claims**, o próprio Reporting Services não reconhece Claims. Isso afeta como a autenticação funciona com o Reporting Services. Então, qual é a diferença do ponto de vista do Reporting Services? Tudo se resume a se você deseja encaminhar as credenciais do usuário para a fonte de dados. 

***Clássica*** - Pode usar Kerberos e encaminhar as credenciais do usuário para sua fonte de dados de back‑end (será necessário usar Kerberos para isso). 

***Claims*** - Um token Claims é usado e não um token Windows. O RS sempre usará Autenticação Confiável nesse cenário e terá acesso apenas ao token SPUser. Você precisará armazenar suas credenciais dentro da fonte de dados. 

Por enquanto, queremos focar apenas na configuração do RS. Neste ponto o SharePoint está instalado na caixa SharePoint e configurado com um **Site de Autenticação Clássica** na **porta 80**. Além disso, no servidor RS eu **acabei de instalar o Reporting Services** e pronto.