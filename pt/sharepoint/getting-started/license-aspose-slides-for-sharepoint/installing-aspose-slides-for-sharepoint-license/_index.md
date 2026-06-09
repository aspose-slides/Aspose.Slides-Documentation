---
title: Instalando a licença Aspose.Slides para SharePoint
type: docs
weight: 10
url: /pt/sharepoint/installing-aspose-slides-for-sharepoint-license/
---
{{% alert color="primary" %}} 

Quando estiver satisfeito com a avaliação, você pode [purchase a license](https://purchase.aspose.com/buy). Antes de comprar, certifique‑se de que entende e concorda com os termos de assinatura da licença. A licença é enviada por e‑mail quando o pedido for pago.

A licença é um arquivo ZIP que contém um pacote de solução SharePoint padrão. O arquivo contém:

- Aspose.Slides.SharePoint.License.wsp – o arquivo do pacote de solução SharePoint. A licença é empacotada como uma solução SharePoint para facilitar a implantação e a retirada em uma fazenda de servidores.
- readme.txt – instruções de instalação da licença.

{{% /alert %}} 
## **Implantando a Licença**
A instalação da licença é feita a partir do console do servidor via **stsadm.exe**.

{{% alert color="primary" %}} 

Os caminhos foram omitidos na seção a seguir para clareza.

{{% /alert %}} 

Execute as etapas a seguir para implantar a licença do Aspose.Slides for SharePoint:

1. Execute stsadm para adicionar a solução ao repositório de soluções SharePoint: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. Implante a solução em todos os servidores da fazenda: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. Execute trabalhos de temporizador administrativos para concluir a implantação imediatamente: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

Você receberá um aviso ao executar a etapa de implantação se o serviço Windows SharePoint Services Administration não estiver em execução. **stsadm.exe** depende desse serviço e do Windows SharePoint Timer Service para replicar os dados da solução na fazenda. Se esses serviços não estiverem em execução na sua fazenda de servidores, pode ser necessário implantar a licença em cada servidor. 

{{% /alert %}} 
## **Testar a Licença**
Para testar se a licença foi instalada corretamente, converta qualquer documento para um novo formato. Se não houver marca d'água de avaliação no documento, a licença foi ativada com sucesso.