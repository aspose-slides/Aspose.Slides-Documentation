---
title: Configuração do Reporting Services no SharePoint
type: docs
weight: 50
url: /pt/reportingservices/reporting-services-sharepoint-configuration/
---
{{% alert color="primary" %}} 

Agora que o SharePoint está instalado e configurado no servidor RS e o RS foi configurado através do Reporting Services Configuration Manager, podemos passar para a configuração no Central Admin. O RS 2008 R2 realmente simplificou esse processo. Antes era necessário um processo de 3 etapas para que isso funcionasse. Agora temos apenas uma etapa. 

Precisamos acessar o site do Central Administrator e, em seguida, entrar em General Application Settings. Na parte inferior veremos Reporting Services. 

{{% /alert %}} 

![todo:image_alt_text](reporting-services-sharepoint-configuration_1.png)


**Figure 17**: Configuração do SharePoint 

{{% alert color="primary" %}} 

Clique em **Reporting Services Integration**. 

{{% /alert %}} 
## **URL do Serviço Web**
Forneceremos a URL do Report Server que encontramos no Reporting Services Configuration Manager. 
## **Modo de Autenticação**
Também selecionaremos um Modo de Autenticação. O link da MSDN a seguir detalha o que são essas opções. 
[Security Overview for Reporting Services in SharePoint Integrated Mode](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb283324(v=sql.105)) 

Em resumo, se o seu site estiver usando **Claims Authentication**, você sempre usará Trusted Authentication, independentemente da escolha aqui. Se quiser repassar credenciais do Windows, escolha Windows Authentication. Para Trusted Authentication, repassaremos o token SPUser e não dependeremos da credencial do Windows. 

Você também deverá usar Trusted Authentication se tiver configurado seus sites em Classic Mode para NTLM e o RS estiver configurado para NTLM. Kerberos seria necessário para usar Windows Authentication e repassar isso para sua fonte de dados. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_2.png)


**Figure 18**: Definindo credenciais da integração do Reporting Services
## **Ativar Recurso**
Isso oferece a opção de ativar o Reporting Services em todas as coleções de sites ou selecionar quais você deseja ativar. Isso significa basicamente quais sites poderão usar o Reporting Services. 
Quando concluído, você deverá ver a figura a seguir. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_3.png)


**Figure 19**: Integração bem‑sucedida do Reporting Services com o ambiente SharePoint 

Voltando para a URL do Report Server mostrada na Figura 14, devemos ver algo semelhante à figura a seguir. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_4.png)


**Figure 20**: Verificação bem‑sucedida do Reporting Services com o ambiente SharePoint 

{{% alert color="primary" %}} 

Se o seu site SharePoint estiver configurado para SSL, ele não aparecerá nesta lista. É um problema conhecido e não indica falha. Seus relatórios ainda devem funcionar. 

{{% /alert %}} 

Agora estamos prontos para usar o Reporting Services no SharePoint 2010. Assim como na versão anterior, temos um recurso (ativado ao configurar Reporting Services Integration) em “Site Collection Feature”. A instalação também adicionou 3 tipos de conteúdo ao nosso site. Na Figura 21 podemos ver 2 desses tipos de conteúdo adicionados a uma biblioteca de documentos para criar um relatório personalizado, como mostra a Figura 21. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_5.png)


**Figure 21**: Report Builder 

O “**Reporter Builder**” é um ActiveX que precisamos baixar no servidor, como mostra a Figura 22. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_6.png)


**Figure 22**: Baixar e instalar o Report Builder 

Quando o download terminar, execute o **Report Builder**. Agora estamos prontos para projetar nosso primeiro relatório, como mostra a Figura 23. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_7.png)

**Figure 23**: Assistente de criação de novo relatório do Report Builder 

Depois de criar nosso relatório, podemos salvá‑lo na biblioteca de documentos criada para armazenar relatórios no SharePoint 2010. 

O outro tipo de conteúdo deve ser usado para criar conexões compartilhadas como fonte de dados e salvá‑las em uma biblioteca de documentos no SharePoint. Podemos criar uma biblioteca de documentos, adicionar esse tipo de conteúdo e, assim, ter nossas conexões disponíveis para alterar a fonte de dados dos relatórios. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_8.png)


**Figure 24**: Exportação bem‑sucedida do relatório para o Report Server